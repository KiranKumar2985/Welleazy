using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy
{
    public partial class UserPermission : System.Web.UI.Page
    {
        
        public string panel1ControlsCount = "";
        public string panel2ControlsCount = "";
        public string panel3ControlsCount = "";
        public string panel4ControlsCount = "";
        public string panel5ControlsCount = "";
        public string panel6ControlsCount = "";
        public string panel7ControlsCount = "";
        public string panel8ControlsCount = "";
        public string panel9ControlsCount = "";
        public string panel10ControlsCount = "";
        public string panel11ControlsCount = "";
        public string panel12ControlsCount = "";
        public string panel13ControlsCount = "";
        public string panel14ControlsCount = "";
        public string panel15ControlsCount = "";
        public string panel16ControlsCount = "";
        public string panel17ControlsCount = "";
        public string panel18ControlsCount = "";
        public string panel19ControlsCount = "";
        public string panel20ControlsCount = "";
        public string panel21ControlsCount = "";
        public string panel22ControlsCount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    LoadProfileTypes();





                    //Panel panel2 = new Panel();
                    //panel2.Visible = true;


                    //// Create a Table and set its properties 
                    ////Table tbl = new Table();
                    //// Add the table to the placeholder control
                    ////PlaceHolder1.Controls.Add(tbl);
                    //// Now iterate through the table and add your controls 
                    //for (int i = 1; i <= tblRows; i++)
                    //{
                    //    TableRow tr = new TableRow();
                    //    for (int j = 1; j <= tblCols; j++)
                    //    {
                    //        if (q <= QuestionNo)
                    //        {

                    //            TableCell tc = new TableCell();
                    //            tc.Width = 200;
                    //            //TextBox txtBox = new TextBox();
                    //            //txtBox.Text = "RowNo:" + i + " " + "ColumnNo:" + " " + j;
                    //            CheckBox btn = new CheckBox();
                    //            //btn.CssClass = "btn btn-info";
                    //            //btn.CssClass = "btn btn-unique btn-sm";
                    //            //btn.Width = 60;
                    //            //btn.Height = 60;
                    //            btn.ID = "btnQuestion" + Q_No;
                    //            btn.Text = "     " + Q_No.ToString();
                    //            //btn.Click += new EventHandler(btn_Click);
                    //            // Add the control to the TableCell
                    //            tc.Controls.Add(btn);
                    //            //btn.CssClass = "button";
                    //            // Add the TableCell to the TableRow
                    //            tr.Cells.Add(tc);
                    //            Q_No++;

                    //        }
                    //        q++;
                    //    }
                    //    // Add the TableRow to the Table
                    //    tbl.Rows.Add(tr);
                    //}

                    //panel2.Controls.Add(tbl);










                    //Table tbldynamic = new Table();
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    TableCell tc = new TableCell();
                    //    TableRow tr = new TableRow();
                    //    CheckBox _checkbox = new CheckBox();
                    //    _checkbox.ID = "chkDynamicCheckBox" + i;
                    //    _checkbox.Text = "Checkbox" + i;
                    //    tc.Controls.Add(_checkbox);
                    //    tr.Cells.Add(tc);
                    //    tbldynamic.Rows.Add(tr);
                    //}
                    //Panel1.Controls.Add(tbldynamic);
                }
            }
            LoadPermissionDetails();
        }

        public void LoadPermissionDetails()
        {

            DataSet dtLoadPermissionDetails = new DataSet();
            Bal BusinessAccessLayer = new Bal();
            dtLoadPermissionDetails = BusinessAccessLayer.LoadPermissionDetails();

            if (dtLoadPermissionDetails != null)
            {
                DataView dvPanelDetails = new DataView(dtLoadPermissionDetails.Tables[1]);

                DataView dvPermission = new DataView(dtLoadPermissionDetails.Tables[0]);

                DataTable dtPermission = new DataTable();
                dtPermission = dvPermission.ToTable();


                if (dtPermission != null && dtPermission.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPermission.Rows.Count; i++)
                    {
                        GenerateCheckBox(i + 1, dvPanelDetails, dtPermission.Rows[i]["permission"].ToString());
                    }
                }

            }

        }

        public void GenerateCheckBox(int PermissionId, DataView PermissionView, string PanelName)
        {
            PermissionView.RowFilter = "permission_id=" + PermissionId;

            DataTable dtpanel1 = new DataTable();
            dtpanel1 = PermissionView.ToTable();

            int permissioncount = dtpanel1.Rows.Count;

            int pc = 1;

            int p_c = 0;

            double RowCount = permissioncount / 4;

            int tblRows = Convert.ToInt32(RowCount);
            int tblCols = 4;

            Table tbl = new Table();

            for (int i = 0; i <= tblRows; i++)
            {
                TableRow tr = new TableRow();
                for (int j = 0; j <= tblCols; j++)
                {
                    if (pc <= permissioncount)
                    {

                        TableCell tc = new TableCell();
                        tc.Width = 300;

                        CheckBox btn = new CheckBox();

                        btn.ID = "chkPermission" + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                        btn.Text = dtpanel1.Rows[p_c]["subpermission"].ToString();


                        if (PermissionId == 1)
                        {
                            if (panel1ControlsCount.Equals(""))
                            {
                                panel1ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel1ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 2)
                        {
                            if (panel2ControlsCount.Equals(""))
                            {
                                panel2ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel2ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 3)
                        {
                            if (panel3ControlsCount.Equals(""))
                            {
                                panel3ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel3ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 4)
                        {
                            if (panel4ControlsCount.Equals(""))
                            {
                                panel4ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel4ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 5)
                        {
                            if (panel5ControlsCount.Equals(""))
                            {
                                panel5ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel5ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 6)
                        {
                            if (panel6ControlsCount.Equals(""))
                            {
                                panel6ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel6ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 7)
                        {
                            if (panel7ControlsCount.Equals(""))
                            {
                                panel7ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel7ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 8)
                        {
                            if (panel8ControlsCount.Equals(""))
                            {
                                panel8ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel8ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 9)
                        {
                            if (panel9ControlsCount.Equals(""))
                            {
                                panel9ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel9ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 10)
                        {
                            if (panel10ControlsCount.Equals(""))
                            {
                                panel10ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel10ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 11)
                        {
                            if (panel11ControlsCount.Equals(""))
                            {
                                panel11ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel11ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 12)
                        {
                            if (panel12ControlsCount.Equals(""))
                            {
                                panel12ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel12ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 13)
                        {
                            if (panel13ControlsCount.Equals(""))
                            {
                                panel13ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel13ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 14)
                        {
                            if (panel14ControlsCount.Equals(""))
                            {
                                panel14ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel14ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 15)
                        {
                            if (panel15ControlsCount.Equals(""))
                            {
                                panel15ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel15ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 16)
                        {
                            if (panel16ControlsCount.Equals(""))
                            {
                                panel16ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel16ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 17)
                        {
                            if (panel17ControlsCount.Equals(""))
                            {
                                panel17ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel17ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 18)
                        {
                            if (panel18ControlsCount.Equals(""))
                            {
                                panel18ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel18ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 19)
                        {
                            if (panel19ControlsCount.Equals(""))
                            {
                                panel19ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel19ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 20)
                        {
                            if (panel20ControlsCount.Equals(""))
                            {
                                panel20ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel20ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 21)
                        {
                            if (panel21ControlsCount.Equals(""))
                            {
                                panel21ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel21ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }

                        if (PermissionId == 22)
                        {
                            if (panel22ControlsCount.Equals(""))
                            {
                                panel22ControlsCount = dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                            else
                            {
                                panel22ControlsCount += "," + dtpanel1.Rows[p_c]["SubPermissionId"].ToString();
                            }
                        }



                        tc.Controls.Add(btn);

                        tr.Cells.Add(tc);
                        p_c++;

                    }
                    pc++;
                }

                tbl.Rows.Add(tr);
            }

            if (PermissionId.Equals(1))
            {
                Panel1.Controls.Add(tbl);
                Panel1.GroupingText = PanelName;
            }
            if (PermissionId.Equals(2))
            {
                Panel2.Controls.Add(tbl);
                Panel2.GroupingText = PanelName;
            }
            if (PermissionId.Equals(3))
            {
                Panel3.Controls.Add(tbl);
                Panel3.GroupingText = PanelName;
            }
            if (PermissionId.Equals(4))
            {
                Panel4.Controls.Add(tbl);
                Panel4.GroupingText = PanelName;
            }
            if (PermissionId.Equals(5))
            {
                Panel5.Controls.Add(tbl);
                Panel5.GroupingText = PanelName;
            }
            if (PermissionId.Equals(6))
            {
                Panel6.Controls.Add(tbl);
                Panel6.GroupingText = PanelName;
            }
            if (PermissionId.Equals(7))
            {
                Panel7.Controls.Add(tbl);
                Panel7.GroupingText = PanelName;
            }

            if (PermissionId.Equals(8))
            {
                Panel8.Controls.Add(tbl);
                Panel8.GroupingText = PanelName;
            }

            if (PermissionId.Equals(9))
            {
                Panel9.Controls.Add(tbl);
                Panel9.GroupingText = PanelName;
            }

            if (PermissionId.Equals(10))
            {
                Panel10.Controls.Add(tbl);
                Panel10.GroupingText = PanelName;
            }

            if (PermissionId.Equals(11))
            {
                Panel11.Controls.Add(tbl);
                Panel11.GroupingText = PanelName;
            }

            if (PermissionId.Equals(12))
            {
                Panel12.Controls.Add(tbl);
                Panel12.GroupingText = PanelName;
            }

            if (PermissionId.Equals(13))
            {
                Panel13.Controls.Add(tbl);
                Panel13.GroupingText = PanelName;
            }

            if (PermissionId.Equals(14))
            {
                Panel14.Controls.Add(tbl);
                Panel14.GroupingText = PanelName;
            }

            if (PermissionId.Equals(15))
            {
                Panel15.Controls.Add(tbl);
                Panel15.GroupingText = PanelName;
            }

            if (PermissionId.Equals(16))
            {
                Panel16.Controls.Add(tbl);
                Panel16.GroupingText = PanelName;
            }

            if (PermissionId.Equals(17))
            {
                Panel17.Controls.Add(tbl);
                Panel17.GroupingText = PanelName;
            }

            if (PermissionId.Equals(18))
            {
                Panel18.Controls.Add(tbl);
                Panel18.GroupingText = PanelName;
            }

            if (PermissionId.Equals(19))
            {
                Panel19.Controls.Add(tbl);
                Panel19.GroupingText = PanelName;
            }

            if (PermissionId.Equals(20))
            {
                Panel20.Controls.Add(tbl);
                Panel20.GroupingText = PanelName;
            }

            if (PermissionId.Equals(21))
            {
                Panel21.Controls.Add(tbl);
                Panel21.GroupingText = PanelName;
            }

            if (PermissionId.Equals(22))
            {
                Panel22.Controls.Add(tbl);
                Panel22.GroupingText = PanelName;
            }



        }

        public void LoadProfileTypes()
        {
            DataTable dtLoadProfileTypes = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadProfileTypes = BusinessAccessLayer.LoadProfileTypes();

            if (dtLoadProfileTypes != null && dtLoadProfileTypes.Rows.Count > 0)
            {
                ddlProfileType.DataSource = dtLoadProfileTypes;
                ddlProfileType.DataTextField = "name";
                ddlProfileType.DataValueField = "role_id";
                ddlProfileType.DataBind();

                //cmbSearch.DataSource = dtLoadProfileTypes;
                //cmbSearch.DataTextField = "name";
                //cmbSearch.DataValueField = "role_id";
                //cmbSearch.DataBind();
            }
            else
            {
                ddlProfileType.DataSource = null;
                ddlProfileType.DataBind();
            }
        }

        public void LoadUserRoles()
        {
            DataTable dtLoadUserRoles = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadUserRoles = BusinessAccessLayer.LoadUserRoles(Convert.ToInt32(ddlProfileType.SelectedValue));

            if (dtLoadUserRoles != null && dtLoadUserRoles.Rows.Count > 0)
            {
                ddlUserRoles.DataSource = dtLoadUserRoles;
                ddlUserRoles.DataTextField = "subrole";
                ddlUserRoles.DataValueField = "subrole_id";
                ddlUserRoles.DataBind();
            }
            else
            {
                ddlUserRoles.DataSource = null;
                ddlUserRoles.DataBind();
            }
        }

        public void LoadUsers()
        {
            DataTable dtLoadUsers = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtLoadUsers = BusinessAccessLayer.LoadUsers(Convert.ToInt32(ddlProfileType.SelectedValue), Convert.ToInt32(ddlUserRoles.SelectedValue));

            if (dtLoadUsers != null && dtLoadUsers.Rows.Count > 0)
            {
                ddlUser.DataSource = dtLoadUsers;
                ddlUser.DataTextField = "name";
                ddlUser.DataValueField = "user_id";
                ddlUser.DataBind();
            }
            else
            {
                ddlUser.DataSource = null;
                ddlUser.DataBind();
            }
        }

        protected void ddlProfileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserRoles();
        }

        protected void ddlUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        protected void chkAll_1_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC1, PC2, PC3, PC4, PC5, PC6, PC7, PC8, PC9, PC10, PC11, PC12, PC13, PC14, PC15, PC16, PC17, PC18, PC19, PC20, PC21;
            PC1 = panel1ControlsCount.Split(',');
            //PC2 = panel2ControlsCount.Split(',');
            //PC3 = panel3ControlsCount.Split(',');
            //PC4 = panel4ControlsCount.Split(',');
            //PC5 = panel5ControlsCount.Split(',');
            //PC6 = panel6ControlsCount.Split(',');
            //PC7 = panel7ControlsCount.Split(',');
            //PC8 = panel8ControlsCount.Split(',');
            //PC9 = panel9ControlsCount.Split(',');
            //PC10 = panel10ControlsCount.Split(',');
            //PC11 = panel11ControlsCount.Split(',');
            //PC12 = panel12ControlsCount.Split(',');
            //PC13 = panel13ControlsCount.Split(',');
            //PC14 = panel14ControlsCount.Split(',');
            //PC15 = panel15ControlsCount.Split(',');
            //PC16 = panel16ControlsCount.Split(',');
            //PC17 = panel17ControlsCount.Split(',');
            //PC18 = panel18ControlsCount.Split(',');
            //PC19 = panel19ControlsCount.Split(',');

            foreach (Control c in Panel1.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC1.Length; i++)
                {
                    string id = "chkPermission" + PC1[i];
                    CheckBox cb = (CheckBox)Panel1.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }
                }

            }

            //foreach (Control c in Panel2.Controls)
            //{
            //    for (int i = 0; i < PC2.Length; i++)
            //    {
            //        string id = "chkPermission" + PC2[i];
            //        CheckBox cb = (CheckBox)Panel2.FindControl(id);
            //        //if (c is CheckBox)
            //        {
            //            if (cb.Checked == false)
            //            {
            //                cb.Checked = true;
            //                //checkF.Text = "UnCheck";
            //            }

            //        }
            //    }
            //}



            //    foreach (Control c in Panel3.Controls)
            //    {
            //        for (int i = 0; i < PC3.Length; i++)
            //        {
            //            string id = "chkPermission" + PC3[i];
            //            CheckBox cb = (CheckBox)Panel3.FindControl(id);
            //            //if (c is CheckBox)
            //            {
            //                if (cb.Checked == false)
            //                {
            //                    cb.Checked = true;
            //                    //checkF.Text = "UnCheck";
            //                }

            //            }
            //        }


            //    }


        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            String[] PC1, PC2, PC3, PC4, PC5, PC6, PC7, PC8, PC9, PC10, PC11, PC12, PC13, PC14, PC15, PC16, PC17, PC18, PC19, PC20, PC21, PC22;
            PC1 = panel1ControlsCount.Split(',');
            PC2 = panel2ControlsCount.Split(',');
            PC3 = panel3ControlsCount.Split(',');
            PC4 = panel4ControlsCount.Split(',');
            PC5 = panel5ControlsCount.Split(',');
            PC6 = panel6ControlsCount.Split(',');
            PC7 = panel7ControlsCount.Split(',');
            PC8 = panel8ControlsCount.Split(',');
            PC9 = panel9ControlsCount.Split(',');
            PC10 = panel10ControlsCount.Split(',');
            PC11 = panel11ControlsCount.Split(',');
            PC12 = panel12ControlsCount.Split(',');
            PC13 = panel13ControlsCount.Split(',');
            PC14 = panel14ControlsCount.Split(',');
            PC15 = panel15ControlsCount.Split(',');
            PC16 = panel16ControlsCount.Split(',');
            PC17 = panel17ControlsCount.Split(',');
            PC18 = panel18ControlsCount.Split(',');
            PC19 = panel19ControlsCount.Split(',');
            PC20 = panel20ControlsCount.Split(',');
            PC21 = panel21ControlsCount.Split(',');
            PC22 = panel22ControlsCount.Split(',');

            string SelectedId = "";

            if (ddlProfileType.SelectedValue.Equals("0"))
            {
                lblProfileTypeDisplay.Text = "Please Select the Provider Type";
                lblProfileTypeDisplay.Visible = true;
                return;
            }
            else
            {
                lblProfileTypeDisplay.Text = "";
                lblProfileTypeDisplay.Visible = false;
            }

            if (ddlUserRoles.SelectedValue.Equals("0"))
            {
                lblUserRolesDisplay.Text = "Please Select the User Role";
                lblUserRolesDisplay.Visible = true;
                return;
            }
            else
            {
                lblUserRolesDisplay.Text = "";
                lblUserRolesDisplay.Visible = false;
            }

            if (ddlUser.SelectedValue.Equals("0"))
            {
                lblUserDisplay.Text = "Please Select the User";
                lblUserDisplay.Visible = true;
                return;
            }
            else
            {
                lblUserDisplay.Text = "";
                lblUserDisplay.Visible = false;
            }



            foreach (Control c in Panel1.Controls)
            {
                for (int i = 0; i < PC1.Length; i++)
                {
                    if (PC1[i] != "")
                    {
                        string id = "chkPermission" + PC1[i];
                        CheckBox cb = (CheckBox)Panel1.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC1[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC1[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC1[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel2.Controls)
            {
                for (int i = 0; i < PC2.Length; i++)
                {
                    if (PC2[i] != "")
                    {
                        string id = "chkPermission" + PC2[i];
                        CheckBox cb = (CheckBox)Panel1.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC2[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC2[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC2[i];
                                    }

                                }
                            }


                        }
                    }
                }


            }

            foreach (Control c in Panel3.Controls)
            {
                for (int i = 0; i < PC3.Length; i++)
                {
                    if (PC3[i] != "")
                    {
                        string id = "chkPermission" + PC3[i];
                        CheckBox cb = (CheckBox)Panel3.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC3[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC3[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC3[i];
                                    }

                                }
                            }

                        }
                    }
                }
            }

            foreach (Control c in Panel4.Controls)
            {
                for (int i = 0; i < PC4.Length; i++)
                {
                    if (PC4[i] != "")
                    {
                        string id = "chkPermission" + PC4[i];
                        CheckBox cb = (CheckBox)Panel4.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC4[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC4[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC4[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel5.Controls)
            {
                for (int i = 0; i < PC5.Length; i++)
                {
                    if (PC5[i] != "")
                    {
                        string id = "chkPermission" + PC5[i];
                        CheckBox cb = (CheckBox)Panel5.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC5[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC5[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC5[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel6.Controls)
            {
                for (int i = 0; i < PC6.Length; i++)
                {
                    if (PC6[i] != "")
                    {
                        string id = "chkPermission" + PC6[i];
                        CheckBox cb = (CheckBox)Panel6.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC6[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC6[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC6[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel7.Controls)
            {
                for (int i = 0; i < PC7.Length; i++)
                {
                    if (PC7[i] != "")
                    {
                        string id = "chkPermission" + PC7[i];
                        CheckBox cb = (CheckBox)Panel7.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC7[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC7[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC7[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel8.Controls)
            {
                for (int i = 0; i < PC8.Length; i++)
                {
                    if (PC8[i] != "")
                    {
                        string id = "chkPermission" + PC8[i];
                        CheckBox cb = (CheckBox)Panel8.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC8[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC8[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC8[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel9.Controls)
            {
                for (int i = 0; i < PC9.Length; i++)
                {
                    if (PC9[i] != "")
                    {
                        string id = "chkPermission" + PC9[i];
                        CheckBox cb = (CheckBox)Panel9.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC9[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC9[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC9[i];
                                    }

                                }
                            }

                        }
                    }
                }




            }

            foreach (Control c in Panel10.Controls)
            {
                for (int i = 0; i < PC10.Length; i++)
                {
                    if (PC10[i] != "")
                    {
                        string id = "chkPermission" + PC10[i];
                        CheckBox cb = (CheckBox)Panel10.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC10[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC10[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC10[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel11.Controls)
            {
                for (int i = 0; i < PC11.Length; i++)
                {
                    if (PC11[i] != "")
                    {
                        string id = "chkPermission" + PC11[i];
                        CheckBox cb = (CheckBox)Panel11.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC11[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC11[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC11[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel12.Controls)
            {
                for (int i = 0; i < PC12.Length; i++)
                {
                    if (PC12[i] != "")
                    {
                        string id = "chkPermission" + PC12[i];
                        CheckBox cb = (CheckBox)Panel12.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC12[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC12[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC12[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel13.Controls)
            {
                for (int i = 0; i < PC13.Length; i++)
                {
                    if (PC13[i] != "")
                    {
                        string id = "chkPermission" + PC13[i];
                        CheckBox cb = (CheckBox)Panel8.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC13[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC13[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC13[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel14.Controls)
            {
                for (int i = 0; i < PC14.Length; i++)
                {
                    if (PC14[i] != "")
                    {
                        string id = "chkPermission" + PC14[i];
                        CheckBox cb = (CheckBox)Panel8.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC14[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC14[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC14[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel15.Controls)
            {
                for (int i = 0; i < PC15.Length; i++)
                {
                    if (PC15[i] != "")
                    {
                        string id = "chkPermission" + PC15[i];
                        CheckBox cb = (CheckBox)Panel15.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC15[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC15[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC15[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel16.Controls)
            {
                for (int i = 0; i < PC16.Length; i++)
                {
                    if (PC16[i] != "")
                    {
                        string id = "chkPermission" + PC16[i];
                        CheckBox cb = (CheckBox)Panel16.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC16[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC16[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC16[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel17.Controls)
            {
                for (int i = 0; i < PC17.Length; i++)
                {
                    if (PC17[i] != "")
                    {
                        string id = "chkPermission" + PC17[i];
                        CheckBox cb = (CheckBox)Panel17.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC17[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC17[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC17[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel18.Controls)
            {
                for (int i = 0; i < PC18.Length; i++)
                {
                    if (PC18[i] != "")
                    {
                        string id = "chkPermission" + PC18[i];
                        CheckBox cb = (CheckBox)Panel18.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC18[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC18[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC18[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel19.Controls)
            {
                for (int i = 0; i < PC19.Length; i++)
                {
                    if (PC19[i] != "")
                    {
                        string id = "chkPermission" + PC19[i];
                        CheckBox cb = (CheckBox)Panel19.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC19[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC19[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC19[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel20.Controls)
            {
                for (int i = 0; i < PC20.Length; i++)
                {
                    if (PC20[i] != "")
                    {
                        string id = "chkPermission" + PC20[i];
                        CheckBox cb = (CheckBox)Panel20.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC20[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC20[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC20[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel21.Controls)
            {
                for (int i = 0; i < PC21.Length; i++)
                {
                    if (PC21[i] != "")
                    {
                        string id = "chkPermission" + PC21[i];
                        CheckBox cb = (CheckBox)Panel21.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC21[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC21[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC21[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            foreach (Control c in Panel22.Controls)
            {
                for (int i = 0; i < PC22.Length; i++)
                {
                    if (PC22[i] != "")
                    {
                        string id = "chkPermission" + PC22[i];
                        CheckBox cb = (CheckBox)Panel22.FindControl(id);
                        //if (c is CheckBox)
                        {
                            if (cb.Checked == true)
                            {
                                if (SelectedId.Equals(""))
                                {
                                    SelectedId = PC22[i];
                                }
                                else
                                {
                                    if (SelectedId.Contains(PC22[i]))
                                    {

                                    }
                                    else
                                    {
                                        SelectedId += "," + PC22[i];
                                    }

                                }
                            }

                        }
                    }
                }


            }

            Bal BusinessAccessLayer = new Bal();
            int result = BusinessAccessLayer.InsertUserRolePermissions(Convert.ToInt32(ddlUser.SelectedValue), SelectedId);
            if (result > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">alert('Data Saved Successfully...!');</script>" + "<script>window.location.href='/Home.aspx';</script>");
            }
            //Response.Write(SelectedId);
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtFetchUserRolePermissionsByUserId = new DataTable();
            Bal BusinessAccessLayer = new Bal();
            dtFetchUserRolePermissionsByUserId = BusinessAccessLayer.FetchUserRolePermissionsByUserId(Convert.ToInt32(ddlUser.SelectedValue));

            string UserRoles = "";

            if (dtFetchUserRolePermissionsByUserId != null && dtFetchUserRolePermissionsByUserId.Rows.Count > 0)
            {
                UserRoles = dtFetchUserRolePermissionsByUserId.Rows[0]["UserRolePermissions"].ToString();
            }

            string[] RolesSelected = UserRoles.Split(',');

            foreach (string s in RolesSelected)
            {
                foreach (Control c in Panel1.Controls)
                {
                    for (int i = 0; i < RolesSelected.Length; i++)
                    {
                        string id = "chkPermission" + RolesSelected[i];
                        CheckBox cb = (CheckBox)Panel1.FindControl(id);
                        //if (c is CheckBox)

                        cb.Checked = true;

                    }
                }
            }
        }

        protected void chkAll_2_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC1, PC2, PC3, PC4, PC5, PC6, PC7, PC8, PC9, PC10, PC11, PC12, PC13, PC14, PC15, PC16, PC17, PC18, PC19, PC20, PC21;
            PC1 = panel1ControlsCount.Split(',');
            PC2 = panel2ControlsCount.Split(',');
            PC3 = panel3ControlsCount.Split(',');
            PC4 = panel4ControlsCount.Split(',');
            PC5 = panel5ControlsCount.Split(',');
            PC6 = panel6ControlsCount.Split(',');
            PC7 = panel7ControlsCount.Split(',');
            PC8 = panel8ControlsCount.Split(',');
            PC9 = panel9ControlsCount.Split(',');
            PC10 = panel10ControlsCount.Split(',');
            PC11 = panel11ControlsCount.Split(',');
            PC12 = panel12ControlsCount.Split(',');
            PC13 = panel13ControlsCount.Split(',');
            PC14 = panel14ControlsCount.Split(',');
            PC15 = panel15ControlsCount.Split(',');
            PC16 = panel16ControlsCount.Split(',');
            PC17 = panel17ControlsCount.Split(',');
            PC18 = panel18ControlsCount.Split(',');
            PC19 = panel19ControlsCount.Split(',');

            foreach (Control c in Panel2.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC2.Length; i++)
                {
                    string id = "chkPermission" + PC2[i];
                    CheckBox cb = (CheckBox)Panel2.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }

        }

        protected void chkAll_3_CheckedChanged(object sender, EventArgs e)
        {

            String[] PC3;

            PC3 = panel3ControlsCount.Split(',');
            foreach (Control c in Panel3.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC3.Length; i++)
                {
                    string id = "chkPermission" + PC3[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_4_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC4;

            PC4 = panel4ControlsCount.Split(',');
            foreach (Control c in Panel4.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC4.Length; i++)
                {
                    string id = "chkPermission" + PC4[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_5_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC5;

            PC5 = panel5ControlsCount.Split(',');
            foreach (Control c in Panel5.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC5.Length; i++)
                {
                    string id = "chkPermission" + PC5[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_6_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC6;

            PC6 = panel6ControlsCount.Split(',');
            foreach (Control c in Panel6.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC6.Length; i++)
                {
                    string id = "chkPermission" + PC6[i];
                    CheckBox cb = (CheckBox)Panel6.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_7_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC7;

            PC7 = panel7ControlsCount.Split(',');
            foreach (Control c in Panel7.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC7.Length; i++)
                {
                    string id = "chkPermission" + PC7[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_8_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC8;

            PC8 = panel8ControlsCount.Split(',');
            foreach (Control c in Panel8.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC8.Length; i++)
                {
                    string id = "chkPermission" + PC8[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_9_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC9;

            PC9 = panel9ControlsCount.Split(',');
            foreach (Control c in Panel9.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC9.Length; i++)
                {
                    string id = "chkPermission" + PC9[i];
                    CheckBox cb = (CheckBox)Panel3.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_10_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC10;

            PC10 = panel10ControlsCount.Split(',');
            foreach (Control c in Panel10.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC10.Length; i++)
                {
                    string id = "chkPermission" + PC10[i];
                    CheckBox cb = (CheckBox)Panel10.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_11_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC11;

            PC11 = panel11ControlsCount.Split(',');
            foreach (Control c in Panel11.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC11.Length; i++)
                {
                    string id = "chkPermission" + PC11[i];
                    CheckBox cb = (CheckBox)Panel10.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_12_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC12;

            PC12 = panel12ControlsCount.Split(',');
            foreach (Control c in Panel12.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC12.Length; i++)
                {
                    string id = "chkPermission" + PC12[i];
                    CheckBox cb = (CheckBox)Panel12.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }



        protected void chkAll_13_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC13;

            PC13 = panel13ControlsCount.Split(',');
            foreach (Control c in Panel13.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC13.Length; i++)
                {
                    string id = "chkPermission" + PC13[i];
                    CheckBox cb = (CheckBox)Panel13.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_14_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC14;

            PC14 = panel14ControlsCount.Split(',');
            foreach (Control c in Panel14.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC14.Length; i++)
                {
                    string id = "chkPermission" + PC14[i];
                    CheckBox cb = (CheckBox)Panel14.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_15_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC15;

            PC15 = panel15ControlsCount.Split(',');
            foreach (Control c in Panel15.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC15.Length; i++)
                {
                    string id = "chkPermission" + PC15[i];
                    CheckBox cb = (CheckBox)Panel15.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }


        protected void chkAll_16_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC16;

            PC16 = panel16ControlsCount.Split(',');
            foreach (Control c in Panel16.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC16.Length; i++)
                {
                    string id = "chkPermission" + PC16[i];
                    CheckBox cb = (CheckBox)Panel16.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_17_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC17;

            PC17 = panel17ControlsCount.Split(',');
            foreach (Control c in Panel17.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC17.Length; i++)
                {
                    string id = "chkPermission" + PC17[i];
                    CheckBox cb = (CheckBox)Panel17.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_18_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC18;

            PC18 = panel18ControlsCount.Split(',');
            foreach (Control c in Panel18.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC18.Length; i++)
                {
                    string id = "chkPermission" + PC18[i];
                    CheckBox cb = (CheckBox)Panel18.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_19_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC19;

            PC19 = panel19ControlsCount.Split(',');
            foreach (Control c in Panel19.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC19.Length; i++)
                {
                    string id = "chkPermission" + PC19[i];
                    CheckBox cb = (CheckBox)Panel19.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }
        protected void chkAll_20_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC20;

            PC20 = panel20ControlsCount.Split(',');
            foreach (Control c in Panel20.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC20.Length; i++)
                {
                    string id = "chkPermission" + PC20[i];
                    CheckBox cb = (CheckBox)Panel20.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_21_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC21;

            PC21 = panel21ControlsCount.Split(',');
            foreach (Control c in Panel21.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC21.Length; i++)
                {
                    string id = "chkPermission" + PC21[i];
                    CheckBox cb = (CheckBox)Panel21.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }

        protected void chkAll_22_CheckedChanged(object sender, EventArgs e)
        {
            String[] PC22;

            PC22 = panel22ControlsCount.Split(',');
            foreach (Control c in Panel22.Controls.OfType<Table>())
            {
                for (int i = 0; i < PC22.Length; i++)
                {
                    string id = "chkPermission" + PC22[i];
                    CheckBox cb = (CheckBox)Panel22.FindControl(id);
                    {
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                            //checkF.Text = "UnCheck";
                        }
                        else if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }

                    }

                }

            }
        }


    }
}