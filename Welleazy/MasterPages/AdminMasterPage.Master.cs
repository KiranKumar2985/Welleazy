using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.MasterPages
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] != null)
                {
                    Label1.Text = Session["username"].ToString();
                    LoadUserAccessRoles();
                }
                else
                {
                    Response.Write("<script>alert('Your session has expired!')</script>" + "<script>window.location.href='/Login.aspx';</script>");
                }

            }
        }

        public void LoadUserAccessRoles()
        {
            DataTable dtUserAccessRole = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtUserAccessRole = BusinessAccessLayer.LoadUserAccessRoles(Convert.ToInt32(Session["UserId"].ToString()));

            string UserRoles = "";

            if (dtUserAccessRole != null && dtUserAccessRole.Rows.Count > 0)
            {
                UserRoles = dtUserAccessRole.Rows[0]["UserRolePermissions"].ToString();
            }

            string[] Roles = UserRoles.Split(',');


        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Successfully Logout...!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
        }
    }
}