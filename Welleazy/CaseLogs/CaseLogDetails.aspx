<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="CaseLogDetails.aspx.cs" Inherits="Welleazy.CaseLogs.CaseLogDetails" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Report Remark | Welleazy </title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; ">
        <h4 style="background-color:#f6f5f5; padding:15px; border-radius:3px; border: 4px solid #808080; border-bottom-style: none; border-left-style: none; border-right-style: none;">
            Comment Logs
             <span style="float:right; font-size:small;">
                    <asp:LinkButton ID="btnGoBack" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClientClick="JavaScript:window. history. back(1); return false;" CausesValidation="false" > Go Back </asp:LinkButton>
             </span>
        </h4><br />
        <div style="background-color:#f6f5f5; padding:15px; border-radius:3px;">
            Reports Logs<br /><br />
            <span style="overflow:auto; width:100%;">
            <telerik:RadGrid ID="rgvReportRemarkDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                OnItemCommand="rgvReportRemarkDetails_ItemCommand" OnNeedDataSource="rgvReportRemarkDetails_NeedDataSource" 
                OnPageIndexChanged="rgvReportRemarkDetails_PageIndexChanged" Skin="Bootstrap">
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Sr. No."  >
                                   <ItemTemplate>
                                       <asp:Label ID="lblSNo" runat="server" Width="50" Text='<%# Container.DataSetIndex+1 %>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Comments" SortExpression="ReportRemark">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReportRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportRemark")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="DisplayName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                                                
                                   </Columns> 
                       </MasterTableView>
                  </telerik:RadGrid>
                </span>
        </div><br />
        <div style="background-color:#f6f5f5; padding:15px; border-radius:3px;">
            Appointment Logs<br /><br />
            <span style="overflow:auto; width:100%;">
            <telerik:RadGrid ID="rgvAppointmentRemarkDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                OnItemCommand="rgvAppointmentRemarkDetails_ItemCommand" OnNeedDataSource="rgvAppointmentRemarkDetails_NeedDataSource" 
                OnPageIndexChanged="rgvAppointmentRemarkDetails_PageIndexChanged" Skin="Bootstrap" >
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Sr. No."  >
                                   <ItemTemplate>
                                       <asp:Label ID="lblSNo" runat="server" Width="50" Text='<%# Container.DataSetIndex+1 %>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Comments" SortExpression="Remark">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Remark")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="CreatedBy">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                                                
                                   </Columns> 
                       </MasterTableView>
                  </telerik:RadGrid>
                </span>
        </div><br />
        <div style="background-color:#f6f5f5; padding:15px; border-radius:3px;">
            Case Logs<br /><br />
            <span style="overflow:auto; width:100%;">
            <telerik:RadGrid ID="rgvCaseRemarkDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                OnItemCommand="rgvCaseRemarkDetails_ItemCommand" OnNeedDataSource="rgvCaseRemarkDetails_NeedDataSource" 
                OnPageIndexChanged="rgvCaseRemarkDetails_PageIndexChanged" Skin="Bootstrap" >
                       <ClientSettings>
              
                </ClientSettings>
                      <MasterTableView Width="100%" AllowMultiColumnSorting="true" AllowSorting="true">
                   
                               <Columns>
                                   <telerik:GridTemplateColumn HeaderText="Sr. No."  >
                                   <ItemTemplate>
                                       <asp:Label ID="lblSNo" runat="server" Width="50" Text='<%# Container.DataSetIndex+1 %>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Comments" SortExpression="ActionPerformed">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActionPerformed")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created On" SortExpression="CreatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="CreatedBy">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>

                                   <telerik:GridTemplateColumn HeaderText="Updated On" SortExpression="UpdatedOn">
                                       <ItemTemplate>
                                           <asp:Label ID="lblUpdatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedOn")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   <telerik:GridTemplateColumn HeaderText="Updated By" SortExpression="UpdatedBy">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedBy")%>'>
                                                        </asp:Label>
                                       </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                                                
                                   </Columns> 
                       </MasterTableView>
                  </telerik:RadGrid>
                </span>
        </div>
        </div>
</asp:Content>
