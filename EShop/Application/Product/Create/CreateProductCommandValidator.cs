using System;
using FluentValidation;

namespace Application.Product.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                   .WithMessage("Adı olmayanın namı olmaz gardaş ! Adınızı girmeyi unuttunuz")
                .MaximumLength(100)
                .MinimumLength(2)
                    .WithMessage("Adınızın uzunluğu  2 ile 100 karakter arasında olmalı");
        }
    }
}

