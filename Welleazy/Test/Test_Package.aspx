<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Test_Package.aspx.cs" Inherits="Welleazy.Test.Test_Package" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Test Management | Test Package List</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> Test Package List<span style="float:right; font-size:small;"><asp:LinkButton ID="Linkspl1" runat="server" OnClick="Linkspl1_Click" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Test Package</asp:LinkButton> | <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="~/Test/BulkPackageUpload.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Bulk Upload</asp:LinkButton></span></h5>
                                   <div class="line"></div>
          <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">
           
            <div class="col-md-2">
                        <asp:TextBox ID="txt_SKUCode" runat="server" placeholder="SKU Code" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_SKUCode_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_PackageName" runat="server" placeholder="Package Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_PackageName_TextChanged"></asp:TextBox>
                    </div>
              
               <div class="col-md-3">
                        <asp:TextBox ID="txt_ClientName" runat="server" placeholder="Corporate Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_ClientName_TextChanged"></asp:TextBox>
                    </div>
               <div class="col-md-2">
                   <telerik:RadComboBox ID="DDL_Status" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo2" AutoPostBack="true" AppendDataBoundItems="true" CausesValidation="false" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged">  
                    <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Active" Text="Active" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Disabled" Text="Disabled" />
                    </Items>
                </telerik:RadComboBox> 
                    </div>
              </div>
          <div class="form-group" style="padding:10px; padding-top:20px; margin-top:40px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none; overflow:auto;">
              <telerik:RadGrid ID="rgvTestPackageDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvTestPackageDetails_ItemCommand" OnPageIndexChanged="rgvTestPackageDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkPackageId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="16" Width="16" ToolTip="Edit Test" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" /><br />
                                       <asp:ImageButton ID="lnkPackageId1" runat="server" ImageUrl="~/images/remark_icon.png" Height="16" Width="16" ToolTip="Package Remarks" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRowRemark" /><br />
                                       <%--<asp:LinkButton ID="lnkTestId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "TestId")%>'></asp:LinkButton>--%>
                                       <asp:Label ID="lblPackageId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PackageId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Corporate Id" SortExpression="CorporateId" Visible="false">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Status" SortExpression="Status">
                                   <ItemTemplate>
                                       <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Product SKU" SortExpression="ProductSKU">
                                   <ItemTemplate>
                                       <asp:Label ID="lblProductSKU" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductSKU")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Package Name" SortExpression="PackageName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblPackageName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PackageName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Test Included" SortExpression="TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                              
                               <telerik:GridTemplateColumn HeaderText="Normal Package Price" SortExpression="NormalPackagePrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblNormalPackagePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NormalPackagePrice")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="HNI Package Price" SortExpression="HNIPackagePrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblHNIPackagePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HNIPackagePrice")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
          </div>
         </div>
         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rgvTestPackageDetails" />
        </Triggers>
        </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog" >
        <div class="modal-dialog" style="width:850px;">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h5 class="modal-title" style="background-color:#e1e1e1; padding:10px;">
                  <asp:Label ID="TextCorporateName" runat="server" >Test Package Remark</asp:Label> | 
                  Package Name (<asp:Label ID="TextPackageName" runat="server" ></asp:Label>)
              </h5>
            </div>
            <div class="modal-body">
                <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; ">
        
        <div style="padding:15px;">
            <span style="overflow:auto; width:100%;">
                <telerik:RadGrid ID="rgvTestPackageRemarkDetails" runat="server" CellPadding="4" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvTestPackageRemarkDetails_ItemCommand" OnNeedDataSource="rgvTestPackageRemarkDetails_NeedDataSource" OnPageIndexChanged="rgvTestPackageRemarkDetails_PageIndexChanged" Skin="Bootstrap">
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Sr. No."  >
                                   <ItemTemplate>
                                       <asp:Label ID="lblSNo" runat="server" Width="50" Text='<%# Container.DataSetIndex+1 %>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Test Remark" SortExpression="ActionPerformed">
                                       <ItemTemplate>
                                           <asp:Label ID="lblActionPerformed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActionPerformed")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="DisplayName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                                                
                                   </Columns> 
                       </MasterTableView>
                  </telerik:RadGrid>
            </span>
            
        </div>        
        
        </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>
</asp:Content>

