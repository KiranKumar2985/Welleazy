using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace Welleazy.Interpretation
{
    public partial class InterpretationCaseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InterpretationTypeList();
                CorporateList();
                InterpretationCaseStatusList();
                LoadDoctor();
                
                if (Session["LoginType"].Equals("1"))
                {
                    Variables.CorporateId = Convert.ToInt32(Session["CorporateId"].ToString());
                    Bal BusinessAccessLayerC = new Bal();
                    DataTable dtCorporateDetails = new DataTable();
                    dtCorporateDetails = BusinessAccessLayerC.LoadCorporateDetails(Variables.CorporateId);


                    if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
                    {
                        string CorporateId = dtCorporateDetails.Rows[0]["CorporateId"].ToString();
                        String[] CorporateIdValue = CorporateId.Split(',');

                        int lenght = CorporateIdValue.Length;

                        foreach (string s in CorporateIdValue)
                        {
                            foreach (RadComboBoxItem item in rcbCorporate.Items)//ListItem item in rcbMedicalTest.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;
                                    //item.Selected = true;
                                    break;
                                }
                            }
                        }
                        rcbCorporate.Enabled = false;
                    }
                }
                else if (Session["LoginType"].Equals("3"))
                {
                    Variables.DoctorId = Convert.ToInt32(Session["EmployeeRefId"].ToString());
                    Bal BusinessAccessLayerC = new Bal();
                    DataSet dtDoctorDetails = new DataSet();
                    dtDoctorDetails = BusinessAccessLayerC.FetchDoctorDetailsById(Variables.DoctorId);


                    if (dtDoctorDetails != null && dtDoctorDetails.Tables[0].Rows.Count > 0)
                    {
                        string DoctorId = dtDoctorDetails.Tables[0].Rows[0]["DoctorId"].ToString();
                        String[] DoctorIdValue = DoctorId.Split(',');

                        int lenght = DoctorIdValue.Length;

                        foreach (string s in DoctorIdValue)
                        {
                            foreach (RadComboBoxItem item in rcbDoctorList.Items)
                            {
                                if (item.Value == s)
                                {
                                    item.Checked = true;
                                    //item.Selected = true;
                                    break;
                                }
                            }
                        }
                        rcbDoctorList.Enabled = false;
                        cmbAssign.Enabled = false;
                    }
                }
                LoadInterpretationCaseDetails();
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                rcbCorporate.DataSource = dtLoadCorporateList;
                rcbCorporate.DataTextField = "CorporateName";
                rcbCorporate.DataValueField = "CorporateId";
                rcbCorporate.DataBind();

            }
            else
            {
                rcbCorporate.DataSource = null;
                rcbCorporate.DataBind();
            }
        }

        public void InterpretationTypeList()
        {
            DataTable dtInterpretationTypeList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationTypeList = BusinessAccessLayer.LoadInterpretationTypeDropDown();

            if (dtInterpretationTypeList != null && dtInterpretationTypeList.Rows.Count > 0)
            {
                rcbInterpretationType.DataSource = dtInterpretationTypeList;
                rcbInterpretationType.DataTextField = "InterpretationType";
                rcbInterpretationType.DataValueField = "InterpretationTypeId";
                rcbInterpretationType.DataBind();

            }
            else
            {
                rcbInterpretationType.DataSource = null;
                rcbInterpretationType.DataBind();
            }
        }

        public void InterpretationCaseStatusList()
        {
            DataTable dtInterpretationCaseStatusList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtInterpretationCaseStatusList = BusinessAccessLayer.LoadCaseStatusList(3);

            if (dtInterpretationCaseStatusList != null && dtInterpretationCaseStatusList.Rows.Count > 0)
            {
                rcbCaseStatus.DataSource = dtInterpretationCaseStatusList;
                rcbCaseStatus.DataTextField = "CaseStatusName";
                rcbCaseStatus.DataValueField = "StatusId";
                rcbCaseStatus.DataBind();

                List<string> list = new List<string>() { "42" };
                foreach (var item in list)
                {
                    RadComboBoxItem items = rcbCaseStatus.Items.FindItemByValue(item);
                    if (item != null)
                    {
                        items.Remove();
                    }
                }

            }
            else
            {
                rcbCaseStatus.DataSource = null;
                rcbCaseStatus.DataBind();
            }
        }

        public void LoadDoctor()
        {
            Bal BusinessAccesslayer = new Bal();
            DataTable dtDoctorDetails = new DataTable();
            dtDoctorDetails = BusinessAccesslayer.FetchDoctorDetails();

            if (dtDoctorDetails != null && dtDoctorDetails.Rows.Count > 0)
            {
                rcbDoctorList.DataSource = dtDoctorDetails;
                rcbDoctorList.DataTextField = "DoctorName";
                rcbDoctorList.DataValueField = "DoctorId";
                rcbDoctorList.DataBind();

                cmbAssignDoctorList.DataSource = dtDoctorDetails;
                cmbAssignDoctorList.DataTextField = "DoctorName";
                cmbAssignDoctorList.DataValueField = "DoctorId";
                cmbAssignDoctorList.DataBind();
            }
        }

        public void LoadInterpretationCaseDetails()
        {
            DataTable dtLoadCaseDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCaseDetailsList = BusinessAccessLayer.LoadInterpretationCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadCaseDetailsList != null && dtLoadCaseDetailsList.Rows.Count > 0)
            {
                rgvInterpretationCaseDetails.DataSource = dtLoadCaseDetailsList;
                rgvInterpretationCaseDetails.DataBind();

                 }
            else
            {
                rgvInterpretationCaseDetails.DataSource = new object[] { };
                rgvInterpretationCaseDetails.DataBind();
            }
            
        }
        protected void rgvInterpretationCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblInterpretationCaseIdI = (Label)rgvInterpretationCaseDetails.Items[intIndex % 10].FindControl("lblInterpretationCaseIdI"); // % 15 for page indexing
                    Variables.InterpretationCaseId = Convert.ToInt32(lblInterpretationCaseIdI.Text.Trim());

                    
                    if (Session["LoginType"].Equals("3"))
                    {
                        Response.Redirect("~/Interpretation/InterpretationReport.aspx");  //Doctor View
                    }
                    else
                    {
                        Response.Redirect("~/Interpretation/AddCase.aspx");
                    }
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void rgvInterpretationCaseDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadTestDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadTestDetailsList = BusinessAccessLayer.LoadInterpretationCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadTestDetailsList != null && dtLoadTestDetailsList.Rows.Count > 0)
            {
                rgvInterpretationCaseDetails.DataSource = dtLoadTestDetailsList;
                //rgvInterpretationCaseDetails.DataBind();
            }
            else
            {
                rgvInterpretationCaseDetails.DataSource = new object[] { };
                //rgvInterpretationCaseDetails.DataBind();
            }
        }

        protected void rgvInterpretationCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadInterpretationCaseDetails();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";
            string CorporateId = "";
            string CaseType = "";
            string DoctorList = "";
            string InterpretationType = "";
            string CaseStatus = "";

            if (Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("0") && Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select InterpretationCaseId, CaseEntryDateTime, CaseType, ICD.CorporateId, MCD.CorporateName, CustomerName, ApplicationNo, PolicyNo, " +
                            "CaseRecMode, ICD.InterpretationType, MIT.InterpretationType as InterpretationTypeText, CaseRemark, ICD.CaseStatus, MICS.CaseStatusName, " +
                            "ReportName, ReportData, ICD.DoctorId, MD.DoctorName, ICD.QCExecutiveId, TU.name, InterpretationAssignDate, InterpretationClosedDate, ICD.CreatedOn, ICD.CreatedBy, ICD.UpdatedOn, ICD.UpdatedBy from InterpretationCaseDetails ICD " +
                            " left join Master_CorporateDetails MCD on MCD.CorporateId = ICD.CorporateId " +
                            " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                            " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus" +
                            " left join Master_Doctor MD on MD.DoctorId=ICD.DoctorId" +
                            " left join tbl_user as TU on TU.user_id = ICD.QCExecutiveId";
                ConditionQuery = " order by InterpretationCaseId desc";
            }
            else if (!Session["EmployeeRefId"].Equals("0") && Session["LoginType"].Equals("1") && !Session["CorporateId"].Equals("0"))
            {
                MainQuery = "Select InterpretationCaseId, CaseEntryDateTime, CaseType, ICD.CorporateId, MCD.CorporateName, CustomerName, ApplicationNo, PolicyNo, " +
                            "CaseRecMode, ICD.InterpretationType, MIT.InterpretationType as InterpretationTypeText, CaseRemark, ICD.CaseStatus, MICS.CaseStatusName, " +
                            "ReportName, ReportData, ICD.DoctorId, MD.DoctorName, ICD.QCExecutiveId, TU.name, InterpretationAssignDate, InterpretationClosedDate, ICD.CreatedOn, ICD.CreatedBy, ICD.UpdatedOn, ICD.UpdatedBy from InterpretationCaseDetails ICD " +
                            " left join Master_CorporateDetails MCD on MCD.CorporateId = ICD.CorporateId " +
                            " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                            " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus" +
                            " left join Master_Doctor MD on MD.DoctorId=ICD.DoctorId" +
                            " left join tbl_user as TU on TU.user_id = ICD.QCExecutiveId";
                ConditionQuery = " and ICD.CorporateId=" + Session["CorporateId"] + " order by InterpretationCaseId desc";
            }
            else
            {
                MainQuery = "Select InterpretationCaseId, CaseEntryDateTime, CaseType, ICD.CorporateId, MCD.CorporateName, CustomerName, ApplicationNo, PolicyNo, " +
                            "CaseRecMode, ICD.InterpretationType, MIT.InterpretationType as InterpretationTypeText, CaseRemark, ICD.CaseStatus, MICS.CaseStatusName, " +
                            "ReportName, ReportData, ICD.DoctorId, MD.DoctorName, ICD.QCExecutiveId, TU.name, InterpretationAssignDate, InterpretationClosedDate, ICD.CreatedOn, ICD.CreatedBy, ICD.UpdatedOn, ICD.UpdatedBy from InterpretationCaseDetails ICD " +
                            " left join Master_CorporateDetails MCD on MCD.CorporateId = ICD.CorporateId " +
                            " left join Master_InterpretationType MIT on MIT.InterpretationTypeId = ICD.InterpretationType " +
                            " left join Master_CaseStatus MICS on MICS.StatusId = ICD.CaseStatus" +
                            " left join Master_Doctor MD on MD.DoctorId=ICD.DoctorId" +
                            " left join tbl_user as TU on TU.user_id = ICD.QCExecutiveId";
                ConditionQuery = " and ICD.DoctorId=" + Session["EmployeeRefId"] + " order by InterpretationCaseId desc";
            }


            for (int i = 0; i < rcbCorporate.CheckedItems.Count; i++)
            {
                if (CorporateId == "")
                {
                    CorporateId = rcbCorporate.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CorporateId += "," + rcbCorporate.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbCaseType.CheckedItems.Count; i++)
            {
                if (CaseType == "")
                {
                    CaseType = rcbCaseType.CheckedItems[i].Text.Trim();
                }
                else
                {
                    CaseType += "," + rcbCaseType.CheckedItems[i].Text.Trim();
                }
            }

            for (int i = 0; i < rcbInterpretationType.CheckedItems.Count; i++)
            {
                if (InterpretationType == "")
                {
                    InterpretationType = rcbInterpretationType.CheckedItems[i].Value.Trim();
                }
                else
                {
                    InterpretationType += "," + rcbInterpretationType.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbCaseStatus.CheckedItems.Count; i++)
            {
                if (CaseStatus == "")
                {
                    CaseStatus = rcbCaseStatus.CheckedItems[i].Value.Trim();
                }
                else
                {
                    CaseStatus += "," + rcbCaseStatus.CheckedItems[i].Value.Trim();
                }
            }

            for (int i = 0; i < rcbDoctorList.CheckedItems.Count; i++)
            {
                if (DoctorList == "")
                {
                    DoctorList = rcbDoctorList.CheckedItems[i].Value.Trim();
                }
                else
                {
                    DoctorList += "," + rcbDoctorList.CheckedItems[i].Value.Trim();
                }
            }

            if (CorporateId != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.CorporateId in (" + CorporateId + ")";
                }
                else
                {
                    Query += "And ICD.CorporateId in(" + CorporateId + ")";
                }
            }
            
            if (CaseType != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where CaseType in ('" + CaseType + "')";
                }
                else
                {
                    Query += " And CaseType in('" + CaseType + "')";
                }
            }
            
            if (InterpretationType != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.InterpretationType in ('" + InterpretationType + "')";
                }
                else
                {
                    Query += " And ICD.InterpretationType in('" + InterpretationType + "')";
                }
            }

            if (CaseStatus != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.CaseStatus in (" + CaseStatus + ")";
                }
                else
                {
                    Query += " And ICD.CaseStatus in (" + CaseStatus + ")";
                }
            }

            if (DoctorList != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ICD.DoctorId in (" + DoctorList + ")";
                }
                else
                {
                    Query += " And ICD.DoctorId in (" + DoctorList + ")";
                }
            }

            if (txt_ApplicationNo.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ApplicationNo like '%" + txt_ApplicationNo.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ApplicationNo like '%" + txt_ApplicationNo.Text.Trim() + "%'";
                }
            }


            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseDetails = new DataTable();
            dtCaseDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtCaseDetails != null && dtCaseDetails.Rows.Count > 0)
            {
                rgvInterpretationCaseDetails.DataSource = dtCaseDetails;
                rgvInterpretationCaseDetails.DataBind();
            }
            else
            {
                rgvInterpretationCaseDetails.DataSource = new object[] { };
                rgvInterpretationCaseDetails.DataBind();
            }

        }

        protected void cmbExport_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbExport.SelectedValue == "1")
            {
                btnDownload.Text = "Export to CSV";
            }
            else
            {
                btnDownload.Text = "Export to Excel";
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExport.SelectedValue == "1")
                {
                    //foreach (GridDataItem item in rgCaseDetails.MasterTableView.Items)
                    //    item.Visible = item.Selected;
                    int x = rgvInterpretationCaseDetails.Items.Count;
                    if (x > 10)
                    {
                        rgvInterpretationCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgvInterpretationCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    //rgCaseDetails.ExportSettings.IgnorePaging = true;
                    rgvInterpretationCaseDetails.MasterTableView.ExportToCSV();
                    rgvInterpretationCaseDetails.ExportSettings.FileName = "InterPreClosedData";
                }

                else if (cmbExport.SelectedValue == "2")
                {
                    int x = rgvInterpretationCaseDetails.Items.Count;
                    if (x > 10)
                    {
                        rgvInterpretationCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgvInterpretationCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgvInterpretationCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgvInterpretationCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    rgvInterpretationCaseDetails.MasterTableView.ExportToExcel();
                }
                else
                {

                    //ApplyStylesToPdfExport(rgvConsultationCaseDetails.MasterTableView);
                    //rgvConsultationCaseDetails.MasterTableView.ExportToPdf();

                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbAssign_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(cmbAssign.SelectedValue=="0")
            {
                
            }
            else
            {
                bool showModal = true;

                if (showModal)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //bool showModal = true;
            //if (showModal)
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);

            if (cmbAssignDoctorList.SelectedValue =="0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Select Doctor to Assign!');</script>");
                return;
            }
            else
            {
                Bal BusinessAccessLayer = new Bal();

                foreach (GridDataItem item in rgvInterpretationCaseDetails.MasterTableView.Items)
                {
                    CheckBox chkTax = (item.FindControl("chkTax") as CheckBox);
                    Label lblInterpretationCaseIdI =(item.FindControl("lblInterpretationCaseIdI") as Label); 
                    Variables.InterpretationCaseId = Convert.ToInt32(lblInterpretationCaseIdI.Text.Trim());
                    Label lblCaseStatusId= (item.FindControl("lblCaseStatusId") as Label);
                    Label lblInterpretationAssignDate = (item.FindControl("lblInterpretationAssignDate") as Label);

                    if (chkTax.Checked==true)
                    {
                        if (lblCaseStatusId.Text == "40")
                        {
                            //return;
                        }
                        else if (lblCaseStatusId.Text == "36")
                        {
                            BusinessAccessLayer.InsertUpdateInterpretationCaseAssign(Variables.InterpretationCaseId, 37,
                                    Convert.ToInt32(cmbAssignDoctorList.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));
                        }
                        else
                        {
                            BusinessAccessLayer.InsertUpdateInterpretationCaseAssign(Variables.InterpretationCaseId, 37,
                                    Convert.ToInt32(cmbAssignDoctorList.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));
                        }
                        
                    }
                   
                }

                
                LoadInterpretationCaseDetails();
                cmbAssign.SelectedValue = "0";
                cmbAssignDoctorList.SelectedValue = "0";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Assign Case Successfully');</script>");
                
            }
        }

        protected void rgvInterpretationCaseDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
                foreach (GridDataItem item in rgvInterpretationCaseDetails.MasterTableView.Items)
                {
                    Label lblInterpretationCaseIdI = (item.FindControl("lblInterpretationCaseIdI") as Label);
                    Variables.InterpretationCaseId = Convert.ToInt32(lblInterpretationCaseIdI.Text.Trim());
                    Label lblCaseStatus = (item.FindControl("lblCaseStatus") as Label);

                    if(lblCaseStatus.Text=="Completed")
                    {
                    item.ForeColor = System.Drawing.Color.Red;
                    }

                    //GridDataItem dataBoundItem = e.Item as GridDataItem;
                    //if (dataBoundItem["CaseStatusName"].Text == "Completed")
                    //{
                    //    dataBoundItem.ForeColor = System.Drawing.Color.Red;
                    //}
                }

            //}
        }

    }
}