<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="QCSummary.aspx.cs" Inherits="Welleazy.Case.QCSummary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>QC Summery | Welleazy </title>
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
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 4px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:850px;">
 
      <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  ForeColor="#0033cc">Appointment List</asp:LinkButton> >> Digitization Summary >> <asp:Label ID="lblCorporateName" runat="server"></asp:Label>
          <asp:Label ID="lblCorporateId" runat="server" Visible="false"></asp:Label>
          <asp:Label ID="lblReportId" runat="server" Visible="false"></asp:Label>
          <asp:Label ID="lblCaseRefId" runat="server" Visible="false"></asp:Label>
          <asp:Label ID="lblCaseId" runat="server" Visible="false"></asp:Label>
          <asp:Label ID="lblQReportId" runat="server" Visible="false"></asp:Label>
             <span style="float:right; font-size:small;">
                    
             </span>
        </h5>

         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:10px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
              <div class="col-md-8">
          
                  <telerik:RadPdfViewer ID="RadPdfViewer1" runat="server" Height="600" Width="700">

                  </telerik:RadPdfViewer>
              </div>
             <div class="col-md-4">
                 <div>
                     <table runat="server" border="1" style="width:100%; border:1px solid #eeeaea;" >
                    <tr>
                        <th style="padding:10px; background:#c6efe7;" colspan="2">Application No</th>
                        <th style="padding:10px; background:#c6efe7;">Gender</th>
                        <th style="padding:10px; background:#c6efe7;">Visit Type</th>
                        </tr>
                     <tr>
                        <td style="padding:10px; background:#e4e3e3;" colspan="2">
                            <asp:Label ID="lblApplicationNo" runat="server"></asp:Label>
                        </td>
                        <td style="padding:10px; background:#e4e3e3;">
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                        </td>
                        <td style="padding:10px; background:#e4e3e3;">
                            <asp:Label ID="lblVisitType" runat="server"></asp:Label>
                            <asp:Label ID="lblTestList" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;" colspan="4"></td>
                        </tr>
                      <tr>
                        <td style="padding:10px;">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/add_icon.png" Visible="true" Height="25" Width="26" OnClick="ImageButton1_Click" />
                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/red_minus_icon.png" Visible="false" Height="22" Width="22" OnClick="ImageButton2_Click" />
                         
                        </td>
                        <td style="padding:8px;">
                           QC Points
                        </td>
                        <td style="padding:8px;" colspan="2"></td>
                        </tr>
                     </table>
                 </div>
                 
                 <div class="form-group" runat="server" id="QCPoints" visible="false">
                     <div class="col-md-12">
                             <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                    </Items>
                                </telerik:RadComboBox>
                          <telerik:RadComboBox ID="rcbQCErrorType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select ErrorType" />
                                    </Items>
                                </telerik:RadComboBox>
                         <telerik:RadComboBox ID="rcbReportStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" Visible="false" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                                    </Items>
                    </telerik:RadComboBox>
                         <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" runat="server" Visible="false" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                    </telerik:RadComboBox>
                         <asp:Label ID="lblCaseStatus" runat="server" Visible="false"></asp:Label>
                    </div>
                     <table runat="server" id="MerDrDetails" visible="false" border="1" style="width:100%; border:1px solid #eeeaea; border-radius:2px; background-color:#e4f8f6; font-size:small;" >
                        <tr>
                        <td style="padding:10px;">MER Dr. Name</td>
                        <td style="padding:10px;">
                            <asp:TextBox ID="txtMerDrName14" runat="server" TextMode="SingleLine" placeholder="MER Dr. Name" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;">MER Dr. Regis. No</td>
                        <td style="padding:10px;">
                            <asp:TextBox ID="txtMerDrRNo15" runat="server" TextMode="SingleLine" placeholder="MER Dr. Regis. No" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;">MER Dr. Qualifications</td>
                        <td style="padding:10px;">
                            <asp:TextBox ID="txtMerDrQualification16" runat="server" TextMode="SingleLine" placeholder="MER Dr. Qualifications" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;">Disclosures</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion17" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                      </table>
                     <table runat="server" id="MerDetails" visible="false" border="1" style="margin-top:3px; width:100%; border:1px solid #eeeaea; background-color:#e4f8f6; font-size:small;" >
                        
                         <tr>
                        <td style="padding:10px;"> Application No in MER </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion18" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbMerQuestion18_SelectedIndexChanged" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Old Application No" />
                                    </Items>
                    </telerik:RadComboBox>
                            <asp:TextBox ID="txtOldApplicationNo19" runat="server" Visible="false" TextMode="SingleLine" placeholder="Old Application No" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>

                         <tr>
                        <td style="padding:10px;"> MER Date Available </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion20" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> BP reading & Pulse Rate </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion21" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Unclear" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Family History (Age, health status if died casue of death) </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion22" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Incomplete" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Self attested feedback form and ID proof </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion23" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbMerQuestion23_SelectedIndexChanged" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Exception" />
                                    </Items>
                    </telerik:RadComboBox>
                            <asp:TextBox ID="txtMerQuestion24" runat="server" Visible="false" TextMode="SingleLine" placeholder="" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Ht/Wt/DOB/Age Matching in Reports </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion25" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> All MER Questions Answered </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion26" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Any question marked as Yes in MER ? </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion27" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbMerQuestion27_SelectedIndexChanged" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr id="RemarkGiven" runat="server" visible="false">
                        <td style="padding:10px;"> Remarks given for the questions marked as yes </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion28" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Client Sign, DC Seal & Doctor Sign available on MER? </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion29" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                         <tr>
                        <td style="padding:10px;"> Was reflexive test applicable </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbMerQuestion30" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                      </table>
                      <table runat="server" border="1" style="margin-top:3px; width:100%; border:1px solid #eeeaea; background-color:#e4f8f6; font-size:small;" >
                        <tr>
                        <td style="padding:10px;">Insured Name matches ? </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion1" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Unclear" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Client ID Proof</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion2" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbQuestion2_SelectedIndexChanged" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Voters Card" />
                                        <telerik:RadComboBoxItem Value="2" Text="Aadhaar Card" />
                                        <telerik:RadComboBoxItem Value="3" Text="Pan Card" />
                                        <telerik:RadComboBoxItem Value="4" Text="Passport" />
                                        <telerik:RadComboBoxItem Value="5" Text="Driving Licence" />
                                        <telerik:RadComboBoxItem Value="6" Text="Other" />
                                        <telerik:RadComboBoxItem Value="7" Text="Missing" />
                                    </Items>
                    </telerik:RadComboBox>

                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Client ID Proof Number</td>
                        <td style="padding:10px;">
                            <asp:TextBox ID="rcbQuestion3" runat="server" TextMode="SingleLine" placeholder="Client ID Proof" class="form-control required Combo_Export" ></asp:TextBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Live Photo</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion4" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Unclear" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">ID & Live Photo / Face Match Score</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion5" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Inconclusive" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Appointment date and date on report matching</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion6" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbQuestion6_SelectedIndexChanged" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                            <asp:TextBox ID="txtQuestion7" runat="server" Visible="false" TextMode="SingleLine" placeholder="" class="form-control required" ></asp:TextBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">DC name on CRM matching with DC name on reports</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion8" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                        <telerik:RadComboBoxItem Value="3" Text="Outsource" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Report Document Sequence</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion9" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                            <tr id="AadhaarMasked" runat="server" visible="false">
                        <td style="padding:10px;">8 digits of Aadhaar card numbers masked? </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion10" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr>
                        <td style="padding:10px;">Report Naming Convention</td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion11" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                           <tr>
                        <td style="padding:10px;"> Client Should not wear Face Mask while performing medicals </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbQuestion33" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                           <tr>
                        <td style="padding:10px;">Report Checklist based on Scheduled test, And values
                        
                            
                            <asp:CheckBoxList ID="CBL_MedicalTestList" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
                        </td>
                               <td style="padding:10px;">
                                   <asp:Button ID="btnViewTest" Text="View Test" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" OnClick="btnViewTest_Click" BorderStyle="None" data-toggle="modal" />
                               </td>
                        </tr>
                        <tr runat="server" visible="false" id="InterpretationAdded" style="margin-top:3px;">
                        <td style="padding:10px;"> Interpretation Added </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="rcbInterQuestion13" RenderMode="Lightweight" CssClass="Combo_Export" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                        <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="2" Text="No" />
                                    </Items>
                    </telerik:RadComboBox>
                        </td>
                        </tr>
                          <tr runat="server" visible="false" id="LIPTestT" style="margin-top:3px;">
                        <td style="padding:10px;" colspan="2"> Test Components LIP <br />
                        
                            <asp:CheckBoxList ID="CBL_TestComponentLIP31" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
                        </td>
                        </tr>
                          <tr runat="server" visible="false" id="LFTTestT" style="margin-top:3px;">
                        <td style="padding:10px;" colspan="2"> Test Components LFT <br />

                           <asp:CheckBoxList ID="CBL_TestComponentLFT32" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
                        </td>
                        </tr>
                            <tr>
                        <td style="padding:10px;" colspan="2">Comment</td>
                       
                        </tr>
                             <tr>
                        <td style="padding:10px;" colspan="2">
                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                        </td>
                       
                        </tr>
                              <tr>
                        <td style="padding:10px; text-align:center;" colspan="2">
                            <asp:Button ID="btnSaveReport" Text="Save Report" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSaveReport_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnQCSubmit" Text="QC Submit" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnQCSubmit_Click" />
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
        <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Test Details </h4>
            </div>
            <div class="modal-body">
                <telerik:RadGrid ID="RadGridTest" runat="server" Skin="Bootstrap" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false">
                 <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Test Code" HeaderStyle-Font-Bold="true" SortExpression="TestCode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestCode")%>'></asp:Label>
                                       <asp:Label ID="lblTestId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Test Name" HeaderStyle-Font-Bold="true" SortExpression="TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               </Columns>
     </MasterTableView>
                                </telerik:RadGrid>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>
 
</asp:Content>

