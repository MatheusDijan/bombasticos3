using System;
using System.Collections.Generic;
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
            return View(Usuario);
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
            catch(Exception)
            {
                return "NOk";
            }
            
        }
    }
}