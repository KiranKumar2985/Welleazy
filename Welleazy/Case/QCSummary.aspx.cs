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
using System.Net;

namespace Welleazy.Case
{
    public partial class QCSummary : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Appointmentid = Variables.AppointmentId;
                QCErrorType();
                ReportStatusList();
                LoadAppointmentDetailById();
                
            }
        }

        public void QCErrorType()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtErrorType = new DataTable();
            dtErrorType = BusinessAccessLayer.LoadErrorTypeDropDown();

            if (dtErrorType != null && dtErrorType.Rows.Count > 0)
            {
                rcbQCErrorType.DataSource = dtErrorType;
                rcbQCErrorType.DataTextField = "ErrorDescription";
                rcbQCErrorType.DataValueField = "ErrorId";
                rcbQCErrorType.DataBind();
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

        public void TestList()
        {
            rcbMedicalTest.Items.Clear();
            rcbMedicalTest.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadTestListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "TestList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", Convert.ToInt32(lblCorporateId.Text));

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

        public void LoadTestNPackageList()
        {
            CBL_MedicalTestList.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtTestListAppointment = new DataTable();

            dtTestListAppointment = BusinessAccessLayer.LoadTestNPackageListA(Convert.ToInt32(lblCorporateId.Text), Convert.ToInt32(lblCaseRefId.Text), Convert.ToInt32(Variables.AppointmentId));

            if (dtTestListAppointment != null && dtTestListAppointment.Rows.Count > 0)
            {
                CBL_MedicalTestList.DataSource = dtTestListAppointment;
                CBL_MedicalTestList.DataTextField = "TestCode";
                CBL_MedicalTestList.DataValueField = "TestId";
                CBL_MedicalTestList.DataBind();


                //CBL_PackageList.DataSource = dtReconized;
                //CBL_PackageList.DataTextField = "PackageName";
                //CBL_PackageList.DataValueField = "PackageId";
                //CBL_PackageList.DataBind();
            }

            if (dtTestListAppointment != null && dtTestListAppointment.Rows.Count > 0)
            {
                RadGridTest.DataSource = dtTestListAppointment;
                RadGridTest.DataBind();
            }
            else
            {
                RadGridTest.DataSource = new object[] { }; ;
                RadGridTest.DataBind();
            }
        }

        public void LoadAppointmentDetailById()
        {
            DataSet dtAppointmentDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


            if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[0].Rows.Count > 0)
            {
                lblCaseRefId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseRefId"].ToString();
                lblCaseId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseId"].ToString();
                lblReportId.Text = dtAppointmentDetails.Tables[0].Rows[0]["ReportId"].ToString();
                lblQReportId.Text = dtAppointmentDetails.Tables[0].Rows[0]["QReportId"].ToString();
                if(lblQReportId.Text=="")
                {
                    Variables.QReportId = 0;
                }
                else
                {
                    Variables.QReportId = Convert.ToInt32(lblQReportId.Text);
                }
                lblCorporateName.Text = dtAppointmentDetails.Tables[0].Rows[0]["CorporateName"].ToString();
                lblCorporateId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                TestList();
                lblApplicationNo.Text = dtAppointmentDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                lblGender.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeGender"].ToString();
                lblVisitType.Text = dtAppointmentDetails.Tables[0].Rows[0]["VisitType"].ToString();
                rcbReportStatus.SelectedValue= dtAppointmentDetails.Tables[0].Rows[0]["ReportStatus"].ToString();
                rcbQCErrorType.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["QC_ErrorType"].ToString();
                rcbCaseStatus.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                lblCaseStatus.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseStatusName"].ToString();
                lblTestList.Text= dtAppointmentDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                string MedicalTest = dtAppointmentDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                //string ViewTestList = "";
                String[] MedicalTestValue = MedicalTest.Split(',');

                int lenght = MedicalTestValue.Length;

                foreach (string s in MedicalTestValue)
                {
                    foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;

                            if (item.Text == "MER" || item.Text=="RUA")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                            }
                            else if (item.Text == "ECG" || item.Text == "TMT")
                            {
                                InterpretationAdded.Visible = true;
                            }
                            else if (item.Text == "LIP")
                            {
                                LIPTestT.Visible = true;
                            }
                            else if (item.Text == "LFT")
                            {
                                LFTTestT.Visible = true;
                            }
                            else if (item.Text == "LFT" && item.Text == "MER" || item.Text == "RUA")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                LFTTestT.Visible = true;
                            }
                            else if (item.Text == "LIP" && item.Text == "MER" || item.Text == "RUA")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                LIPTestT.Visible = true;
                            }
                            else if (item.Text == "MER" || item.Text == "RUA" && item.Text == "ECG" || item.Text == "TMT" && item.Text == "LFT")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                InterpretationAdded.Visible = true;
                                LFTTestT.Visible = true;
                            }
                            else if (item.Text == "MER" || item.Text == "RUA" && item.Text == "ECG" || item.Text == "TMT" && item.Text == "LIP")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                InterpretationAdded.Visible = true;
                                LIPTestT.Visible = true;
                            }
                            else if (item.Text == "MER" || item.Text == "RUA" && item.Text == "ECG" || item.Text == "TMT" && item.Text == "LIP" && item.Text == "LFT")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                InterpretationAdded.Visible = true;
                                LFTTestT.Visible = true;
                                LIPTestT.Visible = true;
                            }
                            else if (item.Text == "MER" || item.Text == "RUA" && item.Text == "ECG" || item.Text == "TMT")
                            {
                                MerDrDetails.Visible = true;
                                MerDetails.Visible = true;
                                InterpretationAdded.Visible = true;
                            }
                            else if (item.Text == "ECG" || item.Text == "TMT" && item.Text == "LFT")
                            {
                                InterpretationAdded.Visible = true;
                                LFTTestT.Visible = true;
                            }
                            else if (item.Text == "ECG" || item.Text == "TMT" && item.Text == "LIP")
                            {
                                InterpretationAdded.Visible = true;
                                LIPTestT.Visible = true;
                            }
                            else if (item.Text == "ECG" || item.Text == "TMT" && item.Text == "LIP" && item.Text == "LFT")
                            {
                                InterpretationAdded.Visible = true;
                                LFTTestT.Visible = true;
                                LIPTestT.Visible = true;
                            }
                            else
                            {
                                //MerDrDetails.Visible = false;
                                //MerDetails.Visible = false;
                                //InterpretationAdded.Visible = false;
                                //LIPTestT.Visible = false;
                                //LFTTestT.Visible = false;
                            }

                        }
                        
                    }

                }
                LoadTestNPackageList();

                string ReportName = "RequirementDocument.pdf";
                string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string filepath = directory + "App_Data" + "\\" + ReportName;
                this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes(filepath));
                //this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes("E:/Welleazy/Welleazy/App_Data/RequirementDocument.pdf"));

                //QC Question
                rcbQuestion1.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q1_InsuredName"].ToString();
                rcbQuestion2.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q2_ClientId"].ToString();
                if (rcbQuestion2.SelectedValue == "2")
                {
                    AadhaarMasked.Visible = true;
                }
                else
                {
                    AadhaarMasked.Visible = false;
                }
                rcbQuestion3.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q3_ClientIdNo"].ToString();
                rcbQuestion4.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q4_LivePhoto"].ToString();
                rcbQuestion5.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q5_FaceMatchScore"].ToString();
                rcbQuestion6.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q6_AppDateMatch"].ToString();
                if (rcbQuestion6.SelectedValue == "2")
                {
                    txtQuestion7.Visible = true;
                }
                else
                {
                    txtQuestion7.Visible = false;
                }
                txtQuestion7.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q7_AppdateMatchIfNo"].ToString();
                rcbQuestion8.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q8_DCNameMatch"].ToString();
                rcbQuestion9.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q9_ReportDocSequence"].ToString();
                rcbQuestion10.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q10_AadharNoMasked"].ToString();
                rcbQuestion11.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q11_ReportNConvention"].ToString();
                string Q12_STV = dtAppointmentDetails.Tables[0].Rows[0]["Q12_RCheckListOnSTV"].ToString();
                
                String[] STVTestValue = Q12_STV.Split(',');
                
                int lenght2 = STVTestValue.Length;

                foreach (string s in STVTestValue)
                {
                    foreach (ListItem item in CBL_MedicalTestList.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                rcbInterQuestion13.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q13_InterAdded"].ToString();
                txtMerDrName14.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q14_MERDrName"].ToString();
                txtMerDrRNo15.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q15_MERDrRegNo"].ToString();
                txtMerDrQualification16.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q16_MERDrQualification"].ToString();
                rcbMerQuestion17.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q17_Disclosures"].ToString();
                rcbMerQuestion18.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q18_ApplicationNoMER"].ToString();
                if (rcbMerQuestion18.SelectedValue == "3")
                {
                    txtOldApplicationNo19.Visible = true;
                }
                else
                {
                    txtOldApplicationNo19.Visible = false;
                }
                txtOldApplicationNo19.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q19_OldApplicationNo"].ToString();
                rcbMerQuestion20.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q20_MERDate"].ToString();
                rcbMerQuestion21.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q21_BPReadingPulseRate"].ToString();
                rcbMerQuestion22.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q22_FamilyHistory"].ToString();
                rcbMerQuestion23.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q23_SAFFandIdProof"].ToString();
                if (rcbMerQuestion23.SelectedValue == "3")
                {
                    txtMerQuestion24.Visible = true;
                }
                else
                {
                    txtMerQuestion24.Visible = false;
                }
                txtMerQuestion24.Text = dtAppointmentDetails.Tables[0].Rows[0]["Q24_SAFFandIdProofException"].ToString();
                rcbMerQuestion25.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q25_HWDAMatchInReport"].ToString();
                rcbMerQuestion26.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q26_AllMERQueAns"].ToString();
                rcbMerQuestion27.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q27_AnyQueMarkedAsYesMER"].ToString();
                if (rcbMerQuestion27.SelectedValue == "1")
                {
                    RemarkGiven.Visible = true;
                }
                else
                {
                    RemarkGiven.Visible = false;
                }
                rcbMerQuestion28.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q28_RemarkGivenAsYes"].ToString();
                rcbMerQuestion29.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q29_VerifiedMER"].ToString();
                rcbMerQuestion30.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q30_ReflexiveTest"].ToString();
                //rcbQuestion2.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q31_TestComponentLIP"].ToString();
                //rcbQuestion2.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q32_TestComponentLFT"].ToString();
                rcbQuestion33.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Q33_WearFaceMask"].ToString();
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Visible = false;
            ImageButton2.Visible = true;
            QCPoints.Visible = true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Visible = true;
            ImageButton2.Visible = false;
            QCPoints.Visible = false;
        }

        protected void btnViewTest_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dtAppointmentDetails = new DataSet();
                Bal BusinessAccessLayer = new Bal();
                dtAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


                if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[0].Rows.Count > 0)
                {
                    lblCorporateId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                    TestList();
                    
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Variables.AppointmentId = 0;
            Response.Redirect("~/Case/AppointmentList.aspx");
            
        }

        protected void rcbQuestion2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(rcbQuestion2.SelectedValue=="2")
            {
                AadhaarMasked.Visible = true;
            }
            else
            {
                AadhaarMasked.Visible = false;
            }
        }

        protected void rcbQuestion6_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(rcbQuestion6.SelectedValue=="2")
            {
                txtQuestion7.Visible = true;
            }
            else
            {
                txtQuestion7.Visible = false;
            }
            
        }

        protected void rcbMerQuestion18_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbMerQuestion18.SelectedValue == "3")
            {
                txtOldApplicationNo19.Visible = true;
            }
            else
            {
                txtOldApplicationNo19.Visible = false;
            }
        }

        protected void rcbMerQuestion23_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbMerQuestion23.SelectedValue == "3")
            {
                txtMerQuestion24.Visible = true;
            }
            else
            {
                txtMerQuestion24.Visible = false;
            }
        }

        protected void rcbMerQuestion27_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(rcbMerQuestion27.SelectedValue=="1")
            {
                RemarkGiven.Visible = true;
            }
            else
            {
                RemarkGiven.Visible = false;
            }
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        //public void SaveCaseRemark()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    //string IsDataExists = "0";
        //    rcbCaseStatus.SelectedValue = "28";
        //    txtComment.Text = txtComment.Text + ", Case Status: " + lblCaseStatus.Text;

        //    BusinessAccessLayer.InsertUpdateCaseRemarkDetails(0, Convert.ToInt32(lblCaseRefId.Text.Trim()), lblCaseId.Text.Trim(), 
        //        txtComment.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));
        //}

        protected void btnSaveReport_Click(object sender, EventArgs e)
        {

            String MedicalTestList = "";
            for (int i = 0; i <= CBL_MedicalTestList.Items.Count - 1; i++)
            {
                if (CBL_MedicalTestList.Items[i].Selected)
                {
                    if (MedicalTestList == "")
                    {
                        MedicalTestList = CBL_MedicalTestList.Items[i].Value;
                    }
                    else
                    {
                        MedicalTestList += "," + CBL_MedicalTestList.Items[i].Value;
                    }
                }
            }
            string LIPTestList = "";
            string LFTTestList = "";
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (Variables.QReportId == 0)
            {
                BusinessAccessLayer.InsertUpdateQCCheckListDetails(0, Convert.ToInt32(lblReportId.Text.Trim()), Convert.ToInt32(lblCaseRefId.Text.Trim()), 
                    Variables.AppointmentId, Convert.ToInt32(rcbQuestion1.SelectedValue), Convert.ToInt32(rcbQuestion2.SelectedValue), rcbQuestion3.Text.Trim(),
                    Convert.ToInt32(rcbQuestion4.SelectedValue), Convert.ToInt32(rcbQuestion5.SelectedValue), Convert.ToInt32(rcbQuestion6.SelectedValue),
                    txtQuestion7.Text.Trim(), Convert.ToInt32(rcbQuestion8.SelectedValue), Convert.ToInt32(rcbQuestion9.SelectedValue),
                    Convert.ToInt32(rcbQuestion10.SelectedValue), Convert.ToInt32(rcbQuestion11.SelectedValue), MedicalTestList, Convert.ToInt32(rcbInterQuestion13.SelectedValue),
                    txtMerDrName14.Text.Trim(), txtMerDrRNo15.Text.Trim(), txtMerDrQualification16.Text.Trim(), Convert.ToInt32(rcbMerQuestion17.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion18.SelectedValue), txtOldApplicationNo19.Text.Trim(), Convert.ToInt32(rcbMerQuestion20.SelectedValue), 
                    Convert.ToInt32(rcbMerQuestion21.SelectedValue), Convert.ToInt32(rcbMerQuestion22.SelectedValue), Convert.ToInt32(rcbMerQuestion23.SelectedValue), 
                    txtMerQuestion24.Text.Trim(), Convert.ToInt32(rcbMerQuestion25.SelectedValue), Convert.ToInt32(rcbMerQuestion26.SelectedValue), 
                    Convert.ToInt32(rcbMerQuestion27.SelectedValue), Convert.ToInt32(rcbMerQuestion28.SelectedValue), Convert.ToInt32(rcbMerQuestion29.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion30.SelectedValue), LIPTestList, LFTTestList, Convert.ToInt32(rcbQuestion33.SelectedValue), txtComment.Text.Trim(), 0, out IsDataExists);

                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Report Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Report Data Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateQCCheckListDetails(Variables.QReportId, Convert.ToInt32(lblReportId.Text.Trim()), Convert.ToInt32(lblCaseRefId.Text.Trim()),
                    Variables.AppointmentId, Convert.ToInt32(rcbQuestion1.SelectedValue), Convert.ToInt32(rcbQuestion2.SelectedValue), rcbQuestion3.Text.Trim(),
                    Convert.ToInt32(rcbQuestion4.SelectedValue), Convert.ToInt32(rcbQuestion5.SelectedValue), Convert.ToInt32(rcbQuestion6.SelectedValue),
                    txtQuestion7.Text.Trim(), Convert.ToInt32(rcbQuestion8.SelectedValue), Convert.ToInt32(rcbQuestion9.SelectedValue),
                    Convert.ToInt32(rcbQuestion10.SelectedValue), Convert.ToInt32(rcbQuestion11.SelectedValue), MedicalTestList, Convert.ToInt32(rcbInterQuestion13.SelectedValue),
                    txtMerDrName14.Text.Trim(), txtMerDrRNo15.Text.Trim(), txtMerDrQualification16.Text.Trim(), Convert.ToInt32(rcbMerQuestion17.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion18.SelectedValue), txtOldApplicationNo19.Text.Trim(), Convert.ToInt32(rcbMerQuestion20.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion21.SelectedValue), Convert.ToInt32(rcbMerQuestion22.SelectedValue), Convert.ToInt32(rcbMerQuestion23.SelectedValue),
                    txtMerQuestion24.Text.Trim(), Convert.ToInt32(rcbMerQuestion25.SelectedValue), Convert.ToInt32(rcbMerQuestion26.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion27.SelectedValue), Convert.ToInt32(rcbMerQuestion28.SelectedValue), Convert.ToInt32(rcbMerQuestion29.SelectedValue),
                    Convert.ToInt32(rcbMerQuestion30.SelectedValue), LIPTestList, LFTTestList, Convert.ToInt32(rcbQuestion33.SelectedValue), txtComment.Text.Trim(),0, out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Report Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Report Data Updated Successfully");

                }
            }
        }

        protected void btnQCSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtComment.Text=="")
                {
                    showPopup("Warning", "Comment should be mandatory.");
                    return;
                }
                else
                {
                    String MedicalTestList = "";
                    for (int i = 0; i <= CBL_MedicalTestList.Items.Count - 1; i++)
                    {
                        if (CBL_MedicalTestList.Items[i].Selected)
                        {
                            if (MedicalTestList == "")
                            {
                                MedicalTestList = CBL_MedicalTestList.Items[i].Value;
                            }
                            else
                            {
                                MedicalTestList += "," + CBL_MedicalTestList.Items[i].Value;
                            }
                        }
                    }
                    string LIPTestList = "";
                    string LFTTestList = "";

                    int CheckedTest = 0;

                    for (int i = 0; i < CBL_MedicalTestList.Items.Count; i++)
                    {
                        if (CBL_MedicalTestList.Items[i].Selected)
                        {
                            CheckedTest = CheckedTest + 1;
                        }
                    }
                    //Test Missing
                    if (CBL_MedicalTestList.Items.Count==CheckedTest)
                    {
                        rcbQCErrorType.SelectedValue = "0";
                        rcbReportStatus.SelectedValue = "3";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "7";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //MER Error
                    if(rcbMerQuestion18.SelectedValue!="0" || rcbMerQuestion18.SelectedValue!="2" || rcbMerQuestion20.SelectedValue!="0" || rcbMerQuestion20.SelectedValue!="2" || rcbMerQuestion21.SelectedValue != "0" || rcbMerQuestion21.SelectedValue!="2" || rcbMerQuestion21.SelectedValue != "3" || rcbMerQuestion22.SelectedValue != "0" || rcbMerQuestion22.SelectedValue!="2" || rcbMerQuestion22.SelectedValue!="3" || rcbMerQuestion23.SelectedValue != "0" || rcbMerQuestion23.SelectedValue!="2" || rcbMerQuestion25.SelectedValue != "0" || rcbMerQuestion25.SelectedValue!="2" || rcbMerQuestion26.SelectedValue != "0" || rcbMerQuestion26.SelectedValue!="2" || rcbMerQuestion28.SelectedValue != "0" || rcbMerQuestion28.SelectedValue!="2" || rcbMerQuestion29.SelectedValue!="0" || rcbMerQuestion29.SelectedValue!="2")
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "1";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //ID Live Photo Error
                    if (rcbQuestion1.SelectedValue != "0" || rcbQuestion1.SelectedValue != "2" || rcbQuestion2.SelectedValue != "0" ||rcbQuestion2.SelectedValue != "7" || rcbQuestion3.Text!="" || rcbQuestion4.SelectedValue != "0" || rcbQuestion4.SelectedValue != "2" || rcbQuestion5.SelectedValue != "0" || rcbQuestion5.SelectedValue != "2" || rcbQuestion5.SelectedValue!="3")
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "2";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //MER/ID-Photo Error
                    if (rcbMerQuestion18.SelectedValue != "0" || rcbMerQuestion18.SelectedValue != "2" || rcbMerQuestion20.SelectedValue != "0" || rcbMerQuestion20.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "0" || rcbMerQuestion21.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "3" || rcbMerQuestion22.SelectedValue != "0" || rcbMerQuestion22.SelectedValue != "2" || rcbMerQuestion22.SelectedValue != "3" || rcbMerQuestion23.SelectedValue != "0" || rcbMerQuestion23.SelectedValue != "2" || rcbMerQuestion25.SelectedValue != "0" || rcbMerQuestion25.SelectedValue != "2" || rcbMerQuestion26.SelectedValue != "0" || rcbMerQuestion26.SelectedValue != "2" || rcbMerQuestion28.SelectedValue != "0" || rcbMerQuestion28.SelectedValue != "2" || rcbMerQuestion29.SelectedValue != "0" || rcbMerQuestion29.SelectedValue != "2" && rcbQuestion1.SelectedValue != "0" || rcbQuestion1.SelectedValue != "2" || rcbQuestion2.SelectedValue != "0" || rcbQuestion2.SelectedValue != "7" || rcbQuestion3.Text != "" || rcbQuestion4.SelectedValue != "0" || rcbQuestion4.SelectedValue != "2" || rcbQuestion5.SelectedValue != "0" || rcbQuestion5.SelectedValue != "2" || rcbQuestion5.SelectedValue != "3")
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "3";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //ID-Photo/Test-Missing Error
                    if (rcbQuestion1.SelectedValue != "0" || rcbQuestion1.SelectedValue != "2" || rcbQuestion2.SelectedValue != "0" || rcbQuestion2.SelectedValue != "7" || rcbQuestion3.Text != "" || rcbQuestion4.SelectedValue != "0" || rcbQuestion4.SelectedValue != "2" || rcbQuestion5.SelectedValue != "0" || rcbQuestion5.SelectedValue != "2" || rcbQuestion5.SelectedValue != "3" && CBL_MedicalTestList.Items.Count == CheckedTest)
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "4";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //MER/Test-Missing Error
                    if (rcbMerQuestion18.SelectedValue != "0" || rcbMerQuestion18.SelectedValue != "2" || rcbMerQuestion20.SelectedValue != "0" || rcbMerQuestion20.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "0" || rcbMerQuestion21.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "3" || rcbMerQuestion22.SelectedValue != "0" || rcbMerQuestion22.SelectedValue != "2" || rcbMerQuestion22.SelectedValue != "3" || rcbMerQuestion23.SelectedValue != "0" || rcbMerQuestion23.SelectedValue != "2" || rcbMerQuestion25.SelectedValue != "0" || rcbMerQuestion25.SelectedValue != "2" || rcbMerQuestion26.SelectedValue != "0" || rcbMerQuestion26.SelectedValue != "2" || rcbMerQuestion28.SelectedValue != "0" || rcbMerQuestion28.SelectedValue != "2" || rcbMerQuestion29.SelectedValue != "0" || rcbMerQuestion29.SelectedValue != "2" && CBL_MedicalTestList.Items.Count == CheckedTest)
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "5";
                        rcbReportStatus.SelectedValue = "4";
                    }
                    //MER/ID-Photo/Test-Missing Error
                    if(rcbMerQuestion18.SelectedValue != "0" || rcbMerQuestion18.SelectedValue != "2" || rcbMerQuestion20.SelectedValue != "0" || rcbMerQuestion20.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "0" || rcbMerQuestion21.SelectedValue != "2" || rcbMerQuestion21.SelectedValue != "3" || rcbMerQuestion22.SelectedValue != "0" || rcbMerQuestion22.SelectedValue != "2" || rcbMerQuestion22.SelectedValue != "3" || rcbMerQuestion23.SelectedValue != "0" || rcbMerQuestion23.SelectedValue != "2" || rcbMerQuestion25.SelectedValue != "0" || rcbMerQuestion25.SelectedValue != "2" || rcbMerQuestion26.SelectedValue != "0" || rcbMerQuestion26.SelectedValue != "2" || rcbMerQuestion28.SelectedValue != "0" || rcbMerQuestion28.SelectedValue != "2" || rcbMerQuestion29.SelectedValue != "0" || rcbMerQuestion29.SelectedValue != "2" && rcbQuestion1.SelectedValue != "0" || rcbQuestion1.SelectedValue != "2" || rcbQuestion2.SelectedValue != "0" || rcbQuestion2.SelectedValue != "7" || rcbQuestion3.Text != "" || rcbQuestion4.SelectedValue != "0" || rcbQuestion4.SelectedValue != "2" || rcbQuestion5.SelectedValue != "0" || rcbQuestion5.SelectedValue != "2" || rcbQuestion5.SelectedValue != "3" && CBL_MedicalTestList.Items.Count == CheckedTest)
                    {
                        rcbQCErrorType.SelectedValue = "0";
                    }
                    else
                    {
                        rcbQCErrorType.SelectedValue = "6";
                        rcbReportStatus.SelectedValue = "4";
                    }

                    
                    Bal BusinessAccessLayer = new Bal();
                    string IsDataExists = "0";
                    if (Variables.QReportId == 0)
                    {
                        BusinessAccessLayer.InsertUpdateQCCheckListDetails(0, Convert.ToInt32(lblReportId.Text.Trim()), Convert.ToInt32(lblCaseRefId.Text.Trim()),
                            Variables.AppointmentId, Convert.ToInt32(rcbQuestion1.SelectedValue), Convert.ToInt32(rcbQuestion2.SelectedValue), rcbQuestion3.Text.Trim(),
                            Convert.ToInt32(rcbQuestion4.SelectedValue), Convert.ToInt32(rcbQuestion5.SelectedValue), Convert.ToInt32(rcbQuestion6.SelectedValue),
                            txtQuestion7.Text.Trim(), Convert.ToInt32(rcbQuestion8.SelectedValue), Convert.ToInt32(rcbQuestion9.SelectedValue),
                            Convert.ToInt32(rcbQuestion10.SelectedValue), Convert.ToInt32(rcbQuestion11.SelectedValue), MedicalTestList, Convert.ToInt32(rcbInterQuestion13.SelectedValue),
                            txtMerDrName14.Text.Trim(), txtMerDrRNo15.Text.Trim(), txtMerDrQualification16.Text.Trim(), Convert.ToInt32(rcbMerQuestion17.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion18.SelectedValue), txtOldApplicationNo19.Text.Trim(), Convert.ToInt32(rcbMerQuestion20.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion21.SelectedValue), Convert.ToInt32(rcbMerQuestion22.SelectedValue), Convert.ToInt32(rcbMerQuestion23.SelectedValue),
                            txtMerQuestion24.Text.Trim(), Convert.ToInt32(rcbMerQuestion25.SelectedValue), Convert.ToInt32(rcbMerQuestion26.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion27.SelectedValue), Convert.ToInt32(rcbMerQuestion28.SelectedValue), Convert.ToInt32(rcbMerQuestion29.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion30.SelectedValue), LIPTestList, LFTTestList, Convert.ToInt32(rcbQuestion33.SelectedValue), txtComment.Text.Trim(), Convert.ToInt32(rcbQCErrorType.SelectedValue), out IsDataExists);

                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Question Data Already Exists");
                        }
                        else
                        {
                            //When Complete Case
                            if (rcbQCErrorType.SelectedValue == "0")
                            {
                                //SaveCaseRemark();

                                BusinessAccessLayer.InsertUpdateCaseDetailsOnCaseCompletion(Convert.ToInt32(lblCaseRefId.Text.Trim()),
                                    Variables.AppointmentId, 28, Convert.ToInt32(rcbReportStatus.SelectedValue), out IsDataExists);
                                showPopup("Warning", "QC Submitted Successfully");
                            }
                            else
                            {
                                showPopup("Warning", "QC Submitted With Error!");
                            }
                        }
                    }
                    else
                    {
                        BusinessAccessLayer.InsertUpdateQCCheckListDetails(Variables.QReportId, Convert.ToInt32(lblReportId.Text.Trim()), Convert.ToInt32(lblCaseRefId.Text.Trim()),
                            Variables.AppointmentId, Convert.ToInt32(rcbQuestion1.SelectedValue), Convert.ToInt32(rcbQuestion2.SelectedValue), rcbQuestion3.Text.Trim(),
                            Convert.ToInt32(rcbQuestion4.SelectedValue), Convert.ToInt32(rcbQuestion5.SelectedValue), Convert.ToInt32(rcbQuestion6.SelectedValue),
                            txtQuestion7.Text.Trim(), Convert.ToInt32(rcbQuestion8.SelectedValue), Convert.ToInt32(rcbQuestion9.SelectedValue),
                            Convert.ToInt32(rcbQuestion10.SelectedValue), Convert.ToInt32(rcbQuestion11.SelectedValue), MedicalTestList, Convert.ToInt32(rcbInterQuestion13.SelectedValue),
                            txtMerDrName14.Text.Trim(), txtMerDrRNo15.Text.Trim(), txtMerDrQualification16.Text.Trim(), Convert.ToInt32(rcbMerQuestion17.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion18.SelectedValue), txtOldApplicationNo19.Text.Trim(), Convert.ToInt32(rcbMerQuestion20.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion21.SelectedValue), Convert.ToInt32(rcbMerQuestion22.SelectedValue), Convert.ToInt32(rcbMerQuestion23.SelectedValue),
                            txtMerQuestion24.Text.Trim(), Convert.ToInt32(rcbMerQuestion25.SelectedValue), Convert.ToInt32(rcbMerQuestion26.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion27.SelectedValue), Convert.ToInt32(rcbMerQuestion28.SelectedValue), Convert.ToInt32(rcbMerQuestion29.SelectedValue),
                            Convert.ToInt32(rcbMerQuestion30.SelectedValue), LIPTestList, LFTTestList, Convert.ToInt32(rcbQuestion33.SelectedValue), txtComment.Text.Trim(), Convert.ToInt32(rcbQCErrorType.SelectedValue), out IsDataExists);
                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Question Data Already Exists");
                        }
                        else
                        {
                            //When Complete Case
                            if (rcbQCErrorType.SelectedValue == "0")
                            {
                                //SaveCaseRemark();

                                BusinessAccessLayer.InsertUpdateCaseDetailsOnCaseCompletion(Convert.ToInt32(lblCaseRefId.Text.Trim()),
                                    Variables.AppointmentId, 28, Convert.ToInt32(rcbReportStatus.SelectedValue), out IsDataExists);
                                showPopup("Warning", "QC Updated Successfully");
                            }
                            else
                            {
                                showPopup("Warning", "QC Updated With Error!");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
    }
}