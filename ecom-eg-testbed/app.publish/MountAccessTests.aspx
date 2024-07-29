<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MountAccessTests.aspx.cs" Inherits="EcomEgTestBed.MountAccessTests" %>
<asp:Content runat="server" 
             ContentPlaceHolderID="HeaderContent">
    <link rel="stylesheet" 
          href="//stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="card" style="margin-top: 20px;">
        <div class="card-header bg-info text-white">
            <h3 class="mb-0">App Service Mount Info</h3>
        </div>
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblShareName" runat="server" 
                           AssociatedControlID="txtShareName" 
                           CssClass="col-sm-3 col-form-label">Mount Share Name

                </asp:Label>
                <div class="col-sm-9">
                    <span>\\mounts\</span>
                    <asp:TextBox ID="txtShareName"
                                 runat="server" 
                                 CssClass="form-control">Assets</asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="lblDirectoryName" runat="server" 
                           AssociatedControlID="txtTenantId" 
                           CssClass="col-sm-3 col-form-label">Directory Name:</asp:Label>
                <div class="col-sm-9">
                    <span>\\mounts\{share name}\{directory name}</span>
                    <asp:TextBox ID="txtTenantId" runat="server" Width="150"
                                 CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <asp:Button runat="server" Text="Get files in Mount / Directory" 
                        ID="btnGetFilesInDirectory" 
                        OnClick="btnGetFilesIn_Click"></asp:Button>

            <asp:Button ID="ButtonWriteToMountShare" runat="server" Text="Write to Mount / Directory"
                        OnClick="ButtonWriteToMountShare_OnClick"/>


        </div>
    </div>


    <div id="divShowResult" runat="server" visible="False" class="alert alert-info">

        <asp:ListView ID="ListViewFilesInDirectory" runat="server">
            <ItemTemplate>
                <div style="margin-bottom:3px;">
                    <asp:Button ID="ButtonGetFile" runat="server" 
                                OnClick="ButtonGetFile_OnClick"
                                Text="<%# Container.DataItem %>" />
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    
    <div id="divError" runat="server" Visible="False" class="alert alert-danger"></div>
</asp:Content>
