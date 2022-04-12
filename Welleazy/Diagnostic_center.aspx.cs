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

namespace Welleazy
{
    public partial class Diagnostic_center : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"]!=null)
                {
                    this.Provider_Data();
                    
                }
            }
        }

        public void Provider_Data()
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select di.imagename, dc.dc_id, dc.center_status, dc.deactivation_reason, dc.deactivation_date, dc.center_name, dc.type_of_provider, dc.address, tc.city_name, ts.state_name, dc.area, dc.emailid, dc.landline_no, dc.name_of_holder, dc.center_categorization, dc.center_grading, dc.center_prioritization, ap.total_call from Tbl_DC_Information as dc left join tbl_dcimage as di on di.dc_id=dc.dc_id left join tbl_appointment as ap on dc.dc_id=ap.dc_id left join tbl_cities as tc on dc.city=tc.city_id left join tbl_states as ts on dc.state=ts.state_id"))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                gvDCDetails.DataSource = dt;
            //                gvDCDetails.DataBind();

            //            }
            //        }
            //    }
            //}
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("Exec proc_FetchAllSerivceProvider", con);
            
            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }

        public void ProviderData_CenterName()
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select di.imagename, dc.dc_id, dc.center_status, dc.deactivation_reason, dc.deactivation_date, dc.center_name, dc.type_of_provider, dc.address, tc.city_name, ts.state_name, dc.area, dc.emailid, dc.landline_no, dc.name_of_holder, dc.center_categorization, dc.center_grading, dc.center_prioritization, ap.total_call from Tbl_DC_Information as dc left join tbl_dcimage as di on di.dc_id=dc.dc_id left join tbl_appointment as ap on dc.dc_id=ap.dc_id left join tbl_cities as tc on dc.city=tc.city_id left join tbl_states as ts on dc.state=ts.state_id where dc.center_name like '%' + '" + txt_Centername.Text + "' + '%'"))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                gvDCDetails.DataSource = dt;
            //                gvDCDetails.DataBind();

            //            }
            //        }
            //    }
            //}
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllSerivceProvider", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_CENTER");

            SqlParameter paramCenterName = new SqlParameter("@centername",txt_Centername.Text.Trim());
            SqlParameter paramArea = new SqlParameter("@area", txt_Area.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@city", txt_City.Text.Trim());
            SqlParameter paramState = new SqlParameter("@state", txt_State.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@status", DDL_Status.SelectedItem.Text.Trim());
            
            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramArea);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);
            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);

            

            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }
        public void ProviderData_Area()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllSerivceProvider", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_AREA");

            SqlParameter paramCenterName = new SqlParameter("@centername", txt_Centername.Text.Trim());
            SqlParameter paramArea = new SqlParameter("@area", txt_Area.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@city", txt_City.Text.Trim());
            SqlParameter paramState = new SqlParameter("@state", txt_State.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramArea);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);
            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }
        public void ProviderData_Status()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllSerivceProvider", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_STATUS");

            SqlParameter paramCenterName = new SqlParameter("@centername", txt_Centername.Text.Trim());
            SqlParameter paramArea = new SqlParameter("@area", txt_Area.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@city", txt_City.Text.Trim());
            SqlParameter paramState = new SqlParameter("@state", txt_State.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramArea);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);
            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }
        public void ProviderData_City()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllSerivceProvider", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_CITY");

            SqlParameter paramCenterName = new SqlParameter("@centername", txt_Centername.Text.Trim());
            SqlParameter paramArea = new SqlParameter("@area", txt_Area.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@city", txt_City.Text.Trim());
            SqlParameter paramState = new SqlParameter("@state", txt_State.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramArea);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);
            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }
        public void ProviderData_State()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchServiceProviderList = new SqlCommand("proc_SearchAllSerivceProvider", con);
            cmdFetchServiceProviderList.CommandType = CommandType.StoredProcedure;
            cmdFetchServiceProviderList.Parameters.AddWithValue("@Action", "FETCH_STATE");

            SqlParameter paramCenterName = new SqlParameter("@centername", txt_Centername.Text.Trim());
            SqlParameter paramArea = new SqlParameter("@area", txt_Area.Text.Trim());
            SqlParameter paramCity = new SqlParameter("@city", txt_City.Text.Trim());
            SqlParameter paramState = new SqlParameter("@state", txt_State.Text.Trim());
            SqlParameter paramStatus = new SqlParameter("@status", DDL_Status.SelectedItem.Text.Trim());

            cmdFetchServiceProviderList.Parameters.Add(paramCenterName);
            cmdFetchServiceProviderList.Parameters.Add(paramArea);
            cmdFetchServiceProviderList.Parameters.Add(paramCity);
            cmdFetchServiceProviderList.Parameters.Add(paramState);
            cmdFetchServiceProviderList.Parameters.Add(paramStatus);



            SqlDataAdapter daFetchServiceProviderDetails = new SqlDataAdapter(cmdFetchServiceProviderList);
            DataTable dtFetchServiveProviderDetails = new DataTable();

            daFetchServiceProviderDetails.Fill(dtFetchServiveProviderDetails);

            if (dtFetchServiveProviderDetails != null && dtFetchServiveProviderDetails.Rows.Count > 0)
            {
                gvDCDetails.DataSource = dtFetchServiveProviderDetails;
                gvDCDetails.DataBind();
            }
            else
            {
                gvDCDetails.DataSource = null;
                gvDCDetails.DataBind();
            }
        }

        protected void gvDCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDCDetails.PageIndex = e.NewPageIndex;
            gvDCDetails.DataBind();
        }
        protected void gvDCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UserName")
            {
                int DCId = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvDCDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                Variables.DcId = DCId;
                Response.Redirect("~/diagnostic_center/AddEditDC.aspx");
            }

            if (e.CommandName == "ApprovalProcess")
            {
                int DCId = 0;
                rcbServiceProviderStatus.SelectedValue = "Select Status";
                lblStatusText.Text = "";
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvDCDetails.Rows[rowIndex];

                DCId = Convert.ToInt32((row.FindControl("lblDCID") as Label).Text);

                Variables.DcId = DCId;

                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                SqlCommand cmdFetchProviderDetails = new SqlCommand("Exec proc_FetchProviderDetailsById @DCId", con);
                SqlParameter paramDCId = new SqlParameter("@DCId", Variables.DcId);

                cmdFetchProviderDetails.Parameters.Add(paramDCId);

                SqlDataAdapter daProviderData = new SqlDataAdapter(cmdFetchProviderDetails);
                DataTable dtProviderDetailds = new DataTable();
                daProviderData.Fill(dtProviderDetailds);

                if (dtProviderDetailds != null && dtProviderDetailds.Rows.Count > 0)
                {
                    TextDCID.Text = dtProviderDetailds.Rows[0]["dc_id"].ToString();
                    TextSPID.Text = dtProviderDetailds.Rows[0]["sptoken_id"].ToString();
                    TextSPType.Text = dtProviderDetailds.Rows[0]["ProviderType"].ToString();
                    TextSPName.Text = dtProviderDetailds.Rows[0]["center_name"].ToString();
                    TextMobileNo.Text = dtProviderDetailds.Rows[0]["mobile_no"].ToString();
                    TextEmail.Text = dtProviderDetailds.Rows[0]["emailid"].ToString();
                    rcbServiceProviderStatus.SelectedValue = dtProviderDetailds.Rows[0]["center_status"].ToString();
                }

                bool showModal = true;

                if (showModal)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);

            }


        }

        protected void gvDCDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            txt_Centername.Text = "";
            txt_Area.Text = "";
            DDL_Status.SelectedItem.Text="--Select Status--";
            Provider_Data();           
        }

        protected void txt_Centername_TextChanged(object sender, EventArgs e)
        {
            txt_Area.Text = "";
            txt_City.Text = "";
            txt_State.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ProviderData_CenterName();
        }

        protected void txt_Area_TextChanged(object sender, EventArgs e)
        {
            txt_Centername.Text = "";
            txt_City.Text = "";
            txt_State.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ProviderData_Area();
        }

        protected void txt_City_TextChanged(object sender, EventArgs e)
        {
            txt_Area.Text = "";
            txt_Centername.Text = "";
            txt_State.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ProviderData_City();
        }

        protected void txt_State_TextChanged(object sender, EventArgs e)
        {
            txt_Area.Text = "";
            txt_City.Text = "";
            txt_Centername.Text = "";
            DDL_Status.SelectedItem.Text = "--Select Status--";
            ProviderData_State();
        }

        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Area.Text = "";
            txt_City.Text = "";
            txt_State.Text = "";
            txt_Centername.Text = "";
            ProviderData_Status();
        }

        protected void Linkspl6_Click(object sender, EventArgs e)
        {
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblStatusText.Text = "";
            Bal BusinessAccessLayer = new Bal();

            Variables.DcId = Convert.ToInt32(TextDCID.Text);
            BusinessAccessLayer.InsertUpdateDCApprovedByPopup(Variables.DcId, rcbServiceProviderStatus.SelectedValue);
            
            lblStatusText.Text = "Status Updated Successfully...!";
            Variables.DcId = 0;
            //rcbServiceProviderStatus.SelectedValue = "Select Status";
            bool showModal = true;

            if (showModal)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal1').modal('show');", true);
            //showPopup("Warning", "Status Updated Successfully");
            Provider_Data();
        }
    }
}