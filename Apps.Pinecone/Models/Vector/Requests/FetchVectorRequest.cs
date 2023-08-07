using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Requests;

public class FetchVectorRequest
{
    [Display("Index name")] 
    public string IndexName { get; set; }
    
    [Display("Project ID")] 
    public string ProjectId { get; set; }
    
    [Display("Vector ID")] 
    public string VectorId { get; set; }
    
    public string? Namespace { get; set; }
}