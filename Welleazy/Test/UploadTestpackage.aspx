<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="UploadTestpackage.aspx.cs" Inherits="Welleazy.Test.UploadTestpackage" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>        
      <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -25px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:150px;">
           <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Test Management >> <asp:LinkButton ID="LinkIndividual" runat="server" PostBackUrl="~/Test/TestPackage.aspx"  ForeColor="#0033cc">Test Package List</asp:LinkButton> >> Bulk Upload
          <span style="float:right;"><asp:Button ID="btnExport" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Format" OnClick="btnExport_Click" runat="server" /></span></h5>
                                   <div class="line"></div>  
          <label class="mandatory" style="font-size:small;">**For Upload Bulk Test Package Details , Click on below button to Download Format:</label><br /> 
          <h4>Bulk Test Package Upload</h4>    
          <asp:MultiView ID="UploadTestPackageView" runat="server">
              
              <asp:View ID="UploadTestPackage" runat="server">
                 <div class="form-group" style="margin-top:20px;">
                     <div class="col-md-4">
                         <label>Test Package Details (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadTestPackage" runat="server" MaxFileInputsCount="1" CssClass="Combo" RenderMode="Lightweight" ></telerik:RadAsyncUpload>
                             </div>
                     </div>
                     <div class="col-md-6">
                         <label> </label>
                         <div class="selector">
                         <asp:button ID="btnUpload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Upload" OnClick="btnUpload_Click"></asp:button>
                             </div>
                     </div>
                   </div>
                  
              </asp:View>
          </asp:MultiView>
            </div>
            
       
    </asp:Content>
