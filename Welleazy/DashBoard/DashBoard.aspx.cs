using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Welleazy.DashBoard
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAdminDashBoard();
            }


        }

        public void LoadAdminDashBoard()
        {
            Bal BusinessAccessLayer = new Bal();
            
            
            DataSet dtAdminDashBoard = new DataSet();
            dtAdminDashBoard= BusinessAccessLayer.LoadAdminDashBoard();

            if(dtAdminDashBoard!=null)
            {
                lblCorporateCount.Text = dtAdminDashBoard.Tables[0].Rows[0]["CorporateCount"].ToString(); ;
                lblClosedCaseCount.Text = dtAdminDashBoard.Tables[1].Rows[0]["ClosedCaseCount"].ToString();
                lblOpenCaseCount.Text = dtAdminDashBoard.Tables[2].Rows[0]["OpenCaseCount"].ToString();
                lblAppointmentScheduledCount.Text = dtAdminDashBoard.Tables[3].Rows[0]["ScheduledAppointmentCount"].ToString();
            }
        }
    }
}