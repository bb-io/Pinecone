using Apps.Pinecone.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Pinecone.UrlBuilders;

public class VectorOperationsBaseUrlBuilder : IBaseUrlBuilder
{
    private readonly string _indexName;
    private readonly IEnumerable<AuthenticationCredentialsProvider> _authenticationCredentialsProviders;
    
    public VectorOperationsBaseUrlBuilder(string indexName,
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        _indexName = indexName;
        _authenticationCredentialsProviders = authenticationCredentialsProviders;
    }

    public Uri BuildBaseUrl()
    {
        var environment = _authenticationCredentialsProviders.First(p => p.KeyName == "Environment").Value;
        var projectId = GetProjectId().Result;
        var baseUrl = $"https://{_indexName}-{projectId}.svc.{environment}.pinecone.io";
        return new Uri(baseUrl);
    }

    private async Task<string> GetProjectId()
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(_authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/actions/whoami", Method.Get, _authenticationCredentialsProviders);
        var project = await client.ExecuteWithHandling<ProjectDto>(request);
        return project.ProjectId;
    }
}