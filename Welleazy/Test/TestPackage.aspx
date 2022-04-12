<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="TestPackage.aspx.cs" Inherits="Welleazy.Test.TestPackage" %>


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
      <div >
           <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> 
               <asp:LinkButton ID="LinkPackage" runat="server" OnClick="LinkPackage_Click" ForeColor="#0033cc"> Test Package List</asp:LinkButton>
               <span style="float:right; font-size:small;">
                   <asp:LinkButton ID="Linkspl1" runat="server" OnClick="Linkspl1_Click" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Test Package</asp:LinkButton> | <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="~/Test/UploadTestpackage.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Bulk Upload</asp:LinkButton></span></h5>
                                   <div class="line"></div>
               
          <asp:MultiView ID="PackageView" runat="server">
              <asp:View ID="View" runat="server">
                 
                <%--  <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">--%>
           
           <div class="container">
               <div class="row">
            <div class="col-lg-3 col-sm-6">
                        <asp:TextBox ID="txt_PackageName" runat="server"  placeholder="Package Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_PackageName_TextChanged"></asp:TextBox>
                    </div>
               
                       <div class="col-lg-3 col-sm-6">
                        <asp:TextBox ID="txt_SKUCode" runat="server" placeholder="SKU Code" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_SKUCode_TextChanged"></asp:TextBox>
                    </div>
               <div class="col-lg-3 col-sm-6">
                        <asp:TextBox ID="txt_ClientName" runat="server" placeholder="Corporate Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_ClientName_TextChanged"></asp:TextBox>
                    </div>

                   <div class="col-lg-3 col-sm-6">
                        <asp:Button ID="btnGo" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Go" CssClass="Login_btn btn" OnClick="btnGo_Click" ></asp:Button>
                    </div>
                  
                   </div>
               <br />
               <br />
               <div>
                  <telerik:RadGrid ID="rgvTestPackageDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true" OnItemCommand="rgvTestPackageDetails_ItemCommand" OnNeedDataSource="rgvTestPackageDetails_NeedDataSource" OnPageIndexChanged="rgvTestPackageDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Package Name" SortExpression="PackageName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkPackageName" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "PackageName")%>'></asp:LinkButton>
                                       <asp:Label ID="lblPackageId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PackageId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="SKU" SortExpression="ProductSKU">
                                   <ItemTemplate>
                                       <asp:Label ID="lblProductSKU" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductSKU")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <%--<telerik:GridTemplateColumn HeaderText="Landline No" SortExpression="LandLineNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblLandLineNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LandLineNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="Emailid">
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmailid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Emailid")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Head Office Address" SortExpression="HeadOfficeAddress">
                                   <ItemTemplate>
                                       <asp:Label ID="lblHeadOfficeAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HeadOfficeAddress")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>--%>
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
                   
              </div>
                  
               </asp:View>
               <asp:View ID="Save" runat="server">
                 <div class="container">
                     <div class="row">
                         <div class="col-lg-3 col-sm-6">
                        <label>Product SKU  <span class="mandatory">*</span></label>
                             
                         <div class="selector">
                             <asp:TextBox ID="txtProductSKU" runat="server" CssClass="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvProductSKU" runat="server" ControlToValidate="txtProductSKU" ForeColor="Red" 
                                           ErrorMessage="Please Enter Product SKU" Enabled="true" ValidationGroup="Save" ></asp:RequiredFieldValidator>
                             </div>
                         </div>
                         <div class="col-lg-3 col-sm-6">
                        <label>Package Name </label>                             
                         <div class="selector">
                             <asp:TextBox ID="txtPackageName" runat="server" CssClass="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPackageName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Package Name" Enabled="true" ValidationGroup="Save"></asp:RequiredFieldValidator>
                             </div>
                             </div>
                         <div class="col-lg-3 col-sm-6">
                        <label>Corporate Name </label>                             
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateName" runat="server" CssClass="Combo" RenderMode="Lightweight" Filter="Contains" AppendDataBoundItems="true">
                                          <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate Name" />
                                </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" 
                                           ErrorMessage="Please Select Corporate" InitialValue="Select Corporate Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         </div>
                         <div class="col-lg-3 col-sm-6">
                        <label>Servicing Channel </label>                             
                         <div class="selector">
                             <asp:TextBox ID="txtReferringChannel" runat="server" CssClass="form-control required" TextMode="SingleLine"></asp:TextBox>
                             <br /><br />
                             </div>
                         </div>
                     </div>
                     <div class="row">
                         
                         <div class="col-lg-3 col-sm-6">
                           <label>Product Type </label>                             
                             <div class="selector">
                                  <telerik:RadComboBox ID="cmbProductType" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" AutoPostBack="true" OnSelectedIndexChanged="cmbProductType_SelectedIndexChanged" runat="server">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="AHC"/>
                                               
                                           </Items>

                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvProductType" runat="server" ControlToValidate="cmbProductType" ForeColor="Red" 
                                           ErrorMessage="Please Select Product Type" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                 <br /><br />
                             </div>
                         
                             </div>
                         </div>
                     <div class="row">
                         <div class="col-lg-3 col-sm-6">
                           <label>Test Include </label>                             
                            
                                  <telerik:RadComboBox ID="cmbTestInclude" CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" AppendDataBoundItems="true" 
                                      EnableCheckAllItemsCheckBox="true"  CssClass="Combo" runat="server" RenderMode="Lightweight" Filter="Contains" >
                                      <Items>
                                          <%--<telerik:RadComboBoxItem  Value="0" Text="Select Test"/>--%>
                                          <%--<telerik:RadComboBoxItem Value="1" Text="test2" />--%>
                                      </Items>
                                  </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvTestInclude" runat="server" ControlToValidate="cmbTestInclude" ForeColor="Red" 
                                           ErrorMessage="Please Select Test" InitialValue="Select Test" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                           
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Normal Price </label>                             
                             <div class="selector">
                                  <asp:TextBox ID="txtNormalPrice" runat="server" CssClass="form-control required" TextMode="SingleLine" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvNormalPrice" runat="server" ControlToValidate="txtNormalPrice" ForeColor="Red" 
                                           ErrorMessage="Please Enter Normal Price"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>HNI Price </label>                             
                             <div class="selector">
                                  <asp:TextBox ID="txtHNIPrice" runat="server" CssClass="form-control required" TextMode="SingleLine" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvHNIPrice" runat="server" ControlToValidate="txtHNIPrice" ForeColor="Red" 
                                           ErrorMessage="Please Enter HNI Price"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Status </label>                             
                             <div class="selector">
                                  <telerik:RadComboBox ID="cmbStatus" CssClass="Combo" RenderMode="Lightweight" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="cmbProductType_SelectedIndexChanged" runat="server">
                                          <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-"/>
                                               <telerik:RadComboBoxItem Value="1" Text="Active" />
                                               <telerik:RadComboBoxItem Value="2" Text="Disabled" />
                                               <telerik:RadComboBoxItem Value="3" Text="On Hold" />
                                           </Items>
                                       </telerik:RadComboBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbStatus" ForeColor="Red" 
                                           ErrorMessage="Please Select Status" InitialValue="-Select-" ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                 <br /><br />
                             </div>
                         
                             </div>
                         </div>
                      <div class="row">
                         <div class="col-lg-3 col-sm-6">
                           <label>Product Type </label>                             
                             <div class="selector">
                                  <telerik:RadComboBox ID="cmbProductType_Concultation" AutoPostBack="true" runat="server" Filter="Contains" RenderMode="Lightweight" CssClass="Combo">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                      
                                               <telerik:RadComboBoxItem Value="1" Text="E-Consultation"/>
                                              
                                           </Items>

                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbProductType_Concultation" ForeColor="Red" 
                                           ErrorMessage="Please Select Product Type" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Consultation Type </label>                             
                             <div class="selector">
                                  <telerik:RadComboBox ID="cmbConsultationType" runat="server" CssClass="Combo" Filter="Contains" RenderMode="Lightweight">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="Tele Consultation" />
                                               <telerik:RadComboBoxItem Value="2" Text="Video Consultation" />
                                               
                                           </Items>
                                       </telerik:RadComboBox>
                                 <asp:RequiredFieldValidator ID="rfvConsultationType" runat="server" ControlToValidate="cmbConsultationType" ForeColor="Red" 
                                           ErrorMessage="Please Select Consultation Type" InitialValue="0" ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Doctor Specialization </label>                             
                             <div class="selector">
                                 <telerik:RadComboBox ID="cmbDoctorSpecialization" CheckBoxes="true"  runat="server" EnableCheckAllItemsCheckBox="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" >
                                           <Items>
                                               <%--<telerik:RadComboBoxItem Value="0" Text="-Select-" />--%>
                                               <telerik:RadComboBoxItem Value="1" Text="MBBS" />
                                               <telerik:RadComboBoxItem Value="2" Text="MD" />
                                               <telerik:RadComboBoxItem Value="3" Text="Cardiologist" />
                                               
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvDoctorSpecialization" runat="server" ControlToValidate="cmbDoctorSpecialization" ForeColor="Red" 
                                           ErrorMessage="Please Select Specialization" InitialValue=""    ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Status </label>                             
                             <div class="selector">
                                 <telerik:RadComboBox ID="cmbConsultation_Status" runat="server" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" >
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="Active" />
                                               <telerik:RadComboBoxItem Value="2" Text="Disabled" />
                                               <telerik:RadComboBoxItem Value="3" Text="On Hold" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvHeadOfficeAddress" runat="server" ControlToValidate="cmbConsultation_Status" ForeColor="Red" 
                                           ErrorMessage="Please Select Status" InitialValue="-Select-" ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                 <br /><br />
                             </div>
                         
                             </div>
                          </div>
                     <div class="row">
                         <div class="col-lg-3 col-sm-6">
                           <label>Product Type </label>                             
                             <div class="selector">
                                <telerik:RadComboBox ID="cmbProductType_SecondOpinion" AutoPostBack="true"  runat="server" CssClass="Combo" Filter="Contains" RenderMode="Lightweight">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               
                                               <telerik:RadComboBoxItem Value="1" Text="Second Opinion"/>
                                           </Items>

                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbProductType_SecondOpinion" ForeColor="Red" 
                                           ErrorMessage="Please Select Product Type" InitialValue="-Select-" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Normal Price </label>                             
                             <div class="selector">
                                <asp:TextBox ID="txtSO_NormalPrice" runat="server"  TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSO_NormalPrice" ForeColor="Red" 
                                           ErrorMessage="Please Enter Normal Price"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>HNI Price </label>                             
                             <div class="selector">
                                 <asp:TextBox ID="txtSO_HNIPrice" runat="server"  TextMode="SingleLine" CssClass="form-control required" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSO_HNIPrice" ForeColor="Red" 
                                           ErrorMessage="Please Enter HNI Price" ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         <div class="col-lg-3 col-sm-6">
                           <label>Status </label>                             
                             <div class="selector">
                                 <telerik:RadComboBox ID="cmbSO_Status" runat="server" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" AppendDataBoundItems="true" >
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="Active" />
                                               <telerik:RadComboBoxItem Value="2" Text="Disabled" />
                                               <telerik:RadComboBoxItem Value="3" Text="On Hold" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cmbSO_Status" ForeColor="Red" 
                                           ErrorMessage="Please Select Status" InitialValue="-Select-" ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                             </div>
                         
                             </div>
                         </div>
                     <div class="row">
                         <div class="col-lg-3 col-sm-6">
                           <label>Is Active </label>                             
                             <div class="selector">
                                <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                             </div>
                         
                             </div>
                         
                         </div>
                     <div class="form-group">
                         <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" ValidationGroup="Save" />&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                         </div>
                         
                 </div>
              </asp:View>
          </asp:MultiView>
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
