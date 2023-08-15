using Apps.Pinecone.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pinecone.Models.Index.Requests;

public class ConfigureIndexRequest
{
    [Display("Index name")]
    [DataSource(typeof(IndexDataSourceHandler))]
    public string IndexName { get; set; }
    
    [Display("Number of replicas")]
    public int? Replicas { get; set; }
    
    [Display("Pod type")]
    [DataSource(typeof(PodTypeDataSourceHandler))]
    public string? PodType { get; set; }
}