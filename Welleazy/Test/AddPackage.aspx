<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPackage.aspx.cs" Inherits="Welleazy.Test.AddPackage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Test Management | Add Package</title>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:250px;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Test/Test_Package.aspx"  ForeColor="#0033cc">Test Package List</asp:LinkButton> >> Add Package</h5>
                                   <div class="line"></div>
        <div class="form-group" style="padding:10px;">
           
            <div class="col-md-3">
                        <label>Client Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_CorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DDL_CorporateName_SelectedIndexChanged" CausesValidation="false" ValidationGroup="Package">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="DDL_CorporateName" ForeColor="Red" ErrorMessage="Please Select Client Name" ValidationGroup="Package" InitialValue="Select Client Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
            
          <div class="col-md-3">
                        <label>Product SKU  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_SKUCode" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Package"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvSKUCode" runat="server" ControlToValidate="txt_SKUCode" ForeColor="Red" ErrorMessage="Please Enter SKU Code" Enabled="true" ValidationGroup="Package"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            <div class="col-md-3">
                        <label>Package Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_PackageName" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Package"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPackageName" runat="server" ControlToValidate="txt_PackageName" ForeColor="Red" ErrorMessage="Please Enter Package Name" Enabled="true" ValidationGroup="Package"></asp:RequiredFieldValidator>
                        </div>
                
                    </div>
       
            <div class="col-md-3">
                        <label>Test Included  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbTestIncluded" RenderMode="Lightweight" CheckBoxes="true" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Package">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Test" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvTestIncluded" runat="server" ControlToValidate="rcbTestIncluded" ForeColor="Red" ErrorMessage="Please Select Test" ValidationGroup="Package" InitialValue="Select Test"></asp:RequiredFieldValidator>
                            </div>
                <br />
                    </div>
            <div class="col-md-3">
                        <label>Normal Test Price </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_NormalPackagePrice" runat="server" TextMode="Number" class="form-control required"></asp:TextBox><br />
                            </div>
                    </div>
            
            
        </div>
        <div class="form-group" style="padding:10px;">
           <div class="col-md-3">
                        <label>HNI Test Price </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_HNIPackagePrice" runat="server" TextMode="Number" class="form-control required"></asp:TextBox>
                           </div>
               
                    </div>
            <div class="col-md-3">
                        <label>Status  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="DDL_Status" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Package">
                                <Items>
                                        <telerik:RadComboBoxItem Value="MyDefaultValue" Text="Select Status" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Active" Text="Active" />
                                </Items>
                                <Items>
                                        <telerik:RadComboBoxItem Value="Disabled" Text="Disabled" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="DDL_Status" ForeColor="Red" ErrorMessage="Please Select Status" Enabled="true" ValidationGroup="Package" InitialValue="Select Status"></asp:RequiredFieldValidator>
                         </div>
                <br />
                    </div>
            <div class="col-md-4">
                        <label>Remark </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Remark" runat="server" TextMode="MultiLine" class="form-control required"></asp:TextBox>

                        </div>
                <br />
                    </div>
            
        </div>
        <div class="form-group" style="padding:10px; text-align:center;">
           
           <div class="col-md-12">
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Package" />
           &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel"/>
                
            </div>
        </div>
         </div>
         </ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
                <asp:PostBackTrigger ControlID="btnCancel" />
            </Triggers>
        </asp:UpdatePanel>
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
      <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",2000);
 }
</script>
</asp:Content>
