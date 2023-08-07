using Apps.Pinecone.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Responses;

public class QueryResponse
{
    [Display("Matching vectors")]
    public IEnumerable<MatchVectorDto> Matches { get; set; }
}