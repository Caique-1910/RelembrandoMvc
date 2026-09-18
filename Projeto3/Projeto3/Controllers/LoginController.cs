using Microsoft.AspNetCore.Mvc;
using Projeto3.Models;
using System.Security.Cryptography;
using System.Text;

namespace Projeto3.Controllers
{
    public class LoginController : Controller
    {
        private readonly cafeteriaContext _context;

        public LoginController(cafeteriaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            string senhadigitadaHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(senha)));

            usuario usuario = _context.usuario.FirstOrDefault(u => u.email == email && u.senha == senhadigitadaHash);

            if (usuario == null)
            {
                ViewBag.Erro = "Email ou senha inválidos!";
                return View("Index");
            }

            HttpContext.Session.SetString("usuarioId", usuario.usuarioid.ToString());

            return RedirectToAction("Index", "Home");
        }
    }
}
