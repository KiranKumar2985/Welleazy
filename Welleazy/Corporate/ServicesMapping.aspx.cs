using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using System.Data.SqlClient;

namespace Welleazy.Corporate
{
    public partial class ServicesMapping : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        static string[] services;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLoginType();
                ProductList();
                LoginCreationView.ActiveViewIndex = 1;
                btnProductServices.Visible = true;
                LoadProductServices();
                LoadAssignedServices();
            }
        }

        public void LoadAssignedServices()
        {
            DataTable dtLoadAssignServices = new DataTable();
            Bal BusinessAccessLayer = new Bal();


            dtLoadAssignServices = BusinessAccessLayer.LoadAssignServicesList();


            if (dtLoadAssignServices != null && dtLoadAssignServices.Rows.Count > 0)
            {
                rgAssignedDetails.DataSource = dtLoadAssignServices;
                rgAssignedDetails.DataBind();
            }
            else
            {
                rgAssignedDetails.DataSource = null;
                rgAssignedDetails.DataBind();
            }
        }

        public void LoadAssignedServicesById()
        {
            DataSet dtLoadAssignServices = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtLoadAssignServices = BusinessAccessLayer.LoadAssignServicesListById(Variables.ProductAssignedId);


            if (dtLoadAssignServices != null && dtLoadAssignServices.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";
                cmbLoginType.SelectedValue = dtLoadAssignServices.Tables[0].Rows[0]["LoginTypeId"].ToString();
                CorporateList();
                cmbCorporateName.SelectedValue = dtLoadAssignServices.Tables[0].Rows[0]["CorporateId"].ToString();
                CorporateBranchList();

                cmdBranchId.SelectedValue = dtLoadAssignServices.Tables[0].Rows[0]["BranchId"].ToString();

                //cmdBranchId.SelectedValue = dtLoadAssignServices.Tables[0].Rows[0]["BranchId"].ToString();
                //string ProductId = dtLoadAssignServices.Tables[0].Rows[0]["ProductId"].ToString();

                string ProductList = dtLoadAssignServices.Tables[0].Rows[0]["ProductId"].ToString();
                String[] ProductListValue = ProductList.Split(',');

                int lenght = ProductListValue.Length;

                foreach (string s in ProductListValue)
                {
                    foreach (RadComboBoxItem item in rcbProduct.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
                string SubProductCategory = dtLoadAssignServices.Tables[0].Rows[0]["SubProductId"].ToString();

                Session["DefaultTaskBasedONRole"] = SubProductCategory;
                //Variables.ServicesId = SubProductCategory;
                Variables.ServicesId = SubProductCategory;
                LoadProductServices();
                rdtCreatedOn.DbSelectedDate = dtLoadAssignServices.Tables[0].Rows[0]["CreatedOn"].ToString();
                txt_CreatedBy.Text = dtLoadAssignServices.Tables[0].Rows[0]["CreatedBy"].ToString();
                if (dtLoadAssignServices.Tables[0].Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }
        }

        protected void btnProductServices_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            Variables.ProductAssignedId = 0;
            LoadProductServices();
            LoginCreationView.ActiveViewIndex = 0;


        }

        public void ClearFields()
        {
            //cmbLoginType.SelectedItem.Text = "Select";
            //cmbDomainType.SelectedItem.Text = "Select";
            //cmbCorporateName.SelectedItem.Text = "Select";
            cmbLoginType.Items.Clear();
            cmbCorporateName.Items.Clear();
            LoadLoginType();
            ProductList();

        }
        public void LoadProductServices()
        {
            DataSet dtSubProductServices = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtSubProductServices = BusinessAccessLayer.LoadProductServicesForAssign();

            if (dtSubProductServices != null && dtSubProductServices.Tables[0].Rows.Count > 0)
            {

                rgProductServices.DataSource = dtSubProductServices.Tables[0];
                rgProductServices.DataBind();


                Session["DefaultProcess"] = dtSubProductServices.Tables[0];
                Session["DefaultTasks"] = dtSubProductServices.Tables[1];
                DataTable objrgProductServicesDepth = new DataTable();
                objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;
            }
            else
            {
                rgProductServices.DataSource = null;
                rgProductServices.DataBind();
            }
        }

        public void LoadLoginType()
        {
            DataTable dtLoginType = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoginType = BusinessAccessLayer.LoadLoginType();

            if (dtLoginType != null && dtLoginType.Rows.Count > 0)
            {
                cmbLoginType.DataSource = dtLoginType;
                cmbLoginType.DataTextField = "LoginType";
                cmbLoginType.DataValueField = "LoginTypeId";
                cmbLoginType.DataBind();
            }


        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbLoginType.SelectedItem.Text == "Select" && cmbCorporateName.SelectedItem.Text == "Select" && cmdBranchId.SelectedItem.Text == "Select Branch")
            {
                showPopup("Warning", "Kindly Select Mandatory Fields");
            }
            else
            {
                string strTasks = "";
                for (int Index = 0; Index < rgProductServices.Items.Count; Index++)
                {
                    RadGrid rgProductServicesDepth = (RadGrid)rgProductServices.Items[Index].FindControl("rgProductServicesDepth");

                    for (int IndexJ = 0; IndexJ < rgProductServicesDepth.Items.Count; IndexJ++)
                    {
                        CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");


                        for (int indexK = 0; indexK < cbTasks.Items.Count; indexK++)
                        {
                            if (cbTasks.Items[indexK].Selected == true)
                            {
                                if (strTasks.Trim() == "")
                                    strTasks = cbTasks.Items[indexK].Value.Trim();
                                else
                                    strTasks += "," + cbTasks.Items[indexK].Value.Trim();
                            }
                        }
                    }
                }

                string ProductList = "";

                for (int i = 0; i < rcbProduct.CheckedItems.Count; i++)
                {
                    if (ProductList == "")
                    {
                        ProductList = rcbProduct.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        ProductList += "," + rcbProduct.CheckedItems[i].Value.Trim();
                    }
                }

                string BranchList = "";

                for (int i = 0; i < cmdBranchId.CheckedItems.Count; i++)
                {
                    if (BranchList == "")
                    {
                        BranchList = cmdBranchId.CheckedItems[i].Value.Trim();
                    }
                    else
                    {
                        BranchList += "," + cmdBranchId.CheckedItems[i].Value.Trim();
                    }
                }


                Bal BusinessAccessLayer = new Bal();
                string IsDataExists = "0";
                if (btnSave.Text.Equals("Save"))
                {
                    BusinessAccessLayer.InsertUpdateServicesAssigned(0, Convert.ToInt32(cmbLoginType.SelectedValue),
                        Convert.ToInt32(cmbCorporateName.SelectedValue),
                        Convert.ToInt32(cmdBranchId.SelectedValue), ProductList, strTasks,
                        DateTime.Now, 0, Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Assign Services Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Assign Services Successfully");

                    }
                }
                else
                {
                    BusinessAccessLayer.InsertUpdateServicesAssigned(Variables.ProductAssignedId, Convert.ToInt32(cmbLoginType.SelectedValue),
                        Convert.ToInt32(cmbCorporateName.SelectedValue),
                        Convert.ToInt32(cmdBranchId.SelectedValue), ProductList, strTasks,
                        rdtCreatedOn.DateInput.SelectedDate.Equals(null) ? nul : rdtCreatedOn.DateInput.SelectedDate.Value,
                        Convert.ToInt32(txt_CreatedBy.Text.Trim()), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Assign Services Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Assign Services Updated Successfully");

                    }
                }
                Variables.ProductAssignedId = 0;
                LoginCreationView.ActiveViewIndex = 1;
                btnProductServices.Visible = true;
                LoadProductServices();
                LoadAssignedServices();

            }
            //int result = BusinessAccessLayer.InsertUpdateServicesAssigned(0, Convert.ToInt32(cmbLoginType.SelectedValue), Convert.ToInt32(cmbDomainType.SelectedValue), Convert.ToInt32(cmbCorporateName.SelectedValue), cmdBranchId.SelectedValue.ToString(), cmdBranchId.SelectedValue.ToString(), "", strTasks, "","", Convert.ToInt32(rbIsActive.SelectedValue));

        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.ProductAssignedId = 0;
            //ClearFields();
            LoginCreationView.ActiveViewIndex = 1;
            btnProductServices.Visible = true;
            LoadProductServices();
            LoadAssignedServices();
        }

        public void CorporateList()
        {
            cmbCorporateName.Items.Clear();
            cmbCorporateName.Items.Insert(0, "Select");
            DataTable dtCorporateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            if (cmbLoginType.SelectedValue.Equals("2"))
            {
                dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

                if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
                {
                    cmbCorporateName.DataSource = dtCorporateDetails;
                    cmbCorporateName.DataTextField = "CorporateName";
                    cmbCorporateName.DataValueField = "CorporateId";
                    cmbCorporateName.DataBind();

                }
            }
        }
        protected void cmbLoginType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CorporateList();
        }

        public void ProductServicesList()
        {

            Bal BusinessAccessLayer = new Bal();
            DataTable dtProductServices = new DataTable();
            dtProductServices = BusinessAccessLayer.LoadProductSubCategory();

            if (dtProductServices != null && dtProductServices.Rows.Count > 0)
            {
                rcbProductServicesList.DataSource = dtProductServices;
                rcbProductServicesList.DataTextField = "SubProductCategory";
                rcbProductServicesList.DataValueField = "SubProductId";
                rcbProductServicesList.DataBind();

            }
        }

        public void ProductList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtProduct = new DataTable();
            dtProduct = BusinessAccessLayer.LoadProductDetailsDropDown();

            if (dtProduct != null && dtProduct.Rows.Count > 0)
            {
                rcbProduct.DataSource = dtProduct;
                rcbProduct.DataTextField = "ProductName";
                rcbProduct.DataValueField = "ProductId";
                rcbProduct.DataBind();

                rcbProductList.DataSource = dtProduct;
                rcbProductList.DataTextField = "ProductName";
                rcbProductList.DataValueField = "ProductId";
                rcbProductList.DataBind();
            }


        }
        public void CorporateBranchList()
        {
            cmdBranchId.Items.Clear();
            cmdBranchId.Items.Insert(0, "Select Branch");
            cmdBranchId.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadBranchListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "BranchList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", cmbCorporateName.SelectedValue.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                cmdBranchId.DataSource = dtFetchServiveProviderDetails;
                cmdBranchId.DataTextField = "Branch";
                cmdBranchId.DataValueField = "BranchDetailsId";
                cmdBranchId.DataBind();
            }
        }
        protected void cmbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CorporateBranchList();

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

        protected void rgProductServices_ItemDataBound(object sender, GridItemEventArgs e)
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

        protected void rgAssignedDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblProductAssignedId = (Label)rgAssignedDetails.Items[intIndex % 10].FindControl("lblProductAssignedId"); // % 15 for page indexing
                    Variables.ProductAssignedId = Convert.ToInt32(lblProductAssignedId.Text.Trim());

                    LoginCreationView.ActiveViewIndex = 0;
                    btnProductServices.Visible = false;
                    LoadAssignedServicesById();
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }

            if (e.CommandName.Equals("ViewProduct"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblProductAssignedIdP = (Label)rgAssignedDetails.Items[intIndex % 10].FindControl("lblProductAssignedIdP"); // % 15 for page indexing
                    Variables.ProductAssignedId = Convert.ToInt32(lblProductAssignedIdP.Text.Trim());

                    DataSet dtAssignDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtAssignDetails = BusinessAccessLayer.LoadAssignServicesListById(Variables.ProductAssignedId);


                    if (dtAssignDetails != null && dtAssignDetails.Tables[0].Rows.Count > 0)
                    {
                        //lblMCorporateId.Text = dtAssignDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        //TestList();
                        ProductList();
                        string ProductText = dtAssignDetails.Tables[0].Rows[0]["ProductId"].ToString();
                        string ProductTextList = "";
                        String[] ProductTextValue = ProductText.Split(',');

                        int lenght = ProductTextValue.Length;

                        foreach (string s in ProductTextValue)
                        {
                            foreach (RadComboBoxItem item in rcbProductList.Items)//ListItem item in rcbMedicalTest.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;

                                    if (ProductTextList.Equals(""))
                                    {
                                        ProductTextList = item.Text;
                                    }
                                    else
                                    {
                                        ProductTextList += "," + item.Text;
                                    }
                                    //item.Selected = true;
                                    lblproductlist.Text = ProductTextList;
                                    break;
                                }
                            }
                        }
                        bool showModal = true;

                        if (showModal)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }

            if (e.CommandName.Equals("ViewServices"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblProductAssignedIdSP = (Label)rgAssignedDetails.Items[intIndex % 10].FindControl("lblProductAssignedIdSP"); // % 15 for page indexing
                    Variables.ProductAssignedId = Convert.ToInt32(lblProductAssignedIdSP.Text.Trim());

                    DataSet dtAssignDetails = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtAssignDetails = BusinessAccessLayer.LoadAssignServicesListById(Variables.ProductAssignedId);


                    if (dtAssignDetails != null && dtAssignDetails.Tables[0].Rows.Count > 0)
                    {
                        //lblMCorporateId.Text = dtAssignDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                        //TestList();
                        ProductServicesList();
                        string SubProductText = dtAssignDetails.Tables[0].Rows[0]["SubProductId"].ToString();
                        string SubProductTextList = "";
                        String[] SubProductTextValue = SubProductText.Split(',');

                        int lenght = SubProductTextValue.Length;

                        foreach (string s in SubProductTextValue)
                        {
                            foreach (RadComboBoxItem item in rcbProductServicesList.Items)//ListItem item in rcbMedicalTest.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;

                                    if (SubProductTextList.Equals(""))
                                    {
                                        SubProductTextList = item.Text;
                                    }
                                    else
                                    {
                                        SubProductTextList += "," + item.Text;
                                    }
                                    //item.Selected = true;
                                    lblproductServiceslist.Text = SubProductTextList;
                                    break;
                                }
                            }
                        }
                        bool showModal = true;

                        if (showModal)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal1", "$('#myModal1').modal('show');", true);

                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void rgAssignedDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }


    }
}