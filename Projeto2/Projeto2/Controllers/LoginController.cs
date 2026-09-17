using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using System.Security.Cryptography;
using System.Text;

namespace Projeto2.Controllers
{
    public class LoginController : Controller
    {
        private readonly mercadoContext _context;

        public LoginController(mercadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            string senhaDigitadaHash = Convert.ToHexString(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(senha)
                )
            );

            var usuario = _context.usuario
                .FirstOrDefault(u =>
                    u.email == email &&
                    u.senha == senhaDigitadaHash
                );

            if (usuario == null)
            {
                ViewBag.Erro = "E-mail ou senha incorretos.";
                return View("Index");
            }

            HttpContext.Session.SetString(
                "usuarioid",
                usuario.usuarioid.ToString()
            );

            return RedirectToAction("Index", "Home");
        }
    }
}