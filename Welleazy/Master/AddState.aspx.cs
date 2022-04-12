using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.Master
{
    public partial class AddState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadStateDetails();
                StateView.ActiveViewIndex = 0;
            }
            
        }

        public void LoadStateDetails()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails= BusinessAccessLayer.LoadStateDetails();

            if(dtStateDetails!=null && dtStateDetails.Rows.Count>0)
            {
                rgState.DataSource = dtStateDetails;
                rgState.DataBind();
            }
            else
            {
                rgState.DataSource = null;
                rgState.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            string IsDataExists = "0";
            if(btnSave.Text.Equals("Save"))
            {
                BusinessAccessLayer.InsertUpdateState(0,txtStateName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue),out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Saved Successfully");
                }
            }
            else
            {
                BusinessAccessLayer.InsertUpdateState(Variables.StateId,txtStateName.Text.Trim(), Convert.ToInt32(rbIsActive.SelectedValue),out IsDataExists);
                if (IsDataExists == "1")
                {
                    showPopup("Warning", "Data Already Exists");
                }
                else
                {
                    showPopup("Warning", "Data Updated Successfully");
                    
                }
            }
            ClearFields();
            LoadStateDetails();
            
        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtStateName.Text = "";
            rbIsActive.SelectedIndex = 0;
            StateView.ActiveViewIndex = 0;
            btnSave.Text = "Save";
        }

        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            StateView.ActiveViewIndex = 1;
        }

        protected void rgState_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblStateId = (Label)rgState.Items[intIndex % 10].FindControl("lblStateId"); // % 15 for page indexing
                    Variables.StateId = Convert.ToInt32(lblStateId.Text.Trim());
                    LoadStateDetailsById();
                    
                    btnSave.Text = "Update";

                   
                    StateView.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {
                    
                    
                }
            }
        }

        public void LoadStateDetailsById()
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadStateDetailsById(Variables.StateId);


            if(dtStateDetails!=null && dtStateDetails.Rows.Count>0)
            {
                txtStateName.Text = dtStateDetails.Rows[0]["StateName"].ToString();

                if(dtStateDetails.Rows[0]["IsActive"].ToString().Equals("True"))
                {
                    rbIsActive.SelectedValue = "1";
                }
                else
                {
                    rbIsActive.SelectedValue = "0";
                }
            }


        }

        protected void rgState_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtStateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtStateDetails = BusinessAccessLayer.LoadStateDetails();

            if (dtStateDetails != null && dtStateDetails.Rows.Count > 0)
            {
                rgState.DataSource = dtStateDetails;
                //rgState.DataBind();
            }
            else
            {
                rgState.DataSource = null;
                //rgState.DataBind();
            }

        }

        protected void rgState_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void btnState_Click(object sender, EventArgs e)
        {
            StateView.ActiveViewIndex = 1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            StateView.ActiveViewIndex = 0;

        }
    }
}