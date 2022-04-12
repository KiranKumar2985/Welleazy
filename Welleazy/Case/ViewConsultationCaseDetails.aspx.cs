//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Case
{
    public partial class ViewConsultationCaseDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Session["ConsultationCaseDetailsId"] = null;
                LoadConsultationCaseDetails();
                LoadCorporate();
                LoadDoctorDetails();
                LoadBranchDetails();
                LoadAssignExecutive();
                LoadState();
                LoadDistrict();
                CaseStatusList();
                LoadCaseReceivedMode();
                ConsultationView.ActiveViewIndex = 0;

                string CorporateId = Session["CorporateId"].ToString();

                if (Session["CorporateId"] != null && Session["LoginType"].Equals("2"))

                {

                    foreach (RadComboBoxItem item in rcbClientName.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == CorporateId)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                    rcbClientName.Enabled = false;
                }
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

                //cmbCaseStatus.DataSource = dtCaseStatus;
                //cmbCaseStatus.DataTextField = "CaseStatusName";
                //cmbCaseStatus.DataValueField = "StatusId";
                //cmbCaseStatus.DataBind();

                //cmbCaseStatus.Items.Remove(1);
            }


        }

        //public void LoadCorporateBranchDetails()
        //{

        //    cmbCorporateBranch.Items.Clear();
        //    DataTable dtCorporateBranchDetails = new DataTable();
        //    Bal BusinessAccessLayer = new Bal();
        //    dtCorporateBranchDetails = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(rcbClientName.SelectedValue));


        //    if (dtCorporateBranchDetails != null && dtCorporateBranchDetails.Rows.Count > 0)
        //    {
        //        cmbCorporateBranch.DataSource = dtCorporateBranchDetails;
        //        cmbCorporateBranch.DataTextField = "Branch";
        //        cmbCorporateBranch.DataValueField = "BranchDetailsId";
        //        cmbCorporateBranch.DataBind();
        //    }
        //}

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
                cmbCitySearch.DataTextField = "DistrictName";
                cmbCitySearch.DataValueField = "DistrictId";
                cmbCitySearch.DataBind();
            }
            else
            {
                cmbCitySearch.DataSource = null;
                cmbCitySearch.DataBind();
            }
        }

        public void LoadConsultationCaseDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();


            dtCaseDetails = BusinessAccessLayer.LoadConsultationCaseDetails(Convert.ToInt32(Session["EmployeeRefId"]),0,Convert.ToInt32(Session["LoginType"]));
            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                Session["ConsultationCaseDetails"] = dtCaseDetails;
                rgvConsultationCaseDetails.DataSource = dtCaseDetails;
                rgvConsultationCaseDetails.DataBind();
            }
            else
            {
                rgvConsultationCaseDetails.DataSource = null;
                rgvConsultationCaseDetails.DataBind();
            }

        }

        public void LoadCorporate()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                rcbClientName.DataSource = dtCorporateDetails;
                rcbClientName.DataTextField = "CorporateName";
                rcbClientName.DataValueField = "CorporateId";
                rcbClientName.DataBind();
            }

            
        }

        public void LoadDoctorDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccessLayer.LoadDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                //cmbDoctorName.DataSource = dtDoctorDetails;
                //cmbDoctorName.DataTextField = "DoctorName";
                //cmbDoctorName.DataValueField = "DoctorId";
                //cmbDoctorName.DataBind();
            }
        }

        public void LoadBranchDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccessLayer.LoadBranchDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                rcbBranchSearch.DataSource = dtDoctorDetails;
                rcbBranchSearch.DataTextField = "BranchName";
                rcbBranchSearch.DataValueField = "BranchId";
                rcbBranchSearch.DataBind();
            }
        }

        protected void rgvConsultationCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "AssignToDoctor")
                {


                    Label lblConsultationCaseDetailsId = (Label)rgvConsultationCaseDetails.Items[intIndex % 10].FindControl("lblConsultationCaseDetailsId");

                    //Response.Write("hi");

                    Variables.ConsultaionId = Convert.ToInt32(lblConsultationCaseDetailsId.Text.Trim());
                    CheckConsultationCaseAppointmentDetails();

                }

                if (e.CommandName == "EditRow")
                {
                    Label lblConsultationCaseDetailsId = (Label)rgvConsultationCaseDetails.Items[intIndex % 10].FindControl("lblConsultationCaseDetailsId"); // % 15 for page indexing
                    Variables.ConsultaionId = Convert.ToInt32(lblConsultationCaseDetailsId.Text.Trim());

                    Variables.ConsultaionId = Convert.ToInt32(lblConsultationCaseDetailsId.Text.Trim());
                    // Variables.ConsultationCaseEdit = 1;

                    string Id = encrypttext(Variables.ConsultaionId.ToString());

                    Response.Redirect("~/Case/ConsultationCaseDetails.aspx?ConsultationCaseId=" + Id);
                    //Response.Redirect("~/Case/ConsultationCaseDetails.aspx");
                }

                if (e.CommandName == "Remarks")


                {
                    Label lblConsultationCaseDetailsId = (Label)rgvConsultationCaseDetails.Items[intIndex % 10].FindControl("lblConsultationCaseDetailsId"); // % 15 for page indexing
                    //Variables.ConsultaionId = Convert.ToInt32(lblConsultationCaseDetailsId.Text.Trim());
                    Session["ConsultationCaseDetailsId"] = lblConsultationCaseDetailsId.Text.Trim();
                    Response.Redirect("~/CaseLogs/CaseLogDetails.aspx");
                }


                // LoadEConsultantCaseDetailsById();

                // btnSave.Text = "Update";


                //ConsultationView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }
        }

        public string encrypttext(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public void CheckConsultationCaseAppointmentDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            int result = 0;

            result = BusinessAccessLayer.CheckConsultationCaseAppointmentDetails(Variables.ConsultaionId);
            if (result == 0)
            {
                showPopup("Warning", "Appointment Already Exists");
                Variables.ConsultaionId = 0;
            }
            else
            {
                Variables.ConsultationCaseAppointmentDetailsId = 0;
                Response.Redirect("~/Appointment/ConsultationCaseAppointmentDetails.aspx");
            }

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void rgvConsultationCaseDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();


            dtCaseDetails = BusinessAccessLayer.LoadConsultationCaseDetails(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]));
            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {

                rgvConsultationCaseDetails.DataSource = Session["ConsultationCaseDetails"] as DataTable; ;
                //rgvConsultationCaseDetails.DataBind();
            }
            else
            {
                rgvConsultationCaseDetails.DataSource = null;
                //rgvConsultationCaseDetails.DataBind();
            }

        }

        protected void rgvConsultationCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";

            string CorporateId = "";
            string CaseStatus = "";
            string AssignedAgent = "";
            string CaseReceivedMode = "";
            string State = "";
            string City = "";
            string Branch = "";

            if (Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("0"))
            {

                MainQuery = "Select ConsultationCaseDetailsId,ConsultationCaseTypeId,CaseId,CorporateName,MB.BranchName,name as AssignedExecutive,MCB.BranchName as CorporateBranch,MCM.CaseReceivedMode,StateName,DistrictName,EmployeeName,MLC.LanguageDescription as CustomerPreferredLanguage," +
                    "ECCD.MobileNo,ECCD.EMailId,Case when CaseType=1 then 'Main' Else 'Additional' End  CaseType, " +
                    "NoOfFreeConsultations,NoOfConsultationReceived,MCT.ConsultationType,  MPT.PaymentType,Relationship as CaseFor," +
                    "MCP.Description as CustomerProfile,DoctorName,ML.LanguageDescription as PrefferedLanguage," +
                    "Format(FollowUpDateTime, 'dd-MM-yyyy hh:mm tt')FollowUpDateTime," +
                    "Format(CaseEntryDateTime, 'dd-MM-yyyy hh:mm tt')CaseEntryDateTime," +
                    "CaseStatusName as CaseStatus,Remarks from ConsultationCaseDetails ECCD" +
                    " Join Master_CorporateDetails MCD on MCD.CorporateId = ECCD.CorporateId" +
                    " Left Join Master_Branch MB on MB.BranchId = ECCD.BranchId" +
                    " Left Join Master_Branch MCB on MCB.BranchId = ECCD.CorporateBranchId" +
                    " Left Join Master_Gender MG on MG.GenderId = ECCD.GenderId" +
                    " Left Join Master_Doctor MD on MD.DoctorId = ECCD.DoctorId" +
                    " Left Join Master_ConsultationType MCT on MCT.ConsultationTypeId = ECCD.ConsultationType " +
                    " Left Join Master_CustomerProfile MCP on MCP.CustomerProfileId = ECCD.CustomerProfile" +
                    " Left Join Master_CaseReceivedMode MCM on MCM.CaseReceivedModeId = ECCD.CaseReceivedMode" +
                    " Left Join Master_Language ML on ML.LanguageId in (select Item from SplitString(ECCD.PrefferedLanguage, ','))" +
                    " Left Join Master_Language MLC on MLC.LanguageId in (select Item from SplitString(ECCD.PrefferedLanguage, ','))" +
                    " Left Join Master_PaymentType MPT on MPT.PaymentTypeId = ECCD.PaymentType" +
                    " Left Join Master_State MS on MS.StateId = ECCD.State" +
                    " Left Join Master_District M_D on M_D.DistrictId = ECCD.City" +
                    " Left Join Master_CaseStatus MCS on MCS.StatusId = ECCD.CaseStatus" +
                    " Left Join Master_RelationShip MRS on MRS.RelationshipId = ECCD.CaseFor " +
                    " Left Join tbl_user TU on TU.user_id=ECCD.AssignedExecutiveId";
                ConditionQuery = " and CaseStatus not in (28) order by ConsultationCaseDetailsId desc";

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
                        Query = " where ECCD.corporateId in (" + CorporateId + ") ";
                    }
                    else
                    {
                        Query += "And ECCD.CorporateId in(" + CorporateId + ")";
                    }
                }

                if (CaseStatus != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where ECCD.CaseStatus in (" + CaseStatus + ")";
                    }
                    else
                    {
                        Query += "And ECCD.CaseStatus in(" + CaseStatus + ")";
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
                        Query += " And CaseId='" + txt_CaseId.Text.Trim() + "' ";
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
                        Query = " where CaseReceivedModeId in (" + CaseReceivedMode + ") ";
                    }
                    else
                    {
                        Query += " And CaseReceivedModeId in(" + CaseReceivedMode + ") ";
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

                if (City != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where City in (" + City + ")";
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
                        Query = " where Convert(varchar(10),CaseRecievedDateTime,105) Between Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                    }
                    else
                    {
                        Query += " And Convert(varchar(10),CaseRecievedDateTime,105) Between Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                    }
                }
                else if (!rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Equals(null))
                {
                    if (Query.Equals(""))
                    {
                        Query = " where Convert(varchar(10),CaseRecievedDateTime,105) Between ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                    }
                    else
                    {
                        Query += " And Convert(varchar(10),CaseRecievedDateTime,105) Between ='" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "'";
                    }
                }



                //if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null))
                //{
                //    if(Query.Equals(""))
                //    {
                //        Query = " where FollowUpDateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd")+"'";
                //    }
                //    else
                //    {
                //        Query += " And FollowUpdateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd")+ "'";
                //    }
                //}

                if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
                {
                    if (Query.Equals(""))
                    {
                        Query = " where Convert(varchar(10),FollowUpDateTime,105) Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
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

                if (txtApplicationNo.Text.Trim() != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where ApplicationNo like '%" + txtApplicationNo.Text.Trim() + "%'";
                    }
                    else
                    {
                        Query += " And ApplicationNo like '%" + txtApplicationNo.Text.Trim() + "%'";
                    }
                }


                if (txtMobileNoSearch.Text.Trim() != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where ECCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%' ";
                    }
                    else
                    {
                        Query += " And ECCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                    }
                }
            }
            else
            {
                MainQuery = "Select ConsultationCaseDetailsId,ConsultationCaseTypeId,CaseId,ApplicationNo,CorporateName,MB.BranchName,name as AssignedExecutive,MCB.BranchName as CorporateBranch,MCM.CaseReceivedMode,StateName,DistrictName,EmployeeName,MLC.LanguageDescription as CustomerPreferredLanguage," +
                    "ECCD.MobileNo,ECCD.EMailId,Case when CaseType=1 then 'Main' Else 'Additional' End  CaseType, " +
                    "NoOfFreeConsultations,NoOfConsultationReceived,MCT.ConsultationType,  MPT.PaymentType,Relationship as CaseFor," +
                    "MCP.Description as CustomerProfile,DoctorName,ML.LanguageDescription as PrefferedLanguage," +
                    "Format(FollowUpDateTime, 'dd-MM-yyyy hh:mm tt')FollowUpDateTime," +
                    "Format(CaseEntryDateTime, 'dd-MM-yyyy hh:mm tt')CaseEntryDateTime," +
                    "CaseStatusName as CaseStatus,Remarks from ConsultationCaseDetails ECCD" +
                    " Join Master_CorporateDetails MCD on MCD.CorporateId = ECCD.CorporateId" +
                    " Left Join Master_Branch MB on MB.BranchId = ECCD.BranchId" +
                    " Left Join Master_Branch MCB on MCB.BranchId = ECCD.CorporateBranchId" +
                    " Left Join Master_Gender MG on MG.GenderId = ECCD.GenderId" +
                    " Left Join Master_Doctor MD on MD.DoctorId = ECCD.DoctorId" +
                    " Left Join Master_ConsultationType MCT on MCT.ConsultationTypeId = ECCD.ConsultationType " +
                    " Left Join Master_CustomerProfile MCP on MCP.CustomerProfileId = ECCD.CustomerProfile" +
                    " Left Join Master_CaseReceivedMode MCM on MCM.CaseReceivedModeId = ECCD.CaseReceivedMode" +
                    " Left Join Master_Language ML on ML.LanguageId in (select Item from SplitString(ECCD.PrefferedLanguage, ','))" +
                    " Left Join Master_Language MLC on MLC.LanguageId in (select Item from SplitString(ECCD.PrefferedLanguage, ','))" +
                    " Left Join Master_PaymentType MPT on MPT.PaymentTypeId = ECCD.PaymentType" +
                    " Left Join Master_State MS on MS.StateId = ECCD.State" +
                    " Left Join Master_District M_D on M_D.DistrictId = ECCD.City" +
                    " Left Join Master_CaseStatus MCS on MCS.StatusId = ECCD.CaseStatus" +
                    " Left Join Master_RelationShip MRS on MRS.RelationshipId = ECCD.CaseFor " +
                    " Left Join tbl_user TU on TU.user_id=ECCD.AssignedExecutiveId";
                ConditionQuery = " and CaseStatus not in (28) and EmployeeRefId=" + Session["EmployeeRefId"] + " order by ConsultationCaseDetailsId desc";

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
                        Query = " where ECCD.corporateId in (" + CorporateId + ")";
                    }
                    else
                    {
                        Query += "And ECCD.CorporateId in(" + CorporateId + ")";
                    }
                }

                if (CaseStatus != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where ECCD.CaseStatus in (" + CaseStatus + ") ";
                    }
                    else
                    {
                        Query += "And ECCD.CaseStatus in(" + CaseStatus + ") ";
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
                        Query += " And AssignedExecutiveId in(" + AssignedAgent + ") ";
                    }
                }

                if (CaseReceivedMode != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where CaseReceivedModeId in (" + CaseReceivedMode + ")";
                    }
                    else
                    {
                        Query += " And CaseReceivedModeId in(" + CaseReceivedMode + ") ";
                    }
                }

                if (State != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where State in (" + State + ") ";
                    }
                    else
                    {
                        Query += " And State in(" + State + ") ";
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
                        Query += " And Convert(varchar(10),CaseRecievedDateTime,105) Between'" + rdrpCaseReceivedate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpCaseReceivedate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' ";
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



                //if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null))
                //{
                //    if(Query.Equals(""))
                //    {
                //        Query = " where FollowUpDateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd")+"'";
                //    }
                //    else
                //    {
                //        Query += " And FollowUpdateTime ='" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd")+ "'";
                //    }
                //}

                if (!rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Equals(null))
                {
                    if (Query.Equals(""))
                    {
                        Query = " where Convert(varchar(10),FollowUpDateTime,105) Between'" + rdrpFollowupdate.StartDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' and '" + rdrpFollowupdate.EndDatePicker.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy") + "' ";
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
                        Query += " And EmployeeName like '%" + txtemplolyeeNameSearch.Text.Trim() + "%' ";
                    }
                }


                if (txtMobileNoSearch.Text.Trim() != "")
                {
                    if (Query.Equals(""))
                    {
                        Query = " where ECCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                    }
                    else
                    {
                        Query += " And ECCD.MobileNo like '%" + txtMobileNoSearch.Text.Trim() + "%'";
                    }
                }
            }



            Bal BusinessAccessLayer = new Bal();
            DataTable dtSearch = new DataTable();
            dtSearch = BusinessAccessLayer.SearchConsultationCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                Session["ConsultationCaseDetails"] = dtSearch;
                rgvConsultationCaseDetails.DataSource = Session["ConsultationCaseDetails"] as DataTable;
                rgvConsultationCaseDetails.DataBind();
            }
            else
            {
                rgvConsultationCaseDetails.DataSource = new object[] { };
                rgvConsultationCaseDetails.DataBind();
            }


        }

        protected void cmbStateSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(cmbStateSearch.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    cmbCitySearch.DataSource = dtCity;
                    cmbCitySearch.DataTextField = "DistrictName";
                    cmbCitySearch.DataValueField = "DistrictId";
                    cmbCitySearch.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rcbClientName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExport.SelectedValue=="0")
            {
                showPopup("Warning","Please Select Format to Download/Export");
            }

                else if(cmbExport.SelectedValue=="1")
                {
                    ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                    rgvConsultationCaseDetails.MasterTableView.ExportToPdf();
                }

            else if(cmbExport.SelectedValue=="2")
            {
                rgvConsultationCaseDetails.ExportSettings.ExportOnlyData = false;
                    rgvConsultationCaseDetails.ExportSettings.IgnorePaging = true;
                    ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                rgvConsultationCaseDetails.MasterTableView.ExportToCSV();
                    
            }
                else if(cmbExport.SelectedValue=="3")
                {
                    rgvConsultationCaseDetails.ExportSettings.IgnorePaging = true;
                    rgvConsultationCaseDetails.MasterTableView.ExportToExcel();
                    //ExportGridToPDF();
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

            rgvConsultationCaseDetails.ExportSettings.Pdf.BorderType = GridPdfSettings.GridPdfBorderType.AllBorders;
            rgvConsultationCaseDetails.ExportSettings.Pdf.BorderStyle = GridPdfSettings.GridPdfBorderStyle.Thin;
            foreach (TableCell cell in headerItem.Cells)
            {
                cell.Style["font-size"] = "10pt";
                cell.Style["text-align"] = "center";
                //cell.Style["font-weight"] = "bold";
            }

        }

        //private void ExportGridToPDF()
        //{

        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    rgvConsultationCaseDetails.RenderControl(hw);
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //    rgvConsultationCaseDetails.AllowPaging = true;
        //    rgvConsultationCaseDetails.DataBind();
        //}

        protected void cmbExport_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbExport.SelectedValue == "2")
            {
                btnDownload.Text = "Export to CSV";
            }
            else
            {
                btnDownload.Text = "Export to Excel";
            }
        }
    }
}