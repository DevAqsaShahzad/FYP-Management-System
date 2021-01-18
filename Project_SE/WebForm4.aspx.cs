using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Project_SE
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-390KB38\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
           if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            if (WebForm1.i== 0)
            {
                Response.Redirect("Category.aspx");
            }
            if (!IsPostBack)
            {

                disp_project();
                disp_gourp();
            }
        }

        protected void next_Click(object sender, EventArgs e)
        {
            Label5.Text = TextBox2.Text;
            Label6.Text = TextBox3.Text;


            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            Printdiv.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker((doc));
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();
            htmlparser.Parse(stringReader);
            doc.Close();
            Response.Write(doc);
            Response.End();

            Label5.Text = "";
            Label6.Text = "";
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select atleast one Project')", true);
            }
            else if (GridView1.Rows.Count == 0)

            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No member selected for this project')", true);
            }
            else if (string.IsNullOrEmpty(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill marks section')", true);
            }
            else
            {
               

                SqlCommand s = new SqlCommand("update group SET TotalMarks=@tm,ObtMarks=@om where (ProjectName=@p)", conn);
                s.Parameters.AddWithValue("@tm", TextBox2.Text);
                s.Parameters.AddWithValue("@om", TextBox3.Text);
                s.Parameters.AddWithValue("@p", DropDownList1.Text);

                
            }
        }
        public void disp_project()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("select * from group", conn);
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "ProjectName";
            DropDownList1.DataValueField = "ProjectName";
            DropDownList1.DataBind();
        }
        public void disp_gourp()
        {
           
            DataTable ds = new DataTable();
             SqlDataAdapter adp = new SqlDataAdapter("select * from tbl_person where(ProjectName=@p)", conn);
            adp.SelectCommand.Parameters.AddWithValue("@p", DropDownList1.SelectedItem.Text);
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            disp_gourp();
        }

    }
}