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
    public partial class Test_Package : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["WelleazyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestPackageDetails();

            }
        }

        public void LoadTestPackageDetails()
        {
            DataTable dtLoadTestPackageDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadTestPackageDetailsList = BusinessAccessLayer.LoadTestPackageDetailsList();

            if (dtLoadTestPackageDetailsList != null && dtLoadTestPackageDetailsList.Rows.Count > 0)
            {
                rgvTestPackageDetails.DataSource = dtLoadTestPackageDetailsList;
                rgvTestPackageDetails.DataBind();
            }
            else
            {
                rgvTestPackageDetails.DataSource = new object[] { };
                rgvTestPackageDetails.DataBind();
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
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_PackageName.Text.Trim());
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
        //        rgvTestPackageDetails.DataSource = dtFetchTestDetailsList;
        //        rgvTestPackageDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgvTestPackageDetails.DataSource = new object[] { };
        //        rgvTestPackageDetails.DataBind();
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
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_PackageName.Text.Trim());
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
        //        rgvTestPackageDetails.DataSource = dtFetchTestDetailsList;
        //        rgvTestPackageDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgvTestPackageDetails.DataSource = new object[] { };
        //        rgvTestPackageDetails.DataBind();
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
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_PackageName.Text.Trim());
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
        //        rgvTestPackageDetails.DataSource = dtFetchTestDetailsList;
        //        rgvTestPackageDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgvTestPackageDetails.DataSource = new object[] { };
        //        rgvTestPackageDetails.DataBind();
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
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_PackageName.Text.Trim());
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
        //        rgvTestPackageDetails.DataSource = dtFetchTestDetailsList;
        //        rgvTestPackageDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgvTestPackageDetails.DataSource = new object[] { };
        //        rgvTestPackageDetails.DataBind();
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
        //    SqlParameter paramTestName = new SqlParameter("@TestName", txt_PackageName.Text.Trim());
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
        //        rgvTestPackageDetails.DataSource = dtFetchTestDetailsList;
        //        rgvTestPackageDetails.DataBind();
        //    }
        //    else
        //    {
        //        rgvTestPackageDetails.DataSource = new object[] { };
        //        rgvTestPackageDetails.DataBind();
        //    }
        //}
        protected void rgvTestPackageDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadTestPackageDetails();
        }

        protected void rgvTestPackageDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditRow"))
            {
                try
                {
                    int intIndex = int.Parse(e.CommandArgument.ToString());
                    Label lblPackageId = (Label)rgvTestPackageDetails.Items[intIndex % 10].FindControl("lblPackageId"); // % 15 for page indexing
                    Variables.PackageId = Convert.ToInt32(lblPackageId.Text.Trim());

                    Response.Redirect("~/Test/AddPackage.aspx");
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
                    Label lblPackageId = (Label)rgvTestPackageDetails.Items[intIndex % 10].FindControl("lblPackageId"); // % 15 for page indexing
                    Variables.PackageId = Convert.ToInt32(lblPackageId.Text.Trim());

                    LoadPackageDetailsById();

                    LoadTestPackageRemarkDetails();


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
       
        public void LoadSearchPackage()
        {
            string MainQuery = "";
            string Query = "";
            string ConditionQuery = "";
            //string Status = "";

            MainQuery = "Select TPD.PackageId, TPD.CorporateId, MCD.CorporateName, TPD.ProductSKU, TPD.PackageName, TPD.TestIncluded, " +
                        " STUFF((select ',' + TestName  from Master_TestDetails MTD  where MTD.TestId in (select item from SplitString(TPD.TestIncluded, ',')) " +
                        " for XML PATH('')), 1, 1, '')TestName, " +
                        " TPD.NormalPackagePrice, TPD.HNIPackagePrice, TPD.Status, TPD.Remark, TPD.CreatedOn, TPD.CreatedBy from dbo.Master_TestPackageDetails as TPD " +
                        " left join dbo.Master_CorporateDetails as MCD on TPD.CorporateId = MCD.CorporateId";

                ConditionQuery = " order by TPD.PackageId desc";



            if (DDL_Status.SelectedValue != "0")
            {
                if (Query.Equals(""))
                {
                    Query = " where TPD.Status = '" + DDL_Status.SelectedValue + "'";
                }
                else
                {
                    Query += " And TPD.Status = '" + DDL_Status.SelectedValue + "'";
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
                    Query = " where TPD.ProductSKU like '%" + txt_SKUCode.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And TPD.ProductSKU like '%" + txt_SKUCode.Text.Trim() + "%'";
                }
            }

            if (txt_PackageName.Text.Trim() != "")
            {
                if (Query.Equals(""))
                {
                    Query = " where TPD.PackageName like '%" + txt_PackageName.Text.Trim() + "%'";
                }
                else
                {
                    Query += " And TPD.PackageName like '%" + txt_PackageName.Text.Trim() + "%'";
                }
            }

            Bal BusinessAccessLayer = new Bal();
            DataTable dtPackageDetails = new DataTable();
            dtPackageDetails = BusinessAccessLayer.SearchCaseDetails(MainQuery + Query + ConditionQuery);

            if (dtPackageDetails != null && dtPackageDetails.Rows.Count > 0)
            {
                rgvTestPackageDetails.DataSource = dtPackageDetails;
                rgvTestPackageDetails.DataBind();
            }
            else
            {
                rgvTestPackageDetails.DataSource = new object[] { };
                rgvTestPackageDetails.DataBind();
            }

        }

        protected void txt_SKUCode_TextChanged(object sender, EventArgs e)
        {
            //txt_PackageName.Text = "";
            //txt_ClientName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchPackage();
        }
        protected void txt_PackageName_TextChanged(object sender, EventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_ClientName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchPackage();
        }

        protected void txt_ClientName_TextChanged(object sender, EventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_PackageName.Text = "";
            //DDL_Status.SelectedItem.Text = "Select Status";
            LoadSearchPackage();
        }

        protected void DDL_Status_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //txt_SKUCode.Text = "";
            //txt_PackageName.Text = "";
            //txt_ClientName.Text = "";
            LoadSearchPackage();
        }

        public void LoadTestPackageRemarkDetails()
        {
            DataTable dtLoadTestPackageRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadTestPackageRemarkDetailsList = BusinessAccessLayer.LoadTestPackageRemarkDetailsList(Variables.PackageId);

            if (dtLoadTestPackageRemarkDetailsList != null && dtLoadTestPackageRemarkDetailsList.Rows.Count > 0)
            {
                rgvTestPackageRemarkDetails.DataSource = dtLoadTestPackageRemarkDetailsList;
                rgvTestPackageRemarkDetails.DataBind();
            }
            else
            {
                rgvTestPackageRemarkDetails.DataSource = new object[] { }; ;
                rgvTestPackageRemarkDetails.DataBind();
            }
        }

        public void LoadPackageDetailsById()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand cmdFetchTestDetails = new SqlCommand("Exec proc_LoadPackageDetailsById @PackageId", con);
            SqlParameter paramPackageId = new SqlParameter("@PackageId", Variables.PackageId);

            cmdFetchTestDetails.Parameters.Add(paramPackageId);

            SqlDataAdapter daPackageData = new SqlDataAdapter(cmdFetchTestDetails);
            DataTable dtPackageDetails = new DataTable();
            daPackageData.Fill(dtPackageDetails);

            if (dtPackageDetails != null && dtPackageDetails.Rows.Count > 0)
            {

                TextPackageName.Text = dtPackageDetails.Rows[0]["PackageName"].ToString();
        
            }
        }
        protected void rgvTestPackageRemarkDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rgvTestPackageRemarkDetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //bool showModal = true;
            //if (showModal)
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

            DataTable dtLoadTestPackageRemarkDetailsList = new DataTable();
            Bal BusinessAccessLayer = new Bal();

            dtLoadTestPackageRemarkDetailsList = BusinessAccessLayer.LoadTestRemarkDetailsList(Variables.TestId);

            if (dtLoadTestPackageRemarkDetailsList != null && dtLoadTestPackageRemarkDetailsList.Rows.Count > 0)
            {
                rgvTestPackageRemarkDetails.DataSource = dtLoadTestPackageRemarkDetailsList;
                //rgvTestPackageRemarkDetails.DataBind();
            }
            else
            {
                rgvTestPackageRemarkDetails.DataSource = new object[] { }; ;
                //rgvTestPackageRemarkDetails.DataBind();
            }
        }

        protected void rgvTestPackageRemarkDetails_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void Linkspl1_Click(object sender, EventArgs e)
        {
            Variables.PackageId = 0;
            Response.Redirect("~/Test/AddPackage.aspx");
        }

        
    }
}