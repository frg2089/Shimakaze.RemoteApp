using Microsoft.AspNetCore.Mvc;

using Shimakaze.RemoteApp.Kernel;

namespace Shimakaze.RemoteApp.Web.Controllers;

[ApiController]
[Route("/")]
public class WebFeedController : ControllerBase
{
    private readonly ILogger<WebFeedController> _logger;
    private readonly RemoteApps _apps;

    public WebFeedController(ILogger<WebFeedController> logger, RemoteApps apps)
    {
        _logger = logger;
        _apps = apps;
    }

    [HttpGet()]
    public string Get()
    {
        
    }
}
