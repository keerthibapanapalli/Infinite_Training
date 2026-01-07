
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ElectricityBill.LoginForm" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f6f9;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form#form1 {
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 350px;
            text-align: center;
        }

        h2 {
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
            color: red;
        }
    </style>
</head>
<body>
    <p><br /></p>
    <form id="form1" runat="server">
        <div>
            <h2> Welcome To Login Page</h2>
            <br />
            Username : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br /><br />
            Password: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click"
                Style="background-color:lightskyblue" />
            <br /><br /><br />
            <asp:Label ID="Label1" runat="server" Text="lblmessage" ForeColor="Red"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
