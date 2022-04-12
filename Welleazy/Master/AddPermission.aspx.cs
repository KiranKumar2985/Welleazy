using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class AddPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadPermission();
                PermissionView.ActiveViewIndex = 0;
            }
        }

        public void LoadPermission()
        {
            DataTable dtPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtPermission = BusinessAccessLayer.LoadPermission();

            if (dtPermission != null && dtPermission.Rows.Count > 0)
            {
                rgPermission.DataSource = dtPermission;
                rgPermission.DataBind();
            }
            else
            {
                rgPermission.DataSource = null;
                rgPermission.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdatePermission(0, txtDesription.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdatePermission(Variables.PermissionId, txtDesription.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");
                    
                }
            }
            ClearFields();
            LoadPermission();

        }

        public void ClearFields()
        {
            txtDesription.Text = "";
            rbIsActive.SelectedIndex = 0;
            PermissionView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }
        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void rgPermission_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblPermissionId = (Label)rgPermission.Items[intIndex % 10].FindControl("lblPermissionId"); // % 15 for page indexing
                    Variables.PermissionId = Convert.ToInt32(lblPermissionId.Text.Trim());
                    LoadPermissionById();

                    btnSave.Text = "Update";


                    PermissionView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadPermissionById()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadPermissionById(Variables.PermissionId);


            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                txtDesription.Text = dtStateDetails.Rows[0]["Description"].ToString();

                if (dtStateDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgPermission_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtPermission = BusinessAccessLayer.LoadPermission();

            if (dtPermission != null && dtPermission.Rows.Count > 0)
            {
                rgPermission.DataSource = dtPermission;
                //rgPermission.DataBind();
            }
            else
            {
                rgPermission.DataSource = null;
                //rgPermission.DataBind();
            }
        }

        protected void rgPermission_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        
        protected void btnPermission_Click(object sender, EventArgs e)
        {
            PermissionView.ActiveViewIndex = 1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PermissionView.ActiveViewIndex = 0;
        }
    }
}