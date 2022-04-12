using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Master
{
    public partial class AddDistrict : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DistrictView.ActiveViewIndex = 0;
                LoadState();
                LoadDistrict();
            }
        }

        public void LoadState()
        {
            DataTable dtState = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtState= BusinessAccessLayer.LoadStateDetailsDropDown();

            if(dtState!=null && dtState.Rows.Count>0)
            {
                cmbState.DataSource = dtState;
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
            }
        }

        public void LoadDistrict()
        {
            DataTable dtDistrict = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDistrict = BusinessAccessLayer.LoadDistrict();

            if(dtDistrict!=null && dtDistrict.Rows.Count>0)
            {
                rgvDistricts.DataSource = dtDistrict;
                rgvDistricts.DataBind();
            }
            else
            {
                rgvDistricts.DataSource = null;
                rgvDistricts.DataBind();
            }
        }

        public void LoadDistrictById()
        {
            DataTable dtDistrict = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDistrict = BusinessAccessLayer.LoadDistrictById(Variables.DistrictId);

            if (dtDistrict != null && dtDistrict.Rows.Count > 0)
            {
                txtDistrictName.Text = dtDistrict.Rows[0]["DistrictName"].ToString();
                cmbState.SelectedValue  = dtDistrict.Rows[0]["StateId"].ToString();

                if (dtDistrict.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }
            
        }

        protected void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictView.ActiveViewIndex = 1;
            //ClearFields();
        }

        protected void rgvDistricts_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblDistrictId = (Label)rgvDistricts.Items[intIndex % 10].FindControl("lblDistrictId"); // % 15 for page indexing
                    Variables.DistrictId = Convert.ToInt32(lblDistrictId.Text.Trim());
                    LoadDistrictById();

                    btnSave.Text = "Update";


                    DistrictView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        protected void rgvDistricts_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtDistrict = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDistrict = BusinessAccessLayer.LoadDistrict();

            if (dtDistrict != null && dtDistrict.Rows.Count > 0)
            {
                rgvDistricts.DataSource = dtDistrict;
                //rgvDistricts.DataBind();
            }
            else
            {
                rgvDistricts.DataSource = null;
                //rgvDistricts.DataBind();
            }
        }

        protected void rgvDistricts_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateDistrict(0,Convert.ToInt32(cmbState.SelectedValue), txtDistrictName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateDistrict(Variables.DistrictId,Convert.ToInt32(cmbState.SelectedValue), txtDistrictName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
            LoadDistrict();
        }

        public void ClearFields()
        {
            txtDistrictName.Text = "";
            rbIsActive.SelectedIndex = 0;
            DistrictView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page,this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DistrictView.ActiveViewIndex = 0;
        }
    }
}