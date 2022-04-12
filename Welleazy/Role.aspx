<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Welleazy.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Role List <span class="glyphicon glyphicon-plus" style="background:#113d7a; color:white; float:right; font-family:Montserrat; border-radius:3px; padding-left:5px;">
            <asp:Button ID="btnAddRole" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" type="submit" value="Add Role" CssClass="Login_btn btn" OnClick="btnAddRole_Click" Text="Add Role" />
   
                    </h4>
                                   <div class="line"></div>
        <div class="form-group" id="RoleList" runat="server" visible="true" style="padding:10px; ">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>
           
            <div style="overflow-x:auto; ">
                
                <asp:GridView ID="GridViewRole" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="GridViewRole_RowCommand" OnSorting="GridViewRole_Sorting" OnRowDeleting="GridViewRole_RowDeleting" OnRowEditing="GridViewRole_RowEditing" OnPageIndexChanging="GridViewRole_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="hyplnkEdit" runat="server"
            Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit"></asp:Button>
        <%--<asp:Button ID="hyplnkDelete" runat="server"
            Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete"></asp:Button>--%>
        <asp:Label ID="lblRoleId" runat="server" Visible="false"
            Text='<%# Bind("role_id") %>'></asp:Label>

    </ItemTemplate>
       
</asp:TemplateField>          

                          <asp:BoundField DataField="name" HeaderText="Role" SortExpression="name"></asp:BoundField>

                         
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                </asp:GridView>
                               
            </div>
            
        </div>
         
        <div class="form-group" id="EditMode" runat="server" visible="false" style="padding:10px; padding-bottom:40px;">
                       
            <div class="form-group">
                
                <div class="col-md-4">
                        <label>Main Role </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Role" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="AddRole"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredField_Role" runat="server" ControlToValidate="txt_Role" ForeColor="Red" ErrorMessage="Please Enter Role" Enabled="true" ValidationGroup="AddRole"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                               
            </div>
            <div class="form-group" style="margin-top:80px; text-align:center;">
                <div class="col-md-4">
            <asp:Button ID="btnSave" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Save" type="submit" value="Save" CssClass="Login_btn btn" OnClick="btnSave_Click" ValidationGroup="AddRole"/>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Cancel" type="submit" value="Cancel" CssClass="Login_btn btn" OnClick="btnCancel_Click"/>
            <asp:Label ID="Label2" runat="server" Visible="false" ></asp:Label>
                               </div>
            </div>
        </div>
          </div>
    </asp:Content>
