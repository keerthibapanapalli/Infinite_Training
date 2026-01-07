using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductAssigment
{
    public partial class ProductsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Select Product", "0"));
                DropDownList1.Items.Add(new ListItem("Dress", "Dress"));
                DropDownList1.Items.Add(new ListItem("Projector", "Projector"));
                DropDownList1.Items.Add(new ListItem("iPhone", "iPhone"));
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Dress")
            {
                Image1.ImageUrl = "https://cdn.mos.cms.futurecdn.net/NwiiiqqoGzR3caNkay8uU4.jpg";
            }
            else if (DropDownList1.SelectedValue == "Projector")
            {
                Image1.ImageUrl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSTG74fgnFYtpnSv0_lAbVsDFpoR-7fRcoJvtLJY9HldQkI9vxE-bRFcMG4fOHjFCZQHLiK41l8MeAfqrDNOzUG1pGXrkkir0_G69SWJBd5";
            }
            else if (DropDownList1.SelectedValue == "iPhone")
            {
                Image1.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3i6rKwXBt9ve_RUxmn5T4IzgoZr6tgBWGew&s";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Dress")
            {
                Label1.Text = "Price: ₹1,200";
            }
            else if (DropDownList1.SelectedValue == "Projector")
            {
                Label1.Text = "Price: ₹8,500";
            }
            else if (DropDownList1.SelectedValue == "iPhone")
            {
                Label1.Text = "Price: ₹80,000";
            }
            else
            {
                Label1.Text = "Please select a product";
            }
        }
    }
}