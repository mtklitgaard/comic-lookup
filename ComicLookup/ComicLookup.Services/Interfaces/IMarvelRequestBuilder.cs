using RestSharp;

namespace ComicLookup.Services.Interfaces
{
    public interface IMarvelRequestBuilder
    {
        RestRequest Build(string characterUrl, Method method);
    }
}