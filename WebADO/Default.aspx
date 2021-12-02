<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebADO.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/bootstrap.css"
</head>
<body style="padding-left: 3%; overflow: scroll;">
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="inputs" style="width: 20%;">
                <div class="input-group">
                    <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="inut-group-append">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-outline-primary" />
                    </div>
                </div>
                <span>-- OR --</span>
                <asp:DropDownList ID="ddlDemo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDemo_SelectedIndexChanged" Width="100%"></asp:DropDownList>
            </div>
            <br />
            <div class="float-end text-wrap" style="padding: 1.5%; width: 8%; position: static;">
                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh Current Search" CssClass="btn btn-success text-wrap" />
            </div>
            <br />
            <asp:GridView ID="gvMain0" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="dataCustomers" Width="90%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                    <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="dataCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindDB %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
            
            <br />

            <div class="container-fluid">
                <div class ="row">
                    <div id="defaultSqlForm" class="col-3">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="CustomerID" DataSourceID="dataCustomer" ForeColor="#333333" GridLines="None" Height="50px" Width="125px" OnLoad="DetailsView1_Load">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                    <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>
            <asp:SqlDataSource ID="dataCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindDB %>" DeleteCommand="DELETE FROM [Customers] WHERE [CustomerID] = @CustomerID" InsertCommand="INSERT INTO [Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)" SelectCommand="SELECT * FROM [Customers] WHERE ([CustomerID] = @CustomerID)" UpdateCommand="UPDATE [Customers] SET [CompanyName] = @CompanyName, [ContactName] = @ContactName, [ContactTitle] = @ContactTitle, [Address] = @Address, [City] = @City, [Region] = @Region, [PostalCode] = @PostalCode, [Country] = @Country, [Phone] = @Phone, [Fax] = @Fax WHERE [CustomerID] = @CustomerID">
                <DeleteParameters>
                    <asp:Parameter Name="CustomerID" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CustomerID" Type="String" />
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="ContactName" Type="String" />
                    <asp:Parameter Name="ContactTitle" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Region" Type="String" />
                    <asp:Parameter Name="PostalCode" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Fax" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvMain0" DefaultValue="NULL" Name="CustomerID" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="ContactName" Type="String" />
                    <asp:Parameter Name="ContactTitle" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Region" Type="String" />
                    <asp:Parameter Name="PostalCode" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Fax" Type="String" />
                    <asp:Parameter Name="CustomerID" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
                        </div>

                    <div id="newDataInputArea" class="col-9 border border-primary rounded" runat="server">
                        <!-- Company Details -->
                        <div id="companyDetailsContainer" class="col-6 justify-content-sm-center float-start" style="padding-right: 3px; border-right: dashed 2px blue"> 
                            <div class="form-row">
                                <div class="input-group input-group-sm"> 
                                    <!-- Name -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbComNameLabel" class="input-group-text">Name</span>
                                    </div>
                                    <asp:TextBox ID="tbComName" runat="server" CssClass="form-control" aria-label="Company Name" aria-descibedby="tbComNameLabel"></asp:TextBox>
                                    <!-- ID -->
                                    <div class="input-group-prepend">
                                        <span id="tbIDLabel" class="input-group-text">ID</span>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="tbID" runat="server" CssClass="form-control" aria-label="ID" aria-descibedby="tbIDLabel" Disabled=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- City -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbCityLabel" class="input-group-text">City</span>
                                    </div>
                                    <asp:TextBox ID="tbCity" runat="server" CssClass="form-control" aria-label="Region" aria-descibedby="tbCityLabel"></asp:TextBox>
                                    <!-- Postal Code -->
                                    <div class="input-group-prepend">
                                        <span id="tbPostalCodeLabel" class="input-group-text">Postal Code</span>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="tbPostalCode" runat="server" CssClass="form-control" aria-label="Postal Code" aria-descibedby="tbPostalCodeLabel"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- Region -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbRegionLabel" class="input-group-text">Region</span>
                                    </div>
                                    <asp:TextBox ID="tbRegion" runat="server" CssClass="form-control" aria-label="Region" aria-descibedby="tbRegionLabel"></asp:TextBox>
                                    <!-- Country -->
                                    <div class="input-group-prepend">
                                        <span id="tbCountryLabel" class="input-group-text">Country</span>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="tbCountry" runat="server" CssClass="form-control" aria-label="Country" aria-descibedby="tbCountryLabel"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- Address -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbAddressLabel" class="input-group-text">Address</span>
                                    </div>
                                    <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control" aria-label="Address" aria-descibedby="tbAddressLabel"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- Contact Details -->
                        <div id="contactDetailsContainer" class="col-6 justify-content-sm-center float-end" style="padding-left: 3px;">
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- Name -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbConNameLabel" class="input-group-text">Name</span>
                                    </div>
                                    <asp:TextBox ID="tbConName" runat="server" CssClass="form-control" aria-label="Contact Name" aria-descibedby="tbConNameLabel"></asp:TextBox>
                                    <!-- Title/role -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbTitleLabel" class="input-group-text">Title</span>
                                    </div>
                                    <asp:TextBox ID="tbTtitle" runat="server" CssClass="form-control" aria-label="Title" aria-descibedby="tbTitleLabel"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- Phone -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbPhoneLabel" class="input-group-text">Phone</span>
                                    </div>
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control" aria-label="Phone" aria-descibedby="tbPhoneLabel"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="input-group input-group-sm">
                                    <!-- Fax -->
                                    <div class="col-2 input-group-prepend">
                                        <span id="tbFaxLabel" class="input-group-text">Fax</span>
                                    </div>
                                    <asp:TextBox ID="tbFax" runat="server" CssClass="form-control" aria-label="Fax" aria-descibedby="tbFaxLabel"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="row"></div>
                    </div>

                </div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
