using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Dtos;

public class VectorDto
{
    public string Id { get; set; }

    [Display("Vector")]
    public float[] Values { get; set; }
}