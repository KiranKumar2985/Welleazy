using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Test
{
    public partial class BulkTestUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UploadTestData.ActiveViewIndex = 0;
                CorporateList();
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
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadTestDocument.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadTestDocument.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadTestDocument.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadTestDocument.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadTestDocument.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

                    RadUploadTestDocument.UploadedFiles[0].SaveAs(fileLocation);
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
                    oleDbComd.CommandText = "SELECT Status, TestType, VisitType, SKUCode, TestName, TestCode, NormalPrice, HNIPrice, Remark, TestDescription FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();
                    
                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        BusinessAccessLayer.UploadTestDetails(Convert.ToInt32(DDL_CorporateName.SelectedValue), dtExcelRecords, Convert.ToInt32(Session["LoginRefId"])); //Create SP
                        //BusinessAccessLayer.UploadTestDetails(dtExcelRecords); //Create SP
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Upload Successfully!');</script>");
                    }

                    showPopup("Warning", "Test Uploaded Successfully...!");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Individual_Test.aspx');</script>");
                }
            }
            catch (Exception ex)
            {
                showPopup("Warning", "Data Not In Proper Format...!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Not In Proper Format!');</script>");
                ex.ToString();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet objDataSet = new DataSet();
            objDataSet.Tables.Add();
            //objDataSet.Tables[0].Columns.Add("CorporateName");
            objDataSet.Tables[0].Columns.Add("Status");
            objDataSet.Tables[0].Columns.Add("TestType");
            objDataSet.Tables[0].Columns.Add("VisitType");
            objDataSet.Tables[0].Columns.Add("SKUCode");
            objDataSet.Tables[0].Columns.Add("TestName");
            objDataSet.Tables[0].Columns.Add("TestCode");
            objDataSet.Tables[0].Columns.Add("NormalPrice");
            objDataSet.Tables[0].Columns.Add("HNIPrice");
            objDataSet.Tables[0].Columns.Add("Remark");
            objDataSet.Tables[0].Columns.Add("TestDescription");

            objDataSet.Tables[0].Rows.Add("CorporateName", "(Active/Disabled)", "(Normal/Approval Based/ADHOC)", "(Home/Center/Both)", "", "", "", "", "", "", "");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk TestDetails Upload Format.xls", Page.Response);
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}