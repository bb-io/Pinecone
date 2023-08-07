using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone;

public class PineconeApplication : IApplication
{
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