using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy
{
    public partial class LoginTest : System.Web.UI.Page
    {
        Dal da = new Dal();
        Bal ba = new Bal();
        string str1, username, password, emailid, status;
        static int OTPGenerated = 0;
        static int i = 3;
        bool ExpiryDate = false;
        static DateTime CreatedDate = new DateTime();
        static DateTime EndDate = new DateTime();

        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //btnOTP.Visible = false;
                if (Session["username"] != null)
                {
                    
                }

                
                


            }

            //ExpiryDate = DateTime.Now.Subtract(CreatedDate).TotalMinutes <= 1;

            //if(ExpiryDate)
           // {
             //   string msg = "expired";
           // }
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
        //string hash = "kanasugara";

        //public string Encrypt(string Value)
        //{
        //    string EncryptText = "";

        //    byte[] data = UTF8Encoding.UTF8.GetBytes(Value);
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {
        //        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
        //        using (TripleDESCryptoServiceProvider triDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
        //        {
        //            ICryptoTransform transform = triDes.CreateEncryptor();
        //            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
        //            EncryptText = Convert.ToBase64String(result, 0, result.Length);
        //            return EncryptText;
        //        }
        //    }

        //}
        //public string Decrypt(string Value)
        //{
        //    string DecryptText = "";

        //    byte[] data = UTF8Encoding.UTF8.GetBytes(Value);
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {
        //        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
        //        using (TripleDESCryptoServiceProvider triDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
        //        {
        //            ICryptoTransform transform = triDes.CreateDecryptor();
        //            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
        //            DecryptText = UTF8Encoding.UTF8.GetString(result);
        //            return DecryptText;
        //        }
        //    }

        //}
        public void VerifyfLogin()
        {
            if (checkterm.Checked == true)
            {
                Attempt.Visible = true;
                try
                {

                    Bal BusinessaccessLayer = new Bal();
                    DataSet dtVerifyLogin = new DataSet();
                    string Password = "";

                    if (OTPGenerated==1)
                    {
                        Password = txtPassword.Text.Trim();
                    }
                    else
                    {
                        Password = encrypttext(txtPassword.Text.Trim());
                    }
                    

                    dtVerifyLogin = BusinessaccessLayer.Verify_Login(txtEmail.Text.Trim(), Password);
                    //li_attempt.Text = "3";
                    
                    if (dtVerifyLogin != null && dtVerifyLogin.Tables[0].Rows.Count > 0)
                    {
                        
                        verify_attempt();

                        Session["LoginRefId"] = dtVerifyLogin.Tables[1].Rows[0]["LoginRefId"].ToString();
                        Session["CorporateId"] = dtVerifyLogin.Tables[1].Rows[0]["CorporateId"].ToString();
                        Session["RoleId"] = dtVerifyLogin.Tables[1].Rows[0]["role_id"].ToString();
                       // Session["UserName"] = dtVerifyLogin.Tables[1].Rows[0]["UserName"].ToString();
                        Session["RolePermissions"] = dtVerifyLogin.Tables[1].Rows[0]["RolePermissions"].ToString();
                        Session["DisplayName"] = dtVerifyLogin.Tables[1].Rows[0]["DisplayName"].ToString();

                        Session["Permissions"] = dtVerifyLogin.Tables[0].Rows[0]["PermissionId"].ToString();
                        Session["EmployeeRefId"] = dtVerifyLogin.Tables[1].Rows[0]["EmployeeRefId"].ToString();
                        Session["UserName"] = dtVerifyLogin.Tables[1].Rows[0]["DisplayName"].ToString();
                        Session["LoginType"] = dtVerifyLogin.Tables[1].Rows[0]["LoginType"].ToString();

                        Session["Permissions"] = dtVerifyLogin.Tables[0].Rows[0]["PermissionId"].ToString();
                        //Session["RoleId"] = "0";
                        //status = dtVerifyLogin.Rows[0]["status"].ToString();
                        status = "Approved";
                        OTPGenerated = 0;

                        InsertLoginHistory();
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
                        

                        
                        i--;
                        li_attempt.Text = i.ToString();
                        //if (i == 1)
                        //{
                        //    lblRemaining.Text = "2";
                        //}
                        //else if (i == 2)
                        //{
                        //    lblRemaining.Text = "1";
                        //}
                        //else if (i == 3)
                        //{
                        //    lblRemaining.Text = "0";
                        //}
                        ///else
                        //{
                          //  lblLocked.Text = "Your Account is Locked, Kindly Contact to Network Team...!";
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>");
                        //}

                        if (i>0 && i <= 3 )
                        {
                            li_attempt.Text = i.ToString();
                            //OTP_Generate();
                            //verify_attempt();
                        }
                        else
                        {
                            //AccountLock
                            AccountLocked();
                            UpdateAccountStatus();
                            Attempt.Visible = false;
                            li_attempt.Text = "0";
                            li_attempt.Visible = false;
                            //verify_attempt();
                            OTPGenerated = 0;
                            i = 3;
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

        public void UpdateAccountStatus()
        {
            Bal BusinessAccessLayer = new Bal();
            BusinessAccessLayer.UpdateAccountStatus(txtEmail.Text.Trim());
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
                BusinessAcessLayer.InsertLoginHistory(Convert.ToInt32(Session["LoginRefId"]),IPAddress, WebBrowserName);

            }
            catch(Exception ex)
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
            string mobile = "+91" + txtEmail.Text; //"+918779017886";
                                                   //Sender ID,While using route4 sender id should be 6 characters long.
                                                   // string senderid = "WELNEX";
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
            catch (Exception ex)
            {

            }
        }

        protected void LinkDontPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void LinkGenerateOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Please Enter Email Id/Mobile No.!');</script>");
                return;
            }
            else
            {
                //lblTimer.Visible = true;
                timer.Visible = true;
                DateTime CreatedDate = new DateTime();
                CreatedDate = System.DateTime.Now;

                DateTime EndDate = new DateTime();
                EndDate = CreatedDate.AddMinutes(3);
                //string time = "2022-02-04 15:40:00";
                timer.Value = EndDate.ToString();
                //lblTimer.Visible = false;


                LinkGenerateOTP.Visible = true;

                //LinkGenerateOTP.Enabled = true;
                
                lblOTPExpiryTime.Visible = true;
                lblOTPText.Visible = true;
                OTPGenerated = 1;
                

                lblOTPExpiryTime.Text = timer.Value.ToString();
                
                //CheckEmail_MobileExists();

                if (txtEmail.Text.Length > 10)
                {
                    if(CheckEmail_MobileExists())
                    {
                        //OTP_Generate();
                        GenerateOTP();
                        //string EmailId = txtEmail.Text;
                        
                        UpdateOTP();
                        SendEmail(txtEmail.Text);
                        verify_attempt();
                    }
                   
                }
                else
                {
                    if(CheckEmail_MobileExists())
                    {
                        //OTP_Generate();
                        GenerateOTP();
                        UpdateOTP();
                        SendMessage();
                        //verify_attempt();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('OTP has been sent on your register mobile no Successfully..!');</script>");
                    }
                    
                }
            }


        }

        public void UpdateOTP()
        {
            Bal BusinessAccessLayer = new Bal();
            BusinessAccessLayer.UpdateOTP(txtEmail.Text.Trim(),lblOTP.Text.Trim());

        }

        public bool CheckEmail_MobileExists()
        {

            bool IsExists = false;
            Bal BusinessAccessLayer = new Bal();
           IsExists= BusinessAccessLayer.CheckEmail_MobileExists(txtEmail.Text.Trim());

            return IsExists;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            timer.Visible = false;
            //OTPGenerated = 0;
            //LinkGenerateOTP.Text = "Re Generate OTP";
            //if (OTPGenerated == 1)
            //{
            //    LinkGenerateOTP.Enabled = true;
            //    OTPGenerated = 0;
            //    lblOTPExpiryTime.Visible = false;
            //    lblOTPText.Visible = false;
            //    lblOTP.Text = "";
            //    UpdateOTP();
            //    //return;
            //}

            if (CheckAccountStatus())
            {
                VerifyfLogin();
                OTPGenerated = 0;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>");
            }
            
        }

        public bool CheckAccountStatus()
        {
            bool AccountStatus = false;
            Bal BusinessAccessLayer = new Bal();
            AccountStatus = BusinessAccessLayer.CheckAccountStatus(txtEmail.Text.Trim());
            return AccountStatus;

        }

        protected void btnOTP_Click(object sender, EventArgs e)
        {
            //LinkGenerateOTP.Enabled = true;
            //lblOTPExpiryTime.Visible = false;
            //lblOTPText.Visible = false;
            
        }

        public void GenerateOTP()
        {
            lblOTP.Text = GenerateNewRandom(); 
        }

        private static string GenerateNewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
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