using Practica1.Application.Utilities.Mediator;
using Practica1.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.UseCases.Product.Commands.CreateProduct
{
	public class CreateProductUseCase : IUseCase<CreateProductCommand, CreateProductResponse>
	{
		private readonly IProductRepository _productRepository;
		public CreateProductUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var product = new Product
			{
				Name = request.Name,
				Description = request.Description,
				Price = request.Price,
				Stock = request.Stock
			};
			await _productRepository.AddAsync(product);
			return new CreateProductResponse
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Stock = product.Stock
			};
		}
		public Task Validate(CreateProductCommand request)
		{
			if (string.IsNullOrWhiteSpace(request.Name))
				throw new ArgumentException("El nombre del producto es obligatorio.");
			if (request.Price < 0)
				throw new ArgumentException("El precio no puede ser negativo.");
			if (request.Stock < 0)
				throw new ArgumentException("El stock no puede ser negativo.");
			return Task.CompletedTask;
		}
}