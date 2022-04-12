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
    public partial class SpecialConsultationCaseDetails : System.Web.UI.Page
    {

        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GenearateSpecialityConsultancyCaseId();
                LoadSpecialityConsultantCaseDetails();
                //txtCaseEntryDate.Text = DateTime.Now.ToString();


                //LoadDoctorDetails();
                //LoadMasterLanguage();
                //LoadMasterDocuments();
                //LoadState();
                // LoadCorporate();
                //SpecialistConultantView.ActiveViewIndex = 0;
            }
        }



        public void LoadSpecialityConsultantCaseDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();


            dtCaseDetails = BusinessAccessLayer.LoadSpecialistConsultantCaseDetails();
            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                rgvSpecialityConsultancyCaseDetails.DataSource = dtCaseDetails;
                rgvSpecialityConsultancyCaseDetails.DataBind();
            }
            else
            {
                rgvSpecialityConsultancyCaseDetails.DataSource = null;
                rgvSpecialityConsultancyCaseDetails.DataBind();
            }

        }








        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ClearFields();
            //SpecialistConultantView.ActiveViewIndex = 0;
        }




        protected void rgvSpecialityConsultancyCaseDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvSpecialityConsultancyCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvSpecialityConsultancyCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());


                if (e.CommandName == "AssignToDoctor")
                {
                    Label lbl_SpecialityConsultantCaseDetailsId = (Label)rgvSpecialityConsultancyCaseDetails.Items[intIndex % 10].FindControl("lbl_SpecialityConsultantCaseDetailsId");

                    Variables.SpecialityConsultantCaseDetailsId = Convert.ToInt32(lbl_SpecialityConsultantCaseDetailsId.Text.Trim());
                    Response.Redirect("~/Appointment/SpecialistConsultantAppointment.aspx");


                }

                if (e.CommandName == "EditRow")
                {
                    Label lblSpecialityConsultantCaseDetailsId = (Label)rgvSpecialityConsultancyCaseDetails.Items[intIndex % 10].FindControl("lblSpecialityConsultantCaseDetailsId"); // % 15 for page indexing
                    Variables.SpecialityConsultantCaseDetailsId = Convert.ToInt32(lblSpecialityConsultantCaseDetailsId.Text.Trim());
                    Response.Redirect("~/Case/AddSpecialConsultantCase.aspx");
                }









            }
            catch (Exception ex)
            {


            }
        }



        protected void btnSpecialConsultant_Click(object sender, EventArgs e)
        {
            // SpecialistConultantView.ActiveViewIndex = 1;
        }

        protected void chkCaseId_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridDataItem editItem = (GridDataItem)chk.NamingContainer;
            GridDataItem ditem = (GridDataItem)editItem;
            ditem.Selected = true;

            int index = ditem.ItemIndex;

            Label lbl = (Label)editItem.FindControl("lbl_SpecialityConsultantCaseDetailsId");


            Variables.SpecialityConsultantCaseDetailsId = Convert.ToInt32(lbl.Text.Trim());
            Response.Redirect("~/Appointment/SpecialistConsultantAppointment.aspx");
        }

        protected void txtSearchCaseId_TextChanged(object sender, EventArgs e)
        {
            //txtsearchCorporateName.Text = "";
            //cmbSearchCaseStatus.SelectedValue = "0";
            //SearchSpecialitiesConsultantCaseDetails(txtSearchCaseId.Text.Trim(), txtsearchCorporateName.Text.Trim(), cmbSearchCaseStatus.SelectedValue, "CaseId");
        }

        protected void txtsearchCorporateName_TextChanged(object sender, EventArgs e)
        {
            //txtSearchCaseId.Text = "";
            //cmbSearchCaseStatus.SelectedValue = "0";
            //SearchSpecialitiesConsultantCaseDetails(txtSearchCaseId.Text.Trim(), txtsearchCorporateName.Text.Trim(), cmbSearchCaseStatus.SelectedValue, "CorporateName");
        }

        protected void cmbSearchCaseStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //txtSearchCaseId.Text = "";
            //txtsearchCorporateName.Text = "";
            //SearchSpecialitiesConsultantCaseDetails(txtSearchCaseId.Text.Trim(), txtsearchCorporateName.Text.Trim(), cmbSearchCaseStatus.SelectedValue, "CaseStatus");
        }

        public void SearchSpecialitiesConsultantCaseDetails(string CaseId, string CorporateName, string CaseStatus, string SearchType)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtPackage = new DataTable();
            dtPackage = BusinessAccessLayer.SearchSpecialitiesConsultantCaseDetails(CaseId, CorporateName, CaseStatus, SearchType);

            if (dtPackage != null && dtPackage.Rows.Count > 0)
            {
                rgvSpecialityConsultancyCaseDetails.DataSource = dtPackage;
                rgvSpecialityConsultancyCaseDetails.DataBind();

            }
            else
            {
                rgvSpecialityConsultancyCaseDetails.DataSource = null;
                rgvSpecialityConsultancyCaseDetails.DataBind();
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            LoadSpecialityConsultantCaseDetails();
        }

        protected void btnAdvanced_Click(object sender, EventArgs e)
        {
            if (AdvancedSearch.Visible == true)
            {
                AdvancedSearch.Visible = false;
            }
            else
            {
                AdvancedSearch.Visible = true;
            }
        }
    }
}