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
    public partial class Case : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
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
                    CaseStatusList();
                    LoadAssignExecutive();
                    LoadUpdatedBy();

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
                LoadCaseDetails();

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
                rcbBranchSearch.DataSource = dtLoadBranchList;
                rcbBranchSearch.DataTextField = "BranchName";
                rcbBranchSearch.DataValueField = "BranchId";
                rcbBranchSearch.DataBind();

            }
            else
            {
                rcbBranchSearch.DataSource = null;
                rcbBranchSearch.DataBind();
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

                rcbContactCaseStatus.DataSource = dtCaseStatus;
                rcbContactCaseStatus.DataTextField = "CaseStatusName";
                rcbContactCaseStatus.DataValueField = "StatusId";
                rcbContactCaseStatus.DataBind();
            }


        }

        public void LoadCaseDetails()
        {
            DataTable dtLoadCaseDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();


            dtLoadCaseDetailsList = BusinessAccessLayer.LoadCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));


            if (dtLoadCaseDetailsList != null && dtLoadCaseDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtLoadCaseDetailsList;
                rgCaseDetails.DataBind();
            }
            else
            {
                //rgCaseDetails.DataSource = null;
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }
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
                rcbMedicalTest.DataTextField = "TestCode";
                rcbMedicalTest.DataValueField = "TestId";
                rcbMedicalTest.DataBind();
            }
            else
            {
                rcbMedicalTest.DataSource = null;
                rcbMedicalTest.DataBind();
            }
        }

        public void LoadAssignExecutive()
        {
            //rcbAssignedAgentSearch.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAssignExecutiveDetails = new DataTable();
            dtAssignExecutiveDetails = BusinessAccessLayer.LoadAssignExecutive();
            
            if (dtAssignExecutiveDetails != null && dtAssignExecutiveDetails.Rows.Count > 0)
            {
                rcbAssignedAgentSearch.DataSource = dtAssignExecutiveDetails;
                rcbAssignedAgentSearch.DataTextField = "name";
                rcbAssignedAgentSearch.DataValueField = "user_id";
                rcbAssignedAgentSearch.DataBind();

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

        protected void rgCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            Variables.CaseRefId = 0;

            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefId = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblCaseRefId"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefId.Text.Trim());

                    Response.Redirect("~/Case/AddCase.aspx");
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }

            if (e.CommandName.Equals("EditRow1"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefId = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblCaseRefId"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefId.Text.Trim());

                    Response.Redirect("~/Case/Remark.aspx");

                }
                catch (Exception ex)
                {
                    //ex.ToString();
                }
            }

            if (e.CommandName.Equals("AppointmentRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefIdA = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblCaseRefIdA"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefIdA.Text.Trim());

                    Response.Redirect("~/Case/Appointment.aspx");
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }

            if (e.CommandName.Equals("ViewTest"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefIdM = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblCaseRefIdM"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefIdM.Text.Trim());

                    DataSet dtCaseDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtCaseDetails = BusinessAccessLayer.LoadCaseDetailsById(Variables.CaseRefId);


                    if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
                    {
                        lblMCorporateId.Text = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        TestList();
                        string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
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

            if (e.CommandName.Equals("ShowContactDetails"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCaseRefIdM = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblCaseRefIdM"); // % 15 for page indexing
                    Variables.CaseRefId = Convert.ToInt32(lblCaseRefIdM.Text.Trim());

                    DataSet dtCaseDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtCaseDetails = BusinessAccessLayer.LoadCaseDetailsById(Variables.CaseRefId);


                    if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
                    {
                        llTestCaseRefId.Text = lblCaseRefIdM.Text;
                        TextCorporateName.Text = dtCaseDetails.Tables[0].Rows[0]["CorporateName"].ToString();
                        TextCaseOwnerName.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                        TextCaseId.Text = dtCaseDetails.Tables[0].Rows[0]["CaseId"].ToString();
                        TextApplicationNo.Text = dtCaseDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                        TextCustomerProfile.Text = dtCaseDetails.Tables[0].Rows[0]["Description"].ToString();
                        TextCity.Text = dtCaseDetails.Tables[0].Rows[0]["DistrictName"].ToString();
                        TextState.Text = dtCaseDetails.Tables[0].Rows[0]["StateName"].ToString();
                        TextMobileNo.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeMobileNo"].ToString();
                        rcbContactCaseStatus.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                        dtpContactFollowUpDate.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["SchFollowupdate"].ToString();
                        dtpEntryDate.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["CaseEntryDatetime"].ToString();
                        //lblMCorporateId.Text = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        //TestList();
                        //string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();

                        bool showModal = true;

                        if (showModal)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void rgCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadCaseDetails();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";
            string CorporateId = "";
            string AssignedAgent = "";
            string UpdatedBy = "";
            string State = "";
            string City = "";
            string Branch = "";
            string CaseStatus = "";

            if (Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("0") && Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select CaseRefId,STUFF((select ' ' + Cast(Convert(Date,APT.AppointmentDateTime,103) as varchar(max)) " +
                "from Master_ScheduleAppointment APT join Master_CaseDetails MSA on MSA.CaseRefId = APT.CaseRefId" +
                " where MCD.CaseRefId = APT.CaseRefId for XML PATH('')), 1, 1, '')AppointmentDateTime,CustomerProfile,MCP.Description,CaseId,MCD.CaseStatus,MCS.CaseStatusName," +
                               " CorporateName,CaseType,MCD.CaseFor,MRS.Relationship,EmployeeName,EmployeeMobileNo,MedicalTest," +
                               " ApplicationNo,AssignedExecutive,TU.name,MCD.WelleazyBranch,MB.BranchName,EmployeeCity,EmployeeState,State.StateId, City.DistrictId, State.StateName, City.DistrictName," +
                               " MCD.CreatedOn, MLD.DisplayName as CreatedBy, MCD.UpdatedOn, MLD2.DisplayName as UpdatedBy, " +
                               " Format(SchFollowupdate, 'dd-MM-yyyy hh:mm tt')SchFollowupdate," +
                               " Format(CaseEntryDatetime, 'dd-MM-yyyy hh:mm tt')CaseEntryDatetime" +
                               " from Master_CaseDetails MCD" +
                               " join Master_CorporateDetails MCCD on MCCD.CorporateId = MCD.CorporateId" +
                               " left join Master_State State on State.StateId = MCD.EmployeeState" +
                               " left join Master_District City on City.DistrictId = MCD.EmployeeCity" +
                               " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = MCD.CustomerProfile" +
                               " left join Master_CaseStatus as MCS on MCS.StatusId = MCD.CaseStatus" +
                               " left join dbo.Master_RelationShip as MRS on MRS.RelationshipId=MCD.CaseFor" +
                               " left join dbo.Master_Branch as MB on MB.BranchId=MCD.WelleazyBranch" +
                               " left join dbo.tbl_user as TU on TU.user_id=MCD.AssignedExecutive" +
                               " left join Master_LoginDetails MLD on MLD.LoginRefId = MCD.CreatedBy" +
                               " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = MCD.UpdatedBy";
                ConditionQuery = " and CaseStatus not in (28) order by MCD.CaseRefId desc";
            }
            else if(!Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("1") && !Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select CaseRefId,STUFF((select ' ' + Cast(Convert(Date,APT.AppointmentDateTime,103) as varchar(max)) " +
                "from Master_ScheduleAppointment APT join Master_CaseDetails MSA on MSA.CaseRefId = APT.CaseRefId" +
                " where MCD.CaseRefId = APT.CaseRefId for XML PATH('')), 1, 1, '')AppointmentDateTime,CustomerProfile,MCP.Description,CaseId,MCD.CaseStatus,MCS.CaseStatusName," +
                               " CorporateName,CaseType,MCD.CaseFor,MRS.Relationship,EmployeeName,EmployeeMobileNo,MedicalTest," +
                               " ApplicationNo,AssignedExecutive,TU.name,MCD.WelleazyBranch,MB.BranchName,EmployeeCity,EmployeeState,State.StateId, City.DistrictId, State.StateName, City.DistrictName," +
                               " MCD.CreatedOn, MLD.DisplayName as CreatedBy, MCD.UpdatedOn, MLD2.DisplayName as UpdatedBy, " +
                               " Format(SchFollowupdate, 'dd-MM-yyyy hh:mm tt')SchFollowupdate," +
                               " Format(CaseEntryDatetime, 'dd-MM-yyyy hh:mm tt')CaseEntryDatetime" +
                               " from Master_CaseDetails MCD" +
                               " join Master_CorporateDetails MCCD on MCCD.CorporateId = MCD.CorporateId" +
                               " left join Master_State State on State.StateId = MCD.EmployeeState" +
                               " left join Master_District City on City.DistrictId = MCD.EmployeeCity" +
                               " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = MCD.CustomerProfile" +
                               " left join Master_CaseStatus as MCS on MCS.StatusId = MCD.CaseStatus" +
                               " left join dbo.Master_RelationShip as MRS on MRS.RelationshipId=MCD.CaseFor" +
                               " left join dbo.Master_Branch as MB on MB.BranchId=MCD.WelleazyBranch" +
                               " left join dbo.tbl_user as TU on TU.user_id=MCD.AssignedExecutive" +
                               " left join Master_LoginDetails MLD on MLD.LoginRefId = MCD.CreatedBy" +
                               " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = MCD.UpdatedBy";
                ConditionQuery = " and CaseStatus not in (28) and MCD.CorporateId=" + Session["CorporateId"] + " order by MCD.CaseRefId desc";
            }
            else
            {
                MainQuery = "Select CaseRefId,STUFF((select ' ' + Cast(Convert(Date,APT.AppointmentDateTime,103) as varchar(max)) " +
                "from Master_ScheduleAppointment APT join Master_CaseDetails MSA on MSA.CaseRefId = APT.CaseRefId" +
                " where MCD.CaseRefId = APT.CaseRefId for XML PATH('')), 1, 1, '')AppointmentDateTime,CustomerProfile,MCP.Description,CaseId,MCD.CaseStatus,MCS.CaseStatusName," +
                               " CorporateName,CaseType,MCD.CaseFor,MRS.Relationship,EmployeeName,EmployeeMobileNo,MedicalTest," +
                               " ApplicationNo,AssignedExecutive,TU.name,MCD.WelleazyBranch,MB.BranchName,EmployeeCity,EmployeeState,State.StateId, City.DistrictId, State.StateName, City.DistrictName," +
                               " MCD.CreatedOn, MLD.DisplayName as CreatedBy, MCD.UpdatedOn, MLD2.DisplayName as UpdatedBy, " +
                               " Format(SchFollowupdate, 'dd-MM-yyyy hh:mm tt')SchFollowupdate," +
                               " Format(CaseEntryDatetime, 'dd-MM-yyyy hh:mm tt')CaseEntryDatetime" +
                               " from Master_CaseDetails MCD" +
                               " join Master_CorporateDetails MCCD on MCCD.CorporateId = MCD.CorporateId" +
                               " left join Master_State State on State.StateId = MCD.EmployeeState" +
                               " left join Master_District City on City.DistrictId = MCD.EmployeeCity" +
                               " left join Master_CustomerProfile MCP on MCP.CustomerProfileId = MCD.CustomerProfile" +
                               " left join Master_CaseStatus as MCS on MCS.StatusId = MCD.CaseStatus" +
                               " left join dbo.Master_RelationShip as MRS on MRS.RelationshipId=MCD.CaseFor" +
                               " left join dbo.Master_Branch as MB on MB.BranchId=MCD.WelleazyBranch" +
                               " left join dbo.tbl_user as TU on TU.user_id=MCD.AssignedExecutive" +
                               " left join Master_LoginDetails MLD on MLD.LoginRefId = MCD.CreatedBy" +
                               " left join Master_LoginDetails MLD2 on MLD2.LoginRefId = MCD.UpdatedBy";
                ConditionQuery = " and CaseStatus not in (28) and MCD.EmployeeRefId=" + Session["EmployeeRefId"] + " and MCD.CorporateId=" + Session["CorporateId"] + " order by MCD.CaseRefId desc";
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

            for (int i = 0; i < rcbCitySearch.CheckedItems.Count; i++)
            {
                if (City == "")
                {
                    City = rcbCitySearch.CheckedItems[i].Value.Trim();
                }
                else
                {
                    City += "," + rcbCitySearch.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbBranchSearch.CheckedItems.Count; i++)
            {
                if (Branch == "")
                {
                    Branch = rcbBranchSearch.CheckedItems[i].Text.Trim();
                }
                else
                {
                    Branch += "," + rcbBranchSearch.CheckedItems[i].Text.Trim();
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

            if (Branch != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where WelleazyBranch in ('" + Branch + "')";
                }
                else
                {
                    Query += " And WelleazyBranch in('" + Branch + "')";
                }
            }


            if (AssignedAgent != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where AssignedExecutive in ('" + AssignedAgent + "')";
                }
                else
                {
                    Query += " And AssignedExecutive in('" + AssignedAgent + "')";
                }
            }

            if (UpdatedBy != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.UpdatedBy in ('" + UpdatedBy + "')";
                }
                else
                {
                    Query += " And MCD.UpdatedBy in('" + UpdatedBy + "')";
                }
            }

            if (State != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeState in (" + State + ")";
                }
                else
                {
                    Query += " And EmployeeState in(" + State + ")";
                }
            }

            if (City != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeCity in (" + City + ")";
                }
                else
                {
                    Query += " And EmployeeCity in(" + City + ")";
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

            if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseEntryDatetime Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And CaseEntryDatetime Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseEntryDatetime ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And CaseEntryDatetime ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }


            if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where SchFollowupdate Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And SchFollowupdate Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where SchFollowupdate ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And SchFollowupdate ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }

            if (txtCaseOwnerSearch.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeName like '%" + txtCaseOwnerSearch.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And EmployeeName like '%" + txtCaseOwnerSearch.Text.Trim() + "%'";
                }
            }


            if (txtMobileNoSearch.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.EmployeeMobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And MCD.EmployeeMobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                }
            }

            if (txt_ApplicationNo.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ApplicationNo like '%" + txt_ApplicationNo.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ApplicationNo like '%" + txt_ApplicationNo.Text.Trim() + "%'";
                }
            }


            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtCaseDetails;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { };
                rgCaseDetails.DataBind();
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

      

        protected void rgCaseDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadCaseDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();



            dtLoadCaseDetailsList = BusinessAccessLayer.LoadCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));


            if (dtLoadCaseDetailsList != null && dtLoadCaseDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtLoadCaseDetailsList;
                //rgCaseDetails.DataBind();
            }
            else
            {
                //rgCaseDetails.DataSource = null;
                rgCaseDetails.DataSource = new object[] { }; ;
                //rgCaseDetails.DataBind();
            }
        }

        protected void btncomment_Click(object sender, ImageClickEventArgs e)
        {
            CaseUpdate.Visible = true;
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
        }

        public void LinkTest()
        {
            try
            {
                Variables.CaseRefId = Convert.ToInt32(llTestCaseRefId.Text.Trim());

                DataSet dtCaseDetails = new DataSet();
                Bal BusinessAccessLayer = new Bal();
                dtCaseDetails = BusinessAccessLayer.LoadCaseDetailsById(Variables.CaseRefId);


                if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
                {
                    lblMCorporateId.Text = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                    TestList();
                    string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
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

        protected void btnAppointment_Click(object sender, ImageClickEventArgs e)
        {
            Variables.CaseRefId = Convert.ToInt32(llTestCaseRefId.Text.Trim());
            Response.Redirect("~/Case/Appointment.aspx");
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpContactFollowUpDate.SelectedDate.Value <= dtpEntryDate.SelectedDate.Value)
            {
                //showPopup("Warning", "Follow Up Date Should not be Less than Case Entry Date");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Follow Up Date Should not be Less than Case Entry Date');</script>");
                return;
            }
            else
            {
                Bal BusinessAccessLayer = new Bal();
                string IsDataExists = "0";
                Variables.CaseRefId = Convert.ToInt32(llTestCaseRefId.Text);
                BusinessAccessLayer.InsertUpdateCaseDetailsByPopup(Variables.CaseRefId,
                    Convert.ToInt32(rcbContactCaseStatus.SelectedValue),
                    dtpContactFollowUpDate.DateInput.SelectedDate.Equals(null) ? nul : dtpContactFollowUpDate.DateInput.SelectedDate.Value,
                    txt_ContactRemark.Text.Trim(), out IsDataExists);
                if (IsDataExists == "1")
                {
                    //showPopup("Warning", "Case Already Exists");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Case Already Exists');</script>");
                }
                else
                {
                    LoadCaseDetails();
                    //SaveCaseRemark();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Case Updated Successfully');</script>");
                }
            }

        }

        //public void SaveCaseRemark()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    //string IsDataExists = "0";

        //    BusinessAccessLayer.InsertUpdateCaseRemarkDetails(0, Variables.CaseRefId, TextCaseId.Text.Trim(),
        //        txt_ContactRemark.Text.Trim(), Convert.ToInt32(rcbContactCaseStatus.SelectedValue), 
        //        Convert.ToInt32(Session["LoginRefId"].ToString()));
        //}

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExport.SelectedValue == "1")
                {
                    //foreach (GridDataItem item in rgCaseDetails.MasterTableView.Items)
                    //    item.Visible = item.Selected;
                    int x = rgCaseDetails.Items.Count;
                    if(x > 10)
                    {
                        rgCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    //rgCaseDetails.ExportSettings.IgnorePaging = true;
                    rgCaseDetails.MasterTableView.ExportToCSV();
                }

                else if (cmbExport.SelectedValue == "2")
                {
                    int x = rgCaseDetails.Items.Count;
                    if (x > 10)
                    {
                        rgCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    rgCaseDetails.MasterTableView.ExportToExcel();
                }
                else
                {

                    //ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                    //rgvConsultationCaseDetails.MasterTableView.ExportToPdf();

                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbExport_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(cmbExport.SelectedValue=="1")
            {
                btnDownload.Text = "Export to CSV";
            }
            else
            {
                btnDownload.Text = "Export to Excel";
            }
        }

        protected void rgCaseDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            foreach (GridDataItem item in rgCaseDetails.MasterTableView.Items)
            {
                Label lblCaseRefId = (item.FindControl("lblCaseRefId") as Label);
                Variables.CaseRefId = Convert.ToInt32(lblCaseRefId.Text.Trim());
                Label lblCaseStatus = (item.FindControl("lblCaseStatus") as Label);

                if (lblCaseStatus.Text == "Fresh Case")
                {
                    item.ForeColor = System.Drawing.Color.Blue;
                }
                else if (lblCaseStatus.Text == "Closed - Reports submitted to insurer")
                {
                    item.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}