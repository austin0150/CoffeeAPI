using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Models
{
    public class ValidationErorrs
    {
        public Object RequestObject { get; set; }
        public List<string> RequestErrors { get; set; }
    }
}
