<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="AddCorporateDetails.aspx.cs" Inherits="Welleazy.AddCorporateDetails" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

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
        <asp:UpdatePanel ID="upCorporate" runat="server" >
            <ContentTemplate>
               
      <div class="form-group" style="width:100%; height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
           <h4>Corporates List 
           
           <span style="float: right;">
         <asp:LinkButton ID="btnCorporate" runat="server" Visible="true" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCorporate_Click" ><i class="glyphicon glyphicon-plus"></i> Add Corporate </asp:LinkButton>
                
           </span>

           </h4>
           
           <div class="line"></div>
           <asp:MultiView ID="CorporateView" runat="server">
               <asp:View ID="View" runat="server">
                   <div class="form-group" style="padding:10px; margin-top:-15px;" runat="server" id="SearchField" visible="true">
                              <div class="col-md-3">
                      
                            <telerik:RadComboBox ID="rcbCorporate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" CheckBoxes="true" runat="server" AppendDataBoundItems="true"  >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                       
                         </div>
          
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Email" runat="server" placeholder="Email" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                    <br />

            </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Mobile" runat="server" placeholder="Mobile" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                    </div>
            <div class="col-md-3">
                <telerik:RadComboBox ID="rcbStatus" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" >
                      <Items>
                          <telerik:RadComboBoxItem Value="-1" Text="Select Status" />
                            <telerik:RadComboBoxItem Value="1" Text="Active" />
                            <telerik:RadComboBoxItem Value="0" Text="InActive" />
                    </Items>
                  </telerik:RadComboBox>
                </div>
          </div>
                         <div class="form-group" style="padding:30px; padding-bottom:0px; margin-top:25px; text-align:center;" runat="server" id="SearchButton" visible="true">
            
                <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go to Search" OnClick="btnGo_Click" CssClass="Login_btn btn"/>
             
          
        </div>
                   <div class="form-group" style="margin-top:20px;">
                   <telerik:RadGrid ID="rgvCorporateDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvCorporateDetails_ItemCommand" OnNeedDataSource="rgvCorporateDetails_NeedDataSource" OnPageIndexChanged="rgvCorporateDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkCorporateName" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:LinkButton>
                                       <asp:Label ID="lblCorporateId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Landline No" SortExpression="LandLineNo">
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
                        <table border="1">
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Corporate Name<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtCorporateName" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="txtCorporateName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Corporate Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Mobile No<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Mobile Name" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="Save" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Landline No<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtLandLineNo" runat="server" class="form-control required" MaxLength="15" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvLandLineNo" runat="server" ControlToValidate="txtLandLineNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter LandLine No." Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Email Id<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtEmailid" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailid" ForeColor="Red" 
                                           ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator><asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                                       <asp:RegularExpressionValidator ID="RegularExpression_email" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txtEmailid"></asp:RegularExpressionValidator>

                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Head Office Address<span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtHeadOfficeAddress" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvHeadOfficeAddress" runat="server" ControlToValidate="txtHeadOfficeAddress" ForeColor="Red" 
                                           ErrorMessage="Please Enter Head Office Address" Enabled="true"  ValidationGroup="Save" 
                                           ></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Branch Office Address
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtBranchOfficeAddress" runat="server" class="form-control required" TextMode="SingleLine"></asp:TextBox>
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
                                       <br /><br />
                                   </div>
                               </div>
                           </div>
                       </table>
                        <div  class="form-group" style="padding-left:20px; overflow:auto;">

<thead><b>Add Contact Person Details:</b></thead><br /><br />
                       <table border="1">
                          
                           <tr>
                               <td>
                                   <telerik:RadGrid ID="rgCorporateContactDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" OnItemCommand="rgCorporateContactDetails_ItemCommand" OnNeedDataSource="rgCorporateContactDetails_NeedDataSource" 
PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="PersonName" HeaderText="Person Name" SortExpression="PersonName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblPersonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PersonName").ToString()%>'></asp:Label>
                                                       <%--<asp:Label ID="lblContactDetailsID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ContactDetailsId") %>' Visible="false"></asp:Label>--%><%-- <telerik:RadDatePicker ID="" runat="server" Culture="English (United States)"
                                                Width="100px" ReadOnly="true" Enabled="false" DateInput-DateFormat="dd/MM/yyyy"
                                                DateInput-EmptyMessage="DD/MM/YYYY" DateInput-MaxLength="10" TitleFormat="MMMM yyyy"
                                                DbSelectedDate=''>
                                            </telerik:RadDatePicker>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtPersonName" runat="server" class="form-control required" MaxLength="230" placeholder="Enter Contact Person Name" ValidationGroup="GridSave">
                                                       </telerik:RadTextBox>
                                                       <asp:RequiredFieldValidator ID="rfvPersonName" runat="server" ControlToValidate="txtPersonName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Person Name" Enabled="true"  ValidationGroup="GridSave" 
                                           ></asp:RequiredFieldValidator>
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
                                               <telerik:GridTemplateColumn DataField="ContactNo" HeaderText="Contact No." SortExpression="ContactNo">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblContactNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ContactNo") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <telerik:RadTextBox ID="txtContactNo" runat="server" MaxLength="256" placeholder="Enter Contact No.">
                                                       </telerik:RadTextBox>
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
                                               <telerik:GridTemplateColumn HeaderText="Add/Delete">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="btnDeleteContactDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="DelateContactDetails" OnClientClick="return deleletconfig();" Text="Delete">
                                                                        </asp:LinkButton>
                                                       <asp:RadioButtonList ID="rbdIsActive" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                           <asp:ListItem Value="True">Active</asp:ListItem>
                                                           <asp:ListItem Value="False">InActive</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                       <asp:Label ID="lblIsActive" runat="server" Visible="false"></asp:Label>
                                                       <%-- <asp:Label ID="Label1" runat="server" Visible="false"='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:Label>--%>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddContactDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AddContactDetails" Text="Add" ValidationGroup="GridSave" />
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                               </td>
                           </tr>
                              
                       </table> 

                        </div>
                        <div  class="form-group" style="padding-left:20px; overflow:auto;">

<thead><b>Add Branch Details:</b></thead><br /><br />
                         
                        <table border="1">
                          
                           <tr>
                               <td>
                                   <telerik:RadGrid ID="rgCorporateBranchDetails"  runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" 
AutoGenerateColumns="False" AllowCustomPaging="false" PageSize="15" ShowFooter="true" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn DataField="Branch" HeaderText="Branch Name" SortExpression="Branch">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Branch") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddBranchDetails" runat="server" Text="Manage Branch" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" PostBackUrl="~/Corporate/BranchManagement.aspx" />
                                                       <%--<telerik:RadTextBox ID="txtBranch" runat="server" TextMode="SingleLine" placeholder="Enter Branch Name" ValidationGroup="GridBranchSave">
                                                       </telerik:RadTextBox>
                                                   <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="txtBranch" ForeColor="Red" 
                                           ErrorMessage="Please Enter Branch" Enabled="true"  ValidationGroup="GridBranchSave" ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="PersonName" HeaderText="Person Name" SortExpression="PersonName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblrownumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"rownumber") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblBranchDetailsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BranchDetailsId") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblPersonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PersonName").ToString()%>'></asp:Label>
                                                      
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <%--<telerik:RadTextBox ID="txtPersonName" runat="server" class="form-control required" MaxLength="230" placeholder="Enter Contact Person Name" ValidationGroup="GridBranchSave">
                                                       </telerik:RadTextBox>
                                                       <asp:RequiredFieldValidator ID="rfvBPersonName" runat="server" ControlToValidate="txtPersonName" ForeColor="Red" 
                                           ErrorMessage="Please Enter Person Name" Enabled="true"  ValidationGroup="GridBranchSave" 
                                           ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="MobileNo" HeaderText="Mobile No." SortExpression="MobileNo">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MobileNo") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                      <%-- <telerik:RadTextBox ID="txtMobileNo" runat="server" MaxLength="10" placeholder="Enter Mobile No." ValidationGroup="GridBranchSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvBMobileNo" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" 
                                           ErrorMessage="Please Enter Mobile No" Enabled="true"  ValidationGroup="GridBranchSave" 
                                           ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revBMobNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txtMobileNo" ValidationGroup="GridBranchSave" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EmailId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                      <%-- <telerik:RadTextBox ID="txtEmailId" runat="server" MaxLength="500" placeholder="Enter the Email Id" ValidationGroup="GridBranchSave">
                                                       </telerik:RadTextBox><br />
                                                       <asp:RequiredFieldValidator ID="rfvBEmailId" runat="server" ControlToValidate="txtEmailid" ForeColor="Red" 
                                           ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="GridBranchSave" 
                                           ></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="revBEmail" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="GridBranchSave" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txtEmailid"></asp:RegularExpressionValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="State" HeaderText="State" SortExpression="State">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StateName") %>'></asp:Label>
                                                       <asp:Label ID="lblStateId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StateId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                      <%-- <telerik:RadComboBox ID="rcbState" AppendDataBoundItems="true" CausesValidation="false" AutoPostBack="true" RenderMode="Lightweight" DataTextField="StateName" DataValueField="StateId" OnSelectedIndexChanged="rcbState_SelectedIndexChanged" Filter="Contains" runat="server" CssClass="Combo2">
                                                           <Items>
                                                               <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                                           </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator id="rfvDepState" ControlToValidate="rcbState" 
                                                           runat="server" InitialValue="Select State" ForeColor="Red" ErrorMessage="Select State" ValidationGroup="GridBranchSave"></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="City" HeaderText="City" SortExpression="City">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DistrictName") %>'></asp:Label>
                                                       <asp:Label ID="lblCityId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"DistrictId") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <%--<telerik:RadComboBox ID="rcbCity"  runat="server" CssClass="Combo2" RenderMode="Lightweight" Filter="Contains" MaxLength="230" AppendDataBoundItems="true" >
                                                             <Items>
                                                                <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                                            </Items>
                                                       </telerik:RadComboBox>
                                                       <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="rcbCity" ForeColor="Red" 
                                           ErrorMessage="Please Select City" Enabled="true"  ValidationGroup="GridBranchSavee" InitialValue="Select City" ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="Address" HeaderText="Address" SortExpression="Address">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Address") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                      <%-- <telerik:RadTextBox ID="txtAddress" runat="server" TextMode="MultiLine" placeholder="Enter Address" ValidationGroup="GridBranchSave">
                                                       </telerik:RadTextBox>
                                                   <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ForeColor="Red" 
                                           ErrorMessage="Please Enter Address" Enabled="true"  ValidationGroup="GridBranchSave" ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                     <%--  <asp:RadioButtonList ID="rbdIsActive" runat="server" RepeatDirection="Horizontal" Visible="true">
                                                           <asp:ListItem Value="1">Yes</asp:ListItem>
                                                           <asp:ListItem Value="0">No</asp:ListItem>
                                                       </asp:RadioButtonList>--%>
                                                   <%--<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ForeColor="Red" 
                                           ErrorMessage="Please Enter Address" Enabled="true"  ValidationGroup="GridBranchSave" ></asp:RequiredFieldValidator>--%>
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>
                                               <%--<telerik:GridTemplateColumn HeaderText="Add/Delete">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="btnDeleteBranchDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="DeleteBranchDetails" OnClientClick="return deleletconfig();" Text="Delete">
                                                                        </asp:LinkButton>
                                                       <asp:RadioButtonList ID="rbdIsActive" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                           <asp:ListItem Value="1">Active</asp:ListItem>
                                                           <asp:ListItem Value="0">InActive</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                       <asp:Label ID="lblIsActive" runat="server" Visible="false"></asp:Label>
                                                   </ItemTemplate>
                                                   <FooterTemplate>
                                                       <asp:Button ID="btnAddBranchDetails" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="AddBranchDetails" Text="Add" ValidationGroup="GridBranchSave" />
                                                   </FooterTemplate>
                                               </telerik:GridTemplateColumn>--%>
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                             
                               </td>
                           </tr>
                              
                       </table> 
                                               
                        <div class="form-group" style="padding-left:5px; overflow:auto; margin-top:15px;">
                       <table>
                           <tr>
                               <th style="width:300px; padding-left:16px;">Corporate Partnership Status </th>
                               <th style="width:300px; padding-left:16px;">Upload Document</th>
                           </tr>
                           <tr>
                               <td>
                                   <div class="col-md-6">
                          <%--<label>Insurance Co-Partnership Status </label>--%>
                          <div class="selector">
                              <telerik:RadComboBox ID="cmbInsuranceStatus" CssClass="Combo" RenderMode="Lightweight" Filter="Contains" runat="server">
                                     <Items>
                                         <telerik:RadComboBoxItem Value="Permanent" Text="Permanent" />
                                         <telerik:RadComboBoxItem Value="Adhoc" Text="Adhoc" />
                                     </Items>
                                 </telerik:RadComboBox><br />
                          </div>
                      </div>
                               </td>
                               <td>
                                   <div class="col-md-6">
                          <%--<label>Upload Document </label>--%>
                          <div class="selector">
                              <telerik:RadAsyncUpload ID="RadUpldDocuments" CssClass="Combo" RenderMode="Lightweight" runat="server"></telerik:RadAsyncUpload>
                              </div>
                      </div>
                               </td>
                              
                           </tr>
                      
                      <tr>
                           <td>
                                   <div class="col-md-6">
                          <label>Agreement Date </label>
                          <div class="selector">
                              <telerik:RadDatePicker ID="dtpAgreementDate" runat="server" Culture="English (United States)"
                                                Width="100px" ReadOnly="true"  DateInput-DateFormat="dd/MM/yyyy"
                                                DateInput-EmptyMessage="DD/MM/YYYY" DateInput-MaxLength="10" TitleFormat="MMMM yyyy"
                                                >
                                            </telerik:RadDatePicker>
                              </div>
                      </div>
                               </td>
                               <td>
                                   <div class="col-md-6">
                          <label>Expiry Date </label>
                          <div class="selector">
                              <telerik:RadDatePicker ID="dtpExpiryDate" runat="server" Culture="English (United States)"
                                                Width="100px" ReadOnly="true"  DateInput-DateFormat="dd/MM/yyyy"
                                                DateInput-EmptyMessage="DD/MM/YYYY" DateInput-MaxLength="10" TitleFormat="MMMM yyyy"
                                                >
                                            </telerik:RadDatePicker>
                              </div>
                      </div>
                               </td>
                      </tr>
                      
                      
                 
                       </table>
                       </div>
                        <div class="form-group" style="padding-left:20px; overflow:auto; margin-top:10px;">
                       <table border="1">
                           <tr>
                               <td>
                                   <telerik:RadGrid ID="rgDocumentDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true" OnItemCommand="rgDocumentDetails_ItemCommand" OnNeedDataSource="rgDocumentDetails_NeedDataSource" OnPageIndexChanged="rgDocumentDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" >
                                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                                           <Columns>
                                               <telerik:GridTemplateColumn HeaderText="Document Name" SortExpression="CorporateName">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblDocumentName" runat="server" CausesValidation="false" Text='<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'></asp:Label>
                                                   </ItemTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn HeaderText="Download">
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="Download" Font-Underline="true" Text="Download">
                                                        
                                                    </asp:LinkButton>
                                                       <asp:Label ID="lblCorporateDocumentDetailsId" runat="server" CommandArgument="<%# (Container.ItemIndex).ToString() %>" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateDocumentDetailsId")%>' Visible="false"></asp:Label>
                                                   </ItemTemplate>
                                               </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn HeaderText="Delete">
                                                   <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="Delete" OnClientClick="javascript:if(!confirm('Are you sure want to delete the Document?')){return false;}" Text="Delete">
                                                    </asp:LinkButton>
                                                   </ItemTemplate>
                                               </telerik:GridTemplateColumn>
                                           </Columns>
                                       </MasterTableView>
                                   </telerik:RadGrid>
                               </td>
                           </tr>
                       </table>
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
                    </div>
               </asp:View>
           </asp:MultiView>
           <%--</span>--%>
            </div>
            

              <%--  </span>
          --%>  

    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="rgDocumentDetails" />
                <asp:PostBackTrigger ControlID="btnCorporate" />
                <asp:PostBackTrigger ControlID="rgvCorporateDetails" />
            </Triggers>
       </asp:UpdatePanel>
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

