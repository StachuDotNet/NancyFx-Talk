using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Caching
{
    /// <summary>
    /// Wraps a regular response in a cached response
    /// The cached response invokes the old response and stores it as a string.
    /// Obviously this only works for ASCII text based responses, so don't use this 
    /// in a real application :-)
    /// </summary>
    public class CachedResponse : Response
    {
        private readonly string oldResponseOutput;

        public CachedResponse(Response response)
        {
            this.ContentType = response.ContentType;
            this.Headers = response.Headers;
            this.StatusCode = response.StatusCode;

            using (var memoryStream = new MemoryStream())
            {
                response.Contents.Invoke(memoryStream);
                this.oldResponseOutput = Encoding.ASCII.GetString(memoryStream.GetBuffer());
            }

            this.Contents = GetContents(this.oldResponseOutput);
        }

        protected static Action<Stream> GetContents(string contents)
        {
            return stream =>
            {
                var writer = new StreamWriter(stream) { AutoFlush = true };
                writer.Write(contents);
            };
        }
    }
}