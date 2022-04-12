<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductServicesMapping.aspx.cs" Inherits="Welleazy.Admin.ProductServicesMapping" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>GoWelnext | Assign Product Services</title>
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
     <asp:UpdatePanel ID="upCorporate" runat="server">
            <ContentTemplate>

      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <h4>Assign Product Services
             <span style="float:right;">
           <asp:LinkButton ID="btnProductServices" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnProductServices_Click" Visible="true" ><i class="glyphicon glyphicon-plus"></i> Assigned Product Services</asp:LinkButton></span>
         </h4>            
           
           
           <div class="line"></div>   
                    <div class="form-group">
               <asp:MultiView ID="LoginCreationView" runat="server">
               
               <asp:View ID="Save" runat="server">
                        
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Login Type <span class="mandatory">*</span></label>
                                   
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbLoginType" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains" OnSelectedIndexChanged="cmbLoginType_SelectedIndexChanged" ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvLoginType" runat="server" ControlToValidate="cmbLoginType" ForeColor="Red" ErrorMessage="Please Select Login Type" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               
                               <div class="col-md-3">
                                   <label>
                                   Corporate Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" Filter="Contains" ValidationGroup="Case">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select Corporate" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Branch Id <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmdBranchId" RenderMode="Lightweight" runat="server" AppendDataBoundItems="true" Filter="Contains">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       
                                       <br /><br />
                                   </div>
                               </div>
                                <div class="col-md-3">
                        <label>Product Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AllowCustomText="true" AppendDataBoundItems="true" Filter="Contains" CheckBoxes="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="rcbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
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
                                       </asp:RadioButtonList><br />
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadDateTimePicker ID="rdtCreatedOn" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" Visible="false">
                                
                            </telerik:RadDateTimePicker>
                                       <asp:TextBox ID="txt_CreatedBy" runat="server" class="form-control required" TextMode="SingleLine" Visible="false"></asp:TextBox>
                                   </div>
                               </div>
                             </div>
                                                   
                           <div class="form-group" style="overflow:auto; width:100%; padding:10px;">
                               
                                           <telerik:RadGrid ID="rgProductServices" runat="server"
                            AutoGenerateColumns="False" Visible="true" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                            HeaderStyle-VerticalAlign="Middle"
                            ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                            OnItemDataBound="rgProductServices_ItemDataBound" CellPadding="4" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                            <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true" >
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Assign Product Services" SortExpression="">
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
                           <div class="form-group">
                               <table style="padding:10px; margin-left:10px;">
                           <tr>
                               <td>
                                   <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Save" ValidationGroup="Save" />
                               </td>
                               <td style="width:10px;">

                               </td>
                               <td>
                                   <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                               </td>
                           </tr>
                       </table>
                           </div>                            
                           
  
               </asp:View>
                   <asp:View ID="View" runat="server">
                            
                        <div class="form-group" style="padding:10px; overflow:auto;">
              <telerik:RadGrid ID="rgAssignedDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgAssignedDetails_ItemCommand" OnPageIndexChanged="rgAssignedDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True"
                    SaveScrollPosition="True" />
            </ClientSettings>
                  <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="TestId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkProductAssignedId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <asp:Label ID="lblProductAssignedId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductAssignedId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Login Type" SortExpression="LoginType" >
                                   <ItemTemplate>
                                       <asp:Label ID="lblLoginType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LoginType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch Id" SortExpression="Branch">
                                   <ItemTemplate>
                                       <asp:Label ID="lblBranchId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Branch")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Product Id" SortExpression="ProductId">
                                   <ItemTemplate>
                                       <asp:Button ID="btnURLLink" runat="server" Text="View Product" CssClass="btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="ViewProduct" CausesValidation="false" data-toggle="modal"></asp:Button>
                                       
                                       <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId")%>' Visible="false">
                                                    </asp:Label>
                                       <asp:Label ID="lblProductAssignedIdP" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProductAssignedId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="SubProduct Id" SortExpression="SubProductId">
                                   <ItemTemplate>
                                       <asp:Button ID="btnURLLink1" runat="server" Text="View Services" CssClass="btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="ViewServices" CausesValidation="false" data-toggle="modal"></asp:Button>
                                       
                                       <asp:Label ID="lblSubProductId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "SubProductId")%>'>
                                                    </asp:Label>
                                         <asp:Label ID="lblProductAssignedIdSP" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProductAssignedId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Is Active" SortExpression="IsActive">
                                   <ItemTemplate>
                                       <asp:Label ID="IsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                        
                             
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
                 </div>
                       <div class="form-group">
                           <div class="col-md-3">
                 
                  <telerik:RadComboBox ID="rcbProductList" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />
                                </Items>
                            </telerik:RadComboBox>
                                <telerik:RadComboBox ID="rcbProductServicesList" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Services" />
                                </Items>
                            </telerik:RadComboBox>
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
                </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="rgAssignedDetails" />
              <asp:PostBackTrigger ControlID="btnProductServices" />
              <asp:PostBackTrigger ControlID="btnSave" />
              <asp:PostBackTrigger ControlID="btnCancel" />

        </Triggers>
         </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Product List</h4>
        </div>
        <div class="modal-body">
           <asp:Label ID="lblproductlist" runat="server" ></asp:Label>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    <div class="modal fade" id="myModal1" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Product Services List</h4>
        </div>
        <div class="modal-body">
           <asp:Label ID="lblproductServiceslist" runat="server" ></asp:Label>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    </asp:Content>