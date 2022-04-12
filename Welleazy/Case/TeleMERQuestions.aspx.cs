using iTextSharp.text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;

namespace Welleazy.Case
{
    public partial class TeleMERQuestions : System.Web.UI.Page
    {
        static StringBuilder html = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadDoctorSignature();
                //LoadQuestionnaire();

                LoadCaseDetailsByIdForReport();
                LoadCustomerDetails();


                lblDoctorName.Text = "Dr.Roy";
                lblDoctorQualification.Text = "MBBS";
                lblDoctorRegistrationNumber.Text = "123456";
                lblMedicalVerificationDateTime.Text = "14-03-2022 05:10 PM";

            }
        }

        public void LoadCustomerDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCustomerDetails = new DataTable();
            dtCustomerDetails = BusinessAccessLayer.LoadCustomerDetails(Convert.ToInt32(Session["ConsultationCaseDetailsId"]), Convert.ToInt32(Session["ConsultationCaseAppointmentDetailsId"]));

            if (dtCustomerDetails != null && dtCustomerDetails.Rows.Count > 0)
            {
                lbl_AppointmentDateTime_Value.Text = dtCustomerDetails.Rows[0]["AppointmentDateTime"].ToString();
                lbl_CustomerName_Value.Text = dtCustomerDetails.Rows[0]["EmployeeName"].ToString();
                lbl_CustomerDOB_Value.Text = dtCustomerDetails.Rows[0]["DOB"].ToString();
                lblAppointmentDateTimeValue.Text = dtCustomerDetails.Rows[0]["AppointmentDateTime"].ToString();
                lbl_MERType_Value.Text = dtCustomerDetails.Rows[0]["ConsultationType"].ToString();
                lblNominee_DOB_Value.Text = dtCustomerDetails.Rows[0]["NomineeDOB"].ToString();
                lbl_NomineeName_Value.Text = dtCustomerDetails.Rows[0]["NomineeName"].ToString();
                lbl_CaseTACode_Value.Text = dtCustomerDetails.Rows[0]["CaseId"].ToString();
                Session["FileName"] = dtCustomerDetails.Rows[0]["CaseId"].ToString();
                lbl_CaseStatus_Value.Text = dtCustomerDetails.Rows[0]["CaseStatusName"].ToString();
                lblCustomerNameForDeclaration.Text = dtCustomerDetails.Rows[0]["EmployeeName"].ToString();
                lblApplcationNoValue.Text = dtCustomerDetails.Rows[0]["ApplicationNo"].ToString();
                lbl_ApplicationNo_Value.Text = dtCustomerDetails.Rows[0]["ApplicationNo"].ToString();
                lblMERTypeValue.Text = dtCustomerDetails.Rows[0]["ConsultationType"].ToString();

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
            dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(Convert.ToInt32(Session["MERFile_ConsultationCaseDetailsId"]), Convert.ToInt32(Session["MERFile_ConsultationCaseAppointmentDetailsId"]));

            //dtConsultationCasDetails = BusinessAccessLayer.LoadCaseDetailsByIdForReport(5, 5);
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

                LoadTeleMERQuestionAnswerDetails();

            }

        }

        public void LoadTeleMERQuestionAnswerDetails()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = BusinessAccessLayer.LoadTeleMERQuestionAnswerDetails(Convert.ToInt32(Session["MERFile_ConsultationCaseDetailsId"]), Convert.ToInt32(Session["MERFile_ConsultationCaseAppointmentDetailsId"]));

            if (dtConsultationCasDetails != null && dtConsultationCasDetails.Rows.Count > 0)
            {
                rgvQuestions.DataSource = dtConsultationCasDetails;
                rgvQuestions.DataBind();
            }
            else
            {
                LoadQuestionnaire();
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                SelectedValue = (item.FindControl("rbYesNo") as RadioButtonList).SelectedValue;
                Reason = (item.FindControl("txtRemarks") as TextBox).Text;

                dtQuestionnaireAnswer.Rows.Add(QuestionId, SelectedValue, Reason);
            }

            Int32 QuestionnaireAnswerDetailsId = 0;
            QuestionnaireAnswerDetailsId = BusinessAccessLayer.SaveTelerMERQuestionAnswer(Convert.ToInt32(Session["MERFile_ConsultationCaseDetailsId"]), Convert.ToInt32(Session["MERFile_ConsultationCaseAppointmentDetailsId"]), dtQuestionnaireAnswer);

            LoadTeleMERResults(QuestionnaireAnswerDetailsId);

            SaveQuestionnaireAnswerDocument(QuestionnaireAnswerDetailsId);

            Response.Redirect("~/Appointment/ConsultationCaseAppointmentDetails.aspx");


        }

        public void SaveQuestionnaireAnswerDocument(Int32 QuestionnaireAnswerDetailsId)
        {
            try
            {



                string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string filepath = directory + "TeleMERQCDocuments";

                string FilePath = filepath + @"\" + Session["FileName"] + ".pdf";

                string filename = Path.GetFileName(FilePath);

                FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);

                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                br.Close();

                fs.Close();

                DataTable dtTeleMERFiles = new DataTable();

                dtTeleMERFiles.Columns.Add("FileName", typeof(string));
                dtTeleMERFiles.Columns.Add("FileData", typeof(Byte[]));

                dtTeleMERFiles.Rows.Add(filename, bytes);
                Bal BusinessAccessLayer = new Bal();

                BusinessAccessLayer.SaveQuestionnaireAnswerDocument(QuestionnaireAnswerDetailsId, dtTeleMERFiles);
            }
            catch (Exception ex)
            {

            }

        }

        public void LoadDoctorSignature()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorSignature = new DataTable();
            dtDoctorSignature = BusinessAccessLayer.LoadDoctorSignature(1);

            string ImagePath = AppDomain.CurrentDomain.BaseDirectory + "DoctorDocument";
            Session["Filepath"] = ImagePath;
            Byte[] byteData = null;
            string FileName = "";
            if (dtDoctorSignature != null && dtDoctorSignature.Rows.Count > 0)
            {
                Session["DoctorFileName"] = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                FileName = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                byteData = (Byte[])dtDoctorSignature.Rows[0]["DocumentContent"];
            }

            System.IO.File.WriteAllBytes(ImagePath + "\\" + FileName, byteData);
            DoctorSignature.ImageUrl = ImagePath + "\\" + FileName;

        }

        public void LoadTeleMERResults(Int32 QuestionnaireAnswerDetailsId)
        {
            Bal BusinessAccessLayer = new Bal();

            LoadDoctorSignature();
            DataTable dt = BusinessAccessLayer.LoadTeleMERResults(QuestionnaireAnswerDetailsId);

            //Building an HTML string.
            html = new StringBuilder();
            //string path = @"F:\Welleazy7_2_2022\Welleazy\Welleazy\images\welleazy-logo.png";
            //string ImagePath = AppDomain.CurrentDomain.BaseDirectory + "images\\welleazy-logo.png";

            //DoctorSignature.ImageUrl = "F:\\Welleazy7_2_2022\\Welleazy\\Welleazy\\images\\welleazy-logo.png";

            //Table start.
            html.Append("<table border = '1' style='font-size:small;'>");

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
            divImg.Visible = true;
            divDeclaration.Visible = true;


            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);



            //content.RenderControl(htmlTextWriter);

            StringWriter stringWriter1 = new StringWriter();
            HtmlTextWriter htmlTextWriter1 = new HtmlTextWriter(stringWriter1);

            StringWriter stringWriter2 = new StringWriter();
            HtmlTextWriter htmlTextWriter2 = new HtmlTextWriter(stringWriter2);



            content.RenderControl(htmlTextWriter);
            divDeclaration.RenderControl(htmlTextWriter2);
            divImg.RenderControl(htmlTextWriter1);

            //string html = File.ReadAllText("input.htm");
            //PdfDocument pdf = PdfGenerator.GeneratePdf(stringWriter.ToString() + html.ToString(), PageSize.A4);
            //pdf.Save(@"F:\testing.pdf");

            string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string filepath = directory + "\\TeleMERQCDocuments";

            StringReader stringReader = new StringReader(stringWriter.ToString() + html.ToString() + stringWriter2.ToString() + stringWriter1.ToString());
            Document Doc = new Document(PageSize.A4, 20f, 20f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);
            //PdfWriter.GetInstance(Doc, new FileStream(@"F:\Testing.pdf", FileMode.Create));

            string FilePath = filepath + @"\" + Session["FileName"].ToString() + ".pdf";

            PdfWriter.GetInstance(Doc, new FileStream(filepath + @"\" + Session["FileName"].ToString() + ".pdf", FileMode.Create));
            //PdfWriter.GetInstance(Doc, Response.OutputStream);



            Doc.Open();
            htmlparser.Parse(stringReader);

            Doc.Close();
            content.Visible = false;

            divImg.Visible = false;
            divDeclaration.Visible = false;
            DeleteFile();




        }

        public void DeleteFile()
        {
            try
            {

                string FilePath = Session["FilePath"].ToString();
                string FileName = Session["FileName"].ToString();
                if (File.Exists(FilePath + "\\" + FileName))
                {
                    File.Delete(FilePath + "\\" + FileName);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rgvQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                RadioButtonList rblAnswer = item.FindControl("rbYesNo") as RadioButtonList;
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Yes");
                //dt.Columns.Add("No");

                //dt.Rows.Add(1,2);
                //dt.AcceptChanges();

                //rblAnswer.DataSource = dt;
                //rblAnswer.DataBind();
                Label lblAnswer = item.FindControl("lblAnswerId") as Label;
                rblAnswer.SelectedValue = lblAnswer.Text;

                //rblAnswer.SelectedValue = lblAnswer.Text;




            }
        }
    }
}