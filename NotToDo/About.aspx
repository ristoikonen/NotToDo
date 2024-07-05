<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NotToDo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
        <asp:TextBox ID="txtdodate" runat="server"></asp:TextBox>
        <br /><br />

        <%--<asp:Label ID="LblDob" runat="server" Text='<%# Bind("DateofBirth") %>'>--%>

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

    </div>
<%--    </form>    --%>


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
