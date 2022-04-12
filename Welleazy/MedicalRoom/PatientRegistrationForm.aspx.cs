using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.MedicalRoom
{


    public partial class PatientRegistrationForm : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PatientRegistrationView.ActiveViewIndex = 0;
                LoadGender();
                LoadMedicines();
                LoadPatientRegistrationDetails();
                rgvMedicineDetails.DataSource = new object[] { };
                rgvMedicineDetails.DataBind();

                
            }
        }

        public void LoadPatientRegistrationDetails()
        {
            try
            {


                Bal BusinessAccessLayer = new Bal();
                DataTable dtLoadPatientRegistrationDetails = new DataTable();
                dtLoadPatientRegistrationDetails = BusinessAccessLayer.LoadPatientRegistrationDetails();

                if (dtLoadPatientRegistrationDetails != null && dtLoadPatientRegistrationDetails.Rows.Count > 0)
                {
                    rgvPatientDetails.DataSource = dtLoadPatientRegistrationDetails;
                    rgvPatientDetails.DataBind();
                }
                else
                {
                    rgvPatientDetails.DataSource = new object[] { };
                    rgvPatientDetails.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void LoadMedicines()
        {
            DataTable dtMedicineDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtMedicineDetails = BusinessAccessLayer.LoadMedicineDropDown();

            if (dtMedicineDetails != null && dtMedicineDetails.Rows.Count > 0)

            {

                ViewState["MedicineDetails"] = dtMedicineDetails;
                //cmb.DataSource = dtMedicineDetails;
                //cmbGender.DataTextField = "ItemDescription";
                //cmbGender.DataValueField = "InventoryId";
                //cmbGender.DataBind();
            }
        }

        public void LoadGender()
        {
            DataTable dtGenderDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtGenderDetails = BusinessAccessLayer.LoadGenderDropDown();

            if (dtGenderDetails != null && dtGenderDetails.Rows.Count > 0)

            {
                
                cmbGender.DataSource = dtGenderDetails;
                cmbGender.DataTextField = "Description";
                cmbGender.DataValueField = "GenderId";
                cmbGender.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();

            DataTable dtMedicineDetails = new DataTable();
            dtMedicineDetails = Session["MedicineDetails"] as DataTable;

            if (dtMedicineDetails != null && dtMedicineDetails.Rows.Count > 0)
            {

                if (dtMedicineDetails.Columns.Contains("rownumber"))
                {
                    dtMedicineDetails.Columns.Remove("rownumber");
                }

               
            }

            try
            {
                if(btnSave.Text.Equals("Save"))
                {
                    BusinessAccessLayer.InsertUpdatePatientRegistrationDetails(txtEmployeeCode.Text.Trim(), txtEmployeeName.Text.Trim(), dtpDOB.DateInput.SelectedDate.Equals(null) ? nul : dtpDOB.DateInput.SelectedDate.Value, Convert.ToInt32(cmbGender.SelectedValue), Convert.ToInt32(cmbDepartment.SelectedValue), txtMobileNo.Text.Trim(), txtEmailId.Text.Trim(), dtpVisitDateTime.DateInput.SelectedDate.Equals(null) ? nul : dtpVisitDateTime.DateInput.SelectedDate.Value,txtDiagnosis.Text.Trim(),txtAdviceGiven.Text.Trim(),txtDoctorName.Text.Trim(),dtMedicineDetails, Convert.ToInt32(Session["LoginRefId"]));
                }
                else
                {

                }
                ClearFields();
            }
            catch(Exception ex)
            {

            }
        }

        public void ClearFields()
        {
            txtEmployeeCode.Text = "";
            txtEmployeeName.Text = "";
            txtEmailId.Text = "";
            txtMobileNo.Text = "";
            dtpDOB.DateInput.Text = "";
            dtpVisitDateTime.DateInput.Text = "";
            txtDoctorName.Text = "";
            txtDiagnosis.Text = "";
            txtAdviceGiven.Text = "";
            dtpDOB.DbSelectedDate = null;
            dtpVisitDateTime.DbSelectedDate = null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PatientRegistrationView.ActiveViewIndex = 0;
            ClearFields();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
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
                        DtMedicineDetails.Columns.Add("MedicineId");
                        DtMedicineDetails.Columns.Add("MedicineDescription");
                        DtMedicineDetails.Columns.Add("Quantity");
                        
                        rownumber = 1;
                    }
                    else
                    {
                        DtMedicineDetails = Session["MedicineDetails"] as DataTable;
                        rownumber = (Convert.ToInt16(DtMedicineDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    GridFooterItem item = (GridFooterItem)e.Item;
                    RadTextBox txtQuantity = (RadTextBox)item.FindControl("txtQuantity");
                    

                    RadComboBox cmbMedicine = (RadComboBox)item.FindControl("cmbMedicine");
                    
                    

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
                        if (dr["MedicineDescription"].ToString().ToUpper() == cmbMedicine.Text.Trim().ToUpper()
                            && dr["Quantity"].ToString().ToUpper() == txtQuantity.Text.Trim().ToUpper())
                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        DtMedicineDetails.Rows.Add(rownumber, cmbMedicine.SelectedValue,cmbMedicine.Text, txtQuantity.Text.Trim());
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
            try
            {
                if (e.Item is GridFooterItem)
                {
                    GridFooterItem item = (GridFooterItem)e.Item;

                    RadComboBox cmbMedicine = (item.FindControl("cmbMedicine") as RadComboBox);


                    cmbMedicine.DataSource = ViewState["MedicineDetails"];
                    cmbMedicine.DataTextField = "MedicineDescription";
                    cmbMedicine.DataValueField = "MedicineId";
                    cmbMedicine.DataBind();

                    

                    



                    
                    //ViewState[""]
                    //ViewState["ConsultationType"]
                    //ViewState["MasterLanguage"];
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkbtnPatientRegistration_Click(object sender, EventArgs e)
        {
            PatientRegistrationView.ActiveViewIndex = 1;
            ClearFields();
        }

        protected void rgvPatientDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void rgvPatientDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditRow"))
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblPatientRegistrationFormId = (Label)rgvPatientDetails.Items[intIndex % 10].FindControl("lblPatientRegistrationFormId"); // % 15 for page indexing

                    LoadPatientRegistrationDetailsById(Convert.ToInt32(lblPatientRegistrationFormId.Text.Trim()));
                    PatientRegistrationView.ActiveViewIndex = 1;
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void LoadPatientRegistrationDetailsById(Int32 PatientRegistrationFormId)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLoadPatientDetails = new DataTable();
            dtLoadPatientDetails = BusinessAccessLayer.LoadPatientRegistrationDetailsById(PatientRegistrationFormId);

            if(dtLoadPatientDetails!=null && dtLoadPatientDetails.Rows.Count>0)
            {
                txtEmployeeName.Text = dtLoadPatientDetails.Rows[0]["EmployeeName"].ToString();
                txtEmployeeCode.Text = dtLoadPatientDetails.Rows[0]["EmployeeCode"].ToString();
                dtpDOB.DbSelectedDate = dtLoadPatientDetails.Rows[0]["DateOfBirth"].ToString();
                txtMobileNo.Text = dtLoadPatientDetails.Rows[0]["MobileNo"].ToString();
                txtEmailId.Text = dtLoadPatientDetails.Rows[0]["EmailId"].ToString();
            }

        }

        protected void rgvPatientDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }
    }
}