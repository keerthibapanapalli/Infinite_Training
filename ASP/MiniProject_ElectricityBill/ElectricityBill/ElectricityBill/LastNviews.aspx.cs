using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBill
{
    public partial class LastNviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private T GetCtrl<T>(string id) where T : Control
        {
            var ctrl = this.FindControl(id) as T;
            if (ctrl != null) return ctrl;


            var form = this.FindControl("form1");
            if (form != null)
            {
                ctrl = form.FindControl(id) as T;
                if (ctrl != null) return ctrl;
            }


            if (this.Master != null)
            {
                var cph = this.Master.FindControl("MainContent");
                if (cph != null)
                {
                    ctrl = cph.FindControl(id) as T;
                    if (ctrl != null) return ctrl;
                }
            }

            return null;
        }


        protected void cvCount_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TextBox txtCount = null;
            if (source is CustomValidator cv && cv.NamingContainer != null)
            {
                txtCount = cv.NamingContainer.FindControl("txtCount") as TextBox;
            }


            if (txtCount == null)
                txtCount = GetCtrl<TextBox>("txtCount");

            var raw = txtCount != null ? txtCount.Text.Trim() : string.Empty;
            args.IsValid = int.TryParse(raw, out int n) && n > 0;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            var lblMessage = GetCtrl<Label>("lblMessage");
            var gvBills = GetCtrl<GridView>("gvBills");
            var txtCount = GetCtrl<TextBox>("txtCount");


            if (lblMessage == null || gvBills == null || txtCount == null)
            {
                if (lblMessage != null)
                {
                    lblMessage.Text = "Page controls not found. Please ensure IDs: txtCount, gvBills, lblMessage, btnView exist in the ASPX.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                return;
            }


            lblMessage.Text = string.Empty;
            lblMessage.ForeColor = System.Drawing.Color.Empty;


            if (!Page.IsValid)
            {
                gvBills.Visible = false;
                return;
            }

            try
            {
                int n = int.Parse(txtCount.Text.Trim());

                var board = new ElectricityBoard();
                List<ElectricityBill> bills = board.Generate_N_BillDetails(n);

                if (bills != null && bills.Count > 0)
                {
                    gvBills.DataSource = bills;
                    gvBills.DataBind();
                    gvBills.Visible = true;

                    lblMessage.Text = $"Showing last {bills.Count} bill(s).";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    gvBills.DataSource = null;
                    gvBills.DataBind();
                    gvBills.Visible = false;

                    lblMessage.Text = "No bill records found.";
                    lblMessage.ForeColor = System.Drawing.Color.DarkOrange;
                }
            }
            catch (Exception ex)
            {
                gvBills.Visible = false;
                lblMessage.Text = "Failed to load bills: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}