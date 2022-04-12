using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.IO;


namespace Welleazy
{
    public class Dal
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=HCL-PC;Initial Catalog=Welleazy;Integrated Security=True");

        public void InsertLogin(Bal ba)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Login values('" + ba.UserName + "','" + ba.Password + "','" + ba.Email + "','" + ba.MobileNo + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateLogin(Bal ba)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Tbl_Login set UserName='" + ba.UserName + "', Password='" + ba.Password + "', Email='" + ba.Email + "', MobileNo='" + ba.MobileNo + "' where Login_ID='" + ba.Login_ID + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public DataTable LoadCaseStatusDetails()
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();

        //    SqlCommand cmdLoadCaseStatusDetails = new SqlCommand("Exec proc_LoadCaseStatusDetails", con);
        //    SqlDataAdapter daLoadCaseStatusDetails = new SqlDataAdapter(cmdLoadCaseStatusDetails);
        //    DataTable dtLoadCaseStatusDetails = new DataTable();
        //    daLoadCaseStatusDetails.Fill(dtLoadCaseStatusDetails);
        //    return dtLoadCaseStatusDetails;
        //}

        public void InsertUpdateServiceProviderDetails(Int32 dc_id, string sptoken_id, Int32 parent_dcid, string username, Int32 center_prioritization, string center_grading, string center_categorization, string center_status, Int32 type_of_provider, Int32 type_of_specialty, Int32 ownership, string corporate_group, Int32 CorporateId, string service_area, string home_delivery, string delivery_tat, string center_name, string plot_no, string address, string area, Int32 state, Int32 city, string pincode, string stdcode, string landline_no, string mobile_no, string fax_no, string emailid, string website, string reconized_by, string accreditation, Int32 service_type, string ambulance, string ambulance_yes, string health_checkup, Int32 bls_ambulance, Int32 acls_ambulance, string specialties_available, Int32 staff_strength, Int32 doctor_consultants, Int32 doctor_consultants_visiting, string account_no, string name_of_holder, string bank_name, string branch, string ifsc_code, string cancelled_cheque, string list_of_provider_branch, string registration_certificate, string bio_medical_waste_mgmt_certificate, string building_permit, string fire_safety_license, string pndt_license, string radiation_protection_certificate, string no_objection_polution_ctrl, string nabh_nabl_iso_jci_other, string cc_bs_passbook, string pan_card, string neft_declaration_form, string gst_certificate, string hospital_opd_tariff, string list_of_tpa, string list_of_consultant, string opd_schedule_for_consultant, string any_other_document, Int32 created_by, string provider_url, string otp, Int32 no_of_attempt, string deactivation_reason, DateTime? deactivation_date, Int32 deactivation_by, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateServiceProvider = new SqlCommand("InsertUpdateServiceProviderDetails", con);
            cmdInsertUpdateServiceProvider.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@dc_id", dc_id);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@sptoken_id", sptoken_id);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@parent_dcid", parent_dcid);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@username", username);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@center_prioritization", center_prioritization);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@center_grading", center_grading);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@center_categorization", center_categorization);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@center_status", center_status);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@type_of_provider", type_of_provider);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@type_of_specialty", type_of_specialty);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@ownership", ownership);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@corporate_group", corporate_group);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@service_area", service_area);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@home_delivery", home_delivery);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@delivery_tat", delivery_tat);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@center_name", center_name);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@plot_no", plot_no);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@address", address);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@area", area);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@state", state);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@city", city);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@pincode", pincode);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@stdcode", stdcode);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@landline_no", landline_no);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@mobile_no", mobile_no);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@fax_no", fax_no);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@emailid", emailid);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@website", website);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@reconized_by", reconized_by);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@accreditation", accreditation);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@service_type", service_type);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@ambulance", ambulance);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@ambulance_yes", ambulance_yes);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@health_checkup", health_checkup);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@bls_ambulance", bls_ambulance);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@acls_ambulance", acls_ambulance);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@specialties_available", specialties_available);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@staff_strength", staff_strength);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@doctor_consultants", doctor_consultants);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@doctor_consultants_visiting", doctor_consultants_visiting);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@account_no", account_no);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@name_of_holder", name_of_holder);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@bank_name", bank_name);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@branch", branch);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@ifsc_code", ifsc_code);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@cancelled_cheque", cancelled_cheque);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_provider_branch", list_of_provider_branch);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@registration_certificate", registration_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", bio_medical_waste_mgmt_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@building_permit", building_permit);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@fire_safety_license", fire_safety_license);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@pndt_license", pndt_license);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@radiation_protection_certificate", radiation_protection_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@no_objection_polution_ctrl", no_objection_polution_ctrl);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", nabh_nabl_iso_jci_other);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@cc_bs_passbook", cc_bs_passbook);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@pan_card", pan_card);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@neft_declaration_form", neft_declaration_form);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@gst_certificate", gst_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@hospital_opd_tariff", hospital_opd_tariff);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_tpa", list_of_tpa);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_consultant", list_of_consultant);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@opd_schedule_for_consultant", opd_schedule_for_consultant);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@any_other_document", any_other_document);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@created_by", created_by);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@provider_url", provider_url);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@otp", otp);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@no_of_attempt", no_of_attempt);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@deactivation_reason", deactivation_reason);
            SqlParameter paramdeactivation_date;

            if (deactivation_date.Equals(null))
            {
                paramdeactivation_date = new SqlParameter("@deactivation_date", DBNull.Value);
            }
            else
            {
                paramdeactivation_date = new SqlParameter("@SchFollowupdate", deactivation_date);
            }

            cmdInsertUpdateServiceProvider.Parameters.Add(paramdeactivation_date);

            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@deactivation_by", deactivation_by);
            // cmdInsertUpdateCase.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            IsDataExists = cmdInsertUpdateServiceProvider.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateServiceProviderDocumentDetails(Int32 dc_id, string list_of_provider_branch, string registration_certificate, string bio_medical_waste_mgmt_certificate, string building_permit, string fire_safety_license, string pndt_license, string radiation_protection_certificate, string no_objection_polution_ctrl, string nabh_nabl_iso_jci_other, string cc_bs_passbook, string pan_card, string neft_declaration_form, string gst_certificate, string hospital_opd_tariff, string list_of_tpa, string list_of_consultant, string opd_schedule_for_consultant, string any_other_document, Int32 updated_by, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateServiceProvider = new SqlCommand("InsertUpdateServiceProviderDocumentDetails", con);
            cmdInsertUpdateServiceProvider.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@dc_id", dc_id);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_provider_branch", list_of_provider_branch);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@registration_certificate", registration_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@bio_medical_waste_mgmt_certificate", bio_medical_waste_mgmt_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@building_permit", building_permit);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@fire_safety_license", fire_safety_license);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@pndt_license", pndt_license);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@radiation_protection_certificate", radiation_protection_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@no_objection_polution_ctrl", no_objection_polution_ctrl);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@nabh_nabl_iso_jci_other", nabh_nabl_iso_jci_other);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@cc_bs_passbook", cc_bs_passbook);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@pan_card", pan_card);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@neft_declaration_form", neft_declaration_form);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@gst_certificate", gst_certificate);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@hospital_opd_tariff", hospital_opd_tariff);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_tpa", list_of_tpa);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@list_of_consultant", list_of_consultant);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@opd_schedule_for_consultant", opd_schedule_for_consultant);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@any_other_document", any_other_document);
            cmdInsertUpdateServiceProvider.Parameters.AddWithValue("@updated_by", updated_by);

            IsDataExists = cmdInsertUpdateServiceProvider.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateDCApprovedByPopup(Int32 dc_id, string center_status)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateStatus = new SqlCommand("InsertUpdateDCApprovedByPopup", con);
            cmdInsertUpdateStatus.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateStatus.Parameters.AddWithValue("@dc_id", dc_id);
            cmdInsertUpdateStatus.Parameters.AddWithValue("@center_status", center_status);
            cmdInsertUpdateStatus.ExecuteNonQuery();
            //IsDataExists = cmdInsertUpdateStatus.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadCaseStatusDetailsById(int StatusId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadCaseStatusDetails = new SqlCommand("Exec proc_LoadCaseStatusDetailsById @StatusId", con);

            SqlParameter paramStatusId = new SqlParameter("@StatusId", StatusId);

            cmdLoadCaseStatusDetails.Parameters.Add(paramStatusId);

            SqlDataAdapter daLoadCaseStatusDetails = new SqlDataAdapter(cmdLoadCaseStatusDetails);
            DataTable dtLoadCaseStatusDetails = new DataTable();
            daLoadCaseStatusDetails.Fill(dtLoadCaseStatusDetails);
            return dtLoadCaseStatusDetails;
        }
        public DataTable LoadBranchDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadBranchDetails = new SqlCommand("Exec proc_LoadBranchDetails", con);

            SqlDataAdapter daLoadBranchDetails = new SqlDataAdapter(cmdLoadBranchDetails);
            DataTable dtLoadBranchDetails = new DataTable();
            daLoadBranchDetails.Fill(dtLoadBranchDetails);
            return dtLoadBranchDetails;
        }
        public DataTable LoadBranchDetailsById(int BranchId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadBranchDetails = new SqlCommand("Exec proc_LoadBranchDetailsById @BranchId", con);

            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);

            cmdLoadBranchDetails.Parameters.Add(paramBranchId);

            SqlDataAdapter daLoadBranchDetails = new SqlDataAdapter(cmdLoadBranchDetails);
            DataTable dtLoadBranchDetails = new DataTable();
            daLoadBranchDetails.Fill(dtLoadBranchDetails);
            return dtLoadBranchDetails;
        }
        public DataTable LoadStateDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadStateDetails", con);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataTable LoadStateDetailsDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadStateDetailsDropDown", con);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            con.Close();
            con.Dispose();
            return dtStateDetails;
        }

        public DataTable LoadStateDetailsById(int StateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadStateDetailsById @StateId", con);

            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);

            cmdLoadStateDetails.Parameters.Add(paramStateId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }


        public DataTable LoadDistrict()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDistrict = new SqlCommand("Exec proc_LoadDistrict", con);



            SqlDataAdapter daLoadDistrict = new SqlDataAdapter(cmdLoadDistrict);
            DataTable dtDistrict = new DataTable();
            daLoadDistrict.Fill(dtDistrict);
            con.Close();
            con.Dispose();
            return dtDistrict;
        }

        public DataTable LoadDistrictById(int DistrictId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDistrict = new SqlCommand("Exec proc_LoadDistrictById @DistrictId", con);

            SqlParameter paramDistrictId = new SqlParameter("@DistrictId", DistrictId);
            cmdLoadDistrict.Parameters.Add(paramDistrictId);


            SqlDataAdapter daLoadDistrict = new SqlDataAdapter(cmdLoadDistrict);
            DataTable dtDistrict = new DataTable();
            daLoadDistrict.Fill(dtDistrict);
            con.Close();
            con.Dispose();
            return dtDistrict;
        }

        public DataTable LoadSpecialities()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSpecialities = new SqlCommand("Exec proc_LoadSpecialities", con);


            SqlDataAdapter daLoadSpecialities = new SqlDataAdapter(cmdLoadSpecialities);
            DataTable dtSpecialities = new DataTable();
            daLoadSpecialities.Fill(dtSpecialities);
            con.Close();
            con.Dispose();
            return dtSpecialities;
        }

        public DataTable LoadSpecialitiesById(int SpecialitiesId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSpecialities = new SqlCommand("Exec proc_LoadSpecialitiesById @SpecialityId", con);

            SqlParameter paramSpecialitiesId = new SqlParameter("@SpecialityId", SpecialitiesId);

            cmdLoadSpecialities.Parameters.Add(paramSpecialitiesId);


            SqlDataAdapter daLoadSpecialities = new SqlDataAdapter(cmdLoadSpecialities);
            DataTable dtSpecialities = new DataTable();
            daLoadSpecialities.Fill(dtSpecialities);
            con.Close();
            con.Dispose();
            return dtSpecialities;
        }

        public DataTable LoadLoginType()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadLoginType = new SqlCommand("Exec proc_LoadLoginType", con);

            SqlDataAdapter daLoginType = new SqlDataAdapter(cmdLoadLoginType);
            DataTable dtLoginType = new DataTable();
            daLoginType.Fill(dtLoginType);
            con.Close();
            con.Dispose();
            return dtLoginType;
        }

        public DataTable LoadDomain()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDomain = new SqlCommand("Exec proc_LoadDomain", con);

            SqlDataAdapter daDomain = new SqlDataAdapter(cmdLoadDomain);
            DataTable dtDomain = new DataTable();
            daDomain.Fill(dtDomain);
            con.Close();
            con.Dispose();
            return dtDomain;


        }


        public DataTable LoadPermissionDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadPermissionDropDown = new SqlCommand("Exec proc_LoadPermissionDropDown", con);

            SqlDataAdapter daLoadPermissionDropDown = new SqlDataAdapter(cmdLoadPermissionDropDown);
            DataTable dtPermissionDetailsDropDown = new DataTable();
            daLoadPermissionDropDown.Fill(dtPermissionDetailsDropDown);
            return dtPermissionDetailsDropDown;
        }

        public DataTable LoadPermission()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadPermission = new SqlCommand("Exec proc_LoadPermission", con);

            SqlDataAdapter daLoadPermission = new SqlDataAdapter(cmdLoadPermission);
            DataTable dtPermissionDetails = new DataTable();
            daLoadPermission.Fill(dtPermissionDetails);
            return dtPermissionDetails;
        }

        public DataTable LoadPermissionById(int PermissionId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadPermission = new SqlCommand("Exec proc_LoadPermissionById @PermissionId", con);

            SqlParameter paramPermissionId = new SqlParameter("@PermissionId", PermissionId);

            cmdLoadPermission.Parameters.Add(paramPermissionId);

            SqlDataAdapter daLoadPermission = new SqlDataAdapter(cmdLoadPermission);
            DataTable dtPermissionDetails = new DataTable();
            daLoadPermission.Fill(dtPermissionDetails);
            return dtPermissionDetails;
        }

        public DataSet LoadPermissionDetailsForLoginCreation()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSubPermission = new SqlCommand("Exec proc_LoadPermissionDetailsForLoginCreation", con);

            SqlDataAdapter daLoadSubPermission = new SqlDataAdapter(cmdLoadSubPermission);
            DataSet dtSubPermissionDetails = new DataSet();
            daLoadSubPermission.Fill(dtSubPermissionDetails);
            con.Close();
            con.Dispose();
            return dtSubPermissionDetails;
        }

        public DataTable LoadSubPermission()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSubPermission = new SqlCommand("Exec proc_LoadSubPermission", con);

            SqlDataAdapter daLoadSubPermission = new SqlDataAdapter(cmdLoadSubPermission);
            DataTable dtSubPermissionDetails = new DataTable();
            daLoadSubPermission.Fill(dtSubPermissionDetails);
            return dtSubPermissionDetails;
        }

        public DataTable LoadSubPermissionById(int SubPermissionId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSubPermission = new SqlCommand("Exec proc_LoadSubPermissionById @SubPermissionId", con);

            SqlParameter paramSubPermissionId = new SqlParameter("@SubPermissionId", SubPermissionId);

            cmdLoadSubPermission.Parameters.Add(paramSubPermissionId);

            SqlDataAdapter daLoadSubPermission = new SqlDataAdapter(cmdLoadSubPermission);
            DataTable dtSubPermissionDetails = new DataTable();
            daLoadSubPermission.Fill(dtSubPermissionDetails);
            return dtSubPermissionDetails;
        }
        public void InsertUpdateCaseStatus(Int32 StatusId, String CaseStatusName, String CaseFor, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCaseStatus = new SqlCommand("Exec proc_InsertUpdateCaseStatus @StatusId,@CaseStatusName,@CaseFor,@IsActive", con);

            SqlParameter paramStatusId = new SqlParameter("@StatusId", StatusId);
            SqlParameter paramCaseStatusName = new SqlParameter("@CaseStatusName", CaseStatusName);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateCaseStatus.Parameters.Add(paramStatusId);
            cmdInsertUpdateCaseStatus.Parameters.Add(paramCaseStatusName);
            cmdInsertUpdateCaseStatus.Parameters.Add(paramIsActive);
            cmdInsertUpdateCaseStatus.Parameters.Add(paramCaseFor);

            IsDataExists = cmdInsertUpdateCaseStatus.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateBranch(Int32 BranchId, String BranchName, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateBranch = new SqlCommand("Exec proc_InsertUpdateBranch @BranchId,@BranchName,@IsActive", con);

            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);
            SqlParameter paramBranchName = new SqlParameter("@BranchName", BranchName);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateBranch.Parameters.Add(paramBranchId);
            cmdInsertUpdateBranch.Parameters.Add(paramBranchName);
            cmdInsertUpdateBranch.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateBranch.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateState(Int32 StateId, String StateName, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateState = new SqlCommand("Exec proc_InsertUpdateState @StateId,@StateName,@IsActive", con);

            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);
            SqlParameter paramStateName = new SqlParameter("@StateName", StateName);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateState.Parameters.Add(paramStateId);
            cmdInsertUpdateState.Parameters.Add(paramStateName);
            cmdInsertUpdateState.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateState.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateDistrict(Int32 DistrictId, Int32 StateId, String DistrictName, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateDistrict = new SqlCommand("Exec proc_InsertUpdateDistrict @DistrictId,@StateId,@DistrictName,@IsActive", con);

            SqlParameter paramDistrictId = new SqlParameter("@DistrictId", DistrictId);
            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);
            SqlParameter paramDistrictName = new SqlParameter("@DistrictName", DistrictName);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateDistrict.Parameters.Add(paramDistrictId);
            cmdInsertUpdateDistrict.Parameters.Add(paramStateId);
            cmdInsertUpdateDistrict.Parameters.Add(paramDistrictName);
            cmdInsertUpdateDistrict.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateDistrict.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateSpeciality(Int32 SpecialityId, String Description, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateSpeciality = new SqlCommand("Exec proc_InsertUpdateSpeciality @SpecialityId,@Description,@IsActive", con);

            SqlParameter paramSpecialityId = new SqlParameter("@SpecialityId", SpecialityId);
            SqlParameter paramDescription = new SqlParameter("@Description", Description);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateSpeciality.Parameters.Add(paramSpecialityId);
            cmdInsertUpdateSpeciality.Parameters.Add(paramDescription);
            cmdInsertUpdateSpeciality.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateSpeciality.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }


        public void InsertUpdatePermission(Int32 PermissionId, String SubPermission, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateState = new SqlCommand("Exec proc_InsertUpdatePermission @PermissionId,@SubPermission,@IsActive", con);

            SqlParameter paramPermissionId = new SqlParameter("@PermissionId", PermissionId);
            SqlParameter paramSubPermission = new SqlParameter("@SubPermission", SubPermission);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);


            cmdInsertUpdateState.Parameters.Add(paramPermissionId);
            cmdInsertUpdateState.Parameters.Add(paramSubPermission);
            cmdInsertUpdateState.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateState.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateSubPermission(Int32 SubPermissionId, Int32 PermissionId, String SubPermission, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateState = new SqlCommand("Exec proc_InsertUpdateSubPermission @SubPermissionId,@PermissionId,@SubPermission,@IsActive", con);

            SqlParameter paramSubPermissionId = new SqlParameter("@SubPermissionId", SubPermissionId);
            SqlParameter paramPermissionId = new SqlParameter("@PermissionId", PermissionId);
            SqlParameter paramSubPermission = new SqlParameter("@SubPermission", SubPermission);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateState.Parameters.Add(paramSubPermissionId);
            cmdInsertUpdateState.Parameters.Add(paramPermissionId);
            cmdInsertUpdateState.Parameters.Add(paramSubPermission);
            cmdInsertUpdateState.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateState.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }


        public DataTable LoadCorporateDetails(Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadCorporateDetails @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadStateDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataSet LoadCorporateDetailsById(int CorporateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadCorporateDetails = new SqlCommand("Exec proc_LoadCorporateDetailsById @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadCorporateDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadCorporateDetails = new SqlDataAdapter(cmdLoadCorporateDetails);
            DataSet dtCorporateDetails = new DataSet();
            daLoadCorporateDetails.Fill(dtCorporateDetails);
            return dtCorporateDetails;
        }

        public DataSet LoadCaseDetailsById(int CaseRefId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadCaseDetails = new SqlCommand("Exec proc_LoadCaseDetailsById @CaseRefId", con);

            SqlParameter paramCaseId = new SqlParameter("@CaseRefId", CaseRefId);

            cmdLoadCaseDetails.Parameters.Add(paramCaseId);

            SqlDataAdapter daLoadCaseDetails = new SqlDataAdapter(cmdLoadCaseDetails);
            DataSet dtCaseDetails = new DataSet();
            daLoadCaseDetails.Fill(dtCaseDetails);
            return dtCaseDetails;
        }

        public DataTable LoadEmployeeDetailsByOther(Int32 CorporateId, string EmployeeId, string MobileNo, string EmployeeName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadEmployeeDetails = new SqlCommand("Exec proc_LoadEmployeeDetailsByOther  @EmployeeId, @MobileNo, @EmployeeName, @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            SqlParameter paramEmployeeId;
            SqlParameter paramMobileNo;
            SqlParameter paramEmployeeName;

            if (!EmployeeName.Equals(""))
            {
                paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            }
            else
            {
                paramEmployeeName = new SqlParameter("@EmployeeName", DBNull.Value);
            }

            if (!MobileNo.Equals(""))
            {
                paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            }
            else
            {
                paramMobileNo = new SqlParameter("@MobileNo", DBNull.Value);
            }

            if (!EmployeeId.Equals(""))
            {
                paramEmployeeId = new SqlParameter("@EmployeeId", EmployeeId);
            }
            else
            {
                paramEmployeeId = new SqlParameter("@EmployeeId", DBNull.Value);
            }

            cmdLoadEmployeeDetails.Parameters.Add(paramCorporateId);
            cmdLoadEmployeeDetails.Parameters.Add(paramEmployeeName);
            cmdLoadEmployeeDetails.Parameters.Add(paramMobileNo);
            cmdLoadEmployeeDetails.Parameters.Add(paramEmployeeId);

            SqlDataAdapter daLoadEmployeeDetails = new SqlDataAdapter(cmdLoadEmployeeDetails);
            DataTable dtLoadEmployeeDetails = new DataTable();
            daLoadEmployeeDetails.Fill(dtLoadEmployeeDetails);
            return dtLoadEmployeeDetails;
        }

        public DataTable SearchMultipleCaseList(string CorporateId, string CaseStatus, string ApplicationNo, string CaseId, string Branch, string AssignedAgent, string City, string MobileNo, string CaseOwnerName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearchMultipleCaseList = new SqlCommand("Exec proc_SearchMultipleCase @CorporateId, @CaseStatus, @ApplicationNo, @CaseId, @Branch, @AssignedAgent, @City, @MobileNo, @CaseOwnerName", con);
            //cmdSearchMultipleCaseList.CommandType = CommandType.StoredProcedure;
            //cmdSearchMultipleCaseList.Parameters.AddWithValue("@Action", "SearchMultiple");

            SqlParameter paramCorporateName = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramApplicationNo = new SqlParameter("@ApplicationNo", ApplicationNo);
            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramBranch = new SqlParameter("@Branch", Branch);
            SqlParameter paramAssignedAgent = new SqlParameter("@AssignedAgent", AssignedAgent);
            SqlParameter paramCity = new SqlParameter("@City", City);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramCaseOwnerName = new SqlParameter("@CaseOwnerName", CaseOwnerName);

            cmdSearchMultipleCaseList.Parameters.Add(paramCorporateName);
            cmdSearchMultipleCaseList.Parameters.Add(paramCaseStatus);
            cmdSearchMultipleCaseList.Parameters.Add(paramApplicationNo);
            cmdSearchMultipleCaseList.Parameters.Add(paramCaseId);
            cmdSearchMultipleCaseList.Parameters.Add(paramBranch);
            cmdSearchMultipleCaseList.Parameters.Add(paramAssignedAgent);
            cmdSearchMultipleCaseList.Parameters.Add(paramCity);
            cmdSearchMultipleCaseList.Parameters.Add(paramMobileNo);
            cmdSearchMultipleCaseList.Parameters.Add(paramCaseOwnerName);

            SqlDataAdapter daSearchMultipleCaseList = new SqlDataAdapter(cmdSearchMultipleCaseList);
            DataTable dtSearchMultipleCaseList = new DataTable();
            daSearchMultipleCaseList.Fill(dtSearchMultipleCaseList);
            con.Close();
            con.Dispose();
            return dtSearchMultipleCaseList;

        }

        public DataSet LoadAppointmentDetailsById(int AppointmentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadAppointmentDetails = new SqlCommand("Exec proc_LoadAppointmentDetailsById @AppointmentId", con);

            SqlParameter paramAppointmentId = new SqlParameter("@AppointmentId", AppointmentId);

            cmdLoadAppointmentDetails.Parameters.Add(paramAppointmentId);

            SqlDataAdapter daLoadApointmentDetails = new SqlDataAdapter(cmdLoadAppointmentDetails);
            DataSet dtLoadApointmentDetails = new DataSet();
            daLoadApointmentDetails.Fill(dtLoadApointmentDetails);
            return dtLoadApointmentDetails;
        }

        public void InsertUpdateTestDetails(Int32 TestId, Int32 CorporateId, string Status, string TestType, string VisitType, string SKUCode, string TestName, string TestCode, string NormalPrice, string HNIPrice, string Remark, string TestDescription, Int32 CreatedBy, out string IsDataExists)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateTestDetails = new SqlCommand("InsertUpdateTestDetails", con);
            cmdInsertUpdateTestDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestId", TestId);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@Status", Status);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestType", TestType);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@VisitType", VisitType);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@SKUCode", SKUCode);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestName", TestName);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestCode", TestCode);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@NormalPrice", NormalPrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@HNIPrice", HNIPrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@Remark", Remark);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestDescription", TestDescription);
            //cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            //IsDataExists = "3";
            //cmdInsertUpdateTestDetails.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateTestDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();


        }

        public void InsertUpdatePackageDetails(Int32 PackageId, Int32 CorporateId, string ProductSKU, string PackageName, string TestIncluded, string NormalPackagePrice, string HNIPackagePrice, string Status, string Remark, Int32 CreatedBy, out string IsDataExists)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateTestDetails = new SqlCommand("InsertUpdatePackageDetails", con);
            cmdInsertUpdateTestDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@PackageId", PackageId);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@ProductSKU", ProductSKU);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@PackageName", PackageName);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestIncluded", TestIncluded);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@NormalPackagePrice", NormalPackagePrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@HNIPackagePrice", HNIPackagePrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@Status", Status);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@Remark", Remark);
            //cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            //IsDataExists = "3";
            //cmdInsertUpdateTestDetails.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateTestDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();


        }

        public void InsertUpdateEmployeeDetails(Int32 EmployeeRefId, string EmployeeId, string EmployeeName, string Address, string Emailid, string MobileNo, string Gender, DateTime? DOB, int State, int City, string Area, string Landmark, string Pincode, string GeoLocation, int CorporateId, int BranchId, string Services, string AccountActivationURL, DateTime? CreatedOn, int CreatedBy, DateTime? ModifiedOn, int ModifiedBy, DateTime? LastActiveDate, DateTime? LastInactiveDate, string InActiveReason, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateEmployeeDetails = new SqlCommand("InsertUpdateEmployeeDetails", con);
            cmdInsertUpdateEmployeeDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@EmployeeRefId", EmployeeRefId);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@FirstName", FirstName);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@LastName", LastName);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Address", Address);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Emailid", Emailid);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Gender", Gender);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@DOB", DOB);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@State", State);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@City", City);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Area", Area);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Landmark", Landmark);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Pincode", Pincode);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@GeoLocation", GeoLocation);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@BranchId", BranchId);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@Services", Services);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@AccountActivationURL", AccountActivationURL);

            SqlParameter paramCreatedOn;

            if (CreatedOn.Equals(null))
            {
                paramCreatedOn = new SqlParameter("@CreatedOn", DBNull.Value);
            }
            else
            {
                paramCreatedOn = new SqlParameter("@CreatedOn", CreatedOn);
            }
            cmdInsertUpdateEmployeeDetails.Parameters.Add(paramCreatedOn);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter paramModifiedOn;

            if (ModifiedOn.Equals(null))
            {
                paramModifiedOn = new SqlParameter("@ModifiedOn", DBNull.Value);
            }
            else
            {
                paramModifiedOn = new SqlParameter("@ModifiedOn", ModifiedOn);
            }

            cmdInsertUpdateEmployeeDetails.Parameters.Add(paramModifiedOn);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
            SqlParameter paramLastActiveDate;

            if (LastActiveDate.Equals(null))
            {
                paramLastActiveDate = new SqlParameter("@LastActiveDate", DBNull.Value);
            }
            else
            {
                paramLastActiveDate = new SqlParameter("@LastActiveDate", LastActiveDate);
            }
            cmdInsertUpdateEmployeeDetails.Parameters.Add(paramLastActiveDate);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@LastActiveDate", LastActiveDate);
            SqlParameter paramLastInactiveDate;

            if (LastInactiveDate.Equals(null))
            {
                paramLastInactiveDate = new SqlParameter("@LastInactiveDate", DBNull.Value);
            }
            else
            {
                paramLastInactiveDate = new SqlParameter("@LastInactiveDate", LastInactiveDate);
            }
            cmdInsertUpdateEmployeeDetails.Parameters.Add(paramLastInactiveDate);
            //cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@LastInactiveDate", LastInactiveDate);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@InActiveReason", InActiveReason);
            cmdInsertUpdateEmployeeDetails.Parameters.AddWithValue("@IsActive", IsActive);

            IsDataExists = cmdInsertUpdateEmployeeDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }
        public void InsertUpdateCustomerDetails(Int32 CustomerRefId, string CustomerId, string FirstName, string LastName, string CustomerName, string Address, string Emailid, string MobileNo, string OTP, string AccountActivationURL, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCustomerDetails = new SqlCommand("InsertUpdateCustomerDetails", con);
            cmdInsertUpdateCustomerDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@CustomerRefId", CustomerRefId);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@FirstName", FirstName);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@LastName", LastName);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@Address", Address);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@Emailid", Emailid);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@OTP", OTP);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@AccountActivationURL", AccountActivationURL);
            cmdInsertUpdateCustomerDetails.Parameters.AddWithValue("@IsActive", IsActive);

            IsDataExists = cmdInsertUpdateCustomerDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateCaseDetails(Int32 CaseRefId, string CaseId, string CaseEntryDatetime, Int32 WelleazyBranch, Int32 AssignedExecutive, string CaseRecMode, DateTime? CaseRecDatetime, Int32 CorporateId, Int32 BranchId, Int32 ProductId, string ServicesOffered, string EmployeeMobileNo, string EmployeeName, string EmployeeGender, Int32 EmployeeRefId, string EmployeeId, string EmployeeEmail, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeeLandmark, string EmployeePincode, string EmployeeAddress, string EmployeeGeoLocation, DateTime? EmployeeDOB, string MedicalTest, string ApplicationNo, Int32 CaseType, string PaymentType, Int32 CaseFor, Int32 CustomerProfile, string GenericTest, string EmployeeToPay, string DHOCAdvancePayment, int CaseStatus, DateTime? SchFollowupdate, string SchRemark, int IsActive, Int32 CreatedBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCase = new SqlCommand("InsertUpdateCaseDetails", con);
            cmdInsertUpdateCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseId", CaseId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseEntryDatetime", CaseEntryDatetime);
            cmdInsertUpdateCase.Parameters.AddWithValue("@WelleazyBranch", WelleazyBranch);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AssignedExecutive", AssignedExecutive);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRecMode", CaseRecMode);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRecDatetime", CaseRecDatetime);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@BranchId", BranchId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ProductId", ProductId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ServicesOffered", ServicesOffered);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeMobileNo", EmployeeMobileNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeGender", EmployeeGender);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeRefId", EmployeeRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeEmail", EmployeeEmail);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeState", EmployeeState);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeCity", EmployeeCity);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeArea", EmployeeArea);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeLandmark", EmployeeLandmark);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeePincode", EmployeePincode);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeAddress", EmployeeAddress);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeGeoLocation", EmployeeGeoLocation);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeDOB", EmployeeDOB);
            cmdInsertUpdateCase.Parameters.AddWithValue("@MedicalTest", MedicalTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseType", CaseType);
            cmdInsertUpdateCase.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseFor", CaseFor);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CustomerProfile", CustomerProfile);
            cmdInsertUpdateCase.Parameters.AddWithValue("@GenericTest", GenericTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeToPay", EmployeeToPay);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DHOCAdvancePayment", DHOCAdvancePayment);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            //cmdInsertUpdateCase.Parameters.AddWithValue("@SchFollowupdate", SchFollowupdate);
            SqlParameter paramSchFollowupdate;

            if (SchFollowupdate.Equals(null))
            {
                paramSchFollowupdate = new SqlParameter("@SchFollowupdate", DBNull.Value);
            }
            else
            {
                paramSchFollowupdate = new SqlParameter("@SchFollowupdate", SchFollowupdate);
            }

            cmdInsertUpdateCase.Parameters.Add(paramSchFollowupdate);
          
            cmdInsertUpdateCase.Parameters.AddWithValue("@SchRemark", SchRemark);
            cmdInsertUpdateCase.Parameters.AddWithValue("@IsActive", IsActive);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CreatedBy", CreatedBy);
           // cmdInsertUpdateCase.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            IsDataExists = cmdInsertUpdateCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateCaseDetailsByPopup(Int32 CaseRefId, int CaseStatus, DateTime? SchFollowupdate, string SchRemark, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCase = new SqlCommand("InsertUpdateCaseDetailsByPopup", con);
            cmdInsertUpdateCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            SqlParameter paramSchFollowupdate;

            if (SchFollowupdate.Equals(null))
            {
                paramSchFollowupdate = new SqlParameter("@SchFollowupdate", DBNull.Value);
            }
            else
            {
                paramSchFollowupdate = new SqlParameter("@SchFollowupdate", SchFollowupdate);
            }

            cmdInsertUpdateCase.Parameters.Add(paramSchFollowupdate);

            cmdInsertUpdateCase.Parameters.AddWithValue("@SchRemark", SchRemark);

            IsDataExists = cmdInsertUpdateCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateAppointmentDetails(Int32 AppointmentId, Int32 CaseRefId, string CaseId, string EmployeeName, string ApplicationNo, int BranchId, Int32 CorporateId, string EmployeeId, int CustomerProfile, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeePincode, int AppointmentStatus, DateTime? AppointmentDateTime, string VisitType, string ADHOC_ApprovalBased, string VideographyDone, string VideographyReason, string Comment, Int32 dc_id, string DCMobileNo, string DCName, string DCAddress, string IndividualTest, string PackageTest, int CaseStatus, int ReportStatus, Int32 ScheduledBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCase = new SqlCommand("InsertUpdateAppointmentDetails", con);
            cmdInsertUpdateCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentId", AppointmentId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseId", CaseId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@BranchId", BranchId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CustomerProfile", CustomerProfile);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeState", EmployeeState);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeCity", EmployeeCity);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeArea", EmployeeArea);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeePincode", EmployeePincode);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VisitType", VisitType);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ADHOC_ApprovalBased", ADHOC_ApprovalBased);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VideographyDone", VideographyDone);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VideographyReason", VideographyReason);
            cmdInsertUpdateCase.Parameters.AddWithValue("@Comment", Comment);
            cmdInsertUpdateCase.Parameters.AddWithValue("@dc_id", dc_id);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCMobileNo", DCMobileNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCName", DCName);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCAddress", DCAddress);
            cmdInsertUpdateCase.Parameters.AddWithValue("@IndividualTest", IndividualTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@PackageTest", PackageTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ReportStatus", ReportStatus);
            //cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentScheduleDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString());
            cmdInsertUpdateCase.Parameters.AddWithValue("@ScheduledBy", ScheduledBy);
            //cmdInsertUpdateCase.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            IsDataExists = cmdInsertUpdateCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }
        public void InsertUpdateCorporateDetails(Int32 CorporateId, String CorporateName, string MobileNo, string LandLineNo, string Emailid, string HeadOfficeAddress, string BranchOfficeAddress, DataTable dtContactDetails, DataTable dtDocumentDetails, int IsActive, string InsuranceStatus, DateTime? AgreementDate, DateTime? ExpiryDate, Int32 CreatedBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            //SqlCommand cmdInsertUpdateState = new SqlCommand("Exec InsertUpdateCorporateDetails @CorporateId,@CorporateName,@MobileNo,@LandLineNo,@HeadOfficeAddress,@BranchOfficeAddress,@ContactDetails,@IsActive", con);

            SqlCommand cmdInsertUpdateState = new SqlCommand("InsertUpdateCorporateDetails", con);
            cmdInsertUpdateState.CommandType = CommandType.StoredProcedure;

            
            cmdInsertUpdateState.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateState.Parameters.AddWithValue("@CorporateName", CorporateName);
            cmdInsertUpdateState.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdInsertUpdateState.Parameters.AddWithValue("@LandLineNo", LandLineNo);
            cmdInsertUpdateState.Parameters.AddWithValue("@Emailid", Emailid);
            cmdInsertUpdateState.Parameters.AddWithValue("@HeadOfficeAddress", HeadOfficeAddress);
            cmdInsertUpdateState.Parameters.AddWithValue("@BranchOfficeAddress", BranchOfficeAddress);
            cmdInsertUpdateState.Parameters.AddWithValue("@ContactDetails", dtContactDetails);
            //cmdInsertUpdateState.Parameters.AddWithValue("@BranchDetails", dtBranchDetails);
            cmdInsertUpdateState.Parameters.AddWithValue("@DocumentDetails", dtDocumentDetails);
            cmdInsertUpdateState.Parameters.AddWithValue("@IsActive", IsActive);
            cmdInsertUpdateState.Parameters.AddWithValue("@InsuranceStatus", InsuranceStatus);

            SqlParameter paramAgreementDate;
            SqlParameter paramExpiryDate;

            if (AgreementDate.Equals(null))
            {
                paramAgreementDate = new SqlParameter("@AgreementDate",DBNull.Value);
            }
            else
            {
                paramAgreementDate = new SqlParameter("@AgreementDate", AgreementDate);
            }

            if (ExpiryDate.Equals(null))
            {
                paramExpiryDate = new SqlParameter("@ExpiryDate", DBNull.Value);
            }
            else
            {
                paramExpiryDate = new SqlParameter("@ExpiryDate", ExpiryDate);
            }

            cmdInsertUpdateState.Parameters.Add(paramAgreementDate);
            cmdInsertUpdateState.Parameters.Add(paramExpiryDate);

            cmdInsertUpdateState.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            //cmdInsertUpdateState.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            IsDataExists = cmdInsertUpdateState.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable DownloadCorporateDocument(Int32 CorporateDocumentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdDownload = new SqlCommand("Exec proc_DownloadCorporateDocument @CorporateDocumentDetailsId", con);

            SqlParameter paramCorporateDocumentDetailsId = new SqlParameter("@CorporateDocumentDetailsId", CorporateDocumentDetailsId);

            cmdDownload.Parameters.Add(paramCorporateDocumentDetailsId);

            SqlDataAdapter daCorporateDocumentDetailsId = new SqlDataAdapter(cmdDownload);
            DataTable dtCorporateDocumentDetailsId = new DataTable();
            daCorporateDocumentDetailsId.Fill(dtCorporateDocumentDetailsId);

            con.Close();
            con.Dispose();
            return dtCorporateDocumentDetailsId;

        }

        public void DeleteCorporateDocument(Int32 CorporateDocumentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdDelete = new SqlCommand("Exec proc_DeleteCorporateDocument @CorporateDocumentDetailsId", con);

            SqlParameter paramCorporateDocumentDetailsId = new SqlParameter("@CorporateDocumentDetailsId", CorporateDocumentDetailsId);

            cmdDelete.Parameters.Add(paramCorporateDocumentDetailsId);

            cmdDelete.ExecuteNonQuery();

            con.Close();
            con.Dispose();


        }

        public DataTable LoadCorporateDetailsDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCorporateDetails = new SqlCommand("Exec proc_FetchCorporateDetails", con);



            SqlDataAdapter daCorporateDetails = new SqlDataAdapter(cmdCorporateDetails);
            DataTable dtCorporateDetails = new DataTable();
            daCorporateDetails.Fill(dtCorporateDetails);
            con.Close();
            con.Dispose();
            return dtCorporateDetails;

        }

        public void UploadTestDetails(Int32 CorporateId, DataTable dtTestDetails, Int32 CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdUploadTestDetails = new SqlCommand("proc_UploadTestDetails", con);
            cmdUploadTestDetails.CommandType = CommandType.StoredProcedure;
            cmdUploadTestDetails.CommandTimeout = 0; //900000
            cmdUploadTestDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdUploadTestDetails.Parameters.AddWithValue("@TestDetail", dtTestDetails);
            cmdUploadTestDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdUploadTestDetails.ExecuteNonQuery();
        }
        public void UploadEmployeeDetails(DataTable dtEmployeeDetails, string Services, Int32 CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdUploadEmployeeDetails = new SqlCommand("proc_UploadEmployeeDetails", con);
            cmdUploadEmployeeDetails.CommandType = CommandType.StoredProcedure;

            cmdUploadEmployeeDetails.Parameters.AddWithValue("@EmployeeDetail", dtEmployeeDetails);
            cmdUploadEmployeeDetails.Parameters.AddWithValue("@Services", Services);
            cmdUploadEmployeeDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdUploadEmployeeDetails.ExecuteNonQuery();
        }


        public DataTable LoadEmployeeDetails(int CorporateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEmployeeDetails = new SqlCommand("Exec proc_FetchEmployeeDetailsOnCorporateId @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdEmployeeDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daEmployeeDetails = new SqlDataAdapter(cmdEmployeeDetails);
            DataTable dtEmployeeDetails = new DataTable();
            daEmployeeDetails.Fill(dtEmployeeDetails);
            con.Close();
            con.Dispose();
            return dtEmployeeDetails;

        }

        public int InsertUpdateLoginDetails(Int32 LoginRefId, Int32 EmployeeLoginRefId, Int32 CorporateId, string UserName, string Password, string DisplayName, string MobileNo, string EmailId, string @RolePermissions, int IsActive, string IPAddress)
        {
            int i = 0;
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdInsert = new SqlCommand("Exec proc_InsertUpdateLoginDetails @LoginRefId,@EmployeeLoginRefId,@CorporateId,@UserName,@Password,@DisplayName,@MobileNo,@EmailId,@RolePermissions,@IsActive,@IPAddress", con);

                SqlParameter paramLoginRefId = new SqlParameter("@LoginRefId", LoginRefId);
                SqlParameter paramEmployeeLoginREfId = new SqlParameter("@EmployeeLoginRefId", EmployeeLoginRefId);
                SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
                SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
                SqlParameter paramPassword = new SqlParameter("@Password", Password);
                SqlParameter paramDisplayName = new SqlParameter("@DisplayName", DisplayName);
                SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
                SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);
                SqlParameter paramRoleDescription = new SqlParameter("@RolePermissions", RolePermissions);
                SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);
                SqlParameter paramIPAddress = new SqlParameter("@IPAddress", IPAddress);

                cmdInsert.Parameters.Add(paramLoginRefId);
                cmdInsert.Parameters.Add(paramEmployeeLoginREfId);
                cmdInsert.Parameters.Add(paramCorporateId);
                cmdInsert.Parameters.Add(paramUserName);
                cmdInsert.Parameters.Add(paramPassword);
                cmdInsert.Parameters.Add(paramDisplayName);
                cmdInsert.Parameters.Add(paramMobileNo);
                cmdInsert.Parameters.Add(paramEmailId);
                cmdInsert.Parameters.Add(paramRoleDescription);
                cmdInsert.Parameters.Add(paramIsActive);
                cmdInsert.Parameters.Add(paramIPAddress);



                i = cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }

            return i;
        }


        public DataTable VerifyLogin(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdverifyLogin = new SqlCommand("Exec proc_VerifyLogin @UserName,@Password", con);
            SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);

            cmdverifyLogin.Parameters.Add(paramUserName);
            cmdverifyLogin.Parameters.Add(paramPassword);

            SqlDataAdapter daVerifyLogin = new SqlDataAdapter(cmdverifyLogin);
            DataTable dtVerifyLogin = new DataTable();

            daVerifyLogin.Fill(dtVerifyLogin);
            return dtVerifyLogin;


        }

        public DataTable VerifyMasterLogin(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdVerifyMasterLogin = new SqlCommand("Exec proc_VerifyMasterLogin @UserName,@Password", con);
            SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);

            cmdVerifyMasterLogin.Parameters.Add(paramUserName);
            cmdVerifyMasterLogin.Parameters.Add(paramPassword);

            SqlDataAdapter daVerifyMasterLogin = new SqlDataAdapter(cmdVerifyMasterLogin);
            DataTable dtVerifyMasterLogin = new DataTable();

            daVerifyMasterLogin.Fill(dtVerifyMasterLogin);
            return dtVerifyMasterLogin;


        }

        public DataTable VerifyMasterLoginMO(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdVerifyMasterLogin = new SqlCommand("Exec proc_VerifyMasterLoginMO @MobileNo,@OTP", con);
            SqlParameter paramUserName = new SqlParameter("@MobileNo", UserName);
            SqlParameter paramPassword = new SqlParameter("@OTP", Password);

            cmdVerifyMasterLogin.Parameters.Add(paramUserName);
            cmdVerifyMasterLogin.Parameters.Add(paramPassword);

            SqlDataAdapter daVerifyMasterLogin = new SqlDataAdapter(cmdVerifyMasterLogin);
            DataTable dtVerifyMasterLogin = new DataTable();

            daVerifyMasterLogin.Fill(dtVerifyMasterLogin);
            return dtVerifyMasterLogin;


        }

        public DataTable LoadClosedAppointmentDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadClosedAppointmentDetails = new SqlCommand("Exec proc_LoadClosedAppointmentList @EmployeeRefId, @RoleId, @LoginType, @CorporateId", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadClosedAppointmentDetails.Parameters.Add(paramEmployeeRefId);
            cmdLoadClosedAppointmentDetails.Parameters.Add(paramRoleId);
            cmdLoadClosedAppointmentDetails.Parameters.Add(paramLoginType);
            cmdLoadClosedAppointmentDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadClosedAppointmentDetails = new SqlDataAdapter(cmdLoadClosedAppointmentDetails);
            DataTable dtLoadClosedAppointmentDetails = new DataTable();

            daLoadClosedAppointmentDetails.Fill(dtLoadClosedAppointmentDetails);

            con.Close();
            con.Dispose();

            return dtLoadClosedAppointmentDetails;

        }

        public DataTable LoadAppointmentDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadAppointmentDetails = new SqlCommand("Exec proc_LoadAppointmentList @EmployeeRefId, @RoleId, @LoginType, @CorporateId", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadAppointmentDetails.Parameters.Add(paramEmployeeRefId);
            cmdLoadAppointmentDetails.Parameters.Add(paramRoleId);
            cmdLoadAppointmentDetails.Parameters.Add(paramLoginType);
            cmdLoadAppointmentDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadAppointmentDetails = new SqlDataAdapter(cmdLoadAppointmentDetails);
            DataTable dtLoadAppointmentDetails = new DataTable();

            daLoadAppointmentDetails.Fill(dtLoadAppointmentDetails);

            con.Close();
            con.Dispose();

            return dtLoadAppointmentDetails;

        }

        public DataTable LoadAppointmentDetailsCaseId()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadAppointmentDetailsCaseId = new SqlCommand("Exec proc_LoadAppointmentDetailsCaseId @CaseRefId", con);

            SqlParameter paramUserId = new SqlParameter("@CaseRefId", Variables.CaseRefId);

            cmdLoadAppointmentDetailsCaseId.Parameters.Add(paramUserId);

            SqlDataAdapter daLoadAppointmentDetailsCaseId = new SqlDataAdapter(cmdLoadAppointmentDetailsCaseId);
            DataTable dtLoadAppointmentDetailsCaseId = new DataTable();

            daLoadAppointmentDetailsCaseId.Fill(dtLoadAppointmentDetailsCaseId);

            con.Close();
            con.Dispose();

            return dtLoadAppointmentDetailsCaseId;

        }
        public DataTable LoadCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadCaseDetailsList = new SqlCommand("Exec proc_LoadCaseDetails @EmployeeRefId, @RoleId, @LoginType, @CorporateId", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadCaseDetailsList.Parameters.Add(paramEmployeeRefId);
            cmdLoadCaseDetailsList.Parameters.Add(paramRoleId);
            cmdLoadCaseDetailsList.Parameters.Add(paramLoginType);
            cmdLoadCaseDetailsList.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadCaseDetailsList = new SqlDataAdapter(cmdLoadCaseDetailsList);
            DataTable dtLoadCaseDetailsList = new DataTable();

            daLoadCaseDetailsList.Fill(dtLoadCaseDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadCaseDetailsList;

        }

        public DataTable LoadTestDetailsList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestDetailsList = new SqlCommand("Exec proc_LoadTestDetails", con);

            SqlDataAdapter daLoadTestDetailsList = new SqlDataAdapter(cmdLoadTestDetailsList);
            DataTable dtLoadTestDetailsList = new DataTable();

            daLoadTestDetailsList.Fill(dtLoadTestDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestDetailsList;

        }

        public DataTable LoadTestPackageDetailsList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestPackageDetailsList = new SqlCommand("Exec proc_LoadTestPackageDetails", con);

            SqlDataAdapter daLoadTestPackageDetailsList = new SqlDataAdapter(cmdLoadTestPackageDetailsList);
            DataTable dtLoadTestPackageDetailsList = new DataTable();

            daLoadTestPackageDetailsList.Fill(dtLoadTestPackageDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestPackageDetailsList;

        }

        public DataTable LoadBranchList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadBranchList = new SqlCommand("Exec proc_LoadBranchDetails", con);

            SqlDataAdapter daLoadBranchList = new SqlDataAdapter(cmdLoadBranchList);
            DataTable dtLoadBranchList = new DataTable();

            daLoadBranchList.Fill(dtLoadBranchList);

            con.Close();
            con.Dispose();

            return dtLoadBranchList;


        }
        public DataTable LoadCaseStatusList(Int32 CaseFor)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadCaseStatusList = new SqlCommand("Exec proc_LoadCaseStatusDetails @CaseFor", con);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            cmdLoadCaseStatusList.Parameters.Add(paramCaseFor);
            SqlDataAdapter daLoadCaseStatusList = new SqlDataAdapter(cmdLoadCaseStatusList);
            DataTable dtLoadCaseStatusList = new DataTable();

            daLoadCaseStatusList.Fill(dtLoadCaseStatusList);

            con.Close();
            con.Dispose();

            return dtLoadCaseStatusList;


        }

        public DataTable LoadCityListSearch()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadCityListSearch = new SqlCommand("Exec proc_LoadCityList", con);

            SqlDataAdapter daLoadCityListSearch = new SqlDataAdapter(cmdLoadCityListSearch);
            DataTable dtLoadCityListSearch = new DataTable();

            daLoadCityListSearch.Fill(dtLoadCityListSearch);

            con.Close();
            con.Dispose();

            return dtLoadCityListSearch;


        }
        public DataTable LoadCoporateList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadCoporateList = new SqlCommand("Exec proc_LoadCorporateDetails", con);

            SqlDataAdapter daLoadCoporateList = new SqlDataAdapter(cmdLoadCoporateList);
            DataTable dtLoadCoporateList = new DataTable();

            daLoadCoporateList.Fill(dtLoadCoporateList);

            con.Close();
            con.Dispose();

            return dtLoadCoporateList;


        }
        public DataTable LoadUserAccessRoles(Int32 UserId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadUserAccessRoles = new SqlCommand("Exec proc_FetchUserRolePermission @UserId", con);
            SqlParameter paramUserId = new SqlParameter("@UserId", UserId);
            cmdLoadUserAccessRoles.Parameters.Add(paramUserId);

            SqlDataAdapter daLoadUserAccessRoles = new SqlDataAdapter(cmdLoadUserAccessRoles);
            DataTable dtLoadUserAccessRoles = new DataTable();

            daLoadUserAccessRoles.Fill(dtLoadUserAccessRoles);

            con.Close();
            con.Dispose();

            return dtLoadUserAccessRoles;


        }

        public DataSet LoadPermissionDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadPermissionDetails = new SqlCommand("Exec proc_FetchPermissionDetails", con);

            SqlDataAdapter daLoadPermissionDetails = new SqlDataAdapter(cmdLoadPermissionDetails);
            DataSet dtLoadPermissionDetails = new DataSet();

            daLoadPermissionDetails.Fill(dtLoadPermissionDetails);

            con.Close();
            con.Dispose();

            return dtLoadPermissionDetails;


        }

        public DataTable LoadProfileTypes()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadProfileTypes = new SqlCommand("Exec proc_FetchProfileTypes", con);

            SqlDataAdapter daLoadProfileTypes = new SqlDataAdapter(cmdLoadProfileTypes);
            DataTable dtLoadProfileTypes = new DataTable();

            daLoadProfileTypes.Fill(dtLoadProfileTypes);

            con.Close();
            con.Dispose();

            return dtLoadProfileTypes;


        }

        public DataTable LoadUserRoles(Int32 RoleId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadUserRoles = new SqlCommand("Exec proc_FetchUserRoles @RoleId", con);

            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);


            cmdLoadUserRoles.Parameters.Add(paramRoleId);

            SqlDataAdapter daLoadUserRoles = new SqlDataAdapter(cmdLoadUserRoles);
            DataTable dtLoadUserRoles = new DataTable();

            daLoadUserRoles.Fill(dtLoadUserRoles);

            con.Close();
            con.Dispose();

            return dtLoadUserRoles;


        }

        public DataTable LoadUsers(Int32 RoleId, Int32 SubRoleId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadUsers = new SqlCommand("Exec proc_FetchUsers @RoleId,@SubRoleId", con);

            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramSubRoleId = new SqlParameter("@SubRoleId", SubRoleId);

            cmdLoadUsers.Parameters.Add(paramRoleId);
            cmdLoadUsers.Parameters.Add(paramSubRoleId);

            SqlDataAdapter daLoadUsers = new SqlDataAdapter(cmdLoadUsers);
            DataTable dtLoadUsers = new DataTable();

            daLoadUsers.Fill(dtLoadUsers);

            con.Close();
            con.Dispose();

            return dtLoadUsers;




        }

        public DataTable LoadUserRolePermissions(Int32 UserId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadUsers = new SqlCommand("Exec proc_FetchUserRolePermissions @UserId", con);

            SqlParameter paramRoleId = new SqlParameter("@UserId", UserId);


            cmdLoadUsers.Parameters.Add(paramRoleId);


            SqlDataAdapter daLoadUserRolePermissions = new SqlDataAdapter(cmdLoadUsers);
            DataTable dtLoadUserRolePermissions = new DataTable();

            daLoadUserRolePermissions.Fill(dtLoadUserRolePermissions);

            con.Close();
            con.Dispose();

            return dtLoadUserRolePermissions;




        }

        public int InsertUserRolePermissions(Int32 UserId, string RolePermissions)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdInsertUserRolePermissions = new SqlCommand("Exec proc_InsertUserRolePermission @UserId,@RolePermissions", con);

            SqlParameter paramUserId = new SqlParameter("@UserId", UserId);
            SqlParameter paramRolePermissions = new SqlParameter("@RolePermissions", RolePermissions);

            cmdInsertUserRolePermissions.Parameters.Add(paramUserId);
            cmdInsertUserRolePermissions.Parameters.Add(paramRolePermissions);

            int i = cmdInsertUserRolePermissions.ExecuteNonQuery();

            con.Close();
            con.Dispose();

            return i;
        }

        public DataTable FetchUserRolePermissionsByUserId(Int32 UserId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchUserRolePermissionsByUserId = new SqlCommand("Exec proc_FetchUserRolePermissionsByUserId @UserId", con);

            SqlParameter paramUserId = new SqlParameter("@UserId", UserId);


            cmdFetchUserRolePermissionsByUserId.Parameters.Add(paramUserId);

            SqlDataAdapter daFetchUserRolePermissionsByUserId = new SqlDataAdapter(cmdFetchUserRolePermissionsByUserId);
            DataTable dtFetchUserRolePermissionsByUserId = new DataTable();

            daFetchUserRolePermissionsByUserId.Fill(dtFetchUserRolePermissionsByUserId);


            con.Close();
            con.Dispose();

            return dtFetchUserRolePermissionsByUserId;




        }


        public DataTable LoadPackageDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchPakageDetails = new SqlCommand("Exec proc_FetchPackageDetails", con);



            SqlDataAdapter daPackageDetails = new SqlDataAdapter(cmdFetchPakageDetails);
            DataTable dtPackageDetails = new DataTable();
            daPackageDetails.Fill(dtPackageDetails);

            con.Close();
            con.Dispose();

            return dtPackageDetails;


        }

        public DataTable LoadPackageDetailsById(Int32 PackageId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchPakageDetails = new SqlCommand("Exec proc_FetchPackageDetailsById @PackageId", con);
            SqlParameter paramPackageId = new SqlParameter("@PackageId", PackageId);

            cmdFetchPakageDetails.Parameters.Add(paramPackageId);

            SqlDataAdapter daPackageDetails = new SqlDataAdapter(cmdFetchPakageDetails);
            DataTable dtPackageDetails = new DataTable();
            daPackageDetails.Fill(dtPackageDetails);

            con.Close();
            con.Dispose();

            return dtPackageDetails;


        }

        public DataTable LoadDCCenterList(Int32 City)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadDCCenterList = new SqlCommand("Exec proc_LoadDCCenterList @City", con);
            SqlParameter paramPackageId = new SqlParameter("@City", City);

            cmdLoadDCCenterList.Parameters.Add(paramPackageId);


            SqlDataAdapter daLoadDCCenterList = new SqlDataAdapter(cmdLoadDCCenterList);
            DataTable dtLoadDCCenterList = new DataTable();

            daLoadDCCenterList.Fill(dtLoadDCCenterList);

            con.Close();
            con.Dispose();

            return dtLoadDCCenterList;


        }


        public void InsertUpdatePackageDetails(Int32 PackageId, string ProductSKU, string PackageName, Int32 CorporateId, string RefferingChannel, string Name, string EmailId, string MobileNo, string ProductType, string TestIncluded, double NormalPrice, double HNIPrice, string AHC_Status, string ProductType_Consultation, string ConsultationTYpe, string DoctorSpecialization, string ConsultationStatus, string ProductType_SecondOpinion, double SecondOpinion_NorMalPrice, double SecondOpinion_HNIPrice, string SecondOpinion_Status, int IsActive, Int32 CreatedBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdatePackageDetails = new SqlCommand("Exec proc_InsertUpdateMaster_TestPackage" +
                " @PackageId,@ProductSKU,@PackageName,@CorporateId," +
                "@RefferingChannel,@Name,@EmailId,@MobileNo," +
                " @ProductType,@TestIncluded,@NormalPrice," +
                "@HNIPrice,@AHC_Status,@ProductType_Consultation,@ConsultationTYpe,@DoctorSpecialization,@ConsultationStatus,@ProductType_SecondOpinion,@SecondOpinion_NorMalPrice," +
                "@SecondOpinion_HNIPrice,@SecondOpinion_Status,@IsActive,@CreatedBy", con);

            SqlParameter paramPackageId = new SqlParameter("@PackageId", PackageId);
            SqlParameter paramProductSKU = new SqlParameter("@ProductSKU", ProductSKU);
            SqlParameter paramPackageName = new SqlParameter("@PackageName", PackageName);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            SqlParameter paramRefferingChannel = new SqlParameter("@RefferingChannel", RefferingChannel);
            SqlParameter paramName = new SqlParameter("@Name", Name);
            SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);

            SqlParameter paramProductType = new SqlParameter("@ProductType", ProductType);
            SqlParameter paramTestIncluded = new SqlParameter("@TestIncluded", TestIncluded);

            SqlParameter paramNormalPrice = new SqlParameter("@NormalPrice", NormalPrice);
            SqlParameter paramHNIPrice = new SqlParameter("@HNIPrice", HNIPrice);
            SqlParameter paramAHC_Status = new SqlParameter("@AHC_Status", AHC_Status);

            SqlParameter paramProductType_Consultation = new SqlParameter("@ProductType_Consultation", ProductType_Consultation);
            SqlParameter paramConsultationTYpe = new SqlParameter("@ConsultationTYpe", ConsultationTYpe);
            SqlParameter paramDoctorSpecialization = new SqlParameter("@DoctorSpecialization", DoctorSpecialization);
            SqlParameter paramConsultationStatus = new SqlParameter("@ConsultationStatus", ConsultationStatus);

            SqlParameter paramProductType_SecondOpinion = new SqlParameter("@ProductType_SecondOpinion", ProductType_SecondOpinion);
            SqlParameter paramSecondOpinion_NorMalPrice = new SqlParameter("@SecondOpinion_NorMalPrice", SecondOpinion_NorMalPrice);
            SqlParameter paramSecondOpinion_HNIPrice = new SqlParameter("@SecondOpinion_HNIPrice", SecondOpinion_HNIPrice);
            SqlParameter paramSecondOpinion_Status = new SqlParameter("@SecondOpinion_Status", SecondOpinion_Status);

            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);
            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);


            cmdInsertUpdatePackageDetails.Parameters.Add(paramPackageId);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramProductSKU);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramPackageName);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramCorporateId);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramProductType);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramRefferingChannel);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramName);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramEmailId);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramMobileNo);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramTestIncluded);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramNormalPrice);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramHNIPrice);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramAHC_Status);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramProductType_Consultation);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramConsultationTYpe);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramDoctorSpecialization);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramConsultationStatus);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramProductType_SecondOpinion);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramSecondOpinion_NorMalPrice);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramSecondOpinion_HNIPrice);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramSecondOpinion_Status);

            cmdInsertUpdatePackageDetails.Parameters.Add(paramIsActive);
            cmdInsertUpdatePackageDetails.Parameters.Add(paramCreatedBy);


            IsDataExists = cmdInsertUpdatePackageDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();



        }

        public void UploadPackageDetails(DataTable dtPackageDetails)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdUploadEmployeeDetails = new SqlCommand("proc_UploadPackageDetails", con);
            cmdUploadEmployeeDetails.CommandType = CommandType.StoredProcedure;

            cmdUploadEmployeeDetails.Parameters.AddWithValue("@PackageDetail", dtPackageDetails);
            cmdUploadEmployeeDetails.ExecuteNonQuery();
        }

        public void UploadTestPackageDetails(Int32 CorporateId, DataTable dtTestPackageDetails, Int32 CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdUploadEmployeeDetails = new SqlCommand("proc_UploadTestPackageDetails", con);
            cmdUploadEmployeeDetails.CommandType = CommandType.StoredProcedure;

            cmdUploadEmployeeDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdUploadEmployeeDetails.Parameters.AddWithValue("@TestPackageDetail", dtTestPackageDetails);
            cmdUploadEmployeeDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdUploadEmployeeDetails.ExecuteNonQuery();
        }

        public void InsertUpdateDoctorDetails(Int32 DoctorId, string DoctorName, string EmailId, string ContactNo, string AlternateContactNo,
            string DoctorLanguage, Int32 DoctorQualification, string RegistrationNumber, string PANCard, string DoctorAddress, Int32 StateId, Int32 DistrictId, string Area,
            double TeleMERRate, double TeleVideoRate,
            string AccountNumber, string BankName, string AccountHolderName, string BankBranch, string IFSCCode, int IsActive, Int32 CreatedBy, DataTable dtDoctorDocument, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            //SqlCommand cmdInsertUpdateDoctorDetails = new SqlCommand("proc_InsertUpdateMaster_Doctor" +
            //    " @DoctorId,@DoctorName,@EmailId,@ContactNo,@AlternateContactNo,@DoctorLanguage,@DoctorQualification,@RegistrationNumber,@PANCard," +
            //    "@DoctorAddress,@StateId,@DistrictId,@Area,@TeleMERRate,@TeleVideoRate,@AccountNumber,@BankName, @AccountHolderName,@BankBranch,@IFSCCode, @IsActive,@CreatedBy", con);
            SqlCommand cmdInsertUpdateDoctorDetails = new SqlCommand("proc_InsertUpdateMaster_Doctor", con);
            cmdInsertUpdateDoctorDetails.CommandType = CommandType.StoredProcedure;

            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramDoctorName = new SqlParameter("@DoctorName", DoctorName);
            SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);
            SqlParameter paramContactNo = new SqlParameter("@ContactNo", ContactNo);
            SqlParameter paramAlternateContactNo = new SqlParameter("@AlternateContactNo", AlternateContactNo);

            SqlParameter paramDoctorLanguage = new SqlParameter("@DoctorLanguage", DoctorLanguage);
            SqlParameter paramDoctorQualification = new SqlParameter("@DoctorQualification", DoctorQualification);
            SqlParameter paramRegistrationNumber = new SqlParameter("@RegistrationNumber", RegistrationNumber);
            SqlParameter paramPANCard = new SqlParameter("@PANCard", PANCard);
            SqlParameter paramDoctorAddress = new SqlParameter("@DoctorAddress", DoctorAddress);
            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);
            SqlParameter paramDistrictId = new SqlParameter("@DistrictId", DistrictId);
            SqlParameter paramArea = new SqlParameter("@Area", Area);
            SqlParameter paramTeleMERRate = new SqlParameter("@TeleMERRate", TeleMERRate);
            SqlParameter paramTeleVideoRate = new SqlParameter("@TeleVideoRate", TeleVideoRate);
            SqlParameter paramAccountNumber = new SqlParameter("@AccountNumber", AccountNumber);
            SqlParameter paramBankName = new SqlParameter("@BankName", BankName);
            SqlParameter paramAccountHolderName = new SqlParameter("@AccountHolderName", AccountHolderName);
            SqlParameter paramBankBranch = new SqlParameter("@BankBranch", BankBranch);
            SqlParameter paramIFSCCode = new SqlParameter("@IFSCCode", IFSCCode);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);
            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);


            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDoctorId);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDoctorName);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramEmailId);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramContactNo);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramAlternateContactNo);

            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDoctorLanguage);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDoctorQualification);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramRegistrationNumber);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramPANCard);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDoctorAddress);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramStateId);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramDistrictId);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramArea);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramTeleMERRate);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramTeleVideoRate);

            cmdInsertUpdateDoctorDetails.Parameters.Add(paramAccountHolderName);


            cmdInsertUpdateDoctorDetails.Parameters.Add(paramAccountNumber);

            cmdInsertUpdateDoctorDetails.Parameters.Add(paramBankName);

            cmdInsertUpdateDoctorDetails.Parameters.Add(paramBankBranch);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramIFSCCode);

            cmdInsertUpdateDoctorDetails.Parameters.Add(paramIsActive);
            cmdInsertUpdateDoctorDetails.Parameters.Add(paramCreatedBy);

            cmdInsertUpdateDoctorDetails.Parameters.AddWithValue("@DoctorDocument", dtDoctorDocument);


            IsDataExists = cmdInsertUpdateDoctorDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }

        public DataTable LoadDoctorDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchDoctorDetails = new SqlCommand("Exec proc_FetchDoctorDetails", con);



            SqlDataAdapter daDoctorDetails = new SqlDataAdapter(cmdFetchDoctorDetails);
            DataTable dtPackageDoctorDetails = new DataTable();
            daDoctorDetails.Fill(dtPackageDoctorDetails);

            con.Close();
            con.Dispose();

            return dtPackageDoctorDetails;


        }

        public DataTable FetchDoctorDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchDoctorDetails = new SqlCommand("Exec proc_LoadDoctorDetails", con);



            SqlDataAdapter daDoctorDetails = new SqlDataAdapter(cmdFetchDoctorDetails);
            DataTable dtDoctorDetails = new DataTable();
            daDoctorDetails.Fill(dtDoctorDetails);

            con.Close();
            con.Dispose();

            return dtDoctorDetails;


        }


        public DataSet FetchDoctorDetailsById(Int32 DoctorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchDoctorDetails = new SqlCommand("Exec proc_LoadDoctorDetailsById @DoctorId", con);

            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);

            cmdFetchDoctorDetails.Parameters.Add(paramDoctorId);

            SqlDataAdapter daDoctorDetails = new SqlDataAdapter(cmdFetchDoctorDetails);
            DataSet dtDoctorDetails = new DataSet();
            daDoctorDetails.Fill(dtDoctorDetails);

            con.Close();
            con.Dispose();

            return dtDoctorDetails;


        }

        public DataTable GenearateEConsultancyCaseId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseId = new SqlCommand("Exec proc_GenerateEConsultancyCaseId", con);

            SqlDataAdapter daCaseId = new SqlDataAdapter(cmdCaseId);
            DataTable dtCaseId = new DataTable();

            daCaseId.Fill(dtCaseId);

            return dtCaseId;
        }

        public DataTable LoadEConsultantCaseDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadEConsultantCaseDetails", con);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public DataTable LoadEConsultantCaseDetailsById(Int32 EConsultantCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadEConsultantCaseDetailsById @EConsultantCaseDetailsId", con);

            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@EConsultantCaseDetailsId", EConsultantCaseDetailsId);
            cmdCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public void InsertUpdateEConsultantCaseDetails(Int32 EConsultantCaseDetailsId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
           Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
Int32 CorporateBranchId, Int32 ServicesOffered, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived,
Int32 ConsultationType, Int32 CaseType, int PaymentType, int CaseFor, int CustomerProfile, int PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateEConsultCaseDetails = new SqlCommand("Exec proc_InsertUpdateEConsultantCaseDetails @EConsultantCaseDetailsId,@CaseId,@CaseEntryDateTime,@BranchId, @AssignedExecutiveId, @CaseReceivedMode, @CaseRecievedDateTime, @CorporateId,@CorporateBranchId,@ServicesOffered, @EmployeeName, @MobileNo, @GenderId, @EMailId, @NoOfFreeConsultations, @NoOfConsultationReceived,@ConsultationType,@CaseType, @PaymentType, @CaseFor, @CustomerProfile, @PrefferedLanguage, @DoctorDateTime, @DoctorId, @DoctorQualificationId,@CaseStatus, @FollowUpDataTime, @Remarks,@CreatedBy", con);

            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@EConsultantCaseDetailsId", EConsultantCaseDetailsId);
            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramCaseEntryDateTime = new SqlParameter("@CaseEntryDateTime", CaseEntryDateTime);
            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);
            SqlParameter paramCAssignedExecutiveId = new SqlParameter("@AssignedExecutiveId", AssignedExecutiveId);
            SqlParameter paramCaseReceivedMode = new SqlParameter("@CaseReceivedMode", CaseReceivedMode);

            SqlParameter paramCaseRecievedDateTime = new SqlParameter("@CaseRecievedDateTime", CaseRecievedDateTime);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCorporateBranchId = new SqlParameter("@CorporateBranchId", CorporateBranchId);
            SqlParameter paramServicesOffered = new SqlParameter("@ServicesOffered", ServicesOffered);
            SqlParameter paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramGenderId = new SqlParameter("@GenderId", GenderId);
            SqlParameter paramEMailId = new SqlParameter("@EMailId", EMailId);
            SqlParameter paramNoOfFreeConsultations = new SqlParameter("@NoOfFreeConsultations", NoOfFreeConsultations);
            SqlParameter paramNoOfConsultationReceived = new SqlParameter("@NoOfConsultationReceived", NoOfConsultationReceived);
            SqlParameter paramConsultationType = new SqlParameter("@ConsultationType", ConsultationType);
            SqlParameter paramCaseType = new SqlParameter("@CaseType", CaseType);
            SqlParameter paramPaymentType = new SqlParameter("@PaymentType", PaymentType);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            SqlParameter paramCustomerProfile = new SqlParameter("@CustomerProfile", CustomerProfile);

            SqlParameter paramPrefferedLanguage = new SqlParameter("@PrefferedLanguage", PrefferedLanguage);
            SqlParameter paramDoctorDateTime = new SqlParameter("@DoctorDateTime", DoctorDateTime);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramDoctorQualificationId = new SqlParameter("@DoctorQualificationId", DoctorQualificationId);
            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramFollowUpDataTime = new SqlParameter("@FollowUpDataTime", FollowUpDataTime);
            SqlParameter paramRemarks = new SqlParameter("@Remarks", Remarks);

            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);




            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseEntryDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramBranchId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCAssignedExecutiveId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseReceivedMode);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseRecievedDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCorporateId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCorporateBranchId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramServicesOffered);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEmployeeName);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramMobileNo);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramGenderId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEMailId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramNoOfFreeConsultations);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramNoOfConsultationReceived);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramPaymentType);


            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramConsultationType);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseType);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCustomerProfile);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseFor);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramPrefferedLanguage);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorQualificationId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramFollowUpDataTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramRemarks);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCreatedBy);


            IsDataExists = cmdInsertUpdateEConsultCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }


        public DataTable GenearateSpecialistConsultancyCaseId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseId = new SqlCommand("Exec proc_GenerateSpecialistConsultancyCaseId", con);

            SqlDataAdapter daCaseId = new SqlDataAdapter(cmdCaseId);
            DataTable dtCaseId = new DataTable();

            daCaseId.Fill(dtCaseId);

            return dtCaseId;
        }

        public DataTable LoadSpecialistConsultantCaseDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadSpecialistConsultantCaseDetails", con);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public DataTable LoadSpecialistConsultantCaseDetailsById(Int32 SpecialistConsultantCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadSpecialistConsultantCaseDetailsById @SpecialityConsultantCaseDetailsId", con);

            SqlParameter paramSpecialistConsultantCaseDetailsId = new SqlParameter("@SpecialityConsultantCaseDetailsId", SpecialistConsultantCaseDetailsId);
            cmdCaseDetails.Parameters.Add(paramSpecialistConsultantCaseDetailsId);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public void InsertUpdateSpecialityConsultantCaseDetails(Int32 SpecialityConsultantCaseDetailsId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
           Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
Int32 CorporateBranchId, Int32 ServicesOffered, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived,
Int32 ConsultationType, Int32 CaseType, int PaymentType, int CaseFor, int CustomerProfile, int PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateSpecialityConsultantCaseDetails = new SqlCommand("Exec proc_InsertUpdateSpecialityConsultantCaseDetails @SpecialityConsultantCaseDetailsId,@CaseId,@CaseEntryDateTime,@BranchId, @AssignedExecutiveId, @CaseReceivedMode, @CaseRecievedDateTime, @CorporateId,@CorporateBranchId,@ServicesOffered, @EmployeeName, @MobileNo, @GenderId, @EMailId, @NoOfFreeConsultations, @NoOfConsultationReceived,@ConsultationType,@CaseType, @PaymentType, @CaseFor, @CustomerProfile, @PrefferedLanguage, @DoctorDateTime, @DoctorId, @DoctorQualificationId,@CaseStatus, @FollowUpDateTime, @Remarks,@CreatedBy", con);

            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@SpecialityConsultantCaseDetailsId", SpecialityConsultantCaseDetailsId);
            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramCaseEntryDateTime = new SqlParameter("@CaseEntryDateTime", CaseEntryDateTime);
            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);
            SqlParameter paramCAssignedExecutiveId = new SqlParameter("@AssignedExecutiveId", AssignedExecutiveId);
            SqlParameter paramCaseReceivedMode = new SqlParameter("@CaseReceivedMode", CaseReceivedMode);

            SqlParameter paramCaseRecievedDateTime = new SqlParameter("@CaseRecievedDateTime", CaseRecievedDateTime);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCorporateBranchId = new SqlParameter("@CorporateBranchId", CorporateBranchId);
            SqlParameter paramServicesOffered = new SqlParameter("@ServicesOffered", ServicesOffered);
            SqlParameter paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramGenderId = new SqlParameter("@GenderId", GenderId);
            SqlParameter paramEMailId = new SqlParameter("@EMailId", EMailId);
            SqlParameter paramNoOfFreeConsultations = new SqlParameter("@NoOfFreeConsultations", NoOfFreeConsultations);
            SqlParameter paramNoOfConsultationReceived = new SqlParameter("@NoOfConsultationReceived", NoOfConsultationReceived);
            SqlParameter paramConsultationType = new SqlParameter("@ConsultationType", ConsultationType);
            SqlParameter paramCaseType = new SqlParameter("@CaseType", CaseType);
            SqlParameter paramPaymentType = new SqlParameter("@PaymentType", PaymentType);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            SqlParameter paramCustomerProfile = new SqlParameter("@CustomerProfile", CustomerProfile);

            SqlParameter paramPrefferedLanguage = new SqlParameter("@PrefferedLanguage", PrefferedLanguage);
            SqlParameter paramDoctorDateTime = new SqlParameter("@DoctorDateTime", DoctorDateTime);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramDoctorQualificationId = new SqlParameter("@DoctorQualificationId", DoctorQualificationId);
            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramFollowUpDateTime = new SqlParameter("@FollowUpDateTime", FollowUpDataTime);
            SqlParameter paramRemarks = new SqlParameter("@Remarks", Remarks);

            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);




            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseEntryDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramBranchId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCAssignedExecutiveId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseReceivedMode);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseRecievedDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCorporateId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCorporateBranchId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramServicesOffered);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEmployeeName);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramMobileNo);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramGenderId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEMailId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramNoOfFreeConsultations);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramNoOfConsultationReceived);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPaymentType);


            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramConsultationType);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseType);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCustomerProfile);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseFor);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPrefferedLanguage);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorQualificationId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramFollowUpDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramRemarks);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCreatedBy);


            IsDataExists = cmdInsertUpdateSpecialityConsultantCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }



        public DataTable LoadDistrictDropDown(int StateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDistrict = new SqlCommand("Exec proc_LoadDistrictByState @StateId", con);

            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);
            cmdLoadDistrict.Parameters.Add(paramStateId);


            SqlDataAdapter daLoadDistrict = new SqlDataAdapter(cmdLoadDistrict);
            DataTable dtDistrict = new DataTable();
            daLoadDistrict.Fill(dtDistrict);
            con.Close();
            con.Dispose();
            return dtDistrict;
        }

        public DataTable LoadMasterLanguageDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLanguage = new SqlCommand("Exec proc_FetchLanguageDropDown", con);



            SqlDataAdapter dalanguage = new SqlDataAdapter(cmdLanguage);
            DataTable dtLanguage = new DataTable();
            dalanguage.Fill(dtLanguage);
            con.Close();
            con.Dispose();
            return dtLanguage;

        }

        public DataTable LoadEConsultantAppointmentDeails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEConsultantAppointmentDetails = new SqlCommand("Exec proc_LoadEConsultantAppointmentDeails", con);



            SqlDataAdapter daEConsultantAppointmentDetails = new SqlDataAdapter(cmdEConsultantAppointmentDetails);
            DataTable dtEConsultantAppointmentDetails = new DataTable();
            daEConsultantAppointmentDetails.Fill(dtEConsultantAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtEConsultantAppointmentDetails;

        }

        public DataTable LoadEConsultantAppointmentDeailsById(Int32 EConsultantAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEConsultantAppointmentDetails = new SqlCommand("Exec proc_LoadEConsultantAppointmentDeailsById @EConsultantAppointmentDetailsId", con);

            SqlParameter paramEConsultantAppointmentDetailsId = new SqlParameter("@EConsultantAppointmentDetailsId", EConsultantAppointmentDetailsId);

            cmdEConsultantAppointmentDetails.Parameters.Add(paramEConsultantAppointmentDetailsId);

            SqlDataAdapter daEConsultantAppointmentDetails = new SqlDataAdapter(cmdEConsultantAppointmentDetails);
            DataTable dtEConsultantAppointmentDetails = new DataTable();
            daEConsultantAppointmentDetails.Fill(dtEConsultantAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtEConsultantAppointmentDetails;

        }

        public void InsertUpdateEConsultantDoctorAppointment(Int32 EConsultantAppointmentDetailsId, Int32 EConsultantCaseDetailsId, Int32 DoctorId, DateTime? AppointmentDateTime, Int32 AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateEConsultCaseDetails = new SqlCommand("Exec proc_InsertUpdateEConsultantDoctorAppointment @EConsultantAppointmentDetailsId,@EConsultantCaseDetailsId, @DoctorId, @AppointmentDateTime,@AppointmentStatus,@CaseStatus,@ReportStatus", con);

            SqlParameter paramEConsultantAppointmentDetailsId = new SqlParameter("@EConsultantAppointmentDetailsId", EConsultantAppointmentDetailsId);
            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@EConsultantCaseDetailsId", EConsultantCaseDetailsId);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramAppointmentDateTime = new SqlParameter("@AppointmentDateTime", AppointmentDateTime);
            SqlParameter paramAppointmentStatus = new SqlParameter("@AppointmentStatus", AppointmentStatus);


            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramReportStatus = new SqlParameter("@ReportStatus", ReportStatus);

            //SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);




            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantAppointmentDetailsId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentStatus);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramReportStatus);

            //cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCreatedBy);


            IsDataExists = cmdInsertUpdateEConsultCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }






        public DataTable LoadSpecialistConsultantAppointmentDeails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSpecialistConsultantAppointmentDetails = new SqlCommand("Exec proc_LoadSpecailistConsultantAppointmentDeails", con);



            SqlDataAdapter daSpecialistConsultantAppointmentDetails = new SqlDataAdapter(cmdSpecialistConsultantAppointmentDetails);
            DataTable dtSpecialistConsultantAppointmentDetails = new DataTable();
            daSpecialistConsultantAppointmentDetails.Fill(dtSpecialistConsultantAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtSpecialistConsultantAppointmentDetails;

        }

        public DataTable LoadSpecialistConsultantAppointmentDeailsById(Int32 SpecialistConsultantAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSpecialistConsultantAppointmentDetails = new SqlCommand("Exec proc_LoadSpecialistConsultantAppointmentDeailsById @SpecialistConsultantAppointmentDetailsId", con);

            SqlParameter paramSpecialistConsultantAppointmentDetailsId = new SqlParameter("@SpecialistConsultantAppointmentDetailsId", SpecialistConsultantAppointmentDetailsId);

            cmdSpecialistConsultantAppointmentDetails.Parameters.Add(paramSpecialistConsultantAppointmentDetailsId);

            SqlDataAdapter daSpecialistConsultantAppointmentDetails = new SqlDataAdapter(cmdSpecialistConsultantAppointmentDetails);
            DataTable dtSpecialistConsultantAppointmentDetails = new DataTable();
            daSpecialistConsultantAppointmentDetails.Fill(dtSpecialistConsultantAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtSpecialistConsultantAppointmentDetails;

        }

        public void InsertUpdateSpecialistConsultantDoctorAppointment(Int32 SpecialistConsultantAppointmentDetailsId, Int32 SpecialistConsultantCaseDetailsId, Int32 DoctorId, DateTime? AppointmentDateTime, int AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateEConsultCaseDetails = new SqlCommand("Exec proc_InsertUpdateSpecialistConsultantDoctorAppointment @SpecialistConsultantAppointmentDetailsId,@SpecialityConsultantCaseDetailsId, @DoctorId, @AppointmentDateTime,@AppointmentStatus,@CaseStatus,@ReportStatus", con);

            SqlParameter paramEConsultantAppointmentDetailsId = new SqlParameter("@SpecialistConsultantAppointmentDetailsId", SpecialistConsultantAppointmentDetailsId);
            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@SpecialityConsultantCaseDetailsId", SpecialistConsultantCaseDetailsId);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramAppointmentDateTime = new SqlParameter("@AppointmentDateTime", AppointmentDateTime);
            SqlParameter paramAppointmentStatus = new SqlParameter("@AppointmentStatus", AppointmentStatus);

            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramReportStatus = new SqlParameter("@ReportStatus", ReportStatus);

            //SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);




            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantAppointmentDetailsId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentStatus);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramReportStatus);

            //cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCreatedBy);


            IsDataExists = cmdInsertUpdateEConsultCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }


        public int CheckAppointment(Int32 EConsultantCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCheck = new SqlCommand("Exec proc_CheckEConsultantAppointment @EConsultantCaseDetailsId", con);
            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@EConsultantCaseDetailsId", EConsultantCaseDetailsId);

            cmdCheck.Parameters.Add(paramEConsultantCaseDetailsId);

            int result = Convert.ToInt32(cmdCheck.ExecuteScalar());
            con.Close();
            con.Dispose();
            return result;


        }

        public int CheckSpecialistAppointment(Int32 SpecialistConsultantCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCheck = new SqlCommand("Exec proc_CheckSpecialistConsultantAppointment  @SpecialistConsultantCaseDetailsId", con);
            SqlParameter paramSpecialistConsultantCaseDetailsId = new SqlParameter("@SpecialistConsultantCaseDetailsId", SpecialistConsultantCaseDetailsId);

            cmdCheck.Parameters.Add(paramSpecialistConsultantCaseDetailsId);

            int result = Convert.ToInt32(cmdCheck.ExecuteScalar());
            con.Close();
            con.Dispose();
            return result;


        }

        public DataTable LoadEConsultantCloseAppointmentDeails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEConsultantCloseAppointmentDetails = new SqlCommand("Exec proc_LoadEConsultantCloseAppointmentDeails", con);



            SqlDataAdapter daEConsultantCloseAppointmentDetails = new SqlDataAdapter(cmdEConsultantCloseAppointmentDetails);
            DataTable dtEConsultantCloseAppointmentDetails = new DataTable();
            daEConsultantCloseAppointmentDetails.Fill(dtEConsultantCloseAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtEConsultantCloseAppointmentDetails;

        }

        public DataTable LoadSpecialistConsultantCloseAppointmentDeails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSpecialistConsultantAppointmentDetails = new SqlCommand("Exec proc_LoadSpecailistConsultantCloseAppointmentDeails", con);



            SqlDataAdapter daSpecialistConsultantAppointmentDetails = new SqlDataAdapter(cmdSpecialistConsultantAppointmentDetails);
            DataTable dtSpecialistConsultantAppointmentDetails = new DataTable();
            daSpecialistConsultantAppointmentDetails.Fill(dtSpecialistConsultantAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtSpecialistConsultantAppointmentDetails;

        }

        public DataTable SearchPackageDetails(string SKUCode, string PackageName, string CorporateName, string SearchType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearch = new SqlCommand("Exec proc_SearchPackageDetails @SKUCode,@PackageName,@CorporateName,@SearchType", con);

            SqlParameter paramSKUCode = new SqlParameter("@SKUCode", SKUCode);
            SqlParameter paramPackageName = new SqlParameter("@PackageName", PackageName);
            SqlParameter paramCorporateName = new SqlParameter("@CorporateName", CorporateName);
            SqlParameter paramSearchType = new SqlParameter("@SearchType", SearchType);

            cmdSearch.Parameters.Add(paramSKUCode);
            cmdSearch.Parameters.Add(paramPackageName);
            cmdSearch.Parameters.Add(paramCorporateName);
            cmdSearch.Parameters.Add(paramSearchType);

            SqlDataAdapter daPackageDetails = new SqlDataAdapter(cmdSearch);
            DataTable dtPackageDetails = new DataTable();
            daPackageDetails.Fill(dtPackageDetails);
            con.Close();
            con.Dispose();
            return dtPackageDetails;
        }

        public DataTable SearchEConsultantCaseDetails(string CaseId, Int32 CorporateId, Int32 BranchId, string EmployeeName, string MobileNo, string EmailId, Int32 ConsultationType, Int32 DoctorId,
            Int32 CaseStatus, string SearchType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearch = new SqlCommand("Exec proc_SearchEConsultantCaseDetails @CaseId,@CorporateId,@BranchId,@EmployeeName,@MobileNo,@EmailId,@ConsultationType,@DoctorId,@CaseStatus,@SearchType", con);

            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);
            SqlParameter paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);
            SqlParameter paramConsultationType = new SqlParameter("@ConsultationType", ConsultationType);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);

            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramSearchType = new SqlParameter("@SearchType", SearchType);

            cmdSearch.Parameters.Add(paramCaseId);
            cmdSearch.Parameters.Add(paramCorporateId);

            cmdSearch.Parameters.Add(paramBranchId);
            cmdSearch.Parameters.Add(paramEmployeeName);
            cmdSearch.Parameters.Add(paramMobileNo);
            cmdSearch.Parameters.Add(paramEmailId);
            cmdSearch.Parameters.Add(paramConsultationType);
            cmdSearch.Parameters.Add(paramDoctorId);

            cmdSearch.Parameters.Add(paramCaseStatus);

            cmdSearch.Parameters.Add(paramSearchType);

            SqlDataAdapter daPackageDetails = new SqlDataAdapter(cmdSearch);
            DataTable dtPackageDetails = new DataTable();
            daPackageDetails.Fill(dtPackageDetails);
            con.Close();
            con.Dispose();
            return dtPackageDetails;
        }

        public DataTable SearchSpecialitiesConsultantCaseDetails(string CaseId, string CorporateName, string CaseStatus, string SearchType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearch = new SqlCommand("Exec proc_SearchSpecialistConsultantCaseDetails @CaseId,@CorporateName,@CaseStatus,@SearchType", con);

            SqlParameter paramSKUCode = new SqlParameter("@CaseId", CaseId);

            SqlParameter paramCorporateName = new SqlParameter("@CorporateName", CorporateName);
            SqlParameter paramPackageName = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramSearchType = new SqlParameter("@SearchType", SearchType);

            cmdSearch.Parameters.Add(paramSKUCode);
            cmdSearch.Parameters.Add(paramPackageName);
            cmdSearch.Parameters.Add(paramCorporateName);
            cmdSearch.Parameters.Add(paramSearchType);

            SqlDataAdapter daPackageDetails = new SqlDataAdapter(cmdSearch);
            DataTable dtPackageDetails = new DataTable();
            daPackageDetails.Fill(dtPackageDetails);
            con.Close();
            con.Dispose();
            return dtPackageDetails;
        }

        public DataTable LoadTestDropDown()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestDetailsList = new SqlCommand("Exec proc_LoadTestDropDown", con);

            SqlDataAdapter daLoadTestDetailsList = new SqlDataAdapter(cmdLoadTestDetailsList);
            DataTable dtLoadTestDetailsList = new DataTable();

            daLoadTestDetailsList.Fill(dtLoadTestDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestDetailsList;

        }

        public DataTable LoadProductDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductDetails = new SqlCommand("Exec proc_LoadProductDetails", con);

            SqlDataAdapter daLoadProductDetails = new SqlDataAdapter(cmdLoadProductDetails);
            DataTable dtProductDetails = new DataTable();
            daLoadProductDetails.Fill(dtProductDetails);
            return dtProductDetails;
        }

        public DataTable LoadProductDetailsById(int ProductId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductDetails = new SqlCommand("Exec proc_LoadProductDetailsById @ProductId", con);

            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);

            cmdLoadProductDetails.Parameters.Add(paramProductId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadProductDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataTable LoadProductDetailsDropDown()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestDetailsList = new SqlCommand("Exec proc_LoadProductDetailsDropDown", con);

            SqlDataAdapter daLoadTestDetailsList = new SqlDataAdapter(cmdLoadTestDetailsList);
            DataTable dtLoadTestDetailsList = new DataTable();

            daLoadTestDetailsList.Fill(dtLoadTestDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestDetailsList;

        }

        public void InsertUpdateProduct(Int32 ProductId, String ProductName, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateProduct = new SqlCommand("Exec proc_InsertUpdateProduct @ProductId,@ProductName,@IsActive", con);

            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);
            SqlParameter paramProductName = new SqlParameter("@ProductName", ProductName);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateProduct.Parameters.Add(paramProductId);
            cmdInsertUpdateProduct.Parameters.Add(paramProductName);
            cmdInsertUpdateProduct.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateProduct.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadProductSubCategory()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductSubCategory = new SqlCommand("Exec proc_LoadProductSubCategoryDetails", con);



            SqlDataAdapter daLoadProductSubCategory = new SqlDataAdapter(cmdLoadProductSubCategory);
            DataTable dtLoadProductSubCategory = new DataTable();
            daLoadProductSubCategory.Fill(dtLoadProductSubCategory);
            con.Close();
            con.Dispose();
            return dtLoadProductSubCategory;
        }

        public DataTable LoadProductSubCategoryById(int SubProductId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductSubCategory = new SqlCommand("Exec proc_LoadProductSubCategoryDetailsById @SubProductId", con);

            SqlParameter paramSubProductId = new SqlParameter("@SubProductId", SubProductId);
            cmdLoadProductSubCategory.Parameters.Add(paramSubProductId);


            SqlDataAdapter daLoadProductSubCategory = new SqlDataAdapter(cmdLoadProductSubCategory);
            DataTable dtLoadProductSubCategory = new DataTable();
            daLoadProductSubCategory.Fill(dtLoadProductSubCategory);
            con.Close();
            con.Dispose();
            return dtLoadProductSubCategory;
        }

        public void InsertUpdateProductSubCategory(Int32 SubProductId, Int32 ProductId, string SubProductCategory, string NormalPrice, string HNIPrice, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductSubCategory = new SqlCommand("Exec proc_InsertUpdateProductSubCategory @SubProductId, @ProductId, @SubProductCategory, @NormalPrice, @HNIPrice, @IsActive", con);

            SqlParameter paramSubProductId = new SqlParameter("@SubProductId", SubProductId);
            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);
            SqlParameter paramSubProductCategory = new SqlParameter("@SubProductCategory", SubProductCategory);
            SqlParameter paramNormalPrice = new SqlParameter("@NormalPrice", NormalPrice);
            SqlParameter paramHNIPrice = new SqlParameter("@HNIPrice", HNIPrice);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdLoadProductSubCategory.Parameters.Add(paramSubProductId);
            cmdLoadProductSubCategory.Parameters.Add(paramProductId);
            cmdLoadProductSubCategory.Parameters.Add(paramSubProductCategory);
            cmdLoadProductSubCategory.Parameters.Add(paramNormalPrice);
            cmdLoadProductSubCategory.Parameters.Add(paramHNIPrice);

            cmdLoadProductSubCategory.Parameters.Add(paramIsActive);

            IsDataExists = cmdLoadProductSubCategory.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadProductSubCategoryDropDown(int ProductId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductSubCategory = new SqlCommand("Exec proc_LoadSubCategoryByProduct @ProductId", con);

            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);
            cmdLoadProductSubCategory.Parameters.Add(paramProductId);


            SqlDataAdapter daLoadProductSubCategory = new SqlDataAdapter(cmdLoadProductSubCategory);
            DataTable dtLoadProductSubCategory = new DataTable();
            daLoadProductSubCategory.Fill(dtLoadProductSubCategory);
            con.Close();
            con.Dispose();
            return dtLoadProductSubCategory;
        }

        public DataSet LoadProductServicesForAssign()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductServices = new SqlCommand("Exec proc_LoadProductServicesForAssign", con);

            SqlDataAdapter daLoadProductServices = new SqlDataAdapter(cmdLoadProductServices);
            DataSet dtLoadProductServices = new DataSet();
            daLoadProductServices.Fill(dtLoadProductServices);
            con.Close();
            con.Dispose();
            return dtLoadProductServices;
        }

        public void InsertUpdateServicesAssigned(Int32 ProductAssignedId, Int32 LoginTypeId, Int32 CorporateId, Int32 BranchId, string ProductId, string SubProductId, DateTime? CreatedOn, Int32 CreatedBy, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateServicesAssigned = new SqlCommand("InsertUpdateServicesAssigned", con);
            cmdInsertUpdateServicesAssigned.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@ProductAssignedId", ProductAssignedId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@LoginTypeId", LoginTypeId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@BranchId", BranchId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@ProductId", ProductId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@SubProductId", SubProductId);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdInsertUpdateServicesAssigned.Parameters.AddWithValue("@IsActive", IsActive);

            IsDataExists = cmdInsertUpdateServicesAssigned.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadAssignServicesList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadAssignServices = new SqlCommand("Exec proc_LoadAssignDetails", con);

            SqlDataAdapter daLoadAssignServices = new SqlDataAdapter(cmdLoadAssignServices);
            DataTable dtLoadAssignServices = new DataTable();

            daLoadAssignServices.Fill(dtLoadAssignServices);

            con.Close();
            con.Dispose();

            return dtLoadAssignServices;

        }

        public DataSet LoadAssignServicesListById(int ProductAssignedId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadAssignServices = new SqlCommand("Exec proc_LoadAssignDetailsById @ProductAssignedId", con);

            SqlParameter paramServicesId = new SqlParameter("@ProductAssignedId", ProductAssignedId);

            cmdLoadAssignServices.Parameters.Add(paramServicesId);

            SqlDataAdapter daLoadAssignServices = new SqlDataAdapter(cmdLoadAssignServices);
            DataSet dtLoadAssignServices = new DataSet();
            daLoadAssignServices.Fill(dtLoadAssignServices);
            return dtLoadAssignServices;
        }


        public DataTable LoadEConsultantTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEConsultantType = new SqlCommand("Exec proc_LoadEConsultationType", con);

            SqlDataAdapter daEConsultantType = new SqlDataAdapter(cmdEConsultantType);
            DataTable dtEConsultationType = new DataTable();
            daEConsultantType.Fill(dtEConsultationType);
            con.Close();
            con.Dispose();
            return dtEConsultationType;
        }

        public DataTable LoadCustomerProfileDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCustomerProfile = new SqlCommand("Exec proc_LoadCustomerProfileDropDown", con);

            SqlDataAdapter daCustomerProfile = new SqlDataAdapter(cmdCustomerProfile);
            DataTable dtCustomerprofile = new DataTable();
            daCustomerProfile.Fill(dtCustomerprofile);
            con.Close();
            con.Dispose();
            return dtCustomerprofile;
        }

        public DataTable LoadPaymentTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdPaymentType = new SqlCommand("Exec proc_LoadPaymentTypeDropDown", con);

            SqlDataAdapter daPaymentType = new SqlDataAdapter(cmdPaymentType);
            DataTable dtPaymentType = new DataTable();
            daPaymentType.Fill(dtPaymentType);
            con.Close();
            con.Dispose();
            return dtPaymentType;
        }

        public DataTable LoadCaseReceivedModeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseReceivedMode = new SqlCommand("Exec proc_LoadCaseReceivedModeDropDown", con);

            SqlDataAdapter daCaseReceivedMode = new SqlDataAdapter(cmdCaseReceivedMode);
            DataTable dtCaseReceivedMode = new DataTable();
            daCaseReceivedMode.Fill(dtCaseReceivedMode);
            con.Close();
            con.Dispose();
            return dtCaseReceivedMode;
        }

        public DataTable GenerateConsultationCaseId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseId = new SqlCommand("Exec proc_GenerateConsultationCaseId", con);

            SqlDataAdapter daCaseId = new SqlDataAdapter(cmdCaseId);
            DataTable dtCaseId = new DataTable();

            daCaseId.Fill(dtCaseId);

            return dtCaseId;
        }

        public DataTable GenerateCaseId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseId = new SqlCommand("Exec proc_GenerateCaseId", con);

            SqlDataAdapter daCaseId = new SqlDataAdapter(cmdCaseId);
            DataTable dtCaseId = new DataTable();

            daCaseId.Fill(dtCaseId);

            return dtCaseId;
        }

        public DataTable LoadConsultationCaseDetailsById(Int32 ConsultantCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadConsultationCaseDetailsById @ConsultationCaseDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultantCaseDetailsId);
            cmdCaseDetails.Parameters.Add(paramConsultationCaseDetailsId);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public void InsertUpdateConsultationCaseDetails(Int32 ConsultationCaseDetailsId, int ConsultationCaseTypeId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
            Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
 Int32 CorporateBranchId, Int32 ServicesOffered, Int32 EmployeeRefId, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived, int IdProof, int State, int City, string CustomerPrefferedLanguage, DateTime? DOB,
 Int32 ConsultationType, Int32 CaseType, int PaymentType, int PaymentStatus, int CaseFor, int CustomerProfile, string PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
 int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, string ApplicationNo, string ActionPerformed, out string IsDataExists)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateSpecialityConsultantCaseDetails = new SqlCommand("Exec proc_InsertUpdateConsultationCaseDetails @ConsultationCaseDetailsId,@ConsultationCaseTypeId,@CaseId,@CaseEntryDateTime,@BranchId, @AssignedExecutiveId, @CaseReceivedMode, @CaseRecievedDateTime, @CorporateId,@CorporateBranchId,@ServicesOffered,@EmployeeRefId, @EmployeeName, @MobileNo, @GenderId, @EMailId, @NoOfFreeConsultations, @NoOfConsultationReceived,@Idproof,@State,@City,@CustomerPrefferedLanguage,@DOB,@ConsultationType,@CaseType, @PaymentType,@PaymentStatus, @CaseFor, @CustomerProfile, @PrefferedLanguage, @DoctorId, @DoctorQualificationId,@CaseStatus, @FollowUpDateTime, @Remarks,@CreatedBy,@ApplicationNo,@ActionPerformed", con);

            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramConsultationCaseTypeId = new SqlParameter("@ConsultationCaseTypeId", ConsultationCaseTypeId);
            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramCaseEntryDateTime = new SqlParameter("@CaseEntryDateTime", CaseEntryDateTime);
            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);
            SqlParameter paramCAssignedExecutiveId = new SqlParameter("@AssignedExecutiveId", AssignedExecutiveId);
            SqlParameter paramCaseReceivedMode = new SqlParameter("@CaseReceivedMode", CaseReceivedMode);

            SqlParameter paramCaseRecievedDateTime = new SqlParameter("@CaseRecievedDateTime", CaseRecievedDateTime);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCorporateBranchId = new SqlParameter("@CorporateBranchId", CorporateBranchId);
            SqlParameter paramServicesOffered = new SqlParameter("@ServicesOffered", ServicesOffered);
            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramGenderId = new SqlParameter("@GenderId", GenderId);
            SqlParameter paramEMailId = new SqlParameter("@EMailId", EMailId);
            SqlParameter paramNoOfFreeConsultations = new SqlParameter("@NoOfFreeConsultations", NoOfFreeConsultations);
            SqlParameter paramNoOfConsultationReceived = new SqlParameter("@NoOfConsultationReceived", NoOfConsultationReceived);

            SqlParameter paramIdProof = new SqlParameter("@IdProof", IdProof);
            SqlParameter paramState = new SqlParameter("@State", State);
            SqlParameter paramCity = new SqlParameter("@City", City);
            SqlParameter paramCustomerPrefferedLanguage = new SqlParameter("@CustomerPrefferedLanguage", CustomerPrefferedLanguage);
            SqlParameter paramDOB = new SqlParameter("@DOB", DOB);



            SqlParameter paramConsultationType = new SqlParameter("@ConsultationType", ConsultationType);
            SqlParameter paramCaseType = new SqlParameter("@CaseType", CaseType);
            SqlParameter paramPaymentType = new SqlParameter("@PaymentType", PaymentType);
            SqlParameter paramPaymentStatus = new SqlParameter("@PaymentStatus", PaymentStatus);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            SqlParameter paramCustomerProfile = new SqlParameter("@CustomerProfile", CustomerProfile);

            SqlParameter paramPrefferedLanguage = new SqlParameter("@PrefferedLanguage", PrefferedLanguage);
            //SqlParameter paramDoctorDateTime = new SqlParameter("@DoctorDateTime", DoctorDateTime);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramDoctorQualificationId = new SqlParameter("@DoctorQualificationId", DoctorQualificationId);
            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramFollowUpDateTime = new SqlParameter("@FollowUpDateTime", FollowUpDataTime);
            SqlParameter paramRemarks = new SqlParameter("@Remarks", Remarks);

            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);
            SqlParameter paramApplicationNo = new SqlParameter("@ApplicationNo", ApplicationNo);
            SqlParameter paramActionPerformed = new SqlParameter("@ActionPerformed", ActionPerformed);




            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramConsultationCaseTypeId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseEntryDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramBranchId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCAssignedExecutiveId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseReceivedMode);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseRecievedDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCorporateId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCorporateBranchId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramServicesOffered);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEmployeeRefId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEmployeeName);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramMobileNo);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramGenderId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEMailId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramNoOfFreeConsultations);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramNoOfConsultationReceived);


            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramIdProof);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramState);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCity);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCustomerPrefferedLanguage);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDOB);




            //            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPaymentType);


            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramConsultationType);

            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseType);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPaymentType);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPaymentStatus);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCustomerProfile);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseFor);


            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramPrefferedLanguage);
            //cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDoctorQualificationId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramFollowUpDateTime);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramRemarks);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCreatedBy);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramApplicationNo);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramActionPerformed);


            IsDataExists = cmdInsertUpdateSpecialityConsultantCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }

        public DataTable FetchEmployeeDetailsonCorporateId(Int32 CorporateId, Int32 BranchId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdFetchEmployeeDetails = new SqlCommand("Exec proc_FetchEmployeeDetailsOnCorporateId @CorporateId, @BranchId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);

            cmdFetchEmployeeDetails.Parameters.Add(paramCorporateId);
            cmdFetchEmployeeDetails.Parameters.Add(paramBranchId);

            SqlDataAdapter daEmployeeDetails = new SqlDataAdapter(cmdFetchEmployeeDetails);
            DataTable dtEmployeeDetails = new DataTable();

            daEmployeeDetails.Fill(dtEmployeeDetails);
            con.Close();
            con.Dispose();
            return dtEmployeeDetails;
        }

        public DataTable LoadEmployeeDetailsById(Int32 EmployeeRefId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadEmployeeDetails = new SqlCommand("Exec proc_LoadEmployeeDetailsById  @EmployeeRefId", con);



            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);

            cmdLoadEmployeeDetails.Parameters.Add(paramEmployeeRefId);

            SqlDataAdapter daLoadEmployeeDetails = new SqlDataAdapter(cmdLoadEmployeeDetails);
            DataTable dtLoadEmployeeDetails = new DataTable();
            daLoadEmployeeDetails.Fill(dtLoadEmployeeDetails);
            return dtLoadEmployeeDetails;
        }

        public DataTable SearchEmployeeDetails(string EmployeeName, string MobileNo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearchEmployeeDetails = new SqlCommand("Exec proc_SearchEmployeeDetails  @EmployeeName, @MobileNo", con);

            SqlParameter paramEmployeeName;
            SqlParameter paramMobileNo;

            if (!EmployeeName.Equals(""))
            {
                paramEmployeeName = new SqlParameter("@EmployeeName", EmployeeName);
            }
            else
            {
                paramEmployeeName = new SqlParameter("@EmployeeName", DBNull.Value);
            }

            if (!MobileNo.Equals(""))
            {
                paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            }
            else
            {
                paramMobileNo = new SqlParameter("@MobileNo", DBNull.Value);
            }

            
            cmdSearchEmployeeDetails.Parameters.Add(paramEmployeeName);
            cmdSearchEmployeeDetails.Parameters.Add(paramMobileNo);


            SqlDataAdapter daSearchEmployeeDetails = new SqlDataAdapter(cmdSearchEmployeeDetails);
            DataTable dtSearchEmployeeDetails = new DataTable();
            daSearchEmployeeDetails.Fill(dtSearchEmployeeDetails);
            return dtSearchEmployeeDetails;
        }

        public DataTable LoadConsultationCaseAppointmentDeailsById(Int32 ConsultationCaseAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdConsultationCaseAppointmentDetails = new SqlCommand("Exec proc_LoadConsultationCaseAppointmentDeailsById @ConsultationCaseAppointmentDetailsId", con);

            SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);

            cmdConsultationCaseAppointmentDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);

            SqlDataAdapter daConsultationCaseAppointmentDetails = new SqlDataAdapter(cmdConsultationCaseAppointmentDetails);
            DataTable dtConsultationCaseAppointmentDetails = new DataTable();
            daConsultationCaseAppointmentDetails.Fill(dtConsultationCaseAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtConsultationCaseAppointmentDetails;

        }

        public DataTable LoadConsultationCaseAppointmentDeails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdConsultationCaseAppointmentDetails = new SqlCommand("Exec proc_LoadConsultationCaseAppointmentDeails @EmployeeRefId,@RoleId,@LoginType", con);

            //  SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);

            //cmdConsultationCaseAppointmentDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);

            cmdConsultationCaseAppointmentDetails.Parameters.Add(paramEmployeeRefId);
            cmdConsultationCaseAppointmentDetails.Parameters.Add(paramRoleId);
            cmdConsultationCaseAppointmentDetails.Parameters.Add(paramLoginType);

            SqlDataAdapter daConsultationCaseAppointmentDetails = new SqlDataAdapter(cmdConsultationCaseAppointmentDetails);
            DataTable dtConsultationCaseAppointmentDetails = new DataTable();
            daConsultationCaseAppointmentDetails.Fill(dtConsultationCaseAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtConsultationCaseAppointmentDetails;

        }

        public void InsertUpdateConsultationCaseDoctorAppointment(Int32 ConsultationCaseAppointmentDetailsId, Int32 ConsultationCaseDetailsId, Int32 DoctorId, DateTime? AppointmentDateTime, Int32 AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus, int IsActive, out string IsDataExists,string ActionPerformed)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateEConsultCaseDetails = new SqlCommand("Exec proc_InsertUpdateConsultationCaseDoctorAppointment @ConsultationCaseAppointmentDetailsId,@ConsultationCaseDetailsId, @DoctorId, @AppointmentDateTime,@AppointmentStatus,@CaseStatus,@ReportStatus,@IsActive,@CreatedBy,@ActionPerformed", con);

            SqlParameter paramEConsultantAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);
            SqlParameter paramEConsultantCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);
            SqlParameter paramAppointmentDateTime = new SqlParameter("@AppointmentDateTime", AppointmentDateTime);
            SqlParameter paramAppointmentStatus = new SqlParameter("@AppointmentStatus", AppointmentStatus);


            SqlParameter paramCaseStatus = new SqlParameter("@CaseStatus", CaseStatus);
            SqlParameter paramReportStatus = new SqlParameter("@ReportStatus", ReportStatus);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);
            SqlParameter paramActionPerformed = new SqlParameter("@ActionPerformed", ActionPerformed);




            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantCaseDetailsId);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramEConsultantAppointmentDetailsId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramDoctorId);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentDateTime);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramAppointmentStatus);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCaseStatus);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramReportStatus);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramIsActive);

            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramCreatedBy);
            cmdInsertUpdateEConsultCaseDetails.Parameters.Add(paramActionPerformed);


            IsDataExists = cmdInsertUpdateEConsultCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }


        public DataTable LoadConsultationCaseDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseDetails = new SqlCommand("Exec proc_LoadConsultationCaseDetails @EmployeeRefId,@RoleId,@LoginType", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);

            cmdCaseDetails.Parameters.Add(paramEmployeeRefId);
            cmdCaseDetails.Parameters.Add(paramRoleId);
            cmdCaseDetails.Parameters.Add(paramLoginType);

            SqlDataAdapter daCaseDetails = new SqlDataAdapter(cmdCaseDetails);
            DataTable dtCaseDetails = new DataTable();

            daCaseDetails.Fill(dtCaseDetails);

            return dtCaseDetails;
        }

        public DataTable LoadQualificationDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadQualificationDetails = new SqlCommand("Exec proc_LoadQualificationDetails", con);

            SqlDataAdapter daLoadQualificationDetails = new SqlDataAdapter(cmdLoadQualificationDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadQualificationDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataTable LoadQualificationDetailsDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadQualificationDetailsDropDown", con);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            con.Close();
            con.Dispose();
            return dtStateDetails;
        }

        public DataTable LoadQualificationDetailsById(int StateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadQualificationDetails = new SqlCommand("Exec proc_LoadQualificationDetailsById @DoctorQualificationId", con);

            SqlParameter paramQualificationId = new SqlParameter("@DoctorQualificationId", StateId);

            cmdLoadQualificationDetails.Parameters.Add(paramQualificationId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadQualificationDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public void InsertUpdateQualification(Int32 DoctorQualificationId, String Qualification, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateState = new SqlCommand("Exec proc_InsertUpdateQualification @DoctorQualificationId,@Qualification,@IsActive", con);

            SqlParameter paramDoctorQualificationId = new SqlParameter("@DoctorQualificationId", DoctorQualificationId);
            SqlParameter paramQualification = new SqlParameter("@Qualification", Qualification);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateState.Parameters.Add(paramDoctorQualificationId);
            cmdInsertUpdateState.Parameters.Add(paramQualification);
            cmdInsertUpdateState.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateState.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataSet LoadBProductListById(int CorporateId, int BranchId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductDetails = new SqlCommand("Exec proc_LoadBProductListForCorporate @CorporateId, @BranchId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramBranchId = new SqlParameter("@BranchId", BranchId);

            cmdLoadProductDetails.Parameters.Add(paramCorporateId);
            cmdLoadProductDetails.Parameters.Add(paramBranchId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadProductDetails);
            DataSet dtStateDetails = new DataSet();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataSet LoadProductListForEmployee(string ProductId, string ServicesAssigned)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductDetails = new SqlCommand("Exec proc_LoadProductListForEmployee @ProductId, @ServicesAssigned", con);

            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);
            SqlParameter paramSubProductId = new SqlParameter("@ServicesAssigned", ServicesAssigned);

            cmdLoadProductDetails.Parameters.Add(paramProductId);
            cmdLoadProductDetails.Parameters.Add(paramSubProductId);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadProductDetails);
            DataSet dtStateDetails = new DataSet();
            daLoadStateDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataTable LoadCorporateBranchList(Int32 CorporateId)
        {

            DataTable dtCorporateBranchDetails = new DataTable();

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchCorporateBranchList = new SqlCommand("proc_LoadBranchListForCorporate", con);
            cmdFetchCorporateBranchList.CommandType = CommandType.StoredProcedure;
            cmdFetchCorporateBranchList.Parameters.AddWithValue("@Action", "BranchList");

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdFetchCorporateBranchList.Parameters.Add(paramCorporateId);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchCorporateBranchList);


            daFetchServiceProviderDetails.Fill(dtCorporateBranchDetails);
            con.Close();
            con.Dispose();
            return dtCorporateBranchDetails;




        }


        public DataTable LoadConsultationCaseClosedAppointmentDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdConsultationCaseClosedAppointmentDetails = new SqlCommand("Exec proc_LoadConsultationCaseClosedAppointmentDeails", con);



            SqlDataAdapter daConsultantionCaseClosedAppointmentDetails = new SqlDataAdapter(cmdConsultationCaseClosedAppointmentDetails);
            DataTable dtConsultationCaseClosedAppointmentDetails = new DataTable();
            daConsultantionCaseClosedAppointmentDetails.Fill(dtConsultationCaseClosedAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtConsultationCaseClosedAppointmentDetails;

        }

        public DataTable LoadConsultationCaseServices(Int32 ConsultationType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdConsultationCaseServices = new SqlCommand("Exec proc_LoadConsultationCaseServices @ConsultationTypeId", con);

            SqlParameter paramConsultationTypeId = new SqlParameter("@ConsultationTypeId", ConsultationType);

            cmdConsultationCaseServices.Parameters.Add(paramConsultationTypeId);

            SqlDataAdapter daConsultantionCaseServices = new SqlDataAdapter(cmdConsultationCaseServices);
            DataTable dtConsultationCaseServices = new DataTable();
            daConsultantionCaseServices.Fill(dtConsultationCaseServices);
            con.Close();
            con.Dispose();
            return dtConsultationCaseServices;

        }

        public DataTable LoadDoctorQualificationDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdQualification = new SqlCommand("Exec proc_LoadDoctorQualificationDropDown", con);



            SqlDataAdapter daQualification = new SqlDataAdapter(cmdQualification);
            DataTable dtQualification = new DataTable();
            daQualification.Fill(dtQualification);
            con.Close();
            con.Dispose();
            return dtQualification;

        }

        public int CheckConsultationCaseAppointmentDetails(Int32 ConsultationCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCheck = new SqlCommand("Exec proc_CheckConsultationCaseAppointmentStatus  @ConsultationCaseDetailsId", con);
            SqlParameter paramConsultantCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);

            cmdCheck.Parameters.Add(paramConsultantCaseDetailsId);

            int result = Convert.ToInt32(cmdCheck.ExecuteScalar());
            con.Close();
            con.Dispose();
            return result;


        }

        public DataTable LoadSpecialitiesList()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSpecialitiesList = new SqlCommand("Exec proc_LoadSpecialitiesList", con);


            SqlDataAdapter daLoadSpecialitiesList = new SqlDataAdapter(cmdLoadSpecialitiesList);
            DataTable dtSpecialitiesList = new DataTable();
            daLoadSpecialitiesList.Fill(dtSpecialitiesList);
            con.Close();
            con.Dispose();
            return dtSpecialitiesList;
        }

        public void InsertUpdateProvideType(Int32 ProviderTypeId, String ProviderType, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateProvideType = new SqlCommand("Exec proc_InsertUpdateTypeOfProvider @ProviderTypeId,@ProviderType,@IsActive", con);

            SqlParameter paramProviderTypeId = new SqlParameter("@ProviderTypeId", ProviderTypeId);
            SqlParameter paramProviderType = new SqlParameter("@ProviderType", ProviderType);
            SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);

            cmdInsertUpdateProvideType.Parameters.Add(paramProviderTypeId);
            cmdInsertUpdateProvideType.Parameters.Add(paramProviderType);
            cmdInsertUpdateProvideType.Parameters.Add(paramIsActive);

            IsDataExists = cmdInsertUpdateProvideType.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }
        public DataTable LoadProvideTypeDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProvideTypeDetails = new SqlCommand("Exec proc_LoadProvideTypeDetails", con);

            SqlDataAdapter daTypeDetails = new SqlDataAdapter(cmdLoadProvideTypeDetails);
            DataTable dtTypeDetails = new DataTable();
            daTypeDetails.Fill(dtTypeDetails);
            return dtTypeDetails;
        }

        public DataTable LoadProvideTypeDetailsDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProvideTypeDetails = new SqlCommand("Exec proc_LoadProvideTypeDetailsDropDown", con);

            SqlDataAdapter daTypeDetails = new SqlDataAdapter(cmdLoadProvideTypeDetails);
            DataTable dtStateDetails = new DataTable();
            daTypeDetails.Fill(dtStateDetails);
            con.Close();
            con.Dispose();
            return dtStateDetails;
        }

        public DataTable LoadProvideTypeDetailsById(int ProviderTypeId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProvideTypeDetails = new SqlCommand("Exec proc_LoadProvideTypeDetailsById @ProviderTypeId", con);

            SqlParameter paramProviderTypeId = new SqlParameter("@ProviderTypeId", ProviderTypeId);

            cmdLoadProvideTypeDetails.Parameters.Add(paramProviderTypeId);

            SqlDataAdapter daTypeDetails = new SqlDataAdapter(cmdLoadProvideTypeDetails);
            DataTable dtStateDetails = new DataTable();
            daTypeDetails.Fill(dtStateDetails);
            return dtStateDetails;
        }

        public DataTable LoadSpecialtyTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadSpecialtyType = new SqlCommand("Exec proc_LoadSpecialtyTypeDropDown", con);

            SqlDataAdapter daTypeDetails = new SqlDataAdapter(cmdLoadSpecialtyType);
            DataTable dtTypeDetails = new DataTable();
            daTypeDetails.Fill(dtTypeDetails);
            con.Close();
            con.Dispose();
            return dtTypeDetails;
        }

        public DataTable LoadOwnershipDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProvideTypeDetails = new SqlCommand("Exec proc_LoadOwnershipDropDown", con);

            SqlDataAdapter daOwnership = new SqlDataAdapter(cmdLoadProvideTypeDetails);
            DataTable dtOwnership = new DataTable();
            daOwnership.Fill(dtOwnership);
            con.Close();
            con.Dispose();
            return dtOwnership;
        }

        public DataTable LoadReconizedList()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadReconizedList = new SqlCommand("Exec proc_LoadReconizedList", con);


            SqlDataAdapter daLoadReconizedList = new SqlDataAdapter(cmdLoadReconizedList);
            DataTable dtReconizedList = new DataTable();
            daLoadReconizedList.Fill(dtReconizedList);
            con.Close();
            con.Dispose();
            return dtReconizedList;
        }

        public DataTable LoadAccreditationList()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadAccreditationList = new SqlCommand("Exec proc_LoadAccreditationList", con);


            SqlDataAdapter daLoadAccreditationList = new SqlDataAdapter(cmdLoadAccreditationList);
            DataTable dtAccreditationList = new DataTable();
            daLoadAccreditationList.Fill(dtAccreditationList);
            con.Close();
            con.Dispose();
            return dtAccreditationList;
        }

        public DataTable LoadServiceTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadServiceTypeDetails = new SqlCommand("Exec proc_LoadServiceTypeDropDown", con);

            SqlDataAdapter daServiceTypeDetails = new SqlDataAdapter(cmdLoadServiceTypeDetails);
            DataTable dtServiceTypeDetails = new DataTable();
            daServiceTypeDetails.Fill(dtServiceTypeDetails);
            con.Close();
            con.Dispose();
            return dtServiceTypeDetails;
        }

        public DataTable LoadDistrictSearch(string StateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDistrict = new SqlCommand("Exec proc_LoadDistrictSearchByState @StateId", con);

            SqlParameter paramStateId = new SqlParameter("@StateId", StateId);
            cmdLoadDistrict.Parameters.Add(paramStateId);


            SqlDataAdapter daLoadDistrict = new SqlDataAdapter(cmdLoadDistrict);
            DataTable dtDistrict = new DataTable();
            daLoadDistrict.Fill(dtDistrict);
            con.Close();
            con.Dispose();
            return dtDistrict;
        }

        public DataTable SearchConsultationCaseDetails(string Query)
        {
            DataTable dtSearch = new DataTable();
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdSearch = new SqlCommand(Query, con);
                

                SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
                daSearch.Fill(dtSearch);
                
            }
            catch(Exception ex)
            {

            }
            return dtSearch;
        }

        public DataTable SearchCaseDetails(string Query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearch = new SqlCommand(Query, con);
            DataTable dtSearch = new DataTable();

            SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
            daSearch.Fill(dtSearch);
            return dtSearch;
        }

        public DataTable SearchEmpDetails(string Query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdEmpSearch = new SqlCommand(Query, con);
            DataTable dtEmpSearch = new DataTable();

            SqlDataAdapter daEmpSearch = new SqlDataAdapter(cmdEmpSearch);
            daEmpSearch.Fill(dtEmpSearch);
            return dtEmpSearch;
        }

        //public DataTable SearchClosedAppointmentDetails(string Query)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();

        //    SqlCommand cmdClosedAppointmentSearch = new SqlCommand(Query, con);
        //    DataTable dtClosedAppointmentSearch = new DataTable();

        //    SqlDataAdapter daClosedAppointmentSearch = new SqlDataAdapter(cmdClosedAppointmentSearch);
        //    daClosedAppointmentSearch.Fill(dtClosedAppointmentSearch);
        //    return dtClosedAppointmentSearch;
        //}

        public DataTable LoadDCListDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDCListDetails = new SqlCommand("Exec proc_LoadServiceProviderList", con);

            SqlDataAdapter daLoadDCListDetails = new SqlDataAdapter(cmdLoadDCListDetails);
            DataTable dtLoadDCListDetails = new DataTable();
            daLoadDCListDetails.Fill(dtLoadDCListDetails);
            return dtLoadDCListDetails;
        }

        public DataTable GenerateServiceProviderId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdspId = new SqlCommand("Exec proc_GenerateServiceProviderId", con);

            SqlDataAdapter daspId = new SqlDataAdapter(cmdspId);
            DataTable dtspId = new DataTable();

            daspId.Fill(dtspId);

            return dtspId;
        }

        public DataTable LoadGenericTestDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadGenericTestDetails = new SqlCommand("Exec proc_LoadGenericTestDetails", con);

            SqlDataAdapter daLoadGenericTestDetails = new SqlDataAdapter(cmdLoadGenericTestDetails);
            DataTable dtLoadGenericTestDetails = new DataTable();
            daLoadGenericTestDetails.Fill(dtLoadGenericTestDetails);
            return dtLoadGenericTestDetails;
        }

        public void InsertUpdateGenericTestDetails(Int32 GenericTestId, string VisitType, string TestName, string TestCode, string NormalPrice, string HNIPrice, string TestDescription, Int32 CreatedBy, int IsActive, out string IsDataExists)
        {
           
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateTestDetails = new SqlCommand("InsertUpdateGenericTestDetails", con);
            cmdInsertUpdateTestDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@GenericTestId", GenericTestId);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@VisitType", VisitType);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestName", TestName);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestCode", TestCode);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@NormalPrice", NormalPrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@HNIPrice", HNIPrice);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@TestDescription", TestDescription);
            //cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdInsertUpdateTestDetails.Parameters.AddWithValue("@IsActive", IsActive);

            IsDataExists = cmdInsertUpdateTestDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();


        }

        public DataTable LoadGenericTestDetailsById(int GenericTestId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadGenericTestDetails = new SqlCommand("Exec proc_LoadGenericTestDetailsById @GenericTestId", con);

            SqlParameter paramProductId = new SqlParameter("@GenericTestId", GenericTestId);

            cmdLoadGenericTestDetails.Parameters.Add(paramProductId);

            SqlDataAdapter daLoadGenericTestDetails = new SqlDataAdapter(cmdLoadGenericTestDetails);
            DataTable dtLoadGenericTestDetails = new DataTable();
            daLoadGenericTestDetails.Fill(dtLoadGenericTestDetails);
            return dtLoadGenericTestDetails;
        }

        public DataTable LoadGenericTestAmount(string GenericTestId, Int32 CustomerProfileId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadGenericTestAmount = new SqlCommand("Exec proc_FetchAmountOfGenericTest @GenericTestId,@CustomerProfileId", con);

            SqlParameter paramGenericTestId = new SqlParameter("@GenericTestId", GenericTestId);
            SqlParameter paramCustomerProfileId = new SqlParameter("@CustomerProfileId", CustomerProfileId);

            cmdLoadGenericTestAmount.Parameters.Add(paramGenericTestId);
            cmdLoadGenericTestAmount.Parameters.Add(paramCustomerProfileId);


            SqlDataAdapter daLoadGenericTestAmount = new SqlDataAdapter(cmdLoadGenericTestAmount);
            DataTable dtLoadGenericTestAmount = new DataTable();
            daLoadGenericTestAmount.Fill(dtLoadGenericTestAmount);
            return dtLoadGenericTestAmount;
        }

        public void InsertUpdateHistoryAppointmentDetails(Int32 AppointmentHistId, Int32 AppointmentId, Int32 CaseRefId, string CaseId, string EmployeeName, string ApplicationNo, int BranchId, Int32 CorporateId, string EmployeeId, int CustomerProfile, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeePincode, int AppointmentStatus, DateTime? AppointmentDateTime, string VisitType, string ADHOC_ApprovalBased, string VideographyDone, string VideographyReason, string Comment, Int32 dc_id, string DCMobileNo, string DCName, string DCAddress, string IndividualTest, string PackageTest, int CaseStatus, int ReportStatus, Int32 ScheduledBy, Int32 UpdatedBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCase = new SqlCommand("InsertUpdateAppointmentDetails", con);
            cmdInsertUpdateCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentHistId", AppointmentHistId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentId", AppointmentId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseId", CaseId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@BranchId", BranchId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CustomerProfile", CustomerProfile);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeState", EmployeeState);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeCity", EmployeeCity);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeeArea", EmployeeArea);
            cmdInsertUpdateCase.Parameters.AddWithValue("@EmployeePincode", EmployeePincode);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VisitType", VisitType);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ADHOC_ApprovalBased", ADHOC_ApprovalBased);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VideographyDone", VideographyDone);
            cmdInsertUpdateCase.Parameters.AddWithValue("@VideographyReason", VideographyReason);
            cmdInsertUpdateCase.Parameters.AddWithValue("@Comment", Comment);
            cmdInsertUpdateCase.Parameters.AddWithValue("@dc_id", dc_id);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCMobileNo", DCMobileNo);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCName", DCName);
            cmdInsertUpdateCase.Parameters.AddWithValue("@DCAddress", DCAddress);
            cmdInsertUpdateCase.Parameters.AddWithValue("@IndividualTest", IndividualTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@PackageTest", PackageTest);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ReportStatus", ReportStatus);
            //cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentScheduleDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString());
            cmdInsertUpdateCase.Parameters.AddWithValue("@ScheduledBy", ScheduledBy);
            cmdInsertUpdateCase.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            IsDataExists = cmdInsertUpdateCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadAppointmentHistoryDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadAppointmentHistoryDetails = new SqlCommand("Exec proc_LoadAppointmentHistoryList", con);

            SqlDataAdapter daLoadAppointmentHistoryDetails = new SqlDataAdapter(cmdLoadAppointmentHistoryDetails);
            DataTable dtLoadAppointmentHistoryDetails = new DataTable();

            daLoadAppointmentHistoryDetails.Fill(dtLoadAppointmentHistoryDetails);

            con.Close();
            con.Dispose();

            return dtLoadAppointmentHistoryDetails;
        }

        public DataTable DCCenterListDetails(Int32 City, Int32 DCID)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadDCCenterDetails = new SqlCommand("Exec proc_FetchDCCenterListDetails @City, @DCID", con);
            SqlParameter paramCity = new SqlParameter("@City", City);
            SqlParameter paramDcid = new SqlParameter("@DCID", DCID);

            cmdLoadDCCenterDetails.Parameters.Add(paramCity);
            cmdLoadDCCenterDetails.Parameters.Add(paramDcid);

            SqlDataAdapter daLoadDCCenterDetails = new SqlDataAdapter(cmdLoadDCCenterDetails);
            DataTable dtLoadDCCenterDetails = new DataTable();

            daLoadDCCenterDetails.Fill(dtLoadDCCenterDetails);

            con.Close();
            con.Dispose();

            return dtLoadDCCenterDetails;
        }

        public DataTable LoadDoctorSearchByLanguage(string LanguageId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDoctorNames = new SqlCommand("Exec proc_LoadDoctorSearchByLanguage @LanguageId", con);

            SqlParameter paramStateId = new SqlParameter("@LanguageId", LanguageId);
            cmdLoadDoctorNames.Parameters.Add(paramStateId);


            SqlDataAdapter daLoadDistrict = new SqlDataAdapter(cmdLoadDoctorNames);
            DataTable dtDistrict = new DataTable();
            daLoadDistrict.Fill(dtDistrict);
            con.Close();
            con.Dispose();
            return dtDistrict;
        }

        public DataTable LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(string CustomerPrefferedLanguageId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLanguage = new SqlCommand("Exec proc_LoadDoctorLanguageDropDownByCustomerPrefferedLanguage @CustomerPrefferedLanguageId", con);

            SqlParameter paramCustomerPrefferedLanguageId = new SqlParameter("@CustomerPrefferedLanguageId", CustomerPrefferedLanguageId);

            cmdLanguage.Parameters.Add(paramCustomerPrefferedLanguageId);


            SqlDataAdapter dalanguage = new SqlDataAdapter(cmdLanguage);
            DataTable dtLanguage = new DataTable();
            dalanguage.Fill(dtLanguage);
            con.Close();
            con.Dispose();
            return dtLanguage;

        }

        public DataTable LoadMasterIDProofDocumentDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadStateDetails = new SqlCommand("Exec proc_LoadMaster_IDProofDocumentDropDown", con);

            SqlDataAdapter daLoadStateDetails = new SqlDataAdapter(cmdLoadStateDetails);
            DataTable dtStateDetails = new DataTable();
            daLoadStateDetails.Fill(dtStateDetails);
            con.Close();
            con.Dispose();
            return dtStateDetails;
        }

        public DataTable LoadTestNPackageList(Int32 CorporateId, Int32 CaseRefId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdTestNPackageList = new SqlCommand("Exec proc_LoadTestNPackageListForCorporate @CorporateId, @CaseRefId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCaseRefId = new SqlParameter("@CaseRefId", CaseRefId);

            cmdTestNPackageList.Parameters.Add(paramCorporateId);
            cmdTestNPackageList.Parameters.Add(paramCaseRefId);

            SqlDataAdapter daTestNPackageList = new SqlDataAdapter(cmdTestNPackageList);
            DataTable dtTestNPackageList = new DataTable();
            daTestNPackageList.Fill(dtTestNPackageList);
            con.Close();
            con.Dispose();
            return dtTestNPackageList;
        }

        public DataTable LoadTestNPackageListA(Int32 CorporateId, Int32 CaseRefId, Int32 AppointmentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdTestNPackageList = new SqlCommand("Exec proc_LoadTestNPackageListAppointmentBasis @CorporateId, @CaseRefId, @AppointmentId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCaseRefId = new SqlParameter("@CaseRefId", CaseRefId);
            SqlParameter paramAppointmentId = new SqlParameter("@AppointmentId", AppointmentId);

            cmdTestNPackageList.Parameters.Add(paramCorporateId);
            cmdTestNPackageList.Parameters.Add(paramCaseRefId);
            cmdTestNPackageList.Parameters.Add(paramAppointmentId);

            SqlDataAdapter daTestNPackageList = new SqlDataAdapter(cmdTestNPackageList);
            DataTable dtTestNPackageList = new DataTable();
            daTestNPackageList.Fill(dtTestNPackageList);
            con.Close();
            con.Dispose();
            return dtTestNPackageList;
        }

        public DataTable LoadConsultationCaseHistoryByCaseId(Int32 ConsultationCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadConsultationCaseHistoryByCaseId = new SqlCommand("Exec proc_LoadConsultationCaseHistoryByCaseId @ConsultationCaseDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);

            cmdLoadConsultationCaseHistoryByCaseId.Parameters.Add(paramConsultationCaseDetailsId);

            SqlDataAdapter daLoadConsultationCaseHistoryByCaseId = new SqlDataAdapter(cmdLoadConsultationCaseHistoryByCaseId);
            DataTable dtLoadConsultationCaseHistoryByCaseId = new DataTable();
            daLoadConsultationCaseHistoryByCaseId.Fill(dtLoadConsultationCaseHistoryByCaseId);
            con.Close();
            con.Dispose();
            return dtLoadConsultationCaseHistoryByCaseId;
        }

        public DataTable LoadConsultationCaseAppointmentDetailsHistory()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdConsultationCaseAppointmentDetails = new SqlCommand("Exec proc_LoadConsultationCaseAppointmentDetailsHistory", con);

            //  SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);

            //cmdConsultationCaseAppointmentDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);

            SqlDataAdapter daConsultationCaseAppointmentDetails = new SqlDataAdapter(cmdConsultationCaseAppointmentDetails);
            DataTable dtConsultationCaseAppointmentDetails = new DataTable();
            daConsultationCaseAppointmentDetails.Fill(dtConsultationCaseAppointmentDetails);
            con.Close();
            con.Dispose();
            return dtConsultationCaseAppointmentDetails;

        }

        public DataTable LoadAppointmentStatusList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdAppointmentStatusList = new SqlCommand("Exec proc_LoadAppointmentStatusDetails", con);

            SqlDataAdapter daAppointmentStatusList = new SqlDataAdapter(cmdAppointmentStatusList);
            DataTable dtAppointmentStatusList = new DataTable();

            daAppointmentStatusList.Fill(dtAppointmentStatusList);

            con.Close();
            con.Dispose();

            return dtAppointmentStatusList;


        }

        public DataTable LoadGenderDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadGenderDetails = new SqlCommand("Exec proc_LoadGenderDropDown", con);

            SqlDataAdapter daLoadGenderDetails = new SqlDataAdapter(cmdLoadGenderDetails);
            DataTable dtGenderDetails = new DataTable();
            daLoadGenderDetails.Fill(dtGenderDetails);
            con.Close();
            con.Dispose();
            return dtGenderDetails;
        }

        public DataTable LoadMasterRelationShipDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadRelationShipDetails = new SqlCommand("Exec proc_LoadRelationShipDropDown", con);

            SqlDataAdapter daLoadRelationShipDetails = new SqlDataAdapter(cmdLoadRelationShipDetails);
            DataTable dtRelationShipDetails = new DataTable();
            daLoadRelationShipDetails.Fill(dtRelationShipDetails);
            con.Close();
            con.Dispose();
            return dtRelationShipDetails;
        }

        public void InsertUpdateConsultationCaseDependentDetails(string CaseId, int EmployeeId, int CaseFor, string DependentName, DateTime? DOB, string MobileNo, string EMailId, int GenderId, Int32 ConsultationType, Int32 CaseType, string CustomerPrefferedLanguage)
        {



            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateSpecialityConsultantCaseDetails = new SqlCommand("Exec proc_InsertUpdateConsultationCaseDependentDetails @CaseId,@EmployeeId,@CaseFor,@DependentName,@DOB, @MobileNo,  @EMailId,@GenderId,@ConsultationType,@CaseType,@CustomerPrefferedLanguage  ", con);


            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramEmployeeId = new SqlParameter("@EmployeeId", EmployeeId);
            SqlParameter paramCaseFor = new SqlParameter("@CaseFor", CaseFor);
            SqlParameter paramDependentName = new SqlParameter("@DependentName", DependentName);
            SqlParameter paramDOB = new SqlParameter("@DOB", DOB);

            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter paramEMailId = new SqlParameter("@EMailId", EMailId);
            SqlParameter paramGenderId = new SqlParameter("@GenderId", GenderId);

            SqlParameter paramConsultationType = new SqlParameter("@ConsultationType", ConsultationType);
            SqlParameter paramCaseType = new SqlParameter("@CaseType", CaseType);
            SqlParameter paramCustomerPrefferedLanguage = new SqlParameter("@CustomerPrefferedLanguage", CustomerPrefferedLanguage);


            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEmployeeId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseFor);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDependentName);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramDOB);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramMobileNo);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramEMailId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramGenderId);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramConsultationType);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCaseType);
            cmdInsertUpdateSpecialityConsultantCaseDetails.Parameters.Add(paramCustomerPrefferedLanguage);







            cmdInsertUpdateSpecialityConsultantCaseDetails.ExecuteNonQuery();

            //IsDataExists = cmdInsertUpdateSpecialityConsultantCaseDetails.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();




        }

        public DataTable LoadDependentCaseDetailsById(string EmployeeId, string CaseId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadDependentCaseDetails = new SqlCommand("Exec proc_LoadDependentCaseDetailsById @EmployeeId, @CaseId", con);

            SqlParameter paramCaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter paramEmployeeId = new SqlParameter("@EmployeeId", EmployeeId);

            cmdLoadDependentCaseDetails.Parameters.Add(paramCaseId);
            cmdLoadDependentCaseDetails.Parameters.Add(paramEmployeeId);

            SqlDataAdapter daLoadCaseDetails = new SqlDataAdapter(cmdLoadDependentCaseDetails);
            DataTable dtCaseDetails = new DataTable();
            daLoadCaseDetails.Fill(dtCaseDetails);
            return dtCaseDetails;
        }

        public void InsertUpdateDependentCaseDetails(Int32 DependentId, string EmployeeId, int CaseRefId, string CaseId, int CaseFor, string DependentName, string DependentMobileNo, string DependentGender, DateTime? DependentDOB, string DependentAddress, string MedicalTest, out string IsDataExistsD)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateDependentCase = new SqlCommand("InsertUpdateDependentCaseDetails", con);
            cmdInsertUpdateDependentCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentId", DependentId);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@CaseId", CaseId);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@CaseFor", CaseFor);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentName", DependentName);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentMobileNo", DependentMobileNo);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentGender", DependentGender);
            //cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentDOB", DependentDOB);
            SqlParameter paramDependentDOB;

            if (DependentDOB.Equals(null))
            {
                paramDependentDOB = new SqlParameter("@DependentDOB", DBNull.Value);
            }
            else
            {
                paramDependentDOB = new SqlParameter("@DependentDOB", DependentDOB);
            }

            cmdInsertUpdateDependentCase.Parameters.Add(paramDependentDOB);

            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@DependentAddress", DependentAddress);
            cmdInsertUpdateDependentCase.Parameters.AddWithValue("@MedicalTest", MedicalTest);
            
            IsDataExistsD = cmdInsertUpdateDependentCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataSet LoadAdminDashBoard()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadAdminDashBoard = new SqlCommand("Exec proc_AdminDashBoard", con);



            SqlDataAdapter daLoadAdminDashBoard = new SqlDataAdapter(cmdLoadAdminDashBoard);
            DataSet dtAdminDashBoard = new DataSet();
            daLoadAdminDashBoard.Fill(dtAdminDashBoard);
            return dtAdminDashBoard;
        }

        public void InsertUpdateBranchDetailsByCorporate(Int32 BranchDetailsId, int CorporateId, string Branch, string PersonName, string MobileNo, string EmailId, Int32 State, Int32 City, string Address, int IsActive, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateBranch = new SqlCommand("InsertUpdateBranchDetailsByCorporate", con);
            cmdInsertUpdateBranch.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateBranch.Parameters.AddWithValue("@BranchDetailsId", BranchDetailsId);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@Branch", Branch);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@PersonName", PersonName);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@EmailId", EmailId);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@State", State);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@City", City);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@Address", Address);
            cmdInsertUpdateBranch.Parameters.AddWithValue("@IsActive", IsActive);

            IsDataExists = cmdInsertUpdateBranch.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();

        }

        public DataTable LoadBranchDetailsByIdForCorporate(int BranchDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadBranchDetails = new SqlCommand("Exec proc_LoadBranchDetailsByIdForCorporate @BranchDetailsId", con);

            SqlParameter paramBranchId = new SqlParameter("@BranchDetailsId", BranchDetailsId);

            cmdLoadBranchDetails.Parameters.Add(paramBranchId);

            SqlDataAdapter daBranchDetails = new SqlDataAdapter(cmdLoadBranchDetails);
            DataTable dtBranchDetails = new DataTable();
            daBranchDetails.Fill(dtBranchDetails);
            return dtBranchDetails;
        }

        public DataTable LoadTotalBranchDetailsList(Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadBranchDetailsList = new SqlCommand("Exec proc_LoadTotalBranchDetailsList @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadBranchDetailsList.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadBranchDetailsList = new SqlDataAdapter(cmdLoadBranchDetailsList);
            DataTable dtLoadBranchDetailsList = new DataTable();

            daLoadBranchDetailsList.Fill(dtLoadBranchDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadBranchDetailsList;

        }

        public void CorporateLoginCreation(Int32 LoginRefId, Int32 CorporateId, Int32 EmployeeRefId, string UserName, string Password, string EmailId, string MobileNo, string RolePermissions, int IsActive, Int32 LoginId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdCorporateLoginCreation = new SqlCommand("Exec proc_CorporateLoginCreation @LoginRefId, @EmployeeRefId,@CorporateId,@UserName,@Password,@EmailId,@MobileNo,@RolePermissions,@IsActive,@CreatedBy", con);

                SqlParameter paramLoginRefId = new SqlParameter("@LoginRefId", LoginRefId);
                SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
                SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
                SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
                SqlParameter paramPasswsord = new SqlParameter("@Password", Password);
                SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);
                SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
                SqlParameter paramRolePermissions = new SqlParameter("@RolePermissions", RolePermissions);
                SqlParameter paramIsActive = new SqlParameter("@IsActive", IsActive);
                SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", LoginId);

                cmdCorporateLoginCreation.Parameters.Add(paramLoginRefId);
                cmdCorporateLoginCreation.Parameters.Add(paramEmployeeRefId);
                cmdCorporateLoginCreation.Parameters.Add(paramCorporateId);
                cmdCorporateLoginCreation.Parameters.Add(paramUserName);
                cmdCorporateLoginCreation.Parameters.Add(paramPasswsord);
                cmdCorporateLoginCreation.Parameters.Add(paramEmailId);
                cmdCorporateLoginCreation.Parameters.Add(paramMobileNo);
                cmdCorporateLoginCreation.Parameters.Add(paramRolePermissions);
                cmdCorporateLoginCreation.Parameters.Add(paramIsActive);
                cmdCorporateLoginCreation.Parameters.Add(paramCreatedBy);

                cmdCorporateLoginCreation.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        public bool CheckEmail_MobileExists(string EmailId)
        {
            bool IsExists = false;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdCheckEmailExists = new SqlCommand("Exec proc_CheckEmail_MobileExists @Emailid", con);

                SqlParameter paramEmail = new SqlParameter("@EmailId", EmailId);

                cmdCheckEmailExists.Parameters.Add(paramEmail);

                int i = Convert.ToInt32(cmdCheckEmailExists.ExecuteScalar());

                if (i == 0)
                {
                    IsExists = false;
                }
                else
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsExists;

        }

        public DataTable LoadUsersBasedOnSubRole(Int32 SubRoleId)
        {
            DataTable dtLoadUsers = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdLoadUsers = new SqlCommand("Exec proc_LoadUsersBasedOnSubRole @SubRoleId", con);
                SqlParameter paramSubRoleId = new SqlParameter("@SubRoleId", SubRoleId);

                cmdLoadUsers.Parameters.Add(paramSubRoleId);

                SqlDataAdapter daLoadUsers = new SqlDataAdapter(cmdLoadUsers);

                daLoadUsers.Fill(dtLoadUsers);



            }
            catch (Exception ex)
            {

            }

            return dtLoadUsers;
        }


        //Kiran New Login
        public DataSet Verify_Login(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdverifyLogin = new SqlCommand("Exec proc_Verify_Login @UserName,@Password", con);
            SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);

            cmdverifyLogin.Parameters.Add(paramUserName);
            cmdverifyLogin.Parameters.Add(paramPassword);

            SqlDataAdapter daVerifyLogin = new SqlDataAdapter(cmdverifyLogin);
            DataSet dtVerifyLogin = new DataSet();

            daVerifyLogin.Fill(dtVerifyLogin);
            return dtVerifyLogin;


        }

        public void InsertLoginHistory(Int32 LoginRefId, string IPAddress, string Browser)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdInsertLoginHistory = new SqlCommand("Exec proc_InsertLoginHistory @LoginRefId,@IPAddress,@Browser", con);

                SqlParameter paramLoginRefId = new SqlParameter("@LoginRefId", LoginRefId);
                SqlParameter paramIPAddress = new SqlParameter("@IPAddress", IPAddress);
                SqlParameter paramBrowser = new SqlParameter("@Browser", Browser);

                cmdInsertLoginHistory.Parameters.Add(paramLoginRefId);
                cmdInsertLoginHistory.Parameters.Add(paramIPAddress);
                cmdInsertLoginHistory.Parameters.Add(paramBrowser);

                cmdInsertLoginHistory.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {

            }


        }

        public void UpdateOTP(string UserName, string OTP)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdUpdateOTP = new SqlCommand("Exec proc_UpdateOTP @UserName,@OTP", con);

                SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
                SqlParameter paramOTP = new SqlParameter("@OTP", OTP);
                cmdUpdateOTP.Parameters.Add(paramUserName);
                cmdUpdateOTP.Parameters.Add(paramOTP);

                cmdUpdateOTP.ExecuteNonQuery();
                con.Close();
                con.Dispose();

            }
            catch (Exception Ex)
            {

            }
        }

        public bool CheckAccountStatus(string EmailId)
        {
            bool IsExists = false;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdCheckEmailExists = new SqlCommand("Exec proc_CheckAccountStatus @Emailid", con);

                SqlParameter paramEmail = new SqlParameter("@EmailId", EmailId);

                cmdCheckEmailExists.Parameters.Add(paramEmail);

                int i = Convert.ToInt32(cmdCheckEmailExists.ExecuteScalar());

                if (i == 0)
                {
                    IsExists = false;
                }
                else
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsExists;

        }

        public void UpdateAccountStatus(string UserName)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdUpdateAccountStatus = new SqlCommand("Exec proc_UpdateAccountStatus @UserName", con);

                SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
                //SqlParameter paramOTP = new SqlParameter("@OTP", OTP);
                cmdUpdateAccountStatus.Parameters.Add(paramUserName);
                //cmdUpdateOTP.Parameters.Add(paramOTP);

                cmdUpdateAccountStatus.ExecuteNonQuery();
                con.Close();
                con.Dispose();

            }
            catch (Exception Ex)
            {

            }
        }

        public DataTable LoadLoginUserDetails(Int32 CorporateId, Int32 UserId)
        {
            DataTable dtLoginUserDetails = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdFetchLoginUserDetails = new SqlCommand("Exec proc_LoadLoginUserDetails @CorporateId, @UserId", con);
                SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
                SqlParameter paramUserId = new SqlParameter("@UserId", UserId);

                cmdFetchLoginUserDetails.Parameters.Add(paramCorporateId);
                cmdFetchLoginUserDetails.Parameters.Add(paramUserId);

                SqlDataAdapter daLoginUserDetails = new SqlDataAdapter(cmdFetchLoginUserDetails);

                daLoginUserDetails.Fill(dtLoginUserDetails);
            }
            catch (Exception ex)
            {

            }

            return dtLoginUserDetails;
        }

        public bool CheckUserNameAvailabilty(string UserName)
        {
            bool IsExists = false;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdCheckEmailExists = new SqlCommand("Exec proc_CheckUserNameAvailabilty @UserName", con);

                SqlParameter paramEmail = new SqlParameter("@UserName", UserName);

                cmdCheckEmailExists.Parameters.Add(paramEmail);

                int i = Convert.ToInt32(cmdCheckEmailExists.ExecuteScalar());

                if (i == 0)
                {
                    IsExists = false;
                }
                else
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsExists;

        }

        public DataTable LoadEmployeeDetailsCorporate(Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadEmployeeCorporateDetails = new SqlCommand("Exec proc_LoadListOfEmployees @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadEmployeeCorporateDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daEmployeeCorporateDetails = new SqlDataAdapter(cmdLoadEmployeeCorporateDetails);
            DataTable dtEmployeeCorporateDetails = new DataTable();
            daEmployeeCorporateDetails.Fill(dtEmployeeCorporateDetails);
            return dtEmployeeCorporateDetails;
        }

        public DataTable LoadReportStatusList()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdReportStatusList = new SqlCommand("Exec proc_LoadReportStatusDetails", con);



            SqlDataAdapter daReportStatusList = new SqlDataAdapter(cmdReportStatusList);
            DataTable dtReportStatusList = new DataTable();
            daReportStatusList.Fill(dtReportStatusList);
            con.Close();
            con.Dispose();
            return dtReportStatusList;

        }

        public DataSet LoadProductServicesForEmployee(string ProductId, Int32 CorporateId, Int32 CorporateBranchId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductServices = new SqlCommand("Exec proc_LoadProductServicesForEmployee @ProductId,@CorporateId,@CorporateBranchId", con);

            SqlParameter paramProductId = new SqlParameter("@ProductId", ProductId);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);
            SqlParameter paramCorporateBranchId = new SqlParameter("@CorporateBranchId", CorporateBranchId);
            cmdLoadProductServices.Parameters.Add(paramProductId);
            cmdLoadProductServices.Parameters.Add(paramCorporateId);
            cmdLoadProductServices.Parameters.Add(paramCorporateBranchId);

            SqlDataAdapter daLoadProductServices = new SqlDataAdapter(cmdLoadProductServices);
            DataSet dtLoadProductServices = new DataSet();
            daLoadProductServices.Fill(dtLoadProductServices);
            con.Close();
            con.Dispose();
            return dtLoadProductServices;
        }

        public DataTable LoadServicesForEmployee(string Services)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadProductServices = new SqlCommand("Exec proc_LoadServicesForEmployee @Services", con);

            SqlParameter paramServices = new SqlParameter("@Services", Services);

            cmdLoadProductServices.Parameters.Add(paramServices);

            SqlDataAdapter daLoadProductServices = new SqlDataAdapter(cmdLoadProductServices);
            DataTable dtLoadProductServices = new DataTable();
            daLoadProductServices.Fill(dtLoadProductServices);
            con.Close();
            con.Dispose();
            return dtLoadProductServices;
        }

        public DataTable LoadAssignExecutive()
        {
            DataTable dtLoadCaseStatusDetails = new DataTable();
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdLoadCaseStatusDetails = new SqlCommand("Exec proc_LoadAssignExecutive", con);

                SqlDataAdapter daLoadCaseStatusDetails = new SqlDataAdapter(cmdLoadCaseStatusDetails);

                daLoadCaseStatusDetails.Fill(dtLoadCaseStatusDetails);

            }
            catch (Exception ex)
            {

            }
            return dtLoadCaseStatusDetails;
        }

        public void InsertUpdatePatientRegistrationDetails(string EmployeeCode, string EmployeeName, DateTime? DOB, Int32 GenderId, Int32 DepartmentId, string MobileNo, string EmailId, DateTime? VisitDateTime, string DiagnosisDetails, string AdviceGiven, string DoctorName, DataTable Medicinedetails, Int32 CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdatePatientRegistrationDetails = new SqlCommand("proc_InsertUpdatePatientRegistrationDetails", con);

            //SqlCommand cmdInsertUpdatePatientRegistrationDetails = new SqlCommand("proc_InsertUpdatePatientRegistrationDetails @EmployeeName,@EmployeeCode,@DateOfBirth,@GenderId,@DepartmentId,@MobileNo,@EmailId,@VisitDateTime,@DiagnosisDetails,@AdviceGiven,@DoctorName,@MedicineDetails,@CreatedBy", con);

            cmdInsertUpdatePatientRegistrationDetails.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);

            //SqlParameter paramEmployeeName = new SqlParameter("@EmployeeName",EmployeeName);
            //SqlParameter paramEmployeeCode = new SqlParameter("@EmployeeCode", EmployeeCode);




            SqlParameter paramDOB;

            if (DOB.Equals(null))
            {
                cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                //paramDOB = new SqlParameter("@DateOfBirth", DBNull.Value);
            }
            else
            {
                cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@DateOfBirth", DOB);
                //paramDOB = new SqlParameter("@DateOfBirth", DOB);
            }

            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@GenderId", GenderId);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@EmailId", EmailId);

            //SqlParameter paramGenderId = new SqlParameter("@GenderId", GenderId);
            //SqlParameter paramDepartmentId = new SqlParameter("@DepartmentId", DepartmentId);
            //SqlParameter paramMobileNo = new SqlParameter("@MobileNo", MobileNo);
            //SqlParameter paramEmailId = new SqlParameter("@EmailId", EmailId);

            SqlParameter paramVisitDateTime;
            if (VisitDateTime.Equals(null))
            {
                cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@VisitDateTime", DBNull.Value);
                //paramVisitDateTime = new SqlParameter("@VisitDateTime", DBNull.Value);
            }
            else
            {
                cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@VisitDateTime", VisitDateTime);
                //paramVisitDateTime = new SqlParameter("@VisitDateTime", DOB);
            }

            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@DiagnosisDetails", DiagnosisDetails);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@AdviceGiven", AdviceGiven);
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@DoctorName", DoctorName);

            //SqlParameter paramDiagnosisDetails = new SqlParameter("@DiagnosisDetails", DiagnosisDetails);
            //SqlParameter paramAdviceGiven = new SqlParameter("@AdviceGiven", AdviceGiven);
            //SqlParameter paramDoctorName = new SqlParameter("@DoctorName", DoctorName);

            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@MedicineDetails", Medicinedetails);

            //SqlParameter paramMedicineDetails = new SqlParameter();
            //paramMedicineDetails.ParameterName = "@MedicineDetails";
            //paramMedicineDetails.SqlDbType = SqlDbType.Structured;
            //paramMedicineDetails.Value = Medicinedetails;
            cmdInsertUpdatePatientRegistrationDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            //SqlParameter paramCreatedBy = new SqlParameter("@CreatedBy", CreatedBy);

            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramEmployeeName);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramEmployeeCode);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramDOB);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramGenderId);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramDepartmentId);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramMobileNo);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramEmailId);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramVisitDateTime);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramDiagnosisDetails);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramAdviceGiven);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramDoctorName);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramMedicineDetails);
            //cmdInsertUpdatePatientRegistrationDetails.Parameters.Add(paramCreatedBy);

            cmdInsertUpdatePatientRegistrationDetails.ExecuteNonQuery();
            con.Close();
            con.Dispose();


        }

        public DataTable LoadMedicineDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadMedicineDetails = new SqlCommand("Exec proc_LoadMedicineDropDown", con);

            SqlDataAdapter daLoadGenderDetails = new SqlDataAdapter(cmdLoadMedicineDetails);
            DataTable dtMedicineDetails = new DataTable();
            daLoadGenderDetails.Fill(dtMedicineDetails);
            con.Close();
            con.Dispose();
            return dtMedicineDetails;
        }

        public DataTable LoadPatientRegistrationDetails()
        {
            DataTable dtPatientRegistrationDetails = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdLoadPatientRegistrationDetails = new SqlCommand("Exec proc_LoadPatientRegistrationDetails", con);

                SqlDataAdapter daLoadPatientRegistrationDetails = new SqlDataAdapter(cmdLoadPatientRegistrationDetails);
                daLoadPatientRegistrationDetails.Fill(dtPatientRegistrationDetails);
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {

            }
            return dtPatientRegistrationDetails;
        }

        public DataTable LoadPatientRegistrationDetailsById(Int32 PatientRegistrationFormId)
        {
            DataTable dtPatientRegistrationDetails = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdLoadPatientRegistrationDetails = new SqlCommand("Exec proc_LoadPatientRegistrationDetailsById @PatientRegistrationFormId", con);

                SqlParameter paramPatientRegistrationFormId = new SqlParameter("@PatientRegistrationFormId", PatientRegistrationFormId);
                cmdLoadPatientRegistrationDetails.Parameters.Add(paramPatientRegistrationFormId);

                SqlDataAdapter daLoadPatientRegistrationDetails = new SqlDataAdapter(cmdLoadPatientRegistrationDetails);
                daLoadPatientRegistrationDetails.Fill(dtPatientRegistrationDetails);
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {

            }
            return dtPatientRegistrationDetails;
        }

        public DataSet LoadConsultationCaseLogDetails(Int32 ConsultationCaseDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadCaseLogDetails @ConsultationCaseDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataSet dtCaseLogDetails = new DataSet();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadTeleVideoQCQuestions()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_FetchTeleVideoQCQuestions", con);

            //SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);


            //cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadCaseDetailsByIdForReport(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_CaseDetailsByIdForReport @ConsultationCaseDetailsId,@ConsultationCaseAppointmentDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public int SaveQCSummaryDetails(Int32 QCSummaryDetailsdId, Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, string Comments, Int32 CreatedBy, DataTable dtQCQuestionAnswer)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("proc_SaveConsultationCaseDetails_QCSummaryDetails", con);
            cmdCaseLogDetails.CommandType = CommandType.StoredProcedure;

            cmdCaseLogDetails.Parameters.AddWithValue("@QCSummaryDetailsdId", QCSummaryDetailsdId);
            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@Comments", Comments);
            cmdCaseLogDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdCaseLogDetails.Parameters.AddWithValue("@QCQuestionAnswer", dtQCQuestionAnswer);

            int i = Convert.ToInt32(cmdCaseLogDetails.ExecuteNonQuery());

            return i;



        }

        public DataTable LoadQCCaseSummaryDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadQCCaseSummaryDetails @ConsultationCaseDetailsId,@ConsultationCaseAppointmentDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadQCQuestionAnswerDetails(Int32 QCSummaryDetailsdId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadQCQuestionAnswerDetails @QCSummaryDetailsdId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@QCSummaryDetailsdId", QCSummaryDetailsdId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadQuestionnaire()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadQuestionnaire", con);

            //SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);


            //cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadTeleMERResults(Int32 QuestionnaireAnswerId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadTeleMERResults @QuestionnaireAnswerId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@QuestionnaireAnswerId", QuestionnaireAnswerId);



            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);
            //cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public Int32 SaveTelerMERQuestionAnswer(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, DataTable dtQuestionnaireAnswer)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("proc_InsertUpdateQuestionnaire_AnswerDetails", con);
            cmdCaseLogDetails.CommandType = CommandType.StoredProcedure;

            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@QuestionnaireAnswer", dtQuestionnaireAnswer);

            Int32 QuestionnaireAnswerDetailsId = 0;
            QuestionnaireAnswerDetailsId = Convert.ToInt32(cmdCaseLogDetails.ExecuteScalar());


            return QuestionnaireAnswerDetailsId;
            //SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            //DataTable dtCaseLogDetails = new DataTable();

            //daCaseLogDetails.Fill(dtCaseLogDetails);

            //return dtCaseLogDetails;
        }



        //public void InsertUpdateCaseRemarkDetails(Int32 CaseRemarkId, Int32 CaseRefId, string CaseId, string Remark, Int32 CaseStatus, int CreatedBy)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();

        //    SqlCommand cmdInsertUpdateCaseRemark = new SqlCommand("InsertUpdateCaseRemarkDetails", con);
        //    cmdInsertUpdateCaseRemark.CommandType = CommandType.StoredProcedure;

        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CaseRemarkId", CaseRemarkId);
        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CaseRefId", CaseRefId);
        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CaseId", CaseId);
        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@Remark", Remark);
        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CaseStatus", CaseStatus);
        //    //cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString());
        //    cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        //    cmdInsertUpdateCaseRemark.ExecuteNonQuery();
        //    //IsDataExists = cmdInsertUpdateCaseRemark.ExecuteScalar().ToString();
        //    con.Close();
        //    con.Dispose();
        //}

        public void InsertUpdateAppointmentRemarkDetails(Int32 AppointmentRemarkId, Int32 CaseRefId, string Remark, Int32 AppointmentStatus, Int32 CaseStatus, Int32 ReportStatus, int CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateAppointmentRemark = new SqlCommand("InsertUpdateAppointmentRemarkDetails", con);
            cmdInsertUpdateAppointmentRemark.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@AppointmentRemarkId", AppointmentRemarkId);
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@Remark", Remark);
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@ReportStatus", ReportStatus);
            //cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString());
            cmdInsertUpdateAppointmentRemark.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdInsertUpdateAppointmentRemark.ExecuteNonQuery();
            //IsDataExists = cmdInsertUpdateAppointmentRemark.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void InsertUpdateReportRemarkDetails(Int32 ReportRemarkId, Int32 CaseRefId, string ReportRemark, Int32 RemarkType, Int32 CaseStatus, Int32 ReportStatus, int CreatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateReportRemark = new SqlCommand("InsertUpdateReportRemarkDetails", con);
            cmdInsertUpdateReportRemark.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@ReportRemarkId", ReportRemarkId);
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@ReportRemark", ReportRemark);
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@RemarkType", RemarkType);
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@ReportStatus", ReportStatus);
            //cmdInsertUpdateReportRemark.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString());
            cmdInsertUpdateReportRemark.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdInsertUpdateReportRemark.ExecuteNonQuery();
            //IsDataExists = cmdInsertUpdateReportRemark.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadCaseRemarkDetailsList(Int32 CaseRefId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadCaseRemarkDetailsList = new SqlCommand("Exec proc_LoadCaseRemarkDetails @CaseRefId", con);

            SqlParameter paramCaseRefId = new SqlParameter("@CaseRefId", CaseRefId);

            cmdLoadCaseRemarkDetailsList.Parameters.Add(paramCaseRefId);

            SqlDataAdapter daLoadCaseRemarkDetailsList = new SqlDataAdapter(cmdLoadCaseRemarkDetailsList);
            DataTable dtLoadCaseRemarkDetailsList = new DataTable();

            daLoadCaseRemarkDetailsList.Fill(dtLoadCaseRemarkDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadCaseRemarkDetailsList;

        }

        public DataTable LoadAppointmentRemarkDetailsList(Int32 CaseRefId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadAppointmentRemarkDetailsList = new SqlCommand("Exec proc_LoadAppointmentRemarkDetails @CaseRefId", con);

            SqlParameter paramCaseRefId = new SqlParameter("@CaseRefId", CaseRefId);

            cmdLoadAppointmentRemarkDetailsList.Parameters.Add(paramCaseRefId);

            SqlDataAdapter daLoadAppointmentRemarkDetailsList = new SqlDataAdapter(cmdLoadAppointmentRemarkDetailsList);
            DataTable dtLoadAppointmentRemarkDetailsList = new DataTable();

            daLoadAppointmentRemarkDetailsList.Fill(dtLoadAppointmentRemarkDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadAppointmentRemarkDetailsList;

        }

        public DataTable LoadReportRemarkDetailsList(Int32 CaseRefId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadReportRemarkDetailsList = new SqlCommand("Exec proc_LoadReportRemarkDetails @CaseRefId", con);

            SqlParameter paramCaseRefId = new SqlParameter("@CaseRefId", CaseRefId);

            cmdLoadReportRemarkDetailsList.Parameters.Add(paramCaseRefId);

            SqlDataAdapter daLoadReportRemarkDetailsList = new SqlDataAdapter(cmdLoadReportRemarkDetailsList);
            DataTable dtLoadReportRemarkDetailsList = new DataTable();

            daLoadReportRemarkDetailsList.Fill(dtLoadReportRemarkDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadReportRemarkDetailsList;

        }

        public DataTable LoadUpdatedBy()
        {
            DataTable dtLoadUpdatedByDetails = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdLoadUpdatedByDetails = new SqlCommand("Exec proc_LoadUpdatedBy", con);

                SqlDataAdapter daLoadUpdatedByDetails = new SqlDataAdapter(cmdLoadUpdatedByDetails);

                daLoadUpdatedByDetails.Fill(dtLoadUpdatedByDetails);
            }
            catch (Exception ex)
            {

            }
            return dtLoadUpdatedByDetails;
        }

        public DataTable LoadMasterGeoTaggingDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadGeoTaggingDetails = new SqlCommand("Exec proc_LoadGeoTaggingDropDown", con);

            SqlDataAdapter daGeoTaggingDetails = new SqlDataAdapter(cmdLoadGeoTaggingDetails);
            DataTable dtGeoTaggingDetails = new DataTable();
            daGeoTaggingDetails.Fill(dtGeoTaggingDetails);
            con.Close();
            con.Dispose();
            return dtGeoTaggingDetails;
        }

        public void InsertUpdateReportDetails(Int32 ReportId, Int32 CaseRefId, Int32 AppointmentId, DataTable dtAppointmentReport, string ReportType, Int32 ReportStatus, DateTime? DateOfClosureApproval, string PhotoId, string Photo, Int32 GeoTagging, string OutSourced, string OutSourcedTest, string ReportRecMode, string ReportRecFrom, string Comment, Int32 Report_Sent_by, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateReport = new SqlCommand("InsertUpdateAppointmentReportDetails", con);
            cmdInsertUpdateReport.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportId", ReportId);
            cmdInsertUpdateReport.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateReport.Parameters.AddWithValue("@AppointmentId", AppointmentId);
            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportsData", dtAppointmentReport);
            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportType", ReportType);
            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportStatus", ReportStatus);

            SqlParameter paramDateOfClosureApproval;

            if (DateOfClosureApproval.Equals(null))
            {
                paramDateOfClosureApproval = new SqlParameter("@DateOfClosureApproval", DBNull.Value);
            }
            else
            {
                paramDateOfClosureApproval = new SqlParameter("@DateOfClosureApproval", DateOfClosureApproval);
            }

            cmdInsertUpdateReport.Parameters.Add(paramDateOfClosureApproval);
            cmdInsertUpdateReport.Parameters.AddWithValue("@PhotoId", PhotoId);
            cmdInsertUpdateReport.Parameters.AddWithValue("@Photo", Photo);
            cmdInsertUpdateReport.Parameters.AddWithValue("@GeoTagging", GeoTagging);
            cmdInsertUpdateReport.Parameters.AddWithValue("@OutSourced", OutSourced);
            cmdInsertUpdateReport.Parameters.AddWithValue("@OutSourcedTest", OutSourcedTest);
            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportRecMode", ReportRecMode);
            cmdInsertUpdateReport.Parameters.AddWithValue("@ReportRecFrom", ReportRecFrom);
            cmdInsertUpdateReport.Parameters.AddWithValue("@Comment", Comment);
            cmdInsertUpdateReport.Parameters.AddWithValue("@Report_Sent_by", Report_Sent_by);

            //cmdInsertUpdateReport.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateReport.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }


        public DataTable GetReportonAppointmentId(Int32 AppointmentReportId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdGetReportonAppointmentId = new SqlCommand("Exec proc_GetReportonAppointmentId @AppointmentReportId",con);

            SqlParameter paramAppointmentReportId = new SqlParameter("@AppointmentReportId",AppointmentReportId);

            cmdGetReportonAppointmentId.Parameters.Add(paramAppointmentReportId);

            SqlDataAdapter daReport = new SqlDataAdapter(cmdGetReportonAppointmentId);
            DataTable dtReport = new DataTable();
            daReport.Fill(dtReport);
            con.Close();
            con.Dispose();
            return dtReport;
        }

        public void InsertUpdateQCCheckListDetails(Int32 QReportId, Int32 ReportId, Int32 CaseRefId, Int32 AppointmentId, int Q1_InsuredName, int Q2_ClientId, string Q3_ClientIdNo, int Q4_LivePhoto, int Q5_FaceMatchScore, int Q6_AppDateMatch, string Q7_AppdateMatchIfNo, int Q8_DCNameMatch, int Q9_ReportDocSequence, int Q10_AadharNoMasked,
                                                int Q11_ReportNConvention, string Q12_RCheckListOnSTV, int Q13_InterAdded, string Q14_MERDrName, string Q15_MERDrRegNo, string Q16_MERDrQualification, int Q17_Disclosures, int Q18_ApplicationNoMER, string Q19_OldApplicationNo, int Q20_MERDate,
                                                int Q21_BPReadingPulseRate, int Q22_FamilyHistory, int Q23_SAFFandIdProof, string Q24_SAFFandIdProofException, int Q25_HWDAMatchInReport, int Q26_AllMERQueAns,
                                                int Q27_AnyQueMarkedAsYesMER, int Q28_RemarkGivenAsYes, int Q29_VerifiedMER, int Q30_ReflexiveTest, string Q31_TestComponentLIP, string Q32_TestComponentLFT, int Q33_WearFaceMask, string QCComment, Int32 QC_ErrorType, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateQReport = new SqlCommand("InsertUpdateQCCheckListDetails", con);
            cmdInsertUpdateQReport.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateQReport.Parameters.AddWithValue("@QReportId", QReportId);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@ReportId", ReportId);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@AppointmentId", AppointmentId);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q1_InsuredName", Q1_InsuredName);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q2_ClientId", Q2_ClientId);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q3_ClientIdNo", Q3_ClientIdNo);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q4_LivePhoto", Q4_LivePhoto);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q5_FaceMatchScore", Q5_FaceMatchScore);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q6_AppDateMatch", Q6_AppDateMatch);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q7_AppdateMatchIfNo", Q7_AppdateMatchIfNo);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q8_DCNameMatch", Q8_DCNameMatch);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q9_ReportDocSequence", Q9_ReportDocSequence);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q10_AadharNoMasked", Q10_AadharNoMasked);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q11_ReportNConvention", Q11_ReportNConvention);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q12_RCheckListOnSTV", Q12_RCheckListOnSTV);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q13_InterAdded", Q13_InterAdded);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q14_MERDrName", Q14_MERDrName);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q15_MERDrRegNo", Q15_MERDrRegNo);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q16_MERDrQualification", Q16_MERDrQualification);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q17_Disclosures", Q17_Disclosures);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q18_ApplicationNoMER", Q18_ApplicationNoMER);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q19_OldApplicationNo", Q19_OldApplicationNo);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q20_MERDate", Q20_MERDate);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q21_BPReadingPulseRate", Q21_BPReadingPulseRate);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q22_FamilyHistory", Q22_FamilyHistory);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q23_SAFFandIdProof", Q23_SAFFandIdProof);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q24_SAFFandIdProofException", Q24_SAFFandIdProofException);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q25_HWDAMatchInReport", Q25_HWDAMatchInReport);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q26_AllMERQueAns", Q26_AllMERQueAns);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q27_AnyQueMarkedAsYesMER", Q27_AnyQueMarkedAsYesMER);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q28_RemarkGivenAsYes", Q28_RemarkGivenAsYes);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q29_VerifiedMER", Q29_VerifiedMER);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q30_ReflexiveTest", Q30_ReflexiveTest);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q31_TestComponentLIP", Q31_TestComponentLIP);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q32_TestComponentLFT", Q32_TestComponentLFT);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@Q33_WearFaceMask", Q33_WearFaceMask); 
            cmdInsertUpdateQReport.Parameters.AddWithValue("@QCComment", QCComment);
            cmdInsertUpdateQReport.Parameters.AddWithValue("@QC_ErrorType", QC_ErrorType);
            //cmdInsertUpdateReport.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateQReport.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadErrorTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadErrorTypeDetails = new SqlCommand("Exec proc_LoadErrorTypeDropDown", con);

            SqlDataAdapter daLoadErrorTypeDetails = new SqlDataAdapter(cmdLoadErrorTypeDetails);
            DataTable dtLoadErrorTypeDetails = new DataTable();
            daLoadErrorTypeDetails.Fill(dtLoadErrorTypeDetails);
            return dtLoadErrorTypeDetails;
        }

        public void InsertUpdateCaseDetailsOnCaseCompletion(Int32 CaseRefId, Int32 AppointmentId, Int32 CaseStatus, Int32 ReportStatus, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCase = new SqlCommand("InsertUpdateCaseDetailsOnCaseCompletion", con);
            cmdInsertUpdateCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@AppointmentId", AppointmentId);
            cmdInsertUpdateCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateCase.Parameters.AddWithValue("@ReportStatus", ReportStatus);

            IsDataExists = cmdInsertUpdateCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadInterpretationTypeDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadInterpretationTypeDetails = new SqlCommand("Exec proc_LoadInterpretationTypeDropDown", con);

            SqlDataAdapter daLoadInterpretationTypeDetails = new SqlDataAdapter(cmdLoadInterpretationTypeDetails);
            DataTable dtLoadInterpretationTypeDetails = new DataTable();
            daLoadInterpretationTypeDetails.Fill(dtLoadInterpretationTypeDetails);
            return dtLoadInterpretationTypeDetails;
        }

        public DataTable LoadInterpretationCaseStatusDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadInterpretationCaseStatusDetails = new SqlCommand("Exec proc_LoadInterpretationCaseStatusDropDown", con);

            SqlDataAdapter daLoadInterpretationCaseStatusDetails = new SqlDataAdapter(cmdLoadInterpretationCaseStatusDetails);
            DataTable dtLoadInterpretationCaseStatusDetails = new DataTable();
            daLoadInterpretationCaseStatusDetails.Fill(dtLoadInterpretationCaseStatusDetails);
            return dtLoadInterpretationCaseStatusDetails;
        }

        public void InsertUpdateInterpretationCaseDetails(Int32 InterpretationCaseId, string CaseType, Int32 CorporateId, string CustomerName, string ApplicationNo, string PolicyNo, string CaseRecMode, int InterpretationType, string CaseRemark, Int32 CaseStatus, string ReportName, byte[] ReportData, Int32 CreatedBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateInterpretationCase = new SqlCommand("InsertUpdateInterpretationCaseDetails", con);
            cmdInsertUpdateInterpretationCase.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@InterpretationCaseId", InterpretationCaseId);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CaseType", CaseType);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@PolicyNo", PolicyNo);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CaseRecMode", CaseRecMode);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@InterpretationType", InterpretationType);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CaseRemark", CaseRemark);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@ReportName", ReportName);

            //SqlParameter paramReportData = new SqlParameter();
            //paramReportData.DbType.

            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@ReportData", ReportData);
            cmdInsertUpdateInterpretationCase.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            //cmdInsertUpdateReport.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateInterpretationCase.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadInterpretationCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadInterpretationCaseDetailsList = new SqlCommand("Exec proc_LoadInterpretationCaseDetails @EmployeeRefId, @RoleId, @LoginType, @CorporateId", con);
            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadInterpretationCaseDetailsList.Parameters.Add(paramEmployeeRefId);
            cmdLoadInterpretationCaseDetailsList.Parameters.Add(paramRoleId);
            cmdLoadInterpretationCaseDetailsList.Parameters.Add(paramLoginType);
            cmdLoadInterpretationCaseDetailsList.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadInterpretationCaseDetailsList = new SqlDataAdapter(cmdLoadInterpretationCaseDetailsList);
            DataTable dtLoadInterpretationCaseDetailsList = new DataTable();

            daLoadInterpretationCaseDetailsList.Fill(dtLoadInterpretationCaseDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadInterpretationCaseDetailsList;

        }

        public DataTable LoadInterpretationClosedCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadInterpretationClosedCaseDetailsList = new SqlCommand("Exec proc_LoadInterpretationClosedCaseDetails @EmployeeRefId, @RoleId, @LoginType, @CorporateId", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            SqlParameter paramRoleId = new SqlParameter("@RoleId", RoleId);
            SqlParameter paramLoginType = new SqlParameter("@LoginType", LoginType);
            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdLoadInterpretationClosedCaseDetailsList.Parameters.Add(paramEmployeeRefId);
            cmdLoadInterpretationClosedCaseDetailsList.Parameters.Add(paramRoleId);
            cmdLoadInterpretationClosedCaseDetailsList.Parameters.Add(paramLoginType);
            cmdLoadInterpretationClosedCaseDetailsList.Parameters.Add(paramCorporateId);

            SqlDataAdapter daLoadInterpretationClosedCaseDetailsList = new SqlDataAdapter(cmdLoadInterpretationClosedCaseDetailsList);
            DataTable dtLoadInterpretationClosedCaseDetailsList = new DataTable();

            daLoadInterpretationClosedCaseDetailsList.Fill(dtLoadInterpretationClosedCaseDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadInterpretationClosedCaseDetailsList;

        }

        public DataSet LoadInterpretationCaseDetailsById(Int32 InterpretationCaseId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadInterpretationCaseDetails = new SqlCommand("Exec proc_LoadInterpretationCaseDetailsById @InterpretationCaseId", con);

            SqlParameter paramInterpretationCaseId = new SqlParameter("@InterpretationCaseId", InterpretationCaseId);

            cmdLoadInterpretationCaseDetails.Parameters.Add(paramInterpretationCaseId);

            SqlDataAdapter daLoadInterpretationCaseDetails = new SqlDataAdapter(cmdLoadInterpretationCaseDetails);
            DataSet dtLoadInterpretationCaseDetails = new DataSet();
            daLoadInterpretationCaseDetails.Fill(dtLoadInterpretationCaseDetails);
            return dtLoadInterpretationCaseDetails;
        }

        public void UploadInterpretationCaseDetails(string CaseType, Int32 CorporateId, DataTable dtInterCaseDetails)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdUploadCaseDetails = new SqlCommand("proc_UploadInterCaseDetails", con);
            cmdUploadCaseDetails.CommandType = CommandType.StoredProcedure;
                        
            cmdUploadCaseDetails.Parameters.AddWithValue("@CaseType", CaseType);
            cmdUploadCaseDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdUploadCaseDetails.Parameters.AddWithValue("@InterCaseDetail", dtInterCaseDetails);
            cmdUploadCaseDetails.ExecuteNonQuery();
        }

        public void InsertUpdateInterpretationReportDetails(Int32 InterReportUploadId, Int32 InterpretationCaseId, Int32 CaseRefId, string IECode, string Rate, string Rhythm, string Axis, string PWave, string PrIntervalPrSegment, string QWave, string RWave, string QRSComplex, string QTInterval, string STSegment, string TWave, string AdditionalWaves, string ChamberHypertrophy, string ECGOther, string ECGStatus, string ECGatRest, string TargetHeartRate, string StTChanges, string ChestPainAngina, string BPResponse, string DyspnoeaBreathlessness, string Arrhythmia, string ExerciseCapacity, string TMTStatus, string Suggestions, Int32 UploadBy, out string IsDataExists)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateInterpretationReport = new SqlCommand("InsertUpdateInterpretationReportDetails", con);
            cmdInsertUpdateInterpretationReport.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@InterReportUploadId", InterReportUploadId);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@InterpretationCaseId", InterpretationCaseId);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@CaseRefId", CaseRefId);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@IECode", IECode);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@Rate", Rate);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@Rhythm", Rhythm);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@Axis", Axis);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@PWave", PWave);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@PrIntervalPrSegment", PrIntervalPrSegment);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@QWave", QWave);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@RWave", RWave);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@QRSComplex", QRSComplex);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@QTInterval", QTInterval);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@STSegment", STSegment);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@TWave", TWave);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@AdditionalWaves", AdditionalWaves);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ChamberHypertrophy", ChamberHypertrophy);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ECGOther", ECGOther);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ECGStatus", ECGStatus);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ECGatRest", ECGatRest);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@TargetHeartRate", TargetHeartRate);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@StTChanges", StTChanges);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ChestPainAngina", ChestPainAngina);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@BPResponse", BPResponse);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@DyspnoeaBreathlessness", DyspnoeaBreathlessness);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@Arrhythmia", Arrhythmia);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@ExerciseCapacity", ExerciseCapacity);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@TMTStatus", TMTStatus);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@Suggestions", Suggestions);
            cmdInsertUpdateInterpretationReport.Parameters.AddWithValue("@UploadBy", UploadBy);

            //cmdInsertUpdateReport.ExecuteNonQuery();
            IsDataExists = cmdInsertUpdateInterpretationReport.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataTable LoadQCCheckListDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdQCCheckListDetails = new SqlCommand("Exec proc_LoadQCCheckList", con);

            SqlDataAdapter daQCCheckListDetails = new SqlDataAdapter(cmdQCCheckListDetails);
            DataTable dtQCCheckListDetails = new DataTable();

            daQCCheckListDetails.Fill(dtQCCheckListDetails);

            con.Close();
            con.Dispose();

            return dtQCCheckListDetails;

        }

        public DataTable LoadUserListDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadUserListDetails = new SqlCommand("Exec proc_LoadUserListDetails", con);

            SqlDataAdapter daLoadUserListDetails = new SqlDataAdapter(cmdLoadUserListDetails);
            DataTable dtLoadUserListDetails = new DataTable();

            daLoadUserListDetails.Fill(dtLoadUserListDetails);

            con.Close();
            con.Dispose();

            return dtLoadUserListDetails;
        }

        public void InsertUpdateInterpretationCaseAssign(Int32 InterpretationCaseId, Int32 CaseStatus, Int32 DoctorId, Int32 UpdatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCaseAssign = new SqlCommand("InsertUpdateInterpretationCaseAssign", con);
            cmdInsertUpdateCaseAssign.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCaseAssign.Parameters.AddWithValue("@InterpretationCaseId", InterpretationCaseId);
            cmdInsertUpdateCaseAssign.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateCaseAssign.Parameters.AddWithValue("@DoctorId", DoctorId);
            cmdInsertUpdateCaseAssign.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            cmdInsertUpdateCaseAssign.ExecuteNonQuery();
            //IsDataExists = cmdInsertUpdateCaseAssign.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public void UpdateInterpretationCaseDetailsByDoctor(Int32 InterpretationCaseId, Int32 CaseStatus, string DoctorReport, Int32 UpdatedBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdInsertUpdateCaseRemark = new SqlCommand("UpdateInterpretationCaseDetailsByDoctor", con);
            cmdInsertUpdateCaseRemark.CommandType = CommandType.StoredProcedure;

            cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@InterpretationCaseId", InterpretationCaseId);
            cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@CaseStatus", CaseStatus);
            cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@DoctorReport", DoctorReport);
            cmdInsertUpdateCaseRemark.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            cmdInsertUpdateCaseRemark.ExecuteNonQuery();
            //IsDataExists = cmdInsertUpdateCaseRemark.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
        }

        public DataSet LoadInterpretationReportDetailsById(Int32 InterpretationCaseId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdLoadInterpretationReportDetails = new SqlCommand("Exec proc_LoadInterpretationReportDetailsById @InterpretationCaseId", con);

            SqlParameter paramInterpretationReportId = new SqlParameter("@InterpretationCaseId", InterpretationCaseId);

            cmdLoadInterpretationReportDetails.Parameters.Add(paramInterpretationReportId);

            SqlDataAdapter daLoadInterpretationReportDetails = new SqlDataAdapter(cmdLoadInterpretationReportDetails);
            DataSet dtLoadInterpretationReportDetails = new DataSet();
            daLoadInterpretationReportDetails.Fill(dtLoadInterpretationReportDetails);
            return dtLoadInterpretationReportDetails;
        }

        public DataTable LoadTestRemarkDetailsList(Int32 TestId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestRemarkDetailsList = new SqlCommand("Exec proc_LoadTestRemarkDetails @TestId", con);

            SqlParameter paramTestId = new SqlParameter("@TestId", TestId);

            cmdLoadTestRemarkDetailsList.Parameters.Add(paramTestId);

            SqlDataAdapter daLoadTestRemarkDetailsList = new SqlDataAdapter(cmdLoadTestRemarkDetailsList);
            DataTable dtLoadTestRemarkDetailsList = new DataTable();

            daLoadTestRemarkDetailsList.Fill(dtLoadTestRemarkDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestRemarkDetailsList;

        }

        public DataTable LoadTestPackageRemarkDetailsList(Int32 PackageId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdLoadTestPackageRemarkDetailsList = new SqlCommand("Exec proc_LoadTestPackageRemarkDetails @PackageId", con);

            SqlParameter paramPackageId = new SqlParameter("@PackageId", PackageId);

            cmdLoadTestPackageRemarkDetailsList.Parameters.Add(paramPackageId);

            SqlDataAdapter daLoadTestPackageRemarkDetailsList = new SqlDataAdapter(cmdLoadTestPackageRemarkDetailsList);
            DataTable dtLoadTestPackageRemarkDetailsList = new DataTable();

            daLoadTestPackageRemarkDetailsList.Fill(dtLoadTestPackageRemarkDetailsList);

            con.Close();
            con.Dispose();

            return dtLoadTestPackageRemarkDetailsList;

        }

        public Int32 SaveDoctorPrescriptionDetails(Int32 PrescriptionId, DateTime? PrescriptionDateTime, Int32 DoctorId, Int32 CorporateId, Int32 EmployeeRefId, Int32 Age, string Symptoms, string TestDetails, string PrescriptionDetails, string DietToBeFollow, DateTime? NextVisitDate, Int32 CreatedBy, DataTable dtMedicineDetails)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("proc_InsertUpdatePrescriptionDetails", con);
            cmdCaseLogDetails.CommandType = CommandType.StoredProcedure;

            cmdCaseLogDetails.Parameters.AddWithValue("@PrescriptionId", PrescriptionId);



            if (PrescriptionDateTime.Equals(null))
            {
                cmdCaseLogDetails.Parameters.AddWithValue("@PrescriptionDateTime", DBNull.Value);
                //paramVisitDateTime = new SqlParameter("@VisitDateTime", DBNull.Value);
            }
            else
            {
                cmdCaseLogDetails.Parameters.AddWithValue("@PrescriptionDateTime", PrescriptionDateTime);
                //paramVisitDateTime = new SqlParameter("@VisitDateTime", DOB);
            }

            //cmdCaseLogDetails.Parameters.AddWithValue("@PrescriptionDateTime", PrescriptionDateTime);
            cmdCaseLogDetails.Parameters.AddWithValue("@DoctorId", DoctorId);
            cmdCaseLogDetails.Parameters.AddWithValue("@CorporateId", CorporateId);
            cmdCaseLogDetails.Parameters.AddWithValue("@EmployeeRefId", EmployeeRefId);
            cmdCaseLogDetails.Parameters.AddWithValue("@Age", Age);
            cmdCaseLogDetails.Parameters.AddWithValue("@Symptoms", Symptoms);
            cmdCaseLogDetails.Parameters.AddWithValue("@TestDetails", TestDetails);
            cmdCaseLogDetails.Parameters.AddWithValue("@PrescriptionDetails", PrescriptionDetails);
            cmdCaseLogDetails.Parameters.AddWithValue("@DietToBeFollow", DietToBeFollow);
            if (NextVisitDate.Equals(null))
            {
                cmdCaseLogDetails.Parameters.AddWithValue("@NextVisitDate", DBNull.Value);
            }
            else
            {
                cmdCaseLogDetails.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
            }
            cmdCaseLogDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdCaseLogDetails.Parameters.AddWithValue("@MedicineDetails", dtMedicineDetails);

            Int32 Prescription_Id = 0;
            Prescription_Id = Convert.ToInt32(cmdCaseLogDetails.ExecuteScalar());


            return Prescription_Id;
            //SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            //DataTable dtCaseLogDetails = new DataTable();

            //daCaseLogDetails.Fill(dtCaseLogDetails);

            //return dtCaseLogDetails;
        }

        public DataTable SearchPrescriptionDetails(string Query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdSearch = new SqlCommand(Query, con);
            DataTable dtSearch = new DataTable();

            SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
            daSearch.Fill(dtSearch);
            return dtSearch;
        }

        public DataSet LoadPrescriptionDetailsById(Int32 PrescriptionId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdPrescriptionDetails = new SqlCommand("Exec proc_FetchPrescriptionDetailsById @PrescriptionId", con);

            SqlParameter paramPrescriptionId = new SqlParameter("@PrescriptionId", PrescriptionId);
            cmdPrescriptionDetails.Parameters.Add(paramPrescriptionId);

            SqlDataAdapter daPrescriptionDetails = new SqlDataAdapter(cmdPrescriptionDetails);
            DataSet dtPrescriptionDetails = new DataSet();

            daPrescriptionDetails.Fill(dtPrescriptionDetails);

            return dtPrescriptionDetails;
        }

        public DataSet LoadPatientHistory(Int32 EmployeeRefId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdPatientHistoryDetails = new SqlCommand("Exec proc_FetchPrescriptionDetailsHistoryById @EmployeeRefId", con);

            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", EmployeeRefId);
            cmdPatientHistoryDetails.Parameters.Add(paramEmployeeRefId);

            SqlDataAdapter daPatientHistoryDetails = new SqlDataAdapter(cmdPatientHistoryDetails);
            DataSet dtPatientHistoryDetails = new DataSet();

            daPatientHistoryDetails.Fill(dtPatientHistoryDetails);

            return dtPatientHistoryDetails;
        }

        public DataTable LoadPrescriptionDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCorporateDetails = new SqlCommand("Exec proc_FetchPrescriptionDetails", con);



            SqlDataAdapter daCorporateDetails = new SqlDataAdapter(cmdCorporateDetails);
            DataTable dtCorporateDetails = new DataTable();
            daCorporateDetails.Fill(dtCorporateDetails);
            con.Close();
            con.Dispose();
            return dtCorporateDetails;

        }

        public DataTable LoadDoctorSignature(Int32 DoctorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdDoctorSignature = new SqlCommand("Exec proc_LoadDoctorSignature @DoctorId", con);

            SqlParameter paramDoctorId = new SqlParameter("@DoctorId", DoctorId);



            cmdDoctorSignature.Parameters.Add(paramDoctorId);
            //cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daDoctorSignature = new SqlDataAdapter(cmdDoctorSignature);
            DataTable dtDoctorSignature = new DataTable();

            daDoctorSignature.Fill(dtDoctorSignature);

            return dtDoctorSignature;
        }

        public DataTable LoadMasterDoctorDocumentDropDown()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdDoctorDocumemt = new SqlCommand("Exec proc_LoadMasterDoctorDocumentDropDown", con);



            SqlDataAdapter daMasterDocument = new SqlDataAdapter(cmdDoctorDocumemt);
            DataTable dtDoctorDocument = new DataTable();
            daMasterDocument.Fill(dtDoctorDocument);
            con.Close();
            con.Dispose();
            return dtDoctorDocument;

        }

        public DataTable LoadCustomerDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadCustomerDetails @ConsultationCaseDetailsId,@ConsultationCaseAppointmentDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public DataTable LoadTeleMERQuestionAnswerDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("Exec proc_LoadTeleMERQuestionAnswerDetails @ConsultationCaseDetailsId,@ConsultationCaseAppointmentDetailsId", con);

            SqlParameter paramConsultationCaseDetailsId = new SqlParameter("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            SqlParameter paramConsultationCaseAppointmentDetailsId = new SqlParameter("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);


            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.Add(paramConsultationCaseAppointmentDetailsId);


            SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            DataTable dtCaseLogDetails = new DataTable();

            daCaseLogDetails.Fill(dtCaseLogDetails);

            return dtCaseLogDetails;
        }

        public void SaveQuestionnaireAnswerDocument(Int32 QuestionnaireAnswerDetailsId, DataTable dtTeleMERFiles)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("proc_InsertUpdateQuestionnaireAnswerDocument", con);
            cmdCaseLogDetails.CommandType = CommandType.StoredProcedure;


            cmdCaseLogDetails.Parameters.AddWithValue("@QuestionnaireAnswerDetailsId", QuestionnaireAnswerDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@QuestionnaireAnswerDocument", dtTeleMERFiles);

            //Int32 QuestionnaireAnswerDetailsId = 0;
            cmdCaseLogDetails.ExecuteNonQuery();


            //return QuestionnaireAnswerDetailsId;
            //SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
            //DataTable dtCaseLogDetails = new DataTable();

            //daCaseLogDetails.Fill(dtCaseLogDetails);

            //return dtCaseLogDetails;
        }

        public int SaveQCSummaryDetails(Int32 QCSummaryDetailsdId, Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, string Comments, Int32 CreatedBy, DataTable dtQCQuestionAnswer, DataTable dtTeleMERFiles, DataTable dtVideoFiles)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdCaseLogDetails = new SqlCommand("proc_SaveConsultationCaseDetails_QCSummaryDetails", con);
            cmdCaseLogDetails.CommandType = CommandType.StoredProcedure;

            cmdCaseLogDetails.Parameters.AddWithValue("@QCSummaryDetailsdId", QCSummaryDetailsdId);
            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseDetailsId", ConsultationCaseDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@ConsultationCaseAppointmentDetailsId", ConsultationCaseAppointmentDetailsId);
            cmdCaseLogDetails.Parameters.AddWithValue("@Comments", Comments);
            cmdCaseLogDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmdCaseLogDetails.Parameters.AddWithValue("@QCQuestionAnswer", dtQCQuestionAnswer);
            cmdCaseLogDetails.Parameters.AddWithValue("@TeleMERFiles", dtTeleMERFiles);
            cmdCaseLogDetails.Parameters.AddWithValue("@VideoMERFiles", dtVideoFiles);

            int i = Convert.ToInt32(cmdCaseLogDetails.ExecuteNonQuery());

            return i;



        }

        public Int32 InsertUpdateUserDetails(Int32 UserId,Int32 RoleId, Int32 SubRoleId, Int32 ReportingPersonId, string EmployeeId, string Name, string ContactNo, string EmailId, string Department, string WorkLocation,
string StateId, string WelnextBranchId, DateTime? JoiningDate, DateTime? RelievingDate, Int32 StatusId,Int32 CreatedBy)
        {
            Int32 User_Id = 0;
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmdUserDetails = new SqlCommand("proc_InsertUpdateUserDetails", con);
                cmdUserDetails.CommandType = CommandType.StoredProcedure;

                cmdUserDetails.Parameters.AddWithValue("@UserId", UserId);
                cmdUserDetails.Parameters.AddWithValue("@RoleId", RoleId);

                
                cmdUserDetails.Parameters.AddWithValue("@SubRoleId", SubRoleId);
                cmdUserDetails.Parameters.AddWithValue("@ReportingPersonId", ReportingPersonId);
                cmdUserDetails.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                cmdUserDetails.Parameters.AddWithValue("@Name", Name);
                cmdUserDetails.Parameters.AddWithValue("@ContactNo", ContactNo);
                cmdUserDetails.Parameters.AddWithValue("@EmailId", EmailId);
                cmdUserDetails.Parameters.AddWithValue("@Department", Department);
                cmdUserDetails.Parameters.AddWithValue("WorkLocation", WorkLocation);
                cmdUserDetails.Parameters.AddWithValue("@StateId", StateId);
                cmdUserDetails.Parameters.AddWithValue("@WelnextBranchId", WelnextBranchId);

                if (JoiningDate.Equals(null))
                {
                    cmdUserDetails.Parameters.AddWithValue("@JoiningDate", DBNull.Value);
                }
                else
                {
                    cmdUserDetails.Parameters.AddWithValue("@JoiningDate", JoiningDate);
                }
                if (RelievingDate.Equals(null))
                {
                    cmdUserDetails.Parameters.AddWithValue("@RelievingDate", DBNull.Value);
                }
                else
                {
                    cmdUserDetails.Parameters.AddWithValue("@RelievingDate", RelievingDate);

                }
                cmdUserDetails.Parameters.AddWithValue("@StatusId", StatusId);
                cmdUserDetails.Parameters.AddWithValue("@CreatedBy", CreatedBy);


                
                User_Id = Convert.ToInt32(cmdUserDetails.ExecuteScalar());


                
                //SqlDataAdapter daCaseLogDetails = new SqlDataAdapter(cmdCaseLogDetails);
                //DataTable dtCaseLogDetails = new DataTable();

                //daCaseLogDetails.Fill(dtCaseLogDetails);

                //return dtCaseLogDetails;
            }
            catch(Exception ex)
            {

            }
            return User_Id;
        }


    }

}