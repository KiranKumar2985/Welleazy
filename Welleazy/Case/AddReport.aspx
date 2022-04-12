<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddReport.aspx.cs" Inherits="Welleazy.Case.AddReport" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" EnableSessionState="True" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Upload Report | Welleazy</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
<%--        <script type="text/javascript">
        var cnt = 0;
        function AddFileUpload() {
            var div = document.createElement('DIV');

            div.innerHTML = '<input id="file' + cnt + '" name = "file' + cnt +
                '" type="file" />' +
             '<a href="#" id="lnl' + cnt + '" onclick = "DeleteFileupload(this)" class="Login_btn btn" style="background-color:red; color:white; padding-left:11px; padding-right:11px;" />X</a>';
            document.getElementById("FileUploadGroup").appendChild(div);
            cnt++;
        }
        function DeleteFileupload(div) {
            document.getElementById("FileUploadGroup").removeChild(div.parentNode);
        }
    </script>--%>
    <style type="text/css">
            /*div.RadUpload .ruFakeInput {
  border:1px solid;
  border-color:#808080 !important;
  border-radius:3px;
     }
        div.RadUpload .ruButton {
           background-color:#eeeaea;
            color:Black;
            border-radius:3px;
            border:1px solid #808080;
        }*/

        div.RadAsyncUpload1 .ruButton{
            height:60px;
            padding:20px;
        }
    </style>


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

    <script type="text/javascript">
        function deleletconfig() {

            var del = confirm("Are you sure you want to delete this record?");
            if (del == true) {

            } else {

            }
            return del;
        }
        </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        
              <asp:MultiView runat="server" ID="AppointmentView">

            <asp:View ID="DefaultAppointment" runat="server" > 
                <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkAppointmentList" runat="server" PostBackUrl="~/Case/AppointmentList.aspx"  ForeColor="#0033cc">Appointment List</asp:LinkButton> >> Upload Reports

                </h5>
                <div class="form-group" style="background-color: white; padding: 3px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; ">
                    <div class="form-group" style="padding:10px; overflow:auto;">
                <table runat="server" border="1" style="width:100%; border:1px solid #eeeaea;" >
                    <tr>
                        <td style="padding:10px; background:#c6efe7;">Customer Name</td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblCaseOwnerName" runat="server" ></asp:Label>
                        </td>
                        <td style="padding:10px; background:#c6efe7;">Application No.</td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblApplicationNo" runat="server"></asp:Label>
                        </td>
                        <td style="padding:10px; background:#c6efe7;">Case Code/TA Code</td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblCaseId" runat="server" ></asp:Label>
                            <asp:Label ID="lblCaseRefId" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="padding:10px; background:#c6efe7;">Digitization Status</td>
                        <td style="padding:10px;">Pending</td>
                    </tr>
                    <tr>
                        <td style="padding:10px; background:#c6efe7;">Medical Test</td>
                        <td style="padding:10px;" colspan="3">
                             <asp:Label ID="lblMedicalTest" runat="server" ></asp:Label>
                        </td>
                        <td style="padding:10px; background:#c6efe7;">Scheduled Test</td>
                        <td style="padding:10px;" colspan="3">
                             <asp:Label ID="lblScheduledTest" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:10px; background:#c6efe7;">Case Status</td>
                        <td style="padding:10px;" colspan="3">
                            <asp:Label ID="lblCaseStatus" runat="server" ></asp:Label>
                             <telerik:RadComboBox ID="rcbCaseStatus" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Status" />

                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td style="padding:10px; background:#c6efe7;">Appointment Status</td>
                        <td style="padding:10px;" colspan="3">
                            <asp:Label ID="lblAppointmentStatus" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:10px; background:#c6efe7;">Interpretation Type</td>
                        <td style="padding:10px;"><asp:Label ID="lblInterpretationType" runat="server" ></asp:Label></td>
                        <td style="padding:10px; background:#c6efe7;">CMO Decision</td>
                        <td style="padding:10px;">NA</td>
                        <td style="padding:10px; background:#c6efe7;">Cardiologist Name</td>
                        <td style="padding:10px;"><asp:Label ID="lblDoctorName" runat="server" ></asp:Label></td>
                        <td style="padding:10px; background:#c6efe7;">Doctor Regn No.</td>
                        <td style="padding:10px;"><asp:Label ID="lblDoctorRegnNo" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="padding:10px; background:#c6efe7;">Geo-Location Details</td>
                        <td style="padding:10px;" colspan="6">NA</td>
                        
                    </tr>
                    
                </table>
            </div>
                    <div class="form-group" style="padding:10px;">
           
            <div class="col-md-3">
                    <label>Report Status </label>
                            <div class="selector">

                                <telerik:RadComboBox ID="rcbReportStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                                    </Items>
                    </telerik:RadComboBox>
                                <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:Label ID="lblCorporateId" runat="server" Visible="false" ></asp:Label>
                                </div>
                                </div>
            <div class="col-md-3">
                    <label>Date of Closure/Approval </label>
                           <div class="selector">
                                 <telerik:RadDateTimePicker ID="dtpClosureApproval" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                               <asp:Label ID="lblReportId" runat="server" Visible="false"></asp:Label>
                           </div>
            </div>
               
        </div>
                   <div class="form-group" style="padding:10px; margin-top:50px;">
           
            <div class="col-md-2">
                    <label>Photo ID </label>
                            <div class="selector">
                                <asp:RadioButtonList ID="rblPhotoId" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                       </asp:RadioButtonList>
                                </div>
                                </div>
            <div class="col-md-2">
                    <label>Photo </label>
                            <div class="selector">
                                <asp:RadioButtonList ID="rblPhoto" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblPhoto_SelectedIndexChanged" CausesValidation="false">
                                           <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                       </asp:RadioButtonList>
                                </div>
                                </div>
                       <div class="col-md-3">
                    <label>Geo Tagging </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbGeoTagging" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                    </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
                       <div class="col-md-2">
                    <label>OutSourced Test </label>
                            <div class="selector">
                                <asp:RadioButtonList ID="rblOutSourcedTest" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblOutSourcedTest_SelectedIndexChanged" CausesValidation="false">
                                           <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                       </asp:RadioButtonList>
                                </div>
                                </div>
               
        </div>
                    <div class="form-group" style="padding:10px; margin-top:60px; border:1px solid black; border-radius:8px;" id="OutSourced" runat="server" visible="false">
                        <span>OutSourced Test</span>
                        <asp:CheckBoxList ID="CBL_OutSourcedTestList" runat="server" RepeatDirection="Horizontal" RepeatColumns="7"></asp:CheckBoxList>
                        </div>
                    <div class="form-group" style="padding:10px; margin-top:60px;">
           
            <div class="col-md-4">
                    <label>1. Reports received mode : </label>
                            <div class="selector">
                                <asp:RadioButtonList ID="rblReportReceivedMode" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Text="Mail" Value="Mail"></asp:ListItem>
                                           <asp:ListItem Text="Whats up" Value="Whats up"></asp:ListItem>
                                           <asp:ListItem Text="Courier" Value="Courier"></asp:ListItem>
                                           <asp:ListItem Text="DC pick up" Value="DC pick up"></asp:ListItem>
                                       </asp:RadioButtonList>
                                </div>
                                </div>
            <div class="col-md-3">
                    <label>2. Reports received from : </label>
                           <div class="selector">
                                <asp:RadioButtonList ID="rblReportsReceivedFrom" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Text="DC" Value="DC"></asp:ListItem>
                                           <asp:ListItem Text="Sales" Value="Sales"></asp:ListItem>
                                       </asp:RadioButtonList>
                           </div>
            </div>
               
        </div>
                    <div class="form-group" style="padding:10px; margin-top:50px;">
           
            <div class="col-md-6">
                    <label>Comment </label>
                            <div class="selector">
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="100" class="form-control required"></asp:TextBox>
                                </div>
                </div>
                        </div>
                    <div class="form-group" style="padding:10px; margin-top:120px;">
<%--       <div class="form-group">
           <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" />
<hr />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="File Name" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
       </div>--%>
            <div class="col-md-12">
                    <label>Upload Reports </label><br />(Multiple Files can be uploaded)
                            <div class="selector">
                                <%--<a href="#" onclick="AddFileUpload()" class="Login_btn btn" style="background-color:#113d7a; color:white; border-style:none;">Add More</a>--%>
                                <p class="mandatory" style="font-size:small;"><b>Please Select less than 7 MB Report to upload, more than 7 MB not allow.</b></p>
                                <br />
                               <%-- <telerik:RadUpload ID="RadUpload1" runat="server" MaxFileInputsCount="10" RenderMode="Lightweight" AllowedFileExtensions=".pdf" Localization-Add="Add More" Localization-Delete="Delete">

                                </telerik:RadUpload> --%>
                                <label>DC Report: </label>
                                <%--<asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                                <asp:Label ID="lblUpload1" runat="server" ></asp:Label>
                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" RenderMode="Lightweight" MultipleFileSelection="Automatic" AllowedFileExtensions=".pdf"  Width="400"></telerik:RadAsyncUpload>
                            <br /><br />
                            </div>
                </div>
                        </div>
                      
                    <div class="form-group" style="padding:10px; margin-top:100px;">
           
            <div class="col-md-3">
                    <%--<label>Reports </label>--%>
                                <telerik:RadGrid ID="RadGridReports" runat="server" Skin="Bootstrap" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false" OnItemCommand="RadGridReports_ItemCommand" >
                 <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Reports" HeaderStyle-Font-Bold="true" SortExpression="ReportName">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkReportName" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" OnClientClick="LoadPDF()" Text='<%# DataBinder.Eval(Container.DataItem, "ReportName")%>'></asp:LinkButton>
                                       <asp:Label ID="lblAppointmentReportId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentReportId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               </Columns>
     </MasterTableView>
                                </telerik:RadGrid>
                              
                </div>
                         <div class="col-md-2">
                    <label>VIDEO FMR Reports </label>
                            <div class="selector">
                            </div>
                </div>
                         <div class="col-md-2">
                    <label>Interpretation Reports </label>
                            <div class="selector">
                            </div>
                </div>
                         <div class="col-md-3">
                                <asp:Button ID="btnFaceMatchReport" Text="Download FaceMatch Report" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" />
                         
                </div>
                         <div class="col-md-2">
                   
                                <asp:Button ID="btnQCCheckList" Text="QC CheckList" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnQCCheckList_Click" />
                             <asp:Label ID="lblQCAppointmentId" runat="server" Visible="false"></asp:Label>
                </div>
                        </div>
                    <div class="form-group" style="padding:10px; margin-top:200px;">
           <div class="col-md-4">
               <asp:Button ID="btnManagePDFReport" Text="Manage PDF Report" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Visible="false" />
               </div>
           <div class="col-md-4">
              
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Appoint" Visible="true" />
               &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click"  />
                <asp:Label ID="lblMessage" Text="" runat="server" />
            </div>
        </div>
                    <div class="form-group" style="padding:10px; margin-top:80px;">
                        <div class="col-md-3">
                    <label>Reports uploaded by DC </label>
                            <div class="selector">
                            </div>
                </div>
                        
                       
                    </div>
                    <div class="form-group" style="padding:10px; margin-top:80px;">
                        <div class="col-md-3">
                    <label>Documents uploaded by DC </label>
                            <div class="selector">
                            </div>
                </div>
                        </div>
              </div>
            </asp:View>
            <asp:View ID="AddAppointment" runat="server"> 
           
            </asp:View>
      
                  </asp:MultiView>
         </div>
                      
                      </ContentTemplate>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
                <asp:PostBackTrigger ControlID="btnCancel" />
            </Triggers>
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
   
</asp:Content>