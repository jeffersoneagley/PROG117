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
    public partial class addDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddDvd_Click(object sender, EventArgs e)
        {
            string res = ""; //hidden sql connection result variable
            SqlConnection conn;
            SqlCommand comm, commdet;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("INSERT INTO DVDtable (DVDtitle, DVDartist, DVDrating, DVDprice) "
                + " VALUES (@DVDtitle, @DVDartist, @DVDrating, @DVDprice); SELECT SCOPE_IDENTITY();", conn);
            commdet = new SqlCommand("INSERT INTO Details(DVDID, Description, PicURL) "
                + "VALUES ( @DVDID, @Description, @PicURL)", conn);
            try //declare parameters and enter data
            {
                comm.Parameters.Add("@DVDtitle", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@DVDtitle"].Value = textboxDVDTitle.Text; //  "meow"; //
                comm.Parameters.Add("@DVDartist", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@DVDartist"].Value = textboxDVDArtist.Text; //"meow"; // 
                comm.Parameters.Add("@DVDrating", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDrating"].Value = Convert.ToInt32(textboxDVDRating.Text); // 1; // 
                comm.Parameters.Add("@DVDprice", System.Data.SqlDbType.Money);
                comm.Parameters["@DVDprice"].Value  = Convert.ToDouble(textboxDVDPrice.Text); // 1; //


            }
            catch //catch errors in comm declarations such as text entered into numeric fields
            {
                dbErrorLabel.Text = "Something was entered wrong.";
                res += comm.ToString() + "\n"
                    + comm.Parameters.ToString() + "\n";
            }

            try //connect to SQL
            {
                dbErrorLabel.Text = "Connecting...";
                conn.Open();

                if (textboxDVDDescription.Text != "" && textboxDVDDescription.Text != null)
                {
                    commdet.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                    commdet.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500);
                    commdet.Parameters.Add("@PicURL", System.Data.SqlDbType.NVarChar, 100);

                    commdet.Parameters["@DVDID"].Value = comm.ExecuteScalar();
                    dbErrorLabel.Text = " DVD named " + comm.Parameters["@DVDtitle"].Value + " was added! ";
                    commdet.Parameters["@Description"].Value = textboxDVDDescription.Text;
                    commdet.Parameters["@PicURL"].Value = textboxDVDPicURL.Text;
                    dbErrorLabel.Text += " " + commdet.ExecuteNonQuery() + " detail added.";
                }else
                {
                    comm.ExecuteScalar();
                    dbErrorLabel.Text = " DVD named " + comm.Parameters["@DVDtitle"].Value + " was added! ";
                }

                InterfaceClearFields();
            }
            catch (SqlException se) //catches sql failures and rejections
            {
                dbErrorLabel.Text += "There was an error adding this DVD entry to the system. "+ se.ToString();
                res += se.ToString() + "\n" + e.ToString() + "\n";
            }
            finally
            {
                res += "results of execution. \n"
                    + comm.Parameters[0].Value + "\n"
                    + conn.ToString() + " " + conn.State + "\n closing connection... ";
                conn.Close();
                res += conn.State +"\n";
            }

        }

        //separate method for clearing out the fields
        private void InterfaceClearFields()
        {
            textboxDVDTitle.Text = "";
            textboxDVDArtist.Text = "";
            textboxDVDRating.Text = "";
            textboxDVDPrice.Text = "";
        }
    }
}