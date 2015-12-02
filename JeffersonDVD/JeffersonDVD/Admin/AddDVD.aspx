<%@ Page Title="Add DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddDVD.aspx.cs" Inherits="JeffersonDVD.admin.addDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h2>Add a new DVD to store</h2>



    <asp:Label ID="LabelTitle" runat="server" Text="Title"
        CssClass="widelabel" AssociatedControlID="textboxDVDTitle"></asp:Label>*
    <asp:TextBox ID="textboxDVDTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="textboxDVDTitle" 
        runat="server" Text="Title is required." 
        Display="Dynamic" SetFocusOnError="true"/>
    <br />
    <asp:Label ID="LabelArtist" runat="server" Text="Artist"
        CssClass="widelabel" AssociatedControlID="textboxDVDArtist"></asp:Label>*
    <asp:TextBox ID="textboxDVDArtist" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="textboxDVDArtist"
        runat="server" Text="Artist is required."
        Display="Dynamic" SetFocusOnError="true" />
    <br />
    <asp:Label ID="LabelRating" runat="server" Text="Rating 1 to 5"
        CssClass="widelabel" AssociatedControlID="textboxDVDRating"></asp:Label>*
    <asp:TextBox ID="textboxDVDRating" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="textboxDVDRating"
        runat="server" Text="Rating is required."
        Display="Dynamic" SetFocusOnError="true" />
    <asp:RangeValidator ControlToValidate="textboxDVDRating"
        runat="server" MaximumValue="5" MinimumValue="1" Type="Integer"
        Text="The rating must be a whole number between 1 & 5"
        Display="Dynamic" SetFocusOnError="true" />
    <br />
    <asp:Label ID="LabelPrice" runat="server" Text="Price"
        CssClass="widelabel" AssociatedControlID="textboxDVDPrice"></asp:Label>*
    <asp:TextBox ID="textboxDVDPrice" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="textboxDVDPrice"
        runat="server" Text="Price is required."
        Display="Dynamic" SetFocusOnError="true" />
    <asp:CompareValidator ControlToValidate="textboxDVDPrice" runat="server"
        Type="Currency" Operator="DataTypeCheck"
        ForeColor="MediumVioletRed" Display="Dynamic" Text="Please enter a decimal number." />
    <br />
    <asp:Label ID="LabelDescription" runat="server" Text="Description"
        CssClass="widelabel" AssociatedControlID="textboxDVDDescription" />
    <asp:TextBox ID="textboxDVDDescription" runat="server" TextMode="MultiLine" />
    <br />
    <asp:Label ID="LabelURL" runat="server" Text="URL of image"
        CssClass="widelabel" AssociatedControlID="textboxDVDPicURL" />
    <asp:TextBox ID="textboxDVDPicURL" runat="server" />


    <br />
    * indicates reqired field
    <br />

    <asp:Button ID="ButtonAddDvd" Text="Add DVD" Width="200"
        runat="server" OnClick="ButtonAddDvd_Click"/>

    <br />
    <asp:Label ID="dbErrorLabel" runat="server" Text=""></asp:Label>
    <br />
    



</asp:Content>
