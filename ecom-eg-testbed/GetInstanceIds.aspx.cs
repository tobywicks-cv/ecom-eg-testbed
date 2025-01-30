using Azure.Storage.Files.Shares.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Identity.Client;
using Microsoft.Rest;

// Web config:
// AzureTenantId
// AzureSubscriptionId ( can be obtained from WEBSITE_OWNER_NAME)
// AzureClientId
// AzureResourceGroup (can be obtained from WEBSITE_RESOURCE_GROUP)
// AzureWebsiteName (can be obtained from WEBSITE_SITE_NAME)
//
// Key vault:
//    AzureApplicationKey

namespace EcomEgTestBed
{
    public partial class GetInstanceIds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWebSiteOwnerName.Text = $"WEBSITE_OWNER_NAME";
            txtWebSiteOwnerName.Text = GetSubscriptionId();
            
            lblAzureResourceGroup.Text = $"WEBSITE_RESOURCE_GROUP";
            txtAzureResourceGroup.Text = GetResourceGroupName();
            
            lblAzureWebSiteName.Text = $"WEBSITE_SITE_NAME";
            txtAzureWebSiteName2.Text = GetSiteName();
            
            lblMachineName.Text = $"Machine name";
            txtMachineName.Text = Environment.MachineName;
        }

        private static string GetSiteName() => Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");

        private static string GetResourceGroupName() => Environment.GetEnvironmentVariable("WEBSITE_RESOURCE_GROUP");

        private static string GetSubscriptionId() => Environment.GetEnvironmentVariable("WEBSITE_OWNER_NAME");

        protected void btnGetInstanceIds_Click(object sender, EventArgs e)
        {
            var instanceIds = GetAllInstancesIds(GetSubscriptionId(), GetResourceGroupName(), GetSiteName());

            divShowResult.Visible = true;
            // lblInstanceIdsResult.Text = $"Instance Ids: {instanceIds}";
        }

        private static string GetAllInstancesIds(string subscriptionId, string resourceGroup, string webSiteName)
        {
            return string.Empty;
            // var resource = "https://management.core.windows.net/";
            // var authority = "https://login.windows.net/tenant";
            //
            // var token = GetToken(authority, clientId, appKey, resource);
            //
            // var webClient = new Microsoft.Azure.Management.WebSites.WebSiteManagementClient(token)
            // {
            //     SubscriptionId = subscriptionId
            // };
            // var instances = webClient.WebApps.ListInstanceIdentifiers(resourceGroup, webSiteName);
            // var listOfInstances = instances.Select(siteInstance => siteInstance.Name).ToList();
            //
            // return string.Join(",", listOfInstances);
        }

        // private static TokenCredentials GetToken(string authority, string clientId, string appKey, string resource)
        // {
        //     var authContext = new AuthenticationContext(authority);
        //     var clientCredential = new ClientCredential(clientId, appKey);
        //     var result = authContext.  //AcquireTokenAsync(resource, clientCredential);
        //     var credentials = new TokenCredentials(result.Result.AccessToken);
        //     return credentials;
        // }

    }
}