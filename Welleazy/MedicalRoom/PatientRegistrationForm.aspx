<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="PatientRegistrationForm.aspx.cs" Inherits="Welleazy.MedicalRoom.PatientRegistrationForm" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | Patient Registration</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>
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
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" > 
     <ContentTemplate>
     <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <div><h4 style="float:left;">Patient Registration Form</h4>
             <span style="float:right;">
                 <asp:LinkButton ID="lnkbtnPatientRegistration" runat="server" OnClick="lnkbtnPatientRegistration_Click" CausesValidation="false" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-home"></i></b>Add Patient Registration Details</asp:LinkButton>
           <asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/Dashboard.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-home"></i></b> Home</asp:LinkButton>
                 </span>
         </div>            
             <div class="line"></div>
         <asp:MultiView ID="PatientRegistrationView" runat="server">
              <asp:View ID="View" runat="server">
          <div class="form-group">
                               <div class="col-md-3">
                                  <asp:TextBox ID="txt_SearchEmployeeName" runat="server" placeholder="Employee Name" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                               
                               <div class="col-md-3">
                                   <asp:TextBox ID="txt_SearchEmployeeId" runat="server" placeholder="Employee ID" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                               <div class="col-md-3">
                                  <asp:TextBox ID="txt_SearchMobileNo" runat="server" placeholder="Employee Mobile No" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                                <div class="col-md-3">
                                <asp:TextBox ID="txt_SearchEmailId" runat="server" placeholder="Employee Email" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                    </div>
                     <div class="form-group" style="padding:60px; padding-bottom:0px; text-align:center;">
            
                <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Search" CssClass="Login_btn btn" OnClick="btnGo_Click"/>
                         
                         <div style="margin-top:30px">
                             <telerik:RadGrid ID="rgvPatientDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True"
                                 AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvPatientDetails_ItemCommand" OnNeedDataSource="rgvPatientDetails_NeedDataSource"
                                 OnPageIndexChanged="rgvPatientDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkEmployeeName" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:LinkButton>
                                       <asp:Label ID="lblPatientRegistrationFormId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatientRegistrationFormId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Employee Code" SortExpression="EmployeeCode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeCode")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="EmailId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
                         </div>
             
          
        </div>
              </div>
                  </asp:View>
             <asp:View ID="Save" runat="server">
                 <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
                               
                               
                               <%--<div class="col-md-3">
                                   <label>
                                   Corporate Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight" AutoPostBack="true" runat="server" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select Corporate" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Branch Id <span class="mandatory">*</span></label>
                                  
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmdBranchId" RenderMode="Lightweight" runat="server" AppendDataBoundItems="true" Filter="Contains">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       
                                       
                                   </div>
                               </div>--%>

                     <div class="col-md-3">
                                   <label>
                                   Employee Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtEmployeeName" runat="server" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ValidationGroup="Save" ControlToValidate="txtEmployeeName" ForeColor="Red" ErrorMessage="Please Enter Employee Name" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                

                     <div class="col-md-3">
                                   <label>
                                   Employee Code<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtEmployeeCode" runat="server" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmployeeCode" runat="server" ValidationGroup="Save" ControlToValidate="txtEmployeeCode" ForeColor="Red" ErrorMessage="Please Enter Employee Code" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                                
                    

                 <div class="col-md-3">
                                   <label>
                                   DOB <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDateTimePicker ID="dtpDOB" runat="server" RenderMode="Lightweight">
                                           
                                       </telerik:RadDateTimePicker>
                                       <asp:RequiredFieldValidator ID="rfvdtDOB" runat="server" ValidationGroup="Save" ControlToValidate="dtpDOB" ForeColor="Red" ErrorMessage="Please Enter Date of Birth" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>

                     <div class="col-md-3">
                                   <label>
                                   Gender <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbGender" runat="server" AppendDataBoundItems="true" RenderMode="Lightweight">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvcmbGender" runat="server" ControlToValidate="cmbGender" ValidationGroup="Save" InitialValue="-Select-" ForeColor="Red" ErrorMessage="Please Select Gender" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>

                     <div class="col-md-3">
                                   <label>
                                   Department <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbDepartment" runat="server" AppendDataBoundItems="true" RenderMode="Lightweight">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem  Value="1" Text="HR"  />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvcmbDepartment" runat="server" ValidationGroup="Save" InitialValue="-Select-" ControlToValidate="cmbDepartment" ForeColor="Red" ErrorMessage="Please Select Department" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>

                      <div class="col-md-3">
                                   <label>
                                   Mobile No.<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtMobileNo" runat="server" ></asp:TextBox>
                                       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeCode" ForeColor="Red" ErrorMessage="Please Enter Employee Code" Enabled="true"></asp:RequiredFieldValidator>--%>
                                   </div>
                               </div>

                     <div class="col-md-3">
                                   <label>
                                   Email Id<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                   
                                       <asp:TextBox ID="txtEmailId" runat="server" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvtxtEmailId" runat="server" ValidationGroup="Save" ControlToValidate="txtEmailId" ForeColor="Red" ErrorMessage="Please Enter EmailId" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>

                     <div class="col-md-3">
                                   <label>
                                   Date and Time of Visit <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDateTimePicker ID="dtpVisitDateTime" runat="server" RenderMode="Lightweight">
                                           
                                       </telerik:RadDateTimePicker>
                                       <asp:RequiredFieldValidator ID="rfvdtpVisitDateTime" runat="server" ValidationGroup="Save" ControlToValidate="dtpVisitDateTime" ForeColor="Red" ErrorMessage="Please Enter Visit Date and Time" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                         <br /><br />
                               </div>
                                
                          
                    <div class="col-md-3">
                                   <label>
                                   Diagnosis<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtDiagnosis" runat="server" CssClass="form-control required" TextMode="MultiLine" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvtxtDiagnosis" runat="server" ValidationGroup="Save" ControlToValidate="txtDiagnosis" ForeColor="Red" ErrorMessage="Please Enter Diagnosis Details" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>  
                     
                     <div class="col-md-3">
                                   <label>
                                   Advice Given<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtAdviceGiven" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvtxtAdviceGiven" runat="server" ControlToValidate="txtAdviceGiven" ValidationGroup="Save" ForeColor="Red" ErrorMessage="Please Enter Advice Given" Enabled="true"></asp:RequiredFieldValidator>
                                   </div>
                               </div>  
                     
                     <div class="col-md-3">
                                   <label>
                                   Doctor Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                      <%-- <telerik:RadComboBox ID="cmb" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>--%>
                                       <asp:TextBox ID="txtDoctorName" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvtxtDoctorName" runat="server" ControlToValidate="txtDoctorName" ValidationGroup="Save" ForeColor="Red" ErrorMessage="Please Enter Doctor Name" Enabled="true"></asp:RequiredFieldValidator>
                                      
                                   </div>
                        
                               </div>  
                    
                     <%--<div  id="MedicineDetails" runat="server" visible="true" class="form-group" style="margin-top:280px; margin-left:10px;">--%>
            
           

             <div id="MedicineDetails" runat="server" visible="true" class="form-group" style="margin-top:300px; margin-left:10px; overflow:auto" >

                  <h4>Medicine Details</h4>
                 <%--<div class="form-group" style="overflow:auto;">--%>
                     <table>
                         <tr>
                             <td>
                                 <telerik:RadGrid ID="rgvMedicineDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgvMedicineDetails_ItemCommand" OnNeedDataSource="rgvMedicineDetails_NeedDataSource" OnItemDataBound="rgvMedicineDetails_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               

                                               

                                               <telerik:GridTemplateColumn DataField="MedicineDescription" HeaderText="Medicine" SortExpression="MedicineDescription">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblMedicineDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineDescription") %>'></asp:Label>
                                                       <asp:Label ID="lblMedicineId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbMedicine" AppendDataBoundItems="true" RenderMode="Lightweight" Filter="Contains" runat="server" CssClass="Combo">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvMedicine" ControlToValidate="cmbMedicine" 
                                                           runat="server" InitialValue="-Select-" ForeColor="Red" ErrorMessage="Select Medicine" ValidationGroup="GridSave"></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                                

                                               <telerik:GridTemplateColumn DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblnewrows" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"newrow") %>' Visible="false"></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtQuantity" runat="server" MaxLength="500" placeholder="Enter the Quantity" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ForeColor="Red" 
                                           ErrorMessage="Please Enter Quantity" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                      
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
                <%-- </div>--%>
             </div>

         <%--</div>--%>

                    <div class="form-group" style="overflow:auto;">
                
                         <asp:Button ID="btnSave" runat="server" BackColor="#113d7a" BorderStyle="None" CausesValidation="true" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSave_Click" Text="Save" ValidationGroup="Save" />
                     &nbsp;&nbsp;
&nbsp;                         <asp:Button ID="btnCancel" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCancel_Click" CausesValidation="false" Text="Cancel" Visible="true" />
                 </div>
                    
             </div>
                 </asp:View>
             </asp:MultiView>
           
           
         </div>
         </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
