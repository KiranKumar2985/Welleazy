<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Welleazy.DashBoard.DashBoard" %>

<!DOCTYPE html>

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
    font-size: 27px;
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
    font-size: 72px;
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

<html lang="en">
<head>
    <title>Bootstrap 4 Responsive Dashboard Card Design</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
</head>

    

<body>
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-sm-6">
                <div class="card-box bg-blue">
                    <div class="inner">
                        <h3> <asp:Label ID="lblCorporateCount" runat="server"></asp:Label> </h3>
                        <p> Corporate Count </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-graduation-cap" aria-hidden="true"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6">
                <div class="card-box bg-green">
                    <div class="inner">
                        <h3> <asp:Label ID="lblOpenCaseCount" runat="server"></asp:Label> </h3>
                        <p> Total Open Cases </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-money" aria-hidden="true"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="card-box bg-orange">
                    <div class="inner">
                        <h3> <asp:Label ID="lblAppointmentScheduledCount" runat="server"></asp:Label> </h3>
                        <p> Appointment Confirmed </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-user-plus" aria-hidden="true"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6">
                <div class="card-box bg-red">
                    <div class="inner">
                        <h3> <asp:Label ID="lblClosedCaseCount" runat="server"></asp:Label> </h3>
                        <p> Total Closed Cases </p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-users"></i>
                    </div>
                    <a href="#" class="card-box-footer">View More <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
        </div>
    </div>


    <%--<div class="container">
            <div class="row" >
                <div class="col-lg-3 col-sm-6">
                     <label>
                         Corporate Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateName" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" DataTextField="CorporateName" DataValueField="CorporateId" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Corporate Name" Value="0" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ErrorMessage="Please Select  Corporate Name" ForeColor="Red" InitialValue="Select Corporate Name" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                         <label>
                         Branch Id <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCorporateBranchId" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Branch Id" Value="0" />
                                     <telerik:RadComboBoxItem Text="CB" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="cmbCorporateBranchId" ErrorMessage="Please Select Branch Id" ForeColor="Red" InitialValue="Select Branch Id" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Services Offered <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbServicesOffered" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Services" Value="0" />
                                     <telerik:RadComboBoxItem Text="Test Service" Value="1" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvrcbServicesOffered" runat="server" ControlToValidate="cmbServicesOffered" ErrorMessage="Please Select Services" ForeColor="Red" InitialValue="Select Services" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                </div>
            <h4>Employee Details </h4>
                     <hr />
            <div class="row">
                     
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Mobile Number <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" Enabled="true" ErrorMessage="Please Enter Mobile No" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Employee Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine" ValidationGroup="Case"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Enabled="true" ErrorMessage="Please Enter Employee Name" ForeColor="Red" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Gender <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbGender" runat="server" AppendDataBoundItems="true" Enabled="false" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Gender" Value="0" />
                                     <telerik:RadComboBoxItem Text="Male" Value="1" />
                                     <telerik:RadComboBoxItem Text="Female" Value="2" />
                                     <telerik:RadComboBoxItem Text="TransGender" Value="3" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="cmbGender" Enabled="true" ErrorMessage="Please Select Gender" ForeColor="Red" InitialValue="Select Gender" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Employee Email Id<span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtEmployeeEmailId" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvEmployeeEmailId" runat="server" ControlToValidate="txtEmployeeEmailId" Enabled="true" ErrorMessage="Please Enter Email Id" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                         
                     </div>
                 </div>
            
           <div class="row">
               <div class="col-lg-3 col-sm-6">
                         <label>
                         No. Of Free Consultations <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfFreeConsultations" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         No Of Consultations Recored <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <asp:TextBox ID="txtNoOfConsultationRecorded" runat="server" class="form-control required" Enabled="false" TextMode="SingleLine"></asp:TextBox>
                         </div>
                     </div>
           </div>
            <br />

              <h4>Case Details </h4>
                     <hr />
            <div class="row">
                <div class="col-lg-3 col-sm-6">
                         <label>
                         Consultation Type <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbConsultationType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Consultation Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Tele" Value="1" />
                                     <telerik:RadComboBoxItem Text="Video" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvConsultationType" runat="server" ControlToValidate="cmbConsultationType" Enabled="true" ErrorMessage="Please Select Consultation Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Case Type <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Case Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Main" Value="1" />
                                     <telerik:RadComboBoxItem Text="Additional" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="cmbCaseType" Enabled="true" ErrorMessage="Please Select Case Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Payment Type <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbPaymentType" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Payment Type" Value="0" />
                                     <telerik:RadComboBoxItem Text="Corporate Paid" Value="1" />
                                     <telerik:RadComboBoxItem Text="Customer Paid" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvPaymentType" runat="server" ControlToValidate="cmbPaymentType" Enabled="true" ErrorMessage="Please Select Payment Type" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Case For <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCaseFor" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Case For" Value="0" />
                                     <telerik:RadComboBoxItem Text="Self" Value="1" />
                                     <telerik:RadComboBoxItem Text="Dependent" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="cmbCaseFor" Enabled="true" ErrorMessage="Please Select Case For" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                             
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Customer Profile <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbCustomerProfile" runat="server" Enabled="false" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Customer Profile" Value="0" />
                                     <telerik:RadComboBoxItem Text="Normal" Value="1" />
                                     <telerik:RadComboBoxItem Text="HNI" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvCustomerProfile" runat="server" ControlToValidate="cmbCustomerProfile" Enabled="true" ErrorMessage="Please Select Customer Profile" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>

            </div>
           
            <h4>Doctor Details </h4>
                     <hr />
            <div class="row">
                <div class="col-lg-3 col-sm-6">
                         <label>
                         Preffered Language <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbLanguage" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Language" Value="0" />
                                     <telerik:RadComboBoxItem Text="English" Value="1" />
                                     <telerik:RadComboBoxItem Text="Hindi" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="cmbLanguage" Enabled="true" ErrorMessage="Please Select Language" ForeColor="Red" InitialValue="Select Language" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Appointment Date and Time <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadDateTimePicker ID="dtpAppointmentDateTime" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                             </telerik:RadDateTimePicker>
                             <asp:RequiredFieldValidator ID="rfvAppointmentDate" runat="server" ControlToValidate="dtpAppointmentDateTime" Enabled="true" ErrorMessage="Please Select Date" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Doctor Name <span class="mandatory">*</span></label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbDoctorName" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Doctor" Value="0" />
                                     <telerik:RadComboBoxItem Text="Test" Value="1" />
                                     <telerik:RadComboBoxItem Text="Test2" Value="2" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvDoctorName" runat="server" ControlToValidate="cmbDoctorName" Enabled="true" ErrorMessage="Please Select Doctor Name" ForeColor="Red" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
        
                     <div class="col-lg-3 col-sm-6">
                         <label>
                         Appointment Status <span class="mandatory">*</span>
                         </label>
                         <div class="selector">
                             <telerik:RadComboBox ID="cmbAppointmentStatus" runat="server" AppendDataBoundItems="true" CssClass="Combo" Filter="Contains" RenderMode="Lightweight" ValidationGroup="Case">
                                 <Items>
                                     <telerik:RadComboBoxItem Text="Select Appointment Status" Value="0" />
                                     <telerik:RadComboBoxItem Text="Scheduled" Value="1" />
                                     <telerik:RadComboBoxItem Text="Completed" Value="2" />
                                     <telerik:RadComboBoxItem Text="ReScheduled" Value="3" />
                                     <telerik:RadComboBoxItem Text="Cancelled" Value="4" />
                                 </Items>
                             </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="rfvAppointmentStatus" runat="server" ControlToValidate="cmbAppointmentStatus" Enabled="true" ErrorMessage="Please Select Status" ForeColor="Red" InitialValue="Select Appointment Status" ValidationGroup="Test"></asp:RequiredFieldValidator>
                         </div>
                     </div>
            </div>
            <div class="row">
                
                         <asp:Button ID="btnSave" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnSave_Click" Text="Save" ValidationGroup="Test" />
                     &nbsp;&nbsp;
&nbsp;                         <asp:Button ID="btnCancel" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnCancel_Click" Text="Cancel" Visible="true" />
                     

            </div>
            </div>--%>
</body>
</html>
