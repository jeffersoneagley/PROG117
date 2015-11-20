<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.Master" AutoEventWireup="true" CodeBehind="EmployeeDirectory2.aspx.cs" Inherits="JeffersonDorknozzle.EmployeeDirectory2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <h1>Employee Directory</h1>

    <asp:DataList ID="employeesDataList" runat="server" OnItemCommand="employeesDataList_ItemCommand">
        <ItemTemplate>
            Name: <strong><%#Eval("Name")%></strong>
            <br />
            Username:<strong><%#Eval("Username")%></strong><br /><asp:Literal ID="extraDetailsLiteral" runat="server" EnableViewState="false" />
            <asp:LinkButton ID="detailsButton" runat="server"
                Text='<%#"View more details about " +  Eval("Name")%>'
                CommandName="MoreDetailsPlease"
                CommandArgument='<%# Eval("EmployeeID") %>' />
            <br />
            <asp:LinkButton ID="editButton" runat="server"
                Text='<%#"Edit employee " + Eval("Name")%>'
                CommandName="EditItem"
                CommandArgument='<%#Eval("EmployeeID")%>' />

        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
        <EditItemTemplate>
            Name:
            <asp:TextBox ID="nameTextBox" runat="server"
                Text='<%# Eval("Name")%>' />
            <br />
            Username:
            <asp:TextBox ID="usernameTextBox" runat="server"
                Text='<%# Eval("Username")%>' />
            <br />
            <asp:LinkButton ID="updateButton" runat="server"
                Text="Update Item" CommandName="UpdateItem"
                CommandArgument='<%# Eval("EmployeeID")%>' />
            &nbsp;or 
   <asp:LinkButton ID="cancelButton" runat="server"
       Text="Cancel Editing" CommandName="CancelEditing"
       CommandArgument='<%# Eval("EmployeeID")%>' />
        </EditItemTemplate>


    </asp:DataList>




</asp:Content>
