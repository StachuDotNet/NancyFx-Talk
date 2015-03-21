using Nancy;
using System;
using System.IO;
using System.Text;

namespace Caching
{
    /// <summary>Wraps a regular response in a cached response</summary>
    public class CachedResponse : Response
    {
	    public CachedResponse(Response response)
        {
	        string oldResponseOutput;
	        ContentType = response.ContentType;
			Headers = response.Headers;
			StatusCode = response.StatusCode;

            using (var memoryStream = new MemoryStream())
            {
                response.Contents.Invoke(memoryStream);
                oldResponseOutput = Encoding.ASCII.GetString(memoryStream.GetBuffer());
            }

            Contents = GetContents(oldResponseOutput);
        }

        protected static Action<Stream> GetContents(string contents)
        {
            return stream => new StreamWriter(stream) { AutoFlush = true }.Write(contents);
        }
    }
}