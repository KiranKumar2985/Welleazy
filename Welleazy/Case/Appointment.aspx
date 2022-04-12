<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="Welleazy.Case.Appointment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Management | Appointment</title>
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
        function deleletconfig() {

            var del = confirm("Are you sure you want to delete this record?");
            if (del == true) {

            } else {

            }
            return del;
        }
        </script>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        
              <asp:MultiView runat="server" ID="AppointmentView">

            <asp:View ID="DefaultAppointment" runat="server"> 
                <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> Schedule Appointment</h5>
                <div class="form-group" style="background-color: white; padding: 3px; border: 3px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; ">
                    <div class="form-group" style="padding:10px; overflow:auto;">
                <table runat="server" border="1" style="width:100%; border:1px solid #b7b6b6;" >
                    <tr>
                        <th style="padding:10px; background:#b9fae0; color:Black;">Case Owner Name</th>
                        <th style="padding:10px; background:#b9fae0; color:Black;">Case Id/TA Code</th>
                        <th style="padding:10px; background:#b9fae0; color:Black;">Application No.</th>
                        <th style="padding:10px; background:#b9fae0; color:Black;">Branch</th>
                        <th style="padding:10px; background:#b9fae0; color:Black;">Corporate Name</th>
                    </tr>
                    <tr>
                        <td style="padding:10px;">
                            <asp:Label ID="lblCaseOwnerName" runat="server" ></asp:Label></td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblCaseId" runat="server" ></asp:Label>
                            <asp:Label ID="lblCaseRefId" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="lblEmployeeId" runat="server" Visible="false" ></asp:Label>
                        </td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblApplicationNo" runat="server"></asp:Label></td>
                        <td style="padding:10px;">
                            <asp:Label ID="lblBranchId" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="lblBranch" runat="server" ></asp:Label>
                        </td>
                        <td style="padding:10px;">
                            <telerik:RadComboBox ID="DDLCName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" AutoPostBack="true" Visible="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="lblCorporateName" runat="server" ></asp:Label>
                            <asp:Label ID="lblCity" runat="server" Visible="false" ></asp:Label>

                           
                            </td>
                    </tr>
                </table>
            </div>
                    <div class="form-group" style="padding:10px;">
           
            <div class="col-md-3">
                        <label>City </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbStateList" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" Visible="false">
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select State" />
                                </Items>
                            </telerik:RadComboBox>
                          <telerik:RadComboBox ID="rcbCityList" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case" AutoPostBack="true" OnSelectedIndexChanged="rcbCityList_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                
                                   
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Area/Locality  </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Area" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                             
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Pincode  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <asp:TextBox ID="txt_Pincode" runat="server" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                             
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Appointment Status  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbAppointmentStatus" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Appoint" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Status" />
<%--                                    <telerik:RadComboBoxItem Value="1" Text="Completed" />
                                    <telerik:RadComboBoxItem Value="2" Text="Scheduled" />
                                    <telerik:RadComboBoxItem Value="3" Text="Re-Scheduled" />
                                    <telerik:RadComboBoxItem Value="4" Text="Cancelled" />
                                    <telerik:RadComboBoxItem Value="5" Text="Pending" />--%>

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvAppointmentStatus" runat="server" ControlToValidate="rcbAppointmentStatus" ForeColor="Red" ErrorMessage="Please Select Status" Enabled="true" ValidationGroup="Appoint" InitialValue="Select Status"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            
           <div class="col-md-3">
                        <label>Case Status  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbCaseStatus" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Appoint" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Status" />

                                </Items>
                            </telerik:RadComboBox>
                            <telerik:RadComboBox ID="rcbReportStatus" Filter="Contains" Visible="false" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Status" />
                                    </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseStatus" runat="server" ControlToValidate="rcbCaseStatus" ForeColor="Red" ErrorMessage="Please Select Status" Enabled="true" ValidationGroup="Appoint" InitialValue="Select Status"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                        
            <div class="col-md-3">
                        <label>Appointment Date & Time <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadDateTimePicker ID="dtpAppointmentDate" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" DateInput-DateFormat="yyyy-MM-dd hh:mm:ss" AppendDataBoundItems="true" ValidationGroup="Appoint">
                                
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="rfvdtpAppointmentDate" runat="server" ControlToValidate="dtpAppointmentDate" ForeColor="Red" ErrorMessage="Please Select Date" Enabled="true" ValidationGroup="Appoint"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            
                  <div class="col-md-2">
                        <label>Visit Type </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbVisitType" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="DCAddress">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select" />
                                
                                        <telerik:RadComboBoxItem Value="Center" Text="Center" />

                                    <telerik:RadComboBoxItem Value="Home" Text="Home" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvVisitType" runat="server" ControlToValidate="rcbVisitType" ForeColor="Red" ErrorMessage="Please Select Visit Type" ValidationGroup="DCAddress" InitialValue="Select"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                  <div class="col-md-3">
                        <label>ADHOC/Approval Based </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbApprovalBased" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                
                                        <telerik:RadComboBoxItem Value="No" Text="No" />

                                    <telerik:RadComboBoxItem Value="Yes" Text="Yes" />
                                </Items>
                            </telerik:RadComboBox>
                            
                        </div>
                      <br /><br />
                    </div>
                  <div class="col-md-2">
                        <label>Videography Done </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbVideography" runat="server" RenderMode="Lightweight" CssClass="Combo3" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Appoint" AutoPostBack="true" OnSelectedIndexChanged="rcbVideography_SelectedIndexChanged">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                
                                        <telerik:RadComboBoxItem Value="1" Text="No" />

                                    <telerik:RadComboBoxItem Value="2" Text="Yes" />
                                    <telerik:RadComboBoxItem Value="3" Text="NA" />
                                </Items>
                            </telerik:RadComboBox>
                            <%--<asp:RequiredFieldValidator ID="rfvVideography" runat="server" ControlToValidate="rcbVideography" ForeColor="Red" ErrorMessage="Please Select Status" Enabled="true" ValidationGroup="Appoint" InitialValue="Select"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                  <div id="reason" class="col-md-2" runat="server" visible="true">
                        <label>Reason </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_VideographyReason" runat="server" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                    </div>
        </div>
                    <div class="form-group" style="padding:10px; margin-top:160px;">
                        <div class="col-md-12">
                             <telerik:RadComboBox ID="rcbMedicalTest" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" Visible="false">
                                   <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                    </Items>
                                </telerik:RadComboBox>
                        <label>Individual Test </label>
                        <div class="selector">
                             <asp:CheckBoxList ID="CBL_IndividualList" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:CheckBoxList>
                        </div>
                    </div>
                        <div class="col-md-12">
                        <label>Test Package </label>
                        <div class="selector">
                         <asp:Label ID="LabelPackage" runat="server" Visible="true" ></asp:Label>
                            <asp:CheckBoxList ID="CBL_PackageList" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:CheckBoxList>
                        </div>
                    </div>
            <div class="col-md-4">
                        <label>Comment </label>
                        <div class="selector">
                          <asp:TextBox ID="txt_Comment" runat="server" TextMode="MultiLine" class="form-control required"></asp:TextBox>
                             
                        </div>
                    </div>
            <div class="col-md-4">
                        <label>DC Address  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_DCAddress" runat="server" TextMode="MultiLine" class="form-control required" ReadOnly="true" ValidationGroup="Appoint"></asp:TextBox>
                             <asp:Label ID="LabelDCID" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="LabelDCMobileNo" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="LabelDCName" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="lblReportStatus" runat="server" Visible="false" ></asp:Label>
                        </div>
                <asp:RequiredFieldValidator ID="rfvDCAddress" runat="server" ControlToValidate="txt_DCAddress" ForeColor="Red" ErrorMessage="Please Select Diagnostic Centre" Enabled="true" ValidationGroup="Appoint" InitialValue=""></asp:RequiredFieldValidator>
                    </div>
                       <div class="col-md-3">
                        <label>  </label>
                        <div class="selector">
                             <asp:Button ID="btnDCAddress" Text="Select Diagnostic Center" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" data-toggle="modal" OnClick="btnDCAddress_Click" ValidationGroup="DCAddress" />
                             
                             
                        </div>
                    </div>
                       </div>
                    <div class="form-group" style="padding:10px; margin-top:320px;">
           
           <div class="col-md-4">
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Appoint" Visible="true" />
           &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click"  />
                
            </div>
        </div>
              </div>
            </asp:View>
            <asp:View ID="AddAppointment" runat="server"> 
                <h5>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> Appointment</h5>
               <span style="float:right;"> <asp:LinkButton ID="LinkAddAppointment" runat="server"  BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="LinkAddAppointment_Click" ><b><i class="glyphicon glyphicon-plus"></i> Add Appointment </b></asp:LinkButton></span>
                <div class="form-group" style=" margin-top:50px; overflow:auto;">
                   <h4>Case Details</h4>
                    <hr />
                     <table runat="server" border="1" style="width:100%; border:1px solid #b7b6b6;" >
                    <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Case Owner Name</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelName" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Case Type</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelCaseType" runat="server" ></asp:Label>
                        </td>
                    </tr>
                     
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Customer Profile</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelCustomerProfile" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="LabelCustomerProfile1" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Corporate Name</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelCorporateName" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">City</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelCity" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Escort</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelEscort" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Address</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelAddress" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Case Id</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelCaseId" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Gender</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelGender" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Application Date</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelApplicationDate" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Contact No</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelContactNo" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Individual Test</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelIndividualTest" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Email</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelEmail" runat="server" ></asp:Label>
                        </td>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Package Test</th>
                        <td style="padding:6px;">
                            <asp:Label ID="LabelPackageTest" runat="server" ></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <th style="padding:6px; background:#b9fae0; color:Black;">Case Status</th>
                        <td style="padding:6px;">
                            <%--<asp:Label ID="LabelCaseStatus" runat="server" Visible="false" ></asp:Label>--%>
                             <asp:Label ID="LabelCaseStatus1" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    
                </table>
                    <br />
                      <h4>Appointment Schedule List</h4>
                    <hr />
                    <div class="form-group" style=" margin-top:20px; overflow:auto;">
                        <telerik:RadGrid ID="rgAppointmentDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="rgAppointmentDetails_ItemCommand" OnPageIndexChanged="rgAppointmentDetails_PageIndexChanged" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True"
                    SaveScrollPosition="True" />
            </ClientSettings>
                  <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Action" SortExpression="AppointmentId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkAppointmentId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="20" Width="20" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <%--<asp:LinkButton ID="lnkAppointmentId" runat="server" CausesValidation="false" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentId")%>'></asp:LinkButton>--%>
                                       <asp:Label ID="lblAppointmentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Sr. No."  >
                                   <ItemTemplate>
                                       <asp:Label ID="lblSNo" runat="server" Width="50" Text='<%# Container.DataSetIndex+1 %>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Appointment Date & Time" SortExpression="AppointmentDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAppointmentDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDateTime")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Individual Test Assigned" SortExpression="TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblIndividualTest" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Package Test Assigned" SortExpression="PackageTest">
                                   <ItemTemplate>
                                       <asp:Label ID="lblPackageTest" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PackageTest")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="DC Name" SortExpression="DCName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDCName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DCName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Type of Visit" SortExpression="VisitType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVisitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VisitType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Appointment Status" SortExpression="AppointmentDescription">
                                   <ItemTemplate>
                                       <asp:Label ID="lblAppointmentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentDescription")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Id/TA Code" SortExpression="CaseId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Photo Uploaded" SortExpression="">
                                   <ItemTemplate>
                                     <%--  <asp:Label ID="lblPhotoUploaded" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "")%>' Visible="false">
                                                    </asp:Label>--%>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Photo ID Uploaded" SortExpression="">
                                   <ItemTemplate>
                                       <%--<asp:Label ID="lblPhotoIdUploaded" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "")%>' Visible="false">
                                                    </asp:Label>--%>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Files" SortExpression="">
                                   <ItemTemplate>
                                      <%-- <asp:Label ID="lblFiles" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "")%>' Visible="false">
                                                    </asp:Label>--%>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                        
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="AppointmentList" runat="server">

            </asp:View>
                  </asp:MultiView>
         </div>
              <%--        
                      </ContentTemplate>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
                <asp:PostBackTrigger ControlID="btnCancel" />
                <asp:PostBackTrigger ControlID="rgAppointmentDetails" />
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
    <div class="modal fade" id="myModal" role="dialog" >
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Diagnostic List</h4>
        </div>
        <div class="modal-body">
          <div class="form-group">
            
             <div class="col-md-3">
                   <telerik:RadComboBox ID="rcbDCList" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="rcbDCList_SelectedIndexChanged" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Center" />
                                </Items>
                            </telerik:RadComboBox>
              <div class="col-md-8">
                   <%--<asp:ListView ID="ListView1" runat="server" >   
            <LayoutTemplate>   
                <table id="Table1" runat="server" class="TableCSS" style="border:1px solid black;">   
                    <tr id="Tr1" runat="server" class="TableHeader">   
                        <td id="Td1" runat="server">DC ID</td>   
                        <td id="Td2" runat="server">DC Name</td>   
                        <td id="Td3" runat="server">DC Address</td>   
                        <td id="Td4" runat="server">DC Contact No</td> 
                    </tr>   
                    <tr id="ItemPlaceholder" runat="server">   
                    </tr>   
                    <tr id="Tr2" runat="server">   
                        <td id="Td6" runat="server" colspan="2">   
                            <asp:DataPager ID="DataPager1" runat="server">   
                                <Fields>   
                                    <asp:NextPreviousPagerField ButtonType="Link" />   
                                    <asp:NumericPagerField />   
                                    <asp:NextPreviousPagerField ButtonType="Link" />   
                                </Fields>   
                            </asp:DataPager>   
                        </td>   
                    </tr>   
                </table>   
            </LayoutTemplate>   
            <ItemTemplate>   
                <tr class="TableData">   
                    <td>   
                        <asp:Label  ID="Label1" runat="server" Text='<%# Eval("dc_id")%>'>   
                        </asp:Label>   
                    </td>   
                    <td>   
                        <asp:Label  ID="Label2" runat="server" Text='<%# Eval("center_name")%>'>   
                        </asp:Label>   
                    </td>  
                    <td>   
                        <asp:Label  ID="Label3" runat="server" Text='<%# Eval("address")%>'>   
                        </asp:Label>   
                    </td>  
                    <td>   
                        <asp:Label  ID="Label4" runat="server" Text='<%# Eval("mobile_no")%>'>   
                        </asp:Label>   
                    </td>  
                
                </tr>                   
            </ItemTemplate>   
        </asp:ListView>--%>
              </div>
          </div>
           
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal" >Close</button>
        </div>
      </div>
      
    </div>
  </div>
</div>
    
  <%--  <style type="text/css">  
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
        targetcontrolid="btnDCAddress"
        popupcontrolid="SearchEmployeeDetails"
        backgroundcssclass="modalBackground" />

     <asp:Panel ID="SearchEmployeeDetails" runat="server" CssClass="modalPopup"  align="center" style="display:none; text-align:left;">
         <div class="col-md-3">
                   <telerik:RadComboBox ID="rcbDCList" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="rcbDCList_SelectedIndexChanged" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Center" />
                                </Items>
                            </telerik:RadComboBox>
             <telerik:RadComboBox ID="RadComboBox1" runat="server" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" AppendDataBoundItems="true" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Center" />
                                     <telerik:RadComboBoxItem Value="0" Text="Select 1" />
                                     <telerik:RadComboBoxItem Value="0" Text="Select 2" />
                                     <telerik:RadComboBoxItem Value="0" Text="Select 3" />
                                     <telerik:RadComboBoxItem Value="0" Text="Select 4" />
                                </Items>
                            </telerik:RadComboBox>
            
              </div>
         <br />



                                        <br />
                                        <div style="align-content:center">
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Close" CssClass="login_btn btn" BackColor="Red" ForeColor="white" BorderStyle="None" OnClick="btn_Cancel_Click" CausesValidation="false"/>
                                        </div>
    </asp:Panel>--%>
    <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",3000);
 }
</script>
</asp:Content>
