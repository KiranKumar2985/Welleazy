using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Master
{
    public partial class AddSpecialities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SpecialitiesView.ActiveViewIndex = 0;
                LoadSpecialities();
            }
        }

        public void LoadSpecialities()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtSpecialities = new DataTable();
            dtSpecialities = BusinessAccessLayer.LoadSpecialities();

            if(dtSpecialities!=null && dtSpecialities.Rows.Count>0)
            {
                rgvSpecialities.DataSource = dtSpecialities;
                rgvSpecialities.DataBind();
            }
            else
            {
                rgvSpecialities.DataSource = null;
                rgvSpecialities.DataBind();
            }

        }

        protected void rgvSpecialities_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblSpecialityId = (Label)rgvSpecialities.Items[intIndex % 10].FindControl("lblSpecialityId"); // % 15 for page indexing
                    Variables.SpecialityId = Convert.ToInt32(lblSpecialityId.Text.Trim());
                    LoadSpecialitiesById();

                    btnSave.Text = "Update";


                    SpecialitiesView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {


                }
            }
        }

        public void LoadSpecialitiesById()
        {
            DataTable dtSpecialities = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtSpecialities=BusinessAccessLayer.LoadSpecialitiesById(Variables.SpecialityId);

            if(dtSpecialities!=null && dtSpecialities.Rows.Count>0)
            {
                txtDescription.Text = dtSpecialities.Rows[0]["Description"].ToString();

                if (dtSpecialities.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }
        }

        protected void rgvSpecialities_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtSpecialities = new DataTable();
            dtSpecialities = BusinessAccessLayer.LoadSpecialities();

            if (dtSpecialities != null && dtSpecialities.Rows.Count > 0)
            {
                rgvSpecialities.DataSource = dtSpecialities;
                //rgvSpecialities.DataBind();
            }
            else
            {
                rgvSpecialities.DataSource = null;
                //rgvSpecialities.DataBind();
            }
        }

        protected void rgvSpecialities_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnAddSpecialities_Click(object sender, EventArgs e)
        {
            SpecialitiesView.ActiveViewIndex = 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateSpeciality(0, txtDescription.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
                BusinessAccessLayer.InsertUpdateSpeciality(Variables.SpecialityId, txtDescription.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
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
            LoadSpecialities();
            SpecialitiesView.ActiveViewIndex = 0;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SpecialitiesView.ActiveViewIndex = 0;
            ClearFields();
        }


        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        public void ClearFields()
        {
            txtDescription.Text = "";
            rbIsActive.SelectedValue = "1";
        }

    }
}