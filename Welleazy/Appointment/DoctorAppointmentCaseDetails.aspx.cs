using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Appointment
{
    public partial class DoctorAppointmentCaseDetails : System.Web.UI.Page
    {
        DateTime? nul = null;
        string LanguageId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CorporateList();
                LoadState();
                LoadDistrict();
                LoadCaseReceivedMode();
                LoadDoctor();
                //LoadMasterLanguage();
                if (Variables.ConsultaionId != 0)
                {

                    LoadConsultationCaseDetailsById();
                    LoadPrefferedLanguage();

                    ConsultationCaseApointmentView.ActiveViewIndex = 1;
                }
                else
                {
                    LoadConsultationAppointmentDeails();

                    //CorporateList();
                    ConsultationCaseApointmentView.ActiveViewIndex = 0;


                    CheckAppointment();
                }


                //LoadServices();

            }

        }

        public void LoadCaseReceivedMode()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseMode = new DataTable();
            dtCaseMode = BusinessAccessLayer.LoadCaseReceivedModeDropDown();

            if (dtCaseMode != null && dtCaseMode.Rows.Count > 0)
            {
                cmbCaseReceivedModeSearch.DataSource = dtCaseMode;
                cmbCaseReceivedModeSearch.DataTextField = "CaseReceivedMode";
                cmbCaseReceivedModeSearch.DataValueField = "CaseReceivedModeId";
                cmbCaseReceivedModeSearch.DataBind();
            }
        }

        public void LoadState()
        {
            DataTable dtState = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                cmbStateSearch.DataSource = dtState;
                cmbStateSearch.DataTextField = "StateName";
                cmbStateSearch.DataValueField = "StateId";
                cmbStateSearch.DataBind();
            }
        }

        public void LoadDistrict()
        {
            DataTable dtDistrict = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDistrict = BusinessAccessLayer.LoadDistrict();

            if (dtDistrict != null && dtDistrict.Rows.Count > 0)
            {
                cmbCitySearch.DataSource = dtDistrict;
                cmbCitySearch.DataBind();
            }
            else
            {
                cmbCitySearch.DataSource = null;
                cmbCitySearch.DataBind();
            }
        }

        public void LoadMasterLanguage()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = BusinessAccessLayer.LoadMasterLanguageDropDown();

            if (dtLanguage != null && dtLanguage.Rows.Count > 0)
            {
                //cmbLanguage.DataSource = dtLanguage;
                //cmbLanguage.DataTextField = "LanguageDescription";
                //cmbLanguage.DataValueField = "LanguageId";
                //cmbLanguage.DataBind();


            }
            else
            {
                //cmbLanguage.DataSource = null;
                //cmbLanguage.DataBind();


            }
        }


        public void LoadPrefferedLanguage()
        {
            //cmbLanguage.Items.Clear();

            Bal BusinessAccessLayer = new Bal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = BusinessAccessLayer.LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(LanguageId);

            if (dtLanguage != null && dtLanguage.Rows.Count > 0)
            {
                //cmbLanguage.DataSource = dtLanguage;
                //cmbLanguage.DataTextField = "LanguageDescription";
                //cmbLanguage.DataValueField = "LanguageId";
                //cmbLanguage.DataBind();


            }
            else
            {
                //cmbLanguage.DataSource = null;
                //cmbLanguage.DataBind();


            }

            //cmbLanguage.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Language"));
            //cmbLanguage.SelectedIndex = 0;
        }



        public void LoadDoctor()
        {
            Bal BusinessAccesslayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccesslayer.FetchDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                //cmbDoctorName.DataSource = dtDoctorDetails;
                //cmbDoctorName.DataTextField = "DoctorName";
                //cmbDoctorName.DataValueField = "DoctorId";
                //cmbDoctorName.DataBind();
            }
        }



        public void CheckAppointment()
        {
            Bal BusinessAccessLayer = new Bal();
            int check = BusinessAccessLayer.CheckAppointment(Variables.ConsultaionId);
            if (check != 0)
            {
                btnSave.Text = "Update";
                LoadConsultationCaseDetailsById();
                LoadConsultationCaseAppointmentDeailsById();
            }

        }
        public void LoadConsultationAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseAppointmentDetails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvConsultantCaseAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultantCaseAppointmentDetails.DataSource = null;
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
        }

        //public void LoadServices()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    DataTable dtConsultationCaseServices = new DataTable();
        //    dtConsultationCaseServices = BusinessAccessLayer.LoadConsultationCaseServices(Convert.ToInt32(ConsultationType.SelectedValue));

        //    if (dtConsultationCaseServices != null && dtConsultationCaseServices.Rows.Count > 0)
        //    {
        //        cmbServicesOffered.DataSource = dtConsultationCaseServices;
        //        cmbServicesOffered.DataTextField = "SubProductCategory";
        //        cmbServicesOffered.DataValueField = "SubProductId";
        //        cmbServicesOffered.DataBind();
        //    }
        //}



        public void LoadConsultationCaseAppointmentDeailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentDetails = new DataTable();
            dtAppointmentDetails = BusinessAccessLayer.LoadConsultationCaseAppointmentDeailsById(Variables.ConsultationCaseAppointmentDetailsId);
            if (dtAppointmentDetails != null && dtAppointmentDetails.Rows.Count > 0)
            {
                //cmbDoctorName.SelectedValue = (dtAppointmentDetails.Rows[0]["DoctorId"].ToString());
                dtpAppointmentDateTime.SelectedDate = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["AppointmentDateTime"].ToString());
                cmbAppointmentStatus.SelectedValue = (dtAppointmentDetails.Rows[0]["AppointmentStatus"].ToString());
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

                rcbClientName.DataSource = dtLoadCorporateList;
                rcbClientName.DataTextField = "CorporateName";
                rcbClientName.DataValueField = "CorporateId";
                rcbClientName.DataBind();



            }
            else
            {
                cmbCorporateName.DataSource = null;
                cmbCorporateName.DataBind();

                rcbClientName.DataSource = null;
                rcbClientName.DataBind();
            }
        }




        public void LoadConsultationCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadConsultationCaseDetailsById(Variables.ConsultaionId);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {

                lblCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
                dtpCaseEntryDate.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseEntryDateTime"].ToString());
                cmbBranch.SelectedValue = (dtCaseDetails.Rows[0]["BranchId"].ToString());
                cmbAssignExecutive.SelectedValue = (dtCaseDetails.Rows[0]["AssignedExecutiveId"].ToString());
                cmbCaseMode.SelectedValue = (dtCaseDetails.Rows[0]["CaseReceivedMode"].ToString());

                dtpCaseRecordedDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseRecievedDateTime"].ToString());
                CorporateList();
                cmbCorporateName.SelectedValue = (dtCaseDetails.Rows[0]["CorporateId"].ToString());
                cmbCorporateName_SelectedIndexChanged(null, null);
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
                LanguageId = dtCaseDetails.Rows[0]["CustomerPrefferedLanguage"].ToString();
                //cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString();

                //dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                //cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                //cmb.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                //cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

                //dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDataTime"].ToString());

                //txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

                //btnSave.Text = "Update";
            }

        }



        protected void rgvConsultantCaseAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvConsultantCaseAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblConsultationAppointmentDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultationAppointmentDetailsId");
                Label lblConsultantCaseDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultantCaseDetailsId"); // % 15 for page indexing
                Variables.ConsultaionId = Convert.ToInt32(lblConsultantCaseDetailsId.Text.Trim());
                Variables.ConsultationCaseAppointmentDetailsId = Convert.ToInt32(lblConsultationAppointmentDetailsId.Text.Trim());
                LoadConsultationCaseDetailsById();
                LoadConsultationCaseAppointmentDeailsById();

                btnSave.Text = "Update";


                ConsultationCaseApointmentView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }

        }

        protected void rgvConsultantCaseAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseAppointmentDetails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvConsultantCaseAppointmentDetails.DataSource = dtEConsultantAppointment;
                //rgvConsultantCaseAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultantCaseAppointmentDetails.DataSource = null;
                //rgvConsultantCaseAppointmentDetails.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            string CaseStatus = "";
            string ReportStatus = "";
            int IsActive = 1;

            if (cmbAppointmentStatus.SelectedItem.Text == "Scheduled")
            {
                CaseStatus = "Appointment Confirmed";
                ReportStatus = "Pending";
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Cancelled")
            {
                CaseStatus = "Appointment Cancelled";
                ReportStatus = "Pending";
                IsActive = 0;
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


            try
            {

                if (btnSave.Text.Equals("Save"))
                {

                    //BusinessAccessLayer.InsertUpdateConsultationCaseDoctorAppointment(0, Variables.ConsultaionId, Convert.ToInt32(cmbDoctorName.SelectedValue),
                    //   dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), 1, CaseStatus, ReportStatus, IsActive, out IsDataExists);
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
                    //BusinessAccessLayer.InsertUpdateConsultationCaseDoctorAppointment(Variables.ConsultationCaseAppointmentDetailsId, Variables.ConsultaionId,
                    //     Convert.ToInt32(cmbDoctorName.SelectedValue),
                    //     dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), 1, CaseStatus, ReportStatus, IsActive, out IsDataExists);
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
            Variables.ConsultaionId = 0;
            LoadConsultationAppointmentDeails();
            ConsultationCaseApointmentView.ActiveViewIndex = 0;
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadConsultationAppointmentDeails();
            ConsultationCaseApointmentView.ActiveViewIndex = 0;
            Variables.ConsultaionId = 0;
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "Select ConsultationCaseAppointmentDetailsId,SCCD.ConsultationCaseDetailsId,CaseId," +
                "Convert(varchar(10),CaseEntryDateTime,103)CaseEntryDateTime,MCP.Description as Customerprofile ," +
                "CorporateName,MB.BranchName,MCB.BranchName as CorporateBranch,MCM.CaseReceivedMode," +
                "StateName,DistrictName,EmployeeName,SCCD.MobileNo,SCCD.EMailId," +
                "NoOfFreeConsultations,NoOfConsultationReceived,MCT.ConsultationType,Case when CaseType = 1 then 'Main' Else 'Additional' End CaseType," +
                "MPT.PaymentType,MCP.Description as CustomerProfile,DoctorName,ML.LanguageDescription as PrefferedLanguage," +
                "Format(FollowUpDateTime, 'dd-MM-yyyy hh:mm tt')FollowUpDateTime," +
                "Case When CaseFor = 1 Then 'Self' Else 'Dependent' End CaseFor," +
                "SCAD.CaseStatus,ReportStatus,MAS.AppointmentDescription as AppointmentStatus" +
                " from ConsultationCaseAppointmentDetails SCAD" +
                " Join ConsultationCaseDetails SCCD on SCAD.ConsultationCaseDetailsId = SCCD.ConsultationCaseDetailsId" +
                " left Join Master_CorporateDetails MCD on MCD.CorporateId = SCCD.CorporateId" +
                " left Join Master_Doctor MD on MD.DoctorId = SCCD.DoctorId" +
                " left Join Master_Language ML on ML.LanguageId = SCCD.PrefferedLanguage" +
                " left Join Master_Gender MG on MG.GenderId = SCCD.GenderId" +
                " left Join Master_Branch MB on MB.BranchId = SCCD.BranchId" +
                " left Join Master_Branch MCB on MCB.BranchId = SCCD.CorporateBranchId" +
                " Left Join Master_CaseReceivedMode MCM on MCM.CaseReceivedModeId = SCCD.CaseReceivedMode" +
                " Left Join Master_ConsultationType MCT on MCT.ConsultationTypeId = SCCD.ConsultationType" +
                " Left Join Master_PaymentType MPT on MPT.PaymentTypeId = SCCD.PaymentType" +
                " Left Join Master_CustomerProfile MCP on MCP.CustomerProfileId = SCCD.CustomerProfile" +
                " Left Join Master_State MS on MS.StateId = SCCD.State" +
                " Left Join Master_District M_D on M_D.DistrictId = SCCD.City" +
                " Left Join MasterCaseStatus MCS on MCS.CaseStatusId = SCCD.CaseStatus" +
                " Left Join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = SCAD.AppointmentStatus";

            string Query = "";

            string CorporateId = "";
            string AssignedAgent = "";
            string CaseReceivedMode = "";
            string State = "";
            string City = "";
            string Branch = "";

            for (int i = 0; i < rcbClientName.CheckedItems.Count; i++)
            {
                if (CorporateId == "")
                {
                    CorporateId = rcbClientName.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CorporateId += "," + rcbClientName.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbCaseReceivedModeSearch.CheckedItems.Count; i++)
            {
                if (CaseReceivedMode == "")
                {
                    CaseReceivedMode = cmbCaseReceivedModeSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CaseReceivedMode += "," + cmbCaseReceivedModeSearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbStateSearch.CheckedItems.Count; i++)
            {
                if (State == "")
                {
                    State = cmbStateSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    State += "," + cmbStateSearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbCitySearch.CheckedItems.Count; i++)
            {
                if (City == "")
                {
                    City = cmbCitySearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    City += "," + cmbCitySearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbBranchSearch.CheckedItems.Count; i++)
            {
                if (Branch == "")
                {
                    Branch = rcbBranchSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    Branch += "," + rcbBranchSearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbAssignedAgentSearch.CheckedItems.Count; i++)
            {
                if (AssignedAgent == "")
                {
                    AssignedAgent = rcbAssignedAgentSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    AssignedAgent += "," + rcbAssignedAgentSearch.CheckedItems[i].Value.Trim();
                }
            }



            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.corporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And SCCD.CorporateId in(" + CorporateId + ")";
                }
            }
            if (txt_CaseId.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseId= '" + txt_CaseId.Text.Trim() + "'";
                }
                else
                {
                    Query += " And CaseId='" + txt_CaseId.Text.Trim() + "'";
                }
            }

            if (AssignedAgent != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where AssignedExecutiveId in (" + AssignedAgent + ")";
                }
                else
                {
                    Query += " And AssignedExecutiveId in(" + AssignedAgent + ")";
                }
            }

            if (CaseReceivedMode != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCM.CaseReceivedModeId in (" + CaseReceivedMode + ")";
                }
                else
                {
                    Query += " And MCM.CaseReceivedModeId in(" + CaseReceivedMode + ")";
                }
            }

            if (cmbStateSearch.SelectedValue != "0" && cmbStateSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where State in (" + cmbStateSearch.SelectedValue + ")";
                }
                else
                {
                    Query += " And State in(" + cmbStateSearch.SelectedValue + ")";
                }
            }

            if (State != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where State in (" + State + ")";
                }
                else
                {
                    Query += " And State in(" + State + ")";
                }
            }

            if (cmbCitySearch.SelectedValue != "" && cmbCitySearch.SelectedValue != "0")
            {
                if (Query.Equals(""))
                {
                    Query = " where City in (" + cmbCitySearch.SelectedValue + ")";
                }
                else
                {
                    Query += " And City in(" + cmbCitySearch.SelectedValue + ")";
                }
            }

            if (City != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where City in (" + City + ")";
                }
                else
                {
                    Query += " And City in(" + City + ")";
                }
            }



            if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseRecievedDateTime Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And CaseRecievedDateTime Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseRecievedDateTime ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And CaseRecievedDateTime ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }





            if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where FollowUpDateTime Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And FollowUpdateTime Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where FollowUpDateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And FollowUpdateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }

            if (txtemplolyeeNameSearch.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeName like '%" + txtemplolyeeNameSearch.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And EmployeeName like '%" + txtemplolyeeNameSearch.Text.Trim() + "%'";
                }
            }


            if (txtMobileNoSearch.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And SCCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                }
            }

            if (cmbCaseTypeSearch.SelectedValue != "0" && cmbCaseTypeSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseType in (" + cmbCaseTypeSearch.SelectedValue + ")";
                }
                else
                {
                    Query += " And CaseType in(" + cmbCaseTypeSearch.SelectedValue + ")";
                }
            }

            if (cmbPaymentTypeSearch.SelectedValue != "0" && cmbPaymentTypeSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.PaymentType in (" + cmbPaymentTypeSearch.SelectedValue + ")";
                }
                else
                {
                    Query += " And SCCD.PaymentType in(" + cmbPaymentTypeSearch.SelectedValue + ")";
                }
            }



            if (cmbCustomerProfileTypeSearch.SelectedValue != "0" && cmbCustomerProfileTypeSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.CustomerProfile in (" + cmbCustomerProfileTypeSearch.SelectedValue + ")";
                }
                else
                {
                    Query += " And SCCD.CustomerProfile in(" + cmbCustomerProfileTypeSearch.SelectedValue + ")";
                }
            }



            Bal BusinessAccessLayer = new Bal();
            DataTable dtSearch = new DataTable();
            dtSearch = BusinessAccessLayer.SearchConsultationCaseDetails(MainQuery + Query);

            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                rgvConsultantCaseAppointmentDetails.DataSource = dtSearch;
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultantCaseAppointmentDetails.DataSource = new object[] { }; ;
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
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

        protected void cmbCorporateName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadCorporateBranchList();
        }

        public void LoadCorporateBranchList()
        {

            cmbCorporateBranchId.Items.Clear();
            DataTable dtCorporateBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateBranchDetails = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(cmbCorporateName.SelectedValue));


            if (dtCorporateBranchDetails != null && dtCorporateBranchDetails.Rows.Count > 0)
            {
                cmbCorporateBranchId.DataSource = dtCorporateBranchDetails;
                cmbCorporateBranchId.DataTextField = "Branch";
                cmbCorporateBranchId.DataValueField = "BranchDetailsId";
                cmbCorporateBranchId.DataBind();
            }
        }

        protected void rcbClientName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbStateSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                cmbCitySearch.Items.Clear();
                string State = "";

                for (int i = 0; i < cmbStateSearch.CheckedItems.Count; i++)
                {
                    if (State == "")
                    {
                        State = cmbStateSearch.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        State += "," + cmbStateSearch.CheckedItems[i].Value.Trim();
                    }
                }

                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictSearch(State);
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    cmbCitySearch.DataSource = dtCity;
                    cmbCitySearch.DataTextField = "DistrictName";
                    cmbCitySearch.DataValueField = "DistrictId";
                    cmbCitySearch.DataBind();
                }

                cmbCitySearch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select City"));
                cmbCitySearch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        protected void cmbLanguage_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //try
            //{
            //    string Language_Id = "";

            //    for (int i = 0; i < cmbLanguage.CheckedItems.Count; i++)
            //    {
            //        if (Language_Id == "")
            //        {
            //            Language_Id = cmbLanguage.CheckedItems[i].Value.Trim();
            //        }
            //        else
            //        {
            //            Language_Id += "," + cmbLanguage.CheckedItems[i].Value.Trim();
            //        }
            //    }

            //    cmbDoctorName.Items.Clear();

            //    DataTable dtDoctorDetails = new DataTable();
            //    Bal BusinessAccessLayer = new Bal();
            //    dtDoctorDetails = BusinessAccessLayer.LoadDoctorSearchByLanguage(Language_Id);
            //    if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            //    {
            //        cmbDoctorName.DataSource = dtDoctorDetails;
            //        cmbDoctorName.DataTextField = "DoctorName";
            //        cmbDoctorName.DataValueField = "DoctorId";
            //        cmbDoctorName.DataBind();
            //    }

            //    cmbDoctorName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Doctor"));
            //    cmbDoctorName.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{

            //}

        }
    }
}