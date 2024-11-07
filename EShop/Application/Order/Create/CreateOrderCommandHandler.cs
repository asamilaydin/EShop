using System.Threading;
using System.Threading.Tasks;
using Domain.Customer;
using Domain.Orders;
using Domain.Product;
using MediatR;

namespace Application.Order.Create
{
    public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse> //mapper yok
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICustomerRepository _customerRepository;

        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;

            _customerRepository = customerRepository;

            _productRepository = productRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            
            var customer = await _customerRepository.GetByIdAsync(request.customerId.Value);

            if (customer == null)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,

                    Message = "Customer not found"
                };
            }

            var order = Domain.Orders.Order.Create(customer);

            if (request.lineItem == null || !request.lineItem.Any())
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,

                    Message = $"Product with ID  not found"
                };
            }
            
            foreach (var item in request.lineItem)
            {
                var product = await _productRepository.GetByIdAsync(item.productId);

                // LineItem eklenmeden önce kontrol yap
                Console.WriteLine($"Adding product with ID: {product.Id}");

                order.Add(product);
                
            }

            _orderRepository.Insert(order);

           await _orderRepository.SaveChangeAsync();

            return new CreateOrderCommandResponse
            {
                Id = order.Id,

                Success = true,

                Message = "Order created successfully",

                LineItems = order.LineItems.ToList()
              
            };
        }
    }
}
