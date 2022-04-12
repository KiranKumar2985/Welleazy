using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.CaseLogs
{
    public partial class CaseLogDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                    LoadConsultationCaseLogDetails();
                
                
            }
        }

        public void LoadConsultationCaseLogDetails()
        {
            Int32 ConsultationCaseDetailsId = 0;
            Bal BusinessAcessLayer = new Bal();
            DataSet dtLoadConsultationCaseLogDetails = new DataSet();
            if (Session["ConsultationCaseDetailsId"] != null)
            {
                ConsultationCaseDetailsId = Convert.ToInt32(Session["ConsultationCaseDetailsId"]);
            }
                dtLoadConsultationCaseLogDetails = BusinessAcessLayer.LoadConsultationCaseLogDetails(ConsultationCaseDetailsId);
            //dtLoadConsultationCaseLogDetails = BusinessAcessLayer.LoadConsultationCaseLogDetails(12);

            if (dtLoadConsultationCaseLogDetails!=null && dtLoadConsultationCaseLogDetails.Tables[0].Rows.Count>0)
            {
                rgvCaseRemarkDetails.DataSource = dtLoadConsultationCaseLogDetails;
                rgvCaseRemarkDetails.DataBind();
            }

            if (dtLoadConsultationCaseLogDetails != null && dtLoadConsultationCaseLogDetails.Tables[1].Rows.Count > 0)
            {
                rgvAppointmentRemarkDetails.DataSource = dtLoadConsultationCaseLogDetails.Tables[1];
                rgvAppointmentRemarkDetails.DataBind();
            }


        }

        protected void rgvReportRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvReportRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvReportRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvAppointmentRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvAppointmentRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvAppointmentRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void rgvCaseRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvCaseRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvCaseRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }
    }
}