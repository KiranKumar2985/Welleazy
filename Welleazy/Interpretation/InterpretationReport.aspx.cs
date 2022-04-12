using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Interpretation
{
    public partial class InterpretationReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int InterpretationCase= Variables.InterpretationCaseId;
                Variables.InterpretationCaseId = InterpretationCase;
                InterpretationCaseStatusList();

                InterpretationCaseDetailsById();

                if(Variables.InterpretationCaseId != 0)
                {
                    InterpretationReportDetailsById();
                    if(Variables.InterReportUploadId != 0)
                    {
                        btnSubmit.Text = "Update";
                    }
                    else
                    {
                        btnSubmit.Text = "Save";
                    }
                    
                }
                else
                {
                    btnSubmit.Text = "Save";
                }
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

                
            }
            else
            {
                rcbCaseStatus.DataSource = null;
                rcbCaseStatus.DataBind();
            }
        }

        public void LoadDoctorSignature()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtDoctorSignature = new DataTable();
            dtDoctorSignature = BusinessAccessLayer.LoadDoctorSignature(Convert.ToInt32(lblDoctorID.Text));

            string ImagePath = AppDomain.CurrentDomain.BaseDirectory + "DoctorDocument";
            Session["Filepath"] = ImagePath;
            Byte[] byteData = null;
            string FileName = "";
            if (dtDoctorSignature != null && dtDoctorSignature.Rows.Count > 0)
            {
                Session["FileName"] = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                FileName = dtDoctorSignature.Rows[0]["DocumentName"].ToString();
                byteData = (Byte[])dtDoctorSignature.Rows[0]["DocumentContent"];
            }

            System.IO.File.WriteAllBytes(ImagePath + "\\" + FileName, byteData);
            LabelSignature.Text = ImagePath + "\\" + FileName;
            //DoctorSignature.ImageUrl = ImagePath + "\\" + FileName;

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

        public void InterpretationCaseDetailsById()
        {
            DataSet dtInterCaseDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtInterCaseDetails = BusinessAccessLayer.LoadInterpretationCaseDetailsById(Variables.InterpretationCaseId);



            if (dtInterCaseDetails != null && dtInterCaseDetails.Tables[0].Rows.Count > 0)
            {
                //lblCaseId.Text = "WX00005";
                lblCorporateId.Text = dtInterCaseDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                lblCustomerName.Text = dtInterCaseDetails.Tables[0].Rows[0]["CustomerName"].ToString();
                lblApplicationNo.Text = dtInterCaseDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                lblDoctorName.Text = dtInterCaseDetails.Tables[0].Rows[0]["DoctorName"].ToString();
                lblDoctorID.Text = dtInterCaseDetails.Tables[0].Rows[0]["DoctorId"].ToString();
                LoadDoctorSignature();
                lblDoctorRegn.Text = dtInterCaseDetails.Tables[0].Rows[0]["RegistrationNumber"].ToString();
                lblCaseRefId.Text = dtInterCaseDetails.Tables[0].Rows[0]["CaseRefId"].ToString();
                lblCaseId.Text = dtInterCaseDetails.Tables[0].Rows[0]["CaseId"].ToString();
                lblInterpretationType.Text = dtInterCaseDetails.Tables[0].Rows[0]["InterpretationType"].ToString();
                lblInterpretationTypeText.Text = dtInterCaseDetails.Tables[0].Rows[0]["InterpretationTypeText"].ToString();
                rcbCaseStatus.SelectedValue = dtInterCaseDetails.Tables[0].Rows[0]["CaseStatus"].ToString();

                lblReportName.Text = dtInterCaseDetails.Tables[0].Rows[0]["ReportName"].ToString();
                
                //if(lblReportName.Text!="")
                //{
                //    //string filepath = "E:/Welleazy/Welleazy/InterpretationReports/";
                //    //filepath = filepath + lblReportName.Text;
                    
                //    this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes(filepath));
                //    //this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes("E:/Welleazy/Welleazy/App_Data/RequirementDocument.pdf"));
                //}
                //else
                //{
                //    //this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes("E:/Welleazy/Welleazy/App_Data/pagenotfound.pdf"));
                //}

                string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string filepath = directory + "InterpretationReports" + "\\" + lblReportName.Text;
                this.RadPdfViewer1.PdfjsProcessingSettings.FileSettings.Data = Convert.ToBase64String(File.ReadAllBytes(filepath));

                if (lblInterpretationType.Text=="1")
                {
                    lblHeading.Text = "ECG Interpretation";
                    ECGInterpretation.Visible = true;

                }
                else
                {
                    lblHeading.Text = "TMT Interpretation";
                    TMTInterpretation.Visible = true;
                }
            }
        }

        public void InterpretationReportDetailsById()
        {
            DataSet dtInterReportDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtInterReportDetails = BusinessAccessLayer.LoadInterpretationReportDetailsById(Variables.InterpretationCaseId);



            if (dtInterReportDetails != null && dtInterReportDetails.Tables[0].Rows.Count > 0)
            {
                //lblCaseId.Text = "WX00005";
                Variables.InterReportUploadId = Convert.ToInt32(dtInterReportDetails.Tables[0].Rows[0]["InterReportUploadId"].ToString());
                txtRate.Text = dtInterReportDetails.Tables[0].Rows[0]["Rate"].ToString();
                txtRhythm.Text= dtInterReportDetails.Tables[0].Rows[0]["Rhythm"].ToString();
                txtAxis.Text = dtInterReportDetails.Tables[0].Rows[0]["Axis"].ToString();
                txtPWave.Text = dtInterReportDetails.Tables[0].Rows[0]["PWave"].ToString();
                txtPrIntervalPrSegment.Text = dtInterReportDetails.Tables[0].Rows[0]["PrIntervalPrSegment"].ToString();
                txtQWave.Text = dtInterReportDetails.Tables[0].Rows[0]["QWave"].ToString();
                txtRWave.Text = dtInterReportDetails.Tables[0].Rows[0]["RWave"].ToString();
                txtQRSComplex.Text = dtInterReportDetails.Tables[0].Rows[0]["QRSComplex"].ToString();
                txtQTInterval.Text = dtInterReportDetails.Tables[0].Rows[0]["QTInterval"].ToString();
                txtSTSegment.Text = dtInterReportDetails.Tables[0].Rows[0]["STSegment"].ToString();
                txtTWave.Text = dtInterReportDetails.Tables[0].Rows[0]["TWave"].ToString();
                txtAdditionalWaves.Text = dtInterReportDetails.Tables[0].Rows[0]["AdditionalWaves"].ToString();
                txtChamberHypertrophy.Text = dtInterReportDetails.Tables[0].Rows[0]["ChamberHypertrophy"].ToString();
                txtECGOther.Text = dtInterReportDetails.Tables[0].Rows[0]["ECGOther"].ToString();
                rcbEStatus.SelectedValue = dtInterReportDetails.Tables[0].Rows[0]["ECGStatus"].ToString();
                txtECGatRest.Text = dtInterReportDetails.Tables[0].Rows[0]["ECGatRest"].ToString();
                txtTargetHeartRate.Text = dtInterReportDetails.Tables[0].Rows[0]["TargetHeartRate"].ToString();
                txtStTChanges.Text = dtInterReportDetails.Tables[0].Rows[0]["StTChanges"].ToString();
                txtChestPainAngina.Text = dtInterReportDetails.Tables[0].Rows[0]["ChestPainAngina"].ToString();
                txtBPResponse.Text = dtInterReportDetails.Tables[0].Rows[0]["BPResponse"].ToString();
                txtDyspnoeaBreathlessness.Text = dtInterReportDetails.Tables[0].Rows[0]["DyspnoeaBreathlessness"].ToString();
                txtArrhythmia.Text = dtInterReportDetails.Tables[0].Rows[0]["Arrhythmia"].ToString();
                txtExerciseCapacity.Text = dtInterReportDetails.Tables[0].Rows[0]["ExerciseCapacity"].ToString();
                rcbTStatus.SelectedValue = dtInterReportDetails.Tables[0].Rows[0]["TMTStatus"].ToString();

                if (lblInterpretationType.Text == "1")
                {
                    txtESuggestions.Text = dtInterReportDetails.Tables[0].Rows[0]["Suggestions"].ToString();
                }
                else
                {
                    txtTSuggestions.Text = dtInterReportDetails.Tables[0].Rows[0]["Suggestions"].ToString();
                }
                
            }
        }


        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void PDFSave()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.Append("<br><br>");
                    sb.Append("<table runat='server' border='1' style='width: 100 %; margin-top:30px; padding:20px; border: 1px solid #eeeaea;'><tr><td style='text-align:center;'><b>" + lblHeading.Text + "</b></td></tr></table>");
                    sb.Append("<br>");
                    sb.Append("<table runat='server' border='1' style='width: 100 %; border: 1px solid #eeeaea;'>");
                    sb.Append("<tr><td style = 'padding:5px;'> Application No </td><td style = 'padding:5px;'>" + lblApplicationNo.Text + "</td><td style = 'padding:5px;'> Customer Name </td><td style = 'padding:5px;'>" + lblCustomerName.Text + "</td></tr>");
                    sb.Append("<tr><td style = 'padding:5px;'> Doctor Name </td><td style = 'padding:5px;'>" + lblDoctorName.Text + "</td><td style = 'padding:5px;'> Doctor Regn </td><td style = 'padding:5px;'>" + lblDoctorRegn.Text + "</td></tr></table>");
                    sb.Append("<br>");
                    if (lblInterpretationType.Text == "1")
                    {
                        sb.Append("<table runat='server' border='1' style='width: 100 %; margin-top:10px; border: 1px solid #eeeaea;'>");
                        sb.Append("<tr><td style = 'padding:5px;' > IE Code </td><td style = 'padding:5px; text-align:center;'>" + lblCaseId.Text + " </td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Rate </td><td style = 'padding:5px; text-align:center;'>" + txtRate.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Rhythm </td><td style = 'padding:5px; text-align:center;'>" + txtRhythm.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Axis </td><td style = 'padding:5px; text-align:center;'>" + txtAxis.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > P Wave </td><td style = 'padding:5px; text-align:center;'>" + txtPWave.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Pr Interval Pr Segment </td><td style = 'padding:5px; text-align:center;'>" + txtPrIntervalPrSegment.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Q Wave </td><td style = 'padding:5px; text-align:center;'>" + txtQWave.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > R Wave </td><td style = 'padding:5px; text-align:center;'>" + txtRWave.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > QRS Complex </td><td style = 'padding:5px; text-align:center;'>" + txtQRSComplex.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > QT Interval </td><td style = 'padding:5px; text-align:center;'>" + txtQTInterval.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > ST Segment </td><td style = 'padding:5px; text-align:center;'>" + txtSTSegment.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > T Wave </td><td style = 'padding:5px; text-align:center;'>" + txtTWave.Text+ "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Additional Waves </td><td style = 'padding:5px; text-align:center;'>" + txtAdditionalWaves.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Chamber Hypertrophy </td><td style = 'padding:5px; text-align:center;'>" + txtChamberHypertrophy.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Other </td><td style = 'padding:5px; text-align:center;'>" + txtECGOther.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Status (Normal/Abnormal) </td><td style = 'padding:5px; text-align:center;'>" + rcbEStatus.SelectedItem.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Suggestions </td><td style = 'padding:5px; text-align:center;'>" + txtESuggestions.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' ></td><td style = 'padding:5px; text-align:center;'>Dr Signature</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' ></td><td style = 'padding:5px; text-align:center;'><img src='"+ LabelSignature.Text + "' alt='Doctor Signature' /></td></tr>");
                        sb.Append("</table>");
                    }
                    else
                    {
                        sb.Append("<table runat='server' border='1' style='width: 100 %; margin-top:10px; border: 1px solid #eeeaea;'>");
                        sb.Append("<tr><td style = 'padding:5px;' > IE Code </td><td style = 'padding:5px; text-align:center;'>" + lblCaseId.Text + " </td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > ECG at Rest </td><td style = 'padding:5px; text-align:center;'>" + txtECGatRest.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Target Heart Rate </td><td style = 'padding:5px; text-align:center;'>" + txtTargetHeartRate.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > St T Changes </td><td style = 'padding:5px; text-align:center;'>" + txtStTChanges.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Chest Pain Angina </td><td style = 'padding:5px; text-align:center;'>" + txtChestPainAngina.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > BP Response </td><td style = 'padding:5px; text-align:center;'>" + txtBPResponse.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Dyspnoea Breathlessness </td><td style = 'padding:5px; text-align:center;'>" + txtDyspnoeaBreathlessness.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Arrhythmia </td><td style = 'padding:5px; text-align:center;'>" + txtArrhythmia.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Exercise Capacity </td><td style = 'padding:5px; text-align:center;'>" + txtExerciseCapacity.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Status (Positive/Negative) </td><td style = 'padding:5px; text-align:center;'>" + rcbTStatus.SelectedItem.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' > Suggestions </td><td style = 'padding:5px; text-align:center;'>" + txtTSuggestions.Text + "</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' ></td><td style = 'padding:5px; text-align:center;'>Dr Signature</td></tr>");
                        sb.Append("<tr><td style = 'padding:5px;' ></td><td style = 'padding:5px; text-align:center;'><img src='" + LabelSignature.Text + "' alt='Doctor Signature' /></td></tr>");
                        sb.Append("</table>");
                    }

                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                    PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~/InterpretationReports/Interpretation_" + lblInterpretationTypeText.Text + "_ReportOf_" + lblApplicationNo.Text + ".pdf"), FileMode.Create));
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                }
            }
        }

        public void UpdateInterpretationCaseDetailsByDoctor()
        {
            Bal BusinessAccessLayer = new Bal();
            //string IsDataExists = "0";
            rcbCaseStatus.SelectedValue = "40";
            string ReportName = "Interpretation_" + lblInterpretationTypeText.Text + "_ReportOf_" + lblApplicationNo.Text + ".pdf";

            BusinessAccessLayer.UpdateInterpretationCaseDetailsByDoctor(Variables.InterpretationCaseId, Convert.ToInt32(rcbCaseStatus.SelectedValue), 
                ReportName, Convert.ToInt32(Session["LoginRefId"].ToString()));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Suggestions = "";
                if(lblInterpretationTypeText.Text=="ECG")
                {
                    Suggestions = txtESuggestions.Text;
                }
                else
                {
                    Suggestions = txtTSuggestions.Text;
                }

                Bal BusinessAccessLayer = new Bal();
                string IsDataExists = "0";
                if (btnSubmit.Text.Equals("Save"))
                {
                    BusinessAccessLayer.InsertUpdateInterpretationReportDetails(0, Variables.InterpretationCaseId, Convert.ToInt32(lblCaseRefId.Text.Trim()), lblCaseId.Text.Trim(),
                        txtRate.Text.Trim(), txtRhythm.Text.Trim(), txtAxis.Text.Trim(), txtPWave.Text.Trim(), txtPrIntervalPrSegment.Text.Trim(), txtQWave.Text.Trim(),
                        txtRWave.Text.Trim(), txtQRSComplex.Text.Trim(), txtQTInterval.Text.Trim(), txtSTSegment.Text.Trim(), txtTWave.Text.Trim(), txtAdditionalWaves.Text.Trim(),
                        txtChamberHypertrophy.Text.Trim(), txtECGOther.Text.Trim(), rcbEStatus.SelectedValue, txtECGatRest.Text.Trim(), txtTargetHeartRate.Text.Trim(), 
                        txtStTChanges.Text.Trim(), txtChestPainAngina.Text.Trim(), txtBPResponse.Text.Trim(), txtDyspnoeaBreathlessness.Text.Trim(), txtArrhythmia.Text.Trim(),
                        txtExerciseCapacity.Text.Trim(), rcbTStatus.SelectedValue, Suggestions, Convert.ToInt32(Session["LoginRefId"].ToString()),
                        out IsDataExists);

                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Interpretation Report Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Interpretation Report Saved Successfully");
                        PDFSave();
                        DeleteFile();
                        UpdateInterpretationCaseDetailsByDoctor();
                        ClearFields();
                        Variables.InterReportUploadId = 0;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('InterpretationCaseList.aspx');</script>");
                    }
                }
                else
                {
                    BusinessAccessLayer.InsertUpdateInterpretationReportDetails(Variables.InterReportUploadId, Variables.InterpretationCaseId, Convert.ToInt32(lblCaseRefId.Text.Trim()), lblCaseId.Text.Trim(),
                        txtRate.Text.Trim(), txtRhythm.Text.Trim(), txtAxis.Text.Trim(), txtPWave.Text.Trim(), txtPrIntervalPrSegment.Text.Trim(), txtQWave.Text.Trim(),
                        txtRWave.Text.Trim(), txtQRSComplex.Text.Trim(), txtQTInterval.Text.Trim(), txtSTSegment.Text.Trim(), txtTWave.Text.Trim(), txtAdditionalWaves.Text.Trim(),
                        txtChamberHypertrophy.Text.Trim(), txtECGOther.Text.Trim(), rcbEStatus.SelectedValue, txtECGatRest.Text.Trim(), txtTargetHeartRate.Text.Trim(),
                        txtStTChanges.Text.Trim(), txtChestPainAngina.Text.Trim(), txtBPResponse.Text.Trim(), txtDyspnoeaBreathlessness.Text.Trim(), txtArrhythmia.Text.Trim(),
                        txtExerciseCapacity.Text.Trim(), rcbTStatus.SelectedValue, Suggestions, Convert.ToInt32(Session["LoginRefId"].ToString()),
                        out IsDataExists);
                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "Interpretation Report Already Exists");
                    }
                    else
                    {
                        showPopup("Warning", "Interpretation Report Updated Successfully");
                        PDFSave();
                        DeleteFile();
                        UpdateInterpretationCaseDetailsByDoctor();
                        ClearFields();
                        Variables.InterReportUploadId = 0;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('InterpretationCaseList.aspx');</script>");
                    }
                }
                //Variables.InterReportUploadId = 0;
                
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            //DataTable dt = new DataTable();
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Visible = false;
            ImageButton2.Visible = true;
            QCPoints.Visible = true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Visible = true;
            ImageButton2.Visible = false;
            QCPoints.Visible = false;
        }

        public void ClearFields()
        {
            txtRate.Text = "";
            txtRhythm.Text = "";
            txtAxis.Text = "";
            txtPWave.Text = "";
            txtPrIntervalPrSegment.Text = "";
            txtQWave.Text = "";
            txtRWave.Text = "";
            txtQRSComplex.Text = "";
            txtQTInterval.Text = "";
            txtSTSegment.Text = "";
            txtTWave.Text = "";
            txtAdditionalWaves.Text = "";
            txtChamberHypertrophy.Text = "";
            txtECGOther.Text = "";
            rcbEStatus.SelectedValue = "0";
            txtESuggestions.Text = "";
            txtECGatRest.Text = "";
            txtTargetHeartRate.Text = "";
            txtStTChanges.Text = "";
            txtChestPainAngina.Text = "";
            txtBPResponse.Text = "";
            txtDyspnoeaBreathlessness.Text = "";
            txtArrhythmia.Text = "";
            txtExerciseCapacity.Text = "";
            rcbTStatus.SelectedValue = "0";
            txtTSuggestions.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Response.Redirect("~/Interpretation/InterpretationCaseList.aspx");
        }
    }
}