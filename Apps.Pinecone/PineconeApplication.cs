using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Pinecone;

public class PineconeApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.ArtificialIntelligence];
        set { }
    }
    
    public string Name
    {
        get => "Pinecone";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}