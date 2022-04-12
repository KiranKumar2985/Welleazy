<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="QCCheckListView.aspx.cs" Inherits="Welleazy.Case.QCCheckListView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>--%>
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Case Management >> QC Check List
             <span style="float:right; font-size:small;">
                    
             </span>
        </h5>
                                   <div class="line"></div>
         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-40px;">
           
            <div class="col-md-3">
                <label>Client Name </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbClientName" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                             <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Corporate" />
                                 </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
               <div class="col-md-3">
                        <label>Application No. </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                        <%--    <asp:TextBox ID="TextBox1" runat="server" placeholder="Email id" TextMode="Email" class="form-control required Combo" ValidationGroup="SaveFrame" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpression_Emailid" runat="server" ErrorMessage="Please Enter Valid Email Id" ForeColor ="Red" ValidationGroup="SaveFrame" ValidationExpression="^[\w!#$%&'*+/=?`{|}~^-]+(?:\.[\w!#$%&'*+/=?`{|}~^-]+)*@↵(?:[A-Z0-9-]+\.)+[A-Z]{2,6}$"  ControlToValidate="TextBox1"></asp:RegularExpressionValidator>
                            \w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*
                            <asp:Button ID="Button1" runat="server" Text="Button" ValidationGroup="SaveFrame"/>--%>
                            </div>
                        
                    </div>
              <div class="col-md-3">
                <label>Appointment Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbAppointmentStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Appointment Status" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            <div class="col-md-3">
                        <label>Case Id/TA Code </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_CaseId" runat="server" placeholder="Case Id/TA Code" TextMode="SingleLine" class="form-control required" ></asp:TextBox>
                            </div>
                        
                    </div>
                 
              <br /><br />
              </div>
         <div runat="server" id="AdvancedSearch" visible="false" class="form-group" style="padding:10px; padding-top:20px; margin-top:-20px; margin-bottom:280px;">
                                   
             <div class="col-md-3">
                        <label>Customer Name </label>
                        <div class="selector">
                            <asp:TextBox ID="txt_EmployeeName" runat="server" placeholder="Customer Name" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                            </div>
                        
                    </div>
            <div class="col-md-3">
                <label>Welnext Branch </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbBranch" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >

                </telerik:RadComboBox>
                            </div>
                            </div>
               
              <div class="col-md-3">
                <label>Assigned Agent </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbAssignedAgent" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Agent" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
            
                   <div class="col-md-3">
                <label>Case Status </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CssClass="Combo" CheckBoxes="true" AppendDataBoundItems="true" runat="server"  >
                                <Items>
                                    <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                </Items>
                </telerik:RadComboBox>
                            </div>
                            </div>
         
             <div class="col-md-3">
                        <label>Updated By </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbUpdatedBy" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select" />
                                </Items>
                            </telerik:RadComboBox>
                            </div>
                    </div>
              <div class="col-md-6">
                        <label>Closed Date </label>
                        <div class="selector">
                           
                            <telerik:RadDateRangePicker ID="rdrpClosedDate" RenderMode="Lightweight" StartDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" EndDatePicker-DateInput-DateFormat="yyyy-MM-dd HH:mm:ss" runat="server" ></telerik:RadDateRangePicker>

                        </div>
                        
                    </div>
              <div class="col-md-3">
                        <label>DC City </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbCitySearch" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select City" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            </div>
                        
                    </div>
             <div class="col-md-3">
                        <label>DC Name </label>
                        <div class="selector">
                            <telerik:RadComboBox ID="rcbDCName" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains"  >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select DC Name" />
                                </Items>
                            </telerik:RadComboBox>
                            </div>
                        
                    </div>
          <div class="col-md-3">
                        <label>Error Type </label>
                        <div class="selector">
                           
                            <telerik:RadComboBox ID="rcbErrorType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" AutoPostBack="true" >
                               <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Error Type" />
                                </Items>
                            </telerik:RadComboBox>

                        </div>
                        
                    </div>
         
             
              </div>
         
         <div runat="server" class="form-group" style="text-align:center; margin-top:20px; padding:10px;" align="center">
             
               <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAdvanced" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Advanced Search" OnClick="btnAdvanced_Click" Width="200" />
                
         
         </div>
         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:10px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">
             <div class="form-group" style="padding:10px; overflow-y:auto;">
                 <telerik:RadGrid ID="rgvQCCheckListView" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                  OnNeedDataSource="rgvQCCheckListView_NeedDataSource" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                     <ClientSettings AllowColumnsReorder="True"></ClientSettings>

                     <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>

                               <telerik:GridTemplateColumn HeaderText="QC Done Date" SortExpression="QCDoneDate">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQCDoneDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QCDoneDate")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Application Number" SortExpression="ApplicationNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblApplicationNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ApplicationNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Id" SortExpression="CaseId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Owner Name" SortExpression="CaseOwnerName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseOwnerName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseOwnerName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Visit Type" SortExpression="VisitType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVisitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VisitType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Branch Name" SortExpression="BranchName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblBranchName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Report Upload By" SortExpression="ReportUploadBy">
                                   <ItemTemplate>
                                       <asp:Label ID="lblReportUploadBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportUploadBy")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Updated By" SortExpression="UpdatedBy">
                                   <ItemTemplate>
                                       <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdatedBy")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Status" SortExpression="CaseStatusName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatusName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Error Type" SortExpression="ErrorDescription">
                                   <ItemTemplate>
                                       <asp:Label ID="lblErrorDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ErrorDescription")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q1_InsuredName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ1_InsuredName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q1_InsuredName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q2_ClientId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ2_ClientId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q2_ClientId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q3_ClientIdNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ3_ClientIdNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q3_ClientIdNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q4_LivePhoto">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ4_LivePhoto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q4_LivePhoto")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q5_FaceMatchScore">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ5_FaceMatchScore" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q5_FaceMatchScore")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q6_AppDateMatch">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ6_AppDateMatch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q6_AppDateMatch")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q7_AppdateMatchIfNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ7_AppdateMatchIfNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q7_AppdateMatchIfNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q8_DCNameMatch">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ8_DCNameMatch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q8_DCNameMatch")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q9_ReportDocSequence">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ9_ReportDocSequence" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q9_ReportDocSequence")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q10_AadharNoMasked">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ10_AadharNoMasked" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q10_AadharNoMasked")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q11_ReportNConvention">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ11_ReportNConvention" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q11_ReportNConvention")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q12_TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ12_TestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q12_TestName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q13_InterAdded">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ13_InterAdded" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q13_InterAdded")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q14_MERDrName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ14_MERDrName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q14_MERDrName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q15_MERDrRegNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ15_MERDrRegNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q15_MERDrRegNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q16_MERDrQualification">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ16_MERDrQualification" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q16_MERDrQualification")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q17_Disclosures">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ17_Disclosures" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q17_Disclosures")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q18_ApplicationNoMER">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ18_ApplicationNoMER" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q18_ApplicationNoMER")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q19_OldApplicationNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ19_OldApplicationNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q19_OldApplicationNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q20_MERDate">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ20_MERDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q20_MERDate")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q21_BPReadingPulseRate">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ21_BPReadingPulseRate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q21_BPReadingPulseRate")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q22_FamilyHistory">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ22_FamilyHistory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q22_FamilyHistory")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q23_SAFFandIdProof">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ23_SAFFandIdProof" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q23_SAFFandIdProof")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q24_SAFFandIdProofException">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ24_SAFFandIdProofException" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q24_SAFFandIdProofException")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q25_HWDAMatchInReport">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ25_HWDAMatchInReport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q25_HWDAMatchInReport")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q26_AllMERQueAns">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ26_AllMERQueAns" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q26_AllMERQueAns")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q27_AnyQueMarkedAsYesMER">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ27_AnyQueMarkedAsYesMER" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q27_AnyQueMarkedAsYesMER")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q28_RemarkGivenAsYes">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ28_RemarkGivenAsYes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q28_RemarkGivenAsYes")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q29_VerifiedMER">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ29_VerifiedMER" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q29_VerifiedMER")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q30_ReflexiveTest">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ30_ReflexiveTest" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q30_ReflexiveTest")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q31_TestComponentLIP">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ31_TestComponentLIP" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q31_TestComponentLIP")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q32_TestComponentLFT">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ32_TestComponentLFT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q32_TestComponentLFT")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="" SortExpression="Q33_WearFaceMask">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQ33_WearFaceMask" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Q33_WearFaceMask")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
                 </div>
             </div>
         </div>
    
</asp:Content>
