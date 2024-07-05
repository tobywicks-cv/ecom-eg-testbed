using System;
using System.Web.UI;
using Microsoft.Data.SqlClient;

namespace EcomEgTestBed
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hostLabel.Text = Request.Headers["Host"];
            var authority = Request.Headers[":authority:"];
            this.authority.Text = string.IsNullOrEmpty(authority) ? "[blank]" : authority;

            var xForwardedHost = Request.Headers["X-Forwarded-Host"];
            this.forwardedHostLabel.Text = string.IsNullOrEmpty(xForwardedHost) ? "[blank]" : xForwardedHost;

            if (!Page.IsPostBack)
            {
                txtTrustedConnectionDBName.Text = InitialConnectionString.InitialCatalog;
                txtTrustedConnectionServerName.Text = InitialConnectionString.DataSource;
                txtBoxUserName.Text = InitialConnectionString.UserID;
                txtBoxPassword.Text = InitialConnectionString.Password;
                CheckBoxIsEncrypted.Checked = InitialConnectionString.Encrypt;
                CheckBoxTrustServerCertificate.Checked = InitialConnectionString.TrustServerCertificate;
            }
        }

        private SqlConnectionStringBuilder InitialConnectionString
        {
            get
            {
                return new SqlConnectionStringBuilder
                {
                    DataSource = "cv-sqls-site-qa-eastau.database.windows.net",
                    InitialCatalog = "cv-db-site-qa-eastau",
                    UserID = "cv-admin",
                    Password = "ek38ep2njAW%raJvzcK8*3",
                    Authentication = SqlAuthenticationMethod.SqlPassword,
                    //builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                    Encrypt = SqlConnectionEncryptOption.Optional,
                    TrustServerCertificate = true
                };
            }
        }

        private SqlConnectionStringBuilder GetConnectionStringBuilder(bool isIntegrated)
        {
            var conBuilder = new SqlConnectionStringBuilder
            {
                DataSource = txtTrustedConnectionServerName.Text.Trim(),
                InitialCatalog = txtTrustedConnectionDBName.Text.Trim(),
                Authentication = isIntegrated ? SqlAuthenticationMethod.ActiveDirectoryIntegrated :
                SqlAuthenticationMethod.SqlPassword,
                Encrypt = CheckBoxIsEncrypted.Checked,
                TrustServerCertificate = CheckBoxTrustServerCertificate.Checked
            };

            if (!isIntegrated)
            {
                conBuilder.UserID = txtBoxUserName.Text.Trim();
                conBuilder.Password = txtBoxPassword.Text.Trim();
            }

            return conBuilder;
        }

        protected void ButtonConnectToDBConnectionString_OnClick(object sender, EventArgs e)
        {
            pResults.Visible = true;
            try
            {
                string connectionString = GetConnectionStringBuilder(false).ConnectionString;
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

        protected void ButtonConnectToDBTrustedConnection_OnClick(object sender, EventArgs e)
        {
            pResults.Visible = true;
            try
            {
                string connectionString = GetConnectionStringBuilder(true).ConnectionString;
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