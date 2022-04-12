using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class DoctorQualification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQualificationDetails();
                QualificationView.ActiveViewIndex = 0;
            }
        }

        public void LoadQualificationDetails()
        {
            DataTable dtQualificationDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtQualificationDetails = BusinessAccessLayer.LoadQualificationDetails();

            if (dtQualificationDetails != null && dtQualificationDetails.Rows.Count > 0)
            {
                rgQualification.DataSource = dtQualificationDetails;
                rgQualification.DataBind();
            }
            else
            {
                rgQualification.DataSource = null;
                rgQualification.DataBind();
            }
        }


        protected void btnQualification_Click(object sender, EventArgs e)
        {
            QualificationView.ActiveViewIndex = 1;
        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtQualificationName.Text = "";
            rbIsActive.SelectedIndex = 0;
            QualificationView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void rgQualification_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblQualificationId = (Label)rgQualification.Items[intIndex % 10].FindControl("lblQualificationId"); // % 15 for page indexing
                    Variables.QualificationId = Convert.ToInt32(lblQualificationId.Text.Trim());
                    LoadQualificationDetailsById();

                    btnSave.Text = "Update";


                    QualificationView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadQualificationDetailsById()
        {
            DataTable dtQualificationDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtQualificationDetails = BusinessAccessLayer.LoadQualificationDetailsById(Variables.QualificationId);


            if (dtQualificationDetails != null && dtQualificationDetails.Rows.Count > 0)
            {
                txtQualificationName.Text = dtQualificationDetails.Rows[0]["Qualification"].ToString();

                if (dtQualificationDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgQualification_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtQualificationDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtQualificationDetails = BusinessAccessLayer.LoadQualificationDetails();

            if (dtQualificationDetails != null && dtQualificationDetails.Rows.Count > 0)
            {
                rgQualification.DataSource = dtQualificationDetails;
                //rgQualification.DataBind();
            }
            else
            {
                rgQualification.DataSource = null;
                //rgQualification.DataBind();
            }
        }

        protected void rgQualification_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateQualification(0, txtQualificationName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateQualification(Variables.QualificationId, txtQualificationName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
            LoadQualificationDetails();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            QualificationView.ActiveViewIndex = 0;
        }
    }
}