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
    public partial class AddCase : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        DataTable dt1 = new DataTable();
        static string ServicesAssigned = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                int caseid = Variables.CaseRefId;
                if (Variables.CaseRefId != 0)
                {
                    CorporateList();
                    LoadAssignExecutive();
                    BranchList();
                    TestList();
                    StateList();
                    GenericTestList();
                    CaseStatusList();
                    RelationshipList();
                    LoadMasterRelationShip();
                    LoadCustomerProfile();

                    LoadCaseDetailsById();

                    txt_CaseEntryDate.Text = Convert.ToDateTime(txt_CaseEntryDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
                    //txt_CaseRecDateTime.Text = Convert.ToDateTime(txt_CaseRecDateTime.Text).ToString("yyyy-MM-dd HH:mm:ss");
                    //rgCaseDependentDetails.DataSource = new object[] { };
                    //rgCaseDependentDetails.DataBind();
                    AddDependent.Visible = true;
                    btnSave.Text = "Update";
                    ImgAddDependent.Visible = false;
                    ImgUpdateDependent.Visible = false;
                    rcbCaseStatus.Enabled = true;
                }
                else
                {
                    GenerateCaseId();
                    GenericTestList();
                    CaseStatusList();
                    RelationshipList();
                    LoadMasterRelationShip();
                    LoadCustomerProfile();
                    txt_CaseEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //txt_CaseRecDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    CorporateList();
                    LoadAssignExecutive();
                    BranchList();
                    TestList();
                    StateList();
                    txtPaybleAmount.Text = "0.00";
                    //TestList();

                    DataTable dt = new DataTable();
                    if (ViewState["Records"] == null)
                    {
                        dt.Columns.Add("CaseId");
                        dt.Columns.Add("Case For");
                        dt.Columns.Add("Dependent Name");
                        dt.Columns.Add("Mobile No");
                        dt.Columns.Add("Gender");
                        dt.Columns.Add("Date Of Birth");
                        dt.Columns.Add("Address");
                        dt.Columns.Add("Medical Test");
                        ViewState["Records"] = dt;
                    }

                    //Session["AdditionalDetails"] = null;

                    //rgCaseDependentDetails.DataSource = new object[] { };
                    //rgCaseDependentDetails.DataBind();
                    btnSave.Text = "Save";
                    ImgAddDependent.Visible = true;
                    ImgUpdateDependent.Visible = false;
                    rcbCaseStatus.SelectedValue = "1";
                    rcbCaseStatus.Enabled = true;

                    Bal BusinessAccessLayer = new Bal();

                    if (Variables.CaseRefId == 0)
                    {

                        if (Session["EmployeeRefId"] != null && Session["LoginType"].Equals("2"))
                        {
                            DataTable dtEmployeeDetails = new DataTable();
                            dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Convert.ToInt32(Session["EmployeeRefId"].ToString()));

                            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                            {
                                Variables.EmployeeRefId = Convert.ToInt32(dtEmployeeDetails.Rows[0]["EmployeeRefId"].ToString());
                                txt_EmployeeName.Text = dtEmployeeDetails.Rows[0]["EmployeeName"].ToString();
                                txt_EmployeeId.Text = dtEmployeeDetails.Rows[0]["EmployeeId"].ToString();
                                txt_EmployeeAreaLocality.Text = dtEmployeeDetails.Rows[0]["Area"].ToString();
                                txt_EmployeeLandmark.Text = dtEmployeeDetails.Rows[0]["Landmark"].ToString();
                                txt_EmployeePincode.Text = dtEmployeeDetails.Rows[0]["Pincode"].ToString();
                                txt_EmployeeGeolocation.Text = dtEmployeeDetails.Rows[0]["GeoLocation"].ToString();
                                txt_EmployeeAddress.Text = dtEmployeeDetails.Rows[0]["Address"].ToString();
                                DDL_CorporateName.SelectedValue = dtEmployeeDetails.Rows[0]["CorporateId"].ToString();
                                DDL_CorporateName_SelectedIndexChanged(null, null);
                                rcbBranchId.SelectedValue = dtEmployeeDetails.Rows[0]["BranchId"].ToString();
                                txt_EmployeeMobileNo.Text = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();
                                txt_EmployeeEmail.Text = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                                rcbGender.SelectedValue = dtEmployeeDetails.Rows[0]["GenderDescription"].ToString();
                                DDL_State.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                                DDL_State_SelectedIndexChanged(null, null);
                                DDL_City.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                                rdpEmployeeDOB.DbSelectedDate = dtEmployeeDetails.Rows[0]["DOB"].ToString();
                                string ServicesAssigned = dtEmployeeDetails.Rows[0]["Services"].ToString();
                                string ProductId = dtEmployeeDetails.Rows[0]["ProductId"].ToString();

                                LoadProductListForEmployee(ProductId, ServicesAssigned);
                                //LoadServicesBasedUponEmployee(Services);
                                btnSearchEmployeee.Visible = false;

                            }
                        }
                        else
                        {
                            btnSearchEmployeee.Visible = true;
                        }
                    }
                }

                if (Session["LoginType"].Equals("2"))
                {
                    DDL_CorporateName.Enabled = false;
                    rcbBranchId.Enabled = false;
                    btnSearchEmployeee.Visible = false;
                    rcbCaseStatus.Enabled = false;
                }
                else if (Session["LoginType"].Equals("1"))
                {
                    Variables.CorporateId = Convert.ToInt32(Session["CorporateId"].ToString());

                    DataSet dtCorporateDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsById(Variables.CorporateId);


                    if (dtCorporateDetails != null && dtCorporateDetails.Tables[0].Rows.Count > 0)
                    {
                        DDL_CorporateName.SelectedValue = dtCorporateDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        DDL_CorporateName.Enabled = false;
                        TestList();
                        CorporateBranchList();
                    }
                }
            }
        }

        public void LoadAssignExecutive()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAssignExecutiveDetails = new DataTable();
            dtAssignExecutiveDetails = BusinessAccessLayer.LoadAssignExecutive();
            rcbAssignExecutive.Items.Clear();
            if (dtAssignExecutiveDetails != null && dtAssignExecutiveDetails.Rows.Count > 0)
            {
                rcbAssignExecutive.DataSource = dtAssignExecutiveDetails;
                rcbAssignExecutive.DataTextField = "name";
                rcbAssignExecutive.DataValueField = "user_id";
                rcbAssignExecutive.DataBind();

                rcbAssignExecutive.Items.Insert(0, "Select Executive");
            }

        }

        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                DDL_State.DataSource = dtState;
                DDL_State.DataTextField = "StateName";
                DDL_State.DataValueField = "StateId";
                DDL_State.DataBind();
            }

            
        }
        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                DDL_CorporateName.DataSource = dtLoadCorporateList;
                DDL_CorporateName.DataTextField = "CorporateName";
                DDL_CorporateName.DataValueField = "CorporateId";
                DDL_CorporateName.DataBind();

            }
            else
            {
                DDL_CorporateName.DataSource = null;
                DDL_CorporateName.DataBind();
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

        public void PackageList()
        {
            rcbMedicalTest.Items.Clear();
            rcbMedicalTest.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_FetchPackageDetails", con);
            
            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                RadComboBox1.Attributes.Add("Test Package", "True");
                RadComboBox1.DataSource = dtFetchServiveProviderDetails;
                RadComboBox1.DataTextField = "PackageName";
                RadComboBox1.DataValueField = "PackageId";
                RadComboBox1.DataBind();

            }
        }
        public void TestList()
        {
            
            rcbMedicalTest.Items.Clear();
            rcbMedicalTest.AppendDataBoundItems = true;

            rcbDMedicalTest.Items.Clear();
            rcbDMedicalTest.AppendDataBoundItems = true;

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadTestListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "TestList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", DDL_CorporateName.SelectedValue.Trim());

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

                rcbDMedicalTest.DataSource = dtFetchServiveProviderDetails;
                rcbDMedicalTest.DataTextField = "TestName";
                rcbDMedicalTest.DataValueField = "TestId";
                rcbDMedicalTest.DataBind();

                //RadComboBox1.DataSource = dtFetchServiveProviderDetails;
                //RadComboBox1.DataTextField = "TestName";
                //RadComboBox1.DataValueField = "TestId";                
                //RadComboBox1.DataBind();

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

                rcbcasefor.DataSource = dtRelationShipDetails;
                rcbcasefor.DataTextField = "Relationship";
                rcbcasefor.DataValueField = "RelationshipId";
                rcbcasefor.DataBind();

                if (Variables.CaseRefId.Equals(0))
                {

                    List<string> list = new List<string>() { "4", "5", "6", "7", "8" };
                    foreach (var item in list)
                    {
                        RadComboBoxItem items = rcbcasefor.Items.FindItemByValue(item);
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
                        RadComboBoxItem items = rcbcasefor.Items.FindItemByValue(item);
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

        public void RelationshipList()
        {
            DataTable dtLoadRelationshipList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadRelationshipList = BusinessAccessLayer.LoadMasterRelationShipDropDown();

            if (dtLoadRelationshipList != null && dtLoadRelationshipList.Rows.Count > 0)
            {
                rcbDCaseFor.DataSource = dtLoadRelationshipList;
                rcbDCaseFor.DataTextField = "Relationship";
                rcbDCaseFor.DataValueField = "RelationshipId";
                rcbDCaseFor.DataBind();

                List<string> list = new List<string>() { "1", "2", "3" };
                foreach (var RelationShipId in list)
                {
                    RadComboBoxItem items = rcbDCaseFor.Items.FindItemByValue(RelationShipId);
                    if (items != null)
                    {
                        items.Remove();
                    }
                }

            }
            else
            {
                rcbDCaseFor.DataSource = null;
                rcbDCaseFor.DataBind();
            }
        }

        public void CorporateBranchList()
        {
            rcbBranchId.Items.Clear();
            rcbBranchId.Items.Insert(0,"Select Branch Id");
            rcbBranchId.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadBranchListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "BranchList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", DDL_CorporateName.SelectedValue.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                rcbBranchId.DataSource = dtFetchServiveProviderDetails;
                rcbBranchId.DataTextField = "Branch";
                rcbBranchId.DataValueField = "BranchDetailsId";
                rcbBranchId.DataBind();
            }
        }

        public void LoadProductListForEmployee(string ProductId, string ServicesAssigned)
        {
            rcbProduct.Items.Clear();
            rcbProduct.Items.Insert(0, "Select Product");
            rcbProduct.AppendDataBoundItems = true;

            Bal BusinessAccessLayer = new Bal();
            DataSet dtProductDetails = new DataSet();
            dtProductDetails = BusinessAccessLayer.LoadProductListForEmployee(ProductId, ServicesAssigned);


            if (dtProductDetails != null && dtProductDetails.Tables[0].Rows.Count > 0)
            {
                Session["CorporatesubCategoryDetails"] = dtProductDetails.Tables[1];
                rcbProduct.DataSource = dtProductDetails;
                rcbProduct.DataTextField = "ProductName";
                rcbProduct.DataValueField = "ProductId";
                rcbProduct.DataBind();
            }

        }

        //public void CorporateBProductList()
        //{
        //    //ProductList();
        //    rcbProduct.Items.Clear();
        //    rcbProduct.Items.Insert(0, "Select Product");
        //    rcbProduct.AppendDataBoundItems = true;
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
        public void ProductList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtProduct = new DataTable();
            dtProduct = BusinessAccessLayer.LoadProductDetailsDropDown();

            if (dtProduct != null && dtProduct.Rows.Count > 0)
            {
                rcbProduct.DataSource = dtProduct;
                rcbProduct.DataTextField = "ProductName";
                rcbProduct.DataValueField = "ProductId";
                rcbProduct.DataBind();

            }


        }
        public void GenerateCaseId()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseId = new DataTable();
            Int32 CaseId = 0;

            dtCaseId = BusinessAccessLayer.GenerateCaseId();
            if (dtCaseId != null && dtCaseId.Rows.Count > 0)
            {
                CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                if (CaseId <= 9)
                {
                    txt_CaseId.Text = "WX0000" + CaseId.ToString();
                }

                else if (CaseId > 9 && CaseId < 100)
                {
                    txt_CaseId.Text = "WX000" + CaseId.ToString();
                }
                else if (CaseId > 99 && CaseId < 1000)
                {
                    txt_CaseId.Text = "WX00" + CaseId.ToString();
                }
                else if (CaseId > 999 && CaseId < 10000)
                {
                    txt_CaseId.Text = "WX0" + CaseId.ToString();
                }
                else
                {
                    txt_CaseId.Text = "WX" + CaseId.ToString();
                }

                txt_DCaseId.Text = txt_CaseId.Text;
            }
        }

        public void GenericTestList()
        {
            DataTable dtLoadGenericTestList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadGenericTestList = BusinessAccessLayer.LoadGenericTestDetails();

            if (dtLoadGenericTestList != null && dtLoadGenericTestList.Rows.Count > 0)
            {
                rcbGenericTest.DataSource = dtLoadGenericTestList;
                rcbGenericTest.DataTextField = "TestName";
                rcbGenericTest.DataValueField = "GenericTestId";
                rcbGenericTest.DataBind();

            }
            else
            {
                rcbGenericTest.DataSource = null;
                rcbGenericTest.DataBind();
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

        public void LoadCustomerProfile()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultantationType = new DataTable();
            dtConsultantationType = BusinessAccessLayer.LoadCustomerProfileDropDown();

            if (dtConsultantationType != null && dtConsultantationType.Rows.Count > 0)
            {
                rcbCustomerProfile.DataSource = dtConsultantationType;
                rcbCustomerProfile.DataTextField = "Description";
                rcbCustomerProfile.DataValueField = "CustomerProfileId";
                rcbCustomerProfile.DataBind();
            }
        }

        public void LoadDependentCaseDetailsById()
        {
            DataTable dtDCaseDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDCaseDetails = BusinessAccessLayer.LoadDependentCaseDetailsById(txt_EmployeeId.Text, txt_CaseId.Text);


            if (dtDCaseDetails != null && dtDCaseDetails.Rows.Count > 0)
            {
                lblDependentId.Text = dtDCaseDetails.Rows[0]["DependentId"].ToString();
                txt_DCaseId.Text = dtDCaseDetails.Rows[0]["CaseId"].ToString();
                rcbDCaseFor.SelectedValue = dtDCaseDetails.Rows[0]["CaseFor"].ToString();
                txt_DepName.Text = dtDCaseDetails.Rows[0]["DependentName"].ToString();
                txt_DepMobileNo.Text = dtDCaseDetails.Rows[0]["DependentMobileNo"].ToString();
                rcbDepGender.SelectedItem.Text = dtDCaseDetails.Rows[0]["DependentGender"].ToString();
                rdpDepDOB.DbSelectedDate = dtDCaseDetails.Rows[0]["DependentDOB"].ToString();
                txt_DepAddress.Text = dtDCaseDetails.Rows[0]["DependentAddress"].ToString();

                string MedicalTest = dtDCaseDetails.Rows[0]["MedicalTest"].ToString();

                String[] MedicalTestValue = MedicalTest.Split(',');

                int lenght = MedicalTestValue.Length;

                foreach (string s in MedicalTestValue)
                {
                    foreach (RadComboBoxItem item in rcbDMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
            }
            
        }

        public void LoadCaseDetailsById()
        {
            DataSet dtCaseDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtCaseDetails = BusinessAccessLayer.LoadCaseDetailsById(Variables.CaseRefId);


            if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";
                ImgAddDependent.Visible = false;
                ImgUpdateDependent.Visible = false;
                rcbCaseStatus.Enabled = true;
                txt_CaseId.Text = dtCaseDetails.Tables[0].Rows[0]["CaseId"].ToString();
                txt_CaseEntryDate.Text = dtCaseDetails.Tables[0].Rows[0]["CaseEntryDatetime"].ToString();
                rcbBranch.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["WelleazyBranch"].ToString();
                rcbAssignExecutive.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["AssignedExecutive"].ToString();
                rcbCaseMode.SelectedItem.Text = dtCaseDetails.Tables[0].Rows[0]["CaseRecMode"].ToString();
                dtpCaseRecDateTime.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["CaseRecDatetime"].ToString();
                DDL_CorporateName.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                TestList();
                CorporateBranchList();
                rcbBranchId.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["BranchId"].ToString();
                //ProductList();

                //ServicesAssigned = dtCaseDetails.Tables[0].Rows[0]["ServicesOffered"].ToString();
                //string ProductId = dtCaseDetails.Tables[0].Rows[0]["ProductId"].ToString();

                //LoadProductListForEmployee(ProductId, ServicesAssigned);

                
                //ProductId = rcbProduct.SelectedValue;
                //ProductServices();
                //rcbServicesOffered.SelectedItem.Text = dtCaseDetails.Tables[0].Rows[0]["ServicesOffered"].ToString();
                //string Services = dtCaseDetails.Tables[0].Rows[0]["ServicesOffered"].ToString();

                Variables.EmployeeRefId = Convert.ToInt32(dtCaseDetails.Tables[0].Rows[0]["EmployeeRefId"].ToString());

                //Bal BusinessAccessLayer = new Bal();
                DataTable dtEmployeeDetails = new DataTable();
                dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Variables.EmployeeRefId);

                if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                {
                    string Services = dtEmployeeDetails.Rows[0]["Services"].ToString();
                    string ProductId = dtEmployeeDetails.Rows[0]["ProductId"].ToString();

                    LoadServicesBasedUponEmployee(Services);
                    LoadProductListForEmployee(ProductId, Services);
                }

                //string service = dtCaseDetails.Rows[0]["ServicesOffered"].ToString();
                //LoadServicesBasedUponEmployee(service);
                rcbProduct.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["ProductId"].ToString();
                ServicesAssigned = dtCaseDetails.Tables[0].Rows[0]["ServicesOffered"].ToString();

                String[] ServicesValue = ServicesAssigned.Split(',');

                int lenght2 = ServicesValue.Length;

                foreach (string s in ServicesValue)
                {
                    foreach (RadComboBoxItem item in rcbServicesOffered.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
                
                //LoadProductListForEmployee(ProductId, Services);
                //ProductServices();

                txt_EmployeeMobileNo.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeMobileNo"].ToString();
                txt_EmployeeName.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                rcbGender.SelectedItem.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeGender"].ToString();
                txt_EmployeeId.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeId"].ToString();
                txt_EmployeeEmail.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeEmail"].ToString();
                DDL_State.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["EmployeeState"].ToString();
                DDL_State_SelectedIndexChanged(null, null);
                DDL_City.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["EmployeeCity"].ToString();
                txt_EmployeeAreaLocality.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeArea"].ToString();
                txt_EmployeeLandmark.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeLandmark"].ToString();
                txt_EmployeePincode.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeePincode"].ToString();
                txt_EmployeeAddress.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeAddress"].ToString();
                txt_EmployeeGeolocation.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeGeoLocation"].ToString();
                rdpEmployeeDOB.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["EmployeeDOB"].ToString();

                LoadDependentCaseDetailsById();

                string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
                String[] MedicalTestValue = MedicalTest.Split(',');

                int lenght = MedicalTestValue.Length;

                foreach (string s in MedicalTestValue)
                {
                    foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
                txt_ApplicationNo.Text = dtCaseDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                rcbCaseType.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CaseType"].ToString();
                rcbPaymentType.SelectedItem.Text = dtCaseDetails.Tables[0].Rows[0]["PaymentType"].ToString();
                rcbcasefor.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CaseFor"].ToString();
                rcbCustomerProfile.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CustomerProfile"].ToString();

                string GenericTest = dtCaseDetails.Tables[0].Rows[0]["GenericTest"].ToString();
                String[] GenericTestValue = GenericTest.Split(',');

                int lenght3 = GenericTestValue.Length;

                foreach (string s in GenericTestValue)
                {
                    foreach (RadComboBoxItem item in rcbGenericTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
                txtPaybleAmount.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeToPay"].ToString();
                rcbDHOCPayment.SelectedItem.Text = dtCaseDetails.Tables[0].Rows[0]["DHOCAdvancePayment"].ToString();
                rcbCaseStatus.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                dtpFollowUp.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["SchFollowupdate"].ToString();
                txt_Remark.Text = dtCaseDetails.Tables[0].Rows[0]["SchRemark"].ToString();

                if (dtCaseDetails.Tables[0].Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }

            //if (dtCaseDetails != null && dtCaseDetails.Tables[1].Rows.Count > 0)
            //{
            //    rgCaseDependentDetails.DataSource = dtCaseDetails.Tables[1];
            //    rgCaseDependentDetails.DataBind();
            //    //Changes Done hide the session line
            //    Session["AdditionalDetails"] = dtCaseDetails.Tables[1];
            //}
            //else
            //{
            //    rgCaseDependentDetails.DataSource = null;
            //    rgCaseDependentDetails.DataBind();
            //    //Changes Done
            //    //rgCorporateContactDetails.DataSource = new object[] { };
            //    //rgCorporateContactDetails.DataBind();
            //}

          
        }

        public void LoadGenericTestAmount()
        {
            string GenericTest = "";
            for (int i = 0; i < rcbGenericTest.CheckedItems.Count; i++)
            {
                if (GenericTest == "")
                {
                    GenericTest = rcbGenericTest.CheckedItems[i].Value.Trim();
                }
                else
                {
                    GenericTest += "," + rcbGenericTest.CheckedItems[i].Value.Trim();
                }
            }

            int Profile = Convert.ToInt32(rcbCustomerProfile.SelectedValue);
            DataTable dtCaseDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCaseDetails = BusinessAccessLayer.LoadGenericTestAmount(GenericTest, Profile);


            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                txtPaybleAmount.Text = dtCaseDetails.Rows[0]["Amount"].ToString();
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //DataTable dtCaseDetails = new DataTable();
            //dtCaseDetails = Session["AdditionalDetails"] as DataTable;

            //if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            //{

            //    if (dtCaseDetails.Columns.Contains("rownumber"))
            //    {
            //        dtCaseDetails.Columns.Remove("rownumber");
            //    }

            //    if (dtCaseDetails.Columns.Contains("DependentId"))
            //    {
            //        dtCaseDetails.Columns.Remove("DependentId");
            //    }

            //    if (dtCaseDetails.Columns.Contains("newrow"))
            //    {
            //        dtCaseDetails.Columns.Remove("newrow");
            //    }
            //}

            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            string MedicalTest = "";

            for(int i = 0; i < rcbMedicalTest.CheckedItems.Count; i++)
            {
                if (MedicalTest == "")
                {
                    MedicalTest = rcbMedicalTest.CheckedItems[i].Value.Trim();
                }
                else
                {
                    MedicalTest += "," + rcbMedicalTest.CheckedItems[i].Value.Trim();
                }
            }

            string GenericTest = "";

            for (int i = 0; i < rcbGenericTest.CheckedItems.Count; i++)
            {
                if (GenericTest == "")
                {
                    GenericTest = rcbGenericTest.CheckedItems[i].Value.Trim();
                }
                else
                {
                    GenericTest += "," + rcbGenericTest.CheckedItems[i].Value.Trim();
                }
            }

            string Services = "";

            for (int i = 0; i < rcbServicesOffered.CheckedItems.Count; i++)
            {
                if (Services == "")
                {
                    Services = rcbServicesOffered.CheckedItems[i].Value.Trim();
                }
                else
                {
                    Services += "," + rcbServicesOffered.CheckedItems[i].Value.Trim();
                }
            }

            try
            {
                int DependentTableLength = rgDependentGrid.Rows.Count;

                if (btnSave.Text.Equals("Save"))
                {
                    if (rcbcasefor.SelectedValue.Equals("1") || rcbcasefor.SelectedValue.Equals("3"))
                    {
                        if (DependentTableLength < 1 && rcbcasefor.SelectedValue.Equals("3"))
                        {
                            showPopup("Warning", "Please Add Dependent Details for Add Case");
                            return;
                        }
                        //Convert.ToInt32(rcbcasefor.SelectedValue)=1
                        BusinessAccessLayer.InsertUpdateCaseDetails(0, txt_CaseId.Text.Trim(), txt_CaseEntryDate.Text.Trim(), Convert.ToInt32(rcbBranch.SelectedValue),
                            Convert.ToInt32(rcbAssignExecutive.SelectedValue), rcbCaseMode.SelectedItem.Text.Trim(),
                            dtpCaseRecDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecDateTime.DateInput.SelectedDate.Value,
                            Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue), Convert.ToInt32(rcbProduct.SelectedValue), Services,
                            txt_EmployeeMobileNo.Text.Trim(), txt_EmployeeName.Text.Trim(), rcbGender.SelectedItem.Text.Trim(), Variables.EmployeeRefId, txt_EmployeeId.Text.Trim(),
                            txt_EmployeeEmail.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue), txt_EmployeeAreaLocality.Text.Trim(),
                            txt_EmployeeLandmark.Text.Trim(), txt_EmployeePincode.Text.Trim(), txt_EmployeeAddress.Text.Trim(), txt_EmployeeGeolocation.Text.Trim(),
                            rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                            MedicalTest, txt_ApplicationNo.Text.Trim(), Convert.ToInt32(rcbCaseType.SelectedValue), rcbPaymentType.SelectedItem.Text.Trim(),
                            1, Convert.ToInt32(rcbCustomerProfile.SelectedValue), GenericTest, txtPaybleAmount.Text.Trim(),
                            rcbDHOCPayment.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value,
                            txt_Remark.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                            //SaveCaseRemark();
                    }
                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Case Already Exists");
                        }
                        else
                        {
                            if (rcbcasefor.SelectedValue.Equals("2") || rcbcasefor.SelectedValue.Equals("3"))
                            {
                                if (DependentTableLength < 1 && (rcbcasefor.SelectedValue.Equals("2") || rcbcasefor.SelectedValue.Equals("3")))
                                {
                                    showPopup("Warning", "Please Add Dependent Details");
                                    return;
                                }
                                SaveDependentDetails(0);
                                
                            }
                            showPopup("Warning", "Case Saved Successfully");
                            ClearFields();
                            Variables.CaseRefId = 0;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Case.aspx');</script>");
                        }
                    }
                    else
                    {
                        if (rcbcasefor.SelectedValue.Equals("1"))
                        {
                            BusinessAccessLayer.InsertUpdateCaseDetails(Variables.CaseRefId, txt_CaseId.Text.Trim(), txt_CaseEntryDate.Text.Trim(), Convert.ToInt32(rcbBranch.SelectedValue),
                            Convert.ToInt32(rcbAssignExecutive.SelectedValue), rcbCaseMode.SelectedItem.Text.Trim(),
                            dtpCaseRecDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecDateTime.DateInput.SelectedDate.Value,
                            Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue), Convert.ToInt32(rcbProduct.SelectedValue), Services,
                            txt_EmployeeMobileNo.Text.Trim(), txt_EmployeeName.Text.Trim(), rcbGender.SelectedItem.Text.Trim(), Variables.EmployeeRefId, txt_EmployeeId.Text.Trim(),
                            txt_EmployeeEmail.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue), txt_EmployeeAreaLocality.Text.Trim(),
                            txt_EmployeeLandmark.Text.Trim(), txt_EmployeePincode.Text.Trim(), txt_EmployeeAddress.Text.Trim(), txt_EmployeeGeolocation.Text.Trim(),
                            rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                            MedicalTest, txt_ApplicationNo.Text.Trim(), Convert.ToInt32(rcbCaseType.SelectedValue), rcbPaymentType.SelectedItem.Text.Trim(),
                            Convert.ToInt32(rcbcasefor.SelectedValue), Convert.ToInt32(rcbCustomerProfile.SelectedValue), GenericTest, txtPaybleAmount.Text.Trim(),
                            rcbDHOCPayment.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value,
                            txt_Remark.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                            //SaveCaseRemark();

                            if (IsDataExists == "1")
                            {
                                showPopup("Warning", "Case Already Exists");
                            }
                            else
                            {
                                showPopup("Warning", "Case Updated Successfully");
                                ClearFields();
                                Variables.CaseRefId = 0;
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Case.aspx');</script>");
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Case Updated Successfully');</script>" + "<script>window.location.href='Case.aspx';</script>");
                            }

                            btnSave.Text = "Save";
                            ImgAddDependent.Visible = true;
                            ImgUpdateDependent.Visible = false;
                            ClearFields();
                        }
                        else
                        {


                        string DMedicalTest = "";

                        for (int i = 0; i < rcbDMedicalTest.CheckedItems.Count; i++)
                        {
                            if (DMedicalTest == "")
                            {
                                DMedicalTest = rcbDMedicalTest.CheckedItems[i].Value.Trim();
                            }
                            else
                            {
                                DMedicalTest += "," + rcbDMedicalTest.CheckedItems[i].Value.Trim();
                            }
                        }

                        
                        Bal DependentBusinessAccessLayer = new Bal();

                        string IsDataExistsD = "0";

                        //DataTable dtCaseId = new DataTable();
                        //Int32 CaseId = 0;

                        //dtCaseId = BusinessAccessLayer.GenerateCaseId();
                        //if (dtCaseId != null && dtCaseId.Rows.Count > 0)
                        //{
                        //    CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                        //    if (CaseId <= 9)
                        //    {
                        //        txt_CaseId.Text = "WX0000" + CaseId.ToString();
                        //    }

                        //    else if (CaseId > 9 && CaseId < 100)
                        //    {
                        //        txt_CaseId.Text = "WX000" + CaseId.ToString();
                        //    }
                        //    else if (CaseId > 99 && CaseId < 1000)
                        //    {
                        //        txt_CaseId.Text = "WX00" + CaseId.ToString();
                        //    }
                        //    else if (CaseId > 999 && CaseId < 10000)
                        //    {
                        //        txt_CaseId.Text = "WX0" + CaseId.ToString();
                        //    }
                        //    else
                        //    {
                        //        txt_CaseId.Text = "WX" + CaseId.ToString();
                        //    }

                        //}



                        BusinessAccessLayer.InsertUpdateCaseDetails(Variables.CaseRefId, txt_CaseId.Text.Trim(), txt_CaseEntryDate.Text.Trim(), Convert.ToInt32(rcbBranch.SelectedValue),
                    Convert.ToInt32(rcbAssignExecutive.SelectedValue), rcbCaseMode.SelectedItem.Text.Trim(),
                    dtpCaseRecDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecDateTime.DateInput.SelectedDate.Value,
                    Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue), Convert.ToInt32(rcbProduct.SelectedValue), Services,
                    txt_EmployeeMobileNo.Text.Trim(), txt_EmployeeName.Text.Trim(), rcbGender.SelectedItem.Text.Trim(), Variables.EmployeeRefId, txt_EmployeeId.Text.Trim(),
                    txt_EmployeeEmail.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue), txt_EmployeeAreaLocality.Text.Trim(),
                    txt_EmployeeLandmark.Text.Trim(), txt_EmployeePincode.Text.Trim(), txt_EmployeeAddress.Text.Trim(), txt_EmployeeGeolocation.Text.Trim(),
                    rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                    DMedicalTest, txt_ApplicationNo.Text.Trim(), Convert.ToInt32(rcbCaseType.SelectedValue), rcbPaymentType.SelectedItem.Text.Trim(),
                    Convert.ToInt32(rcbcasefor.SelectedValue), Convert.ToInt32(rcbCustomerProfile.SelectedValue), GenericTest, txtPaybleAmount.Text.Trim(),
                    rcbDHOCPayment.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value,
                    txt_Remark.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                        DependentBusinessAccessLayer.InsertUpdateDependentCaseDetails(Convert.ToInt32(lblDependentId.Text.Trim()), txt_EmployeeId.Text.Trim(),
                            Variables.CaseRefId, txt_DCaseId.Text.Trim(), Convert.ToInt32(rcbDCaseFor.SelectedValue), txt_DepName.Text.Trim(),
                            txt_DepMobileNo.Text.Trim(), rcbDepGender.SelectedItem.Text.Trim(),
                            Convert.ToDateTime(rdpDepDOB.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy")),
                            txt_DepAddress.Text.Trim(), DMedicalTest, out IsDataExistsD);

                        //SaveCaseRemark();

                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Case Already Exists");
                        }
                        else
                        {
                            showPopup("Warning", "Case Updated Successfully");
                            ClearFields();
                            Variables.CaseRefId = 0;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Case.aspx');</script>");
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Case Updated Successfully');</script>" + "<script>window.location.href='Case.aspx';</script>");
                        }
                    }
                        
                    }
                    if (Session["RoleId"].ToString().Equals("1"))
                    {

                    }
                    else
                    {
                        btnSave.Text = "Save";
                        ClearFields();
                        //GenerateCaseId();
                        Variables.CaseRefId = 0;
                        //LoadCorporateDetails();
                        //CorporateView.ActiveViewIndex = 0;
                        //rgCaseDependentDetails.DataSource = new object[] { };
                        //rgCaseDependentDetails.DataBind();
                    }
                }
                
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }
        
        }

        public void SaveDependentDetails(int Id)
        {

            Bal BusinessAccessLayer = new Bal();

            int DependentTableLength = rgDependentGrid.Rows.Count;

            foreach (GridViewRow grow in rgDependentGrid.Rows)
            {


                string DMedicalTest = "";

                for (int i = 0; i < rcbDMedicalTest.CheckedItems.Count; i++)
                {
                    if (DMedicalTest == "")
                    {
                        DMedicalTest = rcbDMedicalTest.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        DMedicalTest += "," + rcbDMedicalTest.CheckedItems[i].Value.Trim();
                    }
                }

                string GenericTest = "";

                for (int i = 0; i < rcbGenericTest.CheckedItems.Count; i++)
                {
                    if (GenericTest == "")
                    {
                        GenericTest = rcbGenericTest.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        GenericTest += "," + rcbGenericTest.CheckedItems[i].Value.Trim();
                    }
                }

                string Services = "";

                for (int i = 0; i < rcbServicesOffered.CheckedItems.Count; i++)
                {
                    if (Services == "")
                    {
                        Services = rcbServicesOffered.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        Services += "," + rcbServicesOffered.CheckedItems[i].Value.Trim();
                    }
                }

                
                Bal DependentBusinessAccessLayer = new Bal();
                DataTable dtCaseId = new DataTable();
                Int32 CaseId = 0;

                dtCaseId = BusinessAccessLayer.GenerateCaseId();
                if (dtCaseId != null && dtCaseId.Rows.Count > 0)
                {
                    CaseId = Convert.ToInt32(dtCaseId.Rows[0]["CaseId"].ToString());

                    if (CaseId <= 9)
                    {
                        txt_CaseId.Text = "WX0000" + CaseId.ToString();
                    }

                    else if (CaseId > 9 && CaseId < 100)
                    {
                        txt_CaseId.Text = "WX000" + CaseId.ToString();
                    }
                    else if (CaseId > 99 && CaseId < 1000)
                    {
                        txt_CaseId.Text = "WX00" + CaseId.ToString();
                    }
                    else if (CaseId > 999 && CaseId < 10000)
                    {
                        txt_CaseId.Text = "WX0" + CaseId.ToString();
                    }
                    else
                    {
                        txt_CaseId.Text = "WX" + CaseId.ToString();
                    }

                }


                string IsDataExistsD = "0";

                Int32 Caserefid = 0;
                string Caserid = grow.Cells[0].Text.Trim();

                String[] caserid = Caserid.Split('X');

                string caseidpart = caserid[1];
                Caserefid = Convert.ToInt32(caseidpart.ToString());

                //rcbcasefor.SelectedValue = grow.Cells[1].Text;

                //if (btnSave.Text.Equals("Save"))
                //{
                //    //DependentBusinessAccessLayer.InsertUpdateDependentCaseDetails(0, txt_EmployeeId.Text.Trim(),
                //    //    Caserefid, grow.Cells[0].Text, Convert.ToInt32(grow.Cells[1].Text.Trim()), grow.Cells[2].Text.Trim(),
                //    //    grow.Cells[3].Text.Trim(), grow.Cells[4].Text.Trim(), Convert.ToDateTime(grow.Cells[5].Text),
                //    //    grow.Cells[6].Text.Trim(), DMedicalTest, out IsDataExistsD);
                //    //if (IsDataExistsD == "1")
                //    //{
                //    //    showPopup("Warning", "Dependent Already Exists");
                //    //}
                //    //else
                //    //{
                //    //    showPopup("Warning", "Case Saved Successfully");

                //    //}
                //}
                //else
                //{
                //    //DependentBusinessAccessLayer.InsertUpdateDependentCaseDetails(Variables.DependentId, txt_EmployeeId.Text.Trim(),
                //    //    Caserefid, grow.Cells[0].Text, Convert.ToInt32(grow.Cells[1].Text.Trim()), grow.Cells[2].Text.Trim(),
                //    //    grow.Cells[3].Text.Trim(), grow.Cells[4].Text.Trim(), Convert.ToDateTime(grow.Cells[5].Text),
                //    //    grow.Cells[6].Text.Trim(), DMedicalTest, out IsDataExistsD);
                //    //if (IsDataExistsD == "1")
                //    //{
                //    //    showPopup("Warning", "Dependent Already Exists");
                //    //}
                //    //else
                //    //{
                //    //    showPopup("Warning", "Case Updated Successfully");
                //    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Case.aspx');</script>");
                //    //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Case Updated Successfully');</script>");
                //    //}
                //}

                string IsDataExists = "0";

                if (btnSave.Text.Equals("Save"))
                {
                    BusinessAccessLayer.InsertUpdateCaseDetails(0, txt_CaseId.Text.Trim(), txt_CaseEntryDate.Text.Trim(), Convert.ToInt32(rcbBranch.SelectedValue),
                        Convert.ToInt32(rcbAssignExecutive.SelectedValue), rcbCaseMode.SelectedItem.Text.Trim(),
                        dtpCaseRecDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpCaseRecDateTime.DateInput.SelectedDate.Value,
                        Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue), Convert.ToInt32(rcbProduct.SelectedValue), Services,
                        txt_EmployeeMobileNo.Text.Trim(), txt_EmployeeName.Text.Trim(), rcbGender.SelectedItem.Text.Trim(), Variables.EmployeeRefId, txt_EmployeeId.Text.Trim(),
                        txt_EmployeeEmail.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue), txt_EmployeeAreaLocality.Text.Trim(),
                        txt_EmployeeLandmark.Text.Trim(), txt_EmployeePincode.Text.Trim(), txt_EmployeeAddress.Text.Trim(), txt_EmployeeGeolocation.Text.Trim(),
                        rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                        DMedicalTest, txt_ApplicationNo.Text.Trim(), Convert.ToInt32(rcbCaseType.SelectedValue), rcbPaymentType.SelectedItem.Text.Trim(),
                        Convert.ToInt32(grow.Cells[1].Text.Trim()), Convert.ToInt32(rcbCustomerProfile.SelectedValue), DMedicalTest, txtPaybleAmount.Text.Trim(),
                        rcbDHOCPayment.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), dtpFollowUp.DateInput.SelectedDate.Equals(null) ? nul : dtpFollowUp.DateInput.SelectedDate.Value,
                        txt_Remark.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                    DependentBusinessAccessLayer.InsertUpdateDependentCaseDetails(0, txt_EmployeeId.Text.Trim(),
                        Caserefid, grow.Cells[0].Text, Convert.ToInt32(grow.Cells[1].Text.Trim()), grow.Cells[2].Text.Trim(),
                        grow.Cells[3].Text.Trim(), grow.Cells[4].Text.Trim(), Convert.ToDateTime(grow.Cells[5].Text),
                        grow.Cells[6].Text.Trim(), DMedicalTest, out IsDataExistsD);

                    //SaveCaseRemark();

                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Case Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Case Saved Successfully");

                    }
                }
                else
                {
                    
                }

                
            }


        }

        //public void SaveCaseRemark()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    //string IsDataExists = "0";

        //    Int32 Caserefid = 0;
        //    string Caserid = txt_CaseId.Text.Trim();

        //    String[] caserid = Caserid.Split('X');

        //    string caseidpart = caserid[1];
        //    Caserefid = Convert.ToInt32(caseidpart.ToString());

        //    BusinessAccessLayer.InsertUpdateCaseRemarkDetails(0, Caserefid, txt_CaseId.Text.Trim(), txt_Remark.Text.Trim(),
        //        Convert.ToInt32(rcbCaseStatus.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));
        //}

        public void ClearFields()
        {
            txt_CaseId.Text = "";
            txt_CaseEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtpCaseRecDateTime.Clear();
            rcbBranch.SelectedItem.Text = "Select Branch";
            rcbAssignExecutive.SelectedItem.Text = "Select Executive";
            rcbCaseMode.SelectedItem.Text = "Select Case Mode";
            DDL_CorporateName.SelectedItem.Text = "Select Client Name";
            rcbBranchId.SelectedItem.Text = "Select Branch Id";
            rcbServicesOffered.SelectedItem.Text = "Select Services";
            txt_EmployeeMobileNo.Text = "";
            txt_EmployeeName.Text = "";
            rcbGender.SelectedItem.Text = "Select Gender";
            txt_EmployeeId.Text = "";
            txt_EmployeeEmail.Text = "";
            DDL_State.SelectedItem.Text = "Select State";
            DDL_City.SelectedItem.Text = "Select City";
            txt_EmployeeAreaLocality.Text = "";
            txt_EmployeeLandmark.Text = "";
            txt_EmployeePincode.Text = "";
            txt_EmployeeAddress.Text = "";
            txt_EmployeeGeolocation.Text = "";
            rdpEmployeeDOB.Clear();
            //rcbMedicalTest.SelectedItem.Text = "Select Test";
            txt_ApplicationNo.Text = "";
            rcbCaseType.SelectedValue = "0";
            rcbPaymentType.SelectedItem.Text = "Select Payment Type";
            rcbcasefor.SelectedItem.Text = "Select case For";
            rcbCustomerProfile.SelectedItem.Text = "Select Profile";
            txtPaybleAmount.Text = "";
            rcbDHOCPayment.SelectedItem.Text = "No";
            rcbCaseStatus.SelectedItem.Text = "Select Case Status";
            dtpFollowUp.Clear();
            txt_Remark.Text = "";

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.CaseRefId = 0;
            Response.Redirect("~/Case/Case.aspx");
        }
        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void DDL_State_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DDL_City.Items.Clear();
            DDL_City.Items.Insert(0, "Select City");
            try
            {


                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(DDL_State.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    DDL_City.DataSource = dtCity;
                    DDL_City.DataTextField = "DistrictName";
                    DDL_City.DataValueField = "DistrictId";
                    DDL_City.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

     
        protected void LinkDependent_Click(object sender, EventArgs e)
        {
            AddDependent.Visible = true;
        }

        public void SearchEmployeeDetailsList()
        {
            DataTable dtEmployeeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtEmployeeDetails = BusinessAccessLayer.FetchEmployeeDetailsOnCorporateId(Convert.ToInt32(DDL_CorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue));

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
        protected void DDL_CorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            TestList();
            //PackageList();
            CorporateBranchList();
            //ProductList();
            //SearchEmployeeDetailsList();
        }

       
        protected void btnSearchEmployeee_Click(object sender, ImageClickEventArgs e)
        {
            ModalPopupExtenderLogin.Show();
            DDL_CorporateName_SelectedIndexChanged(null, null);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string ConditionQuery = "";
            string Query = "";
            string MainQuery = "";

            if(txtSearchEmployeeName.Text=="" && txtSearchMobileNo.Text=="" && txtSearchEmployeeId.Text=="")
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
                ConditionQuery = " and ED.CorporateId = '" + DDL_CorporateName.SelectedValue + "' and ED.BranchId = '" + rcbBranchId.SelectedValue + "'";
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderLogin.Hide();
        }

        protected void rgvSearchEmployeeDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "EditRow")
                {
                    Label lblEmployeeRefId = (Label)rgvSearchEmployeeDetails.Items[intIndex % 10].FindControl("lblEmployeeRefId"); // % 15 for page indexing
                    Variables.EmployeeRefId = Convert.ToInt32(lblEmployeeRefId.Text.Trim());

                    Bal BusinessAccessLayer = new Bal();
                    DataTable dtEmployeeDetails = new DataTable();
                    dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsById(Variables.EmployeeRefId);

                    if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                    {
                        txt_EmployeeName.Text = dtEmployeeDetails.Rows[0]["EmployeeName"].ToString();
                        txt_EmployeeMobileNo.Text = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();
                        rcbGender.SelectedItem.Text = dtEmployeeDetails.Rows[0]["Gender"].ToString();
                        txt_EmployeeId.Text = dtEmployeeDetails.Rows[0]["EmployeeId"].ToString();
                        txt_EmployeeAddress.Text = dtEmployeeDetails.Rows[0]["Address"].ToString();
                        txt_EmployeeEmail.Text = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                        DDL_State.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                        DDL_State_SelectedIndexChanged(null, null);
                        DDL_City.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                        txt_EmployeeAreaLocality.Text = dtEmployeeDetails.Rows[0]["Area"].ToString();
                        txt_EmployeeLandmark.Text = dtEmployeeDetails.Rows[0]["Landmark"].ToString();
                        txt_EmployeePincode.Text = dtEmployeeDetails.Rows[0]["Pincode"].ToString();
                        txt_EmployeeGeolocation.Text = dtEmployeeDetails.Rows[0]["GeoLocation"].ToString();
                        rdpEmployeeDOB.DbSelectedDate = dtEmployeeDetails.Rows[0]["DOB"].ToString();                                                             

                        
                        ServicesAssigned = dtEmployeeDetails.Rows[0]["Services"].ToString();
                        string ProductId = dtEmployeeDetails.Rows[0]["ProductId"].ToString();

                        LoadProductListForEmployee(ProductId, ServicesAssigned );
                        //LoadServicesBasedUponEmployee(ServicesAssigned);

                        //String[] ProductValue = ProductId.Split(',');

                        //foreach (string s in ProductValue)
                        //{
                        //    foreach (RadComboBoxItem item in rcbProduct.Items)//ListItem item in rcbMedicalTest.Items)
                        //    {
                        //        if (item.Value == s)
                        //        {
                        //            item.Checked = true;
                        //            //item.Selected = true;
                        //            break;
                        //        }
                        //    }
                        //}

                        //rcbProduct_SelectedIndexChanged(null, null);
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        public void LoadServicesBasedUponEmployee(string Services)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtServices = new DataTable();
            dtServices = BusinessAccessLayer.LoadServicesForEmployee(Services);
            rcbServicesOffered.Items.Clear();
            if (dtServices != null && dtServices.Rows.Count > 0)

            {
                rcbServicesOffered.DataSource = dtServices;
                rcbServicesOffered.DataValueField = "SubProductId";
                rcbServicesOffered.DataTextField = "SubProductCategory";
                rcbServicesOffered.DataBind();

                rcbServicesOffered.Items.Insert(0, "Select Services");
            }

        }

        protected void rgvSearchEmployeeDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvSearchEmployeeDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        

        protected void rcbBranchId_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //CorporateBProductList(); Changes
            SearchEmployeeDetailsList();
        }

        public void ProductServices()
        {

            rcbServicesOffered.Items.Clear();
            rcbServicesOffered.AppendDataBoundItems = true;

            if (Session["CorporatesubCategoryDetails"] != null)
            {
                DataTable dt = new DataTable();

                dt = Session["CorporatesubCategoryDetails"] as DataTable;

                //DataView dvSubProduct = Session["CorporatesubCategoryDetails"] as DataView;
                DataView dv = new DataView(dt);

                DataTable dtSubProductDetails = new DataTable();

                // dvSubProduct.RowFilter = "ProductId=" + rcbProduct.SelectedValue;
                dv.RowFilter = "ProductId=" + rcbProduct.SelectedValue;

                rcbServicesOffered.DataSource = dv.ToTable();
                rcbServicesOffered.DataTextField = "SubProductCategory";
                rcbServicesOffered.DataValueField = "SubProductId";
                rcbServicesOffered.DataBind();
            }


        }
        protected void rcbProduct_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ProductServices();

            
        }

        protected void rcbCustomerProfile_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadGenericTestAmount();
            if(txtPaybleAmount.Text=="")
            {
                txtPaybleAmount.Text = "0.00";
            }
            else
            {
                txtPaybleAmount.Text = txtPaybleAmount.Text;
            }
        }

        protected void txtSearchEmployeeName_TextChanged(object sender, EventArgs e)
        {
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

        public void ClearDependent()
        {
            rcbDCaseFor.SelectedValue = "0";
            txt_DepName.Text = "";
            txt_DepMobileNo.Text = "";
            rcbDepGender.SelectedValue = "0";
            rdpDepDOB.DbSelectedDate = "";
            txt_DepAddress.Text = "";

        }

        protected void ImgAddDependent_Click(object sender, ImageClickEventArgs e)
        {
            string DMedicalTest = "";

            for (int i = 0; i < rcbDMedicalTest.CheckedItems.Count; i++)
            {
                if (DMedicalTest == "")
                {
                    DMedicalTest = rcbDMedicalTest.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DMedicalTest += "," + rcbDMedicalTest.CheckedItems[i].Value.Trim();
                }
            }


            dt1 = (DataTable)ViewState["Records"];
            dt1.Rows.Add(txt_DCaseId.Text.Trim(),
                rcbDCaseFor.SelectedValue,
                txt_DepName.Text.Trim(),
                txt_DepMobileNo.Text.Trim(),
                rcbDepGender.SelectedItem.Text.Trim(),
                //rdpDepDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpDepDOB.DateInput.SelectedDate.Value.ToString('dd-MM-yyyy'),
                rdpDepDOB.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy"),
                txt_DepAddress.Text.Trim(),
                DMedicalTest);
            rgDependentGrid.DataSource = dt1;
            rgDependentGrid.DataBind();


            Int32 DCaseid = 0;
            string Caseid = txt_DCaseId.Text.Trim();

            String[] caseid = Caseid.Split('X');

            string casepart = caseid[1];
            DCaseid = Convert.ToInt32(1) + Convert.ToInt32(casepart.ToString());

            if (DCaseid <= 9)
            {
                txt_DCaseId.Text = "WX0000" + DCaseid.ToString();
            }

            else if (DCaseid > 9 && DCaseid < 100)
            {
                txt_DCaseId.Text = "WX000" + DCaseid.ToString();
            }
            else if (DCaseid > 99 && DCaseid < 1000)
            {
                txt_DCaseId.Text = "WX00" + DCaseid.ToString();
            }
            else if (DCaseid > 999 && DCaseid < 10000)
            {
                txt_DCaseId.Text = "WX0" + DCaseid.ToString();
            }
            else
            {
                txt_DCaseId.Text = "WX" + DCaseid.ToString();
            }

            ClearDependent();
        }

        protected void ImgUpdateDependent_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Bal DependentBusinessAccessLayer = new Bal();
                string IsDataExistsD = "";
                Variables.DependentId = Convert.ToInt32(lblDependentId.Text);

                

                Int32 Caserefid = 0;
                string Caserid = txt_DCaseId.Text.Trim();

                String[] caserid = Caserid.Split('X');

                string caseidpart = caserid[1];
                Caserefid = Convert.ToInt32(caseidpart.ToString());

                string DMedicalTest = "";

                for (int i = 0; i < rcbDMedicalTest.CheckedItems.Count; i++)
                {
                    if (DMedicalTest == "")
                    {
                        DMedicalTest = rcbDMedicalTest.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        DMedicalTest += "," + rcbDMedicalTest.CheckedItems[i].Value.Trim();
                    }
                }


                DependentBusinessAccessLayer.InsertUpdateDependentCaseDetails(Variables.DependentId, txt_EmployeeId.Text.Trim(),
                        Caserefid, txt_DCaseId.Text.Trim(), Convert.ToInt32(rcbDCaseFor.SelectedValue), txt_DepName.Text.Trim(),
                        txt_DepMobileNo.Text.Trim(), rcbDepGender.SelectedItem.Text.Trim(), 
                        Convert.ToDateTime(rdpDepDOB.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy")),
                        txt_DepAddress.Text.Trim(), DMedicalTest, out IsDataExistsD);
                if (IsDataExistsD == "1")
                {
                    showPopup("Warning", "Dependent Already Exists");
                }
                else
                {
                    showPopup("Warning", "Dependent Updated Successfully");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Dependent Updated Successfully');</script>");
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
            
        }

        protected void btn_Details_Click(object sender, EventArgs e)
        {
            string DMedicalTest = "";

            for (int i = 0; i < rcbDMedicalTest.CheckedItems.Count; i++)
            {
                if (DMedicalTest == "")
                {
                    DMedicalTest = rcbDMedicalTest.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DMedicalTest += "," + rcbDMedicalTest.CheckedItems[i].Value.Trim();
                }
            }

            
            dt1 = (DataTable)ViewState["Records"];
            dt1.Rows.Add(txt_DCaseId.Text.Trim(), 
                rcbDCaseFor.SelectedValue, 
                txt_DepName.Text.Trim(), 
                txt_DepMobileNo.Text.Trim(),
                rcbDepGender.SelectedItem.Text.Trim(),
                //rdpDepDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpDepDOB.DateInput.SelectedDate.Value.ToString('dd-MM-yyyy'),
                rdpDepDOB.DateInput.SelectedDate.Value.ToString("dd-MM-yyyy"),
                txt_DepAddress.Text.Trim(),
                DMedicalTest);
            rgDependentGrid.DataSource = dt1;
            rgDependentGrid.DataBind();


            Int32 DCaseid = 0;
            string Caseid = txt_DCaseId.Text.Trim();

            String[] caseid = Caseid.Split('X');

            string casepart = caseid[1];
            DCaseid = Convert.ToInt32(1) + Convert.ToInt32(casepart.ToString());

            if (DCaseid <= 9)
            {
                txt_DCaseId.Text = "WX0000" + DCaseid.ToString();
            }

            else if (DCaseid > 9 && DCaseid < 100)
            {
                txt_DCaseId.Text = "WX000" + DCaseid.ToString();
            }
            else if (DCaseid > 99 && DCaseid < 1000)
            {
                txt_DCaseId.Text = "WX00" + DCaseid.ToString();
            }
            else if (DCaseid > 999 && DCaseid < 10000)
            {
                txt_DCaseId.Text = "WX0" + DCaseid.ToString();
            }
            else
            {
                txt_DCaseId.Text = "WX" + DCaseid.ToString();
            }

            ClearDependent();
        }

        protected void rgvDependentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //int CaseId = 0;
                //int rowIndex = Convert.ToInt32(e.CommandArgument);

                //GridViewRow row = gvDCDetails.Rows[rowIndex];

                //DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                //Variables.CaseId = DCId;
            }

        }

        
    }
}