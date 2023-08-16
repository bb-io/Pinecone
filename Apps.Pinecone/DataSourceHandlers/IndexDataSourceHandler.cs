using Apps.Pinecone.Actions;
using Apps.Pinecone.UrlBuilders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Pinecone.DataSourceHandlers;

public class IndexDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    public IndexDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, 
        CancellationToken cancellationToken)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(InvocationContext.AuthenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/databases", Method.Get, InvocationContext.AuthenticationCredentialsProviders);
        var indexes = (await client.ExecuteWithHandling<IEnumerable<string>>(request))
            .Where(c => context.SearchString == null || c.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20);
        return indexes.ToDictionary(i => i, i => i);
    }
}