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

namespace Welleazy.Appointment
{
    public partial class AppointmentHistory : System.Web.UI.Page
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
                    AppointmentStatusList();
                    CaseStatusList();
                    ReportStatusList();
                    LoadAssignExecutive();
                    LoadUpdatedBy();
                    LoadAppointmentHistoryDetails();
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

        public void AppointmentStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentStatus = new DataTable();
            dtAppointmentStatus = BusinessAccessLayer.LoadAppointmentStatusList();

            if (dtAppointmentStatus != null && dtAppointmentStatus.Rows.Count > 0)
            {
                rcbAppointmentStatus.DataSource = dtAppointmentStatus;
                rcbAppointmentStatus.DataTextField = "AppointmentDescription";
                rcbAppointmentStatus.DataValueField = "AppointmentStatusId";
                rcbAppointmentStatus.DataBind();
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

        public void LoadAppointmentHistoryDetails()
        {
            DataTable dtLoadAppointmentDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadAppointmentDetails = BusinessAccessLayer.LoadAppointmentHistoryDetails();

            if (dtLoadAppointmentDetails != null && dtLoadAppointmentDetails.Rows.Count > 0)
            {
                rgAppointmentHistoryDetails.DataSource = dtLoadAppointmentDetails;
                rgAppointmentHistoryDetails.DataBind();
            }
            else
            {
                rgAppointmentHistoryDetails.DataSource = null;
                rgAppointmentHistoryDetails.DataBind();
            }

        }

        protected void rgAppointmentHistoryDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgAppointmentHistoryDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "Select AppointmentHistId,Hist.AppointmentId,CD.CaseEntryDatetime, Hist.CustomerProfile, MCP.Description, Hist.CaseId, " +
                                "Hist.CaseStatus, MCS.CaseStatusName, Hist.AppointmentStatus,MAS.AppointmentDescription, Hist.ReportStatus, " +
                                "MRES.ReportStatusName, CD.CaseFor,MRS.Relationship, Hist.EmployeeName, " +
                                "Hist.ApplicationNo, Hist.CorporateId, MCD.CorporateName, Hist.AppointmentDateTime, CD.EmployeeMobileNo, Hist.DCName, " +
                                "Hist.VisitType, Hist.DCMobileNo, State.StateName,City.DistrictName, Hist.BranchId, MB.BranchName, CD.CaseType, Hist.VideographyDone, " +
                                "CD.AssignedExecutive, TU.name, APT.AppointmentScheduleDate, MLD.DisplayName as ScheduledBy," +
                                "TAR.ReportId, TAR.DateOfClosureApproval, TAR.PhotoId, TAR.Photo, TAR.GeoTagging, TAR.OutSourced, TAR.OutSourcedTest, TAR.ReportRecMode, TAR.ReportRecFrom, TAR.Comment as ReportComment, TAR.Report_Sent_at, MLD3.DisplayName as Report_Sent_by, Hist.UpdatedOn, MLD2.DisplayName as UpdatedBy from dbo.HistoryAppointmentDetails as Hist" +
                                " left join dbo.Master_ScheduleAppointment as APT on APT.AppointmentId = Hist.AppointmentId" +
                                " left join dbo.Master_CaseDetails as CD on APT.CaseRefId = CD.CaseRefId" +
                                " left join dbo.Master_RelationShip as MRS on MRS.RelationshipId = CD.CaseFor" +
                                " left join dbo.Master_CorporateDetails MCD on APT.CorporateId = MCD.CorporateId" +
                                " left join Tbl_DC_Information PI on PI.dc_id = APT.dc_id" +
                                " left join Master_State State on State.StateId = PI.state" +
                                " left join Master_District City on City.DistrictId = PI.city" +
                                " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = APT.CustomerProfile" +
                                " left join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = Hist.AppointmentStatus" +
                                " left join Master_CaseStatus MCS on MCS.StatusId = Hist.CaseStatus" +
                                " left join Master_ReportStatus MRES on MRES.StatusId = Hist.ReportStatus" +
                                " left join Master_Branch MB on MB.BranchId = Hist.BranchId" +
                                " left join tbl_user as TU on TU.user_id = CD.AssignedExecutive" +
                                " left join Master_LoginDetails MLD on MLD.LoginRefId = APT.ScheduledBy" +
                                " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = Hist.UpdatedBy" +
                                " left join Tbl_Appointment_Report TAR on TAR.AppointmentId = Hist.AppointmentId" +
                                " left join Master_LoginDetails MLD3 on MLD3.LoginRefId = TAR.Report_Sent_by";
            string Query = "";
            string CorporateId = "";
            string AssignedAgent = "";
            string UpdatedBy = "";
            string DCState = "";
            string DCCity = "";
            string DCName = "";
            string Branch = "";
            string AppointmentStatus = "";
            string CaseStatus = "";
            string ReportStatus = "";
            string Videography = "";
            string CaseType = "";
            string CustomerProfile = "";

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
                    DCName = rcbDCName.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DCName += "," + rcbDCName.CheckedItems[i].Value.Trim();
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

            for (int i = 0; i < rcbAppointmentStatus.CheckedItems.Count; i++)
            {
                if (AppointmentStatus == "")
                {
                    AppointmentStatus = rcbAppointmentStatus.CheckedItems[i].Value.Trim();
                }
                else
                {
                    AppointmentStatus += "," + rcbAppointmentStatus.CheckedItems[i].Value.Trim();
                }
            }

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
                    CaseType = rcbCaseType.CheckedItems[i].Text.Trim();
                }
                else
                {
                    CaseType += "," + rcbCaseType.CheckedItems[i].Text.Trim();
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

            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.CorporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And Hist.CorporateId in(" + CorporateId + ")";
                }
            }

            if (AssignedAgent != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CD.AssignedExecutive in ('" + AssignedAgent + "')";
                }
                else
                {
                    Query += " And CD.AssignedExecutive in('" + AssignedAgent + "')";
                }
            }

            if (UpdatedBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.UpdatedBy in ('" + UpdatedBy + "')";
                }
                else
                {
                    Query += " And Hist.UpdatedBy in('" + UpdatedBy + "')";
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
                    Query = " where PI.center_name in (" + DCName + ")";
                }
                else
                {
                    Query += " And PI.center_name in(" + DCName + ")";
                }
            }

            if (Branch != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.BranchId in ('" + Branch + "')";
                }
                else
                {
                    Query += " And Hist.BranchId in('" + Branch + "')";
                }
            }

            if (AppointmentStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.AppointmentStatus in (" + AppointmentStatus + ")";
                }
                else
                {
                    Query += " And Hist.AppointmentStatus in (" + AppointmentStatus + ")";
                }
            }

            if (CaseStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.CaseStatus in (" + CaseStatus + ")";
                }
                else
                {
                    Query += " And Hist.CaseStatus in (" + CaseStatus + ")";
                }
            }

            if (ReportStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.ReportStatus in (" + ReportStatus + ")";
                }
                else
                {
                    Query += " And Hist.ReportStatus in (" + ReportStatus + ")";
                }
            }

            if (Videography != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.VideographyDone in ('" + Videography + "')";
                }
                else
                {
                    Query += " And Hist.VideographyDone in('" + Videography + "')";
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
                    Query = " where Hist.CustomerProfile in (" + CustomerProfile + ")";
                }
                else
                {
                    Query += " And Hist.CustomerProfile in(" + CustomerProfile + ")";
                }
            }

            if (txt_ApplicationNo.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And Hist.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
            }

            if (txt_CaseId.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.CaseId= '" + txt_CaseId.Text.Trim() + "'";
                }
                else
                {
                    Query += " And Hist.CaseId='" + txt_CaseId.Text.Trim() + "'";
                }
            }

            if (txt_EmployeeName.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Hist.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And Hist.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
            }




            if (!rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where AppointmentScheduleDate Between'" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    Query += " And AppointmentScheduleDate Between'" + rdrpAppointmentDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpAppointmentDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' ";
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
            dtAppointmentSearch = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query);

            if (dtAppointmentSearch != null && dtAppointmentSearch.Rows.Count > 0)
            {
                rgAppointmentHistoryDetails.DataSource = dtAppointmentSearch;
                rgAppointmentHistoryDetails.DataBind();
            }
            else
            {
                rgAppointmentHistoryDetails.DataSource = new object[] { };
                rgAppointmentHistoryDetails.DataBind();
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExport.SelectedValue == "1")
                {
                    int x = rgAppointmentHistoryDetails.Items.Count;
                    if (x > 10)
                    {
                        rgAppointmentHistoryDetails.ExportSettings.IgnorePaging = true;
                        rgAppointmentHistoryDetails.MasterTableView.ExportToCSV();
                    }
                    else
                    {
                        rgAppointmentHistoryDetails.ExportSettings.IgnorePaging = false;
                        rgAppointmentHistoryDetails.MasterTableView.ExportToCSV();
                    }
                }

                //else if (cmbExport.SelectedValue == "1")
                //{
                //    ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                //    rgvConsultationCaseDetails.MasterTableView.ExportToPdf();
                //}

                else if (cmbExport.SelectedValue == "2")
                {
                    int x = rgAppointmentHistoryDetails.Items.Count;
                    if (x > 10)
                    {
                        rgAppointmentHistoryDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgAppointmentHistoryDetails.ExportSettings.IgnorePaging = true;
                        rgAppointmentHistoryDetails.MasterTableView.ExportToExcel();
                    }
                    else
                    {
                        rgAppointmentHistoryDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgAppointmentHistoryDetails.ExportSettings.IgnorePaging = false;
                        rgAppointmentHistoryDetails.MasterTableView.ExportToExcel();
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

        protected void rgAppointmentHistoryDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadAppointmentDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadAppointmentDetails = BusinessAccessLayer.LoadAppointmentHistoryDetails();

            if (dtLoadAppointmentDetails != null && dtLoadAppointmentDetails.Rows.Count > 0)
            {
                rgAppointmentHistoryDetails.DataSource = dtLoadAppointmentDetails;
                //rgAppointmentHistoryDetails.DataBind();
            }
            else
            {
                rgAppointmentHistoryDetails.DataSource = null;
                //rgAppointmentHistoryDetails.DataBind();
            }
        }
    }
}