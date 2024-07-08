using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Web.ModelBinding;
using NotToDo.OutlookAccess;
using System.Security.Policy;
using Microsoft.Office.Interop.Outlook;

namespace NotToDo
{
    public partial class _Default : Page
    {
        //TODO: conn string safety!
        string cs = "data source=telli;initial catalog=TODO;trusted_connection=true";
        SqlConnection con = new SqlConnection(@"data source=telli;initial catalog=TODO;trusted_connection=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPage();
            }
        }


        public void ShowPage()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("SELECT [empid] ,[name] ,[details] ,CONVERT(datetime, SWITCHOFFSET(CONVERT(datetimeoffset, [dodate]), DATENAME(TzOffset, SYSDATETIMEOFFSET())))  AS dodate  FROM [dbo].[Todo] WHERE Dodate >= GETUTCDATE()", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                //DumpDataTable(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string tableName = "Todo";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string sql = string.Format($"INSERT into dbo.{tableName} values ( @name , @details , @dodate)");

                Debug.WriteLine(sql ?? "");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                                
                DateTime dodate = DateTime.Parse(txtdodateloc.Text);
                string sdodate = dodate.ToUniversalTime().ToString( "yyyy-MM-ddTHH:mm:ss"); 
                                                                                           
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate.ToUniversalTime();

                cmd.ExecuteNonQuery();
                lblmsg.Text = "Record Inserted Successfully";

            }

            ShowPage();
            ClearAllFields();
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            int empid = 0;
            string tableName = "Todo";
            if(Int32.TryParse(((LinkButton)sender).CommandArgument, out empid))
            { 
                int rowIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                // ex?
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand(string.Format($"SELECT * FROM {tableName} WHERE empid = @colval;"), conn);
                    cmd.Parameters.Add("@colval", SqlDbType.Int).Value = empid;

                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    //DumpDataTable(dt);
                    if (dt.Rows.Count >= 0)
                    {
                        DateTime dodate;
                        txtid.Text = dt.Rows[0]["empid"].ToString();
                        txtname.Text = dt.Rows[0]["name"].ToString();
                        txtdetails.Text = dt.Rows[0]["details"].ToString();
                        // TODO errors -  if success
                        if (DateTime.TryParse(dt.Rows[0]["dodate"].ToString(), out dodate))
                        {
                            dodate = dodate.ToLocalTime();
                            txtdodateloc.Text = dodate.ToString("yyyy-MM-ddTHH:mm");
                        }
                    }
                }
            }
        }

        // Uses Microsoft.Office.Interop.Outlook.Application
        // TODO: missing parameters and validation
        protected void Reminder_Click(object sender, EventArgs e)
        {
            int empid = 0;
            DateTime startdate;
            string arguments = ((LinkButton)sender).CommandArgument;
            string[] args = arguments.Split(';');

            
            if (Int32.TryParse(args[0], out empid))
            { 
                if(DateTime.TryParse(args[1], out startdate))
                    try
                    {
                        
                        Remind.ReminderExample(empid, startdate);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                
            }
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            string tableName = "Todo";
            string id = txtid.Text;
            DateTime dodate;

            if (DateTime.TryParse(txtdodateloc.Text, out dodate))
            {
                dodate = dodate.ToUniversalTime();

                using (SqlConnection conn = new SqlConnection(cs))
                {

                    string sql = string.Format($"update {tableName} set name = @name , details= @details , dodate= @dodate where empid = '{id}'");
                    //Debug.WriteLine(sql);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                                                            
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                    cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                    cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate; // txtdodateloc.Text;

                    cmd.ExecuteNonQuery();
                    lblmsg.Text = "Record Updated Successfully";
                }
            }
            ShowPage();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if(Int32.TryParse(txtid.Text , out id))
            { 
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    string sql = string.Format($"DELETE from Todo where empid = @id");

                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();

                    lblmsg.Text = "Record Deleted";
                }
            }

            ShowPage();
            ClearAllFields();
        }

        public void ClearAllFields()
        {
            txtdetails.Text = "";
            txtname.Text = "";
            txtdodateloc.Text = "";
        }


        public static void DumpDataTable(DataTable table)
        {
            string data = string.Empty;
            String s1 = "";

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        s1 += item;
                        s1 += ",";
                    }
                    s1 += Environment.NewLine;
                }

            }

            return; 
        }



        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Label4.Text = DateTime.Now.ToLongTimeString();
        //    Label5.Text = DateTime.Now.ToLongTimeString();
        //    //string str = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "YourColumnName"));
        //    DateTime dodate;

        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //       //row.Cells[0].Text = "Hello";
        //        string x = row.Cells[3].Text;
        //        if (DateTime.TryParse(row.Cells[3].Text, out dodate))
        //        { 
        //            int result = DateTime.Compare(DateTime.Now, dodate);
        //            Label5.Text = dodate.ToLongTimeString();

        //        }
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            cell.Text = "Hesllo";
        //            //int index = cell.ColumnIndex;
        //            //if (index == 0)
        //            //{
        //            //    value = cell.Value.ToString();
        //            //do what you want with the value
        //            // }
        //        }

        //    }
    }
}