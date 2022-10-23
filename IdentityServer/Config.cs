using Duende.IdentityServer.Models;
using static System.Net.WebRequestMethods;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(name: "api1", displayName: "TestAPI")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // machine to machine client (from quickstart 1)
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "api1" }
                },
                new Client
                {
                    ClientId = "mobile",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://host.docker.internal:5001/signin-oidc" },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "api1"
                    }
                },
                new Client
                {
                    ClientId = "device",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.DeviceFlow,
                    RedirectUris = { "http://localhost:5000/signin-oidc" },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "api1"
                    }
                }
            };
    }
}