using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;

namespace Welleazy.Test
{
    public partial class Individual_Test : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestDetails();
                
            }
        }

        public void LoadTestDetails()
        {
            DataTable dtLoadTestDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadTestDetailsList = BusinessAccessLayer.LoadTestDetailsList();

            if (dtLoadTestDetailsList != null && dtLoadTestDetailsList.Rows.Count > 0)
            {
                rgTestDetails.DataSource = dtLoadTestDetailsList;
                rgTestDetails.DataBind();
            }
            else
            {
                rgTestDetails.DataSource = new object[] { };
                rgTestDetails.DataBind();
            }
        }

        public void LoadSearchTestDetails()
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";
            //string Status = "";

            MainQuery = "Select TD.TestId, TD.CorporateId, MCD.CorporateName, TD.Status, TD.TestType, TD.VisitType, TD.SKUCode, TD.TestName, " +
                        "TD.TestCode, TD.NormalPrice, TD.HNIPrice, TD.Remark, TD.TestDescription, TD.CreatedOn, TD.CreatedBy " +
                        "from dbo.Master_TestDetails as TD join dbo.Master_CorporateDetails as MCD on TD.CorporateId = MCD.CorporateId";

            ConditionQuery = " order by TD.TestId desc";



            if (DDL_Status.SelectedValue != "0")
            {
                if (Query.Equals(""))
                {
                    Query = " where TD.Status = '" + DDL_Status.SelectedValue + "'";
                }
                else
                {
                    Query += " And TD.Status = '" + DDL_Status.SelectedValue + "'";
                }
            }


            if (txt_ClientName.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where MCD.CorporateName like '%" + txt_ClientName.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And MCD.CorporateName like '%" + txt_ClientName.Text.Trim() + "%'";
                }
            }

            if (txt_SKUCode.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where TD.SKUCode like '%" + txt_SKUCode.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And TD.SKUCode like '%" + txt_SKUCode.Text.Trim() + "%'";
                }
            }

            if (txt_TestName.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where TD.TestName like '%" + txt_TestName.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And TD.TestName like '%" + txt_TestName.Text.Trim() + "%'";
                }
            }

            if (txt_TestCode.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where TD.TestCode like '%" + txt_TestCode.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And TD.TestCode like '%" + txt_TestCode.Text.Trim() + "%'";
                }
            }

            Bal BusinessAccessLayer = new Bal();
            DataTable dtTestDetails = new DataTable();

            dtTestDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtTestDetails != null && dtTestDetails.Rows.Count > 0)
            {
                rgTestDetails.DataSource = dtTestDetails;
                rgTestDetails.DataBind();
            }
            else
            {
                rgTestDetails.DataSource = new object[] { };
                rgTestDetails.DataBind();
            }

        }

        //public void LoadTestDetails_SKUCode()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();

        //    SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_SearchTestDetailsList", con);
        //    cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
        //    cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "FETCH_SKUCODE");

        //    SqlParameter paramTestCode = new SqlParameter("@TestCode", txt_TestCode.Text.Trim());
        //    SqlParameter paramClientName = new SqlParameter("@ClientName", txt_ClientName.Text.Trim());
        //    SqlParameter paramTestStatus = new SqlParameter("@TestStatus", DDL_Status.SelectedItem.Text.Trim());
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_TestName.Text.Trim());
        //    SqlParameter paramSKUCode = new SqlParameter("@SKUCode", txt_SKUCode.Text.Trim());

        //    cmdFetchTestDetailsList.Parameters.Add(paramTestCode);
        //    cmdFetchTestDetailsList.Parameters.Add(paramClientName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestStatus);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramSKUCode);



        //    SqlDataAdapter daFetchTestDetailsList = new SqlDataAdapter(cmdFetchTestDetailsList);
        //    DataTable dtFetchTestDetailsList = new DataTable();

        //    daFetchTestDetailsList.Fill(dtFetchTestDetailsList);

        //    if (dtFetchTestDetailsList != null && dtFetchTestDetailsList.Rows.Count > 0)
        //    {
        //        rgTestDetails.DataSource = dtFetchTestDetailsList;
        //        rgTestDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgTestDetails.DataSource = new object[] { };
        //        rgTestDetails.DataBind();
        //    }
        //}

        //public void LoadTestDetails_TestName()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();

        //    SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_SearchTestDetailsList", con);
        //    cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
        //    cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "FETCH_TESTNAME");

        //    SqlParameter paramTestCode = new SqlParameter("@TestCode", txt_TestCode.Text.Trim());
        //    SqlParameter paramClientName = new SqlParameter("@ClientName", txt_ClientName.Text.Trim());
        //    SqlParameter paramTestStatus = new SqlParameter("@TestStatus", DDL_Status.SelectedItem.Text.Trim());
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_TestName.Text.Trim());
        //    SqlParameter paramSKUCode = new SqlParameter("@SKUCode", txt_SKUCode.Text.Trim());

        //    cmdFetchTestDetailsList.Parameters.Add(paramTestCode);
        //    cmdFetchTestDetailsList.Parameters.Add(paramClientName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestStatus);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramSKUCode);



        //    SqlDataAdapter daFetchTestDetailsList = new SqlDataAdapter(cmdFetchTestDetailsList);
        //    DataTable dtFetchTestDetailsList = new DataTable();

        //    daFetchTestDetailsList.Fill(dtFetchTestDetailsList);

        //    if (dtFetchTestDetailsList != null && dtFetchTestDetailsList.Rows.Count > 0)
        //    {
        //        rgTestDetails.DataSource = dtFetchTestDetailsList;
        //        rgTestDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgTestDetails.DataSource = new object[] { };
        //        rgTestDetails.DataBind();
        //    }
        //}

        //public void LoadTestDetails_TestCode()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();

        //    SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_SearchTestDetailsList", con);
        //    cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
        //    cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "FETCH_TESTCODE");

        //    SqlParameter paramTestCode = new SqlParameter("@TestCode", txt_TestCode.Text.Trim());
        //    SqlParameter paramClientName = new SqlParameter("@ClientName", txt_ClientName.Text.Trim());
        //    SqlParameter paramTestStatus = new SqlParameter("@TestStatus", DDL_Status.SelectedItem.Text.Trim());
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_TestName.Text.Trim());
        //    SqlParameter paramSKUCode = new SqlParameter("@SKUCode", txt_SKUCode.Text.Trim());

        //    cmdFetchTestDetailsList.Parameters.Add(paramTestCode);
        //    cmdFetchTestDetailsList.Parameters.Add(paramClientName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestStatus);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramSKUCode);



        //    SqlDataAdapter daFetchTestDetailsList = new SqlDataAdapter(cmdFetchTestDetailsList);
        //    DataTable dtFetchTestDetailsList = new DataTable();

        //    daFetchTestDetailsList.Fill(dtFetchTestDetailsList);

        //    if (dtFetchTestDetailsList != null && dtFetchTestDetailsList.Rows.Count > 0)
        //    {
        //        rgTestDetails.DataSource = dtFetchTestDetailsList;
        //        rgTestDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgTestDetails.DataSource = new object[] { };
        //        rgTestDetails.DataBind();
        //    }
        //}

        //public void LoadTestDetails_ClientName()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();

        //    SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_SearchTestDetailsList", con);
        //    cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
        //    cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "FETCH_CLIENTNAME");

        //    SqlParameter paramTestCode = new SqlParameter("@TestCode", txt_TestCode.Text.Trim());
        //    SqlParameter paramClientName = new SqlParameter("@ClientName", txt_ClientName.Text.Trim());
        //    SqlParameter paramTestStatus = new SqlParameter("@TestStatus", DDL_Status.SelectedItem.Text.Trim());
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_TestName.Text.Trim());
        //    SqlParameter paramSKUCode = new SqlParameter("@SKUCode", txt_SKUCode.Text.Trim());

        //    cmdFetchTestDetailsList.Parameters.Add(paramTestCode);
        //    cmdFetchTestDetailsList.Parameters.Add(paramClientName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestStatus);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramSKUCode);



        //    SqlDataAdapter daFetchTestDetailsList = new SqlDataAdapter(cmdFetchTestDetailsList);
        //    DataTable dtFetchTestDetailsList = new DataTable();

        //    daFetchTestDetailsList.Fill(dtFetchTestDetailsList);

        //    if (dtFetchTestDetailsList != null && dtFetchTestDetailsList.Rows.Count > 0)
        //    {
        //        rgTestDetails.DataSource = dtFetchTestDetailsList;
        //        rgTestDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgTestDetails.DataSource = new object[] { };
        //        rgTestDetails.DataBind();
        //    }
        //}

        //public void LoadTestDetails_TestStatus()
        //{
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();

        //    SqlCommand cmdFetchTestDetailsList = new SqlCommand("proc_SearchTestDetailsList", con);
        //    cmdFetchTestDetailsList.CommandType = CommandType.StoredProcedure;
        //    cmdFetchTestDetailsList.Parameters.AddWithValue("@Action", "FETCH_TESTSTATUS");

        //    SqlParameter paramTestCode = new SqlParameter("@TestCode", txt_TestCode.Text.Trim());
        //    SqlParameter paramClientName = new SqlParameter("@ClientName", txt_ClientName.Text.Trim());
        //    SqlParameter paramTestStatus = new SqlParameter("@TestStatus", DDL_Status.SelectedItem.Text.Trim());
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_TestName.Text.Trim());
        //    SqlParameter paramSKUCode = new SqlParameter("@SKUCode", txt_SKUCode.Text.Trim());

        //    cmdFetchTestDetailsList.Parameters.Add(paramTestCode);
        //    cmdFetchTestDetailsList.Parameters.Add(paramClientName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestStatus);
        //    cmdFetchTestDetailsList.Parameters.Add(paramTestName);
        //    cmdFetchTestDetailsList.Parameters.Add(paramSKUCode);



        //    SqlDataAdapter daFetchTestDetailsList = new SqlDataAdapter(cmdFetchTestDetailsList);
        //    DataTable dtFetchTestDetailsList = new DataTable();

        //    daFetchTestDetailsList.Fill(dtFetchTestDetailsList);

        //    if (dtFetchTestDetailsList != null && dtFetchTestDetailsList.Rows.Count > 0)
        //    {
        //        rgTestDetails.DataSource = dtFetchTestDetailsList;
        //        rgTestDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgTestDetails.DataSource = new object[] { };
        //        rgTestDetails.DataBind();
        //    }
        //}
        protected void rgTestDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadTestDetails();
        }

        protected void rgTestDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblTestId = (Label)rgTestDetails.Items[intIndex % 10].FindControl("lblTestId"); // % 15 for page indexing
                    Variables.TestId = Convert.ToInt32(lblTestId.Text.Trim());

                    Response.Redirect("~/Test/AddTest.aspx");
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }

            if (e.CommandName.Equals("EditRowRemark"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblTestId = (Label)rgTestDetails.Items[intIndex % 10].FindControl("lblTestId"); // % 15 for page indexing
                    Variables.TestId = Convert.ToInt32(lblTestId.Text.Trim());

                    LoadTestDetailsById();

                    LoadTestRemarkDetails();
                    

                    bool showModal = true;

                    if (showModal)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }

        protected void txt_SKUCode_TextChanged(object sender, EventArgs e)
        {
            //txt_TestCode.Text = "";
            //txt_TestName.Text = "";
            //txt_ClientName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchTestDetails();
        }
        protected void txt_TestName_TextChanged(object sender, EventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_TestCode.Text = "";
            //txt_ClientName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchTestDetails();
        }

        protected void txt_TestCode_TextChanged(object sender, EventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_TestName.Text = "";
            //txt_ClientName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchTestDetails();
        }

        protected void txt_ClientName_TextChanged(object sender, EventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_TestName.Text = "";
            //txt_TestCode.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchTestDetails();
        }

        protected void DDL_Status_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_TestName.Text = "";
            //txt_TestCode.Text = "";
            //txt_ClientName.Text = "";
            LoadSearchTestDetails();
        }

        public void LoadTestRemarkDetails()
        {
            DataTable dtLoadTestRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadTestRemarkDetailsList = BusinessAccessLayer.LoadTestRemarkDetailsList(Variables.TestId);

            if (dtLoadTestRemarkDetailsList != null && dtLoadTestRemarkDetailsList.Rows.Count > 0)
            {
                rgvTestRemarkDetails.DataSource = dtLoadTestRemarkDetailsList;
                rgvTestRemarkDetails.DataBind();
            }
            else
            {
                rgvTestRemarkDetails.DataSource = new object[] { }; ;
                rgvTestRemarkDetails.DataBind();
            }
        }

        public void LoadTestDetailsById()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchTestDetails = new SqlCommand("Exec proc_FetchTestDetailsById @TestId", con);
            SqlParameter paramTestId = new SqlParameter("@TestId", Variables.TestId);

            cmdFetchTestDetails.Parameters.Add(paramTestId);

            SqlDataAdapter daTestData = new SqlDataAdapter(cmdFetchTestDetails);
            DataTable dtTestDetails = new DataTable();
            daTestData.Fill(dtTestDetails);

            if (dtTestDetails != null && dtTestDetails.Rows.Count > 0)
            {
                TextTestName.Text = dtTestDetails.Rows[0]["TestName"].ToString();
                
            }
        }

        protected void rgvTestRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvTestRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //bool showModal = true;
            //if (showModal)
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

            DataTable dtLoadTestRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadTestRemarkDetailsList = BusinessAccessLayer.LoadTestRemarkDetailsList(Variables.TestId);

            if (dtLoadTestRemarkDetailsList != null && dtLoadTestRemarkDetailsList.Rows.Count > 0)
            {
                rgvTestRemarkDetails.DataSource = dtLoadTestRemarkDetailsList;
                //rgvTestRemarkDetails.DataBind();
            }
            else
            {
                rgvTestRemarkDetails.DataSource = new object[] { }; ;
                //rgvTestRemarkDetails.DataBind();
            }
        }

        protected void rgvTestRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void Linkspl1_Click(object sender, EventArgs e)
        {
            Variables.TestId = 0;
            Response.Redirect("~/Test/AddTest.aspx");
        }
    }
}