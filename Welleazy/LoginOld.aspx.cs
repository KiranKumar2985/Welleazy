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
using System.Collections;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;

namespace Welleazy
{
    public partial class Login : System.Web.UI.Page
    {
        Dal da = new Dal();
        Bal ba = new Bal();
        string str1, username, password, emailid, status;

        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] != null)
                {

                }

            }
        }

        public void verify_attempt()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("user_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "UpdateAttempt");
            cmd.Parameters.AddWithValue("@user_id", Label1.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@contact", txtEmail.Text);
            cmd.Parameters.AddWithValue("@mfa_otp", lblOTP.Text);
            cmd.Parameters.AddWithValue("@no_of_attempt", li_attempt.Text);
            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void AccountLocked()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd2 = new SqlCommand("user_CRUD", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Action", "AccountStatus");
            cmd2.Parameters.AddWithValue("@user_id", Label1.Text);
            cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd2.Parameters.AddWithValue("@contact", txtEmail.Text);
            cmd2.Parameters.AddWithValue("@status", "Locked");

            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        public void VerifyfLogin()
        {
            if(checkterm.Checked==true)
            {
                Attempt.Visible = true;
                try
                {
                    
                    Bal BusinessaccessLayer = new Bal();
                    DataTable dtVerifyLogin = new DataTable();
                    dtVerifyLogin = BusinessaccessLayer.VerifyLogin(txtEmail.Text.Trim(), txtPassword.Text.Trim());

                    if (dtVerifyLogin != null && dtVerifyLogin.Rows.Count > 0)
                    {
                        li_attempt.Text = "0";
                        verify_attempt();

                        Session["UserId"] = dtVerifyLogin.Rows[0]["user_id"].ToString();
                        Session["username"] = dtVerifyLogin.Rows[0]["name"].ToString();
                        Session["UserRolePermissions"] = dtVerifyLogin.Rows[0]["UserRolePermissions"].ToString();
                        Session["RoleId"] = "0";
                        status = dtVerifyLogin.Rows[0]["status"].ToString();

                        if (status == "Approved")
                        {
                            Response.Redirect("Home.aspx");
                        }
                        else if (status == "Locked")
                        {
                            Attempt.Visible = false;
                            ChangeMsg.Text = "Your Account is Locked, Kindly inform to Network Team !!!";
                        }
                        else
                        {
                            Attempt.Visible = false;
                            ChangeMsg.Text = "Your Account is not Activated Now, Contact to Network Team !";
                        }
                                               
                        //Response.Write("<script>window.location.href='Home.aspx';</script>");

                    }
                    else
                    {
                        int i = Convert.ToInt32(li_attempt.Text);
                        i++;
                        if (i == 1)
                        {
                            lblRemaining.Text = "2";
                        }
                        else if (i == 2)
                        {
                            lblRemaining.Text = "1";
                        }
                        else if (i == 3)
                        {
                            lblRemaining.Text = "0";
                        }
                        else
                        {
                            lblLocked.Text= "Your Account is Locked, Kindly Contact to Network Team...!";
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>");
                        }

                        if (i <= 3)
                        {
                            li_attempt.Text = i.ToString();
                            OTP_Generate();
                            verify_attempt();
                        }
                        else
                        {
                            //AccountLock
                            AccountLocked();
                            Attempt.Visible = false;
                            li_attempt.Text = "0";
                            verify_attempt();
                            
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>");
                        }
                        //ChangeMsg.Text = "UserName or Password is Not Correct!!";

                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                   
                }

            }
            else
            {
                return;
            }
            
        }

        public void SendMessage()
        {
            //Your user name
            //string user = "WELNEX";
            //Your authentication key
            //string key = "Aebc12bb79cecc469fc48a451657b3c01";
            //Multiple mobiles numbers separated by comma
            string mobile = "+91" + txtEmail.Text; //"+918779017886";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderid = "WELNEX";
            //Your message to send, Add URL encoding here.
            //string name = "XYZ";
            string message = HttpUtility.UrlEncode("Dear User, Your One Time Password is '" + lblOTP.Text + "' to login welleazy portal.");

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

        //public void SendEmail(string EmailId)
        //{
        //    MailMessage mm = new MailMessage("Alerts@welleazy.com", EmailId);
        //    string cc = "kamlesh.prajapat@welleazy.com";
        //    mm.CC.Add(cc);
        //    mm.Subject = "Welleazy : One Time Passowrd";
        //    mm.Body = "<div style='font-family:Calibri;'> " +
        //              "<b>Dear User,</b><br /><br />Please find the below OTP to login Welleazy Portal.<br />" +
        //              "OTP : '" + lblOTP.Text + "'<br /><br /> Regards, Team WELLEAZY.</div>";
        //    mm.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();

        //    //smtp.EnableSsl = true;
        //    NetworkCredential NetworkCred = new NetworkCredential();

        //    //smtp.Timeout = 10000;
        //    NetworkCred.UserName = "Alerts@welleazy.com";
        //    NetworkCred.Password = "Network@123";

        //    smtp.Host = "smtpout.secureserver.net";
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Port = 465;

        //    smtp.Send(mm);

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email sent Successfully..!');</script>");
        //}


        public void SendEmail(string EmailId)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("alerts@welleazy.com");
                mail.Subject = "Welleazy : One Time Passowrd";


                mail.To.Add(new MailAddress(EmailId));
                mail.Body = "<div style='font-family:Calibri;'> " +
                            "<b>Dear User,</b><br /><br />Your One Time Password is '" + lblOTP.Text + "' to login welleazy portal.<br /><br /> Regards, Team WELLEAZY.</div>";
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('OTP has been sent on your email id Successfully..!');</script>");
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkDontPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void LinkGenerateOTP_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('First To Enter Email/MobileNo...!');</script>");
                return;
            }
            else
            {
                if(txtEmail.Text.Length > 10)
                {
                    OTP_Generate();
                    string EmailId = txtEmail.Text;
                    SendEmail(EmailId); 
                    verify_attempt();
                }
                else
                {
                    OTP_Generate();
                    SendMessage();
                    verify_attempt();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('OTP has been sent on your register mobile no Successfully..!');</script>");
                }
            }
            
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            VerifyfLogin();
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
            lblOTP.Text = otp;
        }

     
        protected void linkCorporateLogin_Click(object sender, EventArgs e)
        {
            lblLoginType.Text = "Corporate Login";
            this.AreCorporate.Visible = false;
        }

       
    }
}