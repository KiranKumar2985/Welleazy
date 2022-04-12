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

namespace Welleazy.diagnostic_center
{
    public partial class AddEditDC : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        //string hash = "welnext";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["username"] != null)
                //{
                    //if (Variables.URLLink == 1)
                    //{
                    //    string dcid = HttpUtility.UrlDecode(Request.QueryString["text"]);
                    //    lbl_dc_id.Text = DecryptCode(dcid);
                    //    Variables.DcId = Convert.ToInt32(lbl_dc_id.Text.Trim());
                    //}
                    int Providerid = Variables.DcId;


                string DCId = "";

                if (Request.QueryString.AllKeys.Contains("text"))
                {
                    DCId = HttpUtility.UrlDecode(Request.QueryString["text"]);
                    lbl_dc_id.Text = Decrypttext(DCId);
                    Variables.DcId = Convert.ToInt32(lbl_dc_id.Text.Trim());
                    Session["LoginRefId"] = "0";
                }
                else
                {
                    Variables.DcId = Providerid;

                }
                    //if (Variables.DcId == 0)
                    //{
                    //    string dcid = HttpUtility.UrlDecode(Request.QueryString["text"]);
                    //    lbl_dc_id.Text = Decrypttext(dcid);
                    //    Variables.DcId = Convert.ToInt32(lbl_dc_id.Text.Trim());
                    //}
                    //else
                    //{
                    //    Variables.DcId = Providerid;
                    //}

                    //EditProvider_information();
                    //EditProvider_laboratory();
                    //EditProvider_manpower();


                    StateList();
                    ProviderTypeList();
                    SpecialtyTypeList();
                    OwnershipList();
                    LoadSpecialities();
                    LoadReconized();
                    LoadAccreditation();
                    ServiceTypeList();
                    CorporateList();
                    LoadProviderDetails();

                    if (DDL_Typeofprovider.SelectedItem.Text == "Pharmacy")
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
                        TypeOfProvider.Visible = true;
                        ProviderBInformation.Visible = true;
                        AccountNumber.Visible = true;
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
                        TypeOfProvider.Visible = true;
                        ProviderBInformation.Visible = true;
                        AccountNumber.Visible = true;
                    }
                    
                    SaveContinue.Visible = true;
                    UploadDocs.Visible = false;
                    DocumentUpload.Visible = false;


                //}
                //else
                //{
                //    //Response.Write("<script>alert('Your session has expired!')</script>" + "<script>window.location.href='/Login.aspx';</script>");
                //}
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

        public void LoadProviderDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchProviderDetails = new SqlCommand("Exec proc_FetchProviderDetailsById @DCId", con);
            SqlParameter paramDCId = new SqlParameter("@DCId", Variables.DcId);

            cmdFetchProviderDetails.Parameters.Add(paramDCId);

            SqlDataAdapter daProviderData = new SqlDataAdapter(cmdFetchProviderDetails);
            DataTable dtProviderDetailds = new DataTable();
            daProviderData.Fill(dtProviderDetailds);
            StateList();

            if (dtProviderDetailds != null && dtProviderDetailds.Rows.Count > 0)
            {
                lblsptoken_id.Text = dtProviderDetailds.Rows[0]["sptoken_id"].ToString();
                DDL_Typeofprovider.SelectedValue = dtProviderDetailds.Rows[0]["type_of_provider"].ToString();
                DDL_Typeofspecialty.SelectedValue = dtProviderDetailds.Rows[0]["type_of_specialty"].ToString();
                DDL_Ownership.SelectedValue = dtProviderDetailds.Rows[0]["ownership"].ToString();
                DDL_Corporategroup.SelectedValue = dtProviderDetailds.Rows[0]["corporate_group"].ToString();
                DDL_State_SelectedIndexChanged(null, null);
                if(DDL_Corporategroup.SelectedValue=="Yes")
                {
                    CorporateName.Visible = true;
                }
                else
                {
                    CorporateName.Visible = false;
                }
                //CorporateList();
                DDL_CorporateName.SelectedValue = dtProviderDetailds.Rows[0]["CorporateId"].ToString();
                lblCenterStatus.Text = dtProviderDetailds.Rows[0]["center_status"].ToString();
                txt_Servicearea.Text = dtProviderDetailds.Rows[0]["service_area"].ToString();
                txt_Homedelivery.Text = dtProviderDetailds.Rows[0]["home_delivery"].ToString();
                txt_Deliverytat.Text = dtProviderDetailds.Rows[0]["delivery_tat"].ToString();
                txt_Hospitalname.Text = dtProviderDetailds.Rows[0]["center_name"].ToString();
                txt_Plotno.Text = dtProviderDetailds.Rows[0]["plot_no"].ToString();
                txt_Address.Text = dtProviderDetailds.Rows[0]["address"].ToString();
                txt_Area.Text = dtProviderDetailds.Rows[0]["area"].ToString();
                DDL_State.SelectedValue = dtProviderDetailds.Rows[0]["state"].ToString();
                DDL_State_SelectedIndexChanged(null, null);
                DDL_City.SelectedValue = dtProviderDetailds.Rows[0]["city"].ToString();
                txt_Pincode.Text = dtProviderDetailds.Rows[0]["pincode"].ToString();
                txt_Stdcode.Text = dtProviderDetailds.Rows[0]["stdcode"].ToString();
                txt_Landlineno.Text = dtProviderDetailds.Rows[0]["landline_no"].ToString();
                txt_Mobileno.Text = dtProviderDetailds.Rows[0]["mobile_no"].ToString();
                txt_Fax.Text = dtProviderDetailds.Rows[0]["fax_no"].ToString();
                txt_Emailid.Text = dtProviderDetailds.Rows[0]["emailid"].ToString();
                txt_Website.Text = dtProviderDetailds.Rows[0]["website"].ToString();
                string RecognizedBy = dtProviderDetailds.Rows[0]["reconized_by"].ToString();
                String[] RecognizedValue = RecognizedBy.Split(',');

                int lenght = RecognizedValue.Length;

                foreach (string s in RecognizedValue)
                {
                    foreach (ListItem item in CBL_Recongnizedby.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }

                string Accrediation = dtProviderDetailds.Rows[0]["accreditation"].ToString();
                String[] AccrediationValue = Accrediation.Split(',');
                foreach (string s in AccrediationValue)
                {
                    foreach (ListItem item in CBL_Accreditation.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                DDL_Servicetype.SelectedValue = dtProviderDetailds.Rows[0]["service_type"].ToString();
                DDL_Ambulance.SelectedValue = dtProviderDetailds.Rows[0]["ambulance"].ToString();
                DDL_Ambulanceyes.SelectedValue = dtProviderDetailds.Rows[0]["ambulance_yes"].ToString();
                DDL_Health.SelectedValue = dtProviderDetailds.Rows[0]["health_checkup"].ToString();
                txt_ACLSambulance.Text = dtProviderDetailds.Rows[0]["acls_ambulance"].ToString();
                txt_BLSambulance.Text = dtProviderDetailds.Rows[0]["bls_ambulance"].ToString();
                string strSpecialties = dtProviderDetailds.Rows[0]["specialties_available"].ToString();

                String[] SpecialitiesValue = strSpecialties.Split(',');
                foreach (string s in SpecialitiesValue)
                {
                    foreach (ListItem item in CBL_Specialties.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }

                txt_Totalstaff.Text = dtProviderDetailds.Rows[0]["staff_strength"].ToString();
                txt_Drsfulltime.Text = dtProviderDetailds.Rows[0]["doctor_consultants"].ToString();
                txt_Drsvisiting.Text = dtProviderDetailds.Rows[0]["doctor_consultants_visiting"].ToString();
                txt_accountno.Text = dtProviderDetailds.Rows[0]["account_no"].ToString();
                txt_nameofholder.Text = dtProviderDetailds.Rows[0]["name_of_holder"].ToString();
                //txt_designation.Text = dtProviderDetailds.Rows[0]["designation_holder"].ToString();
                txt_bankname.Text = dtProviderDetailds.Rows[0]["bank_name"].ToString();
                txt_branch.Text = dtProviderDetailds.Rows[0]["branch"].ToString();
                txt_ifsccode.Text = dtProviderDetailds.Rows[0]["ifsc_code"].ToString();

                //var img19 = Server.MapPath("~/diagnostic_center/provider_document/" + dtProviderDetailds.Rows[0]["cancelled_cheque"].ToString());
                //lblUpload19.Text = dtProviderDetailds.Rows[0]["cancelled_cheque"].ToString();
                //txtUpload19.Text= dtProviderDetailds.Rows[0]["cancelled_cheque"].ToString();
                Image19.ImageUrl = dtProviderDetailds.Rows[0]["cancelled_cheque"].ToString();
                lblUpload19.Text = Image19.ImageUrl;
                if (!lblUpload19.Text.Trim().Equals(""))
                {
                    RequiredField_CancelCheque.Enabled = false;
                }


                Image1.ImageUrl = dtProviderDetailds.Rows[0]["list_of_provider_branch"].ToString();
                lblUpload1.Text = Image1.ImageUrl;
                Image2.ImageUrl = dtProviderDetailds.Rows[0]["registration_certificate"].ToString();
                lblUpload2.Text = Image2.ImageUrl;

                if(!lblUpload2.Text.Trim().Equals(""))
                {
                    RequiredField_RegistrationCertificate.Enabled = false;
                }

                Image3.ImageUrl = dtProviderDetailds.Rows[0]["bio_medical_waste_mgmt_certificate"].ToString();
                lblUpload3.Text = Image3.ImageUrl;
                Image4.ImageUrl = dtProviderDetailds.Rows[0]["building_permit"].ToString();
                lblUpload4.Text = Image4.ImageUrl;
                Image5.ImageUrl = dtProviderDetailds.Rows[0]["fire_safety_license"].ToString();
                lblUpload5.Text = Image5.ImageUrl;
                Image6.ImageUrl = dtProviderDetailds.Rows[0]["pndt_license"].ToString();
                lblUpload6.Text = Image6.ImageUrl;
                Image7.ImageUrl = dtProviderDetailds.Rows[0]["radiation_protection_certificate"].ToString();
                lblUpload7.Text = Image7.ImageUrl;
                Image8.ImageUrl = dtProviderDetailds.Rows[0]["no_objection_polution_ctrl"].ToString();
                lblUpload8.Text = Image8.ImageUrl;
                Image9.ImageUrl = dtProviderDetailds.Rows[0]["nabh_nabl_iso_jci_other"].ToString();
                lblUpload9.Text = Image9.ImageUrl;

                if (!lblUpload9.Text.Trim().Equals(""))
                {
                    RequiredField_NNIJOther.Enabled = false;
                }
                Image10.ImageUrl = dtProviderDetailds.Rows[0]["cc_bs_passbook"].ToString();
                lblUpload10.Text = Image10.ImageUrl;

                if (!lblUpload10.Text.Trim().Equals(""))
                {
                    RequiredField_CCBSPassbook.Enabled = false;
                }

                Image11.ImageUrl = dtProviderDetailds.Rows[0]["pan_card"].ToString();
                lblUpload11.Text = Image11.ImageUrl;

                if (!lblUpload11.Text.Trim().Equals(""))
                {
                    RequiredField_PCard.Enabled = false;
                }
                Image12.ImageUrl = dtProviderDetailds.Rows[0]["neft_declaration_form"].ToString();
                lblUpload12.Text = Image12.ImageUrl;
                Image13.ImageUrl = dtProviderDetailds.Rows[0]["gst_certificate"].ToString();
                lblUpload13.Text = Image13.ImageUrl;
                Image14.ImageUrl = dtProviderDetailds.Rows[0]["hospital_opd_tariff"].ToString();
                lblUpload14.Text = Image14.ImageUrl;

                if (!lblUpload14.Text.Trim().Equals(""))
                {
                    RequiredField_HOPDTariff.Enabled = false;
                }
                Image15.ImageUrl = dtProviderDetailds.Rows[0]["list_of_tpa"].ToString();
                lblUpload15.Text = Image15.ImageUrl;

                if (!lblUpload15.Text.Trim().Equals(""))
                {
                    RequiredField_ListTICRegistered.Enabled = false;
                }
                Image16.ImageUrl = dtProviderDetailds.Rows[0]["list_of_consultant"].ToString();
                lblUpload16.Text = Image16.ImageUrl;

                if (!lblUpload16.Text.Trim().Equals(""))
                {
                    RequiredField_ListConsultants.Enabled = false;
                }

                Image17.ImageUrl = dtProviderDetailds.Rows[0]["opd_schedule_for_consultant"].ToString();
                lblUpload17.Text = Image17.ImageUrl;
                Image18.ImageUrl = dtProviderDetailds.Rows[0]["any_other_document"].ToString();
                lblUpload18.Text = Image18.ImageUrl;

                DDL_Dep1.SelectedValue = dtProviderDetailds.Rows[0]["insurance_desk_title"].ToString();
                txt_cpn1.Text = dtProviderDetailds.Rows[0]["insurance_desk_name"].ToString();
                txt_des1.Text = dtProviderDetailds.Rows[0]["insurance_desk_designation"].ToString();
                txt_cno1.Text = dtProviderDetailds.Rows[0]["insurance_desk_cellno"].ToString();
                txt_em1.Text = dtProviderDetailds.Rows[0]["insurance_desk_email"].ToString();

                DDL_Dep2.SelectedValue = dtProviderDetailds.Rows[0]["business_development_title"].ToString();
                txt_cpn2.Text = dtProviderDetailds.Rows[0]["business_development_name"].ToString();
                txt_des2.Text = dtProviderDetailds.Rows[0]["business_development_designation"].ToString();
                txt_em2.Text = dtProviderDetailds.Rows[0]["business_development_email"].ToString();
                txt_cno2.Text = dtProviderDetailds.Rows[0]["business_development_cellno"].ToString();

                DDL_Dep3.SelectedValue = dtProviderDetailds.Rows[0]["finance_title"].ToString();
                txt_cpn3.Text = dtProviderDetailds.Rows[0]["finance_name"].ToString();
                txt_des3.Text = dtProviderDetailds.Rows[0]["finance_designation"].ToString();
                txt_em3.Text = dtProviderDetailds.Rows[0]["finance_email"].ToString();
                txt_cno3.Text = dtProviderDetailds.Rows[0]["finance_cellno"].ToString();

                DDL_Dep4.SelectedValue = dtProviderDetailds.Rows[0]["clinical_services_title"].ToString();
                txt_cpn4.Text = dtProviderDetailds.Rows[0]["clinical_services_name"].ToString();
                txt_des4.Text = dtProviderDetailds.Rows[0]["clinical_services_designation"].ToString();
                txt_em4.Text = dtProviderDetailds.Rows[0]["clinical_services_email"].ToString();
                txt_cno4.Text = dtProviderDetailds.Rows[0]["clinical_services_cellno"].ToString();

                DDL_Dep5.SelectedValue = dtProviderDetailds.Rows[0]["nursing_services_title"].ToString();
                txt_cpn5.Text = dtProviderDetailds.Rows[0]["nursing_services_name"].ToString();
                txt_des5.Text = dtProviderDetailds.Rows[0]["nursing_services_designation"].ToString();
                txt_em5.Text = dtProviderDetailds.Rows[0]["nursing_services_email"].ToString();
                txt_cno5.Text = dtProviderDetailds.Rows[0]["nursing_services_cellno"].ToString();


                DDL_Dep6.SelectedValue = dtProviderDetailds.Rows[0]["fund_transfer_title"].ToString();
                txt_cpn6.Text = dtProviderDetailds.Rows[0]["fund_transfer_name"].ToString();
                txt_des6.Text = dtProviderDetailds.Rows[0]["fund_transfer_designation"].ToString();
                txt_em6.Text = dtProviderDetailds.Rows[0]["fund_transfer_email"].ToString();
                txt_cno6.Text = dtProviderDetailds.Rows[0]["fund_transfer_cellno"].ToString();

                DDL_Dep7.SelectedValue = dtProviderDetailds.Rows[0]["cashless_opd_title"].ToString();
                txt_cpn7.Text = dtProviderDetailds.Rows[0]["cashless_opd_name"].ToString();
                txt_des7.Text = dtProviderDetailds.Rows[0]["cashless_opd_designation"].ToString();
                txt_em7.Text = dtProviderDetailds.Rows[0]["cashless_opd_email"].ToString();
                txt_cno7.Text = dtProviderDetailds.Rows[0]["cashless_opd_cellno"].ToString();


                DDL_Dep8.SelectedValue = dtProviderDetailds.Rows[0]["organization_title"].ToString();
                txt_cpn8.Text = dtProviderDetailds.Rows[0]["organization_name"].ToString();
                txt_des8.Text = dtProviderDetailds.Rows[0]["organization_designation"].ToString();
                txt_em8.Text = dtProviderDetailds.Rows[0]["organization_email"].ToString();
                txt_cno8.Text = dtProviderDetailds.Rows[0]["organization_cellno"].ToString();

                DDL_Dep9.SelectedValue = dtProviderDetailds.Rows[0]["business_spoc_title"].ToString();
                txt_cpn9.Text = dtProviderDetailds.Rows[0]["business_spoc_name"].ToString();
                txt_des9.Text = dtProviderDetailds.Rows[0]["business_spoc_designation"].ToString();
                txt_em9.Text = dtProviderDetailds.Rows[0]["business_spoc_email"].ToString();
                txt_cno9.Text = dtProviderDetailds.Rows[0]["business_spoc_cellno"].ToString();

                //DDL_Lab1.SelectedValue = dtProviderDetailds.Rows[0]["hematology"].ToString();
                //DDL_Lab2.SelectedValue = dtProviderDetailds.Rows[0]["biochemistry"].ToString();
                //DDL_Lab3.SelectedValue = dtProviderDetailds.Rows[0]["microbiology"].ToString();
                //DDL_Lab4.SelectedValue = dtProviderDetailds.Rows[0]["pathology"].ToString();
                //DDL_Lab5.SelectedValue = dtProviderDetailds.Rows[0]["serology"].ToString();
                //DDL_Lab6.SelectedValue = dtProviderDetailds.Rows[0]["histopathology"].ToString();
                //DDL_Lab7.SelectedValue = dtProviderDetailds.Rows[0]["endocrinology"].ToString();
                //DDL_Lab8.SelectedValue = dtProviderDetailds.Rows[0]["cytology"].ToString();
                //DDL_Lab9.SelectedValue = dtProviderDetailds.Rows[0]["immunology"].ToString();

                DDL_Rad1.SelectedValue = dtProviderDetailds.Rows[0]["x_ray"].ToString();
                DDL_Rad2.SelectedValue = dtProviderDetailds.Rows[0]["digital_x_ray"].ToString();
                DDL_Rad3.SelectedValue = dtProviderDetailds.Rows[0]["ultra_sound"].ToString();
                DDL_Rad4.SelectedValue = dtProviderDetailds.Rows[0]["color_doppler"].ToString();
                DDL_Rad5.SelectedValue = dtProviderDetailds.Rows[0]["mammogram"].ToString();
                DDL_Rad6.SelectedValue = dtProviderDetailds.Rows[0]["ct_scan"].ToString();
                DDL_Rad7.SelectedValue = dtProviderDetailds.Rows[0]["mri"].ToString();
                DDL_Rad8.SelectedValue = dtProviderDetailds.Rows[0]["PET_Scan"].ToString();
                DDL_Rad9.SelectedValue = dtProviderDetailds.Rows[0]["Nuclear_Imaging"].ToString();
                DDL_Rad10.SelectedValue = dtProviderDetailds.Rows[0]["ECG"].ToString();
                DDL_Rad11.SelectedValue = dtProviderDetailds.Rows[0]["PFT"].ToString();
                DDL_Rad12.SelectedValue = dtProviderDetailds.Rows[0]["TMT"].ToString();
                DDL_Rad13.SelectedValue = dtProviderDetailds.Rows[0]["Echo_2D"].ToString();
                DDL_Rad14.SelectedValue = dtProviderDetailds.Rows[0]["fluoroscopy"].ToString();

                DDL_SRad1.SelectedValue = dtProviderDetailds.Rows[0]["x_ray1"].ToString();
                DDL_SRad2.SelectedValue = dtProviderDetailds.Rows[0]["digital_x_ray1"].ToString();
                DDL_SRad3.SelectedValue = dtProviderDetailds.Rows[0]["ultra_sound1"].ToString();
                DDL_SRad4.SelectedValue = dtProviderDetailds.Rows[0]["color_doppler1"].ToString();
                DDL_SRad5.SelectedValue = dtProviderDetailds.Rows[0]["mammogram1"].ToString();
                DDL_SRad6.SelectedValue = dtProviderDetailds.Rows[0]["ct_scan1"].ToString();
                DDL_SRad7.SelectedValue = dtProviderDetailds.Rows[0]["mri1"].ToString();
                DDL_SRad8.SelectedValue = dtProviderDetailds.Rows[0]["PET_Scan1"].ToString();
                DDL_SRad9.SelectedValue = dtProviderDetailds.Rows[0]["Nuclear_Imaging1"].ToString();
                DDL_SRad10.SelectedValue = dtProviderDetailds.Rows[0]["ECG1"].ToString();
                DDL_SRad11.SelectedValue = dtProviderDetailds.Rows[0]["PFT1"].ToString();
                DDL_SRad12.SelectedValue = dtProviderDetailds.Rows[0]["TMT1"].ToString();
                DDL_SRad13.SelectedValue = dtProviderDetailds.Rows[0]["Echo_2D1"].ToString();
                DDL_SRad14.SelectedValue = dtProviderDetailds.Rows[0]["fluoroscopy1"].ToString();

               
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


        //public void EditProvider_information()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from Tbl_DC_Information where dc_id='" + lbl_dc_id.Text + "'", con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        DDL_Typeofprovider.SelectedValue = dr["type_of_provider"].ToString();
        //        DDL_Typeofspecialty.SelectedValue = dr["type_of_specialty"].ToString();
        //        DDL_Ownweship.SelectedValue = dr["ownership"].ToString();
        //        DDL_Corporategroup.SelectedValue = dr["corporate_group"].ToString();
        //        DDL_Providersetup.SelectedValue = dr["provider_setup"].ToString();
        //        txt_Serviearea.Text = dr["service_area"].ToString();
        //        txt_Homedelivery.Text = dr["home_delivery"].ToString();
        //        txt_Deliverytat.Text = dr["delivery_tat"].ToString();
        //        txt_Hospitalname.Text = dr["hospital_name"].ToString();
        //        txt_Plotno.Text = dr["plot_no"].ToString();
        //        txt_Address.Text = dr["address"].ToString();
        //        txt_Area.Text = dr["area"].ToString();
        //        DDL_State.SelectedValue = dr["state"].ToString();
        //        DDL_City.SelectedValue = dr["city"].ToString();
        //        txt_Pincode.Text = dr["pincode"].ToString();
        //        txt_Stdcode.Text = dr["stdcode"].ToString();
        //        txt_Landlineno.Text = dr["landline_no"].ToString();
        //        txt_Mobileno.Text = dr["mobile_no"].ToString();
        //        txt_Fax.Text = dr["fax_no"].ToString();
        //        txt_Emailid.Text = dr["emailid"].ToString();
        //        txt_Website.Text = dr["website"].ToString();
        //        CBL_Recongnizedby.Text = dr["reconized_by"].ToString();
        //        Recongnized_by_other.Text = dr["reconized_by_others"].ToString();
        //        CBL_Accreditation.Text = dr["accreditation"].ToString();
        //        Accreditation_other.Text = dr["accreditation_others"].ToString();
        //        DDL_Servicetype.SelectedValue = dr["service_type"].ToString();
        //        DDL_Ambulance.SelectedValue = dr["ambulance"].ToString();
        //        DDL_Ambulanceyes.SelectedValue = dr["ambulance_yes"].ToString();
        //        DDL_Health.SelectedValue = dr["health_checkup"].ToString();
        //        txt_BLSambulance.Text = dr["bls_ambulance"].ToString();
        //        txt_ACLSambulance.Text = dr["acls_ambulance"].ToString();
        //        CBL_Specialties.Text = dr["specialties_available"].ToString();
        //        txt_Totalstaff.Text = dr["staff_strength"].ToString();
        //        txt_Drsfulltime.Text = dr["doctor_consultants"].ToString();
        //        txt_Drsvisiting.Text = dr["doctor_consultants_visiting"].ToString();
        //        txt_accountno.Text = dr["account_no"].ToString();
        //        txt_nameofholder.Text = dr["name_of_holder"].ToString();
        //        txt_designation.Text = dr["designation_holder"].ToString();
        //        txt_bankname.Text = dr["bank_name"].ToString();
        //        txt_branch.Text = dr["branch"].ToString();
        //        txt_ifsccode.Text = dr["ifsc_code"].ToString();
        //        Image19.ImageUrl = dr["cancelled_cheque"].ToString();
        //        lblUpload19.Text = Image19.ImageUrl;

        //        Image20.ImageUrl = dr["bank_letter"].ToString();
        //        lblUpload20.Text = Image20.ImageUrl;

        //        Image1.ImageUrl = dr["list_of_provider_branch"].ToString();
        //        lblUpload1.Text = Image1.ImageUrl;

        //        Image2.ImageUrl = dr["registration_certificate"].ToString();
        //        lblUpload2.Text = Image2.ImageUrl;

        //        Image3.ImageUrl = dr["bio_medical_waste_mgmt_certificate"].ToString();
        //        lblUpload3.Text = Image3.ImageUrl;

        //        Image4.ImageUrl = dr["building_permit"].ToString();
        //        lblUpload4.Text = Image4.ImageUrl;

        //        Image5.ImageUrl = dr["fire_safety_license"].ToString();
        //        lblUpload5.Text = Image5.ImageUrl;

        //        Image6.ImageUrl = dr["pndt_license"].ToString();
        //        lblUpload6.Text = Image6.ImageUrl;

        //        Image7.ImageUrl = dr["radiation_protection_certificate"].ToString();
        //        lblUpload7.Text = Image7.ImageUrl;

        //        Image8.ImageUrl = dr["no_objection_polution_ctrl"].ToString();
        //        lblUpload8.Text = Image8.ImageUrl;

        //        Image9.ImageUrl = dr["nabh_nabl_iso_jci_other"].ToString();
        //        lblUpload9.Text = Image9.ImageUrl;

        //        Image10.ImageUrl = dr["cc_bs_passbook"].ToString();
        //        lblUpload10.Text = Image10.ImageUrl;

        //        Image11.ImageUrl = dr["pan_card"].ToString();
        //        lblUpload11.Text = Image11.ImageUrl;

        //        Image12.ImageUrl = dr["neft_declaration_form"].ToString();
        //        lblUpload12.Text = Image12.ImageUrl;

        //        Image13.ImageUrl = dr["gst_certificate"].ToString();
        //        lblUpload13.Text = Image13.ImageUrl;

        //        Image14.ImageUrl = dr["hospital_opd_tariff"].ToString();
        //        lblUpload14.Text = Image14.ImageUrl;

        //        Image15.ImageUrl = dr["list_of_tpa"].ToString();
        //        lblUpload15.Text = Image15.ImageUrl;

        //        Image16.ImageUrl = dr["list_of_consultant"].ToString();
        //        lblUpload16.Text = Image16.ImageUrl;

        //        Image17.ImageUrl = dr["opd_schedule_for_consultant"].ToString();
        //        lblUpload17.Text = Image17.ImageUrl;

        //        Image18.ImageUrl = dr["any_other_document"].ToString();
        //        lblUpload18.Text = Image18.ImageUrl;

        //    }
        //    con.Close();
        //}
        //public void EditProvider_laboratory()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from tbl_provider_laboratory_status where dc_id='" + lbl_dc_id.Text + "'", con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        DDL_Lab1.SelectedValue = dr["hematology"].ToString();
        //        DDL_Lab2.SelectedValue = dr["biochemistry"].ToString();
        //        DDL_Lab3.SelectedValue = dr["microbiology"].ToString();
        //        DDL_Lab4.SelectedValue = dr["pathology"].ToString();
        //        DDL_Lab5.SelectedValue = dr["serology"].ToString();
        //        DDL_Lab6.SelectedValue = dr["histopathology"].ToString();
        //        DDL_Lab7.SelectedValue = dr["endocrinology"].ToString();
        //        DDL_Lab8.SelectedValue = dr["cytology"].ToString();
        //        DDL_Lab9.SelectedValue = dr["immunology"].ToString();
        //        DDL_Rad1.SelectedValue = dr["x_ray"].ToString();
        //        DDL_Rad2.SelectedValue = dr["digital_x_ray"].ToString();
        //        DDL_Rad3.SelectedValue = dr["ultra_sound"].ToString();
        //        DDL_Rad4.SelectedValue = dr["color_doppler"].ToString();
        //        DDL_Rad5.SelectedValue = dr["mammogram"].ToString();
        //        DDL_Rad6.SelectedValue = dr["ct_scan"].ToString();
        //        DDL_Rad7.SelectedValue = dr["mri"].ToString();
        //        DDL_Rad8.SelectedValue = dr["PET_Scan"].ToString();
        //        DDL_Rad9.SelectedValue = dr["Nuclear_Imaging"].ToString();
        //        DDL_Rad10.SelectedValue = dr["ECG"].ToString();
        //        DDL_Rad11.SelectedValue = dr["PFT"].ToString();
        //        DDL_Rad12.SelectedValue = dr["TMT"].ToString();
        //        txt_2decho.Text = dr["Echo_2D"].ToString();
        //        txt_Fluoroscopy.Text = dr["fluoroscopy"].ToString();

        //    }
        //    con.Close();
        //}
        //public void EditProvider_manpower()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from tbl_provider_manpower_staffing where dc_id='" + lbl_dc_id.Text + "'", con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        DDL_Dep1.SelectedValue = dr["insurance_desk_title"].ToString();
        //        txt_cpn1.Text = dr["insurance_desk_name"].ToString();
        //        txt_des1.Text = dr["insurance_desk_designation"].ToString();
        //        txt_em1.Text = dr["insurance_desk_email"].ToString();
        //        txt_cno1.Text = dr["insurance_desk_cellno"].ToString();
        //        DDL_Dep2.SelectedValue = dr["business_development_title"].ToString();
        //        txt_cpn2.Text = dr["business_development_name"].ToString();
        //        txt_des2.Text = dr["business_development_designation"].ToString();
        //        txt_em2.Text = dr["business_development_email"].ToString();
        //        txt_cno2.Text = dr["business_development_cellno"].ToString();
        //        DDL_Dep3.SelectedValue = dr["finance_title"].ToString();
        //        txt_cpn3.Text = dr["finance_name"].ToString();
        //        txt_des3.Text = dr["finance_designation"].ToString();
        //        txt_em3.Text = dr["finance_email"].ToString();
        //        txt_cno3.Text = dr["finance_cellno"].ToString();
        //        DDL_Dep4.SelectedValue = dr["clinical_services_title"].ToString();
        //        txt_cpn4.Text = dr["clinical_services_name"].ToString();
        //        txt_des4.Text = dr["clinical_services_designation"].ToString();
        //        txt_em4.Text = dr["clinical_services_email"].ToString();
        //        txt_cno4.Text = dr["clinical_services_cellno"].ToString();
        //        DDL_Dep5.SelectedValue = dr["nursing_services_title"].ToString();
        //        txt_cpn5.Text = dr["nursing_services_name"].ToString();
        //        txt_des5.Text = dr["nursing_services_designation"].ToString();
        //        txt_em5.Text = dr["nursing_services_email"].ToString();
        //        txt_cno5.Text = dr["nursing_services_cellno"].ToString();
        //        DDL_Dep6.SelectedValue = dr["fund_transfer_title"].ToString();
        //        txt_cpn6.Text = dr["fund_transfer_name"].ToString();
        //        txt_des6.Text = dr["fund_transfer_designation"].ToString();
        //        txt_em6.Text = dr["fund_transfer_email"].ToString();
        //        txt_cno6.Text = dr["fund_transfer_cellno"].ToString();
        //        DDL_Dep7.SelectedValue = dr["cashless_opd_title"].ToString();
        //        txt_cpn7.Text = dr["cashless_opd_name"].ToString();
        //        txt_des7.Text = dr["cashless_opd_designation"].ToString();
        //        txt_em7.Text = dr["cashless_opd_email"].ToString();
        //        txt_cno7.Text = dr["cashless_opd_cellno"].ToString();
        //        DDL_Dep8.SelectedValue = dr["organization_title"].ToString();
        //        txt_cpn8.Text = dr["organization_name"].ToString();
        //        txt_des8.Text = dr["organization_designation"].ToString();
        //        txt_em8.Text = dr["organization_email"].ToString();
        //        txt_cno8.Text = dr["organization_cellno"].ToString();
        //        DDL_Dep9.SelectedValue = dr["business_spoc_title"].ToString();
        //        txt_cpn9.Text = dr["business_spoc_name"].ToString();
        //        txt_des9.Text = dr["business_spoc_designation"].ToString();
        //        txt_em9.Text = dr["business_spoc_email"].ToString();
        //        txt_cno9.Text = dr["business_spoc_cellno"].ToString();
        //    }
        //    con.Close();
        //}

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


        protected void DDL_Typeofprovider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Typeofprovider.SelectedItem.Text == "Pharmacy")
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
            else if (DDL_Typeofprovider.SelectedItem.Text == "Diagnostic")
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

            if (FileCount==0)
            {
                showPopup("Warning", "Kindly Select Document!");
                return;
            }

            if(FileCount>10)
            {
                showPopup("Warning", "Document count is more than 10!!");
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
                    for(int i=0;i<FileCount;i++)
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
                            cmd.Parameters.AddWithValue("@Action", "Update");
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
            //lblDCImage.ForeColor = System.Drawing.Color.Green;

            //lblDCUpload.Text = "Document upload successfully...!";
            //con.Close();
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

            BusinessAccessLayer.InsertUpdateServiceProviderDocumentDetails(Variables.DcId, lblUpload1.Text.Trim(), lblUpload2.Text.Trim(),
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
            //if (lblUpload2.Text == "" || lblUpload9.Text == "" || lblUpload10.Text == "" || lblUpload11.Text == "" || lblUpload14.Text == "" || lblUpload15.Text == "" || lblUpload16.Text == "")
            //{
            //    showPopup("Warning", "Mandatory Document Missing!");
            //    return;
            //}
            //else
            //{
                ServiceProviderDocumentUpload();
                showPopup("Warning", "Service Provider Documents Upload Successfully!");

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
                //lblUpdate.Text = "Document update successfully...!";
                
            //}
            
            //SqlConnection con = new SqlConnection(conStr);
            //SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Action", "UploadDocument");
            //cmd.Parameters.AddWithValue("@dc_id", Variables.DcId);

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

            //if(lblUpload2.Text=="" || lblUpload9.Text == "" || lblUpload10.Text == "" || lblUpload11.Text == "" || lblUpload14.Text == "" || lblUpload15.Text == "" || lblUpload16.Text == "")
            //{
            //    showPopup("Warning", "Mandatory Document Missing!");
            //    return;
            //}
            //else
            //{
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    showPopup("Warning", "Service Provider Documents Upload Successfully!");

            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
            //    //lblUpdate.Text = "Document update successfully...!";
            //    con.Close();
            //}

        }

        public void Service_Provider_Details()
        {
            try
            {
                //if (lblUpload19.Text == "")
                //{
                //    showPopup("Warning", "Mandatory Document Missing!");
                //    return;
                //}
                //else
                //{
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

                    
                    BusinessAccessLayer.InsertUpdateServiceProviderDetails(Variables.DcId, lblsptoken_id.Text.Trim(), 0, txt_Emailid.Text.Trim(), 0, "B", "Normal", lblCenterStatus.Text.Trim(),
                        Convert.ToInt32(DDL_Typeofprovider.SelectedValue), Convert.ToInt32(DDL_Typeofspecialty.SelectedValue), Convert.ToInt32(DDL_Ownership.SelectedValue), DDL_Corporategroup.SelectedValue,
                        Convert.ToInt32(DDL_CorporateName.SelectedValue), txt_Servicearea.Text.Trim(), txt_Homedelivery.Text.Trim(), txt_Deliverytat.Text.Trim(), txt_Hospitalname.Text.Trim(),
                        txt_Plotno.Text.Trim(), txt_Address.Text.Trim(), txt_Area.Text.Trim(), Convert.ToInt32(DDL_State.SelectedValue), Convert.ToInt32(DDL_City.SelectedValue),
                        txt_Pincode.Text.Trim(), txt_Stdcode.Text.Trim(), txt_Landlineno.Text.Trim(), txt_Mobileno.Text.Trim(), txt_Fax.Text.Trim(), txt_Emailid.Text.Trim(), txt_Website.Text.Trim(),
                        strRecognized, strAccreditation, Convert.ToInt32(DDL_Servicetype.SelectedValue), DDL_Ambulance.SelectedValue, DDL_Ambulanceyes.SelectedValue, DDL_Health.SelectedValue,
                        Convert.ToInt32(txt_BLSambulance.Text.Trim()), Convert.ToInt32(txt_ACLSambulance.Text.Trim()), strSpecialties, Convert.ToInt32(txt_Totalstaff.Text.Trim()),
                        Convert.ToInt32(txt_Drsfulltime.Text.Trim()), Convert.ToInt32(txt_Drsvisiting.Text.Trim()), txt_accountno.Text.Trim(), txt_nameofholder.Text.Trim(), txt_bankname.Text.Trim(),
                        txt_branch.Text.Trim(), txt_ifsccode.Text.Trim(), lblUpload19.Text.Trim(), lblUpload1.Text.Trim(), lblUpload2.Text.Trim(), lblUpload3.Text.Trim(),
                        lblUpload4.Text.Trim(), lblUpload5.Text.Trim(), lblUpload6.Text.Trim(), lblUpload7.Text.Trim(), lblUpload8.Text.Trim(), lblUpload9.Text.Trim(),
                        lblUpload10.Text.Trim(), lblUpload11.Text.Trim(), lblUpload12.Text.Trim(), lblUpload13.Text.Trim(), lblUpload14.Text.Trim(), lblUpload15.Text.Trim(),
                        lblUpload16.Text.Trim(), lblUpload17.Text.Trim(), lblUpload18.Text.Trim(), Convert.ToInt32(Session["LoginRefId"].ToString()),
                        "", "", 0, "NA", null, 0, out IsDataExists);

                    if (IsDataExists == "1")
                    {
                        showPopup("Warning", "DC Already Exists");
                    }
                    else
                    {
                        //showPopup("Warning", "DC Add Successfully");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Diagnostic_center.aspx');</script>");
                    }
                //}
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            
        }

        //public void ProviderInformation()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(conStr);
        //        SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Action", "Update");
        //        cmd.Parameters.AddWithValue("@dc_id", Variables.DcId);
        //        cmd.Parameters.AddWithValue("@sptoken_id", lblsptoken_id.Text);
        //        cmd.Parameters.AddWithValue("@parent_dcid", Label1.Text);
        //        cmd.Parameters.AddWithValue("@ic_id", Label1.Text);
        //        cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
        //        cmd.Parameters.AddWithValue("@center_categorization", "Normal");
        //        cmd.Parameters.AddWithValue("@center_status", "Approved");
        //        cmd.Parameters.AddWithValue("@type_of_provider", DDL_Typeofprovider.SelectedValue);
        //        cmd.Parameters.AddWithValue("@type_of_specialty", DDL_Typeofspecialty.SelectedValue);
        //        cmd.Parameters.AddWithValue("@ownership", DDL_Ownership.SelectedValue);
        //        cmd.Parameters.AddWithValue("@corporate_group", DDL_Corporategroup.SelectedItem.Text);
        //        cmd.Parameters.AddWithValue("@service_area", txt_Servicearea.Text);
        //        cmd.Parameters.AddWithValue("@home_delivery", txt_Homedelivery.Text);
        //        cmd.Parameters.AddWithValue("@delivery_tat", txt_Deliverytat.Text);
        //        cmd.Parameters.AddWithValue("@center_name", txt_Hospitalname.Text);
        //        cmd.Parameters.AddWithValue("@plot_no", txt_Plotno.Text);
        //        cmd.Parameters.AddWithValue("@address", txt_Address.Text);
        //        cmd.Parameters.AddWithValue("@area", txt_Area.Text);
        //        cmd.Parameters.AddWithValue("@state", DDL_State.SelectedValue);
        //        cmd.Parameters.AddWithValue("@city", DDL_City.SelectedValue);
        //        cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text);
        //        cmd.Parameters.AddWithValue("@stdcode", txt_Stdcode.Text);
        //        cmd.Parameters.AddWithValue("@landline_no", txt_Landlineno.Text);
        //        cmd.Parameters.AddWithValue("@mobile_no", txt_Mobileno.Text);
        //        cmd.Parameters.AddWithValue("@fax_no", txt_Fax.Text);
        //        cmd.Parameters.AddWithValue("@emailid", txt_Emailid.Text);
        //        cmd.Parameters.AddWithValue("@website", txt_Website.Text);
        //        String strRecognized = "";
        //        for (int i = 0; i <= CBL_Recongnizedby.Items.Count - 1; i++)
        //        {
        //            if (CBL_Recongnizedby.Items[i].Selected)
        //            {
        //                if (strRecognized == "")
        //                {
        //                    strRecognized = CBL_Recongnizedby.Items[i].Value;
        //                }
        //                else
        //                {
        //                    strRecognized += "," + CBL_Recongnizedby.Items[i].Value;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@reconized_by", strRecognized);
        //        String strAccreditation = "";
        //        for (int i = 0; i <= CBL_Accreditation.Items.Count - 1; i++)
        //        {
        //            if (CBL_Accreditation.Items[i].Selected)
        //            {
        //                if (strAccreditation == "")
        //                {
        //                    strAccreditation = CBL_Accreditation.Items[i].Value;
        //                }
        //                else
        //                {
        //                    strAccreditation += "," + CBL_Accreditation.Items[i].Value;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@accreditation", strAccreditation);
        //        cmd.Parameters.AddWithValue("@service_type", DDL_Servicetype.SelectedValue);
        //        cmd.Parameters.AddWithValue("@ambulance", DDL_Ambulance.SelectedItem.Text);
        //        cmd.Parameters.AddWithValue("@ambulance_yes", DDL_Ambulanceyes.SelectedItem.Text);
        //        cmd.Parameters.AddWithValue("@health_checkup", DDL_Health.SelectedItem.Text);
        //        cmd.Parameters.AddWithValue("@bls_ambulance", Convert.ToInt32(txt_BLSambulance.Text));
        //        cmd.Parameters.AddWithValue("@acls_ambulance", Convert.ToInt32(txt_ACLSambulance.Text));
        //        String strSpecialties = "";
        //        for (int i = 0; i <= CBL_Specialties.Items.Count - 1; i++)
        //        {
        //            if (CBL_Specialties.Items[i].Selected)
        //            {
        //                if (strSpecialties == "")
        //                {
        //                    strSpecialties = CBL_Specialties.Items[i].Value;
        //                }
        //                else
        //                {
        //                    strSpecialties += "," + CBL_Specialties.Items[i].Value;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@specialties_available", strSpecialties);
        //        cmd.Parameters.AddWithValue("@staff_strength", Convert.ToInt32(txt_Totalstaff.Text));
        //        cmd.Parameters.AddWithValue("@doctor_consultants", Convert.ToInt32(txt_Drsfulltime.Text));
        //        cmd.Parameters.AddWithValue("@doctor_consultants_visiting", Convert.ToInt32(txt_Drsvisiting.Text));
        //        cmd.Parameters.AddWithValue("@account_no", txt_accountno.Text);
        //        cmd.Parameters.AddWithValue("@name_of_holder", txt_nameofholder.Text);  
        //        cmd.Parameters.AddWithValue("@bank_name", txt_bankname.Text);
        //        cmd.Parameters.AddWithValue("@branch", txt_branch.Text);
        //        cmd.Parameters.AddWithValue("@ifsc_code", txt_ifsccode.Text);

        //        if (FileUploadCancelCheque.PostedFile != null)
        //        {
        //            if (FileUploadCancelCheque.HasFile == false)
        //            {
        //                lblUpload19.Text = Image19.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadCancelCheque.FileName);
        //                Int32 fileSize = FileUploadCancelCheque.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadCancelCheque.PostedFile.FileName);
        //                    FileUploadCancelCheque.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload19.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload19.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload19.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@cancelled_cheque", lblUpload19.Text);

        //        //if (FileUploadBankLetter.PostedFile != null)
        //        //{
        //        //    if (FileUploadBankLetter.HasFile == false)
        //        //    {
        //        //        lblUpload20.Text = lblUpload20.Text;
        //        //    }
        //        //    else
        //        //    {
        //        //        string fileName = Path.GetFileName(FileUploadBankLetter.PostedFile.FileName);
        //        //        FileUploadBankLetter.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //        //        string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //        //        lblUpload20.Text = filepath.ToString();
        //        //    }
        //        //}
        //        //cmd.Parameters.AddWithValue("@bank_letter", lblUpload20.Text);
        //        cmd.Parameters.AddWithValue("@bank_letter", "");

        //        if (FileUploadLPBranch.PostedFile != null)
        //        {
        //            if (FileUploadLPBranch.HasFile == false)
        //            {
        //                lblUpload1.Text = Image1.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadLPBranch.FileName);
        //                Int32 fileSize = FileUploadLPBranch.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadLPBranch.PostedFile.FileName);
        //                    FileUploadLPBranch.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload1.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload1.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload1.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@list_of_provider_branch", lblUpload1.Text);


        //        if (FileUploadRCertificate.PostedFile != null)
        //        {
        //            if (FileUploadRCertificate.HasFile == false)
        //            {
        //                lblUpload2.Text = Image2.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadRCertificate.FileName);
        //                Int32 fileSize = FileUploadRCertificate.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadRCertificate.PostedFile.FileName);
        //                    FileUploadRCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload2.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload2.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload2.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@registration_certificate", lblUpload2.Text);


        //        if (FileUploadBIOcertificate.PostedFile != null)
        //        {
        //            if (FileUploadBIOcertificate.HasFile == false)
        //            {
        //                lblUpload3.Text = Image3.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadBIOcertificate.FileName);
        //                Int32 fileSize = FileUploadBIOcertificate.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadBIOcertificate.PostedFile.FileName);
        //                    FileUploadBIOcertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload3.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload3.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload3.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", lblUpload3.Text);


        //        if (FileUploadBPermit.PostedFile != null)
        //        {
        //            if (FileUploadBPermit.HasFile == false)
        //            {
        //                lblUpload4.Text = Image4.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadBPermit.FileName);
        //                Int32 fileSize = FileUploadBPermit.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadBPermit.PostedFile.FileName);
        //                    FileUploadBPermit.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload4.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload4.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload4.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@building_permit", lblUpload4.Text);


        //        if (FileUploadFSLicense.PostedFile != null)
        //        {
        //            if (FileUploadFSLicense.HasFile == false)
        //            {
        //                lblUpload5.Text = Image5.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadFSLicense.FileName);
        //                Int32 fileSize = FileUploadFSLicense.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadFSLicense.PostedFile.FileName);
        //                    FileUploadFSLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload5.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload5.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload5.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@fire_safety_license", lblUpload5.Text);


        //        if (FileUploadPNDTLicense.PostedFile != null)
        //        {
        //            if (FileUploadPNDTLicense.HasFile == false)
        //            {
        //                lblUpload6.Text = Image6.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadPNDTLicense.FileName);
        //                Int32 fileSize = FileUploadPNDTLicense.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadPNDTLicense.PostedFile.FileName);
        //                    FileUploadPNDTLicense.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload6.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload6.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload6.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@pndt_license", lblUpload6.Text);


        //        if (FileUploadRPCertification.PostedFile != null)
        //        {
        //            if (FileUploadRPCertification.HasFile == false)
        //            {
        //                lblUpload7.Text = Image7.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadRPCertification.FileName);
        //                Int32 fileSize = FileUploadRPCertification.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadRPCertification.PostedFile.FileName);
        //                    FileUploadRPCertification.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload7.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload7.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload7.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@radiation_protection_certificate", lblUpload7.Text);


        //        if (FileUploadNOFPControl.PostedFile != null)
        //        {
        //            if (FileUploadNOFPControl.HasFile == false)
        //            {
        //                lblUpload8.Text = Image8.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadNOFPControl.FileName);
        //                Int32 fileSize = FileUploadNOFPControl.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadNOFPControl.PostedFile.FileName);
        //                    FileUploadNOFPControl.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload8.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload8.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload8.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@no_objection_polution_ctrl", lblUpload8.Text);


        //        if (FileUploadNNIJOther.PostedFile != null)
        //        {
        //            if (FileUploadNNIJOther.HasFile == false)
        //            {
        //                lblUpload9.Text = Image9.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadNNIJOther.FileName);
        //                Int32 fileSize = FileUploadNNIJOther.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadNNIJOther.PostedFile.FileName);
        //                    FileUploadNNIJOther.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload9.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload9.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload9.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", lblUpload9.Text);


        //        if (FileUploadCCBSPassbook.PostedFile != null)
        //        {
        //            if (FileUploadCCBSPassbook.HasFile == false)
        //            {
        //                lblUpload10.Text = Image10.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadCCBSPassbook.FileName);
        //                Int32 fileSize = FileUploadCCBSPassbook.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadCCBSPassbook.PostedFile.FileName);
        //                    FileUploadCCBSPassbook.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload10.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload10.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload10.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@cc_bs_passbook", lblUpload10.Text);


        //        if (FileUploadPCard.PostedFile != null)
        //        {
        //            if (FileUploadPCard.HasFile == false)
        //            {
        //                lblUpload11.Text = Image11.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadPCard.FileName);
        //                Int32 fileSize = FileUploadPCard.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadPCard.PostedFile.FileName);
        //                    FileUploadPCard.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload11.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload11.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload11.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@pan_card", lblUpload11.Text);


        //        if (FileUploadNDPAForm.PostedFile != null)
        //        {
        //            if (FileUploadNDPAForm.HasFile == false)
        //            {
        //                lblUpload12.Text = Image12.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadNDPAForm.FileName);
        //                Int32 fileSize = FileUploadNDPAForm.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadNDPAForm.PostedFile.FileName);
        //                    FileUploadNDPAForm.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload12.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload12.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload12.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@neft_declaration_form", lblUpload12.Text);


        //        if (FileUploadGSTCertificate.PostedFile != null)
        //        {
        //            if (FileUploadGSTCertificate.HasFile == false)
        //            {
        //                lblUpload13.Text = Image13.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadGSTCertificate.FileName);
        //                Int32 fileSize = FileUploadGSTCertificate.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadGSTCertificate.PostedFile.FileName);
        //                    FileUploadGSTCertificate.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload13.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload13.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload13.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@gst_certificate", lblUpload13.Text);


        //        if (FileUploadHOPDTariff.PostedFile != null)
        //        {
        //            if (FileUploadHOPDTariff.HasFile == false)
        //            {
        //                lblUpload14.Text = Image14.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadHOPDTariff.FileName);
        //                Int32 fileSize = FileUploadHOPDTariff.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadHOPDTariff.PostedFile.FileName);
        //                    FileUploadHOPDTariff.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload14.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload14.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload14.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@hospital_opd_tariff", lblUpload14.Text);


        //        if (FileUploadListTICRegistered.PostedFile != null)
        //        {
        //            if (FileUploadListTICRegistered.HasFile == false)
        //            {
        //                lblUpload15.Text = Image15.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadListTICRegistered.FileName);
        //                Int32 fileSize = FileUploadListTICRegistered.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadListTICRegistered.PostedFile.FileName);
        //                    FileUploadListTICRegistered.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload15.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload15.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload15.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@list_of_tpa", lblUpload15.Text);


        //        if (FileUploadListConsultants.PostedFile != null)
        //        {
        //            if (FileUploadListConsultants.HasFile == false)
        //            {
        //                lblUpload16.Text = Image16.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadListConsultants.FileName);
        //                Int32 fileSize = FileUploadListConsultants.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadListConsultants.PostedFile.FileName);
        //                    FileUploadListConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload16.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload16.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload16.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@list_of_consultant", lblUpload16.Text);


        //        if (FileUploadOPDSConsultants.PostedFile != null)
        //        {
        //            if (FileUploadOPDSConsultants.HasFile == false)
        //            {
        //                lblUpload17.Text = Image17.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadOPDSConsultants.FileName);
        //                Int32 fileSize = FileUploadOPDSConsultants.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadOPDSConsultants.PostedFile.FileName);
        //                    FileUploadOPDSConsultants.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload17.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload17.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload17.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@opd_schedule_for_consultant", lblUpload17.Text);


        //        if (FileUploadAODocuments.PostedFile != null)
        //        {
        //            if (FileUploadAODocuments.HasFile == false)
        //            {
        //                lblUpload18.Text = Image18.ImageUrl;
        //            }
        //            else
        //            {
        //                string fileExt = System.IO.Path.GetExtension(FileUploadAODocuments.FileName);
        //                Int32 fileSize = FileUploadAODocuments.PostedFile.ContentLength;
        //                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" && fileSize <= 1048576)
        //                {
        //                    string fileName = Path.GetFileName(FileUploadAODocuments.PostedFile.FileName);
        //                    FileUploadAODocuments.SaveAs(Server.MapPath("~/diagnostic_center/provider_document/" + fileName));
        //                    string filepath = "~/diagnostic_center/provider_document/" + fileName;
        //                    lblUpload18.Text = filepath.ToString();
        //                }
        //                else
        //                {
        //                    lblUpload18.ForeColor = System.Drawing.Color.Red;
        //                    lblUpload18.Text = "Only .png |.jpg |.jpeg files allowed with size below 1 MB";
        //                    return;
        //                }
        //            }
        //        }
        //        cmd.Parameters.AddWithValue("@any_other_document", lblUpload18.Text);

        //        //cmd.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").ToString());
        //        //cmd.Parameters.AddWithValue("@created_by", Session["username"].ToString());
        //        // cmd.Parameters.AddWithValue("@provider_url", lblUpload18.Text);
        //        // cmd.Parameters.AddWithValue("@otp", "");
        //        cmd.Parameters.AddWithValue("@no_of_attempt", "0");

        //        if(lblUpload19.Text=="")
        //        {
        //            showPopup("Warning", "Mandatory Document Missing!");
        //            return;
        //        }

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}
        public void Laboratory()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd2 = new SqlCommand("Provider_Laboratory_Status_CRUD", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Action", "Update");
            cmd2.Parameters.AddWithValue("@lab_id", Label1.Text);
            cmd2.Parameters.AddWithValue("@dc_id", Variables.DcId);
            
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
            cmd1.Parameters.AddWithValue("@Action", "Update");
            cmd1.Parameters.AddWithValue("@manpower_id", Label1.Text);
            cmd1.Parameters.AddWithValue("@dc_id", Variables.DcId);
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);

            string emailid = txt_Emailid.Text.Trim();

            con.Open();
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("select substring('" + emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
            var adapter = new SqlDataAdapter(cmd);

            adapter.Fill(result);

            if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in") || result.Rows[0]["Ext"].Equals("net") || result.Rows[0]["Ext"].Equals("edu") || result.Rows[0]["Ext"].Equals("org"))
            {
                lblEmailError.Text = "";
                Service_Provider_Details();
            }
            else
            {
                lblEmailError.Text = "Invalid Email Id";
                showPopup("Warning", "Invalid Email Address");
                return;
            }
                
            //DC_ID create
            //FetchDC_ID();
            Laboratory();
            Manpower_staffing();
            showPopup("Warning", "Service Provider Updated Successfully!");

            lblUpdate.ForeColor = System.Drawing.Color.Green;
            lblUpdate.Text = "Update provider information...!";

            TypeOfProvider.Visible = false;
            Depart1.Visible = false;
            ProviderBInformation.Visible = false;
            ProviderRecognition.Visible = false;
            ProviderManpower.Visible = false;
            Dep1.Visible = false;
            ProviderServices.Visible = false;
            Specialtiesavail.Visible = false;
            LaboratoryRadiology.Visible = false;
            //ListOfDoctor.Visible = false;
            AccountNumber.Visible = false;
            SaveContinue.Visible = false;
            UploadDocs.Visible = true;
            DocumentUpload.Visible = true;

        }

        protected void btnUploadDoc_Click(object sender, EventArgs e)
        {
            TypeOfProvider.Visible = false;
            Depart1.Visible = false;
            ProviderBInformation.Visible = false;
            ProviderRecognition.Visible = false;
            ProviderManpower.Visible = false;
            Dep1.Visible = false;
            ProviderServices.Visible = false;
            Specialtiesavail.Visible = false;
            LaboratoryRadiology.Visible = false;
            //ListOfDoctor.Visible = false;
            AccountNumber.Visible = false;
            SaveContinue.Visible = false;
            UploadDocs.Visible = true;
            DocumentUpload.Visible = true;
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
            if (DDL_Corporategroup.SelectedValue == "Yes")
            {
                CorporateName.Visible = true;
            }
            else
            {
                CorporateName.Visible = false;
            }
        }       

    }
}