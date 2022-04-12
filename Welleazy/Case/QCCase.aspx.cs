using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Case
{
    public partial class QCCase : System.Web.UI.Page
    {
        static int IsDataExists = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadStatusDropDown();
                LoadQCCaseSummaryDetails();
                LoadQCQuestion();
                LoadPDFDocument();
                LoadCustomerDetails();
                //LoadCaseDetailsByIdForReport();
            }
        }

        public void LoadCustomerDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCustomerDetails = new DataTable();
            dtCustomerDetails = BusinessAccessLayer.LoadCustomerDetails(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            if (dtCustomerDetails != null && dtCustomerDetails.Rows.Count > 0)
            {
                lblApplcationNoValue.Text = dtCustomerDetails.Rows[0]["ApplicationNo"].ToString();
                lblCustomerNameValue.Text = dtCustomerDetails.Rows[0]["EmployeeName"].ToString();
                lblCustomerDOBValue.Text = dtCustomerDetails.Rows[0]["DOB"].ToString();
                lblAppointmentDateTimeValue.Text = dtCustomerDetails.Rows[0]["AppointmentDateTime"].ToString();
                lblMERTypeValue.Text = dtCustomerDetails.Rows[0]["ConsultationType"].ToString();
                lblNomineeDOBValue.Text = dtCustomerDetails.Rows[0]["NomineeDOB"].ToString();
                lblNomineeNameValue.Text = dtCustomerDetails.Rows[0]["NomineeName"].ToString();
                lblCaseCodeValue.Text = dtCustomerDetails.Rows[0]["CaseId"].ToString();
                Session["FileName"] = dtCustomerDetails.Rows[0]["CaseId"].ToString();
                lblCaseStatusValue.Text = dtCustomerDetails.Rows[0]["CaseStatusName"].ToString();

                if (lblMERTypeValue.Text.Trim().Equals("Tele"))
                {
                    divUploadTeleFiles.Visible = true;
                    divUploadVideoFiles.Visible = false;
                }
                else
                {
                    divUploadTeleFiles.Visible = false;
                    divUploadVideoFiles.Visible = true;
                }
            }
        }
        public void LoadPDFDocument()
        {
            //string ReportName = "RequirementDocument.pdf";
            //string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            //string filepath = directory + "App_Data" + "\\" + ReportName;

            string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string filepath = directory + "TeleMERQCDocuments";

            string FilePath = filepath + @"\" + Session["FileName"].ToString() + ".pdf";

            this.rpdfVReport.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes(FilePath));
        }

        public void LoadQCCaseSummaryDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = BusinessAccessLayer.LoadQCCaseSummaryDetails(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            if (dtConsultationCasDetails != null && dtConsultationCasDetails.Rows.Count > 0)
            {
                Session["QCSummaryDetailsdId"] = dtConsultationCasDetails.Rows[0]["QCSummaryDetailsdId"];
                txtComments.Text = dtConsultationCasDetails.Rows[0]["Comments"].ToString();
                IsDataExists = 1;
            }
            else
            {
                LoadCaseDetailsByIdForReport();
            }
        }

        public void LoadCaseDetailsByIdForReport()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            if (dtConsultationCasDetails != null && dtConsultationCasDetails.Rows.Count > 0)
            {
                Session["ConsultationCaseDetailsId"] = dtConsultationCasDetails.Rows[0]["ConsultationCaseDetailsId"].ToString();
                Session["ConsultationCaseAppointmentDetailsId"] = dtConsultationCasDetails.Rows[0]["ConsultationCaseAppointmentDetailsId"].ToString();
                lblCustomerNameValue.Text = dtConsultationCasDetails.Rows[0]["EmployeeName"].ToString();
                lblCustomerDOBValue.Text = dtConsultationCasDetails.Rows[0]["DOB"].ToString();
                lblCaseCodeValue.Text = dtConsultationCasDetails.Rows[0]["CaseId"].ToString();
                Session["FileName"] = dtConsultationCasDetails.Rows[0]["CaseId"].ToString();
                lblCaseStatusValue.Text = dtConsultationCasDetails.Rows[0]["CaseStatusName"].ToString();
                lblAppointmentDateTimeValue.Text = dtConsultationCasDetails.Rows[0]["AppointmentDateTime"].ToString();
                lblMERTypeValue.Text = dtConsultationCasDetails.Rows[0]["ConsultationType"].ToString();

                //LoadQCQuestionAnswerDetails();
                rgvQCQuestions.DataSource = new object[] { };
                rgvQCQuestions.DataBind();

            }

        }

        public void LoadQCQuestionAnswerDetails(DataTable dtQCQuestionAnswerDetails)
        {


            rgvQCQuestions.DataSource = dtQCQuestionAnswerDetails;
            rgvQCQuestions.DataBind();
        }

        public void LoadQCQuestion()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtQCQuestion = new DataTable();
            dtQCQuestion = BusinessAccessLayer.LoadTeleVideoQCQuestions();

            if (dtQCQuestion != null && dtQCQuestion.Rows.Count > 0)
            {
                rgvQCQuestions.DataSource = dtQCQuestion;
                rgvQCQuestions.DataBind();
            }
            else
            {
                rgvQCQuestions.DataSource = new object[] { };
                rgvQCQuestions.DataBind();
            }

        }

        //public void LoadStatusDropDown()
        //{
        //    Bal BusinessAccessLayer = new Bal();

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id");
        //    dt.Columns.Add("Status");

        //    //DataRow dtr = new DataRow();
        //    dt.Rows.Add("1", "Yes");

        //    foreach (GridDataItem item in rgvQCQuestions.MasterTableView.Items)
        //    {
        //        RadComboBox ddlStatus = (item.FindControl("ddlStatus") as RadComboBox);

        //        ddlStatus.DataSource = dt;
        //        ddlStatus.DataValueField = "Id";
        //        ddlStatus.DataTextField = "Status";
        //        ddlStatus.DataBind();
        //    }
        //}

        protected void imgbthViewQCPoints_Click(object sender, ImageClickEventArgs e)
        {
            if (QCPoints.Visible.Equals(false))
            {
                //imgbthViewQCPoints.ImageUrl = "~/images/red_minus_icon.png";
                QCPoints.Visible = true;
            }
            else
            {
                //imgbthViewQCPoints.ImageUrl = "~/images/add_icon.png";
                QCPoints.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveReport_Click(object sender, EventArgs e)
        {

        }

        protected void btnQCSubmit_Click(object sender, EventArgs e)
        {
            string QuestionId = "";
            string SelectedValue = "";
            string Reason = "";

            DataTable dtQCQuestionAnswer = new DataTable();

            dtQCQuestionAnswer.Columns.Add("QuestionId");
            dtQCQuestionAnswer.Columns.Add("Answer");
            dtQCQuestionAnswer.Columns.Add("Reason");

            foreach (GridDataItem item in rgvQCQuestions.MasterTableView.Items)
            {
                QuestionId = (item.FindControl("lblQusetionId") as Label).Text;
                SelectedValue = (item.FindControl("ddlStatus") as RadComboBox).SelectedValue;
                Reason = (item.FindControl("txtReason") as TextBox).Text;

                dtQCQuestionAnswer.Rows.Add(QuestionId, SelectedValue, Reason);
            }




            Bal BusinessAccessLayer = new Bal();
            int i = 0;
            Int32 QCSummaryDetailsId = 0;
            try
            {
                if (Session["QCSummaryDetailsdId"] != null)
                {
                    QCSummaryDetailsId = Convert.ToInt32(Session["QCSummaryDetailsdId"].ToString());
                }


                DataTable dtTeleMERFiles = new DataTable();

                dtTeleMERFiles.Columns.Add("FileName", typeof(string));
                dtTeleMERFiles.Columns.Add("FileData", typeof(Byte[]));

                for (int j = 0; j < rauTeleMERFiles.UploadedFiles.Count; j++)
                {
                    Stream fs = rauTeleMERFiles.UploadedFiles[j].InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] byteDocumentData = new Byte[5242880];
                    byteDocumentData = br.ReadBytes((Int32)fs.Length);
                    string DocumentName = rauTeleMERFiles.UploadedFiles[i].FileName;
                    //String targetFolder = Server.MapPath("~/AppointmentReports/");

                    dtTeleMERFiles.Rows.Add(DocumentName, byteDocumentData);
                }

                DataTable dtVideoFiles = new DataTable();

                dtVideoFiles.Columns.Add("PhotoId", typeof(string));
                dtVideoFiles.Columns.Add("PhotoIdData", typeof(Byte[]));
                dtVideoFiles.Columns.Add("LivePhoto", typeof(string));
                dtVideoFiles.Columns.Add("LivePhotoData", typeof(Byte[]));
                dtVideoFiles.Columns.Add("VideoScreenshot", typeof(string));
                dtVideoFiles.Columns.Add("VideoScreenshotData", typeof(Byte[]));

                Byte[] bytePhotoId = new Byte[5242880];
                string PhotoIdName = "";
                if (rauPhotoId.UploadedFiles.Count > 0)
                {
                    Stream PhotoId = rauPhotoId.UploadedFiles[0].InputStream;
                    BinaryReader brPhotoId = new BinaryReader(PhotoId);

                    bytePhotoId = brPhotoId.ReadBytes((Int32)PhotoId.Length);
                    PhotoIdName = rauPhotoId.UploadedFiles[0].FileName;
                }
                Byte[] byteLivePhoto = new Byte[5242880];
                string LivePhotoName = "";
                if (rauLivePhoto.UploadedFiles.Count > 0)
                {
                    Stream LivePhoto = rauLivePhoto.UploadedFiles[0].InputStream;
                    BinaryReader brLivePhoto = new BinaryReader(LivePhoto);

                    byteLivePhoto = brLivePhoto.ReadBytes((Int32)LivePhoto.Length);
                    LivePhotoName = rauLivePhoto.UploadedFiles[0].FileName;
                }
                Byte[] byteVideoScreenshot = new Byte[5242880];
                string VideoScreenshotName = "";
                if (rauVideoScreenshot.UploadedFiles.Count > 0)
                {
                    Stream VideoScreenshot = rauVideoScreenshot.UploadedFiles[0].InputStream;
                    BinaryReader brVideoScreenshot = new BinaryReader(VideoScreenshot);

                    byteVideoScreenshot = brVideoScreenshot.ReadBytes((Int32)VideoScreenshot.Length);
                    VideoScreenshotName = rauVideoScreenshot.UploadedFiles[0].FileName;
                }



                dtVideoFiles.Rows.Add(PhotoIdName, bytePhotoId, LivePhotoName, byteVideoScreenshot, VideoScreenshotName, byteVideoScreenshot);

                //if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[1].Rows.Count > 0)
                //{
                //    RadGridReports.DataSource = dtAppointmentDetails.Tables[1];
                //    RadGridReports.DataBind();

                //    //Session["AdditionalDetails"] = dtCorporateDetails.Tables[3];
                //}
                //else
                //{
                //    RadGridReports.DataSource = new object[] { }; //null;
                //    RadGridReports.DataBind();
                //}



                if (btnQCSubmit.Text.Equals("QC Submit") && IsDataExists != 1)
                {


                    i = BusinessAccessLayer.SaveQCSummaryDetails(0, Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]), txtComments.Text.Trim(), Convert.ToInt32(Session["LoginRefId"]), dtQCQuestionAnswer, dtTeleMERFiles, dtVideoFiles);

                    if (i > 0)
                    {
                        showPopup("Warning", "QC Summary Saved Successfully");
                    }
                }
                else
                {
                    i = BusinessAccessLayer.SaveQCSummaryDetails(QCSummaryDetailsId, Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]), txtComments.Text.Trim(), Convert.ToInt32(Session["LoginRefId"]), dtQCQuestionAnswer, dtTeleMERFiles, dtVideoFiles);

                    if (i > 0)
                    {
                        showPopup("Warning", "QC Summary Updated Successfully");
                    }
                }

                Response.Redirect("~/Appointment/ConsultationCaseClosedAppointmentDetails.aspx");
                ClearFields();
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearFields()
        {
            rgvQCQuestions.DataSource = new object[] { };
            rgvQCQuestions.DataBind();
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        //protected void rcbMerQuestion18_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //}

        //protected void rcbMerQuestion23_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //}

        //protected void rcbMerQuestion27_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //}

        //protected void rcbQuestion2_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //}

        //protected void rcbQuestion6_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //}

        protected void rgvQCQuestions_DataBound(object sender, EventArgs e)
        {





            Bal BusinessAccessLayer = new Bal();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Value");

            //DataRow dtr = new DataRow();
            dt.Rows.Add("0", "Select");
            dt.Rows.Add("1", "Yes");
            dt.Rows.Add("2", "No");




            if (IsDataExists.Equals(1))
            {

                foreach (GridDataItem item in rgvQCQuestions.MasterTableView.Items)
                {
                    int i = item.ItemIndex + 1;
                    RadComboBox ddlStatus = (item.FindControl("ddlStatus") as RadComboBox);
                    string lblQuestionId = (item.FindControl("lblQusetionId") as Label).Text;
                    TextBox txtReason = (item.FindControl("txtReason") as TextBox);
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataValueField = "Id";
                    ddlStatus.DataTextField = "Value";
                    ddlStatus.DataBind();

                    DataTable dtConsultationCasDetails = new DataTable();
                    dtConsultationCasDetails = BusinessAccessLayer.LoadQCQuestionAnswerDetails(Convert.ToInt32(Session["QCSummaryDetailsdId"]));

                    DataView dv = dtConsultationCasDetails.DefaultView;
                    dv.RowFilter = "QuestionId =" + i.ToString();
                    DataTable dtResult = dv.ToTable();
                    ddlStatus.SelectedValue = dtResult.Rows[0]["Answer"].ToString();
                    txtReason.Text = dtResult.Rows[0]["Reason"].ToString();

                    if (txtReason.Text != "")
                    {
                        txtReason.Visible = true;
                    }
                    else
                    {
                        txtReason.Visible = false;
                    }


                    //ddlStatus.SelectedValue = "1";
                }

            }
            else
            {
                foreach (GridDataItem item in rgvQCQuestions.MasterTableView.Items)
                {
                    //int i = item.ItemIndex + 1;
                    RadComboBox ddlStatus = (item.FindControl("ddlStatus") as RadComboBox);
                    //string lblQuestionId = (item.FindControl("lblQusetionId") as Label).Text;
                    //TextBox txtReason = (item.FindControl("txtReason") as TextBox);
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataValueField = "Id";
                    ddlStatus.DataTextField = "Value";
                    ddlStatus.DataBind();
                }
                //Bal BusinessAccessLayer = new Bal();

            }
        }

        protected void rgvQCQuestions_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string text = "";
        }

        protected void rgvQCQuestions_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvQCQuestions_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                //foreach (GridDataItem item in rgCorporateBranchDetails.MasterTableView.Items)
                //{

                RadComboBox cmb = (RadComboBox)sender;
                GridItem item = (GridItem)cmb.NamingContainer;

                Label lblQusetionId = (item.FindControl("lblQusetionId") as Label);
                Label lblReason = (item.FindControl("lblReason") as Label);
                TextBox txtReason = (item.FindControl("txtReason") as TextBox);
                RadComboBox ddlStatus = (item.FindControl("ddlStatus") as RadComboBox);


                if (ddlStatus.SelectedValue.Equals("2") && lblQusetionId.Text.Equals("3"))
                {
                    txtReason.Visible = true;
                    lblReason.Visible = true;
                }
                else
                {
                    txtReason.Visible = false;
                    lblReason.Visible = false;
                }



                //}




            }
            catch (Exception ex)
            {

            }
        }

        protected void rgvQCQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
    }
}