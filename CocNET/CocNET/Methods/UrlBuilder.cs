using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CocNET.Methods
{
    public class UrlBuilder
    {
        /// <summary>
        /// Create your query part of url.
        /// </summary>
        /// <param name="root">Parent directory</param>
        /// <param name="query">Collection with key/value queries.</param>
        /// <returns></returns>
        public static Uri BuildUri(string root, NameValueCollection query)
        {
            var collection = HttpUtility.ParseQueryString(string.Empty);
            foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
            {
                collection[key] = query[key];
            }
            var builder = new UriBuilder(root) { Query = collection.ToString() };
            return builder.Uri;
        }
    }
}
