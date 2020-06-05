using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class Atividade : ClasseBasica
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Repeticoes { get; set; }
    }
}
