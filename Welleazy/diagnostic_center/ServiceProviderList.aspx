<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="ServiceProviderList.aspx.cs" Inherits="Welleazy.diagnostic_center.ServiceProviderList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | Provider List </title>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
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

         <%--<div>
                        <asp:RadioButtonList ID="rbSearch" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Center Name" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Service Provider Type" Value="2" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>--%>
        <div class="form-group" style="padding-left:10px; padding-right:10px;">
           
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Centername" runat="server" placeholder="Center Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Centername_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_Servicecode" runat="server" placeholder="Service Provider Code" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Servicecode_TextChanged"></asp:TextBox>
                    </div>
            
            <div class="col-md-3">
                <telerik:RadComboBox ID="DDL_Status" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged">  
                    <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Status" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Active" Text="Active" />
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
           
        </div>
         
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:100px; background-color:white; text-align:center;">
           <hr /> <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go" CssClass="Login_btn btn" OnClick="btnGo_Click"/>
            
        </div> 
           
        <div class="form-group" style="padding:10px; ">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>
           
            <div style="overflow-x:auto; ">
                
                <asp:GridView ID="gvServiceProviderDetails" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="gvServiceProviderDetails_RowCommand" OnSorting="gvServiceProviderDetails_Sorting" OnRowDeleting="gvServiceProviderDetails_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="Action">
    <ItemTemplate>
        <asp:ImageButton ID="hyplnkEdit" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit" />
        <asp:ImageButton ID="hyplnkDelete" runat="server" ImageUrl="~/images/delete-icon.png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete" />
        <%--<asp:Button ID="hyplnkEdit" runat="server"
            Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit"></asp:Button>--%>
       <%-- <asp:Button ID="hyplnkDelete" runat="server"
            Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete"></asp:Button>--%>
        <asp:Label ID="lblDCId" runat="server" Visible="false"
            Text='<%# Bind("dc_id") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>

                        <asp:TemplateField HeaderText="Provider URL" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="btnURLLink" runat="server"
            Text="Send Link" CommandArgument="<%# Container.DataItemIndex %>" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" CommandName="SendLink"></asp:Button>
        
        <asp:Label ID="lblProviderURL" runat="server" Visible="false"
            Text='<%# Bind("provider_url") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                       
                        
                         <asp:BoundField DataField="center_status" HeaderText="Status" SortExpression="Status" ItemStyle-ForeColor="Red"></asp:BoundField>

                     <%--    <asp:BoundField DataField="sptoken_id" HeaderText="SP ID" SortExpression="sptoken_id"></asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Email Id" SortExpression="Action">
    <ItemTemplate>
               
        <asp:Label ID="lblsptoken_id" runat="server" Visible="true" Text='<%# Bind("sptoken_id") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>

                         <%--<asp:BoundField DataField="center_name" HeaderText="Name" SortExpression="center_name"></asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Email Id" SortExpression="Action">
    <ItemTemplate>
               
        <asp:Label ID="lblDcname" runat="server" Visible="true" Text='<%# Bind("center_name") %>'></asp:Label>

    </ItemTemplate>
       
</asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Id" SortExpression="Action">
    <ItemTemplate>
               
        <asp:Label ID="lblEmailId" runat="server" Visible="true"
            Text='<%# Bind("EmailId") %>'></asp:Label>

    </ItemTemplate>

       
</asp:TemplateField>
                         <asp:BoundField DataField="mobile_no" HeaderText="Contact Number" SortExpression="mobile_no"></asp:BoundField>

                         <asp:BoundField DataField="ProviderType" HeaderText="Service Provider Type" SortExpression="ProviderType"></asp:BoundField>

                         <asp:BoundField DataField="name_of_holder" HeaderText="Concerned Person Name" SortExpression="name_of_holder"></asp:BoundField>

                        <asp:BoundField DataField="created_on" HeaderText="Created Date" SortExpression="created_on"></asp:BoundField>
                        
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                </asp:GridView>

               
            </div>
            
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
             <asp:PostBackTrigger ControlID="DDL_Status"  />
             <asp:PostBackTrigger ControlID="txt_Centername" />
             <asp:PostBackTrigger ControlID="txt_Servicecode"  />
         </Triggers>
        </asp:UpdatePanel>
    
      </asp:Content>
