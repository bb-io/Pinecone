using Apps.Pinecone.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pinecone.Models.Index.Requests;

public class CreateCollectionRequest
{
    [Display("Collection name")]
    public string CollectionName { get; set; }
    
    [Display("Source index name")]
    [DataSource(typeof(IndexDataSourceHandler))]
    public string SourceIndex { get; set; }
}