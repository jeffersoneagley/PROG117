<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JeffersonDorknozzle.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Please log in:</h2>
    <p>
        Username:<br />
        <asp:TextBox ID="usernameTextBox" runat="server" />
        <asp:RequiredFieldValidator ID="usernameReq" runat="server"
            ControlToValidate="usernameTextBox" SetFocusOnError="true"
            ErrorMessage="Username is required!" />
    </p>

    <p>
        Password:<br />
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="passwordReq" runat="server"
            ControlToValidate="passwordTextBox" SetFocusOnError="true"
            ErrorMessage="Password is required!" />
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" Text="Login" OnClick="submitButton_Click" />
    </p>
</asp:Content>
