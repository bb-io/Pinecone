using Apps.Pinecone.UrlBuilders;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Pinecone.Connections
{
    public class ConnectionValidator : IConnectionValidator
    {
        public async ValueTask<ConnectionValidationResponse> ValidateConnection(
            IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
        {
            var urlBuilder = new IndexOperationsBaseUrlBuilder(authProviders);
            var client = new PineconeClient(urlBuilder);
            var request = new PineconeRequest("/actions/whoami", Method.Get, authProviders);

            try
            {
                await client.ExecuteWithHandling(request);
                return new() { IsValid = true };
            }
            catch
            {
                return new()
                {
                    IsValid = false,
                    Message = "Failed to connect. Please check you API key and environment connection parameters."
                };
            }
        }
    }
}
