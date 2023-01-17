using System.Xml.Serialization;

using Microsoft.AspNetCore.StaticFiles;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Kernel.WebFeed;
using Shimakaze.RemoteApp.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<RemoteApps>()
    .AddSingleton<RemoteAppService>()
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

XmlSerializer serializer = new(typeof(ResourceCollection));
app.MapGet("/", async (HttpContext context) =>
{
    var logger = app.Services.GetService<ILogger<RemoteAppService>>();
    var service = app.Services.GetRequiredService<RemoteAppService>();

    logger?.LogInformation("UserAgent:\r\n{0}", context.Request.Headers.UserAgent.ToString());
    context.Response.ContentType = "application/xml";
    serializer.Serialize(context.Response.BodyWriter.AsStream(), await service.GetRDS());
    await context.Response.Body.FlushAsync();
    await context.Response.Body.DisposeAsync();
    return Results.Ok();
});

app.Run();
