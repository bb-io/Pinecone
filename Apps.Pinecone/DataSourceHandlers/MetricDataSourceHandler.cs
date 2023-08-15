using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Pinecone.DataSourceHandlers;

public class MetricDataSourceHandler : BaseInvocable, IDataSourceHandler
{
    public MetricDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var metrics = new List<string>
        {
            "euclidean",
            "cosine",
            "dotproduct"
        };
        
        return metrics
            .Where(m => context.SearchString == null || m.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(m => m, m => m);
    }
}