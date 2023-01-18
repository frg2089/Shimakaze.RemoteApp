using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

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
                screen_mode_id = 1,
                use_multimon = 0,
                desktopwidth = 1024,
                desktopheight = 768,
                session_bpp = 32,
                compression = 1,
                keyboardhook = 1,
                audiocapturemode = 1,
                videoplaybackmode = 1,
                connection_type = 7,
                networkautodetect = 1,
                bandwidthautodetect = 1,
                displayconnectionbar = 1,
                disable_wallpaper = 0,
                allow_font_smoothing = 0,
                allow_desktop_composition = 0,
                disable_full_window_drag = 1,
                disable_menu_anims = 1,
                disable_themes = 0,
                bitmapcachepersistenable = 1,
                full_address = Hostname,
                audiomode = 0,
                redirectprinters = 1,
                redirectlocation = 1,
                redirectcomports = 0,
                redirectsmartcards = 1,
                redirectwebauthn = 1,
                redirectclipboard = 1,
                redirectposdevices = 0,
                autoreconnection_enabled = 1,
                authentication_level = 2,
                prompt_for_credentials = 0,
                negotiate_security_layer = 1,
                remoteapplicationmode = 0,
                alternate_shell = string.Empty,
                shell_working_directory = string.Empty,
                gatewayhostname = string.Empty,
                gatewayusagemethod = 4,
                gatewaycredentialssource = 4,
                gatewayprofileusagemethod = 0,
                promptcredentialonce = 0,
                kdcproxyname = string.Empty,
                enablerdsaadauth = 0,
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
