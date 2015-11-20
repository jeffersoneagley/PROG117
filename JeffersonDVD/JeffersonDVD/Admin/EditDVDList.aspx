<%@ Page Title="Edit DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditDVDList.aspx.cs" Inherits="JeffersonDVD.admin.EDITDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit a DVD</h2>
    <asp:Label ID="dbErrorLabel" runat="server"></asp:Label>
    <asp:DataList ID="DatalistDVD" runat="server" OnItemCommand="DatalistDVD_ItemCommand">
        <ItemTemplate>
            <h3><%# Eval("DVDtitle") %></h3>
            By <%# Eval("DVDartist") %><br />
            <%# Eval("DVDrating") %>/5
            $<%# Eval("DVDprice") %><br /><asp:LinkButton ID="LinkbuttonEdit" CssClass="buttonfy" runat="server"
                Text="Edit DVD"
                CommandName="DVDEditOpen"
                CommandArgument=<%#Eval("DVDid")%>/>
        </ItemTemplate>
        <EditItemTemplate>
            DVD#: <%#Eval("DVDID")%>
            <br />
            Title: <asp:TextBox ID="TextBoxTitle" runat="server"
                Text=<%#Eval("DVDtitle")%> />
            <br />
            Artist: <asp:TextBox ID="TextBoxArtist" runat="server"
                Text=<%#Eval("DVDartist")%>/>
            <br />
            Rating: <asp:TextBox ID="TextBoxRating" runat="server"
                Text=<%#Eval("DVDrating")%> />
            <br />
            Price: <asp:TextBox ID="TextBoxPrice" runat="server"
                Text=<%#Eval("DVDprice")%> />
            <br />
            <asp:LinkButton ID="LinkbuttonSave" CssClass="buttonfy" runat="server"
                Text="Save changes"
                CommandName="DVDEditSave"
                CommandArgument=<%#Eval("DVDid")%>/>
            
            <asp:LinkButton ID="LinkbuttonCancel" CssClass="buttonfy" runat="server"
                Text="Cancel changes"
                CommandName="DVDEditCancel"
                CommandArgument='<%#Eval("DVDid")%>' />
            <br />

        </EditItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
</asp:Content>
