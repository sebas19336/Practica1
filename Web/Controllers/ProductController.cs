using Microsoft.AspNetCore.Mvc;
using Practica1.Application.Interfaces;
using Practica1.Domain.Entities;
using Practica1.Application.Services;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ProductService _service;

        public ProductController(
    IProductRepository repo,
    ICategoryRepository categoryRepo,
        ProductService service)
            {
                _repo = repo;
                _categoryRepo = categoryRepo;
                _service = service;
            }

        // - GET: muestra el formulario
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            return View();
        }

        // - POST: guarda el producto
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryRepo.GetAll();
                return View(product);
            }


            _repo.Add(product);
            return RedirectToAction("Index");
        }

        // - Lista productos
        public IActionResult Index()
        {
            var products = _repo.GetAll();

            ViewBag.Categories = _categoryRepo.GetAll(); //  ESTA LÍNEA ES LA CLAVE

            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            ViewBag.Categories = _categoryRepo.GetAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryRepo.GetAll();
                return View(product);
            }

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