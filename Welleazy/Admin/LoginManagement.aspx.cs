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
    public partial class LoginManagement : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    EmployeeDetails.Visible = false;
                    CustomerDetails.Visible = false;
                }
            }
        }

        //Employee Details
        public void EmployeeDetails_All()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdAccessEmployeeDetails = new SqlCommand("Exec proc_LoadListOfEmployees", con);

            SqlDataAdapter daAccessEmployeeDetails = new SqlDataAdapter(cmdAccessEmployeeDetails);
            DataTable dtAccessEmployeeDetails = new DataTable();

            daAccessEmployeeDetails.Fill(dtAccessEmployeeDetails);

            if (dtAccessEmployeeDetails != null && dtAccessEmployeeDetails.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtAccessEmployeeDetails;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                gvEmployeeDetails.DataSource = null;
                gvEmployeeDetails.DataBind();
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
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);
            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtFetchEmployeeDetailsList;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                gvEmployeeDetails.DataSource = null;
                gvEmployeeDetails.DataBind();
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
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);


            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtFetchEmployeeDetailsList;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                gvEmployeeDetails.DataSource = null;
                gvEmployeeDetails.DataBind();
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
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtFetchEmployeeDetailsList;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                gvEmployeeDetails.DataSource = null;
                gvEmployeeDetails.DataBind();
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
            SqlParameter paramStatus = new SqlParameter("@AccountStatus", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchEmployeeDetailsList.Parameters.Add(paramName);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramEmail);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramMobile);
            cmdFetchEmployeeDetailsList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchEmployeeDetailsList = new SqlDataAdapter(cmdFetchEmployeeDetailsList);
            DataTable dtFetchEmployeeDetailsList = new DataTable();

            daFetchEmployeeDetailsList.Fill(dtFetchEmployeeDetailsList);

            if (dtFetchEmployeeDetailsList != null && dtFetchEmployeeDetailsList.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtFetchEmployeeDetailsList;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                gvEmployeeDetails.DataSource = null;
                gvEmployeeDetails.DataBind();
            }
        }

        //Customer Details
        public void CustomerDetails_All()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdAccessCustomerDetails = new SqlCommand("Exec proc_AccessCustomerDetails", con);

            SqlDataAdapter daAccessCustomerDetails = new SqlDataAdapter(cmdAccessCustomerDetails);
            DataTable dtAccessCustomerDetails = new DataTable();

            daAccessCustomerDetails.Fill(dtAccessCustomerDetails);

            if (dtAccessCustomerDetails != null && dtAccessCustomerDetails.Rows.Count > 0)
            {
                gvCustomerDetails.DataSource = dtAccessCustomerDetails;
                gvCustomerDetails.DataBind();
            }
            else
            {
                gvCustomerDetails.DataSource = null;
                gvCustomerDetails.DataBind();
            }

        }

        public void CustomerDetails_Name()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchCustomerDetailsList = new SqlCommand("proc_SearchAllCustomerList", con);
            cmdFetchCustomerDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchCustomerDetailsList.Parameters.AddWithValue("@Action", "FETCH_NAME");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());

            cmdFetchCustomerDetailsList.Parameters.Add(paramName);
            cmdFetchCustomerDetailsList.Parameters.Add(paramEmail);
            cmdFetchCustomerDetailsList.Parameters.Add(paramMobile);



            SqlDataAdapter daFetchCustomerDetailsList = new SqlDataAdapter(cmdFetchCustomerDetailsList);
            DataTable dtFetchCustomerDetailsList = new DataTable();

            daFetchCustomerDetailsList.Fill(dtFetchCustomerDetailsList);

            if (dtFetchCustomerDetailsList != null && dtFetchCustomerDetailsList.Rows.Count > 0)
            {
                gvCustomerDetails.DataSource = dtFetchCustomerDetailsList;
                gvCustomerDetails.DataBind();
            }
            else
            {
                gvCustomerDetails.DataSource = null;
                gvCustomerDetails.DataBind();
            }
        }

        public void CustomerDetails_Email()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchCustomerDetailsList = new SqlCommand("proc_SearchAllCustomerList", con);
            cmdFetchCustomerDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchCustomerDetailsList.Parameters.AddWithValue("@Action", "FETCH_EMAIL");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());

            cmdFetchCustomerDetailsList.Parameters.Add(paramName);
            cmdFetchCustomerDetailsList.Parameters.Add(paramEmail);
            cmdFetchCustomerDetailsList.Parameters.Add(paramMobile);



            SqlDataAdapter daFetchCustomerDetailsList = new SqlDataAdapter(cmdFetchCustomerDetailsList);
            DataTable dtFetchCustomerDetailsList = new DataTable();

            daFetchCustomerDetailsList.Fill(dtFetchCustomerDetailsList);

            if (dtFetchCustomerDetailsList != null && dtFetchCustomerDetailsList.Rows.Count > 0)
            {
                gvCustomerDetails.DataSource = dtFetchCustomerDetailsList;
                gvCustomerDetails.DataBind();
            }
            else
            {
                gvCustomerDetails.DataSource = null;
                gvCustomerDetails.DataBind();
            }
        }

        public void CustomerDetails_Mobile()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchCustomerDetailsList = new SqlCommand("proc_SearchAllCustomerList", con);
            cmdFetchCustomerDetailsList.CommandType = CommandType.StoredProcedure;
            cmdFetchCustomerDetailsList.Parameters.AddWithValue("@Action", "FETCH_MOBILE");

            SqlParameter paramName = new SqlParameter("@Name", txt_Name.Text.Trim());
            SqlParameter paramEmail = new SqlParameter("@Email", txt_Email.Text.Trim());
            SqlParameter paramMobile = new SqlParameter("@Mobile", txt_Mobile.Text.Trim());

            cmdFetchCustomerDetailsList.Parameters.Add(paramName);
            cmdFetchCustomerDetailsList.Parameters.Add(paramEmail);
            cmdFetchCustomerDetailsList.Parameters.Add(paramMobile);



            SqlDataAdapter daFetchCustomerDetailsList = new SqlDataAdapter(cmdFetchCustomerDetailsList);
            DataTable dtFetchCustomerDetailsList = new DataTable();

            daFetchCustomerDetailsList.Fill(dtFetchCustomerDetailsList);

            if (dtFetchCustomerDetailsList != null && dtFetchCustomerDetailsList.Rows.Count > 0)
            {
                gvCustomerDetails.DataSource = dtFetchCustomerDetailsList;
                gvCustomerDetails.DataBind();
            }
            else
            {
                gvCustomerDetails.DataSource = null;
                gvCustomerDetails.DataBind();
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if(DetailsType.SelectedItem.Text=="Employee Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                EmployeeDetails_All();
            }
            else if (DetailsType.SelectedItem.Text == "Customer Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                CustomerDetails_All();
            }
            else
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
            }
            
            

        }

        protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvEmployeeDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblEmpId") as Label).Text);

                Variables.DcId = DCId;
                Response.Redirect("~/Admin/LoginManagement.aspx");

            }

            if (e.CommandName.Equals("Delete"))
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvEmployeeDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblEmpId") as Label).Text);

                Variables.DcId = DCId;
                Response.Redirect("~/Admin/LoginManagement.aspx");

            }

            if (e.CommandName.Equals("SendLink"))
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvEmployeeDetails.Rows[rowIndex];

                string ActivationURL = (row.FindControl("lblActivationURL") as Label).Text;
                string EmailId = (row.FindControl("lblEmailId") as Label).Text;

                SendEmail(ActivationURL, EmailId);


            }


        }

        public void SendEmail(string ActivationURL, string EmailId)
        {
            MailMessage mm = new MailMessage("kirans@welnext.com", EmailId);

            mm.Subject = "Password Recovery";
            mm.Body = string.Format("Dear Service Provider, Please update your details and complete your profile on WELLEAZY. Visit link: {0} , Regards, Team WELLEAZY.", EmailId);
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

        protected void gvEmployeeDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvEmployeeDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void txt_Name_TextChanged(object sender, EventArgs e)
        {
            if(DetailsType.SelectedItem.Text=="Employee Details")
            {
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                EmployeeDetails_Name();
            }
            else if (DetailsType.SelectedItem.Text == "Customer Details")
            {
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                CustomerDetails_Name();
            }
            else
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Select Details Type!!');</script>");
            }
            
        }

        protected void txt_Email_TextChanged(object sender, EventArgs e)
        {
            
            if (DetailsType.SelectedItem.Text == "Employee Details")
            {
                txt_Name.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                EmployeeDetails_Email();
            }
            else if (DetailsType.SelectedItem.Text == "Customer Details")
            {
                txt_Name.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                CustomerDetails_Email();
            }
            else
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Select Details Type!!');</script>");
            }
        }

        protected void txt_Mobile_TextChanged(object sender, EventArgs e)
        {
            
            if (DetailsType.SelectedItem.Text == "Employee Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                EmployeeDetails_Mobile();
            }
            else if (DetailsType.SelectedItem.Text == "Customer Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                CustomerDetails_Mobile();
            }
            else
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Select Details Type!!');</script>");
            }
        }

        protected void DDL_Status_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (DetailsType.SelectedItem.Text == "Employee Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                EmployeeDetails_Status();
            }
            else if (DetailsType.SelectedItem.Text == "Customer Details")
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                //CustomerDetails_Mobile();
            }
            else
            {
                txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Mobile.Text = "";
                DDL_Status.SelectedItem.Text = "Select Status";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Select Details Type!!');</script>");
            }
        }
        
        protected void DetailsType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if(DetailsType.SelectedItem.Text=="Employee Details")
            {
                EmployeeDetails.Visible = true;
                CustomerDetails.Visible = false;
            }
            else if(DetailsType.SelectedItem.Text=="Customer Details")
            {
                CustomerDetails.Visible = true;
                EmployeeDetails.Visible = false;
            }
            else
            {
                EmployeeDetails.Visible = false;
                CustomerDetails.Visible = false;
            }

        }

        protected void gvCustomerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCustomerDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvCustomerDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

     
       
    }
}