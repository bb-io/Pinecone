using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apps.Pinecone.Extensions;

public static class JsonExtensions
{
    public static bool IsValidJson(this string json)
    {
        try
        {
            JObject.Parse(json);
            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}