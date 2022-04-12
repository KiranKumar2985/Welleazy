<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterLogin.aspx.cs" Inherits="Welleazy.MasterLogin" %>

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
      <style type="text/css">
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
.Combo_Size{
width:300px !important;
}
</style>
       <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js">  
</script>  
<script type="text/javascript">
    $(function () {
        $('#btnLogin').click(function () {
            if ($('#customCheck1').is(':checked')) {
                alert('You are Agreed to  Welleazy’s Terms of Service and Privacy Policy')
            }
            else {
                alert('Please Check Terms of Service and Privacy Policy')
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
      <h4 class="Sign_inheading" style="color:#125bf2; position:relative; text-align:center;">Sign in</h4>
    <div style="border-radius:15px; font-size:small; position:relative; background:white; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); padding:15px;">

        <div class="bck-arr text-center">
	  
	  <img class="mb-4" src="/images/login-img.png" alt="" width="100" height="83"></div>
  	
	<div class="row">
	<div class="mb-3 col-6 Create_an_account">Sign in to your account <strong>or</strong><a href="#"><asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/SignUp.aspx"> Create an account</asp:LinkButton></a></div>
	
	</div>
        <div class="form-group col-md-12">
                        <label>Select Your Account Type  </label>
                        <div class="selector">
                
               <telerik:RadComboBox ID="DDL_LoginType" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo_Size" AutoPostBack="true" OnSelectedIndexChanged="DDL_LoginType_SelectedIndexChanged">
                    <Items>
                            <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Partners" Text="Partners" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Corporates" Text="Corporates" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Coporate Employees" Text="Coporate Employees" />
                    </Items>
                    <Items>
                            <telerik:RadComboBoxItem Value="Customers" Text="Customers" />
                    </Items>
                </telerik:RadComboBox>
                    </div>
            </div>
            <div class="form-group">
                
                <asp:Panel ID="Partners_panel" runat="server" Visible="false">
                    <div class="col-md-10" style="padding:10px;">
                        
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="text" placeholder="Email Address" maxlength="50" minlength="6" Visible="true" ></asp:TextBox><br />
            
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" type="password" placeholder="Password" maxlength="50" minlength="6" Visible="true" ></asp:TextBox>
            </div>
                </asp:Panel>
                <asp:Panel ID="Corporates_panel" runat="server" Visible="false">
                    <div class="col-md-10" style="padding:10px;">
                        
                    <asp:TextBox ID="CP_txtemail" runat="server" class="form-control" type="text" placeholder="Email Address" maxlength="50" minlength="6" Visible="true" ></asp:TextBox><br />
            
                    <asp:TextBox ID="CP_txtpassword" runat="server" class="form-control" type="password" placeholder="Password" maxlength="50" minlength="6" Visible="true" ></asp:TextBox>
            </div>
                </asp:Panel>
                <asp:Panel ID="InternalEmp_panel" runat="server" Visible="false">
                    <div class="col-md-10" style="padding:10px;">
                        
                    <asp:TextBox ID="IP_txtemail" runat="server" class="form-control" type="text" placeholder="Enter Email/Mobile No" maxlength="50" minlength="6" Visible="true" ></asp:TextBox><br />
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                            <asp:ListItem runat="server" onclick="MutExChkList1(this);" style="background:#113d7a; color:White; padding:6px; font-size:14px;">OTP</asp:ListItem>
                            <asp:ListItem runat="server" onclick="MutExChkList1(this);" style="background:#113d7a; color:White; padding:6px; font-size:14px;">Password</asp:ListItem>
                    </asp:CheckBoxList>
                 <script type="text/javascript">
                     function MutExChkList1(chk) {
                         var chkList = chk.parentNode.parentNode.parentNode;
                         var chks = chkList.getElementsByTagName("input");
                         for (var i = 0; i < chks.length; i++) {
                             if (chks[i] != chk && chk.checked) {
                                 chks[i].checked = false;
                             }
                         }
                     }
                    </script>
                            <asp:TextBox ID="IP_txtOTP" runat="server" class="form-control" type="password" placeholder="Enter the OTP within 30 secs" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
                            <br />
                            <asp:Label ID="lblOTPMatch1" runat="server" ></asp:Label>
                    <asp:TextBox ID="IP_txtpassword" runat="server" class="form-control" type="password" placeholder="Enter the Password" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
            </div>
                </asp:Panel>
                <asp:Panel ID="Customers_panel" runat="server" Visible="false">
                    <div class="col-md-12" style="padding:10px;">
                        <div class="col-md-10">
                            <asp:TextBox ID="CT_txtemail" runat="server" class="form-control" type="text" placeholder="Enter Email/Mobile No" maxlength="50" minlength="6" Visible="true" ></asp:TextBox><br />
                        </div>
                        <div class="col-md-10">
                             <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                            <asp:ListItem runat="server" onclick="MutExChkList(this);" style="background:#113d7a; color:White; padding:6px; font-size:14px;">OTP</asp:ListItem>
                            <asp:ListItem runat="server" onclick="MutExChkList(this);" style="background:#113d7a; color:White; padding:6px; font-size:14px;">Password</asp:ListItem>
        </asp:CheckBoxList>
                 <script type="text/javascript">
                     function MutExChkList(chk) {
                         var chkList = chk.parentNode.parentNode.parentNode;
                         var chks = chkList.getElementsByTagName("input");
                         for (var i = 0; i < chks.length; i++) {
                             if (chks[i] != chk && chk.checked) {
                                 chks[i].checked = false;
                             }
                         }
                     }
                        </script>
                            <asp:TextBox ID="CT_txtOTP" runat="server" class="form-control" type="password" placeholder="Enter the OTP within 30 secs" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
                            <br />
                            <asp:Label ID="lblOTPMatch" runat="server" ></asp:Label>
                            <asp:TextBox ID="CT_txtpassword" runat="server" class="form-control" type="password" placeholder="Enter the Password" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
                            <asp:TextBox ID="CT_txtfname" runat="server" class="form-control" TextMode="SingleLine" placeholder="First/Middle Name" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
                            <asp:TextBox ID="CT_txtlname" runat="server" class="form-control" TextMode="SingleLine" placeholder="Last Name" maxlength="50" minlength="6" Visible="false" ></asp:TextBox>
                        </div>
                    
                    
                    
            </div>
                </asp:Panel>
            </div>


	<div class="row" runat="server" visible="false">
	<div class="mb-2 col-6"><a href="#" class="clrgray"><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="LinkButton1_Click"> Generate OTP</asp:LinkButton></a></div>
	<div class="mb-2 col-6 text-right"><a href="#" class="clrgray">Don’t Have Password?</a>  </div>
	</div>
<div class="checkbox mb-3">  
<div class="custom-control form-control-lg custom-checkbox">
<input runat="server" type="checkbox" class="custom-control-input" id="customCheck1" checked="checked">
<label class="custom-control-label clrgray" for="customCheck1" style="font-size:small;">I agree to Welleazy’s Terms of Service and Privacy Policy</label>
</div>
	  
  </div>
        <div class="form-group" style="width:100%;" align="center">
        <asp:Button ID="btnLogin" Width="300" BackColor="#ff9900" ForeColor="white" BorderStyle="None" runat="server" Text="Sign in" type="submit" value="Sign in" CssClass="Login_btn btn" Visible="true" OnClick="btnLogin_Click" /><br />
            <asp:Label ID="ChangeMsg" runat="server" ForeColor="Green" Visible="true" ></asp:Label>  <br />
            <asp:LinkButton ID="LinkButton2" runat="server" class="clrgray" CausesValidation="false" OnClick="LinkButton2_Click" Visible="false">Generate a Link to Activate Your Account</asp:LinkButton>   
            <asp:Label ID="lblOTP" runat="server" ForeColor="Green" Visible="true" ></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Green" ></asp:Label>
	</div>
  </div>
</ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="DDL_LoginType"  />
             <asp:PostBackTrigger ControlID="btnLogin" />
             <asp:PostBackTrigger ControlID="LinkButton1"  />
             <asp:PostBackTrigger ControlID="LinkButton2" />
         </Triggers>
        </asp:UpdatePanel>
</form>
           
	  </main> 
  
  </body>
</html>
