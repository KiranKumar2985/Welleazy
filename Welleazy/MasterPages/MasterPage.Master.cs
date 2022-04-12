using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] != null)
                {
                    Label1.Text = Session["DisplayName"].ToString();
                    LoadUserAccessRoles();

                    //Session["LocalDataTime"] = test_date.Text;
                    //string datetime = Session["LocalDataTime"].ToString();
                }
                //else
                //{
                    //Response.Write("<script>alert('Your session has expired!')</script>" + "<script>window.location.href='/Login.aspx';</script>");
                //}

            }


        }

        public void LoadUserAccessRoles()
        {
            //DataTable dtUserAccessRole = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            //dtUserAccessRole = BusinessAccessLayer.LoadUserAccessRoles(Convert.ToInt32(Session["UserId"].ToString()));

            //dtUserAccessRole = Session["RolePermissions"] as DataTable;

            string UserRoles = "";
            string Users_Premission = "";

            //if (dtUserAccessRole != null && dtUserAccessRole.Rows.Count > 0)
            //{
            //    UserRoles = dtUserAccessRole.Rows[0]["UserRolePermissions"].ToString();
            //}

            Users_Premission = Session["Permissions"].ToString();

            UserRoles = Session["RolePermissions"].ToString();

            string[] Permissions = Users_Premission.Split(',');

            for (int j = 0; j < Permissions.Length; j++)
            {
                if (Permissions[j] == "1")
                {
                    ClientManagement.Style.Add("Display", "Block");
                }
                if (Permissions[j] == "2")
                {
                    Test_Management.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "3")
                {
                    ServiceProviders.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "4")
                {
                    PysicalMedical.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "5")
                {
                    TeleVideoConsultation.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "6")
                {
                    UserMenu.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "7")
                {
                    MasterManagement.Style.Add("Display", "Block");
                }

                if (Permissions[j] == "8")
                {
                    Admin_Management.Style.Add("Display", "Block");
                }
                if (Permissions[j] == "10")
                {
                    Second_Opinion.Style.Add("Display", "Block");
                }
                if (Permissions[j] == "11")
                {
                    Doctor_Prescription.Style.Add("Display", "Block");
                }
            }

            string[] Roles = UserRoles.Split(',');

            for (int i = 0; i < Roles.Length; i++)
            {
                if (Roles[i] == "1")
                {
                    AddCorporateDetails.Style.Add("Display", "Block");
                }

                if (Roles[i] == "2")
                {
                    ListOfEmployees.Style.Add("Display", "Block");
                }
                if (Roles[i] == "3")
                {
                    IndividualTest.Style.Add("Display", "Block");
                }
                if (Roles[i] == "4")
                {
                    TestPackage.Style.Add("Display", "Block");
                }

                if (Roles[i] == "5")
                {
                    AddNewDC.Style.Add("Display", "Block");
                }

                if (Roles[i] == "6")
                {
                    SendDCRequest.Style.Add("Display", "Block");
                }

                if (Roles[i] == "7")
                {
                    DiagnosticCenter.Style.Add("Display", "Block");
                }

                if (Roles[i] == "8")
                {
                    ServiceProviderList.Style.Add("Display", "Block");
                }

                if (Roles[i] == "9")
                {
                    DCFeedBack.Style.Add("Display", "Block");
                }

                if (Roles[i] == "10")
                {
                    AddCase.Style.Add("Display", "Block");
                }

                if (Roles[i] == "11")
                {
                    CaseList.Style.Add("Display", "Block");
                }

                if (Roles[i] == "12")
                {
                    AppointmentList.Style.Add("Display", "Block");
                }

                if (Roles[i] == "13")
                {
                    ClosedAppointmentList.Style.Add("Display", "Block");
                }

                if (Roles[i] == "14")
                {
                    ConsultationCaseDetails.Style.Add("Display", "Block");
                }

                if (Roles[i] == "15")
                {
                    ViewConsultationCaseDetails.Style.Add("Display", "Block");
                }
                if (Roles[i] == "16")
                {
                    ConsultationCaseAppointmentDetails.Style.Add("Display", "Block");
                }
                if (Roles[i] == "17")
                {
                    ConsultationCaseClosedAppointmentDetails.Style.Add("Display", "Block");
                }

                if (Roles[i] == "18")
                {
                    AddUser.Style.Add("Display", "Block");
                }

                if (Roles[i] == "19")
                {
                    AddDoctor.Style.Add("Display", "Block");
                }
                if (Roles[i] == "20")
                {
                    UserList.Style.Add("Display", "Block");
                }
                if (Roles[i] == "21")
                {
                    Role.Style.Add("Display", "Block");
                }

                if (Roles[i] == "22")
                {
                    SubRole.Style.Add("Display", "Block");
                }

                if (Roles[i] == "23")
                {
                    UsersPermission.Style.Add("Display", "Block");
                }
                if (Roles[i] == "24")
                {
                    AddState.Style.Add("Display", "Block");
                }
                if (Roles[i] == "25")
                {
                    AddDistrict.Style.Add("Display", "Block");
                }

                if (Roles[i] == "26")
                {
                    AddBranch.Style.Add("Display", "Block");
                }

                if (Roles[i] == "27")
                {
                    AddSpecialities.Style.Add("Display", "Block");
                }
                if (Roles[i] == "28")
                {
                    AddDoctorQualification.Style.Add("Display", "Block");
                }
                if (Roles[i] == "29")
                {
                    AddTypeOfProvider.Style.Add("Display", "Block");
                }

                if (Roles[i] == "30")
                {
                    AddGenericTest.Style.Add("Display", "Block");
                }

                if (Roles[i] == "31")
                {
                    AddProduct.Style.Add("Display", "Block");
                }
                if (Roles[i] == "32")
                {
                    AddProductSubCategory.Style.Add("Display", "Block");
                }
                if (Roles[i] == "33")
                {
                    ProductServiceMapping.Style.Add("Display", "Block");
                }
                if (Roles[i] == "34")
                {
                    AdminLoginCreation.Style.Add("Display", "Block");
                }
                if (Roles[i] == "35")
                {
                    CorporateEmployeeLoginCreation.Style.Add("Display", "Block");
                }
                if (Roles[i] == "36")
                {
                    AddBranchDetails.Style.Add("Display", "Block");
                }
                if (Roles[i] == "37")
                {
                    QCCheckList.Style.Add("Display", "Block");
                }
                if (Roles[i] == "38")
                {
                    SecondOpinionAddCase.Style.Add("Display", "Block");
                }
                if (Roles[i] == "39")
                {
                    SecondOpinionActiveCase.Style.Add("Display", "Block");
                }
                if (Roles[i] == "40")
                {
                    SecondOpinionClosedCase.Style.Add("Display", "Block");
                }
                if (Roles[i] == "41")//Prescription
                {
                    PatientPrescription.Style.Add("Display", "Block");
                }
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            InsertLoginHistory();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Successfully Logout...!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
        }

        public void InsertLoginHistory()
        {
            try
            {


                string IPAddress = "";
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPAddress = ip.ToString();
                    }
                }

                string WebBrowserName = string.Empty;

                WebBrowserName = HttpContext.Current.Request.Browser.Browser;




                Bal BusinessAcessLayer = new Bal();
                BusinessAcessLayer.InsertLoginHistory(Convert.ToInt32(Session["LoginRefId"]), IPAddress, WebBrowserName);

            }
            catch (Exception ex)
            {

            }
        }
    }
}