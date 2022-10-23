using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PrivateController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok("hellow!");
        }
    }
}
