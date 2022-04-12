using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy
{
    public partial class WalkinRegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    EmployeeView.ActiveViewIndex = 0;
                    //EmployeeView.ActiveViewIndex = 1;
                }
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

        }
    }
}