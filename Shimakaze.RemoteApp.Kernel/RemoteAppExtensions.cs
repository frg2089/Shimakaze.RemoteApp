
using Shimakaze.RemoteApp.Kernel.Rdp;
using Shimakaze.RemoteApp.Kernel.WebFeed;

namespace Shimakaze.RemoteApp.Kernel;

public static class RemoteAppExtensions
{
    public static RDPFile CreateRDPFile(this RemoteApp app, string hostname) => new()
    {
        Keyboardhook = 3,
        AllowDesktopComposition = 1,
        AllowFontSmoothing = 1,
        AlternateFullAddress = hostname,
        AlternateShell = "rdpinit.exe",
        Devicestoredirect = "*",
        Disableremoteappcapscheck = 1,
        Drivestoredirect = "*",
        FullAddress = hostname,
        PromptForCredentialsOnClient = 1,
        Promptcredentialonce = 0,
        Redirectcomports = 1,
        Redirectdrives = 1,
        Remoteapplicationmode = 1,
        Remoteapplicationname = app.FullName,
        Remoteapplicationprogram = $"||{app.Name}",
        SpanMonitors = 1,
        UseMultimon = 1,
        Remoteapplicationfileextensions = string.Join(',', app.FileTypeAssociations?.Select(i => $".{i.Extension}") ?? Array.Empty<string>())
    };

    public static Resource CreateWebFeedResource(
        this RemoteApp app,
        TerminalServerRef terminalServerRef,
        string rdpPath,
        string icoPath,
        string pngPath,
        DateTime lastUpdated,
        Action<FileTypeAssociation, string>? action = null) => new()
        {
            ID = app.Name,
            Alias = app.Name,
            Title = app.FullName,
            LastUpdated = lastUpdated.ToString("O"),
            Type = "RemoteApp",
            Icons = new()
            {
                IconRaw = new(icoPath),
                Icon32 = new(pngPath)
            },
            FileExtensions = app.FileTypeAssociations?.Select(i =>
            {
                string ext = i.Extension.TrimStart('.');
                action?.Invoke(i, ext);
                return new FileExtension()
                {
                    Name = ext,
                    FileAssociationIcons = new IconRaw[]{
                        new ($"{app.Name}.{ext}.ico")
                    },
                };

            }).ToArray() ?? Array.Empty<FileExtension>(),
            HostingTerminalServers = new HostingTerminalServer[]{
            new (){
                ResourceFile =  new(rdpPath),
                TerminalServerRef = terminalServerRef
            }
        }
        };
}