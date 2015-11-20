<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="JeffersonDVD.Admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Reports</h1>

    <asp:Button ID="ButtonCustomers" Text="List Customers" runat="server" OnClick="ButtonCustomers_Click" />
    <asp:Button ID="ButtonOrders" Text="Get Orders" runat="server" OnClick="ButtonOrders_Click" />
    <asp:Label AssociatedControlID="TextBoxCustNum" Text="For customer #:" runat="server"></asp:Label>
    <asp:TextBox ID="TextboxCustNum" runat="server"></asp:TextBox>

    <asp:Label ID="dbErrorLabel" runat="server"></asp:Label>

    <asp:DataList ID="DataListCustomers" CssClass="prettyTable" runat="server">
        <HeaderTemplate>
            <td>CustomerID
            </td>
            <td>First Name
            </td>
            <td>Last Name
            </td>
        </HeaderTemplate>
        <ItemTemplate>
            <th class="prettyTableCell">
                <%# Eval("CustomerID") %>
            </th>
            <td class="prettyTableCell">
                <%# Eval("FirstName") %>
            </td>
            <td class="prettyTableCell">
                <%# Eval("LastName") %>
            </td>
        </ItemTemplate>
    </asp:DataList>

    <asp:DataList ID="DataListOrders" CssClass="prettyTable" runat="server">
        <HeaderTemplate>
            <td>
                OrderID
            </td>
            <td>
                CustomerID
            </td>
            <td>DVDID
            </td>
            <td>
                DVD Title
            </td>
        </HeaderTemplate>
        <ItemTemplate>
            <th class="prettyTableCell">
                <%# Eval("OrderID") %>
            </th>
            <td class="prettyTableCell">
                <%# Eval("CustomerID") %>
            </td>
            <td class="prettyTableCell">
                <%# Eval("DVDID") %>
            </td>
            <td class="prettyTableCell">
                <%# Eval("DVDtitle") %>
            </td>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
