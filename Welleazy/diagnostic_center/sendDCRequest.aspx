<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="sendDCRequest.aspx.cs" Inherits="Welleazy.diagnostic_center.sendDCRequest" EnableEventValidation="false" EnableSessionState="True" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | Send Request to DC </title>
     <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
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
 <asp:UpdatePanel ID="upCorporate" runat="server">
            <ContentTemplate>
    <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Send Add Provider Details Request<span style="float:right;"><asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClick="btnGoBack_Click" CausesValidation="false"/></span></h4> <%--OnClientClick="JavaScript:window. history. back(1); return false;"--%>
                                   <div class="line"></div>
        
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
            <h5>Provider Basic Information</h5>
            <hr />
            <div class="col-md-4">
                        <label>Hospital Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Hospitalname" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Hopital Name" ControlToValidate="txt_Hospitalname" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="lbl_dcid" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>Email Id  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Emailid" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmailid" runat="server" ErrorMessage="Please Enter Email Id" ControlToValidate="txt_Emailid" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                            <%--<asp:RegularExpressionValidator ID="revEmailid" runat="server" ErrorMessage="Incorrect Email id" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$" ControlToValidate="txt_Emailid" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>Type of Service Provider  </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_ServiceProviderType" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true">
                                 <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Provider Type" />
                                    </Items>
                            </telerik:RadComboBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Provider Type" ControlToValidate="DDL_ServiceProviderType" ForeColor="Red" InitialValue="Select Provider Type"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            </div>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:100px;">
            <div class="col-md-4">
                        <label>Concerned Person Name  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Concernedperson" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>

                        </div>
                    </div>
            <div class="col-md-4">
                        <label>Contact Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Contactnumber" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ErrorMessage="Please Enter Mobile Number" ControlToValidate="txt_Contactnumber" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revContactNumber" runat="server" ErrorMessage="Incorrect Mobile No" ValidationExpression="^[6-9]\d{9}$" ControlToValidate="txt_Contactnumber" ForeColor="Red"></asp:RegularExpressionValidator>

                        </div>
                    </div>  
        </div>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:200px;">
                        <div class="col-md-10" id="URL_link" runat="server" visible="false" >
                            <label>URL  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_URL" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Green" ></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="Green" ></asp:Label>
                            </div>
                        </div><br />
            
            
                   
        </div>
        
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:80px; background-color:white; text-align:center;">
            <asp:Button ID="btnSaveGenerate" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Save and Generate Link" type="submit" value="Save and Generate Link" CssClass="Login_btn btn" OnClick="btnSaveGenerate_Click" Visible="true"/><br />
            <asp:Label ID="Label1" runat="server" ></asp:Label><asp:Label ID="lbldc_id" runat="server" Visible="false"></asp:Label><br />
            <asp:Label ID="li" ForeColor="Red" runat="server" Visible="false" ></asp:Label><br /><asp:Label ID="Label2" ForeColor="Red" runat="server" ></asp:Label>
          
        </div>
    </div>

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
                </ContentTemplate>
     <Triggers>
         <asp:PostBackTrigger ControlID="btnSaveGenerate" />
     </Triggers>
     </asp:UpdatePanel>
</asp:Content>
