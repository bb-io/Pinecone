using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Index.Responses;

public class IndexResponse
{
    [Display("Index name")]
    public string IndexName { get; set; }
}