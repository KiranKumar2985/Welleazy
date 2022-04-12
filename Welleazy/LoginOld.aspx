<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginOld.aspx.cs" Inherits="Welleazy.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
   
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/main.css" rel="stylesheet">

  <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900;1,100;1,300;1,400;1,700&display=swap" rel="stylesheet">
<link href="images/welleazy-logo.png" rel="icon" />
    <title>Welleazy</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

   	<style>
		.input-icons i {
			position: absolute;
		}
		
		.input-icons {
			width: 100%;
			margin-bottom: 10px;
		}
		
		.icon {
			padding: 10px;
			min-width: 40px;
            float:left;
		}
		
		.input-field {
			width: 100%;
			padding: 10px;
		}

.center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
        form-group{
            width:100%; /* The width is 100%, by default */
        }
        .col-md-3{
            
            width:33%; /* The width is 20%, by default */
        }
        @media screen and (max-width:500px) {
            .col-md-3 {
                width: 100%; /* The width is 100%, when the viewport is 800px or smaller */
            }
        }
        .col-md-2{
            float:left;
            width:20%; /* The width is 20%, by default */
        }
        @media screen and (max-width:800px) {
            .col-md-2 {
                width: 100%; /* The width is 100%, when the viewport is 800px or smaller */
            }
        }
        .col-md-1{
            float:left;
            width:10%; /* The width is 10%, by default */
        }
        @media screen and (max-width:400px) {
            .col-md-1 {
                width: 50%; /* The width is 100%, when the viewport is 800px or smaller */
            }
        }
        .btn{
            width:100px;
            padding:10px;
            border-radius:5px;
        }
</style>
          <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js">  
</script>  
<script type="text/javascript">
    $(function () {
        $('#btnLogin').click(function () {
            if ($('#checkterm').is(':checked')) {
                //alert('You are Agreed to  Welleazy’s Terms of Service and Privacy Policy')
                //alert('Please Check Terms of Service and Privacy Policy')
            }
            else {
                alert('Please Agree to Terms of Service and Privacy Policy')
                return;
            }
        })
    })
</script> 
 </head>
<body>
 
    <img src="images/main-image.png" style="position:fixed; margin-left:0px; width:100%;" />
	  <nav class="navbar navbar-expand-lg bg-white mb-3">
          <div class="container">
    <a class="navbar-brand" href="#"><img src="/images/image-logo-welnext.png" alt=""></a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample07" aria-controls="navbarsExample07" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarsExample07">
      <ul class="navbar-nav mr-auto"> </ul>
      <form class="form-inline my-2 my-md-0">
		  <a class="nav-link dropdown-toggle" href="#"><img src="/images/user-icon.png" height="30" alt=""></a>
      </form>
    </div>
  </div>
      </nav>
        <main role="main" class="container" style="background:white; height:550px;" >
		
		
		

<form runat="server" id="form1" class="form-signin float-left">
    
      <h4 class="Sign_inheading" style="color:#125bf2; position:relative;">Sign in to Welleazy</h4>
    <div style="border-radius:15px; font-size:small; position:relative; background:white; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); padding:15px;">

        <div class="bck-arr text-center">
	  <span class="back-arrow-btn" style="float:left;">
          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/back-arrow.png" CausesValidation="false" PostBackUrl="~/SignUp.aspx" ToolTip="Go to SignUp Page" ></asp:ImageButton>
	  </span>
	  <img class="mb-4" src="/images/login-img.png" alt="" width="100" height="83"></div>
  	<h6 class="Sign_inheading" style="color:#125bf2; position:relative;"><asp:Label ID="lblLoginType" runat="server"></asp:Label></h6>
	<div class="row" >
        
	<div class="mb-3 col-6 Create_an_account">Sign in to your account<br><strong>or</strong><a href="#"><asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/SignUp.aspx"> Create an account</asp:LinkButton></a></div>
	<div runat="server" id="AreCorporate" visible="true" class="mb-3 col-6 Create_an_account text-right">Are you a corporate user?<br><asp:LinkButton ID="linkCorporateLogin" runat="server" OnClick="linkCorporateLogin_Click">Click Here</asp:LinkButton></div>
	</div>
        <div class="form-group">
            <div class="col-md-12">
                <label for="inputEmail" class="sr-only">Email address</label>
  <%--<input type="email" id="inputEmail" class="form-control logIntsty" placeholder="Email Address/Phone number" required autofocus>--%>

    <asp:RequiredFieldValidator ID="RequiredField_Email" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Login" ToolTip="Please Enter Email Id" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="text" placeholder="Email Address/Phone number" maxlength="50" minlength="6" Visible="true" ValidationGroup="Login" ></asp:TextBox>
                <br />
            </div>
            <div class="col-md-12">
                  <label for="inputPassword" class="sr-only">Password</label>
  <%--<input type="password" id="inputPassword" class="form-control logIntsty" placeholder="Password" required>--%>
    <asp:RequiredFieldValidator ID="RequiredField_Password" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Login" ToolTip="Please Enter Password/OTP" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" type="password" placeholder="Password/OTP" maxlength="50" minlength="6" Visible="true" ValidationGroup="Login"></asp:TextBox>
                
            </div>
        </div>
  <br />


	<div class="row">
	<div class="mb-2 col-6"><a href="#" class="clrgray"><asp:LinkButton ID="LinkGenerateOTP" runat="server" CausesValidation="false" OnClick="LinkGenerateOTP_Click"> Generate OTP</asp:LinkButton></a></div>
	<div class="mb-2 col-6 text-right"><a href="#" class="clrgray"><asp:LinkButton ID="LinkDontPassword" runat="server" CausesValidation="false" OnClick="LinkDontPassword_Click">Don’t Have Password?</asp:LinkButton></a>  </div>
	</div>
<%--<div class="checkbox mb-3">  
<div class="custom-control form-control-lg custom-checkbox">
<input type="checkbox" class="custom-control-input" id="customCheck1" checked="checked">
    
<label class="custom-control-label clrgray" for="customCheck1" style="font-size:small;">I agree to Welleazy’s Terms of Service and Privacy Policy</label>
</div>
	  
  </div>--%>
        <div class="form-group">
        <asp:CheckBox ID="checkterm" runat="server" />
        I agree to Welleazy’s <asp:LinkButton id="hyplnkTerms" runat="server" class="clrgray" style="font-size:small;" OnClientClick="window.open('TermsofService.aspx','New Page')"> Terms of Service</asp:LinkButton> and <asp:LinkButton id="hyplnkPolicy" runat="server" class="clrgray" style="font-size:small;" OnClientClick="window.open('PrivacyPolicy.aspx','New Page')"> Privacy Policy</asp:LinkButton>
            <br /></div>
        <div class="form-group" style="width:100%;" align="center">
        <asp:Button ID="btnLogin" Width="330" BackColor="#ff9900" ForeColor="white" BorderStyle="None" runat="server" Text="Sign in" type="submit" value="Sign in" CssClass="Login_btn btn" OnClick="btnLogin_Click" Visible="true" ValidationGroup="Login"/><br />
            <asp:Label ID="ChangeMsg" runat="server" ForeColor="Green" Visible="true" ></asp:Label>     
            <asp:Label ID="lblOTP" runat="server" ForeColor="Green" Visible="false" ></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Green" Visible="false" ></asp:Label>
            <span runat="server" id="Attempt" style="color:red;" visible="false">Remaining attempt: <asp:Label ID="lblRemaining" runat="server"></asp:Label></span><br />
            <asp:Label ID="lblLocked" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="li_attempt" runat="server" ForeColor="Red" Visible="false" ></asp:Label>
	</div>
  </div>
</form>
           
	  </main> 
 
  </body>
    
</html>
