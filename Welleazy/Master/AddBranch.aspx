﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="Welleazy.Master.AddBranch" %>
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
            <h4>Master Branch List 
           <span style="float:right;">
           <asp:LinkButton ID="btnBranch" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnBranch_Click" ><i class="glyphicon glyphicon-plus"></i> Add Branch </asp:LinkButton></span>
           </h4>
           
           <div class="line"></div>       
          <asp:MultiView ID="BranchView" runat="server">
              <asp:View ID="View" runat="server">
                
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgBranch" runat="server" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" OnItemCommand="rgBranch_ItemCommand" OnNeedDataSource="rgBranch_NeedDataSource" OnPageIndexChanged="rgBranch_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="BranchName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBranchName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName")%>'
                                                        Font-Underline="true" CommandName="EditRow" CommandArgument='<%# (Container.ItemIndex).ToString() %>'
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:Label ID="lblBranchId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchId")%>'></asp:Label>
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
                                   Branch Name
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtBranchName" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="txtBranchName" ForeColor="Red" ErrorMessage="Enter Branch Name" Enabled="true"  ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                             <asp:Button ID="btnShowBulkUpload" Text="Bulk Branch Upload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnShowBulkUpload_Click" /> <--Click on for Bulk Upload
                           </div>
                  </div>
                  
                 
              </asp:View>
              <asp:View ID="BulkView" runat="server">
                  <h4>Bulk Branch Upload</h4> 
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
                         <label> Branch Details (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadBranchDocument" RenderMode="Lightweight" runat="server" MaxFileInputsCount="1" CssClass="Combo"></telerik:RadAsyncUpload>
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