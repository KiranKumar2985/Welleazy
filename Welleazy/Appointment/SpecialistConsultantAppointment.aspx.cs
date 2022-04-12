using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Appointment
{
    public partial class SpecialistConsultantAppointment : System.Web.UI.Page
    {
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Variables.SpecialityConsultantCaseDetailsId != 0)
                {
                    LoadSpecialistConsultantCaseDetailsById();
                    //LoadSpecialistConsultantAppointmentDeailsById();
                    //StateList();
                    CorporateList();
                    SpecialistConultantApointmentView.ActiveViewIndex = 1;
                }
                else
                {
                    CorporateList();
                    SpecialistConultantApointmentView.ActiveViewIndex = 0;
                    LoadSpecialistConsultantAppointmentDeails();

                    //CheckAppointment();
                }

            }

        }

        public void CheckAppointment()
        {
            Bal BusinessAccessLayer = new Bal();
            int check = BusinessAccessLayer.CheckSpecialistAppointment(Variables.SpecialityConsultantCaseDetailsId);
            if (check != 0)
            {
                btnSave.Text = "Update";
                LoadSpecialistConsultantCaseDetailsById();
                LoadSpecialistConsultantAppointmentDeailsById();
            }

        }

        public void LoadSpecialistConsultantAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadSpecialistConsultantAppointmentDeails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvSpecialistConsultancyAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvSpecialistConsultancyAppointmentDetails.DataBind();
            }
            else
            {
                rgvSpecialistConsultancyAppointmentDetails.DataSource = null;
                rgvSpecialistConsultancyAppointmentDetails.DataBind();
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCoporateList();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtLoadCorporateList;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();

            }
            else
            {
                cmbCorporateName.DataSource = null;
                cmbCorporateName.DataBind();
            }
        }

        protected void lnlScheduleAppointment_Click(object sender, EventArgs e)
        {
            //SpecialistConultantApointmentView.ActiveViewIndex = 1;
        }

        protected void lnlAppointmentList_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            string CaseStatus = "";
            string ReportStatus = "";

            if (cmbAppointmentStatus.SelectedItem.Text == "Scheduled")
            {
                CaseStatus = "Appointment Confirmed";
                ReportStatus = "Pending";
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Cancelled")
            {
                CaseStatus = "Appointment Cancelled";
                ReportStatus = "Pending";
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Re-Schedule")
            {
                CaseStatus = "Appointment Missed - Reschedule Appointment";
                ReportStatus = "Pending";
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Completed")
            {
                CaseStatus = "Closed - Reports Submitted to Insurer";
                ReportStatus = "Report Received QC Pending";
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Pending")
            {
                CaseStatus = "Appointment Missed - Reschedule Appointment";
                ReportStatus = "Pending";
            }
            else
            {

            }

            if (btnSave.Text.Equals("Save"))
            {

                BusinessAccessLayer.InsertUpdateSpecialistConsultantDoctorAppointment(0, Variables.SpecialityConsultantCaseDetailsId, Convert.ToInt32(cmbDoctorName.SelectedValue),
                   dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), 1, CaseStatus, ReportStatus, out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Appointment Already Exists");
                }
                else
                {
                    showPopup("Warning", "Appointment Scheduled Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateSpecialistConsultantDoctorAppointment(Variables.SpecialistConsultantAppointmentDetailsId, Variables.SpecialityConsultantCaseDetailsId,
                     Convert.ToInt32(cmbDoctorName.SelectedValue),
                     dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), 1, CaseStatus, ReportStatus, out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Appointment Already Exists");
                }
                else
                {
                    showPopup("Warning", "Appointment Scheduled Updated Successfully");

                }
            }
            LoadSpecialistConsultantAppointmentDeails();
            SpecialistConultantApointmentView.ActiveViewIndex = 0;
            Variables.SpecialityConsultantCaseDetailsId = 0;

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSpecialistConsultantAppointmentDeails();
            SpecialistConultantApointmentView.ActiveViewIndex = 0;
            Variables.SpecialityConsultantCaseDetailsId = 0;
        }

        protected void rgvSpecialistConsultancyAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblSpecialistConsultantAppointmentDetailsId = (Label)rgvSpecialistConsultancyAppointmentDetails.Items[intIndex % 10].FindControl("lblSpecilaistConsultantAppointmentDetailsId");
                Label lblSpecialistConsultantCaseDetailsId = (Label)rgvSpecialistConsultancyAppointmentDetails.Items[intIndex % 10].FindControl("lblSpecialistConsultantCaseDetailsId"); // % 15 for page indexing
                Variables.SpecialityConsultantCaseDetailsId = Convert.ToInt32(lblSpecialistConsultantCaseDetailsId.Text.Trim());
                Variables.SpecialistConsultantAppointmentDetailsId = Convert.ToInt32(lblSpecialistConsultantAppointmentDetailsId.Text.Trim());
                LoadSpecialistConsultantCaseDetailsById();
                LoadSpecialistConsultantAppointmentDeailsById();

                btnSave.Text = "Update";


                SpecialistConultantApointmentView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }
        }

        public void LoadSpecialistConsultantAppointmentDeailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentDetails = new DataTable();
            dtAppointmentDetails = BusinessAccessLayer.LoadSpecialistConsultantAppointmentDeailsById(Variables.SpecialistConsultantAppointmentDetailsId);
            if (dtAppointmentDetails != null && dtAppointmentDetails.Rows.Count > 0)
            {
                cmbDoctorName.SelectedValue = (dtAppointmentDetails.Rows[0]["DoctorId"].ToString());
                dtpAppointmentDateTime.SelectedDate = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["AppointmentDateTime"].ToString());
                cmbAppointmentStatus.SelectedValue = (dtAppointmentDetails.Rows[0]["AppointmentStatus"].ToString());
            }
        }
        public void LoadSpecialistConsultantCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadSpecialistConsultantCaseDetailsById(Variables.SpecialityConsultantCaseDetailsId);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                lblCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
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

                //dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                //cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                //cmb.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                //cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

                //dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDataTime"].ToString());

                //txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

                //btnSave.Text = "Update";
            }

        }

        protected void rgvSpecialistConsultancyAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvSpecialistConsultancyAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

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

        //public void StateList()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    DataTable dtState = new DataTable();
        //    dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

        //    if (dtState != null && dtState.Rows.Count > 0)
        //    {
        //        rcbStateList.DataSource = dtState;
        //        rcbStateList.DataTextField = "StateName";
        //        rcbStateList.DataValueField = "StateId";
        //        rcbStateList.DataBind();
        //    }
        //}
        //public void CityList()
        //{
        //    rcbCityList.Items.Clear();
        //    try
        //    {


        //        DataTable dtCity = new DataTable();
        //        Bal BusinessAccessLayer = new Bal();
        //        dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbStateList.SelectedValue));
        //        if (dtCity != null && dtCity.Rows.Count > 0)
        //        {
        //            rcbCityList.DataSource = dtCity;
        //            rcbCityList.DataTextField = "DistrictName";
        //            rcbCityList.DataValueField = "DistrictId";
        //            rcbCityList.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}