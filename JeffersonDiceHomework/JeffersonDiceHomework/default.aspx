<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="JeffersonDiceHomework._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Total of 7 or 11 wins</h1>
        <asp:Image ID="Image1" runat="server" />
        <asp:Image ID="Image2" runat="server" />
        <br />
        Select your bet amount:<br />
        <asp:RadioButtonList ID="RadioButtonListBetAmount" runat="server">
            <asp:ListItem Selected="True" Value="1">$1</asp:ListItem>
            <asp:ListItem Value="3">$3</asp:ListItem>
            <asp:ListItem Value="5">$5</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="ButtonBet" runat="server" OnClick="ButtonBet_Click" Text="Click to bet" />
        <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Play Again" />
        <br />
        <asp:Label ID="LabelResults" runat="server" Text="Label"></asp:Label>
        <br />
        Your Balance is: $ <asp:Label ID="LabelBalance" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
