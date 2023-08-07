using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Pinecone.Dtos;

public class IndexDto
{
    public string Name { get; set; }
    
    public string Metric { get; set; }
    
    public int Dimension { get; set; }
    
    [Display("Number of replicas")]
    public int Replicas { get; set; }
    
    [Display("Number of pods")]
    public int Pods { get; set; }
    
    [Display("Pod type")]
    public string PodType { get; set; }
    
    [Display("Is ready")]
    public bool IsReady { get; set; }
    
    public string State { get; set; }
    
    public string Host { get; set; }
}

public class IndexDtoWrapper
{
    public IndexDatabaseDto Database { get; set; }
    public StatusDto Status { get; set; }
}

public class IndexDatabaseDto
{
    public string Name { get; set; }
    public string Metric { get; set; }
    public int Dimension { get; set; }
    public int Replicas { get; set; }
    public int Pods { get; set; }
    
    [JsonProperty("pod_type")]
    public string PodType { get; set; }
}

public class StatusDto
{
    public bool Ready { get; set; }
    public string State { get; set; }
    public string Host { get; set; }
}