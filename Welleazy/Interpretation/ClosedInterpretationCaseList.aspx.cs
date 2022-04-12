using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Interpretation
{
    public partial class ClosedInterpretationCaseList : System.Web.UI.Page
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
                    }
                }
                LoadInterpretationClosedCaseDetails();
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

                List<string> list = new List<string>() { "36", "37", "38", "39", "41" };
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
            }
        }

        public void LoadInterpretationClosedCaseDetails()
        {
            DataTable dtLoadClosedCaseDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadClosedCaseDetailsList = BusinessAccessLayer.LoadInterpretationClosedCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadClosedCaseDetailsList != null && dtLoadClosedCaseDetailsList.Rows.Count > 0)
            {
                rgvInterpretationClosedCaseDetails.DataSource = dtLoadClosedCaseDetailsList;
                rgvInterpretationClosedCaseDetails.DataBind();
            }
            else
            {
                rgvInterpretationClosedCaseDetails.DataSource = new object[] { };
                rgvInterpretationClosedCaseDetails.DataBind();
            }

        }

        protected void rgvInterpretationClosedCaseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblInterpretationCaseIdI = (Label)rgvInterpretationClosedCaseDetails.Items[intIndex % 10].FindControl("lblInterpretationCaseIdI"); // % 15 for page indexing
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

            if (e.CommandName.Equals("ViewReport"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblInterpretationCaseIdR = (Label)rgvInterpretationClosedCaseDetails.Items[intIndex % 10].FindControl("lblInterpretationCaseId");
                    Variables.InterpretationCaseId = Convert.ToInt32(lblInterpretationCaseIdR.Text.Trim());

                    DataSet dtReport = new DataSet();
                    Bal BusinessAccessLayer = new Bal();
                    dtReport = BusinessAccessLayer.LoadInterpretationCaseDetailsById(Variables.InterpretationCaseId);
                    //string Filename = "";
                    //byte[] FileData = new byte[5242880];
                    //if (dtReport != null && dtReport.Tables[0].Rows.Count > 0)
                    //{
                    //    Filename = dtReport.Tables[0].Rows[0]["ReportName"].ToString();
                    //    //FileData= Convert.ToByte(dtReport.Rows[0][""].ToString());
                    //    FileData = (byte[])dtReport.Tables[0].Rows[0]["ReportData"];
                    //}

                    //// string directoryName = String.Empty;
                    ////var path = HttpRuntime.AppDomainAppPath;
                    ////directoryName = System.IO.Path.Combine(path, "UploadImages");

                    //string FilePath = @"E:\Welleazy\Welleazy\AppointmentReports\" + Filename;
                    //File.WriteAllBytes(FilePath, FileData);
                    string Filename = "";
                    //string InterpretationCaseId = "";
                    if (dtReport != null && dtReport.Tables[0].Rows.Count > 0)
                    {
                        Filename = dtReport.Tables[0].Rows[0]["DoctorReport"].ToString();
                        //InterpretationCaseId = Convert.ToInt32(Variables.InterpretationCaseId).ToString();

                        
                    }
                    string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                    string FilePath = directory + "InterpretationReports" + "\\" + Filename;
                    Session["FilePath"] = FilePath;
                        //Session["InterpretationCaseId"] = InterpretationCaseId;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../ViewDocuments/ViewDocument.aspx');", true);

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:1125/ViewDocuments/ViewDocument.aspx','_blank');", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">window.location.href='ViewDocument.aspx';</script>");

                    //Response.Redirect("~/ViewDocuments/ViewDocument.aspx"); //--Running Code


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
                }
            }
        }

        protected void rgvInterpretationClosedCaseDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtLoadTestDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadTestDetailsList = BusinessAccessLayer.LoadInterpretationCaseDetailsList(Convert.ToInt32(Session["EmployeeRefId"]), 0, Convert.ToInt32(Session["LoginType"]), Convert.ToInt32(Session["CorporateId"]));

            if (dtLoadTestDetailsList != null && dtLoadTestDetailsList.Rows.Count > 0)
            {
                rgvInterpretationClosedCaseDetails.DataSource = dtLoadTestDetailsList;
                //rgvInterpretationClosedCaseDetails.DataBind();
            }
            else
            {
                rgvInterpretationClosedCaseDetails.DataSource = new object[] { };
                //rgvInterpretationClosedCaseDetails.DataBind();
            }
        }

        protected void rgvInterpretationClosedCaseDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadInterpretationClosedCaseDetails();
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
                ConditionQuery = " and CaseStatus = '40' OR CaseStatus = '42' order by InterpretationCaseId desc";
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
                ConditionQuery = " and CaseStatus = '40' OR CaseStatus = '42' and ICD.CorporateId=" + Session["CorporateId"] + " order by InterpretationCaseId desc";
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
                ConditionQuery = "  and CaseStatus = '40' OR CaseStatus = '42' and ICD.DoctorId=" + Session["EmployeeRefId"] + " order by InterpretationCaseId desc";
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
                rgvInterpretationClosedCaseDetails.DataSource = dtCaseDetails;
                rgvInterpretationClosedCaseDetails.DataBind();
            }
            else
            {
                rgvInterpretationClosedCaseDetails.DataSource = new object[] { };
                rgvInterpretationClosedCaseDetails.DataBind();
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
                    int x = rgvInterpretationClosedCaseDetails.Items.Count;
                    if (x > 10)
                    {
                        rgvInterpretationClosedCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgvInterpretationClosedCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    //rgCaseDetails.ExportSettings.IgnorePaging = true;
                    rgvInterpretationClosedCaseDetails.MasterTableView.ExportToCSV();
                    rgvInterpretationClosedCaseDetails.ExportSettings.FileName = "InterPreClosedData";
                }

                else if (cmbExport.SelectedValue == "2")
                {
                    int x = rgvInterpretationClosedCaseDetails.Items.Count;
                    if (x > 10)
                    {
                        rgvInterpretationClosedCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgvInterpretationClosedCaseDetails.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        rgvInterpretationClosedCaseDetails.ExportSettings.ExportOnlyData = false;
                        //ApplyStylesToPdfExport(rgCaseDetails.MasterTableView);
                        rgvInterpretationClosedCaseDetails.ExportSettings.IgnorePaging = false;
                    }
                    rgvInterpretationClosedCaseDetails.MasterTableView.ExportToExcel();
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

        protected void rgvInterpretationClosedCaseDetails_ItemDataBound(object sender, GridItemEventArgs e)
        {
            foreach (GridDataItem item in rgvInterpretationClosedCaseDetails.MasterTableView.Items)
            {
                Label lblInterpretationCaseIdI = (item.FindControl("lblInterpretationCaseIdI") as Label);
                Variables.InterpretationCaseId = Convert.ToInt32(lblInterpretationCaseIdI.Text.Trim());
                Label lblCaseStatus = (item.FindControl("lblCaseStatus") as Label);

                if (lblCaseStatus.Text == "Completed")
                {
                    item.ForeColor = System.Drawing.Color.Red;
                }

                //GridDataItem dataBoundItem = e.Item as GridDataItem;
                //if (dataBoundItem["CaseStatusName"].Text == "Completed")
                //{
                //    dataBoundItem.ForeColor = System.Drawing.Color.Red;
                //}
            }
        }
    }
}