<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCase.aspx.cs" Inherits="Welleazy.Case.AddCase" EnableEventValidation="true" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Add Case</title>
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

   <script type ="text/javascript">
        function showTime() {
            var dt = new Date();
            document.getElementById("txt_CaseEntryDate").innerText = dt;
        }
    </script>
    <script type="text/javascript">
        function ShowSearchPopup() {
            //$("#MyPopup .modal-title").html(title);
            //$("#MyPopup .modal-body").html(body);
            $("#SearchPopUp").modal("show");
        }
</script>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"> </script>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />


  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Case/Case.aspx"  ForeColor="#0033cc">Case List</asp:LinkButton> >> Add Case</h5>
                                   <div class="line"></div>
        <div class="form-group" style="padding:10px; margin-top:-30px;">
           <h4>Case Management </h4>
            <hr />
            <div class="col-md-3">
                        <label>Case ID </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_CaseId" runat="server" TextMode="SingleLine" placeholder="Auto Generate" class="form-control required" ReadOnly="true"></asp:TextBox>
                             
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Case Entry Date & Time  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_CaseEntryDate" runat="server" TextMode="DateTime" class="form-control required" ReadOnly="true" ></asp:TextBox>
                             
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Welleazy Branch  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbBranch" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="BranchName" DataValueField="BranchId" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="rcbBranch" ForeColor="Red" ErrorMessage="Please Select Branch Name" ValidationGroup="Case" InitialValue="Select Branch"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Assigned Executive </label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbAssignExecutive" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Executive" />
<%--                                
                                        <telerik:RadComboBoxItem Value="Mr Dixit" Text="Mr Dixit" />

                                    <telerik:RadComboBoxItem Value="Rakesh Kumar" Text="Rakesh Kumar" />--%>
                                </Items>
                            </telerik:RadComboBox>
                            
                         </div><br />
                    </div>
            <div class="col-md-3">
                        <label>Case Rec'd Mode </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseMode" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDeafultValue" Text="Select Case Mode" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Email" Text="Email" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="SMS" Text="SMS" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Call" Text="Call" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Client Online Updations" Text="Client Online Updations" />
                                </Items>

                            </telerik:RadComboBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Case Rec'd Date & Time  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <%-- <asp:TextBox ID="txt_CaseRecDateTime" runat="server" TextMode="DateTime" class="form-control required" ></asp:TextBox>--%>
                            <telerik:RadDateTimePicker ID="dtpCaseRecDateTime" RenderMode="Lightweight" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">

                            </telerik:RadDateTimePicker>
                          
                            <asp:RequiredFieldValidator ID="rfvCaseRecDateTime" runat="server" ControlToValidate="dtpCaseRecDateTime" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            
        </div>
        <div class="form-group" style="padding:10px; margin-top:140px;">
            <h4>Clients Details </h4>
            <hr />
            <div class="col-md-3">
                        <label>Corporate Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_CorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" AutoPostBack="true" OnSelectedIndexChanged="DDL_CorporateName_SelectedIndexChanged" ValidationGroup="Case" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="DDL_CorporateName" ForeColor="Red" ErrorMessage="Please Select Client Name" ValidationGroup="Case" InitialValue="Select Client Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Branch Id  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbBranchId" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case" AutoPostBack="true" OnSelectedIndexChanged="rcbBranchId_SelectedIndexChanged" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Branch Id" />
                                </Items>
                               
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvrcbBranchId" runat="server" ControlToValidate="rcbBranchId" ForeColor="Red" ErrorMessage="Please Select Branch Id" ValidationGroup="Case" InitialValue="Select Branch Id"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
          
            <div class="col-md-3">
                        <label>Product Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case" AutoPostBack="true" OnSelectedIndexChanged="rcbProduct_SelectedIndexChanged" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="rcbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Services Offered  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbServicesOffered" RenderMode="Lightweight" Filter="Contains" CheckBoxes="true" CssClass="Combo" runat="server" AppendDataBoundItems="true" ValidationGroup="Case">
                               
                                 <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Services" />

                                </Items>
                            </telerik:RadComboBox>
                        
                         </div>
                    </div>
        </div>                      
        <div class="form-group" style="padding:10px; margin-top:60px;">
            <h4>Employee Details </h4>
            <hr />
            <div class="col-md-2">
                        <label>Employee Id  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeId" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ControlToValidate="txt_EmployeeId" ForeColor="Red" ErrorMessage="Please Enter Employee Id" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Employee Name  <span class="mandatory">*</span></label>
                <span><asp:ImageButton ID="btnSearchEmployeee" Visible="true" Height="20px" Width="25px" ImageUrl="~/images/Search Image.png" runat="server" AlternateText="Search" OnClick="btnSearchEmployeee_Click" /></span>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeName" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txt_EmployeeName" ForeColor="Red" ErrorMessage="Please Enter Employee Name" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-md-2">
                        <label>Mobile Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeMobileNo" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtEmployeeMobileNo" runat="server" ControlToValidate="txt_EmployeeMobileNo" ForeColor="Red" ErrorMessage="Please Enter Mobile No" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmployeeMNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_EmployeeMobileNo" ValidationGroup="Case" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
            
            <div class="col-md-2">
                        <label>Gender </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbGender" runat="server" RenderMode="Lightweight" CssClass="Combo3_Gender" AppendDataBoundItems="true" Filter="Contains" Enabled="false" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Gender" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="1" Text="Male" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="2" Text="Female" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="3" Text="Transgender" />
                                </Items>
                                </telerik:RadComboBox>
                         </div><asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rcbGender" ForeColor="Red" ErrorMessage="Please Select Gender" Enabled="true" ValidationGroup="Case" InitialValue="Select Gender"></asp:RequiredFieldValidator>
                    </div>
            
            <div class="col-md-3">
                        <label>Employee Email Id </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeEmail" runat="server" TextMode="SingleLine" class="form-control required" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfEmployeeEmail" runat="server" ControlToValidate="txt_EmployeeEmail" ForeColor="Red" ErrorMessage="Please Enter Employee Email" Enabled="true" ValidationGroup="Case"></asp:RequiredFieldValidator>
                         
                            </div>
                <br /><br />
                    </div>
        </div>                      
        <div class="form-group" style="padding:10px;">
            <div class="col-md-3">
                        <label>State  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="DDL_State" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged" ValidationGroup="Dep" CausesValidation="false" Enabled="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_State" runat="server" ControlToValidate="DDL_State" ForeColor="Red" ErrorMessage="Please Select State" Enabled="true"  ValidationGroup="Case" InitialValue="Select State"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>City/District  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="DDL_City" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Dep" Enabled="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_City" runat="server" ControlToValidate="DDL_City" ForeColor="Red" ErrorMessage="Please Select City" Enabled="true"  ValidationGroup="Case" InitialValue="Select City"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Area/Locality <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeAreaLocality" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeAreaLocality" runat="server" ControlToValidate="txt_EmployeeAreaLocality" ForeColor="Red" ErrorMessage="Please Enter Area/Locality" Enabled="true"  ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Landmark </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeLandmark" runat="server" TextMode="SingleLine" class="form-control required" ReadOnly="true"></asp:TextBox>
                            <br /><br />
                         </div>
                    </div>
    </div>                      
        <div class="form-group" style="padding:10px;">
            <div class="col-md-3">
                        <label>Pin Code <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeePincode" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeePincode" runat="server" ControlToValidate="txt_EmployeePincode" ForeColor="Red" ErrorMessage="Please Enter Pin Code" Enabled="true"  ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Address <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeAddress" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeAddress" runat="server" ControlToValidate="txt_EmployeeAddress" ForeColor="Red" ErrorMessage="Please Enter Address" Enabled="true"  ValidationGroup="Case"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Geo Location </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeGeolocation" runat="server" TextMode="SingleLine" class="form-control required" ReadOnly="true"></asp:TextBox>
                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Date of Birth </label>
                        <div class="selector">
                            <telerik:RadDatePicker ID="rdpEmployeeDOB" runat="server" RenderMode="Lightweight" DateInput-DateFormat="dd-MM-yyyy" Enabled="false"></telerik:RadDatePicker>
                        
                         </div>
                    </div>
                </div>                      
        <div class="form-group" style="padding:10px; margin-top:240px;">
            <asp:LinkButton ID="LinkDependent" runat="server"  BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="LinkDependent_Click" ><b><i class="glyphicon glyphicon-plus"></i> Add Dependent </b></asp:LinkButton>
            <hr />
            <div id="AddDependent" runat="server" visible="false" class="form-group" style="padding:10px; margin-top:20px; overflow:auto;">
            <table border="1">
               
                <tr>
                    <th class="table_space"></th>
                    <th class="table_space">Case Id</th>
                    <th class="table_space">Case For<span class="mandatory">*</span></th>
                    <th class="table_space">Dependent Name<span class="mandatory">*</span></th>
                    <th class="table_space">Mobile Number<span class="mandatory">*</span></th>
                    <th class="table_space">Gender<span class="mandatory">*</span></th>
                    <th class="table_space">Date Of Birth<span class="mandatory">*</span></th>
                    <th class="table_space">Address</th>
                    <th class="table_space">MedicalTest</th>
                </tr>
                <tr>
                    <td class="table_space">
                        <asp:ImageButton ID="ImgAddDependent" runat="server" ImageUrl="~/images/add_icon.png" Height="30" Width="33" OnClick="ImgAddDependent_Click" ToolTip="Add Dependent" Visible="true" ValidationGroup="AddDependent" />
                        <asp:ImageButton ID="ImgUpdateDependent" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="30" Width="30" OnClick="ImgUpdateDependent_Click" ToolTip="Update Dependent" Visible="false"  />
                       <%-- <asp:Button ID="btn_Details" BackColor="#113d7a" ForeColor="white"  CssClass="btn Login_btn" runat="server" Text="Add" OnClick="btn_Details_Click" ValidationGroup="AddDependent" />--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_DCaseId" runat="server" TextMode="SingleLine" placeholder="Auto" class="form-control required" Width="100" ValidationGroup="AddDependent"></asp:TextBox>
                        <asp:Label ID="lblDependentId" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td class="table_space">
                        <telerik:RadComboBox ID="rcbDCaseFor" runat="server" RenderMode="Lightweight" CssClass="Combo3" Filter="Contains" AppendDataBoundItems="true" ValidationGroup="AddDependent" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                </Items>
                                </telerik:RadComboBox>
                        
                    </td>
                    
                    <td class="table_space">
                            <asp:TextBox ID="txt_DepName" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="AddDependent"></asp:TextBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_DepMobileNo" runat="server" MaxLength="10" Width="120" TextMode="SingleLine" class="form-control required" ValidationGroup="AddDependent" ></asp:TextBox>
                    </td>
                    <td class="table_space">
                         <telerik:RadComboBox ID="rcbDepGender" runat="server" RenderMode="Lightweight" CssClass="Combo3" Width="120" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="AddDependent">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Gender" />
                                        <telerik:RadComboBoxItem Value="Male" Text="Male" />
                                        <telerik:RadComboBoxItem Value="Female" Text="Female" />
                                </Items>
                                </telerik:RadComboBox>
                    </td>
                    <td class="table_space">
                        <telerik:RadDatePicker ID="rdpDepDOB" runat="server" CssClass="Combo2" RenderMode="Lightweight" DateInput-DateFormat="dd-MM-yyyy" ValidationGroup="AddDependent">

                            </telerik:RadDatePicker>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_DepAddress" runat="server" TextMode="SingleLine" Width="150" class="form-control required" ></asp:TextBox>
                    </td>
                    <td class="table_space">
                         <telerik:RadComboBox ID="rcbDMedicalTest" runat="server"  RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem runat="server" IsSeparator="True" Value="12" Text="Individual Test"/>
<%--                                    <telerik:RadComboBoxItem runat="server" IsSeparator="True" Value="13" Text="Test Package"/>--%>
                                </Items>
                            </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_space"></td>
                    <td class="table_space"></td>
                    <td class="table_space">
                        <asp:RequiredFieldValidator ID="rfvDCaseFor" runat="server" ControlToValidate="rcbDCaseFor" ForeColor="Red" ErrorMessage="Select CaseFor" Enabled="true" ValidationGroup="AddDependent" InitialValue="Select"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:RequiredFieldValidator ID="rfvDepName" runat="server" ControlToValidate="txt_DepName" ForeColor="Red" ErrorMessage="Enter Name" Enabled="true" ValidationGroup="AddDependent" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:RequiredFieldValidator ID="rfvDMobileNo" runat="server" ControlToValidate="txt_DepMobileNo" ForeColor="Red" ErrorMessage="Enter Mobile No" Enabled="true" ValidationGroup="AddDependent"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDMobileNo" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_DepMobileNo" ValidationGroup="Case" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:RequiredFieldValidator ID="rfvDepGender" runat="server" ControlToValidate="rcbDepGender" ForeColor="Red" ErrorMessage="Select Gender" Enabled="true" ValidationGroup="AddDependent" InitialValue="Select Gender"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:RequiredFieldValidator ID="rfvDepDOB" runat="server" ControlToValidate="rdpDepDOB" ForeColor="Red" ErrorMessage="Enter DOB" Enabled="true" ValidationGroup="AddDependent" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space"></td>
                    <td class="table_space"></td>
                </tr>
                
            </table>
         

             <asp:GridView ID="rgDependentGrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top">

             </asp:GridView>
            </div>
             </div> 
         <%--<div  class="form-group" style="padding:10px; margin-top:120px; overflow:auto;  display:none;">

             <asp:GridView ID="rgvDependentDetails" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="true" AllowSorting="true" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White" FooterStyle-VerticalAlign="Top" OnRowCommand="rgvDependentDetails_RowCommand">
                 <Columns>
                        <asp:TemplateField HeaderText="Action" SortExpression="CaseId">
    <ItemTemplate>
        <asp:ImageButton ID="hyplnkUserName" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" />
       
        <asp:Label ID="lblcaseId" runat="server" Visible="false"
            Text='<%# Bind("CaseId") %>'></asp:Label>
    </ItemTemplate>
        
                            
    
</asp:TemplateField>
                        <asp:BoundField DataField="CaseId" HeaderText="Case Id" SortExpression="CaseId" ItemStyle-ForeColor="Red"></asp:BoundField>
                        <asp:BoundField DataField="CaseFor" HeaderText="Case For" SortExpression="CaseFor"></asp:BoundField>
                        <asp:BoundField DataField="DependentName" HeaderText="Dependent Name" SortExpression="DependentName"></asp:BoundField>
                        <asp:BoundField DataField="DependentMobileNo" HeaderText="Dependent MobileNo" SortExpression="DependentMobileNo"></asp:BoundField>
                        <asp:BoundField DataField="DependentGender" HeaderText="Dependent Gender" SortExpression="DependentGender"></asp:BoundField>
                        <asp:BoundField DataField="DependentDOB" HeaderText="Dependent DOB" SortExpression="DependentDOB"></asp:BoundField>
                        <asp:BoundField DataField="DependentAddress" HeaderText="Dependent Address" SortExpression="DependentAddress"></asp:BoundField>
                        <asp:BoundField DataField="MedicalTest" HeaderText="Medical Test" SortExpression="MedicalTest"></asp:BoundField> 
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
             </asp:GridView>             

         </div>--%>        
        
         <div class="form-group" style="padding:10px; ">
            <h4>Case Details </h4>
            <hr />
            
             
             <div class="col-md-3">
                        <label>Medical Test  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="RadComboBox1" runat="server"  RenderMode="Lightweight" Visible="false" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem runat="server" IsSeparator="True" Text="Individual Test"/>
                                    <telerik:RadComboBoxItem runat="server" IsSeparator="True" Text="Test Package"/>
                                </Items>
                            </telerik:RadComboBox>
                             <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" ValidationGroup="Case">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                   <%--<telerik:RadComboBoxItem runat="server" IsSeparator="True" Text="Individual Test"/>--%>
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvMedicalTest" runat="server" ControlToValidate="rcbMedicalTest" ForeColor="Red" ErrorMessage="Please Select Test" Enabled="true" ValidationGroup="Case" InitialValue="Select Test"></asp:RequiredFieldValidator>

                        </div>
                    </div>
             <div class="col-md-3">
                        <label>Welleazy Generic Test </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbGenericTest" RenderMode="Lightweight" Filter="Contains" CheckBoxes="true" CssClass="Combo" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDL_CorporateName" ForeColor="Red" ErrorMessage="Please Select Client Name" ValidationGroup="Case" InitialValue="Select Client Name"></asp:RequiredFieldValidator>--%>
                            
                         </div>
                    </div>
             <div class="col-md-3">
                        <label>Customer Profile <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbCustomerProfile" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="rcbCustomerProfile_SelectedIndexChanged" ValidationGroup="Case" CausesValidation="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Profile" />
                                </Items>
<%--                                 <Items>
                                        <telerik:RadComboBoxItem Value="Normal" Text="Normal" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="HNI" Text="HNI" />
                                </Items>--%>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_ProfileType" runat="server" ControlToValidate="rcbCustomerProfile" ForeColor="Red" ErrorMessage="Please Select Profile Type" InitialValue="Select Profile" ValidationGroup="Case"></asp:RequiredFieldValidator>                            

                        </div>
                    </div>
             <div class="col-md-3">
                        <label>Employee Pay Amount  </label>
                        <div class="selector">
                             <asp:TextBox ID="txtPaybleAmount" runat="server" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            
                         </div>
                 <br /><br />
                    </div>
             <div class="col-md-3">
                        <label>Application No  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_ApplicationNo" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Case"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApplicationNo" runat="server" ControlToValidate="txt_ApplicationNo" ForeColor="Red" ErrorMessage="Please Enter Application No" ValidationGroup="Case"></asp:RequiredFieldValidator>                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Case Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbCaseType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" ValidationGroup="Case">
                               <Items>
                                      <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                   <telerik:RadComboBoxItem Value="1" Text="Main Medicals" />
                                   <telerik:RadComboBoxItem Value="2" Text="Additional Medicals" />
                                   <telerik:RadComboBoxItem Value="3" Text="Clarifications" />
                                   <telerik:RadComboBoxItem Value="4" Text="Repeat Medicals" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="rcbCaseType" ForeColor="Red" ErrorMessage="Please Select Case Type" Enabled="true" ValidationGroup="Case" InitialValue="Select Case Type"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Payment Type  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbPaymentType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Payment Type" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="1" Text="Corporate Paid" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="2" Text="Customer Paid" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="3" Text="Partial Pay" />
                                </Items>
                            </telerik:RadComboBox>
                           

                        </div>
                    </div>
             <div class="col-md-3">
                        <label>Case For <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbcasefor" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" ValidationGroup="Case" CausesValidation="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case For" />
                                </Items>
                               <%--  <Items>
                                        <telerik:RadComboBoxItem Value="Self" Text="Self" />
                                        <telerik:RadComboBoxItem Value="Dependent" Text="Dependent" />
                                        <telerik:RadComboBoxItem Value="Both" Text="Both" />
                                </Items>--%>
                            </telerik:RadComboBox>
                            
                             <asp:RequiredFieldValidator ID="rfvCaseFor" runat="server" ControlToValidate="rcbcasefor" ForeColor="Red" ErrorMessage="Please Select Case For" Enabled="true" ValidationGroup="Case" InitialValue="Select Case For"></asp:RequiredFieldValidator>
                        </div>
                 <br /><br />
                    </div>
              <div class="col-md-3">
                        <label>DHOC/Advance Payment  </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbDHOCPayment" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" ValidationGroup="Case">
                               <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                
                            </telerik:RadComboBox>
                            

                        </div>
                  
                    </div>
            <div class="col-md-3" style="display:none;">
                                   <label>
                                   Is Active
                                   </label>
                                   <div class="selector">
                                       <asp:RadioButtonList ID="rbIsActive" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                           <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                       </asp:RadioButtonList>
                                   </div>
                               </div>
        </div>                      
       

         <div class="form-group" style="padding:10px; margin-top:260px;">
            <h4>Schedule Appointment </h4>
            <hr />
            <div class="col-md-3">
                <label>Case Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" Enabled="false" EnableCheckAllItemsCheckBox="true" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                  <%--  <telerik:RadComboBoxItem Value="1" Text="Fresh Case" Selected="true" />
                                    <telerik:RadComboBoxItem Value="2" Text="Call Later - Customer asked to call back" />
                                    <telerik:RadComboBoxItem Value="3" Text="Call Later - Customer phone switched off" />
                                    <telerik:RadComboBoxItem Value="4" Text="Call Later - Customer not answering/available" />
                                    <telerik:RadComboBoxItem Value="5" Text="Call Later - Customer not Responding" />
                                    <telerik:RadComboBoxItem Value="6" Text="Appointment Confirmed" />
                                    <telerik:RadComboBoxItem Value="7" Text="Appointment Missed - Reschedule Appointment" />
                                    <telerik:RadComboBoxItem Value="8" Text="Escalated to Insurance Co - Customer No Show" />
                                    <telerik:RadComboBoxItem Value="9" Text="Escalated to Insurance Co - Customer Not Interested" />
                                    <telerik:RadComboBoxItem Value="10" Text="Escalated to Insurance Co - Customer Not Responding/Wrong Number" />
                                    <telerik:RadComboBoxItem Value="11" Text="Escalated to Insurance Co - Customer Not Co-operating" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Other TPA Completed" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Unable to find DC" />
                                    <telerik:RadComboBoxItem Value="12" Text="Cancelled by Insurance Company - Customer Not Interested" />
                                    <telerik:RadComboBoxItem Value="12" Text="Cancelled by Insurance Company - Customer Not Responding/Wrong number" />
                                    <telerik:RadComboBoxItem Value="12" Text="Cancelled by Insurance Company - Customer cancelled policy" />
                                    <telerik:RadComboBoxItem Value="12" Text="Cancelled by Insurance Company - Other TPA completed" />
                                    <telerik:RadComboBoxItem Value="12" Text="Cancelled by Insurance Company - No DC / Unable to complete" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Policy cancelled as per the customer" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Customer not aware of medicals" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Medicals done by other policy no" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed medicals not required" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />
                                    <telerik:RadComboBoxItem Value="12" Text="Escalated to Insurance Co - Agent confirmed policy cancelled" />--%>
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            <div class="col-md-3">
                        <label>Follow Up Date  </label>
                        <div class="selector">
                         <telerik:RadDateTimePicker ID="dtpFollowUp" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Case">
                                
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>
            <div class="col-md-6">
                        <label>Remark  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Remark" runat="server" TextMode="MultiLine" class="form-control required" ></asp:TextBox>
                        </div>
                    </div>
        
        </div>
        <div class="form-group" style="padding:10px; margin-top:100px; text-align:center;">
                 
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Case" />
     &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel"  />
    
        </div>
         </div>
  <%--        </ContentTemplate>
         <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
                <asp:PostBackTrigger ControlID="btnCancel" />
            </Triggers>
        </asp:UpdatePanel>--%>
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

    <%--<div id="SearchPopUp" class="modal fade" role="dialog" >
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                     
                                        <h4 class="modal-title"></h4>
                                    </div>
                                    <div class="modal-body">

                                                             
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Ok" OnClick="btnSearch_Click" />
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

    <style type="text/css">  
    .modalBackground  
    {  
        background-color: Black;  
        filter: alpha(opacity=90);  
        opacity: 0.8;  
    }  
      
    .modalPopup  
    {  
        background-color: #FFFFFF;  
        border-width: 3px;  
        border-style: solid;  
        border-color: black;  
        padding-top: 10px;  
        padding-left: 10px;  
        width: 1100px;  
        height: 500px;  
    }  
</style>  
       

    <ajaxtoolkit:modalpopupextender id="ModalPopupExtenderLogin" runat="server"
        targetcontrolid="btnSearchEmployeee"
        popupcontrolid="SearchEmployeeDetails"
        backgroundcssclass="modalBackground" />

     <asp:Panel ID="SearchEmployeeDetails" runat="server" CssClass="modalPopup"  align="center" style="display:none">
         <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSearchEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchEmployeeId" runat="server" Text="Employee Id"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox id="txtSearchEmployeeName" runat="server" OnTextChanged="txtSearchEmployeeName_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchMobileNo" runat="server" OnTextChanged="txtSearchMobileNo_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtSearchEmployeeId" runat="server" OnTextChanged="txtSearchEmployeeId_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
         <br />

                                        <telerik:RadGrid ID="rgvSearchEmployeeDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                      BorderWidth="1px" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" EnableTheming="true"
                      OnItemCommand="rgvSearchEmployeeDetails_ItemCommand" OnNeedDataSource="rgvSearchEmployeeDetails_NeedDataSource" OnPageIndexChanged="rgvSearchEmployeeDetails_PageIndexChanged"
                      Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                       <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" NoDetailRecordsText="No Records to Display">
                           <Columns>
                               
                               <telerik:GridTemplateColumn HeaderText="Employee Id" SortExpression="EmployeeId">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkEmployeeId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" OnClientClick="window.closes()" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeId")%>'></asp:LinkButton>
                                       <asp:Label ID="lblEmployeeRefId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeRefId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName" Visible="false">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="Branch" Visible="false">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblBranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Branch")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Employee Name" SortExpression="EmployeeName">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Address" SortExpression="Address">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Email Id" SortExpression="Emailid">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblEmailid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Emailid")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="Mobile No" SortExpression="MobileNo">
                                   <ItemTemplate>                                       
                                       <asp:Label ID="lblMobileNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>'></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                          
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>


                                        <br />
                                        <div style="align-content:center">
                                             <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btn_Search_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Close" CssClass="login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btn_Cancel_Click" CausesValidation="false"/>
                                        </div>
    </asp:Panel>
        <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",3000);
 }
</script>
</asp:Content>
