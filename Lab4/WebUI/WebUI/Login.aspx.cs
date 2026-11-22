using BLL;
using System;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserService _userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            UserService userService = new UserService();

            bool result = userService.CheckLogin(username, password);

            if (result)
            {
                Response.Redirect("Main.aspx");
            }
            else
            {
                lblMessage.Text = "Login failed!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblMessage.Text = "";
        }
    }
}