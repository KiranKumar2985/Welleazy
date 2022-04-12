using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Appointment
{
    public partial class SpecialistConsultantClosedAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadSpecialistConsultantAppointmentDeails();
                //StateList();
                //CorporateList();
                SpecialistConultantApointmentView.ActiveViewIndex = 0;
            }
        }

        public void LoadSpecialistConsultantAppointmentDeails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEConsultantAppointment = new DataTable();
            dtEConsultantAppointment = BusinessAccessLayer.LoadSpecialistConsultantAppointmentDeails();
            if (dtEConsultantAppointment != null && dtEConsultantAppointment.Rows.Count > 0)
            {
                rgvSpecialistConsultanntClosedAppointmentDetails.DataSource = dtEConsultantAppointment;
                rgvSpecialistConsultanntClosedAppointmentDetails.DataBind();
            }
            else
            {
                rgvSpecialistConsultanntClosedAppointmentDetails.DataSource = null;
                rgvSpecialistConsultanntClosedAppointmentDetails.DataBind();
            }
        }

        protected void lnlAppointmentList_Click(object sender, EventArgs e)
        {

        }

        protected void rgvSpecialistConsultanntClosedAppointmentDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvSpecialistConsultanntClosedAppointmentDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvSpecialistConsultanntClosedAppointmentDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
    }
}