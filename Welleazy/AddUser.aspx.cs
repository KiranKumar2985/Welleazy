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
    public partial class add_user : System.Web.UI.Page
    {
        DateTime? nul = null;
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {

                    string id = "";

                    if (Request.QueryString.AllKeys.Contains("UserId"))
                    {
                        id = Request.QueryString["UserId"];
                    }


                    if (id.Equals(""))
                    {
                        Variables.user_id = 0;
                    }


                    RoleList();
                    StateList();
                    //int userid = Variables.user_id;
                    if (Variables.user_id != 0)
                    {
                        
                        LoadUserDetailsById();
                        btnSave.Text="Update";
                        //btnUpdate.Visible = true;
                    }
                    else
                    {
                        //RoleList();
                        //StateList();
                        btnSave.Text = "Save";
                        //btnUpdate.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            //SqlCommand cmdcount = new SqlCommand("select count(*) from tbl_user where name='" + txt_Name.Text + "' AND email='" + txt_Email.Text + "'", con);
            //cmdcount.Connection = con;
            //int count = Convert.ToInt32(cmdcount.ExecuteScalar());
            //if (count > 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('User Already Exist..!');</script>");
            //}
            //else
            {
                try
                {
                    string emailid = txt_Email.Text.Trim();

                    //con.Open();
                    DataTable result = new DataTable();
                    SqlCommand cmdEmail = new SqlCommand("select substring('" + emailid + "',charindex('.','" + emailid + "',charindex('@','" + emailid + "'))+1,len('" + emailid + "')) as Ext", con);
                    var adapter = new SqlDataAdapter(cmdEmail);



                    adapter.Fill(result);

                    string StateId = "";

                    for (int i = 0; i < DDL_State.CheckedItems.Count; i++)
                    {
                        if (StateId == "")
                        {
                            StateId = DDL_State.CheckedItems[i].Value.Trim();
                        }
                        else
                        {
                            StateId += "," + DDL_State.CheckedItems[i].Value.Trim();
                        }
                    }

                    string WelnextBranchId = "";

                    for (int i = 0; i < DDL_WelnextBranch.CheckedItems.Count; i++)
                    {
                        if (WelnextBranchId == "")
                        {
                            WelnextBranchId = DDL_WelnextBranch.CheckedItems[i].Value.Trim();
                        }
                        else
                        {
                            WelnextBranchId += "," + DDL_WelnextBranch.CheckedItems[i].Value.Trim();
                        }
                    }

                    Bal BusinessAccessLayer = new Bal();
                    Int32 IsDataExists = 0;

                    if (result.Rows[0]["Ext"].Equals("com") || result.Rows[0]["Ext"].Equals("co.in") || result.Rows[0]["Ext"].Equals("net") || result.Rows[0]["Ext"].Equals("edu") || result.Rows[0]["Ext"].Equals("org"))
                    {

                        if (btnSave.Text.Trim().Equals("Save"))
                        {
                            lblEmailError.Text = "";
                            
                            IsDataExists = BusinessAccessLayer.InsertUpdateUserDetails(0, Convert.ToInt32(DDL_Role.SelectedValue), Convert.ToInt32(DDL_SubRole.SelectedValue), Convert.ToInt32(DDL_ReportingPerson.SelectedValue), txt_EmployeeId.Text.Trim(), txt_Name.Text.Trim(), txt_Contact.Text.Trim(), txt_Email.Text.Trim(), txt_Department.Text.Trim(), txt_WorkLocation.Text.Trim(), StateId, WelnextBranchId, dtpJoiningDate.DateInput.SelectedDate.Equals(null) ? nul : dtpJoiningDate.DateInput.SelectedDate.Value, dtpRelievingDate.DateInput.SelectedDate.Equals(null) ? nul : dtpRelievingDate.DateInput.SelectedDate.Value, Convert.ToInt32(DDL_Status.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));

                            if (IsDataExists == 1)
                            {
                                showPopup("Warning", "User Already Exists");
                            }
                            else
                            {
                                showPopup("Warning", "Data Saved Successfully");
                            }
                        }
                        else
                        {
                            IsDataExists = BusinessAccessLayer.InsertUpdateUserDetails(Variables.user_id, Convert.ToInt32(DDL_Role.SelectedValue), Convert.ToInt32(DDL_SubRole.SelectedValue), Convert.ToInt32(DDL_ReportingPerson.SelectedValue), txt_EmployeeId.Text.Trim(), txt_Name.Text.Trim(), txt_Contact.Text.Trim(), txt_Email.Text.Trim(), txt_Department.Text.Trim(), txt_WorkLocation.Text.Trim(), StateId, WelnextBranchId, dtpJoiningDate.DateInput.SelectedDate.Equals(null) ? nul : dtpJoiningDate.DateInput.SelectedDate.Value, dtpRelievingDate.DateInput.SelectedDate.Equals(null) ? nul : dtpRelievingDate.DateInput.SelectedDate.Value, Convert.ToInt32(DDL_Status.SelectedValue), Convert.ToInt32(Session["LoginRefId"].ToString()));

                            if (IsDataExists == 1)
                            {
                                showPopup("Warning", "User Already Exists");
                            }
                            else
                            {
                                showPopup("Warning", "Data Updated Successfully");
                            }
                        }

                        ClearFields();

                        //SqlCommand cmd = new SqlCommand("user_CRUD", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Action", "Insert");
                        //cmd.Parameters.AddWithValue("@user_id", Label1.Text);
                        //cmd.Parameters.AddWithValue("@parent_id", "");
                        //cmd.Parameters.AddWithValue("@user_type_id", "");
                        //cmd.Parameters.AddWithValue("@user_type", "");
                        //cmd.Parameters.AddWithValue("@gwlempid", "");
                        //cmd.Parameters.AddWithValue("@dc_parent_id", "");
                        //cmd.Parameters.AddWithValue("@address", "");
                        //cmd.Parameters.AddWithValue("@branch", DDL_WelnextBranch.SelectedValue);
                        ////cmd.Parameters.AddWithValue("@welnext_branch_id", DDL_BranchId.SelectedValue);
                        //cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                        //cmd.Parameters.AddWithValue("@email", txt_Email.Text);
                        //cmd.Parameters.AddWithValue("@contact", txt_Contact.Text);
                        //cmd.Parameters.AddWithValue("@ic_id", "");
                        //cmd.Parameters.AddWithValue("@state_id", DDL_State.SelectedValue);
                        //cmd.Parameters.AddWithValue("@business_channel", "");
                        //cmd.Parameters.AddWithValue("@role_id", DDL_Role.SelectedValue);
                        //cmd.Parameters.AddWithValue("@subrole_id", DDL_SubRole.SelectedValue);
                        ////cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                        //cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").ToString());
                        //cmd.Parameters.AddWithValue("@created_by", Session["LoginRefId"].ToString());
                        //cmd.Parameters.AddWithValue("@modified_at", "");
                        //cmd.Parameters.AddWithValue("@modified_by", "");
                        //cmd.Parameters.AddWithValue("@status", DDL_Status.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@logged_in", "");
                        //cmd.Parameters.AddWithValue("@last_loggedin", "");
                        //cmd.Parameters.AddWithValue("@incorrect_try", "");
                        //cmd.Parameters.AddWithValue("@fpwd_key", "");
                        //cmd.Parameters.AddWithValue("@fpwd_key_datetime", "");
                        //cmd.Parameters.AddWithValue("@password_set_date", DateTime.Now.ToString("yyyy-MM-dd").ToString());
                        //cmd.Parameters.AddWithValue("@ip_address", "");
                        //cmd.Parameters.AddWithValue("@is_loggedin", "");
                        //cmd.Parameters.AddWithValue("@login_token", "");
                        //cmd.Parameters.AddWithValue("@mfa_status", DDL_MFA.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@mfa_otp", "");
                        //cmd.Parameters.AddWithValue("@mfa_validity", "");
                        //cmd.Parameters.AddWithValue("@agent_campaign_id", txt_AgentComp.Text);
                        //cmd.Parameters.AddWithValue("@inbound_call", DDL_InboundCall.Text);
                        //cmd.Parameters.AddWithValue("@outbound_call", DDL_OutboundCall.Text);
                        //cmd.Parameters.AddWithValue("@mer_type_id", DDL_MerType.Text);
                        //cmd.Parameters.AddWithValue("@designation", txt_Designation.Text);
                        //cmd.Parameters.AddWithValue("@department", txt_Department.Text);
                        //cmd.Parameters.AddWithValue("@function_area", txt_Function.Text);
                        //cmd.Parameters.AddWithValue("@worklocation", txt_WorkLocation.Text);
                        //cmd.Parameters.AddWithValue("@joining_date_time", txt_JoiningDate.Text);
                        //cmd.Parameters.AddWithValue("@relieving_date_time", txt_RelievingDate.Text);
                        //cmd.Parameters.AddWithValue("@UserRolePermissions", "");
                        //cmd.Parameters.AddWithValue("@no_of_attempt", "0");
                        ////con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                    }
                    else
                    {
                        lblEmailError.Text = "Invalid Email Id";
                        showPopup("Warning", "Invalid Email Address");
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            con.Close();
        }

        public void ClearFields()
        {
            DDL_Role.SelectedValue = "0";
            DDL_SubRole.SelectedValue = "0";
            DDL_ReportingPerson.SelectedValue = "0";
            DDL_Status.SelectedValue = "0";

            DDL_State.ClearSelection();
            DDL_WelnextBranch.ClearSelection();

            txt_EmployeeId.Text = "";
            txt_Contact.Text = "";
            txt_Email.Text = "";
            txt_Name.Text = "";
            txt_Department.Text = "";
            txt_WorkLocation.Text = "";
            dtpJoiningDate.DateInput.Text = "";
            dtpRelievingDate.DateInput.Text = "";

        }

        public void LoadUserDetailsById()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdUserDetails = new SqlCommand("Exec proc_LoadUserListDetailsById @UserId", con);
            SqlParameter paramUserId = new SqlParameter("@UserId", Variables.user_id);

            cmdUserDetails.Parameters.Add(paramUserId);

            SqlDataAdapter daUserDetails = new SqlDataAdapter(cmdUserDetails);
            DataTable dtUserDetails = new DataTable();
            daUserDetails.Fill(dtUserDetails);

            if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
            {
                DDL_Role.SelectedValue = dtUserDetails.Rows[0]["RoleId"].ToString();
                DDL_Role_SelectedIndexChanged(null, null);
                DDL_SubRole.SelectedValue = dtUserDetails.Rows[0]["SubRoleId"].ToString();
                txt_EmployeeId.Text = dtUserDetails.Rows[0]["EmployeeId"].ToString();
                txt_Name.Text = dtUserDetails.Rows[0]["Name"].ToString();
                txt_Contact.Text = dtUserDetails.Rows[0]["ContactNo"].ToString();
                
                txt_Email.Text = dtUserDetails.Rows[0]["EmailId"].ToString();
                DDL_Status.SelectedValue = dtUserDetails.Rows[0]["StatusId"].ToString();
                //txt_Designation.Text = dtUserDetails.Rows[0]["designation"].ToString();
                txt_Department.Text = dtUserDetails.Rows[0]["department"].ToString();
                //txt_Function.Text = dtUserDetails.Rows[0]["function_area"].ToString();
                txt_WorkLocation.Text = dtUserDetails.Rows[0]["worklocation"].ToString();
                //DDL_State.SelectedValue = dtUserDetails.Rows[0]["StateId"].ToString();
                string stateid = dtUserDetails.Rows[0]["StateId"].ToString();
                String[] stateidValue = stateid.Split(',');

                int lenght = stateidValue.Length;

                foreach (string s in stateidValue)
                {
                    foreach (RadComboBoxItem item in DDL_State.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }
                DDL_State_SelectedIndexChanged(null,null);
                string BranchId = dtUserDetails.Rows[0]["WelnextBranchId"].ToString();
                String[] BranchIdValue = BranchId.Split(',');

                //int lenght = stateidValue.Length;

                foreach (string s in BranchIdValue)
                {
                    foreach (RadComboBoxItem item in DDL_WelnextBranch.Items)
                    {
                        if (item.Value == s)
                        {
                            item.Checked = true;
                            //item.Selected = true;
                            break;
                        }
                    }
                }

                dtpJoiningDate.DbSelectedDate = dtUserDetails.Rows[0]["JoiningDate"].ToString();
                dtpRelievingDate.DbSelectedDate = dtUserDetails.Rows[0]["RelievingDate"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserList.aspx");
        }

        private void showPopup(string title, string body)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        public void RoleList()
        {
            DataTable dtLoadProfileTypes = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadProfileTypes = BusinessAccessLayer.LoadProfileTypes();

            if (dtLoadProfileTypes != null && dtLoadProfileTypes.Rows.Count > 0)
            {
                DDL_Role.DataSource = dtLoadProfileTypes;
                DDL_Role.DataTextField = "name";
                DDL_Role.DataValueField = "role_id";
                DDL_Role.DataBind();

            }
            else
            {
                DDL_Role.DataSource = null;
                DDL_Role.DataBind();
            }
        }

        public void StateList()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_FetchStateCity", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "StateList");

            SqlParameter paramState = new SqlParameter("@StateID", Label1.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@CityID", Label1.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);

            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                DDL_State.DataSource = dtFetchServiveProviderDetails;
                DDL_State.DataTextField = "state_name";
                DDL_State.DataValueField = "state_id";
                DDL_State.DataBind();
            }
        }

        //protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string Id = "";
        //    foreach (ListItem lst in ListBox1.Items)
        //    {
        //        if (lst.Selected == true)
        //        {
        //            if (Id.Equals(""))
        //            {
        //                Id = lst.Value;

        //            }
        //            else
        //            {
        //                Id += "," + lst.Value;
        //            }


        //        }

        //    }
        //    txt_State.Text = Id;
        //} 

  
        protected void DDL_State_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchWelnextBranch = new SqlCommand("proc_FetchWelnextBranch", con);
            cmdFetchWelnextBranch.CommandType = CommandType.StoredProcedure;
            cmdFetchWelnextBranch.Parameters.AddWithValue("@Action", "WelnextBranchList");
            string StateId = "";

            for (int i = 0; i < DDL_State.CheckedItems.Count; i++)
            {
                if (StateId == "")
                {
                    StateId = DDL_State.CheckedItems[i].Value.Trim();
                }
                else
                {
                    StateId += "," + DDL_State.CheckedItems[i].Value.Trim();
                }

            }
            cmdFetchWelnextBranch.Parameters.AddWithValue("@StateID", StateId);


            //SqlParameter paramCenterName = new SqlParameter("@StateID", StateId);
            ////SqlParameter paramArea = new SqlParameter("@welnext_branch", "");
            ////SqlParameter paramCity = new SqlParameter("@CityId", "");


            //cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            ////cmdFetchServiceProviderList.Parameters.Add(paramArea);
            ////cmdFetchServiceProviderList.Parameters.Add(paramCity);
           
            SqlDataAdapter daFetchWelnextBranch = new SqlDataAdapter(cmdFetchWelnextBranch);
            DataTable dtFetchWelnextBranch = new DataTable();

            daFetchWelnextBranch.Fill(dtFetchWelnextBranch);
            cmdFetchWelnextBranch.ExecuteReader();

            if (dtFetchWelnextBranch != null && dtFetchWelnextBranch.Rows.Count > 0)
            {
                DDL_WelnextBranch.DataSource = dtFetchWelnextBranch;
                DDL_WelnextBranch.DataTextField = "welnext_branch";
                DDL_WelnextBranch.DataValueField = "welnext_branch";
                DDL_WelnextBranch.DataBind();
            }
            else
            {
                DDL_WelnextBranch.DataSource = null;
                DDL_WelnextBranch.DataBind();
            }
           
            
        }

        protected void DDL_Role_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DDL_SubRole.DefaultItem.Text = "Select Sub Role";
            DataTable dtLoadUserRoles = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadUserRoles = BusinessAccessLayer.LoadUserRoles(Convert.ToInt32(DDL_Role.SelectedValue));

            if (dtLoadUserRoles != null && dtLoadUserRoles.Rows.Count > 0)
            {
                DDL_SubRole.DataSource = dtLoadUserRoles;
                DDL_SubRole.DataTextField = "subrole";
                DDL_SubRole.DataValueField = "subrole_id";
                DDL_SubRole.DataBind();
            }
            else
            {
                DDL_SubRole.DataSource = null;
                DDL_SubRole.DataBind();
            }
        }

       
   }
}