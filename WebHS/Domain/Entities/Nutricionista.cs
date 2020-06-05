using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class Nutricionista : Usuario
    {
        public string CRN { get; set; }
    }
}
