using Apps.Pinecone.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pinecone.Models.Vector.Requests;

public class UpsertVectorRequest
{
    [Display("Index name")] 
    [DataSource(typeof(IndexDataSourceHandler))]
    public string IndexName { get; set; }

    public float[] Vector { get; set; }
    
    public string? Namespace { get; set; }
}