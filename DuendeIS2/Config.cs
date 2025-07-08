using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace DuendeIS2;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    private const string WeatherForecastApiReadScope = "weather-forecast-api.read";

    public static IEnumerable<ApiScope> ApiScopes =>
     [
         new ApiScope(WeatherForecastApiReadScope)
     ];

    public static IEnumerable<ApiResource> ApiResources =>
        [
            new ApiResource("weather-forecast-api", "Weather Forecast API")
            {
                Scopes = { WeatherForecastApiReadScope },
                // UserClaims = { "role", "email" } // opcional
            }
        ];

    public static IEnumerable<Client> Clients =>
        [
            // m2m client credentials flow client
            new Client
            {
                ClientId = "ClientApi1",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets=[new Secret("Secret".Sha256())],

                AllowedScopes=[WeatherForecastApiReadScope],
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "Web",
                ClientSecrets=[new Secret("websecret".ToSha256())],

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris=["https://localhost:5002/signin-oidc"],
                FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                PostLogoutRedirectUris=["https://localhost:5002/signout-callback-oidc"],

                AllowOfflineAccess = true,
                AllowedScopes=[IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, WeatherForecastApiReadScope],
            },
        ];
}
