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
    public partial class EDITDVDLIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindDatalist();
            }
        }

        protected void bindDatalist()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDID, DVDtitle, DVDartist, DVDrating, DVDprice FROM DVDtable", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DatalistDVD.DataSource = reader;
                DatalistDVD.DataBind();
                reader.Close();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void DatalistDVD_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "DVDEditOpen")
            {
                DatalistDVD.EditItemIndex = e.Item.ItemIndex;
                bindDatalist();
            }
            else if(e.CommandName == "DVDEditSave")
            {
                int DVDID = Convert.ToInt32(e.CommandArgument);
                TextBox TextBoxTitle = (TextBox)e.Item.FindControl("TextBoxTitle");
                string newTitle = TextBoxTitle.Text;
                TextBox TextBoxArtist = (TextBox)e.Item.FindControl("TextBoxArtist");
                string newArtist = TextBoxArtist.Text;
                TextBox TextBoxRating = (TextBox)e.Item.FindControl("TextBoxRating");
                string newRating = TextBoxRating.Text;
                TextBox TextBoxPrice = (TextBox)e.Item.FindControl("TextBoxPrice");
                string newPrice = TextBoxPrice.Text;

                sqlUpdateItem(DVDID, newTitle, newArtist, newRating, newPrice);
                DatalistDVD.EditItemIndex = -1;
                bindDatalist();
            }
            else if(e.CommandName == "DVDEditCancel")
            {
                DatalistDVD.EditItemIndex = -1;
                bindDatalist();
            }
        }

        private void sqlUpdateItem(int DVDId, string newTitle, string newArtist, string newRating, string newPrice)
        {
            try
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
            }
            catch(Exception e)
            {
                dbErrorLabel.Text = e.ToString();
            }
            finally
            {

            }
        }
    }
}