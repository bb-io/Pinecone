using Apps.Pinecone.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pinecone.Models.Vector.Requests;

public class QueryRequest
{
    [Display("Index name")] 
    [DataSource(typeof(IndexDataSourceHandler))]
    public string IndexName { get; set; }

    [Display("Query vector")]
    public IEnumerable<float> Vector { get; set; }
    
    [Display("Number of most relevant results to return")]
    public int TopK { get; set; }
    
    [Display("Include vector values")]
    public bool IncludeValues { get; set; }
    
    [Display("Include vector metadata")]
    public bool? IncludeMetadata { get; set; }

    [Display("Filter metadata in JSON format")]
    public string? FilterJsonMetadata { get; set; }

    public string? Namespace { get; set; }
}