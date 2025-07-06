using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace DuendeIS;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    private const string WeatherForecastApiRead = "weather-forecast-api.read";
    public static IEnumerable<ApiScope> ApiScopes =>
        [new ApiScope { Name = WeatherForecastApiRead, DisplayName = "Read Weather Forecast" }];

    public static IEnumerable<Client> Clients =>
        [ new Client{
            ClientId="ClientApi1",
            AllowedGrantTypes= GrantTypes.ClientCredentials,
            ClientSecrets=[new Secret("Secret".Sha256())],
            AllowedScopes=[WeatherForecastApiRead]},
        new Client{
            ClientId="Web",
            ClientSecrets=[new Secret("websecret".ToSha256())],
            AllowedGrantTypes=GrantTypes.Code,
            RedirectUris=["https://localhost:5002/signin-oidc"],
            PostLogoutRedirectUris=["https://localhost:5002/signout-callback-oidc"],
            AllowedScopes=[IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile]
            }];
}
