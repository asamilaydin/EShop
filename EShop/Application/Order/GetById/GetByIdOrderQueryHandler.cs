using System;
using AutoMapper;
using Domain.Orders;
using MediatR;

namespace Application.Order.GetById
{
	public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
	{
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

		public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
		{
            _mapper = mapper;

            _orderRepository = orderRepository;
		}

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id.Value);

            if (order == null)
            {
                throw new Exception("Sipariş Bulunamadı");
            }

            var orderDto = _mapper.Map<GetByIdOrderQueryResponse>(order);

            orderDto.TotalPrice = order.LineItems.Sum(item => item.Price.Amount);

            return orderDto;
        }
    }
}

