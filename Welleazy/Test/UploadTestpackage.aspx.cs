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
    public partial class UploadTestpackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UploadTestPackageView.ActiveViewIndex = 0;
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
                    oleDbComd.CommandText = "SELECT ProductSKU,PackageName,ProductType,TestIncluded,NormalPrice,HNIPrice,AHC_Status,ProductType_Consultation," +
                        "ConsultationType,DoctorSpecialization,ConsultationStatus,ProductType_SecondOpinion, SecondOpinion_NorMalPrice, SecondOpinion_HNIPrice, " +
                        "SecondOpinion_Status FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();


                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        BusinessAccessLayer.UploadPackageDetails(dtExcelRecords);
                    }



                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
           
            DataSet objDataSet = new DataSet();
            objDataSet.Tables.Add();
            objDataSet.Tables[0].Columns.Add("ProductSKU");
            objDataSet.Tables[0].Columns.Add("PackageName");
            objDataSet.Tables[0].Columns.Add("ProductType");
            objDataSet.Tables[0].Columns.Add("TestIncluded");


            objDataSet.Tables[0].Columns.Add("NormalPrice");
            objDataSet.Tables[0].Columns.Add("HNIPrice");
            objDataSet.Tables[0].Columns.Add("AHC_Status");

            objDataSet.Tables[0].Columns.Add("ProductType_Consultation");
            objDataSet.Tables[0].Columns.Add("ConsultationType");
            objDataSet.Tables[0].Columns.Add("DoctorSpecialization");
            objDataSet.Tables[0].Columns.Add("ConsultationStatus");

            objDataSet.Tables[0].Columns.Add("ProductType_SecondOpinion");
            objDataSet.Tables[0].Columns.Add("SecondOpinion_NorMalPrice");
            objDataSet.Tables[0].Columns.Add("SecondOpinion_HNIPrice");
            objDataSet.Tables[0].Columns.Add("SecondOpinion_Status");

            objDataSet.Tables[0].Rows.Add("Test", "Test Package", "AHC", "Test1","600","800","Active/Disabled/Hold","Consultation","Tele/Video Consultation","MBBS/MD/Cardiologist","Active/Disabled/Hold","Second Opinion","600","800","Active/Disabled/Hold");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk Test Package Upload Format.xls", Page.Response);
        }
    }
}