using System.ComponentModel.DataAnnotations;
namespace Practica1.Domain.Entities;
public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; } = string.Empty;
    [Range(1, 1000000, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}