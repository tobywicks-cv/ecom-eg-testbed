using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace EcomEgTestBed.Code
{
    public static class KeyVaultAccess
    {
        public static string ReadSecret(string secretName, string keyVaultName)
        {
            if(string.IsNullOrEmpty(secretName)) return "ERROR: No secret name provided";

            if(string.IsNullOrEmpty(keyVaultName)) return "ERROR: No key vault name provided";

            // Replace with your Key Vault URL
            string keyVaultUrl = $"https://{keyVaultName}.vault.azure.net/";
                
            // Create a SecretClient using DefaultAzureCredential which will use RBAC
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            try
            {
                // Get the secret
                KeyVaultSecret secret = client.GetSecret(secretName);
                return secret.Value;
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
}
//
// string keyVaultUrl = $"https://{keyVaultName}.vault.azure.net/";
// var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
//
// KeyVaultSecret secret = client.GetSecret(secretName);
// return secret.Value;
