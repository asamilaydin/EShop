using System.Threading;
using System.Threading.Tasks;
using Domain.Orders;
using MediatR;

namespace Application.Order.Delete
{
    public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            
            var order = await _orderRepository.GetByIdAsync(request.Id.Value);

            if (order == null)
            {
                return new DeleteOrderCommandResponse
                {
                    Success = false,

                    Message = "Order not found"
                };
            }

           
            _orderRepository.Delete(order);

            _orderRepository.SaveChangeAsync();

            return new DeleteOrderCommandResponse
            {
                Success = true,

                Message = "Order deleted successfully"
            };
        }
    }
}
