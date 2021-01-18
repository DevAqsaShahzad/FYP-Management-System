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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-390KB38\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            i++;
            display();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string value = c_name.Text;
            if (string.IsNullOrEmpty(c_name.Text) || string.IsNullOrWhiteSpace(c_name.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Category Name')", true);
            }
            else
            {
                SqlCommand sql = new SqlCommand("Select COUNT(*) from tbl_category where(categoryname=@catname)", conn);
                sql.Parameters.AddWithValue("@catname", value);
                int c = (int)sql.ExecuteScalar();
                if (c > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already Exist')", true);
                }

                else
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into tbl_category values('" + c_name.Text + "')";
                    cmd.ExecuteNonQuery();
                    c_name.Text = "";
                }
            }
            display();

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " delete from tbl_category where categoryname='" + c_name.Text+"'";
            cmd.ExecuteNonQuery();
            display();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "update tbl_category SET [categoryname]='" + c_name.Text+"'";
            cmd.ExecuteNonQuery();
            display();
        }

        protected void next_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
        public void display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_category";
             cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

           
        }
    }
}
