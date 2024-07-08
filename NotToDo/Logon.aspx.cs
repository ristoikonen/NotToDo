using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;

namespace NotToDo
{
    // https://learn.microsoft.com/en-us/troubleshoot/developer/webapps/aspnet/development/forms-based-authentication#configure-security-settings-in-the-webconfig-file
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Three valid username/password pairs: Scott/password, Jisun/password, and Sam/password.
            string[] users = { "Scott", "user", "sa" };
            string[] passwords = { "password", "password", "sa" };
            for (int i = 0; i < users.Length; i++)
            {
                bool validUsername = (string.Compare(UserName.Text, users[i], true) == 0);
                bool validPassword = (string.Compare(Password.Text, passwords[i], false) == 0);
                if (validUsername && validPassword)
                {
                    // TODO: Log in the user...
                    // TODO: Redirect them to the appropriate page
                    Response.Redirect("Default.aspx");
                }
            }
            // If we reach here, the user's credentials were invalid
            InvalidCredentialsMessage.Visible = true;
        }

        //private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        //{
        //    if (ValidateUser(txtUserName.Value, txtUserPass.Value))
        //        FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, chkPersistCookie.Checked);
        //    else
        //        Response.Redirect("logon.aspx", true);
        //}

        //private bool ValidateUser(string userName, string passWord)
        //{
        //    SqlConnection conn;
        //    SqlCommand cmd;
        //    string lookupPassword = null;

        //    // Check for invalid userName.
        //    // userName must not be null and must be between 1 and 15 characters.
        //    if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
        //    {
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
        //        return false;
        //    }

        //    // Check for invalid passWord.
        //    // passWord must not be null and must be between 1 and 25 characters.
        //    if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
        //    {
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
        //        return false;
        //    }

        //    try
        //    {
        //        // Consult with your SQL Server administrator for an appropriate connection
        //        // string to use to connect to your local SQL Server.
        //        //conn = new SqlConnection("server=localhost;Integrated Security=SSPI;database=pubs");
        //        conn = new SqlConnection("data source=telli;initial catalog=TODO;trusted_connection=true");

        //        conn.Open();

        //        // Create SqlCommand to select pwd field from users table given supplied userName.
        //        cmd = new SqlCommand("Select pwd from users where uname=@userName", conn);
        //        cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
        //        cmd.Parameters["@userName"].Value = userName;

        //        // Execute command and fetch pwd field into lookupPassword string.
        //        lookupPassword = (string)cmd.ExecuteScalar();

        //        // Cleanup command and connection objects.
        //        cmd.Dispose();
        //        conn.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Add error handling here for debugging.
        //        // This error message should not be sent back to the caller.
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
        //    }

        //    // If no password found, return false.
        //    if (null == lookupPassword)
        //    {
        //        // You could write failed login attempts here to event log for additional security.
        //        return false;
        //    }

        //    // Compare lookupPassword and input passWord, using a case-sensitive comparison.
        //    return (0 == string.Compare(lookupPassword, passWord, false));
        //}
    }
}