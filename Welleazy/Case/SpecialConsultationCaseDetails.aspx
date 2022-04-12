<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="SpecialConsultationCaseDetails.aspx.cs" Inherits="Welleazy.Test.SpecialConsultationCaseDetails" %>







<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Add Specialities-Consultant Case</title>
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

    
  
    
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        
            <%--<asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Case/Case.aspx"  ForeColor="#0033cc">Case List</asp:LinkButton> >> Add E-Consultant Case</h5>--%>

         
                                   <div class="line"></div>

         
            
         

             
                 <%-- <table  style="align-items:flex-end; width:100%">
                      <tr style="vertical-align">
                          <td><asp:ImageButton ID="ImgBtnAdd" runat="server" Text="Add" ImageUrl="~/images/Add Image.jpg" Width="45px" OnClick="ImgBtnAdd_Click"/></td>
                      </tr>
                  </table>--%>

                 
                  

                 

                  <div class="container">
                     
                     <%-- <div class="row">
                           <span runat="server" id="AddSpecialistConsultantCaseButton" class="glyphicon glyphicon-plus" style="background: #113d7a; color: white; float: right; font-family: Montserrat; border-radius: 3px; padding-left: 5px;">
         
                <asp:Button ID="btnSpecialistConsultant" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None"  CssClass="Login_btn btn" OnClick="btnSpecialConsultant_Click" Text="Add Case" />
           </span>
                      </div>   --%>  
             
                   
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
                      <br />
                      <div class="row">


                  <telerik:RadGrid ID="rgvSpecialityConsultancyCaseDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      OnItemCommand="rgvSpecialityConsultancyCaseDetails_ItemCommand" OnNeedDataSource="rgvSpecialityConsultancyCaseDetails_NeedDataSource" OnPageIndexChanged="rgvSpecialityConsultancyCaseDetails_PageIndexChanged"
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Schedule Appointment" >
                                   <ItemTemplate>
                                       <%--<asp:CheckBox ID="chkCaseId" AutoPostBack="true" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" OnCheckedChanged="chkCaseId_CheckedChanged" CommandName="AssignToDoctor" Font-Underline="true"></asp:CheckBox>--%>
                                       <asp:ImageButton ID="ScheduleAppointment" runat="server" ImageUrl="~/images/calender_icon.jpg" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AssignToDoctor" />
                                       <asp:Label ID="lbl_SpecialityConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialityConsultantCaseDetailsId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkCaseId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'></asp:LinkButton>
                                       <asp:Label ID="lblSpecialityConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialityConsultantCaseDetailsId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               


                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="BranchName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lbl_BranchName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Corporate Branch" SortExpression="CorporateBranch">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCorporateBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateBranch")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="EMail Id" SortExpression="EMailId">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEMailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EMailId")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>



                               
                               <telerik:GridTemplateColumn HeaderText="No. Of Free Consultations" SortExpression="NoOfFreeConsultations">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblNoOfFreeConsultations" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfFreeConsultations")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="No. Of Consultation Received" SortExpression="NoOfConsultationReceived">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblNoOfConsultationReceived" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfConsultationReceived")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Consultation Type" SortExpression="ConsultationType">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblConsultationType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationType")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Case Type" SortExpression="CaseType">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCaseType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseType")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Payment Type" SortExpression="PaymentType">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblPaymentType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentType")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Case For" SortExpression="CaseFor">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseFor")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Customer Profile" SortExpression="CustomerProfile">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCustomerProfile" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerProfile")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>


                               <telerik:GridTemplateColumn HeaderText="Entry Date and Time" SortExpression="CaseEntryDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseEntryDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseEntryDateTime")%>'>
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
                      </div>
              
         </div>
         
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



