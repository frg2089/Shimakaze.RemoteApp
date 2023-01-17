using Microsoft.AspNetCore.StaticFiles;

using Shimakaze.RemoteApp.Kernel;
using Shimakaze.RemoteApp.Web.Services;

// Is Administrator Identity?
// if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
// {
//var identity = WindowsIdentity.GetCurrent();
//WindowsPrincipal principal = new(identity);
//if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
//{
//    Console.Error.WriteLine("We MUST run as Administrator");
//    Environment.Exit(-1);
//}
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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

app.UseAuthorization();

app.MapControllers();

app.Run();
