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
using NotToDo.OutlookAccess;

namespace NotToDo
{
    public partial class About : Page
    {
        //TODO: safety!
        string cs = "data source=telli;initial catalog=TODO;trusted_connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayAll();
            }
        }

        SqlConnection con = new SqlConnection(@"data source=telli;initial catalog=TODO;trusted_connection=true");

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //string sql = "insert into Todo values('" + txtname.Text + "','" + txtdetails.Text + "','\" + txtdodate.Text + \"')";

                string sql = string.Format($"INSERT into dbo.Todo values('{txtname.Text}', '{txtdetails.Text}', CAST('{txtdodate.Text}' AS DATETIME))"); //, txtname.Text, txtdetails.Text, txtdodate.Text);

                Debug.WriteLine(sql ?? "");

                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Record Inserted Successfully";
            }

            DisplayAll();
            ClearAllFields();
        }

        protected void LnkSelect_Click(object sender, EventArgs e)
        {
            int empid = 0;
            string tableName =  "Todo";
            bool  ok = Int32.TryParse(((LinkButton)sender).CommandArgument, out empid);
            int rowIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            // ex?

            //Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");

            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                
                SqlCommand cmd = new SqlCommand(string.Format($"SELECT * FROM {tableName} WHERE empid = @colval;" ), conn);
                cmd.Parameters.AddWithValue("@colval", empid);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                DumpDataTable(dt);
                if (dt.Rows.Count >= 0)
                {
                    txtid.Text = dt.Rows[0]["empid"].ToString();
                    txtname.Text = dt.Rows[0]["name"].ToString();
                    txtdetails.Text = dt.Rows[0]["details"].ToString();
                    //TODO: format date
                    txtdodate.Text = dt.Rows[0]["dodate"].ToString();

                }
                DumpDataTable(dt);
            }
        }

        public void DisplayAll()
        {
            

            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("SELECT * from Todo", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                DumpDataTable(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }




        protected void ExecNonQuery(object sender, EventArgs e) //string tableName, string columnName, string id, string name, string mno )
        {

            //int empid = ;
            string tableName = "Todo";
            string name = "";
            string details = "";

            string id  = txtid.Text;
            /*
            bool ok = Int32.TryParse(((Button)sender).CommandArgument, out empid);
            int rowIndex = Convert.ToInt32(((Button)sender).CommandArgument);
            // ex?
            
            Button btn = (Button)sender;
            Session["id"] = btn.CommandArgument;
            */


            using (SqlConnection conn = new SqlConnection(cs))
            {
                //SqlCommand cmd = new SqlCommand("select * from tblemp ", con);
                // {Session["id"]}

                //string sql = string.Format($"update {tableName} set name ='\" + @name + \"', details='\" + @details + \"' where empid = '{id}'");

                string sql = string.Format($"update {tableName} set name = @name , details= @details where empid = '{id}'");

                //string sql = string.Format($"update {tableName} set name= '{txtname.Text}', '{txtdetails.Text}', CAST('{txtdodate.Text}' AS DATETIME))"); //, txtname.Text, txtdetails.Text, txtdodate.Text);


                //string sql = string.Format($"update {tableName} set name ='@name + \"' mno='\" + @mno + \"' where empid = '{id}'");

                //string sql2  = string.Format("update {tableName} set name='" + {txtname.Text} + "'");

                //string sql = string.Format("update {0} set name='" + {1}    +"', mno='" + { 2}
                //+"'where empid='" + Session["id"] + "'", tableName, txtname.Text, txtdetails.Text);

                Debug.WriteLine(sql);

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn); // string.Format("UPDATE {0} SET name='\" + @colval1 + \"' mno='\" + @colval2 + \"' where empid='\" + id  + \"' ", tableName), con);
                                                      //cmd.Parameters.Add("@colval", empid);
                //cmd.Parameters.AddWithValue("@name", txtname.Text);
                //cmd.Parameters.AddWithValue("@details", txtdetails.Text);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = txtname.Text;
                cmd.Parameters.Add("@details", SqlDbType.VarChar, 5000).Value = txtdetails.Text;

                //cmd.Parameters.AddWithValue("@dodate", dodate);
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Record Updated Successfully";
            }
            DisplayAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            string id = txtid.Text;


            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("DELETE from tblemp where empid='" + Session["id"] + "'", conn);
                

                string sql = string.Format($"DELETE from Todo where empid = '{id}'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                lblmsg.Text = "Record Deleted";
            }
            DisplayAll();
            ClearAllFields();
        }

        public void ClearAllFields()
        {
            txtdetails.Text = "";
            txtname.Text = "";
            txtdodate.Text = "";
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
                        s1 += item ;
                        s1 += ",";
                    }
                    s1 += Environment.NewLine;
                }

                //data = sb.ToString();
            }
            Debug.WriteLine(s1);
            return; //data;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            ExecNonQuery(sender, e);
            /*
            con.Open();
            string str = "UPDATE tblemp set name='" + txtname.Text + "', mno='" + txtdetails.Text + "'where empid='" + Session["id"] + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            lblmsg.Text = "Record Updated Successfully";
            con.Close();
            */
        }
            
        
        

    }
}