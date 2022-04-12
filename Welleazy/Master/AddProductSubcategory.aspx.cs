using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Master
{
    public partial class AddProductSubcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductName();
                LoadProductSubCategory();
                ProductSubCategoryView.ActiveViewIndex = 0;
            }
        }

        public void LoadProductName()
        {
            DataTable dtProductName = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtProductName = BusinessAccessLayer.LoadProductDetailsDropDown();

            if (dtProductName != null && dtProductName.Rows.Count > 0)
            {
                rcbProductName.DataSource = dtProductName;
                rcbProductName.DataTextField = "ProductName";
                rcbProductName.DataValueField = "ProductId";
                rcbProductName.DataBind();
            }
        }

        public void LoadProductSubCategory()
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadProductSubCategory = BusinessAccessLayer.LoadProductSubCategory();

            if (dtLoadProductSubCategory != null && dtLoadProductSubCategory.Rows.Count > 0)
            {
                rgvProductSubCategory.DataSource = dtLoadProductSubCategory;
                rgvProductSubCategory.DataBind();
            }
            else
            {
                rgvProductSubCategory.DataSource = null;
                rgvProductSubCategory.DataBind();
            }
        }

        public void LoadProductSubCategoryById()
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadProductSubCategory = BusinessAccessLayer.LoadProductSubCategoryById(Variables.SubProductId);

            if (dtLoadProductSubCategory != null && dtLoadProductSubCategory.Rows.Count > 0)
            {
                txtProductSubCategory.Text = dtLoadProductSubCategory.Rows[0]["SubProductCategory"].ToString();
                rcbProductName.SelectedValue = dtLoadProductSubCategory.Rows[0]["ProductId"].ToString();
                txtPSCNormalPrice.Text = dtLoadProductSubCategory.Rows[0]["NormalPrice"].ToString();
                txtPSCHNIPrice.Text = dtLoadProductSubCategory.Rows[0]["HNIPrice"].ToString();

                if (dtLoadProductSubCategory.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }

        }
        protected void rgvProductSubCategory_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblSubProductId = (Label)rgvProductSubCategory.Items[intIndex % 10].FindControl("lblSubProductId"); // % 15 for page indexing
                    Variables.SubProductId = Convert.ToInt32(lblSubProductId.Text.Trim());
                    LoadProductSubCategoryById();

                    btnSave.Text = "Update";


                    ProductSubCategoryView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        protected void rgvProductSubCategory_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadProductSubCategory = BusinessAccessLayer.LoadProductSubCategory();

            if (dtLoadProductSubCategory != null && dtLoadProductSubCategory.Rows.Count > 0)
            {
                rgvProductSubCategory.DataSource = dtLoadProductSubCategory;
                //rgvProductSubCategory.DataBind();
            }
            else
            {
                rgvProductSubCategory.DataSource = null;
                //rgvProductSubCategory.DataBind();
            }
        }

        protected void rgvProductSubCategory_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnProductSubCategory_Click(object sender, EventArgs e)
        {
            ProductSubCategoryView.ActiveViewIndex = 1;
        }

        public void ClearFields()
        {
            rcbProductName.SelectedValue = "0";
            txtProductSubCategory.Text = "";
            txtPSCNormalPrice.Text = "";
            txtPSCHNIPrice.Text = "";
            rbIsActive.SelectedIndex = 0;
            ProductSubCategoryView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }
        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateProductSubCategory(0, Convert.ToInt32(rcbProductName.SelectedValue), txtProductSubCategory.Text.Trim(), txtPSCNormalPrice.Text.Trim(), txtPSCHNIPrice.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Product Service Already Exists");
                }
                else
                {
                    showPopup("Warning", "Product Service Updated Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateProductSubCategory(Variables.SubProductId, Convert.ToInt32(rcbProductName.SelectedValue), txtProductSubCategory.Text.Trim(), txtPSCNormalPrice.Text.Trim(), txtPSCHNIPrice.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Product Service Already Exists");
                }
                else
                {
                    showPopup("Warning", "Product Service Updated Successfully");

                }
            }
            ClearFields();
            LoadProductSubCategory();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ProductSubCategoryView.ActiveViewIndex = 0;
        }
    }
}