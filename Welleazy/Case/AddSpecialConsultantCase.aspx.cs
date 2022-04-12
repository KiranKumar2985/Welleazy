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
    public partial class AddSpecialConsultantCase : System.Web.UI.Page
    {
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Variables.SpecialityConsultantCaseDetailsId == 0)
                {
                    ClearFields();
                    btnSave.Text = "Save";
                    GenearateSpecialityConsultancyCaseId();
                }
                else
                {
                    LoadEConsultantCaseDetailsById();
                }


                //LoadSpecialityConsultantCaseDetails();
                //txtCaseEntryDate.Text = DateTime.Now.ToString();

                dtpCaseEntryDate.SelectedDate = DateTime.Now;
                LoadDoctorDetails();
                LoadMasterLanguage();

                //LoadMasterDocuments();
                //LoadState();
                LoadCorporate();
                //SpecialistConultantView.ActiveViewIndex = 0;
            }
        }

        public void LoadEConsultantCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadSpecialistConsultantCaseDetailsById(Variables.SpecialityConsultantCaseDetailsId);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                txtCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
                dtpCaseEntryDate.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseEntryDateTime"].ToString());
                cmbBranch.SelectedValue = (dtCaseDetails.Rows[0]["BranchId"].ToString());
                cmbAssignExecutive.SelectedValue = (dtCaseDetails.Rows[0]["AssignedExecutiveId"].ToString());
                cmbCaseMode.SelectedValue = (dtCaseDetails.Rows[0]["CaseReceivedMode"].ToString());

                dtpCaseRecordedDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseRecievedDateTime"].ToString());

                cmbCorporateName.SelectedValue = (dtCaseDetails.Rows[0]["CorporateId"].ToString());
                cmbCorporateBranchId.SelectedValue = (dtCaseDetails.Rows[0]["CorporateBranchId"].ToString());
                cmbServicesOffered.SelectedValue = (dtCaseDetails.Rows[0]["ServicesOffered"].ToString());

                txtEmployeeName.Text = dtCaseDetails.Rows[0]["EmployeeName"].ToString();
                txtMobileNo.Text = dtCaseDetails.Rows[0]["MobileNo"].ToString();
                cmbGender.SelectedValue = dtCaseDetails.Rows[0]["GenderId"].ToString();


                txtEmployeeEmailId.Text = dtCaseDetails.Rows[0]["EMailId"].ToString();
                txtNoOfFreeConsultations.Text = dtCaseDetails.Rows[0]["NoOfFreeConsultations"].ToString();
                txtNoOfConsultationRecorded.Text = dtCaseDetails.Rows[0]["NoOfConsultationReceived"].ToString();

                cmbConsultationType.SelectedValue = dtCaseDetails.Rows[0]["ConsultationType"].ToString();
                cmbCaseType.SelectedValue = dtCaseDetails.Rows[0]["CaseType"].ToString();
                cmbPaymentType.SelectedValue = dtCaseDetails.Rows[0]["PaymentType"].ToString();
                cmbCaseFor.SelectedValue = dtCaseDetails.Rows[0]["CaseFor"].ToString();
                cmbCustomerProfile.SelectedValue = dtCaseDetails.Rows[0]["CustomerProfile"].ToString();
                cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString();

                dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                cmbDoctorQualification.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();
                dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDateTime"].ToString());
                txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

                btnSave.Text = "Update";
            }

        }

        public void GenearateSpecialityConsultancyCaseId()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseId = new DataTable();
            Int32 CaseId = 0;

            dtCaseId = BusinessAccessLayer.GenearateSpecialistConsultancyCaseId();
            if (dtCaseId != null && dtCaseId.Rows.Count > 0)
            {
                CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                if (CaseId < 9)
                {
                    txtCaseId.Text = "WX000" + CaseId.ToString();
                }

                else if (CaseId > 9 && CaseId < 100)
                {
                    txtCaseId.Text = "WX00" + CaseId.ToString();
                }
                else if (CaseId > 99 && CaseId < 1000)
                {
                    txtCaseId.Text = "WX0" + CaseId.ToString();
                }
                else
                {
                    txtCaseId.Text = "WX" + CaseId.ToString();
                }

            }
        }



        public void LoadMasterLanguage()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = BusinessAccessLayer.LoadMasterLanguageDropDown();

            if (dtLanguage != null && dtLanguage.Rows.Count > 0)
            {
                cmbLanguage.DataSource = dtLanguage;
                cmbLanguage.DataTextField = "LanguageDescription";
                cmbLanguage.DataValueField = "LanguageId";
                cmbLanguage.DataBind();
            }
            else
            {
                cmbLanguage.DataSource = null;
                cmbLanguage.DataBind();
            }
        }





        public void LoadCorporate()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtCorporateDetails;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();
            }
        }

        public void LoadDoctorDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccessLayer.LoadDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                cmbDoctorName.DataSource = dtDoctorDetails;
                cmbDoctorName.DataTextField = "DoctorName";
                cmbDoctorName.DataValueField = "DoctorId";
                cmbDoctorName.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            int NoOfFreeConsultation = 0;
            int NoofConsultationRecorded = 0;

            if (!txtNoOfFreeConsultations.Text.Trim().Equals(""))
            {
                NoOfFreeConsultation = Convert.ToInt32(txtNoOfFreeConsultations.Text.Trim());
            }

            if (!txtNoOfConsultationRecorded.Text.Trim().Equals(""))
            {
                NoofConsultationRecorded = Convert.ToInt32(txtNoOfConsultationRecorded.Text.Trim());
            }


            try
            {



                if (btnSave.Text.Equals("Save"))
                {

                    BusinessAccessLayer.InsertUpdateSpecialityConsultantCaseDetails(0, txtCaseId.Text.Trim(), Convert.ToInt32(cmbBranch.SelectedValue), dtpCaseEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseEntryDate.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbAssignExecutive.SelectedValue), Convert.ToInt32(cmbCaseMode.SelectedValue), dtpCaseRecordedDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecordedDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue), Convert.ToInt32(cmbServicesOffered.SelectedValue), txtEmployeeName.Text.Trim(),
                        txtMobileNo.Text.Trim(), Convert.ToInt32(cmbGender.SelectedValue), txtEmployeeEmailId.Text.Trim(), NoOfFreeConsultation, NoofConsultationRecorded, Convert.ToInt32(cmbConsultationType.SelectedValue)
                        , Convert.ToInt32(cmbCaseType.SelectedValue), Convert.ToInt32(cmbPaymentType.SelectedValue), Convert.ToInt32(cmbCaseFor.SelectedValue), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                        Convert.ToInt32(cmbLanguage.SelectedValue), dtpDoctorDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpDoctorDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbDoctorName.SelectedValue),
                        1, Convert.ToInt32(cmbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value, txtRemarks.Text.Trim(),
                        1, out IsDataExists);
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
                    BusinessAccessLayer.InsertUpdateSpecialityConsultantCaseDetails(Variables.SpecialityConsultantCaseDetailsId, txtCaseId.Text.Trim(), Convert.ToInt32(cmbBranch.SelectedValue), dtpCaseEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseEntryDate.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbAssignExecutive.SelectedValue), Convert.ToInt32(cmbCaseMode.SelectedValue), dtpCaseRecordedDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecordedDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue), Convert.ToInt32(cmbServicesOffered.SelectedValue), txtEmployeeName.Text.Trim(),
                        txtMobileNo.Text.Trim(), Convert.ToInt32(cmbGender.SelectedValue), txtEmployeeEmailId.Text.Trim(), NoOfFreeConsultation, NoofConsultationRecorded, Convert.ToInt32(cmbConsultationType.SelectedValue)
                        , Convert.ToInt32(cmbCaseType.SelectedValue), Convert.ToInt32(cmbPaymentType.SelectedValue), Convert.ToInt32(cmbCaseFor.SelectedValue), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                        Convert.ToInt32(cmbLanguage.SelectedValue), dtpDoctorDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpDoctorDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbDoctorName.SelectedValue),
                        1, Convert.ToInt32(cmbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value, txtRemarks.Text.Trim(),
                        1, out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Data Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Data Updated Successfully");

                    }
                }
                //ClearFields();

                if (Session["RoleId"].ToString().Equals("1"))
                {
                    //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
                }
                else
                {
                    ClearFields();
                    GenearateSpecialityConsultancyCaseId();
                    //LoadDoctorDetails();
                    //SpecialistConultantView.ActiveViewIndex = 0;
                    //LoadSpecialityConsultantCaseDetails();
                    //rgCorporateContactDetails.DataSource = new object[] { };
                    //rgCorporateContactDetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearFields()
        {
            cmbAssignExecutive.SelectedValue = "0";
            cmbBranch.SelectedValue = "0";
            cmbCorporateName.SelectedValue = "0";
            cmbCorporateBranchId.SelectedValue = "0";
            cmbServicesOffered.SelectedValue = "0";

            txtEmployeeName.Text = "";
            txtEmployeeEmailId.Text = "";
            cmbGender.SelectedValue = "0";
            txtNoOfFreeConsultations.Text = "";
            txtNoOfConsultationRecorded.Text = "";
            cmbConsultationType.SelectedValue = "0";
            cmbCaseType.SelectedValue = "0";
            cmbPaymentType.SelectedValue = "0";
            cmbCaseFor.SelectedValue = "0";
            cmbCustomerProfile.SelectedValue = "0";
            cmbLanguage.SelectedValue = "0";
            cmbDoctorName.SelectedValue = "0";
            cmbDoctorQualification.SelectedValue = "0";
            cmbCaseStatus.SelectedValue = "0";
            txtRemarks.Text = "";

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}