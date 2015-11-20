using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDiceHomework
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)//standard run
            {

            }else //first run
            {
                LabelBalance.Text = "5";                //initial amount of money
                Image1.ImageUrl = "/img/dice-1.jpg";    //some default images
                Image2.ImageUrl = "/img/dice-6.jpg";    

                Image1.Height = 100;                    //resizing images   
                Image2.Height = 100;

                LabelResults.Text = "Welcome! Select your bet and press the button to play.";           //relabel result
                ButtonReset.Visible = false;            //hides the reset button    
                    
                RadioButtonListBetAmount.SelectedIndex = 0; //set a default bet to the minimum
            }
        }

        // button click methods //
        //  roll the dice!
        protected void ButtonBet_Click(object sender, EventArgs e)
        {
            int diceOneValue, diceTwoValue, balance, inputBet; //variables to hold current dice

            //time to do accounting
            //get balance value from label
            balance = Convert.ToInt32(LabelBalance.Text);
            //get bet amount
            inputBet = Convert.ToInt32(RadioButtonListBetAmount.SelectedValue);

            if (balance<inputBet)
            {
                effectPoor(); //sad sad... your money is too low
            }
            else //process the round
            {
                //use .NET to get a random number
                Random rng = new Random();
                diceOneValue = rng.Next(1, 7);
                diceTwoValue = rng.Next(1, 7);

                //now update images to reflect dice values
                Image1.ImageUrl = "/img/dice-" + diceOneValue.ToString() + ".jpg";
                Image2.ImageUrl = "/img/dice-" + diceTwoValue.ToString() + ".jpg";

                //get the result of win or loss
                int res = winLossCheck(diceOneValue, diceTwoValue);

                //update the result pane
                LabelResults.Text = winLossResponse(res);
                //LabelResults.Visible = true;              //disabled because I put an introduction in the label


                //affect balance by scale
                balance = (balance + (inputBet * res));
                LabelBalance.Text = balance.ToString();
                LabelBalance.Visible = true;

                //check for no money
                if (balance <= 0)
                {
                    effectLoss();
                }
            }
        }

        //  resets the page
        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        //this method is a lose/draw/win comparator -1/0/1
        protected int winLossCheck(int d1, int d2)
        {
            if (d1 == d2)
            {
                return 1;   //pl win, skip math
            }

            //we now do a calculation
            int r = d1 + d2; //gets result of multiply

            //do we have a winning number?
            if (r == 7 || r == 11)
            {
                return 1;   //pl won
            }
            else //so sad =[
            {
                return -1;  //pl loss
            }
        }

        //this method returns a method based on a lose/draw/win comparator
        protected string winLossResponse(int r)
        {
            if(r==1)
            {
                LabelResults.ForeColor = System.Drawing.Color.ForestGreen;
                return "You won the round!";
            }
            else if(r==-1)
            {
                LabelResults.ForeColor = System.Drawing.Color.Firebrick;
                return "You lost the round.";
            }
            else
            {
                return "It was a draw...";
            }
        }

        //  these are effect methods //
        //when you lose, show these things
        protected void effectLoss()
        {
            ButtonBet.Visible = false;
            ButtonReset.Visible = true;
            LabelResults.Text = "BUSTED!!!";
            LabelResults.ForeColor = System.Drawing.Color.Maroon;
        }

        //when try to bet more than you have, show these things
        protected void effectPoor()
        {
            LabelResults.Text = "You don't have enough money for that bet.";
            LabelResults.ForeColor = System.Drawing.Color.OrangeRed;
        }
    }
}