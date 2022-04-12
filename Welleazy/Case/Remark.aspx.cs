using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Case
{
    public partial class Remark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    int caserefid = Variables.CaseRefId;
                    LoadCaseRemarkDetails();
                    LoadAppointmentRemarkDetails();
                    LoadReportRemarkDetails();
                }
            }
        }



        //Case Remark
        public void LoadCaseRemarkDetails()
        {
            DataTable dtLoadCaseRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadCaseRemarkDetailsList = BusinessAccessLayer.LoadCaseRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadCaseRemarkDetailsList != null && dtLoadCaseRemarkDetailsList.Rows.Count > 0)
            {
                rgvCaseRemarkDetails.DataSource = dtLoadCaseRemarkDetailsList;
                rgvCaseRemarkDetails.DataBind();
            }
            else
            {
                rgvCaseRemarkDetails.DataSource = new object[] { }; ;
                rgvCaseRemarkDetails.DataBind();
            }
        }

        protected void rgvCaseRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvCaseRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadCaseRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadCaseRemarkDetailsList = BusinessAccessLayer.LoadCaseRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadCaseRemarkDetailsList != null && dtLoadCaseRemarkDetailsList.Rows.Count > 0)
            {
                rgvCaseRemarkDetails.DataSource = dtLoadCaseRemarkDetailsList;
                //rgvCaseRemarkDetails.DataBind();
            }
            else
            {
                rgvCaseRemarkDetails.DataSource = new object[] { }; ;
                //rgvCaseRemarkDetails.DataBind();
            }
        }

        protected void rgvCaseRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        //Appointment Remark

        public void LoadAppointmentRemarkDetails()
        {
            DataTable dtLoadAppointmentRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadAppointmentRemarkDetailsList = BusinessAccessLayer.LoadAppointmentRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadAppointmentRemarkDetailsList != null && dtLoadAppointmentRemarkDetailsList.Rows.Count > 0)
            {
                rgvAppointmentRemarkDetails.DataSource = dtLoadAppointmentRemarkDetailsList;
                rgvAppointmentRemarkDetails.DataBind();
            }
            else
            {
                rgvAppointmentRemarkDetails.DataSource = new object[] { }; ;
                rgvAppointmentRemarkDetails.DataBind();
            }
        }

        protected void rgvAppointmentRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvAppointmentRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadAppointmentRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadAppointmentRemarkDetailsList = BusinessAccessLayer.LoadAppointmentRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadAppointmentRemarkDetailsList != null && dtLoadAppointmentRemarkDetailsList.Rows.Count > 0)
            {
                rgvAppointmentRemarkDetails.DataSource = dtLoadAppointmentRemarkDetailsList;
                //rgvAppointmentRemarkDetails.DataBind();
            }
            else
            {
                rgvAppointmentRemarkDetails.DataSource = new object[] { }; ;
                //rgvAppointmentRemarkDetails.DataBind();
            }
        }

        protected void rgvAppointmentRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        //Report Remark

        public void LoadReportRemarkDetails()
        {
            DataTable dtLoadReportRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadReportRemarkDetailsList = BusinessAccessLayer.LoadReportRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadReportRemarkDetailsList != null && dtLoadReportRemarkDetailsList.Rows.Count > 0)
            {
                rgvReportRemarkDetails.DataSource = dtLoadReportRemarkDetailsList;
                rgvReportRemarkDetails.DataBind();
            }
            else
            {
                rgvReportRemarkDetails.DataSource = new object[] { }; ;
                rgvReportRemarkDetails.DataBind();
            }
        }

        protected void rgvReportRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvReportRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadReportRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadReportRemarkDetailsList = BusinessAccessLayer.LoadReportRemarkDetailsList(Variables.CaseRefId);

            if (dtLoadReportRemarkDetailsList != null && dtLoadReportRemarkDetailsList.Rows.Count > 0)
            {
                rgvReportRemarkDetails.DataSource = dtLoadReportRemarkDetailsList;
                //rgvReportRemarkDetails.DataBind();
            }
            else
            {
                rgvReportRemarkDetails.DataSource = new object[] { }; ;
                //rgvReportRemarkDetails.DataBind();
            }
        }

        protected void rgvReportRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }
    }
}