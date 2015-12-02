<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="JeffersonDVD.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="ButtonDone" runat="server" OnClick="ButtonDone_Click" Text="< Return" />
    <asp:Label ID="dbErrorLabel" runat="server"></asp:Label><br />
    <asp:Image ID="Pic" CssClass="justinline" ImageAlign="Left" runat="server" Width="150" Height="200" BackColor="Black" ForeColor="Blue" />
    <div id="DivInfoPanel">
        <h2><asp:Label ID="TitleLabel" runat="server"></asp:Label></h2>
        <h3><asp:Label ID="LabelDVDArtist" runat="server" /></h3>
        <asp:Label ID="LabelDVDDescription" runat="server" /><br />
        Rating: <asp:Label ID="LabelDVDRating" runat="server" /> out of 5
    </div>

</asp:Content>