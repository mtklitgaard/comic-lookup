using System;
using ComicLookup.Services.Interfaces;

namespace ComicLookup.Services
{
    public class MarvelKeyRepository : IMarvelKeyRepository
    {
        public string ApiKey { get; private set; }
        public string TimeStamp { get; private set; }
        public Uri MarvelBaseUrl { get; private set; }
        public string Hash()
        { 
            //Input secret key building here
        }
    }
}