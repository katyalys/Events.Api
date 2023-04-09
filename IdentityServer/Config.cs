using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwmId",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "eventsApi.create", "eventsApi.delete", "eventsApi.update", "eventsApi.read" }
                },
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("eventsApi")
                {
                    Scopes = new List<string>{ "eventsApi.create", "eventsApi.delete", "eventsApi.update", "eventsApi.read"},
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope(name: "eventsApi.create"),
                new ApiScope(name: "eventsApi.delete"),
                new ApiScope(name: "eventsApi.update"),
                new ApiScope(name: "eventsApi.read")
            };
    }
}
