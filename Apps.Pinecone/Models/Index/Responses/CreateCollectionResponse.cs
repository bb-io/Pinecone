using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Index.Responses;

public class CreateCollectionResponse
{
    [Display("Collection name")]
    public string CollectionName { get; set; }
}