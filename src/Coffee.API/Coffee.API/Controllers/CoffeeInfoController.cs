using Coffee.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeInfoController : ControllerBase
    {
        public IActionResult Get([FromBody] CoffeeInfoRequest request)
        {
            return Ok();
        }
    }
}
