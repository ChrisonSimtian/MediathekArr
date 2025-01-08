﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvdb.Models;

/// <summary>
/// An alias model, which can be associated with a series, season, movie, person, or list.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Alias
{
    /// <summary>
    /// A 3-4 character string indicating the language of the alias, as defined in Language.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    /// <summary>
    /// A string containing the alias itself.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base artwork record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ArtworkBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("height")]
    public long? Height { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("includesText")]
    public bool? IncludesText { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    /// <summary>
    /// The artwork type corresponds to the ids from the /artwork/types endpoint.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public long? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("width")]
    public long? Width { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended artwork record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ArtworkExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("episodeId")]
    public int? EpisodeId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("height")]
    public long? Height { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("includesText")]
    public bool? IncludesText { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movieId")]
    public int? MovieId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("networkId")]
    public int? NetworkId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("peopleId")]
    public int? PeopleId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasonId")]
    public int? SeasonId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public int? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesPeopleId")]
    public int? SeriesPeopleId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public ArtworkStatus Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbnailHeight")]
    public long? ThumbnailHeight { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbnailWidth")]
    public long? ThumbnailWidth { get; set; }

    /// <summary>
    /// The artwork type corresponds to the ids from the /artwork/types endpoint.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public long? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("width")]
    public long? Width { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// artwork status record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ArtworkStatus
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// artwork type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ArtworkType
{

    [System.Text.Json.Serialization.JsonPropertyName("height")]
    public long? Height { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageFormat")]
    public string ImageFormat { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("recordType")]
    public string RecordType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbHeight")]
    public long? ThumbHeight { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbWidth")]
    public long? ThumbWidth { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("width")]
    public long? Width { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base award record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AwardBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base award category record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AwardCategoryBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("allowCoNominees")]
    public bool? AllowCoNominees { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("award")]
    public AwardBaseRecord Award { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("forMovies")]
    public bool? ForMovies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("forSeries")]
    public bool? ForSeries { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended award category record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AwardCategoryExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("allowCoNominees")]
    public bool? AllowCoNominees { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("award")]
    public AwardBaseRecord Award { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("forMovies")]
    public bool? ForMovies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("forSeries")]
    public bool? ForSeries { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nominees")]
    public System.Collections.Generic.ICollection<AwardNomineeBaseRecord> Nominees { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended award record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AwardExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("categories")]
    public System.Collections.Generic.ICollection<AwardCategoryBaseRecord> Categories { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public long? Score { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base award nominee record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AwardNomineeBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("character")]
    public Character Character { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("details")]
    public string Details { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episode")]
    public EpisodeBaseRecord Episode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isWinner")]
    public bool? IsWinner { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movie")]
    public MovieBaseRecord Movie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("series")]
    public SeriesBaseRecord Series { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("category")]
    public string Category { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// biography record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Biography
{

    [System.Text.Json.Serialization.JsonPropertyName("biography")]
    public string Biography1 { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// character record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Character
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episode")]
    public RecordInfo Episode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episodeId")]
    public int? EpisodeId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isFeatured")]
    public bool? IsFeatured { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movieId")]
    public int? MovieId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movie")]
    public RecordInfo Movie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("peopleId")]
    public int? PeopleId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("personImgURL")]
    public string PersonImgURL { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("peopleType")]
    public string PeopleType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public int? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("series")]
    public RecordInfo Series { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sort")]
    public long? Sort { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public long? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("personName")]
    public string PersonName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// A company record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Company
{

    [System.Text.Json.Serialization.JsonPropertyName("activeDate")]
    public string ActiveDate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("inactiveDate")]
    public string InactiveDate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("primaryCompanyType")]
    public long? PrimaryCompanyType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("parentCompany")]
    public ParentCompany ParentCompany { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// A parent company record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ParentCompany
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("relation")]
    public CompanyRelationShip Relation { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// A company relationship
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class CompanyRelationShip
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("typeName")]
    public string TypeName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// A company type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class CompanyType
{

    [System.Text.Json.Serialization.JsonPropertyName("companyTypeId")]
    public int? CompanyTypeId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companyTypeName")]
    public string CompanyTypeName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// content rating record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ContentRating
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("description")]
    public string Description { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("order")]
    public int? Order { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("fullName")]
    public string FullName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// country record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Country
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("shortCode")]
    public string ShortCode { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Entity record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Entity
{

    [System.Text.Json.Serialization.JsonPropertyName("movieId")]
    public int? MovieId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("order")]
    public long? Order { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public int? SeriesId { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Entity Type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class EntityType
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("hasSpecials")]
    public bool? HasSpecials { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// entity update record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class EntityUpdate
{

    [System.Text.Json.Serialization.JsonPropertyName("entityType")]
    public string EntityType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("methodInt")]
    public int? MethodInt { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("method")]
    public string Method { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("extraInfo")]
    public string ExtraInfo { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("userId")]
    public int? UserId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("recordType")]
    public string RecordType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("recordId")]
    public long? RecordId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("timeStamp")]
    public long? TimeStamp { get; set; }

    /// <summary>
    /// Only present for episodes records
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("mergeToId")]
    public long? MergeToId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("mergeToEntityType")]
    public string MergeToEntityType { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base episode record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class EpisodeBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("absoluteNumber")]
    public int? AbsoluteNumber { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("aired")]
    public string Aired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsAfterSeason")]
    public int? AirsAfterSeason { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsBeforeEpisode")]
    public int? AirsBeforeEpisode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsBeforeSeason")]
    public int? AirsBeforeSeason { get; set; }

    /// <summary>
    /// season, midseason, or series
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("finaleType")]
    public string FinaleType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageType")]
    public int? ImageType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isMovie")]
    public long? IsMovie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("linkedMovie")]
    public int? LinkedMovie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("number")]
    public int? Number { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasonNumber")]
    public int? SeasonNumber { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasons")]
    public System.Collections.Generic.ICollection<SeasonBaseRecord> Seasons { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasonName")]
    public string SeasonName { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended episode record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class EpisodeExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aired")]
    public string Aired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsAfterSeason")]
    public int? AirsAfterSeason { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsBeforeEpisode")]
    public int? AirsBeforeEpisode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsBeforeSeason")]
    public int? AirsBeforeSeason { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("awards")]
    public System.Collections.Generic.ICollection<AwardBaseRecord> Awards { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("characters")]
    public System.Collections.Generic.ICollection<Character> Characters { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public System.Collections.Generic.ICollection<Company> Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("contentRatings")]
    public System.Collections.Generic.ICollection<ContentRating> ContentRatings { get; set; }

    /// <summary>
    /// season, midseason, or series
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("finaleType")]
    public string FinaleType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageType")]
    public int? ImageType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isMovie")]
    public long? IsMovie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("linkedMovie")]
    public int? LinkedMovie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("networks")]
    public System.Collections.Generic.ICollection<Company> Networks { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nominations")]
    public System.Collections.Generic.ICollection<AwardNomineeBaseRecord> Nominations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("number")]
    public int? Number { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("productionCode")]
    public string ProductionCode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remoteIds")]
    public System.Collections.Generic.ICollection<RemoteID> RemoteIds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasonNumber")]
    public int? SeasonNumber { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasons")]
    public System.Collections.Generic.ICollection<SeasonBaseRecord> Seasons { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("studios")]
    public System.Collections.Generic.ICollection<Company> Studios { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("trailers")]
    public System.Collections.Generic.ICollection<Trailer> Trailers { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public TranslationExtended Translations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// User favorites record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Favorites
{

    [System.Text.Json.Serialization.JsonPropertyName("series")]
    public System.Collections.Generic.ICollection<int> Series { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movies")]
    public System.Collections.Generic.ICollection<int> Movies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episodes")]
    public System.Collections.Generic.ICollection<int> Episodes { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("artwork")]
    public System.Collections.Generic.ICollection<int> Artwork { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("people")]
    public System.Collections.Generic.ICollection<int> People { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lists")]
    public System.Collections.Generic.ICollection<int> Lists { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Favorites record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class FavoriteRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("series")]
    public int? Series { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movie")]
    public int? Movie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episode")]
    public int? Episode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("artwork")]
    public int? Artwork { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("people")]
    public int? People { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("list")]
    public int? List { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// gender record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Gender
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base genre record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class GenreBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// language record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Language
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nativeName")]
    public string NativeName { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("shortCode")]
    public string ShortCode { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base list record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ListBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageIsFallback")]
    public bool? ImageIsFallback { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isOfficial")]
    public bool? IsOfficial { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remoteIds")]
    public System.Collections.Generic.ICollection<RemoteID> RemoteIds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tags")]
    public System.Collections.Generic.ICollection<TagOption> Tags { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public int? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended list record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ListExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("entities")]
    public System.Collections.Generic.ICollection<Entity> Entities { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageIsFallback")]
    public bool? ImageIsFallback { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isOfficial")]
    public bool? IsOfficial { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public long? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base movie record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class MovieBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public Status Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended movie record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class MovieExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("artworks")]
    public System.Collections.Generic.ICollection<ArtworkBaseRecord> Artworks { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("audioLanguages")]
    public System.Collections.Generic.ICollection<string> AudioLanguages { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("awards")]
    public System.Collections.Generic.ICollection<AwardBaseRecord> Awards { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("boxOffice")]
    public string BoxOffice { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("boxOfficeUS")]
    public string BoxOfficeUS { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("budget")]
    public string Budget { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("characters")]
    public System.Collections.Generic.ICollection<Character> Characters { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public Companies Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("contentRatings")]
    public System.Collections.Generic.ICollection<ContentRating> ContentRatings { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("first_release")]
    public Release First_release { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("genres")]
    public System.Collections.Generic.ICollection<GenreBaseRecord> Genres { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("inspirations")]
    public System.Collections.Generic.ICollection<Inspiration> Inspirations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lists")]
    public System.Collections.Generic.ICollection<ListBaseRecord> Lists { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalCountry")]
    public string OriginalCountry { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalLanguage")]
    public string OriginalLanguage { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("production_countries")]
    public System.Collections.Generic.ICollection<ProductionCountry> Production_countries { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("releases")]
    public System.Collections.Generic.ICollection<Release> Releases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remoteIds")]
    public System.Collections.Generic.ICollection<RemoteID> RemoteIds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("spoken_languages")]
    public System.Collections.Generic.ICollection<string> Spoken_languages { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public Status Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("studios")]
    public System.Collections.Generic.ICollection<StudioBaseRecord> Studios { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("subtitleLanguages")]
    public System.Collections.Generic.ICollection<string> SubtitleLanguages { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("trailers")]
    public System.Collections.Generic.ICollection<Trailer> Trailers { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public TranslationExtended Translations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base people record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class PeopleBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public long? Score { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended people record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class PeopleExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("awards")]
    public System.Collections.Generic.ICollection<AwardBaseRecord> Awards { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("biographies")]
    public System.Collections.Generic.ICollection<Biography> Biographies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("birth")]
    public string Birth { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("birthPlace")]
    public string BirthPlace { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("characters")]
    public System.Collections.Generic.ICollection<Character> Characters { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("death")]
    public string Death { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("gender")]
    public int? Gender { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("races")]
    public System.Collections.Generic.ICollection<Race> Races { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remoteIds")]
    public System.Collections.Generic.ICollection<RemoteID> RemoteIds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public long? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public TranslationExtended Translations { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// people type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class PeopleType
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// race record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Race
{

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// base record info
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class RecordInfo
{

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// release record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Release
{

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("date")]
    public string Date { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("detail")]
    public string Detail { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// remote id record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class RemoteID
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public long? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sourceName")]
    public string SourceName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// search result
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SearchResult
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<string> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public System.Collections.Generic.ICollection<string> Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companyType")]
    public string CompanyType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("director")]
    public string Director { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("first_air_time")]
    public string First_air_time { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("genres")]
    public System.Collections.Generic.ICollection<string> Genres { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image_url")]
    public string Image_url { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("is_official")]
    public bool? Is_official { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name_translated")]
    public string Name_translated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("network")]
    public string Network { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("objectID")]
    public string ObjectID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("officialList")]
    public string OfficialList { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviews")]
    public TranslationSimple Overviews { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview_translated")]
    public System.Collections.Generic.ICollection<string> Overview_translated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("poster")]
    public string Poster { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("posters")]
    public System.Collections.Generic.ICollection<string> Posters { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("primary_language")]
    public string Primary_language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remote_ids")]
    public System.Collections.Generic.ICollection<RemoteID> Remote_ids { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public string Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("studios")]
    public System.Collections.Generic.ICollection<string> Studios { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public TranslationSimple Translations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translationsWithLang")]
    public System.Collections.Generic.ICollection<string> TranslationsWithLang { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tvdb_id")]
    public string Tvdb_id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// search by remote reuslt is a base record for a movie, series, people, season or company search result
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SearchByRemoteIdResult
{

    [System.Text.Json.Serialization.JsonPropertyName("series")]
    public SeriesBaseRecord Series { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("people")]
    public PeopleBaseRecord People { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("movie")]
    public MovieBaseRecord Movie { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episode")]
    public EpisodeBaseRecord Episode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("company")]
    public Company Company { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// season genre record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeasonBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageType")]
    public int? ImageType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("number")]
    public long? Number { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public Companies Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public SeasonType Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// extended season record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeasonExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("artwork")]
    public System.Collections.Generic.ICollection<ArtworkBaseRecord> Artwork { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public Companies Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episodes")]
    public System.Collections.Generic.ICollection<EpisodeBaseRecord> Episodes { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("imageType")]
    public int? ImageType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("number")]
    public long? Number { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("trailers")]
    public System.Collections.Generic.ICollection<Trailer> Trailers { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public SeasonType Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagOptions")]
    public System.Collections.Generic.ICollection<TagOption> TagOptions { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public System.Collections.Generic.ICollection<Translation> Translations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// season type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeasonType
{

    [System.Text.Json.Serialization.JsonPropertyName("alternateName")]
    public string AlternateName { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string Type { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// A series airs day record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeriesAirsDays
{

    [System.Text.Json.Serialization.JsonPropertyName("friday")]
    public bool? Friday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("monday")]
    public bool? Monday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("saturday")]
    public bool? Saturday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sunday")]
    public bool? Sunday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("thursday")]
    public bool? Thursday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tuesday")]
    public bool? Tuesday { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("wednesday")]
    public bool? Wednesday { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// The base record for a series. All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeriesBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("averageRuntime")]
    public int? AverageRuntime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("defaultSeasonType")]
    public long? DefaultSeasonType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episodes")]
    public System.Collections.Generic.ICollection<EpisodeBaseRecord> Episodes { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("firstAired")]
    public string FirstAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isOrderRandomized")]
    public bool? IsOrderRandomized { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastAired")]
    public string LastAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nextAired")]
    public string NextAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalCountry")]
    public string OriginalCountry { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalLanguage")]
    public string OriginalLanguage { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public Status Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// The extended record for a series. All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SeriesExtendedRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsDays")]
    public SeriesAirsDays AirsDays { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("airsTime")]
    public string AirsTime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<Alias> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("artworks")]
    public System.Collections.Generic.ICollection<ArtworkExtendedRecord> Artworks { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("averageRuntime")]
    public int? AverageRuntime { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("characters")]
    public System.Collections.Generic.ICollection<Character> Characters { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("contentRatings")]
    public System.Collections.Generic.ICollection<ContentRating> ContentRatings { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("defaultSeasonType")]
    public long? DefaultSeasonType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("episodes")]
    public System.Collections.Generic.ICollection<EpisodeBaseRecord> Episodes { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("firstAired")]
    public string FirstAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lists")]
    public object Lists { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("genres")]
    public System.Collections.Generic.ICollection<GenreBaseRecord> Genres { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public string Image { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isOrderRandomized")]
    public bool? IsOrderRandomized { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastAired")]
    public string LastAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<string> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("companies")]
    public System.Collections.Generic.ICollection<Company> Companies { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nextAired")]
    public string NextAired { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalCountry")]
    public string OriginalCountry { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalLanguage")]
    public string OriginalLanguage { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("originalNetwork")]
    public Company OriginalNetwork { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("latestNetwork")]
    public Company LatestNetwork { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<string> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("remoteIds")]
    public System.Collections.Generic.ICollection<RemoteID> RemoteIds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("score")]
    public double? Score { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasons")]
    public System.Collections.Generic.ICollection<SeasonBaseRecord> Seasons { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("seasonTypes")]
    public System.Collections.Generic.ICollection<SeasonType> SeasonTypes { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("status")]
    public Status Status { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tags")]
    public System.Collections.Generic.ICollection<TagOption> Tags { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("trailers")]
    public System.Collections.Generic.ICollection<Trailer> Trailers { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("translations")]
    public TranslationExtended Translations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("year")]
    public string Year { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// source type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SourceType
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("postfix")]
    public string Postfix { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("prefix")]
    public string Prefix { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("slug")]
    public string Slug { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sort")]
    public long? Sort { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// status record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Status
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("keepUpdated")]
    public bool? KeepUpdated { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("recordType")]
    public string RecordType { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// studio record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class StudioBaseRecord
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("parentStudio")]
    public int? ParentStudio { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// tag record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Tag
{

    [System.Text.Json.Serialization.JsonPropertyName("allowsMultiple")]
    public bool? AllowsMultiple { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("helpText")]
    public string HelpText { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("options")]
    public System.Collections.Generic.ICollection<TagOption> Options { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// tag option record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TagOption
{

    [System.Text.Json.Serialization.JsonPropertyName("helpText")]
    public string HelpText { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tag")]
    public long? Tag { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagName")]
    public string TagName { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// trailer record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Trailer
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// translation record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Translation
{

    [System.Text.Json.Serialization.JsonPropertyName("aliases")]
    public System.Collections.Generic.ICollection<string> Aliases { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isAlias")]
    public bool? IsAlias { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("isPrimary")]
    public bool? IsPrimary { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overview")]
    public string Overview { get; set; }

    /// <summary>
    /// Only populated for movie translations.  We disallow taglines without a title.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("tagline")]
    public string Tagline { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// translation simple record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TranslationSimple : System.Collections.Generic.Dictionary<string, string>
{

}

/// <summary>
/// translation extended record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TranslationExtended
{

    [System.Text.Json.Serialization.JsonPropertyName("nameTranslations")]
    public System.Collections.Generic.ICollection<Translation> NameTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("overviewTranslations")]
    public System.Collections.Generic.ICollection<Translation> OverviewTranslations { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("alias")]
    public System.Collections.Generic.ICollection<string> Alias { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// a entity with selected tag option
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TagOptionEntity
{

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagName")]
    public string TagName { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("tagId")]
    public int? TagId { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// User info record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class UserInfo
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("language")]
    public string Language { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string Type { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Movie inspiration record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Inspiration
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("type_name")]
    public string Type_name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Movie inspiration type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class InspirationType
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("description")]
    public string Description { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("reference_name")]
    public string Reference_name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Production country record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ProductionCountry
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public long? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("country")]
    public string Country { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Companies by type record
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Companies
{

    [System.Text.Json.Serialization.JsonPropertyName("studio")]
    public System.Collections.Generic.ICollection<Company> Studio { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("network")]
    public System.Collections.Generic.ICollection<Company> Network { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("production")]
    public System.Collections.Generic.ICollection<Company> Production { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("distributor")]
    public System.Collections.Generic.ICollection<Company> Distributor { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("special_effects")]
    public System.Collections.Generic.ICollection<Company> Special_effects { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}