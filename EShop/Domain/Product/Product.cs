using System;
namespace Domain.Product
{
    public class Product
	{
        public ProductId Id { get; set; } // Güçlü Id record yapısı

        public string Name { get; set; }

        public Money Price { get; set; }

        public Sku Sku { get; set; }
    }
}

