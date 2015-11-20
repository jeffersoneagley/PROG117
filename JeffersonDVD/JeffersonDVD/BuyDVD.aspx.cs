using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDVD
{
    public partial class BuyDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID.Visible = false; // only show this after we create it
            DVDIDlabel.Text = Request.QueryString["id"];
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtitle, DVDprice FROM DVDtable WHERE DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = Convert.ToInt32(Request.QueryString["id"]); // get the passed DVDID
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    TitleLabel.Text = reader["DVDtitle"].ToString();
                    PriceLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(reader["DVDprice"]), 2));
                }
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error loading the DVD info ";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            long insertedId = 0;
            SqlConnection conn;
            SqlCommand comm;
            SqlCommand comm2;
            SqlCommand comm3;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);

            if (InputCustNumberTextBox.Text.Length < 1) // add this and its  {   }
            {
                // update the Customers table

                comm = new SqlCommand("INSERT INTO Customers (FirstName, LastName)" +
                    " VALUES (@FirstName, @LastName ); SELECT SCOPE_IDENTITY()", conn);
                comm.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@FirstName"].Value = FirstNameTextBox.Text;
                comm.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@LastName"].Value = LastNameTextBox.Text;
                try
                {
                    conn.Open();
                    insertedId = Convert.ToInt64(comm.ExecuteScalar()); // new db request that returns a value (the new primary key)
                    UserID.Text = Convert.ToString(insertedId);
                    UserID.Visible = true;
                }
                catch
                {
                    dbErrorLabel.Text = "Database error adding customer. <br/>";
                }
                finally
                {
                    conn.Close();
                }
                InputCustNumberTextBox.Text = Convert.ToString(insertedId); // add this one line
            }
            else // add these 4 lines
            {
                insertedId = Convert.ToInt64(InputCustNumberTextBox.Text);
            }


        /* 
        * Update the Orders table
        */
        comm2 = new SqlCommand("INSERT INTO Orders (CustomerID)" +
                " VALUES (@CustomerID); SELECT SCOPE_IDENTITY()", conn);
            comm2.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
            comm2.Parameters["@CustomerID"].Value = insertedId;
            try
            {
                conn.Open();
                insertedId = Convert.ToInt64(comm2.ExecuteScalar());
            }
            catch
            {
                dbErrorLabel.Text = "Database error adding order. <br/>";
            }
            finally
            {
                conn.Close();
            }

            /*
            * update the DVDsOrdered DB
            */ 
            comm3 = new SqlCommand("INSERT INTO DVDsOrdered (OrderID, DVDID)" +
                  " VALUES (@OrderID, @DVDID); SELECT SCOPE_IDENTITY()", conn);
            comm3.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
            comm3.Parameters["@OrderID"].Value = insertedId;
            comm3.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm3.Parameters["@DVDID"].Value = Convert.ToInt32(DVDIDlabel.Text);
            try
            {
                conn.Open();
                insertedId = Convert.ToInt64(comm3.ExecuteScalar());
            }
            catch
            {
                dbErrorLabel.Text = "Database error adding DVDsordered DB. <br/>";
            }
            finally
            {
                conn.Close();
            }
            Response.Redirect("Thanks.aspx?id=" + InputCustNumberTextBox.Text);

        }

    }
}
