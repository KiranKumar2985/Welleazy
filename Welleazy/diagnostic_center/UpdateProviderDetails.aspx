<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UpdateProviderDetails.aspx.cs" Inherits="Welleazy.diagnostic_center.UpdateProviderDetails" EnableEventValidation="false" EnableSessionState="True" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Provider Details</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <link href="/images/welleazy-logo.png" rel="icon" />
        <%--<title>Go Welnext</title>--%>

         <!-- Bootstrap CSS CDN -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">--%>

        <!-- Our Custom CSS -->
        <link href="../css/style4.css" rel="stylesheet" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>  
    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
</script>
  
    <%-- <asp:UpdatePanel ID="upCorporate" runat="server">
            <ContentTemplate>--%>

    <div class="form-group" style="background-color: white; padding: 3px; margin-top: 30px; margin-bottom:150px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Update Service Provider Detalis<span style="float:right;"><asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;"/></span></h4>
                                   <div class="line"></div>

        <div class="form-group">
               <asp:MultiView ID="ProviderDetailsView" runat="server">
               
               <asp:View ID="Save" runat="server">

                    <p style="padding:10px; background:#088b37;  color:white; border-radius:2px; font-size:small;">
            <asp:Label ID="VerifyMobileNo" runat="server" ForeColor="White"></asp:Label></p>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
            
            <div class="col-md-4">
                        <label>Enter Mobile Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_mobileno" runat="server" TextMode="SingleLine" MaxLength="10" placeholder="Enter Mobile No" class="form-control required"></asp:TextBox>
                            <asp:Label ID="lblContactNo" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            
            <div class="col-md-3">
                <label><span class="mandatory"></span></label>
                        <div class="selector">
                <asp:Button ID="btnVerifyNo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Verify Mobile No" type="submit" value="Verify Mobile No" CssClass="Login_btn btn" OnClick="btnVerifyNo_Click" Visible="true"/><br />
                </div>
            </div>
            </div>

                           </asp:View>
               <asp:View ID="View" runat="server">
                        <p style="padding:10px; background:#088b37;  color:white; border-radius:2px; font-size:small;">
            <asp:Label ID="ContactText" runat="server" ForeColor="White"></asp:Label></p>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
            
            <div class="col-md-4">
                        <label>Enter OTP  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_otp" runat="server" TextMode="SingleLine" MaxLength="6" placeholder="Enter OTP" class="form-control required"></asp:TextBox>
                            <br />
                            <span runat="server" id="Attempt" style="color:red;" visible="false">Remaining attempt: <asp:Label ID="lblRemaining" runat="server"></asp:Label></span><br />
                            <asp:Label ID="lblLocked" runat="server" ForeColor="Red"></asp:Label>
                         </div>
                    </div>
            
            <div class="col-md-3">
                <label><span class="mandatory"></span></label>
                        <div class="selector">
                <asp:Button ID="btn_verify" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Verify OTP" type="submit" value="Verify OTP" CssClass="Login_btn btn" OnClick="btn_verify_Click" Visible="true"/><br />
                <asp:LinkButton ID="OTP_resendlink" runat="server" ForeColor="#0000ff" Font-Size="Small" OnClick="OTP_resendlink_Click">Resend OTP (If OTP is not received)</asp:LinkButton>
            <asp:Label ID="li" runat="server" ForeColor="Red" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label ID="li_attempt" runat="server" ForeColor="Red" Visible="false" ></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Visible="true"></asp:Label><asp:Label ID="lbl_dc_id" runat="server" Visible="false"></asp:Label><asp:Label ID="ContactNo" runat="server" Visible="false"></asp:Label>
                            </div>
            </div>
            </div>

                        </asp:View>
               </asp:MultiView>
        
         </div>

          </div>       
   <%--             </ContentTemplate>
          <Triggers>
           
        </Triggers>
         </asp:UpdatePanel>--%>
    
    </form>
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
</body>
</html>
