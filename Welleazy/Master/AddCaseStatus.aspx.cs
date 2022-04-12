using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class AddCaseStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCaseStatusDetails();
                CaseStatusView.ActiveViewIndex = 0;
            }

        }

        public void LoadCaseStatusDetails()
        {
            DataTable dtCaseStatusDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCaseStatusDetails = BusinessAccessLayer.LoadCaseStatusList(0);

            if (dtCaseStatusDetails != null && dtCaseStatusDetails.Rows.Count > 0)
            {
                rgCaseStatus.DataSource = dtCaseStatusDetails;
                rgCaseStatus.DataBind();
            }
            else
            {
                rgCaseStatus.DataSource = null;
                rgCaseStatus.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateCaseStatus(0, txtCaseStatusName.Text.Trim(), txtCaseFor.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateCaseStatus(Variables.StatusId, txtCaseStatusName.Text.Trim(), txtCaseFor.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");

                }
            }
            ClearFields();
            LoadCaseStatusDetails();

        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtCaseStatusName.Text = "";
            txtCaseFor.Text = "";
            rbIsActive.SelectedIndex = 0;
            CaseStatusView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

       
        protected void rgCaseStatus_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblStatusId = (Label)rgCaseStatus.Items[intIndex % 10].FindControl("lblStatusId"); // % 15 for page indexing
                    Variables.StatusId = Convert.ToInt32(lblStatusId.Text.Trim());
                    LoadCaseStatusDetailsById();

                    btnSave.Text = "Update";


                    CaseStatusView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadCaseStatusDetailsById()
        {
            DataTable dtCaseStatusDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCaseStatusDetails = BusinessAccessLayer.LoadCaseStatusDetailsById(Variables.StatusId);


            if (dtCaseStatusDetails != null && dtCaseStatusDetails.Rows.Count > 0)
            {
                txtCaseStatusName.Text = dtCaseStatusDetails.Rows[0]["CaseStatusName"].ToString();
                txtCaseFor.Text = dtCaseStatusDetails.Rows[0]["CaseFor"].ToString();

                if (dtCaseStatusDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgCaseStatus_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtCaseStatusDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCaseStatusDetails = BusinessAccessLayer.LoadCaseStatusList(0);

            if (dtCaseStatusDetails != null && dtCaseStatusDetails.Rows.Count > 0)
            {
                rgCaseStatus.DataSource = dtCaseStatusDetails;
                //rgCaseStatus.DataBind();
            }
            else
            {
                rgCaseStatus.DataSource = null;
                //rgCaseStatus.DataBind();
            }
        }

        protected void rgCaseStatus_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CaseStatusView.ActiveViewIndex = 0;

        }

        protected void btnCaseStatus_Click(object sender, EventArgs e)
        {
            CaseStatusView.ActiveViewIndex = 1;
        }

        protected void btnShowBulkUpload_Click(object sender, EventArgs e)
        {
            CaseStatusView.ActiveViewIndex = 2;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadCaseStatusDocument.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadCaseStatusDocument.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadCaseStatusDocument.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadCaseStatusDocument.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadCaseStatusDocument.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

                    RadUploadCaseStatusDocument.UploadedFiles[0].SaveAs(fileLocation);
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
                    oleDbComd.CommandText = "SELECT CaseStatusName, CaseFor FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();

                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        //BusinessAccessLayer.UploadCaseStatusDetails(dtExcelRecords); //Create SP
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet objDataSet = new DataSet();
            objDataSet.Tables.Add();
            objDataSet.Tables[0].Columns.Add("CaseStatusName");
            objDataSet.Tables[0].Columns.Add("CaseFor");

            objDataSet.Tables[0].Rows.Add("","");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk CaseStatus Upload Format.xls", Page.Response);
        }
    }
}