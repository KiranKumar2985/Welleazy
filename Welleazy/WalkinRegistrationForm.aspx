<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="WalkinRegistrationForm.aspx.cs" Inherits="Welleazy.WalkinRegistrationForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Welleazy | Walk in Registration</title>
    <link href="../css/GridViewStyle.css" rel="stylesheet" type="text/css" />
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
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" > 
     <ContentTemplate>
     <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <div><h4 style="float:left;">Walk in Registration Form</h4>
             <span style="float:right;">
           <asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/Dashboard.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-home"></i></b> Home</asp:LinkButton>
                 </span>
         </div>            
             <div class="line"></div>
         <asp:MultiView ID="EmployeeView" runat="server">
              <asp:View ID="View" runat="server">
          <div class="form-group">
                               <div class="col-md-3">
                                  <asp:TextBox ID="txt_SEmployeeName" runat="server" placeholder="Employee Name" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                               
                               <div class="col-md-3">
                                   <asp:TextBox ID="txt_SEmployeeId" runat="server" placeholder="Employee ID" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                               <div class="col-md-3">
                                  <asp:TextBox ID="txt_SMobileNo" runat="server" placeholder="Employee Mobile No" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                               </div>
                                <div class="col-md-3">
                                <asp:TextBox ID="txt_SEmailId" runat="server" placeholder="Employee Email" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                    </div>
                     <div class="form-group" style="padding:60px; padding-bottom:0px; text-align:center;">
            
                <asp:Button ID="btnGo" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go to Search" CssClass="Login_btn btn" OnClick="btnGo_Click"/>
             
          
        </div>
              </div>
                  </asp:View>
             <asp:View ID="Save" runat="server">
                 <div class="form-group">
                               <div class="col-md-3">
                                   <label>
                                   Employee Id <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbLoginType" AutoPostBack="true" runat="server" RenderMode="Lightweight" AppendDataBoundItems="true" Filter="Contains"  ValidationGroup="Case" CausesValidation="false">
                                           <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                       </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvLoginType" runat="server" ControlToValidate="cmbLoginType" ForeColor="Red" ErrorMessage="Please Select Login Type" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               
                               <div class="col-md-3">
                                   <label>
                                   Employee Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight" AutoPostBack="true" runat="server" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select Corporate" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Branch Id <span class="mandatory">*</span></label>
                                  
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmdBranchId" RenderMode="Lightweight" runat="server" AppendDataBoundItems="true" Filter="Contains">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="0" Text="Select Branch" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       
                                       <br /><br />
                                   </div>
                               </div>
                                <div class="col-md-3">
                        <label>Product Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AllowCustomText="true" AppendDataBoundItems="true" Filter="Contains" CheckBoxes="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="rcbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                    
              </div>
                 </asp:View>
             </asp:MultiView>
           
           
         </div>
         </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
