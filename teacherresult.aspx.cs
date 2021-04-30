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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "teacher")
            {
                Response.Redirect("login.aspx");
            }
        }
        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM user_data where dep ='" + ddtdep.SelectedItem.Text.Trim() + "' and sem='" + DropDownList1.SelectedItem.Text.Trim() + "'", con);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        

        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            PopulateGridview();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("teacherresultedit.aspx");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            PopulateGridview();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Marks where Student_id=@Id and Courseid=@cid", conn);
            cmd.Parameters.AddWithValue("@Id", (GridView1.Rows[e.RowIndex].FindControl("id") as Label).Text.Trim());
            cmd.Parameters.AddWithValue("@cid", ddcid.SelectedItem.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Open();


            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (dt.Rows.Count == 0)
            {
                try
                {
                    string marks = (GridView1.Rows[e.RowIndex].FindControl("txtMarks") as TextBox).Text.Trim();
                    int mark = Convert.ToInt32(marks);
                    string sid = (GridView1.Rows[e.RowIndex].FindControl("id") as Label).Text.Trim();
                    string Sem = DropDownList1.SelectedItem.Text.Trim();
                    string Dep = ddtdep.SelectedItem.Text.Trim();
                    string Courseid = ddcid.SelectedItem.Text.Trim();
                    string Coursename = ddcname.SelectedItem.Text.Trim();
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                    {
                        con.Open();
                        string query = "INSERT INTO Marks (Student_id,Sem,Dep,Courseid,Coursename,Marks) VALUES (@Student_id,@Sem,@Dep,@Courseid,@Coursename,@Marks)";
                        SqlCommand sqlCmd = new SqlCommand(query, con);
                        sqlCmd.Parameters.AddWithValue("@Student_id", sid);
                        sqlCmd.Parameters.AddWithValue("@Sem", Sem);
                        sqlCmd.Parameters.AddWithValue("@Dep", Dep);
                        sqlCmd.Parameters.AddWithValue("@Courseid", Courseid);
                        sqlCmd.Parameters.AddWithValue("@Coursename", Coursename);
                        sqlCmd.Parameters.AddWithValue("@Marks", mark);
                        sqlCmd.ExecuteNonQuery();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    lblSuccessMessage.Text = "";
                    lblErrorMessage.Text = ex.Message;
                }
            }
            else
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "Marks Already present";
            }
        }

        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}