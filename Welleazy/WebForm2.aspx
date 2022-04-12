<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication6.WebForm2" %>



<!DOCTYPE html>
<style>
   
   
    .button {  
     font-size: 11px;  
     font-weight: bold;  
     font-family: Arial;  
     color: #ffffff;  
     background-color:Orange;
     min-width: 54px;  
height: 24px;  
white-space: nowrap;  
cursor: pointer;  
outline: 0 none;  
padding: 0 20px 20px;  
text-align: center; 
}  
  

    * {
  box-sizing: border-box;
}

.row {
  margin-left:-5px;
  margin-right:-5px;
}
  
.column {
  float: left;
  width: 50%;
  padding: 5px;
}

/* Clearfix (clear floats) */
.row::after {
  content: "";
  clear: both;
  display: table;
}

table {
  border-collapse: collapse;
  border-spacing: 0;
  width: 100%;
  border: 1px solid #ddd;
}

th, td {
  text-align: left;
  padding: 16px;
}

tr:nth-child(even) {
  background-color: #f2f2f2;
}

/* Responsive layout - makes the two columns stack on top of each other instead of next to each other on screens that are smaller than 600 px */
@media screen and (max-width: 600px) {
  .column {
    width: 100%;
  }
}
    
   
</style>
 <!-- jQuery -->
  <script type="text/javascript" src="../MDB/js/jquery.min.js"></script>
  <!-- Bootstrap tooltips -->
  <script type="text/javascript" src="../MDB/js/popper.min.js"></script>
  <!-- Bootstrap core JavaScript -->
  <script type="text/javascript" src="../MDB/js/bootstrap.min.js"></script>
  <!-- MDB core JavaScript -->
  <script type="text/javascript" src="../MDB/js/mdb.min.js"></script>
  <!-- Your custom scripts (optional) -->

<script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html(title);
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
        return false;
    }
</script>



<html xmlns="http://www.w3.org/1999/xhtml">

    
<head runat="server">
    <title></title>

    

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.11.2/css/all.css"/>
  <!-- Google Fonts Roboto -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"/>
  <!-- Bootstrap core CSS -->
  <link rel="stylesheet" href="../MDB/css/bootstrap.min.css"/>
  <!-- Material Design Bootstrap -->
  <link rel="stylesheet" href="../MDB/css/mdb.min.css"/>
  <!-- Your custom styles (optional) -->
  <link rel="stylesheet" href="../MDB/css/style.css"/>
</head>
 
<body>
     <form id="form1" runat="server">
     <table>
     
      <tr>
        <td>name: TESTING</td>
        <td> <center> <h1>Test</h1></center></td>
        <td>TIMER: 
        </td>
          <td>
              <asp:Label ID="lblTimer" runat="server" Text="00:00:00"></asp:Label>
          </td>
          <td>
              </td>
      </tr>     
    </table>
    <br />
    <br />

         
   
       <%-- <table style="width:100%">
            <tr>
                
                <td>--%>

      
<div class="container">
  <div class="row">
    <div class="col-sm-9">
        <div class="column">
        <table style="width:100%;align-items:center" >
            
            
               <tr>
                                <td>
                                    <asp:TextBox ID="txt" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                                   
                                  

                                    <asp:Button id="btnGenerateOTP" runat="server" Text="OTP" OnClick="btnGenerateOTP_Click"/>
                                </td>
                            </tr>
        </table>
      </div>
      <div class="row">
        <div class="col-8 col-sm-6">
           
            <div class="column">
            <table>
              
            </table>
                </div>
        </div>
          
        
      </div>
    </div>
  </div>
</div>
               <%-- </td>
            </tr>
        
        </table>--%>
       <%-- <table>
           <tr>
               
                <td >
                    <div  class="table-responsive">
                    <table >
                        <tr>
                            <td style="background-color:#42a5f5;text-align:center" >
                                <asp:Label ID="lblHeading" runat="server"  Font-Size="XX-Large" Font-Bold="true" ForeColor="#ff9900" Text="OnLine Question List"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <table>
                        
                        <tr>
                            <td>
                                <%--<asp:Label ID="lblQuestionNo" runat="server" Text="Question 1. The process by which green plants are grown in soil?" Font-Size="Medium"  ></asp:Label>
                            </td>
                        </tr>
                    </table>
                        </div>
                    <div>
                        <table>
                            <tr>
                                <td>
                                   <%-- <asp:RadioButtonList ID="rblAnswer" runat="server">
                                        <asp:ListItem Text="Option One" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Option Two" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Option Three" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Option Four" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <br />
                                    <%--<dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" Border-BorderStyle="None"  ValueField="StateId" RepeatDirection="Vertical" TextField="StateName">
                                        
                                    </dx:ASPxRadioButtonList>
                                </td>
                               


                            </tr>
                             <br />
                                <br />
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" Text="Save" runat="server" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" />
                                    <asp:Button ID="btnPrevious" Text="Previous" runat="server" />
                                    <asp:Button ID="btnReview" Text="Review" runat="server" OnClick="btnReview_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
               </td>
               <td style="width:450px"> 
                   <div>
            <table class="table-responsive">

                <tr>
                    
                    <td>
                         <asp:Panel ID="Panel2" runat="server">
</asp:Panel>
                        
                        
                    </td>
                    
                    
                </tr>
                </table>
            

</div>
               </td>
              
           </tr>
           
              
           
       </table>--%>
        
        
        

        <div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <%--<button type="button" class="close" data-dismiss="modal">
                    &times;</button>--%>
                <h4 class="modal-title">
                </h4>
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
         <input type="hidden" id="timeAllocated" name="timeAllocated" value="30" runat="server">
         <asp:HiddenField ID="timer" runat="server" Value="" />
    </form>
    <script>

    
        // Set the date we're counting down to
    var countDownDateValue = (document.getElementById('timer').value);

    
    //var countDownDateValue = $('timer').val();

    //alert(countDownDateValue);
        //var countDownDate = new Date("2021-04-19 14:18:00").getTime();
        var countDownDate = new Date(countDownDateValue).getTime();
        var click = 0;

        // Update the count down every 1 second
        var x = setInterval(function () {

            // Get today's date and time
            var now = new Date().getTime();

            // Find the distance between now and the count down date
            var distance = countDownDate - now;

            // Time calculations for days, hours, minutes and seconds
            //var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            // Output the result in an element with id="demo"
            var displayhours = "";
            var displayminites = "";
            var displayseconds = "";

            if (hours > 10) {
                displayhours = hours;
            }
            else {
                displayhours = "0" + hours;
            }

            if (minutes > 10) {
                displayminites = minutes;
            }
            else {
                displayminites = "0" + minutes;
            }

            if (seconds > 10) {
                displayseconds = seconds;
            }
            else {
                displayseconds = "0" + seconds;
            }

           

            document.getElementById("lblTimer").innerHTML = displayhours + ":" + displayminites + ":" + displayseconds;

            // If the count down is over, write some text 

            if (distance < 0) {
                clearInterval(x);
                //click = 1;
                //if (click == 1) {

                //}
                //else {
                    document.getElementById("btnSave").click();
                //}



            }
        }, 1000);
    
</script>
</body>
</html>

