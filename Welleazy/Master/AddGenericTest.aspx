<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddGenericTest.aspx.cs" Inherits="Welleazy.Master.AddGenericTest" %>
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
      <div class="form-group" style="background: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none; margin-bottom:200px;">
            <h4>Master Generic Test 
           <span style="float:right;">
           <asp:LinkButton ID="btnTest" runat="server" BackColor="#113d7a" BorderStyle="None" CssClass="Login_btn btn" ForeColor="white" OnClick="btnTest_Click" ><b><i class="glyphicon glyphicon-plus"></i> Add Generic Test </b></asp:LinkButton></span>
         </h4>
           
           <div class="line"></div>       
          <asp:MultiView ID="GenericTestView" runat="server">
              <asp:View ID="View" runat="server">
                  <div class="form-group" style="overflow:auto;">
                  <telerik:RadGrid ID="rgvGenericTest" runat="server" AutoGenerateColumns="false" EnableTheming="true" CellPadding="4" BackColor="White" BorderColor="#3366CC" 
                      BorderStyle="None" BorderWidth="1px" AllowPaging="True" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" 
                      HeaderStyle-ForeColor="White" OnItemCommand="rgvGenericTest_ItemCommand" OnNeedDataSource="rgvGenericTest_NeedDataSource" OnPageIndexChanged="rgvGenericTest_PageIndexChanged">
                      <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                          <Columns>
                              <telerik:GridTemplateColumn HeaderText="Action" SortExpression="GenericTestId">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="lnkGenericTestId" runat="server" ImageUrl="~/images/edit-icon (1).png" Height="16" Width="16" CommandArgument="<%# (Container.ItemIndex).ToString() %>" CommandName="EditRow" />
                                       
                                       <asp:Label ID="lblGenericTestId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GenericTestId")%>' Visible="false"></asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                                              
                               <telerik:GridTemplateColumn HeaderText="Visit Type" SortExpression="VisitType">
                                   <ItemTemplate>
                                       <asp:Label ID="lblVisitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VisitType")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               
                               <telerik:GridTemplateColumn HeaderText="Test Name" SortExpression="TestName">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestName")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Test Code" SortExpression="TestCode">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTestCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TestCode")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="Normal Price" SortExpression="NormalPrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblNormalPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NormalPrice")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="HNI Price" SortExpression="HNIPrice">
                                   <ItemTemplate>
                                       <asp:Label ID="lblHNIPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HNIPrice")%>'>
                                                    </asp:Label>
                                   </ItemTemplate>
                               </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Is Active" SortExpression="IsActive">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                          </Columns>
                      </MasterTableView>

                  </telerik:RadGrid>
                  </div>
              </asp:View>
              <asp:View ID="Save" runat="server">
                  <div class="form-group" style="padding:10px;">
           
                      <div class="col-md-3">
                        <label>Visit Type  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <telerik:RadComboBox ID="DDL_VisitType" runat="server" RenderMode="Lightweight" CssClass="Combo" AppendDataBoundItems="true" Filter="Contains" ValidationGroup="Test">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Visit Type" />
                                </Items>
                                 <Items>
                                        <telerik:RadComboBoxItem Value="Home" Text="Home" />
                                        <telerik:RadComboBoxItem Value="Center" Text="Center" />
                                </Items>
                                
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvVisitType" runat="server" ControlToValidate="DDL_VisitType" ForeColor="Red" ErrorMessage="Please Select Visit Type" Enabled="true" ValidationGroup="Test" InitialValue="Select Visit Type"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                      <div class="col-md-3">
                        <label>Test Name  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_TestName" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvTestName" runat="server" ControlToValidate="txt_TestName" ForeColor="Red" ErrorMessage="Please Enter Test Name" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                      <div class="col-md-3">
                        <label>Test Code  <span class="mandatory">*</span></label>
                        <div class="selector">
                             <asp:TextBox ID="txt_TestCode" runat="server" TextMode="SingleLine" class="form-control required" ValidationGroup="Test"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvTestCode" runat="server" ControlToValidate="txt_TestCode" ForeColor="Red" ErrorMessage="Please Enter Test Code" Enabled="true" ValidationGroup="Test"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                      <div class="col-md-3">
                        <label>Normal Test Price </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_NormalPrice" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox><br />
                            </div>
                          <br /><br />
                    </div>
        </div>                      
      
        <div class="form-group" style="padding:10px;">
                      
                      <div class="col-md-3">
                        <label>HNI Test Price </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_HNIPrice" runat="server" TextMode="SingleLine" class="form-control required"></asp:TextBox>
                           </div>
                    </div>
                      <div class="col-md-4">
                        <label>Test Description </label>
                        <div class="selector">
                             <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" class="form-control required"></asp:TextBox><br />
                            </div>
                    </div>
                      <div class="col-md-2">
                                   <label>Is Active </label>
                                   <div class="selector">
                                       <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                   </div>
                               </div>
            <div class="col-md-3">
               <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnSave_Click" ValidationGroup="Test" />
           &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" OnClick="btnCancel_Click" Text="Cancel" />
                
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
       
    </asp:Content>

