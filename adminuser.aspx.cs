using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace student_management_system
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            sm.Text = "";
            error.Text = "";
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (txtid.Text!=""&& txtname.Text!=""&& txtpassword.Text!=""&& dddep.SelectedItem.Text!=""&& DropDownList.SelectedItem.Text!=""&& ddtype.SelectedItem.Text!="")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                    {
                        con.Open();
                        SqlCommand sqlcmd = new SqlCommand("useradd", con);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Id", txtid.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@name", txtname.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@type", ddtype.SelectedItem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@dep", dddep.SelectedItem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@sem", DropDownList.SelectedItem.Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                        clear();
                        error.Text = "";
                        sm.Text = "User added";

                    }
                }
                catch (Exception)
                {
                    sm.Text = "";
                    error.Text = "User Already Exist";
                }
            }
            else
            {
                sm.Text = "";
                error.Text = "No Null Values";
            }
            
            void clear()
            {
                txtid.Text = txtname.Text = txtpassword.Text = "";
              
            }


        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminuseredit.aspx");
        }

        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}