﻿using Apps.Pinecone.Extensions;
using Apps.Pinecone.Models.Vector.Requests;
using Apps.Pinecone.Models.Vector.Responses;
using Apps.Pinecone.UrlBuilders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Pinecone.Actions;

[ActionList]
public class VectorActions
{
    [Action("Query", Description = "Using the query vector, retrieve the most similar vectors to it.")]
    public async Task<QueryResponse> Query(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] QueryRequest input)
    {
        if (input.FilterJsonMetadata != null && !input.FilterJsonMetadata.IsValidJson())
            throw new Exception("Metadata must be in JSON format. Example of valid JSON: { \"key\": \"value\", \"key2\": \"value2\" }");

        var urlBuilder = new VectorOperationsBaseUrlBuilder(input.IndexName, authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/query", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            input.Namespace,
            input.TopK,
            input.IncludeValues,
            input.IncludeMetadata,
            input.Vector,
            Filter = input.FilterJsonMetadata?.DeserializeContent<Dictionary<string, object>>()
        });
        
        var response = await client.ExecuteWithHandling<QueryResponse>(request);
        return response;
    }
    
    [Action("Fetch vector", Description = "Fetch vector by its ID.")]
    public async Task<FetchVectorResponse> FetchVector(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] FetchVectorRequest input)
    {
        var urlBuilder = new VectorOperationsBaseUrlBuilder(input.IndexName, authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/vectors/fetch?ids={input.VectorId}&namespace={input.Namespace ?? ""}", 
            Method.Get, authenticationCredentialsProviders);

        var result = await client.ExecuteWithHandling<FetchVectorResponseWrapper>(request);
        
        if (!result.Vectors.TryGetValue(input.VectorId, out var response))
            throw new Exception("Vector with ID provided was not found.");

        return response;
    }

    [Action("Upsert vector", Description = "Upsert the vector.")]
    public async Task<UpsertVectorResponse> UpsertVector(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] UpsertVectorRequest input)
    {
        if (input.JsonMetadata != null && !input.JsonMetadata.IsValidJson())
            throw new Exception("Metadata must be in JSON format. Example of valid JSON: { \"key\": \"value\", \"key2\": \"value2\" }");

        var urlBuilder = new VectorOperationsBaseUrlBuilder(input.IndexName, authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/vectors/upsert", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            Vectors = new[]
            {
                new
                {
                    Id = input.VectorId,
                    Values = input.Vector,
                    Metadata = input.JsonMetadata?.DeserializeContent<Dictionary<string, object>>()
                }
            },
            input.Namespace
        });
        
        await client.ExecuteWithHandling(request);
        return new UpsertVectorResponse { VectorId = input.VectorId };
    }
    
    [Action("Delete vector", Description = "Delete vector by its ID.")]
    public async Task DeleteVector(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] DeleteVectorRequest input)
    {
        var urlBuilder = new VectorOperationsBaseUrlBuilder(input.IndexName, authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/vectors/delete", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            Ids = new[] { input.VectorId },
            input.Namespace
        });

        await client.ExecuteWithHandling(request);
    }
    
    [Action("Delete all vectors in namespace", Description = "Delete all vectors in the index namespace.")]
    public async Task DeleteAllVectorsInNamespace(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] DeleteAllVectorsInNamespaceRequest input)
    {
        var urlBuilder = new VectorOperationsBaseUrlBuilder(input.IndexName, authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/vectors/delete", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            DeleteAll = true,
            input.Namespace
        });

        await client.ExecuteWithHandling(request);
    }
}