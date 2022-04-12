using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Corporate
{
    public partial class BranchManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTotalBranchDetailsList();
                CorporateList();
                StateList();
                if(Convert.ToInt32(Session["CorporateId"].ToString())==0)
                {
                    rcbCorporateName.Visible = true;
                }
                else
                {
                    rcbCorporateName.Visible = false;
                }
                

                //LoadBranchDetailsByCorporate();
                BranchListView.ActiveViewIndex = 0;
            }
        }

        public void LoadTotalBranchDetailsList()
        {
            DataTable dtLoadCaseDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadCaseDetailsList = BusinessAccessLayer.LoadTotalBranchDetailsList(Convert.ToInt32(Session["CorporateId"].ToString()));

            if (dtLoadCaseDetailsList != null && dtLoadCaseDetailsList.Rows.Count > 0)
            {
                rgvBranchDetails.DataSource = dtLoadCaseDetailsList;
                rgvBranchDetails.DataBind();
            }
            else
            {
                rgvBranchDetails.DataSource = new object[] { }; ;
                rgvBranchDetails.DataBind();
            }
        }
        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                rcbCorporateName.DataSource = dtLoadCorporateList;
                rcbCorporateName.DataTextField = "CorporateName";
                rcbCorporateName.DataValueField = "CorporateId";
                rcbCorporateName.DataBind();

            }
            else
            {
                rcbCorporateName.DataSource = null;
                rcbCorporateName.DataBind();
            }
        }

        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                rcbState.DataSource = dtState;
                rcbState.DataTextField = "StateName";
                rcbState.DataValueField = "StateId";
                rcbState.DataBind();
            }
        }

        public void LoadBranchDetailsByCorporate()
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtBranchDetails = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(rcbCorporateName.SelectedValue));

            if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
            {
                rgvBranchDetails.DataSource = dtBranchDetails;
                rgvBranchDetails.DataBind();
            }
            else
            {
                rgvBranchDetails.DataSource = null;
                rgvBranchDetails.DataBind();
            }
        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
            BranchListView.ActiveViewIndex = 1;
        }

        protected void rgvBranchDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            if (rcbCorporateName.SelectedValue=="0")
            {                
                dtBranchDetails = BusinessAccessLayer.LoadTotalBranchDetailsList(Convert.ToInt32(Session["CorporateId"].ToString()));

                if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
                {
                    rgvBranchDetails.DataSource = dtBranchDetails;
                    //rgvBranchDetails.DataBind();
                }
                else
                {
                    rgvBranchDetails.DataSource = new object[] { };
                    //rgvBranchDetails.DataBind();
                }
            }
            else
            {
                dtBranchDetails = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(rcbCorporateName.SelectedValue));

                if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
                {
                    rgvBranchDetails.DataSource = dtBranchDetails;
                    //rgvBranchDetails.DataBind();
                }
                else
                {
                    rgvBranchDetails.DataSource = new object[] { };
                    //rgvBranchDetails.DataBind();
                }
            }
            
        }

        protected void rgvBranchDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblBranchDetailsId = (Label)rgvBranchDetails.Items[intIndex % 10].FindControl("lblBranchDetailsId"); // % 15 for page indexing
                    Variables.BranchDetailsId = Convert.ToInt32(lblBranchDetailsId.Text.Trim());
                    LoadBranchDetailsByIdForCorporate();

                    btnSave.Text = "Update";


                    BranchListView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadBranchDetailsByIdForCorporate()
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtBranchDetails = BusinessAccessLayer.LoadBranchDetailsByIdForCorporate(Variables.BranchDetailsId);


            if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
            {
                txtBranchName.Text = dtBranchDetails.Rows[0]["Branch"].ToString();
                txtPersonName.Text = dtBranchDetails.Rows[0]["PersonName"].ToString();
                txtMobileNo.Text = dtBranchDetails.Rows[0]["MobileNo"].ToString();
                txtEmailId.Text = dtBranchDetails.Rows[0]["EmailId"].ToString();
                rcbState.SelectedValue = dtBranchDetails.Rows[0]["State"].ToString();
                rcbState_SelectedIndexChanged(null, null);
                rcbCity.SelectedValue = dtBranchDetails.Rows[0]["City"].ToString();
                txtAddress.Text = dtBranchDetails.Rows[0]["Address"].ToString();

                if (dtBranchDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgvBranchDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateBranchDetailsByCorporate(0, Convert.ToInt32(rcbCorporateName.SelectedValue), 
                    txtBranchName.Text.Trim(), txtPersonName.Text.Trim(), txtMobileNo.Text.Trim(), txtEmailId.Text.Trim(), 
                    Convert.ToInt32(rcbState.SelectedValue), Convert.ToInt32(rcbCity.SelectedValue), 
                    txtAddress.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Branch Already Exists");
                }
                else
                {
                    showPopup("Warning", "Branch Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateBranchDetailsByCorporate(Variables.BranchDetailsId, Convert.ToInt32(rcbCorporateName.SelectedValue),
                    txtBranchName.Text.Trim(), txtPersonName.Text.Trim(), txtMobileNo.Text.Trim(), txtEmailId.Text.Trim(),
                    Convert.ToInt32(rcbState.SelectedValue), Convert.ToInt32(rcbCity.SelectedValue),
                    txtAddress.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Branch Already Exists");
                }
                else
                {
                    showPopup("Warning", "Branch Updated Successfully");

                }
            }
            ClearFields();
            if (Convert.ToInt32(Session["CorporateId"].ToString()) == 0)
            {
                rcbCorporateName.Visible = true;
                LoadBranchDetailsByCorporate();
            }
            else
            {
                rcbCorporateName.Visible = false;
                LoadTotalBranchDetailsList();
            }
            
        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtBranchName.Text = "";
            txtPersonName.Text = "";
            txtMobileNo.Text = "";
            txtEmailId.Text = "";
            rcbState.SelectedValue = "0";
            rcbCity.SelectedValue = "0";
            txtAddress.Text = "";
            rbIsActive.SelectedIndex = 0;
            BranchListView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BranchListView.ActiveViewIndex = 0;
        }

        protected void rcbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadBranchDetailsByCorporate();
        }

        protected void rcbState_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            rcbCity.Items.Clear();
            rcbCity.Items.Insert(0,"Select City");
            try
            {


                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbState.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    rcbCity.DataSource = dtCity;
                    rcbCity.DataTextField = "DistrictName";
                    rcbCity.DataValueField = "DistrictId";
                    rcbCity.DataBind();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}