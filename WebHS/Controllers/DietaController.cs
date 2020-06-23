using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHS.Domain.Entities;
using WebHS.Models;
using WebHS.Models.Enums;

namespace WebHS.Controllers
{
    public class DietaController : Controller
    {
        Usuario Usuario = new Usuario();
        Dieta Dieta = new Dieta();
        private readonly ProjetoContext _context;

        public DietaController(ProjetoContext context)
        {
            _context = context;
        }
        public IActionResult Index() //View do nutricionista (mostra lista de users)
        {
            Usuario = new Usuario();
            Usuario.Usuarios = _context.Usuario.Where(u => u.TipoUsuario.Equals(TipoUsuario.Usuario)).ToList();
            foreach (var item in Usuario.Usuarios)
            {
                Dieta dieta = _context.Dieta.Where(x => x.UsuarioId == item.Id).FirstOrDefault();
                if (dieta == null)
                    dieta = new Dieta();
                else
                    dieta.Alimentos = _context.Alimento.Where(x => x.DietaId == dieta.Id).ToList();
                dieta.Usuario = item;
                Dieta.Dietas.Add(dieta);
            }
            return View(Dieta);
        }
        public IActionResult Criar(int Id) // View criação da dieta
        {
            Dieta = new Dieta();
            Dieta.Usuario = _context.Usuario.Where(u => u.Id == Id).FirstOrDefault();
            var verificacao = _context.Dieta.Where(u => u.UsuarioId == Id).FirstOrDefault();
            if (verificacao != null)
            {
                Dieta = verificacao;
                Dieta.Alimentos = _context.Alimento.Where(u => u.DietaId == Dieta.Id).ToList();
            }
            return View(Dieta);
        }

        public IActionResult Visualizar(int Id) // View visualização da dieta
        {
            Dieta = new Dieta();
            Dieta.Usuario = _context.Usuario.Where(u => u.Id == Id).FirstOrDefault();
            var verificacao = _context.Dieta.Where(u => u.UsuarioId == Id).FirstOrDefault();
            if (verificacao != null)
            {
                Dieta = verificacao;
                Dieta.Alimentos = _context.Alimento.Where(u => u.DietaId == Dieta.Id).ToList();
            }
            return View(Dieta);
        }

        public async Task<string> Delete(int alimentoid)
        {
            try
            {
                Alimento alimento = new Alimento();
                alimento = _context.Alimento.Where(x => x.Id == alimentoid).FirstOrDefault();
                _context.Alimento.Remove(alimento);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception)
            {
                return "NOk";
            }

        }
        public List<int> Pesquisar(string palavra)
        {
            Usuario usuario = new Usuario();
            if (palavra == null)
                usuario.Usuarios = _context.Usuario.ToList();
            else
                usuario.Usuarios = _context.Usuario.Where(x => x.Nome.Contains(palavra)).ToList();

            List<int> UsuariosIds = usuario.Usuarios.Select(x => x.Id).ToList();
            return UsuariosIds;
        }
        public async Task<string> Salvar(string nome, string unidade, int idusuario)
        {
            try
            {
                Dieta dieta = _context.Dieta.Where(x => x.UsuarioId == idusuario).FirstOrDefault();
                if (dieta == null)
                {
                    dieta = new Dieta();
                    dieta.UsuarioId = idusuario;
                    dieta.Dias = 15;
                    _context.Dieta.Add(dieta);
                    await _context.SaveChangesAsync();
                    dieta = _context.Dieta.Where(x => x.UsuarioId == idusuario).FirstOrDefault();
                }

                Alimento alimento = new Alimento();
                alimento.Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome);
                alimento.UnidadeMedida = unidade;
                alimento.DietaId = dieta.Id;

                _context.Alimento.Add(alimento);
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