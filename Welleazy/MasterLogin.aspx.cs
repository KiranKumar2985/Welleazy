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

namespace Welleazy
{
    public partial class MasterLogin : System.Web.UI.Page
    {
        Dal da = new Dal();
        Bal ba = new Bal();
        string str1, username, password, emailid, status, Domain;

        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Update_OTP();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            OTP_Generate();
            Update_OTP();
        }

        protected void DDL_LoginType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDL_LoginType.SelectedValue=="Partners")
            {
                Partners_panel.Visible = true;
                Corporates_panel.Visible = false;
                InternalEmp_panel.Visible = false;
                Customers_panel.Visible = false;
            }
            else if(DDL_LoginType.SelectedValue=="Corporates")
            {
                Partners_panel.Visible = false;
                Corporates_panel.Visible = true;
                InternalEmp_panel.Visible = false;
                Customers_panel.Visible = false;
            }
            else if(DDL_LoginType.SelectedValue=="Coporate Employees")
            {
                Partners_panel.Visible = false;
                Corporates_panel.Visible = false;
                InternalEmp_panel.Visible = true;
                Customers_panel.Visible = false;
            }
            else if(DDL_LoginType.SelectedValue=="Customers")
            {
                Partners_panel.Visible = false;
                Corporates_panel.Visible = false;
                InternalEmp_panel.Visible = false;
                Customers_panel.Visible = true;
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CheckBoxList1.SelectedValue=="OTP")
            {
                CT_txtOTP.Visible=true;
                CT_txtpassword.Visible=false;
                CT_txtfname.Visible = true;
                CT_txtlname.Visible = true;
                CT_txtpassword.Text = "";
                OTP_Generate();
               
            }
            else
            {
                CT_txtOTP.Visible=false;
                CT_txtpassword.Visible = true;
                CT_txtfname.Visible = false;
                CT_txtlname.Visible = false;
                CT_txtOTP.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
                if(DDL_LoginType.SelectedItem.Text=="Partners")
                {
                    VerifyMasterLogin();
                }
                else if (DDL_LoginType.SelectedItem.Text == "Corporates")
                {
                    VerifyMasterLogin();
                }
                else if (DDL_LoginType.SelectedItem.Text == "Coporate Employees")
                {
                    if (CheckBoxList2.SelectedValue == "OTP")
                    {

                        if (lblOTP.Text == IP_txtOTP.Text)
                        {
                            VerifyMasterLoginMO();
                            lblOTPMatch.ForeColor = Color.Green;
                            lblOTPMatch.Text = "OTP is Correct!!!";                            
                        }
                        else
                        {
                            VerifyMasterLoginMO();
                            lblOTPMatch.ForeColor = Color.Red;
                            lblOTPMatch.Text = "OTP is Not Correct!!!";                            
                        }
                    }
                    else
                    {
                        VerifyMasterLogin();
                    }
                }
                else
                {
                    if (CheckBoxList1.SelectedValue == "OTP")
                    {

                        if (lblOTP.Text == CT_txtOTP.Text)
                        {                            
                            VerifyMasterLoginMO();
                            lblOTPMatch1.ForeColor = Color.Green;
                            lblOTPMatch1.Text = "OTP is Correct!!!";
                        }
                        else
                        {
                            VerifyMasterLoginMO();
                            lblOTPMatch.ForeColor = Color.Red;
                            lblOTPMatch.Text = "OTP is Not Correct!!!";
                        }
                    }
                    else
                    {
                        VerifyMasterLogin();
                    }
                }
        
        }
        public void VerifyMasterLogin()
        {
            if (DDL_LoginType.SelectedValue == "Partners")
            {
                txtEmail.Text=txtEmail.Text;
                txtPassword.Text=txtPassword.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Corporates")
            {
                txtEmail.Text = CP_txtemail.Text;
                txtPassword.Text = CP_txtpassword.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Coporate Employees")
            {
                txtEmail.Text = IP_txtemail.Text;
                txtPassword.Text = IP_txtpassword.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Customers")
            {
                txtEmail.Text = CT_txtemail.Text;
                txtPassword.Text = CT_txtpassword.Text;
            }
            else
            {

            }

            Bal BusinessaccessLayer = new Bal();
            DataTable dtVerifyMasterLogin = new DataTable();
           
            dtVerifyMasterLogin = BusinessaccessLayer.VerifyMasterLogin(txtEmail.Text.Trim(), txtPassword.Text.Trim());

            if (dtVerifyMasterLogin != null && dtVerifyMasterLogin.Rows.Count > 0)
            {
                Session["UserId"] = dtVerifyMasterLogin.Rows[0]["User_Id"].ToString();
                Session["username"] = dtVerifyMasterLogin.Rows[0]["FullName"].ToString();
                Session["UserRolePermission"] = dtVerifyMasterLogin.Rows[0]["UserRolePermission"].ToString();
                Session["RoleId"] = dtVerifyMasterLogin.Rows[0]["role_id"].ToString();
                Session["CorporateId"] = dtVerifyMasterLogin.Rows[0]["CorporateId"].ToString();
                status = dtVerifyMasterLogin.Rows[0]["AccountStatus"].ToString();
                Domain = dtVerifyMasterLogin.Rows[0]["DomainName"].ToString();

                if (customCheck1.Checked == true)
                {



                    if (status != "InActive")
                    {
                        if (txtEmail.Text == "kiran@welleazy.com" || txtEmail.Text=="info@welnext.com")
                        {
                            Response.Redirect("~/Corporate/CorporateDashBoard.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Home.aspx");
                        }

                    }
                    else if (status == "InActive")
                    {
                        ChangeMsg.Text = "Your Account is InActive, Kindly inform to Network Team !!!";
                        LinkButton2.Visible = true;
                    }
                    else
                    {
                        ChangeMsg.Text = "Access Denied....<br>email id or password is incorrect !!!";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Please Accept Terms and Conditions');</script>");
                }
                
            }
            else
            {
                ChangeMsg.Text = "User Not Exists!!!";

            }
        }

        public void VerifyMasterLoginMO()
        {
            if (DDL_LoginType.SelectedValue == "Partners")
            {
                txtEmail.Text = txtEmail.Text;
                txtPassword.Text = txtPassword.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Corporates")
            {
                txtEmail.Text = CP_txtemail.Text;
                txtPassword.Text = CP_txtpassword.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Coporate Employees")
            {
                txtEmail.Text = IP_txtemail.Text;
                txtPassword.Text = IP_txtOTP.Text;
            }
            else if (DDL_LoginType.SelectedValue == "Customers")
            {
                txtEmail.Text = CT_txtemail.Text;
                txtPassword.Text = CT_txtOTP.Text;
            }
            else
            {

            }

            Bal BusinessaccessLayer = new Bal();
            DataTable dtVerifyMasterLogin = new DataTable();
            //if(lblOTP.Text==CT_txtOTP.Text)
            //{
            //    txtPassword.Text = CT_txtOTP.Text;
            //}
            //else if (lblOTP.Text == IP_txtOTP.Text)
            //{
            //    txtPassword.Text = IP_txtOTP.Text;
            //}
            //else
            //{
            //    return;
            //}
           
            dtVerifyMasterLogin = BusinessaccessLayer.VerifyMasterLoginMO(txtEmail.Text.Trim(), txtPassword.Text.Trim());

            if (dtVerifyMasterLogin != null && dtVerifyMasterLogin.Rows.Count > 0)
            {
                Session["UserId"] = dtVerifyMasterLogin.Rows[0]["User_Id"].ToString();
                Session["username"] = dtVerifyMasterLogin.Rows[0]["FullName"].ToString();
                Session["UserRolePermission"] = dtVerifyMasterLogin.Rows[0]["UserRolePermission"].ToString();
                Session["RoleId"] = dtVerifyMasterLogin.Rows[0]["role_id"].ToString();
                Session["CorporateId"] = dtVerifyMasterLogin.Rows[0]["CorporateId"].ToString();
                status = dtVerifyMasterLogin.Rows[0]["AccountStatus"].ToString();

                if (customCheck1.Checked == true)
                {

                    if (status != "InActive")
                    {
                        Response.Redirect("~/Customer/CustomerDashBoard.aspx");
                    }
                    else if (status == "InActive")
                    {
                        ChangeMsg.Text = "Your Account is InActive, Kindly inform to Network Team !!!";
                        //LinkButton2.Visible = true;
                    }
                    else
                    {
                        ChangeMsg.Text = "Access Denied....<br>email id or password is incorrect !!!";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Please Accept Terms and Conditions');</script>");
                }
            }
            else
            {
                ChangeMsg.Text = "User Not Exists!!!";

            }
        }

        public void Update_OTP()
        {
            string mbltxt="";
            if(CT_txtemail.Text!="")
            {
               mbltxt = CT_txtemail.Text;
            }
            else if(IP_txtemail.Text!="")
            {
                mbltxt = IP_txtemail.Text;
            }
            else
            {
                CT_txtemail.Text = "";
                IP_txtemail.Text = "";
            }
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("OTP_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "UpdateOTP");
            cmd.Parameters.AddWithValue("@MobileNo", Convert.ToString(mbltxt));
            cmd.Parameters.AddWithValue("@OTP", lblOTP.Text);
            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void SendLink()
        {
            MailMessage mm = new MailMessage("kamleshprajapat45@gmail.com", txtEmail.Text);

            mm.Subject = "Password Recovery";
            mm.Body = string.Format("Dear Service Provider, Please update your details and complete your profile on WELLEAZY. Visit link: {0} , Regards, Team WELLEAZY.", txtEmail.Text);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.rediffmailpro.com";
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "kamleshprajapat45@gmail.com";
            NetworkCred.Password = "Prajapat@6991#";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SendLink();
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxList2.SelectedValue == "OTP")
            {
                IP_txtOTP.Visible = true;
                IP_txtpassword.Visible = false;
                IP_txtpassword.Text = "";
                OTP_Generate();

            }
            else
            {
                IP_txtOTP.Visible = false;
                IP_txtpassword.Visible = true;
                IP_txtOTP.Text = "";
            }
        }
        
    }
}