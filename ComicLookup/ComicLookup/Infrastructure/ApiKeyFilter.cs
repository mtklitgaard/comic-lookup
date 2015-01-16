using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject;

namespace ComicLookup.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiKeyFilter : AuthorizationFilterAttribute
    {
        private const string hiddenApiKey = "ApiKey";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;

            IEnumerable<string> apiKeyHeaders = null;
            headers.TryGetValues("ApiKey", out apiKeyHeaders);

            var givenApiKey = string.Empty;
            if (apiKeyHeaders != null)
            {
                givenApiKey = apiKeyHeaders.FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(givenApiKey) || givenApiKey != hiddenApiKey)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            base.OnAuthorization(actionContext);
        }
    }
}