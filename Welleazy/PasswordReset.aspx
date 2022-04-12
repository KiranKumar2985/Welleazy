<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Welleazy.PasswordReset" EnableEventValidation="false" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h4>Reset Password<span style="float:right;"><asp:Button ID="btnGoBack" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Go Back" type="submit" value="Go Back" CssClass="Login_btn btn" OnClientClick="JavaScript:window. history. back(1); return false;"/></span></h4>
                                   <div class="line"></div>
        
    <div runat="server" align="center">   
    <div class="form-group" style="padding-left:10px; padding-right:10px; text-align:center; ">
        <div class="col-md-3"><label>Old Password <span class="mandatory">*</span></label></div>
        <div class="col-md-9"><asp:TextBox ID="txt_oldpass" runat="server" TextMode="Password" class="form-control required" ></asp:TextBox></div><br />
        
         <br />               
       
    </div>
    <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:50px; text-align:center;">
        <div class="col-md-3"><label>New Password <span class="mandatory">*</span></label></div>
        <div class="col-md-9"><asp:TextBox ID="txt_newpass" runat="server" TextMode="Password" class="form-control required"></asp:TextBox></div>
         <br />          
    </div>
    <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:50px; text-align:center;" >
        <div class="col-md-3"><label>Confirm Password <span class="mandatory">*</span></label></div>
        <div class="col-md-9"><asp:TextBox ID="txt_confirmpass" runat="server" TextMode="Password" class="form-control required"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Confirm password is different!" ControlToValidate="txt_confirmpass" ForeColor="Red" ControlToCompare="txt_newpass"></asp:CompareValidator></div>
    <br />
    </div>
    <div class="form-group" style="padding-left:10px; padding-right:10px; margin-top:40px; background-color:white; text-align:center;">
            <asp:Button ID="btnreset" BackColor="#113d7a" ForeColor="white" BorderStyle="None" runat="server" Text="Reset Password" type="submit" value="Reset Password" CssClass="Login_btn btn" OnClick="btnreset_Click"/><br /><br />
        <asp:Label ID="ChangeMsg" runat="server" ></asp:Label>
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label><asp:Label ID="LabelConvert" runat="server" Visible="false"></asp:Label>
        </div>

       </div>
    </div>
</asp:Content>
