using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project_SE
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-390KB38\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            /*if (WebForm1.i == 0)
            {
                Response.Redirect("Category.aspx");
            }*/
            if (!IsPostBack)
            {

                filldrop_s();
                filldrop_a();
                GridView1.AutoGenerateColumns = false;
            }
        }
        public static int Std_count = 0;
        public static int Ad_count = 0;
        protected void add_Click(object sender, EventArgs e)
        {

            int count = GridView1.Rows.Count;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            Std_count = 0;
            Ad_count = 0;
            foreach (ListItem l in CheckBoxList1.Items)
            {
                if (l.Selected == true)
                {
                    DataRow d = dt.NewRow();
                    d["Name"] = l.Value.ToString();
                    d["ID"] = l.Text;
                    d["Category"] = "Student";
                    Std_count = Std_count + 1;
                    dt.Rows.Add(d);

                }
            }
            foreach (ListItem l in CheckBoxList2.Items)
            {
                if (l.Selected == true)
                {
                    DataRow d = dt.NewRow();
                    d["Name"] = l.Text;
                    d["ID"] = l.Value.ToString();
                    d["Category"] = "Advisor";
                    Ad_count = Ad_count + 1;
                    dt.Rows.Add(d);

                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (Std_count > 0 || Ad_count > 0)
            {
                update.Enabled = true;
            }
        }


        protected void delete_Click(object sender, EventArgs e)
        {
            SqlCommand sql = conn.CreateCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText="delete from group where ProjectName ='"+TextBox1.Text+"'";
            sql.ExecuteNonQuery();

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill Project Name')", true);
            }
            else if (Ad_count == 0 && Std_count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Or Person must be selected')", true);
            }
            else if (Ad_count > 0 && Std_count == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Atleast one Student must be Selected')", true);
            }
            else if (Ad_count == 0 && Std_count > 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Atleast one Advisor must be Selected')", true);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select count(*) from group where (ProjectName=@pn)", conn);
                cmd.Parameters.AddWithValue("@pn", TextBox1.Text);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Project already exists!')", true);

                }
                else
                {

                    SqlCommand sql = new SqlCommand("insert into group(ProjectName) values(@pn)", conn);

                    sql.Parameters.AddWithValue("@pn", TextBox1.Text);
                    sql.ExecuteNonQuery();
                    foreach (GridViewRow t in GridView1.Rows)
                    {
                        string ID = t.Cells[1].Text;

                        SqlCommand command = new SqlCommand("update  tbl_person set ProjectName=@pn where(RegNo=@ID or supervisorId=@ID)", conn);
                        command.Parameters.AddWithValue("@pn", TextBox1.Text);
                        command.Parameters.AddWithValue("@ID", ID);
                        command.ExecuteNonQuery();

                    }


                }
            }
            update.Enabled = false;
        }
        
    

        protected void next_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm4.aspx");

        }

        public void filldrop_s()
        {
            DataSet d = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_person where (categoryname=@n)", conn);
            da.SelectCommand.Parameters.AddWithValue("@n", "Student");
            da.Fill(d);
            CheckBoxList1.DataSource = d;
            CheckBoxList1.DataTextField = "RegNo";
            CheckBoxList1.DataValueField = "Name";
            CheckBoxList1.DataBind();

        }
        public void filldrop_a()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dp = new SqlDataAdapter("select * from tbl_person where (categoryname=@n)", conn);
            dp.SelectCommand.Parameters.AddWithValue("@n", "Advisor");
            dp.Fill(ds);
            CheckBoxList2.DataSource = ds;
            CheckBoxList2.DataTextField = "Name";
            CheckBoxList2.DataValueField = "supervisorId";
            CheckBoxList2.DataBind();


        }


    }
}