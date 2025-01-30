using Azure.Storage.Files.Shares.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            txtWebSiteOwnerName.Text = Environment.GetEnvironmentVariable("WEBSITE_OWNER_NAME");
            
            lblAzureResourceGroup.Text = $"WEBSITE_RESOURCE_GROUP";
            txtAzureResourceGroup.Text = Environment.GetEnvironmentVariable("WEBSITE_RESOURCE_GROUP");
            
            lblAzureWebSiteName.Text = $"WEBSITE_SITE_NAME";
            txtAzureWebSiteName2.Text = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
        }

        protected void btnGetInstanceIds_Click(object sender, EventArgs e)
        {
            divShowResult.Visible = true;
            lblInstanceIdsResult.Text = "this is the result";
        }
    }
}