using Newtonsoft.Json;

namespace Apps.Pinecone.Dtos;

public class ProjectDto
{
    [JsonProperty("project_name")]
    public string ProjectId { get; set; }
}