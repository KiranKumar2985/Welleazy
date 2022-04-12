<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestView.aspx.cs" Inherits="Welleazy.Test.TestView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
        <div class="popContent prod_redirect" style="width:50%; height:50%; margin-left:25%; margin-top:25%; background-color:wheat;">
        <div class="sec_title">
       <h4> Medical Test</h4>
        <hr />
        <h5> Individual Test</h5>
        <hr />
        <h5> Package List</h5>
    </div>
    </div>

                      </ContentTemplate>
                      </asp:UpdatePanel>
    </form>
</body>
</html>
