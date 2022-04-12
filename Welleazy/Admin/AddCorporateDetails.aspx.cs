using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy
{
    public partial class AddCorporateDetails : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadCorporateDetails();
                    if (!Session["CorporateId"].ToString().Equals("0"))
                    {
                        StateList();
                        CorporateList();
                        btnCorporate.Visible = false;
                        CorporateView.ActiveViewIndex = 1;
                        btnCorporate.Visible = false;
                        Variables.CorporateId = Convert.ToInt32(Session["CorporateId"].ToString());
                        txtCorporateName.Enabled = false;
                        txtEmailid.Enabled = false;
                        txtHeadOfficeAddress.Enabled = false;
                        txtBranchOfficeAddress.Enabled = false;
                        //txtLandLineNo.Enabled = false;
                        rbIsActive.Enabled = false;

                        LoadCorporateDetailsById();
                        SearchButton.Visible = false;
                        SearchField.Visible = false;

                    }
                    else
                    {
                        StateList();
                        CorporateList();
                        rbIsActive.Enabled = true;
                        btnCorporate.Visible = true;
                        txtCorporateName.Enabled = true;
                        txtEmailid.Enabled = true;
                        txtHeadOfficeAddress.Enabled = true;
                        txtBranchOfficeAddress.Enabled = true;
                        txtLandLineNo.Enabled = true;


                        CorporateView.ActiveViewIndex = 0;
                        btnCorporate.Visible = true;
                        Session["AdditionalDetails"] = null;

                        rgCorporateContactDetails.DataSource = new object[] { };
                        rgCorporateContactDetails.DataBind();


                        Session["AdditionalBranchDetails"] = null;

                        rgCorporateBranchDetails.DataSource = new object[] { };
                        rgCorporateBranchDetails.DataBind();

                        //rgDocumentDetails.DataSource = new object[] { };
                        //rgDocumentDetails.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Session has Expired..!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
                }

            }
        }

        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                ViewState["MasterState"] = dtState;
                //rcbState.DataSource = dtState;
                //rcbState.DataTextField = "StateName";
                //rcbState.DataValueField = "StateId";
                //rcbState.DataBind();
            }
            
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {

                rcbCorporate.DataSource = dtLoadCorporateList;
                rcbCorporate.DataTextField = "CorporateName";
                rcbCorporate.DataValueField = "CorporateId";
                rcbCorporate.DataBind();

            }
            else
            {

                rcbCorporate.DataSource = new object[] { }; ;
                rcbCorporate.DataBind();
            }
        }

        public void LoadCorporateDetails()
        {
            DataTable dtCorporateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetails(Convert.ToInt32(Session["CorporateId"]));

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                rgvCorporateDetails.DataSource = dtCorporateDetails;
                rgvCorporateDetails.DataBind();
            }
            else
            {
                rgvCorporateDetails.DataSource = null;
                rgvCorporateDetails.DataBind();
            }
        }

        protected void rgvCorporateDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvCorporateDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCorporateId = (Label)rgvCorporateDetails.Items[intIndex % 10].FindControl("lblCorporateId"); // % 15 for page indexing
                    Variables.CorporateId = Convert.ToInt32(lblCorporateId.Text.Trim());
                    LoadCorporateDetailsById();
                    CorporateView.ActiveViewIndex = 1;
                    btnCorporate.Visible = false;
                    btnSave.Text = "Update";


                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.ToString());
                }
            }
        }

        public void LoadCorporateDetailsById()
        {
            DataSet dtCorporateDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsById(Variables.CorporateId);


            if (dtCorporateDetails != null && dtCorporateDetails.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";
                txtCorporateName.Text = dtCorporateDetails.Tables[0].Rows[0]["CorporateName"].ToString();
                txtMobileNo.Text = dtCorporateDetails.Tables[0].Rows[0]["MobileNo"].ToString();
                txtLandLineNo.Text = dtCorporateDetails.Tables[0].Rows[0]["LandLineNo"].ToString();
                txtEmailid.Text = dtCorporateDetails.Tables[0].Rows[0]["Emailid"].ToString();
                txtHeadOfficeAddress.Text = dtCorporateDetails.Tables[0].Rows[0]["HeadOfficeAddress"].ToString();
                txtBranchOfficeAddress.Text = dtCorporateDetails.Tables[0].Rows[0]["BranchOfficeAddress"].ToString();

                cmbInsuranceStatus.SelectedValue = dtCorporateDetails.Tables[0].Rows[0]["InsuranceStatus"].ToString();
                dtpAgreementDate.DbSelectedDate = dtCorporateDetails.Tables[0].Rows[0]["AgreementDate"].ToString();
                dtpExpiryDate.DbSelectedDate = dtCorporateDetails.Tables[0].Rows[0]["ExpiryDate"].ToString();

                if (dtCorporateDetails.Tables[0].Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }

            if (dtCorporateDetails != null && dtCorporateDetails.Tables[1].Rows.Count > 0)
            {
                rgCorporateContactDetails.DataSource = dtCorporateDetails.Tables[1];
                rgCorporateContactDetails.DataBind();
                //Changes Done hide the session line
                Session["AdditionalDetails"] = dtCorporateDetails.Tables[1];
            }
            else
            {
                rgCorporateContactDetails.DataSource = new object[] { };
                rgCorporateContactDetails.DataBind();
                //Changes Done
                //rgCorporateContactDetails.DataSource = new object[] { };
                //rgCorporateContactDetails.DataBind();
            }

            //Branch Details
            if (dtCorporateDetails != null && dtCorporateDetails.Tables[2].Rows.Count > 0)
            {
                rgCorporateBranchDetails.DataSource = dtCorporateDetails.Tables[2];
                rgCorporateBranchDetails.DataBind();
                
                //Changes Done hide the session line
                Session["AdditionalBranchDetails"] = dtCorporateDetails.Tables[2];
            }
            else
            {

                rgCorporateBranchDetails.DataSource = new object[] { };
                rgCorporateBranchDetails.DataBind();
                //rgCorporateBranchDetails.DataSource = null;
                //rgCorporateBranchDetails.DataBind();
                //Changes Done
                //rgCorporateContactDetails.DataSource = new object[] { };
                //rgCorporateContactDetails.DataBind();
            }

            if (dtCorporateDetails != null && dtCorporateDetails.Tables[3].Rows.Count > 0)
            {
                rgDocumentDetails.DataSource = dtCorporateDetails.Tables[3];
                rgDocumentDetails.DataBind();

                //Session["AdditionalDetails"] = dtCorporateDetails.Tables[3];
            }
            else
            {
                rgDocumentDetails.DataSource = new object[] { }; //null;
                rgDocumentDetails.DataBind();
            }


        }

        protected void rgvCorporateDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string emailid = txtEmailid.Text.Trim();

                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                DataTable result = new DataTable();
                SqlCommand cmd = new SqlCommand("select substring('" + emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
                var adapter = new SqlDataAdapter(cmd);

                adapter.Fill(result);

                if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in") || result.Rows[0]["Ext"].Equals("net") || result.Rows[0]["Ext"].Equals("edu") || result.Rows[0]["Ext"].Equals("org"))
                {
                    lblEmailError.Text = "";

                    DataTable dtContactDetails = new DataTable();
                    dtContactDetails = Session["AdditionalDetails"] as DataTable;

                    if (dtContactDetails != null && dtContactDetails.Rows.Count > 0)
                    {

                        if (dtContactDetails.Columns.Contains("rownumber"))
                        {
                            dtContactDetails.Columns.Remove("rownumber");
                        }

                        if (dtContactDetails.Columns.Contains("ContactDetailsId"))
                        {
                            dtContactDetails.Columns.Remove("ContactDetailsId");
                        }

                        if (dtContactDetails.Columns.Contains("newrow"))
                        {
                            dtContactDetails.Columns.Remove("newrow");
                        }
                    }

                    DataTable dtBranchDetails = new DataTable();
                    dtBranchDetails = Session["AdditionalBranchDetails"] as DataTable;

                    if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
                    {

                        if (dtBranchDetails.Columns.Contains("rownumber"))
                        {
                            dtBranchDetails.Columns.Remove("rownumber");
                        }

                        if (dtBranchDetails.Columns.Contains("State"))
                        {
                            dtBranchDetails.Columns.Remove("State");
                        }

                        if (dtBranchDetails.Columns.Contains("City"))
                        {
                            dtBranchDetails.Columns.Remove("City");
                        }

                        if (dtBranchDetails.Columns.Contains("StateName"))
                        {
                            dtBranchDetails.Columns.Remove("StateName");
                        }

                        if (dtBranchDetails.Columns.Contains("DistrictName"))
                        {
                            dtBranchDetails.Columns.Remove("DistrictName");
                        }


                        //if (dtBranchDetails.Columns.Contains("BranchDetailsId"))
                        //{
                        //    dtBranchDetails.Columns.Remove("BranchDetailsId");
                        //}

                        if (dtBranchDetails.Columns.Contains("newrow"))
                        {
                            dtBranchDetails.Columns.Remove("newrow");
                        }
                    }

                    DataTable dtDocumentDetails = new DataTable();


                    dtDocumentDetails.Columns.Add("DocumentName", typeof(string));
                    dtDocumentDetails.Columns.Add("Document", typeof(Byte[]));



                    //RadUpload document = (RadUpload)item.FindControl("RadUpldDocuments");

                    for (int i = 0; i < RadUpldDocuments.UploadedFiles.Count; i++)
                    {
                        Stream fs = RadUpldDocuments.UploadedFiles[i].InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] byteDocumentData = new Byte[5242880];
                        byteDocumentData = br.ReadBytes((Int32)fs.Length);
                        string DocumentName = RadUpldDocuments.UploadedFiles[i].FileName;

                        dtDocumentDetails.Rows.Add(DocumentName, byteDocumentData);
                    }




                    Bal BusinessAccessLayer = new Bal();
                    string IsDataExists = "0";
                    if (btnSave.Text.Equals("Save"))
                    {
                        BusinessAccessLayer.InsertUpdateCorporateDetails(0, txtCorporateName.Text.Trim(), txtMobileNo.Text.Trim(), txtLandLineNo.Text.Trim(),
                            txtEmailid.Text.Trim(), txtHeadOfficeAddress.Text.Trim(), txtBranchOfficeAddress.Text.Trim(), dtContactDetails,
                            dtDocumentDetails, Convert.ToInt32(rbIsActive.SelectedValue), cmbInsuranceStatus.SelectedValue,
                            dtpAgreementDate.DateInput.SelectedDate.Equals(null) ? nul : dtpAgreementDate.DateInput.SelectedDate.Value,
                            dtpExpiryDate.SelectedDate.Equals(null) ? nul : dtpExpiryDate.DateInput.SelectedDate.Value,
                            Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
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
                        BusinessAccessLayer.InsertUpdateCorporateDetails(Variables.CorporateId, txtCorporateName.Text.Trim(), txtMobileNo.Text.Trim(), txtLandLineNo.Text.Trim(),
                            txtEmailid.Text.Trim(), txtHeadOfficeAddress.Text.Trim(), txtBranchOfficeAddress.Text.Trim(), dtContactDetails,
                            dtDocumentDetails, Convert.ToInt32(rbIsActive.SelectedValue), cmbInsuranceStatus.SelectedValue,
                            dtpAgreementDate.DateInput.SelectedDate.Equals(null) ? nul : dtpAgreementDate.DateInput.SelectedDate.Value,
                            dtpExpiryDate.SelectedDate.Equals(null) ? nul : dtpExpiryDate.DateInput.SelectedDate.Value,
                            Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
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

                    if (!Session["CorporateId"].ToString().Equals("0"))
                    {
                        ClearFields();
                        CorporateView.ActiveViewIndex = 0;
                        btnCorporate.Visible = false;
                        //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
                    }
                    else
                    {
                        ClearFields();
                        LoadCorporateDetails();
                        CorporateView.ActiveViewIndex = 0;
                        btnCorporate.Visible = true;
                        rgCorporateContactDetails.DataSource = new object[] { };
                        rgCorporateContactDetails.DataBind();

                        rgCorporateBranchDetails.DataSource = new object[] { };
                        rgCorporateBranchDetails.DataBind();
                    }
                }
                else
                {
                    lblEmailError.Text = "Invalid Email Id";
                    showPopup("Warning", "Invalid Email Address");
                    return;
                }
                con.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }           

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtCorporateName.Text = "";
            txtHeadOfficeAddress.Text = "";
            txtBranchOfficeAddress.Text = "";
            txtLandLineNo.Text = "";
            txtEmailid.Text = "";
            txtMobileNo.Text = "";
            rbIsActive.SelectedIndex = 0;
            //CorporateView.ActiveViewIndex = 0;
            btnSave.Text = "Save";

            rgCorporateContactDetails.DataSource = null;
            rgCorporateContactDetails.DataBind();

            rgCorporateBranchDetails.DataSource = null;
            rgCorporateBranchDetails.DataBind();

            rgDocumentDetails.DataSource = new object[] { };
            rgDocumentDetails.DataBind();
        }

 

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!Session["CorporateId"].ToString().Equals("0"))
            {
                ClearFields();
                CorporateView.ActiveViewIndex = 0;
                btnCorporate.Visible = false;
                //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
            }
            else
            {
                ClearFields();
                LoadCorporateDetails();
                CorporateView.ActiveViewIndex = 0;
                btnCorporate.Visible = true;
                rgCorporateContactDetails.DataSource = new object[] { };
                rgCorporateContactDetails.DataBind();
                rgCorporateBranchDetails.DataSource = new object[] { };
                rgCorporateBranchDetails.DataBind();
            }
        }

        protected void rgCorporateContactDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int rownumber;
                if (e.CommandName == "AddContactDetails")
                {
                    DataTable DtAdditionalDetails = new DataTable();
                    if (Session["AdditionalDetails"] == null || (Session["AdditionalDetails"] as DataTable).Rows.Count <= 0)
                    {
                        DtAdditionalDetails.Columns.Add("rownumber");
                        DtAdditionalDetails.Columns.Add("PersonName");
                        DtAdditionalDetails.Columns.Add("MobileNo");
                        DtAdditionalDetails.Columns.Add("ContactNo");
                        DtAdditionalDetails.Columns.Add("EmailId");

                        //DtAdditionalDetails.Columns.Add("newrow");
                        //DtAdditionalDetails.Columns.Add("ContactDetailsId");
                        rownumber = 1;
                    }
                    else
                    {
                        DtAdditionalDetails = Session["AdditionalDetails"] as DataTable;
                        rownumber = (Convert.ToInt16(DtAdditionalDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    GridFooterItem item = (GridFooterItem)e.Item;
                    RadTextBox txtPersonName = (RadTextBox)item.FindControl("txtPersonName");
                    RadTextBox txtMobileNo = (RadTextBox)item.FindControl("txtMobileNo");
                    RadTextBox txtContactNo = (RadTextBox)item.FindControl("txtContactNo");
                    RadTextBox txtEmailId = (RadTextBox)item.FindControl("txtEmailId");

                    //Label lblnewrows = (Label)item.FindControl("lblnewrows");
                    //Label lblContactDetailsID = (Label)item.FindControl("lblContactDetailsID");
                    //lblnewrows.Text.Trim() = "1";
                    DataTable dtSubjects = new DataTable();
                    // ViewState["ElectiveAlreadyPresent"] = ViewState["ElectiveAlreadyPresent"].ToString()+SubjectIDs;

                    //if (frtxtRemarks.Text.Trim() == "")
                    //{

                    //}

                    if (DtAdditionalDetails != null && DtAdditionalDetails.Rows.Count > 0)
                    {
                        rownumber = (Convert.ToInt16(DtAdditionalDetails.Compute("MAX(rownumber)", ""))) + 1;
                    }
                    else
                    {
                        rownumber = 1;
                    }
                    bool ifExist = false;
                    foreach (DataRow dr in DtAdditionalDetails.Rows)
                    {
                        if (dr["PersonName"].ToString().ToUpper() == txtPersonName.Text.Trim().ToUpper() && dr["MobileNo"].ToString().ToUpper() == txtMobileNo.Text.Trim().ToUpper()
                            && dr["ContactNo"].ToString().ToUpper() == txtContactNo.Text.Trim().ToUpper() && dr["EmailId"].ToString().ToUpper() == txtEmailId.Text.Trim().ToUpper())
                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        DtAdditionalDetails.Rows.Add(rownumber, txtPersonName.Text.Trim(), txtMobileNo.Text.Trim(), txtContactNo.Text.Trim(), txtEmailId.Text.Trim());
                        Session["AdditionalDetails"] = DtAdditionalDetails;
                        rgCorporateContactDetails.DataSource = Session["AdditionalDetails"] as DataTable;
                        rgCorporateContactDetails.DataBind();
                    }
                }
                if (e.CommandName == "DelateContactDetails")
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblrownumber = (Label)rgCorporateContactDetails.Items[intIndex].FindControl("lblrownumber");
                    //Label lblnewrows = (Label)rgCorporateContactDetails.Items[intIndex].FindControl("lblnewrows");
                    //Label lblContactDetailsID = (Label)rgCorporateContactDetails.Items[intIndex].FindControl("lblContactDetailsID");

                    //DataView DtAdditionalDetails = new DataView(Session["ElectiveSubject"] as DataTable);
                    DataTable DtAdditionalDetails = Session["AdditionalDetails"] as DataTable;
                    if (Session["AdditionalDetails"] != null)
                    {
                        if (Convert.ToInt16(lblrownumber.Text.Trim()) != 0)
                        {
                            DataRow[] dtRow = null;
                            dtRow = DtAdditionalDetails.Select("rownumber=" + lblrownumber.Text.Trim());
                            DtAdditionalDetails.Rows.Remove(dtRow[0]);
                            DtAdditionalDetails.AcceptChanges();
                            Session["AdditionalDetails"] = DtAdditionalDetails;
                        }
                        else
                        {
                            //int facultyid = Convert.ToInt32(hfFacultyID.Value);
                            DataSet dsAdditionalDetails = new DataSet();
                            //FacultyModule ObjMasterModule = new FacultyModule();
                            //dsAdditionalDetails = ObjMasterModule.fnDeleteAdditionalrecords(Convert.ToInt64(lblFacultyTrainingDetailsID.Text), facultyid);
                            if (dsAdditionalDetails.Tables[0] != null && dsAdditionalDetails.Tables[0].Rows.Count > 0)
                            {
                                Session["AdditionalDetails"] = dsAdditionalDetails.Tables[0];
                                rgCorporateContactDetails.DataSource = Session["AdditionalDetails"] as DataTable;
                                rgCorporateContactDetails.DataBind();
                            }
                        }
                    }
                    if (Session["AdditionalDetails"] != null && (Session["AdditionalDetails"] as DataTable).Rows.Count > 0)
                    {
                        rgCorporateContactDetails.DataSource = Session["AdditionalDetails"] as DataTable;
                        rgCorporateContactDetails.DataBind();
                    }
                    else
                    {
                        rgCorporateContactDetails.DataSource = string.Empty;
                        rgCorporateContactDetails.DataBind();
                        rgCorporateContactDetails.DataSource = Session["AdditionalDetails"] as DataTable;
                        rgCorporateContactDetails.DataBind();
                        rgCorporateContactDetails.ShowFooter = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rgCorporateContactDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgDocumentDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgDocumentDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblCorporateDocumentDetailsId = (Label)rgDocumentDetails.Items[intIndex].FindControl("lblCorporateDocumentDetailsId"); // % 15 for page indexing
                    //Variables.CorporateId = Convert.ToInt32(CorporateDocumentDetailsId.Text.Trim());
                    //LoadCorporateDetailsById();

                    DataTable objDataSet = new DataTable();
                    //int intIndex = int.Parse(e.CommandArgument.ToString());

                    Label lblDocumentName = (Label)rgDocumentDetails.Items[intIndex].FindControl("lblDocumentName");
                    //FacultyModule objFacultyModule = new FacultyModule();
                    // objDataSet = objFacultyModule.fnDownloadDoc(Convert.ToInt32(lblFacultyDocumentID.Text.Trim()));

                    Bal BusinessAccessLayer = new Bal();
                    objDataSet = BusinessAccessLayer.DownloadCorporateDocument(Convert.ToInt32(lblCorporateDocumentDetailsId.Text.Trim()));

                    if (objDataSet != null && objDataSet.Rows.Count > 0)
                    {

                        if (objDataSet.Rows[0][0] != DBNull.Value)
                        {
                            Byte[] bytDocumentData = (Byte[])objDataSet.Rows[0][0];
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = "application/octectstream";
                            Response.AddHeader("content-disposition", "attachment;filename=" + lblDocumentName.Text.Trim());
                            Response.BinaryWrite(bytDocumentData);
                            Response.Flush();
                            Response.End();
                        }

                    }




                }
                catch (Exception ex)
                {


                }
            }

            if (e.CommandName.Equals("Delete"))
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblCorporateDocumentDetailsId = (Label)rgDocumentDetails.Items[intIndex].FindControl("lblCorporateDocumentDetailsId"); // % 15 for page indexing

                Bal BusinessAccessLayer = new Bal();
                BusinessAccessLayer.DeleteCorporateDocument(Convert.ToInt32(lblCorporateDocumentDetailsId.Text.Trim()));

                DataSet dtCorporateDetails = new DataSet();

                dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsById(Variables.CorporateId);






                if (dtCorporateDetails != null && dtCorporateDetails.Tables[2].Rows.Count > 0)
                {
                    rgDocumentDetails.DataSource = dtCorporateDetails.Tables[2];
                    rgDocumentDetails.DataBind();

                    //Session["AdditionalDetails"] = dtCorporateDetails.Tables[2];
                }
                else
                {
                    rgDocumentDetails.DataSource = null;
                    rgDocumentDetails.DataBind();
                }

            }
        }

        protected void rgDocumentDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void btnCorporate_Click(object sender, EventArgs e)
        {
            CorporateView.ActiveViewIndex = 1;
            btnCorporate.Visible = false;
            rgCorporateContactDetails.DataSource = new object[] { };
            rgCorporateContactDetails.DataBind();

            rgCorporateBranchDetails.DataSource = new object[] { };
            rgCorporateBranchDetails.DataBind();
        }

        //protected void rgCorporateBranchDetails_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    try
        //    {
                
        //        int rownumber;
        //        if (e.CommandName == "AddBranchDetails")
        //        {
        //            DataTable DtAdditionalBranchDetails = new DataTable();
        //            if (Session["AdditionalBranchDetails"] == null || (Session["AdditionalBranchDetails"] as DataTable).Rows.Count <= 0)
        //            {
        //                DtAdditionalBranchDetails.Columns.Add("rownumber");
        //                DtAdditionalBranchDetails.Columns.Add("BranchDetailsId");
        //                DtAdditionalBranchDetails.Columns.Add("Branch");
        //                DtAdditionalBranchDetails.Columns.Add("PersonName");
        //                DtAdditionalBranchDetails.Columns.Add("MobileNo");
        //                DtAdditionalBranchDetails.Columns.Add("EmailId");
        //                DtAdditionalBranchDetails.Columns.Add("StateName");
        //                DtAdditionalBranchDetails.Columns.Add("StateId");
        //                DtAdditionalBranchDetails.Columns.Add("DistrictName");
        //                DtAdditionalBranchDetails.Columns.Add("DistrictId");
        //                DtAdditionalBranchDetails.Columns.Add("Address");
        //                DtAdditionalBranchDetails.Columns.Add("IsActive");

        //                rownumber = 1;
        //            }
        //            else
        //            {
        //                DtAdditionalBranchDetails = Session["AdditionalBranchDetails"] as DataTable;
        //                rownumber = (Convert.ToInt16(DtAdditionalBranchDetails.Compute("MAX(rownumber)", ""))) + 1;
        //            }
        //            GridFooterItem item = (GridFooterItem)e.Item;
        //            RadTextBox txtBranch = (RadTextBox)item.FindControl("txtBranch");
        //            RadTextBox txtPersonName = (RadTextBox)item.FindControl("txtPersonName");
        //            RadTextBox txtMobileNo = (RadTextBox)item.FindControl("txtMobileNo");
        //            RadTextBox txtEmailId = (RadTextBox)item.FindControl("txtEmailId");
        //            //StateList();
        //            RadComboBox rcbState = (RadComboBox)item.FindControl("rcbState");
        //            //Label StateId = (Label)item.FindControl("lblStateId");
        //            RadComboBox rcbCity = (RadComboBox)item.FindControl("rcbCity");
        //            //Label DistrictId = (Label)item.FindControl("lblCityId");
        //            RadTextBox txtAddress = (RadTextBox)item.FindControl("txtAddress");
        //            RadioButtonList rbdIsActive = (RadioButtonList)item.FindControl("rbdIsActive");

        //            DataTable dtSubjects = new DataTable();
                  

        //            if (DtAdditionalBranchDetails != null && DtAdditionalBranchDetails.Rows.Count > 0)
        //            {
        //                rownumber = (Convert.ToInt16(DtAdditionalBranchDetails.Compute("MAX(rownumber)", ""))) + 1;
        //            }
        //            else
        //            {
        //                rownumber = 1;
        //            }
        //            bool ifExist = false;
        //            foreach (DataRow dr in DtAdditionalBranchDetails.Rows)
        //            {
        //                if (
        //                    dr["Branch"].ToString().ToUpper() == txtBranch.Text.Trim().ToUpper()
        //                    && dr["PersonName"].ToString().ToUpper() == txtPersonName.Text.Trim().ToUpper() 
        //                    && dr["MobileNo"].ToString().ToUpper() == txtMobileNo.Text.Trim().ToUpper()
        //                    && dr["EmailId"].ToString().ToUpper() == txtEmailId.Text.Trim().ToUpper() 
        //                    //&& dr["State"].ToString().ToUpper() == rcbState.SelectedItem.Text.Trim().ToUpper() 
        //                    //&& dr["City"].ToString().ToUpper() == rcbCity.SelectedItem.Text.Trim().ToUpper()
        //                    && dr["Address"].ToString().ToUpper() == txtAddress.Text.Trim()
        //                    && dr["IsActive"].ToString().ToUpper() == rbdIsActive.SelectedValue.Trim()
        //                    )
        //                {
        //                    ifExist = true;
        //                }
        //            }
        //            if (!ifExist)
        //            {
        //                DtAdditionalBranchDetails.Rows.Add(rownumber,0, txtBranch.Text.Trim(), txtPersonName.Text.Trim(), txtMobileNo.Text.Trim(), 
        //                txtEmailId.Text.Trim(), rcbState.SelectedItem.Text, rcbState.SelectedValue, rcbCity.SelectedItem.Text, rcbCity.SelectedValue, 
        //                txtAddress.Text.Trim(), Convert.ToInt32(rbdIsActive.SelectedValue));
        //                Session["AdditionalBranchDetails"] = DtAdditionalBranchDetails;
        //                rgCorporateBranchDetails.DataSource = Session["AdditionalBranchDetails"] as DataTable;
        //                rgCorporateBranchDetails.DataBind();
        //            }
        //        }
        //        if (e.CommandName == "DeleteBranchDetails")
        //        {
        //            int intIndex = int.Parse(e.CommandArgument.ToString());
        //            Label lblrownumber = (Label)rgCorporateBranchDetails.Items[intIndex].FindControl("lblrownumber");

        //            DataTable DtAdditionalBranchDetails = Session["AdditionalBranchDetails"] as DataTable;
        //            if (Session["AdditionalBranchDetails"] != null)
        //            {
        //                if (Convert.ToInt16(lblrownumber.Text.Trim()) != 0)
        //                {
        //                    DataRow[] dtRow = null;
        //                    dtRow = DtAdditionalBranchDetails.Select("rownumber=" + lblrownumber.Text.Trim());
        //                    DtAdditionalBranchDetails.Rows.Remove(dtRow[0]);
        //                    DtAdditionalBranchDetails.AcceptChanges();
        //                    Session["AdditionalBranchDetails"] = DtAdditionalBranchDetails;
        //                }
        //                else
        //                {
        //                    DataSet dsAdditionalBranchDetails = new DataSet();
                           
        //                    if (dsAdditionalBranchDetails.Tables[0] != null && dsAdditionalBranchDetails.Tables[0].Rows.Count > 0)
        //                    {
        //                        Session["AdditionalBranchDetails"] = dsAdditionalBranchDetails.Tables[0];
        //                        rgCorporateBranchDetails.DataSource = Session["AdditionalDetails"] as DataTable;
        //                        rgCorporateBranchDetails.DataBind();
        //                    }
        //                }
        //            }
        //            if (Session["AdditionalBranchDetails"] != null && (Session["AdditionalBranchDetails"] as DataTable).Rows.Count > 0)
        //            {
        //                rgCorporateBranchDetails.DataSource = Session["AdditionalBranchDetails"] as DataTable;
        //                rgCorporateBranchDetails.DataBind();
        //            }
        //            else
        //            {
        //                rgCorporateBranchDetails.DataSource = string.Empty;
        //                rgCorporateBranchDetails.DataBind();
        //                rgCorporateBranchDetails.DataSource = Session["AdditionalBranchDetails"] as DataTable;
        //                rgCorporateBranchDetails.DataBind();
        //                rgCorporateBranchDetails.ShowFooter = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void rgCorporateBranchDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{

        //}

        //protected void rgCorporateBranchDetails_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Item is GridFooterItem)
        //        {
        //            GridFooterItem item = (GridFooterItem)e.Item;

        //            RadComboBox rcbState = (item.FindControl("rcbState") as RadComboBox);
        //            //RadComboBox cmbDependentRelationShip = (item.FindControl("cmbDependentRelationShip") as RadComboBox);

        //            rcbState.DataSource = ViewState["MasterState"];
        //            rcbState.DataTextField = "StateName";
        //            rcbState.DataValueField = "StateId";
        //            rcbState.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void RadGridBranchDetails_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Item is GridFooterItem)
        //        {
        //            GridFooterItem item = (GridFooterItem)e.Item;

        //            RadComboBox rcbState = (item.FindControl("rcbState") as RadComboBox);

        //            rcbState.DataSource = ViewState["MasterState"];
        //            rcbState.DataTextField = "StateName";
        //            rcbState.DataValueField = "StateId";
        //            rcbState.DataBind();

        //            RadComboBox rcbCity = (item.FindControl("rcbCity") as RadComboBox);

        //            rcbCity.DataSource = ViewState["MasterCity"];
        //            rcbCity.DataTextField = "DistrictName";
        //            rcbCity.DataValueField = "DistrictId";
        //            rcbCity.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void RadGridBranchDetails_ItemCommand(object sender, GridCommandEventArgs e)
        //{

        //}

        //protected void RadGridBranchDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{

        //}

        protected void rcbState_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //CityList();

            try
            {
                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                //foreach (GridDataItem item in rgCorporateBranchDetails.MasterTableView.Items)
                //{

                RadComboBox cmb = (RadComboBox)sender;
                GridFooterItem item = (GridFooterItem)cmb.NamingContainer;

                RadComboBox rcbState = (item.FindControl("rcbState") as RadComboBox);
                RadComboBox rcbCity = (item.FindControl("rcbCity") as RadComboBox);


                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbState.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    rcbCity.DataSource = dtCity;
                    rcbCity.DataTextField = "DistrictName";
                    rcbCity.DataValueField = "DistrictId";
                    rcbCity.DataBind();
                }

                //}




            }
            catch (Exception ex)
            {

            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "Select CorporateId, CorporateName, MobileNo, LandLineNo, Emailid, HeadOfficeAddress," +
                               " BranchOfficeAddress, Case when IsActive = 1 then 'True' Else 'False' End as IsActive from Master_CorporateDetails";

            string Query = "";
            string CorporateId = "";

            for (int i = 0; i < rcbCorporate.CheckedItems.Count; i++)
            {
                if (CorporateId == "")
                {
                    CorporateId = rcbCorporate.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CorporateId += "," + rcbCorporate.CheckedItems[i].Value.Trim();
                }
            }

            
            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CorporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And CorporateId in(" + CorporateId + ")";
                }
            }
            

            if (txt_Email.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where Emailid like '%" + txt_Email.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And Emailid like '%" + txt_Email.Text.Trim() + "%'";
                }
            }


            if (txt_Mobile.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MobileNo like '%" + txt_Mobile.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And MobileNo like '%" + txt_Mobile.Text.Trim() + "%'";
                }
            }

            if (rcbStatus.SelectedValue != "-1")
            {
                if (Query.Equals(""))
                {
                    Query = " where IsActive='" + rcbStatus.SelectedItem.Value.Trim() + "'";
                }
                else
                {
                    Query += " And IsActive='" + rcbStatus.SelectedItem.Value.Trim() + "'";
                }
            }

            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                rgvCorporateDetails.DataSource = dtCaseDetails;
                rgvCorporateDetails.DataBind();
            }
            else
            {
                rgvCorporateDetails.DataSource = new object[] { };
                rgvCorporateDetails.DataBind();
            }


        }



        //protected void rcbState_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    rcbCity.Items.Clear();
        //    try
        //    {


        //        DataTable dtCity = new DataTable();
        //        Bal BusinessAccessLayer = new Bal();
        //        dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbState.SelectedValue));
        //        if (dtCity != null && dtCity.Rows.Count > 0)
        //        {
        //            rcbCity.DataSource = dtCity;
        //            rcbCity.DataTextField = "DistrictName";
        //            rcbCity.DataValueField = "DistrictId";
        //            rcbCity.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}