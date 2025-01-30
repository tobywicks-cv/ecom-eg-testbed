<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MountAccessTests.aspx.cs" Inherits="EcomEgTestBed.GetInstanceIds" %>

<asp:Content runat="server"
    ContentPlaceHolderID="HeaderContent">
    <link rel="stylesheet"
        href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card" style="margin-top: 20px;">
        <div class="card-header bg-info text-white">
            <h3 class="mb-0">Inter-Instance Communications</h3>
        </div>
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblWebSiteOwnerName" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtWebSiteOwnerName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblAzureResourceGroup" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAzureResourceGroup" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblAzureWebSiteName" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAzureWebSiteName2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <asp:Label ID="lblMachineName" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtMachineName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <asp:Button runat="server" Text="Get Instance Ids" Visible="False"
                ID="btnGetInstanceIds"
                OnClick="btnGetInstanceIds_Click"></asp:Button>

            <div id="divShowResult" runat="server" Visible="False" class="alert alert-info">
                <asp:Label ID="lblInstanceIdsResult" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
            </div>

        </div>
    </div>

</asp:Content>
