<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="AddDoctorDetails.aspx.cs" Inherits="Welleazy.Master.AddDoctorDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
       <%-- <asp:UpdatePanel ID="upDoctor" runat="server" >
            <ContentTemplate>--%>
               
      <div class="form-group" style="width:100%; height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
           <h4>Doctors List 
           <span style="float:right;">
           <asp:LinkButton ID="btnAddDoctor" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnAddDoctor_Click" ><i class="glyphicon glyphicon-plus"></i> Add Doctor </asp:LinkButton>

           </span>
           </h4>
           
           <div class="line"></div>
           <asp:MultiView ID="DoctorView" runat="server">
               <asp:View ID="View" runat="server">
                   <div class="form-group" style="overflow:auto;">
                   <telerik:RadGrid ID="rgvDoctorDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                       BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvDoctorDetails_ItemCommand" OnNeedDataSource="rgvDoctorDetails_NeedDataSource" OnPageIndexChanged="rgvDoctorDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDoctorNameName" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'></asp:LinkButton>
                                       <asp:Label ID="lblDoctorId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Contact No." SortExpression="ContactNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblContactNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContactNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Alternate Contact No." SortExpression="AlternateContactNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAlternateContactNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AlternateContactNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="EmailId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                              
                               <telerik:GridTemplateColumn HeaderText="Is Active" SortExpression="IsActive">
                                   <ItemTemplate>
                                       <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
                       </div>
               </asp:View>
               <asp:View ID="Save" runat="server">
                  
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Doctor Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtDoctorName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" ControlToValidate="txtDoctorName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Doctor Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Mobile No<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtContactNo" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Contact No." Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="Save" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Alternate Contact No.<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtAlternateContactNo" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAlternateContatNo" runat="server" ControlToValidate="txtAlternateContactNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Alternate Contact No." Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Email Id<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtEmailId" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ForeColor="Red" 
                                           ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpression_email" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txtEmailid"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                               
                               
                           </div>
                           
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Doctor Language<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbLanguage" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" AppendDataBoundItems="true" runat="server" Filter="Contains" RenderMode="Lightweight" CssClass="Combo">
                                           <Items>
                                               <%--<telerik:RadComboBoxItem Value="0" Text="-Select-" />--%>
                                               <%--<telerik:RadComboBoxItem Value="1" Text="English" />
                                               <telerik:RadComboBoxItem Value="2" Text="Hindi" />--%>
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" ForeColor="Red" 
                                           ErrorMessage="Please Select Language" InitialValue="" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div></div>
                               <div class="col-md-3">
                                   <label>
                                   Doctor Qualification<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbQualification" runat="server" Filter="Contains" RenderMode="Lightweight" CssClass="Combo">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="MBBS" />
                                               <telerik:RadComboBoxItem Value="2" Text="M.Tech" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvQualification" runat="server" ControlToValidate="cmbQualification" ForeColor="Red" 
                                           ErrorMessage="Please Select Qualification" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="Save" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Registration No.<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtRegistrationNo" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvRegistrationNumber" runat="server" ControlToValidate="txtRegistrationNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Registration No." Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   PAN Card No.<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtPANCardNo" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvPANCardNo" runat="server" ControlToValidate="txtPANCardNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter PAN Card No." Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>

                                   <br />

                               </div>
                               
                               
                           </div>                                        
                               
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Address<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtAddress" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ForeColor="Red" 
                                           ErrorMessage="Please Enter Address" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>
                               </div>

                               <div class="col-md-3">
                                   <label>
                                   Area<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtArea" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="txtArea" ForeColor="Red" 
                                           ErrorMessage="Please Enter Area" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>
                               </div>

                               <div class="col-md-3">
                                   <label>
                                   State<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbState" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbState_SelectedIndexChanged" Filter="Contains" RenderMode="Lightweight" CssClass="Combo">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="cmbState" ForeColor="Red" 
                                           ErrorMessage="Please Select State" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>
                               </div>

                               <div class="col-md-3">
                                   <label>
                                   City<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCity" runat="server" AppendDataBoundItems="true" Filter="Contains" RenderMode="Lightweight" CssClass="Combo">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="cmbCity" ForeColor="Red" 
                                           ErrorMessage="Please Select City" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       <br /><br />
                                   </div>
                               </div>

                               </div>

                           <div class="form-group">

                                    <div class="col-md-3">
                                   <label>
                                   Tele MER Rate<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtTeleMERRate" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvTeleMERRate" runat="server" ControlToValidate="txtTeleMERRate" ForeColor="Red" 
                                           ErrorMessage="Please Enter Tele MER Rate" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>
                               </div>

                                    <div class="col-md-3">
                                   <label>
                                   Tele Video Rate<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtVideoMERRate" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvVideoMERRate" runat="server" ControlToValidate="txtVideoMERRate" ForeColor="Red" 
                                           ErrorMessage="Please Enter Video MER Rate" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                       
                                   </div>
                               </div>
                               
                                    <div class="col-md-3">
                                   <label>
                                   Is Active
                                   </label>
                                   <div class="selector">
                                       <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                       </asp:RadioButtonList>
                                       
                                   </div>
                                       
                               </div>
                               <div class="col-md-3">
                                   <br /><br /><br /><br /><br />
                               </div>
                                                  
                           </div>
                                          
                           <div  class="form-group" style="padding-left:20px; overflow:auto; margin-top:30px;">

<h4><b>Add Document Details:</b></h4>
                       
                                   <telerik:RadGrid ID="rgDoctorDocumentDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgDoctorDocumentDetails_ItemCommand" OnNeedDataSource="rgDoctorDocumentDetails_NeedDataSource"  OnItemDataBound="rgDoctorDocumentDetails_ItemDataBound"
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="PersonName" HeaderText="Document Name" SortExpression="DocumentName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblDocumentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DocumentName").ToString()%>'></asp:Label>
                                                       
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadComboBox ID="cmbDocumentName" runat="server" class="form-control required" MaxLength="230" placeholder="Enter Contact Person Name" ValidationGroup="GridSave">
                                                           <%--<Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                                               <telerik:RadComboBoxItem Value="1" Text="Digital Signature" />
                                                               <telerik:RadComboBoxItem Value="2" Text="Profile Picture" />
                                                               <telerik:RadComboBoxItem Value="3" Text="PAN Certificate" />
                                                               <telerik:RadComboBoxItem Value="4" Text="Registration Certificate" />
                                                               <telerik:RadComboBoxItem Value="5" Text="Cancelled Cheque" />
                                                               <telerik:RadComboBoxItem Value="6" Text="KYC Registration" />
                                                               <telerik:RadComboBoxItem Value="7" Text="Bank Declaration" />
                                                               <telerik:RadComboBoxItem Value="8" Text="PAN Declaration" />
                                                           </Items>--%>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" ControlToValidate="cmbDocumentName" ForeColor="Red" 
                                           ErrorMessage="Select Document Type" InitialValue="-Select-" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn DataField="DocumentContent" HeaderText="Document">
                                                   <ItemTemplate>
                                                       
                                                       <asp:Label ID="lblDocument" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DocumentContent").ToString()%>'></asp:Label>
                                                       
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadAsyncUpload ID="raUploadDocument"  runat="server" InitialFileInputsCount="1" MaxFileInputsCount="1"   class="form-control required" MaxLength="230" placeholder="Upload Document" ValidationGroup="GridSave">
                                                           
                                                       </telerik:RadAsyncUpload>
                                                      <%-- <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" ControlToValidate="cmbDocumentName" ForeColor="Red" 
                                           ErrorMessage="Select Document Type" InitialValue="-Select-" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>

                                               <telerik:GridTemplateColumn HeaderText="Add/Delete">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="btnDeleteDocumentDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="DeleteDocumentDetails" OnClientClick="return deleletconfig();" Text="Delete">
                                                                        </asp:LinkButton>
                                                       
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddDocumentDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AddDocumentDetails" Text="Add" ValidationGroup="GridSave" />
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                              

                        </div>
                           
                           <div  class="form-group" style="margin-top:120px; overflow:auto;">

                           <h4><b>Account Details:</b></h4>
                      <br />
                           <div class="col-md-3">
                                   <label>
                                   Account Number<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" ForeColor="Red" 
                                           ErrorMessage="Please Enter Account Number" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div> 

                           <div class="col-md-3">
                                   <label>
                                   Bank Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtBankName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Bank Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div> 

                           <div class="col-md-3">
                                   <label>
                                   Account Holder Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtAccountHolderName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvAccountHolderName" runat="server" ControlToValidate="txtAccountHolderName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Account Holder Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div> 

                           <div class="col-md-3">
                                   <label>
                                   Bank Branch<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtBankBranch" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvBankBranch" runat="server" ControlToValidate="txtBankBranch" ForeColor="Red" 
                                           ErrorMessage="Please Enter Bank Branch Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               <br />
                               </div> 
                               
                        
                         <div class="col-md-3">
                                   <label>
                                   IFSC Code<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtIFSCCode" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIFSCCode" ForeColor="Red" 
                                           ErrorMessage="Please Enter IFSC Code" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               
                       
                   </div>

                   <div class="form-group" style="padding-left:20px; overflow:auto; margin-top:10px;">
                       <table>
                           <tr>
                               <td>
                                   <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Save" ValidationGroup="Save" />
                               </td>
                               <td style="width:20px;"></td>
                               <td>
                                   <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                               </td>
                           </tr>
                       </table>
                       </div>
                           
               
               </asp:View>
           </asp:MultiView>
            </div>
                       

   <%-- </ContentTemplate>
            <Triggers>
                
                <asp:PostBackTrigger ControlID="rgvDoctorDetails" />
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

