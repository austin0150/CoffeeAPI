using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API
{
    public class BrewTypeValidation
    {
        public static List<string> ValidateNewBrewType(BrewType brew)
        {
            List<string> errors = new List<string>();

            if(String.IsNullOrEmpty(brew.Name))
            {
                errors.Add("Brew type name cannot be null or empty");
            }

            if(String.IsNullOrEmpty(brew.Description))
            {
                errors.Add("Brew type description cannot be null or empty");
            }

            if(brew.BrewTime < 1)
            {
                errors.Add("Brew time cannot be less than 1");
            }
            if(brew.CoffeeWaterRatio < 0)
            {
                errors.Add("CoffeeWater Ration cannot be less than 0");
            }

            if(String.IsNullOrEmpty(brew.GrindSize))
            {
                errors.Add("GrindSize cannot be null or empty");
            }

            return errors;
        }

        public static List<string> ValidateUpdateBrewType(BrewType type)
        {
            List<string> errors = new List<string>();

            if (String.IsNullOrEmpty(type.Name))
            {
                errors.Add("Brew type name cannot be null or empty");
            }

            if (String.IsNullOrEmpty(type.Description))
            {
                errors.Add("Brew type description cannot be null or empty");
            }

            if (type.BrewTime < 1)
            {
                errors.Add("Brew time cannot be less than 1");
            }
            if (type.CoffeeWaterRatio < 0)
            {
                errors.Add("CoffeeWater Ration cannot be less than 0");
            }

            if (String.IsNullOrEmpty(type.GrindSize))
            {
                errors.Add("GrindSize cannot be null or empty");
            }

            return errors;
        }

        public static List<string> ValidateBrewTypeGet(BrewTypeGetRequest request)
        {
            List<string> errors = new List<string>();
            if (String.IsNullOrEmpty(request.AttributeValue))
            {
                errors.Add("The attribute value must not be null or empty");
            }

            if(String.IsNullOrEmpty(request.BrewTypeAttribute))
            {
                errors.Add("The BrewTypeAttribute must not be null or empty");
            }

            return errors;
        }
    }
}
