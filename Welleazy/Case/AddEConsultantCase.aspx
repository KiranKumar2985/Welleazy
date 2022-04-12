<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="AddEConsultantCase.aspx.cs" Inherits="Welleazy.Case.AddEConsultantCase" %>






<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Add E-Consultant Case</title>
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

    
  
    <%--<asp:UpdatePanel ID="upEConsultant" runat="server">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <h5>
            <%--<asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Case/Case.aspx"  ForeColor="#0033cc">Case List</asp:LinkButton> >> Add E-Consultant Case</h5>--%>

         
                                   <div class="line"></div>

         


             
                 <div class="container">
        <div class="row" >
           <h4>Case Management </h4>
            <hr />
            <div class="col-lg-3 col-sm-6">
                        <label>Case ID/TA code test </label>
                        <div class="selector">
                             <asp:TextBox ID="txtCaseId" runat="server" TextMode="SingleLine" placeholder="Auto Generate" class="form-control required" ReadOnly="true"></asp:TextBox>
                             
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
                            <telerik:RadComboBox ID="cmbBranch" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="BranchName" DataValueField="BranchId" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                    <telerik:RadComboBoxItem Value="1" Text="WX-Bangalore" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="cmbBranch" ForeColor="Red" ErrorMessage="Please Select Branch Name" ValidationGroup="Case" InitialValue="Select Branch"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Assigned Executive  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="cmbAssignExecutive" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
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
                            <telerik:RadComboBox ID="cmbCaseMode" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="True" Filter="Contains" >
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
                            <telerik:RadDateTimePicker ID="dtpCaseRecordedDateTime" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                             
                        </div>
                    </div>
        </div>  
                     
                
        <div class="row">
            <h4>Clients Details </h4>
            <hr />
            <div class="col-lg-3 col-sm-6">
                        <label>Corporate Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select  Corporate Name" ValidationGroup="Case" InitialValue="Select Corporate Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Branch Id  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCorporateBranchId" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch Id" />
                                    <telerik:RadComboBoxItem  Value="1" Text="CB"/>
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ForeColor="Red" ErrorMessage="Please Select Branch Id" ValidationGroup="Case" InitialValue="Select Branch Id"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Services Offered  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbServicesOffered" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Services" />
                                    <telerik:RadComboBoxItem Value="1" Text="Test Service" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvrcbServicesOffered" runat="server" ControlToValidate="cmbServicesOffered" ForeColor="Red" ErrorMessage="Please Select Services" ValidationGroup="Case" InitialValue="Select Services"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
        </div>
                     <h4>Employee Details </h4>
            <hr />
        <div class="row">
            
            <div class="col-lg-3 col-sm-6">
                        <label>Mobile Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" ErrorMessage="Please Enter Mobile No" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Employee Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ForeColor="Red" ErrorMessage="Please Enter Employee Name" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Gender <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbGender" RenderMode="Lightweight"  Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Gender" />
                                    <telerik:RadComboBoxItem Value="1" Text="Male" />
                                    <telerik:RadComboBoxItem Value="2" Text="Female" />
                                    <telerik:RadComboBoxItem Value="3" Text="TransGender" />
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="cmbGender" InitialValue="Select Gender" ForeColor="Red" ErrorMessage="Please Select Gender" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Employee Email Id<span class="mandatory">*</span> </label>
                        <div class="selector">
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" ForeColor="Red" ErrorMessage="Please Enter Email Id" 
                                Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            </div>
                    </div>
        
        
           <div class="col-lg-3 col-sm-6">
                        <label>No. Of Free Consultations <span class="mandatory">*</span>  </label>
                        <div class="selector">
                             <asp:TextBox ID="txtNoOfFreeConsultations" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>No Of Consultations Recored <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <asp:TextBox ID="txtNoOfConsultationRecorded" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                            <asp:RequiredFieldValidator Id="rfvConsultationRecord" runat="server" ControlToValidate="txtNoOfConsultationRecorded" ErrorMessage="Please Enter Consultation Recorded"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
           
            

</div>
        
         
         <div class="row">
             <h4>Case Details </h4>
           <div class="col-lg-3 col-sm-6">
                        <label>Consultation Type <span class="mandatory">*</span>  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbConsultationType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Consultation Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Tele" />
                                    <telerik:RadComboBoxItem Value="2" Text="Video" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvConsultationType" runat="server" ControlToValidate="cmbConsultationType" ForeColor="Red" ErrorMessage="Please Select Consultation Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Type <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Main" />
                                    <telerik:RadComboBoxItem Value="2" Text="Additional" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="cmbCaseType" ForeColor="Red" ErrorMessage="Please Select Case Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Payment Type <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbPaymentType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Payment Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Corporate Paid" />
                                    <telerik:RadComboBoxItem Value="2" Text="Customer Paid" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvPaymentType" runat="server" ControlToValidate="cmbPaymentType" ForeColor="Red" ErrorMessage="Please Select Payment Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Case For <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseFor" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case For" />
                                    <telerik:RadComboBoxItem Value="1" Text="Self" />
                                    <telerik:RadComboBoxItem Value="2" Text="Dependent" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="cmbCaseFor" ForeColor="Red" ErrorMessage="Please Select Case For" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Customer Profile <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCustomerProfile" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Customer Profile" />
                                    <telerik:RadComboBoxItem Value="1" Text="Normal" />
                                    <telerik:RadComboBoxItem Value="2" Text="HNI" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCustomerProfile" runat="server" ControlToValidate="cmbCustomerProfile" ForeColor="Red" ErrorMessage="Please Select Customer Profile" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
           
            
        </div>


         <div class="row">
             <h4>Doctor Details </h4>
           <div class="col-lg-3 col-sm-6">
                        <label>Preffered Language <span class="mandatory">*</span>  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbLanguage" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Language" />
                                    <telerik:RadComboBoxItem Value="1" Text="English" />
                                    <telerik:RadComboBoxItem Value="2" Text="Hindi" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" InitialValue="Select Language" ForeColor="Red" ErrorMessage="Please Select Language" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Doctor Date and Time <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpDoctorDateTime" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="dtpDoctorDateTime" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Doctor Name <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbDoctorName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Doctor" />
                                    <telerik:RadComboBoxItem Value="1" Text="Test" />
                                    <telerik:RadComboBoxItem Value="2" Text="Test2" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" ControlToValidate="cmbDoctorName" ForeColor="Red" ErrorMessage="Please Select Doctor Name" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Doctor Qualification <span class="mandatory">*</span></label>
                        
                            <%-- <asp:TextBox ID="txtDoctorQualification" runat="server" TextMode="MultiLine"></asp:TextBox>--%>

                 <telerik:RadComboBox ID="cmbDoctorQualification" RenderMode="Lightweight" runat="server">
                     <Items>
                         <telerik:RadComboBoxItem Value="0" Text="Select Qualification" />
                         <telerik:RadComboBoxItem Value="1" Text="MBBS" /> 
                     </Items>
                 </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvDoctorQualification" InitialValue="Select Qualification" runat="server" ControlToValidate="cmbDoctorQualification" ForeColor="Red" ErrorMessage="Please Select Qualification" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                    
                    </div>

             
           
            
        </div>

         <div class="row">
            
           <div class="col-lg-3 col-sm-6">
                        <label>Case Status <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseStatus" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                                    <telerik:RadComboBoxItem Value="1" Text="Pending" />
                                    <telerik:RadComboBoxItem Value="2" Text="Closed" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseStatus" runat="server" ControlToValidate="cmbCaseStatus" InitialValue="Select Status" ForeColor="Red" ErrorMessage="Please Select Language" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Follow Up Date and Time <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpFollowUp" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvFollowUp" runat="server" ControlToValidate="dtpFollowUp" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>

              <div class="col-lg-3 col-sm-6">
                        <label>Remarks <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" ForeColor="Red" ErrorMessage="Please Enter Remarks" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            
             </div>


        <div class="row">
           
           <div class="col-md-2">
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Test" />
          &nbsp;&nbsp;
            
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                
            </div>
        </div>
                          </div>
           
         </div>
         <%--</ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="rgvEConsultancyCaseDetails" />
               
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

