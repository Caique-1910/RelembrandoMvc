using Microsoft.AspNetCore.Mvc;
using Projeto1.Models;
using System.Diagnostics;

namespace Projeto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BibliotecaContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarLivro(string nome, string? descricao, DateOnly dtLivro)
        {
            if(string.IsNullOrEmpty(nome) || dtLivro == null)
            {
                ViewBag.Erro = "Por favor, preencha todos os campos obrigatórios.";
                return View("Index");
            }

            livro livro = new livro
            {
                nome = nome,
                descricao = descricao,
                dtLivro = dtLivro.ToDateTime(new TimeOnly(0, 0))
            };

            _context.Add(livro);
            _context.SaveChanges();

            return View(livro);
        }

        public IActionResult Editar(livro livroEditado)
        {


            livro livro = _context.livro.FirstOrDefault(l => l.id == livroEditado.id);

            if (livro == null)
            {
                return NotFound();
            }

            _context.Update(livro);
            _context.SaveChanges();

            return View(livro);
        }
    }
}
