using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDVD.admin
{
    public partial class EDITDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //performs the same function as a cancel button
                ButtonDVDEditCancel_Click(sender, e);
            }
        }

        /*
        *   button onclick methods
        */
        //DVD Chosen, lock out select fields, load info
        protected void ButtonDVDSelect_Click(object sender, EventArgs e)
        {
            UIModeEdit();
            UIGetSelectedDVD();
        }

        //save button
        protected void ButtonDVDEditSave_Click(object sender, EventArgs e)
        {
            int DVDID = Convert.ToInt32(DropDownListDVD.SelectedValue);
            sqlUpdateItem(DVDID, TextBoxDVDTitle.Text, TextBoxDVDArtist.Text, TextBoxDVDRating.Text, TextBoxDVDPrice.Text);
            sqlUpdateItemDetail(DVDID, textboxDVDDescription.Text, textboxDVDPicURL.Text);
            DropDownListDVD.SelectedIndex = -1;
            UISelectRepopulate();
            UIModeSelect();
        }

        //revert button (reloads dvd)
        protected void ButtonDVDEditRevert_Click(object sender, EventArgs e)
        {
            UIGetSelectedDVD();
        }
        
        //cancel button (lets you select another dvd)
        protected void ButtonDVDEditCancel_Click(object sender, EventArgs e)
        {
            dbErrorLabel.Text = string.Empty;
            UISelectRepopulate();
            UIModeSelect();
        }
        //delete button (deletes dvd)
        protected void ButtonDVDEditDelete_Click(object sender, EventArgs e)
        {
            sqlDeleteItem();
            ButtonDVDEditCancel_Click(sender, e);
        }

        /*
        Some UI stuff
        */
        //disable all but Selection fields
        private void UIModeSelect()
        {
            UIModeEdit(false);
            UIModeSelect(true);
        }
        private void UIModeSelect(bool b)
        {
            DropDownListDVD.Enabled = b;
            ButtonDVDSelect.Enabled = b;
        }
        //disable all but Edit fields
        private void UIModeEdit ()
        {
            UIModeEdit(true);
            UIModeSelect(false);
        }
        private void UIModeEdit( bool b )
        {
            TextBoxDVDTitle.Enabled = b;
            TextBoxDVDArtist.Enabled = b;
            TextBoxDVDRating.Enabled = b;
            TextBoxDVDPrice.Enabled = b;
            textboxDVDDescription.Enabled = b;
            textboxDVDPicURL.Enabled = b;
            LabelDVDTitle.Enabled = b;
            LabelDVDArtist.Enabled = b;
            LabelDVDRating.Enabled = b;
            LabelDVDPrice.Enabled = b;
            ButtonDVDEditCancel.Enabled = b;
            ButtonDVDEditRevert.Enabled = b;
            ButtonDVDEditSave.Enabled = b;
            ButtonDVDEditDelete.Enabled = b;
        }

        //empties out the text fields
        protected void UIClearFields()
        {
            TextBoxDVDTitle.Text = string.Empty;
            TextBoxDVDArtist.Text = string.Empty;
            TextBoxDVDRating.Text = string.Empty;
            TextBoxDVDPrice.Text = string.Empty;
            textboxDVDDescription.Text = string.Empty;
            textboxDVDPicURL.Text = string.Empty;
        }

        /*
        * Time to SQL!
        */

        //Gets a specific DVD's information
        protected void UIGetSelectedDVD()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtitle, DVDartist, DVDrating, DVDprice, d.Description AS DVDdescription, d.PicURL AS DVDpic FROM DVDtable AS t LEFT OUTER JOIN Details AS d ON t.DVDID=d.DVDID WHERE t.DVDID = @DVDID", conn);
            comm.Parameters.Add("DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["DVDID"].Value = Convert.ToInt32(DropDownListDVD.SelectedValue);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                Console.WriteLine(reader);
                
                if (reader.Read())
                {
                    TextBoxDVDTitle.Text = reader["DVDTitle"].ToString();
                    TextBoxDVDArtist.Text = reader["DVDartist"].ToString();
                    TextBoxDVDRating.Text = reader["DVDrating"].ToString();
                    TextBoxDVDPrice.Text = reader["DVDprice"].ToString();
                    if(reader["DVDpic"]!= null)
                    {
                        textboxDVDPicURL.Text = reader["DVDpic"].ToString();
                        textboxDVDDescription.Text = reader["DVDdescription"].ToString();
                    }
                    else
                    {
                        textboxDVDPicURL.Text = string.Empty;
                        textboxDVDPicURL.Text = string.Empty;
                    }
                    
                    dbErrorLabel.Text = "DVD information loaded. Make changes, the press save to keep them, "
                        +" press revert to re-load the DVD and make changes over again. Press cancel to select another DVD. ";
                }
                else
                {
                    dbErrorLabel.Text = "Error, SQL reader failure!";
                }
            }
            catch
            {
                dbErrorLabel.Text = "Error getting DVD information from SQL";
            }
            finally
            {
                conn.Close();
            }
        }




        //Get the initial Select Box list of DVD names
        protected void UISelectRepopulate()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDID, DVDtitle FROM DVDtable", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DropDownListDVD.DataSource = reader;
                DropDownListDVD.DataValueField = "DVDID";
                DropDownListDVD.DataTextField = "DVDtitle";
                DropDownListDVD.DataBind();
                reader.Close();
                dbErrorLabel.Text += "Select a DVD from the list to edit. ";
                UIClearFields();
            }
            catch
            {
                dbErrorLabel.Text = "Error getting DVD list from database. Ensure SQL is properly connected";
            }
            finally
            {
                conn.Close();
            }
        }

        //uploads changes to selected DVD in the database
        private void sqlUpdateItem(int DVDId, string newTitle, string newArtist, string newRating, string newPrice)
        {
            SqlConnection conn;
            SqlCommand comm;
            string cs = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(cs);
            comm = new SqlCommand("UPDATE DVDtable "
                + " SET DVDtitle = @NewTitle, "
                + " DVDartist = @NewArtist, "
                + " DVDrating = @NewRating, "
                + " DVDprice = @NewPrice "
                + " WHERE DVDID = @DVDID"
                , conn
                );
            try
            {
                comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDID"].Value = DVDId;
                comm.Parameters.Add("@newTitle", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@newTitle"].Value = newTitle;
                comm.Parameters.Add("@newArtist", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@newArtist"].Value = newArtist;
                comm.Parameters.Add("@newRating", System.Data.SqlDbType.Int);
                comm.Parameters["@newRating"].Value = Convert.ToInt32(newRating);
                comm.Parameters.Add("@newPrice", System.Data.SqlDbType.Money);
                comm.Parameters["@newPrice"].Value = Convert.ToDouble(newPrice);
                conn.Open();
                comm.ExecuteNonQuery();
                dbErrorLabel.Text = "Changes to "+newTitle+" saved! ";
            }
            catch(Exception e)
            {
                dbErrorLabel.Text = e.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        //uploads the changes to the DVD detail table in the database
        private void sqlUpdateItemDetail(int DVDID, string newDesc, string newPicURL)
        {
            SqlConnection conn;
            SqlCommand comm;
            string cs = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(cs);
            comm = new SqlCommand("UPDATE Details "
                + " SET Description = @NewDescription, "
                + " PicURL = @NewPicURL "
                + " WHERE DVDID = @DVDID;"
                + "     IF @@ROWCOUNT=0 "
                + "     INSERT INTO Details(DVDID, Description, PicURL) "
                + "         VALUES ( @DVDID, @NewDescription, @NewPicURL); "
                , conn
                );
            try
            {
                comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDID"].Value = DVDID;
                comm.Parameters.Add("@NewDescription", System.Data.SqlDbType.NVarChar, 500);
                comm.Parameters["@NewDescription"].Value = newDesc;
                comm.Parameters.Add("@NewPicURL", System.Data.SqlDbType.NVarChar, 100);
                comm.Parameters["@NewPicURL"].Value = newPicURL;
                conn.Open();
                comm.ExecuteNonQuery();
                dbErrorLabel.Text = " ** ";
            }
            catch (Exception e)
            {
                dbErrorLabel.Text = e.ToString();
            }
            finally
            {
                conn.Close();
            }
            
        }

        protected void sqlDeleteItem()
        {
            int DVDID = Int32.Parse(DropDownListDVD.SelectedValue);
            SqlConnection conn;
            SqlCommand comm, comm2;
            string cs = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(cs);
            comm = new SqlCommand("DELETE FROM DVDtable WHERE DVDID = @DVDID", conn);
            comm2 = new SqlCommand("DELETE FROM Details WHERE DVDID = @DVDID", conn);
            try
            {
                comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDID"].Value = DVDID;
                comm2.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm2.Parameters["@DVDID"].Value = DVDID;
                conn.Open();
                comm.ExecuteNonQuery();
                dbErrorLabel.Text = TextBoxDVDTitle.Text + " deleted from database!";
                comm2.ExecuteNonQuery();
                dbErrorLabel.Text += " ** ";
            }
            catch
            {
                dbErrorLabel.Text = "Error deleting DVD from database";
            }
            finally
            {
                conn.Close();
            }
        }

    }
}