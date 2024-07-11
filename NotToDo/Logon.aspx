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
            <label class="control-label col-sm-2" for="CheckBoxRememberMe">Remember </label>
          <asp:CheckBox ID="CheckBoxRememberMe"  runat="server" />
              <%--<input type="checkbox" name="chkRememberMe">Remember me</label>--%>
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
</asp:Content>

