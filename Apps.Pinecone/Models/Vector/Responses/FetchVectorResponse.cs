using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Responses;

public class FetchVectorResponse
{
    public string Id { get; set; }
    
    [Display("Vector")]
    public float[] Values { get; set; }
}

public class FetchVectorResponseWrapper
{
    public Dictionary<string, FetchVectorResponse> Vectors { get; set; }
}