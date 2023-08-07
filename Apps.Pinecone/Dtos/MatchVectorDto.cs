using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Dtos;

public class MatchVectorDto
{
    public string Id { get; set; }
    
    [Display("Similarity score")]
    public string Score { get; set; }
    
    [Display("Vector")]
    public float[] Values { get; set; }
}