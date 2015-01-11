namespace ComicLookup.Services.Interfaces
{
    public interface IJsonTranslator
    {
        T Deserialize<T>(string content);
    }
}