using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Case
{
    public partial class EConsultantCaseDetails : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEConsultantCaseDetails();
                LoadCorporate();
                LoadDoctorDetails();
                LoadBranchDetails();
                EConultantView.ActiveViewIndex = 0;
            }
        }


        public void LoadEConsultantCaseDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();


            dtCaseDetails = BusinessAccessLayer.LoadEConsultantCaseDetails();
            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                rgvEConsultancyCaseDetails.DataSource = dtCaseDetails;
                rgvEConsultancyCaseDetails.DataBind();
            }
            else
            {
                rgvEConsultancyCaseDetails.DataSource = null;
                rgvEConsultancyCaseDetails.DataBind();
            }

        }






        protected void btnSave_Click(object sender, EventArgs e)
        {



        }



        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EConultantView.ActiveViewIndex = 0;
            //ClearFields();
        }

        protected void rgvEConsultancyCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "AssignToDoctor")
                {


                    Label lbl_EConsultantCaseDetailsId = (Label)rgvEConsultancyCaseDetails.Items[intIndex % 10].FindControl("lblEConsultantCaseDetailsId");

                    //Response.Write("hi");
                    Variables.EConsultantCaseDetailsId = Convert.ToInt32(lbl_EConsultantCaseDetailsId.Text.Trim());
                    Response.Redirect("~/Appointment/EConsultantAppointment.aspx");
                }

                if (e.CommandName == "EditRow")
                {
                    Label lblEConsultantCaseDetailsId = (Label)rgvEConsultancyCaseDetails.Items[intIndex % 10].FindControl("lblEConsultantCaseDetailsId"); // % 15 for page indexing
                    Variables.EConsultantCaseDetailsId = Convert.ToInt32(lblEConsultantCaseDetailsId.Text.Trim());
                    Response.Redirect("~/Case/AddEConsultantCase.aspx");
                }


                // LoadEConsultantCaseDetailsById();

                // btnSave.Text = "Update";


                EConultantView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }

        }

        //public void LoadEConsultantCaseDetailsById()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    DataTable dtCaseDetails = new DataTable();
        //    dtCaseDetails = BusinessAccessLayer.LoadEConsultantCaseDetailsById(Variables.EConsultantCaseDetailsId);

        //    if (dtCaseDetails != null && dtCaseDetails.Rows.Count>0)
        //    {
        //        txtCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
        //        dtpCaseEntryDate.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseEntryDateTime"].ToString());
        //        cmbBranch.SelectedValue = (dtCaseDetails.Rows[0]["BranchId"].ToString());
        //        cmbAssignExecutive.SelectedValue = (dtCaseDetails.Rows[0]["AssignedExecutiveId"].ToString());
        //        cmbCaseMode.SelectedValue = (dtCaseDetails.Rows[0]["CaseReceivedMode"].ToString());

        //        dtpCaseRecordedDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseRecievedDateTime"].ToString());

        //        cmbCorporateName.SelectedValue = (dtCaseDetails.Rows[0]["CorporateId"].ToString());
        //        cmbCorporateBranchId.SelectedValue = (dtCaseDetails.Rows[0]["CorporateBranchId"].ToString());
        //        cmbServicesOffered.SelectedValue = (dtCaseDetails.Rows[0]["ServicesOffered"].ToString());

        //        txtEmployeeName.Text = dtCaseDetails.Rows[0]["EmployeeName"].ToString();
        //        txtMobileNo.Text = dtCaseDetails.Rows[0]["MobileNo"].ToString();
        //        cmbGender.SelectedValue = dtCaseDetails.Rows[0]["GenderId"].ToString();


        //        txtEmployeeEmailId.Text = dtCaseDetails.Rows[0]["EMailId"].ToString();
        //        txtNoOfFreeConsultations.Text = dtCaseDetails.Rows[0]["NoOfFreeConsultations"].ToString();
        //        txtNoOfConsultationRecorded.Text = dtCaseDetails.Rows[0]["NoOfConsultationReceived"].ToString();

        //        cmbConsultationType.SelectedValue = dtCaseDetails.Rows[0]["ConsultationType"].ToString();
        //        cmbCaseType.SelectedValue = dtCaseDetails.Rows[0]["CaseType"].ToString();
        //        cmbPaymentType.SelectedValue = dtCaseDetails.Rows[0]["PaymentType"].ToString();
        //        cmbCaseFor.SelectedValue = dtCaseDetails.Rows[0]["CaseFor"].ToString();
        //        cmbCustomerProfile.SelectedValue = dtCaseDetails.Rows[0]["CustomerProfile"].ToString();
        //        cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString();

        //        dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
        //        cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
        //        cmbDoctorQualification.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
        //        cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

        //        dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDataTime"].ToString());

        //        txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

        //        //btnSave.Text = "Update";
        //    }

        //}

        protected void rgvEConsultancyCaseDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvEConsultancyCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void chkCaseId_CheckedChanged(object sender, EventArgs e)
        {



            CheckBox chk = (CheckBox)sender;
            GridDataItem editItem = (GridDataItem)chk.NamingContainer;
            GridDataItem ditem = (GridDataItem)editItem;
            ditem.Selected = true;

            int index = ditem.ItemIndex;

            Label lbl = (Label)editItem.FindControl("lbl_EConsultantCaseDetailsId");


            Variables.EConsultantCaseDetailsId = Convert.ToInt32(lbl.Text.Trim());
            Response.Redirect("~/Appointment/EConsultantAppointment.aspx");



        }

        protected void txtSearchCaseId_TextChanged(object sender, EventArgs e)
        {
            //txtCaseStatus.Text = "";
            //txtsearchCorporateName.Text = "";
            //cmbSearchCaseStatus.SelectedValue = "0";
            //SearchEConsultantCaseDetails(txtSearchCaseId.Text.Trim(),txtsearchCorporateName.Text.Trim(),cmbSearchCaseStatus.SelectedValue,"CaseId");
        }

        protected void txtSearchDoctor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtsearchCorporateName_TextChanged(object sender, EventArgs e)
        {
            //txtCaseStatus.Text = "";
            //txtSearchCaseId.Text = "";
            //cmbSearchCaseStatus.SelectedValue = "0";
            //SearchEConsultantCaseDetails(txtSearchCaseId.Text.Trim(), txtsearchCorporateName.Text.Trim(), cmbSearchCaseStatus.SelectedValue,"CorporateName");
        }

        protected void txtCaseStatus_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmbSearchCaseStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //txtSearchCaseId.Text = "";
            //txtsearchCorporateName.Text = "";
            //SearchEConsultantCaseDetails(txtSearchCaseId.Text.Trim(), txtsearchCorporateName.Text.Trim(), cmbSearchCaseStatus.SelectedValue, "CaseStatus");
        }

        public void LoadCorporate()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                rcbClientName.DataSource = dtCorporateDetails;
                rcbClientName.DataTextField = "CorporateName";
                rcbClientName.DataValueField = "CorporateId";
                rcbClientName.DataBind();
            }
        }

        public void LoadDoctorDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccessLayer.LoadDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                //cmbDoctorName.DataSource = dtDoctorDetails;
                //cmbDoctorName.DataTextField = "DoctorName";
                //cmbDoctorName.DataValueField = "DoctorId";
                //cmbDoctorName.DataBind();
            }
        }

        public void LoadBranchDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccessLayer.LoadBranchDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                rcbBranchSearch.DataSource = dtDoctorDetails;
                rcbBranchSearch.DataTextField = "BranchName";
                rcbBranchSearch.DataValueField = "BranchId";
                rcbBranchSearch.DataBind();
            }
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {
            //LoadEConsultantCaseDetails();

            string SearchType = "";

            //if(cmbCorporateName.SelectedValue!="0" && txtSearchCaseId.Text!="" && cmbBranchName.SelectedValue!="0" && txtSearchEmployeeName.Text!="" && txtSearchMobileNo.Text!="" && txtSearchEmailId.Text!="" && cmbConsultationType.SelectedValue!="0" && cmbDoctorName.SelectedValue!="0" && cmbSearchCaseStatus.SelectedValue!="0")
            //{
            //    SearchType = "0";
            //}

            //SearchEConsultantCaseDetails(txtSearchCaseId.Text.Trim(), Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbBranchName.SelectedValue),
            //    txtSearchEmployeeName.Text.Trim(),txtSearchMobileNo.Text.Trim(),txtSearchEmailId.Text.Trim(),Convert.ToInt32(cmbConsultationType.SelectedValue),
            //    Convert.ToInt32(cmbDoctorName.SelectedValue),
            //    Convert.ToInt32(cmbSearchCaseStatus.SelectedValue), "CaseStatus");
        }

        public void SearchEConsultantCaseDetails(string CaseId, Int32 CorporateId, Int32 BranchId, string EmployeeName, string MobileNo, string EmailId, Int32 ConsultationType, Int32 DoctorId,
            Int32 CaseStatus, string SearchType)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtPackage = new DataTable();
            dtPackage = BusinessAccessLayer.SearchEConsultantCaseDetails(CaseId, CorporateId, BranchId, EmployeeName, MobileNo, EmailId, ConsultationType, DoctorId,
             CaseStatus, SearchType);

            if (dtPackage != null && dtPackage.Rows.Count > 0)
            {
                rgvEConsultancyCaseDetails.DataSource = dtPackage;
                rgvEConsultancyCaseDetails.DataBind();

            }
            else
            {
                rgvEConsultancyCaseDetails.DataSource = null;
                rgvEConsultancyCaseDetails.DataBind();
            }

        }

        protected void btnEConsultant_Click(object sender, EventArgs e)
        {
            EConultantView.ActiveViewIndex = 1;
        }

        protected void btnAdvanced_Click(object sender, EventArgs e)
        {
            if (AdvancedSearch.Visible == true)
            {
                AdvancedSearch.Visible = false;
            }
            else
            {
                AdvancedSearch.Visible = true;
            }
        }
    }
}