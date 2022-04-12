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
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Welleazy.diagnostic_center
{
    public partial class AddNewDc : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        string hash = "welnext";
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"]!=null)
                {
                    StateList();
                    ProviderTypeList();
                    SpecialtyTypeList();
                    OwnershipList();
                    LoadSpecialities();
                    LoadReconized();
                    LoadAccreditation();
                    ServiceTypeList();
                    CorporateList();
                    GenerateServiceProivderId();

                    TypeOfProvider.Visible = true;
                    Depart1.Visible = false;
                    ProviderBInformation.Visible = true;
                    ProviderRecognition.Visible = true;
                    ProviderManpower.Visible = true;
                    Dep1.Visible = true;
                    ProviderServices.Visible = true;
                    Specialtiesavail.Visible = true;
                    LaboratoryRadiology.Visible = true;
                    //ListOfDoctor.Visible = false;
                    AccountNumber.Visible = true;
                    SaveContinue.Visible = true;
                    UploadDocs.Visible = false;
                    DocumentUpload.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('Your session has expired!')</script>" + "<script>window.location.href='/Login.aspx';</script>");
                }
            }
        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                DDL_CorporateName.DataSource = dtLoadCorporateList;
                DDL_CorporateName.DataTextField = "CorporateName";
                DDL_CorporateName.DataValueField = "CorporateId";
                DDL_CorporateName.DataBind();
                
            }
            else
            {
                DDL_CorporateName.DataSource = null;
                DDL_CorporateName.DataBind();
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

        public void ProviderTypeList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtType = new DataTable();
            dtType = BusinessAccessLayer.LoadProvideTypeDetailsDropDown();

            if (dtType != null && dtType.Rows.Count > 0)
            {
                DDL_Typeofprovider.DataSource = dtType;
                DDL_Typeofprovider.DataTextField = "ProviderType";
                DDL_Typeofprovider.DataValueField = "ProviderTypeId";
                DDL_Typeofprovider.DataBind();
            }
        }
        public void SpecialtyTypeList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtType = new DataTable();
            dtType = BusinessAccessLayer.LoadSpecialtyTypeDropDown();

            if (dtType != null && dtType.Rows.Count > 0)
            {
                DDL_Typeofspecialty.DataSource = dtType;
                DDL_Typeofspecialty.DataTextField = "SpecialtyType";
                DDL_Typeofspecialty.DataValueField = "SpecialtyTypeId";
                DDL_Typeofspecialty.DataBind();
            }
        }
        public void OwnershipList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtType = new DataTable();
            dtType = BusinessAccessLayer.LoadOwnershipDropDown();

            if (dtType != null && dtType.Rows.Count > 0)
            {
                DDL_Ownership.DataSource = dtType;
                DDL_Ownership.DataTextField = "Ownership";
                DDL_Ownership.DataValueField = "OwnershipId";
                DDL_Ownership.DataBind();
            }
        }

        public void ServiceTypeList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtServiceType = new DataTable();
            dtServiceType = BusinessAccessLayer.LoadServiceTypeDropDown();

            if (dtServiceType != null && dtServiceType.Rows.Count > 0)
            {
                DDL_Servicetype.DataSource = dtServiceType;
                DDL_Servicetype.DataTextField = "ServiceType";
                DDL_Servicetype.DataValueField = "ServiceTypeId";
                DDL_Servicetype.DataBind();
            }
        }
        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                DDL_State.DataSource = dtState;
                DDL_State.DataTextField = "StateName";
                DDL_State.DataValueField = "StateId";
                DDL_State.DataBind();
            }
        }

        public void LoadSpecialities()
        {
            CBL_Specialties.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtSpecialities = new DataTable();

            dtSpecialities = BusinessAccessLayer.LoadSpecialitiesList();

            if (dtSpecialities != null && dtSpecialities.Rows.Count > 0)
            {
                CBL_Specialties.DataSource = dtSpecialities;
                CBL_Specialties.DataTextField = "Description";
                CBL_Specialties.DataValueField = "SpecialityId";
                CBL_Specialties.DataBind();
            }
        }

        public void LoadReconized()
        {
            CBL_Recongnizedby.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtReconized = new DataTable();

            dtReconized = BusinessAccessLayer.LoadReconizedList();

            if (dtReconized != null && dtReconized.Rows.Count > 0)
            {
                CBL_Recongnizedby.DataSource = dtReconized;
                CBL_Recongnizedby.DataTextField = "Description";
                CBL_Recongnizedby.DataValueField = "ReconizedId";
                CBL_Recongnizedby.DataBind();
            }
        }

        public void LoadAccreditation()
        {
            CBL_Accreditation.Items.Clear();
            Bal BusinessAccessLayer = new Bal();
            DataTable dtAccreditation = new DataTable();

            dtAccreditation = BusinessAccessLayer.LoadAccreditationList();

            if (dtAccreditation != null && dtAccreditation.Rows.Count > 0)
            {
                CBL_Accreditation.DataSource = dtAccreditation;
                CBL_Accreditation.DataTextField = "Description";
                CBL_Accreditation.DataValueField = "AccreditationId";
                CBL_Accreditation.DataBind();
            }
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

        //public static string Encrypt(string inputText)
        //{
        //    string encryptionkey = "SAUW193BX628TD57";
        //    byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
        //    RijndaelManaged rijndaelCipher = new RijndaelManaged();
        //    byte[] plainText = Encoding.Unicode.GetBytes(inputText);
        //    PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
        //    using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
        //    {
        //        using (MemoryStream mstrm = new MemoryStream())
        //        {
        //            using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
        //            {
        //                cryptstm.Write(plainText, 0, plainText.Length);
        //                cryptstm.Close();
        //                return Convert.ToBase64String(mstrm.ToArray());
        //            }
        //        }
        //    }
        //}
        //public static string Decrypt(string encryptText)
        //{
        //    string encryptionkey = "SAUW193BX628TD57";
        //    byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
        //    RijndaelManaged rijndaelCipher = new RijndaelManaged();
        //    byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
        //    PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
        //    using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
        //    {
        //        using (MemoryStream mstrm = new MemoryStream(encryptedData))
        //        {
        //            using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
        //            {
        //                byte[] plainText = new byte[encryptedData.Length];
        //                int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
        //                return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
        //            }
        //        }
        //    }
        //}
        public void FetchDC_ID()
        {
            SqlConnection con = new SqlConnection(conStr);

            var results = new DataTable();
            //SqlCommand cmd = new SqlCommand("select MAX (dc_id) dc_id from Tbl_DC_Information", con);
            SqlCommand cmd = new SqlCommand("select MAX (dc_id) dc_id from Tbl_DC_Information", con);
            var adapter = new SqlDataAdapter(cmd);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandTimeout = 0;
            adapter.Fill(results);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (results.Rows.Count > 0)
            {
                var dr = results.Rows[0];
                lbldc_id.Text = dr["dc_id"].ToString();
                if (lbldc_id.Text == "")
                {
                    lbldc_id.Text = "1";
                }
                else
                {
                    lbldc_id.Text = dr["dc_id"].ToString();
                    lbl_dc_id.Text = (Convert.ToInt32(lbldc_id.Text) + 1).ToString();
                }

            }
        }
        
        public void Service_Provider_Details()
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            String strRecognized = "";
            for (int i = 0; i <= CBL_Recongnizedby.Items.Count - 1; i++)
            {
                if (CBL_Recongnizedby.Items[i].Selected)
                {
                    if (strRecognized == "")
                    {
                        strRecognized = CBL_Recongnizedby.Items[i].Value;
                    }
                    else
                    {
                        strRecognized += "," + CBL_Recongnizedby.Items[i].Value;
                    }
                }
            }

            String strAccreditation = "";
            for (int i = 0; i <= CBL_Accreditation.Items.Count - 1; i++)
            {
                if (CBL_Accreditation.Items[i].Selected)
                {
                    if (strAccreditation == "")
                    {
                        strAccreditation = CBL_Accreditation.Items[i].Value;
                    }
                    else
                    {
                        strAccreditation += "," + CBL_Accreditation.Items[i].Value;
                    }
                }
            }

            String strSpecialties = "";
            for (int i = 0; i <= CBL_Specialties.Items.Count - 1; i++)
            {
                if (CBL_Specialties.Items[i].Selected)
                {
                    if (strSpecialties == "")
                    {
                        strSpecialties = CBL_Specialties.Items[i].Value;
                    }
                    else
                    {
                        strSpecialties += "," + CBL_Specialties.Items[i].Value;
                    }
                }
            }

            if (FileUploadCancelCheque.PostedFile != null)
            {
                if (FileUploadCancelCheque.HasFile == false)
                {
                    lblUpload19.Text = lblUpload19.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadCancelCheque.FileName);
                    Int32 fileSize = FileUploadCancelCheque.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadCancelCheque.PostedFile.FileName);
                        FileUploadCancelCheque.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload19.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload19.ForeColor = System.Drawing.Color.Red;
                        lblUpload19.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            FetchDC_ID();
            string dcid = HttpUtility.UrlEncode(encrypttext(lbl_dc_id.Text.Trim()));
            lblURL.Text = "http://uat.welleazy.com/diagnostic_center/UpdateProviderDetails.aspx?text=" + dcid + "";

            OTP_Generate();

            string ApprovalStatus = "";

            if(Session["LoginType"].ToString()=="0")
            {
                ApprovalStatus = "Approved";
            }
            else
            {
                ApprovalStatus = "Approval Pending";
            }

            BusinessAccessLayer.InsertUpdateServiceProviderDetails(0, lbl_dcid.Text.Trim(), 0, txt_Emailid.Text.Trim(), 0, "B", "Normal", ApprovalStatus,
                Convert.ToInt32(DDL_Typeofprovider.SelectedValue), Convert.ToInt32(DDL_Typeofspecialty.SelectedValue), Convert.ToInt32(DDL_Ownership.SelectedValue), DDL_Corporategroup.SelectedValue,
                Convert.ToInt32(DDL_CorporateName.SelectedValue), txt_Servicearea.Text.Trim(), txt_Homedelivery.Text.Trim(), txt_Deliverytat.Text.Trim(), txt_Hospitalname.Text.Trim(),
                txt_Plotno.Text.Trim(), txt_Address.Text.Trim(), txt_Area.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue),
                txt_Pincode.Text.Trim(), txt_Stdcode.Text.Trim(), txt_Landlineno.Text.Trim(), txt_Mobileno.Text.Trim(), txt_Fax.Text.Trim(), txt_Emailid.Text.Trim(), txt_Website.Text.Trim(),
                strRecognized, strAccreditation, Convert.ToInt32(DDL_Servicetype.SelectedValue), DDL_Ambulance.SelectedValue, DDL_Ambulanceyes.SelectedValue, DDL_Health.SelectedValue,
                Convert.ToInt32(txt_BLSambulance.Text.Trim()), Convert.ToInt32(txt_ACLSambulance.Text.Trim()), strSpecialties, Convert.ToInt32(txt_Totalstaff.Text.Trim()),
                Convert.ToInt32(txt_Drsfulltime.Text.Trim()), Convert.ToInt32(txt_Drsvisiting.Text.Trim()), txt_accountno.Text.Trim(), txt_nameofholder.Text.Trim(), txt_bankname.Text.Trim(),
                txt_branch.Text.Trim(), txt_ifsccode.Text.Trim(), lblUpload19.Text.Trim(), "","","","","","","","","","","","","","","","","","", Convert.ToInt32(Session["LoginRefId"].ToString()),
                lblURL.Text.Trim(), li.Text.Trim(), 0, "NA", null, 0, out IsDataExists);

            if (IsDataExists == "1")
            {
                showPopup("Warning", "DC Already Exists");
            }
            else
            {
                //showPopup("Warning", "DC Add Successfully");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
            }
        }
    
        //public void ProviderInformation()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Action", "Insert");
        //    cmd.Parameters.AddWithValue("@dc_id", lbldc_id.Text);
        //    cmd.Parameters.AddWithValue("@sptoken_id", lbl_dcid.Text);
        //    cmd.Parameters.AddWithValue("@parent_dcid", Label1.Text);
        //    cmd.Parameters.AddWithValue("@ic_id", Label1.Text);
        //    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
        //    cmd.Parameters.AddWithValue("@center_prioritization", "");
        //    cmd.Parameters.AddWithValue("@center_grading", "B");
        //    cmd.Parameters.AddWithValue("@center_categorization", "Normal");
        //    cmd.Parameters.AddWithValue("@center_status", "Approved");
        //    cmd.Parameters.AddWithValue("@type_of_provider", DDL_Typeofprovider.SelectedValue);
        //    cmd.Parameters.AddWithValue("@type_of_specialty", DDL_Typeofspecialty.SelectedValue);
        //    cmd.Parameters.AddWithValue("@ownership", DDL_Ownership.SelectedValue);
        //    cmd.Parameters.AddWithValue("@corporate_group", DDL_Corporategroup.SelectedItem.Text);
        //    cmd.Parameters.AddWithValue("@provider_setup", ""); //Required remove
        //    cmd.Parameters.AddWithValue("@service_area", txt_Servicearea.Text);
        //    cmd.Parameters.AddWithValue("@home_delivery", txt_Homedelivery.Text);
        //    cmd.Parameters.AddWithValue("@delivery_tat", txt_Deliverytat.Text);
        //    cmd.Parameters.AddWithValue("@center_name", txt_Hospitalname.Text);
        //    cmd.Parameters.AddWithValue("@plot_no", txt_Plotno.Text);
        //    cmd.Parameters.AddWithValue("@address", txt_Address.Text);
        //    cmd.Parameters.AddWithValue("@area", txt_Area.Text);
        //    cmd.Parameters.AddWithValue("@state", DDL_State.SelectedValue);
        //    cmd.Parameters.AddWithValue("@city", DDL_City.SelectedValue);
        //    cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text);
        //    cmd.Parameters.AddWithValue("@stdcode", txt_Stdcode.Text);
        //    cmd.Parameters.AddWithValue("@landline_no", txt_Landlineno.Text);
        //    cmd.Parameters.AddWithValue("@mobile_no", txt_Mobileno.Text);
        //    cmd.Parameters.AddWithValue("@fax_no", txt_Fax.Text);
        //    cmd.Parameters.AddWithValue("@emailid", txt_Emailid.Text);
        //    cmd.Parameters.AddWithValue("@website", txt_Website.Text);
        //    String strRecognized = "";
        //    for (int i = 0; i <= CBL_Recongnizedby.Items.Count - 1; i++)
        //    {
        //        if (CBL_Recongnizedby.Items[i].Selected)
        //        {
        //            if (strRecognized == "")
        //            {
        //                strRecognized = CBL_Recongnizedby.Items[i].Value;
        //            }
        //            else
        //            {
        //                strRecognized += "," + CBL_Recongnizedby.Items[i].Value;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@reconized_by", strRecognized);
        //    cmd.Parameters.AddWithValue("@reconized_by_others", ""); //Required remove
        //    String strAccreditation = "";
        //    for (int i = 0; i <= CBL_Accreditation.Items.Count - 1; i++)
        //    {
        //        if (CBL_Accreditation.Items[i].Selected)
        //        {
        //            if (strAccreditation == "")
        //            {
        //                strAccreditation = CBL_Accreditation.Items[i].Value;
        //            }
        //            else
        //            {
        //                strAccreditation += "," + CBL_Accreditation.Items[i].Value;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@accreditation", strAccreditation);
        //    cmd.Parameters.AddWithValue("@accreditation_others", ""); //Required remove
        //    cmd.Parameters.AddWithValue("@service_type", DDL_Servicetype.SelectedValue);
        //    cmd.Parameters.AddWithValue("@ambulance", DDL_Ambulance.SelectedItem.Text);
        //    cmd.Parameters.AddWithValue("@ambulance_yes", DDL_Ambulanceyes.SelectedItem.Text);
        //    cmd.Parameters.AddWithValue("@health_checkup", DDL_Health.SelectedItem.Text);
        //    cmd.Parameters.AddWithValue("@bls_ambulance", txt_BLSambulance.Text);
        //    cmd.Parameters.AddWithValue("@acls_ambulance", txt_ACLSambulance.Text);
        //    String strSpecialties = "";
        //    for (int i = 0; i <= CBL_Specialties.Items.Count - 1; i++)
        //    {
        //        if (CBL_Specialties.Items[i].Selected)
        //        {
        //            if (strSpecialties == "")
        //            {
        //                strSpecialties = CBL_Specialties.Items[i].Value;
        //            }
        //            else
        //            {
        //                strSpecialties += "," + CBL_Specialties.Items[i].Value;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@specialties_available", strSpecialties);
        //    cmd.Parameters.AddWithValue("@staff_strength", txt_Totalstaff.Text);
        //    cmd.Parameters.AddWithValue("@doctor_consultants", txt_Drsfulltime.Text);
        //    cmd.Parameters.AddWithValue("@doctor_consultants_visiting", txt_Drsvisiting.Text);
        //    cmd.Parameters.AddWithValue("@account_no", txt_accountno.Text);
        //    cmd.Parameters.AddWithValue("@name_of_holder", txt_nameofholder.Text);
        //    cmd.Parameters.AddWithValue("@designation_holder", "");//Required remove
        //    cmd.Parameters.AddWithValue("@bank_name", txt_bankname.Text);
        //    cmd.Parameters.AddWithValue("@branch", txt_branch.Text);
        //    cmd.Parameters.AddWithValue("@ifsc_code", txt_ifsccode.Text);
            
        //    if (FileUploadCancelCheque.PostedFile != null)
        //    {
        //        if (FileUploadCancelCheque.HasFile == false)
        //        {
        //            lblUpload19.Text = lblUpload19.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadCancelCheque.FileName);
        //            Int32 fileSize = FileUploadCancelCheque.PostedFile.ContentLength;
        //            if (fileExt==".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadCancelCheque.PostedFile.FileName);
        //                FileUploadCancelCheque.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload19.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload19.ForeColor = System.Drawing.Color.Red;
        //                lblUpload19.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@cancelled_cheque", lblUpload19.Text);

        //    //if (FileUploadBankLetter.PostedFile != null)
        //    //{
        //    //    if (FileUploadBankLetter.HasFile == false)
        //    //    {
        //    //        lblUpload20.Text = lblUpload20.Text;
        //    //    }
        //    //    else
        //    //    {
        //    //        string fileName = Path.GetFileName(FileUploadBankLetter.PostedFile.FileName);
        //    //        FileUploadBankLetter.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //    //        string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //    //        lblUpload20.Text = filepath.ToString();
        //    //    }
        //    //}
        //    cmd.Parameters.AddWithValue("@bank_letter", ""); //Required remove


        //    if (FileUploadLPBranch.PostedFile != null)
        //    {
        //        if (FileUploadLPBranch.HasFile == false)
        //        {
        //            lblUpload1.Text = lblUpload1.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadLPBranch.FileName);
        //            Int32 fileSize = FileUploadLPBranch.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadLPBranch.PostedFile.FileName);
        //                FileUploadLPBranch.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload1.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload1.ForeColor = System.Drawing.Color.Red;
        //                lblUpload1.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@list_of_provider_branch", lblUpload1.Text);


        //    if (FileUploadRCertificate.PostedFile != null)
        //    {
        //        if (FileUploadRCertificate.HasFile == false)
        //        {
        //            lblUpload2.Text = lblUpload2.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadRCertificate.FileName);
        //            Int32 fileSize = FileUploadRCertificate.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadRCertificate.PostedFile.FileName);
        //                FileUploadRCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload2.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload2.ForeColor = System.Drawing.Color.Red;
        //                lblUpload2.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@registration_certificate", lblUpload2.Text);


        //    if (FileUploadBIOcertificate.PostedFile != null)
        //    {
        //        if (FileUploadBIOcertificate.HasFile == false)
        //        {
        //            lblUpload3.Text = lblUpload3.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadBIOcertificate.FileName);
        //            Int32 fileSize = FileUploadBIOcertificate.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadBIOcertificate.PostedFile.FileName);
        //                FileUploadBIOcertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload3.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload3.ForeColor = System.Drawing.Color.Red;
        //                lblUpload3.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", lblUpload3.Text);


        //    if (FileUploadBPermit.PostedFile != null)
        //    {
        //        if (FileUploadBPermit.HasFile == false)
        //        {
        //            lblUpload4.Text = lblUpload4.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadBPermit.FileName);
        //            Int32 fileSize = FileUploadBPermit.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadBPermit.PostedFile.FileName);
        //                FileUploadBPermit.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload4.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload4.ForeColor = System.Drawing.Color.Red;
        //                lblUpload4.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@building_permit", lblUpload4.Text);


        //    if (FileUploadFSLicense.PostedFile != null)
        //    {
        //        if (FileUploadFSLicense.HasFile == false)
        //        {
        //            lblUpload5.Text = lblUpload5.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadFSLicense.FileName);
        //            Int32 fileSize = FileUploadFSLicense.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadFSLicense.PostedFile.FileName);
        //                FileUploadFSLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload5.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload5.ForeColor = System.Drawing.Color.Red;
        //                lblUpload5.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@fire_safety_license", lblUpload5.Text);


        //    if (FileUploadPNDTLicense.PostedFile != null)
        //    {
        //        if (FileUploadPNDTLicense.HasFile == false)
        //        {
        //            lblUpload6.Text = lblUpload6.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadPNDTLicense.FileName);
        //            Int32 fileSize = FileUploadPNDTLicense.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadPNDTLicense.PostedFile.FileName);
        //                FileUploadPNDTLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload6.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload6.ForeColor = System.Drawing.Color.Red;
        //                lblUpload6.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@pndt_license", lblUpload6.Text);


        //    if (FileUploadRPCertification.PostedFile != null)
        //    {
        //        if (FileUploadRPCertification.HasFile == false)
        //        {
        //            lblUpload7.Text = lblUpload7.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadRPCertification.FileName);
        //            Int32 fileSize = FileUploadRPCertification.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadRPCertification.PostedFile.FileName);
        //                FileUploadRPCertification.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload7.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload7.ForeColor = System.Drawing.Color.Red;
        //                lblUpload7.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@radiation_protection_certificate", lblUpload7.Text);


        //    if (FileUploadNOFPControl.PostedFile != null)
        //    {
        //        if (FileUploadNOFPControl.HasFile == false)
        //        {
        //            lblUpload8.Text = lblUpload8.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadNOFPControl.FileName);
        //            Int32 fileSize = FileUploadNOFPControl.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadNOFPControl.PostedFile.FileName);
        //                FileUploadNOFPControl.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload8.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload8.ForeColor = System.Drawing.Color.Red;
        //                lblUpload8.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@no_objection_polution_ctrl", lblUpload8.Text);


        //    if (FileUploadNNIJOther.PostedFile != null)
        //    {
        //        if (FileUploadNNIJOther.HasFile == false)
        //        {
        //            lblUpload9.Text = lblUpload9.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadNNIJOther.FileName);
        //            Int32 fileSize = FileUploadNNIJOther.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadNNIJOther.PostedFile.FileName);
        //                FileUploadNNIJOther.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload9.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload9.ForeColor = System.Drawing.Color.Red;
        //                lblUpload9.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", lblUpload9.Text);


        //    if (FileUploadCCBSPassbook.PostedFile != null)
        //    {
        //        if (FileUploadCCBSPassbook.HasFile == false)
        //        {
        //            lblUpload10.Text = lblUpload10.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadCCBSPassbook.FileName);
        //            Int32 fileSize = FileUploadCCBSPassbook.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadCCBSPassbook.PostedFile.FileName);
        //                FileUploadCCBSPassbook.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload10.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload10.ForeColor = System.Drawing.Color.Red;
        //                lblUpload10.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@cc_bs_passbook", lblUpload10.Text);


        //    if (FileUploadPCard.PostedFile != null)
        //    {
        //        if (FileUploadPCard.HasFile == false)
        //        {
        //            lblUpload11.Text = lblUpload11.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadPCard.FileName);
        //            Int32 fileSize = FileUploadPCard.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadPCard.PostedFile.FileName);
        //                FileUploadPCard.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload11.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload11.ForeColor = System.Drawing.Color.Red;
        //                lblUpload11.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@pan_card", lblUpload11.Text);


        //    if (FileUploadNDPAForm.PostedFile != null)
        //    {
        //        if (FileUploadNDPAForm.HasFile == false)
        //        {
        //            lblUpload12.Text = lblUpload12.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadNDPAForm.FileName);
        //            Int32 fileSize = FileUploadNDPAForm.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadNDPAForm.PostedFile.FileName);
        //                FileUploadNDPAForm.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload12.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload12.ForeColor = System.Drawing.Color.Red;
        //                lblUpload12.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@neft_declaration_form", lblUpload12.Text);


        //    if (FileUploadGSTCertificate.PostedFile != null)
        //    {
        //        if (FileUploadGSTCertificate.HasFile == false)
        //        {
        //            lblUpload13.Text = lblUpload13.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadGSTCertificate.FileName);
        //            Int32 fileSize = FileUploadGSTCertificate.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadGSTCertificate.PostedFile.FileName);
        //                FileUploadGSTCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload13.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload13.ForeColor = System.Drawing.Color.Red;
        //                lblUpload13.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@gst_certificate", lblUpload13.Text);


        //    if (FileUploadHOPDTariff.PostedFile != null)
        //    {
        //        if (FileUploadHOPDTariff.HasFile == false)
        //        {
        //            lblUpload14.Text = lblUpload14.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadHOPDTariff.FileName);
        //            Int32 fileSize = FileUploadHOPDTariff.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadHOPDTariff.PostedFile.FileName);
        //                FileUploadHOPDTariff.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload14.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload14.ForeColor = System.Drawing.Color.Red;
        //                lblUpload14.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@hospital_opd_tariff", lblUpload14.Text);


        //    if (FileUploadListTICRegistered.PostedFile != null)
        //    {
        //        if (FileUploadListTICRegistered.HasFile == false)
        //        {
        //            lblUpload15.Text = lblUpload15.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadListTICRegistered.FileName);
        //            Int32 fileSize = FileUploadListTICRegistered.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadListTICRegistered.PostedFile.FileName);
        //                FileUploadListTICRegistered.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload15.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload15.ForeColor = System.Drawing.Color.Red;
        //                lblUpload15.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@list_of_tpa", lblUpload15.Text);


        //    if (FileUploadListConsultants.PostedFile != null)
        //    {
        //        if (FileUploadListConsultants.HasFile == false)
        //        {
        //            lblUpload16.Text = lblUpload16.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadListConsultants.FileName);
        //            Int32 fileSize = FileUploadListConsultants.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadListConsultants.PostedFile.FileName);
        //                FileUploadListConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload16.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload16.ForeColor = System.Drawing.Color.Red;
        //                lblUpload16.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@list_of_consultant", lblUpload16.Text);


        //    if (FileUploadOPDSConsultants.PostedFile != null)
        //    {
        //        if (FileUploadOPDSConsultants.HasFile == false)
        //        {
        //            lblUpload17.Text = lblUpload17.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadOPDSConsultants.FileName);
        //            Int32 fileSize = FileUploadOPDSConsultants.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadOPDSConsultants.PostedFile.FileName);
        //                FileUploadOPDSConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload17.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload17.ForeColor = System.Drawing.Color.Red;
        //                lblUpload17.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@opd_schedule_for_consultant", lblUpload17.Text);


        //    if (FileUploadAODocuments.PostedFile != null)
        //    {
        //        if (FileUploadAODocuments.HasFile == false)
        //        {
        //            lblUpload18.Text = lblUpload18.Text;
        //        }
        //        else
        //        {
        //            string fileExt = System.IO.Path.GetExtension(FileUploadAODocuments.FileName);
        //            Int32 fileSize = FileUploadAODocuments.PostedFile.ContentLength;
        //            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //            {
        //                string fileName = Path.GetFileName(FileUploadAODocuments.PostedFile.FileName);
        //                FileUploadAODocuments.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                lblUpload18.Text = filepath.ToString();
        //            }
        //            else
        //            {
        //                lblUpload18.ForeColor = System.Drawing.Color.Red;
        //                lblUpload18.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                return;
        //            }
        //        }
        //    }
        //    cmd.Parameters.AddWithValue("@any_other_document", lblUpload18.Text);

        //    cmd.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").ToString());
        //    cmd.Parameters.AddWithValue("@created_by", Session["username"].ToString());

        //    FetchDC_ID();
        //    string dcid = HttpUtility.UrlEncode(encrypttext(lbl_dc_id.Text.Trim()));
        //    lblURL.Text = "http://uat.welleazy.com/diagnostic_center/UpdateProviderDetails.aspx?text=" + dcid + "";

        //    OTP_Generate();

        //    cmd.Parameters.AddWithValue("@provider_url", lblURL.Text);
        //    cmd.Parameters.AddWithValue("@otp", li.Text);
        //    cmd.Parameters.AddWithValue("@no_of_attempt", "0");
        //    cmd.Parameters.AddWithValue("@deactivation_reason", "NA");
        //    cmd.Parameters.AddWithValue("@deactivation_date", "");
        //    cmd.Parameters.AddWithValue("@deactivation_by", "");
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public void Laboratory()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd2 = new SqlCommand("Provider_Laboratory_Status_CRUD", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Action", "Insert");
            cmd2.Parameters.AddWithValue("@lab_id", Label1.Text);
            cmd2.Parameters.AddWithValue("@dc_id", lbldc_id.Text);
            //cmd2.Parameters.AddWithValue("@hematology", DDL_Lab1.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@biochemistry", DDL_Lab2.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@microbiology", DDL_Lab3.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@pathology", DDL_Lab4.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@serology", DDL_Lab5.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@histopathology", DDL_Lab6.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@endocrinology", DDL_Lab7.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@cytology", DDL_Lab8.SelectedItem.Text);
            //cmd2.Parameters.AddWithValue("@immunology", DDL_Lab9.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@x_ray", DDL_Rad1.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@digital_x_ray", DDL_Rad2.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ultra_sound", DDL_Rad3.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@color_doppler", DDL_Rad4.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@mammogram", DDL_Rad5.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ct_scan", DDL_Rad6.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@mri", DDL_Rad7.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PET_Scan", DDL_Rad8.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@Nuclear_Imaging", DDL_Rad9.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ECG", DDL_Rad10.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PFT", DDL_Rad11.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@TMT", DDL_Rad12.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@Echo_2D", DDL_Rad13.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@fluoroscopy", DDL_Rad14.SelectedItem.Text);

            cmd2.Parameters.AddWithValue("@x_ray1", DDL_SRad1.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@digital_x_ray1", DDL_SRad2.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ultra_sound1", DDL_SRad3.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@color_doppler1", DDL_SRad4.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@mammogram1", DDL_SRad5.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ct_scan1", DDL_SRad6.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@mri1", DDL_SRad7.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PET_Scan1", DDL_SRad8.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@Nuclear_Imaging1", DDL_SRad9.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@ECG1", DDL_SRad10.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PFT1", DDL_SRad11.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@TMT1", DDL_SRad12.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@Echo_2D1", DDL_SRad13.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@fluoroscopy1", DDL_SRad14.SelectedItem.Text);
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
            cmd1.Parameters.AddWithValue("@insurance_desk_title", DDL_Dep1.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@insurance_desk_name", txt_cpn1.Text);
            cmd1.Parameters.AddWithValue("@insurance_desk_designation", txt_des1.Text);
            cmd1.Parameters.AddWithValue("@insurance_desk_email", txt_em1.Text);
            cmd1.Parameters.AddWithValue("@insurance_desk_cellno", txt_cno1.Text);
            cmd1.Parameters.AddWithValue("@business_development_title", DDL_Dep2.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@business_development_name", txt_cpn2.Text);
            cmd1.Parameters.AddWithValue("@business_development_designation", txt_des2.Text);
            cmd1.Parameters.AddWithValue("@business_development_email", txt_em2.Text);
            cmd1.Parameters.AddWithValue("@business_development_cellno", txt_cno2.Text);
            cmd1.Parameters.AddWithValue("@finance_title", DDL_Dep3.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@finance_name", txt_cpn3.Text);
            cmd1.Parameters.AddWithValue("@finance_designation", txt_des3.Text);
            cmd1.Parameters.AddWithValue("@finance_email", txt_em3.Text);
            cmd1.Parameters.AddWithValue("@finance_cellno", txt_cno3.Text);
            cmd1.Parameters.AddWithValue("@clinical_services_title", DDL_Dep4.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@clinical_services_name", txt_cpn4.Text);
            cmd1.Parameters.AddWithValue("@clinical_services_designation", txt_des4.Text);
            cmd1.Parameters.AddWithValue("@clinical_services_email", txt_em4.Text);
            cmd1.Parameters.AddWithValue("@clinical_services_cellno", txt_cno4.Text);
            cmd1.Parameters.AddWithValue("@nursing_services_title", DDL_Dep5.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@nursing_services_name", txt_cpn5.Text);
            cmd1.Parameters.AddWithValue("@nursing_services_designation", txt_des5.Text);
            cmd1.Parameters.AddWithValue("@nursing_services_email", txt_em5.Text);
            cmd1.Parameters.AddWithValue("@nursing_services_cellno", txt_cno5.Text);
            cmd1.Parameters.AddWithValue("@fund_transfer_title", DDL_Dep6.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@fund_transfer_name", txt_cpn6.Text);
            cmd1.Parameters.AddWithValue("@fund_transfer_designation", txt_des6.Text);
            cmd1.Parameters.AddWithValue("@fund_transfer_email", txt_em6.Text);
            cmd1.Parameters.AddWithValue("@fund_transfer_cellno", txt_cno6.Text);
            cmd1.Parameters.AddWithValue("@cashless_opd_title", DDL_Dep7.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@cashless_opd_name", txt_cpn7.Text);
            cmd1.Parameters.AddWithValue("@cashless_opd_designation", txt_des7.Text);
            cmd1.Parameters.AddWithValue("@cashless_opd_email", txt_em7.Text);
            cmd1.Parameters.AddWithValue("@cashless_opd_cellno", txt_cno7.Text);
            cmd1.Parameters.AddWithValue("@organization_title", DDL_Dep8.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@organization_name", txt_cpn8.Text);
            cmd1.Parameters.AddWithValue("@organization_designation", txt_des8.Text);
            cmd1.Parameters.AddWithValue("@organization_email", txt_em8.Text);
            cmd1.Parameters.AddWithValue("@organization_cellno", txt_cno8.Text);
            cmd1.Parameters.AddWithValue("@business_spoc_title", DDL_Dep9.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@business_spoc_name", txt_cpn9.Text);
            cmd1.Parameters.AddWithValue("@business_spoc_designation", txt_des9.Text);
            cmd1.Parameters.AddWithValue("@business_spoc_email", txt_em9.Text);
            cmd1.Parameters.AddWithValue("@business_spoc_cellno", txt_cno9.Text);
            con.Open();
            cmd1.ExecuteNonQuery();
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
            for (int i = 0; i < otpdigit; i++)
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
        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (DDL_Typeofprovider.SelectedItem.Text.Equals("Pharmacy"))
            {
               
                Custom_Recongnizedby.Enabled = false;
                Custom_Accreditation.Enabled = false;
                RequiredField_Totalstaff.Enabled = false;
                RequiredField_Drsfulltime.Enabled = false;
                RequiredField_Drsvisiting.Enabled = false;

                RequiredField_Dep1.Enabled = false;
                RequiredField_cpn1.Enabled = false;
                RequiredField_des1.Enabled = false;
                RequiredField_em1.Enabled = false;
                RequiredField_cno1.Enabled = false;

                //RequiredField_Dep2.Enabled = false;
                //RequiredField_cpn2.Enabled = false;
                //RequiredField_des2.Enabled = false;
                //RequiredField_em2.Enabled = false;
                //RequiredField_cno2.Enabled = false;

                //RequiredField_Dep3.Enabled = false;
                //RequiredField_cpn3.Enabled = false;
                //RequiredField_des3.Enabled = false;
                //RequiredField_em3.Enabled = false;
                //RequiredField_cno3.Enabled = false;

                RequiredField_Dep6.Enabled = false;
                RequiredField_cpn6.Enabled = false;
                RequiredField_des6.Enabled = false;
                RequiredField_em6.Enabled = false;
                RequiredField_cno6.Enabled = false;

                RequiredField_Dep7.Enabled = false;
                RequiredField_cpn7.Enabled = false;
                RequiredField_des7.Enabled = false;
                RequiredField_em7.Enabled = false;
                RequiredField_cno7.Enabled = false;

                RequiredField_Servicetype.Enabled = false;
                RequiredField_Ambulance.Enabled = false;
                RequiredField_Health.Enabled = false;
                Custom_Specialties.Enabled = false;

                //RequiredField_Lab1.Enabled = false;
                //RequiredField_Lab2.Enabled = false;
                //RequiredField_Lab3.Enabled = false;
                //RequiredField_Lab4.Enabled = false;
                //RequiredField_Lab5.Enabled = false;
                //RequiredField_Lab6.Enabled = false;
                //RequiredField_Lab7.Enabled = false;
                //RequiredField_Lab8.Enabled = false;
                //RequiredField_Lab9.Enabled = false;

                //RequiredField_Rad1.Enabled = false;
                //RequiredField_Rad2.Enabled = false;
                //RequiredField_Rad3.Enabled = false;
                //RequiredField_Rad4.Enabled = false;
                //RequiredField_Rad5.Enabled = false;
                //RequiredField_Rad6.Enabled = false;
                //RequiredField_Rad7.Enabled = false;
                //RequiredField_Rad8.Enabled = false;
                //RequiredField_Rad9.Enabled = false;
                //RequiredField_Rad10.Enabled = false;
                //RequiredField_Rad11.Enabled = false;
                //RequiredField_Rad12.Enabled = false;
                //RequiredField_Rad13.Enabled = false;
                //RequiredField_Rad14.Enabled = false;

                //RequiredField_SRad1.Enabled = false;
                //RequiredField_SRad2.Enabled = false;
                //RequiredField_SRad3.Enabled = false;
                //RequiredField_SRad4.Enabled = false;
                //RequiredField_SRad6.Enabled = false;
                //RequiredField_SRad7.Enabled = false;
                //RequiredField_SRad8.Enabled = false;
                //RequiredField_SRad9.Enabled = false;
                //RequiredField_SRad10.Enabled = false;
                //RequiredField_SRad11.Enabled = false;
                //RequiredField_SRad12.Enabled = false;
                //RequiredField_SRad13.Enabled = false;
                //RequiredField_SRad14.Enabled = false;
            }
            else
            {
                RequiredField_Servicearea.Enabled = false;
                RequiredField_Homedelivery.Enabled = false;
                RequiredField_Deliverytat.Enabled = false;

                RequiredField_Dep9.Enabled = false;
                RequiredField_cpn9.Enabled = false;
                RequiredField_des9.Enabled = false;
                RequiredField_em9.Enabled = false;
                RequiredField_cno9.Enabled = false;                           
            }

            SqlConnection con = new SqlConnection(conStr);
        con.Open(); 
        //SqlCommand cmdcount = new SqlCommand("select count(*) from Tbl_DC_Information where username='" + Session["username"] + "' AND type_of_provider='" + DDL_Typeofprovider.SelectedValue + "' AND center_name='" + txt_Hospitalname.Text + "'", con);
        SqlCommand cmdcount = new SqlCommand("select count(*) from Tbl_DC_Information where username='" + Session["username"] + "' AND type_of_provider='" + DDL_Typeofprovider.SelectedValue + "' AND center_name='" + txt_Hospitalname.Text + "'", con);
            cmdcount.Connection = con;
        int count = Convert.ToInt32(cmdcount.ExecuteScalar());
        if (count > 0)
        {
                showPopup("Warning", "Service Provider ALready Exist!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Service Provider Already Exist!');</script>");
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
                        //ProviderInformation();
                        Service_Provider_Details();
                    }
                    else
                    {
                        lblEmailError.Text = "Invalid Email Id";
                        showPopup("Warning", "Invalid Email Address");
                        return;
                    }
                    
                //DC_ID create
                FetchDC_ID();
                Laboratory();
                Manpower_staffing();
                string ProviderURL = lblURL.Text;
                string EmailId = txt_Emailid.Text;

                SendEmail(ProviderURL, EmailId);
                showPopup("Warning", "Service Provider Add Successfully!");
                    //Mail Code
                //lblInsert.ForeColor = System.Drawing.Color.Green;
                //lblInsert.Text = "Provider Add Successfully...!";

                TypeOfProvider.Visible = false;
                Depart1.Visible = false;
                ProviderBInformation.Visible = false;
                ProviderRecognition.Visible = false;
                ProviderManpower.Visible = false;
                Dep1.Visible = false;
                ProviderServices.Visible = false;
                Specialtiesavail.Visible = false;
                LaboratoryRadiology.Visible = false;
                AccountNumber.Visible = false;
                SaveContinue.Visible = false;
                UploadDocs.Visible = true;
                DocumentUpload.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        con.Close();
        }

        protected void DDL_Typeofprovider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDL_Typeofprovider.SelectedItem.Text=="Pharmacy")
            {
                ServiceArea.Visible = true;
                HomeDelivery.Visible = true;
                Deliverytat.Visible = true;
                Depart1.Visible = true;
                ProviderRecognition.Visible = false;
                ProviderManpower.Visible = false;
                Dep1.Visible = false;
                ProviderServices.Visible = false;
                Specialtiesavail.Visible = false;
                LaboratoryRadiology.Visible = false;
            }
            else if (DDL_Typeofprovider.SelectedItem.Text=="Diagnostic")
            {
                ServiceArea.Visible = false;
                HomeDelivery.Visible = false;
                Deliverytat.Visible = false;
                Depart1.Visible = false;
                ProviderRecognition.Visible = true;
                ProviderManpower.Visible = true;
                Dep1.Visible = true;
                ProviderServices.Visible = true;
                Specialtiesavail.Visible = true;
                LaboratoryRadiology.Visible = true;
            }
            else
            {
                ServiceArea.Visible = false;
                HomeDelivery.Visible = false;
                Deliverytat.Visible = false;
                Depart1.Visible = false;
                ProviderRecognition.Visible = true;
                ProviderManpower.Visible = true;
                Dep1.Visible = true;
                ProviderServices.Visible = true;
                Specialtiesavail.Visible = true;
                LaboratoryRadiology.Visible = true;
            }
        }

        protected void btnUploadnow_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);


            int FileCount = FileUploadDCImage.PostedFiles.Count;

            if (FileCount == 0)
            {
                showPopup("Warning", "Kindly Select Document!");
                return;
            }

            if (FileCount > 10)
            {
                showPopup("Warning", "Document count is more than 10!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Document count is more than 10!');</script>");
                return;
            }


            if (FileUploadDCImage.PostedFile != null)
            {
                if (FileUploadDCImage.HasFile == false)
                {
                    lblDCImage.Text = lblDCImage.Text;
                }
                else
                {
                    for (int i = 0; i < FileCount; i++)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUploadDCImage.PostedFiles[i].FileName);
                        Int32 fileSize = FileUploadDCImage.PostedFiles[i].ContentLength;

                        // int FileCount = FileUploadDCImage.PostedFiles.Count;

                        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize >= 1048576)
                        {

                            string fileName = Path.GetFileName(FileUploadDCImage.PostedFiles[i].FileName);
                            FileUploadDCImage.SaveAs(Server.MapPath("~/diagnostic_center/dc_image/" + fileName));
                            string filepath = "~/diagnostic_center/dc_image/" + fileName;
                            lblDCImage.Text = filepath.ToString();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("DC_Image_CRUD", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "Insert");
                            cmd.Parameters.AddWithValue("@image_id", Label1.Text);
                            cmd.Parameters.AddWithValue("@dc_id", Variables.DcId);
                            cmd.Parameters.AddWithValue("@imagename", lblDCImage.Text);

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }


                    // else
                    //{
                    //  lblDCImage.ForeColor = System.Drawing.Color.Red;
                    //lblDCUpload.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                    //return;
                    // }
                }
            }
            lblDCImage.Visible = false;

            showPopup("Warning", "Document Upload Successfully!");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Document Upload Successfully!');</script>");

            TypeOfProvider.Visible = false;
            Depart1.Visible = false;
            ProviderBInformation.Visible = false;
            ProviderRecognition.Visible = false;
            ProviderManpower.Visible = false;
            Dep1.Visible = false;
            ProviderServices.Visible = false;
            Specialtiesavail.Visible = false;
            LaboratoryRadiology.Visible = false;
            AccountNumber.Visible = false;
            SaveContinue.Visible = false;
            UploadDocs.Visible = true;
            DocumentUpload.Visible = true;
        }

        public void ServiceProviderDocumentUpload()
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";

            if (FileUploadLPBranch.PostedFile != null)
            {
                if (FileUploadLPBranch.HasFile == false)
                {
                    lblUpload1.Text = lblUpload1.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadLPBranch.FileName);
                    Int32 fileSize = FileUploadLPBranch.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadLPBranch.PostedFile.FileName);
                        FileUploadLPBranch.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload1.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload1.ForeColor = System.Drawing.Color.Red;
                        lblUpload1.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadRCertificate.PostedFile != null)
            {
                if (FileUploadRCertificate.HasFile == false)
                {
                    lblUpload2.Text = lblUpload2.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadRCertificate.FileName);
                    Int32 fileSize = FileUploadRCertificate.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadRCertificate.PostedFile.FileName);
                        FileUploadRCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload2.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload2.ForeColor = System.Drawing.Color.Red;
                        lblUpload2.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadBIOcertificate.PostedFile != null)
            {
                if (FileUploadBIOcertificate.HasFile == false)
                {
                    lblUpload3.Text = lblUpload3.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadBIOcertificate.FileName);
                    Int32 fileSize = FileUploadBIOcertificate.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadBIOcertificate.PostedFile.FileName);
                        FileUploadBIOcertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload3.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload3.ForeColor = System.Drawing.Color.Red;
                        lblUpload3.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadBPermit.PostedFile != null)
            {
                if (FileUploadBPermit.HasFile == false)
                {
                    lblUpload4.Text = lblUpload4.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadBPermit.FileName);
                    Int32 fileSize = FileUploadBPermit.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadBPermit.PostedFile.FileName);
                        FileUploadBPermit.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload4.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload4.ForeColor = System.Drawing.Color.Red;
                        lblUpload4.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadFSLicense.PostedFile != null)
            {
                if (FileUploadFSLicense.HasFile == false)
                {
                    lblUpload5.Text = lblUpload5.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadFSLicense.FileName);
                    Int32 fileSize = FileUploadFSLicense.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadFSLicense.PostedFile.FileName);
                        FileUploadFSLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload5.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload5.ForeColor = System.Drawing.Color.Red;
                        lblUpload5.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadPNDTLicense.PostedFile != null)
            {
                if (FileUploadPNDTLicense.HasFile == false)
                {
                    lblUpload6.Text = lblUpload6.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadPNDTLicense.FileName);
                    Int32 fileSize = FileUploadPNDTLicense.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadPNDTLicense.PostedFile.FileName);
                        FileUploadPNDTLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload6.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload6.ForeColor = System.Drawing.Color.Red;
                        lblUpload6.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadRPCertification.PostedFile != null)
            {
                if (FileUploadRPCertification.HasFile == false)
                {
                    lblUpload7.Text = lblUpload7.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadRPCertification.FileName);
                    Int32 fileSize = FileUploadRPCertification.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadRPCertification.PostedFile.FileName);
                        FileUploadRPCertification.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload7.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload7.ForeColor = System.Drawing.Color.Red;
                        lblUpload7.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadNOFPControl.PostedFile != null)
            {
                if (FileUploadNOFPControl.HasFile == false)
                {
                    lblUpload8.Text = lblUpload8.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadNOFPControl.FileName);
                    Int32 fileSize = FileUploadNOFPControl.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadNOFPControl.PostedFile.FileName);
                        FileUploadNOFPControl.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload8.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload8.ForeColor = System.Drawing.Color.Red;
                        lblUpload8.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadNNIJOther.PostedFile != null)
            {
                if (FileUploadNNIJOther.HasFile == false)
                {
                    lblUpload9.Text = lblUpload9.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadNNIJOther.FileName);
                    Int32 fileSize = FileUploadNNIJOther.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadNNIJOther.PostedFile.FileName);
                        FileUploadNNIJOther.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload9.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload9.ForeColor = System.Drawing.Color.Red;
                        lblUpload9.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadCCBSPassbook.PostedFile != null)
            {
                if (FileUploadCCBSPassbook.HasFile == false)
                {
                    lblUpload10.Text = lblUpload10.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadCCBSPassbook.FileName);
                    Int32 fileSize = FileUploadCCBSPassbook.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadCCBSPassbook.PostedFile.FileName);
                        FileUploadCCBSPassbook.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload10.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload10.ForeColor = System.Drawing.Color.Red;
                        lblUpload10.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadPCard.PostedFile != null)
            {
                if (FileUploadPCard.HasFile == false)
                {
                    lblUpload11.Text = lblUpload11.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadPCard.FileName);
                    Int32 fileSize = FileUploadPCard.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadPCard.PostedFile.FileName);
                        FileUploadPCard.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload11.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload11.ForeColor = System.Drawing.Color.Red;
                        lblUpload11.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadNDPAForm.PostedFile != null)
            {
                if (FileUploadNDPAForm.HasFile == false)
                {
                    lblUpload12.Text = lblUpload12.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadNDPAForm.FileName);
                    Int32 fileSize = FileUploadNDPAForm.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadNDPAForm.PostedFile.FileName);
                        FileUploadNDPAForm.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload12.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload12.ForeColor = System.Drawing.Color.Red;
                        lblUpload12.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadGSTCertificate.PostedFile != null)
            {
                if (FileUploadGSTCertificate.HasFile == false)
                {
                    lblUpload13.Text = lblUpload13.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadGSTCertificate.FileName);
                    Int32 fileSize = FileUploadGSTCertificate.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadGSTCertificate.PostedFile.FileName);
                        FileUploadGSTCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload13.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload13.ForeColor = System.Drawing.Color.Red;
                        lblUpload13.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadHOPDTariff.PostedFile != null)
            {
                if (FileUploadHOPDTariff.HasFile == false)
                {
                    lblUpload14.Text = lblUpload14.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadHOPDTariff.FileName);
                    Int32 fileSize = FileUploadHOPDTariff.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadHOPDTariff.PostedFile.FileName);
                        FileUploadHOPDTariff.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload14.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload14.ForeColor = System.Drawing.Color.Red;
                        lblUpload14.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadListTICRegistered.PostedFile != null)
            {
                if (FileUploadListTICRegistered.HasFile == false)
                {
                    lblUpload15.Text = lblUpload15.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadListTICRegistered.FileName);
                    Int32 fileSize = FileUploadListTICRegistered.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadListTICRegistered.PostedFile.FileName);
                        FileUploadListTICRegistered.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload15.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload15.ForeColor = System.Drawing.Color.Red;
                        lblUpload15.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadListConsultants.PostedFile != null)
            {
                if (FileUploadListConsultants.HasFile == false)
                {
                    lblUpload16.Text = lblUpload16.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadListConsultants.FileName);
                    Int32 fileSize = FileUploadListConsultants.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadListConsultants.PostedFile.FileName);
                        FileUploadListConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload16.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload16.ForeColor = System.Drawing.Color.Red;
                        lblUpload16.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadOPDSConsultants.PostedFile != null)
            {
                if (FileUploadOPDSConsultants.HasFile == false)
                {
                    lblUpload17.Text = lblUpload17.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadOPDSConsultants.FileName);
                    Int32 fileSize = FileUploadOPDSConsultants.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadOPDSConsultants.PostedFile.FileName);
                        FileUploadOPDSConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload17.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload17.ForeColor = System.Drawing.Color.Red;
                        lblUpload17.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            if (FileUploadAODocuments.PostedFile != null)
            {
                if (FileUploadAODocuments.HasFile == false)
                {
                    lblUpload18.Text = lblUpload18.Text;
                }
                else
                {
                    string fileExt = System.IO.Path.GetExtension(FileUploadAODocuments.FileName);
                    Int32 fileSize = FileUploadAODocuments.PostedFile.ContentLength;
                    if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
                    {
                        string fileName = Path.GetFileName(FileUploadAODocuments.PostedFile.FileName);
                        FileUploadAODocuments.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
                        string filepath = "~/diagnostic_center/provider_document/" + fileName;
                        lblUpload18.Text = filepath.ToString();
                    }
                    else
                    {
                        lblUpload18.ForeColor = System.Drawing.Color.Red;
                        lblUpload18.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
                        return;
                    }
                }
            }

            BusinessAccessLayer.InsertUpdateServiceProviderDocumentDetails(Convert.ToInt32(lbldc_id.Text.Trim()), lblUpload1.Text.Trim(), lblUpload2.Text.Trim(),
                lblUpload3.Text.Trim(), lblUpload4.Text.Trim(), lblUpload5.Text.Trim(), lblUpload6.Text.Trim(), lblUpload7.Text.Trim(), lblUpload8.Text.Trim(), 
                lblUpload9.Text.Trim(), lblUpload10.Text.Trim(), lblUpload11.Text.Trim(), lblUpload12.Text.Trim(), lblUpload13.Text.Trim(), lblUpload14.Text.Trim(), 
                lblUpload15.Text.Trim(), lblUpload16.Text.Trim(), lblUpload17.Text.Trim(), lblUpload18.Text.Trim(),  
                Convert.ToInt32(Session["LoginRefId"].ToString()), out IsDataExists);

            if (IsDataExists == "1")
            {
                showPopup("Warning", "DC Already Exists");
            }
            else
            {
                showPopup("Warning", "DC Documents Uploaded Successfully");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
            }

        }

        protected void btnUploadnow1_Click(object sender, EventArgs e)
        {
            ServiceProviderDocumentUpload();
            //SqlConnection con = new SqlConnection(conStr);
            //SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Action", "UploadDocument");
            //cmd.Parameters.AddWithValue("@dc_id", lbldc_id.Text);

            //if (FileUploadLPBranch.PostedFile != null)
            //{
            //    if (FileUploadLPBranch.HasFile == false)
            //    {
            //        lblUpload1.Text = lblUpload1.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadLPBranch.FileName);
            //        Int32 fileSize = FileUploadLPBranch.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadLPBranch.PostedFile.FileName);
            //            FileUploadLPBranch.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload1.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload1.ForeColor = System.Drawing.Color.Red;
            //            lblUpload1.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@list_of_provider_branch", lblUpload1.Text);


            //if (FileUploadRCertificate.PostedFile != null)
            //{
            //    if (FileUploadRCertificate.HasFile == false)
            //    {
            //        lblUpload2.Text = lblUpload2.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadRCertificate.FileName);
            //        Int32 fileSize = FileUploadRCertificate.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadRCertificate.PostedFile.FileName);
            //            FileUploadRCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload2.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload2.ForeColor = System.Drawing.Color.Red;
            //            lblUpload2.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@registration_certificate", lblUpload2.Text);


            //if (FileUploadBIOcertificate.PostedFile != null)
            //{
            //    if (FileUploadBIOcertificate.HasFile == false)
            //    {
            //        lblUpload3.Text = lblUpload3.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadBIOcertificate.FileName);
            //        Int32 fileSize = FileUploadBIOcertificate.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadBIOcertificate.PostedFile.FileName);
            //            FileUploadBIOcertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload3.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload3.ForeColor = System.Drawing.Color.Red;
            //            lblUpload3.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", lblUpload3.Text);


            //if (FileUploadBPermit.PostedFile != null)
            //{
            //    if (FileUploadBPermit.HasFile == false)
            //    {
            //        lblUpload4.Text = lblUpload4.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadBPermit.FileName);
            //        Int32 fileSize = FileUploadBPermit.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadBPermit.PostedFile.FileName);
            //            FileUploadBPermit.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload4.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload4.ForeColor = System.Drawing.Color.Red;
            //            lblUpload4.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@building_permit", lblUpload4.Text);


            //if (FileUploadFSLicense.PostedFile != null)
            //{
            //    if (FileUploadFSLicense.HasFile == false)
            //    {
            //        lblUpload5.Text = lblUpload5.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadFSLicense.FileName);
            //        Int32 fileSize = FileUploadFSLicense.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadFSLicense.PostedFile.FileName);
            //            FileUploadFSLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload5.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload5.ForeColor = System.Drawing.Color.Red;
            //            lblUpload5.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@fire_safety_license", lblUpload5.Text);


            //if (FileUploadPNDTLicense.PostedFile != null)
            //{
            //    if (FileUploadPNDTLicense.HasFile == false)
            //    {
            //        lblUpload6.Text = lblUpload6.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadPNDTLicense.FileName);
            //        Int32 fileSize = FileUploadPNDTLicense.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadPNDTLicense.PostedFile.FileName);
            //            FileUploadPNDTLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload6.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload6.ForeColor = System.Drawing.Color.Red;
            //            lblUpload6.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@pndt_license", lblUpload6.Text);


            //if (FileUploadRPCertification.PostedFile != null)
            //{
            //    if (FileUploadRPCertification.HasFile == false)
            //    {
            //        lblUpload7.Text = lblUpload7.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadRPCertification.FileName);
            //        Int32 fileSize = FileUploadRPCertification.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadRPCertification.PostedFile.FileName);
            //            FileUploadRPCertification.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload7.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload7.ForeColor = System.Drawing.Color.Red;
            //            lblUpload7.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@radiation_protection_certificate", lblUpload7.Text);


            //if (FileUploadNOFPControl.PostedFile != null)
            //{
            //    if (FileUploadNOFPControl.HasFile == false)
            //    {
            //        lblUpload8.Text = lblUpload8.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadNOFPControl.FileName);
            //        Int32 fileSize = FileUploadNOFPControl.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadNOFPControl.PostedFile.FileName);
            //            FileUploadNOFPControl.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload8.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload8.ForeColor = System.Drawing.Color.Red;
            //            lblUpload8.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@no_objection_polution_ctrl", lblUpload8.Text);


            //if (FileUploadNNIJOther.PostedFile != null)
            //{
            //    if (FileUploadNNIJOther.HasFile == false)
            //    {
            //        lblUpload9.Text = lblUpload9.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadNNIJOther.FileName);
            //        Int32 fileSize = FileUploadNNIJOther.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadNNIJOther.PostedFile.FileName);
            //            FileUploadNNIJOther.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload9.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload9.ForeColor = System.Drawing.Color.Red;
            //            lblUpload9.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", lblUpload9.Text);


            //if (FileUploadCCBSPassbook.PostedFile != null)
            //{
            //    if (FileUploadCCBSPassbook.HasFile == false)
            //    {
            //        lblUpload10.Text = lblUpload10.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadCCBSPassbook.FileName);
            //        Int32 fileSize = FileUploadCCBSPassbook.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadCCBSPassbook.PostedFile.FileName);
            //            FileUploadCCBSPassbook.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload10.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload10.ForeColor = System.Drawing.Color.Red;
            //            lblUpload10.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@cc_bs_passbook", lblUpload10.Text);


            //if (FileUploadPCard.PostedFile != null)
            //{
            //    if (FileUploadPCard.HasFile == false)
            //    {
            //        lblUpload11.Text = lblUpload11.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadPCard.FileName);
            //        Int32 fileSize = FileUploadPCard.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadPCard.PostedFile.FileName);
            //            FileUploadPCard.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload11.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload11.ForeColor = System.Drawing.Color.Red;
            //            lblUpload11.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@pan_card", lblUpload11.Text);


            //if (FileUploadNDPAForm.PostedFile != null)
            //{
            //    if (FileUploadNDPAForm.HasFile == false)
            //    {
            //        lblUpload12.Text = lblUpload12.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadNDPAForm.FileName);
            //        Int32 fileSize = FileUploadNDPAForm.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadNDPAForm.PostedFile.FileName);
            //            FileUploadNDPAForm.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload12.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload12.ForeColor = System.Drawing.Color.Red;
            //            lblUpload12.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@neft_declaration_form", lblUpload12.Text);


            //if (FileUploadGSTCertificate.PostedFile != null)
            //{
            //    if (FileUploadGSTCertificate.HasFile == false)
            //    {
            //        lblUpload13.Text = lblUpload13.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadGSTCertificate.FileName);
            //        Int32 fileSize = FileUploadGSTCertificate.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadGSTCertificate.PostedFile.FileName);
            //            FileUploadGSTCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload13.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload13.ForeColor = System.Drawing.Color.Red;
            //            lblUpload13.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@gst_certificate", lblUpload13.Text);


            //if (FileUploadHOPDTariff.PostedFile != null)
            //{
            //    if (FileUploadHOPDTariff.HasFile == false)
            //    {
            //        lblUpload14.Text = lblUpload14.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadHOPDTariff.FileName);
            //        Int32 fileSize = FileUploadHOPDTariff.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadHOPDTariff.PostedFile.FileName);
            //            FileUploadHOPDTariff.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload14.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload14.ForeColor = System.Drawing.Color.Red;
            //            lblUpload14.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@hospital_opd_tariff", lblUpload14.Text);


            //if (FileUploadListTICRegistered.PostedFile != null)
            //{
            //    if (FileUploadListTICRegistered.HasFile == false)
            //    {
            //        lblUpload15.Text = lblUpload15.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadListTICRegistered.FileName);
            //        Int32 fileSize = FileUploadListTICRegistered.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadListTICRegistered.PostedFile.FileName);
            //            FileUploadListTICRegistered.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload15.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload15.ForeColor = System.Drawing.Color.Red;
            //            lblUpload15.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@list_of_tpa", lblUpload15.Text);


            //if (FileUploadListConsultants.PostedFile != null)
            //{
            //    if (FileUploadListConsultants.HasFile == false)
            //    {
            //        lblUpload16.Text = lblUpload16.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadListConsultants.FileName);
            //        Int32 fileSize = FileUploadListConsultants.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadListConsultants.PostedFile.FileName);
            //            FileUploadListConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload16.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload16.ForeColor = System.Drawing.Color.Red;
            //            lblUpload16.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@list_of_consultant", lblUpload16.Text);


            //if (FileUploadOPDSConsultants.PostedFile != null)
            //{
            //    if (FileUploadOPDSConsultants.HasFile == false)
            //    {
            //        lblUpload17.Text = lblUpload17.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadOPDSConsultants.FileName);
            //        Int32 fileSize = FileUploadOPDSConsultants.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadOPDSConsultants.PostedFile.FileName);
            //            FileUploadOPDSConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload17.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload17.ForeColor = System.Drawing.Color.Red;
            //            lblUpload17.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@opd_schedule_for_consultant", lblUpload17.Text);


            //if (FileUploadAODocuments.PostedFile != null)
            //{
            //    if (FileUploadAODocuments.HasFile == false)
            //    {
            //        lblUpload18.Text = lblUpload18.Text;
            //    }
            //    else
            //    {
            //        string fileExt = System.IO.Path.GetExtension(FileUploadAODocuments.FileName);
            //        Int32 fileSize = FileUploadAODocuments.PostedFile.ContentLength;
            //        if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
            //        {
            //            string fileName = Path.GetFileName(FileUploadAODocuments.PostedFile.FileName);
            //            FileUploadAODocuments.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
            //            string filepath = "~/diagnostic_center/provider_document/" + fileName;
            //            lblUpload18.Text = filepath.ToString();
            //        }
            //        else
            //        {
            //            lblUpload18.ForeColor = System.Drawing.Color.Red;
            //            lblUpload18.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
            //            return;
            //        }
            //    }
            //}
            //cmd.Parameters.AddWithValue("@any_other_document", lblUpload18.Text);

            //con.Open();
            //cmd.ExecuteNonQuery();

            //showPopup("Warning", "Documents Upload Successfully!");
            
            //Variables.DcId = 0;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
            //lblupload.Text = "Document upload successfully...!";
            //con.Close();
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //if (CheckBox2.Checked == true)
            //{
            //    TypeOfProvider.Visible = false;
            //    ProviderType.Visible = false;
            //    Depart1.Visible = false;
            //    ProviderBInformation.Visible = false;
            //    ProviderRecognition.Visible = false;
            //    ProviderManpower.Visible = false;
            //    Dep1.Visible = false;
            //    ProviderServices.Visible = false;
            //    Specialtiesavail.Visible = false;
            //    LaboratoryRadiology.Visible = false;
            //    AccountNumber.Visible = false;
            //    SaveContinue.Visible = false;
            //    UploadDocs.Visible = true;
            //    DocumentUpload.Visible = true;
            //}
            //else
            //{
            //    TypeOfProvider.Visible = true;
            //    ProviderType.Visible = true;
            //    Depart1.Visible = true;
            //    ProviderBInformation.Visible = true;
            //    ProviderRecognition.Visible = true;
            //    ProviderManpower.Visible = true;
            //    Dep1.Visible = true;
            //    ProviderServices.Visible = true;
            //    Specialtiesavail.Visible = true;
            //    LaboratoryRadiology.Visible = true;
            //    AccountNumber.Visible = true;
            //    SaveContinue.Visible = true;
            //    UploadDocs.Visible = false;
            //    DocumentUpload.Visible = false;
            //}
        }

        protected void DDL_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_City.Items.Clear();
            
            try
            {


                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(DDL_State.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    DDL_City.DataSource = dtCity;
                    DDL_City.DataTextField = "DistrictName";
                    DDL_City.DataValueField = "DistrictId";
                    DDL_City.DataBind();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void SendEmail(string ProviderURL, string EmailId)
        {
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
                            "<b>Dear Service Provider,</b><br /><br />Kindly update your details and complete your profile on WELLEAZY.<br />" +
                            "Token Id: '" + lbl_dcid.Text + "'<br />Visit URL: "+ hl1.NavigateUrl + ".<br /><br /> Regards, Team WELLEAZY.</div>";
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
                showPopup("Warning", "Email sent Successfully..!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email sent Successfully..!');</script>");
            }
            catch (Exception ex)
            {

            }
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void Linkspl1_Click(object sender, EventArgs e)
        {
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
        }

        protected void DDL_Corporategroup_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(DDL_Corporategroup.SelectedValue=="Yes")
            {
                CorporateName.Visible = true;
            }
            else
            {
                CorporateName.Visible = false;
            }
            
        }



        //protected void CB_Recongnizedby_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(CB_Recongnizedby.Checked==true)
        //    {
        //        Recongnized_by_other.Visible = true;
        //    }
        //    else
        //    {
        //        Recongnized_by_other.Visible = false;
        //    }
        //}

        //protected void CB_Accreditation_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(CB_Accreditation.Checked==true)
        //    {
        //        Accreditation_other.Visible = true;
        //    }
        //    else
        //    {
        //        Accreditation_other.Visible = false;
        //    }
        //}

    }
}