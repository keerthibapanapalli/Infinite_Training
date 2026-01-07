using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBill
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] == null)
            {

                Response.Redirect("LoginForm.aspx");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                WriteResult("Please correct the highlighted validation errors before submitting.", isError: true);
                return;
            }


            string consumerNumber = TextBox1.Text.Trim();
            string consumerName = TextBox2.Text.Trim();
            string unitsText = TextBox3.Text.Trim();

            try
            {
                var temp = new ElectricityBill();
                temp.ValidateConsumerNumberOrThrow(consumerNumber);

                if (string.IsNullOrWhiteSpace(consumerName) ||
                    !Regex.IsMatch(consumerName, @"^[A-Za-z ]{2,50}$"))
                {
                    throw new FormatException("Invalid Consumer Name");
                }


                if (!int.TryParse(unitsText, out int units) || units < 0 || units > 10000)
                {
                    throw new FormatException("Invalid Units Consumed");
                }


                var ebill = new ElectricityBill
                {
                    ConsumerNumber = consumerNumber,
                    ConsumerName = consumerName,
                    UnitsConsumed = units
                };


                var board = new ElectricityBoard();
                board.CalculateBill(ebill);

                try
                {
                    board.AddBill(ebill);

                    string success =
                        $"Consumer Number : {ebill.ConsumerNumber}<br/>" +
                        $"Consumer Name : {ebill.ConsumerName}<br/>" +
                        $"Units Consumed : {ebill.UnitsConsumed}<br/>" +
                        $"Bill Amount : {ebill.BillAmount:F2}<br/><br/>" +
                        " Bill inserted successfully into database";

                    WriteResult(success, isError: false);
                }
                catch (Exception ex)
                {
                    WriteResult(" Bill calculation done but failed to save into database. Error: " + ex.Message, isError: true);
                }
            }
            catch (FormatException fx)
            {
                WriteResult(fx.Message, isError: true);
            }
            catch (Exception ex)
            {
                WriteResult("Error occurred : " + ex.Message, isError: true);
            }
        }


        private void WriteResult(string message, bool isError)
        {
            var lbl = this.FindControl("lblResult") as System.Web.UI.WebControls.Label;
            if (lbl != null)
            {
                lbl.Text = message;

                lbl.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.DarkBlue;
            }
            else
            {
                string color = isError ? "red" : "green";
                string safeMsg = message.Replace("'", "\\'");
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "resultMsg",
                    $"document.body.insertAdjacentHTML('beforeend','<div style=\"padding:12px;margin-top:12px;color:{color}\">{safeMsg}</div>');",
                    true
                );
            }
        }
    }
}