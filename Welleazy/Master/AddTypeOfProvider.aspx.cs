using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class AddTypeOfProvider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProvideTypeDetails();
                StateView.ActiveViewIndex = 0;
            }

        }

        public void LoadProvideTypeDetails()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadProvideTypeDetails();

            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                rgTypeofProvider.DataSource = dtStateDetails;
                rgTypeofProvider.DataBind();
            }
            else
            {
                rgTypeofProvider.DataSource = null;
                rgTypeofProvider.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateProvideType(0, txtProviderType.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Provider Type Already Exists");
                }
                else
                {
                    showPopup("Warning", "Prvider Type Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateProvideType(Variables.ProviderTypeId, txtProviderType.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Provider Type Already Exists");
                }
                else
                {
                    showPopup("Warning", "Prvider Type Updated Successfully");

                }
            }
            ClearFields();
            LoadProvideTypeDetails();

        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtProviderType.Text = "";
            rbIsActive.SelectedIndex = 0;
            StateView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            StateView.ActiveViewIndex = 1;
        }

        protected void rgTypeofProvider_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblProviderTypeId = (Label)rgTypeofProvider.Items[intIndex % 10].FindControl("lblProviderTypeId"); // % 15 for page indexing
                    Variables.ProviderTypeId = Convert.ToInt32(lblProviderTypeId.Text.Trim());
                    LoadProvideTypeDetailsById();

                    btnSave.Text = "Update";


                    StateView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadProvideTypeDetailsById()
        {
            DataTable dtTypeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtTypeDetails = BusinessAccessLayer.LoadProvideTypeDetailsById(Variables.ProviderTypeId);


            if (dtTypeDetails != null && dtTypeDetails.Rows.Count > 0)
            {
                txtProviderType.Text = dtTypeDetails.Rows[0]["ProviderType"].ToString();

                if (dtTypeDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgTypeofProvider_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtTypeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtTypeDetails = BusinessAccessLayer.LoadProvideTypeDetails();

            if (dtTypeDetails != null && dtTypeDetails.Rows.Count > 0)
            {
                rgTypeofProvider.DataSource = dtTypeDetails;
                //rgTypeofProvider.DataBind();
            }
            else
            {
                rgTypeofProvider.DataSource = null;
                //rgTypeofProvider.DataBind();
            }

        }

        protected void rgTypeofProvider_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            StateView.ActiveViewIndex = 0;

        }

        protected void btnType_Click(object sender, EventArgs e)
        {
            StateView.ActiveViewIndex = 1;
        }
    }
}