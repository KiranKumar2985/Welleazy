using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Test
{
    public partial class TestPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PackageView.ActiveViewIndex = 0;
                LoadCorporateDetails();
                LoadPackageDetails();
                LoadTestDropDown();
            }

        }

        public void LoadTestDropDown()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtTestDetails = new DataTable();
            dtTestDetails = BusinessAccessLayer.LoadTestDropDown();

            if (dtTestDetails != null && dtTestDetails.Rows.Count > 0)
            {
                cmbTestInclude.DataSource = dtTestDetails;
                cmbTestInclude.DataValueField = "TestId";
                cmbTestInclude.DataTextField = "TestName";
                cmbTestInclude.DataBind();
            }
            else
            {
                rgvTestPackageDetails.DataSource = null;
                rgvTestPackageDetails.DataBind();
            }

        }

        public void LoadPackageDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtPackageDetailds = new DataTable();
            dtPackageDetailds = BusinessAccessLayer.LoadPackageDetails();

            if (dtPackageDetailds != null && dtPackageDetailds.Rows.Count > 0)
            {
                rgvTestPackageDetails.DataSource = dtPackageDetailds;
                rgvTestPackageDetails.DataBind();
            }
            else
            {
                rgvTestPackageDetails.DataSource = null;
                rgvTestPackageDetails.DataBind();
            }
        }

        public void LoadCorporateDetails()
        {
            Bal BusinessAccesslayer = new Bal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = BusinessAccesslayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtCorporateDetails;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();
            }
        }

        //protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        //{
        //    PackageView.ActiveViewIndex = 1;
        //}

        protected void rgvTestPackageDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblPackageId = (Label)rgvTestPackageDetails.Items[intIndex % 10].FindControl("lblPackageId"); // % 15 for page indexing
                    Variables.PackageId = Convert.ToInt32(lblPackageId.Text.Trim());
                    LoadPackageDetailsById();

                    btnSave.Text = "Update";


                    PackageView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadPackageDetailsById()
        {
            DataTable dtPackageDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtPackageDetails = BusinessAccessLayer.LoadPackageDetailsById(Variables.PackageId);

            if (dtPackageDetails != null && dtPackageDetails.Rows.Count > 0)
            {
                txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();

                txtPackageName.Text = dtPackageDetails.Rows[0]["PackageName"].ToString();
                cmbCorporateName.SelectedValue = dtPackageDetails.Rows[0]["CorporateId"].ToString();
                txtReferringChannel.Text = dtPackageDetails.Rows[0]["ReferringChannel"].ToString();
                //txtName.Text= dtPackageDetails.Rows[0]["Name"].ToString();
                //txtEmailId.Text = dtPackageDetails.Rows[0]["EmailId"].ToString();
                //txtMobileNo.Text = dtPackageDetails.Rows[0]["MobileNo"].ToString();
                cmbProductType.SelectedValue = dtPackageDetails.Rows[0]["ProductType"].ToString();
                //string ProductType = dtPackageDetails.Rows[0]["ProductType"].ToString();
                //if(ProductType.Equals("AHC"))
                //{
                //    cmbProductType.SelectedValue = "1";
                //}
                //cmbProductType_SelectedIndexChanged(null, null);
                string TestIncluded = dtPackageDetails.Rows[0]["TestIncluded"].ToString();

                //string MedicalTest = dtCaseDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
                String[] TestValue = TestIncluded.Split(',');
                //LoadTestDropDown();
                for (int i = 0; i < TestValue.Length; i++)
                {
                    foreach (RadComboBoxItem item in cmbTestInclude.Items)
                    {
                        if (item.Value.ToString().Trim() == TestValue[i].ToString().Trim())
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }



                string Specialization = dtPackageDetails.Rows[0]["DoctorSpecialization"].ToString();


                String[] SpecializationValue = Specialization.Split(',');
                //LoadTestDropDown();
                for (int i = 0; i < SpecializationValue.Length; i++)
                {
                    foreach (RadComboBoxItem item in cmbDoctorSpecialization.Items)
                    {
                        if (item.Value.ToString().Trim() == SpecializationValue[i].ToString().Trim())
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }

                //foreach (String s in TestValue)
                //{

                //    foreach (RadComboBoxItem item in cmbTestInclude.Items)
                //    {
                //        if (item.Value == s)
                //        {
                //            item.Selected = true;
                //            break;
                //        }
                //    }
                //}

                txtNormalPrice.Text = dtPackageDetails.Rows[0]["NormalPrice"].ToString();
                txtHNIPrice.Text = dtPackageDetails.Rows[0]["HNIPrice"].ToString();
                cmbStatus.SelectedValue = dtPackageDetails.Rows[0]["AHC_Status"].ToString();
                cmbProductType_Concultation.SelectedValue = dtPackageDetails.Rows[0]["ProductType_Consultation"].ToString();
                //if(ProductType_Consultation.Equals("E-Consultation"))
                //{
                //    cmbProductType_Concultation.SelectedValue = "1";
                //}
                cmbConsultationType.SelectedValue = dtPackageDetails.Rows[0]["ConsultationTYpe"].ToString();
                //cmbDoctorSpecialization.SelectedValue = dtPackageDetails.Rows[0]["DoctorSpecialization"].ToString();
                cmbConsultation_Status.SelectedValue = dtPackageDetails.Rows[0]["ConsultationStatus"].ToString();

                cmbProductType_SecondOpinion.SelectedValue = dtPackageDetails.Rows[0]["ProductType_SecondOpinion"].ToString();
                // if (ProductType_SecondOpinion.Equals("Second Opinion"))
                //{
                //   cmbProductType_SecondOpinion.SelectedValue = "1";
                // }

                txtSO_NormalPrice.Text = dtPackageDetails.Rows[0]["SecondOpinion_NorMalPrice"].ToString();
                txtSO_HNIPrice.Text = dtPackageDetails.Rows[0]["SecondOpinion_HNIPrice"].ToString();
                cmbSO_Status.SelectedValue = dtPackageDetails.Rows[0]["SecondOpinion_Status"].ToString();

                if (dtPackageDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }

                //txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
                //txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
                //txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
                //txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
                //txtProductSKU.Text = dtPackageDetails.Rows[0]["ProductSKU"].ToString();
            }
        }

        protected void rgvTestPackageDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvTestPackageDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void cmbProductType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if(cmbProductType.SelectedValue=="1" || cmbProductType.Text== "AHC")
            //{
            //    //trAHC.Visible = true;
            //    //trConsultation.Visible = false;
            //    //trSecondOpinion.Visible = false;
            //    //trAHC.Style.Add("visibility", "visible");
            //}
            //else if(cmbProductType.SelectedValue=="2" ||  cmbProductType.Text== "E-Consultation")
            //{
            //    trConsultation.Visible = true;
            //    trAHC.Visible = false;
            //    trSecondOpinion.Visible = false;
            //}
            //else if (cmbProductType.SelectedValue == "3" || cmbProductType.Text == "Second Opinion")
            //{
            //    trConsultation.Visible = false;
            //    trAHC.Visible = false;
            //    trSecondOpinion.Visible = true;
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Double NormalPrice = 0.0;
            Double HNIPrice = 0.0;
            Double SO_NormalPrice = 0.0;
            Double SO_HNIPrice = 0.0;


            if (!txtNormalPrice.Text.Trim().Equals(""))
            {
                NormalPrice = Convert.ToDouble(txtNormalPrice.Text.Trim());
            }

            if (!txtHNIPrice.Text.Trim().Equals(""))
            {
                HNIPrice = Convert.ToDouble(txtHNIPrice.Text.Trim());
            }

            if (!txtSO_NormalPrice.Text.Trim().Equals(""))
            {
                SO_NormalPrice = Convert.ToDouble(txtSO_NormalPrice.Text.Trim());
            }

            if (!txtSO_HNIPrice.Text.Trim().Equals(""))
            {
                SO_HNIPrice = Convert.ToDouble(txtSO_HNIPrice.Text.Trim());
            }

            string TestIncluded = "";

            string Specialization = "";

            for (int i = 0; i <= cmbTestInclude.CheckedItems.Count; i++)
            {
                //if (cmbTestInclude.Items[i].Selected)
                {
                    if (TestIncluded == "")
                    {
                        TestIncluded = cmbTestInclude.Items[i].Value;
                    }
                    else
                    {
                        TestIncluded += "," + cmbTestInclude.Items[i].Value;
                    }
                }
            }

            for (int i = 0; i <= cmbDoctorSpecialization.CheckedItems.Count; i++)
            {
                //if (cmbTestInclude.Items[i].Selected)
                {
                    if (Specialization == "")
                    {
                        Specialization = cmbDoctorSpecialization.Items[i].Value;
                    }
                    else
                    {
                        Specialization += "," + cmbDoctorSpecialization.Items[i].Value;
                    }
                }
            }


            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdatePackageDetails(0, txtProductSKU.Text.Trim(), txtPackageName.Text, Convert.ToInt32(cmbCorporateName.SelectedValue),
                    txtReferringChannel.Text.Trim(), "", "", "",
                    cmbProductType.SelectedValue, TestIncluded, NormalPrice, HNIPrice, cmbStatus.SelectedValue, cmbProductType_Concultation.SelectedValue, cmbConsultationType.SelectedValue,
                    Specialization, cmbConsultation_Status.SelectedValue, cmbProductType_SecondOpinion.SelectedValue, SO_NormalPrice, SO_HNIPrice, cmbSO_Status.SelectedValue, Convert.ToInt32(rbIsActive.SelectedValue), 1, out IsDataExists);
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
                BusinessAccessLayer.InsertUpdatePackageDetails(Variables.PackageId, txtProductSKU.Text.Trim(), txtPackageName.Text,
                    Convert.ToInt32(cmbCorporateName.SelectedValue),
                    txtReferringChannel.Text.Trim(), "", "", "",
                    cmbProductType.SelectedValue, TestIncluded, NormalPrice,
                    HNIPrice, cmbStatus.SelectedValue, cmbProductType_Concultation.SelectedValue, cmbConsultationType.SelectedValue, cmbDoctorSpecialization.SelectedValue, cmbConsultation_Status.SelectedValue,
                    cmbProductType_SecondOpinion.SelectedValue, SO_NormalPrice, SO_HNIPrice, cmbSO_Status.SelectedValue, Convert.ToInt32(rbIsActive.SelectedValue), 1, out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");

                }
            }


            //if (Session["RoleId"].ToString().Equals("1"))
            //{
            //    //Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
            //}
            //else
            {
                ClearFields();
                LoadCorporateDetails();
                LoadPackageDetails();
                PackageView.ActiveViewIndex = 0;

            }
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtPackageName.Text = "";
            txtProductSKU.Text = "";
            cmbCorporateName.SelectedValue = "0";
            txtReferringChannel.Text = "";
            cmbProductType.SelectedValue = "0";
            cmbTestInclude.Text = "";
            txtNormalPrice.Text = "";
            txtHNIPrice.Text = "";
            cmbStatus.SelectedValue = "0";
            cmbProductType_Concultation.SelectedValue = "0";
            cmbConsultationType.SelectedValue = "0";
            cmbDoctorSpecialization.SelectedValue = "0";
            rbIsActive.SelectedIndex = 0;
            cmbConsultation_Status.SelectedValue = "0";
            cmbProductType_SecondOpinion.SelectedValue = "0";
            cmbSO_Status.SelectedValue = "0";
            txtSO_HNIPrice.Text = "";
            txtSO_HNIPrice.Text = "";
            //CorporateView.ActiveViewIndex = 0;
            btnSave.Text = "Save";


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PackageView.ActiveViewIndex = 0;
            ClearFields();
        }

        protected void Linkspl1_Click(object sender, EventArgs e)
        {
            PackageView.ActiveViewIndex = 1;
            ClearFields();
        }

        protected void txt_ClientName_TextChanged(object sender, EventArgs e)
        {
            txt_SKUCode.Text = "";
            txt_PackageName.Text = "";

            SearchPackageDetails(txt_SKUCode.Text.Trim(), txt_PackageName.Text.Trim(), txt_ClientName.Text.Trim(), "CorporateName");
        }

        protected void txt_SKUCode_TextChanged(object sender, EventArgs e)
        {
            txt_PackageName.Text = "";
            txt_ClientName.Text = "";
            SearchPackageDetails(txt_SKUCode.Text.Trim(), txt_PackageName.Text.Trim(), "", "SKUCode");
        }

        protected void txt_PackageName_TextChanged(object sender, EventArgs e)
        {
            txt_SKUCode.Text = "";
            txt_ClientName.Text = "";
            SearchPackageDetails(txt_SKUCode.Text.Trim(), txt_PackageName.Text.Trim(), "", "PackageName");
        }

        public void SearchPackageDetails(string SKUCode, string PackageName, string CorporateName, string SearchType)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtPackage = new DataTable();
            dtPackage = BusinessAccessLayer.SearchPackageDetails(SKUCode, PackageName, CorporateName, SearchType);

            if (dtPackage != null && dtPackage.Rows.Count > 0)
            {
                rgvTestPackageDetails.DataSource = dtPackage;
                rgvTestPackageDetails.DataBind();

            }
            else
            {
                rgvTestPackageDetails.DataSource = null;
                rgvTestPackageDetails.DataBind();
            }

        }

        protected void LinkPackage_Click(object sender, EventArgs e)
        {
            PackageView.ActiveViewIndex = 0;
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            LoadPackageDetails();
        }

    }
}