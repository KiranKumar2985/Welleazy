using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Telerik.Web.UI;

namespace Welleazy.Admin
{
    public partial class ListOfEmployee : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        static string ServicesAssigned = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    try
                    {

                        if (!Session["CorporateId"].ToString().Equals("0"))
                        {
                            StateList();
                            CorporateList();
                            EmployeeView.ActiveViewIndex = 0;
                            Variables.CorporateId = Convert.ToInt32(Session["CorporateId"].ToString());
                            LoadEmployeeDetailsCorporate();
                            rcbCorporateName.SelectedValue = Convert.ToInt32(Variables.CorporateId).ToString();
                            rcbCorporateName.Enabled = false;
                            rcbCorporate.SelectedValue = Convert.ToInt32(Variables.CorporateId).ToString();
                            rcbCorporate.Enabled = false;
                            NotUpdatedByEmployee.Visible = false;
                            BranchList();
                            BranchListSearch();
                        }
                        else
                        {
                            StateList();
                            CorporateList();
                            EmployeeView.ActiveViewIndex = 0;
                            LoadEmployeeDetailsCorporate();
                            rcbCorporateName.Enabled = true;
                            rcbCorporate.Enabled = true;
                        }

                        if (Session["LoginType"].Equals("2"))
                        {
                            SearchField.Visible = false;
                            GoButton.Visible = false;
                            int Empid = Convert.ToInt32(Session["EmployeeRefId"].ToString());
                            Variables.EmployeeRefId = Empid;
                            LoadEmployeeDetails();
                            EmployeePageHeading.Text = "Employee Profile";
                            NotUpdatedByEmployee.Visible = false;
                            services.Visible = false;
                            rcbBranchId.Enabled = false;
                            cmbProduct.Enabled = false;
                            txt_EmployeeId.ReadOnly = true;
                            txt_Emailid.ReadOnly = true;
                            EmployeeView.ActiveViewIndex = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Abandon();
                        Session.Clear();
                        Session.RemoveAll();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Session has Expired..!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
                    }


                    //if (Convert.ToInt32(Session["CorporateId"].ToString()) == 0)
                    //{

                    //    EmployeeDetails_All(Convert.ToInt32(Session["CorporateId"].ToString()));
                    //}
                    //else
                    //{
                    //    EmployeeDetails_All(Convert.ToInt32(Session["CorporateId"].ToString()));
                    //}

                }
            }
        }


        public void BranchListSearch()
        {
            cmbBranchId.Items.Clear();
            cmbBranchId.Items.Insert(0, "Select Branch");
            cmbBranchId.AppendDataBoundItems = true;
            try
            {


                DataTable dtBranchList = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtBranchList = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(rcbCorporate.SelectedValue));
                if (dtBranchList != null && dtBranchList.Rows.Count > 0)
                {
                    cmbBranchId.DataSource = dtBranchList;
                    cmbBranchId.DataTextField = "Branch";
                    cmbBranchId.DataValueField = "BranchDetailsId";
                    cmbBranchId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void StateList()
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtState = new DataTable();
            dtState = BusinessAccessLayer.LoadStateDetailsDropDown();

            if (dtState != null && dtState.Rows.Count > 0)
            {
                rcbState.DataSource = dtState;
                rcbState.DataTextField = "StateName";
                rcbState.DataValueField = "StateId";
                rcbState.DataBind();
            }

        }

        public void CorporateList()
        {
            DataTable dtLoadCorporateList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadCorporateList = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            rcbCorporateName.Items.Clear();
            rcbCorporateName.Items.Insert(0, "Select Corporate Name");
            if (dtLoadCorporateList != null && dtLoadCorporateList.Rows.Count > 0)
            {
                rcbCorporateName.DataSource = dtLoadCorporateList;
                rcbCorporateName.DataTextField = "CorporateName";
                rcbCorporateName.DataValueField = "CorporateId";
                rcbCorporateName.DataBind();

                rcbCorporate.DataSource = dtLoadCorporateList;
                rcbCorporate.DataTextField = "CorporateName";
                rcbCorporate.DataValueField = "CorporateId";
                rcbCorporate.DataBind();

            }
            else
            {
                rcbCorporateName.DataSource = new object[] { }; ;
                rcbCorporateName.DataBind();

                rcbCorporate.DataSource = new object[] { }; ;
                rcbCorporate.DataBind();
            }
        }

        protected void rcbState_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            rcbCity.Items.Clear();
            try
            {


                DataTable dtCity = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtCity = BusinessAccessLayer.LoadDistrictDropDown(Convert.ToInt32(rcbState.SelectedValue));
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    rcbCity.DataSource = dtCity;
                    rcbCity.DataTextField = "DistrictName";
                    rcbCity.DataValueField = "DistrictId";
                    rcbCity.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LoadEmployeeDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchEmployeeDetails = new SqlCommand("Exec proc_LoadEmployeeDetailsById @EmployeeRefId", con);
            SqlParameter paramEmployeeRefId = new SqlParameter("@EmployeeRefId", Variables.EmployeeRefId);

            cmdFetchEmployeeDetails.Parameters.Add(paramEmployeeRefId);

            SqlDataAdapter daEmployeeData = new SqlDataAdapter(cmdFetchEmployeeDetails);
            DataTable dtEmployeeDetails = new DataTable();
            daEmployeeData.Fill(dtEmployeeDetails);

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            {
                btnSave.Text = "Update";
                EmployeePageHeading.Text = "Update Corporate Employee";
                rdtCreatedOn.Enabled = false;
                txt_CreatedBy.Enabled = false;
                CorporateList();
                rcbCorporateName.SelectedValue = dtEmployeeDetails.Rows[0]["CorporateId"].ToString();
                BranchList();

                rcbBranchId.SelectedValue = dtEmployeeDetails.Rows[0]["BranchId"].ToString();
                rcbBranchId_SelectedIndexChanged(null, null);
                txt_EmployeeId.Text = dtEmployeeDetails.Rows[0]["EmployeeId"].ToString();
                //txt_FirstName.Text = dtEmployeeDetails.Rows[0]["FirstName"].ToString();
                //txt_LastName.Text = dtEmployeeDetails.Rows[0]["LastName"].ToString();
                txt_EmployeeName.Text = dtEmployeeDetails.Rows[0]["EmployeeName"].ToString();
                txt_Address.Text = dtEmployeeDetails.Rows[0]["Address"].ToString();
                txt_Emailid.Text = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                txt_MobileNo.Text = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();
                rcbGender.SelectedItem.Text = dtEmployeeDetails.Rows[0]["Gender"].ToString();
                rdpEmployeeDOB.DbSelectedDate = dtEmployeeDetails.Rows[0]["DOB"].ToString();
                rcbState.SelectedValue = dtEmployeeDetails.Rows[0]["State"].ToString();
                rcbState_SelectedIndexChanged(null, null);
                rcbCity.SelectedValue = dtEmployeeDetails.Rows[0]["City"].ToString();
                txt_AreaLocality.Text = dtEmployeeDetails.Rows[0]["Area"].ToString();
                txt_Landmark.Text = dtEmployeeDetails.Rows[0]["Landmark"].ToString();
                txt_Pincode.Text = dtEmployeeDetails.Rows[0]["Pincode"].ToString();
                txt_GeoLocation.Text = dtEmployeeDetails.Rows[0]["GeoLocation"].ToString();

                ServicesAssigned = dtEmployeeDetails.Rows[0]["Services"].ToString();
                string ProductId = dtEmployeeDetails.Rows[0]["ProductId"].ToString();

                String[] ProductValue = ProductId.Split(',');

                foreach (string s in ProductValue)
                {
                    foreach (RadComboBoxItem item in cmbProduct.Items)//ListItem item in rcbMedicalTest.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

                cmbProduct_SelectedIndexChanged(null, null);

                txt_ActivationURL.Text = dtEmployeeDetails.Rows[0]["AccountActivationURL"].ToString();
                rdtCreatedOn.DbSelectedDate = dtEmployeeDetails.Rows[0]["CreatedOn"].ToString();
                txt_CreatedBy.Text = dtEmployeeDetails.Rows[0]["CreatedBy"].ToString();
                rdtModifiedOn.DbSelectedDate = dtEmployeeDetails.Rows[0]["ModifiedOn"].ToString();
                //txt_ModifiedBy.Text = dtEmployeeDetails.Rows[0]["ModifiedBy"].ToString();
                dtplastActiveDate.DbSelectedDate = dtEmployeeDetails.Rows[0]["LastActiveDate"].ToString();
                dtplastInActiveDate.DbSelectedDate = dtEmployeeDetails.Rows[0]["LastInactiveDate"].ToString();
                txt_InactiveReason.Text = dtEmployeeDetails.Rows[0]["InActiveReason"].ToString();
                if (dtEmployeeDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }
        }

        public void LoadEmployeeDetailsCorporate()
        {
            DataTable dtCorporateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateDetails = BusinessAccessLayer.LoadEmployeeDetailsCorporate(Convert.ToInt32(Session["CorporateId"]));

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtCorporateDetails;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = null;
                rgCaseDetails.DataBind();
            }
        }


        public void EmployeeDetails_All(Int32 CorporateId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdAccessEmployeeDetails = new SqlCommand("Exec proc_LoadListOfEmployees @CorporateId", con);

            SqlParameter paramCorporateId = new SqlParameter("@CorporateId", CorporateId);

            cmdAccessEmployeeDetails.Parameters.Add(paramCorporateId);

            SqlDataAdapter daAccessEmployeeDetails = new SqlDataAdapter(cmdAccessEmployeeDetails);
            DataTable dtAccessEmployeeDetails = new DataTable();

            daAccessEmployeeDetails.Fill(dtAccessEmployeeDetails);

            if (dtAccessEmployeeDetails != null && dtAccessEmployeeDetails.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtAccessEmployeeDetails;
                rgCaseDetails.DataBind();
                rgCaseDetails.DataSource = dtAccessEmployeeDetails;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }

        }

        public void EmployeeDetails_Name()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchEmployeeDetailsList = new SqlCommand("proc_SearchListOfEmployees", con);
            cmdFetchEmployeeDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchEmployeeDetailsList.Parameters.AddWithValue("@Action", "FETCH_NAME");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedValue);

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtFetchEmployeeDetailsList;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }
        }

        public void EmployeeDetails_Email()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchEmployeeDetailsList = new SqlCommand("proc_SearchListOfEmployees", con);
            cmdFetchEmployeeDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchEmployeeDetailsList.Parameters.AddWithValue("@Action", "FETCH_EMAIL");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedValue);

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtFetchEmployeeDetailsList;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }
        }

        public void EmployeeDetails_Mobile()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchEmployeeDetailsList = new SqlCommand("proc_SearchListOfEmployees", con);
            cmdFetchEmployeeDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchEmployeeDetailsList.Parameters.AddWithValue("@Action", "FETCH_MOBILE");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedValue);

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtFetchEmployeeDetailsList;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }
        }

        public void EmployeeDetails_Status()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchEmployeeDetailsList = new SqlCommand("proc_SearchListOfEmployees", con);
            cmdFetchEmployeeDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchEmployeeDetailsList.Parameters.AddWithValue("@Action", "FETCH_STATUS");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedValue);

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtFetchEmployeeDetailsList;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { }; ;
                rgCaseDetails.DataBind();
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            string MainQuery = "Select ED.AccountActivationURL, ED.EmployeeRefId, ED.EmployeeId, ED.FirstName, ED.LastName, ED.EmployeeName, ED.Address," +
                                "ED.Emailid, ED.MobileNo, ED.Gender, ED.DOB, ED.State, MS.StateName, ED.City, MD.DistrictName, ED.Area, ED.Landmark, " +
                                "ED.Pincode, ED.GeoLocation, ED.CorporateId, MCD.CorporateName, ED.BranchId, CBD.Branch, ED.CreatedOn, ED.CreatedBy, " +
                                "ED.ModifiedOn, ED.ModifiedBy, ED.LastActiveDate, ED.LastInactiveDate, ED.InActiveReason, " +
                                " case when ED.IsActive = 1 then 'True' else 'False' End as IsActive from dbo.EmployeeDetails ED " +
                                " left Join Master_CorporateDetails MCD on MCD.CorporateId = ED.corporateid" +
                                " left join CorporateBranchDetails CBD on CBD.BranchDetailsId = ED.BranchId" +
                                " left join Master_State MS on MS.StateId = ED.State" +
                                " left join Master_District MD on MD.DistrictId = ED.City";

            string Query = "";
            string Branch = "";

            for (int i = 0; i < cmbBranchId.CheckedItems.Count; i++)
            {
                if (Branch == "")
                {
                    Branch = cmbBranchId.CheckedItems[i].Value.Trim();
                }
                else
                {
                    Branch += "," + cmbBranchId.CheckedItems[i].Value.Trim();
                }
            }

            if (rcbCorporate.SelectedValue != "0")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.CorporateId='" + rcbCorporate.SelectedItem.Value.Trim() + "'";
                }
                else
                {
                    Query += " And ED.CorporateId='" + rcbCorporate.SelectedItem.Value.Trim() + "'";
                }
            }

            //if (cmbBranchId.SelectedValue != "0")
            //{
            //    if (Query.Equals(""))
            //    {
            //        Query = " where ED.BranchId='" + cmbBranchId.SelectedItem.Value.Trim() + "'";
            //    }
            //    else
            //    {
            //        Query += " And ED.BranchId='" + cmbBranchId.SelectedItem.Value.Trim() + "'";
            //    }
            //}

            if (txt_EmpId.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.EmployeeId like '%" + txt_EmpId.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ED.EmployeeId like '%" + txt_EmpId.Text.Trim() + "%'";
                }
            }


            if (txt_Name.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.EmployeeName like '%" + txt_Name.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ED.EmployeeName like '%" + txt_Name.Text.Trim() + "%'";
                }
            }

            if (txt_Email.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.Emailid like '%" + txt_Email.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ED.Emailid like '%" + txt_Email.Text.Trim() + "%'";
                }
            }

            if (txt_Mobile.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.MobileNo like '%" + txt_Mobile.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And ED.MobileNo like '%" + txt_Mobile.Text.Trim() + "%'";
                }
            }

            if (DDL_Status.SelectedValue != "-1")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.IsActive='" + DDL_Status.SelectedItem.Value.Trim() + "'";
                }
                else
                {
                    Query += " And ED.IsActive='" + DDL_Status.SelectedItem.Value.Trim() + "'";
                }
            }

            if (Branch != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where ED.BranchId in (" + Branch + ")";
                }
                else
                {
                    Query += "And ED.BranchId in(" + Branch + ")";
                }
            }


            Bal BusinessAccessLayer = new Bal();
            DataTable dtEmployeeDetails = new DataTable();
            dtEmployeeDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query);

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtEmployeeDetails;
                rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { };
                rgCaseDetails.DataBind();
            }

            //txt_Name.Text = "";
            //txt_Email.Text = "";
            //txt_Mobile.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            //EmployeeDetails_All(Convert.ToInt32(Session["CorporateId"].ToString()));

        }

        //protected void rgCaseDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("Edit"))
        //    {

        //        int EmployeeRefId = 0;
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);

        //        GridViewRow row = rgCaseDetails.Rows[rowIndex];

        //        EmployeeRefId = Convert.ToInt32((row.FindControl("lblEmpId") as Label).Text);

        //        Variables.EmployeeRefId = EmployeeRefId;

        //        EmployeeView.ActiveViewIndex = 1;
        //        LoadEmployeeDetails();

        //    }

        //    //if (e.CommandName.Equals("Delete"))
        //    //{
        //    //    int EmployeeRefId = 0;
        //    //    int rowIndex = Convert.ToInt32(e.CommandArgument);

        //    //    GridViewRow row = rgCaseDetails.Rows[rowIndex];

        //    //    EmployeeRefId = Convert.ToInt32((row.FindControl("lblEmpId") as Label).Text);

        //    //    Variables.EmployeeRefId = EmployeeRefId;

        //    //    EmployeeView.ActiveViewIndex = 1;

        //    //}

        //    if (e.CommandName.Equals("SendLink"))
        //    {

        //        int rowIndex = Convert.ToInt32(e.CommandArgument);

        //        GridViewRow row = rgCaseDetails.Rows[rowIndex];

        //        string ActivationURL = (row.FindControl("lblActivationURL") as Label).Text;
        //        string EmailId = (row.FindControl("lblEmailId") as Label).Text;

        //        SendEmail(ActivationURL, EmailId);


        //    }


        //}

        public void SendEmail(string ActivationURL, string EmailId)
        {
            MailMessage mm = new MailMessage("kirans@welnext.com", EmailId);

            mm.Subject = "Password Recovery";
            mm.Body = string.Format("Dear User, Please Click on below link to activate your account. Activation link: {0} , Regards, Team WELLEAZY.", EmailId);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.rediffmailpro.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "4serna0e";
            NetworkCred.Password = "abc@123";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        protected void rgCaseDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        //protected void txt_Name_TextChanged(object sender, EventArgs e)
        //{
        //        txt_Email.Text = "";
        //        txt_Mobile.Text = "";
        //        DDL_Status.SelectedItem.Text = "Select Status";
        //        EmployeeDetails_Name();

        //}

        //protected void txt_Email_TextChanged(object sender, EventArgs e)
        //{

        //        txt_Name.Text = "";
        //        txt_Mobile.Text = "";
        //        DDL_Status.SelectedItem.Text = "Select Status";
        //        EmployeeDetails_Email();
        //}

        //protected void txt_Mobile_TextChanged(object sender, EventArgs e)
        //{

        //        txt_Name.Text = "";
        //        txt_Email.Text = "";
        //        DDL_Status.SelectedItem.Text = "Select Status";
        //        EmployeeDetails_Mobile();
        //}

        //protected void DDL_Status_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    txt_Name.Text = "";
        //    txt_Email.Text = "";
        //    txt_Mobile.Text = "";
        //    EmployeeDetails_Status();
        //}

        protected void rgCaseDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmployeeDetails_All(Convert.ToInt32(Session["CorporateId"].ToString()));
            //EmployeeView.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //EmployeeView.ActiveViewIndex = 0;
            //EmployeeDetails_All();
            if (Session["LoginType"].Equals("2"))
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                Response.Redirect("ListOfEmployee.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string emailid = txt_Emailid.Text.Trim();

                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                DataTable result = new DataTable();
                SqlCommand cmd = new SqlCommand("select substring('" + emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
                var adapter = new SqlDataAdapter(cmd);

                adapter.Fill(result);

                if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in") || result.Rows[0]["Ext"].Equals("net") || result.Rows[0]["Ext"].Equals("edu") || result.Rows[0]["Ext"].Equals("org"))
                {
                    lblEmailError.Text="";

                    Bal BusinessAccessLayer = new Bal();
                    string IsDataExists = "0";
                    //txt_CreatedBy.Text = "0";
                    //txt_ModifiedBy.Text = "0";

                    string strServices = "";
                    for (int Index = 0; Index < rgProductServices.Items.Count; Index++)
                    {
                        RadGrid rgvDefaultRoleTasksDepth = (RadGrid)rgProductServices.Items[Index].FindControl("rgProductServicesDepth");

                        for (int IndexJ = 0; IndexJ < rgvDefaultRoleTasksDepth.Items.Count; IndexJ++)
                        {
                            CheckBoxList cbTasks = (CheckBoxList)rgvDefaultRoleTasksDepth.Items[0].FindControl("cbTasks");

                            for (int indexK = 0; indexK < cbTasks.Items.Count; indexK++)
                            {
                                if (cbTasks.Items[indexK].Selected == true)
                                {
                                    if (strServices.Trim() == "")
                                        strServices = cbTasks.Items[indexK].Value.Trim();
                                    else
                                        strServices += "," + cbTasks.Items[indexK].Value.Trim();
                                }
                            }
                        }
                    }

                    if (btnSave.Text.Equals("Save"))
                    {


                        BusinessAccessLayer.InsertUpdateEmployeeDetails(0, txt_EmployeeId.Text.Trim(), txt_EmployeeName.Text.Trim(),
                            txt_Address.Text.Trim(), txt_Emailid.Text.Trim(), txt_MobileNo.Text.Trim(),
                            rcbGender.SelectedItem.Text.Trim(),
                            rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                            Convert.ToInt32(rcbState.SelectedValue),
                            Convert.ToInt32(rcbCity.SelectedValue),
                            txt_AreaLocality.Text.Trim(),
                            txt_Landmark.Text.Trim(),
                            txt_Pincode.Text.Trim(),
                            txt_GeoLocation.Text.Trim(),
                            Convert.ToInt32(rcbCorporateName.SelectedValue),
                            Convert.ToInt32(rcbBranchId.SelectedValue), strServices,
                            txt_ActivationURL.Text.Trim(),
                            rdtCreatedOn.DateInput.SelectedDate.Equals(null) ? nul : rdtCreatedOn.DateInput.SelectedDate.Value,
                            Convert.ToInt32(Session["LoginRefId"]), rdtModifiedOn.DateInput.SelectedDate.Equals(null) ? nul : rdtModifiedOn.DateInput.SelectedDate.Value,
                            0, dtplastActiveDate.DateInput.SelectedDate.Equals(null) ? nul : dtplastActiveDate.DateInput.SelectedDate.Value,
                            dtplastInActiveDate.DateInput.SelectedDate.Equals(null) ? nul : dtplastInActiveDate.DateInput.SelectedDate.Value,
                            txt_InactiveReason.Text.Trim(),
                            Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Employee Data Already Exists");
                        }
                        else
                        {
                            showPopup("Warning", "Employee Data Saved Successfully");
                            Variables.EmployeeRefId = 0;
                            //Response.Redirect("ListOfEmployee.aspx");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('ListOfEmployee.aspx');</script>");

                        }
                    }
                    else
                    {
                        BusinessAccessLayer.InsertUpdateEmployeeDetails(Variables.EmployeeRefId, txt_EmployeeId.Text.Trim(), txt_EmployeeName.Text.Trim(),
                            txt_Address.Text.Trim(), txt_Emailid.Text.Trim(), txt_MobileNo.Text.Trim(), rcbGender.SelectedItem.Text.Trim(), rdpEmployeeDOB.DateInput.SelectedDate.Equals(null) ? nul : rdpEmployeeDOB.DateInput.SelectedDate.Value,
                            Convert.ToInt32(rcbState.SelectedValue), Convert.ToInt32(rcbCity.SelectedValue), txt_AreaLocality.Text.Trim(), txt_Landmark.Text.Trim(), txt_Pincode.Text.Trim(),
                            txt_GeoLocation.Text.Trim(), Convert.ToInt32(rcbCorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue), strServices, txt_ActivationURL.Text.Trim(),
                            rdtCreatedOn.DateInput.SelectedDate.Equals(null) ? nul : rdtCreatedOn.DateInput.SelectedDate.Value, Convert.ToInt32(txt_CreatedBy.Text.Trim()),
                            rdtModifiedOn.DateInput.SelectedDate.Equals(null) ? nul : rdtModifiedOn.DateInput.SelectedDate.Value, Convert.ToInt32(Session["LoginRefId"]),
                            dtplastActiveDate.DateInput.SelectedDate.Equals(null) ? nul : dtplastActiveDate.DateInput.SelectedDate.Value,
                            dtplastInActiveDate.DateInput.SelectedDate.Equals(null) ? nul : dtplastInActiveDate.DateInput.SelectedDate.Value,
                            txt_InactiveReason.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue), out IsDataExists);
                        if (IsDataExists == "1")
                        {
                            showPopup("Warning", "Employee Data Already Exists");
                        }
                        else
                        {
                            showPopup("Warning", "Employee Data Updated Successfully");
                            Variables.EmployeeRefId = 0;
                            if (Session["LoginType"].Equals("2"))
                            {
                                Variables.EmployeeRefId = 0;
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('../Home.aspx');</script>");
                            }
                            else
                            {
                                Variables.EmployeeRefId = 0;
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('ListOfEmployee.aspx');</script>");
                                EmployeeView.ActiveViewIndex = 0;
                            }
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Delay then redirect", "<script type=text/javascript>delayRedirect('ListOfEmployee.aspx');</script>");
                        }
                    }
                }
                else
                {
                    lblEmailError.Text = "Invalid Email Id";
                    showPopup("Warning", "Invalid Email Address");
                    return;
                }
                con.Close();
            
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
                       
            

        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            EmployeePageHeading.Text = "Add Corporate Employee";
            EmployeeView.ActiveViewIndex = 1;
            ClearFields();
        }

        public void ClearFields()
        {
            //rcbCorporateName.SelectedItem.Text = "Select Client Name";
            //rcbBranchId.SelectedItem.Text = "Select Branch";
            //txt_FirstName.Text = "";
            //txt_LastName.Text = "";
            txt_EmployeeName.Text = "";
            txt_EmployeeId.Text = "";
            txt_Address.Text = "";
            txt_Emailid.Text = "";
            txt_MobileNo.Text = "";
            rcbGender.SelectedItem.Text = "Select Gender";
            rdpEmployeeDOB.Clear();
            rcbState.SelectedItem.Text = "Select State";
            rcbCity.SelectedItem.Text = "Select City";
            txt_AreaLocality.Text = "";
            txt_Landmark.Text = "";
            txt_Pincode.Text = "";
            txt_GeoLocation.Text = "";
            txt_ActivationURL.Text = "";
            rdtCreatedOn.Clear();
            txt_CreatedBy.Text = "";
            rdtModifiedOn.Clear();
            txt_ModifiedBy.Text = "";
            dtplastActiveDate.Clear();
            dtplastInActiveDate.Clear();
            txt_InactiveReason.Text = "";
            rbIsActive.SelectedValue = "1";
        }

        public void BranchList()
        {
            rcbBranchId.Items.Clear();
            rcbBranchId.Items.Insert(0, "Select Branch");
            rcbBranchId.AppendDataBoundItems = true;
            try
            {


                DataTable dtBranchList = new DataTable();
                Bal BusinessAccessLayer = new Bal();
                dtBranchList = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(rcbCorporateName.SelectedValue));
                if (dtBranchList != null && dtBranchList.Rows.Count > 0)
                {
                    rcbBranchId.DataSource = dtBranchList;
                    rcbBranchId.DataTextField = "Branch";
                    rcbBranchId.DataValueField = "BranchDetailsId";
                    rcbBranchId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            //rcbBranchId.Items.Clear();
            //rcbBranchId.Items.Insert(0, "Select Branch");
            //rcbBranchId.AppendDataBoundItems = true;


            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();

            //SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_LoadBranchListForCorporate", con);
            //cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            //cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "BranchList");

            //SqlParameter paramCorporateId = new SqlParameter("@CorporateId", rcbCorporateName.SelectedValue.Trim());

            //cmdFetchServiceProviderList.Parameters.Add(paramCorporateId);



            //SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            //DataTable dtFetchServiveProviderDetails = new DataTable();

            //daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            //if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            //{
            //    rcbBranchId.DataSource = dtFetchServiveProviderDetails;
            //    rcbBranchId.DataTextField = "Branch";
            //    rcbBranchId.DataValueField = "BranchDetailsId";
            //    rcbBranchId.DataBind();
            //}
        }
        protected void rcbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BranchList();
        }

        protected void rgCaseDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblEmployeeRefId = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblEmployeeRefId"); // % 15 for page indexing
                    Variables.EmployeeRefId = Convert.ToInt32(lblEmployeeRefId.Text.Trim());

                    EmployeeView.ActiveViewIndex = 1;
                    LoadEmployeeDetails();
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }

            }

            if (e.CommandName.Equals("SendLink"))
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
                Label lblEmployeeRefId = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblEmployeeRefId"); // % 15 for page indexing
                Variables.EmployeeRefId = Convert.ToInt32(lblEmployeeRefId.Text.Trim());


                //string ActivationURL = (row.FindControl("lblActivationURL") as Label).Text;
                //string EmailId = (row.FindControl("lblEmailId") as Label).Text;

                Label lblActivationURL = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblActivationURL");
                Label lblEmailId = (Label)rgCaseDetails.Items[intIndex % 10].FindControl("lblEmailId");

                string ActivationURL = Convert.ToString(lblActivationURL.Text.Trim());
                string EmailId = Convert.ToString(lblEmailId.Text.Trim());

                SendEmail(ActivationURL, EmailId);
            }
        }

        protected void rgCaseDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtEmployeeDetails = new DataTable();
            dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetailsCorporate(Convert.ToInt32(Session["CorporateId"]));

            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            {
                rgCaseDetails.DataSource = dtEmployeeDetails;
                //rgCaseDetails.DataBind();
            }
            else
            {
                rgCaseDetails.DataSource = new object[] { };
                //rgCaseDetails.DataBind();
            }
        }

        protected void rgCaseDetails_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {

        }

        protected void chkAllTask_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objDDL = (CheckBox)sender;
            GridDataItem row = (GridDataItem)objDDL.NamingContainer;
            int intIndex = row.ItemIndex;

            CheckBox chkAllTask = (CheckBox)rgProductServices.Items[intIndex].FindControl("chkAllTask");
            Label lblProductId = (Label)rgProductServices.Items[intIndex].FindControl("lblProductId");
            RadGrid rgProductServicesDepth = (RadGrid)rgProductServices.Items[intIndex].FindControl("rgProductServicesDepth");


            DataSet dtPermissionDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtPermissionDetails = BusinessAccessLayer.LoadProductServicesForAssign();


            DataTable objrgProductServicesDepth = new DataTable();
            objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;

            DataView dv = new DataView(objrgProductServicesDepth);
            dv.RowFilter = "ProductId=" + lblProductId.Text.Trim();

            DataTable dt = new DataTable();
            dt.Columns.Add(lblProductId.Text.Trim());
            dt.Rows.Add("");
            rgProductServicesDepth.DataSource = dt;
            rgProductServicesDepth.DataBind();
            CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");

            for (int Index = 0; Index < dv.Count; Index++)
            {
                cbTasks.Items.Add(new ListItem(dv[Index]["SubProductCategory"].ToString().Trim(), dv[Index]["SubProductId"].ToString().Trim()));
                cbTasks.Items.FindByValue(dv[Index]["SubProductId"].ToString().Trim()).Selected = chkAllTask.Checked;
            }
            GridHeaderItem headerItem = (GridHeaderItem)rgProductServicesDepth.MasterTableView.GetItems(GridItemType.Header)[0];
            Label lblProductHeader = (Label)headerItem.FindControl("lblProductHeader");  //access Label inside HeaderTemplate  
            lblProductHeader.Text = dv[0]["ProductName"].ToString().Trim();
        }

        protected void rgProductServices_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lblProductId = (Label)item.FindControl("lblProductId");
                    RadGrid rgProductServicesDepth = (RadGrid)item.FindControl("rgProductServicesDepth");

                    {

                        DataTable objrgProductServicesDepth = new DataTable();
                        objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;

                        //DataTable dtPermissionDetails = new DataTable();
                        //Bal BusinessAccessLayer = new Bal();
                        //dtPermissionDetails = BusinessAccessLayer.LoadProductServicesForAssign();


                        DataView dv = new DataView(objrgProductServicesDepth);
                        dv.RowFilter = "ProductId=" + lblProductId.Text.Trim();

                        DataTable dt = new DataTable();
                        dt.Columns.Add(lblProductId.Text.Trim());
                        dt.Rows.Add("");
                        rgProductServicesDepth.DataSource = dt;
                        rgProductServicesDepth.DataBind();

                        CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");

                        for (int Index = 0; Index < dv.Count; Index++)
                        {
                            cbTasks.Items.Add(new ListItem(dv[Index]["SubProductCategory"].ToString().Trim(), dv[Index]["SubProductId"].ToString().Trim()));
                        }
                        //int length = Variables.ServicesId.Length;

                        string RecognizedBy = ServicesAssigned;
                        String[] ServiceValue = ServicesAssigned.Split(',');
                        // if (Session["DefaultTaskBasedONRole"] != null && Session["DefaultTaskBasedONRole"].ToString().Trim() != "")
                        {
                            //string[] objrgProductServices = Session["DefaultTaskBasedONRole"] as string[];
                            //string[] objrgProductServices = Variables.ServicesId as string[];

                            // if (objrgProductServices != null && objrgProductServices.Length > 0)
                            {
                                //for (int Index = 0; Index < objrgProductServices.Length; Index++)
                                for (int Index = 0; Index < ServiceValue.Length; Index++)
                                {
                                    if (cbTasks.Items.FindByValue(ServiceValue[Index].ToString().Trim()) != null)
                                    {
                                        cbTasks.Items.FindByValue(ServiceValue[Index].ToString().Trim()).Selected = true;

                                    }
                                }
                            }
                        }

                        GridHeaderItem headerItem = (GridHeaderItem)rgProductServicesDepth.MasterTableView.GetItems(GridItemType.Header)[0];
                        Label lblProductHeader = (Label)headerItem.FindControl("lblProductHeader");  //access Label inside HeaderTemplate  
                        lblProductHeader.Text = dv[0]["ProductName"].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                //string ErrorID = EffiaErrorLogWriter.writeToErrorLog(ex);
                //WUCMessage.ShowMessage("Error", "Error ID :" + ErrorID + " , " + PopUpMessages.AdminError);
            }
        }

        protected void cmbProduct_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string ProductList = "";

            for (int i = 0; i < cmbProduct.CheckedItems.Count; i++)
            {
                if (ProductList == "")
                {
                    ProductList = cmbProduct.CheckedItems[i].Value.Trim();
                }
                else
                {
                    ProductList += "," + cmbProduct.CheckedItems[i].Value.Trim();
                }
            }

            DataSet dtSubProductServices = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtSubProductServices = BusinessAccessLayer.LoadProductServicesForEmployee(ProductList, Convert.ToInt32(rcbCorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue));

            if (dtSubProductServices != null && dtSubProductServices.Tables[0].Rows.Count > 0)
            {

                Session["DefaultProcess"] = dtSubProductServices.Tables[0];
                Session["DefaultTasks"] = dtSubProductServices.Tables[1];
                rgProductServices.DataSource = dtSubProductServices.Tables[0];
                rgProductServices.DataBind();




                DataTable objrgProductServicesDepth = new DataTable();
                objrgProductServicesDepth = Session["DefaultTasks"] as DataTable;
            }
            else
            {
                rgProductServices.DataSource = null;
                rgProductServices.DataBind();
            }
        }

        protected void rcbBranchId_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CorporateBProductList();
        }

        public void CorporateBProductList()
        {
            //ProductList();
            cmbProduct.Items.Clear();
            cmbProduct.Items.Insert(0, "Select Product");
            cmbProduct.AppendDataBoundItems = true;
            DataSet dtProductListDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtProductListDetails = BusinessAccessLayer.LoadBProductListById(Convert.ToInt32(rcbCorporateName.SelectedValue), Convert.ToInt32(rcbBranchId.SelectedValue));


            if (dtProductListDetails != null && dtProductListDetails.Tables[0].Rows.Count > 0)
            {
                //Session["CorporatesubCategoryDetails"] = dtProductListDetails.Tables[1];
                cmbProduct.DataSource = dtProductListDetails.Tables[0];
                cmbProduct.DataTextField = "ProductName";
                cmbProduct.DataValueField = "ProductId";
                cmbProduct.DataBind();
            }
            //else
            //{

            //    rcbProduct.SelectedValue = "0";
            //    //rcbProduct.DataValueField=null;
            //}

        }

        protected void rcbCorporate_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BranchListSearch();
        }

        //protected void txt_Emailid_TextChanged(object sender, EventArgs e)
        //{
        //    string emailid = txt_Emailid.Text.Trim();

        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();
        //    DataTable result = new DataTable();
        //    SqlCommand cmd = new SqlCommand("select substring('"+ emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
        //    var adapter = new SqlDataAdapter(cmd);
            
        //    adapter.Fill(result);
            
        //    if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in"))
        //    {
        //        revEmailid.Enabled = false;
        //    }
        //    else
        //    {
        //        revEmailid.Enabled = true;
        //        revEmailid.Text = "Invalid Email Id";
        //        revEmailid.SetFocusOnError = true;
        //    }
        //    con.Close();
        //}
    }
}