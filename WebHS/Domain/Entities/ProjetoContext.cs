using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHS.Domain.Entities
{
    public class ProjetoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Treino> Treino { get; set; }
        public DbSet<Nutricionista> Nutricionista { get; set; }
        public DbSet<EducadorFisico> EducadorFisico { get; set; }
        public DbSet<Dieta> Dieta { get; set; }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<Atividade> Atividade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Integrated Security=True;Database=ProjetoDb");

        }

        internal Usuario Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
