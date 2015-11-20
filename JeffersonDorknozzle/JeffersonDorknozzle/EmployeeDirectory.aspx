<%@ Page Title="EmployeeDirectory" Language="C#" MasterPageFile="~/Dorknozzle.Master" AutoEventWireup="true" CodeBehind="EmployeeDirectory.aspx.cs" Inherits="JeffersonDorknozzle.EmployeeDirectory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Employee Directory</h1>

    <asp:Repeater id="employeesRepeater" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                    <td>Employee ID:</td>
                    <td><strong><%#Eval("EmployeeID") %></strong></td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td><strong><%#Eval("Name")%></strong>
                    </td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td><strong><%#Eval("Username")%></strong></td>
                </tr>
            </table>
        </ItemTemplate>
        <separatortemplate>
            <hr />
        </separatortemplate>
    </asp:Repeater>


</asp:Content>
