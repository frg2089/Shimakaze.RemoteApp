using Microsoft.AspNetCore.Mvc;

using Shimakaze.RemoteApp.Web.Services;

namespace Shimakaze.RemoteApp.Web.Controllers;

[ApiController]
[Route("/")]
public class WebFeedController : ControllerBase
{
    private readonly ILogger<WebFeedController> _logger;
    private readonly RemoteAppService _service;

    public WebFeedController(ILogger<WebFeedController> logger, RemoteAppService remoteApps)
    {
        _logger = logger;
        _service = remoteApps;
    }


    [HttpGet("")]
    [Produces("application/xml")]
    public async Task<IActionResult> GetAsync()
    {
        // TSWorkspace/2.0
        _logger.LogInformation("UserAgent:\r\n{0}", Request.Headers.UserAgent.ToString());
        //if (Request.Headers.UserAgent.Any(i => !string.IsNullOrWhiteSpace(i) && i.StartsWith("Mozilla")))
        //    return Redirect("/dashboard");

        return Ok(await _service.GetRDS());
    }
}
