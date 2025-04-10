using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSetorTecnico.Data;
using SistemaSetorTecnico.Models;
using System.Security.Claims;

namespace SistemaSetorTecnico.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null) // Criar encriptação posteriormente.
            {
                TempData["ErrorMessage"] = "Usuário ou senha inválidos.";
                ModelState.AddModelError("", "E-mail ou senha inválidos!");
                return View();
            }

            var passwordHasher = new PasswordHasher<Usuario>();
            var result = passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, senha);

            if (result != PasswordVerificationResult.Success)
            {
                TempData["ErrorMessage"] = "Usuário ou senha inválidos.";
                ModelState.AddModelError("", "E-mail ou senha inválidos!");
                return View();
            }

            // Criar a identidade do usuário

            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                };

            if (usuario.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            if (usuario.IsBioquimico)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Bioquimico"));
            }

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal);
            TempData["SuccessMessage"] = "Login realizado com sucesso!";
            Thread.Sleep(1000);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Auth");
        }

    }
}
