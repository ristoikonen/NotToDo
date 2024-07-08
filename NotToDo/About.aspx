<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NotToDo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

        <h2>Check readme.md for database installation instructions.</h2>
        <div>Steps taken</div>
         <ul class="list-group">
              <li class="list-group-item">
                    1. Start with adding Web Forms support to VS 2022, install SQL Server and IIS as Windows feature.
              </li>
              <li class="list-group-item">
                    2. Get template sample from GitHub: simple, Web Forms app:	https://gist.github.com/Aneeq/dc10e6ef5e8c363dd7acd80a157c40d3
              </li>
              <li class="list-group-item">
                    3. Setup solutions setup: Add connections, create basic Db table, git codebase.
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

    </main>
</asp:Content>
