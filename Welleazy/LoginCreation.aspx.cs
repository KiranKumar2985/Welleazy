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
    public partial class LoginCreation : System.Web.UI.Page
    {

        static string DisplayName = "";
        static string EmailId = "";
        static string MobileNo = "";
        static string RolePermission = "";
        static string LoginRefId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadLoginType();
                //LoadDomainType();
                LoadPermissionDetails();
                LoginCreationView.ActiveViewIndex = 0;

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

        public void LoadLoginType()
        {
            DataTable dtLoginType = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoginType = BusinessAccessLayer.LoadLoginType();

            if (dtLoginType != null && dtLoginType.Rows.Count > 0)
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

            if (dtDomain != null && dtDomain.Rows.Count > 0)
            {
                //cmbDomainType.DataSource = dtDomain;
                //cmbDomainType.DataValueField = "DomainDetailsId";
                //cmbDomainType.DataTextField = "DomainName";
                //cmbDomainType.DataBind();
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
            int result = 0;

            try
            {

                if (cmbLoginType.SelectedValue != "2")
                {
                    //rfvCorporateName.Enabled = false;
                }

                Int32 CorporateId = 0;
                if (!cmbCorporateName.SelectedValue.Equals(""))
                {
                    CorporateId = Convert.ToInt32(cmbCorporateName.SelectedValue);
                }



                if (btnSave.Text == "Save")
                {
                    //txtPassword.Text = txtUserName.Text + "@123";
                    if (CheckUserNameAvailabilty())
                    {
                        txtUserName.Text = "";
                        showPopup("Warning", "User Name Already Exists");
                        return;
                    }
                    result = BusinessAccessLayer.InsertUpdateLoginDetails(0, Convert.ToInt32(cmbUser.SelectedValue), CorporateId, txtUserName.Text.Trim(), encrypttext(txtPassword.Text.Trim()), txtDisplayName.Text.Trim(), MobileNo, EmailId, strTasks, 1, IPAddress);
                    showPopup("Success", "Login Created Successfully");
                }
                else
                {
                    result = BusinessAccessLayer.InsertUpdateLoginDetails(Convert.ToInt32(LoginRefId), Convert.ToInt32(cmbUser.SelectedValue), CorporateId, txtUserName.Text.Trim(), encrypttext(txtPassword.Text.Trim()), txtDisplayName.Text.Trim(), MobileNo, EmailId, strTasks, 1, IPAddress);
                    showPopup("Success", "Login Updated Successfully");
                }

                ClearFields();
            }
            catch (Exception ex)
            {

            }

        }

        private void showPopup(string title, string body)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void ClearFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";

            cmbLoginType.SelectedValue = "0";
            cmbSubRole.SelectedValue = "0";
            cmbCorporateName.SelectedValue = "0";
            cmbUser.SelectedValue = "0";

            rbIsActive.SelectedValue = "1";

            RolePermission = "";
            LoadPermissionDetails();
            btnSave.Text = "Save";
            //rgvDefaultRoleTasks.DataSource = new object[] { };
            //rgvDefaultRoleTasks.DataBind();
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



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void cmbLoginType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbSubRole.DefaultItem.Text = "Select Sub Role";
            DataTable dtLoadUserRoles = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadUserRoles = BusinessAccessLayer.LoadUserRoles(Convert.ToInt32(cmbLoginType.SelectedValue));

            cmbSubRole.Items.Clear();
            if (dtLoadUserRoles != null && dtLoadUserRoles.Rows.Count > 0)
            {
                cmbSubRole.DataSource = dtLoadUserRoles;
                cmbSubRole.DataTextField = "subrole";
                cmbSubRole.DataValueField = "subrole_id";
                cmbSubRole.DataBind();

                cmbSubRole.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-Select-"));
            }
            else
            {
                cmbSubRole.DataSource = null;
                cmbSubRole.DataBind();  
            }
            DataTable dtCorporateDetails = new DataTable();
            //Bal BusinessAccessLayer = new Bal();
            if (cmbLoginType.SelectedValue.Equals("2"))
            {
                cmbCorporateName.Enabled = true;
                dtCorporateDetails = BusinessAccessLayer.LoadCorporateDetailsDropDown();
                cmbCorporateName.Items.Clear();
                if (dtCorporateDetails != null && dtCorporateDetails.Rows.Count > 0)
                {
                    cmbCorporateName.DataSource = dtCorporateDetails;
                    cmbCorporateName.DataTextField = "CorporateName";
                    cmbCorporateName.DataValueField = "CorporateId";
                    cmbCorporateName.DataBind();

                }
                cmbCorporateName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-Select-"));
            }
            else
            {
                cmbCorporateName.Enabled = false;
            }
        }

        protected void cmbCorporateName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DataTable dtEmployeeDetails = new DataTable();
            //Bal BusinessAccessLayer = new Bal();
            ////if (cmbLoginType.SelectedValue.Equals("2"))
            ////{
            //    dtEmployeeDetails = BusinessAccessLayer.LoadEmployeeDetails(Convert.ToInt32(cmbCorporateName.SelectedValue));

            //    if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
            //    {
            //        //cmbEmployeeName.DataSource = dtEmployeeDetails;
            //        //cmbEmployeeName.DataTextField = "EmployeeName";
            //        //cmbEmployeeName.DataValueField = "EmployeeRefId";
            //        //cmbEmployeeName.DataBind();
            //    }
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

        protected void rgvDefaultRoleTasks_ItemDataBound(object sender, GridItemEventArgs e)
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

                    //if (Session["UserPermission"] != null && Session["UserPermission"].ToString().Trim() != "")
                    {
                        //string = Variables.ServicesId;
                        String[] RolePermissionValues = RolePermission.Split(',');
                        // DataTable objrgvDefaultRoleTasks = new DataTable();
                        //string[] objrgvDefaultRoleTasks = Session["UserPermission"] as string[];

                        // if (objrgvDefaultRoleTasks != null && objrgvDefaultRoleTasks.Length > 0)
                        {
                            //for (int Index = 0; Index < objrgvDefaultRoleTasks.Length; Index++)
                            for (int Index = 0; Index < RolePermissionValues.Length; Index++)
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

        protected void cmbEmployeeName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DataTable dtPermissions = new DataTable();
            //Bal BusinessAcessLayer = new Bal();
            //dtPermissions = BusinessAcessLayer.LoadUserPermissions(Convert.ToInt32(cmbEmployeeName.SelectedValue));
            //Session["DefaultTaskBasedONRole"] = dtPermissions;

            //rgvDefaultRoleTasks.DataSource = dtPermissions;
            //rgvDefaultRoleTasks.DataBind();
        }

        protected void cmbSubRole_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLoadUsers = new DataTable();
            dtLoadUsers = BusinessAccessLayer.LoadUsersBasedOnSubRole(Convert.ToInt32(cmbSubRole.SelectedValue));
            cmbUser.Items.Clear();
            if (dtLoadUsers != null && dtLoadUsers.Rows.Count > 0)
            {
                DisplayName = dtLoadUsers.Rows[0]["name"].ToString();
                EmailId = dtLoadUsers.Rows[0]["email"].ToString();
                MobileNo = dtLoadUsers.Rows[0]["contact"].ToString();
                cmbUser.DataSource = dtLoadUsers;
                cmbUser.DataTextField = "name";
                cmbUser.DataValueField = "user_id";
                cmbUser.DataBind();
            }
            cmbUser.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-Select-"));

        }

        protected void cmbUser_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Bal BusinessAccessLayer = new Bal();
            DataTable dtLoginUserDetails = new DataTable();
            dtLoginUserDetails = BusinessAccessLayer.LoadLoginUserDetails(Convert.ToInt32(cmbCorporateName.SelectedValue), Convert.ToInt32(cmbUser.SelectedValue));

            if (dtLoginUserDetails != null && dtLoginUserDetails.Rows.Count > 0)
            {
                LoginRefId = dtLoginUserDetails.Rows[0]["LoginRefId"].ToString();
                cmbCorporateName.SelectedValue = dtLoginUserDetails.Rows[0]["CorporateId"].ToString();
                txtUserName.Text = dtLoginUserDetails.Rows[0]["UserName"].ToString();
                txtPassword.Text = dtLoginUserDetails.Rows[0]["Password"].ToString();
                txtDisplayName.Text = dtLoginUserDetails.Rows[0]["DisplayName"].ToString();
                RolePermission = dtLoginUserDetails.Rows[0]["RolePermissions"].ToString();
                rbIsActive.SelectedValue = dtLoginUserDetails.Rows[0]["IsActive"].ToString();

                Session["UserPermission"] = RolePermission;
                LoadPermissionDetails();

                btnSave.Text = "Update";

            }
            else
            {
                txtDisplayName.Text = DisplayName;
            }

        }

        protected void lnkCheckUserName_Click(object sender, EventArgs e)
        {
            if (CheckUserNameAvailabilty())
            {
                txtUserName.Text = "";
                showPopup("Warning", "User Name Already Exists");
                return;
            }
            else
            {
                showPopup("Sucess", "User Name Available");
            }
        }

        public bool CheckUserNameAvailabilty()
        {
            bool UserNameExists = false;
            Bal BusinessAccessLayer = new Bal();
            UserNameExists = BusinessAccessLayer.CheckUserNameAvailabilty(txtUserName.Text.Trim());
            return UserNameExists;

        }
    }
}