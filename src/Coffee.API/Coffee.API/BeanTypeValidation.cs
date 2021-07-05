using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API
{
    public class BeanTypeValidation
    {
        public static List<string> ValidateNewBeanType(BeanType bean)
        {
            List<string> errors = new List<string>();

            if (String.IsNullOrEmpty(bean.Name))
            {
                errors.Add("Bean name cannot be null");
            }

            if (String.IsNullOrEmpty(bean.FlavorDescription))
            {
                errors.Add("Bean flavor description cannot be null");
            }

            if(String.IsNullOrEmpty(bean.GrowingElevation))
            {
                errors.Add("Growing elevation cannot be null");
            }

            return errors;
        }
    }
}
