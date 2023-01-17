
using Shimakaze.RemoteApp.Kernel.Rdp;
using Shimakaze.RemoteApp.Kernel.WebFeed;

namespace Shimakaze.RemoteApp.Kernel;

public static class RemoteAppExtensions
{
    public static RDPFile CreateRDPFile(this RemoteApp app, string hostname) => new()
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
    };

    public static Resource CreateWebFeedResource(this RemoteApp app, string hostname, string rdpPath, string icoPath, string pngPath, DateTime lastUpdated) => new()
    {
        ID = app.Name,
        Alias = app.Name,
        Title = app.FullName,
        LastUpdated = lastUpdated.ToString("O"),
        Type = "RemoteApp",
        Icons = new()
        {
            IconRaw = new() { FileURL = icoPath },
            Icon32 = new() { FileURL = pngPath }
        },
        FileExtensions = app.FileTypeAssociations?.Select(i => new FileExtension()
        {
            Name = i.Extension.TrimStart('.'),
            FileAssociationIcons = new IconRaw[]{
                new (){
                    FileURL = $"{app.Name}.{i.Extension.TrimStart('.')}.ico"
                }
            },
        }).ToArray() ?? Array.Empty<FileExtension>(),
        HostingTerminalServers = new HostingTerminalServer[]{
            new (){
                ResourceFile = new(){
                    URL = rdpPath,
                },
                TerminalServerRef = new(){
                    Ref = hostname
                }
            }
        }
    };
}