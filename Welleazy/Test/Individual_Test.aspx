<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Individual_Test.aspx.cs" Inherits="Welleazy.Test.Individual_Test" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Test Management | Individual Test</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> Individual Test List<span style="float:right; font-size:small;"><asp:LinkButton ID="Linkspl1" runat="server" OnClick="Linkspl1_Click" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Test</asp:LinkButton> | <asp:LinkButton ID="Linkspl2" runat="server" PostBackUrl="~/Test/BulkTestUpload.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Bulk Upload</asp:LinkButton></span></h5>
                                   <div class="line"></div>
          <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">
           
            <div class="col-md-2">
                        <asp:TextBox ID="txt_SKUCode" runat="server" placeholder="SKU Code" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_SKUCode_TextChanged"></asp:TextBox>
                    </div>
            <div class="col-md-3">
                        <asp:TextBox ID="txt_TestName" runat="server" placeholder="Test Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_TestName_TextChanged"></asp:TextBox>
                    </div>
               <div class="col-md-2">
                        <asp:TextBox ID="txt_TestCode" runat="server" placeholder="Test Code" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_TestCode_TextChanged"></asp:TextBox>
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
              <telerik:RadGrid ID="rgTestDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgTestDetails_ItemCommand" OnPageIndexChanged="rgTestDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkTestId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="16" Width="16" ToolTip="Edit Test" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" /><br />
                                       <asp:ImageButton ID="lnkTestId1" runat="server" ImageUrl="~/images/remark_icon.png" Height="16" Width="16" ToolTip="Test Remarks" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRowRemark" /><br />
                                       <%--<asp:LinkButton ID="lnkTestId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "TestId")%>'></asp:LinkButton>--%>
                                       <asp:Label ID="lblTestId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestId")%>' Visible="false"></asp:Label>
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
                               <telerik:GridTemplateColumn HeaderText="Test Type" SortExpression="TestType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Visit Type" SortExpression="VisitType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVisitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VisitType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="SKU Code" SortExpression="SKUCode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblSKUCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SKUCode")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Test Name" SortExpression="TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Test Code" SortExpression="TestCode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestCode")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Normal Price" SortExpression="NormalPrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblNormalPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NormalPrice")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="HNI Price" SortExpression="HNIPrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblHNIPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HNIPrice")%>'>
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
            <asp:PostBackTrigger ControlID="rgTestDetails" />
        </Triggers>
        </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog" >
        <div class="modal-dialog" style="width:850px;">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h5 class="modal-title" style="background-color:#e1e1e1; padding:10px;">
                  <asp:Label ID="TextCorporateName" runat="server" >Individual Test Remark</asp:Label> | 
                  Test Name (<asp:Label ID="TextTestName" runat="server" ></asp:Label>)
              </h5>
            </div>
            <div class="modal-body">
                <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; ">
        
        <div style="padding:15px;">
            <span style="overflow:auto; width:100%;">
                <telerik:RadGrid ID="rgvTestRemarkDetails" runat="server" CellPadding="4" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgvTestRemarkDetails_ItemCommand" OnNeedDataSource="rgvTestRemarkDetails_NeedDataSource" OnPageIndexChanged="rgvTestRemarkDetails_PageIndexChanged" Skin="Bootstrap">
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
