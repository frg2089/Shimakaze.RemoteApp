using System.Drawing;
using System.Net;
using System.Xml.Serialization;

using Shimakaze.RemoteApp.Kernel;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var hostname = Dns.GetHostName();

RemoteApps remoteApps = new();
Console.WriteLine($"DisableAppAllowList: {remoteApps.DisableAppAllowList}");
Console.WriteLine($"ResetBroken: {remoteApps.ResetBroken}");
Console.WriteLine($"AllowUnlistedRemotePrograms: {remoteApps.AllowUnlistedRemotePrograms}");
Console.WriteLine($"MaxDisconnectionTime: {remoteApps.MaxDisconnectionTime}");
Console.WriteLine($"MaxIdleTime: {remoteApps.MaxIdleTime}");
Console.WriteLine();


List<Resource> resources = new();
foreach (var app in remoteApps.GetRemoteApps())
{
    Console.WriteLine(app.Name);
    Console.WriteLine(app);
    Console.WriteLine();
    await File.WriteAllTextAsync(
        $"{app.Name}.rdp",
        new RDPFile()
        {
            allow_desktop_composition = 1,
            allow_font_smoothing = 1,
            alternate_full_address = hostname,
            alternate_shell = "rdpinit.exe",
            devicestoredirect = "*",
            disableremoteappcapscheck = 1,
            drivestoredirect = "*",
            full_address = hostname,
            prompt_for_credentials_on_client = 1,
            promptcredentialonce = 0,
            redirectcomports = 1,
            redirectdrives = 1,
            remoteapplicationmode = 1,
            remoteapplicationname = app.FullName,
            remoteapplicationprogram = $"||{app.Name}",
            span_monitors = 1,
            use_multimon = 1,
            remoteapplicationfileextensions = string.Join(',', app.FileTypeAssociations?.Select(i => $".{i.Extension}") ?? Array.Empty<string>())
        }.GetRDPstring());

    using Icon? ico = Icon.ExtractAssociatedIcon(app.IconPath);

    if (ico is not null)
    {
        ico.ToBitmap().Save($"{app.Name}.ico", System.Drawing.Imaging.ImageFormat.Icon);
        ico.ToBitmap().Save($"{app.Name}.png", System.Drawing.Imaging.ImageFormat.Png);
    }


    FileInfo fileInfo = new($"{app.Name}.rdp");
    resources.Add(new Resource()
    {
        ID = app.Name,
        Alias = app.Name,
        Title = app.FullName,
        LastUpdated = fileInfo.LastWriteTimeUtc.ToString("O"),
        Type = "RemoteApp",
        Icons = new()
        {
            IconRaw = new() { FileURL = $"{app.Name}.ico" },
            Icon32 = new() { FileURL = $"{app.Name}.png" }
        },
        FileExtensions = app.FileTypeAssociations?.Select(i => new FileExtension()
        {
            Name = i.Extension.TrimStart('.'),
            FileAssociationIcons = new[]{new IconRaw(){
                FileURL = $"{app.Name}.{i.Extension.TrimStart('.')}.ico"
            }},
        }).ToArray() ?? Array.Empty<FileExtension>(),
        HostingTerminalServers = new[]{
            new HostingTerminalServer(){
                ResourceFile = new(){
                    URL=$"{app.Name}.rdp",
                },
                TerminalServerRef = new(){
                    Ref = hostname
                }
            }
        }
    });
}

ResourceCollection xml = new()
{
    PubDate = DateTime.UtcNow.ToString("O"),
    Publisher = new()
    {
        Name = hostname,
        ID = hostname,
        LastUpdated = DateTime.UtcNow.ToString("O"),
        Resources = resources.ToArray(),
        TerminalServers = new[]{
            new TerminalServer(){
                Name = hostname,
                ID = hostname,
                LastUpdated = DateTime.UtcNow.ToString("O"),
            }
        }
    }
};

XmlSerializer serializer = new(typeof(ResourceCollection));
using var sw = new StreamWriter(Console.OpenStandardError(), System.Text.Encoding.UTF8);
serializer.Serialize(sw, xml);

