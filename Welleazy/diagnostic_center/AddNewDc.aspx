<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNewDc.aspx.cs" Inherits="Welleazy.diagnostic_center.AddNewDc" EnableEventValidation="false" EnableSessionState="True" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | Add Service Provider</title>
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
    <script type="text/javascript">
       function ProviderType() {
           if (document.getElementById("DDL_Typeofprovider")) {

        document.getElementById("userinfo").style.display="block";
    } else {
        document.getElementById("userinfo").style.display="none";
    }
}
    </script>

    <script type="text/javascript">
        function ValidateFile2() {
            var fileCount = document.getElementById('FileUploadDCImage').files.length;
            if (fileCount > 2) // Selected images with in 10 count
            {
                alert("Please select only 10 images..!!!");
                return false;
            }
            else if (fileCount <= 0) // Selected atleast 1 image check
            {
                alert("Please select atleat 1 image..!!!");
                return false;
            }

            return true;  // Good to go
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
    <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Add Serivce Provider</h4>
            <span style="float:right;">
            <%--<asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;" CausesValidation="false"/>--%>
            <asp:LinkButton ID="Linkspl1" runat="server" OnClick="Linkspl1_Click" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-earphone"></i></b> Network Manager Contact Details </asp:LinkButton> 

                                </span>
                                   <div class="line"></div>
      
        <div id="TypeOfProvider" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-bottom:10px;">
            <h4>Type of Provider</h4>
            <hr />
            <div class="col-md-3">
                        <label>Type of Provider  </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Typeofprovider" runat="server" RenderMode="Lightweight" CssClass="Combo" AutoPostBack="true" AppendDataBoundItems="true" Filter="Contains" OnSelectedIndexChanged="DDL_Typeofprovider_SelectedIndexChanged" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Provider Type" />
                                    </Items>
                               
                            </telerik:RadComboBox>
                            <asp:Label ID="lbl_dcid" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Type of Specialty  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Typeofspecialty" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Specialty type" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Typeofspecialty" runat="server" ControlToValidate="DDL_Typeofspecialty" ForeColor="Red" ErrorMessage="Please Select Specialty" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Specialty type"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Ownership  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="DDL_Ownership" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Ownership Type" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Ownership" runat="server" ControlToValidate="DDL_Ownership" ForeColor="Red" ErrorMessage="Please Select Ownership" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Ownership Type"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Corporate Group  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Corporategroup" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="DDL_Corporategroup_SelectedIndexChanged" CausesValidation="false" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Corporategroup" runat="server" ControlToValidate="DDL_Corporategroup" ForeColor="Red" ErrorMessage="Please Select CorporateGroup" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3" runat="server" id="CorporateName" visible="false" >
                        <label>Corporate Name  <span class="mandatory"></span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_CorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <%--<asp:RequiredFieldValidator ID="rfvCorporateList" runat="server" ControlToValidate="DDL_CorporateName" ForeColor="Red" ErrorMessage="Select Corporate Name" ValidationGroup="SaveFrame" InitialValue="Select Corporate Name"></asp:RequiredFieldValidator>--%>
                            
                         </div>
                    </div>
            <div id="ServiceArea" class="col-md-3" runat="server" visible="false">
                        <label>Service Area <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Servicearea" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Servicearea" runat="server" ControlToValidate="txt_Servicearea" ForeColor="Red" ErrorMessage="Please Enter Service Area" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div id="HomeDelivery" class="col-md-3" runat="server" visible="false">
                        <label>Home Delivery <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Homedelivery" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Homedelivery" runat="server" ControlToValidate="txt_Homedelivery" ForeColor="Red" ErrorMessage="Please Enter Home Delivery" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div id="Deliverytat" class="col-md-3" runat="server" visible="false">
                        <label>Delivery TAT <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Deliverytat" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Deliverytat" runat="server" ControlToValidate="txt_Deliverytat" ForeColor="Red" ErrorMessage="Please Enter Delivery TAT" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                
                    </div>
        </div>
        <div id="ProviderBInformation" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:190px;">
            <h4>Provider Basic Information</h4>
            <hr />
            <div class="col-md-3">
                        <label>Hospital Name <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Hospitalname" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Hospitalname" runat="server" ControlToValidate="txt_Hospitalname" ForeColor="Red" ErrorMessage="Please Enter Hospital Name" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Plot No </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Plotno" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Address <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Address" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Address" runat="server" ControlToValidate="txt_Address" ForeColor="Red" ErrorMessage="Please Enter Address" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>

            <div class="col-md-3">
                        <label>Area/Town <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Area" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Area" runat="server" ControlToValidate="txt_Area" ForeColor="Red" ErrorMessage="Please Enter Area" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>State  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="DDL_State" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged" ValidationGroup="SaveFrame" CausesValidation="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_State" runat="server" ControlToValidate="DDL_State" ForeColor="Red" ErrorMessage="Please Select State" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select State"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>City/District  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="DDL_City" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_City" runat="server" ControlToValidate="DDL_City" ForeColor="Red" ErrorMessage="Please Select City" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select City"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Pin Code <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Pincode" runat="server" TextMode="Number" MaxLength="6" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Pincode" runat="server" ControlToValidate="txt_Pincode" ForeColor="Red" ErrorMessage="Please Enter Pin Code" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="revPincode" ControlToValidate="txt_Pincode" ErrorMessage="Only 6 digit allowed" ValidationExpression="^\d{6}$" ForeColor="Red" ValidationGroup="SaveFrame"></asp:RegularExpressionValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>STD Code </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Stdcode" runat="server" TextMode="Number" class="form-control required" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredField_Stdcode" runat="server" ControlToValidate="txt_Stdcode" ForeColor="Red" ErrorMessage="Please Enter STD Code" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%><br /><br />
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Landline No </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Landlineno" runat="server" TextMode="Number" class="form-control required" MaxLength="20" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredField_Landlineno" runat="server" ControlToValidate="txt_Landlineno" ForeColor="Red" ErrorMessage="Please Enter landline Number" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Mobile Number <span class="mandatory">*</span></label>
                        <div class="selector">
                            <asp:TextBox ID="txt_Mobileno" runat="server" TextMode="Number" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Mobileno" runat="server" ControlToValidate="txt_Mobileno" ForeColor="Red" ErrorMessage="Please Enter Mobile Number" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Invalid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_Mobileno" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Fax </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Fax" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Email Id <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Emailid" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Emailid" runat="server" ControlToValidate="txt_Emailid" ForeColor="Red" ErrorMessage="Please Enter Email id" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpression_Emailid" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_Emailid"></asp:RegularExpressionValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Website </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Website" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
<div class="col-md-3"></div>
            <div class="col-md-3"></div>
            <div class="col-md-3"><br /><br /><br /><br /></div>
        </div>
        <div id="ProviderRecognition" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:330px;">
            <h4>Provider Recognition</h4>
            <hr />
            <div class="form-group" style="padding-left:15px; overflow:auto; text-align:left;">
                        <label>Reconized By <span class="mandatory">*</span></label>
                        <div class="selector">
                            <asp:CheckBoxList ID="CBL_Recongnizedby" runat="server" RepeatDirection="Horizontal" Width="500" ValidationGroup="SaveFrame">
                               <%-- <asp:ListItem Value="CGHS">CGHS</asp:ListItem>
                                <asp:ListItem Value="State Govt.">State Govt.</asp:ListItem>
                                <asp:ListItem Value="Local Municipal">Local Municipal</asp:ListItem>--%>
                            </asp:CheckBoxList>
                            
                            <%--<asp:CheckBox ID="CB_Recongnizedby" runat="server" Text="Other" AutoPostBack="true" OnCheckedChanged="CB_Recongnizedby_CheckedChanged" /><asp:TextBox ID="Recongnized_by_other" TextMode="SingleLine" Visible="false" runat="server"></asp:TextBox>--%>
                            <asp:CustomValidator ID="Custom_Recongnizedby" ErrorMessage="Please select at least one item."  ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" ValidationGroup="SaveFrame"  />
                            <script type="text/javascript">
                                function ValidateCheckBoxList(sender, args) {
                                    var checkBoxList = document.getElementById("<%=CBL_Recongnizedby.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
    }
</script>
                         </div>
            </div>
            <div class="form-group" style="padding-left:15px; overflow:auto; text-align:left;">
                        <label>Accreditation <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:CheckBoxList ID="CBL_Accreditation" runat="server" RepeatDirection="Horizontal" Width="500" ValidationGroup="SaveFrame">
                                <%--<asp:ListItem Value="ISO">ISO</asp:ListItem>
                                <asp:ListItem Value="NABH">NABH</asp:ListItem>
                                <asp:ListItem Value="NABL">NABL</asp:ListItem>
                                <asp:ListItem Value="JCI">JCI</asp:ListItem>
                                <asp:ListItem Value="ICRA">ICRA</asp:ListItem>
                                <asp:ListItem Value="CRISIL">CRISIL</asp:ListItem>--%>
                            </asp:CheckBoxList>
                            
                            <%--<asp:CheckBox ID="CB_Accreditation" runat="server" Text="Other" AutoPostBack="true" OnCheckedChanged="CB_Accreditation_CheckedChanged" /><asp:TextBox ID="Accreditation_other" TextMode="SingleLine" Visible="false" runat="server"></asp:TextBox>--%>
                            <asp:CustomValidator ID="Custom_Accreditation" ErrorMessage="Please select at least one item."  ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList1" runat="server" ValidationGroup="SaveFrame"  />
                                               <script type="text/javascript">
                                                   function ValidateCheckBoxList1(sender, args) {
                                                       var checkBoxList = document.getElementById("<%=CBL_Accreditation.ClientID %>");
                                    var checkboxes = checkBoxList.getElementsByTagName("input");
                                    var isValid = false;
                                    for (var i = 0; i < checkboxes.length; i++) {
                                        if (checkboxes[i].checked) {
                                            isValid = true;
                                            break;
                                        }
                                    }
                                    args.IsValid = isValid;
                                }
</script>
                         </div>
            </div>
        </div> 
        <div id="ProviderManpower" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:20px;">
            <h4>Provider Manpower & Staffing</h4>
            <hr />
            <div class="col-md-3">
                        <label>Total Staff Strength <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Totalstaff" runat="server" TextMode="Number" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Totalstaff" runat="server" ControlToValidate="txt_Totalstaff" ForeColor="Red" ErrorMessage="Please Enter Total No of Staff" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>No. Of Doctors/Consultants (Full Time) <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Drsfulltime" runat="server" TextMode="Number" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Drsfulltime" runat="server" ControlToValidate="txt_Drsfulltime" ForeColor="Red" ErrorMessage="Please Enter Doctor/Consultants Fulltime" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>No. Of Doctors/Consultants (Visiting) <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Drsvisiting" runat="server" TextMode="Number" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Drsvisiting" runat="server" ControlToValidate="txt_Drsvisiting" ForeColor="Red" ErrorMessage="Please Enter Doctor/Consultants Visiting" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         </div>
                    </div>
        </div>
        <div id="Depart1" runat="server" visible="false" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:240px; overflow:auto;">
            <hr />
            <table style="border:1px solid #f2f1f1; padding:10px;">
                <tr>
                    <th class="table_space">Department </th>
                    <th class="table_space Combo3">Title <span class="mandatory">*</span></th>
                    <th class="table_space">Contact Person Name <span class="mandatory">*</span></th>
                    <th class="table_space">Designation <span class="mandatory">*</span></th>
                    <th class="table_space">Email <span class="mandatory">*</span></th>
                    <th class="table_space">Cell No. <span class="mandatory">*</span></th>
                </tr>
                <tr>
                    <td class="table_space">Business SPOC <span class="mandatory">*</span></td>
                    <td class="table_space">
                         <telerik:RadComboBox ID="DDL_Dep9" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Dep9" runat="server" ControlToValidate="DDL_Dep9" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn9" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cpn9" runat="server" ControlToValidate="txt_cpn9" ForeColor="Red" ErrorMessage="Please Enter Contact Person name" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des9" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_des9" runat="server" ControlToValidate="txt_des9" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em9" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_em9" runat="server" ControlToValidate="txt_em9" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpression_em9" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em9"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno9" runat="server" TextMode="Phone" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cno9" runat="server" ControlToValidate="txt_cno9" ForeColor="Red" ErrorMessage="Please Enter cell Number" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpression_cno9" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno9" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                
            </table>
        </div>
        <div id="Dep1" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:120px; overflow:auto;">
            <table style="border:1px solid #f2f1f1; padding:10px;">
                <tr>
                    <th class="table_space">Department </th>
                    <th class="table_space Combo3">Title <span class="mandatory">*</span></th>
                    <th class="table_space">Contact Person Name <span class="mandatory">*</span></th>
                    <th class="table_space">Designation <span class="mandatory">*</span></th>
                    <th class="table_space">Email <span class="mandatory">*</span></th>
                    <th class="table_space">Cell No. <span class="mandatory">*</span></th>
                </tr>
                <tr>
                    <td class="table_space">Head of Insurance Desk <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep1" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Dep1" runat="server" ControlToValidate="DDL_Dep1" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true" ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn1" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cpn1" runat="server" ControlToValidate="txt_cpn1" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true" ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des1" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_des1" runat="server" ControlToValidate="txt_des1" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true" ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em1" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_em1" runat="server" ControlToValidate="txt_em1" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true" ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpression_em1" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em1"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno1" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cno1" runat="server" ControlToValidate="txt_cno1" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true" ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno1" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno1" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Head of Marketing/Business Development </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep2" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_Dep2" runat="server" ControlToValidate="DDL_Dep2" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn2" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cpn2" runat="server" ControlToValidate="txt_cpn2" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des2" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_des2" runat="server" ControlToValidate="txt_des2" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em2" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_em2" runat="server" ControlToValidate="txt_em2" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpression_em2" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em2"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno2" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cno2" runat="server" ControlToValidate="txt_cno2" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno2" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno2" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Head of Accounts/Finance </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep3" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_Dep3" runat="server" ControlToValidate="DDL_Dep3" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn3" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cpn3" runat="server" ControlToValidate="txt_cpn3" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des3" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_des3" runat="server" ControlToValidate="txt_des3" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em3" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_em3" runat="server" ControlToValidate="txt_em3" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpression_em3" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em3"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno3" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cno3" runat="server" ControlToValidate="txt_cno3" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true"  ValidationGroup="SaveFrame"></asp:RequiredFieldValidator>--%>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno3" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno3" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Head of Clinical Services </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep4" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn4" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des4" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em4" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpression_em4" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em4"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno4" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno4" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno4" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Head of Nursing Services </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep5" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn5" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des5" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em5" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpression_em5" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em5"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno5" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno5" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno5" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Fund Transfer Detail to be updated to <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep6" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Dep6" runat="server" ControlToValidate="DDL_Dep6" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn6" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cpn6" runat="server" ControlToValidate="txt_cpn6" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des6" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_des6" runat="server" ControlToValidate="txt_des6" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em6" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_em6" runat="server" ControlToValidate="txt_em6" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpression_em6" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em6"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno6" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cno6" runat="server" ControlToValidate="txt_cno6" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno6" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno6" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Cashless OPD Related Communication to be updated to  <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep7" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Dep7" runat="server" ControlToValidate="DDL_Dep7" ForeColor="Red" ErrorMessage="Please Select Title" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn7" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cpn7" runat="server" ControlToValidate="txt_cpn7" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des7" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_des7" runat="server" ControlToValidate="txt_des7" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em7" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_em7" runat="server" ControlToValidate="txt_em7" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpression_em7" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em7"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno7" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredField_cno7" runat="server" ControlToValidate="txt_cno7" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno7" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno7" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Chairman/Manging Director/CEO/Unit Head of the organization </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Dep8" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Dr." Text="Dr." />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Mr." Text="Mr." />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Mrs." Text="Mrs." />
                                </Items>
                              <Items>
                                        <telerik:RadComboBoxItem Value="Ms." Text="Ms." />
                                </Items>
                            </telerik:RadComboBox>
                        
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cpn8" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cpn8" runat="server" ControlToValidate="txt_cpn8" ForeColor="Red" ErrorMessage="Please Enter Contact Person Name" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_des8" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_des8" runat="server" ControlToValidate="txt_des8" ForeColor="Red" ErrorMessage="Please Enter Designation" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_em8" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_em8" runat="server" ControlToValidate="txt_em8" ForeColor="Red" ErrorMessage="Please Enter Email Id" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpression_em8" runat="server" ErrorMessage="Enter Valid Email" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_em8"></asp:RegularExpressionValidator>
                    </td>
                    <td class="table_space">
                        <asp:TextBox ID="txt_cno8" runat="server" TextMode="SingleLine" class="form-control required" MaxLength="10" ValidationGroup="SaveFrame"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredField_cno8" runat="server" ControlToValidate="txt_cno8" ForeColor="Red" ErrorMessage="Please Enter Cell Number" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>--%>
                         <asp:RegularExpressionValidator ID="RegularExpression_cno8" runat="server" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                        ControlToValidate="txt_cno8" ValidationGroup="SaveFrame" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div id="ProviderServices" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:30px;">
            <h4>Provider Services</h4>
            <hr />
            <div class="col-md-3">
                        <label>Service Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Servicetype" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Service Type" />
                                </Items>
                                <%--<Items>
                                        <telerik:RadComboBoxItem Value="Only OPD" Text="Only OPD" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Only IPD" Text="Only IPD" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Only IPD Including Emergency" Text="Only IPD Including Emergency" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Only Casluaty/Emergency" Text="Only Casluaty/Emergency" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="OPD & IPD Including Emergency" Text="OPD & IPD Including Emergency" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Only Day care" Text="Only Day care" />
                                    <telerik:RadComboBoxItem Value="Dental" Text="Dental" />
                                    <telerik:RadComboBoxItem Value="Eye" Text="Eye" />
                                </Items>--%>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="RequiredField_Servicetype" runat="server" ControlToValidate="DDL_Servicetype" ForeColor="Red" ErrorMessage="Please Select Service Type" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Service Type"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Ambulance  <span class="mandatory">*</span></label>
                        <div class="selector">
                             
                            <telerik:RadComboBox ID="DDL_Ambulance" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                                
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Ambulance" runat="server" ControlToValidate="DDL_Ambulance" ForeColor="Red" ErrorMessage="Please Select Ambulance Option" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>If Ambulance Yes  </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Ambulanceyes" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="BLS" Text="BLS" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="ACLS" Text="ACLS" />
                                </Items>
                                <%--<Items>
                                        <telerik:RadComboBoxItem Value="Both" Text="Both" />
                                </Items>--%>
                                
                            </telerik:RadComboBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Health Check Up  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Health" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <%--<Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>--%>
                                <Items>
                                    <telerik:RadComboBoxItem Value="No" Text="No" />
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                               
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Health" runat="server" ControlToValidate="DDL_Health" ForeColor="Red" ErrorMessage="Please Select Health Check Up" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                         <br /><br /></div>
                    </div>
            <div class="col-md-3">
                        <label>No. Of BLS Ambulances </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_BLSambulance" runat="server" TextMode="Number" MaxLength="3" class="form-control required" ValidationGroup="SaveFrame"></asp:TextBox>
                            </div>
                    </div>
            <div class="col-md-3">
                        <label>No. Of ACLS Ambulances </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_ACLSambulance" runat="server" TextMode="Number" MaxLength="3" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
        </div>
        <div id="Specialtiesavail" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:220px;">
          
            <div class="form-group" style="padding-left:15px; overflow:auto; text-align:left;">
                         <label>Specialties Available <span class="mandatory">*</span></label>
                        <div class="selector" style="padding:20px;">
                            <asp:CheckBoxList ID="CBL_Specialties" runat="server" Width="900" RepeatDirection="Horizontal" RepeatColumns="4" CssClass="" ValidationGroup="SaveFrame">
                                <%--<asp:ListItem Value="Anesthesia">Anesthesia</asp:ListItem>
                                <asp:ListItem Value="Surgical Oncology">Surgical Oncology</asp:ListItem>
                                <asp:ListItem Value="Gastroenterology">Gastroenterology</asp:ListItem>
                                <asp:ListItem Value="Obstetrics & Gynecology">Obstetrics & Gynecology</asp:ListItem>
                                <asp:ListItem Value="Renal Dialysis">Renal Dialysis</asp:ListItem>
                                <asp:ListItem Value="General Medicine">General Medicine</asp:ListItem>
                                <asp:ListItem Value="Medical Oncology">Medical Oncology</asp:ListItem>
                                <asp:ListItem Value="General Surgery">General Surgery</asp:ListItem>
                                <asp:ListItem Value="IVF">IVF</asp:ListItem>
                                <asp:ListItem Value="Occupational therapy">Occupational therapy</asp:ListItem>
                                <asp:ListItem Value="Cardiology">Cardiology</asp:ListItem>
                                <asp:ListItem Value="Radiation Oncology">Radiation Oncology</asp:ListItem>
                                <asp:ListItem Value="Surgical Gastroenterology">Surgical Gastroenterology</asp:ListItem>
                                <asp:ListItem Value="Neonatology">Neonatology</asp:ListItem>
                                <asp:ListItem Value="Physiotherapy">Physiotherapy</asp:ListItem>
                                <asp:ListItem Value="Cardio Thoracic Surgery">Cardio Thoracic Surgery</asp:ListItem>
                                <asp:ListItem Value="BMT">BMT</asp:ListItem>
                                <asp:ListItem Value="Orthopedics">Orthopedics</asp:ListItem>
                                <asp:ListItem Value="Pediatrics">Pediatrics</asp:ListItem>
                                <asp:ListItem Value="Pulmonology">Pulmonology</asp:ListItem>
                                <asp:ListItem Value="Endocrinology">Endocrinology</asp:ListItem>
                                <asp:ListItem Value="Plastic Surgery">Plastic Surgery</asp:ListItem>
                                <asp:ListItem Value="Dental">Dental</asp:ListItem>
                                <asp:ListItem Value="Urology">Urology</asp:ListItem>                                
                                <asp:ListItem Value="Hematology">Hematology</asp:ListItem>
                                <asp:ListItem Value="Kidney Transplant">Kidney Transplant</asp:ListItem>
                                <asp:ListItem Value="Homeopathy">Homeopathy</asp:ListItem>
                                <asp:ListItem Value="Nephrology">Nephrology</asp:ListItem>
                                <asp:ListItem Value="Rheumatology">Rheumatology</asp:ListItem>
                                <asp:ListItem Value="Liver Transplant">Liver Transplant</asp:ListItem>
                                <asp:ListItem Value="Ayurveda">Ayurveda</asp:ListItem>
                                <asp:ListItem Value="Neuro Surgery">Neuro Surgery</asp:ListItem>
                                <asp:ListItem Value="ENT">ENT</asp:ListItem>
                                <asp:ListItem Value="Heart Transplant">Heart Transplant</asp:ListItem>
                                <asp:ListItem Value="Unani">Unani</asp:ListItem>
                                <asp:ListItem Value="Neurology">Neurology</asp:ListItem>
                                <asp:ListItem Value="Ophthalmology">Ophthalmology</asp:ListItem>
                                <asp:ListItem Value="Other Transplant Surgery">Other Transplant Surgery</asp:ListItem>
                                <asp:ListItem Value="Breast Cancer Services">Breast Cancer Services</asp:ListItem>
                                <asp:ListItem Value="Psychiatry">Psychiatry</asp:ListItem>
                                <asp:ListItem Value="Dermatology">Dermatology</asp:ListItem>--%>
                            </asp:CheckBoxList>
                            <asp:CustomValidator ID="Custom_Specialties" ErrorMessage="Please select at least one item."  ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList2" runat="server" ValidationGroup="SaveFrame"  />
                         </div>
                <script type="text/javascript">
                    function ValidateCheckBoxList2(sender, args) {
                        var checkBoxList = document.getElementById("<%=CBL_Specialties.ClientID %>");
                                                       var checkboxes = checkBoxList.getElementsByTagName("input");
                                                       var isValid = false;
                                                       for (var i = 0; i < checkboxes.length; i++) {
                                                           if (checkboxes[i].checked) {
                                                               isValid = true;
                                                               break;
                                                           }
                                                       }
                                                       args.IsValid = isValid;
                                                   }
</script>
            </div>
        </div>
        <div id="LaboratoryRadiology" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:20px; background-color:white;">
            <h5> </h5>
            <hr />
            
            <%--<div class="col-md-6">
                        <table style="border:1px solid #f2f1f1; padding:10px;">
                <tr>
                    <th class="table_space">Laboratory </th>
                    <th class="table_space">Status <span class="mandatory">*</span></th>
                </tr>
                <tr>
                    <td class="table_space">Hematology </td>
                    <td class="table_space">
                        <telerik:RadComboBox ID="DDL_Lab1" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab1" runat="server" ControlToValidate="DDL_Lab1" ForeColor="Red" ErrorMessage="Please Select Hematology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Biochemistry </td>
                    <td class="table_space">
                        <telerik:RadComboBox ID="DDL_Lab2" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                <Items>
                                    <telerik:RadComboBoxItem Value="Outsourced" Text="Outsourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab2" runat="server" ControlToValidate="DDL_Lab2" ForeColor="Red" ErrorMessage="Please Select Biochemistry" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Microbiology </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Lab3" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab3" runat="server" ControlToValidate="DDL_Lab3" ForeColor="Red" ErrorMessage="Please Select Microbiology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Pathology </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Lab4" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                <Items>
                                    <telerik:RadComboBoxItem Value="Outsourced" Text="Outsourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab4" runat="server" ControlToValidate="DDL_Lab4" ForeColor="Red" ErrorMessage="Please Select Pathology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Serology </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Lab5" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab5" runat="server" ControlToValidate="DDL_Lab5" ForeColor="Red" ErrorMessage="Please Select Serology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="table_space">Histopathology </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Lab6" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab6" runat="server" ControlToValidate="DDL_Lab6" ForeColor="Red" ErrorMessage="Please Select Histopathology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="table_space">Endocrinology  </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Lab7" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                <Items>
                                    <telerik:RadComboBoxItem Value="Outsourced" Text="Outsourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab7" runat="server" ControlToValidate="DDL_Lab7" ForeColor="Red" ErrorMessage="Please Select Endocrinology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="table_space">Cytology  </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Lab8" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                <Items>
                                    <telerik:RadComboBoxItem Value="Outsourced" Text="Outsourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab8" runat="server" ControlToValidate="DDL_Lab8" ForeColor="Red" ErrorMessage="Please Select Cytology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="table_space">Immunology  </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Lab9" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Any One" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                <Items>
                                    <telerik:RadComboBoxItem Value="Outsourced" Text="Outsourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Lab9" runat="server" ControlToValidate="DDL_lab9" ForeColor="Red" ErrorMessage="Please Select Immunology" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
            </table>
                    </div>--%>
            <div class="form-group">
                     <table style="border:1px solid #f2f1f1; padding:10px; ">
                <tr>
                    <th class="table_space" style="width:190px;">Radiology </th>
                    <th class="table_space" style="width:220px;">Status </th>
                    <th class="table_space" style="width:220px;">Services </th>
                </tr>
                <tr>
                    <td class="table_space">X-ray <span class="mandatory">*</span></td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad1" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                             
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad1" runat="server" ControlToValidate="DDL_Rad1" ForeColor="Red" ErrorMessage="Please Select X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad1" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad1" runat="server" ControlToValidate="DDL_SRad1" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Digital X-ray<span class="mandatory">*</span> </td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Rad2" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad2" runat="server" ControlToValidate="DDL_Rad2" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad2" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad2" runat="server" ControlToValidate="DDL_SRad2" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Ultra Sound <span class="mandatory">*</span></td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad3" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad3" runat="server" ControlToValidate="DDL_Rad3" ForeColor="Red" ErrorMessage="Please Select Ultra Sound" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad3" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad3" runat="server" ControlToValidate="DDL_SRad3" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Color Doppler <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Rad4" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                               <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad4" runat="server" ControlToValidate="DDL_Rad4" ForeColor="Red" ErrorMessage="Please Select Color Doppler" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad4" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad4" runat="server" ControlToValidate="DDL_SRad4" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Mammogram <span class="mandatory">*</span></td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad5" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad5" runat="server" ControlToValidate="DDL_Rad5" ForeColor="Red" ErrorMessage="Please Select Mammogram" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad5" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad5" runat="server" ControlToValidate="DDL_SRad5" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="table_space">CT Scan <span class="mandatory">*</span></td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad6" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                             <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad6" runat="server" ControlToValidate="DDL_Rad6" ForeColor="Red" ErrorMessage="Please Select CT Scan" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad6" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad6" runat="server" ControlToValidate="DDL_SRad6" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">MRI  <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Rad7" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad7" runat="server" ControlToValidate="DDL_Rad7" ForeColor="Red" ErrorMessage="Please Select MRI" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad7" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad7" runat="server" ControlToValidate="DDL_SRad7" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">PET Scan  <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Rad8" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                               <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad8" runat="server" ControlToValidate="DDL_Rad8" ForeColor="Red" ErrorMessage="Please Select PET Scan" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad8" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad8" runat="server" ControlToValidate="DDL_SRad8" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Nuclear Imaging  <span class="mandatory">*</span></td>
                    <td class="table_space">
                             <telerik:RadComboBox ID="DDL_Rad9" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                               <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad9" runat="server" ControlToValidate="DDL_Rad9" ForeColor="Red" ErrorMessage="Please Select Nuclear Imaging" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad9" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad9" runat="server" ControlToValidate="DDL_SRad9" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">ECG <span class="mandatory">*</span> </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad10" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">

                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                               
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad10" runat="server" ControlToValidate="DDL_Rad10" ForeColor="Red" ErrorMessage="Please Select ECG" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad10" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad10" runat="server" ControlToValidate="DDL_SRad10" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">PFT <span class="mandatory">*</span> </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad11" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                             
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                              
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad11" runat="server" ControlToValidate="DDL_Rad11" ForeColor="Red" ErrorMessage="Please Select PFT" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad11" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad11" runat="server" ControlToValidate="DDL_SRad11" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">TMT <span class="mandatory">*</span> </td>
                    <td class="table_space">
                              <telerik:RadComboBox ID="DDL_Rad12" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                             
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />                             
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                                
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_Rad12" runat="server" ControlToValidate="DDL_Rad12" ForeColor="Red" ErrorMessage="Please Select TMT" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad12" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad12" runat="server" ControlToValidate="DDL_SRad12" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="table_space">2D Echo  <span class="mandatory">*</span></td>
                   <td class="table_space">
                            <telerik:RadComboBox ID="DDL_Rad13" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                         <asp:RequiredFieldValidator ID="RequiredField_Rad13" runat="server" ControlToValidate="DDL_Rad13" ForeColor="Red" ErrorMessage="Please Enter Fluoroscopy" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad13" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad13" runat="server" ControlToValidate="DDL_SRad13" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table_space">Fluoroscopy	 <span class="mandatory">*</span> </td>
                    <td class="table_space">
                            <telerik:RadComboBox ID="DDL_Rad14" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                        <telerik:RadComboBoxItem Value="No" Text="No" />
                                </Items>
                            </telerik:RadComboBox>
                         <asp:RequiredFieldValidator ID="RequiredField_Rad14" runat="server" ControlToValidate="DDL_Rad14" ForeColor="Red" ErrorMessage="Please Enter Fluoroscopy" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                      <td class="table_space">
                             <telerik:RadComboBox ID="DDL_SRad14" runat="server" RenderMode="Lightweight" CssClass="Combo2" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="SaveFrame">
                              
                                <Items>
                                        <telerik:RadComboBoxItem Value="In House" Text="In House" />
                                        <telerik:RadComboBoxItem Value="Out Sourced" Text="Out Sourced" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredField_SRad14" runat="server" ControlToValidate="DDL_SRad14" ForeColor="Red" ErrorMessage="Please Select Digital X-ray" Enabled="true"  ValidationGroup="SaveFrame" InitialValue="Select Any One"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
                    </div>
        </div>
       <%-- <div id="ListOfDoctor" runat="server" visible="true" class="form-group" style="padding:10px; margin-top:320px; background-color:white; display:none;">
            List of Doctors with OPD Timings and Fees attached  <asp:CheckBox ID="CheckBox1" runat="server" />
        </div>--%>
        <div id="AccountNumber" runat="server" visible="true" class="form-group" style="padding:10px; height:auto; margin-top:30px; border-radius:5px;">
              <h4>Hospital Bank Details</h4>
            <hr />
            <div class="col-md-4">
                        <label>Bank Account Number  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_accountno" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvaccountno" runat="server" ControlToValidate="txt_accountno" ForeColor="Red" ErrorMessage="Please Enter Bank Account No" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-md-4">
                        <label>Account Holder Name <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_nameofholder" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredField_nameofholder" runat="server" ControlToValidate="txt_nameofholder" ForeColor="Red" ErrorMessage="Please Enter Account Holder Name" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                         </div>
                    </div>
        <%--    <div class="col-md-4">
                        <label>Designation of Account Holder  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_designation" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>--%>
            <div class="col-md-4">
                        <label>Bank Name  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_bankname" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div><br /><br />
                    </div>
            <div class="col-md-4">
                        <label>Branch  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_branch" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>IFSC Code   <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_ifsccode" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvifsccode" runat="server" ControlToValidate="txt_ifsccode" ForeColor="Red" ErrorMessage="Please Enter IFSC Code" Enabled="true"  ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-4">
                        <label>Upload Cancelled Cheque  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <asp:FileUpload ID="FileUploadCancelCheque" runat="server" class="form-control required" ValidationGroup="SaveFrame"  /> 
                            <asp:RequiredFieldValidator ID="RequiredField_CancelCheque" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadCancelCheque" ForeColor="Red" ValidationGroup="SaveFrame" ></asp:RequiredFieldValidator>
                            <asp:Label ID="lblUpload19" runat="server" ForeColor="#006666"></asp:Label>

                         </div>
                
                    </div>
            <%--<div class="col-md-4">
                        <label>Bank letter confirming  </label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadBankLetter" runat="server" class="form-control required" />
                             <asp:Label ID="lblUpload20" runat="server" ForeColor="#006666"></asp:Label>
                        </div>
                    </div>--%>
        </div>
        <div id="SaveContinue" runat="server" visible="true" class="form-group" style="padding-left:10px; padding-right:10px; margin-top:240px; background-color:white; text-align:center;">
            <asp:Button ID="btnSaveContinue" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Save & Continue" type="submit" value="Save & Continue" CssClass="Login_btn btn" OnClick="btnSaveContinue_Click" ValidationGroup="SaveFrame" />&nbsp;&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" Visible="false" /><br />
            <asp:Label ID="lblInsert" runat="server" ></asp:Label>
            <asp:Label ID="lblURL" runat="server" Visible="false" ></asp:Label><asp:Label ID="lbl_dc_id" runat="server" Visible="false" ></asp:Label><asp:Label ID="li" ForeColor="Red" runat="server" Visible="false" ></asp:Label>
            
        </div>
        <div id="UploadDocs" runat="server" visible="false" class="form-group" style="padding:10px;">
            <span style="padding:7px; background-color:#0869b1; color:white; text-align:center; width:100%;">Service Provider Details</span>
            <h4>Upload Service Provider Documents </h4>
            
            <div class="form-group" style="padding:20px; margin-top:0px; border-radius:4px; border:1px solid #242424;">
         
                        <label>Update DC Document  :  <span class="mandatory" style="font-size:11px;">(You can select Max 10 Document only JPG, JPEG, PNG( maximum 1 MB each))</span></label>
                        <div class="selector col-md-6">
                             <asp:FileUpload ID="FileUploadDCImage" runat="server" class="form-control required" AllowMultiple="true" />
                            <asp:Label ID="lblDCImage" runat="server" ForeColor="#006666"></asp:Label>
                         </div>
            <div class="form-group" style="margin-top:50px;">
                
                <asp:Button ID="btnUploadnow" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Upload Now" type="submit" value="Upload Now" CssClass="Login_btn btn" OnClientClick="ValidateFile2()" OnClick="btnUploadnow_Click" CausesValidation="false"/><br />
                <asp:Label ID="lblDCUpload" runat="server" ForeColor="#006666"></asp:Label>
            </div>
                   
            </div>
            
        </div>
        <div id="DocumentUpload" runat="server" visible="false" class="form-group" style="padding:10px;">
            <asp:Label ID="lbldc_id" runat="server" Visible="false" ></asp:Label>
            <h4>Document Upload </h4>
            
            <div class="form-group" style="padding:20px; margin-top:0px; border-radius:4px; border:1px solid #242424;">
            
            <div class="form-group" style="margin-top:10px; height:100px;">
                    <div class="col-md-6">
                        <label>List of Provider Branch(s) :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadLPBranch" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload1" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Registration Certificate :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadRCertificate" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_RegistrationCertificate" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadRCertificate" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:Label ID="lblUpload2" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                
            </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>BIO Medical Waste Management certificate/ Agreement :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadBIOcertificate" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload3" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Building permit :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadBPermit" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload4" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>Fire safety license :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadFSLicense" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload5" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Pre-Natal Diagnostic Techniques (PNDT) License :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadPNDTLicense" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload6" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;" >
            <div class="col-md-6">
                        <label>Radiation Protection Certification :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadRPCertification" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload7" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>No Objection from Pollution control :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadNOFPControl" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload8" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>NABH / NABL / ISO / JCI / Other :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadNNIJOther" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_NNIJOther" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadNNIJOther" ForeColor="Red"></asp:RequiredFieldValidator>  
                            <asp:Label ID="lblUpload9" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Cancelled cheque / Bank Statement / Passbook :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadCCBSPassbook" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:RequiredFieldValidator ID="RequiredField_CCBSPassbook" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadCCBSPassbook" ForeColor="Red"></asp:RequiredFieldValidator>
                             <asp:Label ID="lblUpload10" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>PAN Card :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadPCard" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_PCard" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadPCard" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:Label ID="lblUpload11" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>NEFT Declaration form (RTGS/NEFT Payment Authorization Form) :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadNDPAForm" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload12" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>GST certificate :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadGSTCertificate" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload13" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Hospital OPD Tariff :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadHOPDTariff" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_HOPDTariff" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadHOPDTariff" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:Label ID="lblUpload14" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>List of TPA / Insurance company with which provider is registered :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadListTICRegistered" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_ListTICRegistered" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadListTICRegistered" ForeColor="Red"></asp:RequiredFieldValidator>
                             <asp:Label ID="lblUpload15" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>List of Consultants :  <span class="mandatory" >*</span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadListConsultants" runat="server" class="form-control required" BorderStyle="None" />
                            <asp:RequiredFieldValidator ID="RequiredField_ListConsultants" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadListConsultants" ForeColor="Red"></asp:RequiredFieldValidator>
                             <asp:Label ID="lblUpload16" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>                
            <div class="form-group" style="margin-top:10px; height:100px;">
            <div class="col-md-6">
                        <label>OPD Schedule for Consultants :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadOPDSConsultants" runat="server" class="form-control required" BorderStyle="None" />
                            <%--<asp:RequiredFieldValidator ID="RequiredField_OPDSConsultants" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="FileUploadOPDSConsultants" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                            <asp:Label ID="lblUpload17" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
            <div class="col-md-6">
                        <label>Any other Documents (Specify) :  <span class="mandatory" ></span></label>
                        <div class="selector">
                             <asp:FileUpload ID="FileUploadAODocuments" runat="server" class="form-control required" BorderStyle="None" />
                             <asp:Label ID="lblUpload18" runat="server" ForeColor="#006666"></asp:Label><br />
                             
                         </div>
            </div>
                </div>                 
            <div class="form-group" runat="server" style="margin-top:50px;">
                <asp:Button ID="btnUploadnow1" BackColor="#0869b1" ForeColor="white" BorderStyle="None" runat="server" Text="Upload Now" type="submit" value="Upload Now" CssClass="Login_btn btn" OnClick="btnUploadnow1_Click"/><br />
                <asp:Label ID="lblupload" runat="server" ></asp:Label>
            </div>
                   
            </div>
            
        </div>
        <div id="Previous" runat="server" visible="true" class="form-group" style="margin-top:2px; float:right;">
                <asp:Button ID="btnPrevious" runat="server" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Previous" type="submit" value="Previous" CssClass="Login_btn btn" PostBackUrl="~/diagnostic_center/AddNewDc.aspx" CausesValidation="false"/>
            </div>
            </div> 
                      <div id="MyPopup" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                     
                                        <h4 class="modal-title">Network Manager Contact Details</h4>
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
                      <div class="modal fade" id="myModal" role="dialog" >
        <div class="modal-dialog" style="width:600px;" >
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <div class="modal-header">
                                     
                <button type="button" class="close" data-dismiss="modal">&times;</button>
           <h4 class="modal-title">Network Manager Contact Details</h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <p><i class="glyphicon glyphicon-envelope"></i>  hello@welleazy.com</p><br />
                    <p><i class="glyphicon glyphicon-earphone"></i>  +91-88840 00687</p>
           
                    </div>
            </div>
            <div class="modal-footer">
              <%--<button type="button" class="btn btn-default" style="background-color:#113d7a; color:white; border-style:none;" data-dismiss="modal" >Close</button>--%>
            </div>
          </div>
      
        </div>
      </div>
      </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="DDL_Typeofprovider"  />
             <asp:PostBackTrigger ControlID="DDL_State" />
             <asp:PostBackTrigger ControlID="btnSaveContinue"  />
             <asp:PostBackTrigger ControlID="btnUploadnow" />
             <asp:PostBackTrigger ControlID="btnUploadnow1"  />
             <asp:PostBackTrigger ControlID="btnPrevious" />
         </Triggers>
        </asp:UpdatePanel>
       <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",2000);
 }
</script>
</asp:Content>