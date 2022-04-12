using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy
{
    public partial class UploadEmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UploadEmployeeData.ActiveViewIndex = 0;
                CorporateList();
                //Response.Write("hi");
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtLoadCorporateList;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();



            }
            else
            {
                cmbCorporateName.DataSource = new object[] { }; ;
                cmbCorporateName.DataBind();


            }
        }

        public void ProductListByCorporateId()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtProduct = new DataTable();
            dtProduct = BusinessAccessLayer.LoadProductDetailsDropDown();

            if (dtProduct != null && dtProduct.Rows.Count > 0)
            {
                cmbProduct.DataSource = dtProduct;
                cmbProduct.DataTextField = "ProductName";
                cmbProduct.DataValueField = "ProductId";
                cmbProduct.DataBind();


            }


        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadUploadEmployeeDocument.UploadedFiles.Count == 1)
                {
                    string connectionString = "";

                    if (RadUploadEmployeeDocument.UploadedFiles.Count == 0)
                    {
                        //WUCMessage.ShowMessage("Error", "Select the file to upload");
                        //return;
                    }
                    Session["FileName"] = RadUploadEmployeeDocument.UploadedFiles[0].FileName;
                    string fileName = Path.GetFileName(RadUploadEmployeeDocument.UploadedFiles[0].FileName);
                    string fileExtension = Path.GetExtension(RadUploadEmployeeDocument.UploadedFiles[0].FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

                    RadUploadEmployeeDocument.UploadedFiles[0].SaveAs(fileLocation);
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
                    oleDbComd.CommandText = "SELECT CorporateName,BranchName,EmployeeId,EmployeeName,EmailId,MobileNo,Gender,DateOfBirth,State,City,Area,LandMark,Address,Pincode FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = oleDbComd;
                    dAdapter.Fill(dtExcelRecords);
                    oleDbConn.Close();

                    Bal BusinessAccessLayer = new Bal();

                    string strServices = "";
                    for (int Index = 0; Index < rgProductServices.Items.Count; Index++)
                    {
                        RadGrid rgvDefaultRoleTasksDepth = (RadGrid)rgProductServices.Items[Index].FindControl("rgProductServicesDepth");

                        for (int IndexJ = 0; IndexJ < rgvDefaultRoleTasksDepth.Items.Count; IndexJ++)
                        {
                            CheckBoxList cbTasks = (CheckBoxList)rgvDefaultRoleTasksDepth.Items[0].FindControl("cbTasks");

                            for (int indexK = 0; indexK < cbTasks.Items.Count; indexK++)
                            {
                                if (cbTasks.Items[indexK].Selected == true)
                                {
                                    if (strServices.Trim() == "")
                                        strServices = cbTasks.Items[indexK].Value.Trim();
                                    else
                                        strServices += "," + cbTasks.Items[indexK].Value.Trim();
                                }
                            }
                        }
                    }


                    if (dtExcelRecords != null && dtExcelRecords.Rows.Count > 0)
                    {
                        BusinessAccessLayer.UploadEmployeeDetails(dtExcelRecords, strServices,Convert.ToInt32(Session["LoginRefId"]));
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
            objDataSet.Tables[0].Columns.Add("CorporateName");
            objDataSet.Tables[0].Columns.Add("BranchName");
            objDataSet.Tables[0].Columns.Add("EmployeeId");
            //objDataSet.Tables[0].Columns.Add("FirstName");
            //objDataSet.Tables[0].Columns.Add("LastName");
            objDataSet.Tables[0].Columns.Add("EmployeeName");
            objDataSet.Tables[0].Columns.Add("EmailId");
            objDataSet.Tables[0].Columns.Add("MobileNo");
            objDataSet.Tables[0].Columns.Add("Gender");
            objDataSet.Tables[0].Columns.Add("DateOfBirth");
            objDataSet.Tables[0].Columns.Add("State");
            objDataSet.Tables[0].Columns.Add("City");
            objDataSet.Tables[0].Columns.Add("Area");
            objDataSet.Tables[0].Columns.Add("LandMark");
            objDataSet.Tables[0].Columns.Add("Address");
            objDataSet.Tables[0].Columns.Add("Pincode");

            objDataSet.Tables[0].Rows.Add("ABC", "XYZ", "Emp01XXX", "EMPNAME", "XXX@XXX.XXX", "864XXXXXXX", "Male", "01-01-1900", "Delhi", "Delhi NCR", "Area", "LandMark", "Address", "Pincode");
            objDataSet.AcceptChanges();
            ExcelHelper.ToExcelDownloadSamePage(objDataSet, "Bulk EmployeeDetails Upload Format.xls", Page.Response);
        }

        protected void rgProductServices_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lblProductId = (Label)item.FindControl("lblProductId");
                    RadGrid rgProductServicesDepth = (RadGrid)item.FindControl("rgProductServicesDepth");

                    {

                        DataTable objrgProductServicesDepth = new DataTable();
                        objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;

                        //DataTable dtPermissionDetails = new DataTable();
                        //Bal BusinessAccessLayer = new Bal();
                        //dtPermissionDetails = BusinessAccessLayer.LoadProductServicesForAssign();


                        DataView dv = new DataView(objrgProductServicesDepth);
                        dv.RowFilter = "ProductId=" + lblProductId.Text.Trim();

                        DataTable dt = new DataTable();
                        dt.Columns.Add(lblProductId.Text.Trim());
                        dt.Rows.Add("");
                        rgProductServicesDepth.DataSource = dt;
                        rgProductServicesDepth.DataBind();

                        CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");

                        for (int Index = 0; Index < dv.Count; Index++)
                        {
                            cbTasks.Items.Add(new ListItem(dv[Index]["SubProductCategory"].ToString().Trim(), dv[Index]["SubProductId"].ToString().Trim()));
                        }
                        int length = Variables.ServicesId.Length;

                        string RecognizedBy = Variables.ServicesId;
                        String[] RecognizedValue = RecognizedBy.Split(',');
                        // if (Session["DefaultTaskBasedONRole"] != null && Session["DefaultTaskBasedONRole"].ToString().Trim() != "")
                        {
                            //string[] objrgProductServices = Session["DefaultTaskBasedONRole"] as string[];
                            //string[] objrgProductServices = Variables.ServicesId as string[];

                            // if (objrgProductServices != null && objrgProductServices.Length > 0)
                            {
                                //for (int Index = 0; Index < objrgProductServices.Length; Index++)
                                for (int Index = 0; Index < RecognizedValue.Length; Index++)
                                {
                                    if (cbTasks.Items.FindByValue(RecognizedValue[Index].ToString().Trim()) != null)
                                    {
                                        cbTasks.Items.FindByValue(RecognizedValue[Index].ToString().Trim()).Selected = true;

                                    }
                                }
                            }
                        }

                        GridHeaderItem headerItem = (GridHeaderItem)rgProductServicesDepth.MasterTableView.GetItems(GridItemType.Header)[0];
                        Label lblProductHeader = (Label)headerItem.FindControl("lblProductHeader");  //access Label inside HeaderTemplate  
                        lblProductHeader.Text = dv[0]["ProductName"].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                //string ErrorID = EffiaErrorLogWriter.writeToErrorLog(ex);
                //WUCMessage.ShowMessage("Error", "Error ID :" + ErrorID + " , " + PopUpMessages.AdminError);
            }
        }

        protected void chkAllTask_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objDDL = (CheckBox)sender;
            GridDataItem row = (GridDataItem)objDDL.NamingContainer;
            int intIndex = row.ItemIndex;

            CheckBox chkAllTask = (CheckBox)rgProductServices.Items[intIndex].FindControl("chkAllTask");
            Label lblProductId = (Label)rgProductServices.Items[intIndex].FindControl("lblProductId");
            RadGrid rgProductServicesDepth = (RadGrid)rgProductServices.Items[intIndex].FindControl("rgProductServicesDepth");


            DataSet dtPermissionDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtPermissionDetails = BusinessAccessLayer.LoadProductServicesForAssign();


            DataTable objrgProductServicesDepth = new DataTable();
            objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;

            DataView dv = new DataView(objrgProductServicesDepth);
            dv.RowFilter = "ProductId=" + lblProductId.Text.Trim();

            DataTable dt = new DataTable();
            dt.Columns.Add(lblProductId.Text.Trim());
            dt.Rows.Add("");
            rgProductServicesDepth.DataSource = dt;
            rgProductServicesDepth.DataBind();
            CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");

            for (int Index = 0; Index < dv.Count; Index++)
            {
                cbTasks.Items.Add(new ListItem(dv[Index]["SubProductCategory"].ToString().Trim(), dv[Index]["SubProductId"].ToString().Trim()));
                cbTasks.Items.FindByValue(dv[Index]["SubProductId"].ToString().Trim()).Selected = chkAllTask.Checked;
            }
            GridHeaderItem headerItem = (GridHeaderItem)rgProductServicesDepth.MasterTableView.GetItems(GridItemType.Header)[0];
            Label lblProductHeader = (Label)headerItem.FindControl("lblProductHeader");  //access Label inside HeaderTemplate  
            lblProductHeader.Text = dv[0]["ProductName"].ToString().Trim();
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


        protected void cmdBranchId_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CorporateBProductList();
        }

        public void CorporateBProductList()
        {
            //ProductList();
            cmbProduct.Items.Clear();
            cmbProduct.Items.Insert(0, "Select Product");
            cmbProduct.AppendDataBoundItems = true;
            DataSet dtProductListDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtProductListDetails = BusinessAccessLayer.LoadBProductListById(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranchId.SelectedValue));


            if (dtProductListDetails != null && dtProductListDetails.Tables[0].Rows.Count > 0)
            {
                //Session["CorporatesubCategoryDetails"] = dtProductListDetails.Tables[1];
                cmbProduct.DataSource = dtProductListDetails.Tables[0];
                cmbProduct.DataTextField = "ProductName";
                cmbProduct.DataValueField = "ProductId";
                cmbProduct.DataBind();
            }
            //else
            //{

            //    rcbProduct.SelectedValue = "0";
            //    //rcbProduct.DataValueField=null;
            //}

        }

        protected void cmbProduct_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string ProductList = "";

            for (int i = 0; i < cmbProduct.CheckedItems.Count; i++)
            {
                if (ProductList == "")
                {
                    ProductList = cmbProduct.CheckedItems[i].Value.Trim();
                }
                else
                {
                    ProductList += "," + cmbProduct.CheckedItems[i].Value.Trim();
                }
            }

            DataSet dtSubProductServices = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtSubProductServices = BusinessAccessLayer.LoadProductServicesForEmployee(ProductList,Convert.ToInt32(cmbCorporateName.SelectedValue),Convert.ToInt32(cmbCorporateBranchId.SelectedValue));

            if (dtSubProductServices != null && dtSubProductServices.Tables[0].Rows.Count > 0)
            {

                Session["DefaultProcess"] = dtSubProductServices.Tables[0];
                Session["DefaultTasks"] = dtSubProductServices.Tables[1];
                rgProductServices.DataSource = dtSubProductServices.Tables[0];
                rgProductServices.DataBind();


               

                DataTable objrgProductServicesDepth = new DataTable();
                objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;
            }
            else
            {
                rgProductServices.DataSource = null;
                rgProductServices.DataBind();
            }
        }

        public void LoadProductServices()
        {
            
        }

    }
}