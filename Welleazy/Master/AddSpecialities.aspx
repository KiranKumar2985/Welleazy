<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="AddSpecialities.aspx.cs" Inherits="Welleazy.Master.AddSpecialities" %>

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
           <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">    
            <h4>Specialities List 
           <span style="float:right;">
           <asp:LinkButton ID="btnAddSpecialities" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnAddSpecialities_Click" ><i class="glyphicon glyphicon-plus"></i> Add Specialities </asp:LinkButton></span>
          </h4>
           <div class="line"></div>
           <asp:MultiView ID="SpecialitiesView" runat="server">
               <asp:View ID="View" runat="server">
                   <div class="form-group" style="padding:10px; overflow:auto;">
          
      
                   <telerik:RadGrid ID="rgvSpecialities" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" EnableTheming="true" OnItemCommand="rgvSpecialities_ItemCommand" OnNeedDataSource="rgvSpecialities_NeedDataSource" OnPageIndexChanged="rgvSpecialities_PageIndexChanged" >
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Specality Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDescription" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" 
                                           CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:LinkButton>
                                       <asp:Label ID="lblSpecialityId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialityId")%>' Visible="false"></asp:Label>
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
                   <div class="form-group">
                    
                          
                           <div class="form-group" style="">
                               <div class="col-md-3">
                                   <asp:Label Id="lblDescription" runat="server" Text="Description"></asp:Label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtDescription" runat="server" class="form-control required" TextMode="SingleLine" ValidationGroup="Save"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredField_Description" runat="server" ControlToValidate="txtDescription" ForeColor="Red" ErrorMessage="Enter Description" Enabled="true" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               
                               <div class="col-md-3">
                                   <asp:Label ID="lblIsActive" runat="server" Text="Is Active"></asp:Label>
                                   <div class="selector">
                                       <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                       </asp:RadioButtonList>
                                       <br />
                                   </div>
                               </div>
                              <div class="form-group">
                                  <table>
                           <tr>
                               <td>
                                   <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Save" ValidationGroup="Save"/>
                               </td>
                                <td style="width:20px;"></td>
                               <td>
                                   <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                               </td>
                           </tr>
                       </table>
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

