using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Master
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDetails();
                ProductView.ActiveViewIndex = 0;
            }
        }

        public void LoadProductDetails()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadProductDetails();

            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                rgvProduct.DataSource = dtStateDetails;
                rgvProduct.DataBind();
            }
            else
            {
                rgvProduct.DataSource = null;
                rgvProduct.DataBind();
            }
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            ProductView.ActiveViewIndex = 1;
        }

        protected void rgvProduct_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvProduct_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblProductId = (Label)rgvProduct.Items[intIndex % 10].FindControl("lblProductId"); // % 15 for page indexing
                    Variables.ProductId = Convert.ToInt32(lblProductId.Text.Trim());
                    LoadProductDetailsById();

                    btnSave.Text = "Update";


                    ProductView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadProductDetailsById()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadProductDetailsById(Variables.ProductId);


            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                txtProductName.Text = dtStateDetails.Rows[0]["ProductName"].ToString();

                if (dtStateDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgvProduct_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateProduct(0, txtProductName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateProduct(Variables.ProductId, txtProductName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");

                }
            }
            ClearFields();
            LoadProductDetails();
        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtProductName.Text = "";
            rbIsActive.SelectedIndex = 0;
            ProductView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ProductView.ActiveViewIndex = 0;
        }
    }
}