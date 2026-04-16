using Microsoft.AspNetCore.Mvc;
using Practica1.Application.Interfaces;
using Practica1.Domain.Entities;

namespace Practica1.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _repo;

    public CategoryController(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var categories = _repo.GetAll();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        _repo.Add(category);
        return RedirectToAction("Index");
    }
}