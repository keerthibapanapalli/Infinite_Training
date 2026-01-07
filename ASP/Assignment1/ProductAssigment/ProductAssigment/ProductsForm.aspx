<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsForm.aspx.cs" Inherits="ProductAssigment.ProductsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
         OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;
        <br />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" /> 
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Price" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="lblmessage"></asp:Label>
        <br />
    </form>
</body>
</html>
