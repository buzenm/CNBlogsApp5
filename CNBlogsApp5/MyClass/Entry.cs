using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNBlogsApp5.MyClass
{
    [XmlRoot(ElementName = "entry")]
    public class Entry
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { set; get; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("published")]
        public DateTime Published { get; set; }

        [XmlElement("link", typeof(Link))]
        public Link Link { get; set; }

        [XmlElement("diggs")]
        public string Diggs { get; set; }

        [XmlElement("views")]
        public string Views { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("topicIcon")]
        public string TopicIcon { get; set; }

        [XmlElement("sourceName")]
        public string SourceName { get; set; }
    }
}
