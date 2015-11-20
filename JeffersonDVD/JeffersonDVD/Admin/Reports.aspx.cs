using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDVD.Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void ButtonCustomers_Click(object sender, EventArgs e)
        {
            //lets do some SQL!!!
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT CustomerID, FirstName, LastName FROM Customers", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DataListCustomers.DataSource = reader;
                DataListCustomers.DataBind();
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error getting customer list. Please reload the page.";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonOrders_Click(object sender, EventArgs e)
        {
            //lets do some SQL!!!
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand(
                "SELECT Orders.OrderID, Orders.CustomerID, DVDsOrdered.DVDID, DVDtable.DVDtitle FROM Orders  " +
                " INNER JOIN DVDsOrdered ON DVDsOrdered.OrderID = Orders.OrderID " +
                " INNER JOIN DVDtable ON DVDsOrdered.DVDID = DVDtable.DVDID " +
                 " WHERE CustomerID = @CustomerID"
                , conn);
            comm.Parameters.Add("CustomerID", System.Data.SqlDbType.Int);
            comm.Parameters["CustomerID"].Value = Int32.Parse(TextboxCustNum.Text);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DataListOrders.DataSource = reader;
                DataListOrders.DataBind();
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error getting customer's data. Please reload the page.";
            }
            finally
            {
                conn.Close();
            }
        }
    }
}