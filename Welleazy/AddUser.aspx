<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Welleazy.add_user" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add New User | Welleazy</title>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>

    <h5 style="margin-top:-20px;">
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> User Management >> Add New User
            </h5>
        <div class="form-group" style="background-color: white; padding: 3px; margin-top: 10px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        
           
                 <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
           
            <div class="col-md-3">
                        <label>Role </label>
                        <div class="selector">
                 
                            <telerik:RadComboBox ID="DDL_Role" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" DataTextField="name" DataValueField="role_id" AutoPostBack="true" OnSelectedIndexChanged="DDL_Role_SelectedIndexChanged" ValidationGroup="AddUser" CausesValidation="false">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Role" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Role" runat="server" ControlToValidate="DDL_Role" ForeColor="Red" ErrorMessage="Please Select Role" ValidationGroup="AddUser" InitialValue="Select Role"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Sub Role </label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="DDL_SubRole" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="AddUser">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Sub Role" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredField_SubRole" runat="server" ControlToValidate="DDL_SubRole" ForeColor="Red" ErrorMessage="Please Select Sub Role" Enabled="true" ValidationGroup="AddUser" InitialValue="Select Sub Role"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Reporting Person </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_ReportingPerson" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="AddUser">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Reporting Person" />
                                    <telerik:RadComboBoxItem Value="1" Text="Munish Bhatia" />
                                </Items>
                               
                            </telerik:RadComboBox>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Contact </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Contact" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="AddUser"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Contact" runat="server" ControlToValidate="txt_Contact" ForeColor="Red" ErrorMessage="Please Enter Contact" Enabled="true" ValidationGroup="AddUser"></asp:RequiredFieldValidator><br /><br />
                         </div>
                    </div>
        </div>                      
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
           
            <div class="col-md-3">
                        <label>Employee Id </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_EmployeeId" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Name </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Name" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="AddUser"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Name" runat="server" ControlToValidate="txt_Name" ForeColor="Red" ErrorMessage="Please Enter Contact" Enabled="true" ValidationGroup="AddUser"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Email Id </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Email" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="AddUser"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredField_Email" runat="server" ControlToValidate="txt_Email" ForeColor="Red" ErrorMessage="Please Enter Email" Enabled="true" ValidationGroup="AddUser"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpression_Email" runat="server" ErrorMessage="Please Enter Valid Email" ForeColor ="Red" ValidationGroup="AddUser" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_Email"></asp:RegularExpressionValidator>

                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_Status" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="AddUser">
                                <Items>
                                        <telerik:RadComboBoxItem Value="1" Text="Pending" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="2" Text="Approved" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="3" Text="Rejected" />
                                </Items>
                            </telerik:RadComboBox>
                            <br /><br /><br />
                         </div>
                    </div>
        </div>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
           
            <%--<div class="col-md-3">
                        <label>Designation </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Designation" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>--%>
            <div class="col-md-3">
                        <label>Department </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Department" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>
           <%-- <div class="col-md-3">
                        <label>Function </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Function" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                         </div>
                    </div>--%>
            <div class="col-md-3">
                        <label>Work Location </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_WorkLocation" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox><br /><br />
                         </div>
                    </div>
        </div>
        <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:10px;">
           
            <div class="col-md-3">
                        <label>State </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_State" runat="server" CheckBoxes="true" RenderMode="Lightweight" EnableCheckAllItemsCheckBox="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged">
                              
                            </telerik:RadComboBox>
                         <br />

                        </div>
                    </div>
            <br />
            <div class="col-md-3">
                        <label>Welnext Branch </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_WelnextBranch" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains">
                              
                            </telerik:RadComboBox>
                             <br />
                         </div>
                    </div>

            <div class="col-md-3">
                        <label>Joining Date </label>
                        <div class="selector">
                             <telerik:RadDatePicker ID="dtpJoiningDate" runat="server"></telerik:RadDatePicker>
                         </div>
                    </div>
            <div class="col-md-3">
                        <label>Relieving Date </label>
                        <div class="selector">
                            <telerik:RadDatePicker ID="dtpRelievingDate" runat="server"></telerik:RadDatePicker>
                             
                         </div>
                    </div>
           
        </div>
         
        <div class="form-group">
        <div class="" style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Save" type="submit" value="Save" CssClass="Login_btn btn" OnClick="btnSave_Click" ValidationGroup="AddUser"/>&nbsp;&nbsp;&nbsp;
            <%--<asp:Button ID="btnUpdate" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Update" type="submit" value="Update" CssClass="Login_btn btn"/>&nbsp;&nbsp;&nbsp;--%>
            <asp:Button ID="btnCancel" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Cancel" type="submit" value="Cancel" CssClass="Login_btn btn" OnClick="btnCancel_Click"/>
            <asp:Label ID="Label1" runat="server" ></asp:Label>
        </div>
           </div>
        
        </div>
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
                      </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="DDL_Role"  />
             <asp:PostBackTrigger ControlID="DDL_State" />
             <asp:PostBackTrigger ControlID="btnSave"  />
             <asp:PostBackTrigger ControlID="btnCancel" />
         </Triggers>
        </asp:UpdatePanel>
</asp:Content>
