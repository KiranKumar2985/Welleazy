<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingDynamicControls.aspx.cs" Inherits="Welleazy.TestingDynamicControls" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="true" OnItemDataBound="RadGrid1_ItemDataBound">
                 <MasterTableView>
           
                <Columns>
                   <%-- <telerik:GridBoundColumn SortExpression="Name" HeaderText="Name" DataField="Name" HeaderButtonType="TextButton" UniqueName="ShortName"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn  SortExpression="CategoryId" HeaderText="Id" DataField="CategoryId" HeaderButtonType="TextButton" Visible="False" Display="False" UniqueName="CategoryId"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="Description" HeaderText="Description" DataField="Description" HeaderButtonType="TextButton" UniqueName="Description"></telerik:GridBoundColumn>
                    <telerik:GridEditCommandColumn UniqueName="EditCol">
                    </telerik:GridEditCommandColumn>--%>


                </Columns>

                 </MasterTableView>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
