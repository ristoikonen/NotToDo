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
        //TODO: safety!
        string cs = "data source=telli;initial catalog=TODO;trusted_connection=true";
        SqlConnection con = new SqlConnection(@"data source=telli;initial catalog=TODO;trusted_connection=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPage();
            }
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

        //}
        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Label4.Text = DateTime.Now.ToLongTimeString();
        //}


        public void ShowPage()
        {
            //Remind.ReminderExample();

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


        //public IQueryable<Student> gridview_Getdata()
        public object GridView1_GetData()//[Control] AcademicYear? displayYear)
        {
            //SchoolContext db = new SchoolContext();
            //var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));

            //if (displayYear != null)
            //{
            //    query = query.Where(s => s.Year == displayYear);
            //}

            return null; ;// query;
        }

        void GridView1_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
        {
            // Get the currently selected row. Because the SelectedIndexChanging event
            // occurs before the select operation in the GridView control, the
            // SelectedRow property cannot be used. Instead, use the Rows collection
            // and the NewSelectedIndex property of the e argument passed to this 
            // event handler.
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            // You can cancel the select operation by using the Cancel
            // property. For this example, if the user selects a customer with 
            // the ID "ANATR", the select operation is canceled and an error message
            // is displayed.
            if (row.Cells[1].Text == "ANATR")
            {
                e.Cancel = true;
                //MessageLabel.Text = "You cannot select " + row.Cells[2].Text + ".";
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
                string sdodate = dodate.ToUniversalTime().ToString( "yyyy-MM-ddTHH:mm:ss"); // yyyy-MM-ddTHH:mm:ss");
                                                                                           // 
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate.ToUniversalTime();

                Debug.WriteLine(sql ?? "");

                cmd.ExecuteNonQuery();
                lblmsg.Text = "Record Inserted Successfully";

            }

            //using (SqlConnection conn = new SqlConnection(cs))
            //{
            //    //string sql = "insert into Todo values('" + txtname.Text + "','" + txtdetails.Text + "','\" + txtdodate.Text + \"')";
            //    DateTime dodate = DateTime.Parse(txtdodateloc.Text);
            //    string sdodate = dodate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"); // yyyy-MM-ddTHH:mm:ss");
            //    string sql = string.Format($"INSERT into dbo.Todo values('{txtname.Text}', '{txtdetails.Text}', '{sdodate}'"); //, txtname.Text, txtdetails.Text, txtdodate.Text);CAST('{txtdodateloc.Text}' AS DATETIME)

            //    Debug.WriteLine(sql ?? "");

            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.ExecuteNonQuery();
            //    lblmsg.Text = "Record Inserted Successfully";
            //}

            ShowPage();
            ClearAllFields();
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            int empid = 0;
            string tableName = "Todo";
            bool ok = Int32.TryParse(((LinkButton)sender).CommandArgument, out empid);
            int rowIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            // ex?

            //Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");

            //LinkButton btn = (LinkButton)sender;
            //Session["id"] = btn.CommandArgument;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                
                SqlCommand cmd = new SqlCommand(string.Format($"SELECT * FROM {tableName} WHERE empid = @colval;"), conn);
                cmd.Parameters.AddWithValue("@colval", empid);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                DumpDataTable(dt);
                if (dt.Rows.Count >= 0)
                {
                    DateTime dodate;
                    txtid.Text = dt.Rows[0]["empid"].ToString();
                    txtname.Text = dt.Rows[0]["name"].ToString();
                    txtdetails.Text = dt.Rows[0]["details"].ToString();
                    // TODO errors -  if success
                    DateTime.TryParse(dt.Rows[0]["dodate"].ToString(), out dodate);
                    dodate = dodate.ToLocalTime();
                    txtdodateloc.Text = dodate.ToString("yyyy-MM-ddTHH:mm");
                    //txtdodateloc.Text = dt.Rows[0]["dodate"].ToString("yyyy-MM-ddTHH:mm");
                    

                }
                //DumpDataTable(dt);
            }
        }


        protected void Reminder_Click(object sender, EventArgs e)
        {
            int empid = 0;
            DateTime startdate;
            string arguments = ((LinkButton)sender).CommandArgument;
            string[] args = arguments.Split(';');

            Int32.TryParse(args[0], out empid);
            DateTime.TryParse(args[1], out startdate);

            //TODO: validate
            Remind.ReminderExample(empid, startdate);
            /*
             $(document).ready(function() {
        $('#myLabel').fadeOut(3000, function() {
            $(this).html(""); //reset the label after fadeout
        });
    });
             */
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            //int empid = ;
            string tableName = "Todo";
            string name = "";
            string details = "";

            string id = txtid.Text;
            /*
            bool ok = Int32.TryParse(((Button)sender).CommandArgument, out empid);
            int rowIndex = Convert.ToInt32(((Button)sender).CommandArgument);
            // ex?
            
            Button btn = (Button)sender;
            Session["id"] = btn.CommandArgument;
            */

            DateTime dodate;
            if (DateTime.TryParse(txtdodateloc.Text, out dodate))
            {
                dodate = dodate.ToUniversalTime();

            }
                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //       //row.Cells[0].Text = "Hello";
                //        string x = row.Cells[3].Text;
                //        if (DateTime.TryParse(row.Cells[3].Text, out dodate))
                //        { 
                //            int result = DateTime.Compare(DateTime.Now, dodate);
                //            Label5.Text = dodate.ToLongTimeString();

                //        }


            using (SqlConnection conn = new SqlConnection(cs))
            {
                //SqlCommand cmd = new SqlCommand("select * from tblemp ", con);
                // {Session["id"]}

                //string sql = string.Format($"update {tableName} set name ='\" + @name + \"', details='\" + @details + \"' where empid = '{id}'");

                string sql = string.Format($"update {tableName} set name = @name , details= @details , dodate= @dodate where empid = '{id}'");


                //string sql = string.Format("update {0} set name='" + {1}    +"', mno='" + { 2}
                //+"'where empid='" + Session["id"] + "'", tableName, txtname.Text, txtdetails.Text);
               //CAST(@ts AT TIME ZONE 'Pacific Standard Time' AT TIME ZONE 'UTC' AS DATETIME)
                Debug.WriteLine(sql);

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn); // string.Format("UPDATE {0} SET name='\" + @colval1 + \"' mno='\" + @colval2 + \"' where empid='\" + id  + \"' ", tableName), con);
                                                            //cmd.Parameters.Add("@colval", empid);
                                                            //cmd.Parameters.AddWithValue("@name", txtname.Text);
                                                            //cmd.Parameters.AddWithValue("@details", txtdetails.Text);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;
                cmd.Parameters.Add("@dodate", SqlDbType.DateTime).Value = dodate; // txtdodateloc.Text;

                //cmd.Parameters.AddWithValue("@dodate", dodate);
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Record Updated Successfully";
            }
            ShowPage();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            int id = Int32.Parse(txtid.Text ?? "");

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("DELETE from tblemp where empid='" + Session["id"] + "'", conn);

                // '{id}'
                string sql = string.Format($"DELETE from Todo where empid = @id");

                SqlCommand cmd = new SqlCommand(sql, conn); // string.Format("UPDATE {0} SET name='\" + @colval1 + \"' mno='\" + @colval2 + \"' where empid='\" + id  + \"' ", tableName), con);
                                                            //cmd.Parameters.Add("@colval", empid);
                                                            //cmd.Parameters.AddWithValue("@name", txtname.Text);
                                                            //cmd.Parameters.AddWithValue("@details", txtdetails.Text);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();

                lblmsg.Text = "Record Deleted";
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

                //data = sb.ToString();
            }
            Debug.WriteLine(s1);
            return; //data;
        }

        //protected void BtnUpdate_Click(object sender, EventArgs e)
        //{
        //    ExecNonQuery(sender, e);
        //    /*
        //    con.Open();
        //    string str = "UPDATE tblemp set name='" + txtname.Text + "', mno='" + txtdetails.Text + "'where empid='" + Session["id"] + "'";
        //    SqlCommand cmd = new SqlCommand(str, con);
        //    cmd.ExecuteNonQuery();
        //    lblmsg.Text = "Record Updated Successfully";
        //    con.Close();
        //    */
        //}




    }
}