<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Welleazy.UserList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User List | Welleazy</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>

    <h5 style="margin-top:-20px;">
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> User Management >> User List
            </h5>
            <div class="form-group" style="background-color: white; padding: 3px; margin-top: 10px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
                <div class="form-group" style="padding:10px; padding-top:20px; ">
           
                <div class="col-md-2">
                        <asp:TextBox ID="txt_Name" runat="server" placeholder="Name" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Name_TextChanged"></asp:TextBox>
                    </div>
                <div class="col-md-3">
                        <asp:TextBox ID="txt_Email" runat="server" placeholder="Email" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Email_TextChanged"></asp:TextBox>
                    </div>
                <div class="col-md-2">
                        <asp:TextBox ID="txt_Contact" runat="server" placeholder="Contact" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Contact_TextChanged"></asp:TextBox>
                    </div>
                <div class="col-md-2">
                        <asp:TextBox ID="txt_Role" runat="server" placeholder="Role" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_Role_TextChanged"></asp:TextBox>
                    </div>
                <div class="col-md-2">
                        <asp:TextBox ID="txt_SubRole" runat="server" placeholder="SubRole" TextMode="SingleLine" class="form-control required" AutoPostBack="true" OnTextChanged="txt_SubRole_TextChanged"></asp:TextBox>
                    </div>
              </div>
          <div class="form-group" style="padding:10px; padding-top:20px; margin-top:40px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none; overflow:auto; ">
              <telerik:RadGrid ID="rgvUserListDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false" OnItemCommand="rgvUserListDetails_ItemCommand" OnPageIndexChanged="rgvUserListDetails_PageIndexChanged" OnNeedDataSource="rgvUserListDetails_NeedDataSource" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="user_id">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkUserId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="16" Width="16" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <%--<asp:LinkButton ID="lnkTestId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "TestId")%>'></asp:LinkButton>--%>
                                       <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <%--<telerik:GridTemplateColumn HeaderText="UserId" SortExpression="user_id">
                                   <ItemTemplate>
                                       <asp:Label ID="lblUserIdU" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "user_id")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>--%>
                               <telerik:GridTemplateColumn HeaderText="Name" SortExpression="Name">
                                   <ItemTemplate>
                                       <asp:Label ID="lblname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Email" SortExpression="EmailId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblemail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Contact" SortExpression="ContactNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblcontact" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContactNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Role" SortExpression="RoleDescription">
                                   <ItemTemplate>
                                       <asp:Label ID="lblroleid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoleDescription")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="SubRole" SortExpression="subrole">
                                   <ItemTemplate>
                                       <asp:Label ID="lblsubroleid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "subrole")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Status" SortExpression="Status">
                                   <ItemTemplate>
                                       <asp:Label ID="lblstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <%--<telerik:GridTemplateColumn HeaderText="AccountStaus" SortExpression="">
                                   <ItemTemplate>
                                       
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="UserType" SortExpression="user_type">
                                   <ItemTemplate>
                                       <asp:Label ID="lblusertype" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "user_type")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Reporting" SortExpression="">
                                   <ItemTemplate>
                                       <asp:Label ID="lblreporting" runat="server" Text="NA">
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>--%>
                               <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                   <ItemTemplate>
                                       <asp:Label ID="lblcreatedat" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="DisplayName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblcreatedby" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Update On" SortExpression="UpdatedOn">
                                   <ItemTemplate>
                                       <asp:Label ID="lblupdatedat" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedOn")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Update By" SortExpression="UpdatedBy">
                                   <ItemTemplate>
                                       <asp:Label ID="lblupdatedby" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedBy")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                            </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
          </div>
            </div>
    </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
