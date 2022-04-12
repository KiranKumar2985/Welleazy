using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Data;
using Telerik.Web.UI;
using AjaxControlToolkit;
using System.IO;
using System.Text;

namespace Welleazy.Case
{
    public partial class DoctorPrescription : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtpPrescriptionEntryDate.SelectedDate = DateTime.Now;
                DoctorPrescriptionView.ActiveViewIndex = 0;
                LoadPrescriptionDetails();

                LoadCorporate();
                Session["MedicineDetails"] = null;


                rgvMedicineDetails.DataSource = new object[] { };
                rgvMedicineDetails.DataBind();


                //rgvMedicineHistory.DataSource = new object[] { };
                //rgvMedicineHistory.DataBind();

                //rgvPatientHistory.DataSource = new object[] { };
                //rgvPatientHistory.DataBind();
            }
        }

        public void LoadPrescriptionDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtPrescriptionDetails = new DataTable();
            dtPrescriptionDetails = BusinessAccessLayer.LoadPrescriptionDetails();

            try
            {


                if (dtPrescriptionDetails != null && dtPrescriptionDetails.Rows.Count > 0)
                {
                    rgvPrescriptionDetails.DataSource = dtPrescriptionDetails;

                    rgvPrescriptionDetails.DataBind();
                }
                else
                {
                    rgvPrescriptionDetails.DataSource = new object[] { };
                    rgvPrescriptionDetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

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

                rcbClientName.DataSource = dtCorporateDetails;
                rcbClientName.DataTextField = "CorporateName";
                rcbClientName.DataValueField = "CorporateId";
                rcbClientName.DataBind();
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";

            string CorporateId = "";

            MainQuery = "Select PrescriptionId, PrescriptionDateTime, EmployeeName,TDP.EmployeeRefId, Age,MCD.CorporateName,TDP.DoctorId, DoctorName, Symptoms, TestDetails, PrescriptionDetails,DietToBeFollow, NextVisitDate, TDP.CreatedOn, MLD.DisplayName as CreatedBy, MLD1.DisplayName as UpdatedBy, TDP.UpdatedOn from Tbl_DoctorPrescription TDP" +
                " left Join EmployeeDetails ED on ED.EmployeeRefId = TDP.EmployeeRefId " +
                " Left Join Master_Doctor MD on MD.DoctorId = TDP.DoctorId " +
                " Left Join Master_LoginDetails MLD on MLD.LoginRefId = TDP.CreatedBy " +
                " Left Join Master_LoginDetails MLD1 on MLD1.LoginRefId = TDP.UpdatedBy " +
                " Left join Master_CorporateDetails MCD on MCD.CorporateId = ED.CorporateId";
            ConditionQuery = " order by PrescriptionId desc";
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

            if (txtEmplolyeeNameSearch.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where EmployeeName like '%" + txtEmplolyeeNameSearch.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And EmployeeName like '%" + txtEmplolyeeNameSearch.Text.Trim() + "%'";
                }
            }

            if (!dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Equals(null) && !dtpPrescriptiondate.EndDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where PrescriptionDateTime Between'" + dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPrescriptiondate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And PrescriptionDateTime Between'" + dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPrescriptiondate.EndDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            else if (!dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Equals(null))
            {
                if (Query.Equals(""))
                {
                    Query = " where PrescriptionDateTime ='" + dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    Query += " And PrescriptionDateTime ='" + dtpPrescriptiondate.StartDatePicker.DateInput.SelectedDate.Value.ToString("yyyy-MM-dd") + "'";
                }
            }

            Bal BusinessAccessLayer = new Bal();
            DataTable dtSearch = new DataTable();
            dtSearch = BusinessAccessLayer.SearchPrescriptionDetails(MainQuery + Query + ConditionQuery);

            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                rgvPrescriptionDetails.DataSource = dtSearch;
                rgvPrescriptionDetails.DataBind();
            }
            else
            {
                rgvPrescriptionDetails.DataSource = new object[] { }; ;
                rgvPrescriptionDetails.DataBind();
            }
        }

        protected void btnAdvanced_Click(object sender, EventArgs e)
        {

        }

        protected void rgvPrescriptionDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "EditRow")
                {
                    Label lblPrescriptionId = (Label)rgvPrescriptionDetails.Items[intIndex % 10].FindControl("lblPrescriptionId");

                    //ModalPopupExtender ModalPopupExtenderHistory = (ModalPopupExtender)rgvPrescriptionDetails.Items[intIndex % 10].FindControl("ModalPopupExtenderHistory");



                    //ModalPopupExtenderHistory.Show();




                    Session["PrescriptionId"] = lblPrescriptionId.Text;
                    LoadPrescriptionDetailsById();

                    DoctorPrescriptionView.ActiveViewIndex = 1;

                    btnSave.Text = "Update";
                }

                if (e.CommandName == "ViewHistory")
                {
                    try
                    {
                        Label lblEmployeeRefId = (Label)rgvPrescriptionDetails.Items[intIndex % 10].FindControl("lblEmployeeRefId");
                        LoadPatientHistory(lblEmployeeRefId.Text);
                        //ModalPopupExtenderHistory.Show();
                        bool showModal = true;

                        if (showModal)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal2').modal('show');", true);

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                if (e.CommandName == "Print")
                {
                    Label lblPrescriptionIdPDF = (Label)rgvPrescriptionDetails.Items[intIndex % 10].FindControl("lblPrescriptionIdPDF");
                    LoadPatientPrescription(lblPrescriptionIdPDF.Text);
                    //ModalPopupExtenderPatientPrescription.Show();
                    bool showModal = true;

                    if (showModal)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LoadPatientHistory(string EmployeeRefId)
        {
            Bal BusinessAccessLayer = new Bal();
            DataSet dtCaseDetails = new DataSet();
            dtCaseDetails = BusinessAccessLayer.LoadPatientHistory(Convert.ToInt32(EmployeeRefId));

            if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
            {


                rgvPatientHistory.DataSource = dtCaseDetails.Tables[0];
                rgvPatientHistory.DataBind();


                rgvMedicineHistory.DataSource = dtCaseDetails.Tables[1];
                rgvMedicineHistory.DataBind();


            }
        }

        public void LoadPatientPrescription(string PrescriptionId)
        {
            Bal BusinessAccessLayer = new Bal();
            DataSet dtPrescriptionDetails = new DataSet();
            dtPrescriptionDetails = BusinessAccessLayer.LoadPrescriptionDetailsById(Convert.ToInt32(PrescriptionId));

            if (dtPrescriptionDetails != null && dtPrescriptionDetails.Tables[0].Rows.Count > 0)
            {
                LabelPrescriptionNo.Text = dtPrescriptionDetails.Tables[0].Rows[0]["PrescriptionId"].ToString();
                LabelPrescriptionDate.Text = dtPrescriptionDetails.Tables[0].Rows[0]["PrescriptionDateTime"].ToString();
                LabelDrName.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DoctorName"].ToString();
                LabelDoctorID.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DoctorId"].ToString();
                LabelDrRegnNo.Text = dtPrescriptionDetails.Tables[0].Rows[0]["RegistrationNumber"].ToString();
                LabelDrQualification.Text = dtPrescriptionDetails.Tables[0].Rows[0]["Qualification"].ToString();
                LabelDrContactNo.Text = dtPrescriptionDetails.Tables[0].Rows[0]["ContactNo"].ToString();
                LabelDrEmail.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DrEmailId"].ToString();
                LabelDrCity.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DrCity"].ToString();
                LabelDrAddress.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DoctorAddress"].ToString();

                LabelCorporateName.Text = dtPrescriptionDetails.Tables[0].Rows[0]["CorporateName"].ToString();
                LabelPtName.Text = dtPrescriptionDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                LabelPtAge.Text = dtPrescriptionDetails.Tables[0].Rows[0]["Age"].ToString();
                LabelPtContactNo.Text = dtPrescriptionDetails.Tables[0].Rows[0]["MobileNo"].ToString();
                LabelPtEmail.Text = dtPrescriptionDetails.Tables[0].Rows[0]["EmailId"].ToString();
                LabelPtCity.Text = dtPrescriptionDetails.Tables[0].Rows[0]["PtCity"].ToString();
                LabelPtAddress.Text = dtPrescriptionDetails.Tables[0].Rows[0]["Address"].ToString();

                LabelSymptoms.Text = dtPrescriptionDetails.Tables[0].Rows[0]["Symptoms"].ToString();
                LabelTestDetails.Text = dtPrescriptionDetails.Tables[0].Rows[0]["TestDetails"].ToString();
                LabelPrescriptionDetails.Text = dtPrescriptionDetails.Tables[0].Rows[0]["PrescriptionDetails"].ToString();
                LabelDietToBeFollow.Text = dtPrescriptionDetails.Tables[0].Rows[0]["DietToBeFollow"].ToString();
                LabelNextVisitDate.Text = dtPrescriptionDetails.Tables[0].Rows[0]["NextVisitDate"].ToString();


                //rgvPatientPrescriptionDetails.DataSource = dtPrescriptionDetails.Tables[0];
                //rgvPatientPrescriptionDetails.DataBind();


                rgvMedicineDetailsView.DataSource = dtPrescriptionDetails.Tables[1];
                rgvMedicineDetailsView.DataBind();

            }
        }

        public void LoadPrescriptionDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataSet dtCaseDetails = new DataSet();
            dtCaseDetails = BusinessAccessLayer.LoadPrescriptionDetailsById(Convert.ToInt32(Session["PrescriptionId"]));

            //LoadAssignExecutive();
            if (dtCaseDetails != null && dtCaseDetails.Tables[0].Rows.Count > 0)
            {

                //lblCaseId.Text = dtCaseDetails.Rows[0]["CaseId"].ToString();
                //dtpPrescriptionEntryDate.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["PrescriptionDateTime"].ToString());

                LoadCorporate();
                cmbCorporateName.SelectedValue = (dtCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString());
                cmbCorporateName_SelectedIndexChanged(null, null);
                cmbCorporateBranchId.SelectedValue = (dtCaseDetails.Tables[0].Rows[0]["BranchId"].ToString());
                //cmbServicesOffered.SelectedValue = (dtCaseDetails.Rows[0]["ServicesOffered"].ToString());

                txtEmployeeName.Text = dtCaseDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtMobileNo.Text = dtCaseDetails.Tables[0].Rows[0]["MobileNo"].ToString();
                cmbGender.SelectedValue = dtCaseDetails.Tables[0].Rows[0]["Gender"].ToString();

                txtEmployeeEmailId.Text = dtCaseDetails.Tables[0].Rows[0]["EMailId"].ToString();
                LabelAge.Text = dtCaseDetails.Tables[0].Rows[0]["Age"].ToString();

                txtSymptoms.Text = dtCaseDetails.Tables[0].Rows[0]["Symptoms"].ToString();
                txtTestDetails.Text = dtCaseDetails.Tables[0].Rows[0]["TestDetails"].ToString();
                txtPrescriptionDetails.Text = dtCaseDetails.Tables[0].Rows[0]["PrescriptionDetails"].ToString();
                txtDietToBeFollow.Text = dtCaseDetails.Tables[0].Rows[0]["DietToBeFollow"].ToString();
                dtpNextVisitDate.DbSelectedDate = dtCaseDetails.Tables[0].Rows[0]["NextVisitDate"].ToString();

                Session["MedicineDetails"] = dtCaseDetails.Tables[1];
                rgvMedicineDetails.DataSource = dtCaseDetails.Tables[1];
                rgvMedicineDetails.DataBind();

                //LanguageId = dtCaseDetails.Rows[0]["CustomerMedicineSessionDetails"].ToString();

                //int lenght2 = ServicesValue.Length;
                //String[] ServicesValue = LanguageId.Split(',');

                //foreach (string s in ServicesValue)
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

                //cmbLanguage_SelectedIndexChanged(null, null);
                //cmbLanguage.SelectedValue = dtCaseDetails.Rows[0]["MedicineSessionDetails"].ToString();

                //dtpDoctorDateTime.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["DoctorDateTime"].ToString());
                //cmbDoctorName.SelectedValue = dtCaseDetails.Rows[0]["DoctorId"].ToString();
                //cmb.SelectedValue = dtCaseDetails.Rows[0]["DoctorQualificationId"].ToString();
                //cmbCaseStatus.SelectedValue = dtCaseDetails.Rows[0]["CaseStatus"].ToString();

                //dtpFollowUp.SelectedDate = Convert.ToDateTime(dtCaseDetails.Rows[0]["FollowUpDataTime"].ToString());

                //txtRemarks.Text = dtCaseDetails.Rows[0]["Remarks"].ToString();

                //btnSave.Text = "Update";
            }
        }

        protected void rgvPrescriptionDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvPrescriptionDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void cmbCorporateName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rgvMedicineDetails.Items.Count < 1)
            {
                showPopup("Warning", "Please Add Medicine Details");
                return;
            }
            DataTable DtMedicineDetails = new DataTable();
            DtMedicineDetails.Columns.Add("MedicineName");


            //DtMedicineDetails.Columns.Add("MedicineType");

            DtMedicineDetails.Columns.Add("MedicineTypeId");
            //DtMedicineDetails.Columns.Add("MedicineSession");
            DtMedicineDetails.Columns.Add("MedicineSessionId");
            //DtMedicineDetails.Columns.Add("InTakeMethod");

            DtMedicineDetails.Columns.Add("InTakeMethodId");

            DtMedicineDetails.Columns.Add("Remarks");
            foreach (GridDataItem item in rgvMedicineDetails.MasterTableView.Items)
            {
                string lblMedicineName = (item.FindControl("lblMedicineName") as Label).Text;

                //string lblMedicineType = (item.FindControl("lblMedicineType") as Label).Text;
                string lblMedicineTypeId = (item.FindControl("lblMedicineTypeId") as Label).Text;
                //string lblMedicineSession = (item.FindControl("lblMedicineSession") as Label).Text;
                string lblMedicineSessionId = (item.FindControl("lblMedicineSessionId") as Label).Text;
                //string lblInTakeMethod = (item.FindControl("lblInTakeMethod") as Label).Text;
                string lblInTakeMethodId = (item.FindControl("lblInTakeMethodId") as Label).Text;
                string lblRemarks = (item.FindControl("lblRemarks") as Label).Text;

                DtMedicineDetails.Rows.Add(lblMedicineName, lblMedicineTypeId, lblMedicineSessionId, lblInTakeMethodId, lblRemarks);

            }
            Bal BusinessAccessLayer = new Bal();
            if (btnSave.Text.Equals("Save"))
            {



                BusinessAccessLayer.SaveDoctorPrescriptionDetails(0, dtpPrescriptionEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpPrescriptionEntryDate.DateInput.SelectedDate.Value, 
                    Convert.ToInt32(Session["EmployeeRefId"]), Convert.ToInt32(cmbCorporateName.SelectedValue), Variables.EmployeeRefId, Convert.ToInt32(LabelAge.Text.Trim()), txtSymptoms.Text.Trim(), txtTestDetails.Text.Trim(), 
                    txtPrescriptionDetails.Text.Trim(), txtDietToBeFollow.Text.Trim(), dtpNextVisitDate.DateInput.SelectedDate.Equals(null) ? nul : dtpNextVisitDate.SelectedDate.Value, 
                    Convert.ToInt32(Session["LoginRefId"]), DtMedicineDetails);
                showPopup("Warning", "Prescription Saved Successfully");
            }
            else
            {
                BusinessAccessLayer.SaveDoctorPrescriptionDetails(Convert.ToInt32(Session["PrescriptionId"]), dtpPrescriptionEntryDate.DateInput.SelectedDate.Equals(null) ? nul : dtpPrescriptionEntryDate.DateInput.SelectedDate.Value,
                    Convert.ToInt32(Session["EmployeeRefId"]), Convert.ToInt32(cmbCorporateName.SelectedValue), Variables.EmployeeRefId, Convert.ToInt32(LabelAge.Text.Trim()), txtSymptoms.Text.Trim(), txtTestDetails.Text.Trim(),
                    txtPrescriptionDetails.Text.Trim(), txtDietToBeFollow.Text.Trim(), dtpNextVisitDate.DateInput.SelectedDate.Equals(null) ? nul : dtpNextVisitDate.SelectedDate.Value,
                    Convert.ToInt32(Session["LoginRefId"]), DtMedicineDetails);
                showPopup("Warning", "Prescription Updated Successfully");
            }

            LoadPrescriptionDetails();
            DoctorPrescriptionView.ActiveViewIndex = 0;
            ClearFields();


        }

        public void ClearFields()
        {
            Session["MedicineDetails"] = null;
            txtEmployeeEmailId.Text = "";
            txtEmployeeName.Text = "";
            txtMobileNo.Text = "";
            txtSymptoms.Text = "";
            txtTestDetails.Text = "";
            txtPrescriptionDetails.Text = "";
            txtDietToBeFollow.Text = "";
            dtpNextVisitDate.Clear();
            cmbCorporateName.SelectedValue = "0";
            cmbCorporateBranchId.SelectedValue = "0";
            cmbGender.SelectedValue = "0";

            rgvMedicineDetails.DataSource = new object[] { };
            rgvMedicineDetails.DataBind();
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            DoctorPrescriptionView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void btnSearchEmployeee_Click(object sender, ImageClickEventArgs e)
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
                        //cmbState.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                        //cmbState_SelectedIndexChanged(null, null);
                        //cmbCity.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                        LabelDOB.Text = dtEmployeeDetails.Rows[0]["DOB"].ToString();
                        //string Services = dtEmployeeDetails.Rows[0]["Services"].ToString();

                        //LoadServicesBasedUponEmployee(Services);
                        Int32 CalDOBYear= Convert.ToDateTime(LabelDOB.Text).Year;
                        Int32 CalTodayYear = DateTime.Now.Year;
                        LabelAge.Text = Convert.ToInt32(CalTodayYear - CalDOBYear).ToString();
                    }

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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderLogin.Hide();
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

        protected void cmbCorporateBranchId_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SearchEmployeeDetailsList();
        }

        protected void rgvMedicineDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int rownumber;
                if (e.CommandName == "AddMedicineDetails")
                {
                    DataTable DtMedicineDetails = new DataTable();
                    if (Session["MedicineDetails"] == null || (Session["MedicineDetails"] as DataTable).Rows.Count <= 0)
                    {
                        DtMedicineDetails.Columns.Add("rownumber");
                        DtMedicineDetails.Columns.Add("PrescriptionId");
                        DtMedicineDetails.Columns.Add("MedicineName");

                        DtMedicineDetails.Columns.Add("MedicineTypeId");
                        DtMedicineDetails.Columns.Add("MedicineType");

                        DtMedicineDetails.Columns.Add("MedicineSessionId");
                        DtMedicineDetails.Columns.Add("MedicineSession");
                        DtMedicineDetails.Columns.Add("InTakeMethodId");
                        DtMedicineDetails.Columns.Add("InTakeMethod");

                        

                        DtMedicineDetails.Columns.Add("Remarks");

                        rownumber = 1;
                    }
                    else
                    {
                        DtMedicineDetails = Session["MedicineDetails"] as DataTable;
                        rownumber = (Convert.ToInt16(DtMedicineDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    GridFooterItem item = (GridFooterItem)e.Item;
                    RadTextBox txtMedicineName = (RadTextBox)item.FindControl("txtMedicineName");




                    RadComboBox cmbMedicineType = (RadComboBox)item.FindControl("cmbMedicineType");
                    //Label MedicineGenderId = (Label)item.FindControl("lblMedicineGenderId");
                    RadComboBox cmbMedicineSession = (RadComboBox)item.FindControl("cmbMedicineSession");
                    //Label cmbMedicineRelationShipId = (Label)item.FindControl("lblMedicineRelationShipId");
                    RadComboBox cmbInTakeMethod = (RadComboBox)item.FindControl("cmbInTakeMethod");

                    RadTextBox txtMedicineRemarks = (RadTextBox)item.FindControl("txtMedicineRemarks");

                    string MedicineSessionDetails = "";
                    string MedicineSessionDetailsText = "";

                    for (int i = 0; i < cmbMedicineSession.CheckedItems.Count; i++)
                    {
                        if (MedicineSessionDetailsText == "")
                        {
                            MedicineSessionDetailsText = cmbMedicineSession.CheckedItems[i].Text.Trim();
                        }
                        else
                        {
                            MedicineSessionDetailsText += "," + cmbMedicineSession.CheckedItems[i].Text.Trim();
                        }
                    }

                    for (int i = 0; i < cmbMedicineSession.CheckedItems.Count; i++)
                    {
                        if (MedicineSessionDetails == "")
                        {
                            MedicineSessionDetails = cmbMedicineSession.CheckedItems[i].Value.Trim();
                        }
                        else
                        {
                            MedicineSessionDetails += "," + cmbMedicineSession.CheckedItems[i].Value.Trim();
                        }
                    }



                    if (DtMedicineDetails != null && DtMedicineDetails.Rows.Count > 0)
                    {
                        rownumber = (Convert.ToInt16(DtMedicineDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    else
                    {
                        rownumber = 1;
                    }
                    bool ifExist = false;
                    foreach (DataRow dr in DtMedicineDetails.Rows)
                    {
                        if (dr["MedicineName"].ToString().ToUpper() == txtMedicineName.Text.Trim().ToUpper())

                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        DtMedicineDetails.Rows.Add(rownumber, Session["PrescriptionId"], txtMedicineName.Text.Trim(),
                            cmbMedicineType.SelectedValue, cmbMedicineType.Text, MedicineSessionDetails, MedicineSessionDetailsText, cmbInTakeMethod.SelectedValue, cmbInTakeMethod.Text, txtMedicineRemarks.Text.Trim());
                        Session["MedicineDetails"] = DtMedicineDetails;
                        rgvMedicineDetails.DataSource = Session["MedicineDetails"] as DataTable;
                        rgvMedicineDetails.DataBind();
                    }
                }


                if (e.CommandName == "DeleteMedicineDetails")
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblrownumber = (Label)rgvMedicineDetails.Items[intIndex].FindControl("lblrownumber");
                    //Label lblnewrows = (Label)rgvMedicineDetails.Items[intIndex].FindControl("lblnewrows");
                    //Label lblContactDetailsID = (Label)rgvMedicineDetails.Items[intIndex].FindControl("lblContactDetailsID");

                    //DataView DtAdditionalDetails = new DataView(Session["ElectiveSubject"] as DataTable);
                    DataTable DtAdditionalDetails = Session["MedicineDetails"] as DataTable;
                    if (Session["MedicineDetails"] != null)
                    {
                        if (Convert.ToInt16(lblrownumber.Text.Trim()) != 0)
                        {
                            DataRow[] dtRow = null;
                            dtRow = DtAdditionalDetails.Select("rownumber=" + lblrownumber.Text.Trim());
                            DtAdditionalDetails.Rows.Remove(dtRow[0]);
                            DtAdditionalDetails.AcceptChanges();
                            Session["MedicineDetails"] = DtAdditionalDetails;
                        }
                        else
                        {
                            //int facultyid = Convert.ToInt32(hfFacultyID.Value);
                            DataSet dsMedicineDetails = new DataSet();
                            //FacultyModule ObjMasterModule = new FacultyModule();
                            //dsAdditionalDetails = ObjMasterModule.fnDeleteAdditionalrecords(Convert.ToInt64(lblFacultyTrainingDetailsID.Text), facultyid);
                            if (dsMedicineDetails.Tables[0] != null && dsMedicineDetails.Tables[0].Rows.Count > 0)
                            {
                                Session["MedicineDetails"] = dsMedicineDetails.Tables[0];
                                rgvMedicineDetails.DataSource = Session["rgvMedicineDetails"] as DataTable;
                                rgvMedicineDetails.DataBind();
                            }
                        }
                    }
                    if (Session["MedicineDetails"] != null && (Session["MedicineDetails"] as DataTable).Rows.Count > 0)
                    {
                        rgvMedicineDetails.DataSource = Session["MedicineDetails"] as DataTable;
                        rgvMedicineDetails.DataBind();
                    }
                    else
                    {
                        rgvMedicineDetails.DataSource = string.Empty;
                        rgvMedicineDetails.DataBind();
                        rgvMedicineDetails.DataSource = Session["MedicineDetails"] as DataTable;
                        rgvMedicineDetails.DataBind();
                        rgvMedicineDetails.ShowFooter = true;
                    }
                }
            }


            catch (Exception ex)
            {

            }
        }

        protected void rgvMedicineDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvMedicineDetails_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void btnHistoryClose_Click(object sender, EventArgs e)
        {
            //ModalPopupExtenderHistory.Hide();
        }

        protected void rgvPatientHistory_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rgvPatientHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvPatientHistory_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void rgvMedicineHistory_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rgvMedicineHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvMedicineHistory_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void lnlPatientHistory_Click(object sender, EventArgs e)
        {
            //ModalPopupExtenderHistory.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
        }

       
        protected void lnkAddPrescription_Click(object sender, EventArgs e)
        {
            DoctorPrescriptionView.ActiveViewIndex = 1;
            btnSave.Text = "Save";
            ClearFields();
            Session["MedicineDetails"] = null;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void rgvMedicineDetailsList_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rgvMedicineDetailsList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvMedicineDetailsList_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void rgvPatientPrescriptionDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void rgvPatientPrescriptionDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rgvPatientPrescriptionDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void btnShow1_Click(object sender, EventArgs e)
        {

        }


        public string gridviewData(GridView GridView1)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            return sb.ToString();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Verifies that the control is rendered */
        }
        protected void btnPDFSave_Click(object sender, EventArgs e)
        {
            //bool showModal = true;

            //if (showModal)
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
            //foreach (GridDataItem item in rgvPatientPrescriptionDetails.MasterTableView.Items)
            //{
            //    //LabelDrName.Text = (item.FindControl("lblDoctorName") as Label).Text;
            //    //LabelDrRegnNo.Text = (item.FindControl("lblRegistrationNumber") as Label).Text;
            //    //LabelDrQualification.Text = (item.FindControl("lblDoctorQualification") as Label).Text;
            //    LabelDrContactNo.Text = (item.FindControl("lblContactNo") as Label).Text;
            //    LabelDrEmail.Text = (item.FindControl("lblDrEmailId") as Label).Text;
            //    LabelDrCity.Text = (item.FindControl("lblDrCity") as Label).Text;
            //    LabelDrAddress.Text = (item.FindControl("lblDoctorAddress") as Label).Text;

            //    LabelCorporateName.Text = (item.FindControl("lblCorporateName") as Label).Text;
            //    LabelPtName.Text = (item.FindControl("lblPtName") as Label).Text;
            //    LabelPtAge.Text = (item.FindControl("lblPtAge") as Label).Text;
            //    LabelPtContactNo.Text = (item.FindControl("lblPtMobileNo") as Label).Text;
            //    LabelPtEmail.Text = (item.FindControl("lblPtEmailId") as Label).Text;
            //    LabelPtCity.Text = (item.FindControl("lblPtCity") as Label).Text;
            //    LabelPtAddress.Text = (item.FindControl("lblPtAddress") as Label).Text;

            //    LabelSymptoms.Text = (item.FindControl("lblSymptoms") as Label).Text;
            //    LabelTestDetails.Text = (item.FindControl("lblTestDetails") as Label).Text;
            //    LabelPrescriptionDetails.Text = (item.FindControl("lblPrescriptionDetails") as Label).Text;
            //    LabelDietToBeFollow.Text = (item.FindControl("lblDietToBeFollow") as Label).Text;
            //    LabelNextVisitDate.Text = (item.FindControl("lblNextVisitDate") as Label).Text;

            //}

                LoadDoctorSignature();
                PDFSave();
                showPopup("Warning", "Patient Prescription Saved Successfully!");
                DeleteFile();

        }

        public void DeleteFile()
        {
            try
            {

                string FilePath = Session["FilePath"].ToString();
                string FileName = Session["FileName"].ToString();
                if (File.Exists(FilePath + "\\" + FileName))
                {
                    File.Delete(FilePath + "\\" + FileName);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LoadDoctorSignature()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorSignature = new DataTable();
            dtDoctorSignature = BusinessAccessLayer.LoadDoctorSignature(Convert.ToInt32(LabelDoctorID.Text));

            string ImagePath = AppDomain.CurrentDomain.BaseDirectory + "DoctorDocument";
            Session["Filepath"] = ImagePath;
            Byte[] byteData = null;
            string FileName = "";
            if (dtDoctorSignature != null && dtDoctorSignature.Rows.Count > 0)
            {
                Session["FileName"] = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                FileName = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                byteData = (Byte[])dtDoctorSignature.Rows[0]["DocumentContent"];
            }

            System.IO.File.WriteAllBytes(ImagePath + "\\" + FileName, byteData);
            LabelSignature.Text = ImagePath + "\\" + FileName;
            //DoctorSignature.ImageUrl = ImagePath + "\\" + FileName;

        }

        public void PDFSave()
        {
            
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    StringBuilder sb = new StringBuilder();
                    //E://Welleazy/Welleazy/DoctorDocument/image-logo-welnext.png

                    sb.Append("<br><br>");
                    sb.Append("<form id='form1' runat='server'>");
                    sb.Append("<table runat='server' border='1' style='width: 100 %; margin-top:30px; padding:20px; border: 1px solid #eeeaea;'><tr><td style='text-align:center;' colspan='4'><b> Patient Prescription </b></td></tr>");
                    sb.Append("<tr><td style = 'padding:5px; font-size: small;'> <b>Prescription No</b></td><td style = 'padding:5px; font-size: small;'>" + LabelPrescriptionNo.Text + "</td><td style = 'padding:5px; font-size: small;'> <b>Prescription Date</b></td><td style = 'padding:5px; font-size: small;'>" + LabelPrescriptionDate.Text + "</td></tr></table>");
                    sb.Append("<br>");
                    sb.Append("<table runat='server' border='1' style=' border: 1px solid #eeeaea; font-size: small;'>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='4'> <b>Doctor Information</b> </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px; text-align:center;' colspan='4'>" + LabelHospital.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Doctor Name </td><td style = 'padding:5px;'>" + LabelDrName.Text+ "</td> <td style = 'padding:5px;'> Dr Registration No </td><td style = 'padding:5px;'>" + LabelDrRegnNo.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Dr Qualification </td><td style = 'padding:5px;'>" + LabelDrQualification.Text + "</td> <td style = 'padding:5px;'> Dr Contact No </td><td style = 'padding:5px;'>" + LabelDrContactNo.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Dr Email </td><td style = 'padding:5px;'>" + LabelDrEmail.Text + "</td><td style = 'padding:5px;'> Dr City </td><td style = 'padding:5px;'>" + LabelDrCity.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Dr Address </td><td style = 'padding:5px;' colspan='3'>" + LabelDrAddress.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='4'> <b>Patient Information</b> </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> <b>Corporate Name</b> </td><td style = 'padding:5px;' colspan='3'><b>" + LabelCorporateName.Text + "</b></td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Patient Name </td><td style = 'padding:5px;'>"+LabelPtName.Text+"</td> <td style = 'padding:5px;'> Patient Age </td><td style = 'padding:5px;'>"+LabelPtAge.Text+"</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Patient Contact No </td><td style = 'padding:5px;'>" + LabelPtContactNo.Text + "</td> <td style = 'padding:5px;'> Patient Email </td><td style = 'padding:5px;'>" + LabelPtEmail.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Patient City </td><td style = 'padding:5px;'>" + LabelPtCity.Text + "</td> <td style = 'padding:5px;'> Patient Address </td><td style = 'padding:5px;'>" + LabelPtAddress.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='4'> <b>Drug Information</b> </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='4'> " + gridviewData(rgvMedicineDetailsView) + " </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='4'> </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> <b>Symptoms</b> </td><td style = 'padding:5px;'> <b>Test Details</b> </td> <td style = 'padding:5px;'> <b>Prescription Details</b> </td><td style = 'padding:5px;'> <b>Diet To Be Follow</b> </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'>" + LabelSymptoms.Text + "</td><td style = 'padding:5px;'>" + LabelTestDetails.Text + "</td> <td style = 'padding:5px;'>" + LabelPrescriptionDetails.Text + "</td><td style = 'padding:5px;'>" + LabelDietToBeFollow.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Next Visit Date </td><td style = 'padding:5px;' colspan='3'>" + LabelNextVisitDate.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='3'> </td><td style = 'padding:5px;'> Doctor Signature </td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;' colspan='3'> </td><td style = 'padding:5px;'> <img src='"+ LabelSignature.Text + "' height='30' weight='100' alt='Doctor Signature' /> </td></tr></table>");
                    sb.Append("</form>");

                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                    PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~/DoctorPrescription/PatientPrescription_" + LabelPtName.Text + "_" + LabelPrescriptionNo.Text + ".pdf"), FileMode.Create));
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                }
            }
        }
    }
}