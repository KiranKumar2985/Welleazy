using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm2 : System.Web.UI.Page
    {
      
        //protected System.Web.UI.HtmlControls.HtmlInputHidden timeAllocated;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                

                //string time = "2021-06-08 16:47:00";


            }

           

        }

       
       

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            //timer.Value = time.ToString();
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            timer.Visible = false;
            btnGenerateOTP.Text = "Re Generate OTP";
            //showPopup("Succes", "Completed");
            return;
            //Response.Redirect("~/Testing Forms/ModalPopUp.aspx");
        }

        protected void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            //lblTimer.Visible = true;
            timer.Visible = true;DateTime CreatedDate = new DateTime();
            CreatedDate = System.DateTime.Now;

            DateTime EndDate = new DateTime();
            EndDate = CreatedDate.AddMinutes(1);
            //string time = "2022-02-04 15:40:00";
            timer.Value = EndDate.ToString();
            //lblTimer.Visible = false;

        }

        
    }
}