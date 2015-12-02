<%@ Page Title="Edit DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditDVD.aspx.cs" Inherits="JeffersonDVD.admin.EDITDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit a DVD</h2>
    <asp:DropDownList ID="DropDownListDVD" runat="server"></asp:DropDownList>
    <asp:Button ID="ButtonDVDSelect" runat="server" Text="Select DVD" OnClick="ButtonDVDSelect_Click" />
    <br />
    <asp:Label ID="LabelDVDTitle" CssClass="widelabel" AssociatedControlID="TextBoxDVDTitle" runat="server">Title: </asp:Label>
    <asp:TextBox ID="TextBoxDVDTitle" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelDVDArtist" CssClass="widelabel" AssociatedControlID="TextBoxDVDArtist" runat="server">Artist: </asp:Label>
    <asp:TextBox ID="TextBoxDVDArtist" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelDVDRating" CssClass="widelabel" AssociatedControlID="TextBoxDVDRating" runat="server">Rating: </asp:Label>
    <asp:TextBox ID="TextBoxDVDRating" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelDVDPrice" CssClass="widelabel" AssociatedControlID="TextBoxDVDPrice" runat="server">Price: </asp:Label>
    <asp:TextBox ID="TextBoxDVDPrice" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="LabelDescription" runat="server" Text="Description" CssClass="widelabel" AssociatedControlID="textboxDVDDescription" />
    <asp:TextBox ID="textboxDVDDescription" runat="server" TextMode="MultiLine" />
    <br />
    <asp:Label ID="LabelURL" runat="server" Text="URL of image" CssClass="widelabel" AssociatedControlID="textboxDVDPicURL" />
    <asp:TextBox ID="textboxDVDPicURL" runat="server" />

    <asp:Button ID="ButtonDVDEditSave" runat="server" Text="Save Changes" OnClick="ButtonDVDEditSave_Click" />
    <asp:Button ID="ButtonDVDEditCancel" runat="server" Text="Cancel" OnClick="ButtonDVDEditCancel_Click" />
    <asp:Button ID="ButtonDVDEditRevert" runat="server" Text="Revert" OnClick="ButtonDVDEditRevert_Click" />  
    <asp:Button ID="ButtonDVDEditDelete" runat="server" Text="Delete" OnClick="ButtonDVDEditDelete_Click" BorderColor="Red" />
    <br />
    <asp:Label ID="dbErrorLabel" runat="server"></asp:Label>
 </asp:Content>
