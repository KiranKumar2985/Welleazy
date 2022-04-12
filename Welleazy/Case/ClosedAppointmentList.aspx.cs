using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using Telerik.Web.UI;

namespace Welleazy.Case
{
    public partial class ClosedAppointmentList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    CorporateList();
                    BranchList();
                    LoadState();
                    LoadDistrict();
                    DCList();
                    //AppointmentStatusList();
                    CaseStatusList();
                    ReportStatusList();
                    LoadAssignExecutive();
                    LoadUpdatedBy();
                    LoadReportUploadBy();
                    LoadAppointmentScheduleBy();
                    QCErrorType();
                    LoadInterpretationCaseStatusList();
                    LoadDoctorList();

                    Bal BusinessAccessLayer = new Bal();
                    if (Session["EmployeeRefId"] != null && Session["LoginType"].Equals("2"))
                    {
                        DataTable dtEmployeeDetails = new DataTable();
                        dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Convert.ToInt32(Session["EmployeeRefId"].ToString()));

                        if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                        {
                            string CorporateId = dtEmployeeDetails.Rows[0]["CorporateId"].ToString();
                            String[] CorporateIdValue = CorporateId.Split(',');

                            int lenght = CorporateIdValue.Length;

                            foreach (string s in CorporateIdValue)
                            {
                                foreach (RadComboBoxItem item in rcbClientName.Items)//ListItem item in rcbMedicalTest.Items)
                                {
                                    if (item.Value == s)
                                    {
                                        item.Checked = true;
                                        //item.Selected = true;
                                        break;
                                    }
                                }
                            }
                            rcbClientName.Enabled = false;
                        }
                    }

                    if (Session["LoginType"].Equals("1"))
                    {
                        Variables.CorporateId = Convert.ToInt32(Session["CorporateId"].ToString());
                        Bal BusinessAccessLayerC = new Bal();
                        DataTable dtCorporateDetails = new DataTable();
                        dtCorporateDetails = BusinessAccessLayerC.LoadCorporateDetails(Variables.CorporateId);


                        if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
                        {
                            string CorporateId = dtCorporateDetails.Rows[0]["CorporateId"].ToString();
                            String[] CorporateIdValue = CorporateId.Split(',');

                            int lenght = CorporateIdValue.Length;

                            foreach (string s in CorporateIdValue)
                            {
                                foreach (RadComboBoxItem item in rcbClientName.Items)//ListItem item in rcbMedicalTest.Items)
                                {
                                    if (item.Value == s)
                                    {
                                        item.Checked = true;
                                        //item.Selected = true;
                                        break;
                                    }
                                }
                            }
                            rcbClientName.Enabled = false;
                        }
                    }
                    LoadClosedAppointmentDetails();

                }
            }
        }


        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                rcbClientName.DataSource = dtLoadCorporateList;
                rcbClientName.DataTextField = "CorporateName";
                rcbClientName.DataValueField = "CorporateId";
                rcbClientName.DataBind();

            }
            else
            {
                rcbClientName.DataSource = null;
                rcbClientName.DataBind();
            }
        }

        public void ReportStatusList()
        {
            DataTable dtReportStatusList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtReportStatusList = BusinessAccessLayer.LoadReportStatusList();

            if (dtReportStatusList != null && dtReportStatusList.Rows.Count > 0)
            {
                rcbReportStatus.DataSource = dtReportStatusList;
                rcbReportStatus.DataTextField = "ReportStatusName";
                rcbReportStatus.DataValueField = "StatusId";
                rcbReportStatus.DataBind();

            }
            else
            {
                rcbReportStatus.DataSource = null;
                rcbReportStatus.DataBind();
            }
        }
        public void BranchList()
        {
            DataTable dtLoadBranchList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadBranchList = BusinessAccessLayer.LoadBranchList();

            if (dtLoadBranchList != null && dtLoadBranchList.Rows.Count > 0)
            {
                rcbBranch.DataSource = dtLoadBranchList;
                rcbBranch.DataTextField = "BranchName";
                rcbBranch.DataValueField = "BranchId";
                rcbBranch.DataBind();

            }
            else
            {
                rcbBranch.DataSource = null;
                rcbBranch.DataBind();
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
            DataTable dtLoadCityListSearch = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCityListSearch = BusinessAccessLayer.LoadDistrict();

            if (dtLoadCityListSearch != null && dtLoadCityListSearch.Rows.Count > 0)
            {
                rcbCitySearch.DataSource = dtLoadCityListSearch;
                rcbCitySearch.DataTextField = "DistrictName";
                rcbCitySearch.DataValueField = "DistrictId";
                rcbCitySearch.DataBind();

            }
            else
            {
                rcbCitySearch.DataSource = null;
                rcbCitySearch.DataBind();
            }

        }

        public void DCList()
        {
            DataTable dtLoadDCList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadDCList = BusinessAccessLayer.LoadDCListDetails();

            if (dtLoadDCList != null && dtLoadDCList.Rows.Count > 0)
            {
                rcbDCName.DataSource = dtLoadDCList;
                rcbDCName.DataTextField = "center_name";
                rcbDCName.DataValueField = "dc_id";
                rcbDCName.DataBind();

            }
            else
            {
                rcbDCName.DataSource = null;
                rcbDCName.DataBind();
            }
        }

        public void LoadAssignExecutive()
        {
            //rcbAssignedAgent.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAssignExecutiveDetails = new DataTable();
            dtAssignExecutiveDetails = BusinessAccessLayer.LoadAssignExecutive();
            
            if (dtAssignExecutiveDetails != null && dtAssignExecutiveDetails.Rows.Count > 0)
            {
                rcbAssignedAgent.DataSource = dtAssignExecutiveDetails;
                rcbAssignedAgent.DataTextField = "name";
                rcbAssignedAgent.DataValueField = "user_id";
                rcbAssignedAgent.DataBind();

            }

        }

        public void LoadUpdatedBy()
        {
            //rcbUpdatedBy.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtUpdatedByDetails = new DataTable();
            dtUpdatedByDetails = BusinessAccessLayer.LoadUpdatedBy();

            if (dtUpdatedByDetails != null && dtUpdatedByDetails.Rows.Count > 0)
            {
                rcbUpdatedBy.DataSource = dtUpdatedByDetails;
                rcbUpdatedBy.DataTextField = "DisplayName";
                rcbUpdatedBy.DataValueField = "LoginRefId";
                rcbUpdatedBy.DataBind();

            }

        }

        public void LoadReportUploadBy()
        {
            //rcbUpdatedBy.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtReportUploadDetails = new DataTable();
            dtReportUploadDetails = BusinessAccessLayer.LoadUpdatedBy();

            if (dtReportUploadDetails != null && dtReportUploadDetails.Rows.Count > 0)
            {
                rcbReportUploadBy.DataSource = dtReportUploadDetails;
                rcbReportUploadBy.DataTextField = "DisplayName";
                rcbReportUploadBy.DataValueField = "LoginRefId";
                rcbReportUploadBy.DataBind();

            }

        }

        public void LoadAppointmentScheduleBy()
        {
            //rcbUpdatedBy.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentScheduleDetails = new DataTable();
            dtAppointmentScheduleDetails = BusinessAccessLayer.LoadUpdatedBy();

            if (dtAppointmentScheduleDetails != null && dtAppointmentScheduleDetails.Rows.Count > 0)
            {
                rcbAppointmentBy.DataSource = dtAppointmentScheduleDetails;
                rcbAppointmentBy.DataTextField = "DisplayName";
                rcbAppointmentBy.DataValueField = "LoginRefId";
                rcbAppointmentBy.DataBind();

            }

        }

        public void QCErrorType()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtErrorType = new DataTable();
            dtErrorType = BusinessAccessLayer.LoadErrorTypeDropDown();

            if (dtErrorType != null && dtErrorType.Rows.Count > 0)
            {
                rcbErrorType.DataSource = dtErrorType;
                rcbErrorType.DataTextField = "ErrorDescription";
                rcbErrorType.DataValueField = "ErrorId";
                rcbErrorType.DataBind();
            }


        }

        public void CaseStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseStatus = new DataTable();
            dtCaseStatus = BusinessAccessLayer.LoadCaseStatusList(1);

            if (dtCaseStatus != null && dtCaseStatus.Rows.Count > 0)
            {
                rcbCaseStatus.DataSource = dtCaseStatus;
                rcbCaseStatus.DataTextField = "CaseStatusName";
                rcbCaseStatus.DataValueField = "StatusId";
                rcbCaseStatus.DataBind();
            }


        }

        public void LoadInterpretationCaseStatusList()
        {
            DataTable dtInterpretationCaseStatusList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationCaseStatusList = BusinessAccessLayer.LoadCaseStatusList(3);

            if (dtInterpretationCaseStatusList != null && dtInterpretationCaseStatusList.Rows.Count > 0)
            {
                rcbInterpretationStatus.DataSource = dtInterpretationCaseStatusList;
                rcbInterpretationStatus.DataTextField = "CaseStatusName";
                rcbInterpretationStatus.DataValueField = "StatusId";
                rcbInterpretationStatus.DataBind();

                List<string> list = new List<string>() { "42" };
                foreach (var item in list)
                {
                    RadComboBoxItem items = rcbInterpretationStatus.Items.FindItemByValue(item);
                    if (item != null)
                    {
                        items.Remove();
                    }
                }

            }
            else
            {
                rcbInterpretationStatus.DataSource = null;
                rcbInterpretationStatus.DataBind();
            }
        }

        public void LoadDoctorList()
        {
            Bal BusinessAccesslayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccesslayer.FetchDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                rcbDoctorName.DataSource = dtDoctorDetails;
                rcbDoctorName.DataTextField = "DoctorName";
                rcbDoctorName.DataValueField = "DoctorId";
                rcbDoctorName.DataBind();

            }
        }

        public void LoadClosedAppointmentDetails()
        {
            DataTable dtLoadClosedAppointmentDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadClosedAppointmentDetails = BusinessAccessLayer.LoadClosedAppointmentDetails(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadClosedAppointmentDetails != null && dtLoadClosedAppointmentDetails.Rows.Count > 0)
            {
                rgAppointmentDetails.DataSource = dtLoadClosedAppointmentDetails;
                rgAppointmentDetails.DataBind();
            }
            else
            {
                rgAppointmentDetails.DataSource = new object[] { }; ;
                rgAppointmentDetails.DataBind();
            }

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "";
            string ConditionQuery = "";
            string Query = "";
            string CorporateId = "";
            string AssignedAgent = "";
            string UpdatedBy = "";
            string AppointmentScheduleBy = "";
            string ReportUploadBy = "";
            string QCErrorType = "";
            string DCState = "";
            string DCCity = "";
            string DCName = "";
            string Branch = "";
            //string AppointmentStatus = "";
            string CaseStatus = "";
            string ReportStatus = "";
            string Videography = "";
            string CaseType = "";
            string CustomerProfile = "";
            string InterpretationType = "";
            string InterpretationStatus = "";
            string DoctorBy = "";

            if (Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("0") && Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select APT.AppointmentId,CD.CaseEntryDatetime,APT.CustomerProfile,MCP.Description,APT.CaseRefId,APT.CaseId,APT.CaseStatus,MCS.CaseStatusName, " +
                                "APT.AppointmentStatus,MAS.AppointmentDescription,APT.ReportStatus,MRES.ReportStatusName,QCD.QC_ErrorType,MET.ErrorDescription,CD.CaseFor,MRS.Relationship,APT.EmployeeName,APT.ApplicationNo, " +
                                "MCD.CorporateName,Format(AppointmentDateTime, 'dd-MM-yyyy hh:mm tt')AppointmentDateTime,TAR.DateOfClosureApproval,CD.CaseCompletionDateTime,CD.EmployeeMobileNo," +
                                "DCName,State.StateName,City.DistrictName,VisitType,DCMobileNo,IndividualTest,PackageTest,APT.BranchId,MB.BranchName,Case when CD.CaseType='1' then 'Main Medicals' when CD.CaseType='2' then 'Additional Medicals' when CD.CaseType='3' then 'Clarifications' when CD.CaseType='4' then 'Repeat Medicals' end as CaseType, " +
                                "VideographyDone,CD.AssignedExecutive,TU.name,Format(AppointmentScheduleDate, 'dd-MM-yyyy hh:mm tt')AppointmentScheduleDate,MLD.DisplayName as ScheduledBy,CD.CaseCompletionDateTime as QCDoneDate, " +
                                "TAR.ReportId,TAR.DateOfClosureApproval,TAR.PhotoId,TAR.Photo,TAR.GeoTagging,TAR.OutSourced,TAR.OutSourcedTest,TAR.ReportRecMode,TAR.ReportRecFrom,TAR.Comment,TAR.Report_Sent_at,MLD3.DisplayName as Report_Sent_by," +
                                " APT.UpdatedOn, MLD2.DisplayName as UpdatedBy, ICD.*, MICS.CaseStatusName as InterpretationStatus, MIT.InterpretationType as InterpretationTypeValue, MD.DoctorName, MD.RegistrationNumber " +
                                " from Master_ScheduleAppointment as APT" +
                                " left join Master_CaseDetails as CD on APT.CaseRefId = CD.CaseRefId" +
                                " left join Master_CorporateDetails MCD on MCD.CorporateId = APT.CorporateId" +
                                " left join Tbl_DC_Information PI on PI.dc_id = APT.dc_id" +
                                " left join Master_State State on State.StateId = PI.state" +
                                " left join Master_District City on City.DistrictId = PI.city" +
                                " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = APT.CustomerProfile" +
                                " left join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = APT.AppointmentStatus" +
                                " left join Master_CaseStatus MCS on MCS.StatusId = APT.CaseStatus" +
                                " left join Master_ReportStatus MRES on MRES.StatusId=APT.ReportStatus" +
                                " left join Master_Branch MB on MB.BranchId = APT.BranchId" +
                                " left join Master_RelationShip MRS on MRS.RelationshipId=CD.CaseFor" +
                                " left join dbo.tbl_user as TU on TU.user_id=CD.AssignedExecutive" +
                                " left join Master_LoginDetails MLD on MLD.LoginRefId = APT.ScheduledBy" +
                                " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = APT.UpdatedBy" +
                                " left join Tbl_Appointment_Report TAR on TAR.AppointmentId=APT.AppointmentId" +
                                " left join Master_LoginDetails MLD3 on MLD3.LoginRefId=TAR.Report_Sent_by" +
                                " left join Tbl_QCCheckListDetails QCD on QCD.AppointmentId=APT.AppointmentId" +
                                " left join Master_ErrorType MET on MET.ErrorId=QCD.QC_ErrorType " +
                                " left join InterpretationCaseDetails ICD on ICD.ApplicationNo=APT.ApplicationNo " +
                                " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                                " left join Master_Doctor MD on MD.DoctorId = ICD.DoctorId " +
                                " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus";

                ConditionQuery = " and APT.CaseStatus='28' and APT.ReportStatus='3' order by AppointmentId desc";
            }
            else if (!Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("1") && !Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select APT.AppointmentId,CD.CaseEntryDatetime,APT.CustomerProfile,MCP.Description,APT.CaseRefId,APT.CaseId,APT.CaseStatus,MCS.CaseStatusName, " +
                                "APT.AppointmentStatus,MAS.AppointmentDescription,APT.ReportStatus,MRES.ReportStatusName,QCD.QC_ErrorType,MET.ErrorDescription,CD.CaseFor,MRS.Relationship,APT.EmployeeName,APT.ApplicationNo, " +
                                "MCD.CorporateName,Format(AppointmentDateTime, 'dd-MM-yyyy hh:mm tt')AppointmentDateTime,TAR.DateOfClosureApproval,CD.CaseCompletionDateTime,CD.EmployeeMobileNo," +
                                "DCName,State.StateName,City.DistrictName,VisitType,DCMobileNo,IndividualTest,PackageTest,APT.BranchId,MB.BranchName,Case when CD.CaseType='1' then 'Main Medicals' when CD.CaseType='2' then 'Additional Medicals' when CD.CaseType='3' then 'Clarifications' when CD.CaseType='4' then 'Repeat Medicals' end as CaseType, " +
                                "VideographyDone,CD.AssignedExecutive,TU.name,Format(AppointmentScheduleDate, 'dd-MM-yyyy hh:mm tt')AppointmentScheduleDate,MLD.DisplayName as ScheduledBy,CD.CaseCompletionDateTime as QCDoneDate, " +
                                "TAR.ReportId,TAR.DateOfClosureApproval,TAR.PhotoId,TAR.Photo,TAR.GeoTagging,TAR.OutSourced,TAR.OutSourcedTest,TAR.ReportRecMode,TAR.ReportRecFrom,TAR.Comment,TAR.Report_Sent_at,MLD3.DisplayName as Report_Sent_by," +
                                " APT.UpdatedOn, MLD2.DisplayName as UpdatedBy, ICD.*, MICS.CaseStatusName as InterpretationStatus, MIT.InterpretationType as InterpretationTypeValue, MD.DoctorName, MD.RegistrationNumber " +
                                " from Master_ScheduleAppointment as APT" +
                                " left join Master_CaseDetails as CD on APT.CaseRefId = CD.CaseRefId" +
                                " left join Master_CorporateDetails MCD on MCD.CorporateId = APT.CorporateId" +
                                " left join Tbl_DC_Information PI on PI.dc_id = APT.dc_id" +
                                " left join Master_State State on State.StateId = PI.state" +
                                " left join Master_District City on City.DistrictId = PI.city" +
                                " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = APT.CustomerProfile" +
                                " left join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = APT.AppointmentStatus" +
                                " left join Master_CaseStatus MCS on MCS.StatusId = APT.CaseStatus" +
                                " left join Master_ReportStatus MRES on MRES.StatusId=APT.ReportStatus" +
                                " left join Master_Branch MB on MB.BranchId = APT.BranchId" +
                                " left join Master_RelationShip MRS on MRS.RelationshipId=CD.CaseFor" +
                                " left join dbo.tbl_user as TU on TU.user_id=CD.AssignedExecutive" +
                                " left join Master_LoginDetails MLD on MLD.LoginRefId = APT.ScheduledBy" +
                                " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = APT.UpdatedBy" +
                                " left join Tbl_Appointment_Report TAR on TAR.AppointmentId=APT.AppointmentId" +
                                " left join Master_LoginDetails MLD3 on MLD3.LoginRefId=TAR.Report_Sent_by" +
                                " left join Tbl_QCCheckListDetails QCD on QCD.AppointmentId=APT.AppointmentId" +
                                " left join Master_ErrorType MET on MET.ErrorId=QCD.QC_ErrorType " +
                                " left join InterpretationCaseDetails ICD on ICD.ApplicationNo=APT.ApplicationNo " +
                                " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                                " left join Master_Doctor MD on MD.DoctorId = ICD.DoctorId " +
                                " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus"; 

                ConditionQuery = " and APT.CaseStatus='28' and APT.ReportStatus='3' and MCD.CorporateId=" + Session["CorporateId"] + " order by AppointmentId desc";
            }
            else
            {
                MainQuery = "Select APT.AppointmentId,CD.CaseEntryDatetime,APT.CustomerProfile,MCP.Description,APT.CaseRefId,APT.CaseId,APT.CaseStatus,MCS.CaseStatusName, " +
                                "APT.AppointmentStatus,MAS.AppointmentDescription,APT.ReportStatus,MRES.ReportStatusName,QCD.QC_ErrorType,MET.ErrorDescription,CD.CaseFor,MRS.Relationship,APT.EmployeeName,APT.ApplicationNo, " +
                                "MCD.CorporateName,Format(AppointmentDateTime, 'dd-MM-yyyy hh:mm tt')AppointmentDateTime,TAR.DateOfClosureApproval,CD.CaseCompletionDateTime,CD.EmployeeMobileNo," +
                                "DCName,State.StateName,City.DistrictName,VisitType,DCMobileNo,IndividualTest,PackageTest,APT.BranchId,MB.BranchName,Case when CD.CaseType='1' then 'Main Medicals' when CD.CaseType='2' then 'Additional Medicals' when CD.CaseType='3' then 'Clarifications' when CD.CaseType='4' then 'Repeat Medicals' end as CaseType, " +
                                "VideographyDone,CD.AssignedExecutive,TU.name,Format(AppointmentScheduleDate, 'dd-MM-yyyy hh:mm tt')AppointmentScheduleDate,MLD.DisplayName as ScheduledBy,CD.CaseCompletionDateTime as QCDoneDate, " +
                                "TAR.ReportId,TAR.DateOfClosureApproval,TAR.PhotoId,TAR.Photo,TAR.GeoTagging,TAR.OutSourced,TAR.OutSourcedTest,TAR.ReportRecMode,TAR.ReportRecFrom,TAR.Comment,TAR.Report_Sent_at,MLD3.DisplayName as Report_Sent_by," +
                                " APT.UpdatedOn, MLD2.DisplayName as UpdatedBy, ICD.*, MICS.CaseStatusName as InterpretationStatus, MIT.InterpretationType as InterpretationTypeValue, MD.DoctorName, MD.RegistrationNumber " +
                                " from Master_ScheduleAppointment as APT" +
                                " left join Master_CaseDetails as CD on APT.CaseRefId = CD.CaseRefId" +
                                " left join Master_CorporateDetails MCD on MCD.CorporateId = APT.CorporateId" +
                                " left join Tbl_DC_Information PI on PI.dc_id = APT.dc_id" +
                                " left join Master_State State on State.StateId = PI.state" +
                                " left join Master_District City on City.DistrictId = PI.city" +
                                " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = APT.CustomerProfile" +
                                " left join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = APT.AppointmentStatus" +
                                " left join Master_CaseStatus MCS on MCS.StatusId = APT.CaseStatus" +
                                " left join Master_ReportStatus MRES on MRES.StatusId=APT.ReportStatus" +
                                " left join Master_Branch MB on MB.BranchId = APT.BranchId" +
                                " left join Master_RelationShip MRS on MRS.RelationshipId=CD.CaseFor" +
                                " left join dbo.tbl_user as TU on TU.user_id=CD.AssignedExecutive" +
                                " left join Master_LoginDetails MLD on MLD.LoginRefId = APT.ScheduledBy" +
                                " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = APT.UpdatedBy" +
                                " left join Tbl_Appointment_Report TAR on TAR.AppointmentId=APT.AppointmentId" +
                                " left join Master_LoginDetails MLD3 on MLD3.LoginRefId=TAR.Report_Sent_by" +
                                " left join Tbl_QCCheckListDetails QCD on QCD.AppointmentId=APT.AppointmentId" +
                                " left join Master_ErrorType MET on MET.ErrorId=QCD.QC_ErrorType " +
                                " left join InterpretationCaseDetails ICD on ICD.ApplicationNo=APT.ApplicationNo " +
                                " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                                " left join Master_Doctor MD on MD.DoctorId = ICD.DoctorId " +
                                " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus";

                ConditionQuery = " and APT.CaseStatus='28' and APT.ReportStatus='3' and CD.EmployeeRefId=" + Session["EmployeeRefId"] + " and MCD.CorporateId=" + Session["CorporateId"] + " order by AppointmentId desc";
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

            for (int i = 0; i < rcbAssignedAgent.CheckedItems.Count; i++)
            {
                if (AssignedAgent == "")
                {
                    AssignedAgent = rcbAssignedAgent.CheckedItems[i].Value.Trim();
                }
                else
                {
                    AssignedAgent += "," + rcbAssignedAgent.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbUpdatedBy.CheckedItems.Count; i++)
            {
                if (UpdatedBy == "")
                {
                    UpdatedBy = rcbUpdatedBy.CheckedItems[i].Value.Trim();
                }
                else
                {
                    UpdatedBy += "," + rcbUpdatedBy.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbAppointmentBy.CheckedItems.Count; i++)
            {
                if (AppointmentScheduleBy == "")
                {
                    AppointmentScheduleBy = rcbAppointmentBy.CheckedItems[i].Value.Trim();
                }
                else
                {
                    AppointmentScheduleBy += "," + rcbAppointmentBy.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbReportUploadBy.CheckedItems.Count; i++)
            {
                if (ReportUploadBy == "")
                {
                    ReportUploadBy = rcbReportUploadBy.CheckedItems[i].Value.Trim();
                }
                else
                {
                    ReportUploadBy += "," + rcbReportUploadBy.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbErrorType.CheckedItems.Count; i++)
            {
                if (QCErrorType == "")
                {
                    QCErrorType = rcbErrorType.CheckedItems[i].Value.Trim();
                }
                else
                {
                    QCErrorType += "," + rcbErrorType.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbStateSearch.CheckedItems.Count; i++)
            {
                if (DCState == "")
                {
                    DCState = cmbStateSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DCState += "," + cmbStateSearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbCitySearch.CheckedItems.Count; i++)
            {
                if (DCCity == "")
                {
                    DCCity = rcbCitySearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DCCity += "," + rcbCitySearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbDCName.CheckedItems.Count; i++)
            {
                if (DCName == "")
                {
                    DCName = rcbDCName.CheckedItems[i].Text.Trim();
                }
                else
                {
                    DCName += "," + rcbDCName.CheckedItems[i].Text.Trim();
                }
            }

            for (int i = 0; i < rcbBranch.CheckedItems.Count; i++)
            {
                if (Branch == "")
                {
                    Branch = rcbBranch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    Branch += "," + rcbBranch.CheckedItems[i].Value.Trim();
                }
            }

            //for (int i = 0; i < rcbAppointmentStatus.CheckedItems.Count; i++)
            //{
            //    if (AppointmentStatus == "")
            //    {
            //        AppointmentStatus = rcbAppointmentStatus.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        AppointmentStatus += "," + rcbAppointmentStatus.CheckedItems[i].Value.Trim();
            //    }
            //}

            for (int i = 0; i < rcbReportStatus.CheckedItems.Count; i++)
            {
                if (ReportStatus == "")
                {
                    ReportStatus = rcbReportStatus.CheckedItems[i].Value.Trim();
                }
                else
                {
                    ReportStatus += "," + rcbReportStatus.CheckedItems[i].Value.Trim();
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

            for (int i = 0; i < rcbVideography.CheckedItems.Count; i++)
            {
                if (Videography == "")
                {
                    Videography = rcbVideography.CheckedItems[i].Text.Trim();
                }
                else
                {
                    Videography += "," + rcbVideography.CheckedItems[i].Text.Trim();
                }
            }

            for (int i = 0; i < rcbCaseType.CheckedItems.Count; i++)
            {
                if (CaseType == "")
                {
                    CaseType = rcbCaseType.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CaseType += "," + rcbCaseType.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < cmbCustomerProfileTypeSearch.CheckedItems.Count; i++)
            {
                if (CustomerProfile == "")
                {
                    CustomerProfile = cmbCustomerProfileTypeSearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CustomerProfile += "," + cmbCustomerProfileTypeSearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbInterpretationType.CheckedItems.Count; i++)
            {
                if (InterpretationType == "")
                {
                    InterpretationType = rcbInterpretationType.CheckedItems[i].Value.Trim();
                }
                else
                {
                    InterpretationType += "," + rcbInterpretationType.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbInterpretationStatus.CheckedItems.Count; i++)
            {
                if (InterpretationStatus == "")
                {
                    InterpretationStatus = rcbInterpretationStatus.CheckedItems[i].Value.Trim();
                }
                else
                {
                    InterpretationStatus += "," + rcbInterpretationStatus.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbDoctorName.CheckedItems.Count; i++)
            {
                if (DoctorBy == "")
                {
                    DoctorBy = rcbDoctorName.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DoctorBy += "," + rcbDoctorName.CheckedItems[i].Value.Trim();
                }
            }

            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.CorporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And APT.CorporateId in(" + CorporateId + ")";
                }
            }

            if (AssignedAgent != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CD.AssignedExecutive in (" + AssignedAgent + ")";
                }
                else
                {
                    Query += " And CD.AssignedExecutive in(" + AssignedAgent + ")";
                }
            }

            if (UpdatedBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.UpdatedBy in ('" + UpdatedBy + "')";
                }
                else
                {
                    Query += " And APT.UpdatedBy in('" + UpdatedBy + "')";
                }
            }

            if (ReportUploadBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where TAR.Report_Sent_by in ('" + ReportUploadBy + "')";
                }
                else
                {
                    Query += " And TAR.Report_Sent_by in('" + ReportUploadBy + "')";
                }
            }

            if (AppointmentScheduleBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.ScheduledBy in ('" + AppointmentScheduleBy + "')";
                }
                else
                {
                    Query += " And APT.ScheduledBy in('" + AppointmentScheduleBy + "')";
                }
            }

            if (QCErrorType != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where QCD.QC_ErrorType in ('" + QCErrorType + "')";
                }
                else
                {
                    Query += " And QCD.QC_ErrorType in('" + QCErrorType + "')";
                }
            }

            if (DCState != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where PI.state in (" + DCState + ")";
                }
                else
                {
                    Query += " And PI.state in(" + DCState + ")";
                }
            }

            if (DCCity != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where PI.city in (" + DCCity + ")";
                }
                else
                {
                    Query += " And PI.city in(" + DCCity + ")";
                }
            }

            if (DCName != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where PI.center_name in ('" + DCName + "')";
                }
                else
                {
                    Query += " And PI.center_name in('" + DCName + "')";
                }
            }

            if (Branch != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.BranchId in ('" + Branch + "')";
                }
                else
                {
                    Query += " And APT.BranchId in('" + Branch + "')";
                }
            }

            //if (AppointmentStatus != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where APT.AppointmentStatus in (" + AppointmentStatus + ")";
            //    }
            //    else
            //    {
            //        Query += " And APT.AppointmentStatus in (" + AppointmentStatus + ")";
            //    }
            //}

            if (ReportStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.ReportStatus in (" + ReportStatus + ")";
                }
                else
                {
                    Query += " And APT.ReportStatus in (" + ReportStatus + ")";
                }
            }

            if (CaseStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.CaseStatus in (" + CaseStatus + ")";
                }
                else
                {
                    Query += " And APT.CaseStatus in (" + CaseStatus + ")";
                }
            }

            if (Videography != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where VideographyDone in ('" + Videography + "')";
                }
                else
                {
                    Query += " And VideographyDone in('" + Videography + "')";
                }
            }

            if (CaseType != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CD.CaseType in (" + CaseType + ")";
                }
                else
                {
                    Query += " And CD.CaseType in(" + CaseType + ")";
                }
            }

            if (CustomerProfile != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.CustomerProfile in (" + CustomerProfile + ")";
                }
                else
                {
                    Query += " And APT.CustomerProfile in(" + CustomerProfile + ")";
                }
            }

            if (InterpretationType != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.InterpretationType in (" + InterpretationType + ")";
                }
                else
                {
                    Query += " And ICD.InterpretationType in(" + InterpretationType + ")";
                }
            }

            if (InterpretationStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.CaseStatus in (" + InterpretationStatus + ")";
                }
                else
                {
                    Query += " And ICD.CaseStatus in(" + InterpretationStatus + ")";
                }
            }

            if (DoctorBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.DoctorId in (" + DoctorBy + ")";
                }
                else
                {
                    Query += " And ICD.DoctorId in(" + DoctorBy + ")";
                }
            }

            if (txt_ApplicationNo.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And APT.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
            }

            if (txt_CaseId.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.CaseId= '" + txt_CaseId.Text.Trim() + "'";
                }
                else
                {
                    Query += " And APT.CaseId='" + txt_CaseId.Text.Trim() + "'";
                }
            }

            if (txt_EmployeeName.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And APT.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
            }


            if (!rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpReportUploadDate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where TAR.Report_Sent_at Between'" + rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpReportUploadDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And TAR.Report_Sent_at Between'" + rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpReportUploadDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where TAR.Report_Sent_at ='" + rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And TAR.Report_Sent_at ='" + rdrpReportUploadDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }

            if (!rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where AppointmentScheduleDate Between'" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And AppointmentScheduleDate Between'" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where AppointmentScheduleDate ='" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And AppointmentScheduleDate ='" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }


            if (!rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpAppointment.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where AppointmentDateTime Between'" + rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointment.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And AppointmentDateTime Between'" + rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointment.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where AppointmentDateTime ='" + rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And AppointmentDateTime ='" + rdrpAppointment.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }



            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentSearch = new DataTable();
            dtAppointmentSearch = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtAppointmentSearch != null && dtAppointmentSearch.Rows.Count > 0)
            {
                rgAppointmentDetails.DataSource = dtAppointmentSearch;
                rgAppointmentDetails.DataBind();
            }
            else
            {
                rgAppointmentDetails.DataSource = new object[] { };
                rgAppointmentDetails.DataBind();
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

        
        protected void rgAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblAppointmentId = (Label)rgAppointmentDetails.Items[intIndex % 10].FindControl("lblAppointmentId"); // % 15 for page indexing
                    Variables.AppointmentId = Convert.ToInt32(lblAppointmentId.Text.Trim());
                                        
                    Response.Redirect("~/Case/AddReport.aspx");
                    
                }
                catch (Exception ex)
                {
                    //ex.ToString();
                }
            }
            if (e.CommandName.Equals("EditRow1"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefId = (Label)rgAppointmentDetails.Items[intIndex % 10].FindControl("lblCaseRefId"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefId.Text.Trim());

                    Response.Redirect("~/Appointment/ReportRemark.aspx");

                }
                catch (Exception ex)
                {
                    //ex.ToString();
                }
            }
            if (e.CommandName.Equals("ViewTest"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblAppointmentIdM = (Label)rgAppointmentDetails.Items[intIndex % 10].FindControl("lblAppointmentIdM"); // % 15 for page indexing
                    Variables.AppointmentId = Convert.ToInt32(lblAppointmentIdM.Text.Trim());

                    DataSet dtAppointmentDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


                    if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[0].Rows.Count > 0)
                    {
                        lblMCorporateId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        TestList();
                        string MedicalTest = dtAppointmentDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
                        string ViewTestList = "";
                        String[] MedicalTestValue = MedicalTest.Split(',');

                        int lenght = MedicalTestValue.Length;

                        foreach (string s in MedicalTestValue)
                        {
                            foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;

                                    if (ViewTestList.Equals(""))
                                    {
                                        ViewTestList = item.Text;
                                    }
                                    else
                                    {
                                        ViewTestList += "," + item.Text;
                                    }
                                    //item.Selected = true;
                                    lblIndividualTest.Text = ViewTestList;
                                    break;
                                }
                            }
                        }

                        string ScheduledTest = dtAppointmentDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                        string ViewTestList2 = "";
                        String[] ScheduledTestValue = ScheduledTest.Split(',');

                        int lenght2 = ScheduledTestValue.Length;

                        foreach (string s in ScheduledTestValue)
                        {
                            foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;

                                    if (ViewTestList2.Equals(""))
                                    {
                                        ViewTestList2 = item.Text;
                                    }
                                    else
                                    {
                                        ViewTestList2 += "," + item.Text;
                                    }
                                    //item.Selected = true;
                                    lblScheduledTest.Text = ViewTestList2;
                                    break;
                                }
                            }
                        }

                        bool showModal = true;

                        if (showModal)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void rgAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadClosedAppointmentDetails();
        }

        protected void rgAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadClosedAppointmentDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadClosedAppointmentDetails = BusinessAccessLayer.LoadClosedAppointmentDetails(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadClosedAppointmentDetails != null && dtLoadClosedAppointmentDetails.Rows.Count > 0)
            {
                rgAppointmentDetails.DataSource = dtLoadClosedAppointmentDetails;
                //rgAppointmentDetails.DataBind();
            }
            else
            {
                rgAppointmentDetails.DataSource = new object[] { }; ;
                //rgAppointmentDetails.DataBind();
            }
        }

        protected void btnAppointment_Click(object sender, ImageClickEventArgs e)
        {
            Variables.AppointmentId = Convert.ToInt32(llTestAppointmentRefId.Text);
            Response.Redirect("~/Case/Appointment.aspx");
        }

        public void TestList()
        {
            rcbMedicalTest.Items.Clear();
            rcbMedicalTest.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadTestListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "TestList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", Convert.ToInt32(lblMCorporateId.Text));

            cmdFetchServiceProviderList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                rcbMedicalTest.DataSource = dtFetchServiveProviderDetails;
                rcbMedicalTest.DataTextField = "TestName";
                rcbMedicalTest.DataValueField = "TestId";
                rcbMedicalTest.DataBind();
            }
            else
            {
                rcbMedicalTest.DataSource = null;
                rcbMedicalTest.DataBind();
            }
        }

        public void LinkTest()
        {
            try
            {
                Variables.AppointmentId = Convert.ToInt32(llTestAppointmentRefId.Text.Trim());

                DataSet dtCaseDetails = new DataSet();
                Bal BusinessAccessLayer = new Bal();
                dtCaseDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


                if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
                {
                    lblMCorporateId.Text = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                    TestList();
                    string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                    string ViewTestList = "";
                    String[] MedicalTestValue = MedicalTest.Split(',');

                    int lenght = MedicalTestValue.Length;

                    foreach (string s in MedicalTestValue)
                    {
                        foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                        {
                            if (item.Value == s)
                            {
                                item.Checked = true;

                                if (ViewTestList.Equals(""))
                                {
                                    ViewTestList = item.Text;
                                }
                                else
                                {
                                    ViewTestList += "," + item.Text;
                                }
                                //item.Selected = true;
                                TestMedicalTest.Text = ViewTestList;
                                break;
                            }
                        }
                    }
                    //bool showModal = true;

                    //if (showModal)
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }

        protected void LinkViewTest_Click(object sender, EventArgs e)
        {
            LinkTest();
            TestMedicalTest.Visible = true;
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExport.SelectedValue == "1")
                {
                    int x = rgAppointmentDetails.Items.Count;
                    if (x > 10)
                    {
                        rgAppointmentDetails.ExportSettings.IgnorePaging = true;
                        rgAppointmentDetails.MasterTableView.ExportToCSV();
                    }
                    else
                    {
                        rgAppointmentDetails.ExportSettings.IgnorePaging = false;
                        rgAppointmentDetails.MasterTableView.ExportToCSV();
                    }
                }

                //else if (cmbExport.SelectedValue == "1")
                //{
                //    ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                //    rgvConsultationCaseDetails.MasterTableView.ExportToPdf();
                //}

                else if (cmbExport.SelectedValue == "2")
                {
                    int x = rgAppointmentDetails.Items.Count;
                    if (x > 10)
                    {
                        rgAppointmentDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgAppointmentDetails.ExportSettings.IgnorePaging = true;
                        rgAppointmentDetails.MasterTableView.ExportToExcel();
                    }
                    else
                    {
                        rgAppointmentDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgAppointmentDetails.ExportSettings.IgnorePaging = false;
                        rgAppointmentDetails.MasterTableView.ExportToExcel();
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbExport_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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

        protected void rgAppointmentDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            foreach (GridDataItem item in rgAppointmentDetails.MasterTableView.Items)
            {
                Label lblAppointmentId = (item.FindControl("lblAppointmentId") as Label);
                Variables.AppointmentId = Convert.ToInt32(lblAppointmentId.Text.Trim());
                Label lblAppointmentStatus = (item.FindControl("lblAppointmentStatus") as Label);

                if (lblAppointmentStatus.Text == "Completed")
                {
                    item.ForeColor = System.Drawing.Color.Red;
                }
                
            }
        }
    }
}