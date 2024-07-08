<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NotToDo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">


     <ul class="list-group">
          <li class="list-group-item">
                1. Install SQL Server 2022, IIS as Windows feature.
          </li>
          <li class="list-group-item">
                2. Get template sample from GitHub: simple, Web Forms app:	https://gist.github.com/Aneeq/dc10e6ef5e8c363dd7acd80a157c40d3
          </li>
          <li class="list-group-item">
                3. Solutions setup: Connections, create basic table, git codebase.
          </li>
          <li class="list-group-item">
                4. Replace CRUDs, remove session variable, add Display and Clear UI methods.

          </li>
          <li class="list-group-item">
                5. Change Db dates to UTC and display dates to local datetime , add conversions, time handling of form
          </li>
          <li class="list-group-item">
                6. Add crude Outlook reminder integration
          </li>
         <li class="list-group-item">
                7.  Add basic, no good, Forms login
            </li>
    </ul>
    

<%--<form id="form1" runat="server">--%>
 <%--   <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtid" runat="server" Visible ="False"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Details"></asp:Label>
        <asp:TextBox ID="txtdetails" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txtdodate" runat="server"></asp:TextBox>
        <br /><br />

  

        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        <br /><br />

        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
        <br /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="empid" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="details" HeaderText="Details" />
                <asp:BoundField DataField="dodate" HeaderText="Date" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkSelect" runat="server" CommandArgument='<%# Eval("empid") %>' OnClick="LnkSelect_Click" >Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>


  </form>    --%>


    </main>
</asp:Content>
