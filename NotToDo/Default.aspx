<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NotToDo._Default" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
<%--<form id="form1" runat="server">--%>


<%--         <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"
               UpdateMode="Conditional">
               <ContentTemplate>
                  <asp:Label ID="Label4" runat="server" />
                  <br />
                  <asp:Button ID="Button1" runat="server"
                     Text="Update Both Panels" OnClick="Button1_Click" />
                  <asp:Button ID="Button2" runat="server"
                     Text="Update This Panel" OnClick="Button2_Click" />
               </ContentTemplate>
            </asp:UpdatePanel>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server"
               UpdateMode="Conditional">
               <ContentTemplate>
                  <asp:Label ID="Label5" runat="server" ForeColor="red" />
               </ContentTemplate>
               <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
    </div>--%>

    <div>

        <asp:TextBox ID="txtid" runat="server" Visible ="False"></asp:TextBox>

        <div class="container">
            <div class="mb-3">
              <label for="formFileMultiple" class="form-label"><asp:Label ID="Label4" runat="server" Text="Name"></asp:Label></label>
              <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label2" runat="server" Text="Details"></asp:Label>
                <asp:TextBox ID="txtdetails" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                <asp:TextBox ID="txtdodateloc"  TextMode="DateTimeLocal" runat="server"></asp:TextBox>
            </div>
            
        </div>
    
         <div class="container">
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
        <br /><br />

            
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="empid" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="details" HeaderText="Details" />
                <asp:BoundField DataField="dodate" HeaderText="Do Date" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="SelectButton" runat="server" CommandArgument='<%# Eval("empid") %>' OnClick="Select_Click" >Select</asp:LinkButton>
                        <asp:LinkButton ID="ReminderButton" runat="server" CommandArgument=' <%# Eval("empid") + ";" + Eval("dodate")  %>' OnClick="Reminder_Click" >Reminder</asp:LinkButton>
                        <asp:Label id="msglabel" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
        
        <br /><br />
        <p class="fw-light"><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></p>


    </div>
<%--    </form>    --%>

<%--        <asp:ScriptManager ID="ScriptManager" 
                   runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" 
                 UpdateMode="Conditional"
                 runat="server">
    <ContentTemplate>
       <fieldset>
       <legend>UpdatePanel content</legend>
        <!-- Other content in the panel. -->
        <%=DateTime.Now.ToString() %>
        <br />
        <asp:Button ID="Button1" 
                    Text="Refresh Panel" 
                    runat="server" />
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>--%>



<%--        <asp:Button ID="Button2" 
            Text="Refresh Panel"
            runat="server" />
<asp:ScriptManager ID="ScriptManager1" 
                   runat="server" />
<asp:UpdatePanel ID="UpdatePanel2" 
                 UpdateMode="Conditional"
                 runat="server">
                 <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Button1" />
                 </Triggers>
                 <ContentTemplate>
                 <fieldset>
                 <legend>UpdatePanel content</legend>
                 <%=DateTime.Now.ToString() %>
                 </fieldset>
                 </ContentTemplate>
</asp:UpdatePanel>--%>

</main>
</asp:Content>
