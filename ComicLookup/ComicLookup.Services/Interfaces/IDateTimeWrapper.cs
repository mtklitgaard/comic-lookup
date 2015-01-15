using System;

namespace ComicLookup.Services.Interfaces
{
    public interface IDateTimeWrapper
    {
        DateTime GetDate();
        string GetDateString();
    }
}