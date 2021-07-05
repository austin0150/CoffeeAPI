using Coffee.API.Data;
using Coffee.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Controllers
{
    [ApiController]
    public class BeanTypeController : ControllerBase
    {
        private readonly IMongoRepository _mongoRepo;
        public BeanTypeController(IMongoRepository mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }

        [Route("/GetBeanType")]
        [ActionName("GET")]
        public async Task<IActionResult> Get([FromBody] string BeanTypeName)
        {
            if (String.IsNullOrEmpty(BeanTypeName))
            {
                List<string> errors = new List<string>();
                errors.Add("BeanTypeName cannot be null or empty");

                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = BeanTypeName;

                return StatusCode(400, errorObj);
            }

            BeanType result = await _mongoRepo.GetBeanType(BeanTypeName);

            return StatusCode(200, result);

        }

        [Route("/AddBeanType")]
        [ActionName("POST")]
        public IActionResult PutBrewType([FromBody] BeanType type)
        {
            BeanType newBeanType = type;

            //Validate the request
            List<string> errors = BeanTypeValidation.ValidateNewBeanType(newBeanType);
            if (errors.Count > 0)
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
