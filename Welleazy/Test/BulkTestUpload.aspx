<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BulkTestUpload.aspx.cs" Inherits="Welleazy.Test.BulkTestUpload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>  
    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
</script>
      <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -25px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
           <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Test/Individual_Test.aspx"  ForeColor="#0033cc">Individual Test List</asp:LinkButton> >> Bulk Upload
          <span style="float:right;"><asp:Button ID="btnExport" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Format" OnClick="btnExport_Click" runat="server" /></span></h5>
                                   <div class="line"></div>  
          <label class="mandatory" style="font-size:small;"> **Please Download Individual Upload format and enter every test according to Format and upload respective Corporate Name with Carefully</label><br /> 
          <h4>Bulk Test Details Upload</h4>     
          <asp:MultiView ID="UploadTestData" runat="server">
              
              <asp:View ID="UploadTestDetail" runat="server">
                 <div class="form-group" style="margin-top:20px;">
                     <div class="col-md-3">
                        <label>Client Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            <telerik:RadComboBox ID="DDL_CorporateName" RenderMode="Lightweight" Filter="Contains" CssClass="Combo" runat="server" AppendDataBoundItems="true" DataTextField="CorporateName" DataValueField="CorporateId" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Client Name" />
                                </Items>
                            </telerik:RadComboBox>
                           
                            <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="DDL_CorporateName" ForeColor="Red" ErrorMessage="Please Select Client Name" ValidationGroup="Test" InitialValue="Select Client Name"></asp:RequiredFieldValidator>
                            
                         </div>
                    </div>
                     <div class="col-md-4">
                         <label> Test Details (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadTestDocument" RenderMode="Lightweight" runat="server" Height="17px" Width="210px" Skin="WebBlue" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                             </div>
                     </div>
                     <div class="col-md-4">
                         <label> </label>
                         <div class="selector">
                         <asp:button ID="btnUpload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Upload" OnClick="btnUpload_Click"></asp:button>
                             </div>
                     </div>
                   </div>

              </asp:View>
          </asp:MultiView>
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
            <script type="text/javascript">
function delayRedirect(url)
 {
 var Timeout = setTimeout("window.location='" + url + "'",3000);
 }
</script>
</asp:Content>
