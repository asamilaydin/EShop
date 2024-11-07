using System.Threading;
using System.Threading.Tasks;
using Application.Customer.Create;
using Application.Order.Create;
using Application.Product.Create;
using Application.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Orders;
using Domain.Product;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper; // AutoMapper

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;

            _mapper = mapper; // Mapper'ı alıyoruz
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            // SKU oluşturulması // otomatik ata belirli bi formatta
            var sku = Sku.Create(request.SkuValue);

            if (sku == null)
            {
                throw new ArgumentException("Invalid SKU");
            }

            // Request'i Product'a dönüştürme
            var product = _mapper.Map<Domain.Product.Product>(request);

            product.Id = new ProductId(Guid.NewGuid()); // Yeni bir ID oluşturma

            product.Sku = sku; // SKU'yu ayarlama
            // Ürünü kaydetme
            _productRepository.Insert(product);

            _productRepository.SaveChangeAsync();
            // Response nesnesini oluşturma
            return new CreateProductCommandResponse
            {
                
                Success = true,

                Message = "Product created successfully"
            };
        }
    }
}
