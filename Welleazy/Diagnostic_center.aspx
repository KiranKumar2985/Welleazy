<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Diagnostic_center.aspx.cs" Inherits="Welleazy.Diagnostic_center" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | DC List</title>
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
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
   
                  <ContentTemplate>--%>
    <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Serivce Provider Management >> Service Provider List
            <span style="float:right; font-size:small;">
                <asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/diagnostic_center/AddNewDc.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Service Provider</asp:LinkButton> | 
                <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="~/diagnostic_center/sendDCRequest.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Send Request</asp:LinkButton> | 
                <asp:LinkButton ID="Linkspl3" runat="server" ForeColor="#0033cc" > Export Client Attribute</asp:LinkButton> |<br />
                <asp:LinkButton ID="Linkspl4" runat="server" ForeColor="#0033cc"> Client Test Management Import</asp:LinkButton> | 
                <asp:LinkButton ID="Linkspl5" runat="server" ForeColor="#0033cc">Export Client Test</asp:LinkButton> | 
                <asp:LinkButton ID="Linkspl6" runat="server" OnClick="Linkspl6_Click" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-earphone"></i></b> Network Manager Contact Details </asp:LinkButton> 
                </span>

        </h5>
                                   <div class="line"></div>
        <div class="form-group" style="padding-left:10px; padding-right:10px;">
          
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Centername" runat="server" placeholder="Center Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Centername_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Servicecode" runat="server" placeholder="Service Provider Code" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Area" runat="server" placeholder="Area" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Area_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                          
                 <telerik:RadComboBox ID="DDL_Client" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true">  
                    <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Client" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Test Insurance Company1" Text="Test Insurance Company1" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Test Insurance Company2" Text="Test Insurance Company2" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Awaiting Test Insurance Company3" Text="Test Insurance Company3" />
                    </Items>
                    
                </telerik:RadComboBox>
                <br />
                   
            </div>

            <div class="col-md-3">
                        <asp:TextBox ID="txt_City" runat="server" placeholder="City" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_City_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_State" runat="server" placeholder="State" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_State_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                 <telerik:RadComboBox ID="DDL_Status" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged">  
                    <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Status" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Approved" Text="Approved" />
                    </Items>
                     <Items>
                            <telerik:RadComboBoxItem Value="Approval Pending" Text="Approval Pending" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Blacklisted" Text="Blacklisted" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Awaiting Confirmation" Text="Awaiting Confirmation" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Non Empanel" Text="Non Empanel" />
                    </Items>
                </telerik:RadComboBox>          
                    </div>
            <div class="col-md-3">
                            
            <telerik:RadComboBox ID="DDL_LNDwithclient" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true">  
                    <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Listed & De-Listed with Clients" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Listed" Text="Listed" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="De-Listed" Text="De-Listed" />
                    </Items>
                   
                </telerik:RadComboBox>
                    </div>   
        </div>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:120px; background-color:white; text-align:center;">
            <hr /><asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go" type="submit" value="Go" CssClass="Login_btn btn" OnClick="btnGo_Click"/>
            
        </div>
           
        <div class="form-group" style="padding:10px; overflow:auto;margin-right:20px; ">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>

                <asp:GridView ID="gvDCDetails" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" CellPadding="4" AllowCustomPaging="true"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="gvDCDetails_RowCommand" OnSorting="gvDCDetails_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="UserName">
    <ItemTemplate>
        <asp:ImageButton ID="hyplnkUserName" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="UserName" />
       <%-- <asp:LinkButton ID="hyplnkUserName" runat="server"
            Text='<%# Bind("dc_id") %>' CommandArgument="<%# Container.DataItemIndex %>" CommandName="UserName">
                        
        </asp:LinkButton>--%>
        <asp:Label ID="lblDCId" runat="server" Visible="false"
            Text='<%# Bind("dc_id") %>'></asp:Label>
    </ItemTemplate>
        
                            
    
</asp:TemplateField>
                        <asp:ImageField DataImageUrlField="imagename"  HeaderText="Images" AlternateText="DC Image" >
<ControlStyle Height="100px" Width="150px"></ControlStyle>
                    </asp:ImageField>
                        <asp:TemplateField HeaderText="DC Status" SortExpression="Status">
    <ItemTemplate>
        <asp:Button ID="btnURLLink" runat="server"
            Text='<%# Bind("center_status") %>' CommandArgument="<%# Container.DataItemIndex %>" CssClass="Login_btn btn" ForeColor="Red" CommandName="ApprovalProcess" data-toggle="modal"></asp:Button>
        
        

    </ItemTemplate>

       
</asp:TemplateField>
                        <%--<asp:BoundField DataField="center_status" HeaderText="Status" SortExpression="center_status" ItemStyle-ForeColor="Red"></asp:BoundField>--%>
                        <asp:BoundField DataField="deactivation_reason" HeaderText="Deactivation Reason" SortExpression="deactivation_reason"></asp:BoundField>
                        <asp:BoundField DataField="deactivation_date" HeaderText="Deactivation Date" SortExpression="deactivation_date"></asp:BoundField>

                        <asp:BoundField DataField="sptoken_id" HeaderText="SP ID" SortExpression="sptoken_id"></asp:BoundField>
                        <asp:BoundField DataField="center_name" HeaderText="Name" SortExpression="center_name"></asp:BoundField>
                        <asp:BoundField DataField="ProviderType" HeaderText="Type" SortExpression="ProviderType"></asp:BoundField>
                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address"></asp:BoundField>
                        <asp:BoundField DataField="DistrictName" HeaderText="City" SortExpression="DistrictName"></asp:BoundField>
                        <asp:BoundField DataField="StateName" HeaderText="State" SortExpression="StateName"></asp:BoundField>
                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area"></asp:BoundField>
                        <asp:BoundField DataField="emailid" HeaderText="Email Id" SortExpression="emailid"></asp:BoundField>
                        <asp:BoundField DataField="landline_no" HeaderText="Landline No" SortExpression="landline_no"></asp:BoundField>
                        <asp:BoundField DataField="name_of_holder" HeaderText="Concerned Person Name" SortExpression="name_of_holder"></asp:BoundField>
                        <asp:BoundField DataField="center_categorization" HeaderText="Categorization" SortExpression="center_categorization"></asp:BoundField>
                        <asp:BoundField DataField="center_grading" HeaderText="Grad" SortExpression="center_grading"></asp:BoundField>                   
                        <asp:BoundField DataField="center_prioritization" HeaderText="Priority" SortExpression="center_prioritization"></asp:BoundField> 
                        <asp:TemplateField HeaderText="TAT" SortExpression="">
                        <ItemTemplate>
                                <asp:Label ID="lbl" runat="server" Text="NA"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="total_call" HeaderText="Total Appointment" SortExpression="total_call"></asp:BoundField> 
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                </asp:GridView>
        
        </div>
        </div>
    <div class="modal fade" id="myModal" role="dialog" >
        <div class="modal-dialog" style="width:600px;" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <div class="modal-header">
                                     
                <button type="button" class="close" data-dismiss="modal">&times;</button>
           <h4 class="modal-title">Network Manager Contact Details</h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <p><i class="glyphicon glyphicon-envelope"></i>  hello@welleazy.com</p><br />
                    <p><i class="glyphicon glyphicon-earphone"></i>  +91-88840 00687</p>
           
                    </div>
            </div>
            <div class="modal-footer">
              <%--<button type="button" class="btn btn-default" style="background-color:#113d7a; color:white; border-style:none;" data-dismiss="modal" >Close</button>--%>
            </div>
          </div>
      
        </div>
      </div>
        </div>
      <div class="modal fade" id="myModal1" role="dialog" >
        <div class="modal-dialog" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <table>
                        <tr>
                            <td class="table_space"><b>Service Provider Id</b></td>
                            <td class="table_space">
                                <asp:Label ID="TextSPID" runat="server" ></asp:Label>
                                <asp:Label ID="TextDCID" runat="server" Visible="false" ></asp:Label>
                            </td>
                            <td class="table_space"><b>Service Provider Type</b></td>
                            <td class="table_space">
                                <asp:Label ID="TextSPType" runat="server" ></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="table_space"><b>Service Provider Name</b></td>
                            <td class="table_space" colspan="3">
                                <asp:Label ID="TextSPName" runat="server" ></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="table_space"><b>Mobile Number</b></td>
                            <td class="table_space">
                                <asp:Label ID="TextMobileNo" runat="server" ></asp:Label>
                            </td>
                            <td class="table_space">Email</td>
                            <td class="table_space">
                                <asp:Label ID="TextEmail" runat="server" ></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="table_space"><b>Status</b> <span class="mandatory">*</span></td>
                            <td class="table_space" colspan="3">
                                <telerik:RadComboBox ID="rcbServiceProviderStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="Select Status" Text="Select Status" />
                                         <telerik:RadComboBoxItem Value="Approved" Text="Approved" />
                                         <telerik:RadComboBoxItem Value="Approval Pending" Text="Approval Pending" />
                                    </Items>
                                </telerik:RadComboBox>
                                <%--<asp:DropDownList ID="rcbProviderStatus" runat="server" CssClass="form-group required" AppendDataBoundItems="true">
                                    <asp:ListItem Value="Select Status" Text="Select Status">Select Status</asp:ListItem>
                                    <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                    <asp:ListItem Value="Approval Pending" Text="Approval Pending"></asp:ListItem>
                                </asp:DropDownList>--%>
                              </td>
                           
                        </tr>
                                    <tr>
                                        <td class="table_space" colspan="4" runat="server" align="center">
                                    <asp:Button ID="btnSave" Text="Approve" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None"  OnClick="btnSave_Click" /><br />
                                            <asp:Label ID="lblStatusText" runat="server" ForeColor="Green" ></asp:Label>
                                </td>
                                    </tr>
                                </table>
                           
                    </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>
                      
       <%--                                     </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="DDL_Status"  />
             <asp:PostBackTrigger ControlID="txt_Centername" />
             <asp:PostBackTrigger ControlID="txt_Servicecode"  />
             <asp:PostBackTrigger ControlID="txt_Area" />
             <asp:PostBackTrigger ControlID="txt_City"  />
             <asp:PostBackTrigger ControlID="txt_State" />
         </Triggers>
        </asp:UpdatePanel>--%>

      </asp:Content>
