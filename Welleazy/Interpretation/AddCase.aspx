<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCase.aspx.cs" Inherits="Welleazy.Interpretation.AddCase" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Second Opinion | Add Case</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
<%--    <script type="text/javascript">  
        function showhide() 
        {  
            var div = document.getElementById("BulkUpload");  
            if (div.style.display !== "none") {  
                div.style.display = "none";  
            }  
            else {  
                div.style.display = "block";  
            }  
        }  
    </script> --%>
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
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Second Opinion >> <asp:LinkButton ID="LinkInterpretation" runat="server" OnClick="LinkInterpretation_Click" ForeColor="#0033cc">Open Second Opinion Case List</asp:LinkButton> >> <asp:Label ID="lblHeading" runat="server" Text="Add Second Opinion Case"></asp:Label>
            <span style="float:right; font-size:small;"><i class="glyphicon glyphicon-plus"></i> <asp:LinkButton ID="Linkspl1" runat="server" OnClick="Linkspl1_Click" ForeColor="#0033cc" CausesValidation="false" ><b></b>Bulk Upload</asp:LinkButton></span>
        </h5>
                                   <div class="line"></div>
         <div class="form-group" id="BulkUpload" runat="server" visible="false" style="margin-top:-30px; padding:10px; margin-bottom:100px;">
             <span style="float:right;">
                 <%--<asp:Button ID="btnExport" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Format" OnClick="btnExport_Click" CausesValidation="false" />--%>
                 <asp:button ID="btnExport" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Format" OnClick="btnExport_Click"></asp:button>
                 
                </span>
             <label class="mandatory" style="font-size:small; width:70%;"> **Please Download Second Opinion Case Upload format and enter every Case according to Format and upload respective Case Type and Corporate Name with Carefully</label><br /> 
          <h5>Bulk Case Details Upload</h5>    
             <div class="form-group" style="">
                 <div class="col-md-3">
                        <label>Case Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbCaseTypeList" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case1">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                        <telerik:RadComboBoxItem Value="1" Text="Interpretation" />
                                        <telerik:RadComboBoxItem Value="2" Text="Digitization" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseTypeList" runat="server" ControlToValidate="rcbCaseTypeList" ForeColor="Red" ErrorMessage="Select Case Type" Enabled="true" ValidationGroup="Case1" InitialValue="Select Case Type"></asp:RequiredFieldValidator>
                         </div>
                    </div>    
                 <div class="col-md-3">
                        <label>Client Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCorporateList" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Case1">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateList" runat="server" ControlToValidate="rcbCorporateList" ForeColor="Red" ErrorMessage="Select Client Name" ValidationGroup="Case1" InitialValue="Select Client Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
                 
                     <div class="col-md-4">
                         <label> Import (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadInterpretationCase" RenderMode="Lightweight" runat="server" Height="17px" Width="210px" Skin="WebBlue" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                             </div>
                     </div>
                 </div>
             <div class="form-group" style="text-align:center; margin-bottom:30px;">
                     <div class="col-md-12" >
                         <label> </label>
                         <div class="selector">
                         <asp:button ID="btnUpload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Upload Now"  ValidationGroup="Case1" OnClick="btnUpload_Click"></asp:button>
                             &nbsp;&nbsp;&nbsp;
                             <asp:button ID="btnCancelB" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Cancel" OnClick="btnCancelB_Click"></asp:button>
                             </div>
                         <hr />
                     </div>
                   </div>
         </div>

        <div class="form-group" style="padding:10px;">
            <div class="col-md-3">
                        <label>Case Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbCaseType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                        <telerik:RadComboBoxItem Value="1" Text="Interpretation" />
                                        <telerik:RadComboBoxItem Value="2" Text="Digitization" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="rcbCaseType" ForeColor="Red" ErrorMessage="Please Select CaseType" Enabled="true" ValidationGroup="Case" InitialValue="Select CaseType"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Client Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCorporate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="rcbCorporate" ForeColor="Red" ErrorMessage="Please Select Client Name" ValidationGroup="Case" InitialValue="Select Client Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Customer Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <asp:TextBox ID="txtCustomerName" runat="server" TextMode="SingleLine" placeholder="Customer Name" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ControlToValidate="txtCustomerName" ForeColor="Red" ErrorMessage="Please Enter Customer name" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Application Number <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <asp:TextBox ID="txtApplicationNo" runat="server" TextMode="SingleLine" placeholder="Application Number" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvApplicationNo" runat="server" ControlToValidate="txtApplicationNo" ForeColor="Red" ErrorMessage="Please Enter Application Number" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>

                        </div><br />
                    </div>
            </div>                      
        <div class="form-group" style="padding:10px;">
            <div class="col-md-3">
                        <label>Policy Number <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <asp:TextBox ID="txtPolicyNo" runat="server" TextMode="SingleLine" placeholder="Policy Number" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPolicyNo" runat="server" ControlToValidate="txtPolicyNo" ForeColor="Red" ErrorMessage="Please Enter Policy Number" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Case Rec'd Mode </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseRecMode" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Mode" />                               
                                        <telerik:RadComboBoxItem Value="1" Text="Insurer" />
                                        <telerik:RadComboBoxItem Value="2" Text="Email" />
                                        <telerik:RadComboBoxItem Value="3" Text="SMS" />
                                        <telerik:RadComboBoxItem Value="4" Text="FTP" />
                                </Items>
                            </telerik:RadComboBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Interpretation Type </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbInterpretationType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Interpretation Type" />
                                </Items>
                             </telerik:RadComboBox>
                            <%--<asp:RequiredFieldValidator ID="rfvInterpretationType" runat="server" ControlToValidate="rcbInterpretationType" ForeColor="Red" ErrorMessage="Please Select Interpretation Type" Enabled="true" ValidationGroup="Case" InitialValue="Select InterpretationType"></asp:RequiredFieldValidator>--%>
                         </div>
                    </div>
        <div class="col-md-3" style="display:none;">
                    <label>Case Status </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" Visible="false" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
        </div>                      
        <div class="form-group" style="padding:10px;">
            <div class="col-md-3">
                        <label>Remark  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" placeholder="Remark" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark" ForeColor="Red" ErrorMessage="Please Enter Remark" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-md-3" id="UploadReport" runat="server" visible="true">
                        <label>Upload Report  <span class="mandatory">*</span></label>
                        <div class="selector">
                    
    <script type="text/javascript">
 
        function validateUpload(sender, args) {
            var upload = $find("rauUploadReport");
            args.IsValid = upload.getUploadedFiles().length != 0;
        }
    
    </script>
                            <telerik:RadAsyncUpload ID="rauUploadReport" runat="server" RenderMode="Lightweight" AllowedFileExtensions=".pdf"  Width="400" ></telerik:RadAsyncUpload>
                            <%--<asp:RequiredFieldValidator ID="rfvUploadReport" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="rauUploadReport" ForeColor="Red" ></asp:RequiredFieldValidator>  OnFileUploaded="rauUploadReport_FileUploaded" --%>
                            <asp:CustomValidator ID="rcvUploadReport" runat="server" ErrorMessage="Mandatory Field" ClientValidationFunction="validateUpload" ></asp:CustomValidator>
                        
                        </div>
                    </div>
            
        </div>
        <div class="form-group" style="padding:10px; margin-top:200px; text-align:center;">
           
           <div class="col-md-12">
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Case" />
           &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel"/>
                
            </div>
        </div>
         </div>
         </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="Linkspl1" />
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
        <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",3000);
 }
</script>
</asp:Content>
