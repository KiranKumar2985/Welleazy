<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="EConsultantClosedAppointment.aspx.cs" Inherits="Welleazy.Appointment.EConsultantClosedAppointment" %>






<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | E-Consultant Closed Appointment List</title>
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

    
    <asp:UpdatePanel ID="upEConsultant" runat="server">
                  <ContentTemplate>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <h5>
            Home >> Case Management >> <asp:LinkButton ID="lnlAppointmentList" runat="server" OnClick="lnlAppointmentList_Click" ForeColor="#0033cc">Case List</asp:LinkButton> >> E-Consultant Closed Appointment List </h5>
                                   <span style="float:right; font-size:small;">
         <h5>
             <%--<asp:LinkButton ID="lnlScheduleAppointment" runat="server" ForeColor="#0033cc" OnClick="lnlScheduleAppointment_Click"><b><i class="glyphicon glyphicon-plus"></i></b> Schedule Appointment</asp:LinkButton>--%>
         </h5>
         <div class="line">
         </div>

                                       <div class="row">
                      

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
            
                  <div class="col-md-3">
                        <label>Application No. </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>
              <div class="col-md-3">
                        <label>Case Id/TA Code </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_CaseId" runat="server" placeholder="Case Id/TA Code" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
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
                            <telerik:RadComboBox ID="rcbAssignedAgentSearch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" AutoPostBack="true" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Agent" />
                                
                                        <telerik:RadComboBoxItem Value="Mr Dixit" Text="Mr Dixit" />

                                    <telerik:RadComboBoxItem Value="Rakesh Kumar" Text="Rakesh Kumar" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            
                  <div class="col-md-3">
                        <label>Updated By </label>
                        <div class="selector">
                            <asp:TextBox ID="txtUpdatedBySearch" runat="server" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>
              <div class="col-md-3">
                        <label>City </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCitySearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
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
                        
                    </div>
             <div class="col-md-4">
                        <label>Case Effective Date (MM-DD-YYYY) </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="rdrpCaseEffectivedate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server"></telerik:RadDateRangePicker>
                            </div>
                        <br />
                    </div>
             <div class="col-md-3">
                        <label>Mobile Number </label>
                        <div class="selector">
                            <asp:TextBox ID="txtMobileNoSearch" runat="server" placeholder="Mobile Number" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>
             <div class="col-md-3">
                        <label>Case Owner Name </label>
                        <div class="selector">
                            <asp:TextBox ID="txtCaseOwnerSearch" runat="server" placeholder="Case Owner Name" TextMode="SingleLine" class="form-control required"></asp:TextBox><br /><br />
                            </div>
                        
                    </div>
              </div>

                      &nbsp;&nbsp;
                      
                        <%--<asp:Button ID="btnGo" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Go" CssClass="Login_btn btn" OnClick="btnGo_Click" ></asp:Button>--%>
                    
                       
                      </div>

                      <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px; " align="center">
             
               <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAdvanced" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Advanced Search" OnClick="btnAdvanced_Click" Width="200" />
                
         
         </div>

         <asp:MultiView ID="EConultantCloseApointmentView" runat="server">
             <asp:View ID="View" runat="server">
                 
                 
                 <div class="form-group" style="padding:10px; padding-top:20px; margin-top:40px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none; overflow:auto;">
                     <telerik:RadGrid ID="rgvEConsultancyAppointmentDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableTheming="true" 
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvEConsultancyAppointmentDetails_ItemCommand" OnNeedDataSource="rgvEConsultancyAppointmentDetails_NeedDataSource"
                         OnPageIndexChanged="rgvEConsultancyAppointmentDetails_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkCaseId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'></asp:LinkButton>
                                         <asp:Label ID="lblEConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EConsultantCaseDetailsId")%>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblEConsultantAppointmentDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EConsultantAppointmentDetailsId")%>' Visible="false"></asp:Label>
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

                                 <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
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

                                  <telerik:GridTemplateColumn HeaderText="Language Preffered" SortExpression="LanguageDescription">
                                        <ItemTemplate>
                                         <asp:Label ID="lblLanguageDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LanguageDescription")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="FollowUp Date Time" SortExpression="FollowUpDataTime">
                                        <ItemTemplate>
                                         <asp:Label ID="lblFollowUpDataTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FollowUpDataTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>


                                 <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatus">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatus")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid>
                 </div>
             </asp:View>
             
         </asp:MultiView>
         </span>
         </div>
                      </span>
         </ContentTemplate>
          <Triggers>
                <%--<asp:PostBackTrigger ControlID="rgvEConsultancyAppointmentDetails" />--%>
               
              </Triggers>
        </asp:UpdatePanel>
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

