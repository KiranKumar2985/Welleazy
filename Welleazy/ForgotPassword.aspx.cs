using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Welleazy
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        string hash = "kanasugara";

        protected void Page_Load(object sender, EventArgs e)
        {
            ForgotView.ActiveViewIndex = 0;
        }

        protected void btnVerifyEmail_Click(object sender, EventArgs e)
        {

            ContactDetails();
            if (txt_EmailAddress.Text == EmailAddress.Text)
            {
                string EmailId = txt_EmailAddress.Text;
                SendEmail(EmailId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email Address Verified Successfully, Password has been sent on email address !');</script>" + "<script>window.location.href='Login.aspx';</script>");
               
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Email Address is not registered with us, please connect with our Network Manager!');</script>");
                
                ForgotView.ActiveViewIndex = 0;
            }
        }

        public void ContactDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Master_LoginDetails where EmailId='"+ txt_EmailAddress.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                EmailAddress.Text = dr["EmailId"].ToString();
                lblPassword.Text = dr["Password"].ToString();

            }
            lblPassword.Text = Decrypttext(lblPassword.Text);

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
        //public void OTP_Generate()
        //{
        //    string num = "0123456789";
        //    int len = num.Length;
        //    string otp = string.Empty;
        //    int otpdigit = 6;
        //    string finaldigit;
        //    int getindex;
        //    for (int i = 0; i < otpdigit; i++)
        //    {
        //        do
        //        {
        //            getindex = new Random().Next(0, len);
        //            finaldigit = num.ToCharArray()[getindex].ToString();
        //        }
        //        while (otp.IndexOf(finaldigit) != -1);
        //        otp += finaldigit;
        //    }
        //    li.Text = otp;

        //}

        //public void SendMessage()
        //{
        //    //Your user name
        //    //string user = "WELNEX";
        //    //Your authentication key
        //    //string key = "Aebc12bb79cecc469fc48a451657b3c01";
        //    //Multiple mobiles numbers separated by comma
        //    string mobile = "+91" + lblEmailAddress.Text; //"+918779017886";
        //    //Sender ID,While using route4 sender id should be 6 characters long.
        //    string senderid = "WELNEX";
        //    //Your message to send, Add URL encoding here.
        //    //string name = "XYZ";
        //    string message = HttpUtility.UrlEncode("Dear User, Your One Time Password is '" + li.Text + "' to login welleazy portal.");

        //    String URL = "https://api.ap.kaleyra.io/v1/HXAP1636111382IN/messages?to=" + mobile + "&sender=" + senderid + "&type=TXN&body=" + message + "&api-key=Aebc12bb79cecc469fc48a451657b3c01&Content-Type=application/x-www-form-urlencoded";


        //    try
        //    {

        //        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12;
        //        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);
        //        //Prepare and Add URL Encoded data
        //        UTF8Encoding encoding = new UTF8Encoding();


        //        HttpWebResponse response = httpWReq.GetResponse() as HttpWebResponse;

        //        string url = response.ResponseUri.OriginalString;

        //    }
        //    catch (SystemException ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        //public void verify_attempt()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    SqlCommand cmd = new SqlCommand("user_CRUD", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Action", "UpdateAttempt");
        //    cmd.Parameters.AddWithValue("@user_id", Label1.Text);
        //    cmd.Parameters.AddWithValue("@email", txt_EmailAddress.Text);
        //    cmd.Parameters.AddWithValue("@contact", txt_EmailAddress.Text);
        //    cmd.Parameters.AddWithValue("@mfa_otp", li.Text);
        //    cmd.Parameters.AddWithValue("@no_of_attempt", li_attempt.Text);
        //    con.Open();
        //    cmd.ExecuteNonQuery();

        //    con.Close();
        //}

        //public void AccountLocked()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    SqlCommand cmd2 = new SqlCommand("user_CRUD", con);
        //    cmd2.CommandType = CommandType.StoredProcedure;
        //    cmd2.Parameters.AddWithValue("@Action", "AccountStatus");
        //    cmd2.Parameters.AddWithValue("@user_id", Label1.Text);
        //    cmd2.Parameters.AddWithValue("@email", txt_EmailAddress.Text);
        //    cmd2.Parameters.AddWithValue("@contact", txt_EmailAddress.Text);
        //    cmd2.Parameters.AddWithValue("@status", "Locked");

        //    con.Open();
        //    cmd2.ExecuteNonQuery();
        //    con.Close();
        //}

        //protected void btn_verify_Click(object sender, EventArgs e)
        //{

        //    if (li.Text == txt_otp.Text)
        //    {
        //        li_attempt.Text = "0";
        //        verify_attempt();
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your OTP is verified, Kindly login with Same OTP...!');</script>" + "<script>window.location.href='Login.aspx';</script>");
        //    }
        //    else
        //    {
        //        Attempt.Visible = true;
        //        int i = Convert.ToInt32(li_attempt.Text);
        //        i++;
        //        if (i == 1)
        //        {
        //            lblRemaining.Text = "2";
        //        }
        //        else if (i == 2)
        //        {
        //            lblRemaining.Text = "1";
        //        }
        //        else if (i == 3)
        //        {
        //            lblRemaining.Text = "0";
        //        }
        //        else
        //        {
        //            lblLocked.Text = "Your account is locked!";
        //        }

        //        if (i <= 3)
        //        {
        //            li_attempt.Text = i.ToString();
        //            OTP_Generate();
        //            SendMessage();
        //            //Pending Code For SMS & Email
        //            verify_attempt();
        //        }
        //        else
        //        {
        //            //AccountLock
        //            AccountLocked();
        //            Attempt.Visible = false;
        //            li_attempt.Text = "0";
        //            verify_attempt();
        //            //Session.Abandon();
        //            //Session.Clear();
        //            //Session.RemoveAll();
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
        //        }
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your OTP is Not verified, Kindly Contact with Netwrok Team...!');</script>" + "<script>window.location.href='ForgotPassword.aspx';</script>");
        //    }
        //    ForgotView.ActiveViewIndex = 1;
        //}

        public void SendEmail(string EmailId)
        {

            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("alerts@welleazy.com");
                mail.Subject = "Welleazy : Forgot Passowrd";


                mail.To.Add(new MailAddress(EmailId));
                mail.Body = "<div style='font-family:Calibri;'> " +
                            "<b>Dear User,</b><br /><br />Your Password is '" + lblPassword.Text + "' to login welleazy portal.<br /><br /> Regards, Team WELLEAZY.</div>";
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
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('OTP has been sent on your email id Successfully..!');</script>");
            }
            catch (Exception ex)
            {

            }
        }

    }

}