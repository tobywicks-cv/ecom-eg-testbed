<%@ Page Title="ECOM EG Testbed" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcomEgTestBed._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section>
            <h2>ECOM EG Testbed</h2>
            <p>
                This is the ECOM EG test app.
            </p>
                
            <form>
                <label>Database connection string:</label>
                <asp:TextBox style="width: 75%" runat="server" ID="databaseconnectionstring" name="databaseconnectionstring" ></asp:TextBox>
                <br/>
                <button type="submit">Connect to DB</button>
            </form>
            
            <p>
                <asp:Label runat="server" ID="ConnectionOutcome"></asp:Label>
            </p>
        </section>
    </main>

</asp:Content>
