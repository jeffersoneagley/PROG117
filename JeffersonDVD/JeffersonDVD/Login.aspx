<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JeffersonDVD.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Please log in:</h2>
    <p>
        Username:<br />
        <asp:TextBox ID="TextBoxUsername" runat="server" />
        <asp:RequiredFieldValidator ID="ReqUsername" runat="server"
            ControlToValidate="TextBoxusername" SetFocusOnError="true"
            ErrorMessage="Username is required!" />
    </p>

    <p>
        Password:<br />
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="ReqPassword" runat="server"
            ControlToValidate="TextBoxPassword" SetFocusOnError="true"
            ErrorMessage="Password is required!" />
    </p>
    <p>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Login" OnClick="submitButton_Click" />
    </p>

</asp:Content>
