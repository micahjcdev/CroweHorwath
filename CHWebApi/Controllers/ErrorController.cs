using Microsoft.AspNetCore.Mvc;

namespace CHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route( "/error" )]
        public IActionResult Error() => Problem();
    }
}