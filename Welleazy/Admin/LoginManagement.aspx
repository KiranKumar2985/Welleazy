<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginManagement.aspx.cs" Inherits="Welleazy.Admin.LoginManagement" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin | Login Management</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager> 
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>
      <div class="form-group" style="background: white; padding: 3px; margin-top: -20px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
            <h4>Login Management<span style="float:right;">
            <asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;" CausesValidation="false"/>

                                </span></h4>
           
          <div class="line"></div>
           <div class="form-group" style="border:3px solid #0869b1; border-top:none; border-left:none; border-right:none; padding:10px; margin-top:-25px; margin-bottom:-15px;">
          
               <telerik:RadComboBox ID="DetailsType" runat="server" RenderMode="Lightweight" CssClass="Combo" Filter="Contains" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DetailsType_SelectedIndexChanged">
                   <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Details Type" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Employee Details" Text="Employee Details" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Customer Details" Text="Customer Details" />
                    </Items>
                   
               </telerik:RadComboBox>
               <asp:RequiredFieldValidator ID="RequiredField_DetailsType" runat="server" ControlToValidate="DetailsType" ForeColor="Red" ErrorMessage="Please Select Details Type" Enabled="true" ValidationGroup="Details" InitialValue="Details Type"></asp:RequiredFieldValidator>
    
               </div>

          <div class="form-group" style="padding:10px; margin-top:50px;">
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Name" runat="server" placeholder="Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Name_TextChanged" ValidationGroup="Details"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Email" runat="server" placeholder="Email" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Email_TextChanged" ValidationGroup="Details"></asp:TextBox>
                    </div>
              <div class="col-md-2">
                        <asp:TextBox ID="txt_Mobile" runat="server" placeholder="Mobile" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Mobile_TextChanged" ValidationGroup="Details"></asp:TextBox>
                    </div>
              <div class="col-md-2">
                  <telerik:RadComboBox ID="DDL_Status" RenderMode="Lightweight" Filter="Contains" CssClass="Combo2" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged" ValidationGroup="Details">
                      <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="1" Text="Active" />
                    </Items>
                      <Items>
                            <telerik:RadComboBoxItem Value="2" Text="InActive" />
                    </Items>
                  </telerik:RadComboBox>
                     
                    </div>
            <div class="col-md-2">
                <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go to Search" CssClass="Login_btn btn" OnClick="btnGo_Click" ValidationGroup="Details"/>
                </div>
          
        </div>
              
        <div class="form-group" style="padding:20px; margin-top:30px;">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>
         
            <div style="overflow-x:auto; ">
          <div class="form-group" runat="server" id="EmployeeDetails" visible="false">
              <asp:GridView ID="gvEmployeeDetails" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="gvEmployeeDetails_RowCommand" OnSorting="gvEmployeeDetails_Sorting" OnRowDeleting="gvEmployeeDetails_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="Action">
    <ItemTemplate>
        <asp:ImageButton ID="hyplnkEdit" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit" />
        <asp:ImageButton ID="hyplnkDelete" runat="server" ImageUrl="~/images/delete-icon.png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete" />
        <%--<asp:Button ID="hyplnkEdit" runat="server"
            Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit"></asp:Button>
        <asp:Button ID="hyplnkDelete" runat="server"
            Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete"></asp:Button>--%>
        <asp:Label ID="lblEmpId" runat="server" Visible="false"
            Text='<%# Bind("EmployeeRefId") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>

                        <asp:TemplateField HeaderText="Activation URL" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="btnURLLink" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None"
            Text="Send Link" CommandArgument="<%# Container.DataItemIndex %>" CommandName="SendLink"></asp:Button>
        
        <asp:Label ID="lblActivationURL" runat="server" Visible="false"
            Text='<%# Bind("AccountActivationURL") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                       
                        
                     <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" SortExpression="EmployeeId" ItemStyle-ForeColor="Red"></asp:BoundField>

                         <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName"></asp:BoundField>

                        <asp:TemplateField HeaderText="Email Id" SortExpression="Action">
    <ItemTemplate>
               
        <asp:Label ID="lblEmailId" runat="server" Visible="true"
            Text='<%# Bind("Emailid") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                         <asp:BoundField DataField="MobileNo" HeaderText="Mobile Number" SortExpression="MobileNo"></asp:BoundField>

                         <asp:BoundField DataField="CorporateName" HeaderText="Corporate Name" SortExpression="CorporateName"></asp:BoundField>

                         <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                         
                        <asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="CreatedOn"></asp:BoundField>

                         <asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="CreatedBy"></asp:BoundField>
                         
                         <asp:BoundField DataField="ModifiedOn" HeaderText="Modified On" SortExpression="ModifiedOn" Visible="false"></asp:BoundField>
                         
                         <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="ModifiedBy" Visible="false"></asp:BoundField>
                         
                         <asp:BoundField DataField="LastActiveDate" HeaderText="Last Active Date" SortExpression="LastActiveDate"></asp:BoundField>

                         <asp:BoundField DataField="LastInactiveDate" HeaderText="Last Inactive Date" SortExpression="LastInactiveDate"></asp:BoundField>

                         <asp:BoundField DataField="IsActive" HeaderText="Is Active" SortExpression="IsActive"></asp:BoundField>
                    

                         </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                </asp:GridView>
          </div>
          <div class="form-group" runat="server" id="CustomerDetails" visible="false">
              <asp:GridView ID="gvCustomerDetails" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="gvCustomerDetails_RowCommand" OnSorting="gvCustomerDetails_Sorting" OnRowDeleting="gvCustomerDetails_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="hyplnkEdit" runat="server"
            Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit"></asp:Button>
        <asp:Button ID="hyplnkDelete" runat="server"
            Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete"></asp:Button>
        <asp:Label ID="lblEmpId" runat="server" Visible="false"
            Text='<%# Bind("CustomerRefId") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>

                        <asp:TemplateField HeaderText="Activation URL" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="btnURLLink" runat="server"
            Text="Send Link" CommandArgument="<%# Container.DataItemIndex %>" CommandName="SendLink"></asp:Button>
        
        <asp:Label ID="lblActivationURL" runat="server" Visible="false"
            Text='<%# Bind("AccountActivationURL") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                       
                        
                         <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="CustomerId" ItemStyle-ForeColor="Red"></asp:BoundField>

                         <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName"></asp:BoundField>

                        <asp:TemplateField HeaderText="Email Id" SortExpression="Action">
    <ItemTemplate>
               
        <asp:Label ID="lblEmailId" runat="server" Visible="true"
            Text='<%# Bind("Emailid") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                         <asp:BoundField DataField="MobileNo" HeaderText="Mobile Number" SortExpression="MobileNo"></asp:BoundField>

                         <asp:BoundField DataField="OTP" HeaderText="OTP" SortExpression="OTP"></asp:BoundField>

                         <asp:BoundField DataField="IsActive" HeaderText="Is Active" SortExpression="IsActive"></asp:BoundField>
                    
                         </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                </asp:GridView>
          </div>
                

               
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
          </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="txt_Mobile"  />
             <asp:PostBackTrigger ControlID="txt_Name" />
             <asp:PostBackTrigger ControlID="txt_Email"  />
         </Triggers>
        </asp:UpdatePanel>
    </asp:Content>