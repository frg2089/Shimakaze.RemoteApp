using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.Net;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Kernel.Rdp;
using Shimakaze.RemoteApp.Kernel.WebFeed;

namespace Shimakaze.RemoteApp.Web;

public sealed class RemoteAppService
{
    private const string FileNotFoundMessage = "Cannot found {file} file. we will create it.";
    private readonly RemoteApps _apps;
    private readonly ILogger<RemoteAppService> _logger;
    private readonly IConfiguration _configuration;
    private static readonly string Hostname = Dns.GetHostName();
    private readonly string DefaultIconPath;
    private readonly int DefaultIconIndex;

    public RemoteAppService(RemoteApps apps, ILogger<RemoteAppService> logger, IConfiguration configuration)
    {
        _apps = apps;
        _logger = logger;
        _configuration = configuration;
        DefaultIconPath = configuration.GetValue<string>("DefaultIconPath") ?? string.Empty;
        DefaultIconIndex = configuration.GetValue<int>("DefaultIconIndex");
    }

    private void ExportIco(string source, int index, string target)
    {
        if (File.Exists(target))
            return;

        _logger.LogInformation(FileNotFoundMessage, target);

        MultiIcon mIcon = new();
        mIcon.Load(source);
        SingleIcon? sIcon = index < mIcon.Count
           ? mIcon[index]
           : default;

        if (sIcon is null)
        {
            index = DefaultIconIndex;

            mIcon.Load(DefaultIconPath);

            sIcon = index < mIcon.Count
               ? mIcon[index]
               : default;
        }

        sIcon?.Save(target);
    }

    private void ExportPng(string ico, string png)
    {
        if (File.Exists(png) || !File.Exists(ico))
            return;

        _logger.LogInformation(FileNotFoundMessage, png);

        using var image = Image.FromFile(ico);
        image.Save(png, ImageFormat.Png);
    }

    private async Task ExportRDP(Kernel.RemoteApp app, string rdp)
    {
        if (!File.Exists(rdp))
        {
            _logger.LogInformation(FileNotFoundMessage, rdp);
            await File.WriteAllTextAsync(rdp, app.CreateRDPFile(Hostname).ToString()).ConfigureAwait(false);
        }
    }


    private async Task<Resource> GetResource(Kernel.RemoteApp app, TerminalServerRef terminalServerRef, string path)
    {
        string png = $"{app.Name}.png";
        string ico = $"{app.Name}.ico";
        string rdp = $"{app.Name}.rdp";
        string extIco = $"{app.Name}.{{0}}.ico";
        string pngTruePath = Path.GetFullPath(Path.Combine(path, png));
        string icoTruePath = Path.GetFullPath(Path.Combine(path, ico));
        string rdpTruePath = Path.GetFullPath(Path.Combine(path, rdp));
        string extIcoTruePath = Path.GetFullPath(Path.Combine(path, extIco));

        Task task = ExportRDP(app, rdpTruePath);
        ExportIco(app.IconPath, app.IconIndex, icoTruePath);
        ExportPng(icoTruePath, pngTruePath);
        await task;

        return app.CreateWebFeedResource(
            terminalServerRef,
            rdp,
            ico,
            png,
            File.GetLastWriteTimeUtc(rdpTruePath),
            (item, ext) =>
            {
                if (!int.TryParse(item.IconIndex, out int i))
                    i = 0;

                string p = string.IsNullOrWhiteSpace(item.IconPath) ? app.IconPath : item.IconPath;
                ExportIco(p, i, string.Format(extIcoTruePath, ext));
            });
    }

    private async Task<Resource> GetDesktop(string dateTime, TerminalServerRef terminalServerRef, string path)
    {
        string rdp = $"{Hostname}.rdp";
        string rdpTruePath = Path.GetFullPath(Path.Combine(path, rdp));
        if (!File.Exists(rdpTruePath))
        {
            _logger.LogInformation(FileNotFoundMessage, rdpTruePath);

            RDPFile fRdp = new()
            {
                ScreenModeId = 1,
                UseMultimon = 0,
                Desktopwidth = 1024,
                Desktopheight = 768,
                SessionBpp = 32,
                Compression = 1,
                Keyboardhook = 1,
                Audiocapturemode = 1,
                Videoplaybackmode = 1,
                ConnectionType = 7,
                Networkautodetect = 1,
                Bandwidthautodetect = 1,
                Displayconnectionbar = 1,
                DisableWallpaper = 0,
                AllowFontSmoothing = 0,
                AllowDesktopComposition = 0,
                DisableFullWindowDrag = 1,
                DisableMenuAnims = 1,
                DisableThemes = 0,
                Bitmapcachepersistenable = 1,
                FullAddress = Hostname,
                Audiomode = 0,
                Redirectprinters = 1,
                Redirectlocation = 1,
                Redirectcomports = 0,
                Redirectsmartcards = 1,
                Redirectwebauthn = 1,
                Redirectclipboard = 1,
                Redirectposdevices = 0,
                AutoreconnectionEnabled = 1,
                AuthenticationLevel = 2,
                PromptForCredentials = 0,
                NegotiateSecurityLayer = 1,
                Remoteapplicationmode = 0,
                AlternateShell = string.Empty,
                ShellWorkingDirectory = string.Empty,
                Gatewayhostname = string.Empty,
                Gatewayusagemethod = 4,
                Gatewaycredentialssource = 4,
                Gatewayprofileusagemethod = 0,
                Promptcredentialonce = 0,
                Kdcproxyname = string.Empty,
                Enablerdsaadauth = 0,
            };
            await File.WriteAllTextAsync(rdpTruePath, fRdp.ToString()).ConfigureAwait(false);
        }


        return new()
        {
            ID = Hostname,
            Alias = Hostname,
            Title = Hostname,
            LastUpdated = dateTime,
            Type = "Desktop",
            HostingTerminalServers = new HostingTerminalServer[]
            {
                new()
                {
                    ResourceFile = new(rdp),
                    TerminalServerRef = terminalServerRef,
                }
            }
        };
    }

    public async Task<ResourceCollection> GetRDS()
    {
        string path = _configuration.GetValue<string>("StaticResourcesPath") ?? string.Empty;
        string dateTime = DateTime.UtcNow.ToString("O");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        TerminalServerRef terminalServerRef = new(Hostname);

        return new()
        {
            PubDate = dateTime,
            Publisher = new()
            {
                Name = Hostname,
                ID = Hostname,
                LastUpdated = dateTime,
                Resources = await Task.WhenAll(
                    _apps.GetRemoteApps()
                         .AsParallel()
                         .Select(app => GetResource(app, terminalServerRef, path))
                         .Append(GetDesktop(dateTime, terminalServerRef, path))),
                TerminalServers = new TerminalServer[]{
                    new (){
                        Name = Hostname,
                        ID = Hostname,
                        LastUpdated = dateTime,
                    }
                }
            }
        };
    }
}
