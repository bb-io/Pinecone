using Apps.Pinecone.Actions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Pinecone.DataSourceHandlers;

public class IndexDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    public IndexDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, 
        CancellationToken cancellationToken)
    {
        var indexesResponse = await new IndexActions().ListIndexes(InvocationContext.AuthenticationCredentialsProviders);
        var indexes = indexesResponse.Indexes
            .Where(c => context.SearchString == null || c.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20);
        return indexes.ToDictionary(i => i, i => i);
    }
}