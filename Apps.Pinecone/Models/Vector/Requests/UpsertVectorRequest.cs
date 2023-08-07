using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Requests;

public class UpsertVectorRequest
{
    [Display("Index name")] 
    public string IndexName { get; set; }
    
    [Display("Project ID")] 
    public string ProjectId { get; set; }
    
    public float[] Vector { get; set; }
    
    public string? Namespace { get; set; }
}