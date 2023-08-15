using Apps.Pinecone.DataSourceHandlers;
using Apps.Pinecone.Dtos;
using Apps.Pinecone.Models.Index.Requests;
using Apps.Pinecone.Models.Index.Responses;
using Apps.Pinecone.UrlBuilders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using RestSharp;

namespace Apps.Pinecone.Actions;

[ActionList]
public class IndexActions
{
    #region Indexes
    
    [Action("List indexes", Description = "Retrieve a list of your indexes.")]
    public async Task<ListIndexesResponse> ListIndexes(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/databases", Method.Get, authenticationCredentialsProviders);
        var indexes = await client.ExecuteWithHandling<IEnumerable<string>>(request);
        return new ListIndexesResponse { Indexes = indexes };
    }
    
    [Action("Create index", Description = "Create a new index.")]
    public async Task<IndexDto> CreateIndex(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] CreateIndexRequest input)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/databases", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            input.Name,
            input.Dimension,
            Metric = input.Metric ?? "cosine",
            Pods = input.PodsNumber,
            Replicas = input.NumberOfReplicas,
            Pod_type = input.PodType,
            Source_collection = input.SourceCollection
        });

        await client.ExecuteWithHandling(request);
        return new IndexDto { Name = input.Name };
    }
    
    [Action("Describe index", Description = "Get a description of an index by its name.")]
    public async Task<IndexDto> DescribeIndex(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Index name")] [DataSource(typeof(IndexDataSourceHandler))] string indexName)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/databases/{indexName}", Method.Get, authenticationCredentialsProviders);
        var index = await client.ExecuteWithHandling<IndexDtoWrapper>(request);
        return new IndexDto
        {
            Name = index.Database.Name,
            Metric = index.Database.Metric,
            Dimension = index.Database.Dimension,
            Replicas = index.Database.Replicas,
            Pods = index.Database.Pods,
            PodType = index.Database.PodType,
            IsReady = index.Status.Ready,
            State = index.Status.State,
            Host = index.Status.Host
        };
    }
    
    [Action("Configure index", Description = "Specify the pod type and/or number of replicas for an index.")]
    public async Task<IndexDto> ConfigureIndex(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ConfigureIndexRequest input)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/databases/{input.IndexName}", Method.Patch, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            input.Replicas,
            Pod_type = input.PodType
        });
        
        await client.ExecuteWithHandling(request);
        return new IndexDto { Name = input.IndexName };
    }
    
    [Action("Delete index", Description = "Delete an existing index by its name.")]
    public async Task DeleteIndex(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Index name")] [DataSource(typeof(IndexDataSourceHandler))] string indexName)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/databases/{indexName}", Method.Delete, authenticationCredentialsProviders);
        await client.ExecuteWithHandling(request);
    }
    
    #endregion
    
    #region Collections
    
    [Action("List collections", Description = "Retrieve a list of your collections.")]
    public async Task<ListCollectionsResponse> ListCollections(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/collections", Method.Get, authenticationCredentialsProviders);
        var collections = await client.ExecuteWithHandling<IEnumerable<string>>(request);
        return new ListCollectionsResponse { Collections = collections };
    }
    
    [Action("Create collection", Description = "Create a collection from index.")]
    public async Task<CollectionDto> CreateCollection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] CreateCollectionRequest input)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest("/collections", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(new
        {
            Name = input.CollectionName,
            Source = input.SourceIndex
        });
        
        await client.ExecuteWithHandling(request);
        return new CollectionDto { Name = input.CollectionName };
    }
    
    [Action("Describe collection", Description = "Get a description of a collection by its name.")]
    public async Task<CollectionDto> DescribeCollection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Collection name")] [DataSource(typeof(CollectionDataSourceHandler))] string collectionName)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/collections/{collectionName}", Method.Get, authenticationCredentialsProviders);
        var collection = await client.ExecuteWithHandling<CollectionDto>(request);
        return collection;
    }
    
    [Action("Delete collection", Description = "Delete an existing collection by its name.")]
    public async Task DeleteCollection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Collection name")] [DataSource(typeof(CollectionDataSourceHandler))] string collectionName)
    {
        var urlBuilder = new IndexOperationsBaseUrlBuilder(authenticationCredentialsProviders);
        var client = new PineconeClient(urlBuilder);
        var request = new PineconeRequest($"/collections/{collectionName}", Method.Delete, authenticationCredentialsProviders);
        await client.ExecuteWithHandling(request);
    }
    
    #endregion
}