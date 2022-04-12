<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubRole.aspx.cs" Inherits="Welleazy.SubRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Role List <span class="glyphicon glyphicon-plus" style="background:#113d7a; color:white; float:right; font-family:Montserrat; border-radius:3px; padding-left:5px;">
            <asp:Button ID="btnAddRole" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" type="submit" value="Add Role" CssClass="Login_btn btn" PostBackUrl="~/Home.aspx" Text="Add Role" />
   </h4> 
        <div style="padding:10px;">
        <div class="col-md-3">
                             <asp:TextBox ID="txt_role" runat="server" TextMode="SingleLine" placeholder="Role" class="form-control required" AutoPostBack="true" OnTextChanged="txt_role_TextChanged"></asp:TextBox>

                    </div>
            <div class="col-md-3">
       
                             <asp:TextBox ID="txt_subrole" runat="server" TextMode="SingleLine" placeholder="SubRole" class="form-control required" AutoPostBack="true" OnTextChanged="txt_subrole_TextChanged"></asp:TextBox>
                   
                    </div>
            </div>
                     <div class="line"></div>
                                 
        <div class="form-group" style="padding:10px; ">
            
                <asp:Label ID="Label1" runat="server" ></asp:Label>
           
            <div style="overflow-x:auto; ">
                
                <asp:GridView ID="GridViewSubRole" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="670px"  AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" OnRowCommand="GridViewSubRole_RowCommand" OnSorting="GridViewSubRole_Sorting" OnRowDeleting="GridViewSubRole_RowDeleting" OnPageIndexChanging="GridViewSubRole_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="Action">
    <ItemTemplate>
        <asp:Button ID="hyplnkEdit" runat="server"
            Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit"></asp:Button>
        <%--<asp:Button ID="hyplnkDelete" runat="server"
            Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Delete"></asp:Button>--%>
        <asp:Label ID="lblDCId" runat="server" Visible="false"
            Text='<%# Bind("subrole_id") %>'></asp:Label>

    </ItemTemplate>
       
</asp:TemplateField>          

                        <asp:BoundField DataField="name" HeaderText="Role" SortExpression="name"></asp:BoundField>
                        <asp:BoundField DataField="subrole" HeaderText="SubRole" SortExpression="subrole"></asp:BoundField>

                         
                    </Columns>
                </asp:GridView>
                               
            </div>
            
        </div>
          </div>
</asp:Content>
