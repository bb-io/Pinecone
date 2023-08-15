using Apps.Pinecone.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pinecone.Models.Index.Requests;

public class CreateIndexRequest
{
    public string Name { get; set; }
    
    public int Dimension { get; set; }
    
    [DataSource(typeof(MetricDataSourceHandler))]
    public string? Metric { get; set; }
    
    [Display("Number of pods")]
    public int? PodsNumber { get; set; }
    
    [Display("Number of replicas")]
    public int? NumberOfReplicas { get; set; }
    
    [Display("Pod type")]
    [DataSource(typeof(PodTypeDataSourceHandler))]
    public string? PodType { get; set; }

    [Display("Source collection")]
    [DataSource(typeof(CollectionDataSourceHandler))]
    public string? SourceCollection { get; set; }
}