<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="ConsultationCaseAppointmentDetailsHistory.aspx.cs" Inherits="Welleazy.Appointment.ConsultationCaseAppointmentDetailsHistory" %>






<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Consultant Case Appointment Details History</title>
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
                                     <telerik:RadGrid ID="rgvConsultantCaseAppointmentDetailsHistory" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvConsultantCaseAppointmentDetailsHistory_ItemCommand" OnNeedDataSource="rgvConsultantCaseAppointmentDetailsHistory_NeedDataSource"
                         OnPageIndexChanged="rgvConsultantCaseAppointmentDetailsHistory_PageIndexChanged" Skin="Bootstrap">
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
             
         </asp:MultiView>
        
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



