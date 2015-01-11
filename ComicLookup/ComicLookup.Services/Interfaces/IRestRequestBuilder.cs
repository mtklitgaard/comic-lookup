using RestSharp;

namespace ComicLookup.Services.Interfaces
{
    public interface IRestRequestBuilder
    {
        RestRequest Build(string empty, Method methodType);
    }
}