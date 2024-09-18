<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/ReadInfraCatalog.aspx.cs" Inherits="EcomEgTestBed.ReadInfraCatalog" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContent" xmlns:app="http://www.w3.org/1999/html">
    <link rel="stylesheet" href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="card" style="margin-top: 20px;">
        <div class="card-header bg-info text-white">
            <h3 class="mb-0">Read Infra Catalog (Cosmos DB)</h3>
        </div>
        <div class="card-body">
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-sm-3 col-form-label">Cosmos DB End Point</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtEndPoint" runat="server" Width="500" CssClass="form-control">https://cv-cosno-sitesinfra-qa-australiaeast.documents.azure.com:443/</asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-sm-3 col-form-label">
                    Read Access Key<br/>
                    <span style="font-size: x-small">Azure Portal > Cosmos Resource > Settings > Keys</span>
                    
                </asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtReadAccessKey" runat="server" Width="500" CssClass="form-control">xxxxxxx</asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-sm-3 col-form-label">Database Name</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtDatabaseId" runat="server" Width="500" CssClass="form-control">cv-cosmos-sitesinfra-qa-australiaeast</asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-sm-3 col-form-label">Container Name</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtContainerID" runat="server" Width="500" CssClass="form-control">SiteFarms</asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-9">
                    <asp:Button ID="btnReadCatalog" runat="server" OnClick="btnReadCatalog_Click" Text="Read Infra Catalog" />
                </div>
            </div>
        </div>
        
        <div class="card-body">
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-sm-3 col-form-label">Response</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox TextMode="MultiLine" ID="txtResult" runat="server" Height="500" Width="500" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

