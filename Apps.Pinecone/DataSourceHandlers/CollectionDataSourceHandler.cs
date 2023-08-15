using Apps.Pinecone.Actions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Pinecone.DataSourceHandlers;

public class CollectionDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    public CollectionDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, 
        CancellationToken cancellationToken)
    {
        var collectionsResponse = await new IndexActions()
            .ListCollections(InvocationContext.AuthenticationCredentialsProviders);
        var collections = collectionsResponse.Collections
            .Where(c => context.SearchString == null || c.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20);
        return collections.ToDictionary(c => c, c => c);
    }
}