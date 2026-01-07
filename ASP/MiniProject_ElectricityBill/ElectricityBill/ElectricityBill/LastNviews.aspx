
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LastNviews.aspx.cs" Inherits="ElectricityBill.LastNviews" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Last N Bills</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        form#form1 {
            background-color: #fff;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 600px;
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        asp\:TextBox {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        asp\:Button {
            width: 100%;
            padding: 10px;
            background-color: #007bff !important;
            color: #fff;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        asp\:Button:hover {
            background-color: #0056b3 !important;
        }

        asp\:Label {
            display: block;
            margin-top: 10px;
            font-size: 14px;
            color: #333;
        }

        asp\:GridView {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        asp\:GridView th {
            background-color: #003399;
            color: #fff;
            padding: 10px;
        }

        asp\:GridView td {
            padding: 8px;
            border: 1px solid #ccc;
        }

        .message {
            margin-top: 15px;
            font-size: 14px;
            color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            HeaderText="Please fix the following:"
            ShowMessageBox="false"
            ShowSummary="true"
            ValidationGroup="ViewBillsGroup"
            BackColor="Blue"
            ForeColor="Red" />
        <div>
            Enter number of bills:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCount" runat="server" />
            <br />
            <asp:RequiredFieldValidator ID="rfvCount" runat="server"
                ControlToValidate="txtCount"
                ErrorMessage="Enter number of bills."
                Display="Dynamic"
                ValidationGroup="ViewBillsGroup" />
            <asp:CustomValidator ID="cvCount" runat="server"
                ControlToValidate="txtCount"
                ErrorMessage="Enter a value greater than zero."
                Display="Dynamic"
                ValidationGroup="ViewBillsGroup"
                OnServerValidate="cvCount_ServerValidate" />
            <br /><br />
            <asp:Button ID="btnView" runat="server"
                Text="View Bills"
                OnClick="btnView_Click"
                CausesValidation="true"
                Style="background-color:lightskyblue"
                ValidationGroup="ViewBillsGroup" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gvBills" runat="server"
                AutoGenerateColumns="False"
                Visible="False"
                CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField HeaderText="Consumer Number" DataField="ConsumerNumber" />
                    <asp:BoundField HeaderText="Consumer Name" DataField="ConsumerName" />
                    <asp:BoundField HeaderText="Units Consumed" DataField="UnitsConsumed" />
                    <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString="{0:F2}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script type="text/javascript">
        function validateOnBlur(group) {
            if (typeof (Page_ClientValidate) === "function") {
                Page_ClientValidate(group);
            }
        }
    </script>
</body>
</html>
