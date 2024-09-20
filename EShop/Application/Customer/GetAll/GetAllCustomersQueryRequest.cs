using MediatR;

namespace Application.Customer.GetAll
{
    public class GetAllCustomersQueryRequest : IRequest<GetAllCustomersQueryResponse.GetAllCustomersResponse> //sor
    {
        // Eğer sorguya parametre eklenecekse buraya eklenebilir
    }
}
