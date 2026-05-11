using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductCommandVaildator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandVaildator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
        }
    }
}