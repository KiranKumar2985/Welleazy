<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Welleazy.SignUp" %>

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
      <link href="css/bootstrap.min.css" rel="stylesheet" />
      <link href="css/mdb.min.css" rel="stylesheet" />
      <link href="css/style.css" rel="stylesheet" />
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
        col-md-10{
            width:100%; /* The width is 100%, by default */
        }
        .col-md-6{
            
            width:49%; /* The width is 20%, by default */
        }
        @media screen and (max-width:500px) {
            .col-md-6 {
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
        ToolTip {
            background:red;
            color:white;
            font-weight:500;
            padding:5px;

        }
</style>
       <script type="text/javascript">
           function ShowPopup(title, body) {
               $("#MyPopup .modal-title").html(title);
               $("#MyPopup .modal-body").html(body);
               $("#MyPopup").modal("show");
           }
</script>
      <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js">  
</script>  
<script type="text/javascript">
    $(function () {
        $('#btnSubmit').click(function () {
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
		
		<h4 class="Sign_inheading" style="color:#125bf2; position:relative;">Sign Up to Welleazy</h4>
		
<form runat="server" id="form1" class="form-signin float-left" style="position:relative;">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="update1">
        <ContentTemplate>
    <div class="col-md-10" style="border-radius:15px; font-size:small; position:relative; right:0; background:white; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); padding:10px;">
  <div class="bck-arr text-center">
	  <span class="back-arrow-btn" style="float:left;">
      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/back-arrow.png" PostBackUrl="~/Login.aspx" ToolTip="Go to Login Page" ></asp:ImageButton></span>
	  <img src="/images/login-img.png" alt="" height="83">

  </div>
  	
        
        
        <div class="from-group">
                <label>Email</label> <asp:RequiredFieldValidator ID="RequiredField_email" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="User" ToolTip="Please Enter Email Id" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                        <div class="selector">
                             <asp:TextBox ID="txt_email" runat="server" TextMode="SingleLine" ToolTip="Please Enter Email Id" class="form-control"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpression_email" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="User" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_email"></asp:RegularExpressionValidator>
                         </div>
           
            </div>
        <div class="form-group row">
            <div class="col-md-6">
                <label>First & Middle Name</label> <asp:RequiredFieldValidator ID="RequiredField_fname" runat="server" ErrorMessage="*" ToolTip="Please Enter First Name" ForeColor="Red" ValidationGroup="User"  ControlToValidate="txt_fname"></asp:RequiredFieldValidator>
                        <div class="selector">
                             <asp:TextBox ID="txt_fname" runat="server" TextMode="SingleLine" class="form-control"></asp:TextBox>
                            
                         </div>
                </div>
            <div class="col-md-6">
                <label>Last Name</label><asp:RequiredFieldValidator ID="RequiredField_lname" runat="server" ErrorMessage="*" ToolTip="Please Enter Last Name" ForeColor="Red" ValidationGroup="User"  ControlToValidate="txt_lname"></asp:RequiredFieldValidator>
                        <div class="selector" style="position:relative;">
                             <asp:TextBox ID="txt_lname" runat="server" TextMode="SingleLine" class="form-control"></asp:TextBox>
                         </div>
                
                </div>
            </div>  
            <div class="from-group">
                <label>Mobile No</label> <asp:RequiredFieldValidator ID="RequiredField_mobileno" runat="server" ErrorMessage="*" ToolTip="Please Enter Mobile No" ForeColor="Red" ValidationGroup="User"  ControlToValidate="txt_mobileno"></asp:RequiredFieldValidator>
                        <div class="selector">
                             <asp:TextBox ID="txt_mobileno" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Invalid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_mobileno" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                          </div>
           
            </div> 
            <div class="from-group">
                <label>Password</label> <asp:RequiredFieldValidator ID="RequiredField_password" runat="server" ErrorMessage="*" ToolTip="Please Enter Strong Password" ForeColor="Red" ValidationGroup="User"  ControlToValidate="txt_password"></asp:RequiredFieldValidator>
                        <div class="selector">
                             <asp:TextBox ID="txt_password" runat="server" TextMode="Password" placeholder="****************" class="form-control required"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpression_password" runat="server" ErrorMessage="Enter Strong Password" ForeColor="Red" ValidationGroup="User" ValidationExpression="((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%~^&*]).{6,30})" ControlToValidate="txt_password" ></asp:RegularExpressionValidator>
                         </div>
           
            </div>
            <div class="from-group">
                <label>Confirm Password</label> <asp:RequiredFieldValidator ID="RequiredField_cpassword" runat="server" ErrorMessage="*" ToolTip="Please Enter Confirm Password" ForeColor="Red" ValidationGroup="User"  ControlToValidate="txt_cpassword"></asp:RequiredFieldValidator>
                        <div class="selector">
                             <asp:TextBox ID="txt_cpassword" runat="server" TextMode="Password" placeholder="****************" class="form-control required" ValidationGroup="User" ></asp:TextBox>
                            
                            <asp:CompareValidator ID="Compare_cpassword" runat="server" ErrorMessage="Confirm Password is Not Match" ForeColor="Red" ValidationGroup="User"  ControlToCompare="txt_password" ControlToValidate="txt_cpassword"></asp:CompareValidator>
                         </div>
               
            </div>
      
        <div class="form-group" style="text-align:center;">
            <telerik:RadCheckBox ID="checkterm" runat="server"></telerik:RadCheckBox>
        I agree to Welleazy’s <asp:LinkButton id="hyplnkTerms" runat="server" class="clrgray" style="font-size:small;" OnClientClick="window.open('TermsofService.aspx','New Page')"> Terms of Service and Privacy Policy</asp:LinkButton>
            <br />

        </div>

    <div style="padding-left:20px;">
        <br />
    </div>

        <div class="form-group" align="center">
        <asp:Button ID="btnSubmit" Width="310" BackColor="#ff9900" ForeColor="white" BorderStyle="None" runat="server" Text="Sign Up" type="submit" value="Sign Up" CssClass="Login_btn btn" OnClick="btnSubmit_Click" Visible="true" ValidationGroup="User" />
        <br />    <asp:Label ID="lblMsg" ForeColor ="Red" runat="server" ></asp:Label><asp:Label ID="Label1" runat="server"></asp:Label>
	</div>
  </div>
               </ContentTemplate>
    </asp:UpdatePanel>
</form>
           
	  </main> 
            
     
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
