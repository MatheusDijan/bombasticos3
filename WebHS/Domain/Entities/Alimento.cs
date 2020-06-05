using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class Alimento : ClasseBasica
    {
        public string Nome { get; set; }
        public string Calorias { get; set; }
        public string UnidadeMedida { get; set; }
        public string Macronutrientes { get; set; }
        public string Micronutrientes { get; set; }
        public int DietaId { get; set; }
    }
}
