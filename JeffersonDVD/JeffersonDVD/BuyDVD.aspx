<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BuyDVD.aspx.cs" Inherits="JeffersonDVD.BuyDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Purchase your DVD</h2>

    <asp:Label ID="dbErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Label ID="DVDIDlabel" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    DVD Title:
    <asp:Label ID="TitleLabel" runat="server" Text="Label"></asp:Label>
    <br />
    DVD Price:
    <asp:Label ID="PriceLabel" runat="server" Text="Label"></asp:Label>
    <br />

    Enter your customer number:
    <asp:TextBox ID="InputCustNumberTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    If you don’t have a customer number, please enter this information to create one:<br />

    Your First Name:
    <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
    <br />
    Your Last Name: 
    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="PurchaseButton" runat="server" Text="Purchase"
        OnClick="PurchaseButton_Click" />
    <br />
    <br />
    Your customer ID is:
    <asp:Label ID="UserID" runat="server" Text="Label"></asp:Label>
    <br />
</asp:Content>
