<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="InterpretationReport.aspx.cs" Inherits="Welleazy.Interpretation.InterpretationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Interpretation | Report </title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.2.2/pdf.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.2.2/pdf.worker.js"></script>
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
     <div class="form-group" style="background-color: white; padding: 3px; margin-top:-30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:1150px;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Interpretation >> Interpretation Report</h5>
                                   
         <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" Visible="false" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                        </telerik:RadComboBox>
       
                      <div class="form-group" style=" padding-top:10px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
              <div class="col-md-8">
          
                  <telerik:RadPdfViewer ID="RadPdfViewer1" runat="server" Height="600" Width="700">

                  </telerik:RadPdfViewer>
              </div>
             <div class="col-md-4">
                 <asp:Label ID="lblCorporateId" runat="server" Visible="false"></asp:Label>
         <asp:Label ID="lblInterpretationType" runat="server" Visible="false"></asp:Label>
         <asp:Label ID="lblInterpretationTypeText" runat="server" Visible="false"></asp:Label>
         <asp:Label ID="lblReportName" runat="server" Visible="false"></asp:Label>
                        
         <div class="form-group" style="margin-top:1px;">
                
             <p style="border:1px solid #eeeaea; background-color:#1999f8; color:white; padding:5px; text-align:center; ">
                 <asp:Label ID="lblHeading" runat="server"></asp:Label>
                 
             </p>                                  
                 
                
                     <table runat="server" border="1" style="width:100%; border:1px solid #eeeaea;" >
                    <tr>
                        <th style="padding:5px; background:#c6efe7; width:50%;" colspan="2">Application No</th>
                        <th style="padding:5px; background:#c6efe7; width:50%;">Customer Name</th>
                        </tr>
                     <tr>
                        <td style="padding:5px; " colspan="2">
                            <asp:Label ID="lblApplicationNo" runat="server"></asp:Label>
                        </td>
                        <td style="padding:5px; ">
                            <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                        </td>
                        </tr>
                       <tr>
                        <th style="padding:5px; background:#c6efe7;" colspan="2">Doctor Name</th>
                        <th style="padding:5px; background:#c6efe7;">Doctor Regn No.</th>
                        </tr>
                     <tr>
                        <td style="padding:5px; " colspan="2">
                            <asp:Label ID="lblDoctorName" runat="server"></asp:Label>
                            <asp:Label ID="lblDoctorID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="padding:5px; ">
                            <asp:Label ID="lblDoctorRegn" runat="server"></asp:Label>
                            <asp:Label ID="lblCaseRefId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="LabelSignature" runat="server" Visible="false" ></asp:Label>
                        </td>
                        </tr>
                      <tr>
                        <td style="padding:5px;">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/add_icon.png" Visible="true" Height="25" Width="26" OnClick="ImageButton1_Click" />
                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/red_minus_icon.png" Visible="false" Height="22" Width="22" OnClick="ImageButton2_Click" />
                         
                        </td>
                        <td style="padding:8px;">
                           Interpretation Report
                        </td>
                        <td style="padding:8px;">Case Id/IE Code<br />
                            <asp:Label ID="lblCaseId" runat="server"></asp:Label>
                        </td>
                        </tr>
                     </table>
                 </div>
                 
                 <div class="form-group" runat="server" id="QCPoints" visible="false">
                       <table runat="server" border="1" style="width:100%; margin-top:10px; border:1px solid #eeeaea; background-color:#e4f8f6; font-size:small;" id="ECGInterpretation" visible="false">
                        <%--<tr>
                        <td style="padding:5px;">IE Code</td>
                        <td style="padding:5px;">                            
                            
                        </td>
                        </tr>--%>
                         <tr>
                        <td style="padding:5px;">Rate</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtRate" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;">Rhythm</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtRhythm" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;">Axis</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtAxis" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;">P Wave</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtPWave" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;">Pr Interval Pr Segment</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtPrIntervalPrSegment" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;">Q Wave</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtQWave" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">R Wave</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtRWave" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">QRS Complex</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtQRSComplex" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">QT Interval</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtQTInterval" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">ST Segment</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtSTSegment" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">T Wave</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtTWave" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Additional Waves</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtAdditionalWaves" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Chamber Hypertrophy</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtChamberHypertrophy" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Other</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtECGOther" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Status </td>
                        <td style="padding:5px;">
                             <telerik:RadComboBox ID="rcbEStatus" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="Normal" Text="Normal" />
                                        <telerik:RadComboBoxItem Value="Abnormal" Text="Abnormal" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:5px;" colspan="2">Suggestions</td>                        
                        </tr>
                        <tr>
                        <td style="padding:5px;" colspan="2">
                            <asp:TextBox ID="txtESuggestions" runat="server" TextMode="MultiLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                            </td>
                        
                        </tr>
                        </table>
                     <table runat="server" border="1" style="width:100%; margin-top:10px; border:1px solid #eeeaea; background-color:#e4f8f6; font-size:small;" id="TMTInterpretation" visible="false">
                        <%--<tr>
                        <td style="padding:5px;">IE Code</td>
                        <td style="padding:5px;">
                            <asp:Label ID="lblCaseId1" runat="server"></asp:Label>
                        </td>
                        </tr>--%>
                        <tr>
                        <td style="padding:5px;">ECG at Rest</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtECGatRest" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Target Heart Rate</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtTargetHeartRate" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">St T Changes</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtStTChanges" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Chest Pain Angina</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtChestPainAngina" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">BP Response</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtBPResponse" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Dyspnoea Breathlessness</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtDyspnoeaBreathlessness" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Arrhythmia</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtArrhythmia" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Exercise Capacity</td>
                        <td style="padding:5px;">
                            <asp:TextBox ID="txtExerciseCapacity" runat="server" TextMode="SingleLine" CssClass="form-control required"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;">Status </td>
                        <td style="padding:5px;">
                            <telerik:RadComboBox ID="rcbTStatus" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="Positive" Text="Positive" />
                                        <telerik:RadComboBoxItem Value="Negative" Text="Negative" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="padding:5px;" colspan="2">Suggestions</td>                        
                        </tr>
                        <tr>
                        <td style="padding:5px;" colspan="2">
                            <asp:TextBox ID="txtTSuggestions" runat="server" TextMode="MultiLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                            </td>
                        
                        </tr>
                        
                     </table>                 
                     
                      <table runat="server" border="1" style="margin-top:3px; width:100%; border:1px solid #eeeaea; background-color:#e4f8f6; font-size:small;" >
                              <tr>
                        <td style="padding:10px; text-align:center;" colspan="2">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Save" Width="100" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Cancel" Width="100" OnClick="btnCancel_Click" />
                        </td>
                       
                        </tr>
                       </table>

                 </div>
             </div>
            
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
       <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",2000);
 }
</script>
</asp:Content>
