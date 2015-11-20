using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffersonDVD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TextBoxUsername.Text, false);
            }
        }
    }
}