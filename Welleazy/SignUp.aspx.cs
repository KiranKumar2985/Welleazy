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
using Telerik.Web.UI;

namespace Welleazy
{
    public partial class SignUp : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        DateTime? nul = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Reset()
        {
            txt_email.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_mobileno.Text = "";
        }
        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(checkterm.Checked==true)
            {
                try
                {

                    string emailid = txt_email.Text.Trim();

                    String[] email = emailid.Split('@');

                    string emailpart = email[1];

                    if (emailpart.Equals("welnext.com") || emailpart.Equals("welleazy.com"))
                    {
                        //SqlConnection con = new SqlConnection(conStr);
                        //SqlCommand cmd = new SqlCommand("proc_EmployeeDetails", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Action", "Insert");
                        //cmd.Parameters.AddWithValue("@EmployeeRefId", Label1.Text);
                        //cmd.Parameters.AddWithValue("@EmployeeId", Label1.Text);
                        //cmd.Parameters.AddWithValue("@FirstName", txt_fname.Text);
                        //cmd.Parameters.AddWithValue("@MiddleName", "");
                        //cmd.Parameters.AddWithValue("@LastName", txt_lname.Text);
                        //cmd.Parameters.AddWithValue("@EmployeeName", txt_fname.Text +" "+ txt_lname.Text);
                        //cmd.Parameters.AddWithValue("@Address", "");
                        //cmd.Parameters.AddWithValue("@Emailid", txt_email.Text);
                        //cmd.Parameters.AddWithValue("@MobileNo", txt_mobileno.Text);
                        //cmd.Parameters.AddWithValue("@CorporateId", "1");
                        //cmd.Parameters.AddWithValue("@AccountActivationURL", "");
                        //cmd.Parameters.AddWithValue("@IsActive", "0");
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        Bal BusinessAccessLayer = new Bal();
                        string IsDataExists = "0";

                        BusinessAccessLayer.InsertUpdateEmployeeDetails(0, "", 
                            txt_fname.Text.Trim() + " " + txt_lname.Text.Trim(), "", txt_email.Text.Trim(), txt_mobileno.Text.Trim(),
                           "", nul, 0, 0, "", "","", "", 0, 0, "","", nul, 0, nul, 0, nul, nul, "", 0, out IsDataExists);
                        if (IsDataExists == "1")
                        {
                            //showPopup("Warning", "Data Already Exists");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Already Exists!!');</script>");
                        }
                        else
                        {
                            //showPopup("Warning", "Data Saved Successfully");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Saved Successfully!!');</script>");
                        }

                        Reset();
                    }
                    else
                    {
                        //SqlConnection con = new SqlConnection(conStr);
                        //SqlCommand cmd = new SqlCommand("proc_CustomerDetails", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Action", "Insert");
                        //cmd.Parameters.AddWithValue("@CustomerRefId", Label1.Text);
                        //cmd.Parameters.AddWithValue("@CustomerId", Label1.Text);
                        //cmd.Parameters.AddWithValue("@FirstName", txt_fname.Text);
                        //cmd.Parameters.AddWithValue("@LastName", txt_lname.Text);
                        //cmd.Parameters.AddWithValue("@CustomerName", txt_fname.Text + " " + txt_lname.Text);
                        //cmd.Parameters.AddWithValue("@Address", "");
                        //cmd.Parameters.AddWithValue("@Emailid", txt_email.Text);
                        //cmd.Parameters.AddWithValue("@MobileNo", txt_mobileno.Text);
                        //cmd.Parameters.AddWithValue("@OTP", "");
                        //cmd.Parameters.AddWithValue("@AccountActivationURL", "");
                        //cmd.Parameters.AddWithValue("@IsActive", "0");
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        Bal BusinessAccessLayer = new Bal();
                        string IsDataExists = "0";

                        BusinessAccessLayer.InsertUpdateCustomerDetails(0, "", txt_fname.Text.Trim(), txt_lname.Text.Trim(),
                             txt_fname.Text.Trim() + " " + txt_lname.Text.Trim(), "", txt_email.Text.Trim(), txt_mobileno.Text.Trim(), "", "", 0, out IsDataExists);
                        if (IsDataExists == "1")
                        {
                            //showPopup("Warning", "Data Already Exists");");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Already Exists!!');</script>");
                        }
                        else
                        {
                            //showPopup("Warning", "Data Saved Successfully");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Saved Successfully!!');</script>");
                        }

                        Reset();

                    }

                }
                catch (Exception ex)
                {
                    //Response.Write(ex.ToString());
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Saved Successfully!!');</script>");
                    Reset();
                }
            }
            else
            {
                return;
            }
            
           
            
        }
    }
}