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
    public partial class AddTest : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    int testid = Variables.TestId;
                    if(Variables.TestId!=0)
                    {
                        CorporateList();
                        LoadTestDetailsById();
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

        public void LoadTestDetailsById()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchTestDetails = new SqlCommand("Exec proc_FetchTestDetailsById @TestId", con);
            SqlParameter paramTestId = new SqlParameter("@TestId", Variables.TestId);

            cmdFetchTestDetails.Parameters.Add(paramTestId);

            SqlDataAdapter daTestData = new SqlDataAdapter(cmdFetchTestDetails);
            DataTable dtTestDetails = new DataTable();
            daTestData.Fill(dtTestDetails);

            if (dtTestDetails != null && dtTestDetails.Rows.Count > 0)
            {
                DDL_CorporateName.SelectedValue = dtTestDetails.Rows[0]["CorporateId"].ToString();
                DDL_Status.SelectedValue = dtTestDetails.Rows[0]["Status"].ToString();
                DDL_TestType.SelectedValue = dtTestDetails.Rows[0]["TestType"].ToString();
                DDL_VisitType.SelectedValue = dtTestDetails.Rows[0]["VisitType"].ToString();
                txt_SKUCode.Text = dtTestDetails.Rows[0]["SKUCode"].ToString();
                txt_TestName.Text = dtTestDetails.Rows[0]["TestName"].ToString();
                txt_TestCode.Text = dtTestDetails.Rows[0]["TestCode"].ToString();
                txt_NormalPrice.Text = dtTestDetails.Rows[0]["NormalPrice"].ToString();
                txt_HNIPrice.Text = dtTestDetails.Rows[0]["HNIPrice"].ToString();
                txt_Remark.Text = dtTestDetails.Rows[0]["Remark"].ToString();
                txt_Description.Text = dtTestDetails.Rows[0]["TestDescription"].ToString();
                
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateTestDetails(0, Convert.ToInt32(DDL_CorporateName.SelectedValue), DDL_Status.SelectedItem.Text.Trim(), DDL_TestType.SelectedItem.Text.Trim(),
                    DDL_VisitType.SelectedItem.Text.Trim(), txt_SKUCode.Text.Trim(), txt_TestName.Text.Trim(), txt_TestCode.Text.Trim(), txt_NormalPrice.Text.Trim(), txt_HNIPrice.Text.Trim(), txt_Remark.Text.Trim(), txt_Description.Text.Trim(),
                    Convert.ToInt32(Session["LoginRefId"].ToString()) , out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Saved Successfully");
                    ClearFields();
                    Variables.TestId = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Individual_Test.aspx');</script>");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateTestDetails(Variables.TestId, Convert.ToInt32(DDL_CorporateName.SelectedValue), DDL_Status.SelectedItem.Text.Trim(), DDL_TestType.SelectedItem.Text.Trim(),
                    DDL_VisitType.SelectedItem.Text.Trim(), txt_SKUCode.Text.Trim(), txt_TestName.Text.Trim(), txt_TestCode.Text.Trim(), txt_NormalPrice.Text.Trim(), txt_HNIPrice.Text.Trim(), txt_Remark.Text.Trim(), 
                    txt_Description.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");
                    ClearFields();
                    Variables.TestId = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('Individual_Test.aspx');</script>");
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
            Variables.TestId = 0;
            Response.Redirect("~/Test/Individual_Test.aspx");
        }

        public void ClearFields()
        {
            DDL_CorporateName.SelectedItem.Text = "Select Client Name";
            DDL_Status.SelectedItem.Text = "Select Status";
            DDL_TestType.SelectedItem.Text = "Normal";
            DDL_VisitType.SelectedItem.Text = "Select Visit Type";
            txt_SKUCode.Text = "";
            txt_TestName.Text = "";
            txt_TestCode.Text = "";
            txt_NormalPrice.Text = "";
            txt_HNIPrice.Text = "";
            txt_Remark.Text = "";
            txt_Description.Text = "";
        }
    }
}