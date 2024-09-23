using System;
using FluentValidation;

namespace Application.Customer.Create
{
	public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommandRequest>
	{
		public CreateCustomerCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotEmpty()
				.NotNull()
				   .WithMessage("Adı olmayanın namı olmaz gardaş ! Adınızı girmeyi unuttunuz")
				.MaximumLength(100)
				.MinimumLength(2)
					.WithMessage("Adınızın uzunluğu  2 ile 100 karakter arasında olmalı");

			RuleFor(c => c.Email)
				.NotEmpty()
		        .NotNull()
				   .WithMessage("Email alanı boş bırakılamaz")
				.EmailAddress()
				   .WithMessage("Email formatı yanlış");
				
		}
	}
}

