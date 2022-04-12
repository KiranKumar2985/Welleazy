<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="AddSubPermission.aspx.cs" Inherits="Welleazy.Master.AddSubPermission" %>


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
      <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
                     <h4>Master Add Sub Permission 
           <span style="float:right;">
           <asp:LinkButton ID="btnSubPermission" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSubPermission_Click" ><i class="glyphicon glyphicon-plus"></i> Add Sub Permission </asp:LinkButton></span>
          </h4>
           
           <div class="line"></div>          
          <asp:MultiView ID="SubPermissionView" runat="server">
              <asp:View ID="View" runat="server">
              
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgSubPermission" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" EnableTheming="true" OnItemCommand="rgSubPermission_ItemCommand" OnNeedDataSource="rgSubPermission_NeedDataSource" OnPageIndexChanged="rgSubPermission_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true" NoDetailRecordsText="No Records to Display">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Sub Permission" SortExpression="SubPermission">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSubPermission" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SubPermission")%>'
                                                        Font-Underline="true" CommandName="EditRow" CommandArgument='<%# (Container.ItemIndex).ToString() %>'
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:Label ID="lblSubPermissionId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SubPermissionId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Permission" SortExpression="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'>
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
                     
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Description
                                   </label>
                                   <div class="selector">
                                 <telerik:RadComboBox ID="cmbPermission" runat="server" AutoCompleteSeparator="true" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Save" AppendDataBoundItems="true">
                                     <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Description" />
                                </Items>
                                 </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="RequiredField_Permission" runat="server" ControlToValidate="cmbPermission" ForeColor="Red" ErrorMessage="Please Select Description" Enabled="true"  ValidationGroup="Save" InitialValue="Select Description"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Sub Permission
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtSubPermission" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredField_SubPermissione" runat="server" ControlToValidate="txtSubPermission" ForeColor="Red" ErrorMessage="Enter Sub Permission" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>Is Active </label>
                                   <div class="selector">
                                    <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                   </div>
                               </div>
                           
                            
                               <table>
                           <tr>
                               <td>
                                  
                                       <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Save" />
                                
                               </td>
                               <td style="width:20px;">
                               </td>
                               <td>
                                   <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                               </td>
                           </tr>
                           </table>
                       
                               
                         </div>
                     
                  </div>
             
              </asp:View>
          </asp:MultiView>
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
