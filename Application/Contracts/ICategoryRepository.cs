using Practica1.Domain.Entities;

namespace Practica1.Application.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void Add(Category category);
    void Update(Category category);
    void Delete(int id);
}

