using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Pinecone.UrlBuilders;

public class IndexOperationsBaseUrlBuilder : IBaseUrlBuilder
{
    private readonly IEnumerable<AuthenticationCredentialsProvider> _authenticationCredentialsProviders;
    
    public IndexOperationsBaseUrlBuilder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        _authenticationCredentialsProviders = authenticationCredentialsProviders;
    }

    public Uri BuildBaseUrl()
    {
        var environment = _authenticationCredentialsProviders.First(p => p.KeyName == "Environment");
        var baseUrl = $"https://controller.{environment}.pinecone.io";
        return new Uri(baseUrl);
    }
}