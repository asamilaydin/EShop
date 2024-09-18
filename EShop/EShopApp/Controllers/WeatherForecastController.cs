using Domain.Product;
using Microsoft.AspNetCore.Mvc;
using Persistence;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
   

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
       
    }

    // POST: api/Product/add
    [HttpPost("add")]
    public async Task<IActionResult> AddProductManually()
    {
        // Manuel olarak ürün oluşturuluyor
        var product = new Product
        {
            Id = new ProductId(Guid.NewGuid()),  // Ürün için benzersiz bir ID oluşturuluyor
            Name = "Example Product",            // Ürün adı manuel olarak giriliyor
            Price = new Money("USD", 99.99M),           // Ürün fiyatı manuel olarak giriliyor
            Sku = new Sku("EXAMPLE123")          // Ürün SKU'su manuel olarak giriliyor
        };

         _productRepository.Insert(product);
       
       await _productRepository.SaveChangeAsync();
       // Ürün veri tabanına ekleniyor
        return Ok("Product added successfully.");
    }

    // GET: api/Product/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound("Product not found.");

        return Ok(product);
    }
}
