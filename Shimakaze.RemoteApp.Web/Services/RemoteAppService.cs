using System.Drawing;
using System.Net;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Kernel.WebFeed;

namespace Shimakaze.RemoteApp.Web.Services;

public sealed class RemoteAppService
{
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
            _logger.LogInformation("Cannot found .ico file. we will create it.");

            icon.Value.ToBitmap().Save(
                ico,
                System.Drawing.Imaging.ImageFormat.Icon);
        }

        if (!File.Exists(png))
        {
            _logger.LogInformation("Cannot found .png file. we will create it.");


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
        _logger.LogInformation("Cannot found .rdp file. we will create it.");
        await File.WriteAllTextAsync(rdp, app.CreateRDPFile(Hostname).ToString()).ConfigureAwait(false);
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

    private async Task<Resource> GetResource(Kernel.RemoteApp app, string path)
    {
        var (png, ico, rdp, pngTruePath, icoTruePath, rdpTruePath) = GetPaths(app, path);
        await GenerateFilesIfNotExist(app, rdpTruePath, icoTruePath, pngTruePath);

        return app.CreateWebFeedResource(
            Hostname,
            rdp,
            ico,
            png,
            File.GetLastWriteTimeUtc(rdpTruePath));
    }


    public async Task<ResourceCollection> GetRDS()
    {
        string path = _configuration.GetValue<string>("StaticResourcesPath") ?? string.Empty;
        string dateTime = DateTime.UtcNow.ToString("O");

        return new()
        {
            PubDate = dateTime,
            Publisher = new()
            {
                Name = Hostname,
                ID = Hostname,
                LastUpdated = dateTime,
                Resources = await Task.WhenAll(_apps.GetRemoteApps().AsParallel().Select(app => GetResource(app, path))),
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
