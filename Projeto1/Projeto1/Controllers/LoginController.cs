using Microsoft.AspNetCore.Mvc;
using Projeto1.Models;
using System.Security.Cryptography;
using System.Text;

namespace Projeto1.Controllers
{
    public class LoginController : Controller
    {
        private readonly BibliotecaContext _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.Erro = "Por favor, preencha todos os campos.";
                return View("Index");
            }

            string senhaDigitadaHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(senha)));

            usuario usuario = _context.usuario.FirstOrDefault(u => u.email == email);

            if (usuario == null)
            {
                ViewBag.Erro = "Email ou senha incorretos.";
                return View("Index");
            }

            if(!usuario.senha.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Erro = "Email ou senha incorretos.";
                return View("Index");
            }

            HttpContext.Session.SetString("UsuarioId", usuario.id.ToString());


            return RedirectToAction("Index", "Home");
        }
    }
}
