using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Welleazy.Appointment
{
    public partial class ConsultationCaseAppointmentDetails : System.Web.UI.Page
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
                LoadAssignExecutive();
                CaseStatusList();
                BranchList();
                AppointmentStatusList();
                LoadMasterLanguage();
                if (Variables.ConsultaionId != 0)
                {

                    LoadConsultationCaseDetailsById();
                    LoadPrefferedLanguage();

                    ConsultationCaseApointmentView.ActiveViewIndex = 1;
                }
                else
                {
                    LoadConsultationAppointmentDeails();
                    LoadPrefferedLanguage();
                    //CorporateList();
                    ConsultationCaseApointmentView.ActiveViewIndex = 0;


                    CheckAppointment();
                }


                //LoadServices();

            }

        }

        public void LoadAssignExecutive()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAssignExecutiveDetails = new DataTable();
            dtAssignExecutiveDetails = BusinessAccessLayer.LoadAssignExecutive();
            rcbAssignedAgentSearch.Items.Clear();
            if (dtAssignExecutiveDetails != null && dtAssignExecutiveDetails.Rows.Count > 0)
            {
                rcbAssignedAgentSearch.DataSource = dtAssignExecutiveDetails;
                rcbAssignedAgentSearch.DataTextField = "name";
                rcbAssignedAgentSearch.DataValueField = "user_id";
                rcbAssignedAgentSearch.DataBind();

                rcbAssignedAgentSearch.Items.Insert(0, "Select Executive");

                cmbAssignExecutive.DataSource = dtAssignExecutiveDetails;
                cmbAssignExecutive.DataTextField = "name";
                cmbAssignExecutive.DataValueField = "user_id";
                cmbAssignExecutive.DataBind();

                cmbAssignExecutive.Items.Insert(0, "Select Executive");
            }

        }

        public void AppointmentStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentStatus = new DataTable();
            dtAppointmentStatus = BusinessAccessLayer.LoadAppointmentStatusList();
            cmbAppointmentStatus.Items.Clear();
            cmbAppointmentStatusSearch.Items.Clear();
            if (dtAppointmentStatus != null && dtAppointmentStatus.Rows.Count > 0)
            {
                cmbAppointmentStatus.DataSource = dtAppointmentStatus;
                cmbAppointmentStatus.DataTextField = "AppointmentDescription";
                cmbAppointmentStatus.DataValueField = "AppointmentStatusId";
                cmbAppointmentStatus.DataBind();

                cmbAppointmentStatusSearch.DataSource = dtAppointmentStatus;
                cmbAppointmentStatusSearch.DataTextField = "AppointmentDescription";
                cmbAppointmentStatusSearch.DataValueField = "AppointmentStatusId";
                cmbAppointmentStatusSearch.DataBind();

                cmbAppointmentStatus.Items.Insert(0, "Select Appointment Status");
                cmbAppointmentStatusSearch.Items.Insert(0, "Select Appointment Status");

            }


            if (Variables.ConsultationCaseAppointmentDetailsId.Equals(0))
            {

                List<string> list = new List<string>() { "2", "3", "4", "5"};
                foreach (var item in list)
                {
                    RadComboBoxItem items = cmbAppointmentStatus.Items.FindItemByValue(item);
                    if (item != null)
                    {
                        items.Remove();
                    }
                }
            }

            else
            {
                //List<string> list = new List<string>() { "2", "3" };
                //foreach (var item in list)
                //{
                //    RadComboBoxItem items = cmbCaseFor.Items.FindItemByValue(item);
                //    if (item != null)
                //    {
                //        items.Remove();
                //    }
                //}
            }


        }

        public void CaseStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseStatus = new DataTable();
            dtCaseStatus = BusinessAccessLayer.LoadCaseStatusList(2);

            if (dtCaseStatus != null && dtCaseStatus.Rows.Count > 0)
            {
                rcbCaseStatus.DataSource = dtCaseStatus;
                rcbCaseStatus.DataTextField = "CaseStatusName";
                rcbCaseStatus.DataValueField = "StatusId";
                rcbCaseStatus.DataBind();

                cmbCaseStatus.DataSource = dtCaseStatus;
                cmbCaseStatus.DataTextField = "CaseStatusName";
                cmbCaseStatus.DataValueField = "StatusId";
                cmbCaseStatus.DataBind();

                cmbCaseStatus.Items.Remove(1);
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


        public void LoadPrefferedLanguage()
        {
            //cmbLanguage.Items.Clear();

            Bal BusinessAccessLayer = new Bal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = BusinessAccessLayer.LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(LanguageId);

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
                cmbDoctorName.DataSource = dtDoctorDetails;
                cmbDoctorName.DataTextField = "DoctorName";
                cmbDoctorName.DataValueField = "DoctorId";
                cmbDoctorName.DataBind();
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
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseAppointmentDetails(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]));
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                Session["ConsultationCaseStatus"] = dtEConsultantAppointment.Rows[0]["CaseStatus"].ToString();
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
                cmbDoctorName.SelectedValue = (dtAppointmentDetails.Rows[0]["DoctorId"].ToString());
                dtpAppointmentDateTime.SelectedDate = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["AppointmentDateTime"].ToString());
                cmbAppointmentStatus.SelectedValue = (dtAppointmentDetails.Rows[0]["AppointmentStatus"].ToString());
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

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

        public void BranchList()
        {
            DataTable dtLoadBranchList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadBranchList = BusinessAccessLayer.LoadBranchList();

            if (dtLoadBranchList != null && dtLoadBranchList.Rows.Count > 0)
            {
                cmbBranch.DataSource = dtLoadBranchList;
                cmbBranch.DataTextField = "BranchName";
                cmbBranch.DataValueField = "BranchId";
                cmbBranch.DataBind();

            }
            else
            {
                cmbBranch.DataSource = null;
                cmbBranch.DataBind();
            }
        }




        public void LoadConsultationCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadConsultationCaseDetailsById(Variables.ConsultaionId);
            BranchList();
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

                //int lenght2 = ServicesValue.Length;
                String[] ServicesValue = LanguageId.Split(',');

                foreach (string s in ServicesValue)
                {
                    foreach (RadComboBoxItem item in cmbLanguage.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

                cmbLanguage_SelectedIndexChanged(null, null);
                //cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString();

                //dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                //cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                //cmb.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

                Session["ConsultationCaseStatus"] = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

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
                if (e.CommandName == "EditRow")
                {
                    Label lblCaseStatusId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex].FindControl("lblCaseStatusId");

                    if (lblCaseStatusId.Text.Equals("44"))
                    {
                        Label lblConsultationCaseDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultantCaseDetailsId");
                        Label lblConsultationAppointmentDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultationAppointmentDetailsId");
                        Session["ConsultationCaseDetailsId"] = lblConsultationCaseDetailsId.Text.Trim();
                        Session["ConsultationCaseAppointmentDetailsId"] = lblConsultationAppointmentDetailsId.Text.Trim();

                        Response.Redirect("~/Case/QCCase.aspx");

                    }
                    else
                    {
                        Label lblConsultationAppointmentDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultationAppointmentDetailsId");
                        Label lblConsultantCaseDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultantCaseDetailsId"); // % 15 for page indexing
                        Variables.ConsultaionId = Convert.ToInt32(lblConsultantCaseDetailsId.Text.Trim());
                        Variables.ConsultationCaseAppointmentDetailsId = Convert.ToInt32(lblConsultationAppointmentDetailsId.Text.Trim());
                        AppointmentStatusList();
                        LoadConsultationCaseDetailsById();
                        LoadConsultationCaseAppointmentDeailsById();
                        btnSave.Text = "Update";


                        ConsultationCaseApointmentView.ActiveViewIndex = 1;
                    }


                }

                if (e.CommandName == "Remarks")
                {
                    Label lblConsultationCaseDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultantCaseDetailsId");
                    Label lblConsultationAppointmentDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultationAppointmentDetailsId");
                    Session["ConsultationCaseDetailsId"] = lblConsultationCaseDetailsId.Text.Trim();
                    Session["ConsultationCaseAppointmentDetailsId"] = lblConsultationAppointmentDetailsId.Text.Trim();
                    Response.Redirect("~/CaseLogs/CaseLogDetails.aspx");
                }

                if (e.CommandName == "OpenMERFile")
                {
                    Label lblAppointmentCaseStatusId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex].FindControl("lblAppointmentCaseStatusId");

                    if (lblAppointmentCaseStatusId.Text.Trim().Equals("2"))
                    {
                        Label lblConsultantCaseDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultantCaseDetails_Id"); // %
                        Label lblConsultationAppointmentDetailsId = (Label)rgvConsultantCaseAppointmentDetails.Items[intIndex % 10].FindControl("lblConsultationAppointmentDetails_Id"); // %

                        Session["MERFile_ConsultationCaseDetailsId"] = lblConsultantCaseDetailsId.Text.Trim();
                        Session["MERFile_ConsultationCaseAppointmentDetailsId"] = lblConsultationAppointmentDetailsId.Text.Trim();

                        Response.Redirect("~/Case/TeleMERQuestions.aspx");
                    }





                }


                //ConsultationCaseApointmentView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }

        }

        protected void rgvConsultantCaseAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseAppointmentDetails(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]));
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

            if (cmbAppointmentStatus.SelectedValue.Equals("1"))
            {
                CaseStatus = "6";
                ReportStatus = "1";
            }
            else if (cmbAppointmentStatus.SelectedValue == "4")
            {
                CaseStatus = "7";
                ReportStatus = "1";
                IsActive = 0;
            }
            else if (cmbAppointmentStatus.SelectedItem.Text == "Re-Schedule")
            {
                CaseStatus = "Appointment Missed - Reschedule Appointment";
                ReportStatus = "1";
            }
            else if (cmbAppointmentStatus.SelectedValue == "2")
            {
                CaseStatus = "28";
                ReportStatus = "2";
            }
            else if (cmbAppointmentStatus.SelectedValue == "5")
            {
                CaseStatus = "7";
                ReportStatus = "1";
            }

            string ActionPerformed = "New Appointment Scheduled. CaseId : "+ lblCaseId.Text.Trim()+" | Appointment Date Time :" + dtpAppointmentDateTime.DateInput.SelectedDate.Value +" | Doctor Name :" + cmbDoctorName.Text.Trim() + " | Appointment Status : "+cmbAppointmentStatus.Text.Trim() +" | Case Status :" + cmbCaseStatus.Text.Trim() ;


            try
            {

                if (btnSave.Text.Equals("Save"))
                {

                    BusinessAccessLayer.InsertUpdateConsultationCaseDoctorAppointment(0, Variables.ConsultaionId, Convert.ToInt32(cmbDoctorName.SelectedValue),
                       dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), Convert.ToInt32(Session["LoginRefId"]), cmbCaseStatus.SelectedValue, ReportStatus, IsActive, out IsDataExists,ActionPerformed);
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
                    BusinessAccessLayer.InsertUpdateConsultationCaseDoctorAppointment(Variables.ConsultationCaseAppointmentDetailsId, Variables.ConsultaionId,
                         Convert.ToInt32(cmbDoctorName.SelectedValue),
                         dtpAppointmentDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbAppointmentStatus.SelectedValue), Convert.ToInt32(Session["LoginRefId"]), cmbCaseStatus.SelectedValue, ReportStatus, IsActive, out IsDataExists,ActionPerformed);
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
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";

            string CorporateId = "";
            string CaseStatus = "";
            string AppointmentStatus = "";
            string AssignedAgent = "";
            string CaseReceivedMode = "";
            string State = "";
            string City = "";
            string Branch = "";

            MainQuery = "Select ConsultationCaseAppointmentDetailsId,SCCD.ConsultationCaseDetailsId,CaseId," +
                "Convert(varchar(10),CaseEntryDateTime,103)CaseEntryDateTime,MCP.Description as Customerprofile ," +
                "CorporateName,MB.BranchName,name as AssignedExecutive,MCB.BranchName as CorporateBranch,MCM.CaseReceivedMode," +
                "StateName,DistrictName,EmployeeName,SCCD.MobileNo,SCCD.EMailId," +
                "NoOfFreeConsultations,NoOfConsultationReceived,MCT.ConsultationType,Case when CaseType = 1 then 'Main' Else 'Additional' End CaseType," +
                "MPT.PaymentType,MCP.Description as CustomerProfile,DoctorName,ML.LanguageDescription as PrefferedLanguage," +
                "Format(FollowUpDateTime, 'dd-MM-yyyy hh:mm tt')FollowUpDateTime," +
                "Relationship as CaseFor, SCAD.CaseStatus as CaseStatusId, SCCD.CaseStatus as Case_StatusId, " +
                " CaseStatusName as CaseStatus, ReportStatus, SCAD.AppointmentStatus as AppointmentStatusId,MAS.AppointmentDescription as AppointmentStatus" +
                " from ConsultationCaseAppointmentDetails SCAD" +
                " Join ConsultationCaseDetails SCCD on SCAD.ConsultationCaseDetailsId = SCCD.ConsultationCaseDetailsId" +
                " left Join Master_CorporateDetails MCD on MCD.CorporateId = SCCD.CorporateId" +
                " left Join Master_Doctor MD on MD.DoctorId = SCAD.DoctorId" +
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
                " Left Join Master_CaseStatus MCS on MCS.StatusId = SCCD.CaseStatus" +
                " Left Join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = SCAD.AppointmentStatus" +
                " Left Join Master_RelationShip MRS on MRS.RelationshipId=SCCD.CaseFor" +
                " Left Join Master_UserDetails MU on MU.UserId=SCCD.AssignedExecutiveId";


            if (rcbClientName.Text.Trim().Equals("") && txt_CaseId.Text.Trim().Equals("") && txtMobileNoSearch.Text.Trim().Equals("")  && rcbCaseStatus.Text.Trim().Equals("") && cmbAppointmentStatusSearch.Text.Trim().Equals("") && rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null) && rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Equals(null) && rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null) && rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && rcbAssignedAgentSearch.Text.Trim().Equals(""))
            {

                ConditionQuery = " where AppointmentStatusId in(1,2) and SCCD.CaseStatus!=28 Order by ConsultationCaseAppointmentDetailsId Desc";
            }
            else
            {
                ConditionQuery = " and AppointmentStatusId in(1,2) and SCCD.CaseStatus!=28 Order by ConsultationCaseAppointmentDetailsId Desc";
            }

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

            for (int i = 0; i < rcbCaseStatus.CheckedItems.Count; i++)
            {
                if (CaseStatus == "")
                {
                    CaseStatus = rcbCaseStatus.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CaseStatus += "," + rcbCaseStatus.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbAppointmentStatusSearch.CheckedItems.Count; i++)
            {
                if (AppointmentStatus == "")
                {
                    AppointmentStatus = cmbAppointmentStatusSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    AppointmentStatus += "," + cmbAppointmentStatusSearch.CheckedItems[i].Value.Trim();
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
                    Query += "And SCCD.CorporateId in(" + CorporateId + ") ";
                }
            }

            if (CaseStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.CaseStatus in (" + CaseStatus + ") ";
                }
                else
                {
                    Query += "And SCCD.CaseStatus in(" + CaseStatus + ")";
                }
            }

            if (AppointmentStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCAD.AppointmentStatus in (" + AppointmentStatus + ")";
                }
                else
                {
                    Query += "And SCAD.AppointmentStatus in(" + AppointmentStatus + ")";
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
                    Query = " where AssignedExecutiveId in (" + AssignedAgent + ") ";
                }
                else
                {
                    Query += " And AssignedExecutiveId in(" + AssignedAgent + ") ";
                }
            }

            if (CaseReceivedMode != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCM.CaseReceivedModeId in (" + CaseReceivedMode + ") ";
                }
                else
                {
                    Query += " And MCM.CaseReceivedModeId in(" + CaseReceivedMode + ") ";
                }
            }

            if (cmbStateSearch.SelectedValue != "0" && cmbStateSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where State in (" + cmbStateSearch.SelectedValue + ") ";
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
                    Query = " where City in (" + cmbCitySearch.SelectedValue + ") ";
                }
                else
                {
                    Query += " And City in(" + cmbCitySearch.SelectedValue + ") ";
                }
            }

            if (City != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where City in (" + City + ") ";
                }
                else
                {
                    Query += " And City in(" + City + ") ";
                }
            }



            if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where Convert(varchar(10),CaseRecievedDateTime,105) Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
                else
                {
                    Query += " And Convert(varchar(10),CaseRecievedDateTime,105) Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
            }
            else if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where Convert(varchar(10),CaseRecievedDateTime,105) ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
                else
                {
                    Query += " And Convert(varchar(10),CaseRecievedDateTime,105) ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
            }





            if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where Convert(varchar(10),FollowUpDateTime,105) Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
                else
                {
                    Query += " And Convert(varchar(10),FollowUpDateTime,105) Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
            }
            else if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where Convert(varchar(10),FollowUpDateTime,105) ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                }
                else
                {
                    Query += " And Convert(varchar(10),FollowUpDateTime,105) ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
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
                    Query = " where SCCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%' ";
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
                    Query = " where CaseType in (" + cmbCaseTypeSearch.SelectedValue + ") ";
                }
                else
                {
                    Query += " And CaseType in(" + cmbCaseTypeSearch.SelectedValue + ") ";
                }
            }

            if (cmbPaymentTypeSearch.SelectedValue != "0" && cmbPaymentTypeSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.PaymentType in (" + cmbPaymentTypeSearch.SelectedValue + ") ";
                }
                else
                {
                    Query += " And SCCD.PaymentType in(" + cmbPaymentTypeSearch.SelectedValue + ") ";
                }
            }



            if (cmbCustomerProfileTypeSearch.SelectedValue != "0" && cmbCustomerProfileTypeSearch.SelectedValue != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where SCCD.CustomerProfile in (" + cmbCustomerProfileTypeSearch.SelectedValue + ") ";
                }
                else
                {
                    Query += " And SCCD.CustomerProfile in(" + cmbCustomerProfileTypeSearch.SelectedValue + ") ";
                }
            }



            Bal BusinessAccessLayer = new Bal();
            DataTable dtSearch = new DataTable();
            dtSearch = BusinessAccessLayer.SearchConsultationCaseDetails(MainQuery + Query + ConditionQuery);

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
            try
            {
                string Language_Id = "";

                for (int i = 0; i < cmbLanguage.CheckedItems.Count; i++)
                {
                    if (Language_Id == "")
                    {
                        Language_Id = cmbLanguage.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        Language_Id += "," + cmbLanguage.CheckedItems[i].Value.Trim();
                    }
                }

                cmbDoctorName.Items.Clear();

                DataTable dtDoctorDetails = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtDoctorDetails = BusinessAccessLayer.LoadDoctorSearchByLanguage(Language_Id);
                if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
                {
                    cmbDoctorName.DataSource = dtDoctorDetails;
                    cmbDoctorName.DataTextField = "DoctorName";
                    cmbDoctorName.DataValueField = "DoctorId";
                    cmbDoctorName.DataBind();
                }

                cmbDoctorName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Doctor"));
                cmbDoctorName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbExport.SelectedValue == "0")
                //{
                //    showPopup("Warning", "Please Select Format to Download/Export");
                //}

                //else if (cmbExport.SelectedValue == "1")
                //{
                //    ApplyStylesToPdfExport(rgvConsultantCaseAppointmentDetails.MasterTableView);
                //    rgvConsultantCaseAppointmentDetails.MasterTableView.ExportToPdf();
                //}

                if (cmbExport.SelectedValue == "1")
                {
                    rgvConsultantCaseAppointmentDetails.MasterTableView.ExportToCSV();
                }

                else if (cmbExport.SelectedValue == "2")
                {
                    rgvConsultantCaseAppointmentDetails.ExportSettings.ExportOnlyData = true;

                    ApplyStylesToPdfExport(rgvConsultantCaseAppointmentDetails.MasterTableView);
                    rgvConsultantCaseAppointmentDetails.MasterTableView.ExportToExcel();

                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
        }

        public void ApplyStylesToPdfExport(GridTableView TableView)
        {
            GridItem headerItem = TableView.GetItems(GridItemType.Header)[0];

            headerItem.Style["font-size"] = "12pt";
            headerItem.Style["color"] = "white";
            headerItem.Style["background-color"] = "#7ba2b8";
            headerItem.Style["height"] = "20px";
            headerItem.Style["vertical-align"] = "middle";

            rgvConsultantCaseAppointmentDetails.ExportSettings.Pdf.BorderType = GridPdfSettings.GridPdfBorderType.AllBorders;
            rgvConsultantCaseAppointmentDetails.ExportSettings.Pdf.BorderStyle = GridPdfSettings.GridPdfBorderStyle.Thin;
            foreach (TableCell cell in headerItem.Cells)
            {
                cell.Style["font-size"] = "10pt";
                cell.Style["text-align"] = "center";
                //cell.Style["font-weight"] = "bold";
            }

        }

        protected void txt_CaseId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmbExport_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbExport.SelectedValue == "1")
            {
                btnDownload.Text = "Export to CSV";
            }
            else
            {
                btnDownload.Text = "Export to Excel";
            }
        }

        protected void rgvConsultantCaseAppointmentDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            foreach (GridDataItem item in rgvConsultantCaseAppointmentDetails.MasterTableView.Items)
            {
                Label lblConsultantCaseDetailsId = (item.FindControl("lblConsultantCaseDetails_Id") as Label);
                Label lblConsultationAppointmentDetailsId = (item.FindControl("lblConsultationAppointmentDetails_Id") as Label);
                //Variables.lblConsultationAppointmentDetailsId = Convert.ToInt32(lblConsultationAppointmentDetailsId.Text.Trim());
                Label lblAppointmentStatusId = (item.FindControl("lblAppointmentStatusId") as Label);
                Label lblCaseStatusId = (item.FindControl("lblCaseStatusId") as Label);
                ImageButton lnkConsultationCaseMERFile = (item.FindControl("lnkConsultationCaseMERFile") as ImageButton);

                if (lblAppointmentStatusId.Text == "2" && lblCaseStatusId.Text.Trim() != "44")
                {
                    lnkConsultationCaseMERFile.Enabled = true;
                    item.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lnkConsultationCaseMERFile.Enabled = false;
                    item.ForeColor = System.Drawing.Color.Red;
                }

                //GridDataItem dataBoundItem = e.Item as GridDataItem;
                //if (dataBoundItem["CaseStatusName"].Text == "Completed")
                //{
                //    dataBoundItem.ForeColor = System.Drawing.Color.Red;
                //}
            }
        }

      

        protected void cmbAppointmentStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(cmbAppointmentStatus.SelectedValue=="1")
            {
                cmbCaseStatus.SelectedValue = "6";
                cmbCaseStatus.Enabled = false;
            }
            else
            {
                cmbCaseStatus.Enabled = true;
            }
        }
    }
}