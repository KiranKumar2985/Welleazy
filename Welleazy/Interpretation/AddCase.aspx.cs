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
using System.Data.OleDb;

namespace Welleazy.Interpretation
{
    public partial class AddCase : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    int testid = Variables.InterpretationCaseId;
                    if (Variables.InterpretationCaseId != 0)
                    {
                        InterpretationTypeList();
                        CorporateList();
                        InterpretationCaseStatusList();
                        LoadInterpretationCaseDetailsById();
                        UploadReport.Visible = true;
                        lblHeading.Text = "Edit Second Opinion Case";
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        InterpretationTypeList();
                        CorporateList();
                        InterpretationCaseStatusList();
                        lblHeading.Text = "Add Second Opinion Case";
                        btnSave.Text = "Save";
                    }
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
                rcbCorporate.DataSource = dtLoadCorporateList;
                rcbCorporate.DataTextField = "CorporateName";
                rcbCorporate.DataValueField = "CorporateId";
                rcbCorporate.DataBind();

                rcbCorporateList.DataSource = dtLoadCorporateList;
                rcbCorporateList.DataTextField = "CorporateName";
                rcbCorporateList.DataValueField = "CorporateId";
                rcbCorporateList.DataBind();

            }
            else
            {
                rcbCorporate.DataSource = null;
                rcbCorporate.DataBind();

                rcbCorporateList.DataSource = null;
                rcbCorporateList.DataBind();
            }
        }

        public void InterpretationTypeList()
        {
            DataTable dtInterpretationTypeList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationTypeList = BusinessAccessLayer.LoadInterpretationTypeDropDown();

            if (dtInterpretationTypeList != null && dtInterpretationTypeList.Rows.Count > 0)
            {
                rcbInterpretationType.DataSource = dtInterpretationTypeList;
                rcbInterpretationType.DataTextField = "InterpretationType";
                rcbInterpretationType.DataValueField = "InterpretationTypeId";
                rcbInterpretationType.DataBind();

            }
            else
            {
                rcbInterpretationType.DataSource = null;
                rcbInterpretationType.DataBind();
            }
        }

        public void InterpretationCaseStatusList()
        {
            DataTable dtInterpretationCaseStatusList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationCaseStatusList = BusinessAccessLayer.LoadCaseStatusList(3);

            if (dtInterpretationCaseStatusList != null && dtInterpretationCaseStatusList.Rows.Count > 0)
            {
                rcbCaseStatus.DataSource = dtInterpretationCaseStatusList;
                rcbCaseStatus.DataTextField = "CaseStatusName";
                rcbCaseStatus.DataValueField = "StatusId";
                rcbCaseStatus.DataBind();

                //List<string> list = new List<string>() { "42" };
                //foreach (var item in list)
                //{
                //    RadComboBoxItem items = rcbCaseStatus.Items.FindItemByValue(item);
                //    if (item != null)
                //    {
                //        items.Remove();
                //    }
                //}

            }
            else
            {
                rcbCaseStatus.DataSource = null;
                rcbCaseStatus.DataBind();
            }
        }

        public void LoadInterpretationCaseDetailsById()
        {
            DataSet dtInterpretationCaseDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationCaseDetails = BusinessAccessLayer.LoadInterpretationCaseDetailsById(Variables.InterpretationCaseId);


            if (dtInterpretationCaseDetails != null && dtInterpretationCaseDetails.Tables[0].Rows.Count > 0)
            {
                rcbCaseType.SelectedItem.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["CaseType"].ToString();
                rcbCorporate.SelectedValue = dtInterpretationCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                txtCustomerName.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["CustomerName"].ToString();
                txtApplicationNo.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                txtPolicyNo.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["PolicyNo"].ToString();
                rcbCaseRecMode.SelectedItem.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["CaseRecMode"].ToString();
                rcbInterpretationType.SelectedValue = dtInterpretationCaseDetails.Tables[0].Rows[0]["InterpretationType"].ToString();
                txtRemark.Text = dtInterpretationCaseDetails.Tables[0].Rows[0]["CaseRemark"].ToString();
                rcbCaseStatus.SelectedValue = dtInterpretationCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dtInterpretationReport = new DataTable();

            dtInterpretationReport.Columns.Add("ReportName", typeof(string));
            dtInterpretationReport.Columns.Add("ReportData", typeof(Byte[]));
            Byte[] byteDocumentData = new Byte[5242880];
            string DocumentName = "";


            for (int i = 0; i < rauUploadReport.UploadedFiles.Count; i++)
            {
                Stream fs = rauUploadReport.UploadedFiles[i].InputStream;
                BinaryReader br = new BinaryReader(fs);

                byteDocumentData = br.ReadBytes((Int32)fs.Length);
                DocumentName = rauUploadReport.UploadedFiles[i].FileName;
                fs.Close();
                //String targetFolder = Server.MapPath("~/InterpretationReports/" + DocumentName + ".pdf");                

                dtInterpretationReport.Rows.Add(DocumentName, byteDocumentData);

                //foreach (UploadedFile f in rauUploadReport.UploadedFiles)
                //{
                //    string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //    string path = directory + "InterpretationReports";
                //    f.SaveAs(path + f.GetName(), true);
                //}
                //string fileName = Path.GetFileName(rauUploadReport.UploadedFiles[i].FileName);
                //string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //string filepath = directory + "InterpretationReports";
                ////rauUploadReport(Server.MapPath("~/InterpretationReports/" + fileName));
                //rauUploadReport.UploadedFiles[i].SaveAs(Server.MapPath("~/InterpretationReports" + fileName));

                string path = Server.MapPath("~/InterpretationReports/");
                rauUploadReport.UploadedFiles[i].SaveAs(path + DocumentName);

            }

            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                if (rauUploadReport.UploadedFiles.Count <= 0)
                {
                    showPopup("Warning", "Kindly Upload the Report!");
                    return;
                }
                else
                {
                    rcbCaseStatus.SelectedValue = "36";
                    BusinessAccessLayer.InsertUpdateInterpretationCaseDetails(0, rcbCaseType.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCorporate.SelectedValue),
                        txtCustomerName.Text.Trim(), txtApplicationNo.Text.Trim(), txtPolicyNo.Text.Trim(), rcbCaseRecMode.SelectedItem.Text,
                        Convert.ToInt32(rcbInterpretationType.SelectedValue), txtRemark.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), DocumentName, byteDocumentData,
                    Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Case Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Case Saved Successfully");
                        ClearFields();
                        Variables.InterpretationCaseId = 0;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('InterpretationCaseList.aspx');</script>");
                    }
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateInterpretationCaseDetails(Variables.InterpretationCaseId, rcbCaseType.SelectedItem.Text.Trim(), Convert.ToInt32(rcbCorporate.SelectedValue),
                    txtCustomerName.Text.Trim(), txtApplicationNo.Text.Trim(), txtPolicyNo.Text.Trim(), rcbCaseRecMode.SelectedItem.Text,
                    Convert.ToInt32(rcbInterpretationType.SelectedValue), txtRemark.Text.Trim(), Convert.ToInt32(rcbCaseStatus.SelectedValue), DocumentName, byteDocumentData,
                    Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Case Already Exists");
                }
                else
                {
                    showPopup("Warning", "Case Updated Successfully");
                    ClearFields();
                    Variables.CaseRefId = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('InterpretationCaseList.aspx');</script>");

                }
            }
        }

       

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Variables.InterpretationCaseId = 0;
            Response.Redirect("~/Interpretation/InterpretationCaseList.aspx");
        }

        public void ClearFields()
        {
            rcbCaseType.SelectedValue = "0";
            rcbCorporate.SelectedValue = "0";
            txtCustomerName.Text = "";
            txtApplicationNo.Text = "";
            txtPolicyNo.Text = "";
            rcbCaseRecMode.SelectedValue = "0";
            rcbInterpretationType.SelectedValue = "0";
            txtRemark.Text = "";
        }

        protected void LinkInterpretation_Click(object sender, EventArgs e)
        {
            ClearFields();
            Variables.InterpretationCaseId = 0;
            Response.Redirect("~/Interpretation/InterpretationCaseList.aspx");
        }

        protected void Linkspl1_Click(object sender, EventArgs e)
        {
            if(Linkspl1.Text == "Bulk Upload")
            {
                BulkUpload.Visible = true;
                Linkspl1.Text = " Bulk Upload";
            }
            else
            {
                BulkUpload.Visible = false;
                Linkspl1.Text = "Bulk Upload";
            }
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadInterpretationCase.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadInterpretationCase.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadInterpretationCase.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadInterpretationCase.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadInterpretationCase.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/InterpretationReports/" + fileName);

                    RadUploadInterpretationCase.UploadedFiles[0].SaveAs(fileLocation);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    else
                    {
                        //WUCMessage.ShowMessage("Error", "Please upload only excel (.xls, .xslx) file");
                        //return;
                    }
                    OleDbConnection oleDbConn = new OleDbConnection(connectionString);
                    OleDbCommand oleDbComd = new OleDbCommand();
                    oleDbComd.CommandType = System.Data.CommandType.Text;
                    oleDbComd.Connection = oleDbConn;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(oleDbComd);
                    DataTable dtExcelRecords = new DataTable();
                    oleDbConn.Open();
                    DataTable dtExcelSheetName = oleDbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                    oleDbComd.CommandText = "SELECT CustomerName, ApplicationNo, PolicyNo, CaseRecMode, InterpretationType FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();

                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        BusinessAccessLayer.UploadInterpretationCaseDetails( rcbCaseTypeList.SelectedItem.Text, Convert.ToInt32(rcbCorporateList.SelectedValue), dtExcelRecords); //Create SP
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Upload Successfully!');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Not In Proper Format!');</script>");
                ex.ToString();
            }
        }

        protected void btnCancelB_Click(object sender, EventArgs e)
        {
            BulkUpload.Visible = false;
            Linkspl1.Text = "Bulk Upload";
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.Tables.Add();
                objDataSet.Tables[0].Columns.Add("CustomerName");
                objDataSet.Tables[0].Columns.Add("ApplicationNo");
                objDataSet.Tables[0].Columns.Add("PolicyNo");
                objDataSet.Tables[0].Columns.Add("CaseRecMode (Insurer/Email/SMS/FTP)");
                objDataSet.Tables[0].Columns.Add("InterpretationType (1 for ECG/2 for TMT)");

                objDataSet.Tables[0].Rows.Add("", "", "", "", "");
                objDataSet.AcceptChanges();
                ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk Interpretation Case Details Upload Format.xls", Page.Response);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void rauUploadReport_FileUploaded(object sender, FileUploadedEventArgs e)
        //{

        //    string path = Server.MapPath("~/InterpretationReports/");
        //    e.File.SaveAs(path + e.File.GetName());
        //}


    }
}