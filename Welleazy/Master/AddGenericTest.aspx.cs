using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Master
{
    public partial class AddGenericTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGenericTestDetails();
                GenericTestView.ActiveViewIndex = 0;
            }
        }

        public void LoadGenericTestDetails()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadGenericTestDetails();

            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                rgvGenericTest.DataSource = dtStateDetails;
                rgvGenericTest.DataBind();
            }
            else
            {
                rgvGenericTest.DataSource = null;
                rgvGenericTest.DataBind();
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            Variables.GenericTestId = 0;
            GenericTestView.ActiveViewIndex = 1;
        }

        protected void rgvGenericTest_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvGenericTest_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblGenericTestId = (Label)rgvGenericTest.Items[intIndex % 10].FindControl("lblGenericTestId"); // % 15 for page indexing
                    Variables.GenericTestId = Convert.ToInt32(lblGenericTestId.Text.Trim());

                    LoadGenericTestDetailsById();

                    btnSave.Text = "Update";

                    GenericTestView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadGenericTestDetailsById()
        {
            DataTable dtGenericTestDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtGenericTestDetails = BusinessAccessLayer.LoadGenericTestDetailsById(Variables.GenericTestId);


            if (dtGenericTestDetails != null && dtGenericTestDetails.Rows.Count > 0)
            {
                DDL_VisitType.SelectedItem.Text = dtGenericTestDetails.Rows[0]["VisitType"].ToString();
                txt_TestName.Text = dtGenericTestDetails.Rows[0]["TestName"].ToString();
                txt_TestCode.Text = dtGenericTestDetails.Rows[0]["TestCode"].ToString();
                txt_NormalPrice.Text = dtGenericTestDetails.Rows[0]["NormalPrice"].ToString();
                txt_HNIPrice.Text = dtGenericTestDetails.Rows[0]["HNIPrice"].ToString();
                txt_Description.Text = dtGenericTestDetails.Rows[0]["TestDescription"].ToString();

                if (dtGenericTestDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgvGenericTest_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateGenericTestDetails(0, DDL_VisitType.SelectedItem.Text, txt_TestName.Text.Trim(), txt_TestCode.Text.Trim(), txt_NormalPrice.Text.Trim(), txt_HNIPrice.Text.Trim(), txt_Description.Text.Trim(), 0, Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Test Already Exists");
                }
                else
                {
                    showPopup("Warning", "Test Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateGenericTestDetails(Variables.GenericTestId, DDL_VisitType.SelectedItem.Text, txt_TestName.Text.Trim(), txt_TestCode.Text.Trim(), txt_NormalPrice.Text.Trim(), txt_HNIPrice.Text.Trim(), txt_Description.Text.Trim(), 0, Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Test Already Exists");
                }
                else
                {
                    showPopup("Warning", "Test Updated Successfully");

                }
            }
            ClearFields();
            LoadGenericTestDetails();
        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            DDL_VisitType.SelectedItem.Text = "Select Visit Type";
            txt_TestName.Text = "";
            txt_TestCode.Text = "";
            txt_NormalPrice.Text = "";
            txt_HNIPrice.Text = "";
            txt_Description.Text = "";
            rbIsActive.SelectedIndex = 0;
            GenericTestView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GenericTestView.ActiveViewIndex = 0;
        }
    }
}