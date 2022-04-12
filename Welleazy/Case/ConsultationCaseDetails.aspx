<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" MaintainScrollPositionOnPostBack="true" CodeBehind="ConsultationCaseDetails.aspx.cs" Inherits="Welleazy.Case.ConsultationCaseDetails" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Add Consultation Case Details</title>
   <%-- <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />--%>
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
        function ShowSearchPopup() {
            //$("#MyPopup .modal-title").html(title);
            //$("#MyPopup .modal-body").html(body);
            $("#SearchPopUp").modal("show");
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


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"> </script>   
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>--%>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />



    
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
      
            <%--<asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Case/Case.aspx"  ForeColor="#0033cc">Case List</asp:LinkButton> >> Add E-Consultant Case</h5>--%>

         
                                   <div class="line"></div>

         

        <div class="form-group" >
                         <div class="col-lg-3 col-sm-6">
                             <label>Consultation Type  <span class="mandatory">*</span></label>
                             <div class="selector">
                             <telerik:RadComboBox ID="ConsultationType" runat="server" AppendDataBoundItems="true" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="ConsultationType_SelectedIndexChanged" RenderMode="Lightweight" Filter="Contains" CssClass="Combo">
                                 <Items>
                                     <telerik:RadComboBoxItem Value="0" Text="Select Consultation Type" />
                                     <telerik:RadComboBoxItem Value="1" Text="E-Consultation" />
                                     <telerik:RadComboBoxItem Value="22" Text="Specialities Consultation" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvConsultation_Type" runat="server" ControlToValidate="ConsultationType" ErrorMessage="Select Consultation Type" 
                                 InitialValue="Select Consultation Type" ValidationGroup="Test" ForeColor="Red" ></asp:RequiredFieldValidator>
                                 </div>
                         </div>
                     </div>

         <telerik:RadStyleSheetManager ID="RadCssManager" runat="server">
        <StyleSheets>
            <telerik:StyleSheetReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Skins.RadDatePicker.css" />
            <telerik:StyleSheetReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Skins.Telerik.RadDatePicker.Telerik.css" />
        </StyleSheets>
    </telerik:RadStyleSheetManager>

        <div class="form-group" style="margin-top:130px; margin-left:10px; ">
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
                             <telerik:RadDateTimePicker ID="dtpCaseEntryDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" Enabled="false" ValidationGroup="Test">
                                
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Welleazy Branch  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbBranch" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="BranchName" DataValueField="BranchId" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                    <%--<telerik:RadComboBoxItem Value="1" Text="WX-Bangalore" />--%>
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="cmbBranch" ForeColor="Red" ErrorMessage="Please Select Branch Name" ValidationGroup="Test" InitialValue="Select Branch"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Assigned Executive  <span class="mandatory"></span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="cmbAssignExecutive" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Executive" />
                                    <%--<telerik:RadComboBoxItem Value="1" Text="Mr.Santosh Kumar" />--%>
                                </Items>
                                
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvExecutive" runat="server" ControlToValidate="cmbAssignExecutive" ForeColor="Red" ErrorMessage="Please Select Executive" Enabled="false" InitialValue="Select Executive"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Rec'd Mode <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCaseMode" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="True" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Mode" />
                               
                                
                                        <%--<telerik:RadComboBoxItem Value="1" Text="Email" />
                                
                                        <telerik:RadComboBoxItem Value="2" Text="SMS" />
                              
                                        <telerik:RadComboBoxItem Value="3" Text="Call" />
                               
                                        <telerik:RadComboBoxItem Value="4" Text="Client Online Updations" />--%>
                                </Items>

                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseMode" runat="server" ControlToValidate="cmbCaseMode" ForeColor="Red" ErrorMessage="Please Select Case Mode" Enabled="true" ValidationGroup="Test" InitialValue="Select Case Mode"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Rec'd Date & Time <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <%--<asp:TextBox ID="txtCaseRecDateTime" runat="server" TextMode="DateTime" class="form-control required" ></asp:TextBox>--%>
                            <telerik:RadDateTimePicker ID="dtpCaseRecordedDateTime" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" ValidationGroup="Test">
                                
                            </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvCaseRecorededDateTime" runat="server" ControlToValidate="dtpCaseRecordedDateTime" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                          
                        </div>
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>Application No. <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtApplicationNo" runat="server" TextMode="SingleLine" placeholder="Application No." class="form-control required" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApplicationNo" runat="server" ControlToValidate="txtApplicationNo" ForeColor="Red" ErrorMessage="Please Enter Application No" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator> 
                        </div>
                    </div>
        </div>  
                     
                
        <div class="form-group" style="margin-top:200px; margin-left:10px;">
            <h4>Clients Details </h4>
            <hr />
            <div class="col-lg-3 col-sm-6">
                        <label>Corporate Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCorporateName" AutoPostBack="true" CausesValidation="false" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" AppendDataBoundItems="true"  DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select  Corporate Name" ValidationGroup="Test" InitialValue="Select Corporate Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Branch Id  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbCorporateBranchId" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test" AutoPostBack="true" OnSelectedIndexChanged="cmbCorporateBranchId_SelectedIndexChanged" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch Id" />
                                    <%--<telerik:RadComboBoxItem  Value="1" Text="CB"/>--%>
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ForeColor="Red" ErrorMessage="Please Select Branch Id" ValidationGroup="Test" InitialValue="Select Branch Id"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
           <%--<div class="col-lg-3 col-sm-6">
                        <label>Product Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />
                                
                                        <telerik:RadComboBoxItem Value="1" Text="E Consultation" />
                                    <telerik:RadComboBoxItem Value="2" Text="Medical Room Management" />
                                    <telerik:RadComboBoxItem Value="3" Text="Health Check ups" />
                                    <telerik:RadComboBoxItem Value="4" Text="Health Risk Assessment" />
                                    <telerik:RadComboBoxItem Value="5" Text="Wellness Activities" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvproduct" runat="server" ControlToValidate="rcbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
                         </div>
                    </div>--%>
            <div class="col-lg-3 col-sm-6">
                        <label>Services Offered  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="cmbServicesOffered" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Services" />
                                    <%--<telerik:RadComboBoxItem Value="1" Text="Test Service" />--%>
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvrcbServicesOffered" runat="server" ControlToValidate="cmbServicesOffered" ForeColor="Red" ErrorMessage="Please Select Services" ValidationGroup="Test" InitialValue="Select Services"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
        </div>
           
        <div class="form-group" style="margin-top:120px; margin-left:10px;">
                      <h4>Employee Details </h4>
            <hr />
            <div class="col-lg-3 col-sm-6">
                        <label>Mobile Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" Enabled="false" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" ErrorMessage="Please Enter Mobile No" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                
                        <label>Employee Name  <span class="mandatory">*</span></label>
                <span><asp:ImageButton ID="btnSearchEmployeee" Height="20px" Width="25px" ImageUrl="~/images/Search Image.png" runat="server" AlternateText="Search" OnClick="btnSearchEmployeee_Click" /></span>
                        <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" Enabled="false" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ForeColor="Red" ErrorMessage="Please Enter Employee Name" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Gender <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbGender" RenderMode="Lightweight" Enabled="false"  Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
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
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" Enabled="false" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" ForeColor="Red" ErrorMessage="Please Enter Email Id" 
                                Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            </div><br />
                    </div>
              <div class="col-lg-3 col-sm-6">
                        <label>No. Of Free Consultations <span class="mandatory"></span>  </label>
                        <div class="selector">
                             <asp:TextBox ID="txtNoOfFreeConsultations" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNoOfFreeConsultation" runat="server" ControlToValidate="txtNoOfFreeConsultations" ForeColor="Red" ErrorMessage="Please Enter No of Free Consultation" Enabled="false"></asp:RequiredFieldValidator>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>No Of Consultations Recored <span class="mandatory"></span> </label>
                        <div class="selector">
                             <asp:TextBox ID="txtNoOfConsultationRecorded" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConsultationRecord" runat="server" ControlToValidate="txtNoOfConsultationRecorded" ForeColor="Red" ErrorMessage="Please Enter Consultation Recorded" Enabled="false"></asp:RequiredFieldValidator>
                            
                        </div>
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>Id Proof Type <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbIdProof" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains" CssClass="Combo" ValidationGroup="Test">
                                 <Items>
                                     <telerik:RadComboBoxItem Value="0" Text="Select Id Proof Type"/>
                                    <%-- <telerik:RadComboBoxItem Value="1" Text="Aadhar Card" />--%>
                                    <%-- <telerik:RadComboBoxItem Value="1" Text="Aadhar Card" />--%>
                                 </Items>
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCmbIdProof" runat="server" ControlToValidate="cmbIdProof" InitialValue="Select Id Proof Type" ForeColor="Red" ErrorMessage="Please Select Id Proof Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            
                        </div>
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>State <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbState" runat="server" RenderMode="Lightweight" Enabled="false" AppendDataBoundItems="true" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="cmbState_SelectedIndexChanged"  CssClass="Combo" Filter="Contains" ValidationGroup="Test">
                                 <Items>
                                     <telerik:RadComboBoxItem Value="0" Text="Select State"/>
                                 </Items>
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvcmbState" runat="server" ControlToValidate="cmbState" InitialValue="Select State" ForeColor="Red" ErrorMessage="Please Select State" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            
                        </div><br />
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>City <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCity" runat="server" Enabled="false" RenderMode="Lightweight"  CssClass="Combo" Filter="Contains" ValidationGroup="Test">
                                 <Items>
                                     <telerik:RadComboBoxItem Value="0" Text="Select City"/>
                                 </Items>
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCmbCity" runat="server" InitialValue="Select City" ControlToValidate="cmbCity" ForeColor="Red" ErrorMessage="Please Select City" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            
                        </div>
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>Customer Preffered Language <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCustomerPrefferedLanguage" runat="server" CheckBoxes="true" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="cmbCustomerPrefferedLanguage_SelectedIndexChanged" AppendDataBoundItems="true" Filter="Contains" RenderMode="Lightweight"  CssClass="Combo" ValidationGroup="Test">
                                 <Items>
                                     <telerik:RadComboBoxItem Value="0" Text="Select Language"/>
                                 </Items>
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCustomerPrefferedLanguage" runat="server" InitialValue="" ControlToValidate="cmbCustomerPrefferedLanguage" ForeColor="Red" ErrorMessage="Please Select Language" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                            
                        </div>
                    </div>

            <div class="col-lg-3 col-sm-6">
                        <label>Date of Birth <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <%--<asp:TextBox ID="txtCaseRecDateTime" runat="server" TextMode="DateTime" class="form-control required" ></asp:TextBox>--%>
                            <telerik:RadDateTimePicker ID="dtpDOB" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" ValidationGroup="Test">
                                
                            </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvdtDOB" runat="server" ControlToValidate="dtpDOB" ForeColor="Red" ErrorMessage="Please Select Date of Birth" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
              <div class="col-lg-3 col-sm-6"></div>
        </div>

         
         <div class="form-group" style="margin-top:330px; margin-left:10px;">
             <h4>Case Details </h4>
             <hr />
           <div class="col-lg-3 col-sm-6">
                        <label>Consultation Type <span class="mandatory">*</span>  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbConsultationType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Consultation Type" />
                                   <%-- <telerik:RadComboBoxItem Value="1" Text="Tele" />
                                    <telerik:RadComboBoxItem Value="2" Text="Video" />--%>
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvConsultationType" runat="server" ControlToValidate="cmbConsultationType" InitialValue="Select Consultation Type" ForeColor="Red" ErrorMessage="Please Select Consultation Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Case Type <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Main" />
                                    <telerik:RadComboBoxItem Value="2" Text="Additional" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="cmbCaseType" InitialValue="Select Case Type" ForeColor="Red" ErrorMessage="Please Select Case Type" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Payment Type <span class="mandatory"></span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbPaymentType" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Payment Type" />
                                    <%--<telerik:RadComboBoxItem Value="1" Text="Corporate Paid" />
                                    <telerik:RadComboBoxItem Value="2" Text="Customer Paid" />--%>
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvPaymentType" runat="server" ControlToValidate="cmbPaymentType" InitialValue="Select Payment Type" ForeColor="Red" ErrorMessage="Please Select Payment Type" Enabled="false"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div id="divPaymentStatus" class="col-lg-3 col-sm-6" style="visibility:hidden" >
                        <label>Payment Status <span class="mandatory">*</span></label>
                        <div class="selector">
                          
                             <telerik:RadComboBox ID="cmbPaymentStatus" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Payment Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Received" />
                                    <telerik:RadComboBoxItem Value="2" Text="Pending" />
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvPaymentStatus" runat="server" ControlToValidate="cmbPaymentStatus" ForeColor="Red" Enabled="false" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div><br />
                    </div>
       
             <div class="col-lg-3 col-sm-6">
                        <label>Case For <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseFor" RenderMode="Lightweight" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbCaseFor_SelectedIndexChanged" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case For" />
                                   <%-- <telerik:RadComboBoxItem Value="1" Text="Self" />
                                    <telerik:RadComboBoxItem Value="2" Text="Dependent" />
                                    <telerik:RadComboBoxItem Value="3" Text="Both" />--%>
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="cmbCaseFor" InitialValue="Select Case For" ForeColor="Red" ErrorMessage="Please Select Case For" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Customer Profile <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCustomerProfile" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Customer Profile" />
                                    <%--<telerik:RadComboBoxItem Value="1" Text="Normal" />
                                    <telerik:RadComboBoxItem Value="2" Text="HNI" />--%>
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCustomerProfile" runat="server" ControlToValidate="cmbCustomerProfile" InitialValue="Select Customer Profile" ForeColor="Red" ErrorMessage="Please Select Customer Profile" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
           
            
        </div>

         <asp:UpdatePanel ID="upDependent" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
         <div  id="DependentDetails" runat="server" visible="false" class="form-group" style="margin-top:230px; margin-left:10px;">
             <h4>Dependent Details</h4>
             <hr />

             <div class="container" style="margin-top:50px; margin-left:10px;" >
                 <div class="form-group" style="overflow:auto;">
                     <table>
                         <tr>
                             <td>
                                 <telerik:RadGrid ID="rgvDependentDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgvDependentDetails_ItemCommand" OnNeedDataSource="rgvDependentDetails_NeedDataSource" OnItemDataBound="rgvDependentDetails_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="DependentName" HeaderText="Person Name" SortExpression="DependentName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblDependentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DependentName").ToString()%>'></asp:Label>
                                                       <%--<asp:Label ID="lblContactDetailsID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ContactDetailsId") %>' Visible="false"></asp:Label>--%><%-- <telerik:RadDatePicker ID="" runat="server" Culture="English (United States)"
                                                Width="100px" ReadOnly="true" Enabled="false" DateInput-DateFormat="dd/MM/yyyy"
                                                DateInput-EmptyMessage="DD/MM/YYYY" DateInput-MaxLength="10" TitleFormat="MMMM yyyy"
                                                DbSelectedDate=''>
                                            </telerik:RadDatePicker>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtDependentName" runat="server" class="form-control required" MaxLength="230" placeholder="Enter Dependent Name" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox>
                                                       <asp:RequiredFieldValidator ID="rfvDependentName" runat="server" ControlToValidate="txtDependentName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Person Name" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="DateOfBirth" HeaderText="Date Of Birth" SortExpression="DateOfBirth">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDateOfBirth" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DateOfBirth") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadDateTimePicker ID="dtpDependentDOB" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server">
                                
                            </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvdtDOB" runat="server" ControlToValidate="dtpDependentDOB" ForeColor="Red" ErrorMessage="Please Select Date of Birth" Enabled="true" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>


                                               <telerik:GridTemplateColumn DataField="MobileNo" HeaderText="Mobile No." SortExpression="MobileNo">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MobileNo") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtMobileNo" runat="server" MaxLength="10" placeholder="Enter Mobile No." ValidationGroup="GridSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Mobile No" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="GridSave" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EmailId") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblnewrows" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"newrow") %>' Visible="false"></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtEmailId" runat="server" MaxLength="500" placeholder="Enter the Email Id" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailid" ForeColor="Red" 
                                           ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpression_email" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="GridSave" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txtEmailid"></asp:RegularExpressionValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="Gender" HeaderText="Gender" SortExpression="DependentGender">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDependentGender" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DependentGender") %>'></asp:Label>
                                                       <asp:Label ID="lblDependentGenderId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DependentGenderId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDependentGender" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvDependentGender" ControlToValidate="cmbDependentGender" 
                                                           runat="server" InitialValue="-Select-" ForeColor="Red" ErrorMessage="Select Gender" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="RelationShip" HeaderText="RelationShip" SortExpression="RelationShip">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDependentRelationShip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RelationShip") %>'></asp:Label>
                                                       <asp:Label ID="lblDependentRelationShipId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RelationShipId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDependentRelationShip" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvDEependentRelationShip" ForeColor="Red" ControlToValidate="cmbDependentRelationShip" 
                                                           runat="server" InitialValue="-Select-" ErrorMessage="Select RelationShip" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="ConsultationType" HeaderText="Consultation Type" SortExpression="ConsultationType">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDependentConsultationType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ConsultationType") %>'></asp:Label>
                                                       <asp:Label ID="lblDependentConsultationTypeId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ConsultationTypeId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDependentConsultationType" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator ID="frvDependentConsultationType" ForeColor="Red" runat="server" ControlToValidate="cmbDependentConsultationType" 
                                                           InitialValue="-Select-" ErrorMessage="Select Consultation Type" ValidationGroup="GridSave">  </asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="CaseType" HeaderText="Case Type" SortExpression="CaseType">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDependentCaseType"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CaseType") %>'></asp:Label>
                                                       <asp:Label ID="lblDependentCaseTypeId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CaseTypeId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDependentCaseType" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                                <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                    <telerik:RadComboBoxItem Value="1" Text="Main" />
                                    <telerik:RadComboBoxItem Value="2" Text="Additional" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator ID="frvDependentCaseType" ForeColor="Red" runat="server" ControlToValidate="cmbDependentCaseType" 
                                                           InitialValue="Select Case Type" ErrorMessage="Select Case Type" ValidationGroup="GridSave">  </asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="PrefferedLanguage" HeaderText="Preffered Language" SortExpression="PrefferedLanguage">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDependentPrefferedLanguage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PrefferedLanguage") %>'></asp:Label>
                                                       <asp:Label ID="lblDependentPrefferedLanguageId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PrefferedLanguageId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDependentPrefferedLanguage" CheckBoxes="true" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                                 <telerik:RadComboBoxItem Value="0" Text="Select Language"/>
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator ID="rfvDependentPrefferedLanguage" runat="server" InitialValue="" ControlToValidate="cmbDependentPrefferedLanguage" ForeColor="Red" ErrorMessage="Please Select Language" Enabled="true" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="FollowUpDateTime" HeaderText="FollowUp Date Time" SortExpression="FollowUpDateTime">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblFollowUpDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FollowUpDateTime") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblnewrows" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"newrow") %>' Visible="false"></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadDateTimePicker ID="dtpDependentFollowUpDatetime" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" >
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvFollowUp" runat="server" ControlToValidate="dtpDependentFollowUpDatetime" ValidationGroup="GridSave" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblRemarks" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Remarks") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblnewrows" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"newrow") %>' Visible="false"></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtDependentRemarks" runat="server" MaxLength="500" placeholder="Enter the Remarks" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtDependentRemarks" ForeColor="Red" 
                                           ErrorMessage="Please Enter Remarks" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                      
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               
                                               <telerik:GridTemplateColumn HeaderText="Add/Delete">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="btnDeleteDependentDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="DeleteDependentDetails" OnClientClick="return deleletconfig();" Text="Delete">
                                                                        </asp:LinkButton>
                                                       <asp:RadioButtonList ID="rbdIsActive" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                           <asp:ListItem Value="True">Active</asp:ListItem>
                                                           <asp:ListItem Value="False">InActive</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                       <asp:Label ID="lblIsActive" runat="server" Visible="false"></asp:Label>
                                                       <%-- <asp:Label ID="Label1" runat="server" Visible="false"='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddDependentDetails" runat="server" CausesValidation="true" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AddDependentDetails" Text="Add" ValidationGroup="GridSave" />
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                             </td>
                         </tr>
                     </table>
                 </div>
             </div>

         </div>
                 </ContentTemplate>
             </asp:UpdatePanel>
         <div class="form-group" style="margin-top:220px; margin-left:10px;">
             <h4>Doctor Appointment Details </h4>
             <hr />

             <div class="container"   style="overflow:auto">
                     <div class="form-group">
                         <table style="width:auto">
                             <tr>
                                 <td>
                                     <telerik:RadGrid ID="rgvConsultantCaseAppointmentDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" 
                          Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <%--<telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                     <ItemTemplate>
                                         <asp:Label ID="lnkCaseId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'></asp:Label>
                                         <%--<asp:Label ID="lblConsultantCaseDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationCaseDetailsId")%>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblConsultationAppointmentDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ConsultationCaseAppointmentDetailsId")%>' Visible="false"></asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>--%>
                                 

                                 <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>


                                 <telerik:GridTemplateColumn HeaderText="Appointment Date Time" SortExpression="AppointmentDateTime">
                                        <ItemTemplate>
                                         <asp:Label ID="lblAppointmentDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>


                                <%-- <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatus">
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
                                 </telerik:GridTemplateColumn>--%>

                                 <telerik:GridTemplateColumn HeaderText="Appointment Status" SortExpression="AppointmentDescription">
                                        <ItemTemplate>
                                         <asp:Label ID="lblAppointmentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDescription")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                <%-- <telerik:GridTemplateColumn HeaderText="Case For" SortExpression="CaseFor">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseFor")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>--%>

                                  

                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid>
                                 </td>
                             </tr>
                         </table>
                     </div>

                 </div>
           <%--<div class="col-lg-3 col-sm-6">
                        <label>Preffered Language <span class="mandatory">*</span>  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbLanguage" CausesValidation="false" RenderMode="Lightweight" CheckBoxes="true" AutoPostBack="true" OnSelectedIndexChanged="cmbLanguage_SelectedIndexChanged"  Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Language" />
                                    
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" InitialValue="" ForeColor="Red" ErrorMessage="Please Select Language" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>
            <div class="col-lg-3 col-sm-6">
                        <label>Doctor Date and Time <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpDoctorDateTime" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="dtpDoctorDateTime" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Doctor Name <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbDoctorName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Doctor" />
                                    
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" ControlToValidate="cmbDoctorName" InitialValue="Select Doctor" ForeColor="Red" ErrorMessage="Please Select Doctor Name" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>

             <div class="col-lg-3 col-sm-6">
                        <label>Doctor Qualification <span class="mandatory">*</span></label>
                        
                            

                 <telerik:RadComboBox ID="cmbDoctorQualification" AppendDataBoundItems="true" RenderMode="Lightweight" runat="server" CssClass="Combo" Filter="Contains">
                     <Items>
                         <telerik:RadComboBoxItem Value="0" Text="Select Qualification" />
                         
                     </Items>
                 </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvDoctorQualification" InitialValue="Select Qualification" runat="server" ControlToValidate="cmbDoctorQualification" ForeColor="Red" ErrorMessage="Please Select Qualification" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                    
                    </div>--%>
            
           <div class="col-lg-3 col-sm-6">
                        <label>Case Status <span class="mandatory">*</span> </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseStatus" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test">
                                <Items>
                                        
                                     <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    <telerik:RadComboBoxItem Value="1" Text="Fresh Case" />
                                    <%--<telerik:RadComboBoxItem Value="2" Text="Call Later - Customer asked to call back" />
                                    <telerik:RadComboBoxItem Value="3" Text="Call Later - Customer phone switched off" />
                                    <telerik:RadComboBoxItem Value="4" Text="Appointment Confirmed" />
                                    <telerik:RadComboBoxItem Value="5" Text="Escalated to Insurance Co - Customer No Show" />
                                    <telerik:RadComboBoxItem Value="6" Text="Medicals Done - Report Awaited" />--%>
                                    
                                    
                                </Items>
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseStatus" runat="server" ControlToValidate="cmbCaseStatus" InitialValue="Select Case Status" ForeColor="Red" ErrorMessage="Please Select Case Status" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                           </div>
                    </div>


             <div class="col-lg-3 col-sm-6">
                        <label>Follow Up Date and Time <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpFollowUp" RenderMode="Lightweight" AutoPostBackControl="Both"  Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Test" PopupDirection="BottomLeft">
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvFollowUp" runat="server" ControlToValidate="dtpFollowUp" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>

              <div class="col-lg-3 col-sm-6">
                        <label>Remarks <span class="mandatory"></span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" ForeColor="Red" ErrorMessage="Please Enter Remarks" Enabled="false"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            
             </div>


        <div class="form-group" style="margin-top:200px; margin-left:10px; text-align:center;">
           
           
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Test" />
          &nbsp;&nbsp;&nbsp;
            
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" CausesValidation="false" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                
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

    <div id="SearchPopUp" class="modal fade" role="dialog" >
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                     
                                        <h4 class="modal-title"></h4>
                                    </div>
                                    <div class="modal-body">

                                                             
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Ok" OnClick="btnSearch_Click" />
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

    <style type="text/css">  
    .modalBackground  
    {  
        background-color: Black;  
        filter: alpha(opacity=90);  
        opacity: 0.8;  
    }  
      
    .modalPopup  
    {  
        background-color: #FFFFFF;  
        border-width: 3px;  
        border-style: solid;  
        border-color: black;  
        padding-top: 10px;  
        padding-left: 10px;  
        width: 1000px;  
        height: 500px;  
    }  
</style>  

   

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderLogin" runat="server"
             TargetControlID="btnSearchEmployeee"
             PopupControlID="SearchEmployeeDetails"
             BackgroundCssClass="modalBackground"
             
         
              />
     <asp:Panel ID="SearchEmployeeDetails" runat="server" CssClass="modalPopup"  align="center" style="display:none">
         <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSearchEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchEmployeeId" runat="server" Text="Employee Id"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox id="txtSearchEmployeeName" OnTextChanged="txtSearchEmployeeName_TextChanged" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchMobileNo" OnTextChanged="txtSearchMobileNo_TextChanged" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchEmployeeId" OnTextChanged="txtSearchEmployeeId_TextChanged" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                       <%-- <br />
                                        <div style="align-content:center">
                                             <asp:Button ID="SearchEmployee" runat="server" Text="Search" OnClick="SearchEmployee_Click"/>
                                        </div>--%>
                                        <br />
                                        

                                        

                                        <telerik:RadGrid ID="rgvSearchEmployeeDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      OnItemCommand="rgvSearchEmployeeDetails_ItemCommand" OnNeedDataSource="rgvSearchEmployeeDetails_NeedDataSource" OnPageIndexChanged="rgvSearchEmployeeDetails_PageIndexChanged"
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               
                               <telerik:GridTemplateColumn HeaderText="Employee Id" SortExpression="EmployeeId">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkEmployeeId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" OnClientClick="window.closes()" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeId")%>'></asp:LinkButton>
                                       <asp:Label ID="lblEmployeeRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeRefId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName" Visible="false">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="Branch" Visible="false">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Branch")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Address" SortExpression="Address">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="Emailid">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmailid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Emailid")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                          
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>


                                        <br />
                                        <div style="align-content:center">
                                             <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btn_Search_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Close" CssClass="login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btn_Cancel_Click" CausesValidation="false"/>
                                        </div>
    </asp:Panel>

    <%--<div id="SearchPopUp" role="dialog"  >
        <div class="modal-dialog">
            <div class="modal-content">

            

        
        <telerik:RadGrid ID="rgvSearchEmployeeDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      OnItemCommand="rgvSearchEmployeeDetails_ItemCommand" OnNeedDataSource="rgvSearchEmployeeDetails_NeedDataSource" OnPageIndexChanged="rgvSearchEmployeeDetails_PageIndexChanged"
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               
                               <telerik:GridTemplateColumn HeaderText="Employee Id" SortExpression="EmployeeId">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkEmployeeId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeId")%>'></asp:LinkButton>
                                       <asp:Label ID="lblEmployeeRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeRefId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>


                               <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Address" SortExpression="Address">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="Emailid">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmailid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Emailid")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               



                               
                          
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>

                <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
            </div>
            </div>
    </div>--%>
</asp:Content>



