using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Responses;

public class UpsertVectorResponse
{
    [Display("Vector ID")]
    public string VectorId { get; set; }
}