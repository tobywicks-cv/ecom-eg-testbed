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
                <asp:Label ID="lblDirectoryName" runat="server"
                    AssociatedControlID="txtFolderPath"
                    CssClass="col-sm-3 col-form-label">Folder Path:</asp:Label>
                <div class="col-sm-9">
                    <div>C:\Mounts\Assets\{tenant ID}\{Asset Type}</div>
                    <div>EG: C:\Mounts\Assets\TenantA\images</div>
                    <div>
                        <asp:TextBox ID="txtFolderPath" runat="server" Width="550"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <asp:Button runat="server" Text="Get files in Directory"
                ID="btnGetFilesInDirectory"
                OnClick="btnGetFilesIn_Click"></asp:Button>

            <asp:Button ID="ButtonWriteToMountShare" runat="server" Text="Write to Directory"
                OnClick="ButtonWriteToMountShare_OnClick" />


        </div>
    </div>


    <div id="divShowResult" runat="server" visible="False" class="alert alert-info">

        <asp:ListView ID="ListViewFilesInDirectory" runat="server">
            <ItemTemplate>
                <div style="margin-bottom: 3px;">
                    <asp:Button ID="ButtonGetFile" runat="server"
                        OnClick="ButtonGetFile_OnClick"
                        Text="<%# Container.DataItem %>" />
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div id="divError" runat="server" visible="False" class="alert alert-danger"></div>
</asp:Content>
