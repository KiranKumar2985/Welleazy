<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BranchManagement.aspx.cs" Inherits="Welleazy.Corporate.BranchManagement" %>
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
      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <h4>Corporate Branch List
           <span style="float:right;">
           <asp:LinkButton ID="btnBranch" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnBranch_Click" ><b><i class="glyphicon glyphicon-plus"></i> Add Branch </b></asp:LinkButton></span>
         </h4>
           
           <div class="line"></div> 
          <div class="form-group" style="display:block; margin-top:-30px;" id="CorporateList" runat="server" visible="true">
              <div class="col-md-3">
                        <label>Corporate Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="rcbCorporateName_SelectedIndexChanged" ValidationGroup="Case" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                         </div>
                         </div>
                    </div>
          <div class="form-group" style="margin-top:100px; padding:16px;">
          <asp:MultiView ID="BranchListView" runat="server">
              <asp:View ID="View" runat="server">
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgvBranchDetails" runat="server" MasterTableView-BorderWidth="1" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" 
                      BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" 
                      HeaderStyle-ForeColor="White" OnItemCommand="rgvBranchDetails_ItemCommand" OnNeedDataSource="rgvBranchDetails_NeedDataSource" OnPageIndexChanged="rgvBranchDetails_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="BranchDetailsId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkBranchDetailsId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <asp:Label ID="lblBranchDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchDetailsId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="CorporateName" SortExpression="CorporateName" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch" SortExpression="Branch" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Branch")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Person Name" SortExpression="PersonName" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblPersonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PersonName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Mobile Number" SortExpression="MobileNo" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="EmailId" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="State" SortExpression="StateName" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="City" SortExpression="DistrictName" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DistrictName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Address" SortExpression="Address" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Is Active" SortExpression="IsActive" >
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
                  <div class="form-group" style="background:white;">
                     
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Branch Name
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtBranchName" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvBranchName" runat="server" ControlToValidate="txtBranchName" ForeColor="Red" ErrorMessage="Enter Branch Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Person Name
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtPersonName" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvPersonName" runat="server" ControlToValidate="txtPersonName" ForeColor="Red" ErrorMessage="Enter Person Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Mobile No
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" MaxLength="10" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" ErrorMessage="Enter Mobile No" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                               
                             <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Invalid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="Save" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Email Id
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtEmailId" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ForeColor="Red" ErrorMessage="Enter Email Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="revEmailId" runat="server" ErrorMessage="Enter Valid Email Id" ForeColor ="Red" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txtEmailId"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                               </div>
                      <div class="form-group">
                               <div class="col-md-3">
                        <label>State  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbState" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="rcbState_SelectedIndexChanged" ValidationGroup="Save" CausesValidation="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="rcbState" ForeColor="Red" ErrorMessage="Select State" Enabled="true"  ValidationGroup="Save" InitialValue="Select State"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="rcbCity" ForeColor="Red" ErrorMessage="Select City" Enabled="true"  ValidationGroup="Save" InitialValue="Select City"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                               <div class="col-md-3">
                                   <label>
                                   Address
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtAddress" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <%--<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Enter Address" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                   </div>
                               </div>
                             
                               <div class="col-md-2">
                                   <label>Is Active </label>
                                   <div class="selector">
                                       <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                   </div>
                               </div>
                               <div class="col-md-6">
                                   <label> </label>
                                   <div class="selector">
                                       <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Save" />
                                       &nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                                   </div>
                               </div>
                          
                         </div>
                     
                  </div>
                  
                 
              </asp:View>
          </asp:MultiView>
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

