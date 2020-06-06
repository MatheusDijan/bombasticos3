using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class Dieta : ClasseBasica
    {
        public Usuario Usuario { get; set; }
        public Dieta()
        {
            Alimentos = new List<Alimento>();
            Dietas = new List<Dieta>();
        }
        public List<Alimento> Alimentos { get; set; }
        public int Dias { get; set; }
        public int UsuarioId { get; set; }
        public List<Dieta> Dietas { get; set; }
    }
}
