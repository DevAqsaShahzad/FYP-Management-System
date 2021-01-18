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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-390KB38\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            //filldrop();
            display();
           /* if(WebForm1.i==0)
            {
                Response.Redirect("WebForm1.aspx");
            }*/
            if (!IsPostBack)
            {

                filldrop();
                TextBox6.Text = DropDownList1.SelectedValue;
                if (string.Equals(DropDownList1.SelectedItem.Text.Trim(), "Student", StringComparison.OrdinalIgnoreCase) == true)
                {
                    TextBox3.Text = "";
                    TextBox7.Text = "";
                    TextBox3.Enabled = false;
                    TextBox7.Enabled = false;

                }
                if (string.Equals(DropDownList1.SelectedItem.Text.Trim(), "Advisor", StringComparison.OrdinalIgnoreCase) == true)
                {
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox5.Enabled = false;
                    TextBox4.Enabled = false;

                }


            }

        }

        protected void add_Click(object sender, EventArgs e)

        {
            Int64 integer;

            if (!Condition())

            {
                if (Int64.TryParse(TextBox2.Text, out integer) == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Contact must be an integer')", true);
                }
                else
                {
                    SqlCommand sql1;

                    if (TextBox7.Enabled == false)
                    {
                        sql1 = new SqlCommand("select count(*) from tbl_person where(RegNo=@ID or supervisorId=@ID)", conn);
                        sql1.Parameters.AddWithValue("@ID", TextBox4.Text);
                    }
                    else
                    {
                        sql1 = new SqlCommand("select count(*) from tbl_person where(supervisorId=@ID or RegNo=@ID)", conn);
                        sql1.Parameters.AddWithValue("@ID", TextBox7.Text);
                    }
                    
                    if ((int)sql1.ExecuteScalar() > 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Person Already Exists')", true);

                    }
                    else
                    {

                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into tbl_person values('" + TextBox1.Text + "' , '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" +Convert.ToInt32(TextBox6.Text) + "', '"+DropDownList1.SelectedItem.Text+"','"+TextBox7.Text+"')";
                        cmd.ExecuteNonQuery();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                        TextBox7.Text = "";
                    }
                }
            }
            display();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_person where Name = '" + TextBox1.Text + "'";
            cmd.ExecuteNonQuery();
            display();

        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tbl_person SET [Name]='" + TextBox1.Text + "' , [Contact]='"+TextBox2.Text+"',[Rank]='"+TextBox3.Text+"', [RegNo]='"+TextBox4.Text+"',[dprogram]='"+TextBox5.Text+"'";
            cmd.ExecuteNonQuery();
            display();
        }

        protected void next_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
        public void filldrop()
        {
            DataSet cd = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_category", conn);
            da.Fill(cd);
            DropDownList1.DataSource = cd;
            DropDownList1.DataTextField = "CategoryName";
            DropDownList1.DataValueField = "CategoryID";
            DropDownList1.DataBind();
        }
        public DataTable getuserdata()
        {
            SqlCommand cmd = new SqlCommand("getcategory",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
              TextBox6.Text = DropDownList1.SelectedValue;

            if (string.Equals(DropDownList1.SelectedItem.Text.Trim(), "Student", StringComparison.OrdinalIgnoreCase) == true)
            {
                TextBox3.Text = "";
                TextBox7.Text = "";
                TextBox3.Enabled = false;
                TextBox7.Enabled = false;
                TextBox5.Enabled = true;
                TextBox4.Enabled = true;
            }
            if (string.Equals(DropDownList1.SelectedItem.Text.Trim(), "Advisor", StringComparison.OrdinalIgnoreCase) == true)
            {
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox5.Enabled = false;
                TextBox4.Enabled = false;

                TextBox3.Enabled = true;
                TextBox7.Enabled = true;

            }
        }
        public bool Condition()
        {
            if ((string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox2.Text)))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
                return true;
            }
            else if (TextBox4.Enabled == false)

            {

                if (string.IsNullOrEmpty(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrEmpty(TextBox7.Text) || string.IsNullOrWhiteSpace(TextBox7.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
                    return true;
                }
                return false;

            }
            else if (TextBox7.Enabled == false)
            {
                if (string.IsNullOrEmpty(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrEmpty(TextBox5.Text) || string.IsNullOrWhiteSpace(TextBox5.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
                    return true;
                    
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public void display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_person";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }

    }

}
