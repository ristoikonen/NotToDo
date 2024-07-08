<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NotToDo._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
<%--<form id="form1" runat="server">--%>
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtid" runat="server" Visible ="False"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Details"></asp:Label>
        <asp:TextBox ID="txtdetails" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txtdodate" TextMode="Date" runat="server"></asp:TextBox>
        <asp:TextBox ID="t" TextMode="DateTime" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtdodateloc"  TextMode="DateTimeLocal" runat="server"></asp:TextBox>
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



        <div class="form-group">
    <label class="control-label col-lg-2">Time and Date</label>
    <div class="col-lg-10">
        <div class="row">
            <div class="col-lg-6">
                <div class='input-group date' id="datetimepicker">
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar">spps</span>
                    </span>
                </div>
            </div>
            <div class="col-lg-6 pull-right">
                divvv
            </div>
        </div>
    </div>
</div>
</main>
</asp:Content>
