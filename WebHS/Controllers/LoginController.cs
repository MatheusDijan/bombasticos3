using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHS.Domain.Entities;
using WebHS.Models.Enums;

namespace WebHS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProjetoContext _context;

        public LoginController(ProjetoContext context)
        {
            _context = context;
        }
        #region get
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autenticar(Usuario usuario)

        {

            Usuario validacao = _context.Usuario.Where(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)).FirstOrDefault();
            if (validacao != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (usuario.Email != null && usuario.Senha != null)
                    ModelState.AddModelError("", "Usuário ou senha inválidos");
                return View("Login");
            }


        }
        #endregion
        #region post
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            usuario.TipoUsuario = TipoUsuario.Usuario;
            if (ModelState.IsValid)
            {
                Usuario validacao = _context.Usuario.Where(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)).FirstOrDefault();
                if (validacao == null)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    if (usuario.Nome != null && usuario.Senha != null && usuario.Email != null)
                        ModelState.AddModelError("", "Usuário já cadastrado");
                    return View();
                }
            }
            return View(usuario);
        }
        #endregion

    }
}
