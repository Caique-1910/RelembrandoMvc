using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;

namespace Projeto2.Controllers
{
    public class HomeController : Controller
    {
        private readonly mercadoContext _context;

        public HomeController(mercadoContext context)
        {
            _context = context;
        }

        // LISTAGEM
        [HttpGet]
        public IActionResult Index()
        {
            List<item> itens = _context.item.ToList();

            return View(itens);
        }

        // CADASTRO
        [HttpPost]
        public IActionResult Cadastro(string nomeItem, int quantidade)
        {
            if (string.IsNullOrEmpty(nomeItem) || quantidade <= 0)
            {
                return RedirectToAction("Index");
            }

            item novoItem = new item
            {
                nomeitem = nomeItem,
                quantidade = quantidade
            };

            _context.item.Add(novoItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIÇÃO
        [HttpPost]
        public IActionResult Editar(int id, string nomeitem, int quantidade)
        {
            item? item = _context.item.FirstOrDefault(i => i.id == id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            item.nomeitem = nomeitem;
            item.quantidade = quantidade;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EXCLUSÃO
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