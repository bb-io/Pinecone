using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Pinecone;

public class PineconeRequest : RestRequest
{
    public PineconeRequest(string endpoint, Method method,
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
    {
        this.AddHeader("Api-Key", authenticationCredentialsProviders.First(p => p.KeyName == "Authorization").Value);
    }
}