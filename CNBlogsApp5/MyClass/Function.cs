using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Web.Http;

namespace CNBlogsApp5.MyClass
{
    public class Function
    {
        
        public static async Task<string> GetNewsListStringAsync(Uri uri)
        {
            
            HttpClient client = new HttpClient();
            string xs = "";
            try
            {
                xs = await client.GetStringAsync(uri);
            }
            catch (Exception)
            {

                throw;
            }
            
            xs = xs.Replace("&amp;rdquo;", "\"");
            xs = xs.Replace("&amp;ldquo;", "\"");
            xs = xs.Replace("&amp;ldqu", "\"");
            xs = xs.Replace("&amp;middot;", "·");
            xs = xs.Replace("&amp;hellip;", "…");
            //xs=xs.Replace("<img", "<img style=\"max-width: 100%\"");
            return xs;


        }

        public static T Derserlializer<T>(string xml)
        {
            T result = default(T);
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                result = (T)xs.Deserialize(sr);
            }
            return result;
        }
    }
}
