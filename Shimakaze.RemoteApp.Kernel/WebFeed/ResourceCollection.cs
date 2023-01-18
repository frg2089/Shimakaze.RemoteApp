

using System.Xml.Serialization;

namespace Shimakaze.RemoteApp.Kernel.WebFeed;

[XmlRoot(Namespace = "http://schemas.microsoft.com/ts/2007/05/tswf")]
public sealed class ResourceCollection
{
    [XmlAttribute]
    public string PubDate { get; set; } = "";
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
    public string LastUpdated { get; set; } = "";

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
    public string LastUpdated { get; set; } = "";
    [XmlAttribute]
    public string Type { get; set; } = "RemoteApp";

    public Icons? Icons { get; set; }

    [XmlArray]
    public FileExtension[]? FileExtensions { get; set; }
    [XmlArray]
    public HostingTerminalServer[]? HostingTerminalServers { get; set; }
}

public sealed class Icons
{
    public IconRaw? IconRaw { get; set; }
    public Icon32? Icon32 { get; set; }
}

public sealed class IconRaw
{
    public IconRaw() : this(string.Empty)
    {
    }

    public IconRaw(string fileURL)
    {
        FileURL = fileURL;
    }

    [XmlAttribute]
    public string FileType { get; set; } = "Ico";
    [XmlAttribute]
    public string FileURL { get; set; }
}

public sealed class Icon32
{
    public Icon32() : this(string.Empty)
    {
    }

    public Icon32(string fileURL)
    {
        FileURL = fileURL;
    }

    [XmlAttribute]
    public string Dimensions { get; set; } = "32x32";
    [XmlAttribute]
    public string FileType { get; set; } = "Png";
    [XmlAttribute]
    public string FileURL { get; set; }
}

public sealed class FileExtension
{
    [XmlAttribute]
    public string Name { get; set; } = "";
    [XmlAttribute]
    public string PrimaryHandler { get; set; } = "True";

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
    public ResourceFile() : this(string.Empty)
    {
    }

    public ResourceFile(string uRL)
    {
        URL = uRL;
    }

    [XmlAttribute]
    public string FileExtension { get; set; } = ".rdp";
    [XmlAttribute]
    public string URL { get; set; }
}


public sealed class TerminalServerRef
{
    public TerminalServerRef() : this(string.Empty)
    {
    }

    public TerminalServerRef(string @ref)
    {
        Ref = @ref;
    }

    [XmlAttribute]
    public string Ref { get; set; }
}

public sealed class TerminalServer
{
    [XmlAttribute]
    public string Name { get; set; } = "";
    [XmlAttribute]
    public string ID { get; set; } = "";
    [XmlAttribute]
    public string LastUpdated { get; set; } = "";
}