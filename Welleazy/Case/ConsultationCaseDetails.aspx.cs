using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Welleazy.Case
{
    public partial class ConsultationCaseDetails : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            //string i=  lblModelPopup.Text;

            //  if (i == "1")
            //  {
            //      ModalPopupExtenderLogin.Show();
            //  }

            if (!IsPostBack)
            {
                //if(Variables.ConsultationCaseEdit.Equals(1) && !Variables.MobileNo.Equals(""))
                // {
                // Variables.ConsultaionId = 0;
                // }



                string id = "";

                if (Request.QueryString.AllKeys.Contains("ConsultationCaseId"))
                {
                    id = Request.QueryString["ConsultationCaseId"];
                }


                if (id.Equals(""))
                {
                    Variables.ConsultaionId = 0;
                }



                BranchList();
                LoadMasterLanguage();
                LoadEConsultantType();
                LoadCustomerProfile();
                LoadPaymentType();
                LoadCaseReceivedMode();
                LoadAssignExecutive();




                LoadDoctorDetails();
                //LoadDoctorQualification();
                LoadMasterDocuments();
                LoadState();
                LoadCorporate();
                LoadIDProof();
                LoadGender();
                LoadMasterRelationShip();
                CaseStatusList();
                rgvDependentDetails.DataSource = new object[] { };
                rgvDependentDetails.DataBind();
                rgvConsultantCaseAppointmentDetails.DataSource = new object[] { };
                rgvConsultantCaseAppointmentDetails.DataBind();

                Bal BusinessAccessLayer = new Bal();

                if (Variables.ConsultaionId == 0)
                {
                    GenerateConsultationCaseId();
                    dtpCaseEntryDate.SelectedDate = DateTime.Now;
                    cmbCaseStatus.SelectedValue = "1";
                    cmbCaseStatus.Enabled = false;
                    btnSave.Text = "Save";

                    if (Session["EmployeeRefId"] != null && Session["LoginType"].Equals("2"))
                    {
                        DataTable dtEmployeeDetails = new DataTable();
                        dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Convert.ToInt32(Session["EmployeeRefId"].ToString()));

                        if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                        {
                            txtEmployeeName.Text = dtEmployeeDetails.Rows[0]["EmployeeName"].ToString();

                            cmbCorporateName.SelectedValue = dtEmployeeDetails.Rows[0]["CorporateId"].ToString();
                            cmbCorporateName_SelectedIndexChanged(null, null);
                            cmbCorporateBranchId.SelectedValue = dtEmployeeDetails.Rows[0]["BranchId"].ToString();
                            txtMobileNo.Text = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();

                            txtEmployeeEmailId.Text = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                            cmbGender.SelectedValue = dtEmployeeDetails.Rows[0]["GenderDescription"].ToString();
                            cmbState.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                            cmbState_SelectedIndexChanged(null, null);
                            cmbCity.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                            dtpDOB.DbSelectedDate = dtEmployeeDetails.Rows[0]["DOB"].ToString();
                            string Services = dtEmployeeDetails.Rows[0]["Services"].ToString();

                            LoadServicesBasedUponEmployee(Services);
                            btnSearchEmployeee.Visible = false;
                        }
                    }
                    else
                    {
                        btnSearchEmployeee.Visible = true;
                    }
                }
                else
                {
                    LoadEConsultantCaseDetailsById();
                    LoadConsultationCaseHistoryByCaseId();
                }





            }
        }

        public void LoadAssignExecutive()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAssignExecutiveDetails = new DataTable();
            dtAssignExecutiveDetails = BusinessAccessLayer.LoadAssignExecutive();
            cmbAssignExecutive.Items.Clear();
            cmbAssignExecutive.Items.Add(new RadComboBoxItem("Select Executive", "0"));
            if (dtAssignExecutiveDetails != null && dtAssignExecutiveDetails.Rows.Count > 0)
            {
                cmbAssignExecutive.DataSource = dtAssignExecutiveDetails;
                cmbAssignExecutive.DataTextField = "name";
                cmbAssignExecutive.DataValueField = "user_id";
                cmbAssignExecutive.DataBind();
                cmbAssignExecutive.AppendDataBoundItems = true;


                //cmbAssignExecutive.Items.Insert(0, "Select Executive");
            }

        }

        public void CaseStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseStatus = new DataTable();
            dtCaseStatus = BusinessAccessLayer.LoadCaseStatusList(2);

            if (dtCaseStatus != null && dtCaseStatus.Rows.Count > 0)
            {
                cmbCaseStatus.DataSource = dtCaseStatus;
                cmbCaseStatus.DataTextField = "CaseStatusName";
                cmbCaseStatus.DataValueField = "StatusId";
                cmbCaseStatus.DataBind();
            }


        }

        public void LoadConsultationCaseHistoryByCaseId()
        {
            DataTable dtConsultationCaseHistory = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtConsultationCaseHistory = BusinessAccessLayer.LoadConsultationCaseHistoryByCaseId(Variables.ConsultaionId);

            if (dtConsultationCaseHistory != null && dtConsultationCaseHistory.Rows.Count > 0)
            {
                rgvConsultantCaseAppointmentDetails.DataSource = dtConsultationCaseHistory;
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
            else
            {
                rgvConsultantCaseAppointmentDetails.DataSource = new object[] { };
                rgvConsultantCaseAppointmentDetails.DataBind();
            }
        }

        public void LoadIDProof()
        {
            DataTable dtIDProof = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtIDProof = BusinessAccessLayer.LoadMasterIDProofDocumentDropDown();

            if (dtIDProof != null && dtIDProof.Rows.Count > 0)
            {
                cmbIdProof.DataSource = dtIDProof;
                cmbIdProof.DataTextField = "IDProofDocumentDescription";
                cmbIdProof.DataValueField = "IDProofDocumentId";
                cmbIdProof.DataBind();
            }
        }

        public void LoadGender()
        {
            DataTable dtGenderDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtGenderDetails = BusinessAccessLayer.LoadGenderDropDown();

            if (dtGenderDetails != null && dtGenderDetails.Rows.Count > 0)

            {
                ViewState["Gender"] = dtGenderDetails;
                //cmbIdProof.DataSource = dtGenderDetails;
                //cmbIdProof.DataTextField = "Description";
                //cmbIdProof.DataValueField = "GenderId";
                //cmbIdProof.DataBind();
            }
        }

        public void LoadMasterRelationShip()
        {
            DataTable dtRelationShipDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtRelationShipDetails = BusinessAccessLayer.LoadMasterRelationShipDropDown();

            if (dtRelationShipDetails != null && dtRelationShipDetails.Rows.Count > 0)

            {
                ViewState["RelationShip"] = dtRelationShipDetails;

                cmbCaseFor.DataSource = dtRelationShipDetails;
                cmbCaseFor.DataTextField = "Relationship";
                cmbCaseFor.DataValueField = "RelationshipId";
                cmbCaseFor.DataBind();

                if (Variables.ConsultaionId.Equals(0))
                {

                    List<string> list = new List<string>() { "4", "5", "6", "7", "8" };
                    foreach (var item in list)
                    {
                        RadComboBoxItem items = cmbCaseFor.Items.FindItemByValue(item);
                        if (item != null)
                        {
                            items.Remove();
                        }
                    }
                }

                else
                {
                    List<string> list = new List<string>() { "2", "3" };
                    foreach (var item in list)
                    {
                        RadComboBoxItem items = cmbCaseFor.Items.FindItemByValue(item);
                        if (item != null)
                        {
                            items.Remove();
                        }
                    }
                }



                //cmbCaseFor.Items.Insert(0, "Select Case For");
                // cmbCaseFor.Items.Remove(2);
                //cmbCaseFor.Items.Remove(3);
                //cmbCaseFor.Items.Remove(4);
                //cmbCaseFor.Items.Remove(5);
                //cmbCaseFor.Items.Remove(6);
                //cmbCaseFor.Items.Remove(7);
                //cmbCaseFor.Items.Remove(8);
            }
        }

        public void LoadState()
        {
            DataTable dtState = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                cmbState.DataSource = dtState;
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
            }
        }

        public void LoadDistrict()
        {
            DataTable dtDistrict = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDistrict = BusinessAccessLayer.LoadDistrict();

            if (dtDistrict != null && dtDistrict.Rows.Count > 0)
            {
                cmbCity.DataSource = dtDistrict;
                cmbCity.DataBind();
            }
            else
            {
                cmbCity.DataSource = null;
                cmbCity.DataBind();
            }
        }

        public void LoadEConsultantType()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultantationType = new DataTable();
            dtConsultantationType = BusinessAccessLayer.LoadEConsultantTypeDropDown();

            if (dtConsultantationType != null && dtConsultantationType.Rows.Count > 0)
            {
                ViewState["ConsultationType"] = dtConsultantationType;
                cmbConsultationType.DataSource = dtConsultantationType;
                cmbConsultationType.DataTextField = "ConsultationType";
                cmbConsultationType.DataValueField = "ConsultationTypeId";
                cmbConsultationType.DataBind();
            }
        }

        public void LoadCustomerProfile()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultantationType = new DataTable();
            dtConsultantationType = BusinessAccessLayer.LoadCustomerProfileDropDown();

            if (dtConsultantationType != null && dtConsultantationType.Rows.Count > 0)
            {
                cmbCustomerProfile.DataSource = dtConsultantationType;
                cmbCustomerProfile.DataTextField = "Description";
                cmbCustomerProfile.DataValueField = "CustomerProfileId";
                cmbCustomerProfile.DataBind();
            }
        }

        public void LoadPaymentType()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultantationType = new DataTable();
            dtConsultantationType = BusinessAccessLayer.LoadPaymentTypeDropDown();

            if (dtConsultantationType != null && dtConsultantationType.Rows.Count > 0)
            {
                cmbPaymentType.DataSource = dtConsultantationType;
                cmbPaymentType.DataTextField = "PaymentType";
                cmbPaymentType.DataValueField = "PaymentTypeId";
                cmbPaymentType.DataBind();
            }
        }

        public void LoadCaseReceivedMode()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseMode = new DataTable();
            dtCaseMode = BusinessAccessLayer.LoadCaseReceivedModeDropDown();

            if (dtCaseMode != null && dtCaseMode.Rows.Count > 0)
            {
                cmbCaseMode.DataSource = dtCaseMode;
                cmbCaseMode.DataTextField = "CaseReceivedMode";
                cmbCaseMode.DataValueField = "CaseReceivedModeId";
                cmbCaseMode.DataBind();
            }
        }

        public void GenerateConsultationCaseId()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseId = new DataTable();
            Int32 CaseId = 0;

            dtCaseId = BusinessAccessLayer.GenerateConsultationCaseId();
            if (dtCaseId != null && dtCaseId.Rows.Count > 0)
            {
                CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                if (CaseId <= 9)
                {
                    txtCaseId.Text = "WX000" + CaseId.ToString();
                }

                else if (CaseId > 9 && CaseId < 100)
                {
                    txtCaseId.Text = "WX00" + CaseId.ToString();
                }
                else if (CaseId > 99 && CaseId < 1000)
                {
                    txtCaseId.Text = "WX0" + CaseId.ToString();
                }
                else
                {
                    txtCaseId.Text = "WX" + CaseId.ToString();
                }

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
                ViewState["MasterLanguage"] = dtLanguage;
                cmbCustomerPrefferedLanguage.DataSource = dtLanguage;
                cmbCustomerPrefferedLanguage.DataTextField = "LanguageDescription";
                cmbCustomerPrefferedLanguage.DataValueField = "LanguageId";
                cmbCustomerPrefferedLanguage.DataBind();
            }
            else
            {
                //cmbLanguage.DataSource = null;
                //cmbLanguage.DataBind();

                cmbCustomerPrefferedLanguage.DataSource = null;
                cmbCustomerPrefferedLanguage.DataBind();
            }
        }

        //public void LoadDoctorQualification()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    DataTable dtQualification = new DataTable();
        //    dtQualification = BusinessAccessLayer.LoadDoctorQualificationDropDown();

        //    if (dtQualification != null && dtQualification.Rows.Count > 0)
        //    {
        //        cmbDoctorQualification.DataSource = dtQualification;
        //        cmbDoctorQualification.DataTextField = "Qualification";
        //        cmbDoctorQualification.DataValueField = "DoctorQualificationId";
        //        cmbDoctorQualification.DataBind();

        //    }
        //    else
        //    {
        //        cmbDoctorQualification.DataSource = null;
        //        cmbDoctorQualification.DataBind();


        //    }
        //}



        public void LoadCorporate()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtCorporateDetails;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();
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

        public void LoadMasterDocuments()
        {

        }


        public void LoadEConsultantCaseDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.LoadConsultationCaseDetailsById(Variables.ConsultaionId);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {

                ConsultationType.SelectedValue = dtCaseDetails.Rows[0]["ConsultationCaseTypeId"].ToString();
                ConsultationType_SelectedIndexChanged(null, null);
                txtCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
                dtpCaseEntryDate.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseEntryDateTime"].ToString());
                cmbBranch.SelectedValue = (dtCaseDetails.Rows[0]["BranchId"].ToString());
                cmbAssignExecutive.SelectedValue = (dtCaseDetails.Rows[0]["AssignedExecutiveId"].ToString());
                cmbCaseMode.SelectedValue = (dtCaseDetails.Rows[0]["CaseReceivedMode"].ToString());

                dtpCaseRecordedDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["CaseRecievedDateTime"].ToString());

                cmbCorporateName.SelectedValue = (dtCaseDetails.Rows[0]["CorporateId"].ToString());
                cmbCorporateName_SelectedIndexChanged(null, null);
                cmbCorporateBranchId.SelectedValue = (dtCaseDetails.Rows[0]["CorporateBranchId"].ToString());

                Variables.EmployeeRefId = Convert.ToInt32(dtCaseDetails.Rows[0]["EmployeeRefId"].ToString());

                //Bal BusinessAccessLayer = new Bal();
                DataTable dtEmployeeDetails = new DataTable();
                dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Variables.EmployeeRefId);

                if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                {
                    string Services = dtEmployeeDetails.Rows[0]["Services"].ToString();

                    LoadServicesBasedUponEmployee(Services);
                }

                //string service = dtCaseDetails.Rows[0]["ServicesOffered"].ToString();
                //LoadServicesBasedUponEmployee(service);

                cmbServicesOffered.SelectedValue = (dtCaseDetails.Rows[0]["ServicesOffered"].ToString());

                btnSearchEmployeee.Visible = false;

                txtEmployeeName.Text = dtCaseDetails.Rows[0]["EmployeeName"].ToString();
                txtMobileNo.Text = dtCaseDetails.Rows[0]["MobileNo"].ToString();
                Variables.MobileNo = dtCaseDetails.Rows[0]["MobileNo"].ToString();
                cmbGender.SelectedValue = dtCaseDetails.Rows[0]["GenderId"].ToString();


                txtEmployeeEmailId.Text = dtCaseDetails.Rows[0]["EMailId"].ToString();


                txtNoOfFreeConsultations.Text = dtCaseDetails.Rows[0]["NoOfFreeConsultations"].ToString();
                txtNoOfConsultationRecorded.Text = dtCaseDetails.Rows[0]["NoOfConsultationReceived"].ToString();

                cmbIdProof.SelectedValue = dtCaseDetails.Rows[0]["IdProof"].ToString();
                cmbState.SelectedValue = dtCaseDetails.Rows[0]["State"].ToString();
                cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = dtCaseDetails.Rows[0]["City"].ToString();

                //cmbCustomerPrefferedLanguage.SelectedValue = dtCaseDetails.Rows[0]["CustomerPrefferedLanguage"].ToString();

                string CustomerLanguage = dtCaseDetails.Rows[0]["CustomerPrefferedLanguage"].ToString();


                String[] ServicesValue = CustomerLanguage.Split(',');

                int lenght2 = ServicesValue.Length;

                foreach (string s in ServicesValue)
                {
                    foreach (RadComboBoxItem item in cmbCustomerPrefferedLanguage.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

                dtpDOB.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DOB"].ToString());


                cmbConsultationType.SelectedValue = dtCaseDetails.Rows[0]["ConsultationType"].ToString();
                cmbCaseType.SelectedValue = dtCaseDetails.Rows[0]["CaseType"].ToString();
                cmbPaymentType.SelectedValue = dtCaseDetails.Rows[0]["PaymentType"].ToString();
                cmbPaymentStatus.SelectedValue = dtCaseDetails.Rows[0]["PaymentStatus"].ToString();
                cmbCaseFor.SelectedValue = dtCaseDetails.Rows[0]["CaseFor"].ToString();
                cmbCustomerProfile.SelectedValue = dtCaseDetails.Rows[0]["CustomerProfile"].ToString();

                //cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString();

                string DoctorLanguage = dtCaseDetails.Rows[0]["PrefferedLanguage"].ToString(); ;

                String[] DoctorValue = DoctorLanguage.Split(',');

                // int lenght2 = ServicesValue.Length;

                //foreach (string s in DoctorValue)
                //{
                //    foreach (RadComboBoxItem item in cmbLanguage.Items)//ListItem item in rcbMedicalTest.Items)
                //    {
                //        if (item.Value == s)
                //        {
                //            item.Checked = true;
                //            //item.Selected = true;
                //            break;
                //        }
                //    }
                //}

                //dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                //cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                //cmbDoctorQualification.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

                dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDateTime"].ToString());

                txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

                btnSave.Text = "Update";
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            int NoOfFreeConsultation = 0;
            int NoofConsultationRecorded = 0;

            if (!txtNoOfFreeConsultations.Text.Trim().Equals(""))
            {
                NoOfFreeConsultation = Convert.ToInt32(txtNoOfFreeConsultations.Text.Trim());
            }

            if (!txtNoOfConsultationRecorded.Text.Trim().Equals(""))
            {
                NoofConsultationRecorded = Convert.ToInt32(txtNoOfConsultationRecorded.Text.Trim());
            }

            string ActionPerformed = "";


            if (NoofConsultationRecorded > NoOfFreeConsultation)
            {
                showPopup("Warning", "No. of Consultation Recorded Cannot be greater than No. Of Free Consultation");
                return;
            }


            string CustomerPrefferedLanguage = "";

            for (int i = 0; i < cmbCustomerPrefferedLanguage.CheckedItems.Count; i++)
            {
                if (CustomerPrefferedLanguage == "")
                {
                    CustomerPrefferedLanguage = cmbCustomerPrefferedLanguage.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CustomerPrefferedLanguage += "," + cmbCustomerPrefferedLanguage.CheckedItems[i].Value.Trim();
                }
            }

            string PrefferedLanguage = "";

            //for (int i = 0; i < cmbLanguage.CheckedItems.Count; i++)
            //{
            //    if (PrefferedLanguage == "")
            //    {
            //        PrefferedLanguage = cmbLanguage.CheckedItems[i].Value.Trim();
            //    }
            //    else
            //    {
            //        PrefferedLanguage += "," + cmbLanguage.CheckedItems[i].Value.Trim();
            //    }
            //}

            if (dtpFollowUp.SelectedDate.Value <= dtpCaseEntryDate.SelectedDate.Value)
            {
                showPopup("Warning", "Follow Up Date Should not be Less than Case Entry Date");
                return;
            }



            try
            {
                int DependentTableLength = rgvDependentDetails.Items.Count;

                ActionPerformed = "New Case Added. Case Id :" + txtCaseId.Text.Trim() + " | Case Recorded Time : " + dtpCaseRecordedDateTime.DateInput.SelectedDate.Value
                + " | Welleazy Branch : " + cmbBranch.Text.Trim() + " | Assigned Executive :" + cmbAssignExecutive.Text.Trim() + " | Case Received Mode : " + cmbCaseMode.Text.Trim() + " | Case Received Date Time :" + dtpCaseRecordedDateTime.DateInput.SelectedDate.Value + " | Application No. : " + txtApplicationNo.Text.Trim() + " | Corporate Name : " + cmbCorporateName.Text.Trim() + " | Corporate Branch :" + cmbCorporateBranchId.Text.Trim() + " | Services Offered : " + cmbServicesOffered.Text.Trim() + " | Employee Name :" + txtEmployeeName.Text.Trim() + " | Employee Mobile No. : " + txtMobileNo.Text.Trim() + " | Gender : " + cmbGender.Text.Trim() + " | Employee EmailId : " + txtEmployeeEmailId.Text.Trim() + " | No. of Free Consultations : " + txtNoOfFreeConsultations.Text.Trim() + " | No. of Consultations Recorded : " + txtNoOfConsultationRecorded.Text.Trim() + " | Id Proof : " + cmbIdProof.Text.Trim() + " | State : " + cmbState.Text.Trim() + " | City : " + cmbCity.Text.Trim() + " | Customer Preffered Language : " + cmbCustomerPrefferedLanguage.Text.Trim() + " | Date Of Birth : " + dtpDOB.DateInput.SelectedDate.Value + " | Consultation Type : " + cmbConsultationType.Text.Trim() + " | Case Type : " + cmbCaseType.Text.Trim() + " | Payment Type : " + cmbPaymentType.Text.Trim() + " | Case For : " + cmbCaseFor.Text.Trim() + " | Customer Profile : " + cmbCustomerProfile.Text.Trim() + " | Case Status : " + cmbCaseStatus.Text.Trim() + " | Follow Up Date Time : " + dtpFollowUp.DateInput.SelectedDate.Value + " | Remarks : " + txtRemarks.Text.Trim();


                if (btnSave.Text.Equals("Save"))
                {
                    if (cmbCaseFor.SelectedValue.Equals("1") || cmbCaseFor.SelectedValue.Equals("3"))

                    {
                        if (DependentTableLength < 1 && cmbCaseFor.SelectedValue.Equals("3"))
                        {
                            showPopup("Warning", "Please Add Dependent Details");
                            return;
                        }

                        BusinessAccessLayer.InsertUpdateConsultationCaseDetails(0, Convert.ToInt32(ConsultationType.SelectedValue), txtCaseId.Text.Trim(), Convert.ToInt32(cmbBranch.SelectedValue), dtpCaseEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseEntryDate.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbAssignExecutive.SelectedValue), Convert.ToInt32(cmbCaseMode.SelectedValue), dtpCaseRecordedDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecordedDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue), Convert.ToInt32(cmbServicesOffered.SelectedValue), Variables.EmployeeRefId, txtEmployeeName.Text.Trim(),
                        txtMobileNo.Text.Trim(), Convert.ToInt32(cmbGender.SelectedValue), txtEmployeeEmailId.Text.Trim(), NoOfFreeConsultation, NoofConsultationRecorded, Convert.ToInt32(cmbIdProof.SelectedValue), Convert.ToInt32(cmbState.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), CustomerPrefferedLanguage, dtpDOB.DateInput.SelectedDate.Equals(null) ? nul : dtpDOB.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbConsultationType.SelectedValue)
                        , Convert.ToInt32(cmbCaseType.SelectedValue), Convert.ToInt32(cmbPaymentType.SelectedValue), Convert.ToInt32(cmbPaymentStatus.SelectedValue), //Convert.ToInt32(cmbCaseFor.SelectedValue), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                        1, Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                       //PrefferedLanguage, dtpDoctorDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpDoctorDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbDoctorName.SelectedValue),
                       PrefferedLanguage, nul, 0,
                        1, Convert.ToInt32(cmbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value, txtRemarks.Text.Trim(),
                        Convert.ToInt32(Session["LoginRefId"]), txtApplicationNo.Text.Trim(), ActionPerformed, out IsDataExists);
                    }
                    if (IsDataExists == "1")
                    {
                        //SaveDependentDetails(0);
                        showPopup("Warning", "Data Already Exists");
                    }
                    else
                    {
                        if (cmbCaseFor.SelectedValue.Equals("2") || cmbCaseFor.SelectedValue.Equals("3"))
                        {
                            if (DependentTableLength < 1 && (cmbCaseFor.SelectedValue.Equals("2") || cmbCaseFor.SelectedValue.Equals("3")))
                            {
                                showPopup("Warning", "Please Add Dependent Details");
                                return;
                            }
                            SaveDependentDetails(0);
                        }
                        // showPopup("Warning", "Data Saved Successfully");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Date Saved Successfully');</script>" + "<script>window.location.href='ViewConsultationCaseDetails.aspx';</script>");
                    }




                }
                else
                {
                    BusinessAccessLayer.InsertUpdateConsultationCaseDetails(Variables.ConsultaionId, Convert.ToInt32(ConsultationType.SelectedValue), txtCaseId.Text.Trim(), Convert.ToInt32(cmbBranch.SelectedValue), dtpCaseEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseEntryDate.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbAssignExecutive.SelectedValue), Convert.ToInt32(cmbCaseMode.SelectedValue), dtpCaseRecordedDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecordedDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue), Convert.ToInt32(cmbServicesOffered.SelectedValue), Variables.EmployeeRefId, txtEmployeeName.Text.Trim(),
                        txtMobileNo.Text.Trim(), Convert.ToInt32(cmbGender.SelectedValue), txtEmployeeEmailId.Text.Trim(), NoOfFreeConsultation, NoofConsultationRecorded, Convert.ToInt32(cmbIdProof.SelectedValue), Convert.ToInt32(cmbState.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), CustomerPrefferedLanguage, dtpDOB.DateInput.SelectedDate.Equals(null) ? nul : dtpDOB.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbConsultationType.SelectedValue)
                        , Convert.ToInt32(cmbCaseType.SelectedValue), Convert.ToInt32(cmbPaymentType.SelectedValue), Convert.ToInt32(cmbPaymentStatus.SelectedValue), //Convert.ToInt32(cmbCaseFor.SelectedValue), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                        Convert.ToInt32(cmbCaseFor.SelectedValue), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                        PrefferedLanguage, nul, 0,
                        1, Convert.ToInt32(cmbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value, txtRemarks.Text.Trim(),
                        Convert.ToInt32(Session["LoginRefId"]), txtApplicationNo.Text.Trim(), ActionPerformed, out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Data Already Exists");
                    }
                    else
                    {
                        //showPopup("Warning", "Data Updated Successfully");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Date Updated Successfully');</script>" + "<script>window.location.href='ViewConsultationCaseDetails.aspx';</script>");

                        //showPopup("Warning", "Data Updated Successfully");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('AppointmentList.aspx');</script>");
                    }
                    btnSave.Text = "Save";
                    ClearFields();
                }
                //ClearFields();

                if (Session["RoleId"].ToString().Equals("1"))
                {
                    //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
                }
                else
                {
                    btnSave.Text = "Save";
                    ClearFields();
                    GenerateConsultationCaseId();
                    Variables.ConsultaionId = 0;
                    //LoadDoctorDetails();
                    //SpecialistConultantView.ActiveViewIndex = 0;
                    //LoadSpecialityConsultantCaseDetails();
                    //rgvDependentDetails.DataSource = new object[] { };
                    //rgvDependentDetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void SaveDependentDetails(int Id)


        {

            Bal BusinessAccessLayer = new Bal();
            int DependentTableLength = rgvDependentDetails.Items.Count;

            foreach (GridDataItem item in rgvDependentDetails.MasterTableView.Items)
            {

                Bal Business_Access_Layer = new Bal();
                DataTable dtCaseId = new DataTable();
                Int32 CaseId = 0;
                string CaseID = "";

                dtCaseId = BusinessAccessLayer.GenerateConsultationCaseId();
                if (dtCaseId != null && dtCaseId.Rows.Count > 0)
                {
                    CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                    if (CaseId <= 9)
                    {
                        CaseID = "WX000" + CaseId.ToString();
                    }

                    else if (CaseId > 9 && CaseId < 100)
                    {
                        CaseID = "WX00" + CaseId.ToString();
                    }
                    else if (CaseId > 99 && CaseId < 1000)
                    {
                        CaseID = "WX0" + CaseId.ToString();
                    }
                    else
                    {
                        CaseID = "WX" + CaseId.ToString();
                    }

                }


                string DependentName = (item.FindControl("lblDependentName") as Label).Text;
                string lblDateOfBirth = (item.FindControl("lblDateOfBirth") as Label).Text;

                string lblFollowUpDateTime = (item.FindControl("lblFollowUpDateTime") as Label).Text;

                DateTime DOB = new DateTime();
                DOB = Convert.ToDateTime(lblDateOfBirth);

                DateTime FollowUpDate = new DateTime();
                FollowUpDate = Convert.ToDateTime(lblFollowUpDateTime);

                string lblMobileNo = (item.FindControl("lblMobileNo") as Label).Text;
                string lblEmailId = (item.FindControl("lblEmailId") as Label).Text;

                string lblDependentGenderId = (item.FindControl("lblDependentGenderId") as Label).Text;
                string lblDependentGenderValue = (item.FindControl("lblDependentGender") as Label).Text;
                string lblDependentRelationShipId = (item.FindControl("lblDependentRelationShipId") as Label).Text;
                string lblDependentRelationShipIdValue = (item.FindControl("lblDependentRelationShip") as Label).Text;
                string lblDependentConsultationTypeId = (item.FindControl("lblDependentConsultationTypeId") as Label).Text;
                string lblDependentConsultationTypeValue = (item.FindControl("lblDependentConsultationType") as Label).Text;
                string lblDependentCaseTypeId = (item.FindControl("lblDependentCaseTypeId") as Label).Text;
                string lblDependentCaseTypeValue = (item.FindControl("lblDependentCaseType") as Label).Text;
                string lblDependentPrefferedLanguageId = (item.FindControl("lblDependentPrefferedLanguageId") as Label).Text;
                string lblDependentPrefferedLanguageValue = (item.FindControl("lblDependentPrefferedLanguage") as Label).Text;
                string lblRemarks = (item.FindControl("lblRemarks") as Label).Text;

                string ActionPerformed = "";

                ActionPerformed = "New Case Added. Case Id :" + txtCaseId.Text.Trim() + " | Case Recorded Time : " + dtpCaseRecordedDateTime.DateInput.SelectedDate.Value
                + " | Welleazy Branch : " + cmbBranch.Text.Trim() + " | Assigned Executive :" + cmbAssignExecutive.Text.Trim() + " | Case Received Mode : " + cmbCaseMode.Text.Trim() + " | Case Received Date Time :" + dtpCaseRecordedDateTime.DateInput.SelectedDate.Value + " | Application No. : " + txtApplicationNo.Text.Trim() + " | Corporate Name : " + cmbCorporateName.Text.Trim() + " | Corporate Branch :" + cmbCorporateBranchId.Text.Trim() + " | Services Offered : " + cmbServicesOffered.Text.Trim() + " | Employee Name :" + txtEmployeeName.Text.Trim() + " | Employee Mobile No. : " + lblMobileNo.Trim() + " | Gender : " + lblDependentGenderValue.Trim() + " | Employee EmailId : " + lblEmailId.Trim() + " | No. of Free Consultations : " + txtNoOfFreeConsultations.Text.Trim() + " | No. of Consultations Recorded : " + txtNoOfConsultationRecorded.Text.Trim() + " | Id Proof : " + cmbIdProof.Text.Trim() + " | State : " + cmbState.Text.Trim() + " | City : " + cmbCity.Text.Trim() + " | Customer Preffered Language : " + lblDependentPrefferedLanguageValue.Trim() + " | Date Of Birth : " + lblDateOfBirth.Trim() + " | Consultation Type : " + lblDependentConsultationTypeValue.Trim() + " | Case Type : " + lblDependentCaseTypeValue.Trim() + " | Payment Type : " + cmbPaymentType.Text.Trim() + " | Case For : " + lblDependentRelationShipIdValue.Trim() + " | Customer Profile : " + cmbCustomerProfile.Text.Trim() + " | Case Status : " + cmbCaseStatus.Text.Trim() + " | Follow Up Date Time : " + dtpFollowUp.DateInput.SelectedDate.Value + " | Remarks : " + lblRemarks.Trim();


                string IsDataExists = "";
                BusinessAccessLayer.InsertUpdateConsultationCaseDetails(Id, Convert.ToInt32(ConsultationType.SelectedValue),
                    CaseID, Convert.ToInt32(cmbBranch.SelectedValue),
                    dtpCaseEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseEntryDate.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbAssignExecutive.SelectedValue), Convert.ToInt32(cmbCaseMode.SelectedValue),
                        dtpCaseRecordedDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecordedDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(cmbCorporateName.SelectedValue),
                        Convert.ToInt32(cmbCorporateBranchId.SelectedValue), Convert.ToInt32(cmbServicesOffered.SelectedValue), Variables.EmployeeRefId, DependentName,
                        txtMobileNo.Text.Trim(), Convert.ToInt32(lblDependentGenderId), lblEmailId, 0, 0, Convert.ToInt32(cmbIdProof.SelectedValue),
                        Convert.ToInt32(cmbState.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue),
                        lblDependentPrefferedLanguageId.Trim(), DOB.Equals(null) ? nul : DOB,
                        Convert.ToInt32(lblDependentConsultationTypeId)
                        , Convert.ToInt32(lblDependentCaseTypeId),
                        Convert.ToInt32(cmbPaymentType.SelectedValue), Convert.ToInt32(cmbPaymentStatus.SelectedValue),
                        Convert.ToInt32(lblDependentRelationShipId), Convert.ToInt32(cmbCustomerProfile.SelectedValue),
                       //PrefferedLanguage, dtpDoctorDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpDoctorDateTime.DateInput.SelectedDate.Value, Convert.ToInt32(cmbDoctorName.SelectedValue),
                       "", nul, 0,
                        1, Convert.ToInt32(cmbCaseStatus.SelectedValue),
                        FollowUpDate.Equals(null) ? nul : FollowUpDate, lblRemarks,
                        1, txtApplicationNo.Text.Trim(), ActionPerformed, out IsDataExists);

                BusinessAccessLayer.InsertUpdateConsultationCaseDependentDetails(CaseID, Variables.EmployeeRefId, Convert.ToInt32(lblDependentRelationShipId), DependentName, DOB, lblMobileNo, lblEmailId, Convert.ToInt32(lblDependentGenderId), Convert.ToInt32(lblDependentConsultationTypeId), Convert.ToInt32(lblDependentCaseTypeId), lblDependentPrefferedLanguageId);


            }


        }

        public void ClearFields()
        {
            cmbAssignExecutive.SelectedValue = "0";
            cmbBranch.SelectedValue = "0";
            cmbCorporateName.SelectedValue = "0";
            cmbCorporateBranchId.SelectedValue = "0";
            cmbServicesOffered.SelectedValue = "0";
            cmbCaseMode.SelectedValue = "0";

            cmbState.SelectedValue = "0";
            cmbCity.SelectedValue = "0";
            cmbIdProof.SelectedValue = "0";
            cmbCustomerPrefferedLanguage.SelectedValue = "0";

            //cmbCity.Items.Clear();

            //dtpCaseEntryDate.DateInput.Text = "";
            //dtpCaseRecordedDateTime.DateInput.SelectedDate = null;
            dtpFollowUp.DateInput.Text = "";
            //dtpDoctorDateTime.DateInput.Text = "";
            dtpDOB.DateInput.Text = "";

            cmbCorporateBranchId.SelectedValue = "0";
            cmbServicesOffered.SelectedValue = "0";
            cmbBranch.SelectedValue = "0";
            txtMobileNo.Text = "";

            cmbCustomerPrefferedLanguage.SelectedValue = "0";
            cmbAssignExecutive.SelectedValue = "0";



            txtEmployeeName.Text = "";
            txtEmployeeEmailId.Text = "";
            cmbGender.SelectedValue = "0";
            txtNoOfFreeConsultations.Text = "";
            txtNoOfConsultationRecorded.Text = "";
            cmbConsultationType.SelectedValue = "0";
            cmbCaseType.SelectedValue = "0";
            cmbPaymentType.SelectedValue = "0";
            cmbCaseFor.SelectedValue = "0";
            cmbCustomerProfile.SelectedValue = "0";
            //cmbLanguage.SelectedValue = "0";
            //cmbDoctorName.SelectedValue = "0";
            //cmbDoctorQualification.SelectedValue = "0";
            cmbCaseStatus.SelectedValue = "0";
            dtpFollowUp.DateInput.Text = "";
            txtRemarks.Text = "";

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.ConsultaionId = 0;
            Response.Redirect("~/Case/ViewConsultationCaseDetails.aspx");
        }

        protected void cmbState_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(cmbState.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    cmbCity.DataSource = dtCity;
                    cmbCity.DataTextField = "DistrictName";
                    cmbCity.DataValueField = "DistrictId";
                    cmbCity.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rgvSearchEmployeeDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvSearchEmployeeDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvSearchEmployeeDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "EditRow")
                {
                    cmbGender.AppendDataBoundItems = true;
                    Label lblEmployeeRefId = (Label)rgvSearchEmployeeDetails.Items[intIndex % 10].FindControl("lblEmployeeRefId"); // % 15 for page indexing
                    Variables.EmployeeRefId = Convert.ToInt32(lblEmployeeRefId.Text.Trim());

                    Bal BusinessAccessLayer = new Bal();
                    DataTable dtEmployeeDetails = new DataTable();
                    dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Variables.EmployeeRefId);

                    if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                    {
                        txtEmployeeName.Text = dtEmployeeDetails.Rows[0]["EmployeeName"].ToString();
                        txtMobileNo.Text = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();
                        txtEmployeeEmailId.Text = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                        cmbGender.SelectedValue = dtEmployeeDetails.Rows[0]["GenderDescription"].ToString();
                        cmbState.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                        cmbState_SelectedIndexChanged(null, null);
                        cmbCity.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                        dtpDOB.DbSelectedDate = dtEmployeeDetails.Rows[0]["DOB"].ToString();
                        string Services = dtEmployeeDetails.Rows[0]["Services"].ToString();

                        LoadServicesBasedUponEmployee(Services);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LoadServicesBasedUponEmployee(string Services)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtServices = new DataTable();
            dtServices = BusinessAccessLayer.LoadServicesForEmployee(Services);
            cmbServicesOffered.Items.Clear();
            if (dtServices != null && dtServices.Rows.Count > 0)

            {
                cmbServicesOffered.DataSource = dtServices;
                cmbServicesOffered.DataValueField = "SubProductId";
                cmbServicesOffered.DataTextField = "SubProductCategory";
                cmbServicesOffered.DataBind();

                cmbServicesOffered.Items.Insert(0, "Select Services");
            }

        }

        protected void cmbCorporateName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DataTable dtEmployeeDetails = new DataTable();
            //Bal BusinessAccessLayer = new Bal();
            //dtEmployeeDetails = BusinessAccessLayer.FetchEmployeeDetailsOnCorporateId(Convert.ToInt32(cmbCorporateName.SelectedValue));

            //if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)

            //{
            //    rgvSearchEmployeeDetails.DataSource = dtEmployeeDetails;
            //    rgvSearchEmployeeDetails.DataBind();
            //}
            //else
            //{
            //    rgvSearchEmployeeDetails.DataSource = new object[] { }; ;
            //    rgvSearchEmployeeDetails.DataBind();
            //}

            LoadCorporateBranchList();
        }

        public void LoadCorporateBranchList()
        {

            cmbCorporateBranchId.Items.Clear();
            //cmbCorporateBranchId.Items.Insert(0, "Select Branch Id");
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

            cmbCorporateBranchId.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Branch Id"));
        }

        protected void btnSearchEmployeee_Click(object sender, ImageClickEventArgs e)
        {
            //ShowSearchPopup();
            //Response.Write("search");
            ModalPopupExtenderLogin.Show();
            cmbCorporateName_SelectedIndexChanged(null, null);
            //Variables.ModalPopUp = 1;
        }

        //private void ShowSearchPopup()
        //{
        //    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        //    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowSearchPopup()", true);
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Response.Write("hello");
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEmployeeDetails = BusinessAccessLayer.SearchEmployeeDetails(txtSearchEmployeeName.Text.Trim(), txtSearchMobileNo.Text.Trim());

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            {
                rgvSearchEmployeeDetails.DataSource = dtEmployeeDetails;
                rgvSearchEmployeeDetails.DataBind();
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowSearchPopup()", true);
            }
            else
            {
                rgvSearchEmployeeDetails.DataSource = null;
                rgvSearchEmployeeDetails.DataBind();
            }
        }

        protected void SearchEmployee_Click(object sender, EventArgs e)
        {
            Response.Write(txtSearchEmployeeName.Text.Trim());

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowSearchPopup()", true);
        }


        protected void txtSearchEmployeeName_TextChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowSearchPopup()", true);
            txtSearchMobileNo.Text = "";
            txtSearchEmployeeId.Text = "";
        }

        protected void txtSearchMobileNo_TextChanged(object sender, EventArgs e)
        {
            txtSearchEmployeeName.Text = "";
            txtSearchEmployeeId.Text = "";
        }

        protected void txtSearchEmployeeId_TextChanged(object sender, EventArgs e)
        {
            txtSearchEmployeeName.Text = "";
            txtSearchMobileNo.Text = "";
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            //Response.Write("Close");
            //lblModelPopup.Text = "0";
            ModalPopupExtenderLogin.Hide();
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string ConditionQuery = "";
            string Query = "";
            string MainQuery = "";

            if (txtSearchEmployeeName.Text == "" && txtSearchMobileNo.Text == "" && txtSearchEmployeeId.Text == "")
            {
                SearchEmployeeDetailsList();
                return;
            }
            else
            {
                MainQuery = "select EmployeeRefId, EmployeeId, FirstName, LastName, EmployeeName, ED.Address, ED.Emailid, ED.MobileNo, Gender, DOB," +
                                "ED.State, ED.City, Area, Landmark, Pincode, GeoLocation, ED.CorporateId, MCD.CorporateName, ED.BranchId, CBD.Branch, AccountActivationURL, ED.CreatedOn, ED.CreatedBy," +
                                "ModifiedOn, ModifiedBy, LastActiveDate, LastInactiveDate, InActiveReason," +
                                " Case when ED.IsActive = 1 then 'True' Else 'False' End as IsActive from dbo.EmployeeDetails ED" +
                                " left join Master_CorporateDetails MCD on MCD.CorporateId = ED.CorporateId" +
                                " left join CorporateBranchDetails CBD on CBD.BranchDetailsId = ED.BranchId" +
                                " left join Master_State MS on MS.StateId = ED.State" +
                                " left join Master_District MD on MD.DistrictId = ED.City";
                ConditionQuery = " and ED.CorporateId = '" + cmbCorporateName.SelectedValue + "' and ED.BranchId = '" + cmbCorporateBranchId.SelectedValue + "'";
            }


            if (txtSearchEmployeeName.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeName like '%" + txtSearchEmployeeName.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And EmployeeName like '%" + txtSearchEmployeeName.Text.Trim() + "%'";
                }
            }


            if (txtSearchMobileNo.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.MobileNo like '%" + txtSearchMobileNo.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ED.MobileNo like '%" + txtSearchMobileNo.Text.Trim() + "%'";
                }
            }

            if (txtSearchEmployeeId.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeId like '%" + txtSearchEmployeeId.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And EmployeeId like '%" + txtSearchEmployeeId.Text.Trim() + "%'";
                }
            }


            Bal BusinessAccessLayer = new Bal();
            DataTable dtEmployeeDetails = new DataTable();
            dtEmployeeDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            {
                rgvSearchEmployeeDetails.DataSource = dtEmployeeDetails;
                rgvSearchEmployeeDetails.DataBind();
            }
            else
            {
                rgvSearchEmployeeDetails.DataSource = new object[] { };
                rgvSearchEmployeeDetails.DataBind();
            }


            ModalPopupExtenderLogin.Show();

        }

        protected void ConsultationType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //LoadServices();
        }

        //public void CorporateBProductList()
        //{
        //    //ProductList();
        //    DataSet dtStateDetails = new DataSet();
        //    Bal BusinessAccessLayer = new Bal();
        //    dtStateDetails = BusinessAccessLayer.LoadBProductListById(Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue));


        //    if (dtStateDetails != null && dtStateDetails.Tables[0].Rows.Count > 0)
        //    {
        //        Session["CorporatesubCategoryDetails"] = dtStateDetails.Tables[1];
        //        rcbProduct.DataSource = dtStateDetails.Tables[0];
        //        rcbProduct.DataTextField = "ProductName";
        //        rcbProduct.DataValueField = "ProductId";
        //        rcbProduct.DataBind();
        //    }
        //    //else
        //    //{

        //    //    rcbProduct.SelectedValue = "0";
        //    //    //rcbProduct.DataValueField=null;
        //    //}

        //}

        public void LoadServicesByCorporateBranchId()
        {
            DataSet dtStateDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadBProductListById(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue));


            if (dtStateDetails != null && dtStateDetails.Tables[0].Rows.Count > 0)
            {
                Session["CorporatesubCategoryDetails"] = dtStateDetails.Tables[1];
                cmbServicesOffered.DataSource = dtStateDetails.Tables[0];
                cmbServicesOffered.DataTextField = "ProductName";
                cmbServicesOffered.DataValueField = "ProductId";
                cmbServicesOffered.DataBind();
            }
        }

        public void LoadServices()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCaseServices = new DataTable();
            dtConsultationCaseServices = BusinessAccessLayer.LoadConsultationCaseServices(Convert.ToInt32(ConsultationType.SelectedValue));

            if (dtConsultationCaseServices != null && dtConsultationCaseServices.Rows.Count > 0)
            {
                cmbServicesOffered.DataSource = dtConsultationCaseServices;
                cmbServicesOffered.DataTextField = "SubProductCategory";
                cmbServicesOffered.DataValueField = "SubProductId";
                cmbServicesOffered.DataBind();
            }
        }

        protected void cmbLanguage_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                //string LanguageId = "";

                //for (int i = 0; i < cmbLanguage.CheckedItems.Count; i++)
                //{
                //    if (LanguageId == "")
                //    {
                //        LanguageId = cmbLanguage.CheckedItems[i].Value.Trim();
                //    }
                //    else
                //    {
                //        LanguageId += "," + cmbLanguage.CheckedItems[i].Value.Trim();
                //    }
                //}

                //cmbDoctorName.Items.Clear();

                //DataTable dtDoctorDetails = new DataTable();
                //Bal BusinessAccessLayer = new Bal();
                //dtDoctorDetails = BusinessAccessLayer.LoadDoctorSearchByLanguage(LanguageId);
                //if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
                //{
                //    cmbDoctorName.DataSource = dtDoctorDetails;
                //    cmbDoctorName.DataTextField = "DoctorName";
                //    cmbDoctorName.DataValueField = "DoctorId";
                //    cmbDoctorName.DataBind();
                //}

                //cmbDoctorName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Doctor"));
                //cmbDoctorName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbCustomerPrefferedLanguage_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //try
            // {
            //   string LanguageId = "";

            //    for (int i = 0; i < cmbCustomerPrefferedLanguage.CheckedItems.Count; i++)
            //    {
            //        if (LanguageId == "")
            //        {
            //            LanguageId = cmbCustomerPrefferedLanguage.CheckedItems[i].Value.Trim();
            //        }
            //        else
            //        {
            //            LanguageId += "," + cmbCustomerPrefferedLanguage.CheckedItems[i].Value.Trim();
            //        }
            //    }

            //    //cmbLanguage.Items.Clear();

            //    Bal BusinessAccessLayer = new Bal();
            //    DataTable dtLanguage = new DataTable();
            //    dtLanguage = BusinessAccessLayer.LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(LanguageId);

            //    if (dtLanguage != null && dtLanguage.Rows.Count > 0)
            //    {
            //        cmbLanguage.DataSource = dtLanguage;
            //        cmbLanguage.DataTextField = "LanguageDescription";
            //        cmbLanguage.DataValueField = "LanguageId";
            //        cmbLanguage.DataBind();


            //    }
            //    else
            //    {
            //        cmbLanguage.DataSource = null;
            //        cmbLanguage.DataBind();


            //    }

            //    cmbLanguage.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Language"));
            //    cmbLanguage.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{

            //}
        }

        protected void rgvDependentDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                int rownumber;
                if (e.CommandName == "AddDependentDetails")
                {
                    DataTable DtDependentDetails = new DataTable();
                    if (Session["DependentDetails"] == null || (Session["DependentDetails"] as DataTable).Rows.Count <= 0)
                    {
                        DtDependentDetails.Columns.Add("rownumber");
                        DtDependentDetails.Columns.Add("DependentName");
                        DtDependentDetails.Columns.Add("DateOfBirth");
                        DtDependentDetails.Columns.Add("MobileNo");
                        DtDependentDetails.Columns.Add("EmailId");

                        DtDependentDetails.Columns.Add("DependentGender");
                        DtDependentDetails.Columns.Add("DependentGenderId");
                        DtDependentDetails.Columns.Add("RelationShip");
                        DtDependentDetails.Columns.Add("RelationShipId");
                        DtDependentDetails.Columns.Add("ConsultationType");
                        DtDependentDetails.Columns.Add("ConsultationTypeId");

                        DtDependentDetails.Columns.Add("CaseType");
                        DtDependentDetails.Columns.Add("CaseTypeId");
                        DtDependentDetails.Columns.Add("PrefferedLanguage");
                        DtDependentDetails.Columns.Add("PrefferedLanguageId");
                        DtDependentDetails.Columns.Add("FollowUpDateTime");
                        DtDependentDetails.Columns.Add("Remarks");

                        rownumber = 1;
                    }
                    else
                    {
                        DtDependentDetails = Session["DependentDetails"] as DataTable;
                        rownumber = (Convert.ToInt16(DtDependentDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    GridFooterItem item = (GridFooterItem)e.Item;
                    RadTextBox txtDependentName = (RadTextBox)item.FindControl("txtDependentName");
                    RadDateTimePicker dtpDependentDOB = (RadDateTimePicker)item.FindControl("dtpDependentDOB");

                    RadTextBox txtMobileNo = (RadTextBox)item.FindControl("txtMobileNo");
                    RadTextBox txtEmailId = (RadTextBox)item.FindControl("txtEmailId");

                    RadComboBox cmbDependentGender = (RadComboBox)item.FindControl("cmbDependentGender");
                    //Label DependentGenderId = (Label)item.FindControl("lblDependentGenderId");
                    RadComboBox cmbDependentRelationShip = (RadComboBox)item.FindControl("cmbDependentRelationShip");
                    //Label cmbDependentRelationShipId = (Label)item.FindControl("lblDependentRelationShipId");
                    RadComboBox cmbDependentConsultationType = (RadComboBox)item.FindControl("cmbDependentConsultationType");
                    //Label cmbDependentConsultationTypeId = (Label)item.FindControl("lblDependentConsultationTypeId");
                    RadComboBox cmbDependentCaseType = (RadComboBox)item.FindControl("cmbDependentCaseType");
                    //Label cmbDependentCaseTypeId = (Label)item.FindControl("lblDependentCaseTypeId");
                    RadComboBox cmbDependentPrefferedLanguage = (RadComboBox)item.FindControl("cmbDependentPrefferedLanguage");
                    //Label cmbDependentPrefferedLanguageId = (Label)item.FindControl("lblDependentPrefferedLanguageId");

                    RadDateTimePicker dtpDependentFollowUpDatetime = (RadDateTimePicker)item.FindControl("dtpDependentFollowUpDatetime");
                    RadTextBox txtDependentRemarks = (RadTextBox)item.FindControl("txtDependentRemarks");

                    string CustomerPrefferedLanguage = "";

                    for (int i = 0; i < cmbDependentPrefferedLanguage.CheckedItems.Count; i++)
                    {
                        if (CustomerPrefferedLanguage == "")
                        {
                            CustomerPrefferedLanguage = cmbDependentPrefferedLanguage.CheckedItems[i].Value.Trim();
                        }
                        else
                        {
                            CustomerPrefferedLanguage += "," + cmbDependentPrefferedLanguage.CheckedItems[i].Value.Trim();
                        }
                    }


                    if (DtDependentDetails != null && DtDependentDetails.Rows.Count > 0)
                    {
                        rownumber = (Convert.ToInt16(DtDependentDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    else
                    {
                        rownumber = 1;
                    }
                    bool ifExist = false;
                    foreach (DataRow dr in DtDependentDetails.Rows)
                    {
                        if (dr["DependentName"].ToString().ToUpper() == txtDependentName.Text.Trim().ToUpper()
                            && dr["MobileNo"].ToString().ToUpper() == txtMobileNo.Text.Trim().ToUpper()
                            && dr["EmailId"].ToString().ToUpper() == txtEmailId.Text.Trim().ToUpper())
                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        DtDependentDetails.Rows.Add(rownumber, txtDependentName.Text.Trim(), dtpDependentDOB.DateInput.SelectedDate, txtMobileNo.Text.Trim(), txtEmailId.Text.Trim(),
                            cmbDependentGender.Text, cmbDependentGender.SelectedValue, cmbDependentRelationShip.Text, cmbDependentRelationShip.SelectedValue, cmbDependentConsultationType.Text, cmbDependentConsultationType.SelectedValue, cmbDependentCaseType.Text, cmbDependentCaseType.SelectedValue, cmbDependentPrefferedLanguage.Text, CustomerPrefferedLanguage,
                            dtpDependentFollowUpDatetime.DateInput.SelectedDate, txtDependentRemarks.Text.Trim());
                        Session["DependentDetails"] = DtDependentDetails;
                        rgvDependentDetails.DataSource = Session["DependentDetails"] as DataTable;
                        rgvDependentDetails.DataBind();
                    }
                }


                if (e.CommandName == "DeleteDependentDetails")
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblrownumber = (Label)rgvDependentDetails.Items[intIndex].FindControl("lblrownumber");
                    //Label lblnewrows = (Label)rgvDependentDetails.Items[intIndex].FindControl("lblnewrows");
                    //Label lblContactDetailsID = (Label)rgvDependentDetails.Items[intIndex].FindControl("lblContactDetailsID");

                    //DataView DtAdditionalDetails = new DataView(Session["ElectiveSubject"] as DataTable);
                    DataTable DtAdditionalDetails = Session["DependentDetails"] as DataTable;
                    if (Session["DependentDetails"] != null)
                    {
                        if (Convert.ToInt16(lblrownumber.Text.Trim()) != 0)
                        {
                            DataRow[] dtRow = null;
                            dtRow = DtAdditionalDetails.Select("rownumber=" + lblrownumber.Text.Trim());
                            DtAdditionalDetails.Rows.Remove(dtRow[0]);
                            DtAdditionalDetails.AcceptChanges();
                            Session["DependentDetails"] = DtAdditionalDetails;
                        }
                        else
                        {
                            //int facultyid = Convert.ToInt32(hfFacultyID.Value);
                            DataSet dsDependentDetails = new DataSet();
                            //FacultyModule ObjMasterModule = new FacultyModule();
                            //dsAdditionalDetails = ObjMasterModule.fnDeleteAdditionalrecords(Convert.ToInt64(lblFacultyTrainingDetailsID.Text), facultyid);
                            if (dsDependentDetails.Tables[0] != null && dsDependentDetails.Tables[0].Rows.Count > 0)
                            {
                                Session["DependentDetails"] = dsDependentDetails.Tables[0];
                                rgvDependentDetails.DataSource = Session["rgvDependentDetails"] as DataTable;
                                rgvDependentDetails.DataBind();
                            }
                        }
                    }
                    if (Session["DependentDetails"] != null && (Session["DependentDetails"] as DataTable).Rows.Count > 0)
                    {
                        rgvDependentDetails.DataSource = Session["DependentDetails"] as DataTable;
                        rgvDependentDetails.DataBind();
                    }
                    else
                    {
                        rgvDependentDetails.DataSource = string.Empty;
                        rgvDependentDetails.DataBind();
                        rgvDependentDetails.DataSource = Session["DependentDetails"] as DataTable;
                        rgvDependentDetails.DataBind();
                        rgvDependentDetails.ShowFooter = true;
                    }
                }
            }


            catch (Exception ex)
            {

            }
        }

        protected void rgvDependentDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvDependentDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridFooterItem)
                {
                    GridFooterItem item = (GridFooterItem)e.Item;

                    RadComboBox cmbDependentGender = (item.FindControl("cmbDependentGender") as RadComboBox);
                    RadComboBox cmbDependentRelationShip = (item.FindControl("cmbDependentRelationShip") as RadComboBox);
                    RadComboBox cmbDependentConsultationType = (item.FindControl("cmbDependentConsultationType") as RadComboBox);
                    RadComboBox cmbDependentPrefferedLanguage = (item.FindControl("cmbDependentPrefferedLanguage") as RadComboBox);

                    cmbDependentGender.DataSource = ViewState["Gender"];
                    cmbDependentGender.DataTextField = "Description";
                    cmbDependentGender.DataValueField = "GenderId";
                    cmbDependentGender.DataBind();

                    cmbDependentRelationShip.DataSource = ViewState["RelationShip"];
                    cmbDependentRelationShip.DataTextField = "Relationship";
                    cmbDependentRelationShip.DataValueField = "RelationshipId";
                    cmbDependentRelationShip.DataBind();

                    List<string> list = new List<string>() { "1", "2", "3" };
                    foreach (var RelationShipId in list)
                    {
                        RadComboBoxItem items = cmbDependentRelationShip.Items.FindItemByValue(RelationShipId);
                        if (items != null)
                        {
                            items.Remove();
                        }
                    }



                    cmbDependentConsultationType.DataSource = ViewState["ConsultationType"];
                    cmbDependentConsultationType.DataTextField = "ConsultationType";
                    cmbDependentConsultationType.DataValueField = "ConsultationTypeId";
                    cmbDependentConsultationType.DataBind();

                    cmbDependentPrefferedLanguage.DataSource = ViewState["MasterLanguage"];
                    cmbDependentPrefferedLanguage.DataTextField = "LanguageDescription";
                    cmbDependentPrefferedLanguage.DataValueField = "LanguageId";
                    cmbDependentPrefferedLanguage.DataBind();
                    //ViewState[""]
                    //ViewState["ConsultationType"]
                    //ViewState["MasterLanguage"];
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void cmbCaseFor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbCaseFor.SelectedValue.Equals("2") || cmbCaseFor.SelectedValue.Equals("3"))
            {
                DependentDetails.Visible = true;
            }
            else
            {
                DependentDetails.Visible = false;
            }
        }

        protected void cmbCorporateBranchId_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SearchEmployeeDetailsList();
        }

        public void SearchEmployeeDetailsList()
        {
            DataTable dtEmployeeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtEmployeeDetails = BusinessAccessLayer.FetchEmployeeDetailsOnCorporateId(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue));

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)

            {
                rgvSearchEmployeeDetails.DataSource = dtEmployeeDetails;
                rgvSearchEmployeeDetails.DataBind();
            }
            else
            {
                rgvSearchEmployeeDetails.DataSource = new object[] { }; ;
                rgvSearchEmployeeDetails.DataBind();
            }
        }


    }
}