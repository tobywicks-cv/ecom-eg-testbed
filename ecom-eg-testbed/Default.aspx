<%@ Page Title="ECOM EG Testbed" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="EcomEgTestBed._Default" %>

<asp:Content runat="server"
    ContentPlaceHolderID="HeaderContent">
    <link rel="stylesheet"
        href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section style="margin-top: 20px">
            <h2>ECOM Evergreen Testbed</h2>
            <p>
                This is the ECOM Evergreen test app.
            </p>
        </section>

        <section>
            <h3>Request Headers</h3>

            <p>
                <table cellpadding="3px">
                    <tr>
                        <th style="text-align: left">Header</th>
                        <th style="text-align: left">Value</th>
                    </tr>
                    <tr>
                        <td>x-forwarded-host</td>
                        <td>
                            <asp:Label ID="forwardedHostLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>host</td>
                        <td>
                            <asp:Label ID="hostLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>:authority:</td>
                        <td>
                            <asp:Label ID="authority" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </p>
        </section>
        
        <section>
            <h3>Environment Variables</h3>

            <p>
                <table cellpadding="3px">
                    <tr>
                        <td>WEBSITE_SITE_NAME</td>
                        <td>
                            <asp:Label ID="AzureWebsiteSiteName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>WEBSITE_RESOURCE_GROUP</td>
                        <td>
                            <asp:Label ID="AzureWebsiteResourceGroup" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </p>
        </section>

        <section>
            <h3>Database Connection Tests</h3>
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtTrustedConnectionServerName" runat="server" class="form-label">Server URL</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtTrustedConnectionServerName" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtTrustedConnectionDBName" class="form-label">Database Name</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtTrustedConnectionDBName" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>

            <div class="row g-3">

                <div class="col-md-6">
                    <label for="txtBoxUserName" class="form-label">User Name</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBoxUserName" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="txtBoxPassword" class="form-label">Password</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBoxPassword" ClientIDMode="Static"></asp:TextBox>
                </div>

            </div>

            <div class="row g-3">

                <div class="col-md-6">
                    <label for="CheckBoxIsEncrypted" class="form-label">Encrypt</label>
                    <asp:CheckBox CssClass="form-control" ID="CheckBoxIsEncrypted" ClientIDMode="Static" runat="server" />
                </div>

                <div class="col-md-6">
                    <label for="CheckBoxIsEncrypted" class="form-label">Trust Server Certificate</label>
                    <asp:CheckBox CssClass="form-control" ID="CheckBoxTrustServerCertificate" ClientIDMode="Static" runat="server" />
                </div>

            </div>
            <div class="mb-3">
                <asp:Button ID="ButtonConnectToDBTrustedConnection" runat="server"
                    OnClick="ButtonConnectToDBTrustedConnection_OnClick"
                    Text="Connect to DB with Trusted Connection" />

                <asp:Button ID="ButtonConnectToDBConnectionString" runat="server"
                    OnClick="ButtonConnectToDBConnectionString_OnClick"
                    Text="Connect to DB with Connection String" />
            </div>
            <p id="pResults" runat="server" visible="False">
                <div id="divComputedConnectionString" runat="server"
                    class="alert alert-info">
                </div>
                <div runat="server"
                    class="alert alert-warning"
                    id="divConnectionOutcome">
                </div>
            </p>
        </section>
    </main>

</asp:Content>
