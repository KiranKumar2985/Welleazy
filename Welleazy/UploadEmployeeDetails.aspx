<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage.Master" CodeBehind="UploadEmployeeDetails.aspx.cs" Inherits="Welleazy.UploadEmployeeDetails" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>        
      <div class="form-group" style="height:auto; background-color: white; padding: 3px; margin-top: -30px; border: 5px solid #0869b1; border-bottom-style: none; border-left-style: none; border-right-style: none;">
          <h5>
            <asp:LinkButton ID="LinkHome" runat="server" PostBackUrl="~/Home.aspx"  ForeColor="#0033cc">Home</asp:LinkButton> >> Corporate Management >> <asp:LinkButton ID="btnAddEmployee" runat="server" PostBackUrl="~/Admin/ListOfEmployee.aspx"  ForeColor="#0033cc" > List of Employee </asp:LinkButton> >> Bulk Employee Upload
          <span style="float:right;"><asp:Button ID="btnExport" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Download Format" OnClick="btnExport_Click" runat="server" /></span></h5>
                                   <div class="line"></div>     
          <label class ="mandatory"> **For Upload Bulk Employee Details , Click on below button to Download Format:</label>
          <h4>Bulk Employee Details Upload</h4>     
          <asp:MultiView ID="UploadEmployeeData" runat="server">
              
              <asp:View ID="UploadEmployeeDetail" runat="server">
                 <div class="form-group" style="margin-top:20px;">
                     <div class="col-md-4">
                         <label> Employee Details (In Bulk)</label>
                         <div class="selector">
                         <telerik:RadAsyncUpload ID="RadUploadEmployeeDocument" RenderMode="Lightweight" runat="server" Height="17px" Width="210px" Skin="WebBlue" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                             </div>
                     </div>

                     <div class="col-md-3">
                                   <label>
                                   Corporate Name <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateName" RenderMode="Lightweight" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbCorporateName_SelectedIndexChanged" Filter="Contains" ValidationGroup="Case">
                                                <Items>
                                               <telerik:RadComboBoxItem Value="0" Text="Select" />
                                           </Items>
                                            </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="rfvCorporateName" runat="server" ControlToValidate="cmbCorporateName" ForeColor="Red" ErrorMessage="Please Select Corporate" Enabled="true" ValidationGroup="Case" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </div>
                               </div>
                               <div class="col-md-3">
                                   <label>
                                   Branch Id <span class="mandatory">*</span>
                                   </label>
                                   <div class="selector">
                                       <telerik:RadComboBox ID="cmbCorporateBranchId" RenderMode="Lightweight" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmdBranchId_SelectedIndexChanged" AppendDataBoundItems="true" Filter="Contains">
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
                            
                            <telerik:RadComboBox ID="cmbProduct" runat="server" RenderMode="Lightweight" CssClass="Combo" AllowCustomText="true" AutoPostBack="true" OnSelectedIndexChanged="cmbProduct_SelectedIndexChanged" AppendDataBoundItems="true" Filter="Contains" CheckBoxes="true" ValidationGroup="Case">
                                <Items>
                                        <telerik:RadComboBoxItem Value="0" Text="Select Product" />

                                </Items>
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="cmbProduct" ForeColor="Red" ErrorMessage="Please Select Product" Enabled="true" ValidationGroup="Case" InitialValue="Select Product"></asp:RequiredFieldValidator>
                         </div>
                         </div>

                     <div class="form-group" style="overflow:auto; width:100%; padding:10px;">
                               
                                           <telerik:RadGrid ID="rgProductServices" runat="server"
                            AutoGenerateColumns="False" Visible="true" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                            HeaderStyle-VerticalAlign="Middle"
                            ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                            OnItemDataBound="rgProductServices_ItemDataBound" CellPadding="4" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" AllowSorting="True" Skin="Bootstrap" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                            <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true" >
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Assign Product Services" SortExpression="">
                                        <HeaderTemplate>
                    <asp:Label ID="lblProductHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Product")%>' ></asp:Label>
                </HeaderTemplate>
                                        <ItemTemplate>
                                              <asp:CheckBox  ID="chkAllTask" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="chkAllTask_CheckedChanged" />
                                                   
                                           <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId")%>'></asp:Label>
                                            <telerik:RadGrid ID="rgProductServicesDepth" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CellSpacing="0" GridLines="None" HeaderStyle-HorizontalAlign="Center" EnableTheming="false"
                                                HeaderStyle-VerticalAlign="Middle"
                                                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                                                Skin="Bootstrap" CellPadding="4" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowSorting="True" HeaderStyle-BackColor="#113d7a" HeaderStyle-ForeColor="White">
                                                <MasterTableView AllowSorting="true" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn SortExpression="">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblProductHeader" ForeColor="White" runat="server"></asp:Label>
                                                                
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBoxList ID="cbTasks" runat="server" RepeatDirection="Vertical" RepeatColumns="6">
                                                                </asp:CheckBoxList>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </telerik:RadGrid>

                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </telerik:RadGrid>
                                  
                               </div>

                     <div class="col-md-6">
                         <label> </label>
                         <div class="selector">
                         <asp:button ID="btnUpload" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Upload" OnClick="btnUpload_Click"></asp:button>
                             &nbsp;&nbsp;&nbsp;
                             <asp:button ID="btnCancel" runat="server" CssClass="Login_btn btn" BackColor="#113d7a" ForeColor="white" BorderStyle="None" Text="Cancel" PostBackUrl="~/Admin/ListOfEmployee.aspx"></asp:button>
                             </div>
                     </div>
                   </div>
                  <div class="form-group" style="margin-top:100px; background:white; margin-bottom:100px;">  
                     
                 </div>
              </asp:View>
          </asp:MultiView>
            </div>
            
       
    </asp:Content>
