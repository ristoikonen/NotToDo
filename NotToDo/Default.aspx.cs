﻿using System;
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
using System.Diagnostics.Tracing;
using System.Configuration;
using System.Linq.Expressions;

namespace NotToDo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (Request.IsAuthenticated )
                {
                    Debug.Print(GetUserID().ToString());

                    ShowPage();
                }
                else 
                {
                    Response.Redirect("Logon.aspx", true);
                }  
            }
        }
        private int GetUserID()
        {
            int userId = 0;
            if (Int32.TryParse(HttpContext.Current.User?.Identity?.Name, out userId)) 
            {
                return userId;
            }
            return 0;

        }

        /// <summary>
        /// Show events with one day diff and all future events in data grid
        /// Display dates local, database dates UTC
        /// </summary>
        public void ShowPage()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                {
                    string tablename = "Todo";
                    // max days of todos from past shown in grid
                    int datediff = 1;

                    if (GetUserID() > 0 )
                    {
                        string sql = string.Format($"SELECT todoid ,name ,details ,CONVERT(datetime, SWITCHOFFSET(CONVERT(datetimeoffset, [dodate]), DATENAME(TzOffset, SYSDATETIMEOFFSET())))  AS dodate FROM dbo.{tablename} " +
                                                $" WHERE UserId = @userId AND (DATEDIFF(Day,Dodate,GETUTCDATE()) <= @datediff OR Dodate >= GETUTCDATE()) ORDER By dodate");

                        Debug.WriteLine(sql ?? "");

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = GetUserID();
                        cmd.Parameters.Add("@datediff", SqlDbType.Int).Value = datediff;

                        //Debug.WriteLine(cmd.CommandText ?? "");

                        DataTable dt = new DataTable();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);

                        DumpDataTable(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
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


       /// <summary>
        /// Insert the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string tableName = "Todo";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                {
                    string sql = string.Format($"INSERT into dbo.{tableName}  (name ,details ,dodate ,userid) VALUES ( @name , @details , @dodate, @userid)");

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (DateTime.TryParse(txtdodateloc.Text, out DateTime dodate) && GetUserID() > 0)
                    {
                        string sdodate = dodate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss");

                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                        cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                        cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate.ToUniversalTime();
                        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = GetUserID();

                        cmd.ExecuteNonQuery();
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

            ShowPage();
            ClearAllFields();
        }

        /// <summary>
        /// Update the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string tableName = "Todo";

            try
            {
                if (DateTime.TryParse(txtdodateloc.Text, out DateTime dodate)  && GetUserID() > 0 
                    && Int32.TryParse(txtid.Text, out int todoid) )
                {
                    dodate = dodate.ToUniversalTime();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                    {
                        string sql = string.Format($"UPDATE {tableName} SET name = @name , details= @details , dodate= @dodate WHERE todoid = @todoid AND userid = @userid");
                        Debug.WriteLine(sql);

                        conn.Open();

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@todoid", SqlDbType.Int).Value = todoid;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                        cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                        cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate; 
                        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = GetUserID();
                        cmd.ExecuteNonQuery();

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

            ShowPage();
        }

        /// <summary>
        /// Delete the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.TryParse(txtid.Text, out int todoid) && GetUserID() > 0 )
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                    {
                        conn.Open();

                        string sql = string.Format($"DELETE from Todo WHERE todoid = @todoid  AND userid = @userId");
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@todoid", SqlDbType.Int).Value = todoid;
                        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = GetUserID();
                        cmd.ExecuteNonQuery();

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

            ShowPage();
            ClearAllFields();
        }


        /// <summary>
        /// Grids Select link
        /// </summary>
        /// <param name="sender">Has rows todoid</param>
        /// <param name="e"></param>
        protected void Select_Click(object sender, EventArgs e)
        {
            int todoid = 0;
            string tableName = "Todo";
            try
            {
                if (Int32.TryParse(((LinkButton)sender).CommandArgument, out todoid))
                { 
                    int rowIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                    if (GetUserID() > 0)
                    { 
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand(string.Format($"SELECT * FROM {tableName} WHERE todoid = @colval  AND userid = @userid"), conn);
                            cmd.Parameters.Add("@colval", SqlDbType.Int).Value = todoid;
                            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = GetUserID();
                            Debug.WriteLine(cmd?.CommandText ?? "");
                            DataTable dt = new DataTable();
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            adp.Fill(dt);
                            DumpDataTable(dt);
                            if (dt.Rows.Count >= 0)
                            {
                                txtid.Text = dt.Rows[0]["todoid"].ToString();
                                txtname.Text = dt.Rows[0]["name"].ToString();
                                txtdetails.Text = dt.Rows[0]["details"].ToString();
                                if (DateTime.TryParse(dt.Rows[0]["dodate"].ToString(), out DateTime dodate))
                                {
                                    dodate = dodate.ToLocalTime();
                                    txtdodateloc.Text = dodate.ToString("yyyy-MM-ddTHH:mm");
                                }
                            }
                        }
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
            ShowPage();
        }


        /// <summary>
        /// Grids create Outlook reminder link
        /// Uses Microsoft.Office.Interop.Outlook.Application
        /// Missing passing parameters to Outlook and their validation
        /// </summary>
        /// <param name="sender">Has params, id, datetime...</param>
        /// <param name="e"></param>
        protected void Reminder_Click(object sender, EventArgs e)
        {
            int todoid = 0;
            DateTime startdate;
            string arguments = ((LinkButton)sender).CommandArgument;
            string[] args = arguments.Split(';');

            // TODO: missing parameters and validation
            if (Int32.TryParse(args[0], out todoid)  && GetUserID() > 0)
            { 
                if(DateTime.TryParse(args[1], out startdate))
                try
                {
                    Remind.ReminderExample(GetUserID(), todoid, startdate);
                }
                catch (System.Exception ex )
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }


        public void ClearAllFields()
        {
            txtdetails.Text = "";
            txtname.Text = "";
            txtdodateloc.Text = "";
        }


        /// <summary>
        /// Color data grids future events to light yellow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells.Count > 3 && DateTime.TryParse(e.Row.Cells[3].Text, out DateTime dodate))
                    {
                        int result = DateTime.Compare(DateTime.Now, dodate);
                        if (result <= 0)
                        {
                            e.Row.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                    //DateTime dod = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "dodate"));
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
       
        /// <summary>
        /// For debug purposes
        /// </summary>
        /// <param name="table"></param>
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
            Debug.WriteLine(s1);

            return; 
        }

        //public int GetUserID()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(cs))
        //        {
        //            string tablename = "Todo";
        //            // max days of todos from past shown in grid
        //            int datediff = 1;

        //            if (Int32.TryParse(Session["user"].ToString(), out int userid))
        //            {
        //                string sql = string.Format($"SELECT todoid ,name ,details ,CONVERT(datetime, SWITCHOFFSET(CONVERT(datetimeoffset, [dodate]), DATENAME(TzOffset, SYSDATETIMEOFFSET())))  AS dodate FROM dbo.{tablename} " +
        //                                        $" WHERE UserId = @userId AND (DATEDIFF(Day,Dodate,GETUTCDATE()) <= @datediff OR Dodate >= GETUTCDATE()) ORDER By dodate");

        //                Debug.WriteLine(sql ?? "");

        //                SqlCommand cmd = new SqlCommand(sql, conn);
        //                cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
        //                cmd.Parameters.Add("@datediff", SqlDbType.Int).Value = datediff;


        //            }
        //        }
        //        return 1;
        //    }
        //    catch (SqlException exp)
        //    {
        //        Debug.WriteLine(exp.ToString());
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //    }
        //}
    }
}