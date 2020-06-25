using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using WebHS.Domain.Entities;
using WebHS.Models.Enums;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHS.Controllers
{
    public class TreinoController : Controller
    {

        Usuario Usuario = new Usuario();
        Treino Treino = new Treino();
        private readonly ProjetoContext _context;

        public TreinoController(ProjetoContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Usuario = new Usuario();
            Usuario.Usuarios = _context.Usuario.Where(u => u.TipoUsuario.Equals(TipoUsuario.Usuario)).ToList();
            foreach (var item in Usuario.Usuarios)
            {
                Treino treino = _context.Treino.Where(x => x.UsuarioId == item.Id).FirstOrDefault();
                if (treino == null)
                    treino = new Treino();
                else
                    treino.Atividades = _context.Atividade.Where(x => x.TreinoId == treino.Id).ToList();
                treino.Usuario = item;
                Treino.Treinos.Add(treino);
            }
            return View(Treino);
        }

        public IActionResult Criar(int id)
        {
            Treino = new Treino();
            Treino.Usuario = _context.Usuario.Where(u => u.Id == id).FirstOrDefault();
            var verificacao = _context.Treino.Where(u => u.UsuarioId == id).FirstOrDefault();
            if (verificacao != null)
            {
                Treino = verificacao;
                Treino.Atividades = _context.Atividade.Where(u => u.TreinoId == Treino.Id).ToList();
            }
            return View(Treino);
        }

        public IActionResult Visualizar(int Id) // View visualização do treino
        {
            Treino = new Treino();
            Treino.Usuario = _context.Usuario.Where(u => u.Id == Id).FirstOrDefault();
            var verificacao = _context.Treino.Where(u => u.UsuarioId == Id).FirstOrDefault();
            if (verificacao != null)
            {
                Treino = verificacao;
                Treino.Atividades = _context.Atividade.Where(u => u.TreinoId == Treino.Id).ToList();
            }
            return View(Treino);
        }

        public async Task<string> Salvar(string nome, int repeticoes, string tipo, int idusuario)
        {
            try
            {
                Treino treino = _context.Treino.Where(x => x.UsuarioId == idusuario).FirstOrDefault();
                if (treino == null)
                {
                    treino = new Treino();
                    treino.UsuarioId = idusuario;
                    treino.Dias = 15;
                    _context.Treino.Add(treino);
                    await _context.SaveChangesAsync();
                    treino = _context.Treino.Where(x => x.UsuarioId == idusuario).FirstOrDefault();
                }

                Atividade atividade = new Atividade();
                atividade.Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome);
                atividade.Repeticoes = repeticoes;
                atividade.Tipo = tipo;
                atividade.TreinoId = treino.Id;

                _context.Atividade.Add(atividade);
                await _context.SaveChangesAsync();

                return "Ok";
            }
            catch (Exception)
            {
                return "NOk";
            }

        }

        public async Task<string> Delete(int atividadeid)
        {
            try
            {
                Atividade atividade = new Atividade();
                atividade = _context.Atividade.Where(x => x.Id == atividadeid).FirstOrDefault();
                _context.Atividade.Remove(atividade);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception)
            {
                return "NOk";
            }

        }
    }
}
