using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Index.Requests;

public class CreateIndexRequest
{
    public string Name { get; set; }
    
    public int Dimension { get; set; }
    
    [Display("Metric: euclidean/cosine/dotproduct")]
    public string? Metric { get; set; }
    
    [Display("Number of pods")]
    public int? PodsNumber { get; set; }
    
    [Display("Number of replicas")]
    public int? NumberOfReplicas { get; set; }
    
    [Display("Pod type")]
    public string? PodType { get; set; }
    
    [Display("Source collection")]
    public string? SourceCollection { get; set; }
}