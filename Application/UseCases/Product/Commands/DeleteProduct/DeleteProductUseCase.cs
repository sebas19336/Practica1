using System;
using System.Collections.Generic;
using System.Text;
using Practica1.Application.Utilities.Mediator;
using Practica1.Domain.Entities.Product;

namespace Practica1.Application.UseCases.Product.Commands.DeleteProduct
{
	public class DeleteProductUseCase : IUseCase<DeleteProductCommand, DeleteProductResponse>
	{
		private readonly IProductRepository _productRepository;
		public DeleteProductUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetByIdAsync(request.Id);
			if (product == null)
				throw new KeyNotFoundException("Producto no encontrado.");
			await _productRepository.DeleteAsync(product);
			return new DeleteProductResponse
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Stock = product.Stock
			};
		}
		public Task Validate(DeleteProductCommand request)
		{
			if (request.Id <= 0)
				throw new ArgumentException("El ID del producto debe ser mayor que cero.");
			return Task.CompletedTask;
		}
	}
}