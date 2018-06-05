using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNBlogsApp5.MyClass
{
    public class BlogEntry:Entry
    {
        [XmlElement("author",typeof(Author))]
        public Author Author { get; set; }
    }
}
