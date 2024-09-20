using System;
namespace Application.Customer.Create
{
	public sealed record CreateCustomerCommandResponse
	{
        public bool Success { get; init; } // İşlemin başarılı olup olmadığı
        public string Message { get; init; } // Hata ya da bilgilendirme mesajı

    }
}

