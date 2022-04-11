using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace KeyVault
{
    public class GetSecrets
    {
        public static string AuthKey { get; private set; }
        public static string ConnectionString { get; private set; }

        static GetSecrets()
        {
            //invalid
            var BASE_URI = "https://elibrary-keys.vault.azure.net/";
            var CLIENT_SECRET = "kHe7Q~h7Hcn9lIlIcGqnPio_PwV0DJfB4TnvC";
            var CLIENT_ID = "95cb976f-13e5-4da9-87c7-c8c5c3b98b3b";
            var TENANT_ID = "544f8ac3-ce4c-47d1-9b72-284ac54b8d1c";

            var client = new SecretClient(new Uri(BASE_URI), new ClientSecretCredential(tenantId: TENANT_ID, clientId: CLIENT_ID, clientSecret: CLIENT_SECRET));

            var authKey = client.GetSecret("AuthKey");

            var connectionString = client.GetSecret("ConnectionStrings");
            //var connectionString = client.GetSecret("TestConnection");

            AuthKey = authKey.Value.Value;
            ConnectionString = connectionString.Value.Value;
        }
    }
}