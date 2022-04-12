<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="QCCase.aspx.cs" Inherits="Welleazy.Case.QCCase" %>



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
          <asp:Label ID="lblConsultationCaseId" runat="server" Visible="false"></asp:Label>
          <asp:Label ID="lblConsultationCaseQCReportId" runat="server" Visible="false"></asp:Label>
             <span style="float:right; font-size:small;">
                    
             </span>
        </h5>

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
                            <asp:Label ID="lblApplcationNo" runat="server" Text="Application No."></asp:Label>
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

         <div id="divUploadTeleFiles" runat="server">
             <asp:Label ID="lblUploadTeleFiles" runat="server" Text="Audio/Video Upload (Multiple Files)"></asp:Label>
             <telerik:RadAsyncUpload ID="rauTeleMERFiles" MultipleFileSelection="Automatic" AllowedFileExtensions="mp4,mp3" runat="server" MaxFileInputsCount="5"></telerik:RadAsyncUpload>
         </div>

         <div id="divUploadVideoFiles" runat="server">
              <div class="form-group">
             <table>
                 <tr>
                     <td>
                         <asp:Label ID="lblUploadPhotoId" runat="server" Text="Upload Photo Id"></asp:Label>
             <telerik:RadAsyncUpload ID="rauPhotoId" MultipleFileSelection="Automatic" runat="server" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                     </td>

                     <td>
                         <asp:Label ID="lblUploadLivePhoto" runat="server" Text="Upload Live Photo"></asp:Label>
             <telerik:RadAsyncUpload ID="rauLivePhoto" MultipleFileSelection="Automatic" runat="server" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                     </td>

                      <td>
                         <asp:Label ID="lblUploadVideoScreenshot" runat="server" Text="Video Screenshot"></asp:Label>
             <telerik:RadAsyncUpload ID="rauVideoScreenshot" MultipleFileSelection="Automatic" runat="server" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                     </td>
                 </tr>
             </table>
                  </div>
              
         </div>

         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:30px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
              <div class="col-md-8">
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
                  <telerik:RadPdfViewer ID="rpdfVReport" runat="server" Height="600" Width="700">

                  </telerik:RadPdfViewer>
              </div>
             <div class="col-md-4">
                 
                 
                 <div class="form-group" runat="server" id="QCPoints" visible="true">
                         <table> 
                             <tr style="height:100px">
                                 <td style="height:100px">
                                     <telerik:RadGrid ID="rgvQCQuestions" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      OnItemCommand="rgvQCQuestions_ItemCommand" OnNeedDataSource="rgvQCQuestions_NeedDataSource" OnDataBound="rgvQCQuestions_DataBound" 
                                         OnPageIndexChanged="rgvQCQuestions_PageIndexChanged"
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" ClientSettings-Scrolling-AllowScroll="true" Height="450" OnItemDataBound="rgvQCQuestions_ItemDataBound">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Mandatory Points To Be Checked" SortExpression="QuestionDescription">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblQuestionDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionDescription")%>'></asp:Label>
                                       <asp:Label ID="lblQusetionId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "QusetionId")%>'></asp:Label>
                                       <asp:Label ID="lblReason" runat="server" Visible="false" Text="Reason" Width="100"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Status" SortExpression="Status">
                                   <ItemTemplate>                                       
                                       <telerik:RadComboBox ID="ddlStatus" runat="server" AutoPostBack="true" RenderMode="Lightweight" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="Combo_Export" ></telerik:RadComboBox>
                                       <asp:TextBox ID="txtReason" runat="server" Visible="false" Width="100" Text="" TextMode="MultiLine"></asp:TextBox>
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
                 <table>
                      <tr>
                                 <td>
                                     <asp:Label ID="lblComments" runat="server" Text="Comment :"></asp:Label> <span class="mandatory">*</span>
                                 </td>
                          <td>

                          </td>
                                 <td>
                                     <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfvComments" runat="server" ControlToValidate="txtComments" ErrorMessage="Please Enter Comments" ForeColor="Red"></asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                 </table>
                 <asp:Button ID="btnQCSubmit" Text="QC Submit" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnQCSubmit_Click" />
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

