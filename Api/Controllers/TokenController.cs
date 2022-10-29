using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] string user = "bob", [FromQuery] string pswd = "bob")
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://host.docker.internal:5001");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, disco.Error);
            }

            // request token

            var tokenResponse = await client.RequestPasswordTokenAsync (new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "mobile_pswd",
                ClientSecret = "secret",
                Scope = "api1",
                UserName = user,
                Password = pswd
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return NotFound();
            }

            Console.WriteLine(tokenResponse.AccessToken);

            return Ok(tokenResponse.AccessToken);
        }
    }
}
