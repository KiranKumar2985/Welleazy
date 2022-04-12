using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Welleazy.Admin
{
    public partial class CorporateEmployeeLoginCreation : System.Web.UI.Page
    {
        static string EmailId = "";
        static string MobileNo = "";
        static string RolePermission = "";
        static string LoginRefId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadSubRole();
                LoadCorporateDetails();
                LoadPermissionDetails();
                LoginCreationView.ActiveViewIndex = 0;
            }
        }

        public void LoadSubRole()
        {

        }

        public void LoadCorporateDetails()
        {
            DataTable dtCorporateDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();

            if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
            {
                cmbCorporateName.DataSource = dtCorporateDetails;
                cmbCorporateName.DataTextField = "CorporateName";
                cmbCorporateName.DataValueField = "CorporateId";
                cmbCorporateName.DataBind();

            }
        }

        public void LoadPermissionDetails()
        {
            DataSet dtSubPermission = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtSubPermission = BusinessAccessLayer.LoadPermissionDetailsForLoginCreation();

            if (dtSubPermission != null && dtSubPermission.Tables[0].Rows.Count > 0)
            {
                Session["DefaultProcess"] = dtSubPermission.Tables[0];
                Session["DefaultTasks"] = dtSubPermission.Tables[1];
                rgvDefaultRoleTasks.DataSource = dtSubPermission.Tables[0];
                rgvDefaultRoleTasks.DataBind();
            }
            else
            {
                rgvDefaultRoleTasks.DataSource = null;
                rgvDefaultRoleTasks.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string RolePermissions = "";
            Bal BusinessAccessLayer = new Bal();

            string IPAddress = "";

            try
            {

                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPAddress = ip.ToString();
                    }
                }

                for (int Index = 0; Index < rgvDefaultRoleTasks.Items.Count; Index++)
                {
                    RadGrid rgProductServicesDepth = (RadGrid)rgvDefaultRoleTasks.Items[Index].FindControl("rgvDefaultRoleTasksDepth");

                    for (int IndexJ = 0; IndexJ < rgProductServicesDepth.Items.Count; IndexJ++)
                    {
                        CheckBoxList cbTasks = (CheckBoxList)rgProductServicesDepth.Items[0].FindControl("cbTasks");


                        for (int indexK = 0; indexK < cbTasks.Items.Count; indexK++)
                        {
                            if (cbTasks.Items[indexK].Selected == true)
                            {
                                if (RolePermissions.Trim() == "")
                                    RolePermissions = cbTasks.Items[indexK].Value.Trim();
                                else
                                    RolePermissions += "," + cbTasks.Items[indexK].Value.Trim();
                            }
                        }
                    }
                }


                if(btnSave.Text=="Save")
                {
                    txtPassword.Text = txtUserName.Text + "@123";

                    BusinessAccessLayer.CorporateLoginCreation(0,Convert.ToInt32(cmbCorporateName.SelectedValue),Convert.ToInt32(cmbEmployeeName.SelectedValue), txtUserName.Text.Trim(), encrypttext(txtPassword.Text.Trim()), EmailId, MobileNo, RolePermissions, Convert.ToInt32(rbIsActive.SelectedValue), 1);
                    showPopup("Success", "Login Created Successfully");

                }
                else
                {
                    BusinessAccessLayer.CorporateLoginCreation(Convert.ToInt32(LoginRefId),Convert.ToInt32(cmbCorporateName.SelectedValue),Convert.ToInt32(cmbEmployeeName.SelectedValue), txtUserName.Text.Trim(), encrypttext(txtPassword.Text.Trim()), EmailId,MobileNo, RolePermissions, Convert.ToInt32(rbIsActive.SelectedValue), 1);
                    showPopup("Success", "Login Updated Successfully");
                }

                ClearFields();

                
            }
            catch(Exception ex)
            {

            }
        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ClearFields();


        }

        public void ClearFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";

            //cmbLoginType.SelectedValue = "0";
            //cmbSubRole.SelectedValue = "0";
            cmbCorporateName.SelectedValue = "0";
            cmbEmployeeName.SelectedValue = "0";
            cmbCorporateBranch.SelectedValue = "0";

            rbIsActive.SelectedValue = "1";

            RolePermission = "";
            LoadPermissionDetails();
            btnSave.Text = "Save";
            //rgvDefaultRoleTasks.DataSource = new object[] { };
            //rgvDefaultRoleTasks.DataBind();
        }

        protected void cmbSubRole_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rgvDefaultRoleTasks_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lblPermissionId = (Label)item.FindControl("lblPermissionId");
                    RadGrid rgvDefaultRoleTasksDepth = (RadGrid)item.FindControl("rgvDefaultRoleTasksDepth");


                    DataTable objrgvDefaultRoleTasksDepth = new DataTable();
                    objrgvDefaultRoleTasksDepth = Session["DefaultTasks"] as DataTable;




                    DataView dv = new DataView(objrgvDefaultRoleTasksDepth);
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

                    //if (Session["DefaultTaskBasedONRole"] != null && Session["DefaultTaskBasedONRole"].ToString().Trim() != "")
                    {
                        // DataTable objrgvDefaultRoleTasks = new DataTable();
                        //      string[] objrgvDefaultRoleTasks = Session["DefaultTaskBasedONRole"] as string[];
                        String[] RolePermissionValues = RolePermission.Split(',');
                        //if (objrgvDefaultRoleTasks != null && objrgvDefaultRoleTasks.Length > 0)
                        {
                            for (int Index = 0; Index < RolePermissionValues.Length; Index++)
                            //for (int Index = 0; Index < objrgvDefaultRoleTasks.Length; Index++)
                            {
                                if (cbTasks.Items.FindByValue(RolePermissionValues[Index].ToString().Trim()) != null)
                                {
                                    cbTasks.Items.FindByValue(RolePermissionValues[Index].ToString().Trim()).Selected = true;

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

            //DataTable dtPermissionDetails = new DataTable();
            //Bal BusinessAccessLayer = new Bal();
            //dtPermissionDetails = BusinessAccessLayer.LoadPermissionDetailsForLoginCreation();


            DataTable objrgvDefaultRoleTasksDepth = new DataTable();
            objrgvDefaultRoleTasksDepth = Session["DefaultTasks"] as DataTable;
            //DataView dv = new DataView(dt1);
            DataView dv = new DataView(objrgvDefaultRoleTasksDepth);
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

        protected void cmbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadCorporateBranchList();
            //DataTable dtEmployeeDetails = new DataTable();
            //Bal BusinessAccessLayer = new Bal();
            ////if (cmbLoginType.SelectedValue.Equals("2"))
            ////{
            //dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetails(Convert.ToInt32(cmbCorporateName.SelectedValue));

            //if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            //{
            //    cmbEmployeeName.DataSource = dtEmployeeDetails;
            //    cmbEmployeeName.DataTextField = "EmployeeName";
            //    cmbEmployeeName.DataValueField = "EmployeeRefId";
            //    cmbEmployeeName.DataBind();
            //}
        }

        public void LoadCorporateBranchList()
        {

            cmbCorporateBranch.Items.Clear();
            //cmbCorporateBranch.Items.Insert(0, "Select Branch Id");
            DataTable dtCorporateBranchDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtCorporateBranchDetails = BusinessAccessLayer.LoadCorporateBranchList(Convert.ToInt32(cmbCorporateName.SelectedValue));


            if (dtCorporateBranchDetails != null && dtCorporateBranchDetails.Rows.Count > 0)
            {
                cmbCorporateBranch.DataSource = dtCorporateBranchDetails;
                cmbCorporateBranch.DataTextField = "Branch";
                cmbCorporateBranch.DataValueField = "BranchDetailsId";
                cmbCorporateBranch.DataBind();
            }

            cmbCorporateBranch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-Select-"));
        }

        protected void cmbCorporateBranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtEmployeeDetails = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtEmployeeDetails = BusinessAccessLayer.FetchEmployeeDetailsOnCorporateId(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbCorporateBranch.SelectedValue));

            cmbEmployeeName.Items.Clear();
            if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)

            {
                EmailId = dtEmployeeDetails.Rows[0]["Emailid"].ToString();
                MobileNo = dtEmployeeDetails.Rows[0]["MobileNo"].ToString();
                cmbEmployeeName.DataSource=  dtEmployeeDetails;
                cmbEmployeeName.DataTextField = "EmployeeName";
                cmbEmployeeName.DataValueField = "EmployeeRefId";
                cmbEmployeeName.DataBind();

            }
            else
            {
                //rgvSearchEmployeeDetails.DataSource = new object[] { }; ;
                //rgvSearchEmployeeDetails.DataBind();
            }
            cmbEmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-Select-"));
        }

        protected void cmbEmployeeName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLoginUserDetails = new DataTable();
            dtLoginUserDetails = BusinessAccessLayer.LoadLoginUserDetails(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbEmployeeName.SelectedValue));

            if (dtLoginUserDetails != null && dtLoginUserDetails.Rows.Count > 0)
            {
                LoginRefId = dtLoginUserDetails.Rows[0]["LoginRefId"].ToString();
                cmbCorporateName.SelectedValue = dtLoginUserDetails.Rows[0]["CorporateId"].ToString();
                txtUserName.Text = dtLoginUserDetails.Rows[0]["UserName"].ToString();
                //txtPassword.Text = Decrypttext(dtLoginUserDetails.Rows[0]["Password"].ToString());
                string Password = dtLoginUserDetails.Rows[0]["Password"].ToString();

                txtPassword.Text = Decrypttext(Password);

                RolePermission = dtLoginUserDetails.Rows[0]["RolePermissions"].ToString();
                rbIsActive.SelectedValue = dtLoginUserDetails.Rows[0]["IsActive"].ToString();

                Session["UserPermission"] = RolePermission;
                LoadPermissionDetails();

                btnSave.Text = "Update";

            }
        }
    }
    }
    
