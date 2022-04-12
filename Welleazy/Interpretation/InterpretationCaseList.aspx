<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="InterpretationCaseList.aspx.cs" Inherits="Welleazy.Interpretation.InterpretationCaseList" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Second Opinion | Open Case List</title>
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
     <div class="form-group" style="background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
        <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Second Opinion >> Open Second Opinion Case List
            <span style="float:right; font-size:small;"><asp:LinkButton ID="Linkspl1" runat="server" PostBackUrl="~/Interpretation/AddCase.aspx" ForeColor="#0033cc"><b><i class="glyphicon glyphicon-plus"></i></b> Add Case</asp:LinkButton></span>
        </h5>
                                   
         <div class="line"></div>

         <div class="form-group" style="padding:10px; padding-top:20px; margin-top:-40px; ">
             <div class="col-md-3">
                        <label>Case Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                            
                            <telerik:RadComboBox ID="rcbCaseType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Type" />
                                        <telerik:RadComboBoxItem Value="1" Text="Interpretation" />
                                        <telerik:RadComboBoxItem Value="2" Text="Digitization" />
                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvCaseType" runat="server" ControlToValidate="rcbCaseType" ForeColor="Red" ErrorMessage="Please Select CaseType" Enabled="true" ValidationGroup="Case" InitialValue="Select CaseType"></asp:RequiredFieldValidator>
                         </div>
                    </div>
            <div class="col-md-3">
                    <label>Client Name </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbCorporate" Filter="Contains" CheckBoxes="true" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" runat="server"  >
                                 <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Corporate" />
                                     </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
               
                  <div class="col-md-3">
                    <label>Case Status </label>
                            <div class="selector">
                                <telerik:RadComboBox ID="rcbCaseStatus" Filter="Contains" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" runat="server" >
                                    <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Case Status" />
                                    </Items>
                    </telerik:RadComboBox>
                                </div>
                                </div>
            <div class="col-md-3">
                        <label>Interpretation Type </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbInterpretationType" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Interpretation Type" />
                                </Items>
                             </telerik:RadComboBox>
                           
                         </div><br />
           
                    </div>
             <div class="col-md-3">
                        <label>Doctor List </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="rcbDoctorList" runat="server" RenderMode="Lightweight" CheckBoxes="true" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Doctor" />
                                </Items>
                             </telerik:RadComboBox>
                            
                         </div>
               
                    </div>
                      <div class="col-md-3">
                            <label>Application No. </label>
                            <div class="selector">
                                <asp:TextBox ID="txt_ApplicationNo" runat="server" placeholder="Application No" TextMode="SingleLine" class="form-control required Combo" ></asp:TextBox>
                                </div>
                        
                        </div>
                
              </div>
         <div runat="server" class="form-group" style="text-align:center; margin-top:140px; padding:10px; " align="center">
             
                   <asp:Button ID="btnGo" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnGo_Click" Text="Go" Width="100" />
             </div>
         <div class="form-group" style="padding-top:20px; margin-top:10px;  border:3px solid #e1e1e1; border-bottom-style:none; border-left-style:none; border-right-style:none;">
             
                 <span style="float:left; padding-left:10px;">
                     <telerik:RadComboBox ID="cmbExport" RenderMode="Lightweight" CssClass="Combo_Export" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbExport_SelectedIndexChanged" CausesValidation="false" >
                          <Items>
                              
                              <telerik:RadComboBoxItem  Value="1" Text="CSV" Selected="true"/>
                              <telerik:RadComboBoxItem  Value="2" Text="Excel"/>
                          </Items>
                      </telerik:RadComboBox>

                      <asp:Button ID="btnDownload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnDownload_Click" Text="Export to CSV"/>
                 </span>
               <span style="float:right; right:0;">
                  <asp:CheckBox ID="chkall" runat="server" onclick="CheckAll(this);" AutoPostBack="false"/>
                    <telerik:RadComboBox ID="cmbAssign" RenderMode="Lightweight" CssClass="Combo2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbAssign_SelectedIndexChanged" CausesValidation="false" data-toggle="modal" >
                          <Items>
                              
                              <telerik:RadComboBoxItem  Value="0" Text="Select Assign Case"/>
                              <telerik:RadComboBoxItem  Value="1" Text="Assign Interpretation"/>
                          </Items>
                      </telerik:RadComboBox>
                   </span>
           
             
          <div class="form-group" style="padding:10px; padding-top:10px; margin-top:10px; float:left; overflow:auto;">
             <telerik:RadGrid ID="rgvInterpretationCaseDetails" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                  OnItemCommand="rgvInterpretationCaseDetails_ItemCommand" OnNeedDataSource="rgvInterpretationCaseDetails_NeedDataSource" OnPageIndexChanged="rgvInterpretationCaseDetails_PageIndexChanged" OnItemDataBound="rgvInterpretationCaseDetails_ItemDataBound" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                   <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true">
                           <Columns>

                               <telerik:GridTemplateColumn HeaderText="" SortExpression="InterpretationCaseId">
                                 
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkInterpretationCaseId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="16" Width="16" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       <%--<telerik:RadCheckBox ID="chkTax" runat="server" oncick="Check(this);" AutoPostBack="false" ></telerik:RadCheckBox>--%>
                                       <asp:CheckBox ID="chkTax" runat="server" onclick="Check(this);" AutoPostBack="false" />
                                       <asp:Label ID="lblInterpretationCaseIdI" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationCaseId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Interpretation Case ID" SortExpression="InterpretationCaseId">
                                   <ItemTemplate>
                                       <asp:Label ID="lblInterpretationCaseId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationCaseId")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Entry Date Time" SortExpression="CaseEntryDateTime">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseEntryDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseEntryDateTime")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Type" SortExpression="CaseType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Corporate Name" SortExpression="CorporateName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCorporateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CorporateName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Rec'd Mode" SortExpression="CaseRecMode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseRecMode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseRecMode")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Customer Name" SortExpression="CustomerName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCustomerName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Application Number" SortExpression="ApplicationNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblApplicationNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ApplicationNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Policy Number" SortExpression="PolicyNo">
                                   <ItemTemplate>
                                       <asp:Label ID="lblPolicyNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PolicyNo")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Interpretation Type" SortExpression="InterpretationTypeText">
                                   <ItemTemplate>
                                       <asp:Label ID="lblInterpretationType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationTypeText")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Case Status" DataField="CaseStatusName" SortExpression="CaseStatusName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblCaseStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatusName")%>'> </asp:Label>
                                           <asp:Label ID="lblCaseStatusId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseStatus")%>' Visible="false"> </asp:Label>
                                                   
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Doctor Name" SortExpression="DoctorName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblDoctorId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DoctorName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="QC Executive Name" SortExpression="name">
                                   <ItemTemplate>
                                       <asp:Label ID="lblQCExecutiveId" runat="server" Text="NA">
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Interpretation Assign Date" SortExpression="InterpretationAssignDate">
                                   <ItemTemplate>
                                       <asp:Label ID="lblInterpretationAssignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InterpretationAssignDate")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="View Report" SortExpression="">
                                   <ItemTemplate>
                                      <asp:Label ID="lblViewReport" runat="server" Text="NA">
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                               </Columns> 
                   </MasterTableView>
              </telerik:RadGrid>
            
          </div>
             </div>
         </div>
                      </ContentTemplate>
    </asp:UpdatePanel>

<script type="text/javascript"> 

    function CheckAll(id) {
            var masterTable = $find("<%= rgvInterpretationCaseDetails.ClientID %>").get_masterTableView();
            var row = masterTable.get_dataItems();
            if (id.checked == true) {
                for (var i = 0; i < row.length; i++) {
                    masterTable.get_dataItems()[i].findElement("chkTax").checked = true;
                }
            }
            else {
                for (var i = 0; i < row.length; i++) {
                    masterTable.get_dataItems()[i].findElement("chkTax").checked = false;
                }
            }
        }
</script> 
<div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" style="padding:10px;">&times;</button>
              <h4 class="modal-title" style="background-color:#e1e1e1; padding:10px;">Assign Doctor</h4>
               
            </div>
            <div class="modal-body">
         
            <div class="col-md-3">
                        <label>Doctor List </label>
                        <div class="selector">
                             <telerik:RadComboBox ID="cmbAssignDoctorList" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Doctor" />
                                </Items>
                             </telerik:RadComboBox>
                            
                         </div>
               
                    </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" Text="Update Assign" />
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
            </div>
          </div>
      
        </div>
      </div>
    <%--<div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" style="padding:10px;">&times;</button>
              <h4 class="modal-title" style="background-color:#e1e1e1; padding:10px;">Assign Doctor</h4>
               
            </div>
            <div class="modal-body">
         
                        <label>Assign Case Successfully! </label>
                        
            <div class="modal-footer">
                
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
      
        </div>
      </div>--%>
</asp:Content>
