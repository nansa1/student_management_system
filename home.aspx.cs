using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace student_management_system
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string Labeid = (string)Session["userid"];

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from user_data where Id=@Id",con);
            cmd.Parameters.AddWithValue("@Id", Labeid.Trim());
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    
                    Session["type"] = reader["type"];
                    Session["dep"] = reader["dep"];
                }
            }
            con.Close();

            string type = (string)Session["type"];
            if (type=="admin")
            {
                Btncourse.Visible = true;
                Label1.Visible = true;
                Btnuser.Visible = true;
                Label2.Visible = true;
            }
            else if (type == "student")
            {
                Btncourse.Visible = true;
                Label1.Visible = true;
                Btnattandance.Visible = true;
                Label3.Visible = true;
                Btnresult.Visible = true;
                Label4.Visible = true;

            }
            else if (type == "teacher")
            {
                
                Btnattandance.Visible = true;
                Label3.Visible = true;
                Btnresult.Visible = true;
                Label4.Visible = true;

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            countte();
            countst();
            countcc();
        }
        void countte()
        {

            int count=0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from user_data where type=@type", con);
            cmd.Parameters.AddWithValue("@type", "teacher");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    count += 1;
                }
            }
            countt.Text = count.ToString();
            con.Close();


        }
        void countst()
        {

            int count = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from user_data where type=@type", con);
            cmd.Parameters.AddWithValue("@type", "student");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    count += 1;
                }
            }
            counts.Text = count.ToString();
            con.Close();


        }
        void countcc()
        {

            int count = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Cid from course", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    count += 1;
                }
            }
            countc.Text = count.ToString();
            con.Close();


        }
        protected void Btncourse_Click1(object sender, ImageClickEventArgs e)
        {
            string type = (string)Session["type"];
            string name = type + "course.aspx";

            Response.Redirect(name);
        }

        protected void Btnuser_Click1(object sender, ImageClickEventArgs e)
        {
            string type = (string)Session["type"];
            string name = type + "user.aspx";

            Response.Redirect(name);
        }

        protected void Btnattandance_Click(object sender, ImageClickEventArgs e)
        {
            string type = (string)Session["type"];
            string name = type + "attandance.aspx";

            Response.Redirect(name);
        }

        protected void Btnresult_Click(object sender, ImageClickEventArgs e)
        {
            string type = (string)Session["type"];
            string name = type + "result.aspx";

            Response.Redirect(name);
        }
    }
}