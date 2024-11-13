using System.Xml;
using System.Xml.Serialization;

namespace MediathekArr.Models;

public class Guid
{
    [XmlAttribute("isPermaLink")]
    public bool IsPermaLink { get; set; }

    [XmlText]
    public string Value { get; set; }
}
