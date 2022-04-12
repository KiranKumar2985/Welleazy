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
    public partial class AddBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranchDetails();
                BranchView.ActiveViewIndex = 0;
            }

        }

        public void LoadBranchDetails()
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtBranchDetails = BusinessAccessLayer.LoadBranchDetails();

            if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
            {
                rgBranch.DataSource = dtBranchDetails;
                rgBranch.DataBind();
            }
            else
            {
                rgBranch.DataSource = null;
                rgBranch.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateBranch(0, txtBranchName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateBranch(Variables.BranchId, txtBranchName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
            LoadBranchDetails();

        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtBranchName.Text = "";
            rbIsActive.SelectedIndex = 0;
            BranchView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }


        protected void rgBranch_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblBranchId = (Label)rgBranch.Items[intIndex % 10].FindControl("lblBranchId"); // % 15 for page indexing
                    Variables.BranchId = Convert.ToInt32(lblBranchId.Text.Trim());
                    LoadBranchDetailsById();

                    btnSave.Text = "Update";


                    BranchView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadBranchDetailsById()
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtBranchDetails = BusinessAccessLayer.LoadBranchDetailsById(Variables.BranchId);


            if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
            {
                txtBranchName.Text = dtBranchDetails.Rows[0]["BranchName"].ToString();

                if (dtBranchDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgBranch_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtBranchDetails = BusinessAccessLayer.LoadBranchDetails();

            if (dtBranchDetails != null && dtBranchDetails.Rows.Count > 0)
            {
                rgBranch.DataSource = dtBranchDetails;
                //rgBranch.DataBind();
            }
            else
            {
                rgBranch.DataSource = null;
                //rgBranch.DataBind();
            }
        }

        protected void rgBranch_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BranchView.ActiveViewIndex = 0;

        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
            BranchView.ActiveViewIndex = 1;
        }

        protected void btnShowBulkUpload_Click(object sender, EventArgs e)
        {
            BranchView.ActiveViewIndex = 2;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadBranchDocument.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadBranchDocument.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadBranchDocument.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadBranchDocument.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadBranchDocument.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

                    RadUploadBranchDocument.UploadedFiles[0].SaveAs(fileLocation);
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
                    oleDbComd.CommandText = "SELECT BranchName FROM [" + getExcelSheetName + "]";
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
            objDataSet.Tables[0].Columns.Add("BranchName");

            objDataSet.Tables[0].Rows.Add("");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk Branch Upload Format.xls", Page.Response);
        }
    }
}