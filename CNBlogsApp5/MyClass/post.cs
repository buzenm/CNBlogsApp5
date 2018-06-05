using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNBlogsApp5.MyClass
{
    [XmlRoot("entry")]
    public class Post
    {
        [XmlElement]
        public string id { get; set; }
        [XmlElement]
        public DateTime published { get; set; }
        [XmlElement(typeof(Author))]
        public Author author { get; set; }
        [XmlElement]
        public string content { get; set; }
    }
}
