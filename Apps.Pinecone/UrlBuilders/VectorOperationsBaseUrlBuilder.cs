using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Pinecone.UrlBuilders;

public class VectorOperationsBaseUrlBuilder : IBaseUrlBuilder
{
    private readonly string _indexName;
    private readonly string _projectId;
    private readonly IEnumerable<AuthenticationCredentialsProvider> _authenticationCredentialsProviders;
    
    public VectorOperationsBaseUrlBuilder(string indexName, string projectId, 
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        _indexName = indexName;
        _projectId = projectId;
        _authenticationCredentialsProviders = authenticationCredentialsProviders;
    }

    public Uri BuildBaseUrl()
    {
        var environment = _authenticationCredentialsProviders.First(p => p.KeyName == "Environment");
        var baseUrl = $"https://{_indexName}-{_projectId}.svc.{environment}.pinecone.io";
        return new Uri(baseUrl);
    }
}