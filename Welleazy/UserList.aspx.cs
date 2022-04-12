using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;

namespace Welleazy
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserListDetails();
            }
        }

        public void LoadUserListDetails()
        {
            DataTable dtLoadUserListDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadUserListDetails = BusinessAccessLayer.LoadUserListDetails();

            if (dtLoadUserListDetails != null && dtLoadUserListDetails.Rows.Count > 0)
            {
                rgvUserListDetails.DataSource = dtLoadUserListDetails;
                rgvUserListDetails.DataBind();
            }
            else
            {
                rgvUserListDetails.DataSource = new object[] { };
                rgvUserListDetails.DataBind();
            }
        }
        protected void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_Contact_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_Role_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_SubRole_TextChanged(object sender, EventArgs e)
        {

        }

        protected void rgvUserListDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblUserId = (Label)rgvUserListDetails.Items[intIndex % 10].FindControl("lblUserId"); // % 15 for page indexing
                    Variables.user_id = Convert.ToInt32(lblUserId.Text.Trim());

                    Response.Redirect("~/AddUser.aspx?UserId="+Variables.user_id);
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void rgvUserListDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvUserListDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
    }
}