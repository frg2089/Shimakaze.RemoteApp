

using System.Xml.Serialization;

[XmlRoot(Namespace = "http://schemas.microsoft.com/ts/2007/05/tswf")]
public sealed class ResourceCollection
{
    [XmlAttribute]
    public DateTime PubDate { get; set; }
    [XmlAttribute]
    public string SchemaVersion { get; set; } = "1.1";

    public Publisher? Publisher { get; set; }
}

public sealed class Publisher
{
    [XmlAttribute]
    public string Name { get; set; } = "";
    [XmlAttribute]
    public string ID { get; set; } = "";
    [XmlAttribute]
    public string Description { get; set; } = "";
    [XmlAttribute]
    public DateTime LastUpdated { get; set; }

    [XmlArray]
    public Resource[]? Resources { get; set; }

    [XmlArray]
    public TerminalServer[]? TerminalServers { get; set; }
}

public sealed class Resource
{
    [XmlAttribute]
    public string ID { get; set; } = "";
    [XmlAttribute]
    public string Alias { get; set; } = "";
    [XmlAttribute]
    public string Title { get; set; } = "";
    [XmlAttribute]
    public DateTime LastUpdated { get; set; }
    [XmlAttribute]
    public string Type { get; set; } = "RemoteApp";

    [XmlArray]
    public FileExtension[]? FileExtensions { get; set; }
    [XmlArray]
    public HostingTerminalServer[]? HostingTerminalServers { get; set; }
}

public sealed class Icons
{
    public IconRaw? IconRaw{ get; set; }
    public Icon32? Icon32{ get; set; }
}

public sealed class IconRaw
{
    [XmlAttribute]
    public string FileType { get; set; } = "";
    [XmlAttribute]
    public string FileURL { get; set; } = "";
}

public sealed class Icon32
{
    [XmlAttribute]
    public string Dimensions { get; set; } = "";
    [XmlAttribute]
    public string FileType { get; set; } = "";
    [XmlAttribute]
    public string FileURL { get; set; } = "";
}

public sealed class FileExtension
{
    [XmlAttribute]
    public string Name { get; set; } = "";
    [XmlAttribute]
    public bool PrimaryHandler { get; set; } = true;

    [XmlArray]
    public IconRaw[]? FileAssociationIcons { get; set; }
}

public sealed class HostingTerminalServer
{
    [XmlElement]
    public ResourceFile? ResourceFile { get; set; }
    [XmlElement]
    public TerminalServerRef? TerminalServerRef { get; set; }
}

public sealed class ResourceFile
{
    [XmlAttribute]
    public string FileExtension { get; set; } = "";
    [XmlAttribute]
    public string URL { get; set; } = "";
}


public sealed class TerminalServerRef
{
    [XmlAttribute]
    public string Ref { get; set; } = "";
}

public sealed class TerminalServer
{
    [XmlAttribute]
    public string Name { get; set; } = "";
    [XmlAttribute]
    public string ID { get; set; } = "";
    [XmlAttribute]
    public DateTime LastUpdated { get; set; }
}