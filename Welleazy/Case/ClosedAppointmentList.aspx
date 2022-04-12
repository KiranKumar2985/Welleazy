<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClosedAppointmentList.aspx.cs" Inherits="Welleazy.Case.ClosedAppointmentList" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Closed Appointment List</title>
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
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> Closed Appointment List</h5>
                                   
         <div class="line"></div>
         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-40px;">
           
            <div class="col-md-3">
                <label>Client Name </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbClientName" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                             <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Corporate" />
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
              <%--<div class="col-md-3">
                <label>Appointment Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbAppointmentStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Appointment Status" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>--%>
            
              <div class="col-md-3">
                <label>Report Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbReportStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Report Status" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>   
             <div class="col-md-3">
                        <label>Case Id/TA Code </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_CaseId" runat="server" placeholder="Case Id/TA Code" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                            </div>
                        
                    </div>
              <br /><br />
              </div>
         <div runat="server" id="AdvancedSearch" visible="false" class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px; margin-bottom:280px;">
           
                         <div class="col-md-3">
                        <label>Appointment Date & Time </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpAppointment" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" EndDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" runat="server" ></telerik:RadDateRangePicker>

                        </div>
                        
                    </div>
             <div class="col-md-3">
                        <label>Customer Name </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_EmployeeName" runat="server" placeholder="Customer Name" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                            </div>
                        
                    </div>
            <div class="col-md-3">
                <label>Welnext Branch </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbBranch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                </telerik:RadComboBox>
                            </div>
                            </div>
               
              <div class="col-md-3">
                <label>Assigned Agent </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbAssignedAgent" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select User" />
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
                <label>Case Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" runat="server"  >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
<%--                                    <telerik:RadComboBoxItem Value="1" Text="Fresh Case" />
                                    <telerik:RadComboBoxItem Value="2" Text="Call Later - Customer asked to call back" />
                                    <telerik:RadComboBoxItem Value="3" Text="Call Later - Customer phone switched off" />
                                    <telerik:RadComboBoxItem Value="4" Text="Appointment Confirmed" />
                                    <telerik:RadComboBoxItem Value="5" Text="Appointment Cancelled" />
                                    <telerik:RadComboBoxItem Value="6" Text="Appointment Missed - Reschedule Appointment" />
                                    <telerik:RadComboBoxItem Value="7" Text="Medicals Done - Report Awaited" />
                                    <telerik:RadComboBoxItem Value="8" Text="Closed - Reports Submitted to Insurer" />
                                    <telerik:RadComboBoxItem Value="9" Text="Pending" />--%>
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            <%-- <div class="col-md-6">
                        <label>Appointment Close Date </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpAppointmentCloseDate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" EndDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" runat="server" ></telerik:RadDateRangePicker>

                        </div>
                        
                    </div>--%>
             <div class="col-md-3">
                        <label>DC State </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbStateSearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            </div>
                    </div>
              <div class="col-md-3">
                        <label>DC City </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCitySearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            </div>
                        
                    </div>
             <div class="col-md-3">
                        <label>DC Name </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbDCName" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                               <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select DC Name" />
                                </Items>
                            </telerik:RadComboBox>
                            </div>
                        
                    </div>
          <div class="col-md-3">
                        <label>Case Type </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                   <telerik:RadComboBoxItem Value="1" Text="Main Medicals" />
                                   <telerik:RadComboBoxItem Value="2" Text="Additional Medicals" />
                                   <telerik:RadComboBoxItem Value="3" Text="Clarifications" />
                                   <telerik:RadComboBoxItem Value="4" Text="Repeat Medicals" />
                                </Items>
                            </telerik:RadComboBox>
                            </div>
                        
                    </div>
             <div class="col-md-3">
                        <label>Customer Profile Type </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCustomerProfileTypeSearch" CssClass="Combo" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" runat="server"> 
                                <Items>
                                     <telerik:RadComboBoxItem Text="Select Profile Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Normal" Value="1" />
                                     <telerik:RadComboBoxItem Text="HNI" Value="2" />
                                 </Items>
                            </telerik:RadComboBox>
                            </div>
                      
                    </div>
             <div class="col-md-3">
                        <label>Error Type </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbErrorType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Error Type" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
                    <div class="col-md-3">
                        <label>Interpretation Type </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbInterpretationType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Interpretation Type" />
                                   <telerik:RadComboBoxItem Value="1" Text="ECG" />
                                   <telerik:RadComboBoxItem Value="2" Text="TMT" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
                    <div class="col-md-3">
                        <label>Interpretation Status </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbInterpretationStatus" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Interpretation Status" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
                    <div class="col-md-3">
                        <label>Doctor Name </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbDoctorName" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Doctor Name" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
             <%--<div class="col-md-3">
                        <label>Business Channel </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="RadComboBox2" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Business Channel" />
                                   <telerik:RadComboBoxItem Value="1" Text="Agency Channel" />
                                   <telerik:RadComboBoxItem Value="2" Text="Bank Insurance Channel" />
                                   <telerik:RadComboBoxItem Value="3" Text="Broker Channel" />
                                   <telerik:RadComboBoxItem Value="4" Text="Direct Channel" />
                                   <telerik:RadComboBoxItem Value="5" Text="Group Bussiness" />
                                   <telerik:RadComboBoxItem Value="6" Text="Head Office" />
                                   <telerik:RadComboBoxItem Value="7" Text="Online - Policy Bazaar" />
                                   <telerik:RadComboBoxItem Value="8" Text="Online - Others" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>--%>
              
             <div class="col-md-3">
                        <label>Report Upload By </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbReportUploadBy" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        <br />
                    </div>
               <div class="col-md-3">
                        <label>Report Upload Date </label>
                        <div class="selector">
                           
                            <telerik:RadDateRangePicker ID="rdrpReportUploadDate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" EndDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" runat="server" ></telerik:RadDateRangePicker>

                        </div>
                    </div>
           
             <div class="col-md-3">
                        <label>Appointment Schedule By </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbAppointmentBy" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
               <div class="col-md-3">
                        <label>Appointment Schedule Date </label>
                        <div class="selector">
                           
                            <telerik:RadDateRangePicker ID="rdrpAppointmentDate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" EndDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" runat="server" ></telerik:RadDateRangePicker>

                        </div>
                        
                    </div>
             
             <div class="col-md-3">
                        <label>Videography </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbVideography" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                   <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                   <telerik:RadComboBoxItem Value="2" Text="No" />
                                   <telerik:RadComboBoxItem Value="3" Text="NA" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                    </div>
             <div class="col-md-3">
                 <asp:Label ID="lblMCorporateId" runat="server" Visible="false"></asp:Label>
                      <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                      </telerik:RadComboBox>   
              </div><br /><br /><br />
         </div>
         <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px;" align="center">
             
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
             <div class="form-group" style="padding:10px; overflow-y:auto; margin-top:40px;">
              <telerik:RadGrid ID="rgAppointmentDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgAppointmentDetails_ItemCommand" OnPageIndexChanged="rgAppointmentDetails_PageIndexChanged" OnNeedDataSource="rgAppointmentDetails_NeedDataSource" OnItemDataBound="rgAppointmentDetails_ItemDataBound" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True"
                    SaveScrollPosition="True" />
            </ClientSettings>
                  <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkAppointmentId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" ToolTip="Edit Appointment" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <asp:ImageButton ID="lnkAppointmentId1" runat="server" ImageUrl="~/images/remark_icon.png" Height="18" Width="18" ToolTip="Appointment Remarks" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow1" /><br />
                                       <asp:CheckBox ID="chkTax" runat="server" onclick="Check(this);" AutoPostBack="false" />
                                       <asp:Label ID="lblAppointmentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Entry Date" SortExpression="CaseEntryDatetime" >
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
                                       <asp:Label ID="lblCaseRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatusName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatusName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Appointment Status" SortExpression="AppointmentDescription">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAppointmentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDescription")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Report Status" SortExpression="ReportStatusName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblReportStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportStatusName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Error Type" SortExpression="ErrorDescription">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQC_ErrorType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ErrorDescription")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Appointment For" SortExpression="Relationship">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Relationship")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Owner Name" SortExpression="EmployeeName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Application No" SortExpression="ApplicationNo">
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
                               <telerik:GridTemplateColumn HeaderText="Appointment Date Time" SortExpression="AppointmentDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAppointmentDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDateTime")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Appointment Closure Date" SortExpression="DateOfClosureApproval">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDateOfClosureApproval" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfClosureApproval")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Case Completion Date" SortExpression="CaseCompletionDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseCompletionDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseCompletionDateTime")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Customer Number" SortExpression="EmployeeMobileNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmployeeMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeMobileNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Diagnostic Center Name" SortExpression="DCName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDCName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DCName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Visit Type" SortExpression="VisitType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVisitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VisitType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="DC Contact Number" SortExpression="DCMobileNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDCMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DCMobileNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="DC State" SortExpression="StateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblStateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="DC City" SortExpression="DistrictName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDistrictName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DistrictName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                             
                              <%-- <telerik:GridTemplateColumn HeaderText="Individual Test" SortExpression="IndividualTest">
                                   <ItemTemplate>
                                       <asp:Label ID="lblIndividualTest" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IndividualTest")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Test Package" SortExpression="PackageTest">
                                   <ItemTemplate>
                                       <asp:Label ID="lblPackageTest" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PackageTest")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>--%>
                               <telerik:GridTemplateColumn HeaderText="Medical Test" SortExpression="MedicalTest">
                                       <ItemTemplate>
                                           <asp:Button ID="btnURLLink" runat="server" Text="View Test" CssClass="Login_btn btn" BorderStyle="None" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="ViewTest" CausesValidation="false" data-toggle="modal"></asp:Button>
                                       
                                           <asp:Label ID="lblAppointmentIdM" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentId")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Welnext Branch" SortExpression="BranchName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblBranchId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Case Type" SortExpression="CaseType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Videography" SortExpression="VideographyDone">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVideographyDone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VideographyDone")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Assigned Agent" SortExpression="name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAssignedExecutive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>                               
                               <telerik:GridTemplateColumn HeaderText="Interpretation Assigned at" SortExpression="InterpretationAssignDate">
                                       <ItemTemplate>
                                           <asp:Label ID="lblInterpretationAssignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationAssignDate")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Interpretation Closure at" SortExpression="InterpretationClosedDate">
                                       <ItemTemplate>
                                           <asp:Label ID="lblInterpretationClosedDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationClosedDate")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Interpretation Status" SortExpression="InterpretationStatus">
                                       <ItemTemplate>
                                           <asp:Label ID="lblInterpretationStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationStatus")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Photo Uploaded" SortExpression="Photo">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPhoto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Photo")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Photo ID Uploaded" SortExpression="PhotoId">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPhotoId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhotoId")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn HeaderText="Closure/Approval On" SortExpression="DateOfClosureApproval">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDateOfClosureApproval" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfClosureApproval")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>--%>
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
                               <telerik:GridTemplateColumn HeaderText="Report Upload Date" SortExpression="Report_Sent_at">
                                   <ItemTemplate>
                                       <asp:Label ID="lblReportUploadOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Report_Sent_at")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Report Upload By" SortExpression="Report_Sent_by">
                                   <ItemTemplate>
                                       <asp:Label ID="lblReportUploadBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Report_Sent_by")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Appointment Schedule Date" SortExpression="AppointmentScheduleDate">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAppointmentScheduleDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentScheduleDate")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="QC Done Date" SortExpression="CaseCompletionDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQCDoneDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseCompletionDateTime")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Scheduled By" SortExpression="ScheduledBy">
                                   <ItemTemplate>
                                       <asp:Label ID="lblScheduledBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ScheduledBy")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
                 </div>
          </div>
         </div>
<%--                      </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="rgAppointmentDetails" />
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
            <h5>Scheduled Test: </h5>
            <asp:Label ID="lblScheduledTest" runat="server" ></asp:Label>
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
                                <asp:LinkButton ID="LinkViewTest" runat="server" OnClick="LinkViewTest_Click" ToolTip="Click On" >View Test</asp:LinkButton><br />
                                <asp:Label ID="TestMedicalTest" runat="server" Visible="false" ForeColor="Green" ></asp:Label><asp:Label ID="llTestAppointmentRefId" runat="server" Visible="false" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_space">Customer Profile</td>
                            <td class="table_space">
                                <asp:Label ID="TextCustomerProfile" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">Appointment Date Time</td>
                            <td class="table_space">
                                <asp:Label ID="TextAppointmentDateTime" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">
                                <asp:Label ID="TextAppointmentStatus" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_space">DC Name</td>
                            <td class="table_space" colspan="4">
                                <asp:Label ID="TextDcName" runat="server" ></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td class="table_space">Videography</td>
                            <td class="table_space" colspan="4">
                                <asp:Label ID="TextVideography" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_space" colspan="2">Customer Number <br />
                                <asp:Label ID="TextMobileNo" runat="server" BackColor="#ccffcc"></asp:Label>
                            </td>
                            <td class="table_space"></td>
                            <td class="table_space"></td>
                            <td class="table_space">
                                <asp:ImageButton ID="btnAppointment" runat="server" Height="25" ImageUrl="~/images/calender_icon.jpg" OnClick="btnAppointment_Click" />
                             
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
            var masterTable = $find("<%= rgAppointmentDetails.ClientID %>").get_masterTableView();
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
