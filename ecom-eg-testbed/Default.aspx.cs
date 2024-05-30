using System;
using System.Web.UI;
using Microsoft.Data.SqlClient;

namespace EcomEgTestBed
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var connectionString = databaseconnectionstring.Text;

                try
                {
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    connection.Close();
                    ConnectionOutcome.Text = "\u2705 Successfully connected to database!";
                }
                catch (Exception exception)
                {
                    ConnectionOutcome.Text = "\ud83d\uded1 " + exception.Message + Environment.NewLine + exception.StackTrace;
                }
            }
            else
            {
                databaseconnectionstring.Text = ConnectionStringSource;
            }
        }

        public static string ConnectionStringSource
        {
            get
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = "server";
                builder.InitialCatalog = "database";
                builder.UserID = "userid";
                builder.Password = "password";
                builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
                //builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                builder.Encrypt = SqlConnectionEncryptOption.Optional;
                builder.TrustServerCertificate = true;
                return builder.ToString();
            }
        }
    }
}