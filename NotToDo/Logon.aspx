<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="NotToDo.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>NotToDo Login</h2>
    <p>
           Username:
        <p>
            <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
        <p>
            Password:
            <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Button1_Click" Text="Log In" />
            <asp:Label ID="lblLogin" runat="server" ></asp:Label>

<%--        Username:
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>
    <p>
        Password:
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></p>
    <p>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" /> </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> </p>
    <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
            Visible="False"></asp:Label> </p>--%>
</asp:Content>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="NotToDo.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h3>
    <font face="Verdana">Logon Page</font>
</h3>
<table>
    <tr>
        <td>Email:</td>
        <td><input id="txtUserName" type="text" runat="server"></td>
        <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
            Display="Static" ErrorMessage="*" runat="server" 
            ID="vUserName" /></td>
    </tr>
    <tr>
        <td>Password:</td>
        <td><input id="txtUserPass" type="password" runat="server"></td>
        <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
        Display="Static" ErrorMessage="*" runat="server"
        ID="vUserPass" />
        </td>
    </tr>
    <tr>
        <td>Persistent Cookie:</td>
        <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
        <td></td>
    </tr>
</table>
<input type="submit" Value="Logon" runat="server" ID="cmdLogin"><p></p>
<asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
</body>
</html>--%>
