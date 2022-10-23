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
                new Client
                {
                    ClientId = "mobile_pswd",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //RedirectUris = { "https://host.docker.internal:6001/callback" },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "api1"
                    }
                },

            };
    }
}