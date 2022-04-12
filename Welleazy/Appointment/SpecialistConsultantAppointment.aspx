<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master"  CodeBehind="SpecialistConsultantAppointment.aspx.cs" Inherits="Welleazy.Appointment.SpecialistConsultantAppointment" %>






<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Specalities Consultant Appointment List</title>
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
    <%--<asp:UpdatePanel ID="upEConsultant" runat="server">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <%--<h5>
            Home >> Case Management >> <asp:LinkButton ID="lnlAppointmentList" runat="server" OnClick="lnlAppointmentList_Click" ForeColor="#0033cc">Case List</asp:LinkButton> >> Specalities Consultant Appointment List </h5>
                                   <span style="float:right; font-size:small;">
         <h5>
             <asp:LinkButton ID="lnlScheduleAppointment" runat="server" ForeColor="#0033cc" OnClick="lnlScheduleAppointment_Click"><b><i class="glyphicon glyphicon-plus"></i></b> Schedule Appointment</asp:LinkButton>
         </h5>
         <div class="line">
         </div>--%>

         <br />
         <br />
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


         <asp:MultiView ID="SpecialistConultantApointmentView" runat="server">
             <asp:View ID="View" runat="server">
                 
                 
                 <div class="form-group" style="padding:10px; padding-top:20px; margin-top:40px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none; overflow:auto;">
                     <telerik:RadGrid ID="rgvSpecialistConsultancyAppointmentDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableTheming="true" 
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvSpecialistConsultancyAppointmentDetails_ItemCommand" OnNeedDataSource="rgvSpecialistConsultancyAppointmentDetails_NeedDataSource"
                         OnPageIndexChanged="rgvSpecialistConsultancyAppointmentDetails_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkCaseId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'></asp:LinkButton>
                                         <asp:Label ID="lblSpecialistConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialityConsultantCaseDetailsId")%>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblSpecilaistConsultantAppointmentDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialistConsultantAppointmentDetailsId")%>' Visible="false"></asp:Label>
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

                                 <telerik:GridTemplateColumn HeaderText="FollowUp Date Time" SortExpression="FollowUpDateTime">
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
                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid>
                 </div>
             </asp:View>
             <asp:View ID="Save" runat="server">
                 <div class="form-group" style="padding:10px; margin-top:-20px;">
                     <h4>Schedule Appointment </h4>
                     <hr />
                     <div class="col-md-3">

                         
                         <label>
                         Case ID/TA code test
                         </label>
                         <div>
                             <asp:Label ID="lblCaseId" runat="server" class="form-control required"></asp:Label>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Case Entry Date &amp; Time
                         </label>
                         <div class="selector">
                             <%-- <asp:TextBox ID="txtCaseEntryDate" runat="server" TextMode="DateTime" class="form-control required" ReadOnly="true" ></asp:TextBox>--%>
                             <telerik:RadDateTimePicker ID="dtpCaseEntryDate" runat="server" CssClass="Combo" Enabled="false" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Welleazy Branch <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbBranch" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" DataTextField="BranchName" DataValueField="BranchId" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Branch" Value="0" />
                                     <telerik:RadComboBoxItem Text="WX-Bangalore" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="cmbBranch" ErrorMessage="Please Select Branch Name" ForeColor="Red" InitialValue="Select Branch" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Assigned Executive <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbAssignExecutive" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Executive" Value="0" />
                                     <telerik:RadComboBoxItem Text="Test1" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvExecutive" runat="server" ControlToValidate="cmbAssignExecutive" Enabled="true" ErrorMessage="Please Select Status" ForeColor="Red" InitialValue="Select Executive" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Case Rec&#39;d Mode
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseMode" runat="server" AppendDataBoundItems="True" CssClass="Combo" Enabled="false" Filter="Contains" RenderMode="Lightweight">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Case Mode" Value="0" />
                                     <telerik:RadComboBoxItem Text="Email" Value="1" />
                                     <telerik:RadComboBoxItem Text="SMS" Value="2" />
                                     <telerik:RadComboBoxItem Text="Call" Value="3" />
                                     <telerik:RadComboBoxItem Text="Client Online Updations" Value="4" />
                                 </Items>
                             </telerik:RadComboBox>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Case Rec&#39;d Date &amp; Time
                         </label>
                         <div class="selector">
                             <%--<asp:TextBox ID="txtCaseRecDateTime" runat="server" TextMode="DateTime" class="form-control required" ></asp:TextBox>--%>
                             <telerik:RadDateTimePicker ID="dtpCaseRecordedDateTime" Enabled="false" runat="server" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                         </div>
                     </div>
                 </div>
                 <div class="form-group" style="padding:10px; margin-top:140px;">
                     <h4>Client Details </h4>
                     <hr />
                     <div class="col-md-3">
                         <label>
                         Corporate Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateName" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" DataTextField="CorporateName" DataValueField="CorporateId" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Corporate Name" Value="0" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ErrorMessage="Please Select  Corporate Name" ForeColor="Red" InitialValue="Select Corporate Name" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Branch Id <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateBranchId" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Branch Id" Value="0" />
                                     <telerik:RadComboBoxItem Text="CB" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ErrorMessage="Please Select Branch Id" ForeColor="Red" InitialValue="Select Branch Id" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Services Offered <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbServicesOffered" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Services" Value="0" />
                                     <telerik:RadComboBoxItem Text="Test Service" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbServicesOffered" runat="server" ControlToValidate="cmbServicesOffered" ErrorMessage="Please Select Services" ForeColor="Red" InitialValue="Select Services" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                 </div>
                 <div class="form-group" style="padding:10px; margin-top:70px;">
                     <h4>Employee Details </h4>
                     <hr />
                     <div class="col-md-3">
                         <label>
                         Mobile Number <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" Enabled="true" ErrorMessage="Please Enter Mobile No" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Employee Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Enabled="true" ErrorMessage="Please Enter Employee Name" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
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
                             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="cmbGender" Enabled="true" ErrorMessage="Please Select Gender" ForeColor="Red" InitialValue="Select Gender" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Employee Email Id<span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" Enabled="true" ErrorMessage="Please Enter Email Id" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                          <br />
                             <br />
                     </div>
                 </div>
                 <div class="form-group" style="padding:10px;">
                     <div class="col-md-3">
                         <label>
                         No. Of Free Consultations <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfFreeConsultations" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <label>
                         No Of Consultations Recored <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfConsultationRecorded" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
                 </div>
                 <div class="form-group" style="padding:10px; margin-top:140px;">
                     <h4>Case Details </h4>
                     <hr />
                     <div class="col-md-3">
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
                     <div class="col-md-3">
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
                     <div class="col-md-3">
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
                     <div class="col-md-3">
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
                             <br />
                             <br />
                         </div>
                     </div>
                     <div class="col-md-3">
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
                 <div class="form-group" style="padding:10px; margin-top:160px;">
                     <h4>Doctor Details </h4>
                     <hr />
                     <div class="col-md-3">
                         <label>
                         Preffered Language <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbLanguage" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Language" Value="0" />
                                     <telerik:RadComboBoxItem Text="English" Value="1" />
                                     <telerik:RadComboBoxItem Text="Hindi" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" Enabled="true" ErrorMessage="Please Select Language" ForeColor="Red" InitialValue="Select Language" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Appointment Date and Time <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpAppointmentDateTime" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvAppointmentDate" runat="server" ControlToValidate="dtpAppointmentDateTime" Enabled="true" ErrorMessage="Please Select Date" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Doctor Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbDoctorName" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Doctor" Value="0" />
                                     <telerik:RadComboBoxItem Text="Test" Value="1" />
                                     <telerik:RadComboBoxItem Text="Test2" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" ControlToValidate="cmbDoctorName" Enabled="true" ErrorMessage="Please Select Doctor Name" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                     <div class="col-md-3">
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
                             <asp:RequiredFieldValidator ID="rfvAppointmentStatus" runat="server" ControlToValidate="cmbAppointmentStatus" Enabled="true" ErrorMessage="Please Select Status" ForeColor="Red" InitialValue="Select Appointment Status" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
        


                <%-- <div class="form-group" style="padding:10px;">
                     <div class="col-md-3">
                         <label>
                         Appointment Date and Time <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadDateTimePicker runat="server" ID="dtpAppopintDateTime"></telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvAppointmentDate" runat="server" ControlToValidate="dtpAppopintDateTime" Enabled="true" ErrorMessage="Select Appointment Date and Time" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     
                     
                 </div>--%>


                 <%--<div class="form-group" style="padding:10px;">
                     <div class="col-md-3">
                         <label>
                         Case Status <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseStatus" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Status" Value="0" />
                                     <telerik:RadComboBoxItem Text="Pending" Value="1" />
                                     <telerik:RadComboBoxItem Text="Closed" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseStatus" runat="server" ControlToValidate="cmbCaseStatus" Enabled="true" ErrorMessage="Please Select Language" ForeColor="Red" InitialValue="Select Status" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Follow Up Date and Time <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpFollowUp" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvFollowUp" runat="server" ControlToValidate="dtpFollowUp" Enabled="true" ErrorMessage="Please Select Date" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Remarks <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control required" TextMode="MultiLine"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" Enabled="true" ErrorMessage="Please Enter Remarks" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                 </div>--%>
                 <div class="form-group" style="padding:10px; margin-top:140px; text-align:center;">
                     <div class="col-md-2">
                         <asp:Button ID="btnSave" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSave_Click" Text="Save" ValidationGroup="Test" />
                     </div>
                     <div class="col-md-2">
                         <asp:Button ID="btnCancel" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                     </div>
                 </div>
             </asp:View>
         </asp:MultiView>
         </span>
         </div>
              <%--        </span>
         </ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="rgvSpecialistConsultancyAppointmentDetails" />
               
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

