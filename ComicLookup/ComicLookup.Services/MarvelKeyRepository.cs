using System;
using System.Security.Cryptography;
using System.Text;
using ComicLookup.Services.Interfaces;

namespace ComicLookup.Services
{
    public class MarvelKeyRepository : IMarvelKeyRepository
    {
        const string PRIVATE_KEY = "PrivateKey"; 

        public string ApiKey { get { return "APIKEY"; } }
        public string TimeStamp { get; private set; }
        public Uri MarvelBaseUrl { get { return new Uri("https://gateway.marvel.com/"); } }

        public MarvelKeyRepository()
        {
            TimeStamp = DateTime.Now.ToString();
        }

        public string Hash()
        {
            var hash = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                var md5Results = md5.ComputeHash(Encoding.UTF8.GetBytes(TimeStamp+PRIVATE_KEY+ApiKey));

                for (int i = 0; i < md5Results.Length; i++)
                {
                    hash.Append(md5Results[i].ToString("x2"));
                }
            }
            return hash.ToString();
        }
    }
}