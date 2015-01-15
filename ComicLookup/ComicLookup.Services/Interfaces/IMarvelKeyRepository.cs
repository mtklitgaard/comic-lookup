using System;

namespace ComicLookup.Services.Interfaces
{
    public interface IMarvelKeyRepository
    {
        string ApiKey { get; }
        Uri MarvelBaseUrl { get; }
        string Hash(string timeStamp);
    }
}