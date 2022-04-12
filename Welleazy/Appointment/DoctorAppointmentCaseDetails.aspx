<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="DoctorAppointmentCaseDetails.aspx.cs" Inherits="Welleazy.Appointment.DoctorAppointmentCaseDetails" %>







<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Add Consultant Case Appointment</title>
    <%--<link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />--%>
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



   
    <%--<asp:UpdatePanel ID="upEConsultant" runat="server">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <%--<h5>
            Home >> Case Management >> <asp:LinkButton ID="lnlAppointmentList" runat="server" OnClick="lnlAppointmentList_Click" ForeColor="#0033cc">Case List</asp:LinkButton> >> E-Consultant Appointment List </h5>
                                   <span style="float:right; font-size:small;">
         <h5>--%>
             <%--<asp:LinkButton ID="lnlScheduleAppointment" runat="server" ForeColor="#0033cc" OnClick="lnlScheduleAppointment_Click"><b><i class="glyphicon glyphicon-plus"></i></b> Schedule Appointment</asp:LinkButton>--%>
        <%-- </h5>--%>
         <div class="line">
         </div>

         



         <asp:MultiView ID="ConsultationCaseApointmentView" runat="server">
             <asp:View ID="View" runat="server">
                 <div class="container form-group">
                 <div class="row">
                      

                      <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-40px;">
           
            <div class="col-lg-3 col-sm-6">
                <label>Corporate Name </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbClientName" Filter="Contains" CheckBoxes="true"  AutoPostBack="true" OnSelectedIndexChanged="rcbClientName_SelectedIndexChanged" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                             <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Corporate" />
                                 </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
               
              <div class="col-lg-3 col-sm-6">
                <label>Case Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    <telerik:RadComboBoxItem Value="1" Text="Fresh Case" />
                                    <telerik:RadComboBoxItem Value="2" Text="Call Later - Customer asked to call back" />
                                    <telerik:RadComboBoxItem Value="3" Text="Call Later - Customer phone switched off" />
                                    <telerik:RadComboBoxItem Value="4" Text="Appointment Confirmed" />
                                    <telerik:RadComboBoxItem Value="5" Text="Escalated to Insurance Co - Customer No Show" />
                                    <telerik:RadComboBoxItem Value="6" Text="Medicals Done - Report Awaited" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            
                  <%--<div class="col-md-3">
                        <label>Application No. </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>--%>
              <div class="col-lg-3 col-sm-6">
                        <label>Case Id/TA Code </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_CaseId" runat="server" placeholder="Case Id/TA Code" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div><br /><br />
              </div>
                     </div>
         <div runat="server" id="AdvancedSearch" visible="false" class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px; ">
           <div class="row">
            <div class="col-lg-3 col-sm-6">
                <label>Branch </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbBranchSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                </telerik:RadComboBox>
                            </div>
                            </div>

             <%--<div class="col-md-3">
                <label>Corporate Branch </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCorporateBranch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                </telerik:RadComboBox>
                            </div>
                            </div>--%>

             <div class="col-lg-3 col-sm-6">
                <label>Case Received Mode </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCaseReceivedModeSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                </telerik:RadComboBox>
                            </div>
                            </div>
               
              <div class="col-lg-3 col-sm-6">
                <label>Assigned Agent </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbAssignedAgentSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" AutoPostBack="true" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Agent" />
                                
                                        <telerik:RadComboBoxItem Value="1" Text="Mr.Santosh Kumar" />

                                    <telerik:RadComboBoxItem Value="2" Text="Rakesh Kumar" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            
                  <%--<div class="col-md-3">
                        <label>Updated By </label>
                        <div class="selector">
                            <asp:TextBox ID="txtUpdatedBySearch" runat="server" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>--%>

             <div class="col-lg-3 col-sm-6">
                        <label>State </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbStateSearch" runat="server" CheckBoxes="true"  RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" OnSelectedIndexChanged="cmbStateSearch_SelectedIndexChanged" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            <%--<asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>--%>
                            </div>
                        <br />
                    </div>

              <div class="col-lg-3 col-sm-6">
                        <label>City </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCitySearch" CheckBoxes="true" runat="server" RenderMode="Lightweight" DataTextField="DistrictName" DataValueField="DistrictId" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            </div>
                        <br />
                    </div>
             
             <%--<div class="col-md-4">
                        <label>Case Effective Date (MM-DD-YYYY) </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpCaseEffectivedate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server"></telerik:RadDateRangePicker>
                            </div>
                        <br />
                    </div>--%>
             <div class="col-lg-3 col-sm-6">
                        <label>Mobile Number </label>
                        <div class="selector">
                            <asp:TextBox ID="txtMobileNoSearch" runat="server" placeholder="Mobile Number" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>
             <div class="col-lg-3 col-sm-6">
                        <label>Employee Name </label>
                        <div class="selector">
                            <asp:TextBox ID="txtemplolyeeNameSearch" runat="server" placeholder="Employee Name" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            </div>
                      
                    </div>
               </div>
           
             <div class="row">

                 <div class="col-lg-3 col-sm-6">
                        <label>Case Type </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCaseTypeSearch" CssClass="Combo" RenderMode="Lightweight" runat="server"> 
                                <Items>
                                     <telerik:RadComboBoxItem Text="Select Case Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Main" Value="1" />
                                     <telerik:RadComboBoxItem Text="Additional" Value="2" />
                                 </Items>
                            </telerik:RadComboBox>
                            </div>
                      
                    </div>

                 <div class="col-lg-3 col-sm-6">
                        <label>Payment Type </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbPaymentTypeSearch" CssClass="Combo" RenderMode="Lightweight" runat="server"> 
                                <Items>
                                     <telerik:RadComboBoxItem Text="Select Payment Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Corporate Paid" Value="1" />
                                     <telerik:RadComboBoxItem Text="Customer Paid" Value="2" />
                                 </Items>
                            </telerik:RadComboBox>
                            </div>
                      
                    </div>

             
                         <div class="col-lg-3 col-sm-6">
                        <label>Follow Up Date (MM-DD-YYYY) </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpFollowupdate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server" ></telerik:RadDateRangePicker>
                            <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="Follow Up Date (MM-DD-YYYY)" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_CaseId_TextChanged"></asp:TextBox>--%>
                            </div>
                        
                    </div>
                 </div>
             <div class="row">

                 <div class="col-lg-3 col-sm-6">
                        <label>Customer Profile Type </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCustomerProfileTypeSearch" CssClass="Combo" RenderMode="Lightweight" runat="server"> 
                                <Items>
                                     <telerik:RadComboBoxItem Text="Select Profile Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Normal" Value="1" />
                                     <telerik:RadComboBoxItem Text="HNI" Value="2" />
                                 </Items>
                            </telerik:RadComboBox>
                            </div>
                      
                    </div>
                 
             <div class="col-lg-3 col-sm-6">
                        <label>Case Receive Date (MM-DD-YYYY) </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpCaseReceivedate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server"></telerik:RadDateRangePicker>
                            </div>
                        
                    </div>
              </div>
                     
                        
                    
                       
                      </div>

                      <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px; " align="center">
             
               <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAdvanced" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Advanced Search" OnClick="btnAdvanced_Click" Width="200" />
                
         
         </div></div>
                 
                 <div class="form-group" style="padding:10px; padding-top:20px; margin-top:40px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none; overflow:auto;">
                     
                 </div>
                 <div class="container"   style="overflow:auto">
                     <div class="form-group">
                         <table style="width:auto">
                             <tr>
                                 <td>
                                     <telerik:RadGrid ID="rgvConsultantCaseAppointmentDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvConsultantCaseAppointmentDetails_ItemCommand" OnNeedDataSource="rgvConsultantCaseAppointmentDetails_NeedDataSource"
                         OnPageIndexChanged="rgvConsultantCaseAppointmentDetails_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkCaseId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'></asp:LinkButton>
                                         <asp:Label ID="lblConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationCaseDetailsId")%>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblConsultationAppointmentDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationCaseAppointmentDetailsId")%>' Visible="false"></asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Entry Date and Time" SortExpression="CaseEntryDateTime">
                                     <ItemTemplate>
                                         <asp:Label ID="lblCaseEntryDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseEntryDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Customer Profile" SortExpression="CustomerProfile">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCustomerProfile" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerProfile")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Case Received Mode" SortExpression="CaseReceivedMode">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseReceivedMode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseReceivedMode")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="State Name" SortExpression="StateName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblStateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StateName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="District Name" SortExpression="DistrictName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDistrictName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DistrictName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>



                                 <telerik:GridTemplateColumn HeaderText="Corporate Branch" SortExpression="CorporateBranch">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCorporateBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateBranch")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="CorporateName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn HeaderText="Mobile No." SortExpression="MobileNo">
                                        <ItemTemplate>
                                         <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn HeaderText="EMail Id" SortExpression="EMailId">
                                        <ItemTemplate>
                                         <asp:Label ID="lblEMailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EMailId")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Consultation Type" SortExpression="ConsultationType">
                                        <ItemTemplate>
                                         <asp:Label ID="lblConsultationType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationType")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Case Type" SortExpression="CaseType">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseType")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Payment Type" SortExpression="PaymentType">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPaymentType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentType")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn HeaderText="Language Preffered" SortExpression="PrefferedLanguage">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPrefferedLanguage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrefferedLanguage")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="FollowUp Date Time" SortExpression="FollowUpDataTime">
                                        <ItemTemplate>
                                         <asp:Label ID="lblFollowUpDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FollowUpDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>


                                 <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatus">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatus")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn HeaderText="Report Status" SortExpression="ReportStatus">
                                        <ItemTemplate>
                                         <asp:Label ID="lblReportStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportStatus")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Appointment Status" SortExpression="AppointmentStatus">
                                        <ItemTemplate>
                                         <asp:Label ID="lblAppointmentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentStatus")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Case For" SortExpression="CaseFor">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseFor")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                  

                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid>
                                 </td>
                             </tr>
                         </table>
                     </div>

                 </div>
             </asp:View>
             <asp:View ID="Save" runat="server">
                    <div class="container">
                        <h4>Case Details </h4>
                     <hr />
                        <div class="row">
                            <div class="form-group" style="padding:10px;">
           <h4>Case Management </h4>
            <hr />
            <div class="col-lg-3 col-sm-6">
                        <label>Case ID/TA code test </label>
                        <div class="selector">
                             <asp:Label ID="lblCaseId" runat="server" TextMode="SingleLine"  class="form-control required" ReadOnly="true"></asp:Label>
                             
                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Entry Date & Time  </label>
                        <div class="selector">
                            <%-- <asp:TextBox ID="txtCaseEntryDate" runat="server" TextMode="DateTime" class="form-control required" ReadOnly="true" ></asp:TextBox>--%>
                             <telerik:RadDateTimePicker ID="dtpCaseEntryDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" Enabled="false" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Welleazy Branch  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbBranch" RenderMode="Lightweight" Filter="Contains" Enabled="false" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="BranchName" DataValueField="BranchId" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                    <telerik:RadComboBoxItem Value="1" Text="WX-Bangalore" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="cmbBranch" Enabled="false" ForeColor="Red" ErrorMessage="Please Select Branch Name" ValidationGroup="Case" InitialValue="Select Branch"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Assigned Executive  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="cmbAssignExecutive" runat="server" RenderMode="Lightweight" Enabled="false" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Executive" />
                                    <telerik:RadComboBoxItem Value="1" Text="Test1" />
                                </Items>
                                
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvExecutive" runat="server" ControlToValidate="cmbAssignExecutive" ForeColor="Red" ErrorMessage="Please Select Status" Enabled="true" ValidationGroup="Case" InitialValue="Select Executive"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Rec'd Mode </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCaseMode" runat="server" RenderMode="Lightweight" Enabled="false" CssClass="Combo" AppendDataBoundItems="True" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Mode" />
                               
                                
                                        <telerik:RadComboBoxItem Value="1" Text="Email" />
                                
                                        <telerik:RadComboBoxItem Value="2" Text="SMS" />
                              
                                        <telerik:RadComboBoxItem Value="3" Text="Call" />
                               
                                        <telerik:RadComboBoxItem Value="4" Text="Client Online Updations" />
                                </Items>

                            </telerik:RadComboBox>
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Rec'd Date & Time  </label>
                        <div class="selector">
                             <%--<asp:TextBox ID="txtCaseRecDateTime" runat="server" TextMode="DateTime" class="form-control required" ></asp:TextBox>--%>
                            <telerik:RadDateTimePicker ID="dtpCaseRecordedDateTime" RenderMode="Lightweight" Enabled="false" Filter="Contains" CssClass="Combo" runat="server" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                             
                        </div>
                    </div>
        </div>
                        </div>
                        <h4>Client Details </h4>
                     <hr />
            <div class="row" >



                <div class="col-lg-3 col-sm-6">
                     <label>
                         Corporate Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateName" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" AutoPostBack="true" OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" DataTextField="CorporateName" DataValueField="CorporateId" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Corporate Name" Value="0" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ErrorMessage="Please Select  Corporate Name" ForeColor="Red" InitialValue="Select Corporate Name" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                         <label>
                         Branch Id <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateBranchId" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Branch Id" Value="0" />
                                     <telerik:RadComboBoxItem Text="CB" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ErrorMessage="Please Select Branch Id" ForeColor="Red" InitialValue="Select Branch Id" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Services Offered <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbServicesOffered" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Services" Value="0" />
                                     <telerik:RadComboBoxItem Text="Video Consultation" Value="1" />
                                     <telerik:RadComboBoxItem Text="Tele Consultation" Value="2" />
                                     <telerik:RadComboBoxItem Text="Chat Consultation" Value="3" />
                                     <telerik:RadComboBoxItem Text="NRI Consultation" Value="4" />
                                     <telerik:RadComboBoxItem Text="Second Opinion" Value="5" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbServicesOffered" runat="server" ControlToValidate="cmbServicesOffered" ErrorMessage="Please Select Services" ForeColor="Red" InitialValue="Select Services" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                </div>
            <h4>Employee Details </h4>
                     <hr />
            <div class="row">
                     
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Mobile Number <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" Enabled="true" ErrorMessage="Please Enter Mobile No" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Employee Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Enabled="true" ErrorMessage="Please Enter Employee Name" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Gender <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbGender" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Gender" Value="0" />
                                     <telerik:RadComboBoxItem Text="Male" Value="1" />
                                     <telerik:RadComboBoxItem Text="Female" Value="2" />
                                     <telerik:RadComboBoxItem Text="TransGender" Value="3" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="cmbGender"  ErrorMessage="Please Select Gender" ForeColor="Red" InitialValue="Select Gender" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Employee Email Id<span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" Enabled="true" ErrorMessage="Please Enter Email Id" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                         
                     </div>
                 </div>
            
           <div class="row">
               <div class="col-lg-3 col-sm-6">
                         <label>
                         No. Of Free Consultations <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfFreeConsultations" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         No Of Consultations Recored <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfConsultationRecorded" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
           </div>
            <br />

              <h4>Case Details </h4>
                     <hr />
            <div class="row">
                <div class="col-lg-3 col-sm-6">
                         <label>
                         Consultation Type <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbConsultationType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Consultation Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Tele" Value="1" />
                                     <telerik:RadComboBoxItem Text="Video" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvConsultationType" runat="server" ControlToValidate="cmbConsultationType" Enabled="true" ErrorMessage="Please Select Consultation Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Case Type <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Case Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Main" Value="1" />
                                     <telerik:RadComboBoxItem Text="Additional" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="cmbCaseType" Enabled="true" ErrorMessage="Please Select Case Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Payment Type <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbPaymentType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Payment Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Corporate Paid" Value="1" />
                                     <telerik:RadComboBoxItem Text="Customer Paid" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvPaymentType" runat="server" ControlToValidate="cmbPaymentType" Enabled="true" ErrorMessage="Please Select Payment Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Case For <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseFor" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Case For" Value="0" />
                                     <telerik:RadComboBoxItem Text="Self" Value="1" />
                                     <telerik:RadComboBoxItem Text="Dependent" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="cmbCaseFor" Enabled="true" ErrorMessage="Please Select Case For" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                             
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Customer Profile <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCustomerProfile" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Customer Profile" Value="0" />
                                     <telerik:RadComboBoxItem Text="Normal" Value="1" />
                                     <telerik:RadComboBoxItem Text="HNI" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCustomerProfile" runat="server" ControlToValidate="cmbCustomerProfile" Enabled="true" ErrorMessage="Please Select Customer Profile" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>

            </div>
           
            <h4>Doctor Details </h4>
                     <hr />
            <div class="row">
                <%--<div class="col-lg-3 col-sm-6">
                         <label>
                         Preffered Language <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbLanguage" runat="server" CheckBoxes="true" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="cmbLanguage_SelectedIndexChanged"  CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Language" Value="0" />
                                     
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" Enabled="true" ErrorMessage="Please Select Language" ForeColor="Red" InitialValue="Select Language" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>--%>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Appointment Date and Time <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpAppointmentDateTime" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvAppointmentDate" runat="server" ControlToValidate="dtpAppointmentDateTime" Enabled="true" ErrorMessage="Please Select Date" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <%--<div class="col-lg-3 col-sm-6">
                         <label>
                         Doctor Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbDoctorName" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Doctor" Value="0" />
                                     <%--<telerik:RadComboBoxItem Text="Test" Value="1" />
                                     <telerik:RadComboBoxItem Text="Test2" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" InitialValue="Select Doctor" ControlToValidate="cmbDoctorName" Enabled="true" ErrorMessage="Please Select Doctor Name" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>--%>
        
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Appointment Status <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbAppointmentStatus" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Appointment Status" Value="0" />
                                     <telerik:RadComboBoxItem Text="Scheduled" Value="1" />
                                     <telerik:RadComboBoxItem Text="Completed" Value="2" />
                                     <telerik:RadComboBoxItem Text="Re-Schedule" Value="3" />
                                     <telerik:RadComboBoxItem Text="Cancelled" Value="4" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvAppointmentStatus" runat="server"  ControlToValidate="cmbAppointmentStatus" Enabled="true" ErrorMessage="Please Select Status" ForeColor="Red" InitialValue="Select Appointment Status" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
            </div>
                 
                <div class="row">
                
                         <asp:Button ID="btnSave" runat="server" BackColor="#113d7a" BorderStyle="None" CausesValidation="true" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSave_Click" Text="Save" ValidationGroup="Test" />
                     &nbsp;&nbsp;
&nbsp;                         <asp:Button ID="btnCancel" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                 </div>
                        </div>
             </asp:View>
         </asp:MultiView>
         </span>
         </div>
                    <%--  </span>
         </ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="rgvConsultantCaseAppointmentDetails" />
               
              </Triggers>
        </asp:UpdatePanel>--%>
    <div id="MyPopup" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                     
                                        <h4 class="modal-title"></h4>
                                    </div>
                                    <div class="modal-body">
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
</asp:Content>



