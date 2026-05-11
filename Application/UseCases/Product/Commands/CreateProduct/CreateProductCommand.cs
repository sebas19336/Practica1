using Practica1.Application.Utilities.Mediator;
public sealed class CreateProductCommand : ICommand<int>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
}