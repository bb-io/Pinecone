using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Index.Requests;

public class CreateCollectionRequest
{
    [Display("Collection name")]
    public string CollectionName { get; set; }
    
    [Display("Source index name")]
    public string SourceIndex { get; set; }
}