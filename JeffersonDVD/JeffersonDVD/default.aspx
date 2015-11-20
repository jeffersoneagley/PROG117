<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="JeffersonDVD._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Our DVD selection</h2>
    <asp:Label ID="DBErrorLabel" runat="server" />
    <asp:DataList ID="repeaterDVDinventory" runat="server" OnItemCommand="repeaterDVDinventory_ItemCommand">
        <ItemTemplate>
            <h3><%#Eval("DVDtitle") %></h3>
            <%#Eval("DVDartist") %><br />
            <%#(int)Eval("DVDrating")%> - $<%#Eval("DVDprice")%> <br />
            <asp:LinkButton ID="DetailsButton" runat="server"
                Text="Details"
                CommandName="details"
                CommandArgument= <%# Eval("DVDID") %> />
            <p>
                <asp:LinkButton ID="ButtonBuy" runat="server"
                    Text="Buy"
                    CommandName="buy"
                    CommandArgument = <%# Eval("DVDID") %> />
            </p>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>

    </asp:DataList>
    







</asp:Content>
