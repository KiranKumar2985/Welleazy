using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy
{
    public partial class TestingDynamicControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RadGrid1.DataSource = new object[] { };
                RadGrid1.DataBind();
            }

            DAta

            RadGrid1.DataSource = new object[] { };
            RadGrid1.DataBind();
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
            {
                GridEditableItem edititem = (GridEditableItem)e.Item;
                string strtxt = edititem.GetDataKeyValue("CategoryId").ToString();
                strtxt = "1";
                if (strtxt == "0")
                {
                    edititem["CategoryId"].Controls.Clear();
                    CheckBox chkbx = new CheckBox();
                    chkbx.ID = "CheckBox1";

                    edititem["CategoryId"].Controls.Add(chkbx);

                }
                else if (strtxt == "1")
                {
                    edititem["CategoryId"].Controls.Clear();
                    DropDownList ddl = new DropDownList();
                    ddl.ID = "DropDownList1";
                    edititem["CategoryId"].Controls.Add(ddl);


                }

                else if (strtxt == "2")
                {
                    edititem["CategoryId"].Controls.Clear();
                    TextBox txtbx = new TextBox();
                    txtbx.ID = "TextBox1";
                    edititem["CategoryId"].Controls.Add(txtbx);


                }

            }
        }
    }
}