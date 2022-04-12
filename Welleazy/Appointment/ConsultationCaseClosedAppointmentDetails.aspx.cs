using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Appointment
{
    public partial class ConsultationCaseClosedAppointmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadConsultationCaseClosedAppointmentDetails();
                CaseStatusList();
                AppointmentStatusList();
                LoadAssignExecutive();
                //StateList();
                CorporateList();
                EConultantCloseApointmentView.ActiveViewIndex = 0;
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

                
            }


        }

        public void AppointmentStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAppointmentStatus = new DataTable();
            dtAppointmentStatus = BusinessAccessLayer.LoadAppointmentStatusList();

            if (dtAppointmentStatus != null && dtAppointmentStatus.Rows.Count > 0)
            {
                
                cmbAppointmentStatusSearch.DataSource = dtAppointmentStatus;
                cmbAppointmentStatusSearch.DataTextField = "AppointmentDescription";
                cmbAppointmentStatusSearch.DataValueField = "AppointmentStatusId";
                cmbAppointmentStatusSearch.DataBind();

            }
        }

        public void LoadConsultationCaseClosedAppointmentDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseClosedAppointmentDetails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvConsultationCaseClosedAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvConsultationCaseClosedAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultationCaseClosedAppointmentDetails.DataSource = null;
                rgvConsultationCaseClosedAppointmentDetails.DataBind();
            }
        }

        protected void rgvConsultationCaseClosedAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvConsultationCaseClosedAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvConsultationCaseClosedAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

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

            MainQuery = "Select ConsultationCaseAppointmentDetailsId,SCCD.ConsultationCaseDetailsId,CaseId,Convert(varchar(10),CaseEntryDateTime,103)CaseEntryDateTime,MCP.Description as CustomerProfile ,CorporateName,EmployeeName,SCCD.MobileNo,LanguageDescription,FollowUpDateTime,MR.Relationship as CaseFor,DoctorName,AppointmentDescription as AppointmentStatus,  CaseStatusName as CaseStatus,SCAD.ReportStatus" +
                " from ConsultationCaseAppointmentDetails SCAD " +
                " left Join ConsultationCaseDetails SCCD on SCAD.ConsultationCaseDetailsId = SCCD.ConsultationCaseDetailsId " +
                " left Join Master_CorporateDetails MCD on MCD.CorporateId = SCCD.CorporateId " +
                " left Join Master_Doctor MD on MD.DoctorId = SCAD.DoctorId " +
                " left Join Master_Language ML on ML.LanguageId = SCCD.PrefferedLanguage " +
                " Left Join Master_CustomerProfile MCP on MCP.CustomerProfileId = SCCD.CustomerProfile " +
                " Left Join Master_AppointmentStatus MAS on MAS.AppointmentStatusId = SCAD.AppointmentStatus " +
                " Left Join Master_CaseStatus MCS on MCS.StatusId = SCAD.CaseStatus " +
                " Left Join Master_RelationShip MR on MR.RelationshipId = SCCD.CaseFor ";



            if(rcbClientName.Text.Trim().Equals("") && txt_CaseId.Text.Trim().Equals("") && txtCaseOwnerSearch.Text.Trim().Equals("")
                && txtMobileNoSearch.Text.Trim().Equals("") && txtUpdatedBySearch.Text.Trim().Equals("") && rcbCaseStatus.Text.Trim().Equals("") && cmbAppointmentStatusSearch.Text.Trim().Equals("") && rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null) && rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Equals(null) && rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null) && rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && rcbAssignedAgentSearch.Text.Trim().Equals(""))
            {
                ConditionQuery = " where SCCD.CaseStatus=28 Order by ConsultationCaseAppointmentDetailsId Desc";
            }
            else
            {
                ConditionQuery = " and SCCD.CaseStatus=28 Order by ConsultationCaseAppointmentDetailsId Desc";
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

            //for (int i = 0; i < cmbCaseReceivedModeSearch.CheckedItems.Count; i++)
            //{
            //    if (CaseReceivedMode == "")
            //    {
            //        CaseReceivedMode = cmbCaseReceivedModeSearch.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        CaseReceivedMode += "," + cmbCaseReceivedModeSearch.CheckedItems[i].Value.Trim();
            //    }
            //}

            //for (int i = 0; i < cmbStateSearch.CheckedItems.Count; i++)
            //{
            //    if (State == "")
            //    {
            //        State = cmbStateSearch.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        State += "," + cmbStateSearch.CheckedItems[i].Value.Trim();
            //    }
            //}

            //for (int i = 0; i < cmbCitySearch.CheckedItems.Count; i++)
            //{
            //    if (City == "")
            //    {
            //        City = cmbCitySearch.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        City += "," + cmbCitySearch.CheckedItems[i].Value.Trim();
            //    }
            //}

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

            //if (cmbStateSearch.SelectedValue != "0" && cmbStateSearch.SelectedValue != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where State in (" + cmbStateSearch.SelectedValue + ") ";
            //    }
            //    else
            //    {
            //        Query += " And State in(" + cmbStateSearch.SelectedValue + ")";
            //    }
            //}

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

            //if (cmbCitySearch.SelectedValue != "" && cmbCitySearch.SelectedValue != "0")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where City in (" + cmbCitySearch.SelectedValue + ") ";
            //    }
            //    else
            //    {
            //        Query += " And City in(" + cmbCitySearch.SelectedValue + ") ";
            //    }
            //}

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

            //if (txtemplolyeeNameSearch.Text.Trim() != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where EmployeeName like '%" + txtemplolyeeNameSearch.Text.Trim() + "%'";
            //    }
            //    else
            //    {
            //        Query += " And EmployeeName like '%" + txtemplolyeeNameSearch.Text.Trim() + "%'";
            //    }
            //}


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

            //if (cmbCaseTypeSearch.SelectedValue != "0" && cmbCaseTypeSearch.SelectedValue != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where CaseType in (" + cmbCaseTypeSearch.SelectedValue + ") ";
            //    }
            //    else
            //    {
            //        Query += " And CaseType in(" + cmbCaseTypeSearch.SelectedValue + ") ";
            //    }
            //}

            //if (cmbPaymentTypeSearch.SelectedValue != "0" && cmbPaymentTypeSearch.SelectedValue != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where SCCD.PaymentType in (" + cmbPaymentTypeSearch.SelectedValue + ") ";
            //    }
            //    else
            //    {
            //        Query += " And SCCD.PaymentType in(" + cmbPaymentTypeSearch.SelectedValue + ") ";
            //    }
            //}



            //if (cmbCustomerProfileTypeSearch.SelectedValue != "0" && cmbCustomerProfileTypeSearch.SelectedValue != "")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where SCCD.CustomerProfile in (" + cmbCustomerProfileTypeSearch.SelectedValue + ") ";
            //    }
            //    else
            //    {
            //        Query += " And SCCD.CustomerProfile in(" + cmbCustomerProfileTypeSearch.SelectedValue + ") ";
            //    }
            //}



            Bal BusinessAccessLayer = new Bal();
            DataTable dtSearch = new DataTable();
            dtSearch = BusinessAccessLayer.SearchConsultationCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                rgvConsultationCaseClosedAppointmentDetails.DataSource = dtSearch;
                rgvConsultationCaseClosedAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultationCaseClosedAppointmentDetails.DataSource = new object[] { }; ;
                rgvConsultationCaseClosedAppointmentDetails.DataBind();
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

        protected void lnlAppointmentList_Click(object sender, EventArgs e)
        {

        }
    }
}