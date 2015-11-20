using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDorknozzle
{
    public partial class AdminTools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeesList();
            }
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Response.Redirect("default.aspx");
        }

        protected void selectButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT Name, Username, Address, City, State, Zip, " +
                    "HomePhone, Extension, MobilePhone FROM Employees " +
                    "WHERE EmployeeID = @EmployeeID", conn);
            comm.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
            comm.Parameters["@EmployeeID"].Value = employeesList.SelectedItem.Value;
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    nameTextBox.Text = reader["Name"].ToString();
                    userNameTextBox.Text = reader["Username"].ToString();
                    addressTextBox.Text = reader["Address"].ToString();
                    cityTextBox.Text = reader["City"].ToString();
                    stateTextBox.Text = reader["State"].ToString();
                    zipTextBox.Text = reader["Zip"].ToString();
                    homePhoneTextBox.Text = reader["HomePhone"].ToString();
                    extensionTextBox.Text = reader["Extension"].ToString();
                    mobilePhoneTextBox.Text = reader["MobilePhone"].ToString();
                }
                reader.Close();
                updateButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            catch
            {
                dbErrorLabel.Text = "Error loading the employee details! < br />";
            }
            finally
            {
                conn.Close();
            }

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString); comm = new SqlCommand("UPDATE Employees SET Name =@Name, Username =@Username, " +
                  "Address = @Address, City = @City, State = @State, Zip = @Zip, " +
                  "HomePhone = @HomePhone, Extension = @Extension, MobilePhone = @MobilePhone " +
                  "WHERE EmployeeID = @EmployeeID", conn);
            comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@Name"].Value = nameTextBox.Text;
            comm.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@Username"].Value = userNameTextBox.Text;
            comm.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@Address"].Value = addressTextBox.Text;
            comm.Parameters.Add("@City", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@City"].Value = cityTextBox.Text;
            comm.Parameters.Add("@State", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@State"].Value = stateTextBox.Text;
            comm.Parameters.Add("@Zip", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@Zip"].Value = zipTextBox.Text;
            comm.Parameters.Add("@HomePhone", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@HomePhone"].Value = homePhoneTextBox.Text;
            comm.Parameters.Add("@Extension", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@Extension"].Value = extensionTextBox.Text;
            comm.Parameters.Add("@MobilePhone", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@MobilePhone"].Value = mobilePhoneTextBox.Text;
            comm.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
            comm.Parameters["@EmployeeID"].Value = employeesList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error updating the employee details! <br/>";
            }
            finally
            {
                conn.Close();
            }
            LoadEmployeesList();

        }


        private void LoadEmployeesList()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT EmployeeID, Name FROM Employees", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                employeesList.DataSource = reader;
                employeesList.DataValueField = "EmployeeID"; //  note the binding here so we can use the ID

                employeesList.DataTextField = "Name"; // but the part that shows is the user friendly name

                employeesList.DataBind();
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error loading the list of employees! <br />";
            }
            finally
            {
                conn.Close();
            }
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            nameTextBox.Text = "";
            userNameTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            zipTextBox.Text = "";
            homePhoneTextBox.Text = "";
            extensionTextBox.Text = "";
            mobilePhoneTextBox.Text = "";
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn);
            comm.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
            comm.Parameters["@EmployeeID"].Value = employeesList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error deleting employee! <br />";
            }
            finally
            {
                conn.Close();
            }
            LoadEmployeesList();


        }
    }
}