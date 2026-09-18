using Microsoft.AspNetCore.Mvc;
using Projeto3.Models;
using System.Diagnostics;

namespace Projeto3.Controllers
{
    public class HomeController : Controller
    {
        private readonly cafeteriaContext _context;
        public HomeController(cafeteriaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<item> itens = _context.item.ToList();
            return View(itens);
        }


        [HttpPost]
        public IActionResult Cadastrar(string nomeItem, decimal preco, string? descricao)
        {
            if (string.IsNullOrEmpty(nomeItem) || preco <= 0)
            {
                return RedirectToAction("Index");
            }

            item item = new item
            {
                nomeItem = nomeItem,
                preco = preco,
                descricao = descricao
            };

            _context.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(int id, string nomeItem, decimal preco, string? descricao)
        {
            item? item = _context.item.FirstOrDefault(i => i.id == id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            item.nomeItem = nomeItem;
            item.preco = preco;
            item.descricao = descricao;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            item? item = _context.item.FirstOrDefault(i => i.id == id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.item.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
