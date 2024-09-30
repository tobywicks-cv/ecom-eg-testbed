﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.Data.SqlClient;

namespace EcomEgTestBed
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["YourPageIDorName"] = 1;

            this.hostLabel.Text = Request.Headers["Host"];
            var authority = Request.Headers[":authority:"];
            this.authority.Text = string.IsNullOrEmpty(authority) ? "[blank]" : authority;

            var xForwardedHost = Request.Headers["X-Forwarded-Host"];
            forwardedHostLabel.Text = string.IsNullOrEmpty(xForwardedHost) ? "[blank]" : xForwardedHost;

            var websiteSiteName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
            AzureWebsiteSiteName.Text = string.IsNullOrEmpty(websiteSiteName) ? "[blank]" : websiteSiteName;

            var websiteResourceGroup = Environment.GetEnvironmentVariable("WEBSITE_RESOURCE_GROUP");
            AzureWebsiteResourceGroup.Text = string.IsNullOrEmpty(websiteResourceGroup) ? "[blank]" : websiteResourceGroup;

            if (!Page.IsPostBack)
            {
                txtTrustedConnectionDBName.Text = "cv-db-site-qa-australiaeast-TenantA";
                txtTrustedConnectionServerName.Text = "cv-sqls-site-qa-australiaeast-001.database.windows.net";
                txtBoxUserName.Text = "cv-admin";
                txtBoxPassword.Text = "ek38ep2njAW%raJvzcK8*3";
                CheckBoxIsEncrypted.Checked = SqlConnectionEncryptOption.Optional;
                CheckBoxTrustServerCertificate.Checked = true;
            }
        }

        private SqlConnectionStringBuilder GetConnectionStringBuilder(SqlAuthenticationMethod authenticationMethod)
        {
            var conBuilder = new SqlConnectionStringBuilder
            {
                DataSource = txtTrustedConnectionServerName.Text.Trim(),
                InitialCatalog = txtTrustedConnectionDBName.Text.Trim(),
                Authentication = authenticationMethod,
                Encrypt = CheckBoxIsEncrypted.Checked,
                TrustServerCertificate = CheckBoxTrustServerCertificate.Checked
            };

            if (authenticationMethod == SqlAuthenticationMethod.SqlPassword)
            {
                conBuilder.UserID = txtBoxUserName.Text.Trim();
                conBuilder.Password = txtBoxPassword.Text.Trim();
            }

            return conBuilder;
        }

        protected void ButtonConnectToDBConnectionString_OnClick(object sender, EventArgs e)
        {
            ConnectToDb(SqlAuthenticationMethod.SqlPassword);
        }

        protected void ButtonConnectToUsingManagedIdentity_OnClick(object sender, EventArgs e)
        {
            ConnectToDb(SqlAuthenticationMethod.ActiveDirectoryManagedIdentity);
        }

        protected void ButtonConnectToDBTrustedConnection_OnClick(object sender, EventArgs e)
        {
            ConnectToDb(SqlAuthenticationMethod.ActiveDirectoryIntegrated);
        }
        
        private void ConnectToDb(SqlAuthenticationMethod sqlAuthenticationMethod)
        {
            pResults.Visible = true;
            try
            {
                string connectionString = GetConnectionStringBuilder(sqlAuthenticationMethod).ConnectionString;
                divComputedConnectionString.InnerHtml = connectionString;
                var connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
                divConnectionOutcome.InnerHtml = "\u2705 Successfully connected to database!";
            }
            catch (Exception exception)
            {
                divConnectionOutcome.InnerHtml = "\ud83d\uded1 " + exception.Message + Environment.NewLine + exception.StackTrace;
            }
        }

    }
}