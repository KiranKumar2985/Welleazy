<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingForm.aspx.cs" Inherits="Welleazy.Case.TestingForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function CallPrint() {

            //document.getElementById('imglogo1').style.display = "block";
            var prtContent = document.getElementById('content');
            var WinPrint = window.open('', '', 'left=0,top=0,width=400,height=400,toolbar=0,scrollbars=0,status=0');

            WinPrint.document.write(prtContent.innerHTML);
            
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="PrintContent">
         <div class="form-group" style="background-color: white; padding: 3px; margin-top: 30px; border: 4px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:150px;">
             <div style="width:100%">
                 <div>
                     <table runat="server"  border="1" style="width:100%; border:1px solid #eeeaea;" >
                    <tr>
                        <td style="width:15%;padding-bottom:10px;padding-left:5px">
                            <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
                        </td>

                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label3" runat="server" Text="Customer DOB"></asp:Label>
                        </td>

                         <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label4" runat="server" Text="Customer DoB"></asp:Label>
                        </td>

                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label5" runat="server" Text="Nominee Name"></asp:Label>
                        </td>

                         <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label6" runat="server" Text="Nominee Name"></asp:Label>
                        </td>

                        </tr>
                      
                         
                     <tr style="padding:10px">
                        <td style="width:15%;padding-bottom:10px;padding-top:10px;padding-left:5px">
                            <asp:Label ID="Label7" runat="server" Text="Nominee DOB"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label8" runat="server" Text="Nominee DOB"></asp:Label>
                        </td>

                        <td style="width:20%">
                            <asp:Label ID="Label9" runat="server" Text="Applicztion No."></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label10" runat="server" Text="ApplicationNo"></asp:Label>
                        </td>

                        <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label11" runat="server" Text="Case TA Code"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label12" runat="server" Text="WX2266"></asp:Label>
                        </td>
                        </tr>

                         <tr style="padding:10px">
                        <td style="width:15%;padding-bottom:10px;padding-top:10px;padding-left:5px">
                            <asp:Label ID="Label13" runat="server" Text="Case Status"></asp:Label>
                        </td>
                        <td style="width:15%;padding-left:5px">
                            <asp:Label ID="Label14" runat="server" Text="Case Status"></asp:Label>
                        </td>

                        <td style="width:20%">
                            <asp:Label ID="Label15" runat="server" Text="Appointment Date Time"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label16" runat="server" Text="AppointmentDate"></asp:Label>
                        </td>

                        <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label17" runat="server" Text="MER Type"></asp:Label>
                        </td>

                         <td style="width:20%;padding-left:5px">
                            <asp:Label ID="Label18" runat="server" Text="MER Type"></asp:Label>
                        </td>
                        </tr>
                        
                      <%--<tr>
                        <td style="padding:10px;">
                            <asp:ImageButton ID="imgbthViewQCPoints" runat="server" ImageUrl="~/images/add_icon.png" Visible="true" Height="25" Width="26" OnClick="imgbthViewQCPoints_Click" />
                    
                         
                        </td>
                        <td style="padding:8px;">
                           QC Points
                        </td>
                        <td style="padding:8px;" colspan="2"></td>
                        </tr>--%>
                     </table>
                 </div>
             </div>
         </div>

         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:30px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;margin-bottom:10px;">
              <%--<div class="col-md-8">
   <%-- <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Bootstrap" ShowChooser="false" />
   <script type="text/javascript">
        window.pdfjsLib.GlobalWorkerOptions.workerSrc = 'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.2.2/pdf.worker.js';
    </script>
    <div class="demo-container size-wide no-bg" runat="server">
        <telerik:RadPdfViewer runat="server" ID="RadPdfViewer2" Height="550px" Width="100%" Scale="0.9">
            <PdfjsProcessingSettings File="../App_Data/RequirementDocument.pdf">
                
            </PdfjsProcessingSettings>
          
        </telerik:RadPdfViewer>
       
    </div>--%>                 
                  <%--<telerik:RadPdfViewer ID="rpdfVReport" runat="server" Height="600" Width="700">

                  </telerik:RadPdfViewer>
              </div>--%>
             <div>
                 
                 
                 <div class="form-group" runat="server" id="QCPoints" visible="true">
                         <table> 
                             <tr >
                                 <td >
                                     <telerik:RadGrid ID="rgvQuestions" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" ClientSettings-Scrolling-AllowScroll="false">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Questionaire" SortExpression="QuestionDescription">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblQuestionDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionDescription")%>'></asp:Label>
                                       <asp:Label ID="lblQuestionNo" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionNo")%>'></asp:Label>
                                       
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Yes/No" SortExpression="Status">
                                   <ItemTemplate>                                       
                                       <%--<telerik:RadComboBox ID="ddlStatus" runat="server" AutoPostBack="true" RenderMode="Lightweight" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="Combo_Export" ></telerik:RadComboBox>--%>
                                       <telerik:RadRadioButtonList ID="rbYesNo" runat="server" Width="80" Direction="Horizontal">
                                           <Items>
                                               <telerik:ButtonListItem Value="1" Text="Yes" />
                                               <telerik:ButtonListItem Value="2" Text="No" />
                                           </Items>
                                       </telerik:RadRadioButtonList>
                                       
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Remarks" SortExpression="Remarks">
                                   <ItemTemplate>                                       
                                       
                                       <asp:TextBox ID="txtRemarks" runat="server" Visible="true" Width="100" Text="" TextMode="MultiLine"></asp:TextBox>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                           </Columns>
                           </MasterTableView>
                                         

                                     </telerik:RadGrid>
                                 </td>
                             </tr>
                             
                             <tr>
                        <td style="padding:10px; text-align:center;" colspan="2">
                            <%--<asp:Button ID="btnSaveReport" Text="Save Report" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSaveReport_Click" />&nbsp;&nbsp;--%>
                            
                        </td>
                       
                        </tr>
                       </table>

                 </div>
             </div>
            <asp:Button ID="btnSubmit" Text="QC Submit" runat="server" CausesValidation="false" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClientClick="CallPrint();" />
             <asp:Button ID="Button1" Text="Print" runat="server" OnClick="Button1_Click" />
         </div>
             </div>
        <!--html-->
<div id="content" runat="server" visible="false">

    
             <div style="width:100%">

                 <div id="Heading" runat="server"  style="align-content:center;width:100%">
                     <asp:Label ID="lblHeading" runat="server" Text="Medical Examination Report"></asp:Label>
                     <%--<table style="border-width:medium;border-bottom-color:black;width:100%;align-content:center">
                         <tr style="align-content:center">
                             <td>

                             </td>
                             <td>

                             </td>
                             <td>

                             </td>
                             <td>

                             </td>
                             <td style="align-content:center;text-align:center;border:solid;width:30% ">
                                 <asp:Label ID="lblHeading" Font-Bold="true" Font-Size="Large" runat="server" Text="Medical Examination Report"> </asp:Label>
                             </td>
                              <td>

                             </td>
                              <td>

                             </td>
                             <td>

                             </td>
                             <td></td>
                         </tr>
                     </table>--%>
                 </div>
                 <br />
                 <div id="divDeclaration" runat="server">
                     <p>
                         This is the transcript of the answers provided by Life to be assured verbally to the questions asked below in a video verification by the underwriting team of
IndiaFirst Life Insurance Company Ltd. The answers provided by the Life to be assured would form a part of the application for insurance. The company has
accepted the answers provided in utmost good faith and thereby issued the policy. The Company reserves the rights to repudiate any claim arising out of this
policy in the event of any mis-statement or suppression of material information found either in the said verification or in the application form. 
                         <br />
                     </p>
                    <br />
                     <p>
                          We request you to go through the transcript carefully. In case of any disagreement, you are requested to highlight the same within 15 days of the receipt of
this transcript; otherwise this would be taken as acceptable to you and thereby binding on you. Please retain this transcript for future reference
                         <br />
                     </p>
                 </div>
                 <br />
                 <div>
                     <table runat="server"  border="2" style="width:100%; border-color:black; border:1px solid #eeeaea;" >
                    <tr>
                        <td style="width:15%;padding-bottom:10px;padding-left:5px;border:solid;border-bottom-color:black">
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
                        
                      <%--<tr>
                        <td style="padding:10px;">
                            <asp:ImageButton ID="imgbthViewQCPoints" runat="server" ImageUrl="~/images/add_icon.png" Visible="true" Height="25" Width="26" OnClick="imgbthViewQCPoints_Click" />
                    
                         
                        </td>
                        <td style="padding:8px;">
                           QC Points
                        </td>
                        <td style="padding:8px;" colspan="2"></td>
                        </tr>--%>
                     </table>
                 </div>
             </div>
         </div>
   
    <br />
    <br />

    <div id="mainContent" style="align-content:center">
        <table>
            <tr style="padding:10px">
                <td>
                    <asp:PlaceHolder ID="PrintData" runat="server" Visible="false" ></asp:PlaceHolder>
                </td>
            </tr>
        </table>
        <br />
        <br />
    
    </div>
    </div>
        <br />
        <br />

        <div id="divImg" runat="server">
        <table>
            <tr>
                <td>
                    Doctor Details
                </td>
                <td>
                    Doctor Signature
                    <asp:Image ID="DoctorSignature" AlternateText="Signature" runat="server"  />

                </td>
            </tr>
        </table>
    </div>

        <%--<asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" OnClientClick="CallPrint();" />--%>
        
    
    </form>
</body>
</html>
