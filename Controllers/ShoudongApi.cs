using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FakeDotNetAPI.Controllers
{
    [Route("api/shoudongapi")]
    [ApiController]
    public class ShoudongApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "s1", "s2" };
        }
    }
}