<%@ Page Title="ECOM EG Testbed" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcomEgTestBed._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section>
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
                        <td><code>x-forwarded-host</code></td>
                        <td><asp:Label ID="forwardedHostLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><code>host</code></td>
                        <td><asp:Label ID="hostLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </p>
        </section>

        <section>
            <h3>Database Connection</h3>

            <form>
                <label>Database connection string:</label>
                <asp:TextBox style="width: 75%" runat="server" ID="databaseconnectionstring" name="databaseconnectionstring" ></asp:TextBox>
                <p>
                    <button type="submit">Connect to DB</button>
                </p>
            </form>

            <p>
                <asp:Label runat="server" ID="ConnectionOutcome"></asp:Label>
            </p>
        </section>
    </main>

</asp:Content>
