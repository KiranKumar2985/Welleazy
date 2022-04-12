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

namespace Welleazy.diagnostic_center
{
    public partial class UpdateProviderDetails : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        string hash = "welnext";

        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();
            //string Uname = "Testing";
            //string Upassword = "0RrDqZowwBhmkwZyDSoa3A==";
            //SqlCommand cmd = new SqlCommand("select * from Master_LoginDetails where UserName ='"+ Uname + "' and Password='"+ Upassword + "'", con);
            //cmd.Parameters.AddWithValue("@username", Uname);
            //cmd.Parameters.AddWithValue("@password", Upassword);

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    string dcid = HttpUtility.UrlDecode(Request.QueryString["text"]);
            //    lbl_dc_id.Text = Decrypttext(dcid);
            //    //Response.Redirect("Details.aspx");
            //    ContactNumber();
            //    ProviderDetailsView.ActiveViewIndex = 0;
            //}
            //if(!IsPostBack)
            //{


            //if(Session["username"]!=null)
            //{

            string dcid = HttpUtility.UrlDecode(Request.QueryString["text"]);
            lbl_dc_id.Text = Decrypttext(dcid);
            //lbl_dc_id.Text = "1";
            ContactNumber();
            ProviderDetailsView.ActiveViewIndex = 0;
            //ProviderDetailsView.ActiveViewIndex = 1;

            //}
            //}
        }

        public void verify_attempt()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("Provider_information_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "UpdateAttempt");
            cmd.Parameters.AddWithValue("@dc_id", lbl_dc_id.Text);
            cmd.Parameters.AddWithValue("@otp", li.Text);
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
            cmd2.Parameters.AddWithValue("@Action", "UpdateAccount");
            cmd2.Parameters.AddWithValue("@user_id", Label1.Text);
            cmd2.Parameters.AddWithValue("@name", Session["username"].ToString());
            cmd2.Parameters.AddWithValue("@status", "Locked");

            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        protected void btn_verify_Click(object sender, EventArgs e)
        {
            Attempt.Visible = true;
            if (li.Text == txt_otp.Text)
            {
                li_attempt.Text = "0";
                verify_attempt();
                string dcid = HttpUtility.UrlEncode(encrypttext(lbl_dc_id.Text.Trim()));
                Response.Redirect("~/diagnostic_center/AddEditDC.aspx?text=" + dcid + "");
            }
            else
            {
                int i = Convert.ToInt32(li_attempt.Text);
                i++;
                if(i==1)
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
                    lblLocked.Text = "Your account is locked!";
                }

                if(i<=3)
                {
                    li_attempt.Text = i.ToString();
                    OTP_Generate();
                    //Pending Code For SMS & Email
                    verify_attempt();
                }
                else
                {
                    //AccountLock
                    AccountLocked();
                    Attempt.Visible = false;
                    li_attempt.Text = "0";
                    verify_attempt();
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Your Account is Locked, Kindly Contact to Network Team ...!');</script>" + "<script>window.location.href='/Login.aspx';</script>");
                }
             
            }            
        }

        public void ContactNumber()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_DC_Information where dc_id='"+lbl_dc_id.Text+"'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ContactNo.Text = dr["mobile_no"].ToString();
                lbl_dc_id.Text = lbl_dc_id.Text;
                li.Text = dr["otp"].ToString();
                li_attempt.Text = dr["no_of_attempt"].ToString();
                lblContactNo.Text = ContactNo.Text;
                this.ContactNo.Text = string.Format("XXXXXX{0}", this.ContactNo.Text.Trim().Substring(6, 4));
                ContactText.Text = "OTP has been sent on: " + this.ContactNo.Text + ", Please verify yourself to update provider details!";
                VerifyMobileNo.Text= "Enter Mobile Number " + this.ContactNo.Text + " , Please verify yourself to update provider details!";


            }
            con.Close();
        }

        public void SendMessage()
        {
            //Your user name
            //string user = "WELNEX";
            //Your authentication key
            //string key = "Aebc12bb79cecc469fc48a451657b3c01";
            //Multiple mobiles numbers separated by comma
            string mobile = "+91" + lblContactNo.Text; //"+918779017886";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderid = "WELNEX";
            //Your message to send, Add URL encoding here.
            //string name = "XYZ";
            string message = HttpUtility.UrlEncode("Dear Service Provider, Your one time password is '" + li.Text + "' to update your details.");

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

        protected void OTP_resendlink_Click(object sender, EventArgs e)
        {
            OTP_Generate();
            SendMessage();
            //Pending Code For SMS & Email
            verify_attempt();
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
            li.Text = otp;
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        protected void btnVerifyNo_Click(object sender, EventArgs e)
        {
            if(txt_mobileno.Text== lblContactNo.Text)
            {
                OTP_Generate();
                SendMessage();
                verify_attempt();
                showPopup("Success", "Mobile Number Matched, Kindly Enter OTP");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Mobile Number Matched, Kindly Enter OTP!');</script>");
                ProviderDetailsView.ActiveViewIndex = 1;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Entered Mobile Number is not Register with us, please connect with our Network Manager!');</script>");
                showPopup("Warning", "Entered Mobile Number is not Register with us, please connect with our Network Manager!");
                ProviderDetailsView.ActiveViewIndex = 0;
            }
        }
    }
}