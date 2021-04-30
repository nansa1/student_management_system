using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student_management_system
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "student")
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnshow_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
            {
                string id = (string)Session["userid"];
                string dep = (string)Session["dep"];
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from  Marks where Student_id=@Id and Dep=@dep and Sem=@sem", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@dep", dep);
                cmd.Parameters.AddWithValue("@sem", DropDownList1.SelectedItem.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}