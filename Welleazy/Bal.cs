using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Welleazy
{
    public class Bal
    {
        public int Login_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }

        //Tbl_DC_Information
        public int dc_id { get; set; }
        public int parent_dcid { get; set; }
        public int ic_id { get; set; }
        public string username { get; set; }
        public string type_of_provider { get; set; }
        public string type_of_specialty { get; set; }
        public string ownership { get; set; }
        public string corporate_group { get; set; }
        public string provider_setup { get; set; }
        public string service_area { get; set; }
        public string home_delivery { get; set; }
        public string delivery_tat { get; set; }
        public string hospital_name { get; set; }
        public string plot_no { get; set; }
        public string address { get; set; }
        public string area { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string stdcode { get; set; }
        public string landline_no { get; set; }
        public string mobile_no { get; set; }
        public string fax_no { get; set; }
        public string emailid { get; set; }
        public string website { get; set; }
        public string reconized_by { get; set; }
        public string reconized_by_others { get; set; }
        public string accreditation { get; set; }
        public string accreditation_others { get; set; }
        public string service_type { get; set; }
        public string ambulance { get; set; }
        public string ambulance_yes { get; set; }
        public string health_checkup { get; set; }
        public string bls_ambulance { get; set; }
        public string acls_ambulance { get; set; }
        public string specialties_available { get; set; }
        public int staff_strength { get; set; }
        public string doctor_consultants { get; set; }
        public string doctor_consultants_visiting { get; set; }
        public string account_no { get; set; }
        public string name_of_holder { get; set; }
        public string designation_holder { get; set; }
        public string bank_name { get; set; }
        public string branch { get; set; }
        public string ifsc_code { get; set; }
        public string list_of_provider_branch { get; set; }
        public string registration_certificate { get; set; }
        public string bio_medical_waste_mgmt_certificate { get; set; }
        public string building_permit { get; set; }
        public string fire_safety_license { get; set; }
        public string pndt_license { get; set; }
        public string radiation_protection_certificate { get; set; }
        public string no_objection_polution_ctrl { get; set; }
        public string nabh_nabl_iso_jci_other { get; set; }
        public string cc_bs_passbook { get; set; }
        public string pan_card { get; set; }
        public string neft_declaration_form { get; set; }
        public string gst_certificate { get; set; }
        public string hospital_opd_tariff { get; set; }
        public string list_of_tpa { get; set; }
        public string list_of_consultant { get; set; }
        public string opd_schedule_for_consultant { get; set; }
        public string any_other_document { get; set; }
        public string created_on { get; set; }
        public string created_by { get; set; }
        public string provider_url { get; set; }
        public int no_of_attempt { get; set; }

        //tbl_provider_manpower_staffing
        public int manpower_id { get; set; }
        //public int dc_id { get; set; }
        public string insurance_desk_title { get; set; }
        public string insurance_desk_name { get; set; }
        public string insurance_desk_designation { get; set; }
        public string insurance_desk_email { get; set; }
        public string insurance_desk_cellno { get; set; }
        public string business_development_title { get; set; }
        public string business_development_name { get; set; }
        public string business_development_designation { get; set; }
        public string business_development_email { get; set; }
        public string business_development_cellno { get; set; }
        public string finance_title { get; set; }
        public string finance_name { get; set; }
        public string finance_designation { get; set; }
        public string finance_email { get; set; }
        public string finance_cellno { get; set; }
        public string clinical_services_title { get; set; }
        public string clinical_services_name { get; set; }
        public string clinical_services_designation { get; set; }
        public string clinical_services_email { get; set; }
        public string clinical_services_cellno { get; set; }
        public string nursing_services_title { get; set; }
        public string nursing_services_name { get; set; }
        public string nursing_services_designation { get; set; }
        public string nursing_services_email { get; set; }
        public string nursing_services_cellno { get; set; }
        public string fund_transfer_title { get; set; }
        public string fund_transfer_name { get; set; }
        public string fund_transfer_designation { get; set; }
        public string fund_transfer_email { get; set; }
        public string fund_transfer_cellno { get; set; }
        public string cashless_opd_title { get; set; }
        public string cashless_opd_name { get; set; }
        public string cashless_opd_designation { get; set; }
        public string cashless_opd_email { get; set; }
        public string cashless_opd_cellno { get; set; }
        public string organization_title { get; set; }
        public string organization_name { get; set; }
        public string organization_designation { get; set; }
        public string organization_email { get; set; }
        public string organization_cellno { get; set; }
        public string business_spoc_title { get; set; }
        public string business_spoc_designation { get; set; }
        public string business_spoc_email { get; set; }
        public string business_spoc_cellno { get; set; }

        //tbl_provider_laboratory_status
        public int lab_id { get; set; }
        //public int dc_id { get; set; }
        public string hematology { get; set; }
        public string biochemistry { get; set; }
        public string microbiology { get; set; }
        public string pathology { get; set; }
        public string serology { get; set; }
        public string histopathology { get; set; }
        public string endocrinology { get; set; }
        public string cytology { get; set; }
        public string immunology { get; set; }
        public string x_ray { get; set; }
        public string digital_x_ray { get; set; }
        public string ultra_sound { get; set; }
        public string color_doppler { get; set; }
        public string mammogram { get; set; }
        public string ct_scan { get; set; }
        public string mri { get; set; }
        public string PET_Scan { get; set; }
        public string Nuclear_Imaging { get; set; }
        public string ECG { get; set; }
        public string PFT { get; set; }
        public string TMT { get; set; }
        public string Echo_2D { get; set; }
        public string fluoroscopy { get; set; }

        public void InsertUpdateServiceProviderDetails(Int32 dc_id, string sptoken_id, Int32 parent_dcid, string username, Int32 center_prioritization, string center_grading, string center_categorization, string center_status, Int32 type_of_provider, Int32 type_of_specialty, Int32 ownership, string corporate_group, Int32 CorporateId, string service_area, string home_delivery, string delivery_tat, string center_name, string plot_no, string address, string area, Int32 state, Int32 city, string pincode, string stdcode, string landline_no, string mobile_no, string fax_no, string emailid, string website, string reconized_by, string accreditation, Int32 service_type, string ambulance, string ambulance_yes, string health_checkup, Int32 bls_ambulance, Int32 acls_ambulance, string specialties_available, Int32 staff_strength, Int32 doctor_consultants, Int32 doctor_consultants_visiting, string account_no, string name_of_holder, string bank_name, string branch, string ifsc_code, string cancelled_cheque, string list_of_provider_branch, string registration_certificate, string bio_medical_waste_mgmt_certificate, string building_permit, string fire_safety_license, string pndt_license, string radiation_protection_certificate, string no_objection_polution_ctrl, string nabh_nabl_iso_jci_other, string cc_bs_passbook, string pan_card, string neft_declaration_form, string gst_certificate, string hospital_opd_tariff, string list_of_tpa, string list_of_consultant, string opd_schedule_for_consultant, string any_other_document, Int32 created_by, string provider_url, string otp, Int32 no_of_attempt, string deactivation_reason, DateTime? deactivation_date, Int32 deactivation_by, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateServiceProviderDetails(dc_id, sptoken_id, parent_dcid, username, center_prioritization, center_grading, center_categorization, center_status, type_of_provider, type_of_specialty, ownership, corporate_group, CorporateId, service_area, home_delivery, delivery_tat, center_name, plot_no, address, area, state, city, pincode, stdcode, landline_no, mobile_no, fax_no, emailid, website, reconized_by, accreditation, service_type, ambulance, ambulance_yes, health_checkup, bls_ambulance, acls_ambulance, specialties_available, staff_strength, doctor_consultants, doctor_consultants_visiting, account_no, name_of_holder, bank_name, branch, ifsc_code, cancelled_cheque, list_of_provider_branch, registration_certificate, bio_medical_waste_mgmt_certificate, building_permit, fire_safety_license, pndt_license, radiation_protection_certificate, no_objection_polution_ctrl, nabh_nabl_iso_jci_other, cc_bs_passbook, pan_card, neft_declaration_form, gst_certificate, hospital_opd_tariff, list_of_tpa, list_of_consultant, opd_schedule_for_consultant, any_other_document, created_by, provider_url, otp, no_of_attempt, deactivation_reason, deactivation_date, deactivation_by, out IsDataExists);

        }

        public void InsertUpdateServiceProviderDocumentDetails(Int32 dc_id,  string list_of_provider_branch, string registration_certificate, string bio_medical_waste_mgmt_certificate, string building_permit, string fire_safety_license, string pndt_license, string radiation_protection_certificate, string no_objection_polution_ctrl, string nabh_nabl_iso_jci_other, string cc_bs_passbook, string pan_card, string neft_declaration_form, string gst_certificate, string hospital_opd_tariff, string list_of_tpa, string list_of_consultant, string opd_schedule_for_consultant, string any_other_document, Int32 updated_by, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateServiceProviderDocumentDetails(dc_id, list_of_provider_branch, registration_certificate, bio_medical_waste_mgmt_certificate, building_permit, fire_safety_license, pndt_license, radiation_protection_certificate, no_objection_polution_ctrl, nabh_nabl_iso_jci_other, cc_bs_passbook, pan_card, neft_declaration_form, gst_certificate, hospital_opd_tariff, list_of_tpa, list_of_consultant, opd_schedule_for_consultant, any_other_document, updated_by, out IsDataExists);

        }

        public void InsertUpdateDCApprovedByPopup(Int32 dc_id, string center_status)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateDCApprovedByPopup(dc_id, center_status);

        }

        public void InsertUpdateTestDetails(Int32 TestId, Int32 CorporateId, string Status, string TestType, string VisitType, string SKUCode, string TestName, string TestCode, string NormalPrice, string HNIPrice, string Remark, string TestDescription, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateTestDetails(TestId, CorporateId, Status, TestType, VisitType, SKUCode, TestName, TestCode, NormalPrice, HNIPrice, Remark, TestDescription, CreatedBy, out IsDataExists);
        }

        public void InsertUpdatePackageDetails(Int32 PackageId, Int32 CorporateId, string ProductSKU, string PackageName, string TestIncluded, string NormalPackagePrice, string HNIPackagePrice, string Status, string Remark, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdatePackageDetails(PackageId, CorporateId, ProductSKU, PackageName, TestIncluded, NormalPackagePrice, HNIPackagePrice, Status, Remark, CreatedBy, out IsDataExists);
        }

        public void InsertUpdateEmployeeDetails(Int32 EmployeeRefId, string EmployeeId, string EmployeeName, string Address, string Emailid, string MobileNo, string Gender, DateTime? DOB, int State, int City, string Area, string Landmark, string Pincode, string GeoLocation, int CorporateId, int BranchId, string Services, string AccountActivationURL, DateTime? CreatedOn, int CreatedBy, DateTime? ModifiedOn, int ModifiedBy, DateTime? LastActiveDate, DateTime? LastInactiveDate, string InActiveReason, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateEmployeeDetails(EmployeeRefId, EmployeeId, EmployeeName, Address, Emailid, MobileNo, Gender, DOB, State, City, Area, Landmark, Pincode, GeoLocation, CorporateId, BranchId, Services, AccountActivationURL, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, LastActiveDate, LastInactiveDate, InActiveReason, IsActive, out IsDataExists);

        }
        public void InsertUpdateCustomerDetails(Int32 CustomerRefId, string CustomerId, string FirstName, string LastName, string CustomerName, string Address, string Emailid, string MobileNo, string OTP, string AccountActivationURL, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCustomerDetails(CustomerRefId, CustomerId, FirstName, LastName, CustomerName, Address, Emailid, MobileNo, OTP, AccountActivationURL, IsActive, out IsDataExists);
        }

        public DataTable LoadCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadCaseDetailsList = new DataTable();
            dtLoadCaseDetailsList = DataAccessLayer.LoadCaseDetailsList(EmployeeRefId, RoleId, LoginType, CorporateId);
            return dtLoadCaseDetailsList;
        }

        public DataTable LoadClosedAppointmentDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadClosedAppointmentDetails = new DataTable();
            dtLoadClosedAppointmentDetails = DataAccessLayer.LoadClosedAppointmentDetails(EmployeeRefId, RoleId, LoginType, CorporateId);
            return dtLoadClosedAppointmentDetails;
        }

        public DataTable LoadAppointmentDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAppointmentDetails = new DataTable();
            dtLoadAppointmentDetails = DataAccessLayer.LoadAppointmentDetails(EmployeeRefId, RoleId, LoginType, CorporateId);
            return dtLoadAppointmentDetails;
        }
        public DataTable LoadAppointmentDetailsCaseId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAppointmentDetails = new DataTable();
            dtLoadAppointmentDetails = DataAccessLayer.LoadAppointmentDetailsCaseId();
            return dtLoadAppointmentDetails;
        }

        public DataTable LoadTestDetailsList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadTestDetailsList = new DataTable();
            dtLoadTestDetailsList = DataAccessLayer.LoadTestDetailsList();
            return dtLoadTestDetailsList;
        }

        public DataTable LoadTestPackageDetailsList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadTestPackageDetailsList = new DataTable();
            dtLoadTestPackageDetailsList = DataAccessLayer.LoadTestPackageDetailsList();
            return dtLoadTestPackageDetailsList;
        }

        public DataTable LoadBranchList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadBranchList = new DataTable();
            dtLoadBranchList = DataAccessLayer.LoadBranchList();
            return dtLoadBranchList;
        }
        public DataTable LoadCaseStatusList(Int32 CaseFor)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadCaseStatusList = new DataTable();
            dtLoadCaseStatusList = DataAccessLayer.LoadCaseStatusList(CaseFor);
            return dtLoadCaseStatusList;
        }


        public DataTable LoadCityListSearch()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadCityListSearch = new DataTable();
            dtLoadCityListSearch = DataAccessLayer.LoadCityListSearch();
            return dtLoadCityListSearch;
        }
        public DataTable LoadCoporateList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadCoporateList = new DataTable();
            dtLoadCoporateList = DataAccessLayer.LoadCoporateList();
            return dtLoadCoporateList;
        }
        //public DataTable LoadCaseStatusDetails()
        //{
        //    DataTable dtCaseStatusDetails = new DataTable();
        //    Dal DataAccessLayer = new Dal();
        //    dtCaseStatusDetails = DataAccessLayer.LoadCaseStatusDetails();
        //    return dtCaseStatusDetails;
        //}

        public DataTable LoadCaseStatusDetailsById(int StatusId)
        {
            DataTable dtCaseStatusDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtCaseStatusDetails = DataAccessLayer.LoadCaseStatusDetailsById(StatusId);
            return dtCaseStatusDetails;
        }
        public DataTable LoadBranchDetails()
        {
            DataTable dtBranchDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtBranchDetails = DataAccessLayer.LoadBranchDetails();
            return dtBranchDetails;
        }
        public DataTable LoadBranchDetailsById(int BranchId)
        {
            DataTable dtBranchDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtBranchDetails = DataAccessLayer.LoadBranchDetailsById(BranchId);
            return dtBranchDetails;
        }
        public DataTable LoadStateDetails()
        {
            DataTable dtStateDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtStateDetails = DataAccessLayer.LoadStateDetails();
            return dtStateDetails;
        }

        public DataTable LoadStateDetailsDropDown()
        {
            DataTable dtStateDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtStateDetails = DataAccessLayer.LoadStateDetailsDropDown();
            return dtStateDetails;
        }

        public DataTable LoadStateDetailsById(int StateId)
        {
            DataTable dtStateDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtStateDetails = DataAccessLayer.LoadStateDetailsById(StateId);
            return dtStateDetails;
        }

        public DataTable LoadDistrict()
        {
            DataTable dtDistrict = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDistrict = DataAccessLayer.LoadDistrict();
            return dtDistrict;
        }

        public DataTable LoadDistrictById(int DistrictId)
        {
            DataTable dtDistrict = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDistrict = DataAccessLayer.LoadDistrictById(DistrictId);
            return dtDistrict;
        }



        public DataTable LoadSpecialities()
        {
            DataTable dtSpecialities = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSpecialities = DataAccessLayer.LoadSpecialities();
            return dtSpecialities;
        }

        public DataTable LoadSpecialitiesById(int SpecialityId)
        {
            DataTable dtSpecialities = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSpecialities = DataAccessLayer.LoadSpecialitiesById(SpecialityId);
            return dtSpecialities;
        }

        public DataTable LoadLoginType()
        {
            DataTable dtLoginType = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoginType = DataAccessLayer.LoadLoginType();
            return dtLoginType;
        }

        public DataTable LoadDomain()
        {
            DataTable dtDomain = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDomain = DataAccessLayer.LoadDomain();
            return dtDomain;
        }

        public DataTable LoadPermission()
        {
            DataTable dtPermission = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtPermission = DataAccessLayer.LoadPermission();
            return dtPermission;
        }

        public DataTable LoadPermissionDropDown()
        {
            DataTable dtPermission = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtPermission = DataAccessLayer.LoadPermissionDropDown();
            return dtPermission;
        }

        public DataTable LoadPermissionById(int PermissionId)
        {
            DataTable dtSubPermission = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSubPermission = DataAccessLayer.LoadPermissionById(PermissionId);
            return dtSubPermission;
        }

        public DataSet LoadPermissionDetailsForLoginCreation()
        {
            DataSet dtPermission = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtPermission = DataAccessLayer.LoadPermissionDetailsForLoginCreation();
            return dtPermission;
        }

        public DataTable LoadSubPermission()
        {
            DataTable dtPermission = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtPermission = DataAccessLayer.LoadSubPermission();
            return dtPermission;
        }

        public DataTable LoadSubPermissionById(int SubPermissionId)
        {
            DataTable dtSubPermission = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSubPermission = DataAccessLayer.LoadSubPermissionById(SubPermissionId);
            return dtSubPermission;
        }

        public DataTable LoadDCCenterList(Int32 City)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadDCCenterList = new DataTable();
            dtLoadDCCenterList = DataAccessLayer.LoadDCCenterList(City);
            return dtLoadDCCenterList;
        }

        public void InsertUpdateCaseStatus(Int32 StatusId, String CaseStatusName, String CaseFor, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCaseStatus(StatusId, CaseStatusName, CaseFor, IsActive, out IsDataExists);

        }
        public void InsertUpdateBranch(Int32 BranchId, String BranchName, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateBranch(BranchId, BranchName, IsActive, out IsDataExists);

        }
        public void InsertUpdateState(Int32 StateId, String StateName, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateState(StateId, StateName, IsActive, out IsDataExists);

        }

        public void InsertUpdateDistrict(Int32 DistrictId, Int32 StateId, String DistrictName, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateDistrict(DistrictId, StateId, DistrictName, IsActive, out IsDataExists);

        }

        public void InsertUpdateSpeciality(Int32 SpecialityId, String Description, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateSpeciality(SpecialityId, Description, IsActive, out IsDataExists);

        }

        public void InsertUpdatePermission(Int32 PermissionId, String Description, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdatePermission(PermissionId, Description, IsActive, out IsDataExists);

        }

        public void InsertUpdateSubPermission(Int32 SubPermissionId, Int32 PermissionId, String SubPermission, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateSubPermission(SubPermissionId, PermissionId, SubPermission, IsActive, out IsDataExists);

        }

        public DataTable LoadCorporateDetails(Int32 CorporateId)
        {
            DataTable dtCorporateDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtCorporateDetails = DataAccessLayer.LoadCorporateDetails(CorporateId);
            return dtCorporateDetails;
        }

        public DataSet LoadCaseDetailsById(int CaseRefId)
        {
            DataSet dtCaseDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtCaseDetails = DataAccessLayer.LoadCaseDetailsById(CaseRefId);
            return dtCaseDetails;
        }
        public DataTable LoadEmployeeDetailsByOther(Int32 CorporateId, string EmployeeId, string MobileNo, string EmployeeName)
        {
            DataTable dtLoadEmployeeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadEmployeeDetails = DataAccessLayer.LoadEmployeeDetailsByOther(CorporateId, EmployeeId, MobileNo, EmployeeName);
            return dtLoadEmployeeDetails;
        }

        public DataTable SearchMultipleCaseList(string CorporateId, string CaseStatus, string ApplicationNo, string CaseId, string Branch, string AssignedAgent, string City, string MobileNo, string CaseOwnerName)
        {
            DataTable dtSearchMultipleCaseList = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSearchMultipleCaseList = DataAccessLayer.SearchMultipleCaseList(CorporateId, CaseStatus, ApplicationNo, CaseId, Branch, AssignedAgent, City, MobileNo, CaseOwnerName);
            return dtSearchMultipleCaseList;
        }
        public DataSet LoadAppointmentDetailsById(int AppointmentId)
        {
            DataSet dtAppointmentDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtAppointmentDetails = DataAccessLayer.LoadAppointmentDetailsById(AppointmentId);
            return dtAppointmentDetails;
        }
        public DataSet LoadCorporateDetailsById(int CorporateId)
        {
            DataSet dtCorporateDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtCorporateDetails = DataAccessLayer.LoadCorporateDetailsById(CorporateId);
            return dtCorporateDetails;
        }

        public void InsertUpdateCorporateDetails(Int32 CorporateId, String CorporateName, string MobileNo, string LandLineNo, string Emailid, string HeadOfficeAddress, string BranchOfficeAddress, DataTable dtContactDetails, DataTable dtDocumentDetails, int IsActive, string InsuranceStatus, DateTime? AgreementDate, DateTime? ExpiryDate, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCorporateDetails(CorporateId, CorporateName, MobileNo, LandLineNo, Emailid, HeadOfficeAddress, BranchOfficeAddress, dtContactDetails, dtDocumentDetails, IsActive, InsuranceStatus, AgreementDate, ExpiryDate, CreatedBy, out IsDataExists);

        }

        public void InsertUpdateCaseDetails(Int32 CaseRefId, string CaseId, string CaseEntryDatetime, Int32 WelleazyBranch, Int32 AssignedExecutive, string CaseRecMode, DateTime? CaseRecDatetime, Int32 CorporateId, Int32 BranchId, Int32 ProductId, string ServicesOffered, string EmployeeMobileNo, string EmployeeName, string EmployeeGender, Int32 EmployeeRefId, string EmployeeId, string EmployeeEmail, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeeLandmark, string EmployeePincode, string EmployeeAddress, string EmployeeGeoLocation, DateTime? EmployeeDOB, string MedicalTest, string ApplicationNo, Int32 CaseType, string PaymentType, Int32 CaseFor, Int32 CustomerProfile, string GenericTest, string EmployeeToPay, string DHOCAdvancePayment, int CaseStatus, DateTime? SchFollowupdate, string SchRemark, int IsActive, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCaseDetails(CaseRefId, CaseId, CaseEntryDatetime, WelleazyBranch, AssignedExecutive, CaseRecMode, CaseRecDatetime, CorporateId, BranchId, ProductId, ServicesOffered, EmployeeMobileNo, EmployeeName, EmployeeGender, EmployeeRefId, EmployeeId, EmployeeEmail, EmployeeState, EmployeeCity, EmployeeArea, EmployeeLandmark, EmployeePincode, EmployeeAddress, EmployeeGeoLocation, EmployeeDOB, MedicalTest, ApplicationNo, CaseType, PaymentType, CaseFor, CustomerProfile, GenericTest, EmployeeToPay, DHOCAdvancePayment, CaseStatus, SchFollowupdate, SchRemark, IsActive, CreatedBy, out IsDataExists);

        }

        public void InsertUpdateCaseDetailsByPopup(Int32 CaseRefId, int CaseStatus, DateTime? SchFollowupdate, string SchRemark, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCaseDetailsByPopup(CaseRefId, CaseStatus, SchFollowupdate, SchRemark, out IsDataExists);

        }

        public void InsertUpdateAppointmentDetails(Int32 AppointmentId, Int32 CaseRefId, string CaseId, string EmployeeName, string ApplicationNo, int BranchId, Int32 CorporateId, string EmployeeId, int CustomerProfile, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeePincode, int AppointmentStatus, DateTime? AppointmentDateTime, string VisitType, string ADHOC_ApprovalBased, string VideographyDone, string VideographyReason, string Comment, Int32 dc_id, string DCMobileNo, string DCName, string DCAddress, string IndividualTest, string PackageTest, int CaseStatus, int ReportStatus, Int32 ScheduledBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateAppointmentDetails(AppointmentId, CaseRefId, CaseId, EmployeeName, ApplicationNo, BranchId, CorporateId, EmployeeId, CustomerProfile, EmployeeState, EmployeeCity, EmployeeArea, EmployeePincode, AppointmentStatus, AppointmentDateTime, VisitType, ADHOC_ApprovalBased, VideographyDone, VideographyReason, Comment, dc_id, DCMobileNo, DCName, DCAddress, IndividualTest, PackageTest, CaseStatus, ReportStatus, ScheduledBy, out IsDataExists);

        }
        public DataTable DownloadCorporateDocument(Int32 CorporateDocumentDetailsId)
        {
            DataTable dtDocument = new DataTable();
            Dal DataAccessLayer = new Dal();

            dtDocument = DataAccessLayer.DownloadCorporateDocument(CorporateDocumentDetailsId);
            return dtDocument;
        }

        public void DeleteCorporateDocument(Int32 CorporateDocumentDetailsId)
        {

            Dal DataAccessLayer = new Dal();

            DataAccessLayer.DeleteCorporateDocument(CorporateDocumentDetailsId);

        }

        public void UploadTestDetails(Int32 CorporateId, DataTable dtTestDetails, Int32 CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UploadTestDetails(CorporateId, dtTestDetails, CreatedBy);
        }
        public void UploadEmployeeDetails(DataTable dtEmployeeDetails, string Services, Int32 CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UploadEmployeeDetails(dtEmployeeDetails, Services, CreatedBy);
        }

        public DataTable LoadCorporateDetailsDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCorporateDetails = new DataTable();
            dtCorporateDetails = DataAccessLayer.LoadCorporateDetailsDropDown();
            return dtCorporateDetails;
        }
        public DataTable LoadEmployeeDetails(int CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEmployeeDetails = new DataTable();
            dtEmployeeDetails = DataAccessLayer.LoadEmployeeDetails(CorporateId);
            return dtEmployeeDetails;
        }

        public int InsertUpdateLoginDetails(Int32 LoginRefId, Int32 EmployeeLoginRefId, Int32 CorporateId, string UserName, string Password, string DisplayName, string MobileNo, string EmailId, string RoleDescriptions, int IsActive, string IPAddress)
        {
            int i;
            Dal DAtaAccessLayer = new Dal();
            i = DAtaAccessLayer.InsertUpdateLoginDetails(LoginRefId, EmployeeLoginRefId, CorporateId, UserName, Password, DisplayName, MobileNo, EmailId, RoleDescriptions, IsActive, IPAddress);
            return i;
        }

        public DataTable VerifyLogin(string UserName, string Password)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtVerifyLogin = new DataTable();
            return dtVerifyLogin = DataAccessLayer.VerifyLogin(UserName, Password);
        }

        public DataTable VerifyMasterLogin(string UserName, string Password)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtVerifyMasterLogin = new DataTable();
            return dtVerifyMasterLogin = DataAccessLayer.VerifyMasterLogin(UserName, Password);
        }

        public DataTable VerifyMasterLoginMO(string UserName, string Password)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtVerifyMasterLogin = new DataTable();
            return dtVerifyMasterLogin = DataAccessLayer.VerifyMasterLoginMO(UserName, Password);
        }
        public DataTable LoadUserAccessRoles(Int32 UserId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadPermissionDetails = new DataTable();
            dtLoadPermissionDetails = DataAccessLayer.LoadUserAccessRoles(UserId);
            return dtLoadPermissionDetails;
        }

        public DataSet LoadPermissionDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtLoadPermissionDetails = new DataSet();
            dtLoadPermissionDetails = DataAccessLayer.LoadPermissionDetails();
            return dtLoadPermissionDetails;
        }
        public DataTable LoadProfileTypes()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadProfileTypes = new DataTable();
            dtLoadProfileTypes = DataAccessLayer.LoadProfileTypes();
            return dtLoadProfileTypes;
        }

        public DataTable LoadUserRoles(Int32 RoleId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadProfileTypes = new DataTable();
            dtLoadProfileTypes = DataAccessLayer.LoadUserRoles(RoleId);
            return dtLoadProfileTypes;
        }

        public DataTable LoadUsers(Int32 RoleId, Int32 SubRoleId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadProfileTypes = new DataTable();
            dtLoadProfileTypes = DataAccessLayer.LoadUsers(RoleId, SubRoleId);
            return dtLoadProfileTypes;
        }

        public int InsertUserRolePermissions(Int32 UserId, string RolePermissions)
        {
            Dal DataAccessLayer = new Dal();
            int result = DataAccessLayer.InsertUserRolePermissions(UserId, RolePermissions);
            return result;

        }

        public DataTable FetchUserRolePermissionsByUserId(Int32 UserId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtFetchUserRolePermissionsByUserId = DataAccessLayer.FetchUserRolePermissionsByUserId(UserId);
            return dtFetchUserRolePermissionsByUserId;

        }

        public DataTable LoadPackageDetailsById(Int32 PackageId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.LoadPackageDetailsById(PackageId);
        }

        public DataTable LoadPackageDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.LoadPackageDetails();
        }

        public void InsertUpdatePackageDetails(Int32 PackageId, string ProductSKU, string PackageName, Int32 CorporateId, string RefferingChannel, string Name, string EmailId, string MobileNo, string ProductType, string TestIncluded, double NormalPrice, double HNIPrice, string AHC_Status, string ProductType_Consultation, string ConsultationTYpe, string DoctorSpecialization, string ConsultationStatus, string ProductType_SecondOpinion, double SecondOpinion_NorMalPrice, double SecondOpinion_HNIPrice, string SecondOpinion_Status, int IsActive, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdatePackageDetails(PackageId, ProductSKU, PackageName, CorporateId, RefferingChannel, Name, EmailId, MobileNo, ProductType, TestIncluded, NormalPrice, HNIPrice, AHC_Status, ProductType_Consultation, ConsultationTYpe, DoctorSpecialization, ConsultationStatus, ProductType_SecondOpinion, SecondOpinion_NorMalPrice, SecondOpinion_HNIPrice, SecondOpinion_Status, IsActive, CreatedBy, out  IsDataExists);

        }

        public void UploadPackageDetails(DataTable dtPackageDetails)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UploadPackageDetails(dtPackageDetails);
        }

        public void UploadTestPackageDetails(Int32 CorporateId, DataTable dtPackageDetails, Int32 CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UploadTestPackageDetails(CorporateId, dtPackageDetails, CreatedBy);
        }

        public void InsertUpdateDoctorDetails(Int32 DoctorId, string DoctorName, string EmailId, string ContactNo, string AlternateContactNo,
           string DoctorLanguage, Int32 DoctorQualification, string RegistrationNumber, string PANCard, string DoctorAddress, Int32 StateId, Int32 DistrictId, string Area,
           double TeleMERRate, double TeleVideoRate,
           string AccountNumber, string BankName, string AccountHolderName, string BankBranch, string IFSCCode, int IsActive, Int32 CreatedBy, DataTable dtDoctorDocument, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateDoctorDetails(DoctorId, DoctorName, EmailId, ContactNo, AlternateContactNo,
             DoctorLanguage, DoctorQualification, RegistrationNumber, PANCard, DoctorAddress, StateId, DistrictId, Area,
             TeleMERRate, TeleVideoRate,
             AccountNumber, BankName, AccountHolderName, BankBranch, IFSCCode, IsActive, CreatedBy, dtDoctorDocument, out IsDataExists);

        }

        public DataTable LoadDoctorDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.LoadDoctorDetails();
        }

        public DataTable FetchDoctorDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.FetchDoctorDetails();
        }

        public DataSet FetchDoctorDetailsById(Int32 DoctorId)
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtDoctorDetails = new DataSet();
            return dtDoctorDetails = DataAccessLayer.FetchDoctorDetailsById(DoctorId);
        }

        public DataTable GenearateEConsultancyCaseId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.GenearateEConsultancyCaseId();
            return dtCaseId;
        }

        public DataTable LoadEConsultantCaseDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadEConsultantCaseDetails();
            return dtCaseId;
        }

        public DataTable LoadEConsultantCaseDetailsById(Int32 EConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadEConsultantCaseDetailsById(EConsultantCaseDetailsId);
            return dtCaseId;
        }

        public void InsertUpdateEConsultantCaseDetails(Int32 EConsultantCaseDetailsId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
          Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
Int32 CorporateBranchId, Int32 ServicesOffered, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived,
Int32 ConsultationType, Int32 CaseType, int PaymentType, int CaseFor, int CustomerProfile, int PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateEConsultantCaseDetails(EConsultantCaseDetailsId, CaseId, BranchId, CaseEntryDateTime, AssignedExecutiveId,
           CaseReceivedMode, CaseRecievedDateTime, CorporateId,
 CorporateBranchId, ServicesOffered, EmployeeName, MobileNo, GenderId, EMailId, NoOfFreeConsultations, NoOfConsultationReceived,
 ConsultationType, CaseType, PaymentType, CaseFor, CustomerProfile, PrefferedLanguage, DoctorDateTime, DoctorId,
 DoctorQualificationId, CaseStatus, FollowUpDataTime, Remarks, CreatedBy, out  IsDataExists);

        }


        public DataTable GenearateSpecialistConsultancyCaseId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.GenearateSpecialistConsultancyCaseId();
            return dtCaseId;
        }

        public DataTable LoadSpecialistConsultantCaseDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadSpecialistConsultantCaseDetails();
            return dtCaseId;
        }

        public DataTable LoadSpecialistConsultantCaseDetailsById(Int32 SpecialistConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadSpecialistConsultantCaseDetailsById(SpecialistConsultantCaseDetailsId);
            return dtCaseId;
        }

        public void InsertUpdateSpecialityConsultantCaseDetails(Int32 SpecialityConsultantCaseDetailsId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
         Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
Int32 CorporateBranchId, Int32 ServicesOffered, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived,
Int32 ConsultationType, Int32 CaseType, int PaymentType, int CaseFor, int CustomerProfile, int PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateSpecialityConsultantCaseDetails(SpecialityConsultantCaseDetailsId, CaseId, BranchId, CaseEntryDateTime, AssignedExecutiveId,
           CaseReceivedMode, CaseRecievedDateTime, CorporateId,
 CorporateBranchId, ServicesOffered, EmployeeName, MobileNo, GenderId, EMailId, NoOfFreeConsultations, NoOfConsultationReceived,
 ConsultationType, CaseType, PaymentType, CaseFor, CustomerProfile, PrefferedLanguage, DoctorDateTime, DoctorId,
 DoctorQualificationId, CaseStatus, FollowUpDataTime, Remarks, CreatedBy, out IsDataExists);

        }

        public DataTable LoadDistrictDropDown(int StateId)
        {
            DataTable dtDistrict = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDistrict = DataAccessLayer.LoadDistrictDropDown(StateId);
            return dtDistrict;
        }

        public DataTable LoadMasterLanguageDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = DataAccessLayer.LoadMasterLanguageDropDown();
            return dtLanguage;
        }

        public DataTable LoadEConsultantAppointmentDeails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadEConsultantAppointmentDeails();
        }

        public DataTable LoadEConsultantAppointmentDeailsById(Int32 EConsultantAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadEConsultantAppointmentDeailsById(EConsultantAppointmentDetailsId);
        }

        public void InsertUpdateEConsultantDoctorAppointment(Int32 EConsultantAppointmentDetailsId, Int32 EConsultantCaseDetailsId, Int32 DoctorId,
 DateTime? AppointmentDateTime, Int32 AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateEConsultantDoctorAppointment(EConsultantAppointmentDetailsId, EConsultantCaseDetailsId, DoctorId, AppointmentDateTime, AppointmentStatus, CreatedBy, CaseStatus, ReportStatus, out IsDataExists);

        }
        public DataTable LoadSpecialistConsultantAppointmentDeails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadSpecialistConsultantAppointmentDeails();
        }

        public DataTable LoadSpecialistConsultantAppointmentDeailsById(Int32 EConsultantAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadSpecialistConsultantAppointmentDeailsById(EConsultantAppointmentDetailsId);
        }

        public void InsertUpdateSpecialistConsultantDoctorAppointment(Int32 SpecialistConsultantAppointmentDetailsId, Int32 SpecialistConsultantCaseDetailsId, Int32 DoctorId,
 DateTime? AppointmentDateTime, int AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateSpecialistConsultantDoctorAppointment(SpecialistConsultantAppointmentDetailsId, SpecialistConsultantCaseDetailsId, DoctorId, AppointmentDateTime, AppointmentStatus, CreatedBy, CaseStatus, ReportStatus, out IsDataExists);
        }

        public int CheckAppointment(Int32 EConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            int result = DataAccessLayer.CheckAppointment(EConsultantCaseDetailsId);
            return result;
        }



        public int CheckSpecialistAppointment(Int32 SpecialityConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            int result = DataAccessLayer.CheckSpecialistAppointment(SpecialityConsultantCaseDetailsId);
            return result;
        }

        public DataTable LoadEConsultantCloseAppointmentDeails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadEConsultantCloseAppointmentDeails();
        }

        public DataTable LoadSpecialistConsultantCloseAppointmentDeails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadSpecialistConsultantCloseAppointmentDeails();
        }

        public DataTable SearchPackageDetails(string SKUCode, string PackageName, string CorporateName, string SearchType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.SearchPackageDetails(SKUCode, PackageName, CorporateName, SearchType);
        }

        public DataTable SearchEConsultantCaseDetails(string CaseId, Int32 CorporateId, Int32 BranchId, string EmployeeName, string MobileNo, string EmailId, Int32 ConsultationType, Int32 DoctorId,
            Int32 CaseStatus, string SearchType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.SearchEConsultantCaseDetails(CaseId, CorporateId, BranchId, EmployeeName, MobileNo, EmailId, ConsultationType, DoctorId,
             CaseStatus, SearchType);
        }

        public DataTable SearchSpecialitiesConsultantCaseDetails(string CaseId, string CorporateName, string CaseStatus, string SearchType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPackageDetails = new DataTable();
            return dtPackageDetails = DataAccessLayer.SearchSpecialitiesConsultantCaseDetails(CaseId, CorporateName, CaseStatus, SearchType);
        }

        public DataTable LoadTestDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadTestDetailsList = new DataTable();
            dtLoadTestDetailsList = DataAccessLayer.LoadTestDropDown();
            return dtLoadTestDetailsList;
        }

        public DataTable LoadProductDetails()
        {
            DataTable dtProductDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtProductDetails = DataAccessLayer.LoadProductDetails();
            return dtProductDetails;
        }

        public DataTable LoadProductDetailsById(int ProductId)
        {
            DataTable dtProductDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtProductDetails = DataAccessLayer.LoadProductDetailsById(ProductId);
            return dtProductDetails;
        }

        public DataTable LoadProductDetailsDropDown()
        {
            DataTable dtProductDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtProductDetails = DataAccessLayer.LoadProductDetailsDropDown();
            return dtProductDetails;
        }
        
        public void InsertUpdateProduct(Int32 ProductId, String ProductName, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateProduct(ProductId, ProductName, IsActive, out IsDataExists);

        }

        public DataTable LoadProductSubCategory()
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadProductSubCategory = DataAccessLayer.LoadProductSubCategory();
            return dtLoadProductSubCategory;
        }
        public DataTable LoadProductSubCategoryById(int SubProductId)
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadProductSubCategory = DataAccessLayer.LoadProductSubCategoryById(SubProductId);
            return dtLoadProductSubCategory;
        }

        public void InsertUpdateProductSubCategory(Int32 SubProductId, Int32 ProductId, string SubProductCategory, string NormalPrice, string HNIPrice, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateProductSubCategory(SubProductId, ProductId, SubProductCategory, NormalPrice, HNIPrice, IsActive, out IsDataExists);

        }

        public DataTable LoadProductSubCategoryDropDown(int ProductId)
        {
            DataTable dtLoadProductSubCategory = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadProductSubCategory = DataAccessLayer.LoadProductSubCategoryDropDown(ProductId);
            return dtLoadProductSubCategory;
        }

        public DataSet LoadProductServicesForAssign()
        {
            DataSet dtLoadProductServices = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtLoadProductServices = DataAccessLayer.LoadProductServicesForAssign();
            return dtLoadProductServices;
        }

        public void InsertUpdateServicesAssigned(Int32 ProductAssignedId, Int32 LoginTypeId, Int32 CorporateId, Int32 BranchId, string ProductId, string SubProductId, DateTime? CreatedOn, Int32 CreatedBy, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateServicesAssigned(ProductAssignedId, LoginTypeId, CorporateId, BranchId, ProductId, SubProductId, CreatedOn, CreatedBy, IsActive, out IsDataExists);
        }

        public DataTable LoadAssignServicesList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAssignServices = new DataTable();
            dtLoadAssignServices = DataAccessLayer.LoadAssignServicesList();
            return dtLoadAssignServices;
        }

        public DataSet LoadAssignServicesListById(int ProductAssignedId)
        {
            DataSet dtLoadAssignServices = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtLoadAssignServices = DataAccessLayer.LoadAssignServicesListById(ProductAssignedId);
            return dtLoadAssignServices;
        }

        public DataTable LoadEConsultantTypeDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultationType = new DataTable();
            return dtEConsultationType = DataAccessLayer.LoadEConsultantTypeDropDown();
        }


        public DataTable LoadCustomerProfileDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultationType = new DataTable();
            return dtEConsultationType = DataAccessLayer.LoadCustomerProfileDropDown();
        }


        public DataTable LoadPaymentTypeDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultationType = new DataTable();
            return dtEConsultationType = DataAccessLayer.LoadPaymentTypeDropDown();
        }


        public DataTable LoadCaseReceivedModeDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultationType = new DataTable();
            return dtEConsultationType = DataAccessLayer.LoadCaseReceivedModeDropDown();
        }

        public DataTable GenerateConsultationCaseId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.GenerateConsultationCaseId();
            return dtCaseId;
        }

        public DataTable GenerateCaseId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.GenerateCaseId();
            return dtCaseId;
        }

        public DataTable LoadConsultationCaseDetailsById(Int32 ConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadConsultationCaseDetailsById(ConsultantCaseDetailsId);
            return dtCaseId;
        }

        public void InsertUpdateConsultationCaseDetails(Int32 ConsultationCaseDetailsId, int ConsultationCaseTypeId, string CaseId, Int32 BranchId, DateTime? CaseEntryDateTime, Int32 AssignedExecutiveId,
           Int32 CaseReceivedMode, DateTime? CaseRecievedDateTime, Int32 CorporateId,
Int32 CorporateBranchId, Int32 ServicesOffered, Int32 EmployeeRefId, string EmployeeName, string MobileNo, int GenderId, string EMailId, int NoOfFreeConsultations, int NoOfConsultationReceived, int IdProof, int State, int City, string CustomerPrefferedLanguage, DateTime? DOB,
Int32 ConsultationType, Int32 CaseType, int PaymentType, int PaymentStatus, int CaseFor, int CustomerProfile, string PrefferedLanguage, DateTime? DoctorDateTime, Int32 DoctorId,
int DoctorQualificationId, int CaseStatus, DateTime? FollowUpDataTime, string Remarks, Int32 CreatedBy, string ApplicationNo, string ActionPerformed, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateConsultationCaseDetails(ConsultationCaseDetailsId, ConsultationCaseTypeId, CaseId, BranchId, CaseEntryDateTime, AssignedExecutiveId,
           CaseReceivedMode, CaseRecievedDateTime, CorporateId,
 CorporateBranchId, ServicesOffered, EmployeeRefId, EmployeeName, MobileNo, GenderId, EMailId, NoOfFreeConsultations, NoOfConsultationReceived, IdProof, State, City, CustomerPrefferedLanguage, DOB,
 ConsultationType, CaseType, PaymentType, PaymentStatus, CaseFor, CustomerProfile, PrefferedLanguage, DoctorDateTime, DoctorId,
 DoctorQualificationId, CaseStatus, FollowUpDataTime, Remarks, CreatedBy, ApplicationNo, ActionPerformed, out IsDataExists);

        }



        public DataTable FetchEmployeeDetailsOnCorporateId(Int32 CorporateId, Int32 BranchId)
        {
            DataTable dtEmployeeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtEmployeeDetails = DataAccessLayer.FetchEmployeeDetailsonCorporateId(CorporateId, BranchId);
            return dtEmployeeDetails;
        }

        public DataTable LoadEmployeeDetailsById(Int32 EmployeeRefId)
        {
            DataTable dtEmployeeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtEmployeeDetails = DataAccessLayer.LoadEmployeeDetailsById(EmployeeRefId);
            return dtEmployeeDetails;
        }

        public DataTable SearchEmployeeDetails(string EmployeeName, string MobileNo)
        {
            DataTable dtLoadEmployeeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadEmployeeDetails = DataAccessLayer.SearchEmployeeDetails(EmployeeName, MobileNo);
            return dtLoadEmployeeDetails;
        }

        public DataTable LoadConsultationCaseAppointmentDeailsById(Int32 ConsultationCaseAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCaseAppointment = new DataTable();
            return dtConsultationCaseAppointment = DataAccessLayer.LoadConsultationCaseAppointmentDeailsById(ConsultationCaseAppointmentDetailsId);
        }

        public DataTable LoadConsultationCaseAppointmentDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCaseAppointment = new DataTable();
            return dtConsultationCaseAppointment = DataAccessLayer.LoadConsultationCaseAppointmentDeails(EmployeeRefId,RoleId,LoginType);
        }

        public void InsertUpdateConsultationCaseDoctorAppointment(Int32 ConsultationCaseAppointmentDetailsId, Int32 ConsultationCaseDetailsId, Int32 DoctorId,
 DateTime? AppointmentDateTime, Int32 AppointmentStatus, Int32 CreatedBy, string CaseStatus, string ReportStatus,int IsActive, out string IsDataExists,string ActionPerformed)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateConsultationCaseDoctorAppointment(ConsultationCaseAppointmentDetailsId, ConsultationCaseDetailsId, DoctorId, AppointmentDateTime, AppointmentStatus, CreatedBy, CaseStatus, ReportStatus,IsActive, out IsDataExists, ActionPerformed);

        }

        public DataTable LoadConsultationCaseDetails(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtCaseId = new DataTable();
            dtCaseId = DataAccessLayer.LoadConsultationCaseDetails(EmployeeRefId, RoleId, LoginType);
            return dtCaseId;
        }


        public DataTable LoadQualificationDetails()
        {
            DataTable dtQualificationDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtQualificationDetails = DataAccessLayer.LoadQualificationDetails();
            return dtQualificationDetails;
        }

        public DataTable LoadQualificationDetailsDropDown()
        {
            DataTable dtQualificationDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtQualificationDetails = DataAccessLayer.LoadQualificationDetailsDropDown();
            return dtQualificationDetails;
        }

        public DataTable LoadQualificationDetailsById(int StateId)
        {
            DataTable dtQualificationDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtQualificationDetails = DataAccessLayer.LoadQualificationDetailsById(StateId);
            return dtQualificationDetails;
        }

        public void InsertUpdateQualification(Int32 DoctorQualificationId, String Qualification, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateQualification(DoctorQualificationId, Qualification, IsActive, out IsDataExists);

        }

        public DataSet LoadBProductListById(int CorporateId, int BranchId)
        {
            DataSet dtProductDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtProductDetails = DataAccessLayer.LoadBProductListById(CorporateId, BranchId);
            return dtProductDetails;
        }

        public DataSet LoadProductListForEmployee(string ProductId, string ServicesAssigned)
        {
            DataSet dtProductDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtProductDetails = DataAccessLayer.LoadProductListForEmployee(ProductId, ServicesAssigned);
            return dtProductDetails;
        }

        public DataTable LoadCorporateBranchList(Int32 CorporateId)
        {
            DataTable dtCorporateBranchDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtCorporateBranchDetails = DataAccessLayer.LoadCorporateBranchList(CorporateId);
            return dtCorporateBranchDetails;

        }

        public DataTable LoadServicesForEmployee(string Services)
        {
            DataTable dtLoadProductServices = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadProductServices = DataAccessLayer.LoadServicesForEmployee(Services);
            return dtLoadProductServices;
        }


        public DataTable LoadConsultationCaseClosedAppointmentDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtEConsultantAppointment = new DataTable();
            return dtEConsultantAppointment = DataAccessLayer.LoadConsultationCaseClosedAppointmentDetails();
        }

        public DataTable LoadConsultationCaseServices(Int32 ConsultationType)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCaseServices = new DataTable();
            return dtConsultationCaseServices = DataAccessLayer.LoadConsultationCaseServices(ConsultationType);

        }

        public DataTable LoadDoctorQualificationDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtQualification = new DataTable();
            dtQualification = DataAccessLayer.LoadDoctorQualificationDropDown();
            return dtQualification;
        }


        public int CheckConsultationCaseAppointmentDetails(Int32 SpecialityConsultantCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            int result = DataAccessLayer.CheckConsultationCaseAppointmentDetails(SpecialityConsultantCaseDetailsId);
            return result;
        }


        public DataTable LoadSpecialitiesList()
        {
            Dal DataAccesslayer = new Dal();
            DataTable dtSpecialities = new DataTable();
            return dtSpecialities = DataAccesslayer.LoadSpecialitiesList();

        }
        public void InsertUpdateProvideType(Int32 ProviderTypeId, String ProviderType, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateProvideType(ProviderTypeId, ProviderType, IsActive, out IsDataExists);

        }

        public DataTable LoadProvideTypeDetails()
        {
            DataTable dtTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtTypeDetails = DataAccessLayer.LoadProvideTypeDetails();
            return dtTypeDetails;
        }

        public DataTable LoadProvideTypeDetailsDropDown()
        {
            DataTable dtTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtTypeDetails = DataAccessLayer.LoadProvideTypeDetailsDropDown();
            return dtTypeDetails;
        }

        public DataTable LoadProvideTypeDetailsById(int ProviderTypeId)
        {
            DataTable dtTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtTypeDetails = DataAccessLayer.LoadProvideTypeDetailsById(ProviderTypeId);
            return dtTypeDetails;
        }

        public DataTable LoadSpecialtyTypeDropDown()
        {
            DataTable dtSpecialtyTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtSpecialtyTypeDetails = DataAccessLayer.LoadSpecialtyTypeDropDown();
            return dtSpecialtyTypeDetails;
        }

        public DataTable LoadOwnershipDropDown()
        {
            DataTable dtOwnershipDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtOwnershipDetails = DataAccessLayer.LoadOwnershipDropDown();
            return dtOwnershipDetails;
        }

        public DataTable LoadReconizedList()
        {
            Dal DataAccesslayer = new Dal();
            DataTable dtReconizedList = new DataTable();
            return dtReconizedList = DataAccesslayer.LoadReconizedList();
            
        }

        public DataTable LoadAccreditationList()
        {
            Dal DataAccesslayer = new Dal();
            DataTable dtAccreditationList = new DataTable();
            return dtAccreditationList = DataAccesslayer.LoadAccreditationList();

        }

        public DataTable LoadServiceTypeDropDown()
        {
            DataTable dtServiceTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtServiceTypeDetails = DataAccessLayer.LoadServiceTypeDropDown();
            return dtServiceTypeDetails;
        }

        public DataTable LoadDistrictSearch(string StateId)
        {
            DataTable dtDistrict = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDistrict = DataAccessLayer.LoadDistrictSearch(StateId);
            return dtDistrict;
        }

        public DataTable SearchConsultationCaseDetails(string Query)
        {
            DataTable dtConsultationcaseDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            return dtConsultationcaseDetails = DataAccessLayer.SearchConsultationCaseDetails(Query);

        }

        public DataTable SearchCaseDetails(string Query)
        {
            DataTable dtCaseDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            return dtCaseDetails = DataAccessLayer.SearchCaseDetails(Query);

        }

        public DataTable SearchEmpDetails(string Query)
        {
            DataTable dtEmpDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            return dtEmpDetails = DataAccessLayer.SearchEmpDetails(Query);

        }

        //public DataTable SearchClosedAppointmentDetails(string Query)
        //{
        //    DataTable dtClosedAppointmentDetails = new DataTable();
        //    Dal DataAccessLayer = new Dal();
        //    return dtClosedAppointmentDetails = DataAccessLayer.SearchClosedAppointmentDetails(Query);

        //}

        public DataTable LoadDCListDetails()
        {
            DataTable dtDCListDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDCListDetails = DataAccessLayer.LoadDCListDetails();
            return dtDCListDetails;
        }

        public DataTable GenerateServiceProviderId()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtspId = new DataTable();
            dtspId = DataAccessLayer.GenerateServiceProviderId();
            return dtspId;
        }

        public DataTable LoadGenericTestDetails()
        {
            DataTable dtLoadGenericTestDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadGenericTestDetails = DataAccessLayer.LoadGenericTestDetails();
            return dtLoadGenericTestDetails;
        }

        public void InsertUpdateGenericTestDetails(Int32 GenericTestId, string VisitType, string TestName, string TestCode, string NormalPrice, string HNIPrice, string TestDescription, Int32 CreatedBy, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateGenericTestDetails(GenericTestId, VisitType, TestName, TestCode, NormalPrice, HNIPrice, TestDescription, CreatedBy, IsActive, out IsDataExists);
        }

        public DataTable LoadGenericTestDetailsById(int GenericTestId)
        {
            DataTable dtGenericTestDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtGenericTestDetails = DataAccessLayer.LoadGenericTestDetailsById(GenericTestId);
            return dtGenericTestDetails;
        }

        public DataTable LoadGenericTestAmount(string GenericTestId, Int32 CustomerProfileId)
        {
            DataTable dtAmountDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtAmountDetails = DataAccessLayer.LoadGenericTestAmount(GenericTestId, CustomerProfileId);
            return dtAmountDetails;
        }

        public void InsertUpdateHistoryAppointmentDetails(Int32 AppointmentHistId, Int32 AppointmentId, Int32 CaseRefId, string CaseId, string EmployeeName, string ApplicationNo, int BranchId, Int32 CorporateId, string EmployeeId, int CustomerProfile, Int32 EmployeeState, Int32 EmployeeCity, string EmployeeArea, string EmployeePincode, int AppointmentStatus, DateTime? AppointmentDateTime, string VisitType, string ADHOC_ApprovalBased, string VideographyDone, string VideographyReason, string Comment, Int32 dc_id, string DCMobileNo, string DCName, string DCAddress, string IndividualTest, string PackageTest, int CaseStatus, int ReportStatus, Int32 ScheduledBy, Int32 UpdatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateHistoryAppointmentDetails(AppointmentHistId, AppointmentId, CaseRefId, CaseId, EmployeeName, ApplicationNo, BranchId, CorporateId, EmployeeId, CustomerProfile, EmployeeState, EmployeeCity, EmployeeArea, EmployeePincode, AppointmentStatus, AppointmentDateTime, VisitType, ADHOC_ApprovalBased, VideographyDone, VideographyReason, Comment, dc_id, DCMobileNo, DCName, DCAddress, IndividualTest, PackageTest, CaseStatus, ReportStatus, ScheduledBy, UpdatedBy, out IsDataExists);

        }

        public DataTable LoadAppointmentHistoryDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAppointmentDetails = new DataTable();
            dtLoadAppointmentDetails = DataAccessLayer.LoadAppointmentHistoryDetails();
            return dtLoadAppointmentDetails;
        }

        public DataTable DCCenterListDetails(Int32 City, Int32 DCID)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadDCCenterDetails = new DataTable();
            dtLoadDCCenterDetails = DataAccessLayer.DCCenterListDetails(City, DCID);
            return dtLoadDCCenterDetails;
        }

        public DataTable LoadDoctorSearchByLanguage(string LanguageId)
        {
            DataTable dtDistrict = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtDistrict = DataAccessLayer.LoadDoctorSearchByLanguage(LanguageId);
            return dtDistrict;
        }

        public DataTable LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(string CustomerPrefferedLanguageId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLanguage = new DataTable();
            dtLanguage = DataAccessLayer.LoadDoctorLanguageDropDownByCustomerPrefferedLanguage(CustomerPrefferedLanguageId);
            return dtLanguage;
        }

        public DataTable LoadMasterIDProofDocumentDropDown()
        {
            DataTable dtIDProofDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtIDProofDetails = DataAccessLayer.LoadMasterIDProofDocumentDropDown();
            return dtIDProofDetails;
        }
        public DataTable LoadTestNPackageList(Int32 CorporateId, Int32 CaseRefId)
        {
            Dal DataAccesslayer = new Dal();
            DataTable dtTestNPackageList = new DataTable();
            return dtTestNPackageList = DataAccesslayer.LoadTestNPackageList(CorporateId, CaseRefId);

        }

        public DataTable LoadConsultationCaseHistoryByCaseId(Int32 ConsultationCaseDetailsId)
        {
            DataTable dtIDProofDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtIDProofDetails = DataAccessLayer.LoadConsultationCaseHistoryByCaseId(ConsultationCaseDetailsId);
            return dtIDProofDetails;
        }

        public DataTable LoadConsultationCaseAppointmentDetailsHistory()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCaseAppointment = new DataTable();
            return dtConsultationCaseAppointment = DataAccessLayer.LoadConsultationCaseAppointmentDetailsHistory();
        }

        public DataTable LoadAppointmentStatusList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAppointmentStatusList = new DataTable();
            dtLoadAppointmentStatusList = DataAccessLayer.LoadAppointmentStatusList();
            return dtLoadAppointmentStatusList;
        }

        public DataTable LoadGenderDropDown()
        {
            DataTable dtIDProofDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtIDProofDetails = DataAccessLayer.LoadGenderDropDown();
            return dtIDProofDetails;
        }

        public DataTable LoadMasterRelationShipDropDown()
        {
            DataTable dtIDProofDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtIDProofDetails = DataAccessLayer.LoadMasterRelationShipDropDown();
            return dtIDProofDetails;
        }

        public void InsertUpdateConsultationCaseDependentDetails(string CaseId, int EmployeeId, int CaseFor, string DependentName, DateTime? DOB, string MobileNo, string EMailId, int GenderId, Int32 ConsultationType, Int32 CaseType, string CustomerPrefferedLanguage)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateConsultationCaseDependentDetails(CaseId, EmployeeId, CaseFor, DependentName, DOB, MobileNo, EMailId, GenderId,
 ConsultationType, CaseType, CustomerPrefferedLanguage);

        }

        public DataTable LoadDependentCaseDetailsById(string EmployeeId, string CaseId)
        {
            DataTable dtCaseDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtCaseDetails = DataAccessLayer.LoadDependentCaseDetailsById(EmployeeId, CaseId);
            return dtCaseDetails;
        }

        public void InsertUpdateDependentCaseDetails(Int32 DependentId, string EmployeeId, int CaseRefId, string CaseId, int CaseFor, string DependentName, string DependentMobileNo, string DependentGender, DateTime? DependentDOB, string DependentAddress, string MedicalTest, out string IsDataExistsD)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateDependentCaseDetails(DependentId, EmployeeId, CaseRefId, CaseId, CaseFor, DependentName, DependentMobileNo, DependentGender, DependentDOB, DependentAddress, MedicalTest, out IsDataExistsD);

        }

        public DataSet LoadAdminDashBoard()
        {
            DataSet dtCaseDetails = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtCaseDetails = DataAccessLayer.LoadAdminDashBoard();
            return dtCaseDetails;
        }

        public void InsertUpdateBranchDetailsByCorporate(Int32 BranchDetailsId, int CorporateId, string Branch, string PersonName, string MobileNo, string EmailId, Int32 State, Int32 City, string Address, int IsActive, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateBranchDetailsByCorporate(BranchDetailsId, CorporateId, Branch, PersonName, MobileNo, EmailId, State, City, Address, IsActive, out IsDataExists);

        }

        public DataTable LoadBranchDetailsByIdForCorporate(int BranchDetailsId)
        {
            DataTable dtBranchDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtBranchDetails = DataAccessLayer.LoadBranchDetailsByIdForCorporate(BranchDetailsId);
            return dtBranchDetails;
        }

        public DataTable LoadTotalBranchDetailsList(Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadBranchDetailsList = new DataTable();
            dtLoadBranchDetailsList = DataAccessLayer.LoadTotalBranchDetailsList(CorporateId);
            return dtLoadBranchDetailsList;
        }

        public void CorporateLoginCreation(Int32 LoginRefId, Int32 CorporateId, Int32 EmployeeRefId, string UserName, string Password, string EmailId, string MobileNo, string RolePermissions, int IsActive, Int32 LoginId)
        {
            Dal DataAcceessLayer = new Dal();
            DataAcceessLayer.CorporateLoginCreation(LoginRefId, CorporateId, EmployeeRefId, UserName, Password, EmailId, MobileNo, RolePermissions, IsActive, LoginId);



        }

        public bool CheckEmail_MobileExists(string EmailId)
        {
            bool IsExists = false;
            Dal DataAccessLayer = new Dal();
            return IsExists = DataAccessLayer.CheckEmail_MobileExists(EmailId);
        }

        public DataTable LoadUsersBasedOnSubRole(Int32 SubRoleId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtUser = new DataTable();
            return dtUser = DataAccessLayer.LoadUsersBasedOnSubRole(SubRoleId);
        }

        public DataSet Verify_Login(string UserName, string Password)
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtVerifyLogin = new DataSet();
            return dtVerifyLogin = DataAccessLayer.Verify_Login(UserName, Password);
        }

        public void InsertLoginHistory(Int32 LoginRefId, string IPAddress, string Browser)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertLoginHistory(LoginRefId, IPAddress, Browser);
        }

        public void UpdateOTP(string UserName, string OTP)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UpdateOTP(UserName, OTP);
        }

        public bool CheckAccountStatus(string EmailId)
        {
            bool IsExists = false;
            Dal DataAccessLayer = new Dal();
            return IsExists = DataAccessLayer.CheckAccountStatus(EmailId);
        }

        public void UpdateAccountStatus(string EmailId)
        {

            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UpdateAccountStatus(EmailId);
        }

        public DataTable LoadLoginUserDetails(Int32 CorporateId, Int32 UserId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoginUserDetails = new DataTable();
            dtLoginUserDetails = DataAccessLayer.LoadLoginUserDetails(CorporateId, UserId);

            return dtLoginUserDetails;
        }

        public bool CheckUserNameAvailabilty(string UserName)
        {
            bool IsExists = false;
            Dal DataAccessLayer = new Dal();
            return IsExists = DataAccessLayer.CheckUserNameAvailabilty(UserName);
        }

        public DataTable LoadEmployeeDetailsCorporate(Int32 CorporateId)
        {
            DataTable dtEmployeeCorporateDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtEmployeeCorporateDetails = DataAccessLayer.LoadEmployeeDetailsCorporate(CorporateId);
            return dtEmployeeCorporateDetails;
        }

        public DataTable LoadReportStatusList()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtReportStatusList = new DataTable();
            dtReportStatusList = DataAccessLayer.LoadReportStatusList();
            return dtReportStatusList;
        }

        public DataSet LoadProductServicesForEmployee(string ProductId, Int32 CorporateId, Int32 CorporateBranchId)
        {
            DataSet dtLoadProductServices = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtLoadProductServices = DataAccessLayer.LoadProductServicesForEmployee(ProductId, CorporateId, CorporateBranchId);
            return dtLoadProductServices;
        }

        public DataTable LoadAssignExecutive()
        {
            DataTable dtAssignExecutiveDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtAssignExecutiveDetails = DataAccessLayer.LoadAssignExecutive();
            return dtAssignExecutiveDetails;
        }

        public void InsertUpdatePatientRegistrationDetails(string EmployeeCode, string EmployeeName, DateTime? DOB, Int32 GenderId, Int32 DepartmentId, string MobileNo, string EmailId, DateTime? VisitDateTime, string Diagnosis, string AdviceGiven, string DoctorName, DataTable MedicineDetails, Int32 CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdatePatientRegistrationDetails(EmployeeCode, EmployeeName, DOB, GenderId, DepartmentId, MobileNo, EmailId, VisitDateTime, Diagnosis, AdviceGiven, DoctorName, MedicineDetails, CreatedBy);

        }

        public DataTable LoadMedicineDropDown()
        {
            DataTable dtMedicineDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtMedicineDetails = DataAccessLayer.LoadMedicineDropDown();
            return dtMedicineDetails;
        }

        public DataTable LoadPatientRegistrationDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadPatientRegistrationDetails = new DataTable();
            dtLoadPatientRegistrationDetails = DataAccessLayer.LoadPatientRegistrationDetails();
            return dtLoadPatientRegistrationDetails;

        }

        public DataTable LoadPatientRegistrationDetailsById(Int32 PatientRegistrationFormId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadPatientRegistrationDetails = new DataTable();
            dtLoadPatientRegistrationDetails = DataAccessLayer.LoadPatientRegistrationDetailsById(PatientRegistrationFormId);
            return dtLoadPatientRegistrationDetails;

        }

        public DataSet LoadConsultationCaseLogDetails(Int32 ConsultationCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtLoadConsultationCaseLogDetails = new DataSet();
            dtLoadConsultationCaseLogDetails = DataAccessLayer.LoadConsultationCaseLogDetails(ConsultationCaseDetailsId);
            return dtLoadConsultationCaseLogDetails;
        }

        public DataTable LoadTeleVideoQCQuestions()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadConsultationCaseLogDetails = new DataTable();
            dtLoadConsultationCaseLogDetails = DataAccessLayer.LoadTeleVideoQCQuestions();
            return dtLoadConsultationCaseLogDetails;
        }

        public DataTable LoadCaseDetailsByIdForReport(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = DataAccessLayer.LoadCaseDetailsByIdForReport(ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId);

            return dtConsultationCasDetails;

        }

        public int SaveQCSummaryDetails(Int32 QCSummaryDetailsdId, Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, string Comments, Int32 CreatedBy, DataTable dtQCQuestionAnswer)
        {
            Dal DataAccessLayer = new Dal();
            int i = 0;
            return i = DataAccessLayer.SaveQCSummaryDetails(QCSummaryDetailsdId, ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId, Comments, CreatedBy, dtQCQuestionAnswer);

        }


        public DataTable LoadQCCaseSummaryDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = DataAccessLayer.LoadQCCaseSummaryDetails(ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId);

            return dtConsultationCasDetails;

        }
        public DataTable LoadQCQuestionAnswerDetails(Int32 ConsultationCaseDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = DataAccessLayer.LoadQCQuestionAnswerDetails(ConsultationCaseDetailsId);

            return dtConsultationCasDetails;

        }

        public DataTable LoadQuestionnaire()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadConsultationCaseLogDetails = new DataTable();
            dtLoadConsultationCaseLogDetails = DataAccessLayer.LoadQuestionnaire();
            return dtLoadConsultationCaseLogDetails;
        }

        public DataTable LoadTeleMERResults(Int32 QuestionnaireAnswerId)
        {
            DataTable dtTeleMERResults = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtTeleMERResults = DataAccessLayer.LoadTeleMERResults(QuestionnaireAnswerId);
            return dtTeleMERResults;
        }

        public Int32 SaveTelerMERQuestionAnswer(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, DataTable dtQuestionnaireAnswer)
        {
            Dal DataAccessLayer = new Dal();
            Int32 QuestionnaireAnswerDetailsId = 0;
            QuestionnaireAnswerDetailsId = DataAccessLayer.SaveTelerMERQuestionAnswer(ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId, dtQuestionnaireAnswer);
            return QuestionnaireAnswerDetailsId;
        }

        //public void InsertUpdateCaseRemarkDetails(Int32 CaseRemarkId, Int32 CaseRefId, string CaseId, string Remark, Int32 CaseStatus, int CreatedBy)
        //{
        //    Dal DataAccessLayer = new Dal();
        //    DataAccessLayer.InsertUpdateCaseRemarkDetails(CaseRemarkId, CaseRefId, CaseId, Remark, CaseStatus, CreatedBy);
        //}

        public void InsertUpdateAppointmentRemarkDetails(Int32 AppointmentRemarkId, Int32 CaseRefId, string Remark, Int32 AppointmentStatus, Int32 CaseStatus, Int32 ReportStatus, int CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateAppointmentRemarkDetails(AppointmentRemarkId, CaseRefId, Remark, AppointmentStatus, CaseStatus, ReportStatus, CreatedBy);
        }

        public void InsertUpdateReportRemarkDetails(Int32 ReportRemarkId, Int32 CaseRefId, string ReportRemark, Int32 RemarkType, Int32 CaseStatus, Int32 ReportStatus, int CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateReportRemarkDetails(ReportRemarkId, CaseRefId, ReportRemark, RemarkType, CaseStatus, ReportStatus, CreatedBy);
        }

        public DataTable LoadCaseRemarkDetailsList(Int32 CaseRefId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadCaseRemarkDetailsList = new DataTable();
            dtLoadCaseRemarkDetailsList = DataAccessLayer.LoadCaseRemarkDetailsList(CaseRefId);
            return dtLoadCaseRemarkDetailsList;
        }
        
        public DataTable LoadAppointmentRemarkDetailsList(Int32 CaseRefId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadAppointmentRemarkDetailsList = new DataTable();
            dtLoadAppointmentRemarkDetailsList = DataAccessLayer.LoadAppointmentRemarkDetailsList(CaseRefId);
            return dtLoadAppointmentRemarkDetailsList;
        }

        public DataTable LoadReportRemarkDetailsList(Int32 CaseRefId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadReportRemarkDetailsList = new DataTable();
            dtLoadReportRemarkDetailsList = DataAccessLayer.LoadReportRemarkDetailsList(CaseRefId);
            return dtLoadReportRemarkDetailsList;
        }

        public DataTable LoadUpdatedBy()
        {
            DataTable dtLoadUpdatedByDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtLoadUpdatedByDetails = DataAccessLayer.LoadUpdatedBy();
            return dtLoadUpdatedByDetails;
        }

        public DataTable LoadMasterGeoTaggingDropDown()
        {
            DataTable dtGeoTaggingDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtGeoTaggingDetails = DataAccessLayer.LoadMasterGeoTaggingDropDown();
            return dtGeoTaggingDetails;
        }
        public DataTable LoadTestNPackageListA(Int32 CorporateId, Int32 CaseRefId, Int32 AppointmentId)
        {
            Dal DataAccesslayer = new Dal();
            DataTable dtTestNPackageList = new DataTable();
            return dtTestNPackageList = DataAccesslayer.LoadTestNPackageListA(CorporateId, CaseRefId, AppointmentId);
        }

        public void InsertUpdateReportDetails(Int32 ReportId, Int32 CaseRefId, Int32 AppointmentId, DataTable dtAppointmentReport, string ReportType, Int32 ReportStatus, DateTime? DateOfClosureApproval, string PhotoId, string Photo, Int32 GeoTagging, string OutSourced, string OutSourcedTest, string ReportRecMode, string ReportRecFrom, string Comment, Int32 Report_Sent_by, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateReportDetails(ReportId, CaseRefId, AppointmentId, dtAppointmentReport, ReportType, ReportStatus, DateOfClosureApproval, PhotoId, Photo, GeoTagging, OutSourced, OutSourcedTest, ReportRecMode, ReportRecFrom, Comment, Report_Sent_by, out IsDataExists);

        }

        public DataTable GetReportonAppointmentId(Int32 AppointmentReportId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtRreport = new DataTable();
            dtRreport = DataAccessLayer.GetReportonAppointmentId(AppointmentReportId);
            return dtRreport;
        }

        public void InsertUpdateQCCheckListDetails(Int32 QReportId, Int32 ReportId, Int32 CaseRefId, Int32 AppointmentId, int Q1_InsuredName, int Q2_ClientId, string Q3_ClientIdNo, int Q4_LivePhoto, int Q5_FaceMatchScore, int Q6_AppDateMatch, string Q7_AppdateMatchIfNo, int Q8_DCNameMatch, int Q9_ReportDocSequence, int Q10_AadharNoMasked, 
                                                int Q11_ReportNConvention, string Q12_RCheckListOnSTV, int Q13_InterAdded, string Q14_MERDrName, string Q15_MERDrRegNo, string Q16_MERDrQualification, int Q17_Disclosures, int Q18_ApplicationNoMER, string Q19_OldApplicationNo, int Q20_MERDate,
                                                int Q21_BPReadingPulseRate, int Q22_FamilyHistory, int Q23_SAFFandIdProof, string Q24_SAFFandIdProofException, int Q25_HWDAMatchInReport, int Q26_AllMERQueAns,
                                                int Q27_AnyQueMarkedAsYesMER, int Q28_RemarkGivenAsYes, int Q29_VerifiedMER, int Q30_ReflexiveTest, string Q31_TestComponentLIP, string Q32_TestComponentLFT, int Q33_WearFaceMask, string QCComment, Int32 QC_ErrorType, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateQCCheckListDetails(QReportId, ReportId, CaseRefId, AppointmentId, Q1_InsuredName, Q2_ClientId, Q3_ClientIdNo, Q4_LivePhoto, Q5_FaceMatchScore,
                                                Q6_AppDateMatch, Q7_AppdateMatchIfNo, Q8_DCNameMatch, Q9_ReportDocSequence, Q10_AadharNoMasked, Q11_ReportNConvention, Q12_RCheckListOnSTV,
                                                Q13_InterAdded, Q14_MERDrName, Q15_MERDrRegNo, Q16_MERDrQualification, Q17_Disclosures, Q18_ApplicationNoMER, Q19_OldApplicationNo, Q20_MERDate,
                                                Q21_BPReadingPulseRate, Q22_FamilyHistory, Q23_SAFFandIdProof, Q24_SAFFandIdProofException, Q25_HWDAMatchInReport, Q26_AllMERQueAns,
                                                Q27_AnyQueMarkedAsYesMER, Q28_RemarkGivenAsYes, Q29_VerifiedMER, Q30_ReflexiveTest, Q31_TestComponentLIP, Q32_TestComponentLFT, Q33_WearFaceMask, QCComment, QC_ErrorType, out IsDataExists);

        }

        public DataTable LoadErrorTypeDropDown()
        {
            DataTable dtErrorTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtErrorTypeDetails = DataAccessLayer.LoadErrorTypeDropDown();
            return dtErrorTypeDetails;
        }
        public void InsertUpdateCaseDetailsOnCaseCompletion(Int32 CaseRefId, Int32 AppointmentId, Int32 CaseStatus, Int32 ReportStatus, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateCaseDetailsOnCaseCompletion(CaseRefId, AppointmentId, CaseStatus, ReportStatus, out IsDataExists);

        }

        public DataTable LoadInterpretationTypeDropDown()
        {
            DataTable dtInterpretationTypeDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtInterpretationTypeDetails = DataAccessLayer.LoadInterpretationTypeDropDown();
            return dtInterpretationTypeDetails;
        }

        public DataTable LoadInterpretationCaseStatusDropDown()
        {
            DataTable dtInterpretationCaseStatusDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtInterpretationCaseStatusDetails = DataAccessLayer.LoadInterpretationCaseStatusDropDown();
            return dtInterpretationCaseStatusDetails;
        } 

        public void InsertUpdateInterpretationCaseDetails(Int32 InterpretationCaseId, string CaseType, Int32 CorporateId, string CustomerName, string ApplicationNo, string PolicyNo, string CaseRecMode, int InterpretationType, string CaseRemark, Int32 CaseStatus, string ReportName, byte[] ReportData, Int32 CreatedBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateInterpretationCaseDetails(InterpretationCaseId, CaseType, CorporateId, CustomerName, ApplicationNo, PolicyNo, CaseRecMode, InterpretationType, CaseRemark, CaseStatus, ReportName, ReportData, CreatedBy, out IsDataExists);

        }

        public DataTable LoadInterpretationCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadInterpretationCaseDetailsList = new DataTable();
            dtLoadInterpretationCaseDetailsList = DataAccessLayer.LoadInterpretationCaseDetailsList(EmployeeRefId, RoleId, LoginType, CorporateId);
            return dtLoadInterpretationCaseDetailsList;
        }

        public DataTable LoadInterpretationClosedCaseDetailsList(Int32 EmployeeRefId, Int32 RoleId, Int32 LoginType, Int32 CorporateId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadInterpretationClosedCaseDetailsList = new DataTable();
            dtLoadInterpretationClosedCaseDetailsList = DataAccessLayer.LoadInterpretationClosedCaseDetailsList(EmployeeRefId, RoleId, LoginType, CorporateId);
            return dtLoadInterpretationClosedCaseDetailsList;
        }

        public DataSet LoadInterpretationCaseDetailsById(Int32 InterpretationCaseId)
        {
            DataSet dtLoadInterpretationCaseDetailsById = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtLoadInterpretationCaseDetailsById = DataAccessLayer.LoadInterpretationCaseDetailsById(InterpretationCaseId);
            return dtLoadInterpretationCaseDetailsById;
        }

        public void UploadInterpretationCaseDetails(string CaseType, Int32 CorporateId, DataTable dtInterCaseDetails)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UploadInterpretationCaseDetails(CaseType, CorporateId, dtInterCaseDetails);
        }

        public void InsertUpdateInterpretationReportDetails(Int32 InterReportUploadId, Int32 InterpretationCaseId, Int32 CaseRefId, string IECode, string Rate, string Rhythm, string Axis, string PWave, string PrIntervalPrSegment, string QWave, string RWave, string QRSComplex, string QTInterval, string STSegment, string TWave, string AdditionalWaves, string ChamberHypertrophy, string ECGOther, string ECGStatus, string ECGatRest, string TargetHeartRate, string StTChanges, string ChestPainAngina, string BPResponse, string DyspnoeaBreathlessness, string Arrhythmia, string ExerciseCapacity, string TMTStatus, string Suggestions, Int32 UploadBy, out string IsDataExists)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateInterpretationReportDetails(InterReportUploadId, InterpretationCaseId, CaseRefId, IECode, Rate, Rhythm, Axis, PWave, PrIntervalPrSegment, QWave, RWave, QRSComplex, QTInterval, STSegment, TWave, AdditionalWaves, ChamberHypertrophy, ECGOther, ECGStatus, ECGatRest, TargetHeartRate, StTChanges, ChestPainAngina, BPResponse, DyspnoeaBreathlessness, Arrhythmia, ExerciseCapacity, TMTStatus, Suggestions, UploadBy, out IsDataExists);

        }

        public DataTable LoadQCCheckListDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtQCCheckListDetails = new DataTable();
            dtQCCheckListDetails = DataAccessLayer.LoadQCCheckListDetails();
            return dtQCCheckListDetails;
        }

        public DataTable LoadUserListDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadUserListDetails = new DataTable();
            dtLoadUserListDetails = DataAccessLayer.LoadUserListDetails();
            return dtLoadUserListDetails;
        }

        public void InsertUpdateInterpretationCaseAssign(Int32 InterpretationCaseId, Int32 CaseStatus, Int32 DoctorId, Int32 UpdatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.InsertUpdateInterpretationCaseAssign(InterpretationCaseId, CaseStatus, DoctorId, UpdatedBy);

        }

        public void UpdateInterpretationCaseDetailsByDoctor(Int32 InterpretationCaseId, Int32 CaseStatus, string DoctorReport, Int32 UpdatedBy)
        {
            Dal DataAccessLayer = new Dal();
            DataAccessLayer.UpdateInterpretationCaseDetailsByDoctor(InterpretationCaseId, CaseStatus, DoctorReport, UpdatedBy);
        }

        public DataSet LoadInterpretationReportDetailsById(Int32 InterpretationCaseId)
        {
            DataSet dtLoadInterpretationReportDetailsById = new DataSet();
            Dal DataAccessLayer = new Dal();
            dtLoadInterpretationReportDetailsById = DataAccessLayer.LoadInterpretationReportDetailsById(InterpretationCaseId);
            return dtLoadInterpretationReportDetailsById;
        }

        public DataTable LoadTestRemarkDetailsList(Int32 TestId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadTestRemarkDetailsList = new DataTable();
            dtLoadTestRemarkDetailsList = DataAccessLayer.LoadTestRemarkDetailsList(TestId);
            return dtLoadTestRemarkDetailsList;
        }

        public DataTable LoadTestPackageRemarkDetailsList(Int32 PackageId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtLoadTestPackageRemarkDetailsList = new DataTable();
            dtLoadTestPackageRemarkDetailsList = DataAccessLayer.LoadTestPackageRemarkDetailsList(PackageId);
            return dtLoadTestPackageRemarkDetailsList;
        }

        public Int32 SaveDoctorPrescriptionDetails(Int32 PrescriptionId, DateTime? PrescriptionDateTime, Int32 DoctorId, Int32 CorporateId, Int32 EmployeeRefId, Int32 Age, string Symptoms, string TestDetails, string PrescriptionDetails, string DietToBeFollow, DateTime? NextVisitDate, Int32 CreatedBy, DataTable dtMedicineDetails)
        {
            Dal DataAccessLayer = new Dal();
            Int32 QuestionnaireAnswerDetailsId = 0;
            QuestionnaireAnswerDetailsId = DataAccessLayer.SaveDoctorPrescriptionDetails(PrescriptionId, PrescriptionDateTime, DoctorId, CorporateId, EmployeeRefId, Age, Symptoms, TestDetails, PrescriptionDetails, DietToBeFollow, NextVisitDate, CreatedBy, dtMedicineDetails);
            return QuestionnaireAnswerDetailsId;
        }

        public DataTable LoadPrescriptionDetails()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtPrescriptionDetails = new DataTable();
            dtPrescriptionDetails = DataAccessLayer.LoadPrescriptionDetails();
            return dtPrescriptionDetails;
        }

        public DataTable SearchPrescriptionDetails(string Query)
        {
            DataTable dtConsultationcaseDetails = new DataTable();
            Dal DataAccessLayer = new Dal();
            return dtConsultationcaseDetails = DataAccessLayer.SearchPrescriptionDetails(Query);

        }

        public DataSet LoadPrescriptionDetailsById(Int32 PrescriptionId)
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtCaseId = new DataSet();
            dtCaseId = DataAccessLayer.LoadPrescriptionDetailsById(PrescriptionId);
            return dtCaseId;
        }

        public DataSet LoadPatientHistory(Int32 EmployeeRefId)
        {
            Dal DataAccessLayer = new Dal();
            DataSet dtCaseId = new DataSet();
            dtCaseId = DataAccessLayer.LoadPatientHistory(EmployeeRefId);
            return dtCaseId;
        }

        public DataTable LoadDoctorSignature(Int32 DoctorId)
        {
            DataTable dtTeleMERResults = new DataTable();
            Dal DataAccessLayer = new Dal();
            dtTeleMERResults = DataAccessLayer.LoadDoctorSignature(DoctorId);
            return dtTeleMERResults;
        }

        public DataTable LoadMasterDoctorDocumentDropDown()
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtDoctorDocument = new DataTable();
            dtDoctorDocument = DataAccessLayer.LoadMasterDoctorDocumentDropDown();
            return dtDoctorDocument;
        }

        public DataTable LoadCustomerDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = DataAccessLayer.LoadCustomerDetails(ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId);

            return dtConsultationCasDetails;

        }

        public DataTable LoadTeleMERQuestionAnswerDetails(Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId)
        {
            Dal DataAccessLayer = new Dal();
            DataTable dtConsultationCasDetails = new DataTable();
            dtConsultationCasDetails = DataAccessLayer.LoadTeleMERQuestionAnswerDetails(ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId);

            return dtConsultationCasDetails;

        }

        public void SaveQuestionnaireAnswerDocument(Int32 QuestionnaireAnswerDetailsId, DataTable dtTeleMERFiles)
        {
            Dal DataAccessLayer = new Dal();
            //Int32 QuestionnaireAnswerDetailsId = 0;
            DataAccessLayer.SaveQuestionnaireAnswerDocument(QuestionnaireAnswerDetailsId, dtTeleMERFiles);
            //return QuestionnaireAnswerDetailsId;
        }

        public int SaveQCSummaryDetails(Int32 QCSummaryDetailsdId, Int32 ConsultationCaseDetailsId, Int32 ConsultationCaseAppointmentDetailsId, string Comments, Int32 CreatedBy, DataTable dtQCQuestionAnswer, DataTable dtTeleMERFiles, DataTable dtVideoFiles)
        {
            Dal DataAccessLayer = new Dal();
            int i = 0;
            return i = DataAccessLayer.SaveQCSummaryDetails(QCSummaryDetailsdId, ConsultationCaseDetailsId, ConsultationCaseAppointmentDetailsId, Comments, CreatedBy, dtQCQuestionAnswer, dtTeleMERFiles, dtVideoFiles);

        }

        public Int32 InsertUpdateUserDetails(Int32 UserId,Int32 RoleId, Int32 SubRoleId, Int32 ReportingPersonId,string EmployeeId,string Name,string ContactNo,string EmailId, string Department,string WorkLocation,
string StateId,string WelnextBranchId,DateTime? JoiningDate,DateTime? RelievingDate,Int32 StatusId,Int32 CreatedBy)
        {
            Dal DataAccessLayer = new Dal();
            Int32 User_Id = 0;
            UserId = DataAccessLayer.InsertUpdateUserDetails(UserId,RoleId, SubRoleId, ReportingPersonId, EmployeeId, Name, ContactNo, EmailId, Department, WorkLocation,
StateId, WelnextBranchId, JoiningDate, RelievingDate, StatusId,CreatedBy);
            return User_Id;
        }


    }
}