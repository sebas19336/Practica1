using Domain.Entities;
using application.Interfaces;
namespace Persistence.Repositories;

public class ProductRepository : IProductRepository
{
	private static List<Product> products = new();

	public List<Product> GetAll() => products;

	public Product GetById(int id) => products.FirstOrDefault(x => x.Id == id);

	public void Add(Product product)
	{
		product.Id = products.Count + 1;
		products.Add(product);
	}

	public void Update(Product product)
	{
		var p = GetById(product.Id);
		if (p != null)
		{
			p.Name = product.Name;
			p.Price = product.Price;
		}
	}

	public void Delete(int id)
	{
		var p = GetById(id);
		if (p != null) products.Remove(p);
	}
}