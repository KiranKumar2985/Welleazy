<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="DoctorPrescription.aspx.cs" Inherits="Welleazy.Case.DoctorPrescription" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Doctor Prescription</title>
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
        function ShowSearchPopup() {
            //$("#MyPopup .modal-title").html(title);
            //$("#MyPopup .modal-body").html(body);
            $("#SearchPopUp").modal("show");
        }
</script>


<%--
   
    <asp:UpdatePanel ID="upEConsultant" runat="server">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
      <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> Doctor Prescription List
             <span style="float:right; font-size:small;">
                    <asp:LinkButton ID="lnkAddPrescription" OnClick="lnkAddPrescription_Click" runat="server"  ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Prescription</asp:LinkButton> 
                 </span>
        </h5>
         <div class="line">
         </div>

         <asp:MultiView ID="DoctorPrescriptionView" runat="server">
             <asp:View ID="View" runat="server">
                 <div class="form-group">                    

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
                <label>Employee Name </label>
                        <div class="selector">
                            <asp:TextBox ID="txtEmplolyeeNameSearch" runat="server" placeholder="Employee Name" TextMode="SingleLine" class="form-control required"></asp:TextBox>

                            </div>
                            </div>

                          <%--<div class="col-md-3">
                        <label>Mobile Number </label>
                        <div class="selector">
                            <asp:TextBox ID="txtMobileNoSearch" runat="server" placeholder="Mobile Number" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>--%>
            

               <div class="col-md-6">
                        <label>Prescription Date (MM-DD-YYYY) </label>
                        <div class="selector">
                            <telerik:RadDateRangePicker ID="dtpPrescriptiondate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="MM-dd-yyyy" EndDatePicker-DateInput-DateFormat="MM-dd-yyyy" runat="server" ></telerik:RadDateRangePicker>
                            <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="Follow Up Date (MM-DD-YYYY)" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_CaseId_TextChanged"></asp:TextBox>--%>
                            </div>
                        
                    </div>
               
              
            
                  <%--<div class="col-md-3">
                        <label>Application No. </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>--%>
              <br /><br />
              </div>

                      <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px; " align="center">
             
               <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
                
                        
         </div>

                 </div>
                         

                 
                 <div class="form-group" style="padding:10px;padding-top:20px;margin-top:20px;border:3px solid #e1e1e1;border-bottom-style:none;border-left-style:none; border-right-style:none; overflow:auto;">
                     <%--<telerik:RadComboBox ID="cmbExport" RenderMode="Lightweight" CssClass="Combo_Export" runat="server" >
                          <Items>
                              <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                              <%--<telerik:RadComboBoxItem Value="1" Text="PDF" />
                              <telerik:RadComboBoxItem  Value="2" Text="Excel"/>
                              <telerik:RadComboBoxItem  Value="3" Text="CSV"/>
                          </Items>
                      </telerik:RadComboBox>--%>

                     <%-- <asp:Button ID="btnDownload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnDownload_Click" Text="Export/Download" Width="200" />--%>
                 </div>
                 <div class="form-group"   style="overflow:auto;">
                     <div class="form-group">
                         <table border="1" style="width:auto;">
                             <tr>
                                 <td>
                                     <telerik:RadGrid ID="rgvPrescriptionDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvPrescriptionDetails_ItemCommand" OnNeedDataSource="rgvPrescriptionDetails_NeedDataSource"
                         OnPageIndexChanged="rgvPrescriptionDetails_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <telerik:GridTemplateColumn HeaderText="Action" >
                                   <ItemTemplate>
                                       <%--<asp:CheckBox ID="chkCaseId" AutoPostBack="true" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" OnCheckedChanged="chkCaseId_CheckedChanged" CommandName="AssignToDoctor" Font-Underline="true"></asp:CheckBox>--%>
                                       <asp:ImageButton ID="lnkPrescriptionDetailsEdit" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                           
                                       <%--<asp:ImageButton ID="PatientHistory" runat="server" ImageUrl="~/images/calender_icon.jpg" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AssignToDoctor" />--%>
                                       <asp:Label ID="lblPrescriptionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionId")%>' Visible="false"></asp:Label>
                                         

                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Prescription Id" SortExpression="PrescriptionId">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionId1" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionId")%>'></asp:Label>
                                         
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                     <ItemTemplate>
                                         <asp:Label ID="lblCorporateName" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:Label>
                                         
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                     <ItemTemplate>
                                         <asp:Label ID="lblEmployeeName" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:Label>
                                         
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Age" SortExpression="Age">
                                     <ItemTemplate>
                                         <asp:Label ID="lblAge" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Age")%>'></asp:Label>
                                         
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Prescription Date and Time" SortExpression="PrescriptionDateTime">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Symptoms" SortExpression="Symptoms">
                                        <ItemTemplate>
                                         <asp:Label ID="lblSymptoms" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Symptoms")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Test Details" SortExpression="TestDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblTestDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Prescription Details" SortExpression="PrescriptionDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Diet To Be Follow" SortExpression="DietToBeFollow">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDietToBeFollow" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "DietToBeFollow")%>'></asp:Label>
                                         
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Next Visit Date" SortExpression="NextVisitDate">
                                     <ItemTemplate>
                                         <asp:Label ID="lblNextVisitDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NextVisitDate")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="CreatedBy">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Updated By" SortExpression="UpdatedBy">
                                        <ItemTemplate>
                                         <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedBy")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Updated On" SortExpression="UpdatedOn">
                                        <ItemTemplate>
                                         <asp:Label ID="lblUpdatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedOn")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="History">
                                        <ItemTemplate>
                                         <asp:LinkButton ID="lnkPatientHistory" CommandName="ViewHistory" runat="server" CommandArgument="<%# (Container.ItemIndex).ToString() %>" Text="View History">
                                                    </asp:LinkButton>
                                            <asp:Label ID="lblEmployeeRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeRefId")%>' Visible="false"></asp:Label>

                                             <ajaxtoolkit:modalpopupextender ID="ModalPopupExtenderHistory" runat="server"
             TargetControlID="btnShow"
             PopupControlID="PatientHistory"
             BackgroundCssClass="modalBackground"/>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkPatientPrescription" runat="server" ImageUrl="~/images/Download-Icon.png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="Print" />
                                            <asp:Label ID="lblPrescriptionIdPDF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionId")%>' Visible="false"></asp:Label>

                                             <ajaxtoolkit:modalpopupextender ID="ModalPopupExtenderPatientPrescription" runat="server"
             TargetControlID="btnShow1"
             PopupControlID="PatientPrescription"
             BackgroundCssClass="modalBackground"/>
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
                    <div class="form-group">
                        
                        <div class="row">
                            <div class="form-group" style="padding:20px; margin-top:-40px;">
           <h4>Prescription Details </h4>
            <hr />
            
            <div class="col-md-3">
                        <label>Prescription Entry Date & Time  </label>
                        <div class="selector">
                            <%-- <asp:TextBox ID="txtCaseEntryDate" runat="server" TextMode="DateTime" class="form-control required" ReadOnly="true" ></asp:TextBox>--%>
                             <telerik:RadDateTimePicker ID="dtpPrescriptionEntryDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" Enabled="false" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>

                                <div class="col-md-3">
                     <label>
                         Corporate Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateName" runat="server" Enabled="true" CausesValidation="false" AppendDataBoundItems="true" CssClass="Combo" AutoPostBack="true" OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" DataTextField="CorporateName" DataValueField="CorporateId" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Corporate Name" Value="0" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCorporateName"  runat="server" ControlToValidate="cmbCorporateName" ErrorMessage="Please Select  Corporate Name" ForeColor="Red" InitialValue="Select Corporate Name" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                </div>
                <div class="col-md-3">
                         <label>
                         Branch Id <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateBranchId" runat="server" Enabled="true" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="cmbCorporateBranchId_SelectedIndexChanged" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Branch Id" Value="0" />
                                     
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ErrorMessage="Please Select Branch Id" ForeColor="Red" InitialValue="Select Branch Id" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
            
        </div>
                        </div>  
                       
                <div class="form-group">
                    <asp:Label ID="LabelDOB" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="LabelAge" runat="server" Visible="false"></asp:Label>
                <div class="col-md-3">
                         <label> Employee Name <span class="mandatory">*</span></label>
                    <span><asp:ImageButton ID="btnSearchEmployeee" Height="20px" Width="25px" ImageUrl="~/images/Search Image.png" runat="server" AlternateText="Search" OnClick="btnSearchEmployeee_Click" /></span>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control required" ReadOnly="true" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Enabled="true" ErrorMessage="Please Enter Employee Name" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                     <div class="col-md-3">
                         <label>
                         Mobile Number <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" ReadOnly="true" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" Enabled="true" ErrorMessage="Please Enter Mobile No" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
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
                             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="cmbGender"  ErrorMessage="Please Select Gender" ForeColor="Red" InitialValue="Select Gender" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-3">
                         <label>
                         Employee Email Id<span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" class="form-control required" ReadOnly="true" TextMode="SingleLine"></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" Enabled="true" ErrorMessage="Please Enter Email Id" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                         
                     </div>
                 </div>

                        <div class="form-group">
                
                <div class="col-md-3">
                         <label>
                         Symptoms <span class="mandatory">*</span></label>
                    
                         <div class="selector">
                             <asp:TextBox ID="txtSymptoms" runat="server" class="form-control required" TextMode="MultiLine" ValidationGroup="Case"></asp:TextBox>
                             
                             <asp:RequiredFieldValidator ID="rfvSymptoms" runat="server" ControlToValidate="txtSymptoms" Enabled="true" ErrorMessage="Please Enter Symptoms" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                     <div class="col-md-3">
                         <label>
                         Test Details <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtTestDetails" runat="server" class="form-control required"  TextMode="MultiLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvTestDetails" runat="server" ControlToValidate="txtTestDetails" Enabled="true" ErrorMessage="Please Enter Test Details" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     
                     <div class="col-md-3">
                         <label>
                         Prescription Details <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtPrescriptionDetails" runat="server" class="form-control required"  TextMode="MultiLine"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtPrescriptionDetails" runat="server" ControlToValidate="txtPrescriptionDetails"  ErrorMessage="Please Enter Prescription Details" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                       <div class="col-md-3">
                         <label>
                         Diet To Be Follow <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtDietToBeFollow" runat="server" class="form-control required"  TextMode="MultiLine"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvDietFollow" runat="server" ControlToValidate="txtDietToBeFollow"  ErrorMessage="Please Enter Diet Details" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                              <div class="col-md-3">
                         <label>
                         Next Visit Date </label>
                         <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpNextVisitDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" >
                                
                            </telerik:RadDateTimePicker>
                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDietToBeFollow"  ErrorMessage="Please Enter Diet Details" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>--%>
                         </div>
                     </div><br /><br /><br /><br />
                 </div>
            
          
          <div  id="MedicineDetails" runat="server" visible="true" class="form-group" style="margin-top:180px; margin-left:10px;">
             <h4>Medicine Details</h4>
             <hr />

             <div class="form-group" style="margin-top:20px; margin-left:1px;" >
                 <div class="form-group" style="overflow:auto;">
                     <table>
                         <tr>
                             <td>
                                 <telerik:RadGrid ID="rgvMedicineDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgvMedicineDetails_ItemCommand" OnNeedDataSource="rgvMedicineDetails_NeedDataSource" OnItemDataBound="rgvMedicineDetails_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="MedicineName" HeaderText="Medicine Name" SortExpression="MedicineName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblMedicineName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineName").ToString()%>'></asp:Label>
                                                       <%--<asp:Label ID="lblContactDetailsID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ContactDetailsId") %>' Visible="false"></asp:Label>--%><%-- <telerik:RadDatePicker ID="" runat="server" Culture="English (United States)"
                                                Width="100px" ReadOnly="true" Enabled="false" DateInput-DateFormat="dd/MM/yyyy"
                                                DateInput-EmptyMessage="DD/MM/YYYY" DateInput-MaxLength="10" TitleFormat="MMMM yyyy"
                                                DbSelectedDate=''>
                                            </telerik:RadDatePicker>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtMedicineName" runat="server" CssClass="form-control required" Height="34" MaxLength="230" placeholder="Enter Medicine Name" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox>
                                                       <asp:RequiredFieldValidator ID="rfvMedicineName" runat="server" ControlToValidate="txtMedicineName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Medicine Name" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               


                                               
                                               <telerik:GridTemplateColumn DataField="MedicineType" HeaderText="Medicine Type" SortExpression="MedicineType">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineType") %>'></asp:Label>
                                                       <asp:Label ID="lblMedicineTypeId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineTypeId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbMedicineType" AppendDataBoundItems="true"  RenderMode="Lightweight" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                               <telerik:RadComboBoxItem Value="1" Text="Tablet" />
                                                               <telerik:RadComboBoxItem Value="2" Text="Capsule" />
                                                               <telerik:RadComboBoxItem Value="3" Text="Cream" />
                                                               <telerik:RadComboBoxItem Value="4" Text="Syrup" />
                                                               <telerik:RadComboBoxItem Value="5" Text="Powder" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvMedicineType" ControlToValidate="cmbMedicineType" 
                                                           runat="server" InitialValue="-Select-" ForeColor="Red" ErrorMessage="Select Type" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="MedicineSession" HeaderText="Session" SortExpression="MedicineSession">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineSession" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSession") %>'></asp:Label>
                                                       <asp:Label ID="lblMedicineSessionId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSessionId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbMedicineSession" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"  AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <%--<telerik:RadComboBoxItem Value="0" Text="-Select-" />--%>
                                                               <telerik:RadComboBoxItem Value="1" Text="Morning" />
                                                               <telerik:RadComboBoxItem Value="2" Text="Afternoon" />
                                                               <telerik:RadComboBoxItem Value="3" Text="Evening" />
                                                               <telerik:RadComboBoxItem Value="4" Text="Night" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvMedicineSession" ControlToValidate="cmbMedicineSession" 
                                                           runat="server" InitialValue="-Select-" ForeColor="Red" ErrorMessage="Select Session" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="InTakeMethod" HeaderText="InTake Method" SortExpression="InTakeMethod">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblInTakeMethod" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethod") %>'></asp:Label>
                                                       <asp:Label ID="lblInTakeMethodId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethodId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbInTakeMethod" AppendDataBoundItems="true" RenderMode="Lightweight"  runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                               <telerik:RadComboBoxItem Value="1" Text="After Breakfast/Meal" />
                                                               <telerik:RadComboBoxItem Value="2" Text="Before Breakfast/Meal" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvInTakeMethod" ForeColor="Red" ControlToValidate="cmbInTakeMethod" 
                                                           runat="server" InitialValue="-Select-" ErrorMessage="Select InTake Method" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               
                                               

                                               <telerik:GridTemplateColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblRemarks" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Remarks") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblnewrows" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"newrow") %>' Visible="false"></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtMedicineRemarks" runat="server" CssClass="form-control required" Height="34" MaxLength="500" placeholder="Enter the Remarks" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox><br />
                                                       <%--<asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtMedicineRemarks" ForeColor="Red" 
                                           ErrorMessage="Please Enter Remarks" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>--%>
                                      
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               
                                               <telerik:GridTemplateColumn HeaderText="Add/Delete">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="btnDeleteMedicineDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="DeleteMedicineDetails" OnClientClick="return deleletconfig();" Text="Delete">
                                                                        </asp:LinkButton>
                                                       <asp:RadioButtonList ID="rbdIsActive" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                           <asp:ListItem Value="True">Active</asp:ListItem>
                                                           <asp:ListItem Value="False">InActive</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                       <asp:Label ID="lblIsActive" runat="server" Visible="false"></asp:Label>
                                                       <%-- <asp:Label ID="Label1" runat="server" Visible="false"='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddMedicineDetails" runat="server" CausesValidation="true" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AddMedicineDetails" Text="Add" ValidationGroup="GridSave" />
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
        <div class="form-group" style="margin-left:14px;">
                
                         <asp:Button ID="btnSave" runat="server" BackColor="#113d7a" BorderStyle="None" CausesValidation="true" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSave_Click" Text="Save" ValidationGroup="Case" />
                     &nbsp;&nbsp;&nbsp; 
            <asp:Button ID="btnCancel" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                 </div>
                        </div>
             </asp:View>
         </asp:MultiView>
       
         </div>
                    <%--  </span>
         </ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="rgvPrescriptionDetails" />
               
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

    <div class="modal fade" id="myModal1" role="dialog" >
        <div class="modal-dialog" style="width:1000px;" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
           
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <%--<telerik:RadGrid ID="rgvPatientPrescriptionDetails" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvPatientPrescriptionDetails_ItemCommand" OnNeedDataSource="rgvPatientPrescriptionDetails_NeedDataSource"
                         OnPageIndexChanged="rgvPatientPrescriptionDetails_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                                 <telerik:GridTemplateColumn HeaderText="Prescription Date and Time" SortExpression="PrescriptionDateTime">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Registration Number" SortExpression="RegistrationNumber">
                                     <ItemTemplate>
                                         <asp:Label ID="lblRegistrationNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RegistrationNumber")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Doctor Qualification" SortExpression="Qualification">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDoctorQualification" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qualification")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Contact No" SortExpression="ContactNo">
                                     <ItemTemplate>
                                         <asp:Label ID="lblContactNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContactNo")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="DrEmailId">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDrEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrEmailId")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="City" SortExpression="DrCity">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDrCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrCity")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Doctor Address" SortExpression="DoctorAddress">
                                     <ItemTemplate>
                                         <asp:Label ID="lblDoctorAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorAddress")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient Name" SortExpression="EmployeeName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient Age" SortExpression="Age">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtAge" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient Contact No" SortExpression="MobileNo">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient Email Id" SortExpression="EmailId">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient City" SortExpression="PtCity">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PtCity")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Patient Address" SortExpression="Address">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPtAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Symptoms" SortExpression="Symptoms">
                                        <ItemTemplate>
                                         <asp:Label ID="lblSymptoms" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Symptoms")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Test Details" SortExpression="TestDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblTestDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Prescription Details" SortExpression="PrescriptionDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Diet To Be Follow" SortExpression="DietToBeFollow">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDietToBeFollow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DietToBeFollow")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Next Visit Date" SortExpression="NextVisitDate">
                                        <ItemTemplate>
                                         <asp:Label ID="lblNextVisitDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NextVisitDate")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid><br />--%>
                    
                    <table runat="server" border="1" style="width: 100%; margin-top:30px; padding:20px; border: 1px solid #eeeaea;">
                        <tr><td style="text-align:center;" colspan="4"><b> Patient Prescription </b></td></tr>
                        <tr><td style = "padding:5px;"> <b>Prescription No</b></td><td style = 'padding:5px;'><asp:Label ID="LabelPrescriptionNo" runat="server" ></asp:Label></td>
                            <td style = 'padding:5px;'> <b>Prescription Date</b></td><td style = 'padding:5px;'><asp:Label ID="LabelPrescriptionDate" runat="server" ></asp:Label></td></tr>

                    </table>
                    <br />
                    <table runat="server" border="1" style="border: 1px solid #eeeaea; font-size: small; width:100%;">
                    <tr><td style = "padding:5px;" colspan="4"> <b>Doctor Information</b></td></tr>
                    <tr><td style = "padding:5px; text-align:center;" colspan="4"><asp:Label ID="LabelHospital" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Doctor Name </td><td style = "padding:5px;"><asp:Label ID="LabelDrName" runat="server" ></asp:Label><asp:Label ID="LabelDoctorID" runat="server" Visible="false" ></asp:Label></td> <td style = "padding:5px;"> Dr Registration No </td><td style = "padding:5px;"><asp:Label ID="LabelDrRegnNo" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Dr Qualification </td><td style = "padding:5px;"><asp:Label ID="LabelDrQualification" runat="server" ></asp:Label></td> <td style = "padding:5px;"> Dr Contact No </td><td style = "padding:5px;"><asp:Label ID="LabelDrContactNo" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Dr Email </td><td style = "padding:5px;"><asp:Label ID="LabelDrEmail" runat="server" ></asp:Label></td><td style = "padding:5px;"> Dr City </td><td style = "padding:5px;"><asp:Label ID="LabelDrCity" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Dr Address </td><td style = "padding:5px;" colspan="3"><asp:Label ID="LabelDrAddress" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;" colspan="4"> <b>Patient Information</b> </td></tr>
                    <tr><td style = "padding:5px;"> Corporate Name </td><td style = "padding:5px;" colspan="3"><asp:Label ID="LabelCorporateName" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Patient Name </td><td style = "padding:5px;"><asp:Label ID="LabelPtName" runat="server" ></asp:Label></td> <td style = "padding:5px;"> Patient Age </td><td style = "padding:5px;"><asp:Label ID="LabelPtAge" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Patient Contact No </td><td style = "padding:5px;"><asp:Label ID="LabelPtContactNo" runat="server" ></asp:Label></td> <td style = "padding:5px;"> Patient Email </td><td style = "padding:5px;"><asp:Label ID="LabelPtEmail" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Patient City </td><td style = "padding:5px;"><asp:Label ID="LabelPtCity" runat="server" ></asp:Label></td> <td style = "padding:5px;"> Patient Address </td><td style = "padding:5px;"><asp:Label ID="LabelPtAddress" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;" colspan="4"> <b>Drug Information</b> </td></tr>
                    <tr><td style = "padding:5px;" colspan="4"> GridView of Medicine </td></tr>
                    <tr><td style = "padding:5px;" colspan="4"> </td></tr>
                    <tr><td style = "padding:5px;"> <b>Symptoms</b> </td><td style = "padding:5px;"> <b>Test Details</b> </td> <td style = "padding:5px;"> <b>Prescription Details</b> </td><td style = "padding:5px;"> <b>Diet To Be Follow</b> </td></tr>
                    <tr><td style = "padding:5px;"><asp:Label ID="LabelSymptoms" runat="server" ></asp:Label></td><td style = "padding:5px;"><asp:Label ID="LabelTestDetails" runat="server" ></asp:Label></td> <td style = "padding:5px;"><asp:Label ID="LabelPrescriptionDetails" runat="server" ></asp:Label></td><td style = "padding:5px;"><asp:Label ID="LabelDietToBeFollow" runat="server" ></asp:Label></td></tr>
                    <tr><td style = "padding:5px;"> Next Visit Date </td><td style = "padding:5px;" colspan="3"><asp:Label ID="LabelNextVisitDate" runat="server" ></asp:Label></td></tr>
                    
                    <tr runat="server" visible="false" id="signature"><td style = "padding:5px;"> </td><td style = "padding:5px;"> </td><td style = "padding:5px;"> </td><td style = "padding:5px;"> <asp:Label ID="LabelSignature" runat="server" ></asp:Label> </td></tr></table>

                </div>
                <div class="form-group">
                     
         <br />
         <%--<telerik:RadGrid ID="rgvMedicineDetailsListRad"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgvMedicineDetailsList_ItemCommand" OnNeedDataSource="rgvMedicineDetailsList_NeedDataSource" OnItemDataBound="rgvMedicineDetailsList_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="MedicineName" HeaderText="Medicine Name" SortExpression="MedicineName">
                                                   <ItemTemplate>
                                                       
                                                       <asp:Label ID="lblMedicineName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineName").ToString()%>'></asp:Label>
                                                  
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               


                                               
                                               <telerik:GridTemplateColumn DataField="MedicineType" HeaderText="Medicine Type" SortExpression="MedicineType">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineType") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="MedicineSession" HeaderText="Session" SortExpression="MedicineSession">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineSession" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSession") %>'></asp:Label>
                                                       <asp:Label ID="lblMedicineSessionId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSessionId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                  
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="InTakeMethod" HeaderText="InTake Method" SortExpression="InTakeMethod">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblInTakeMethod" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethod") %>'></asp:Label>
                                                       <asp:Label ID="lblInTakeMethodId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethodId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               
                                               

                                               <telerik:GridTemplateColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblRemarks" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Remarks") %>'></asp:Label>
                                                       
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               
                                               
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>--%>
                   <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/DoctorDocument/image-logo-welnext.png" />--%>
                    <asp:GridView ID="rgvMedicineDetailsView" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" CellPadding="4" AllowCustomPaging="true" BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" >

                        <Columns>
                            <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name"></asp:BoundField>
                            <asp:BoundField DataField="MedicineType" HeaderText="Medicine Type"></asp:BoundField>
                            <asp:BoundField DataField="MedicineSession" HeaderText="Medicine Session"></asp:BoundField>
                            <asp:BoundField DataField="IntakeMethod" HeaderText="InTake Method"></asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                    </asp:GridView>
               
                    </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnPDFSave" runat="server" class="btn btn-default" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="PDF Save" OnClick="btnPDFSave_Click"/>
              <button type="button" class="btn btn-default" style="background-color:#113d7a; color:white; border-style:none;" data-dismiss="modal" >Close</button>
            </div>
          </div>
      
        </div>
      </div>

    <div class="modal fade" id="myModal2" role="dialog" >
        <div class="modal-dialog" style="width:1000px;" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
           
            </div>
            <div class="modal-body">
                <div class="form-group">
                   <telerik:RadGrid ID="rgvPatientHistory" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" 
                         BackColor="White" BorderColor="#3366CC" BorderStyle="None" EnableTheming="true"  
                         HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgvPatientHistory_ItemCommand" OnNeedDataSource="rgvPatientHistory_NeedDataSource"
                         OnPageIndexChanged="rgvPatientHistory_PageIndexChanged" Skin="Bootstrap">
                         <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                             <Columns>
                               
                                 <telerik:GridTemplateColumn HeaderText="Prescription Date and Time" SortExpression="PrescriptionDateTime">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Symptoms" SortExpression="Symptoms">
                                        <ItemTemplate>
                                         <asp:Label ID="lblSymptoms" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Symptoms")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                        <ItemTemplate>
                                         <asp:Label ID="lblDoctorName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Test Details" SortExpression="TestDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblTestDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn HeaderText="Prescription Details" SortExpression="PrescriptionDetails">
                                        <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDetails")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>

               

                             </Columns>
                         </MasterTableView>
                     </telerik:RadGrid>
         <br />
         <telerik:RadGrid ID="rgvMedicineHistory"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgvMedicineHistory_ItemCommand" OnNeedDataSource="rgvMedicineHistory_NeedDataSource" OnItemDataBound="rgvMedicineHistory_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn HeaderText="Prescription Date and Time" SortExpression="PrescriptionDateTime">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrescriptionDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrescriptionDateTime")%>'>
                                                    </asp:Label>
                                     </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="MedicineName" HeaderText="Medicine Name" SortExpression="MedicineName">
                                                   <ItemTemplate>
                                                       
                                                       <asp:Label ID="lblMedicineName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineName").ToString()%>'></asp:Label>
                                                  
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               


                                               
                                               <telerik:GridTemplateColumn DataField="MedicineType" HeaderText="Medicine Type" SortExpression="MedicineType">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="MedicineSession" HeaderText="Session" SortExpression="MedicineSession">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMedicineSession" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSession") %>'></asp:Label>
                                                       <asp:Label ID="lblMedicineSessionId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineSessionId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                  
                                               </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn DataField="InTakeMethod" HeaderText="InTake Method" SortExpression="InTakeMethod">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblInTakeMethod" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethod") %>'></asp:Label>
                                                       <asp:Label ID="lblInTakeMethodId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"InTakeMethodId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               
                                               

                                               <telerik:GridTemplateColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblRemarks" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Remarks") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   
                                               </telerik:GridTemplateColumn>

                                               
                                               
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                </div>
              
            </div>
            <div class="modal-footer">
                <%--<asp:Button ID="Button2" runat="server" class="btn btn-default" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="PDF Save" OnClick="btnPDFSave_Click"/>--%>
              <button type="button" class="btn btn-default" style="background-color:#113d7a; color:white; border-style:none;" data-dismiss="modal" >Close</button>
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

    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Visible="false"/>
    <asp:Button ID="btnShow1" runat="server" OnClick="btnShow1_Click" Visible="false"/>

    <ajaxtoolkit:modalpopupextender ID="ModalPopupExtenderLogin" runat="server"
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
                                                    <asp:TextBox id="txtSearchEmployeeName"  runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchMobileNo"  runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchEmployeeId"  runat="server"></asp:TextBox>
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
                                <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="Branch">
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



   <%--  <ajaxtoolkit:modalpopupextender ID="ModalPopupExtenderHistory" runat="server"
             TargetControlID="btnShow"
             PopupControlID="PatientHistory"
             BackgroundCssClass="modalBackground"/>
    
     <asp:Panel ID="PatientHistory" runat="server" CssClass="modalPopup"  align="center" style="display:none; overflow:auto;">
    
               


                                        <br />
                                        <div style="align-content:center">
                                             <asp:Button ID="btnHistoryClose" runat="server" Text="Close" CssClass="login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnHistoryClose_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;
                                            
                                        </div>
    </asp:Panel>--%>


</asp:Content>



