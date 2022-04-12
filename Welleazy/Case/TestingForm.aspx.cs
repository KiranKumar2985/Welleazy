using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
//using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
//using iTextSharp.text;

//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Welleazy.Case
{
    public partial class TestingForm : System.Web.UI.Page
    {
        static StringBuilder html = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadQuestionnaire();
                LoadCaseDetailsByIdForReport();
                
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
                rgvQuestions.DataSource = new object[] { };
                rgvQuestions.DataBind();
            }


        }

        public void LoadCaseDetailsByIdForReport()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            //dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(5, 5);
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            Bal BusinessAccessLayer = new Bal();

            string QuestionId = "";
            string SelectedValue = "";
            string Reason = "";

            DataTable dtQuestionnaireAnswer = new DataTable();
            dtQuestionnaireAnswer.Columns.Add("QuestionnaireId");
            dtQuestionnaireAnswer.Columns.Add("Answer");
            dtQuestionnaireAnswer.Columns.Add("Reason");

            foreach (GridDataItem item in rgvQuestions.MasterTableView.Items)
            {
                QuestionId = (item.FindControl("lblQuestionNo") as Label).Text;
                SelectedValue = (item.FindControl("rbYesNo") as RadRadioButtonList).SelectedValue;
                Reason = (item.FindControl("txtRemarks") as TextBox).Text;

                dtQuestionnaireAnswer.Rows.Add(QuestionId, SelectedValue,Reason);
            }

            Int32 QuestionnaireAnswerDetailsId = 0;
            QuestionnaireAnswerDetailsId = BusinessAccessLayer.SaveTelerMERQuestionAnswer(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]),dtQuestionnaireAnswer);

            LoadTeleMERResults(QuestionnaireAnswerDetailsId);




        }

        public void LoadTeleMERResults(Int32 QuestionnaireAnswerDetailsId)
        {
            Bal BusinessAccessLayer = new Bal();


            DataTable dt = BusinessAccessLayer.LoadTeleMERResults(QuestionnaireAnswerDetailsId);

            //Building an HTML string.
            html = new StringBuilder();
            string path = @"F:\Welleazy7_2_2022\Welleazy\Welleazy\images\welleazy-logo.png";
            string ImagePath = AppDomain.CurrentDomain.BaseDirectory + "images\\welleazy-logo.png";

            DoctorSignature.ImageUrl = "F:\\Welleazy7_2_2022\\Welleazy\\Welleazy\\images\\welleazy-logo.png";

            //Table start.
            html.Append("<table border = '1'>");

            //Building the Header row.
            html.Append("<tr style=align-content:center;>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");


            }

//            html.Append(

//"   <tr>" +
//"       <td>Image: </td>" +
//"       <td><img src=" + path + " > </ td > " +
//"   </tr>");

            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            PrintData.Controls.Add(new Literal { Text = html.ToString() });

            content.Visible = true;


            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);



            //content.RenderControl(htmlTextWriter);

            StringWriter stringWriter1 = new StringWriter();
            HtmlTextWriter htmlTextWriter1 = new HtmlTextWriter(stringWriter1);



            content.RenderControl(htmlTextWriter);
            divImg.RenderControl(htmlTextWriter1);

            //string html = File.ReadAllText("input.htm");
            //PdfDocument pdf = PdfGenerator.GeneratePdf(stringWriter.ToString() + html.ToString(), PageSize.A4);
            //pdf.Save(@"F:\testing.pdf");

            StringReader stringReader = new StringReader(stringWriter.ToString() + html.ToString() + stringWriter1.ToString());
            Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);
            PdfWriter.GetInstance(Doc, new FileStream(@"F:\Testing.pdf", FileMode.Create));
            //PdfWriter.GetInstance(Doc, Response.OutputStream);

            Doc.Open();
            htmlparser.Parse(stringReader);

            Doc.Close();
            content.Visible = false;


        }

        public void LoadTeleMERQuestionDetails()
        {
            
        }
    }
    }
