<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="LoginCreation.aspx.cs" Inherits="Welleazy.Admin.LoginCreation" %>


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
        <asp:UpdatePanel ID="upLoginCreation" runat="server">
            <ContentTemplate>
         <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Login Creation<span style="float:right;">
            <asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;" CausesValidation="false"/>

                                </span></h4>
                                   <div class="line"></div>     
           <div class="form-group">
               <asp:MultiView ID="LoginCreationView" runat="server">
               
               <asp:View ID="Save" runat="server">
                 
                  
                           
                           <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Login Type <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbLoginType" CausesValidation="false" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains" OnSelectedIndexChanged="cmbLoginType_SelectedIndexChanged">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                               <telerik:RadComboBoxItem Value="1" Text="Diagnostic Center" />
                                               <telerik:RadComboBoxItem Value="2" Text="Corporate" />
                                               <telerik:RadComboBoxItem Value="3" Text="WellEasy" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvcmbLoginType" runat="server" ControlToValidate="cmbSubRole" ForeColor="Red" InitialValue="-Select-" ErrorMessage="Select Type"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Sub Role <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbSubRole" RenderMode="Lightweight" CausesValidation="false" AutoPostBack="true"  OnSelectedIndexChanged="cmbSubRole_SelectedIndexChanged" AppendDataBoundItems="true" runat="server" Filter="Contains">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvcmbSubRole" runat="server" ControlToValidate="cmbSubRole" ForeColor="Red" InitialValue="-Select-" ErrorMessage="Select Role"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   User <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbUser" RenderMode="Lightweight" CausesValidation="false" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbUser_SelectedIndexChanged" Filter="Contains">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCmbUser" runat="server" ControlToValidate="cmbUser" ForeColor="Red" InitialValue="-Select-" ErrorMessage="Select User Name"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Corporate Name <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight"  OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" AppendDataBoundItems="true" runat="server" Filter="Contains">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <%--<asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" InitialValue="-Select-" ErrorMessage="Select Corporate Name"></asp:RequiredFieldValidator>--%>
                                   </div><br />
                               </div>

                               <div class="col-md-3">
                                   <label>
                                   User Name <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtUserName" CssClass="form-control required" runat="server" ></asp:TextBox>
                                       <asp:LinkButton ID="lnkCheckUserName" runat="server" CausesValidation="false" OnClick="lnkCheckUserName_Click" Text="Check User Name Availability" ForeColor="#0000ff"></asp:LinkButton>
                                       <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ForeColor="Red" InitialValue="" ErrorMessage="Please Enter User Name"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3" runat="server" id="InputPassword" visible="true">
                                   <label>
                                   Password <span class="mandatory"></span></label>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control required" TextMode="Password"></asp:TextBox>
                                       <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" InitialValue="" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>--%>
                                   </div>
                               </div>

                               <div class="col-md-3">
                                   <label>
                                   Display Name <span class="mandatory">*</span></label>
                                   </label>
                                   <div class="selector">
                                       <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control required" ></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server" ControlToValidate="txtDisplayName" ForeColor="Red" InitialValue="" ErrorMessage="Please Enter Display Name"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               
                               
                               <%--<div class="col-md-3">
                                   <label>
                                   Employee Name
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbEmployeeName" RenderMode="Lightweight" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbEmployeeName_SelectedIndexChanged" Filter="Contains">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="-Select-" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <br /><br />
                                   </div>
                               </div>--%>
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
                  
                             </div>
                                                   
                           <div class="form-group" style="overflow:auto; width:100%; padding:10px;">
                               
                                           <telerik:RadGrid ID="rgvDefaultRoleTasks" runat="server"
                            AutoGenerateColumns="False" Visible="true"
                            CellSpacing="0" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                            HeaderStyle-VerticalAlign="Middle"
                            ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left" CellPadding="4" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White"
                            OnItemDataBound="rgvDefaultRoleTasks_ItemDataBound">
                            <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Assign Permissions For Roles" SortExpression="">
                                        <HeaderTemplate>
                    <asp:Label ID="lblProcessHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Permission")%>' ></asp:Label>
                </HeaderTemplate>
                                        <ItemTemplate>
                                              <asp:CheckBox  ID="chkAllTask" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="chkAllTask_CheckedChanged" />
                                                   
                                         <asp:Label ID="lblPermissionId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "PermissionId")%>'></asp:Label>
                                            <telerik:RadGrid ID="rgvDefaultRoleTasksDepth" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CellSpacing="0" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                                                HeaderStyle-VerticalAlign="Middle"
                                                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                                                CellPadding="4" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                                                <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn SortExpression="">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblProcessHeader" ForeColor="White" runat="server"></asp:Label>
                                                                
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
                                   <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Save" />
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
           </asp:MultiView>
           </div>          
       
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
    <%--<asp:HiddenField  ID="LoginRefId" runat="server"/>--%>
    </asp:Content>


