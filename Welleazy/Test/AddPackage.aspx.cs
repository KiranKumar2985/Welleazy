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

namespace Welleazy.Test
{
    public partial class AddPackage : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    int testid = Variables.PackageId;
                    if (Variables.PackageId != 0)
                    {
                        CorporateList();
                        LoadPackageDetailsById();
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        CorporateList();
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

        public void TestList()
        {

            rcbTestIncluded.Items.Clear();
            rcbTestIncluded.AppendDataBoundItems = true;

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_LoadTestListForCorporate", con);
            cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "TestList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", DDL_CorporateName.SelectedValue.Trim());

            cmdFetchTestDetailsList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchTestDetailsList);
            DataTable dtFetchTestDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchTestDetails);

            if (dtFetchTestDetails != null && dtFetchTestDetails.Rows.Count > 0)
            {
                rcbTestIncluded.DataSource = dtFetchTestDetails;
                rcbTestIncluded.DataTextField = "TestName";
                rcbTestIncluded.DataValueField = "TestId";
                rcbTestIncluded.DataBind();

            }
        }

        public void LoadPackageDetailsById()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchTestDetails = new SqlCommand("Exec proc_LoadPackageDetailsById @PackageId", con);
            SqlParameter paramPackageId = new SqlParameter("@PackageId", Variables.PackageId);

            cmdFetchTestDetails.Parameters.Add(paramPackageId);

            SqlDataAdapter daPackageData = new SqlDataAdapter(cmdFetchTestDetails);
            DataTable dtPackageDetails = new DataTable();
            daPackageData.Fill(dtPackageDetails);

            if (dtPackageDetails != null && dtPackageDetails.Rows.Count > 0)
            {
                DDL_CorporateName.SelectedValue = dtPackageDetails.Rows[0]["CorporateId"].ToString();
                TestList();
                txt_SKUCode.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
                txt_PackageName.Text = dtPackageDetails.Rows[0]["PackageName"].ToString();
                txt_NormalPackagePrice.Text = dtPackageDetails.Rows[0]["NormalPackagePrice"].ToString();
                txt_HNIPackagePrice.Text = dtPackageDetails.Rows[0]["HNIPackagePrice"].ToString();
                DDL_Status.SelectedValue = dtPackageDetails.Rows[0]["Status"].ToString();
                txt_Remark.Text = dtPackageDetails.Rows[0]["Remark"].ToString();

                string IncludedTest = dtPackageDetails.Rows[0]["TestIncluded"].ToString();

                String[] IncludedTestValue = IncludedTest.Split(',');

                int lenght = IncludedTestValue.Length;

                foreach (string s in IncludedTestValue)
                {
                    foreach (RadComboBoxItem item in rcbTestIncluded.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            string TestIncluded = "";

            for (int i = 0; i < rcbTestIncluded.CheckedItems.Count; i++)
            {
                if (TestIncluded == "")
                {
                    TestIncluded = rcbTestIncluded.CheckedItems[i].Value.Trim();
                }
                else
                {
                    TestIncluded += "," + rcbTestIncluded.CheckedItems[i].Value.Trim();
                }
            }

            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdatePackageDetails(0, Convert.ToInt32(DDL_CorporateName.SelectedValue), txt_SKUCode.Text.Trim(), 
                    txt_PackageName.Text.Trim(), TestIncluded, txt_NormalPackagePrice.Text.Trim(), txt_HNIPackagePrice.Text.Trim(), 
                    DDL_Status.SelectedItem.Text.Trim(), txt_Remark.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Package Already Exists");
                }
                else
                {
                    showPopup("Warning", "Package Saved Successfully");
                    ClearFields();
                    Variables.PackageId = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Test_Package.aspx');</script>");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdatePackageDetails(Variables.PackageId, Convert.ToInt32(DDL_CorporateName.SelectedValue), txt_SKUCode.Text.Trim(),
                    txt_PackageName.Text.Trim(), TestIncluded, txt_NormalPackagePrice.Text.Trim(), txt_HNIPackagePrice.Text.Trim(),
                    DDL_Status.SelectedItem.Text.Trim(), txt_Remark.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Package Already Exists");
                }
                else
                {
                    showPopup("Warning", "Package Updated Successfully");
                    ClearFields();
                    Variables.PackageId = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Test_Package.aspx');</script>");
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
            Variables.PackageId = 0;
            Response.Redirect("~/Test/Test_Package.aspx");
        }

        public void ClearFields()
        {
            DDL_CorporateName.SelectedItem.Text = "Select Client Name";
            DDL_Status.SelectedItem.Text = "Select Status";
            txt_SKUCode.Text = "";
            txt_PackageName.Text = "";
            txt_NormalPackagePrice.Text = "";
            txt_HNIPackagePrice.Text = "";
            txt_Remark.Text = "";
        }

        protected void DDL_CorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            TestList();
        }
    }
}