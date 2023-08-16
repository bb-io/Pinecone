using Newtonsoft.Json;

namespace Apps.Pinecone.Converters;

public class ObjectToStringConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => false;
    
    public override string ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
            return serializer.Deserialize<object>(reader).ToString();

        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}