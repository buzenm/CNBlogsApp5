using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNBlogsApp5.MyClass
{
    public class NewsBody
    {
        [XmlElement("Title")]
        public string title { get; set; }

        [XmlElement("SourceName")]
        public string sourceName { get; set; }

        [XmlElement("SubmitData")]
        public DateTime submitdate { get; set; }

        [XmlElement("Content")]
        public string content { get; set; }

        [XmlElement("ImageUrl")]
        public string imageUrl { get; set; }

        [XmlElement("PrevNews")]
        public string prevName { get; set; }

        [XmlElement("NextNews")]
        public string nextName { get; set; }

        [XmlElement("CommentCount")]
        public string commentCount { get; set; }
    }
}
