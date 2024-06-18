using Microsoft.AspNetCore.Mvc;

namespace IdentityServerOtel.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Example data";
    }
}