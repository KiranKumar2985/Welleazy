using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Appointment
{
    public partial class ConsultationCaseAppointmentDetailsHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadConsultationAppointmentDeails();
                ConsultationCaseApointmentView.ActiveViewIndex = 0;
            }
        }

        protected void rgvConsultantCaseAppointmentDetailsHistory_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvConsultantCaseAppointmentDetailsHistory_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvConsultantCaseAppointmentDetailsHistory_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            
        }

        public void LoadConsultationAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadConsultationCaseAppointmentDetailsHistory();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvConsultantCaseAppointmentDetailsHistory.DataSource = dtEConsultantAppointment;
                rgvConsultantCaseAppointmentDetailsHistory.DataBind();
            }
            else
            {
                rgvConsultantCaseAppointmentDetailsHistory.DataSource = new object[] { };
                rgvConsultantCaseAppointmentDetailsHistory.DataBind();
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

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

        protected void rcbClientName_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbStateSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
    }
}