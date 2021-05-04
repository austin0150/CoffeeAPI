using Coffee.API.Data;
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
    public class BrewTypeController : ControllerBase
    {
        private readonly IMongoRepository _mongoRepo;
        public BrewTypeController(IMongoRepository mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }

        public IActionResult Get([FromBody] CoffeeInfoRequest request)
        {
            return Ok();
        }

        [Route("/BrewType")]
        [ActionName("Put")]
        public IActionResult PutBrewType([FromBody] BrewType type)
        {
            BrewType newBrewType = type;

            //Validate the request
            List<string> errors = BrewTypeValidation.ValidateNewBrewType(newBrewType);
            if(errors.Count > 0)
            {
                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = newBrewType;

                return StatusCode(400, errorObj);
            }

            _mongoRepo.InsertBrewType(newBrewType);

            return StatusCode(200, newBrewType);

        }
    }
}
