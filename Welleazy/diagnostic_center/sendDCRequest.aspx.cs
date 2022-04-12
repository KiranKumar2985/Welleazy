using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.Net.Mail;

namespace Welleazy.diagnostic_center
{
    public partial class sendDCRequest : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        string hash = "welnext";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"]!=null)
                {
                    ProviderTypeList();
                    GenerateServiceProivderId();
                }
            }
        }

        public void ProviderTypeList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtType = new DataTable();
            dtType = BusinessAccessLayer.LoadProvideTypeDetailsDropDown();

            if (dtType != null && dtType.Rows.Count > 0)
            {
                DDL_ServiceProviderType.DataSource = dtType;
                DDL_ServiceProviderType.DataTextField = "ProviderType";
                DDL_ServiceProviderType.DataValueField = "ProviderTypeId";
                DDL_ServiceProviderType.DataBind();
            }
        }
        public void GenerateServiceProivderId()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtdcId = new DataTable();
            Int32 dcid = 0;

            dtdcId = BusinessAccessLayer.GenerateServiceProviderId();
            if (dtdcId != null && dtdcId.Rows.Count > 0)
            {
                dcid = Convert.ToInt32(dtdcId.Rows[0]["dc_id"].ToString());
                lbl_dcid.Text = "SP0000" + dcid.ToString();
                //if (CaseId < 9)
                //{
                //    lbl_dcid.Text = "WX0000" + CaseId.ToString();
                //}

                //else if (CaseId > 9 && CaseId < 100)
                //{
                //    lbl_dcid.Text = "WX000" + CaseId.ToString();
                //}
                //else if (CaseId > 99 && CaseId < 1000)
                //{
                //    lbl_dcid.Text = "WX00" + CaseId.ToString();
                //}
                //else if (CaseId > 999 && CaseId < 10000)
                //{
                //    lbl_dcid.Text = "WX0" + CaseId.ToString();
                //}
                //else
                //{
                //    lbl_dcid.Text = "WX" + CaseId.ToString();
                //}

            }
        }
        public void Laboratory()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd2 = new SqlCommand("Provider_Laboratory_Status_CRUD", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Action", "Insert");
            cmd2.Parameters.AddWithValue("@lab_id", Label1.Text);
            cmd2.Parameters.AddWithValue("@dc_id", lbldc_id.Text);
            cmd2.Parameters.AddWithValue("@x_ray", "");
            cmd2.Parameters.AddWithValue("@digital_x_ray", "");
            cmd2.Parameters.AddWithValue("@ultra_sound", "");
            cmd2.Parameters.AddWithValue("@color_doppler", "");
            cmd2.Parameters.AddWithValue("@mammogram", "");
            cmd2.Parameters.AddWithValue("@ct_scan", "");
            cmd2.Parameters.AddWithValue("@mri", "");
            cmd2.Parameters.AddWithValue("@PET_Scan", "");
            cmd2.Parameters.AddWithValue("@Nuclear_Imaging", "");
            cmd2.Parameters.AddWithValue("@ECG", "");
            cmd2.Parameters.AddWithValue("@PFT", "");
            cmd2.Parameters.AddWithValue("@TMT", "");
            cmd2.Parameters.AddWithValue("@Echo_2D", "");
            cmd2.Parameters.AddWithValue("@fluoroscopy", "");
            cmd2.Parameters.AddWithValue("@x_ray1", "");
            cmd2.Parameters.AddWithValue("@digital_x_ray1", "");
            cmd2.Parameters.AddWithValue("@ultra_sound1", "");
            cmd2.Parameters.AddWithValue("@color_doppler1", "");
            cmd2.Parameters.AddWithValue("@mammogram1", "");
            cmd2.Parameters.AddWithValue("@ct_scan1", "");
            cmd2.Parameters.AddWithValue("@mri1", "");
            cmd2.Parameters.AddWithValue("@PET_Scan1", "");
            cmd2.Parameters.AddWithValue("@Nuclear_Imaging1", "");
            cmd2.Parameters.AddWithValue("@ECG1", "");
            cmd2.Parameters.AddWithValue("@PFT1", "");
            cmd2.Parameters.AddWithValue("@TMT1", "");
            cmd2.Parameters.AddWithValue("@Echo_2D1", "");
            cmd2.Parameters.AddWithValue("@fluoroscopy1", "");
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        public void Manpower_staffing()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd1 = new SqlCommand("Provider_Manpower_Staffing_CRUD", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Action", "Insert");
            cmd1.Parameters.AddWithValue("@manpower_id", Label1.Text);
            cmd1.Parameters.AddWithValue("@dc_id", lbldc_id.Text);
            cmd1.Parameters.AddWithValue("@insurance_desk_title", "");
            cmd1.Parameters.AddWithValue("@insurance_desk_name", "");
            cmd1.Parameters.AddWithValue("@insurance_desk_designation", "");
            cmd1.Parameters.AddWithValue("@insurance_desk_email", "");
            cmd1.Parameters.AddWithValue("@insurance_desk_cellno", "");
            cmd1.Parameters.AddWithValue("@business_development_title", "");
            cmd1.Parameters.AddWithValue("@business_development_name", "");
            cmd1.Parameters.AddWithValue("@business_development_designation", "");
            cmd1.Parameters.AddWithValue("@business_development_email", "");
            cmd1.Parameters.AddWithValue("@business_development_cellno", "");
            cmd1.Parameters.AddWithValue("@finance_title", "");
            cmd1.Parameters.AddWithValue("@finance_name", "");
            cmd1.Parameters.AddWithValue("@finance_designation", "");
            cmd1.Parameters.AddWithValue("@finance_email", "");
            cmd1.Parameters.AddWithValue("@finance_cellno", "");
            cmd1.Parameters.AddWithValue("@clinical_services_title", "");
            cmd1.Parameters.AddWithValue("@clinical_services_name", "");
            cmd1.Parameters.AddWithValue("@clinical_services_designation", "");
            cmd1.Parameters.AddWithValue("@clinical_services_email", "");
            cmd1.Parameters.AddWithValue("@clinical_services_cellno", "");
            cmd1.Parameters.AddWithValue("@nursing_services_title", "");
            cmd1.Parameters.AddWithValue("@nursing_services_name", "");
            cmd1.Parameters.AddWithValue("@nursing_services_designation", "");
            cmd1.Parameters.AddWithValue("@nursing_services_email", "");
            cmd1.Parameters.AddWithValue("@nursing_services_cellno", "");
            cmd1.Parameters.AddWithValue("@fund_transfer_title", "");
            cmd1.Parameters.AddWithValue("@fund_transfer_name", "");
            cmd1.Parameters.AddWithValue("@fund_transfer_designation", "");
            cmd1.Parameters.AddWithValue("@fund_transfer_email", "");
            cmd1.Parameters.AddWithValue("@fund_transfer_cellno", "");
            cmd1.Parameters.AddWithValue("@cashless_opd_title", "");
            cmd1.Parameters.AddWithValue("@cashless_opd_name", "");
            cmd1.Parameters.AddWithValue("@cashless_opd_designation", "");
            cmd1.Parameters.AddWithValue("@cashless_opd_email", "");
            cmd1.Parameters.AddWithValue("@cashless_opd_cellno", "");
            cmd1.Parameters.AddWithValue("@organization_title", "");
            cmd1.Parameters.AddWithValue("@organization_name", "");
            cmd1.Parameters.AddWithValue("@organization_designation", "");
            cmd1.Parameters.AddWithValue("@organization_email", "");
            cmd1.Parameters.AddWithValue("@organization_cellno", "");
            cmd1.Parameters.AddWithValue("@business_spoc_title", "");
            cmd1.Parameters.AddWithValue("@business_spoc_name", "");
            cmd1.Parameters.AddWithValue("@business_spoc_designation", "");
            cmd1.Parameters.AddWithValue("@business_spoc_email", "");
            cmd1.Parameters.AddWithValue("@business_spoc_cellno", "");
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

        }
        public void Provider_information()
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            FetchDC_ID();
            string dcid = HttpUtility.UrlEncode(encrypttext(lbldc_id.Text.Trim()));
            txt_URL.Text = "http://uat.welleazy.com/diagnostic_center/UpdateProviderDetails.aspx?text=" + dcid + "";
            lblMsg.Text = "Provider created successfully, Please Check your Register Email and Contact Number";

            URL_link.Visible = true;

            if (URL_link.Visible == true)
            {
                btnSaveGenerate.Visible = false;
                OTP_Generate();

                //Pending Code For SMS & Email
                //SendMessage();

            }
            else
            {
                btnSaveGenerate.Visible = true;
            }


            OTP_Generate();

            

            BusinessAccessLayer.InsertUpdateServiceProviderDetails(0, lbl_dcid.Text.Trim(), 0, txt_Emailid.Text.Trim(), 0, "B", "Normal", "Approval Pending",
                Convert.ToInt32(DDL_ServiceProviderType.SelectedValue), 0, 0, "", 0, "", "", "", txt_Hospitalname.Text.Trim(),"", "", "", 0, 0,
                "", "", "", txt_Contactnumber.Text.Trim(), "", txt_Emailid.Text.Trim(), "","","", 0,"", "", "", 0, 0, "", 0, 0,0, "", txt_Concernedperson.Text.Trim(), 
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Convert.ToInt32(Session["LoginRefId"].ToString()),
                txt_URL.Text.Trim(), li.Text.Trim(), 0, "NA", null, 0, out IsDataExists);

            if (IsDataExists == "1")
            {
                showPopup("Warning", "DC Already Exists");
            }
            else
            {
                //showPopup("Warning", "DC Add Successfully");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
            }
            //SqlConnection con = new SqlConnection(conStr);
            //SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Action", "Insert");
            //cmd.Parameters.AddWithValue("@dc_id", "");
            //cmd.Parameters.AddWithValue("@parent_dcid", "");
            //cmd.Parameters.AddWithValue("@ic_id", "");
            //cmd.Parameters.AddWithValue("@username", "");
            //cmd.Parameters.AddWithValue("@center_prioritization", "");
            //cmd.Parameters.AddWithValue("@center_grading", "B");
            //cmd.Parameters.AddWithValue("@center_categorization", "Normal");
            //cmd.Parameters.AddWithValue("@center_status", "Approval Pending");
            //cmd.Parameters.AddWithValue("@type_of_provider", DDL_ServiceProviderType.SelectedValue);
            //cmd.Parameters.AddWithValue("@type_of_specialty", "");
            //cmd.Parameters.AddWithValue("@ownership", "");
            //cmd.Parameters.AddWithValue("@corporate_group", "");
            //cmd.Parameters.AddWithValue("@provider_setup", "");
            //cmd.Parameters.AddWithValue("@service_area", "");
            //cmd.Parameters.AddWithValue("@home_delivery", "");
            //cmd.Parameters.AddWithValue("@delivery_tat", "");
            //cmd.Parameters.AddWithValue("@center_name", txt_Hospitalname.Text);
            //cmd.Parameters.AddWithValue("@plot_no", "");
            //cmd.Parameters.AddWithValue("@address", "");
            //cmd.Parameters.AddWithValue("@area", "");
            //cmd.Parameters.AddWithValue("@state", "");
            //cmd.Parameters.AddWithValue("@city", "");
            //cmd.Parameters.AddWithValue("@pincode", "");
            //cmd.Parameters.AddWithValue("@stdcode", "");
            //cmd.Parameters.AddWithValue("@landline_no", "");
            //cmd.Parameters.AddWithValue("@mobile_no", txt_Contactnumber.Text);
            //cmd.Parameters.AddWithValue("@fax_no", "");
            //cmd.Parameters.AddWithValue("@emailid", txt_Emailid.Text);
            //cmd.Parameters.AddWithValue("@website", "");
            //cmd.Parameters.AddWithValue("@reconized_by", "");
            //cmd.Parameters.AddWithValue("@reconized_by_others", "");
            //cmd.Parameters.AddWithValue("@accreditation", "");
            //cmd.Parameters.AddWithValue("@accreditation_others", "");
            //cmd.Parameters.AddWithValue("@service_type", "");
            //cmd.Parameters.AddWithValue("@ambulance", "");
            //cmd.Parameters.AddWithValue("@ambulance_yes", "");
            //cmd.Parameters.AddWithValue("@health_checkup", "");
            //cmd.Parameters.AddWithValue("@bls_ambulance", "");
            //cmd.Parameters.AddWithValue("@acls_ambulance", "");
            //cmd.Parameters.AddWithValue("@specialties_available", "");
            //cmd.Parameters.AddWithValue("@staff_strength", "");
            //cmd.Parameters.AddWithValue("@doctor_consultants", "");
            //cmd.Parameters.AddWithValue("@doctor_consultants_visiting", "");
            //cmd.Parameters.AddWithValue("@account_no", "");
            //cmd.Parameters.AddWithValue("@name_of_holder", txt_Concernedperson.Text);
            //cmd.Parameters.AddWithValue("@designation_holder", "");
            //cmd.Parameters.AddWithValue("@bank_name", "");
            //cmd.Parameters.AddWithValue("@branch", "");
            //cmd.Parameters.AddWithValue("@ifsc_code", "");
            //cmd.Parameters.AddWithValue("@cancelled_cheque", "");
            //cmd.Parameters.AddWithValue("@bank_letter", "");
            //cmd.Parameters.AddWithValue("@list_of_provider_branch", "");
            //cmd.Parameters.AddWithValue("@registration_certificate", "");
            //cmd.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", "");
            //cmd.Parameters.AddWithValue("@building_permit", "");
            //cmd.Parameters.AddWithValue("@fire_safety_license", "");
            //cmd.Parameters.AddWithValue("@pndt_license", "");
            //cmd.Parameters.AddWithValue("@radiation_protection_certificate", "");
            //cmd.Parameters.AddWithValue("@no_objection_polution_ctrl", "");
            //cmd.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", "");
            //cmd.Parameters.AddWithValue("@cc_bs_passbook", "");
            //cmd.Parameters.AddWithValue("@pan_card", "");
            //cmd.Parameters.AddWithValue("@neft_declaration_form", "");
            //cmd.Parameters.AddWithValue("@gst_certificate", "");
            //cmd.Parameters.AddWithValue("@hospital_opd_tariff", "");
            //cmd.Parameters.AddWithValue("@list_of_tpa", "");
            //cmd.Parameters.AddWithValue("@list_of_consultant", "");
            //cmd.Parameters.AddWithValue("@opd_schedule_for_consultant", "");
            //cmd.Parameters.AddWithValue("@any_other_document", "");
            //cmd.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").ToString());
            //cmd.Parameters.AddWithValue("@created_by", Session["username"].ToString());

            
            //cmd.Parameters.AddWithValue("@provider_url", txt_URL.Text);
            //cmd.Parameters.AddWithValue("@otp", li.Text);
            //cmd.Parameters.AddWithValue("@no_of_attempt", "");
            //cmd.Parameters.AddWithValue("@deactivation_reason", "NA");
            //cmd.Parameters.AddWithValue("@deactivation_date", "");
            //cmd.Parameters.AddWithValue("@deactivation_by", "");
            //con.Open();

            //cmd.ExecuteNonQuery();
            //con.Close();
        }
        public void DCImage()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("DC_Image_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Insert");
            cmd.Parameters.AddWithValue("@image_id", Label1.Text);
            cmd.Parameters.AddWithValue("@dc_id", lbldc_id.Text);
            cmd.Parameters.AddWithValue("@imagename", "");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnSaveGenerate_Click(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmdcount = new SqlCommand("select count(*) from Tbl_DC_Information where type_of_provider='" + DDL_ServiceProviderType.SelectedValue + "' AND center_name='" + txt_Hospitalname.Text + "'", con);
                cmdcount.Connection = con;
                int count = Convert.ToInt32(cmdcount.ExecuteScalar());
                if (count > 0)
                {
                showPopup("Warning", "Service provider Name Already Exist...!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Hospital Name Already Exist..!');</script>");
                }
                else
                {
                    try
                    {
                    string emailid = txt_Emailid.Text.Trim();

                    //con.Open();
                    DataTable result = new DataTable();
                    SqlCommand cmd = new SqlCommand("select substring('" + emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
                    var adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(result);

                    if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in") || result.Rows[0]["Ext"].Equals("net") || result.Rows[0]["Ext"].Equals("edu") || result.Rows[0]["Ext"].Equals("org"))
                    {
                        lblEmailError.Text = "";
                        Provider_information();
                    }
                    else
                    {
                        lblEmailError.Text = "Invalid Email Id";
                        showPopup("Warning", "Invalid Email Address");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Invalid Email Address!');</script>");
                        return;
                    }
                    
                        Laboratory();
                        Manpower_staffing();
                        DCImage();
                        SendMessage();
                    
                        

                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Service Provider Add Successfully..!');</script>");
                        string ProviderURL = txt_URL.Text;
                        string EmailId = txt_Emailid.Text;

                        SendEmail(ProviderURL, EmailId);
                        showPopup("Warning", "Service provider Add Successfully...");
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
        }

        
        public void SendEmail(string ProviderURL, string EmailId)
        {
            //MailMessage mm = new MailMessage("Alerts@welleazy.com", EmailId);
            //string cc = "kamlesh.prajapat@welleazy.com";
            //mm.CC.Add(cc);
            //mm.Subject = "For Provider Services - " + txt_Hospitalname.Text;
            //mm.Body = "<div style='font-family:Calibri;'> " +
            //          "<b>Dear Service Provider,</b><br /><br />Please update your details and complete your profile on WELLEAZY.<br />" +
            //          "Token Id : '" + lbl_dcid.Text + "'<br /> Visit link: '" + ProviderURL + "' ,<br /><br /> Regards, Team WELLEAZY.</div>";
            //mm.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();

            ////smtp.EnableSsl = true;
            //NetworkCredential NetworkCred = new NetworkCredential();

            ////smtp.Timeout = 10000;
            //NetworkCred.UserName = "Alerts@welleazy.com";
            //NetworkCred.Password = "Network@123";

            //smtp.Host = "smtpout.secureserver.net";
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = NetworkCred;
            //smtp.Port = 465;

            //smtp.Send(mm);
            try
            {

                HyperLink hl1 = new HyperLink();
                hl1.Text = ProviderURL;
                hl1.NavigateUrl = ProviderURL;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("alerts@welleazy.com");
                mail.Subject = "For Provider Services - " + txt_Hospitalname.Text;


                mail.To.Add(new MailAddress(EmailId));
                mail.Body = "<div style='font-family:Calibri;'> " +
                          "<b>Dear Service Provider,</b><br /><br />Please update your details and complete your profile on WELLEAZY.<br />" +
                          "Token Id : '" + lbl_dcid.Text + "'<br /> Visit link: " + hl1.NavigateUrl + " ,<br /><br /> Regards, Team WELLEAZY.</div>";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.secureserver.net";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Timeout = 0;
                smtp.Credentials = new System.Net.NetworkCredential("alerts@welleazy.com", "Network@123");
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 465;
                smtp.Send(mail);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email sent Successfully..!');</script>");
            }
            catch (Exception ex)
            {

            }
            
        }

    
        public void SendMessage()
        {
            //Your user name
            //string user = "WELNEX";
            //Your authentication key
            //string key = "Aebc12bb79cecc469fc48a451657b3c01";
            //Multiple mobiles numbers separated by comma
            string mobile ="+91" + txt_Contactnumber.Text; //"+918779017886";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderid = "WELNEX";
            //Your message to send, Add URL encoding here.
            //string name = "XYZ";
            string message = HttpUtility.UrlEncode("Dear Service Provider, Your one time password is '"+ li.Text + "' to update your details.");

            String URL = "https://api.ap.kaleyra.io/v1/HXAP1636111382IN/messages?to=" + mobile + "&sender=" + senderid + "&type=TXN&body=" + message + "&api-key=Aebc12bb79cecc469fc48a451657b3c01&Content-Type=application/x-www-form-urlencoded";
            

            try
            {

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12;
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();


                HttpWebResponse response = httpWReq.GetResponse() as HttpWebResponse;

                string url = response.ResponseUri.OriginalString;

            }
            catch (SystemException ex)
            {
                ex.Message.ToString();
            }
        }


        //public void SendMessage()
        //{
        //    //Your user name
        //    string user = "WELNEX";
        //    //Your authentication key
        //    string key = "Aebc12bb79cecc469fc48a451657b3c01";


        //    //Multiple mobiles numbers separated by comma
        //    string mobile = "+918779017886"; //"+918779017886";
        //    //Sender ID,While using route4 sender id should be 6 characters long.
        //    //string senderid = "WELNEX";// "WELNEX";
        //    //Your message to send, Add URL encoding here.
        //    //string name = "Kamlesh";
        //    string message = HttpUtility.UrlEncode("Dear Service Provider,Your one time password is 123476 to update your details.");

        //    //Prepare you post parameters

        //    String sbPostData = "to=" + mobile + "&sender=" + user + "&body= " + message + "&api-key=" + key + "&Content-Type=application/x-www-form-urlencoded";

        //    Label3.Text = sbPostData;
        //    try
        //    {
        //        //Call Send SMS API
        //        string sendSMSUri = "https://api.ap.kaleyra.io/v1/HXAP1636111382IN/messages?";
        //        //Create HTTPWebrequest
        //        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //        //Prepare and Add URL Encoded data
        //        UTF8Encoding encoding = new UTF8Encoding();
        //        byte[] data = encoding.GetBytes(sbPostData.ToString());
        //        //Specify post method
        //        httpWReq.Method = "POST";
        //        //httpWReq.ContentType = "application/x-www-form-urlencoded";
        //        httpWReq.ContentLength = data.Length;
        //        using (Stream stream = httpWReq.GetRequestStream())
        //        {
        //            stream.Write(data, 0, data.Length);
        //        }
        //        //Get the response
        //        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        string responseString = reader.ReadToEnd();

        //        //Close the response
        //        reader.Close();
        //        response.Close();
        //        Label2.Text = "SMS send";
        //    }
        //    catch (SystemException ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        public void FetchDC_ID()
        {
        SqlConnection con = new SqlConnection(conStr);
        con.Open();
        string che = @"select count(*) from Tbl_DC_Information";
        SqlCommand cmd1 = new SqlCommand(che, con);
        int count = (int)cmd1.ExecuteScalar();
        if (count == '0')
        {
            lbldc_id.Text = "1";
        }
        else
        {

            SqlCommand cmd = new SqlCommand("select MAX (dc_id) dc_id from Tbl_DC_Information", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lbldc_id.Text = dr[0].ToString();
                }
            }

            if (lbldc_id.Text == "")
            {
                lbldc_id.Text = "1";
            }
            else if (lbldc_id.Text != "0")
            {
                lbldc_id.Text = (Convert.ToInt32(lbldc_id.Text) + 1).ToString();
            }
            else
            {

            }
            
        }
        con.Close();
        }
        public void OTP_Generate()
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdigit = 6;
            string finaldigit;
            int getindex;
            for(int i=0; i<otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }
            li.Text = otp;
        }

        public string encrypttext(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypttext(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            txt_Hospitalname.Text = "";
            txt_Emailid.Text = "";
            DDL_ServiceProviderType.SelectedValue = "0";
            txt_Concernedperson.Text = "";
            txt_Contactnumber.Text = "";
            URL_link.Visible = false;
        }
    }
}