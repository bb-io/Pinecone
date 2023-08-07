using Apps.Pinecone.Dtos;
using Apps.Pinecone.Extensions;
using Apps.Pinecone.UrlBuilders;
using RestSharp;

namespace Apps.Pinecone;

public class PineconeClient : RestClient
{
    public PineconeClient(IBaseUrlBuilder baseUrlBuilder) 
        : base(new RestClientOptions { ThrowOnAnyError = false, BaseUrl = GetBaseUrl(baseUrlBuilder) }) { }

    private static Uri GetBaseUrl(IBaseUrlBuilder baseUrlBuilder) => baseUrlBuilder.BuildBaseUrl();
    
    public async Task<T> ExecuteWithHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithHandling(request);
        return SerializationExtensions.DeserializeResponseContent<T>(response.Content);
    }

    private async Task<RestResponse> ExecuteWithHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        
        if (response.IsSuccessful)
            return response;

        throw ConfigureErrorException(response.Content);
    }

    private Exception ConfigureErrorException(string responseContent)
    {
        var error = SerializationExtensions.DeserializeResponseContent<ErrorDto>(responseContent);
        return new(error.Message);
    }
}