

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ValidationAssignment.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Details Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 24px;
            display: flex;
            justify-content: center;
        }

        form#form1 {
            background-color: #fff;
            width: 760px;
            padding: 28px 28px 20px;
            border-radius: 10px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.12);
        }

        .title {
            font-size: 18px;
            color: #333;
            margin-bottom: 18px;
            font-weight: 600;
        }

        .form-container {
            display: grid;
            grid-template-columns: 180px 320px 1fr;
            column-gap: 16px;
            row-gap: 12px;
            align-items: center;
        }

        asp\:TextBox {
            width: 320px !important;   
            height: 40px !important;   
            padding: 8px 10px;
            border: 1px solid #cfd8dc;
            border-radius: 6px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .actions {
            display: flex;
            justify-content: flex-end;
            margin-top: 16px;
        }

        asp\:Button {
            width: 160px;
            height: 44px;
            background-color: #007bff !important;
            color: #fff;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }
        asp\:Button:hover {
            background-color: #0056b3 !important;
        }

        asp\:RequiredFieldValidator,
        asp\:RegularExpressionValidator,
        asp\:CompareValidator {
            color: #c62828;      
            font-size: 13px;
        }

        asp\:ValidationSummary {
            display: block;
            margin-top: 16px;
            padding: 10px 12px;
            background-color: #fff3f3;
            border: 1px solid #ffb3b3;
            border-radius: 8px;
            color: #b71c1c;
            font-weight: 600;
        }

        .spacer {
            grid-column: 1 / 4;
            height: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title">Insert Your Personal Details:</div>

        <div class="form-container">

            <div>First Name:</div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TextBox1"
                    ErrorMessage="* Name Cannot be Empty"
                    ForeColor="DarkBlue">
                </asp:RequiredFieldValidator>
            </div>

            <div>Family Name:</div>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="TextBox2"
                    ErrorMessage="Family name requried"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToCompare="TextBox1"
                    ControlToValidate="TextBox2"
                    ErrorMessage=" differ from Name"
                    ForeColor="DarkBlue"
                    Operator="NotEqual">
                </asp:CompareValidator>
            </div>

            <div>Full Address:</div>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="TextBox3"
                    ErrorMessage="Full Address is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="TextBox3"
                    ErrorMessage="at least 2 Chars"
                    ForeColor="DarkBlue"
                    ValidationExpression="^.{2,}$">
                </asp:RegularExpressionValidator>
            </div>

            <div>City:</div>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ControlToValidate="TextBox4"
                    ErrorMessage="City is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="TextBox4"
                    ErrorMessage="at least 2 Chars"
                    ForeColor="DarkBlue"
                    ValidationExpression="^.{2,}$">
                </asp:RegularExpressionValidator>
            </div>

            <div>Zip Code:</div>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="TextBox5"
                    ErrorMessage="pincode is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                    ControlToValidate="TextBox5"
                    ErrorMessage="(xxxxxx)"
                    ForeColor="DarkBlue"
                    ValidationExpression="^[1-9][0-9]{5}$">
                </asp:RegularExpressionValidator>
            </div>

            <div>Mobile No:</div>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="TextBox6"
                    ErrorMessage="Mobile Number is required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                    ControlToValidate="TextBox6"
                    ErrorMessage="(xx-xxxxxxxxxx)     (xxx-xxxxxxxxxx)"
                    ForeColor="DarkBlue"
                    ValidationExpression="^(?:\+91|91)?[6-9][0-9]{9}$">
                </asp:RegularExpressionValidator>
            </div>

            <div>Gmail:</div>
            <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ControlToValidate="TextBox7"
                    ErrorMessage="GMail is Required"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ControlToValidate="TextBox7"
                    ErrorMessage="example@example.com"
                    ForeColor="DarkBlue"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </div>

            <div class="spacer"></div>
        </div>

        <div class="actions">
            <asp:Button ID="Button1" runat="server" Text="Check" OnClick="Button1_Click" />
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ForeColor="Red"
            HeaderText="Validation sum"
            ShowMessageBox="True" />
    </form>
</body>
</html>
