using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNBlogsApp5.MyClass
{
    [XmlRoot("feed",Namespace="http://www.w3.org/2005/Atom")]
    public class Feed<T>
    {
        [XmlElement("title")]
        public string Title { set; get; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("entry")]
        public List<T> Entries { get; set; }
    }

    public enum NewsTitle
    {
        最新,
        热门,
        推荐
    }

    public class NewsEnumList
    {
        public string Name { get; set; }
    }
}
