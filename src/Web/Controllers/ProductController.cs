using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

public class ProductController : Controller
{
	private readonly ProductService _service;

	public ProductController(ProductService service)
	{
		_service = service;
	}

	public IActionResult Index()
	{
		return View(_service.GetAll());
	}

	public IActionResult Create() => View();

	[HttpPost]
	public IActionResult Create(Product p)
	{
		_service.Create(p);
		return RedirectToAction("Index");
	}

	public IActionResult Delete(int id)
	{
		_service.Delete(id);
		return RedirectToAction("Index");
	}
}