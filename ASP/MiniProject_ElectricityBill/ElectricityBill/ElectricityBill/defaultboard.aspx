<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defaultboard.aspx.cs" Inherits="ElectricityBill.defaultboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <h3> Electricity Board Billing System </h3>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="AddBill"
                 Style="background-color:lightskyblue"/>
            &nbsp&nbsp&nbsp&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ViewBill" 
                 Style="background-color:lightskyblue" />
              &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
            <br />
            <br />

        </div>
    </form>
</body>
</html>
