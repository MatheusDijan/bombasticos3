using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class Treino : ClasseBasica
    {
        public Treino()
        {
            Atividades = new List<Atividade>();
        }
        List<Atividade> Atividades { get; set; }
        public int Dias { get; set; }
        public int UsuarioId { get; set; }
    }
}
