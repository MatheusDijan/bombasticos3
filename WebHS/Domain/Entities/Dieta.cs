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
        }
        public List<Alimento> Alimentos { get; set; }
        public int Dias { get; set; }
        public int UsuarioId { get; set; }
    }
}
