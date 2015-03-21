using Nancy;

namespace Caching.CachingExtensions
{
    public static class ContextExtensions
    {
        public const string OutputCacheTimeKey = "OUTPUT_CACHE_TIME";

        /// <summary>Enable output caching for this route</summary>
        public static void EnableOutputCache(this NancyContext context, int seconds)
        {
            context.Items[OutputCacheTimeKey] = seconds;
        }

        /// <summary>Disable the output cache for this route</summary>
        public static void DisableOutputCache(this NancyContext context)
        {
            context.Items.Remove(OutputCacheTimeKey);
        }
    }
}