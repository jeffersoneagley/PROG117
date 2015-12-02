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
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dvdID; 
            if(Int32.TryParse( Request.QueryString["id"], out dvdID))
            {
                sqlLoadDVD();
            }

            
        }

        private void sqlLoadDVD()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtitle, DVDartist, DVDrating, d.Description AS DVDdescription, d.PicURL AS DVDpic FROM DVDtable AS t INNER JOIN Details AS d ON t.DVDID=d.DVDID WHERE t.DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = Convert.ToInt32(Request.QueryString["id"]); // get the passed DVDID
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    TitleLabel.Text = reader["DVDtitle"].ToString();
                    LabelDVDDescription.Text = reader["DVDdescription"].ToString();
                    LabelDVDRating.Text = reader["DVDrating"].ToString();
                    Pic.ImageUrl = reader["DVDpic"].ToString();
                    LabelDVDArtist.Text = reader["DVDartist"].ToString();
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

        protected void ButtonDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}