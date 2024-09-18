<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/LongRunningWebRequest.aspx.cs" Inherits="EcomEgTestBed.LongRunningWebRequest" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContent">
    <link rel="stylesheet" href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="card" style="margin-top: 20px;">
        <div class="card-header bg-info text-white">
            <h3 class="mb-0">Simulate Long Running Web Requests</h3>
        </div>
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblTimeout" runat="server" CssClass="col-sm-3 col-form-label">Timeout (seconds)</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtTimeout" runat="server" CssClass="form-control">5</asp:TextBox>
                    <asp:Button ID="btnRunWithTimout" runat="server" OnClick="btnRunWithTimout_Click" Text="Start" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblFinished" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>

