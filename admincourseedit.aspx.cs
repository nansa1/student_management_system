﻿using System;
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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
        }
        void PopulateGridview1()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM course where Cid ='" + txtid.SelectedItem.Text.Trim()+ "'", con);
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
            PopulateGridview1();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            PopulateGridview1();


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            PopulateGridview1();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string cname = (GridView1.Rows[e.RowIndex].FindControl("txtCname") as TextBox).Text.Trim();
                string tname = (GridView1.Rows[e.RowIndex].FindControl("txttname") as TextBox).Text.Trim();
                string tid = (GridView1.Rows[e.RowIndex].FindControl("txttid") as TextBox).Text.Trim();
                string Credit = (GridView1.Rows[e.RowIndex].FindControl("txtcredit") as TextBox).Text.Trim();
                string sem = (GridView1.Rows[e.RowIndex].FindControl("txtSem") as TextBox).Text.Trim();
                string ids = (GridView1.Rows[e.RowIndex].FindControl("txtCid") as Label).Text.Trim();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE course SET [Course name]=@cname,Sem=@Sem,teachername=@teachername,teacherid=@teacherid,credit=@credit WHERE Cid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@cname", cname);
                    sqlCmd.Parameters.AddWithValue("@Sem", sem);
                    sqlCmd.Parameters.AddWithValue("@teachername", tname);
                    sqlCmd.Parameters.AddWithValue("@teacherid", tid);
                    sqlCmd.Parameters.AddWithValue("@credit", Credit);
                    sqlCmd.Parameters.AddWithValue("@id", ids);
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ids = GridView1.DataKeys[e.RowIndex].Value.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
                {
                    con.Open();
                    string query = "DELETE FROM course WHERE Cid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", ids);
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview1();
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
            Response.Redirect("admincourse.aspx");
        }
    }
}