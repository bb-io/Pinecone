using Blackbird.Applications.Sdk.Common;

namespace Apps.Pinecone.Models.Vector.Requests;

public class DeleteAllVectorsInNamespaceRequest
{
    [Display("Index name")] 
    public string IndexName { get; set; }

    public string Namespace { get; set; }
}