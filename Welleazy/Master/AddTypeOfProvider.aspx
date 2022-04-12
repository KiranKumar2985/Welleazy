<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddTypeOfProvider.aspx.cs" Inherits="Welleazy.Master.AddTypeOfProvider" %>
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
      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
            <h4>Master Type Of Provider 
           <span style="float:right;">
           <asp:LinkButton ID="btnType" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnType_Click" ><i class="glyphicon glyphicon-plus"></i> Add Type Of Provider </asp:LinkButton></span>
          </h4>
           
           <div class="line"></div>       
          <asp:MultiView ID="StateView" runat="server">
              <asp:View ID="View" runat="server">
               
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgTypeofProvider" runat="server" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgTypeofProvider_ItemCommand" OnNeedDataSource="rgTypeofProvider_NeedDataSource" OnPageIndexChanged="rgTypeofProvider_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Proivder Type" SortExpression="ProviderType">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkProviderType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProviderType")%>'
                                                        Font-Underline="true" CommandName="EditRow" CommandArgument='<%# (Container.ItemIndex).ToString() %>'
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:Label ID="lblProviderTypeId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProviderTypeId")%>'></asp:Label>
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
                                   Provider Type
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtProviderType" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvProviderType" runat="server" ControlToValidate="txtProviderType" ForeColor="Red" ErrorMessage="Enter Provider Type" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
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

