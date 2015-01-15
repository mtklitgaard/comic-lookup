using System;
using ComicLookup.Services.Interfaces;

namespace ComicLookup.Services
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public string GetDateString()
        {
            return GetDate().ToString();
        }
    }
}