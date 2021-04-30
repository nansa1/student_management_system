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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string)Session["type"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            sm.Text = "";
            error.Text = "";

        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {


            if (txtcid.Text!=""&& txtcname.Text!=""&& txtsem.Text!=""&& txtcredit.Text!=""&& ddcdep.SelectedItem.Text!="")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                    {
                        con.Open();
                        SqlCommand sqlcmd = new SqlCommand("courseadd", con);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Cid", txtcid.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Cname", txtcname.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Sem", txtsem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@dep", ddcdep.SelectedItem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@teachername", ddteachername.SelectedItem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@teacherid", ddtid.SelectedItem.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@credit", txtcredit.Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                        clear();
                        error.Text = "";
                        sm.Text = "Course added";
                    }
                }
                catch (Exception)
                {
                    sm.Text = "";
                    error.Text = "Course Already Exist";
                }
            }
            else
            {
                sm.Text = "";
                error.Text = "No Null values";
            }

            
            void clear()
            {

                txtcid.Text = txtcname.Text = txtsem.Text = txtcredit.Text = "";
            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("admincourseedit.aspx");
        }

        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}