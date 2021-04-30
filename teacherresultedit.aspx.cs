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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "teacher")
            {
                Response.Redirect("login.aspx");
            }
        }
        void PopulateGridview2()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Marks where dep ='" + ddtdep.SelectedItem.Text.Trim() + "' and sem='" + DropDownList1.SelectedItem.Text.Trim() + "' and Courseid='" + ddcid.SelectedItem.Text.Trim() + "'", con);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView2.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            PopulateGridview2();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView2.EditIndex = e.NewEditIndex;
            PopulateGridview2();


        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            PopulateGridview2();
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string marks = (GridView2.Rows[e.RowIndex].FindControl("txtMarks") as TextBox).Text.Trim();
                int mark = Convert.ToInt32(marks);
                string ids = GridView2.DataKeys[e.RowIndex].Value.ToString();
                int id = Convert.ToInt32(ids);
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE Marks SET Marks=@Marks WHERE id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@Marks", mark);
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.ExecuteNonQuery();
                    lblSuccessMessage.Text = "Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ids = GridView2.DataKeys[e.RowIndex].Value.ToString();
            int id = Convert.ToInt32(ids);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Marks WHERE id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview2();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("teacherresult.aspx");
        }
    }
}