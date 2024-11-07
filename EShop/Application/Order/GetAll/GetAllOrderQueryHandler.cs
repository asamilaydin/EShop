using AutoMapper;
using Domain.Orders;
using MediatR;

namespace Application.Order.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse.OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;

            _mapper = mapper;
        }

        public async Task<List<GetAllOrderQueryResponse.OrderDto>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            // Veritabanından tüm siparişleri al
            var orders = await _orderRepository.GetAllAsync();
            // Her sipariş için TotalPrice hesapla
            var orderDtos = orders.Select(order =>
            {
                // LineItems'daki Price değerlerinin toplamını hesapla
                var totalPrice = order.LineItems.Sum(item => item.Price.Amount); //mapperde var kontrol et
                // Order nesnesini OrderDto'ya dönüştür ve TotalPrice'ı ayarla
                var orderDto = _mapper.Map<GetAllOrderQueryResponse.OrderDto>(order);

                orderDto.TotalPrice = totalPrice;

                return orderDto;

            }).ToList();

            return orderDtos;
        }
    }
}
