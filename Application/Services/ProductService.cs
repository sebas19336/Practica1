using Practica1.Domain.Entities;
using Practica1.Application.Interfaces;
namespace Practica1.Application.Services;

public class ProductService
{
	private readonly IProductRepository _repo;

	public ProductService(IProductRepository repo)
	{
		_repo = repo;
	}

	public List<Product> GetAll() => _repo.GetAll();
	public Product GetById(int id) => _repo.GetById(id);
	public void Create(Product p) => _repo.Add(p);
	public void Update(Product p) => _repo.Update(p);
	public void Delete(int id) => _repo.Delete(id);
}