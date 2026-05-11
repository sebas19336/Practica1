using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.UseCases.Product.Commands.DeleteProduct
{ 
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El ID del producto es obligatorio.");
        }
    }
}