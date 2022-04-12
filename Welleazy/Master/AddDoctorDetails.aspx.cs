using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Master
{
    public partial class AddDoctorDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DoctorView.ActiveViewIndex = 0;

                LoadState();
                FetchDoctorDetails();
                LoadMasterLanguage();
                LoadMasterDoctorDocument();
                rgDoctorDocumentDetails.DataSource = new object[] { };
                rgDoctorDocumentDetails.DataBind();
            }
        }

        public void LoadMasterDoctorDocument()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorDocument = new DataTable();
            dtDoctorDocument = BusinessAccessLayer.LoadMasterDoctorDocumentDropDown();

            if (dtDoctorDocument != null && dtDoctorDocument.Rows.Count > 0)
            {

                ViewState["MasterDoctorDocument"] = dtDoctorDocument;

            }
            else
            {

            }
        }

        public void LoadMasterLanguage()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = BusinessAccessLayer.LoadMasterLanguageDropDown();

            if (dtLanguage != null && dtLanguage.Rows.Count > 0)
            {
                cmbLanguage.DataSource = dtLanguage;
                cmbLanguage.DataTextField = "LanguageDescription";
                cmbLanguage.DataValueField = "LanguageId";
                cmbLanguage.DataBind();


            }
            else
            {
                cmbLanguage.DataSource = null;
                cmbLanguage.DataBind();


            }
        }

        public void LoadState()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                cmbState.DataSource = dtState;
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
            }
        }

        public void FetchDoctorDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.FetchDoctorDetails();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                rgvDoctorDetails.DataSource = dtState;

                rgvDoctorDetails.DataBind();
            }
            else
            {
                rgvDoctorDetails.DataSource = null;
                rgvDoctorDetails.DataBind();
            }
        }

        protected void btnAddDoctor_Click(object sender, EventArgs e)
        {
            DoctorView.ActiveViewIndex = 1;
            ClearFields();
        }

        protected void rgvDoctorDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblDoctorId = (Label)rgvDoctorDetails.Items[intIndex % 10].FindControl("lblDoctorId"); // % 15 for page indexing
                Variables.DoctorId = Convert.ToInt32(lblDoctorId.Text.Trim());
                LoadDoctorDetailsById();

                btnSave.Text = "Update";


                DoctorView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {


            }
        }

        public void LoadDoctorDetailsById()
        {
            Bal BusinessAccessLayer = new Bal();
            DataSet dtDoctorDetails = new DataSet();
            dtDoctorDetails = BusinessAccessLayer.FetchDoctorDetailsById(Variables.DoctorId);
            LoadMasterLanguage();
            if (dtDoctorDetails != null && dtDoctorDetails.Tables[0].Rows.Count > 0)
            {
                txtDoctorName.Text = dtDoctorDetails.Tables[0].Rows[0]["DoctorName"].ToString();
                txtContactNo.Text = dtDoctorDetails.Tables[0].Rows[0]["ContactNo"].ToString();
                txtAlternateContactNo.Text = dtDoctorDetails.Tables[0].Rows[0]["AlternateContactNo"].ToString();
                txtEmailId.Text = dtDoctorDetails.Tables[0].Rows[0]["EmailId"].ToString();

                //cmbLanguage.SelectedValue = dtDoctorDetails.Rows[0]["DoctorLanguage"].ToString();


                string DoctorLanguage = dtDoctorDetails.Tables[0].Rows[0]["DoctorLanguage"].ToString(); ;

                String[] DoctorValue = DoctorLanguage.Split(',');

                // int lenght2 = ServicesValue.Length;

                foreach (string s in DoctorValue)
                {
                    foreach (RadComboBoxItem item in cmbLanguage.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

                cmbQualification.SelectedValue = dtDoctorDetails.Tables[0].Rows[0]["DoctorQualification"].ToString();

                txtRegistrationNo.Text = dtDoctorDetails.Tables[0].Rows[0]["RegistrationNumber"].ToString();
                txtPANCardNo.Text = dtDoctorDetails.Tables[0].Rows[0]["PANCard"].ToString();
                txtAddress.Text = dtDoctorDetails.Tables[0].Rows[0]["DoctorAddress"].ToString();

                cmbState.SelectedValue = dtDoctorDetails.Tables[0].Rows[0]["StateId"].ToString();
                cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = dtDoctorDetails.Tables[0].Rows[0]["DistrictId"].ToString();

                txtArea.Text = dtDoctorDetails.Tables[0].Rows[0]["Area"].ToString();
                txtTeleMERRate.Text = dtDoctorDetails.Tables[0].Rows[0]["TeleMERRate"].ToString();
                txtVideoMERRate.Text = dtDoctorDetails.Tables[0].Rows[0]["TeleVideoRate"].ToString();

                if (dtDoctorDetails.Tables[0].Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }

                txtAccountNumber.Text = dtDoctorDetails.Tables[0].Rows[0]["AccountNumber"].ToString();
                txtBankName.Text = dtDoctorDetails.Tables[0].Rows[0]["BankName"].ToString();
                txtAccountHolderName.Text = dtDoctorDetails.Tables[0].Rows[0]["AccountHolderName"].ToString();
                txtBankBranch.Text = dtDoctorDetails.Tables[0].Rows[0]["BankBranch"].ToString();
                txtIFSCCode.Text = dtDoctorDetails.Tables[0].Rows[0]["IFSCCode"].ToString();
            }

            if (dtDoctorDetails != null && dtDoctorDetails.Tables[1].Rows.Count > 0)
            {
                Session["DocumentDetails"] = dtDoctorDetails.Tables[1];
                rgDoctorDocumentDetails.DataSource = dtDoctorDetails.Tables[1];
                rgDoctorDocumentDetails.DataBind();
            }
            else
            {
                rgDoctorDocumentDetails.DataSource = new object[] { };
                rgDoctorDocumentDetails.DataBind();
            }
        }

        protected void rgvDoctorDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.FetchDoctorDetails();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                rgvDoctorDetails.DataSource = dtState;

                //rgvDoctorDetails.DataBind();
            }
            else
            {
                rgvDoctorDetails.DataSource = null;
                //rgvDoctorDetails.DataBind();
            }
        }

        protected void rgvDoctorDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgDoctorDocumentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int rownumber;
                if (e.CommandName == "AddDocumentDetails")
                {
                    DataTable DtDocumentDetails = new DataTable();
                    if (Session["DocumentDetails"] == null || (Session["DocumentDetails"] as DataTable).Rows.Count <= 0)
                    {
                        DtDocumentDetails.Columns.Add("rownumber", typeof(int));
                        DtDocumentDetails.Columns.Add("DocumentId", typeof(int));
                        DtDocumentDetails.Columns.Add("DocumentName", typeof(string));
                        DtDocumentDetails.Columns.Add("DocumentContent", typeof(Byte[]));


                        rownumber = 1;
                    }
                    else
                    {
                        DtDocumentDetails = Session["DocumentDetails"] as DataTable;
                        rownumber = (Convert.ToInt16(DtDocumentDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    GridFooterItem item = (GridFooterItem)e.Item;
                    //RadLabel lblDocumentName = (RadLabel)item.FindControl("lblDocumentName");
                    RadComboBox cmbDocumentName = (RadComboBox)item.FindControl("cmbDocumentName");

                    RadAsyncUpload raUploadDocument = (RadAsyncUpload)item.FindControl("raUploadDocument");


                    if (DtDocumentDetails != null && DtDocumentDetails.Rows.Count > 0)
                    {
                        rownumber = (Convert.ToInt16(DtDocumentDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    else
                    {
                        rownumber = 1;
                    }
                    bool ifExist = false;
                    foreach (DataRow dr in DtDocumentDetails.Rows)
                    {
                        if (dr["DocumentName"].ToString().ToUpper() == cmbDocumentName.Text.Trim().ToUpper())
                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        Stream fs = raUploadDocument.UploadedFiles[0].InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] byteDocumentData = new Byte[5242880];
                        byteDocumentData = br.ReadBytes((Int32)fs.Length);
                        string DocumentName = raUploadDocument.UploadedFiles[0].FileName;
                        //String targetFolder = Server.MapPath("~/AppointmentReports/");

                        DtDocumentDetails.Rows.Add(rownumber, cmbDocumentName.SelectedValue, DocumentName, byteDocumentData);

                        Session["DocumentDetails"] = DtDocumentDetails;
                        rgDoctorDocumentDetails.DataSource = Session["DocumentDetails"] as DataTable;
                        rgDoctorDocumentDetails.DataBind();
                    }
                }


                if (e.CommandName == "DeleteDocumentDetails")
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblrownumber = (Label)rgDoctorDocumentDetails.Items[intIndex].FindControl("lblrownumber");
                    //Label lblnewrows = (Label)rgDoctorDocumentDetails.Items[intIndex].FindControl("lblnewrows");
                    //Label lblContactDetailsID = (Label)rgDoctorDocumentDetails.Items[intIndex].FindControl("lblContactDetailsID");

                    //DataView DtAdditionalDetails = new DataView(Session["ElectiveSubject"] as DataTable);
                    DataTable DtAdditionalDetails = Session["DocumentDetails"] as DataTable;
                    if (Session["DocumentDetails"] != null)
                    {
                        if (Convert.ToInt16(lblrownumber.Text.Trim()) != 0)
                        {
                            DataRow[] dtRow = null;
                            dtRow = DtAdditionalDetails.Select("rownumber=" + lblrownumber.Text.Trim());
                            DtAdditionalDetails.Rows.Remove(dtRow[0]);
                            DtAdditionalDetails.AcceptChanges();
                            Session["DocumentDetails"] = DtAdditionalDetails;
                        }
                        else
                        {
                            //int facultyid = Convert.ToInt32(hfFacultyID.Value);
                            DataSet dsDocumentDetails = new DataSet();
                            //FacultyModule ObjMasterModule = new FacultyModule();
                            //dsAdditionalDetails = ObjMasterModule.fnDeleteAdditionalrecords(Convert.ToInt64(lblFacultyTrainingDetailsID.Text), facultyid);
                            if (dsDocumentDetails.Tables[0] != null && dsDocumentDetails.Tables[0].Rows.Count > 0)
                            {
                                Session["DocumentDetails"] = dsDocumentDetails.Tables[0];
                                rgDoctorDocumentDetails.DataSource = Session["rgDoctorDocumentDetails"] as DataTable;
                                rgDoctorDocumentDetails.DataBind();
                            }
                        }
                    }
                    if (Session["DocumentDetails"] != null && (Session["DocumentDetails"] as DataTable).Rows.Count > 0)
                    {
                        rgDoctorDocumentDetails.DataSource = Session["DocumentDetails"] as DataTable;
                        rgDoctorDocumentDetails.DataBind();
                    }
                    else
                    {
                        rgDoctorDocumentDetails.DataSource = string.Empty;
                        rgDoctorDocumentDetails.DataBind();
                        rgDoctorDocumentDetails.DataSource = Session["DocumentDetails"] as DataTable;
                        rgDoctorDocumentDetails.DataBind();
                        rgDoctorDocumentDetails.ShowFooter = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rgDoctorDocumentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            double TeleMERRate = 0.0;
            double VideoMERRate = 0.0;

            if (!txtTeleMERRate.Text.Trim().Equals(""))
            {
                TeleMERRate = Convert.ToDouble(txtTeleMERRate.Text.Trim());
            }

            if (!txtVideoMERRate.Text.Trim().Equals(""))
            {
                VideoMERRate = Convert.ToDouble(txtVideoMERRate.Text.Trim());
            }

            try
            {
                string PrefferedLanguage = "";

                for (int i = 0; i < cmbLanguage.CheckedItems.Count; i++)
                {
                    if (PrefferedLanguage == "")
                    {
                        PrefferedLanguage = cmbLanguage.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        PrefferedLanguage += "," + cmbLanguage.CheckedItems[i].Value.Trim();
                    }
                }


                //foreach (GridDataItem item in rgDoctorDocumentDetails.MasterTableView.Items)
                //{

                //    Bal Business_Access_Layer = new Bal();
                //    DataTable dtDocumentDetails = new DataTable();


                //    dtDocumentDetails.Columns.Add("DocumentName",typeof(string));
                //    dtDocumentDetails.Columns.Add("DocumentContent",typeof(Byte[]));





                //    string cmbDocumentName = (item.FindControl("lblDocumentName") as Label).Text;
                //    string DocumentContent = (item.FindControl("lblDocument") as Label).Text;

                //    //RadAsyncUpload raUploadDocument = (item.FindControl("raUploadDocument") as RadAsyncUpload);

                //    //Stream fs = raUploadDocument.UploadedFiles[0].InputStream;
                //    //BinaryReader br = new BinaryReader(fs);
                //    //Byte[] byteDocumentData = new Byte[5242880];
                //    //byteDocumentData = br.ReadBytes((Int32)fs.Length);
                //    //string DocumentName = raUploadDocument.UploadedFiles[0].FileName;
                //    //String targetFolder = Server.MapPath("~/AppointmentReports/");

                //    dtDocumentDetails.Rows.Add(cmbDocumentName, DocumentContent);













                //}
                DataTable dtDoctorDocument = new DataTable();

                dtDoctorDocument = Session["DocumentDetails"] as DataTable;

                dtDoctorDocument.Columns.Remove("rownumber");

                dtDoctorDocument.AcceptChanges();


                if (btnSave.Text.Equals("Save"))
                {

                    BusinessAccessLayer.InsertUpdateDoctorDetails(0, txtDoctorName.Text.Trim(), txtEmailId.Text.Trim(), txtContactNo.Text.Trim(), txtAlternateContactNo.Text.Trim(),
                        PrefferedLanguage, Convert.ToInt32(cmbQualification.SelectedValue), txtRegistrationNo.Text.Trim(), txtPANCardNo.Text.Trim()
                        , txtAddress.Text.Trim(), Convert.ToInt32(cmbState.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), txtArea.Text.Trim(), TeleMERRate, VideoMERRate,
                        txtAccountNumber.Text.Trim(), txtBankName.Text.Trim(), txtAccountHolderName.Text.Trim(), txtBankBranch.Text.Trim(),
                        txtIFSCCode.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"])
                        , dtDoctorDocument, out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Data Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Data Saved Successfully");
                    }
                }
                else
                {
                    BusinessAccessLayer.InsertUpdateDoctorDetails(Variables.DoctorId, txtDoctorName.Text.Trim(), txtEmailId.Text.Trim(), txtContactNo.Text.Trim(), txtAlternateContactNo.Text.Trim(),
                        PrefferedLanguage, Convert.ToInt32(cmbQualification.SelectedValue), txtRegistrationNo.Text.Trim(), txtPANCardNo.Text.Trim()
                        , txtAddress.Text.Trim(), Convert.ToInt32(cmbState.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), txtArea.Text.Trim(), TeleMERRate, VideoMERRate,
                        txtAccountNumber.Text.Trim(), txtBankName.Text.Trim(), txtAccountHolderName.Text.Trim(), txtBankBranch.Text.Trim(),
                        txtIFSCCode.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), Convert.ToInt32(Session["LoginRefId"])
                        , dtDoctorDocument, out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Data Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Data Updated Successfully");

                    }
                }
                //ClearFields();

                //if (Session["RoleId"].ToString().Equals("1"))
                //{
                //    //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
                //}
                //else
                {
                    ClearFields();
                    FetchDoctorDetails();
                    //LoadDoctorDetails();
                    DoctorView.ActiveViewIndex = 0;
                    rgDoctorDocumentDetails.DataSource = new object[] { };
                    rgDoctorDocumentDetails.DataBind();

                    //rgCorporateContactDetails.DataSource = new object[] { };
                    //rgCorporateContactDetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }



        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DoctorView.ActiveViewIndex = 0;
            ClearFields();

        }

        public void ClearFields()
        {
            txtDoctorName.Text = "";
            txtContactNo.Text = "";
            txtAlternateContactNo.Text = "";
            txtEmailId.Text = "";
            txtAccountNumber.Text = "";
            txtAccountHolderName.Text = "";
            txtBankName.Text = "";
            txtBankBranch.Text = "";
            txtArea.Text = "";
            txtAddress.Text = "";

            txtRegistrationNo.Text = "";
            txtPANCardNo.Text = "";
            txtIFSCCode.Text = "";

            txtTeleMERRate.Text = "";
            txtVideoMERRate.Text = "";


            cmbQualification.ClearSelection();
            //cmbLanguage.ClearSelection();
            cmbLanguage.ClearCheckedItems();
            cmbLanguage.EnableCheckAllItemsCheckBox = true;
            cmbState.ClearSelection();
            cmbCity.ClearSelection();
            btnSave.Text = "Save";

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

        protected void rgDoctorDocumentDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridFooterItem)
                {
                    GridFooterItem item = (GridFooterItem)e.Item;

                    RadComboBox cmbDocumentName = (item.FindControl("cmbDocumentName") as RadComboBox);


                    cmbDocumentName.DataSource = ViewState["MasterDoctorDocument"];
                    cmbDocumentName.DataTextField = "DocumentName";
                    cmbDocumentName.DataValueField = "DocumentId";
                    cmbDocumentName.DataBind();






                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}