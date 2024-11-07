using Application.Product.Create;
using AutoMapper;
using Domain.Product;

public class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductCommandRequest, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID otomatik oluşturulacak
            .ForMember(dest => dest.Sku, opt => opt.Ignore()); // SKU manuel olarak ayarlanacak
    }
}
