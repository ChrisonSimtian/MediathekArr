﻿using System.Xml;
using System.Xml.Serialization;

namespace MediathekArr.Models;

public class Channel
{
    [XmlElement("title")]
    public string Title { get; set; }

    [XmlElement("description")]
    public string Description { get; set; }

    [XmlElement("newznab:response", Namespace = "http://www.newznab.com/DTD/2010/feeds/attributes/")]
    public NewznabResponse Response { get; set; }

    [XmlElement("item")]
    public List<Item> Items { get; set; } = new List<Item>();
}
