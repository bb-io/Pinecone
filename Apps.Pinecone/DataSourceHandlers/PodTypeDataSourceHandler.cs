using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Pinecone.DataSourceHandlers;

public class PodTypeDataSourceHandler : BaseInvocable, IDataSourceHandler
{
    public PodTypeDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var podTypes = new List<string>
        {
            "s1.x1",
            "s1.x2",
            "s1.x4",
            "s1.x8",
            "p1.x1",
            "p1.x2",
            "p1.x4",
            "p1.x8",
            "p2.x1",
            "p2.x2",
            "p2.x4",
            "p2.x8"
        };
        
        return podTypes
            .Where(t => context.SearchString == null || t.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(t => t, t => t);
    }
}