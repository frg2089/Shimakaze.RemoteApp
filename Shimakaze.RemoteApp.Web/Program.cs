using System.Security.Principal;

using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Fast.Components.FluentUI;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Web.Services;

// Is Administrator Identity?
// if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
// {
var identity = WindowsIdentity.GetCurrent();
WindowsPrincipal principal = new(identity);
if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
{
    Console.Error.WriteLine("We MUST run as Administrator");
    Environment.Exit(-1);
}
// }



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<RemoteApps>();
builder.Services.AddSingleton<RemoteAppService>();

builder.Services.AddMvcCore().AddXmlSerializerFormatters();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".rdp"] = "text/plain";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
