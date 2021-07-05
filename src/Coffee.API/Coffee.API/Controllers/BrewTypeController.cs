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
    [ApiController]
    public class BrewTypeController : ControllerBase
    {
        private readonly IMongoRepository _mongoRepo;
        public BrewTypeController(IMongoRepository mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }

        [Route("/GetBrewType")]
        [ActionName("GET")]
        public async Task<IActionResult> Get([FromBody] string BrewTypeName)
        {
            if (String.IsNullOrEmpty(BrewTypeName))
            {
                List<string> errors = new List<string>();
                errors.Add("BrewTypeName cannot be null or empty");

                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = BrewTypeName;

                return StatusCode(400, errorObj);
            }
            
            BrewType result = await _mongoRepo.GetBrewType(BrewTypeName);

            return StatusCode(200,result);

        }

        [Route("/GetBrewTypeByID")]
        [ActionName("GET")]
        public async Task<IActionResult> GetID([FromBody] string BrewTypeID)
        {
            if (String.IsNullOrEmpty(BrewTypeID))
            {
                List<string> errors = new List<string>();
                errors.Add("BrewTypeID cannot be null or empty");

                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = BrewTypeID;

                return StatusCode(400, errorObj);
            }

            BrewType result = await _mongoRepo.GetBrewTypeByID(BrewTypeID);

            return StatusCode(200, result);
        }

        [Route("/SearchBrewTypeName")]
        [ActionName("GET")]
        public async Task<IActionResult> SearchByName([FromBody] string BrewTypeName)
        {
            if (String.IsNullOrEmpty(BrewTypeName))
            {
                List<string> errors = new List<string>();
                errors.Add("BrewTypeName cannot be null or empty");

                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = BrewTypeName;

                return StatusCode(400, errorObj);
            }

            List<BrewType> result = await _mongoRepo.SearchBrewTypeName(BrewTypeName);

            return StatusCode(200, result);
        }

        [Route("/SearchBrewTypeDesc")]
        [ActionName("GET")]
        public async Task<IActionResult> SearchByDesc([FromBody] string BrewTypeDesc)
        {
            if (String.IsNullOrEmpty(BrewTypeDesc))
            {
                List<string> errors = new List<string>();
                errors.Add("BrewTypeDesc cannot be null or empty");

                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = BrewTypeDesc;

                return StatusCode(400, errorObj);
            }

            List<BrewType> result = await _mongoRepo.SearchBrewTypeDescription(BrewTypeDesc);

            return StatusCode(200, result);
        }

        [Route("/AddBrewType")]
        [ActionName("POST")]
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

        [Route("/UpdateBrewType")]
        [ActionName("PUT")]
        public async Task<IActionResult> UpdateBrewType([FromBody] BrewType type)
        {
            BrewType newBrewType = type;

            //Validate the request
            List<string> errors = BrewTypeValidation.ValidateUpdateBrewType(type);
            if (errors.Count > 0)
            {
                ValidationErorrs errorObj = new ValidationErorrs();
                errorObj.RequestErrors = errors;
                errorObj.RequestObject = newBrewType;

                return StatusCode(400, errorObj);
            }

            await _mongoRepo.UpdateBrewType(newBrewType);

            return StatusCode(200, newBrewType);
        }
    }
}
