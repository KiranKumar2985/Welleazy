using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            LabelDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LabelDateTime1.Text = DateTime.UtcNow.ToLongDateString();
            TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
            DateTime CuurectDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
            LabelDateTime2.Text = CuurectDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}