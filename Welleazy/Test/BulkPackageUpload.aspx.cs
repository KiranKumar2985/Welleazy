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
    public partial class BulkPackageUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CorporateList();
                UploadTestPackageView.ActiveViewIndex = 0;
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                rcbCorporateName.DataSource = dtLoadCorporateList;
                rcbCorporateName.DataTextField = "CorporateName";
                rcbCorporateName.DataValueField = "CorporateId";
                rcbCorporateName.DataBind();
            }
            else
            {
                rcbCorporateName.DataSource = new object[] { }; ;
                rcbCorporateName.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadTestPackage.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadTestPackage.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadTestPackage.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadTestPackage.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadTestPackage.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

                    RadUploadTestPackage.UploadedFiles[0].SaveAs(fileLocation);
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
                    oleDbComd.CommandText = "SELECT ProductSKU,PackageName,TestIncluded,NormalPackagePrice,HNIPackagePrice,Status,Remark FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();


                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        BusinessAccessLayer.UploadTestPackageDetails(Convert.ToInt32(rcbCorporateName.SelectedValue), dtExcelRecords, Convert.ToInt32(Session["LoginRefId"]));
                    }

                    showPopup("Warning", "Package Uploaded Successfully...!");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Test_Package.aspx');</script>");
                }
            }
            catch (Exception ex)
            {
                showPopup("Warning", "Data Not In Proper Format...!");
                ex.ToString();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet objDataSet = new DataSet();
            objDataSet.Tables.Add();
            //objDataSet.Tables[0].Columns.Add("CorporateName");
            objDataSet.Tables[0].Columns.Add("ProductSKU");
            objDataSet.Tables[0].Columns.Add("PackageName");
            objDataSet.Tables[0].Columns.Add("TestIncluded");


            objDataSet.Tables[0].Columns.Add("NormalPackagePrice");
            objDataSet.Tables[0].Columns.Add("HNIPackagePrice");
            objDataSet.Tables[0].Columns.Add("Status");
            objDataSet.Tables[0].Columns.Add("Remark");

            objDataSet.Tables[0].Rows.Add("Test", "Test Package", "Test1", "600", "800", "Active/Disabled", "Remark");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk Test Package Upload Format.xls", Page.Response);
        }
        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}