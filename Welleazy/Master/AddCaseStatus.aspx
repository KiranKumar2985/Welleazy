<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCaseStatus.aspx.cs" Inherits="Welleazy.Master.AddCaseStatus" %>
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
      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <h4>Master Case Status 
           <span style="float:right;">
           <asp:LinkButton ID="btnCaseStatus" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCaseStatus_Click" ><i class="glyphicon glyphicon-plus"></i> Add Case Status </asp:LinkButton></span>
           </h4>
           
           <div class="line"></div>       
          <asp:MultiView ID="CaseStatusView" runat="server">
              <asp:View ID="View" runat="server">
                
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgCaseStatus" runat="server" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgCaseStatus_ItemCommand" OnNeedDataSource="rgCaseStatus_NeedDataSource" OnPageIndexChanged="rgCaseStatus_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Case Status Name" SortExpression="CaseStatusName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkCaseStatusName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatusName")%>'
                                                        Font-Underline="true" CommandName="EditRow" CommandArgument='<%# (Container.ItemIndex).ToString() %>'
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:Label ID="lblStatusId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Case For" SortExpression="CaseFor">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCaseFor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseFor")%>'>
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
                               <div class="col-md-8">
                                   <label>
                                   Case Status Name
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtCaseStatusName" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvCaseStatus" runat="server" ControlToValidate="txtCaseStatusName" ForeColor="Red" ErrorMessage="Enter Case Status Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-4">
                                   <label>
                                   Case For (PhysicalMedical- 1, Tele-Video- 2 and Interpretation- 3)
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtCaseFor" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="txtCaseFor" ForeColor="Red" ErrorMessage="Enter Case For" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                           <div class="form-group" style="margin-top:70px; padding-left:16px;">
                             <asp:Button ID="btnShowBulkUpload" Text="Bulk Case Status Upload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnShowBulkUpload_Click" /> <--Click on for Bulk Upload
                           </div>
                  </div>
                  
                 
              </asp:View>
              <asp:View ID="BulkView" runat="server">
                  <h4>Bulk Case Status Upload</h4> 
                  <asp:Button ID="btnExport" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Case Status Format" OnClick="btnExport_Click" runat="server" /><br />
                  <div class="form-group" style="margin-top:20px;">

                      <label class="mandatory" style="font-size:small;">
                          Note:<br />
                          » Please do not change or delete Excel Sheet format.<br />
                          » All Excel Sheet fields are mandatory.

                      </label><br />
                 
                  </div>
                  <div class="form-group" style="margin-top:20px;">
                     
                     <div class="col-md-4">
                         <label> Case Status Details (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadCaseStatusDocument" RenderMode="Lightweight" runat="server" Height="17px" Width="210px" Skin="WebBlue" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                             </div>
                     </div>
                     <div class="col-md-4">
                         <label> </label>
                         <div class="selector">
                         <asp:button ID="btnUpload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Upload" OnClick="btnUpload_Click"></asp:button>
                             </div>
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

