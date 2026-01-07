using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationAssignment
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("All Validations Passed");
            }
            else
            {
                Response.Write("Some Validations are incorrect pls check");
            }
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}