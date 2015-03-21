using Nancy;
using System;
using System.Collections.Generic;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Caching.CachingExtensions;

namespace Caching
{
    public class CachingBootstrapper : DefaultNancyBootstrapper
    {
        private readonly Dictionary<string, Tuple<DateTime, Response, int>> _cachedResponses = new Dictionary<string, Tuple<DateTime, Response, int>>();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest += CheckCache;

            pipelines.AfterRequest += SetCache;
        }

        public Response CheckCache(NancyContext context)
        {
            Tuple<DateTime, Response, int> cacheEntry;

            if (_cachedResponses.TryGetValue(context.Request.Path, out cacheEntry))
                if (cacheEntry.Item1.AddSeconds(cacheEntry.Item3) > DateTime.Now)
                    return cacheEntry.Item2;

            return null;
        }

        public void SetCache(NancyContext context)
        {
            if (context.Response.StatusCode != HttpStatusCode.OK)
                return;

            object cacheSecondsObject;
            if (!context.Items.TryGetValue(ContextExtensions.OutputCacheTimeKey, out cacheSecondsObject))
                return;

            int cacheSeconds;
            if (!int.TryParse(cacheSecondsObject.ToString(), out cacheSeconds))
                return;

            var cachedResponse = new CachedResponse(context.Response);

            _cachedResponses[context.Request.Path] = new Tuple<DateTime, Response, int>(DateTime.Now, cachedResponse, cacheSeconds);

            context.Response = cachedResponse;
        }
    }
}