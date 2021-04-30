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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelpassworderror.Text = "";

            if (Session["attement"] == null)
            {
                Session["attement"] = 0;
            }
            
        }
        

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int User_Name = (int)Session["attement"];
            
            if (User_Name != 5)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from user_data where Id=@Id and password=@password", con);
                cmd.Parameters.AddWithValue("@Id", Txtid.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Txtpassword.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();


                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["userid"] = Txtid.Text.Trim();
                    Session["attement"] = 0;
                
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Labelpassworderror.Text = "Incorrect user or password";
                    int t = (int)Session["attement"];
                    t += 1;
                    Session["attement"] = t;
                } 
            }
            else
            {
               
                Labelpassworderror.Text = "Too many trys close and start again";
            }
        }
    }
}