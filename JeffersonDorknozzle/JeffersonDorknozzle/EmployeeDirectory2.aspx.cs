using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDorknozzle
{
    public partial class EmployeeDirectory2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString =
                ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT EmployeeID, Name, Username FROM Employees", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                employeesDataList.DataSource = reader;
                employeesDataList.DataBind();
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
        }


        protected void employeesDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "MoreDetailsPlease")
            {
                Literal myLiteral;
                myLiteral = (Literal)e.Item.FindControl("extraDetailsLiteral");
                myLiteral.Text = "Employee ID: <strong>" + e.CommandArgument +
                    "</strong><br />";
            }
            else if (e.CommandName == "EditItem")
            {
                employeesDataList.EditItemIndex = e.Item.ItemIndex;
                BindList();
            }
            else if (e.CommandName == "CancelEditing")
            {
                employeesDataList.EditItemIndex = -1;
                BindList();
            }
            else if (e.CommandName == "UpdateItem")
            {
                int employeeId = Convert.ToInt32(e.CommandArgument);
                TextBox nameTextBox = (TextBox)e.Item.FindControl("nameTextBox");
                string newName = nameTextBox.Text;
                TextBox usernameTextBox = (TextBox)e.Item.FindControl("usernameTextBox");
                string newUsername = usernameTextBox.Text;
                UpdateItem(employeeId, newName, newUsername);
                employeesDataList.EditItemIndex = -1;
                BindList();
            }
        }

        protected void UpdateItem(int employeeId, string newName, string newUsername)
        {
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("UPDATE Employees SET Name =@NewName, Username =@NewUsername " +
                   "WHERE EmployeeID = @EmployeeID", conn);
            comm.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
            comm.Parameters["@EmployeeID"].Value = employeeId;
            comm.Parameters.Add("@NewName", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@NewName"].Value = newName;
            comm.Parameters.Add("@NewUsername", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@NewUsername"].Value = newUsername;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}