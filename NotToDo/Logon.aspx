<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="NotToDo.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <div class="container">
  <h2>Login form</h2>
    <div class="form-group">
      <label class="control-label col-sm-2" for="email">Username:</label>
      <div class="col-sm-10">
        <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
      </div>
    </div>
    <div class="form-group">
      <label class="control-label col-sm-2" for="pwd">Password:</label>
      <div class="col-sm-10">          
        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"></asp:TextBox>
      </div>
    </div>
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
        <div class="checkbox">
          <label><input type="checkbox" name="remember"> Remember me</label>
        </div>
      </div>
    </div>
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Sign In" />
      </div>
    </div>
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
         <asp:Label id="lblLogin" runat="server" />
      </div>
    </div>


       
          <div class="dropdown-divider"></div>



</div>



<%--     <div class="form-horizontal">
        <div class="form-group">
            <div class="col-sm-2">Username:</div>
            <div class="col-sm-10"><asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox></div>
      </div>
      <div class="form-group">
            <div class="col-sm-2">Password:</div>
            <div class="col-sm-10"><asp:TextBox ID="TextBox3" runat="server"  TextMode="Password"></asp:TextBox></div>
      </div>
     </div>

    <h2>NotToDo Login</h2>

    <div class="container">
      <div class="form-group">
            <div class="col-6 col-md-4">Username:</div>
            <div class="col-6 col-md-4"><asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox></div>
            <div class="col-6 col-md-4"></div>
      </div>
      <div class="form-group">
            <div class="col-6 col-md-4">Password:</div>
            <div class="col-6 col-md-4"><asp:TextBox ID="TextBox1" runat="server"  TextMode="Password"></asp:TextBox></div>
            <div class="col-6 col-md-4"></div>
      </div>
      <div class="form-group">
            <div  >Username:</div>
            <div class="form-control" ><asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox></div>

      </div>


        <div class="row">
                <div class="col-md-4">
               <label for="validationSuccess" class="form-label text-success">Input with success</label>
               <input type="text" class="form-control is-valid" id="validationSuccess" required>
            </div>
            <div class="col-md-4">
               <label for="validationError" class="form-label text-danger"><asp:Label ID="Label1" runat="server" ></asp:Label></label>
               <input type="text" class="form-control is-invalid" id="validationError" required>
            </div>
        </div>
   </div>

    <p>
           
        <p>
            
        <p>
            Password:
            <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log In" />
            <asp:Label ID="lblLogin" runat="server" ></asp:Label>--%>


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
