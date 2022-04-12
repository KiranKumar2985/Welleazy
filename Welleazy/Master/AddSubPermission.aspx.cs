using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class AddSubPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPermissionDropDown();
                LoadSubPermission();
                SubPermissionView.ActiveViewIndex = 0;
            }
        }

        public void LoadPermissionDropDown()
        {
            DataTable dtPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtPermission = BusinessAccessLayer.LoadPermissionDropDown();

            if (dtPermission != null && dtPermission.Rows.Count > 0)
            {
                cmbPermission.DataSource = dtPermission;
                cmbPermission.DataTextField = "Description";
                cmbPermission.DataValueField = "PermissionId";
                cmbPermission.DataBind();
            }
            else
            {
                cmbPermission.DataSource = null;
                cmbPermission.DataBind();
            }
        }

        public void LoadSubPermission()
        {
            DataTable dtSubPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtSubPermission = BusinessAccessLayer.LoadSubPermission();

            if (dtSubPermission != null && dtSubPermission.Rows.Count > 0)
            {
                rgSubPermission.DataSource = dtSubPermission;
                rgSubPermission.DataBind();
            }
            else
            {
                rgSubPermission.DataSource = null;
                rgSubPermission.DataBind();
            }
        }

        //protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        //{
        //    SubPermissionView.ActiveViewIndex = 1;
        //}

        protected void rgSubPermission_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgSubPermission_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtSubPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtSubPermission = BusinessAccessLayer.LoadSubPermission();

            if (dtSubPermission != null && dtSubPermission.Rows.Count > 0)
            {
                rgSubPermission.DataSource = dtSubPermission;
                //rgPermission.DataBind();
            }
            else
            {
                rgSubPermission.DataSource = null;
                //rgPermission.DataBind();
            }
        }

        protected void rgSubPermission_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblPermissionId = (Label)rgSubPermission.Items[intIndex % 10].FindControl("lblSubPermissionId"); // % 15 for page indexing
                    Variables.SubPermissionId = Convert.ToInt32(lblPermissionId.Text.Trim());
                    LoadSubPermissionById();

                    btnSave.Text = "Update";


                    SubPermissionView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadSubPermissionById()
        {
            DataTable dtSubPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtSubPermission = BusinessAccessLayer.LoadSubPermissionById(Variables.SubPermissionId);


            if (dtSubPermission != null && dtSubPermission.Rows.Count > 0)
            {
                txtSubPermission.Text = dtSubPermission.Rows[0]["SubPermission"].ToString();
                cmbPermission.SelectedValue= dtSubPermission.Rows[0]["PermissionId"].ToString();

                if (dtSubPermission.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateSubPermission(0,Convert.ToInt32(cmbPermission.SelectedValue), txtSubPermission.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateSubPermission(Variables.SubPermissionId, Convert.ToInt32(cmbPermission.SelectedValue), txtSubPermission.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
            LoadSubPermission();
        }

        public void ClearFields()
        {
            txtSubPermission.Text = "";
            cmbPermission.SelectedValue = "0";
            rbIsActive.SelectedIndex = 0;
            SubPermissionView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }
        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnSubPermission_Click(object sender, EventArgs e)
        {
            SubPermissionView.ActiveViewIndex = 1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SubPermissionView.ActiveViewIndex = 0;
        }
    }
}