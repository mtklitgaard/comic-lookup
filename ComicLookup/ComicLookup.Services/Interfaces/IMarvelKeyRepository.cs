using System;

namespace ComicLookup.Services.Interfaces
{
    public interface IMarvelKeyRepository
    {
        string ApiKey { get; }
        string TimeStamp { get; }
        Uri MarvelBaseUrl { get; set; }
        string Hash();
    }
}