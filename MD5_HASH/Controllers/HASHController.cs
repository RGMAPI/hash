using Microsoft.AspNetCore.Mvc;

namespace MD5_HASH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HASHController : ControllerBase
    {
        private readonly string _privateKey;
        public HASHController(IConfiguration configuration)
        {
            _privateKey = configuration.GetSection("Keys").GetSection("ExternalAuthorization").Value;
        }

        [HttpGet("/MD5/{value}")]
        public IActionResult GetMd5([FromHeader] string key,[FromRoute] string value)
        {
            if (key == _privateKey) 
            {
                return Ok(Hashing.ToMD5(value));
            }
            return new UnauthorizedResult();
        }

        [HttpGet("/SHA-256/{value}")]
        public IActionResult GetSha_256([FromHeader] string key,[FromRoute] string value)
        {
            if (key == _privateKey)
            {
                return Ok(Hashing.ToSHA256(value));
            }
            return new UnauthorizedResult();
        }
    }
}