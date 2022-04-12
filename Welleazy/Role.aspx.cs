using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Welleazy
{
    public partial class Role : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"]!=null)
                {
                    RoleDetails();
                }
            }
        }

        public void RoleDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchRoleList = new SqlCommand("Role_CRUD", con);
            cmdFetchRoleList.CommandType = CommandType.StoredProcedure;
            cmdFetchRoleList.Parameters.AddWithValue("Action", "GetRole");
            cmdFetchRoleList.Parameters.AddWithValue("@role_id", Label2.Text);

            SqlDataAdapter daFetchRoleList = new SqlDataAdapter(cmdFetchRoleList);
            DataTable dtFetchRoleList = new DataTable();

            daFetchRoleList.Fill(dtFetchRoleList);

            if (dtFetchRoleList != null && dtFetchRoleList.Rows.Count > 0)
            {
                GridViewRole.DataSource = dtFetchRoleList;
                GridViewRole.DataBind();
            }
            else
            {
                GridViewRole.DataSource = null;
                GridViewRole.DataBind();
            }
           
        }
        protected void GridViewRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RoleList.Visible = false;
            EditMode.Visible = true;

            if (e.CommandName.Equals("Edit"))
            {
                int RoleID = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewRole.Rows[rowIndex];

                RoleID = Convert.ToInt32((row.FindControl("lblRoleId") as Label).Text);

                Label2.Text = RoleID.ToString();
                FetchRole();
                //Response.Redirect("~/Role.aspx");
            }
            

            //if (e.CommandName.Equals("Delete"))
            //{
            //    int DCId = 0;
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);

            //    GridViewRow row = gvServiceProviderDetails.Rows[rowIndex];

            //    DCId = Convert.ToInt32((row.FindControl("lblRoleId") as Label).Text);

            //    Variables.DcId = DCId;
            //    //Response.Redirect("~/diagnostic_center/AddEditDC.aspx");

            //}

        }

        protected void GridViewRole_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridViewRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRole.PageIndex = e.NewPageIndex;
            RoleDetails();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            txt_Role.Text = "";
            Label2.Text = "";
            RoleList.Visible = false;
            EditMode.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select count(*) from tbl_roles where role_id='"+Label2.Text+"' ", con);
        cmd.Connection = con;
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            SqlCommand cmd1 = new SqlCommand("[Role_CRUD]", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Action", "UpdateRole");
            cmd1.Parameters.AddWithValue("@role_id", Label2.Text);
            cmd1.Parameters.AddWithValue("@name", txt_Role.Text);
            cmd1.Parameters.AddWithValue("@description", "");
            cmd1.Parameters.AddWithValue("@created_by", Session["username"].ToString());
            cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd").ToString());
            cmd1.ExecuteNonQuery();
            Response.Write("<script>alert('Record Update Successfully!')</script>" + "<script>window.location.href='/Role.aspx';</script>");
            con.Close();
        }
        else
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("[Role_CRUD]", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "InsertRole");
                cmd1.Parameters.AddWithValue("@role_id", Label2.Text);
                cmd1.Parameters.AddWithValue("@name", txt_Role.Text);
                cmd1.Parameters.AddWithValue("@description", "");
                cmd1.Parameters.AddWithValue("@created_by", Session["username"].ToString());
                cmd1.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd").ToString());
                cmd1.Parameters.AddWithValue("@updated_at", "");
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Record Insert Successfully!')</script>" + "<script>window.location.href='/Role.aspx';</script>");
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='/Role.aspx';</script>");
            RoleList.Visible = true;
            EditMode.Visible = false;
        }

        public void FetchRole()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdRoleList = new SqlCommand("Role_CRUD", con);
            cmdRoleList.CommandType = CommandType.StoredProcedure;
            cmdRoleList.Parameters.AddWithValue("Action", "EditRole");
            SqlParameter paramRoleID = new SqlParameter("@role_id", Label2.Text);

            cmdRoleList.Parameters.Add(paramRoleID);

            SqlDataAdapter daRoleList = new SqlDataAdapter(cmdRoleList);
            DataTable dtRoleList = new DataTable();
            daRoleList.Fill(dtRoleList);

            if (dtRoleList != null && dtRoleList.Rows.Count > 0)
            {
                txt_Role.Text = dtRoleList.Rows[0]["name"].ToString();

            }
        }

        protected void GridViewRole_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}