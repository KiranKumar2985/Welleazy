<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListOfEmployee.aspx.cs" Inherits="Welleazy.Admin.ListOfEmployee" EnableEventValidation="false" EnableSessionState="True" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin | List Of Employees</title>
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
     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" > 
     <ContentTemplate>--%>
      <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:350px;" >
            <%--<h4>List Of Corporate Employee<span style="float:right;">
            <asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;" CausesValidation="false"/>
              
           
           </h4>--%>
           
        
          <asp:MultiView ID="EmployeeView" runat="server">
              <asp:View ID="View" runat="server">
                   <h5> List Of Corporate Employee 
                       <span style="float:right;">
                      <asp:LinkButton ID="btnAddEmployee" runat="server" OnClick="btnAddEmployee_Click" ForeColor="#0033cc"><i class="glyphicon glyphicon-plus"></i> Add Employee </asp:LinkButton> | 
                           <asp:LinkButton ID="btnBulkAddEmployee" runat="server" PostBackUrl="~/UploadEmployeeDetails.aspx"  ForeColor="#0033cc"><i class="glyphicon glyphicon-plus"></i> Bulk Employee Upload</asp:LinkButton>
                       </span>
                 </h5> 
                   
                  <div class="line"></div>
                         <div class="form-group" id="SearchField" runat="server" visible="true" style="padding:10px; margin-top:-15px;">
                              <div class="col-md-3">
                      
                            <telerik:RadComboBox ID="rcbCorporate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="rcbCorporate_SelectedIndexChanged" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                       
                         </div>
                              <div class="col-md-3">
                                       <telerik:RadComboBox ID="cmbBranchId" RenderMode="Lightweight" runat="server" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" Filter="Contains">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                           </Items>
                                            </telerik:RadComboBox>
                                     
                               </div>
                             <div class="col-md-3">
                        <asp:TextBox ID="txt_EmpId" runat="server" placeholder="Employee Id" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                   
            </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Name" runat="server" placeholder="Employee Name" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                     <br />
            </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Email" runat="server" placeholder="Employee Email" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                   
            </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Mobile" runat="server" placeholder="Employee Mobile" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                    </div>
            <div class="col-md-3">
                  <telerik:RadComboBox ID="DDL_Status" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" >
                      <Items>
                          <telerik:RadComboBoxItem Value="-1" Text="Select Status" />
                            <telerik:RadComboBoxItem Value="1" Text="Active" />
                            <telerik:RadComboBoxItem Value="0" Text="InActive" />
                    </Items>
                  </telerik:RadComboBox>
                     
                    </div>
          </div>
                         <div class="form-group" id="GoButton" runat="server" visible="true" style="padding:30px; padding-bottom:0px; text-align:center; margin-top:70px;">
            
                <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go to Search" CssClass="Login_btn btn" OnClick="btnGo_Click" ValidationGroup="Details"/>
             
          
        </div>
                         <div class="form-group" style="padding:20px; margin-top:20px;">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>
         
          
          <div class="form-group" runat="server" id="EmployeeDetails" visible="true" style="overflow:auto;">
              <telerik:RadGrid ID="rgCaseDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgCaseDetails_ItemCommand" OnNeedDataSource="rgCaseDetails_NeedDataSource" OnPageIndexChanged="rgCaseDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                       <ItemTemplate>
                                           <asp:ImageButton ID="lnkCaseRefId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                           <%--<asp:LinkButton ID="lnkCaseRefId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRefId")%>'></asp:LinkButton>--%>
                                           <asp:Label ID="lblEmployeeRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeRefId")%>' Visible="false"></asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Activation URL" SortExpression="" Visible="false">
                                       <ItemTemplate>
                                           <asp:Button ID="btnURLLink" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Send Link" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="SendLink"></asp:Button>
                                           <asp:Label ID="lblActivationURL" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "AccountActivationURL")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Employee Id" SortExpression="EmployeeId">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmployeeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeId")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="Emailid">
                                       <ItemTemplate>
                                           <asp:Label ID="lblEmailid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Emailid")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Mobile Number" SortExpression="MobileNo">
                                       <ItemTemplate>
                                           <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Branch" SortExpression="Branch">
                                       <ItemTemplate>
                                           <asp:Label ID="lblBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Branch")%>'>
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
                                   <telerik:GridTemplateColumn HeaderText="Last Active Date" SortExpression="LastActiveDate">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLastActiveDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastActiveDate")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Last Inactive Date" SortExpression="LastInactiveDate">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLastInactiveDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastInactiveDate")%>'>
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
          
            
        </div>

                  </asp:View>
              <asp:View ID="Save" runat="server">
                  <h4>
                      <asp:Label ID="EmployeePageHeading" runat="server" Text="Update Corporate Employee"></asp:Label></h4>
                  <div class="line"></div>
                   <div class="form-group" style="padding:12px;">
                       <div class="col-md-3">
                                   <label>
                                   Corporate Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="rcbCorporateName" RenderMode="Lightweight" Enabled="true" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="rcbCorporateName_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate Name" />
                                </Items>
                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateId" runat="server" ControlToValidate="rcbCorporateName" ForeColor="Red" 
                                           ErrorMessage="Please Select Corporate" Enabled="true"  ValidationGroup="Save" InitialValue="Select Client Name" ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   Branch Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="rcbBranchId" AutoPostBack="true" OnSelectedIndexChanged="rcbBranchId_SelectedIndexChanged" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                </Items>
                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvBranchId" runat="server" ControlToValidate="rcbBranchId" ForeColor="Red" 
                                           ErrorMessage="Please Select Branch" Enabled="true"  ValidationGroup="Save" InitialValue="Select Branch" ></asp:RequiredFieldValidator>
                                   </div>
                               </div>

                       <div class="col-md-3">
                        <label>Product Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="cmbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AllowCustomText="true" AutoPostBack="true" OnSelectedIndexChanged="cmbProduct_SelectedIndexChanged" AppendDataBoundItems="true" Filter="Contains" CheckBoxes="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="cmbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
                         </div>
                         </div>


                       <div class="col-md-3">
                                   <label>
                                   Employee Id <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_EmployeeId" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ControlToValidate="txt_EmployeeId" ForeColor="Red" ErrorMessage="Please Enter Employee Id" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                           <br />
                               </div>
                      <%-- <div class="col-md-3">
                                   <label>
                                   First Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_FirstName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txt_FirstName" ForeColor="Red" ErrorMessage="Please Enter First Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>--%>
                       <%-- <div class="col-md-3">
                                   <label>
                                   Last Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_LastName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txt_LastName" ForeColor="Red" ErrorMessage="Please Enter Last Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>--%>
                       
                   </div>
                   <div class="form-group" style="padding:12px; ">
                       <div class="col-md-3">
                                   <label>
                                   Employee Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_EmployeeName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txt_EmployeeName" ForeColor="Red" ErrorMessage="Please Enter Employee Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   Email Id <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_Emailid" runat="server" class="form-control required" TextMode="SingleLine" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txt_Emailid" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="Save" ></asp:RequiredFieldValidator>
                                       <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                                       <asp:RegularExpressionValidator ID="revEmailid" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_Emailid" Enabled="true"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   Mobile No <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_MobileNo" runat="server" class="form-control required" MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txt_MobileNo" ForeColor="Red" ErrorMessage="Please Enter Mobile Name" Enabled="true"  ValidationGroup="Save" ></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" ControlToValidate="txt_MobileNo" ValidationGroup="Save" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   Gender <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                  <telerik:RadComboBox ID="rcbGender" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" >
                      <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Gender" />
                            <telerik:RadComboBoxItem Value="1" Text="Male" />
                            <telerik:RadComboBoxItem Value="2" Text="Female" />
                            <telerik:RadComboBoxItem Value="3" Text="Transgender" />
                          </Items>
                   
                  </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rcbGender" ForeColor="Red" ErrorMessage="Please Select Gender" Enabled="true"  ValidationGroup="Save" InitialValue="Select Gender"></asp:RequiredFieldValidator>
                     </div>
                           <br />
                               </div>
                       
                        <%--</div>
                   <div class="form-group" style="padding:12px;">--%>
                       <div class="col-md-3">
                                   <label>
                                   Date Of Birth <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDatePicker ID="rdpEmployeeDOB" runat="server" RenderMode="Lightweight" DateInput-DateFormat="dd-MM-yyyy"></telerik:RadDatePicker>
                                   </div>
                               </div>
                       <div class="col-md-3">
                        <label>State  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbState" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="rcbState_SelectedIndexChanged" ValidationGroup="Save" CausesValidation="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="rcbState" ForeColor="Red" ErrorMessage="Please Select State" Enabled="true"  ValidationGroup="Save" InitialValue="Select State"></asp:RequiredFieldValidator>
                           
                         </div>
                    </div>
                       <div class="col-md-3">
                        <label>City/District  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbCity" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Save">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="rcbCity" ForeColor="Red" ErrorMessage="Please Select City" Enabled="true"  ValidationGroup="Save" InitialValue="Select City"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                       <div class="col-md-3">
                        <label>Area/Locality <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_AreaLocality" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAreaLocality" runat="server" ControlToValidate="txt_AreaLocality" ForeColor="Red" ErrorMessage="Please Enter Area/Locality" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                         </div>
                          <br />
                    </div>
                                            
                 <%--  </div>
                   <div class="form-group" style="padding:12px;">--%>
                       <div class="col-md-3">
                        <label>Landmark </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Landmark" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            
                         </div>
                    </div>
                       <div class="col-md-3">
                                   <label>
                                   Address
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_Address" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       
                                   </div>
                           <br /><br />
                               </div>
                       <div class="col-md-3">
                             <label>
                                   Pincode <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                        <asp:TextBox ID="txt_Pincode" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txt_Pincode" ForeColor="Red" ErrorMessage="Please Enter Pincode" Enabled="true"  ValidationGroup="Save" ></asp:RequiredFieldValidator>
                     </div>
                    </div>
                       <div class="col-md-3">
                                   <label>
                                   Geo Location
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_GeoLocation" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                   </div>
                           <br /><br />
                               </div>
                       
                       
                   </div>

                  <div class="form-group" runat="server" id="services" visible="true" style="overflow:auto; width:100%; padding:10px;">
                               
                                           <telerik:RadGrid ID="rgProductServices" runat="server"
                            AutoGenerateColumns="False" Visible="true" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                            HeaderStyle-VerticalAlign="Middle"
                            ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                            OnItemDataBound="rgProductServices_ItemDataBound" CellPadding="4" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                            <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true" >
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Assigned Services" SortExpression="">
                                        <HeaderTemplate>
                    <asp:Label ID="lblProductHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Product")%>' ></asp:Label>
                </HeaderTemplate>
                                        <ItemTemplate>
                                              <asp:CheckBox  ID="chkAllTask" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="chkAllTask_CheckedChanged" />
                                                   
                                           <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId")%>'></asp:Label>
                                            <telerik:RadGrid ID="rgProductServicesDepth" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CellSpacing="0" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                                                HeaderStyle-VerticalAlign="Middle"
                                                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                                                Skin="Bootstrap" CellPadding="4" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowSorting="True" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                                                <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn SortExpression="">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblProductHeader" ForeColor="White" runat="server"></asp:Label>
                                                                
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBoxList ID="cbTasks" runat="server" RepeatDirection="Vertical" RepeatColumns="6">
                                                                </asp:CheckBoxList>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </telerik:RadGrid>

                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </telerik:RadGrid>
                                  
                               </div>


                   <div class="form-group" style="padding:12px;" runat="server" id="NotUpdatedByEmployee" visible="true">
                       <div class="col-md-8">
                                   <label>
                                   Account Activation URL
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_ActivationURL" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                   </div>
                               </div>
                                   
                       <div class="col-md-3" style="display:none;">
                                   <label>
                                   Created On
                                   </label>
                                   <div class="selector">
                                        <telerik:RadDateTimePicker ID="rdtCreatedOn" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                                   </div>
                               </div>
                       <div class="col-md-3" style="display:none;">
                                   <label>
                                   Created By
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_CreatedBy" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                   </div>
                               </div>
                       <div class="col-md-3" style="display:none;">
                                   <label>
                                   Modified On
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDateTimePicker ID="rdtModifiedOn" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                                   </div>
                               </div>
                       <div class="col-md-3" style="display:none;">
                                   <label>
                                   Modified By
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_ModifiedBy" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                   </div>
                           <br /><br />
                               </div>
                       
                       <div class="col-md-3">
                                   <label>
                                   Last Active Date
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDateTimePicker ID="dtplastActiveDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   Last InActive Date
                                   </label>
                                   <div class="selector">
                                        <telerik:RadDateTimePicker ID="dtplastInActiveDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                                   </div>
                               </div>
                       <div class="col-md-3">
                                   <label>
                                   InActive Reason
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txt_InactiveReason" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
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
                           <br /><br />
                               </div>
                                    
                  </div>
                   <div class="form-group" style="padding-left:25px; margin-top:80px; text-align:center;">
                       <div class="col-md-10">
                                   <label>
                                  
                                   </label>
                                   <div class="selector">
                                       
                                   <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Save" ValidationGroup="Save" />
                              &nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                             
                                       </div>
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
          <%--   </ContentTemplate>
      <Triggers>
             <asp:PostBackTrigger ControlID="txt_Mobile"  />
             <asp:PostBackTrigger ControlID="txt_Name" />
             <asp:PostBackTrigger ControlID="txt_Email"  />
             <asp:PostBackTrigger ControlID="rgCaseDetails" />
         </Triggers>
        </asp:UpdatePanel>--%>
      <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",2000);
 }
</script>
    </asp:Content>
