using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Welleazy
{
    public partial class SubRole : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    SubRoleDetails();
                }
            }
        }

        public void SubRoleDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select tsr.subrole_id, tsr.role_id, tsr.subrole, tr.name from tbl_subroles as tsr join tbl_roles as tr on tr.role_id=tsr.role_id", con);

            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dr.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewSubRole.DataSource = dt;
                GridViewSubRole.DataBind();
            }
            else
            {
                GridViewSubRole.DataSource = null;
                GridViewSubRole.DataBind();
            }

        }

        public void SubRoleDetails_Role()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select tsr.subrole_id, tsr.role_id, tsr.subrole, tr.name from tbl_subroles as tsr join tbl_roles as tr on tr.role_id=tsr.role_id where tr.name like '%' + '"+txt_role.Text+"' + '%'", con);

            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dr.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewSubRole.DataSource = dt;
                GridViewSubRole.DataBind();
            }
            else
            {
                GridViewSubRole.DataSource = null;
                GridViewSubRole.DataBind();
            }

        }
        public void SubRoleDetails_SubRole()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select tsr.subrole_id, tsr.role_id, tsr.subrole, tr.name from tbl_subroles as tsr join tbl_roles as tr on tr.role_id=tsr.role_id where tsr.subrole like '%' + '" + txt_subrole.Text + "' + '%'", con);

            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dr.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewSubRole.DataSource = dt;
                GridViewSubRole.DataBind();
            }
            else
            {
                GridViewSubRole.DataSource = null;
                GridViewSubRole.DataBind();
            }

        }
        protected void GridViewSubRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewSubRole.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                Variables.DcId = DCId;
                Response.Redirect("~/SubRole.aspx");

            }

            //if (e.CommandName.Equals("Delete"))
            //{
            //    int DCId = 0;
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);

            //    GridViewRow row = gvServiceProviderDetails.Rows[rowIndex];

            //    DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

            //    Variables.DcId = DCId;
            //    //Response.Redirect("~/diagnostic_center/AddEditDC.aspx");

            //}

        }

        protected void GridViewSubRole_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridViewSubRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewSubRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSubRole.PageIndex = e.NewPageIndex;
            SubRoleDetails();
        }

        protected void txt_role_TextChanged(object sender, EventArgs e)
        {
            txt_subrole.Text = "";
            SubRoleDetails_Role();
        }

        protected void txt_subrole_TextChanged(object sender, EventArgs e)
        {
            txt_role.Text = "";
            SubRoleDetails_SubRole();
        }
   
    }
}