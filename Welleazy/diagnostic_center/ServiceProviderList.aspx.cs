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

namespace Welleazy.diagnostic_center
{
    public partial class ServiceProviderList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    ServiceProviderDetails();
                }
            }
        }

        public void ServiceProviderDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("Exec proc_FetchServiceProviderDetails", con);

            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetvhServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetvhServiveProviderDetails);

            if (dtFetvhServiveProviderDetails != null && dtFetvhServiveProviderDetails.Rows.Count > 0)
            {
                gvServiceProviderDetails.DataSource = dtFetvhServiveProviderDetails;
                gvServiceProviderDetails.DataBind();
            }
            else
            {
                gvServiceProviderDetails.DataSource = null;
                gvServiceProviderDetails.DataBind();
            }

        }

        public void ServiceProviderDetails_Centername()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllProviderList", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_CENTER");

            SqlParameter paramCenterName = new SqlParameter("@CenterName", txt_Centername.Text.Trim());
            SqlParameter paramServiceProvider = new SqlParameter("@ServiceProviderType", txt_Servicecode.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@Status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramServiceProvider);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvServiceProviderDetails.DataSource = dtFetchServiveProviderDetails;
                gvServiceProviderDetails.DataBind();
            }
            else
            {
                gvServiceProviderDetails.DataSource = null;
                gvServiceProviderDetails.DataBind();
            }
        }

        public void ServiceProviderDetails_Provider()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllProviderList", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_PROVIDER");

            SqlParameter paramCenterName = new SqlParameter("@CenterName", txt_Centername.Text.Trim());
            SqlParameter paramServiceProvider = new SqlParameter("@ServiceProviderType", txt_Servicecode.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@Status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramServiceProvider);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvServiceProviderDetails.DataSource = dtFetchServiveProviderDetails;
                gvServiceProviderDetails.DataBind();
            }
            else
            {
                gvServiceProviderDetails.DataSource = null;
                gvServiceProviderDetails.DataBind();
            }
        }

        public void ServiceProviderDetails_Status()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllProviderList", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_STATUS");

            SqlParameter paramCenterName = new SqlParameter("@CenterName", txt_Centername.Text.Trim());
            SqlParameter paramServiceProvider = new SqlParameter("@ServiceProviderType", txt_Servicecode.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@Status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramServiceProvider);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvServiceProviderDetails.DataSource = dtFetchServiveProviderDetails;
                gvServiceProviderDetails.DataBind();
            }
            else
            {
                gvServiceProviderDetails.DataSource = null;
                gvServiceProviderDetails.DataBind();
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            txt_Centername.Text = "";
            txt_Servicecode.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ServiceProviderDetails();
            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();

            //SqlCommand cmdSearch = new SqlCommand("Exec proc_SearchProviderList @CenterName,@ServiceProviderType,@Status,@SearchType", con);
            //SqlParameter paramCentreName;
            //SqlParameter paramServiceProviderType;
            //SqlParameter paramStatus;

            //if (txt_Centername.Text.Trim().Equals(""))
            //{
            //    paramCentreName = new SqlParameter("@CenterName", DBNull.Value);
            //}
            //else
            //{
            //    paramCentreName = new SqlParameter("@CenterName", txt_Centername.Text.Trim());
            //}

            //if (txt_Servicecode.Text.Trim().Equals(""))
            //{
            //    paramServiceProviderType = new SqlParameter("@ServiceProviderType", DBNull.Value);
            //}
            //else
            //{
            //    paramServiceProviderType = new SqlParameter("@ServiceProviderType", txt_Servicecode.Text.Trim());
            //}


            //SqlParameter paramSearchType = new SqlParameter("@SearchType", rbSearch.SelectedValue);


            ////if(DDL_Status.SelectedValue.Equals(0))

            //paramStatus = new SqlParameter("@Status", DBNull.Value);

            ////else
            //// {
            ////     paramStatus = new SqlParameter("@Status", DDL_Status.SelectedValue);
            //// }

            //cmdSearch.Parameters.Add(paramCentreName);
            //cmdSearch.Parameters.Add(paramServiceProviderType);
            //cmdSearch.Parameters.Add(paramStatus);
            //cmdSearch.Parameters.Add(paramSearchType);

            //SqlDataAdapter daFetchProviderDetails = new SqlDataAdapter(cmdSearch);
            //DataTable dtProviderLists = new DataTable();

            //daFetchProviderDetails.Fill(dtProviderLists);

            //if (dtProviderLists != null && dtProviderLists.Rows.Count > 0)
            //{
            //    gvServiceProviderDetails.DataSource = dtProviderLists;
            //    gvServiceProviderDetails.DataBind();

            //}
            //else
            //{
            //    gvServiceProviderDetails.DataSource = null;
            //    gvServiceProviderDetails.DataBind();
            //}

        }

        protected void gvServiceProviderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvServiceProviderDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                Variables.DcId = DCId;
                Response.Redirect("~/diagnostic_center/AddEditDC.aspx");

            }

            if (e.CommandName.Equals("Delete"))
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvServiceProviderDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                Variables.DcId = DCId;
                //Response.Redirect("~/diagnostic_center/AddEditDC.aspx");

            }

            if (e.CommandName.Equals("SendLink"))
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvServiceProviderDetails.Rows[rowIndex];

                string ProviderURL = (row.FindControl("lblProviderURL") as Label).Text;
                string EmailId = (row.FindControl("lblEmailId") as Label).Text;
                string Dcname = (row.FindControl("lblDcname") as Label).Text;
                string spid = (row.FindControl("lblsptoken_id") as Label).Text;

                SendEmail(ProviderURL, EmailId, Dcname, spid);
                showPopup("Warning", "Email Sent Successfully...!");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email sent Successfully..!');</script>");
            }


        }

        public void SendEmail(string ProviderURL, string EmailId, string Dcname, string spid)
        {
            //MailMessage mm = new MailMessage("Alerts@welleazy.com", EmailId);

            //mm.Subject = "Provider Details Update Link";
            //mm.Body = string.Format("Dear Service Provider, Please update your details and complete your profile on WELLEAZY. Visit link: {0} , Regards, Team WELLEAZY.", EmailId);
            //mm.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtpout.secureserver.net";
            //smtp.EnableSsl = true;
            //NetworkCredential NetworkCred = new NetworkCredential();
            //NetworkCred.UserName = "Alerts@welleazy.com";
            //NetworkCred.Password = "Network@123";
            //smtp.UseDefaultCredentials = true;
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
                mail.Subject = "For Provider Services - " + Dcname.ToString();


                mail.To.Add(new MailAddress(EmailId));
                mail.Body = "<div style='font-family:Calibri;'> " +
                            "<b>Dear Service Provider,</b><br /><br />Kindly update your details and complete your profile on WELLEAZY.<br />" +
                            "Token Id: '" + spid.ToString() + "'<br />Visit URL: " + hl1.NavigateUrl + ".<br /><br /> Regards, Team WELLEAZY.</div>";
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
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email sent Successfully..!');</script>");
            }
            catch (Exception ex)
            {

            }
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void gvServiceProviderDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvServiceProviderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void txt_Centername_TextChanged(object sender, EventArgs e)
        {
            txt_Servicecode.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ServiceProviderDetails_Centername();
        }

        protected void txt_Servicecode_TextChanged(object sender, EventArgs e)
        {
            txt_Centername.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ServiceProviderDetails_Provider();
        }

        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Centername.Text = "";
            txt_Servicecode.Text = "";
            ServiceProviderDetails_Status();
        }

        protected void Linkspl6_Click(object sender, EventArgs e)
        {
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
        }
    }
}