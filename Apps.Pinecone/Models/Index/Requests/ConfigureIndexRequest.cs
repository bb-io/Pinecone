using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Index.Requests;

public class ConfigureIndexRequest
{
    [Display("Index name")]
    public string IndexName { get; set; }
    
    [Display("Number of replicas")]
    public int? Replicas { get; set; }
    
    [Display("Pod type")]
    public string? PodType { get; set; }
}