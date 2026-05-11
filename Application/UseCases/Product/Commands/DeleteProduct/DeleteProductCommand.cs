using Practica1.Application.Utilities.Mediator;
public sealed class DeleteProductCommand : ICommand
{
    public int Id { get; init; }
}