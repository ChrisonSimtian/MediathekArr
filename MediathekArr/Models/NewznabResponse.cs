﻿using System.Xml;
using System.Xml.Serialization;

namespace MediathekArr.Models;

public class NewznabResponse
{
    [XmlAttribute("offset")]
    public int Offset { get; set; }

    [XmlAttribute("total")]
    public int Total { get; set; }
}
