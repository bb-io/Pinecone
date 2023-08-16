using Newtonsoft.Json;

namespace Apps.Pinecone.Extensions;

public static class SerializationExtensions
{
    public static T DeserializeContent<T>(this string content)
    {
        var deserializedContent = JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            }
        );
        return deserializedContent;
    }
}