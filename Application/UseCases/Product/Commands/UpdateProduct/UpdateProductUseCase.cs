using System;
using System.Collections.Generic;
using System.Text;
using Practica1.Application.Utilities.Mediator;
using Practica1.Domain.Entities.Product;

namespace Practica1.Application.UseCase.Product.Commands.UpdateProduct
{
    public class UpdateProductUseCase : IUseCase<UpdateProductCommand, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException("Producto no encontrado.");
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;
            await _productRepository.UpdateAsync(product);
            return new UpdateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }
        public Task Validate(UpdateProductCommand request)
        {
            if (request.Id <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("El nombre del producto es obligatorio.");
            if (request.Price < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            if (request.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            return Task.CompletedTask;
        }
    }
}   