﻿using MediathekArr.Models.Newznab;
using System.Xml.Serialization;

namespace MediathekArr.Utilities;
public static class NewznabUtils
{
    public static class Application
    {
        public const string Nzb = "application/x-nzb";
    }

    public static List<Models.Newznab.Attribute> GenerateAttributes(string? season, string[] categoryValues)
    {
        var attributes = new List<Models.Newznab.Attribute>();

        foreach (var categoryValue in categoryValues)
        {
            attributes.Add(new Models.Newznab.Attribute { Name = "category", Value = categoryValue });
        }

        if (season != null)
        {
            attributes.Add(new Models.Newznab.Attribute { Name = "season", Value = season });
        }

        return attributes;
    }

    public static string SerializeRss(Rss rss)
    {
        var serializer = new XmlSerializer(typeof(Rss));

        // Define the namespaces and add the newznab namespace
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("newznab", "http://www.newznab.com/DTD/2010/feeds/attributes/");

        using var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, rss, namespaces);

        // TODO quick fix
        string result = stringWriter.ToString();
        result = result.Replace(":newznab_x003A_", ":");

        return result;
    }

    public static Rss GetEmptyRssResult() => Factories.RssFactory.Empty;
}