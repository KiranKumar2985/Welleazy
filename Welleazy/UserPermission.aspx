<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="UserPermission.aspx.cs" Inherits="Welleazy.UserPermission" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" EnableSessionState="True" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Provider List | GoWel Next</title>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.2/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.2/css/bootstrap-select.min.css" />--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
    <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Serivce Provider Management >> Service Provider List<span style="float:right; font-size:small;"><asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/diagnostic_center/AddNewDc.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Service Provider</asp:LinkButton> | <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="~/diagnostic_center/sendDCRequest.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Send Request</asp:LinkButton> | <asp:LinkButton ID="Linkspl3" runat="server" ForeColor="#0033cc" > Export Client Attribute</asp:LinkButton> |<br /><asp:LinkButton ID="Linkspl4" runat="server" ForeColor="#0033cc"> Client Test Management Import</asp:LinkButton> | <asp:LinkButton ID="Linkspl5" runat="server" ForeColor="#0033cc">Export Client Test</asp:LinkButton></span></h5>
                                   <div class="line"></div>

         
        <div class="form-group" style="padding-left:10px; padding-right:10px; background-color:white;">
                     

             <div class="col-md-3">
                        <label>Profile Type</label>
                        <div class="selector">
                            <telerik:RadComboBox ID="ddlProfileType" runat="server" CssClass="Combo" RenderMode="Lightweight" Filter="Contains" AutoPostBack="true" AppendDataBoundItems="true"  OnSelectedIndexChanged="ddlProfileType_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="lblProfileTypeDisplay" runat="server"></asp:Label>
                         </div>
                    </div>

            <div class="col-md-3">
                        <label>User Roles</label>
                        <div class="selector">
                             <%--<asp:DropDownList ID="ddlUserRoles" runat="server" class="form-control required" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlUserRoles_SelectedIndexChanged">  
                                <asp:ListItem Value="0">Select</asp:ListItem>
                             </asp:DropDownList>--%>
                            <telerik:RadComboBox ID="ddlUserRoles" runat="server" CssClass="Combo" RenderMode="Lightweight" Filter="Contains" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlUserRoles_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="lblUserRolesDisplay" runat="server"></asp:Label>
                         </div>
                    </div>

            <div class="col-md-3">
                        <label>Select User</label>
                        <div class="selector">
                            <%-- <asp:DropDownList ID="ddlUser" runat="server" class="form-control required" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">  
                                <asp:ListItem Value="0">Select</asp:ListItem>
                             </asp:DropDownList>--%>
                            <telerik:RadComboBox ID="ddlUser" runat="server" CssClass="combo" RenderMode="Lightweight" Filter="Contains" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="lblUserDisplay" runat="server"></asp:Label>
                         </div>
                    </div>
 
          
            

         
            
           
        </div>
        <%--<div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:120px; background-color:white; text-align:center;">
            
            
        </div>--%> 
           
        <%--<div class="form-group" style="padding:10px; ">
            
                <asp:GridView ID="gvpermissionDetails" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Assign Permission For Roles">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAllTask" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="chkAllTask_CheckedChanged" />

                                <asp:Label ID="lblPermissionId" runat="server" Visible="false"  Text='<%# Bind("permissionId") %>' ></asp:Label>

                                <asp:GridView ID="rgvDefaultRoleTasksDepth" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CellSpacing="0" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                                                HeaderStyle-VerticalAlign="Middle"
                                                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                                                Skin="WebBlue">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblProcessHeader" ForeColor="White" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                                <asp:CheckBoxList ID="cbTasks" runat="server" RepeatDirection="Vertical" RepeatColumns="6">
                                                                </asp:CheckBoxList>
                                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>


                            </ItemTemplate>
                            
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>     




               
            </div>--%>
            
        </div>
    <div class="form-group"  style="position:relative; padding-left:10px; padding-right:10px; margin-top:120px; background-color:white;">
    <asp:CheckBox ID="chkAll_1" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_1_CheckedChanged" />
    <asp:Panel ID="Panel1" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_2" Checked="false" Text="Select All" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_2_CheckedChanged" />
    <asp:Panel ID="Panel2" GroupingText="Test" runat="server">
        
    </asp:Panel>

    
        <asp:CheckBox ID="chkAll_3" Checked="false" Text="Select All" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_3_CheckedChanged" />
    <asp:Panel ID="Panel3" GroupingText="Test" runat="server">
    </asp:Panel>

    
        <asp:CheckBox ID="chkAll_4" Checked="false" Text="Select All" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_4_CheckedChanged" />
    <asp:Panel ID="Panel4" GroupingText="Test" runat="server">
    </asp:Panel>

    
        <asp:CheckBox ID="chkAll_5" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_5_CheckedChanged"/>
    <asp:Panel ID="Panel5" GroupingText="Test" runat="server">
    </asp:Panel>

    <asp:CheckBox ID="chkAll_6" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_6_CheckedChanged"/>
    <asp:Panel ID="Panel6" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_7" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_7_CheckedChanged"/>
    <asp:Panel ID="Panel7" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_8" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_8_CheckedChanged"/>
    <asp:Panel ID="Panel8" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_9" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_9_CheckedChanged"/>
    <asp:Panel ID="Panel9" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_10" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_10_CheckedChanged"/>
    <asp:Panel ID="Panel10" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_11" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_11_CheckedChanged"/>
    <asp:Panel ID="Panel11" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_12" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_12_CheckedChanged"/>
    <asp:Panel ID="Panel12" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_13" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_13_CheckedChanged"/>
    <asp:Panel ID="Panel13" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_14" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_14_CheckedChanged"/>
    <asp:Panel ID="Panel14" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_15" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_15_CheckedChanged"/>
    <asp:Panel ID="Panel15" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_16" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_16_CheckedChanged"/>
    <asp:Panel ID="Panel16" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_17" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_17_CheckedChanged" />
    <asp:Panel ID="Panel17" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_18" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_18_CheckedChanged" />
    <asp:Panel ID="Panel18" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_19" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_19_CheckedChanged"/>
    <asp:Panel ID="Panel19" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_20" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_20_CheckedChanged"/>
    <asp:Panel ID="Panel20" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_21" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_21_CheckedChanged" />
    <asp:Panel ID="Panel21" GroupingText="Test" runat="server">
        
    </asp:Panel>

    <asp:CheckBox ID="chkAll_22" Checked="false" Text="Select All" AutoPostBack="true" runat="server" OnCheckedChanged="chkAll_22_CheckedChanged" />
    <asp:Panel ID="Panel22" GroupingText="Test" runat="server">
        
    </asp:Panel>
    </div>
    <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:120px; background-color:white; text-align:center;">
            <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go" CssClass="Login_btn btn" OnClick="btnGo_Click"/>
            
        </div>
    
  
     </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="ddlProfileType"  />
             <asp:PostBackTrigger ControlID="ddlUserRoles" />
             <asp:PostBackTrigger ControlID="ddlUser"  />
             <asp:PostBackTrigger ControlID="btnGo" />
         </Triggers>
        </asp:UpdatePanel>
      </asp:Content>
