using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok();
        }
    }
}
