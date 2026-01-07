using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBill
{
    public partial class LoginForm : System.Web.UI.Page
    {


        private readonly string storedUsername = "admin";
        private readonly string storedPassword = "admin123";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            if (username == storedUsername && password == storedPassword)
            {
                Session["AdminUser"] = username;
                Response.Redirect("defaultboard.aspx");

            }
            else
            {
                Label1.Text = "Invalid username or password.";
            }

        }
    }
}