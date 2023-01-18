using System.Net;
using System.Xml.Serialization;

using Microsoft.AspNetCore.StaticFiles;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Kernel.WebFeed;
using Shimakaze.RemoteApp.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<RemoteApps>()
    .AddSingleton<RemoteAppService>()
    .AddSingleton<XmlSerializer>(i => new(typeof(ResourceCollection)))
    .AddWindowsService()
    .AddHostedService<Worker>();

var app = builder.Build();

app
    .UseHttpsRedirection()
    .UseStaticFiles(new StaticFileOptions
    {
        ContentTypeProvider = new FileExtensionContentTypeProvider(
        new Dictionary<string, string>
        {
            [".rdp"] = "text/plain"
        })
    });

app.MapGet("/", Get);

app.Urls.Add("https://*:443");
app.Logger.LogInformation(">>> https://{host}:443 <<<", Dns.GetHostName());

await app.RunAsync();

async Task Get(HttpContext context)
{
    var service = app.Services.GetRequiredService<RemoteAppService>();
    var serializer = app.Services.GetRequiredService<XmlSerializer>();

    app.Logger.LogInformation("UserAgent:\r\n{user-agent}", context.Request.Headers.UserAgent.ToString());
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    context.Response.ContentType = "application/xml";
    using StreamWriter sw = new(context.Response.BodyWriter.AsStream());
    serializer.Serialize(sw, await service.GetRDS());
    await sw.FlushAsync();
    await context.Response.CompleteAsync();
}