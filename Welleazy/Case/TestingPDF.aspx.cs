//using iTextSharp.text;

//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web;
using System.Web.UI;
using System.IO;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;

namespace Welleazy.Case
{
    public partial class TestingPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestionnaire();
                LoadCaseDetailsByIdForReport();
            }
        }

        public void LoadQCCaseSummaryDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = BusinessAccessLayer.LoadQCCaseSummaryDetails(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

           
            //else
            //{
                LoadCaseDetailsByIdForReport();
           // }
        }

        public void LoadCaseDetailsByIdForReport()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            //dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(5,5);
            if (dtConsultationCasDetails != null && dtConsultationCasDetails.Rows.Count > 0)
            {
                Session["ConsultationCaseDetailsId"] = dtConsultationCasDetails.Rows[0]["ConsultationCaseDetailsId"].ToString();
                Session["ConsultationCaseAppointmentDetailsId"] = dtConsultationCasDetails.Rows[0]["ConsultationCaseAppointmentDetailsId"].ToString();
                lblCustomerNameValue.Text = dtConsultationCasDetails.Rows[0]["EmployeeName"].ToString();
                lblCustomerDOBValue.Text = dtConsultationCasDetails.Rows[0]["DOB"].ToString();
                lblCaseCodeValue.Text = dtConsultationCasDetails.Rows[0]["CaseId"].ToString();
                lblCaseStatusValue.Text = dtConsultationCasDetails.Rows[0]["CaseStatusName"].ToString();
                lblAppointmentDateTimeValue.Text = dtConsultationCasDetails.Rows[0]["AppointmentDateTime"].ToString();
                lblMERTypeValue.Text = dtConsultationCasDetails.Rows[0]["ConsultationType"].ToString();

                //LoadQCQuestionAnswerDetails();

            }

        }



        public void LoadQuestionnaire()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtQuestionnaire = new DataTable();
            dtQuestionnaire = BusinessAccessLayer.LoadQuestionnaire();

            if (dtQuestionnaire != null && dtQuestionnaire.Rows.Count > 0)
            {
                rgvQuestions.DataSource = dtQuestionnaire;
                rgvQuestions.DataBind();
            }
            else
            {
                //gvData.DataSource = new object[] { };
                //gvData.DataBind();
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //// var example_html = @"<p>This is some sample  text<span style="">!!!</span></p>";
                //var example_html = PrintContent.ToString();
                ////StringWriter stringWriter = new StringWriter();
                ////HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                ////PrintContent.RenderControl(htmlTextWriter);
                //StringReader sr = new StringReader(example_html);
                ////StringReader stringReader = new StringReader(stringWriter.ToString());
                //Document pdfDoc = new Document(PageSize.A4);
                //var writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                //pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Employee.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                PrintContent.RenderControl(htmlTextWriter);

                StringReader stringReader = new StringReader(stringWriter.ToString());

                PdfDocument pdf = PdfGenerator.GeneratePdf(htmlTextWriter.InnerWriter.ToString(), PageSize.A4);
                pdf.Save(@"F:\document.pdf");   
                //Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                //Document Doc = new Document(PageSize.A4);
                //HTMLWorker htmlparser = new HTMLWorker(Doc);
                //PdfWriter.GetInstance(Doc, Response.OutputStream);

                //Doc.Open();
                //htmlparser.Parse(stringReader);
                //Doc.Close();
                //Response.Write(Doc);
                //Response.End();

                //Response.Write(pdfDoc);
                //Response.End();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter stringWriter = new StringWriter();
                //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                //PrintContent.RenderControl(htmlTextWriter);
                //StringReader stringReader = new StringReader(stringWriter.ToString());
                //Document Doc = new Document(PageSize.A4, 10, 10, 100, 0);

                //// Document doc = new Document()
                //HTMLWorker htmlparser = new HTMLWorker(Doc);
                //PdfWriter.GetInstance(Doc, Response.OutputStream);
                //Doc.Open();
                //htmlparser.Parse(stringReader);
                //Doc.Close();
                //Response.Write(Doc);
                //Response.End();
            }
            catch (Exception ex)
            {

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void rgvQuestions_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rgvQuestions_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void rgvQuestions_DataBound(object sender, EventArgs e)
        {

        }

        protected void rgvQuestions_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void rgvQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
    }
}