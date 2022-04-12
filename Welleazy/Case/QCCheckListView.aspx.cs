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
    public partial class QCCheckListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    CorporateList();
                    BranchList();
                    LoadDistrict();
                    DCList();
                    AppointmentStatusList();
                    CaseStatusList();
                    QCErrorType();
                    LoadQCCheckListDetails();
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

                List<string> list = new List<string>() { "1", "2", "3", "4", "5", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27","28","32","33","34","35" };
                foreach (var item in list)
                {
                    RadComboBoxItem items = rcbCaseStatus.Items.FindItemByValue(item);
                    if (item != null)
                    {
                        items.Remove();
                    }
                }
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

        public void LoadQCCheckListDetails()
        {
            DataTable dtQCCheckListDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtQCCheckListDetails = BusinessAccessLayer.LoadQCCheckListDetails();

            if (dtQCCheckListDetails != null && dtQCCheckListDetails.Rows.Count > 0)
            {
                rgvQCCheckListView.DataSource = dtQCCheckListDetails;
                rgvQCCheckListView.DataBind();
            }
            else
            {
                rgvQCCheckListView.DataSource = new object[] { };
                rgvQCCheckListView.DataBind();
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "Select MCD.CaseCompletionDateTime as QCDoneDate, MCD.ApplicationNo, QReportId, TAR.ReportId, MCD.CaseRefId, MCD.CaseId, MCD.EmployeeName as CaseOwnerName, " +
                            "MCRD.CorporateName, APT.VisitType, MB.BranchName, MLD.DisplayName as ReportUploadBy, MLD2.DisplayName as UpdatedBy,APT.AppointmentStatus,MCD.CaseStatus,MCS.CaseStatusName, TQC.AppointmentId, " +
                            "Case when MET.ErrorDescription = '' Then 'NA' when MET.ErrorDescription != '' Then MET.ErrorDescription End as ErrorDescription, " +
                            "Case when Q1_InsuredName = '' then 'NA' when Q1_InsuredName = '1' then 'Yes' when Q1_InsuredName = '2' then 'No' when Q1_InsuredName = '3' then 'Unclear' end as Q1_InsuredName, " +
                            "Case when Q2_ClientId = '' then 'NA' when Q2_ClientId = '1' then 'Voters Card' when Q2_ClientId = '2' then 'Aadhaar Card' when Q2_ClientId = '3' then 'Pan Card' when Q2_ClientId = '4' then 'Passport' when Q2_ClientId = '5' then 'Driving Licence' when Q2_ClientId = '6' then 'Other' when Q2_ClientId = '7' then 'Missing' end as Q2_ClientId," +
                            "Q3_ClientIdNo, Case when Q4_LivePhoto = '' then 'NA' when Q4_LivePhoto = '1' then 'Yes' when Q4_LivePhoto = '2' then 'No' when Q4_LivePhoto = '3' then 'Unclear' end as Q4_LivePhoto , " +
                            "Case when Q5_FaceMatchScore = '' then 'NA' when Q5_FaceMatchScore = '1' then 'Yes' when Q5_FaceMatchScore = '2' then 'No' when Q5_FaceMatchScore = '3' then 'Inconclusive' end as Q5_FaceMatchScore ,  " +
                            "Case when Q6_AppDateMatch = '' then 'NA' when Q6_AppDateMatch = '1' then 'Yes' when Q6_AppDateMatch = '2' then 'No' end as Q6_AppDateMatch, " +
                            "Case when Q7_AppdateMatchIfNo = '' then 'NA' when Q7_AppdateMatchIfNo!= '' then Q7_AppdateMatchIfNo end as Q7_AppdateMatchIfNo, " +
                            "Case when Q8_DCNameMatch = '' then 'NA' when Q8_DCNameMatch = '1' then 'Yes' when Q8_DCNameMatch = '2' then 'No' when Q8_DCNameMatch = '3' then 'Outsource' end as Q8_DCNameMatch, " +
                            "Case when Q9_ReportDocSequence = '' then 'NA' when Q9_ReportDocSequence = '1' then 'Yes' when Q9_ReportDocSequence = '2' then 'No' end as Q9_ReportDocSequence, " +
                            "Case when Q10_AadharNoMasked = '' then 'NA' when Q10_AadharNoMasked = '1' then 'Yes' when Q10_AadharNoMasked = '2' then 'No' end as Q10_AadharNoMasked, " +
                            "Case when Q11_ReportNConvention = '' then 'NA' when Q11_ReportNConvention = '1' then 'Yes' when Q11_ReportNConvention = '2' then 'No' end as Q11_ReportNConvention, " +
                            "Q12_RCheckListOnSTV, STUFF((select ',' + TestName  from Master_TestDetails MTD  where MTD.TestId in (select item from SplitString(TQC.Q12_RCheckListOnSTV, ',')) " +
                            "for XML PATH('')), 1, 1, '')Q12_TestName, " +
                            "Case when Q13_InterAdded = '' then 'NA' when Q13_InterAdded = '1' then 'Yes' when Q13_InterAdded = '2' then 'No' end as Q13_InterAdded, " +
                            "Case when Q14_MERDrName = '' then 'NA' when Q14_MERDrName!= '' then Q14_MERDrName end as Q14_MERDrName, " +
                            "Case when Q15_MERDrRegNo = '' then 'NA' when Q15_MERDrRegNo!= '' then Q15_MERDrRegNo end as Q15_MERDrRegNo, " + 
                            "Case when Q16_MERDrQualification = '' then 'NA' when Q16_MERDrQualification!= '' then Q16_MERDrQualification end as Q16_MERDrQualification, " +
                            "Case When Q17_Disclosures = '' Then 'NA' when Q17_Disclosures = '1' Then 'Yes' when Q17_Disclosures = '2' Then 'No' End as Q17_Disclosures, " +
                            "Case When Q18_ApplicationNoMER = '' Then 'NA' when Q18_ApplicationNoMER = '1' Then 'Yes' when Q18_ApplicationNoMER = '2' Then 'No' when Q18_ApplicationNoMER = '3' then 'Old Application No' End as Q18_ApplicationNoMER, " +
                            "Case When Q19_OldApplicationNo = '' Then 'NA' when Q19_OldApplicationNo!= '' Then Q19_OldApplicationNo End as Q19_OldApplicationNo, " +
                            "Case When Q20_MERDate = '' Then 'NA' when Q20_MERDate = '1' Then 'Yes' when Q20_MERDate = '2' Then 'No' End as Q20_MERDate, " +
                            "Case When Q21_BPReadingPulseRate = '' Then 'NA' when Q21_BPReadingPulseRate = '1' Then 'Yes' when Q21_BPReadingPulseRate = '2' Then 'No' when Q21_BPReadingPulseRate = '3' then 'Unclear' End as Q21_BPReadingPulseRate, " +
                            "Case When Q22_FamilyHistory = '' Then 'NA' when Q22_FamilyHistory = '1' Then 'Yes' when Q22_FamilyHistory = '2' Then 'No' when Q22_FamilyHistory = '3' then 'Incomplete' End as Q22_FamilyHistory, " +
                            "Case When Q23_SAFFandIdProof = '' Then 'NA' when Q23_SAFFandIdProof = '1' Then 'Yes' when Q23_SAFFandIdProof = '2' Then 'No' when Q23_SAFFandIdProof = '3' then 'Exception' End as Q23_SAFFandIdProof, " + 
                            "Case when Q24_SAFFandIdProofException = '' then 'NA' when Q24_SAFFandIdProofException!= '' then Q24_SAFFandIdProofException end as Q24_SAFFandIdProofException, " +
                            "Case When Q25_HWDAMatchInReport = '' Then 'NA' when Q25_HWDAMatchInReport = '1' Then 'Yes' when Q25_HWDAMatchInReport = '2' Then 'No' End as Q25_HWDAMatchInReport, " +
                            "Case When Q26_AllMERQueAns = '' Then 'NA' when Q26_AllMERQueAns = '1' Then 'Yes' when Q26_AllMERQueAns = '2' Then 'No' End as Q26_AllMERQueAns, " +
                            "Case When Q27_AnyQueMarkedAsYesMER = '' Then 'NA' when Q27_AnyQueMarkedAsYesMER = '1' Then 'Yes' when Q27_AnyQueMarkedAsYesMER = '2' Then 'No' End as Q27_AnyQueMarkedAsYesMER, " +
                            "Case When Q28_RemarkGivenAsYes = '' Then 'NA' when Q28_RemarkGivenAsYes = '1' Then 'Yes' when Q28_RemarkGivenAsYes = '2' Then 'No' End as Q28_RemarkGivenAsYes, " +
                            "Case When Q29_VerifiedMER = '' Then 'NA' when Q29_VerifiedMER = '1' Then 'Yes' when Q29_VerifiedMER = '2' Then 'No' End as Q29_VerifiedMER, " +
                            "Case When Q30_ReflexiveTest = '' Then 'NA' when Q30_ReflexiveTest = '1' Then 'Yes' when Q30_ReflexiveTest = '2' Then 'No' End as Q30_ReflexiveTest, " +
                            "Case When Q31_TestComponentLIP = '' then 'NA' when Q31_TestComponentLIP!= '' then Q31_TestComponentLIP end as Q31_TestComponentLIP, " +
                            "Case When Q32_TestComponentLFT = '' then 'NA' when Q32_TestComponentLFT!= '' then Q32_TestComponentLFT end as Q32_TestComponentLFT, " +
                            "Case When Q33_WearFaceMask = '' Then 'NA' when Q33_WearFaceMask = '1' Then 'Yes' when Q33_WearFaceMask = '2' Then 'No' End as Q33_WearFaceMask " +
                            "from Tbl_QCCheckListDetails TQC " +
                            " left join Master_CaseDetails MCD on MCD.CaseRefId = TQC.CaseRefId " +
                            " left join Master_CorporateDetails MCRD on MCRD.CorporateId = MCD.CorporateId " +
                            " left join Master_ScheduleAppointment APT on APT.AppointmentId = TQC.AppointmentId " +
                            " left join Master_Branch MB on MB.BranchId = APT.BranchId " +
                            " left join Tbl_Appointment_Report TAR on TAR.AppointmentId = APT.AppointmentId " +
                            " left join Master_LoginDetails MLD    on MLD.LoginRefId = TAR.Report_Sent_by " +
                            " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = APT.UpdatedBy " +
                            " left join Master_ErrorType MET on MET.ErrorId = TQC.QC_ErrorType " +
                            " left join Master_CaseStatus MCS on MCS.StatusId = MCD.CaseStatus";
            string Query = "";
            string CorporateId = "";
            string AssignedAgent = "";
            string UpdatedBy = "";
            string QCErrorType = "";
            //string DCCity = "";
            //string DCName = "";
            string Branch = "";
            string AppointmentStatus = "";
            string CaseStatus = "";

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

            //for (int i = 0; i < rcbCitySearch.CheckedItems.Count; i++)
            //{
            //    if (DCCity == "")
            //    {
            //        DCCity = rcbCitySearch.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        DCCity += "," + rcbCitySearch.CheckedItems[i].Value.Trim();
            //    }
            //}

            //for (int i = 0; i < rcbDCName.CheckedItems.Count; i++)
            //{
            //    if (DCName == "")
            //    {
            //        DCName = rcbDCName.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        DCName += "," + rcbDCName.CheckedItems[i].Value.Trim();
            //    }
            //}

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


            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.CorporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And MCD.CorporateId in(" + CorporateId + ")";
                }
            }

            if (AssignedAgent != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.AssignedExecutive in ('" + AssignedAgent + "')";
                }
                else
                {
                    Query += " And MCD.AssignedExecutive in('" + AssignedAgent + "')";
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

            //if (DCCity != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where PI.city in (" + DCCity + ")";
            //    }
            //    else
            //    {
            //        Query += " And PI.city in(" + DCCity + ")";
            //    }
            //}

            //if (DCName != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where PI.center_name in (" + DCName + ")";
            //    }
            //    else
            //    {
            //        Query += " And PI.center_name in(" + DCName + ")";
            //    }
            //}

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

            if (AppointmentStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where APT.AppointmentStatus in (" + AppointmentStatus + ")";
                }
                else
                {
                    Query += " And APT.AppointmentStatus in (" + AppointmentStatus + ")";
                }
            }

            if (CaseStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.CaseStatus in (" + CaseStatus + ")";
                }
                else
                {
                    Query += " And MCD.CaseStatus in (" + CaseStatus + ")";
                }
            }


            if (txt_ApplicationNo.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And MCD.ApplicationNo like '%' + '" + txt_ApplicationNo.Text.Trim() + "' + '%'";
                }
            }

            if (txt_CaseId.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.CaseId= '" + txt_CaseId.Text.Trim() + "'";
                }
                else
                {
                    Query += " And MCD.CaseId='" + txt_CaseId.Text.Trim() + "'";
                }
            }

            if (txt_EmployeeName.Text != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
                else
                {
                    Query += " And MCD.EmployeeName like '%' + '" + txt_EmployeeName.Text.Trim() + "' + '%'";
                }
            }

            if (!rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpClosedDate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where QCDoneDate Between'" + rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpClosedDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And QCDoneDate Between'" + rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpClosedDate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where QCDoneDate ='" + rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And QCDoneDate ='" + rdrpClosedDate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }


            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentSearch = new DataTable();
            dtAppointmentSearch = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query);

            if (dtAppointmentSearch != null && dtAppointmentSearch.Rows.Count > 0)
            {
                rgvQCCheckListView.DataSource = dtAppointmentSearch;
                rgvQCCheckListView.DataBind();
            }
            else
            {
                rgvQCCheckListView.DataSource = new object[] { };
                rgvQCCheckListView.DataBind();
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

        protected void rgvQCCheckListView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dtQCCheckListDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtQCCheckListDetails = BusinessAccessLayer.LoadQCCheckListDetails();

            if (dtQCCheckListDetails != null && dtQCCheckListDetails.Rows.Count > 0)
            {
                rgvQCCheckListView.DataSource = dtQCCheckListDetails;
                //rgvQCCheckListView.DataBind();
            }
            else
            {
                rgvQCCheckListView.DataSource = new object[] { };
                //rgvQCCheckListView.DataBind();
            }
        }
    }
}