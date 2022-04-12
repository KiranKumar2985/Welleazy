using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Welleazy
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        Dal da = new Dal();
        Bal ba = new Bal();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    SqlConnection con = new SqlConnection(conStr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Master_LoginDetails where LoginRefId='" + Session["LoginRefId"] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Label1.Text = dr["Password"].ToString();
                        //LabelConvert.Text = Decrypt(Label1.Text.Trim());
                    }
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Your session has expired!')</script>" + "<script>window.location.href='Login.aspx';</script>");
                }
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

        protected void btnreset_Click(object sender, EventArgs e)
        {
            
            txt_oldpass.Text = encrypttext(txt_oldpass.Text);
            txt_newpass.Text = encrypttext(txt_newpass.Text);
            if (Label1.Text == txt_oldpass.Text)
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    con.Open();
                    string str = "select * from Master_LoginDetails";
                    SqlCommand cmd = new SqlCommand(str, con);
                    if (txt_oldpass.Text != txt_newpass.Text)
                    {
                        //ba.UserName = Convert.ToString(Session["username"]);
                        //ba.Password = encrypttext(txt_newpass.Text);
                        cmd = new SqlCommand("Update Master_LoginDetails set Password='" + txt_newpass.Text.Trim() + "' where UserName='" + Session["username"] + "'", con);
                        cmd.ExecuteNonQuery();
                        ChangeMsg.ForeColor = System.Drawing.Color.Green;
                        ChangeMsg.Text = "Password Changed Successfully...!";
                    }
                    else
                    {
                        ChangeMsg.ForeColor = System.Drawing.Color.Red;
                        ChangeMsg.Text = "Kindly Enter Password Different with Old One!";
                    }
                    da.UpdateLogin(ba);
                    con.Close();
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                ChangeMsg.ForeColor = System.Drawing.Color.Red;
                ChangeMsg.Text = "Old Password is not match to Database";
            }

        }

    }
}