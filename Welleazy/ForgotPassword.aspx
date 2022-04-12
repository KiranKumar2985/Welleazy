<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Welleazy.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <link href="images/welleazy-logo.png" rel="icon">
    <title>Welleazy | Forgot Password</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
        <!-- Our Custom CSS -->
        <link href="css/style4.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: 10px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Forgot Password :</h4>
                                   <div class="line"></div>
              <div class="form-group">
               <asp:MultiView ID="ForgotView" runat="server">
               
               <asp:View ID="Save" runat="server">

                    <p style="padding:10px; background:#088b37;  color:white; border-radius:2px; font-size:small;">
            <asp:Label ID="VerifyMobileNo" runat="server" ForeColor="White"></asp:Label></p>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
            
            <div class="col-md-4">
                        <label>Enter Email Address  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmailAddress" runat="server" TextMode="SingleLine" MaxLength="50" placeholder="Enter Email Address" class="form-control required"></asp:TextBox>
                            <asp:Label ID="lblEmailAddress" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            
            <div class="col-md-3">
                <label><span class="mandatory"></span></label>
                        <div class="selector">
                <asp:Button ID="btnVerifyEmail" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Verify Email" type="submit" value="Verify Email" CssClass="Login_btn btn" OnClick="btnVerifyEmail_Click" Visible="true"/><br />
                            <asp:Label ID="lblPassword" runat="server" Visible="false"></asp:Label><asp:Label ID="EmailAddress" runat="server" Visible="false"></asp:Label><br />
                            <asp:Label ID="li" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
            </div>

                           </asp:View>
               <%--<asp:View ID="View" runat="server">
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
                <asp:Label ID="Label1" runat="server" Visible="true"></asp:Label><asp:Label ID="ContactNo" runat="server" Visible="false"></asp:Label>
                            </div>
            </div>
            </div>

                        </asp:View>--%>
               </asp:MultiView>
        
         </div>
             </div>
    </form>
</body>
</html>
