using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Xml.Linq;
using System.Configuration;

namespace NotToDo
{
    // https://learn.microsoft.com/en-us/troubleshoot/developer/webapps/aspnet/development/forms-based-authentication#configure-security-settings-in-the-webconfig-file
    public partial class Logon : System.Web.UI.Page
    {

        //TODO: conn string safety!
        string cs = "data source=telli;initial catalog=TODO;trusted_connection=true";

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            string tableName = "Users";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                {
                    conn.Open();

                    string sql = string.Format($"SELECT * FROM {tableName} WHERE Username=  @name AND Pwd = @password;");
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtUsername.Text;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;

                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    //DumpDataTable(dt);
                    if (dt.Rows.Count == 1 )
                    {
                        // todo checks
                        int userid = dt.Rows[0].Field<int>("Userid");
                        //FormsAuthentication.SetAuthCookie(username, true);
                                             
                        FormsAuthentication.RedirectFromLoginPage(userid.ToString(), CheckBoxRememberMe.Checked);
                    }
                    else
                    {
                        lblLogin.Text = "Invalid username/password.";
                    }
                }
            }
            catch (SqlException exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }
        //TODO Use this to authorise users to access admin page etc
        public bool IsAuthorized(string dashboardId)
        {
            var identityName = HttpContext.Current.User?.Identity?.Name; 
            if (!string.IsNullOrEmpty(identityName))
            {
                return false; //authDictionary.ContainsKey(identityName) && authDictionary[identityName].Contains(pageId);
            }

            return false;
        }
    }
}