<%@ Page Language="C#" 
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="TestFileShareConnectivity.aspx.cs"
    Inherits="EcomEgTestBed.TestFileShareConnectivity" %>

<asp:Content runat="server" 
             ContentPlaceHolderID="HeaderContent">
    <link rel="stylesheet" 
          href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>


<asp:Content ID="BodyContent" 
             ContentPlaceHolderID="MainContent" 
             runat="server">

    <div class="card" style="margin-top: 20px;">
        <div class="card-header bg-info text-white">
            <h3 class="mb-0">Share File Information</h3>
        </div>
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblAccountKey" runat="server" AssociatedControlID="txtAccountKey" CssClass="col-sm-3 col-form-label">Account Key:</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAccountKey" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="lblShareName" runat="server" AssociatedControlID="txtShareName" CssClass="col-sm-3 col-form-label">Share Name:</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtShareName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="lblAccountName" runat="server" AssociatedControlID="txtAccountName" CssClass="col-sm-3 col-form-label">Account Name:</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="lblDirectoryName" runat="server" AssociatedControlID="txtDirectoryName" CssClass="col-sm-3 col-form-label">Directory Name:</asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtDirectoryName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <asp:Button runat="server" Text="Directory Info" ID="btnGetFilesInDirectory" OnClick="btnGetFilesIn_Click"></asp:Button>


        </div>
    </div>


    <div id="divShowResult" runat="server" visible="False" class="alert alert-info">

        <asp:ListView ID="ListViewFilesInDirectory" runat="server">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:Button ID="ButtonGetFile" runat="server" CssClass="btn btn-sm"
                                OnClick="ButtonGetFile_OnClick"
                                Text="<%# Container.DataItem %>" />
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
    
    <div id="divError" runat="server" Visible="False" class="alert alert-danger"></div>
</asp:Content>
