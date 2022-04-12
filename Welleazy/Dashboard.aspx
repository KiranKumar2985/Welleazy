<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Welleazy.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />

    <%--<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />--%>

    <style>
.card-box {
    position: relative;
    color: #fff;
    padding: 20px 10px 40px;
    margin: 20px 0px;
   
}
.card-box:hover {
    text-decoration: none;
    color: #f1f1f1;
}
.card-box:hover .icon i {
    font-size: 100px;
    transition: 1s;
    -webkit-transition: 1s;
}
.card-box .inner {
    padding: 5px 10px 0 10px;
}
.card-box h3 {
    font-size: 22px;
    font-weight: bold;
    margin: 0 0 8px 0;
    white-space: nowrap;
    padding: 0;
    text-align: left;

}
.card-box p {
    font-size: 15px;
}
.card-box .icon {
    position: absolute;
    top: auto;
    bottom: 5px;
    right: 5px;
    z-index: 0;
    font-size: 60px;
    color: rgba(0, 0, 0, 0.15);
}
.card-box .card-box-footer {
    position: absolute;
    left: 0px;
    bottom: 0px;
    text-align: center;
    padding: 3px 0;
    color: rgba(255, 255, 255, 0.8);
    background: rgba(0, 0, 0, 0.1);
    width: 100%;
    text-decoration: none;
}
.card-box:hover .card-box-footer {
    background: rgba(0, 0, 0, 0.3);
}
.bg-blue {
    background-color: #00c0ef !important;
}
.bg-green {
    background-color: #00a65a !important;
}
.bg-orange {
    background-color: #f39c12 !important;
}
.bg-red {
    background-color: #d9534f !important;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <div><h4 style="float:left;">Dashboard</h4>
             <span style="float:right;">
           <i class="glyphicon glyphicon-home"></i> Home >> Dashboard </span>
         </div>            
           
           
           <div class="line"></div>   
        <span>
            <asp:Label ID="LabelDateTime" runat="server" ></asp:Label><br />
             <asp:Label ID="LabelDateTime1" runat="server" ></asp:Label><br />
             <asp:Label ID="LabelDateTime2" runat="server" ></asp:Label><br />
             <asp:Label ID="LabelDateTime3" runat="server" ></asp:Label>
        </span>
        <div class="Form-group">
            <div class="col-md-2">
                <div class="card-box bg-blue">
                    <div class="inner">
                        <h3> <asp:Label ID="lblCorporateCount" runat="server"></asp:Label> </h3>
                        <p style="color:white;"> Walkin Registration </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-graduation-cap" aria-hidden="true"></i>
                    </div>
                    <a href="WalkinRegistrationForm.aspx" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card-box bg-green">
                    <div class="inner">
                        <h3> <asp:Label ID="lblOpenCaseCount" runat="server"></asp:Label> </h3>
                        <p style="color:white;"> Total Open Cases </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-money" aria-hidden="true"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card-box bg-orange">
                    <div class="inner">
                        <h3> <asp:Label ID="lblAppointmentScheduledCount" runat="server"></asp:Label> </h3>
                        <p style="color:white;"> Appointment Confirmed </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-user-plus" aria-hidden="true"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card-box bg-red">
                    <div class="inner">
                        <h3> <asp:Label ID="lblClosedCaseCount" runat="server"></asp:Label> </h3>
                        <p style="color:white;"> Total Closed Cases </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-users"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card-box bg-red">
                    <div class="inner">
                        <h3> <asp:Label ID="Label1" runat="server"></asp:Label> </h3>
                        <p style="color:white;"> Total Closed Cases </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-users"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
        </div>
  
        </div>
      
</asp:Content>
