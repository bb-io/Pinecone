using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Dtos;

public class CollectionDto
{
    public string Name { get; set; }
    
    public string Status { get; set; }
    
    [Display("Size in bytes")]
    public string Size { get; set; }
    
    public string Dimension { get; set; }
}