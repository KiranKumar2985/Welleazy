using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net;

namespace Welleazy.Case
{
    public partial class AddReport : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        static string test = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //test = "TRUE";
            //AddControl();
            string error;
            if (!IsPostBack)
            {
                int Appointmentid = Variables.AppointmentId;
                //this.pnlTemp.Controls.Clear();
                error = "";

                if (Variables.AppointmentId != 0)
                {
                    LoadAppointmentDetailById();
                    CaseStatusList();
                    ReportStatusList();
                    AppointmentView.ActiveViewIndex = 0;
                }
                else
                {
                        
                }

            }
        }

        public void CaseStatusList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtCaseStatus = new DataTable();
            dtCaseStatus = BusinessAccessLayer.LoadCaseStatusList(1);

            if (dtCaseStatus != null && dtCaseStatus.Rows.Count > 0)
            {
                rcbCaseStatus.DataSource = dtCaseStatus;
                rcbCaseStatus.DataTextField = "CaseStatusName";
                rcbCaseStatus.DataValueField = "StatusId";
                rcbCaseStatus.DataBind();
            }


        }

        public void ReportStatusList()
        {
            DataTable dtReportStatusList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtReportStatusList = BusinessAccessLayer.LoadReportStatusList();

            if (dtReportStatusList != null && dtReportStatusList.Rows.Count > 0)
            {
                rcbReportStatus.DataSource = dtReportStatusList;
                rcbReportStatus.DataTextField = "ReportStatusName";
                rcbReportStatus.DataValueField = "StatusId";
                rcbReportStatus.DataBind();

            }
            else
            {
                rcbReportStatus.DataSource = null;
                rcbReportStatus.DataBind();
            }
        }

        public void TestList()
        {
            rcbMedicalTest.Items.Clear();
            rcbMedicalTest.AppendDataBoundItems = true;


            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadTestListForCorporate", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "TestList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", Convert.ToInt32(lblCorporateId.Text));

            cmdFetchServiceProviderList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                rcbMedicalTest.DataSource = dtFetchServiveProviderDetails;
                rcbMedicalTest.DataTextField = "TestCode";
                rcbMedicalTest.DataValueField = "TestId";
                rcbMedicalTest.DataBind();
            }
            else
            {
                rcbMedicalTest.DataSource = null;
                rcbMedicalTest.DataBind();
            }
        }

        public void LoadMasterGeoTagging()
        {
            rcbGeoTagging.Items.Clear();
            rcbGeoTagging.Items.Insert(0,"Select");
            DataTable dtGeoTaggingDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtGeoTaggingDetails = BusinessAccessLayer.LoadMasterGeoTaggingDropDown();

            if (dtGeoTaggingDetails != null && dtGeoTaggingDetails.Rows.Count > 0)

            {
                rcbGeoTagging.DataSource = dtGeoTaggingDetails;
                rcbGeoTagging.DataTextField = "GeoTaggingDescription";
                rcbGeoTagging.DataValueField = "GeoTaggingId";
                rcbGeoTagging.DataBind();

                if (rblPhoto.SelectedValue=="Yes")
                {
                    List<string> list = new List<string>() { "1" };
                    foreach (var item in list)
                    {
                        RadComboBoxItem items = rcbGeoTagging.Items.FindItemByValue(item);
                        if (item != null)
                        {
                            items.Remove();
                        }
                    }
                }

                else
                {
                    List<string> list = new List<string>() { "2", "3" };
                    foreach (var item in list)
                    {
                        RadComboBoxItem items = rcbGeoTagging.Items.FindItemByValue(item);
                        if (item != null)
                        {                            
                            items.Remove();
                        }
                       
                    }
                }

            }
        }

        public void LoadTestNPackageList()
        {
            CBL_OutSourcedTestList.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtReconized = new DataTable();

            dtReconized = BusinessAccessLayer.LoadTestNPackageListA(Convert.ToInt32(lblCorporateId.Text), Convert.ToInt32(lblCaseRefId.Text), Convert.ToInt32(Variables.AppointmentId));

            if (dtReconized != null && dtReconized.Rows.Count > 0)
            {
                CBL_OutSourcedTestList.DataSource = dtReconized;
                CBL_OutSourcedTestList.DataTextField = "TestCode";
                CBL_OutSourcedTestList.DataValueField = "TestId";
                CBL_OutSourcedTestList.DataBind();
            }
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtAppointmentReport = new DataTable();

            dtAppointmentReport.Columns.Add("ReportName", typeof(string));
            dtAppointmentReport.Columns.Add("ReportData", typeof(Byte[]));

            string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string filepath = directory + "AppointmentReports";

            for (int i = 0; i < RadAsyncUpload1.UploadedFiles.Count; i++)
            {
                Stream fs = RadAsyncUpload1.UploadedFiles[i].InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] byteDocumentData = new Byte[5242880];
                byteDocumentData = br.ReadBytes((Int32)fs.Length);
                string DocumentName = RadAsyncUpload1.UploadedFiles[i].FileName;

               // string FilePath = filepath + "\\"+DocumentName;

               // string filename = Path.GetFileName(FilePath);

               // //FileStream filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);

               // //BinaryReader binaryreader = new BinaryReader(filestream);

               // //Byte[] bytes = binaryreader.ReadBytes((Int32)filestream.Length);

               // //binaryreader.Close();

               // //filestream.Close();
               // //String targetFolder = Server.MapPath("~/AppointmentReports/");

               // string folderName = @"c:\Top-Level Folder";

               // // To create a string that specifies the path to a subfolder under your
               // // top-level folder, add a name for the subfolder to folderName.
               // string pathString = System.IO.Path.Combine(folderName, "SubFolder");

                
               // // You can extend the depth of your path if you want to.
               // //pathString = System.IO.Path.Combine(pathString, "SubSubFolder");

               // // Create the subfolder. You can verify in File Explorer that you have this
               // // structure in the C: drive.
               // //    Local Disk (C:)
               // //        Top-Level Folder
               // ////            SubFolder
               // //System.IO.Directory.CreateDirectory(pathString);

               // // Create a file name for the file you want to create.
               //// string fileName = System.IO.Path.GetRandomFileName();

               // // This example uses a random string for the name, but you also can specify
               // // a particular name.
               // //string fileName = "MyNewFile.txt";

               // // Use Combine again to add the file name to the path.
               // pathString = System.IO.Path.Combine(pathString, filename);

               // // Verify the path that you have constructed.
               // Console.WriteLine("Path to my file: {0}\n", pathString);

               // // Check that the file doesn't already exist. If it doesn't exist, create
               // // the file and write integers 0 - 99 to it.
               // // DANGER: System.IO.File.Create will overwrite the file if it already exists.
               // // This could happen even with random file names, although it is unlikely.
               // if (!System.IO.File.Exists(pathString))
               // {
                    
               //             fs.Write(byteDocumentData,0, (Int32)fs.Length);
                        
                    
               // }


                dtAppointmentReport.Rows.Add(DocumentName, byteDocumentData);
            }

            //for (int i = 0; i < FileUpload1.PostedFiles.Count; i++)
            //{
            //    if (FileUpload1.PostedFiles[i] != null)
            //    {
            //        if (FileUpload1.HasFile == false)
            //        {
            //            lblUpload1.Text = lblUpload1.Text;
            //        }
            //        else
            //        {
            //            string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //            Int32 fileSize = FileUpload1.PostedFile.ContentLength;
            //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 7340032)
            //            {
            //                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //                FileUpload1.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //                lblUpload1.Text = filepath.ToString();
            //            }
            //            else
            //            {
            //                lblUpload1.ForeColor = System.Drawing.Color.Red;
            //                lblUpload1.Text = "Only .pdf files allowed with size below 7 MB";
            //                return;
            //            }
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@cancelled_cheque", lblUpload19.Text);

            String StrOutSourcedTest = "";
            for (int i = 0; i <= CBL_OutSourcedTestList.Items.Count - 1; i++)
            {
                if (CBL_OutSourcedTestList.Items[i].Selected)
                {
                    if (StrOutSourcedTest == "")
                    {
                        StrOutSourcedTest = CBL_OutSourcedTestList.Items[i].Value;
                    }
                    else
                    {
                        StrOutSourcedTest += "," + CBL_OutSourcedTestList.Items[i].Value;
                    }
                }
            }


            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if (btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateReportDetails(0, Convert.ToInt32(lblCaseRefId.Text.Trim()), Variables.AppointmentId,
                    dtAppointmentReport, "0", Convert.ToInt32(rcbReportStatus.SelectedValue),
                    dtpClosureApproval.DateInput.SelectedDate.Equals(null) ? nul : dtpClosureApproval.DateInput.SelectedDate.Value,
                    rblPhotoId.SelectedValue.Trim(), rblPhoto.SelectedValue.Trim(), Convert.ToInt32(rcbGeoTagging.SelectedValue),
                    rblOutSourcedTest.SelectedValue.Trim(), StrOutSourcedTest, rblReportReceivedMode.SelectedValue.Trim(),
                    rblReportsReceivedFrom.SelectedValue.Trim(), txtComment.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()),
                    out IsDataExists);

                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Report Data Already Exists");
                }
                else
                {
                    //SaveReportRemark();
                    showPopup("Warning", "Report Data Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateReportDetails(Convert.ToInt32(lblReportId.Text.Trim()), Convert.ToInt32(lblCaseRefId.Text.Trim()), Variables.AppointmentId,
                    dtAppointmentReport, "0", Convert.ToInt32(rcbReportStatus.SelectedValue),
                    dtpClosureApproval.DateInput.SelectedDate.Equals(null) ? nul : dtpClosureApproval.DateInput.SelectedDate.Value,
                    rblPhotoId.SelectedValue.Trim(), rblPhoto.SelectedValue.Trim(), Convert.ToInt32(rcbGeoTagging.SelectedValue),
                    rblOutSourcedTest.SelectedValue.Trim(), StrOutSourcedTest, rblReportReceivedMode.SelectedValue.Trim(),
                    rblReportsReceivedFrom.SelectedValue.Trim(), txtComment.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()),
                    out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Report Data Already Exists");
                }
                else
                {
                    //SaveReportRemark();
                    showPopup("Warning", "Report Data Updated Successfully");

                }
            }


        }

        //public void SaveReportRemark()
        //{
        //    Bal BusinessAccessLayer = new Bal();
        //    //string IsDataExists = "0";

        //    BusinessAccessLayer.InsertUpdateReportRemarkDetails(0, Convert.ToInt32(lblCaseRefId.Text), txtComment.Text.Trim(),
        //        0, Convert.ToInt32(rcbCaseStatus.SelectedValue), Convert.ToInt32(rcbReportStatus.SelectedValue), 
        //        Convert.ToInt32(Session["LoginRefId"].ToString()));
        //}

        public void ClearReportFields()
        {

        }

        protected void LinkAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentView.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.CaseRefId = 0;
            Variables.AppointmentId = 0;
            Response.Redirect("~/Case/AppointmentList.aspx");
        }

        public void LoadAppointmentDetailById()
        {
            DataSet dtAppointmentDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtAppointmentDetails = BusinessAccessLayer.LoadAppointmentDetailsById(Variables.AppointmentId);


            if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[0].Rows.Count > 0)
            {
                //btnSave.Text = "Update";
                lblQCAppointmentId.Text = dtAppointmentDetails.Tables[0].Rows[0]["AppointmentId"].ToString();
                lblCorporateId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CorporateId"].ToString();
                TestList();
                lblCaseOwnerName.Text = dtAppointmentDetails.Tables[0].Rows[0]["EmployeeName"].ToString();
                lblApplicationNo.Text = dtAppointmentDetails.Tables[0].Rows[0]["ApplicationNo"].ToString();
                lblCaseRefId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseRefId"].ToString();
                lblCaseId.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseId"].ToString();                
                lblCaseStatus.Text = dtAppointmentDetails.Tables[0].Rows[0]["CaseStatusName"].ToString();
                rcbCaseStatus.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["CaseStatus"].ToString();
                lblAppointmentStatus.Text = dtAppointmentDetails.Tables[0].Rows[0]["AppointmentDescription"].ToString();

                lblInterpretationType.Text = dtAppointmentDetails.Tables[0].Rows[0]["InterpretationTypeValue"].ToString();
                lblDoctorName.Text = dtAppointmentDetails.Tables[0].Rows[0]["DoctorName"].ToString();
                lblDoctorRegnNo.Text = dtAppointmentDetails.Tables[0].Rows[0]["RegistrationNumber"].ToString();

                rcbReportStatus.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["ReportStatus"].ToString();
                lblReportId.Text = dtAppointmentDetails.Tables[0].Rows[0]["ReportId"].ToString();
                if(lblReportId.Text=="")
                {
                    btnSave.Text = "Save";
                }
                else
                {
                    btnSave.Text = "Update";
                }
                dtpClosureApproval.DbSelectedDate = dtAppointmentDetails.Tables[0].Rows[0]["DateOfClosureApproval"].ToString();
                rblPhotoId.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["PhotoId"].ToString();
                rblPhoto.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["Photo"].ToString();
                LoadMasterGeoTagging();
                rcbGeoTagging.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["GeoTagging"].ToString();
                rblOutSourcedTest.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["OutSourced"].ToString();

                string MedicalTest = dtAppointmentDetails.Tables[0].Rows[0]["MedicalTest"].ToString();
                string ViewTestList = "";
                String[] MedicalTestValue = MedicalTest.Split(',');

                int lenght = MedicalTestValue.Length;

                foreach (string s in MedicalTestValue)
                {
                    foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;

                            if (ViewTestList.Equals(""))
                            {
                                ViewTestList = item.Text;
                            }
                            else
                            {
                                ViewTestList += "," + item.Text;

                            }
                            //item.Selected = true;
                            lblMedicalTest.Text = ViewTestList;
                            break;
                        }
                    }
                }
                string IndividualTest = dtAppointmentDetails.Tables[0].Rows[0]["IndividualTest"].ToString();
                string ViewTestList2 = "";
                String[] IndividualTestValue = IndividualTest.Split(',');

                int lenght2 = IndividualTestValue.Length;

                foreach (string s in IndividualTestValue)
                {
                    foreach (RadComboBoxItem item in rcbMedicalTest.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;

                            if (ViewTestList2.Equals(""))
                            {
                                ViewTestList2 = item.Text;
                            }
                            else
                            {
                                ViewTestList2 += "," + item.Text;

                            }
                            //item.Selected = true;
                            lblScheduledTest.Text = ViewTestList2;
                            break;
                        }
                    }
                }

                LoadTestNPackageList();

                if (rblOutSourcedTest.SelectedValue=="Yes")
                {
                    OutSourced.Visible = true;
                    string CBLOutSourcedTest = dtAppointmentDetails.Tables[0].Rows[0]["OutSourcedTest"].ToString();
                    String[] CBLOutSourcedTestValue = CBLOutSourcedTest.Split(',');

                    int lenght3 = CBLOutSourcedTestValue.Length;

                    foreach (string s in CBLOutSourcedTestValue)
                    {
                        foreach (ListItem item in CBL_OutSourcedTestList.Items)
                        {
                            if (item.Value == s)
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    OutSourced.Visible = false;
                }

                rblReportReceivedMode.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["ReportRecMode"].ToString();
                rblReportsReceivedFrom.SelectedValue = dtAppointmentDetails.Tables[0].Rows[0]["ReportRecFrom"].ToString();
                txtComment.Text = dtAppointmentDetails.Tables[0].Rows[0]["ReportComment"].ToString();
                
                if (dtAppointmentDetails != null && dtAppointmentDetails.Tables[1].Rows.Count > 0)
                {
                    RadGridReports.DataSource = dtAppointmentDetails.Tables[1];
                    RadGridReports.DataBind();

                    //Session["AdditionalDetails"] = dtCorporateDetails.Tables[3];
                }
                else
                {
                    RadGridReports.DataSource = new object[] { }; //null;
                    RadGridReports.DataBind();
                }

                
            }

        }
        //protected void ViewFile(object sender, EventArgs e)
        //{
        //    string url = string.Format("Home.aspx?FN={0}", (sender as LinkButton).CommandArgument);
        //    string script = "<script type='text/javascript'>window.open('" + url + "')</script>";
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
        //}
        //private void AddControl()
        //{
        //    if (test == "FALSE")
        //    {
        //        for (int i = 0; i < Request.Files.Count - 1; i++)
        //        {
        //            AddRemovePanel(i);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < Request.Files.Count + 1; i++)
        //        {
        //            AddRemovePanel(i);
        //        }
        //    }
        //}

        //private void AddRemovePanel(int i)
        //{
        //    FileUpload file = new FileUpload();
        //    file.ID = "File" + (i + 1);
        //    Button btnremove = new Button();
        //    btnremove.ID = "btn" + (i + 1);
        //    btnremove.Text = "Remove";
        //    btnremove.Click += new EventHandler(RemoveFileUpload);
        //    Literal li = new Literal();
        //    li.Text = "<br/>";
        //    Panel pnl = new Panel();
        //    pnl.ID = "dynamicpanel" + (i + 1);
        //    pnl.Controls.Add(file);
        //    pnl.Controls.Add(btnremove);
        //    pnl.Controls.Add(li);
        //    this.pnlTemp.Controls.Add(pnl);
        //}

        //protected void RemoveFileUpload(object sender, EventArgs e)
        //{
        //    this.pnlTemp.Controls.Clear();
        //    test = "FALSE";
        //    this.AddControl();
        //}


        protected void btnQCCheckList_Click(object sender, EventArgs e)
        {
            Variables.AppointmentId = Convert.ToInt32(lblQCAppointmentId.Text.Trim());

            Response.Redirect("~/Case/QCSummary.aspx");
        }

        protected void rblOutSourcedTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rblOutSourcedTest.SelectedValue=="Yes")
            {
                OutSourced.Visible = true;                           
            }
            else
            {
                OutSourced.Visible = false;
            }
        }

        protected void rblPhoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadMasterGeoTagging();
        }

        protected void RadGridReports_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblAppointmentReportId = (Label)RadGridReports.Items[intIndex % 10].FindControl("lblAppointmentReportId");
                    Variables.AppointmentReportId = Convert.ToInt32(lblAppointmentReportId.Text.Trim());

                    DataTable dtReport = new DataTable();
                    Bal BusinessAccessLayer = new Bal();
                    dtReport =  BusinessAccessLayer.GetReportonAppointmentId(Variables.AppointmentReportId);
                    string Filename = "";
                    byte[] FileData = new byte[5242880];
                    if(dtReport!=null && dtReport.Rows.Count>0)
                    {
                        Filename = dtReport.Rows[0]["ReportName"].ToString();
                        //FileData= Convert.ToByte(dtReport.Rows[0][""].ToString());
                        FileData = (byte[])dtReport.Rows[0]["ReportData"];
                    }

                    // string directoryName = String.Empty;
                    //var path = HttpRuntime.AppDomainAppPath;
                    //directoryName = System.IO.Path.Combine(path, "UploadImages");
                    string directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                    string FilePath = directory + "AppointmentReports" + "\\" + Filename;

                    //string FilePath = @"E:\Welleazy\Welleazy\AppointmentReports\"+Filename;
                    File.WriteAllBytes(FilePath, FileData);

                    Session["FilePath"] = FilePath;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../ViewDocuments/ViewDocument.aspx');", true);

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:1125/ViewDocuments/ViewDocument.aspx','_blank');", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">window.location.href='ViewDocument.aspx';</script>");

                    //Response.Redirect("~/ViewDocuments/ViewDocument.aspx"); //--Running Code


                }
                catch(Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
                }
             }
        }

        
    }
}