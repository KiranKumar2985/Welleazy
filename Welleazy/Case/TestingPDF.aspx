<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingPDF.aspx.cs" EnableEventValidation="false" Inherits="Welleazy.Case.TestingPDF" %>

<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<telerik:RadScriptManager ID="ScriptManager1" runat="server"></telerik:RadScriptManager>--%>
    <form id="form1" runat="server">

        <div id="PrintContent" runat="server">
         <div class="form-group" style="background-color: white; padding: 3px; margin-top: 30px; border: 4px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:150px;">
             <div style="width:100%">
                 <div>
                     <table runat="server"  border="1" style="width:100%; border:1px solid #eeeaea;" >
                    <tr>
                        <td style="width:15%;padding-bottom:10px;padding-left:5px">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblCustomerNameValue" runat="server" Text="Customer Name"></asp:Label>
                        </td>

                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblCustomerDOB" runat="server" Text="Customer DOB"></asp:Label>
                        </td>

                         <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblCustomerDOBValue" runat="server" Text="Customer DoB"></asp:Label>
                        </td>

                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblNomineeName" runat="server" Text="Nominee Name"></asp:Label>
                        </td>

                         <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblNomineeNameValue" runat="server" Text="Nominee Name"></asp:Label>
                        </td>

                        </tr>
                      
                         
                     <tr style="padding:10px">
                        <td style="width:15%;padding-bottom:10px;padding-top:10px;padding-left:5px">
                            <asp:Label ID="lblNomineeDOB" runat="server" Text="Nominee DOB"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblNomineeDOBValue" runat="server" Text="Nominee DOB"></asp:Label>
                        </td>

                        <td style="width:20%">
                            <asp:Label ID="lblApplcationNo" runat="server" Text="Applicztion No."></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblApplcationNoValue" runat="server" Text="ApplicationNo"></asp:Label>
                        </td>

                        <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblCaseCode" runat="server" Text="Case TA Code"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblCaseCodeValue" runat="server" Text="WX2266"></asp:Label>
                        </td>
                        </tr>

                         <tr style="padding:10px">
                        <td style="width:15%;padding-bottom:10px;padding-top:10px;padding-left:5px">
                            <asp:Label ID="lblCaseStatus" runat="server" Text="Case Status"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="lblCaseStatusValue" runat="server" Text="Case Status"></asp:Label>
                        </td>

                        <td style="width:20%">
                            <asp:Label ID="lblAppointmentDateTime" runat="server" Text="Appointment Date Time"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblAppointmentDateTimeValue" runat="server" Text="AppointmentDate"></asp:Label>
                        </td>

                        <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblMERType" runat="server" Text="MER Type"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="lblMERTypeValue" runat="server" Text="MER Type"></asp:Label>
                        </td>
                        </tr>
                        
               
                     </table>
                 </div>
             </div>

            
         </div>

         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:30px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;margin-bottom:10px;">
             
             <div>
                 
                 
                 <div class="form-group" runat="server" id="QCPoints" visible="true">
                         <table> 
                             <tr >
                                 <td >
                                     <asp:GridView ID="rgvQuestions" runat="server" AutoGenerateColumns="false">
                                         <Columns>
                                             <asp:TemplateField>
                                                 <ItemTemplate>
                        <asp:Label ID="lblQuestionDescription" Text='<%# Bind("QuestionDescription") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                                             </asp:TemplateField>

                                             <asp:TemplateField>
                                                 <ItemTemplate>
                        <asp:RadioButtonList ID="rbYesNo"  runat="server">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                                             </asp:TemplateField>

                                             <asp:TemplateField>
                                                 <ItemTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                    </ItemTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                     </asp:GridView>
                                 </td>
                             </tr>
                             
                             <tr>
                                 <td style="padding: 10px; text-align: center;" colspan="2">
                                     <%--<asp:Button ID="btnSaveReport" Text="Save Report" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSaveReport_Click" />&nbsp;&nbsp;--%>
                                     
                                 </td>
                       
                        </tr>
                       </table>

                 </div>
             </div>
            
         </div>
             </div>

   <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
