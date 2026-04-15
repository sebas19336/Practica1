using Practica1.Application.Interfaces;
using Practica1.Domain.Entities;

namespace Practica1.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private static List<Category> _categories = new List<Category>
{
    new Category { Id = 1, Name = "Tecnología" },
    new Category { Id = 2, Name = "Alimentos" },
    new Category { Id = 3, Name = "Ropa" }
};

    public IEnumerable<Category> GetAll()
    {
        return _categories;
    }

    public Category GetById(int id)
    {
        return _categories.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Category category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);
    }

    public void Update(Category category)
    {
        var existing = GetById(category.Id);
        if (existing != null)
        {
            existing.Name = category.Name;
        }
    }

    public void Delete(int id)
    {
        var category = GetById(id);
        if (category != null)
        {
            _categories.Remove(category);
        }
    }
}