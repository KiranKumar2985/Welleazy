<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="Welleazy.Case.Case" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
         <title>Case Management | Case</title>
        <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
      
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script type="text/javascript">
                function ShowPopup(title, body) {
                    $("#MyPopup .modal-title").html(title);
                    $("#MyPopup .modal-body").html(body);
                    $("#MyPopup").modal("show");
                }
    </script>

        <script type="text/javascript">
            function deleletconfig() {

                var del = confirm("Are you sure you want to delete this record?");
                if (del == true) {

                } else {

                }
                return del;
            }
            </script>
      <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>--%>
         <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
            <h5>
                <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> Case List
                <span style="float:right; font-size:small;">
                    <asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/Case/AddCase.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Case</asp:LinkButton> | 
                    <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="#" ForeColor="#0033cc"> Bulk Case Upload</asp:LinkButton> | 
                    <asp:LinkButton ID="Linkspl3" runat="server" PostBackUrl="~/Master/AddCaseStatus.aspx" ForeColor="#0033cc"> Bulk Case Status Upload </asp:LinkButton> | 
                    <asp:LinkButton ID="Linkspl4" runat="server" PostBackUrl="~/Master/AddBranch.aspx" ForeColor="#0033cc"> Bulk Branch Upload</asp:LinkButton> | 
                    <asp:LinkButton ID="Linkspl5" runat="server" PostBackUrl="#" ForeColor="#0033cc"> Move Case PM to VMER</asp:LinkButton>
                    </span></h5>
                                       <div class="line"></div>
     
              <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-40px;">
           
                <div class="col-md-3">
                    <label>Client Name </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbClientName" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server"  >
                                 <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate" />
                                     </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
               
                  <div class="col-md-3">
                    <label>Case Status </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
            
                      <div class="col-md-3">
                            <label>Application No. </label>
                            <div class="selector">
                                <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                                </div>
                        
                        </div>
                  <div class="col-md-3">
                            <label>Case Id/TA Code </label>
                            <div class="selector">
                                <asp:TextBox ID="txt_CaseId" runat="server" placeholder="Case Id/TA Code" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                                </div>
                        
                        </div><br /><br />
                  </div>
             <div runat="server" id="AdvancedSearch" visible="false" class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px; margin-bottom:240px;">
           
                <div class="col-md-3">
                    <label>Branch </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbBranchSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                    </telerik:RadComboBox>
                                </div>
                                </div>
               
                  <div class="col-md-3">
                    <label>Assigned Agent </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbAssignedAgentSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select User" />
                                
<%--                                            <telerik:RadComboBoxItem Value="Mr Dixit" Text="Mr Dixit" />

                                        <telerik:RadComboBoxItem Value="Rakesh Kumar" Text="Rakesh Kumar" />--%>
                                    </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
            
                      <div class="col-md-3">
                            <label>Updated By </label>
                            <div class="selector">
                               <telerik:RadComboBox ID="rcbUpdatedBy" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select" />
                                    </Items>
                                </telerik:RadComboBox>
                                </div>
                        
                        </div>
                 <div class="col-md-3">
                            <label>State </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="cmbStateSearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                    </Items>
                                </telerik:RadComboBox>
                                </div>
                            <br />
                        </div>
                  <div class="col-md-3">
                            <label>City </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbCitySearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                                   <Items>
                                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select City" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                </div>
                            <br />
                        </div>
                 <div class="col-md-4">
                            <label>Follow Up Date (MM-DD-YYYY) </label>
                            <div class="selector">
                                <telerik:RadDateRangePicker ID="rdrpFollowupdate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server" ></telerik:RadDateRangePicker>
                                <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="Follow Up Date (MM-DD-YYYY)" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_CaseId_TextChanged"></asp:TextBox>--%>
                                </div>
                        
                        </div>
                 <div class="col-md-4">
                            <label>Case Receive Date (MM-DD-YYYY) </label>
                            <div class="selector">
                                <telerik:RadDateRangePicker ID="rdrpCaseReceivedate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server"></telerik:RadDateRangePicker>
                                </div>
                        <br /><br />
                        </div>
                <%-- <div class="col-md-4">
                            <label>Case Effective Date (MM-DD-YYYY) </label>
                            <div class="selector">
                                <telerik:RadDateRangePicker ID="rdrpCaseEffectivedate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server"></telerik:RadDateRangePicker>
                                </div>
                            <br />
                        </div>--%>
                 <div class="col-md-3">
                            <label>Mobile Number </label>
                            <div class="selector">
                                <asp:TextBox ID="txtMobileNoSearch" runat="server" placeholder="Mobile Number" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                                </div>
                        
                        </div>
                 <div class="col-md-3">
                            <label>Case Owner Name </label>
                            <div class="selector">
                                <asp:TextBox ID="txtCaseOwnerSearch" runat="server" placeholder="Case Owner Name" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox><br /><br />
                                </div>
                        
                        </div>
                 <div class="col-md-3">
                     <asp:Label ID="lblMCorporateId" runat="server" Visible="false"></asp:Label>
                      <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                    </Items>
                                </telerik:RadComboBox>
                 </div><br /><br />
                  </div>
         

         
             <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px; " align="center">
             
                   <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAdvanced" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Advanced Search" OnClick="btnAdvanced_Click" Width="200" />
              
         
             </div>
              <div class="form-group" style="padding:10px; padding-top:20px; margin-top:10px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">
                 <span style="float:left;">
                     <telerik:RadComboBox ID="cmbExport" RenderMode="Lightweight" CssClass="Combo_Export" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbExport_SelectedIndexChanged" CausesValidation="false" >
                          <Items>
                              
                              <telerik:RadComboBoxItem  Value="1" Text="CSV" Selected="true"/>
                              <telerik:RadComboBoxItem  Value="2" Text="Excel"/>
                          </Items>
                      </telerik:RadComboBox>

                      <asp:Button ID="btnDownload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnDownload_Click" Text="Export to CSV"/>
                 </span>
                  <span style="float:right; right:0;">
                  <asp:CheckBox ID="chkall" runat="server" onclick="CheckAll(this);" AutoPostBack="false" />
                   </span>
                  <div class="form-group" style="padding:10px; overflow:auto; overflow-y:hidden; margin-top:40px;">
                  <telerik:RadGrid ID="rgCaseDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgCaseDetails_ItemCommand" OnNeedDataSource="rgCaseDetails_NeedDataSource" OnPageIndexChanged="rgCaseDetails_PageIndexChanged" OnItemDataBound="rgCaseDetails_ItemDataBound" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                       <ItemTemplate>
                                           
                                           <asp:ImageButton ID="lnkCaseRefId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                           <asp:ImageButton ID="lnkCaseRefId1" runat="server" ImageUrl="~/images/remark_icon.png" Height="18" Width="18" ToolTip="Case Remarks" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow1" /><br />
                                           <asp:CheckBox ID="chkTax" runat="server" onclick="Check(this);" AutoPostBack="false" />
                                           <asp:Label ID="lblCaseRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>' Visible="false"></asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case Entry Date" SortExpression="CaseEntryDatetime">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCaseEntryDatetime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseEntryDatetime")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Customer Profile" SortExpression="Description">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCustomerProfile" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCaseId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                              
                                   <telerik:GridTemplateColumn HeaderText="Follow Up Date" SortExpression="SchFollowupdate">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSchFollowupdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SchFollowupdate")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
    <%--                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="lnkCaseRefId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>'></asp:LinkButton>
                                           <asp:Label ID="lblCaseRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>' Visible="false"></asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>--%>
                                   <telerik:GridTemplateColumn HeaderText="Schedule Appointment" SortExpression="">
                                       <ItemTemplate>
                                           <asp:ImageButton ID="ScheduleAppointment" runat="server" ImageUrl="~/images/calender_icon.jpg" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AppointmentRow" />
                                           <asp:Label ID="lblCaseRefIdA" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>' Visible="false"></asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Appointment Date" SortExpression="AppointmentDateTime">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAppointmentDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDateTime")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatusName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatusName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Application No." SortExpression="ApplicationNo">
                                       <ItemTemplate>
                                           <asp:Label ID="lblApplicationNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ApplicationNo")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case Type" SortExpression="CaseType">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCaseType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseType")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case For" SortExpression="Relationship">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Relationship")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Case Owner" SortExpression="EmployeeName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Customer_Mobile_No" SortExpression="EmployeeMobileNo">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmployeeMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeMobileNo")%>'>
                                                        </asp:Label>
                                           <asp:ImageButton ID="lblContact" runat="server" Height="25" ImageUrl="~/images/contact_icon.png" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="ShowContactDetails" data-toggle="modal" />
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Medical Test" SortExpression="MedicalTest">
                                       <ItemTemplate>
                                           <asp:Button ID="btnURLLink" runat="server" Text="View Test" CssClass="Login_btn btn" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="ViewTest" CausesValidation="false" data-toggle="modal"></asp:Button>
                                       
                                           <asp:Label ID="lblCaseRefIdM" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Assigned Agent" SortExpression="name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAssignedExecutive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Branch" SortExpression="BranchName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblWelleazyBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="City" SortExpression="DistrictName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmployeeCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DistrictName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="State" SortExpression="StateName">
                                       <ItemTemplate>
                                           <asp:Label ID="EmployeeState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StateName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="CreatedBy">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Last Action Date" SortExpression="UpdatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblUpdatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Updated By" SortExpression="UpdatedBy">
                                       <ItemTemplate>
                                           <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedBy")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                             
                                   </Columns> 
                       </MasterTableView>
                  </telerik:RadGrid>
                     </div>
              </div>
         
             </div>
                      


            <%-- </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="rgCaseDetails" />

            </Triggers>
            </asp:UpdatePanel>--%>
        <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Medical Test</h4>
            </div>
            <div class="modal-body">
         
            <h5>Medical Test: </h5>
            <asp:Label ID="lblIndividualTest" runat="server" ></asp:Label>
                <hr />
                <h5>Test Name: </h5>
            <asp:Label ID="lblTestName" runat="server" ></asp:Label>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>

         <div class="modal fade" id="myModal1" role="dialog" >
        <div class="modal-dialog" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h5 class="modal-title" style="background-color:#e1e1e1; padding:10px;">
                  <asp:Label ID="TextCorporateName" runat="server" ></asp:Label> | 
                  <asp:Label ID="TextCaseOwnerName" runat="server" ></asp:Label>
              </h5>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <table>
                        <tr>
                            <td class="table_space">Case Id</td>
                            <td class="table_space">
                                <asp:Label ID="TextCaseId" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">Application No.</td>
                            <td class="table_space">
                                <asp:Label ID="TextApplicationNo" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">
                                <asp:LinkButton ID="LinkViewTest" runat="server" OnClick="LinkViewTest_Click" ToolTip="Click On">View Test</asp:LinkButton><br />
                                <asp:Label ID="TestMedicalTest" runat="server" Visible="false" ForeColor="Green" ></asp:Label><asp:Label ID="llTestCaseRefId" runat="server" Visible="false" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_space">Customer Profile</td>
                            <td class="table_space">
                                <asp:Label ID="TextCustomerProfile" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">City/State</td>
                            <td class="table_space">
                                <asp:Label ID="TextCity" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">
                                <asp:Label ID="TextState" runat="server" ></asp:Label>
                            </td>
                        </tr>
                         <%--<tr>
                            <td class="table_space">Videography</td>
                            <td class="table_space">
                                <asp:Label ID="TextVideography" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space"></td>
                            <td class="table_space"></td>
                            <td class="table_space"></td>
                        </tr>--%>
                        <tr>
                            <td class="table_space" colspan="2">Customer Number <br />
                                <asp:Label ID="TextMobileNo" runat="server" BackColor="#ccffcc"></asp:Label>
                            </td>
                            <td class="table_space"></td>
                            <td class="table_space"></td>
                            <td class="table_space">
                                <asp:ImageButton ID="btncomment" runat="server" Height="25" ImageUrl="~/images/comment-icon.png" ToolTip="Update Case Status" OnClick="btncomment_Click" />
                                <asp:ImageButton ID="btnAppointment" runat="server" Height="25" ImageUrl="~/images/calender_icon.jpg" ToolTip="Schedule Appointment" OnClick="btnAppointment_Click" />
                             
                            </td>
                        </tr>
                        <tr runat="server" id="CaseUpdate" visible="false">
                            <td class="table_space" colspan="5" runat="server" align="center">
                                <table border="1">
                                    <tr>
                                        
                                <td class="table_space">Follow Up Date<br />
                                    <telerik:RadDateTimePicker ID="dtpContactFollowUpDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true">
                                
                                </telerik:RadDateTimePicker>
                                    <telerik:RadDateTimePicker ID="dtpEntryDate" RenderMode="Lightweight" Filter="Contains" Visible="false" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true">
                                
                                </telerik:RadDateTimePicker>
                                  
                                </td>
                                <td class="table_space">Case Status<br />
                                <telerik:RadComboBox ID="rcbContactCaseStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                                </telerik:RadComboBox>
                                </td>
                                    </tr>
                                    <tr>
                                        <td class="table_space" colspan="2">Remark<br />
                                    <asp:TextBox ID="txt_ContactRemark" runat="server" TextMode="MultiLine" class="form-control required" ></asp:TextBox>
                                </td>
                                
                                    </tr>
                                    <tr>
                                        <td class="table_space" colspan="2" runat="server" align="center">
                                    <asp:Button ID="btnSave" Text="Update Now" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" />
                                </td>
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                    </table>
                    </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>
        <script type="text/javascript"> 

    function CheckAll(id) {
            var masterTable = $find("<%= rgCaseDetails.ClientID %>").get_masterTableView();
            var row = masterTable.get_dataItems();
            if (id.checked == true) {
                for (var i = 0; i < row.length; i++) {
                    masterTable.get_dataItems()[i].findElement("chkTax").checked = true;
                }
            }
            else {
                for (var i = 0; i < row.length; i++) {
                    masterTable.get_dataItems()[i].findElement("chkTax").checked = false;
                }
            }
        }
</script> 
    </asp:Content>
