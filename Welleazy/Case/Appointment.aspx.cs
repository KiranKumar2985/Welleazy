using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;
using System.IO;

namespace Welleazy.Case
{
    public partial class Appointment : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int caseid = Variables.CaseRefId;
                if (Variables.CaseRefId != 0)
                {
                        CorporateList();
                        StateList();
                        AppointmentStatusList();
                        CaseStatusList();
                        ReportStatusList();
                        LoadCaseDetailsById();
                        LoadAppointmentDetailsCaseId();
                        
                        AppointmentView.ActiveViewIndex = 1;
                    
                }
                else
                {
                    if (Variables.AppointmentId != 0)
                    {
                        CorporateList();
                        StateList();
                        AppointmentStatusList();
                        CaseStatusList();
                        ReportStatusList();
                        //LoadCaseDetailsById();
                        LoadAppointmentDetailById();
                        
                        AppointmentView.ActiveViewIndex = 0;

                    }
                    else
                    {
                        StateList();
                        AppointmentStatusList();
                        CorporateList();
                        CaseStatusList();
                        ReportStatusList();
                    }

                }
                if (Session["LoginType"].Equals("2"))
                {
                    rcbCityList.Enabled = false;
                    txt_Area.ReadOnly = true;
                    txt_Pincode.ReadOnly= true;
                    rcbAppointmentStatus.Enabled = false;
                    rcbCaseStatus.Enabled = false;
                    dtpAppointmentDate.Enabled = false;
                    rcbVisitType.Enabled = false;
                    rcbApprovalBased.Enabled = false;
                    rcbVideography.Enabled = false;
                    txt_VideographyReason.ReadOnly = true;
                    btnSave.Enabled = false;
                }
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
        public void LoadAppointmentDetailsCaseId()
        {
            DataTable dtLoadAppointmentDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsCaseId();

            if (dtLoadAppointmentDetails != null && dtLoadAppointmentDetails.Rows.Count > 0)
            {
                rgAppointmentDetails.DataSource = dtLoadAppointmentDetails;
                rgAppointmentDetails.DataBind();
            }
            else
            {
                rgAppointmentDetails.DataSource = new object[] { };
                rgAppointmentDetails.DataBind();
            }
        }
        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                DDLCName.DataSource = dtLoadCorporateList;
                DDLCName.DataTextField = "CorporateName";
                DDLCName.DataValueField = "CorporateId";
                DDLCName.DataBind();

            }
            else
            {
                DDLCName.DataSource = null;
                DDLCName.DataBind();
            }
        }

        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                rcbStateList.DataSource = dtState;
                rcbStateList.DataTextField = "StateName";
                rcbStateList.DataValueField = "StateId";
                rcbStateList.DataBind();
            }
        }
        public void CityList()
        {
            rcbCityList.Items.Clear();
            try
            {
                
                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbStateList.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {   
                    rcbCityList.DataSource = dtCity;
                    rcbCityList.DataTextField = "DistrictName";
                    rcbCityList.DataValueField = "DistrictId";
                    rcbCityList.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        public void LoadTestNPackageList()
        {
            CBL_IndividualList.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtReconized = new DataTable();

            dtReconized = BusinessAccessLayer.LoadTestNPackageList(Convert.ToInt32(DDLCName.SelectedValue), Convert.ToInt32(lblCaseRefId.Text));

            if (dtReconized != null && dtReconized.Rows.Count > 0)
            {
                CBL_IndividualList.DataSource = dtReconized;
                CBL_IndividualList.DataTextField = "TestName";
                CBL_IndividualList.DataValueField = "TestId";
                CBL_IndividualList.DataBind();

                //CBL_PackageList.DataSource = dtReconized;
                //CBL_PackageList.DataTextField = "PackageName";
                //CBL_PackageList.DataValueField = "PackageId";
                //CBL_PackageList.DataBind();
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

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", Convert.ToInt32(DDLCName.SelectedValue));

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

        public void LoadCaseDetailsById()
        {
            DataSet dtCaseDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtCaseDetails = BusinessAccessLayer.LoadCaseDetailsById(Variables.CaseRefId);


            if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
            {
                lblCaseOwnerName.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                lblCaseRefId.Text = Convert.ToInt32(Variables.CaseRefId).ToString();
                lblEmployeeId.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeId"].ToString();
                lblCaseId.Text = dtCaseDetails.Tables[0].Rows[0]["CaseId"].ToString();
                lblApplicationNo.Text = dtCaseDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                lblBranchId.Text = dtCaseDetails.Tables[0].Rows[0]["WelleazyBranch"].ToString();
                lblBranch.Text = dtCaseDetails.Tables[0].Rows[0]["BranchName"].ToString();
                DDLCName.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                lblCorporateName.Text = DDLCName.SelectedItem.Text;
                rcbStateList.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["EmployeeState"].ToString();
                //rcbStateList_SelectedIndexChanged(null, null);
                CityList();
                rcbCityList.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["EmployeeCity"].ToString();
                DCCenterList();
                txt_Area.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeArea"].ToString();
                txt_Pincode.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeePincode"].ToString();

                LabelName.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                LabelCaseType.Text = dtCaseDetails.Tables[0].Rows[0]["CaseType"].ToString();
                LabelCustomerProfile.Text = dtCaseDetails.Tables[0].Rows[0]["CustomerProfile"].ToString();
                LabelCustomerProfile1.Text = dtCaseDetails.Tables[0].Rows[0]["Description"].ToString();
                LabelCorporateName.Text = DDLCName.SelectedItem.Text;
                LabelCity.Text = rcbCityList.SelectedItem.Text;
                LabelEscort.Text = "";
                LabelAddress.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeAddress"].ToString();
                LabelCaseId.Text = dtCaseDetails.Tables[0].Rows[0]["CaseId"].ToString();
                LabelGender.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeGender"].ToString();
                LabelApplicationDate.Text = dtCaseDetails.Tables[0].Rows[0]["CaseEntryDatetime"].ToString();
                LabelContactNo.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeMobileNo"].ToString();
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
                            LabelIndividualTest.Text = ViewTestList;
                            break;
                        }
                    }
                }
                //LabelIndividualTest.Text = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
                LoadTestNPackageList();
                
                LabelEmail.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeEmail"].ToString();
                LabelPackageTest.Text = "";
                rcbCaseStatus.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                //LabelCaseStatus.Text = dtCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                LabelCaseStatus1.Text = dtCaseDetails.Tables[0].Rows[0]["CaseStatusName"].ToString();
                //lblCaseStatusText.Text = LabelCaseStatus.Text;
                
                if (rcbAppointmentStatus.SelectedItem.Text == "Completed")
                {
                    rcbAppointmentStatus.Enabled = false;
                    btnSave.Visible = false;
                }
                else
                {
                    rcbAppointmentStatus.Enabled = true;
                    btnSave.Visible = true;
                }
            }

            
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if(rcbAppointmentStatus.SelectedValue=="1")
            //{
            //    //lblCaseStatusText.Text = "6";
            //    lblReportStatus.Text = "Pending";
            //}
            //else if(rcbAppointmentStatus.SelectedValue == "4")
            //{
            //    //lblCaseStatusText.Text = "7";
            //    lblReportStatus.Text = "Pending";
            //}
            //else if (rcbAppointmentStatus.SelectedValue == "3")
            //{
            //    //lblCaseStatusText.Text = "7";
            //    lblReportStatus.Text = "Pending";
            //}
            //else if (rcbAppointmentStatus.SelectedValue == "2")
            //{
            //    //lblCaseStatusText.Text = "28";
            //    lblReportStatus.Text = "Report Received QC Pending";
            //}
            //else if (rcbAppointmentStatus.SelectedValue == "5")
            //{
            //    //lblCaseStatusText.Text = "7";
            //    lblReportStatus.Text = "Pending";
            //}
            //else
            //{

            //}

            String strIndividualList = "";
            for (int i = 0; i <= CBL_IndividualList.Items.Count - 1; i++)
            {
                if (CBL_IndividualList.Items[i].Selected)
                {
                    if (strIndividualList == "")
                    {
                        strIndividualList = CBL_IndividualList.Items[i].Value;
                    }
                    else
                    {
                        strIndividualList += "," + CBL_IndividualList.Items[i].Value;
                    }
                }
            }

            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                if(rcbAppointmentStatus.SelectedValue=="1")
                {
                    rcbCaseStatus.SelectedValue = "6";
                }
                BusinessAccessLayer.InsertUpdateAppointmentDetails(0, Convert.ToInt32(lblCaseRefId.Text), 
                    lblCaseId.Text.Trim(), lblCaseOwnerName.Text.Trim(), lblApplicationNo.Text.Trim(),
                    Convert.ToInt32(lblBranchId.Text.Trim()), Convert.ToInt32(DDLCName.SelectedValue), 
                    lblEmployeeId.Text.Trim(), Convert.ToInt32(LabelCustomerProfile.Text),
                    Convert.ToInt32(rcbStateList.SelectedValue), Convert.ToInt32(rcbCityList.SelectedValue), txt_Area.Text.Trim(), txt_Pincode.Text.Trim(),
                    Convert.ToInt32(rcbAppointmentStatus.SelectedValue), dtpAppointmentDate.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDate.DateInput.SelectedDate.Value,
                    rcbVisitType.SelectedItem.Text.Trim(), rcbApprovalBased.SelectedItem.Text.Trim(),
                    rcbVideography.SelectedItem.Text.Trim(), txt_VideographyReason.Text.Trim(),
                    txt_Comment.Text.Trim(), Convert.ToInt32(LabelDCID.Text), LabelDCMobileNo.Text.Trim(),
                    LabelDCName.Text.Trim(), txt_DCAddress.Text.Trim(), strIndividualList,
                    LabelPackage.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue),1,
                    Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Appointment Already Exists");
                }
                else
                {
                    //SaveAppointmentRemark();
                    showPopup("Warning", "Appointment Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateAppointmentDetails(Variables.AppointmentId, Convert.ToInt32(lblCaseRefId.Text),
                    lblCaseId.Text.Trim(), lblCaseOwnerName.Text.Trim(), lblApplicationNo.Text.Trim(),
                    Convert.ToInt32(lblBranchId.Text.Trim()), Convert.ToInt32(DDLCName.SelectedValue),
                    lblEmployeeId.Text.Trim(), Convert.ToInt32(LabelCustomerProfile.Text),
                    Convert.ToInt32(rcbStateList.SelectedValue), Convert.ToInt32(rcbCityList.SelectedValue), txt_Area.Text.Trim(), txt_Pincode.Text.Trim(),
                    Convert.ToInt32(rcbAppointmentStatus.SelectedValue), dtpAppointmentDate.DateInput.SelectedDate.Equals(null) ? nul : dtpAppointmentDate.DateInput.SelectedDate.Value,
                    rcbVisitType.SelectedItem.Text.Trim(), rcbApprovalBased.SelectedItem.Text.Trim(),
                    rcbVideography.SelectedItem.Text.Trim(), txt_VideographyReason.Text.Trim(),
                    txt_Comment.Text.Trim(), Convert.ToInt32(LabelDCID.Text), LabelDCMobileNo.Text.Trim(),
                    LabelDCName.Text.Trim(), txt_DCAddress.Text.Trim(), strIndividualList,
                    LabelPackage.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), Convert.ToInt32(rcbReportStatus.SelectedValue),
                    Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Appointment Already Exists");
                }
                else
                {
                    //SaveAppointmentRemark();
                    showPopup("Warning", "Data Updated Successfully");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('AppointmentList.aspx');</script>");

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Appointment Updated Successfully');</script>" + "<script>window.location.href='AppointmentList.aspx';</script>");
                }
            }

            if (Variables.CaseRefId != 0)
            {
                LoadAppointmentDetailsCaseId();
                AppointmentView.ActiveViewIndex = 1;
            }
            else
            {
                //Response.Redirect("~/Case/AppointmentList.aspx");
            }
        }

        //public void SaveAppointmentRemark()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    //string IsDataExists = "0";

        //    BusinessAccessLayer.InsertUpdateAppointmentRemarkDetails(0, Convert.ToInt32(lblCaseRefId.Text), txt_Comment.Text.Trim(),
        //        Convert.ToInt32(rcbAppointmentStatus.SelectedValue), Convert.ToInt32(rcbCaseStatus.SelectedValue),
        //        Convert.ToInt32(rcbReportStatus.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));
        //}

        protected void LinkAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentView.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.CaseRefId = 0;
            Variables.AppointmentId = 0;
            Response.Redirect("~/Case/AppointmentList.aspx");
            //if(Variables.CaseRefId==0)
            //{
            //    AppointmentView.ActiveViewIndex = 1;
            //}
            //AppointmentView.ActiveViewIndex = 1;
        }

        protected void rcbVideography_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(rcbVideography.SelectedItem.Text=="No")
            {
                reason.Visible = true;
                txt_VideographyReason.Text = txt_VideographyReason.Text;
            }
            else
            {
                reason.Visible = false;
                txt_VideographyReason.Text = "";
            }
        }

        public void LoadAppointmentDetailById()
        {
            DataSet dtAppointmentDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


            if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";

                lblCaseOwnerName.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                lblCaseRefId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseRefId"].ToString();
                lblEmployeeId.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeId"].ToString();
                LabelCustomerProfile.Text = dtAppointmentDetails.Tables[0].Rows[0]["CustomerProfile"].ToString();
                lblCaseId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseId"].ToString();
                lblApplicationNo.Text = dtAppointmentDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                lblBranch.Text = dtAppointmentDetails.Tables[0].Rows[0]["BranchName"].ToString();
                lblBranchId.Text = dtAppointmentDetails.Tables[0].Rows[0]["BranchId"].ToString();
                DDLCName.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                lblCorporateName.Text = DDLCName.SelectedItem.Text;
                rcbStateList.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeState"].ToString();
                //rcbStateList_SelectedIndexChanged(null, null);
                CityList();               
                rcbCityList.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeCity"].ToString();
                DCCenterList();
                txt_Area.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeArea"].ToString();
                txt_Pincode.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeePincode"].ToString();
                rcbAppointmentStatus.SelectedValue   = dtAppointmentDetails.Tables[0].Rows[0]["AppointmentStatus"].ToString();
                dtpAppointmentDate.DbSelectedDate = dtAppointmentDetails.Tables[0].Rows[0]["AppointmentDateTime"].ToString();
                rcbVisitType.SelectedItem.Text = dtAppointmentDetails.Tables[0].Rows[0]["VisitType"].ToString();
                rcbApprovalBased.SelectedItem.Text = dtAppointmentDetails.Tables[0].Rows[0]["ADHOC_ApprovalBased"].ToString();
                rcbVideography.SelectedItem.Text = dtAppointmentDetails.Tables[0].Rows[0]["VideographyDone"].ToString();
                txt_VideographyReason.Text = dtAppointmentDetails.Tables[0].Rows[0]["VideographyReason"].ToString();
                txt_Comment.Text = dtAppointmentDetails.Tables[0].Rows[0]["Comment"].ToString();
                rcbDCList.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["dc_id"].ToString();
                LabelDCID.Text = dtAppointmentDetails.Tables[0].Rows[0]["dc_id"].ToString();
                LabelDCMobileNo.Text = dtAppointmentDetails.Tables[0].Rows[0]["DCMobileNo"].ToString();
                LabelDCName.Text = dtAppointmentDetails.Tables[0].Rows[0]["DCName"].ToString();
                txt_DCAddress.Text = dtAppointmentDetails.Tables[0].Rows[0]["DCAddress"].ToString();

                LoadTestNPackageList();
                string IndividualTest = dtAppointmentDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                String[] IndividualTestValue = IndividualTest.Split(',');

                int lenght = IndividualTestValue.Length;

                foreach (string s in IndividualTestValue)
                {
                    foreach (ListItem item in CBL_IndividualList.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                rcbCaseStatus.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                rcbReportStatus.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["ReportStatus"].ToString();
                lblReportStatus.Text = dtAppointmentDetails.Tables[0].Rows[0]["ReportStatus"].ToString();
                
                if(rcbAppointmentStatus.SelectedItem.Text=="Completed")
                {
                    rcbAppointmentStatus.Enabled = false;
                }
                else
                {
                    rcbAppointmentStatus.Enabled = true;
                }
            }

        }
        protected void rgAppointmentDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblAppointmentId = (Label)rgAppointmentDetails.Items[intIndex % 10].FindControl("lblAppointmentId"); // % 15 for page indexing
                    Variables.AppointmentId = Convert.ToInt32(lblAppointmentId.Text.Trim());

                    btnSave.Text = "Update";

                    AppointmentView.ActiveViewIndex = 0;

                    LoadAppointmentDetailById();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
                }
            }
        }

        protected void rgAppointmentDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void rcbDCList_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();

            //SqlCommand cmdFetchProviderDetails = new SqlCommand("Exec proc_LoadDCCenterList @City", con);
            //SqlParameter paramCity = new SqlParameter("@City", rcbCityList.SelectedValue);

            //cmdFetchProviderDetails.Parameters.Add(paramCity);

            //SqlDataAdapter daProviderData = new SqlDataAdapter(cmdFetchProviderDetails);
            //DataTable dtProviderDetailds = new DataTable();
            //daProviderData.Fill(dtProviderDetailds);

            DataTable dtLoadDCCenterList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadDCCenterList = BusinessAccessLayer.DCCenterListDetails(Convert.ToInt32(rcbCityList.SelectedValue), Convert.ToInt32(rcbDCList.SelectedValue));

            if (dtLoadDCCenterList != null && dtLoadDCCenterList.Rows.Count > 0)
            {
                LabelDCID.Text = dtLoadDCCenterList.Rows[0]["dc_id"].ToString();
                LabelDCMobileNo.Text = dtLoadDCCenterList.Rows[0]["mobile_no"].ToString();
                LabelDCName.Text = dtLoadDCCenterList.Rows[0]["center_name"].ToString();
                txt_DCAddress.Text = dtLoadDCCenterList.Rows[0]["address"].ToString();
 
            }
        }

        public void DCCenterList()
        {
            try
            {
                rcbDCList.Items.Clear();
                rcbDCList.Items.Insert(0,"Select Diagnostic Center");

                //DropDownList1.Items.Clear();
                //DropDownList1.Items.Insert(0, "Select Diagnostic Center");
                DataTable dtLoadDCCenterList = new DataTable();
                Bal BusinessAccessLayer = new Bal();

                dtLoadDCCenterList = BusinessAccessLayer.LoadDCCenterList(Convert.ToInt32(rcbCityList.SelectedValue));
                
               

                if (dtLoadDCCenterList != null && dtLoadDCCenterList.Rows.Count > 0)
                {
                    rcbDCList.DataSource = dtLoadDCCenterList;
                    rcbDCList.DataTextField = "center_name";
                    rcbDCList.DataValueField = "dc_id";
                    rcbDCList.DataBind();

                    //ListView1.DataSource = dtLoadDCCenterList;
                    //ListView1.DataBind();

                    //DropDownList1.DataSource = dtLoadDCCenterList;
                    //DropDownList1.DataTextField = "center_name";
                    //DropDownList1.DataValueField = "dc_id";
                    //DropDownList1.DataBind();


                }
                else
                {
                    rcbDCList.DataSource = null;
                    rcbDCList.DataBind();

                    //DropDownList1.DataSource = null;
                    //DropDownList1.DataBind();
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
      
        protected void rcbCityList_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DCCenterList();
        }

        protected void btnDCAddress_Click(object sender, EventArgs e)
        {
            //ModalPopupExtenderLogin.Show();
            //rcbDCList_SelectedIndexChanged(null, null);

            if (rcbVisitType.SelectedItem.Text=="Select")
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Please Select Visit Type');</script>");
            }
            else
            {
                //DCCenterList();
                //bool showModal = true;
                //if (showModal)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
            }
            
        }

        //protected void btn_Cancel_Click(object sender, EventArgs e)
        //{
        //    ModalPopupExtenderLogin.Hide();
        //}
    }
}