using System;
using System.Drawing;
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

    public RemoteAppService(RemoteApps apps, ILogger<RemoteAppService> logger, IConfiguration configuration)
    {
        _apps = apps;
        _logger = logger;
        _configuration = configuration;
    }

    private Icon GetIcon(string path, int index)
    {
        return IconLoader.GetImage(path)
            ?? IconLoader.GetImage(_configuration.GetValue<string>("DefaultIconPath") ?? string.Empty)
            ?? throw new InvalidOperationException("Cannot found icon");
    }

    private void ExportIcon(Lazy<Icon> icon, string ico, string png, bool leaveOpen = false)
    {
        if (!File.Exists(ico))
        {
            _logger.LogInformation(FileNotFoundMessage, ico);

            icon.Value.ToBitmap().Save(
                ico,
                System.Drawing.Imaging.ImageFormat.Icon);
        }

        if (!File.Exists(png))
        {
            _logger.LogInformation(FileNotFoundMessage, png);


            icon.Value.ToBitmap().Save(
                png,
                System.Drawing.Imaging.ImageFormat.Png
                );
        }

        if (icon.IsValueCreated && !leaveOpen)
        {
            icon.Value.Dispose();
        }
    }

    private async Task ExportRDP(Kernel.RemoteApp app, string rdp)
    {
        if (!File.Exists(rdp))
        {
            _logger.LogInformation(FileNotFoundMessage, rdp);
            await File.WriteAllTextAsync(rdp, app.CreateRDPFile(Hostname).ToString()).ConfigureAwait(false);
        }
    }

    public (string png, string ico, string rdp, string pngTruePath, string icoTruePath, string rdpTruePath) GetPaths(Kernel.RemoteApp app, string path)
    {
        string png = $"{app.Name}.png";
        string ico = $"{app.Name}.ico";
        string rdp = $"{app.Name}.rdp";
        string pngTruePath = Path.GetFullPath(Path.Combine(path, png));
        string icoTruePath = Path.GetFullPath(Path.Combine(path, ico));
        string rdpTruePath = Path.GetFullPath(Path.Combine(path, rdp));
        return (png, ico, rdp, pngTruePath, icoTruePath, rdpTruePath);
    }

    public async Task GenerateFilesIfNotExist(Kernel.RemoteApp app, string rdpTruePath, string icoTruePath, string pngTruePath)
    {
        Task task = ExportRDP(app, rdpTruePath);
        ExportIcon(
            new(() => GetIcon(app.IconPath, app.IconIndex)),
            icoTruePath,
            pngTruePath);

        await task;
    }

    private async Task<Resource> GetResource(Kernel.RemoteApp app, TerminalServerRef terminalServerRef, string path)
    {
        var (png, ico, rdp, pngTruePath, icoTruePath, rdpTruePath) = GetPaths(app, path);
        await GenerateFilesIfNotExist(app, rdpTruePath, icoTruePath, pngTruePath);

        return app.CreateWebFeedResource(
            terminalServerRef,
            rdp,
            ico,
            png,
            File.GetLastWriteTimeUtc(rdpTruePath));
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
