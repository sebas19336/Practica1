using Microsoft.AspNetCore.Mvc;
using Practica1.Application.Interfaces;
using Practica1.Domain.Entities;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        // 👉 GET: muestra el formulario
        public IActionResult Create()
        {
            return View();
        }

        // 👉 POST: guarda el producto
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.Add(product);
            return RedirectToAction("Index");
        }

        // 👉 Lista productos
        public IActionResult Index()
        {
            var products = _repo.GetAll();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
        var product = _repo.GetById(id);
        return View(product);
        }   

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

    }

}