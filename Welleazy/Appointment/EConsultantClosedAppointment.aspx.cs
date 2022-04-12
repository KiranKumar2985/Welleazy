using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.Appointment
{
    public partial class EConsultantClosedAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEConsultantCloseAppointmentDeails();
                //StateList();
                //CorporateList();
                EConultantCloseApointmentView.ActiveViewIndex = 0;
            }
        }

        public void LoadEConsultantCloseAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadEConsultantCloseAppointmentDeails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvEConsultancyAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvEConsultancyAppointmentDetails.DataBind();
            }
            else
            {
                rgvEConsultancyAppointmentDetails.DataSource = null;
                rgvEConsultancyAppointmentDetails.DataBind();
            }
        }

        protected void rgvEConsultancyAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvEConsultancyAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvEConsultancyAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void lnlAppointmentList_Click(object sender, EventArgs e)
        {

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
    }
}