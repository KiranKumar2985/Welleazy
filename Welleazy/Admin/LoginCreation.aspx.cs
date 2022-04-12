using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Admin
{
    public partial class LoginCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadLoginType();
                LoadDomainType();
                LoadPermissionDetails();
                LoginCreationView.ActiveViewIndex = 0;

            }

            
        }

        public void LoadPermissionDetails()
        {
            DataTable dtSubPermission = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtSubPermission = BusinessAccessLayer.LoadPermissionDetailsForLoginCreation();

            if (dtSubPermission != null && dtSubPermission.Rows.Count > 0)
            {
                rgvDefaultRoleTasks.DataSource = dtSubPermission;
                rgvDefaultRoleTasks.DataBind();
            }
            else
            {
                rgvDefaultRoleTasks.DataSource = null;
                rgvDefaultRoleTasks.DataBind();
            }
        }

        public void LoadLoginType()
        {
            DataTable dtLoginType = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoginType = BusinessAccessLayer.LoadLoginType();

            if(dtLoginType!=null && dtLoginType.Rows.Count>0)
            {
                cmbLoginType.DataSource = dtLoginType;
                cmbLoginType.DataTextField = "LoginType";
                cmbLoginType.DataValueField = "LoginTypeId";
                cmbLoginType.DataBind();
            }


        }

        public void LoadDomainType()
        {
            DataTable dtDomain = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtDomain = BusinessAccessLayer.LoadDomain();

            if(dtDomain!=null && dtDomain.Rows.Count>0)
            {
                cmbDomainType.DataSource = dtDomain;
                cmbDomainType.DataValueField = "DomainDetailsId";
                cmbDomainType.DataTextField = "DomainName";
                cmbDomainType.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();


            string IPAddress = "";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPAddress = ip.ToString();
                }
            }

            string strTasks = "";
            for (int Index = 0; Index < rgvDefaultRoleTasks.Items.Count; Index++)
            {
                RadGrid rgvDefaultRoleTasksDepth = (RadGrid)rgvDefaultRoleTasks.Items[Index].FindControl("rgvDefaultRoleTasksDepth");

                for (int IndexJ = 0; IndexJ < rgvDefaultRoleTasksDepth.Items.Count; IndexJ++)
                {
                    CheckBoxList cbTasks = (CheckBoxList)rgvDefaultRoleTasksDepth.Items[0].FindControl("cbTasks");

                    for (int indexK = 0; indexK < cbTasks.Items.Count; indexK++)
                    {
                        if (cbTasks.Items[indexK].Selected == true)
                        {
                            if (strTasks.Trim() == "")
                                strTasks = cbTasks.Items[indexK].Value.Trim();
                            else
                                strTasks += "," + cbTasks.Items[indexK].Value.Trim();
                        }
                    }
                }
            }

            int result = BusinessAccessLayer.InsertUpdateLoginDetails(1,txtUserName.Text.Trim(),txtPassword.Text.Trim(), strTasks, 1, IPAddress);
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void cmbLoginType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtCorporateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            if(cmbLoginType.SelectedValue.Equals("2"))
            {
                dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

                if(dtCorporateDetails!=null && dtCorporateDetails.Rows.Count>0)
                {
                    cmbCorporateName.DataSource = dtCorporateDetails;
                    cmbCorporateName.DataTextField = "CorporateName";
                    cmbCorporateName.DataValueField = "CorporateId";
                    cmbCorporateName.DataBind();
                    
                }
            }
        }

        protected void cmbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtEmployeeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            //if (cmbLoginType.SelectedValue.Equals("2"))
            //{
                dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetails(Convert.ToInt32(cmbCorporateName.SelectedValue));

                if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                {
                    cmbEmployeeName.DataSource = dtEmployeeDetails;
                    cmbEmployeeName.DataTextField = "EmployeeName";
                    cmbEmployeeName.DataValueField = "EmployeeRefId";
                    cmbEmployeeName.DataBind();
                }
            //}
        }

        protected void chkAllTask_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objDDL = (CheckBox)sender;
            GridDataItem row = (GridDataItem)objDDL.NamingContainer;
            int intIndex = row.ItemIndex;
            //  GridDataItem item = (GridDataItem)e.Item;
            // Label lblProcessId = (Label)item.FindControl("lblProcessId");
            // RadGrid rgvDefaultRoleTasksDepth = (RadGrid)item.FindControl("rgvDefaultRoleTasksDepth");
            CheckBox chkAllTask = (CheckBox)rgvDefaultRoleTasks.Items[intIndex].FindControl("chkAllTask");
            Label lblPermissionId = (Label)rgvDefaultRoleTasks.Items[intIndex].FindControl("lblPermissionId");
            RadGrid rgvDefaultRoleTasksDepth = (RadGrid)rgvDefaultRoleTasks.Items[intIndex].FindControl("rgvDefaultRoleTasksDepth");

            //Label lblProcessId = new Label();
            //lblProcessId.Text = "1";
            //DataTable dt1 = new DataTable();
            //dt1.Columns.Add("processId", typeof(int));
            //dt1.Columns.Add("ProcessDescription", typeof(string));
            //dt1.Columns.Add("TaskId", typeof(int));
            //dt1.Columns.Add("TaskDescription", typeof(string));

            //dt1.Rows.Add(1, "IC", 1, "Test");
            //dt1.Rows.Add(1, "IC", 2, "Test2");

            DataTable dtPermissionDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtPermissionDetails = BusinessAccessLayer.LoadPermissionDetailsForLoginCreation();
            

            DataTable objrgvDefaultRoleTasksDepth = new DataTable();
            objrgvDefaultRoleTasksDepth = Session["DefaultTasks"] as DataTable;
            //DataView dv = new DataView(dt1);
            DataView dv = new DataView(dtPermissionDetails);
            dv.RowFilter = "PermissionId=" + lblPermissionId.Text.Trim();

            DataTable dt = new DataTable();
            dt.Columns.Add(lblPermissionId.Text.Trim());
            dt.Rows.Add("");
            rgvDefaultRoleTasksDepth.DataSource = dt;
            rgvDefaultRoleTasksDepth.DataBind();
            CheckBoxList cbTasks = (CheckBoxList)rgvDefaultRoleTasksDepth.Items[0].FindControl("cbTasks");

            for (int Index = 0; Index < dv.Count; Index++)
            {
                cbTasks.Items.Add(new ListItem(dv[Index]["SubPermission"].ToString().Trim(), dv[Index]["SubPermissionId"].ToString().Trim()));
                cbTasks.Items.FindByValue(dv[Index]["SubPermissionId"].ToString().Trim()).Selected = chkAllTask.Checked;
            }
            GridHeaderItem headerItem = (GridHeaderItem)rgvDefaultRoleTasksDepth.MasterTableView.GetItems(GridItemType.Header)[0];
            Label lblProcessHeader = (Label)headerItem.FindControl("lblProcessHeader");  //access Label inside HeaderTemplate  
            lblProcessHeader.Text = dv[0]["Description"].ToString().Trim();
        }

        protected void rgvDefaultRoleTasks_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lblPermissionId = (Label)item.FindControl("lblPermissionId");
                    RadGrid rgvDefaultRoleTasksDepth = (RadGrid)item.FindControl("rgvDefaultRoleTasksDepth");

                    //if (Session["DefaultTasks"] != null)
                    //{
                        //Label lblProcessId = new Label();
                        //lblProcessId.Text = "1";
                        //DataTable dt1 = new DataTable();
                        //dt1.Columns.Add("processId", typeof(int));
                        //dt1.Columns.Add("ProcessDescription", typeof(string));
                        //dt1.Columns.Add("TaskId", typeof(int));
                        //dt1.Columns.Add("TaskDescription", typeof(string));

                        //dt1.Rows.Add(1, "IC", 1, "Test");
                        //dt1.Rows.Add(1, "IC", 2, "Test2");
                        DataTable objrgvDefaultRoleTasksDepth = new DataTable();
                        objrgvDefaultRoleTasksDepth = Session["DefaultTasks"] as DataTable;

                        DataTable dtPermissionDetails = new DataTable();
                        Bal BusinessAccessLayer = new Bal();
                        dtPermissionDetails = BusinessAccessLayer.LoadPermissionDetailsForLoginCreation();


                        DataView dv = new DataView(dtPermissionDetails);
                        dv.RowFilter = "PermissionId=" + lblPermissionId.Text.Trim();

                        DataTable dt = new DataTable();
                        dt.Columns.Add(lblPermissionId.Text.Trim());
                        dt.Rows.Add("");
                        rgvDefaultRoleTasksDepth.DataSource = dt;
                        rgvDefaultRoleTasksDepth.DataBind();

                        CheckBoxList cbTasks = (CheckBoxList)rgvDefaultRoleTasksDepth.Items[0].FindControl("cbTasks");

                        for (int Index = 0; Index < dv.Count; Index++)
                        {
                            cbTasks.Items.Add(new ListItem(dv[Index]["SubPermission"].ToString().Trim(), dv[Index]["SubPermissionId"].ToString().Trim()));
                        }

                        if (Session["DefaultTaskBasedONRole"] != null && Session["DefaultTaskBasedONRole"].ToString().Trim() != "")
                        {
                            // DataTable objrgvDefaultRoleTasks = new DataTable();
                            string[] objrgvDefaultRoleTasks = Session["DefaultTaskBasedONRole"] as string[];

                            if (objrgvDefaultRoleTasks != null && objrgvDefaultRoleTasks.Length > 0)
                            {
                                for (int Index = 0; Index < objrgvDefaultRoleTasks.Length; Index++)
                                {
                                    if (cbTasks.Items.FindByValue(objrgvDefaultRoleTasks[Index].ToString().Trim()) != null)
                                    {
                                        cbTasks.Items.FindByValue(objrgvDefaultRoleTasks[Index].ToString().Trim()).Selected = true;

                                    }
                                }
                            }
                        }
                    
                    GridHeaderItem headerItem = (GridHeaderItem)rgvDefaultRoleTasksDepth.MasterTableView.GetItems(GridItemType.Header)[0];
                    Label lblProcessHeader = (Label)headerItem.FindControl("lblProcessHeader");  //access Label inside HeaderTemplate  
                    lblProcessHeader.Text = dv[0]["Description"].ToString().Trim();
                }
            }
            
            catch (Exception ex)
            {
                //string ErrorID = EffiaErrorLogWriter.writeToErrorLog(ex);
                //WUCMessage.ShowMessage("Error", "Error ID :" + ErrorID + " , " + PopUpMessages.AdminError);
            }
        }

        protected void cmbEmployeeName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DataTable dtPermissions = new DataTable();
            //Bal BusinessAcessLayer = new Bal();
            //dtPermissions = BusinessAcessLayer.LoadUserPermissions(Convert.ToInt32(cmbEmployeeName.SelectedValue));
            //Session["DefaultTaskBasedONRole"] = dtPermissions;

            //rgvDefaultRoleTasks.DataSource = dtPermissions;
            //rgvDefaultRoleTasks.DataBind();
        }
    }
}