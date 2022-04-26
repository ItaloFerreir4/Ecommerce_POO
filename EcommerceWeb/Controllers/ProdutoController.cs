using EcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using EcommerceWeb.Repositories;

namespace EcommerceWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository repository;

        public ProdutoController(IProdutoRepository repository){
            this.repository = repository;
        }

        public ActionResult Index()
        {
            List<Produto> produtos = repository.Read();

            // PATH: Views/Produto/Index.cshtml
            return View(produtos);
        }

        public ActionResult Promocoes()
        {
            List<Produto> produtos = repository.ReadPromocoes();
            
            // PATH: /Views/Produto/Promocoes.cshtml
            return View(produtos); 
        }

        [HttpGet] // TODOS OS DEMAIS CASOS
        public ActionResult Create()
        {
            // PATH: /Views/Produto/Create.cshtml
            return View();
        }

        [HttpPost] // FORMULARIO COM METHOD = POST
        public ActionResult Create(Produto produto)
        {
            repository.Create(produto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var produto = repository.Read(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Update(int id, Produto produto)
        {
            repository.Update(id, produto);
            return RedirectToAction("Index");
        }        

        // [HttpPost] // FORMULARIO COM METHOD = POST
        // public ActionResult Create(IFormCollection form)
        // {
        //     Produto produto = new Produto();
        //     produto.Nome = form["Nome"];
        //     produto.Descricao = form["Descricao"];
        //     produto.Preco = decimal.Parse(form["Preco"]);
        //     produto.Desconto = decimal.Parse(form["Desconto"]);

        //     ProdutoRepository repository = new ProdutoRepository();
        //     repository.Create(produto);

        //     return RedirectToAction("Index");
        // }
    }
}