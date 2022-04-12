<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddProductSubcategory.aspx.cs" Inherits="Welleazy.Master.AddProductSubcategory" %>

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
     <asp:UpdatePanel ID="upCorporate" runat="server">
            <ContentTemplate>

      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <h4>Master Product Sub Category
           <span style="float:right;">
           <asp:LinkButton ID="btnProductSubCategory" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnProductSubCategory_Click" ><i class="glyphicon glyphicon-plus"></i> Add Product Sub Category</asp:LinkButton></span>
         </h4>
           
           <div class="line"></div>       
          <asp:MultiView ID="ProductSubCategoryView" runat="server">
              <asp:View ID="View" runat="server">
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgvProductSubCategory" runat="server" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" 
                      BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" 
                      HeaderStyle-ForeColor="White" OnItemCommand="rgvProductSubCategory_ItemCommand" OnNeedDataSource="rgvProductSubCategory_NeedDataSource" OnPageIndexChanged="rgvProductSubCategory_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Sub Product Category" SortExpression="SubProductCategory">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkSubProductCategory" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" 
                                           CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "SubProductCategory")%>'></asp:LinkButton>
                                       <asp:Label ID="lblSubProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SubProductId")%>' Visible="false"></asp:Label>
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
                              <telerik:GridTemplateColumn HeaderText="Product Name" SortExpression="ProductName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName")%>'>
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
                  <div class="form-group" style="background:white;">
                         <div class="col-md-3">
                                   <label>
                                   Product Name
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="rcbProductName" RenderMode="Lightweight" runat="server" class="form-control required" Filter="Contains" AppendDataBoundItems="true">
                                           <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />
                                </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="rcbProductName" ForeColor="Red" ErrorMessage="Select Product" Enabled="true" InitialValue="Select Product" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   
                                       </div>
                         </div>
                         <div class="col-md-3">
                                   <label>
                                   Sub Product Category
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtProductSubCategory" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvProductSubCategory" runat="server" ControlToValidate="txtProductSubCategory" ForeColor="Red" ErrorMessage="Enter Product Sub Category" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                      <div class="col-md-3">
                                   <label> Normal Price </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtPSCNormalPrice" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvPSCNormalPrice" runat="server" ControlToValidate="txtPSCNormalPrice" ForeColor="Red" ErrorMessage="Enter Service Normal Price" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                      <div class="col-md-3">
                                   <label> HNI Price </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtPSCHNIPrice" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvPSCHNIPrice" runat="server" ControlToValidate="txtPSCHNIPrice" ForeColor="Red" ErrorMessage="Enter Service HNI Price" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                               <div class="col-md-3">
                                   <label> </label>
                                   <div class="selector">
                                       <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Save" />
                                       &nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                                   </div>
                               </div>
                           
                     
                  </div>
                  
                 
              </asp:View>
          </asp:MultiView>
       
            </div>
         
 </ContentTemplate>
            
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
