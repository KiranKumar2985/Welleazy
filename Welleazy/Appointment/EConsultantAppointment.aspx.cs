using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Appointment
{
    public partial class EConsultantAppointment : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Variables.EConsultantCaseDetailsId != 0)
                {

                    LoadEConsultantCaseDetailsById();
                    //StateList();
                    CorporateList();
                    EConultantApointmentView.ActiveViewIndex = 1;
                }
                else
                {
                    LoadEConsultantAppointmentDeails();
                    CorporateList();
                    EConultantApointmentView.ActiveViewIndex = 0;


                    CheckAppointment();
                }


            }

        }

        public void CheckAppointment()
        {
            Bal BusinessAccessLayer = new Bal();
            int check = BusinessAccessLayer.CheckAppointment(Variables.EConsultantCaseDetailsId);
            if (check != 0)
            {
                btnSave.Text = "Update";
                LoadEConsultantCaseDetailsById();
                LoadEConsultantAppointmentDeailsById();
            }

        }
        public void LoadEConsultantAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadEConsultantAppointmentDeails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvEConsultancyAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvEConsultancyAppointmentDetails.DataBind();
            }
            else
            {
                rgvEConsultancyAppointmentDetails.DataSource = null;
                rgvEConsultancyAppointmentDetails.DataBind();
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

            try
            {

                if (btnSave.Text.Equals("Save"))
                {

                    BusinessAccessLayer.InsertUpdateEConsultantDoctorAppointment(0, Variables.EConsultantCaseDetailsId, Convert.ToInt32(cmbDoctorName.SelectedValue),
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
                    BusinessAccessLayer.InsertUpdateEConsultantDoctorAppointment(Variables.EConsultantAppointmentDetailsId, Variables.EConsultantCaseDetailsId,
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
            }
            catch (Exception ex)
            {

            }
            Variables.EConsultantCaseDetailsId = 0;
            LoadEConsultantAppointmentDeails();
            EConultantApointmentView.ActiveViewIndex = 0;


        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadEConsultantAppointmentDeails();
            EConultantApointmentView.ActiveViewIndex = 0;
            Variables.EConsultantCaseDetailsId = 0;
        }

        protected void rgvEConsultancyAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblEConsultantAppointmentDetailsId = (Label)rgvEConsultancyAppointmentDetails.Items[intIndex % 10].FindControl("lblEConsultantAppointmentDetailsId");
                Label lblEConsultantCaseDetailsId = (Label)rgvEConsultancyAppointmentDetails.Items[intIndex % 10].FindControl("lblEConsultantCaseDetailsId"); // % 15 for page indexing
                Variables.EConsultantCaseDetailsId = Convert.ToInt32(lblEConsultantCaseDetailsId.Text.Trim());
                Variables.EConsultantAppointmentDetailsId = Convert.ToInt32(lblEConsultantAppointmentDetailsId.Text.Trim());
                LoadEConsultantCaseDetailsById();
                LoadEConsultantAppointmentDeailsById();

                btnSave.Text = "Update";


                EConultantApointmentView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }
        }

        public void LoadEConsultantAppointmentDeailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentDetails = new DataTable();
            dtAppointmentDetails = BusinessAccessLayer.LoadEConsultantAppointmentDeailsById(Variables.EConsultantAppointmentDetailsId);
            if (dtAppointmentDetails != null && dtAppointmentDetails.Rows.Count > 0)
            {
                cmbDoctorName.SelectedValue = (dtAppointmentDetails.Rows[0]["DoctorId"].ToString());
                dtpAppointmentDateTime.SelectedDate = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["AppointmentDateTime"].ToString());
                cmbAppointmentStatus.SelectedValue = (dtAppointmentDetails.Rows[0]["AppointmentStatus"].ToString());
            }
        }
        public void LoadEConsultantCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadEConsultantCaseDetailsById(Variables.EConsultantCaseDetailsId);

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

        protected void rgvEConsultancyAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvEConsultancyAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

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