using Practica1.Domain.Entities;
using Practica1.Application.Interfaces;
namespace Practica1.Application.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}