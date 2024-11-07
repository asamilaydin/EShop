using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Customer.GetAll;
using Application.Customer.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Customer.Delete;
using Application.Customer.GetById;
using Application.Order.Create;
using Application.Product.Create;
using Application.Product.Delete;
using Application.Product.GetAll;
using Application.Product.GetById;
using Application.Order.Delete;
using Application.Order.GetAll;
using Application.Order.GetById;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomersQueryRequest getAllCustomersQueryRequest)
        {
            GetAllCustomersResponse response = await _mediator.Send(getAllCustomersQueryRequest);
            return Ok(response);            
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromQuery] CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse  response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-customer")]
        public async Task<IActionResult> Delete ([FromBody] DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            DeleteCustomerCommandResponse response = await _mediator.Send(deleteCustomerCommandRequest);
            return Ok(response);
        }


        [HttpGet("GetById-Customer")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCustomerQueryRequest getByIdCustomerQueryrequest)
        {
            var response = await _mediator.Send(getByIdCustomerQueryrequest);
            return Ok(response);
            
        }

        [HttpPost("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            DeleteOrderCommandResponse response = await _mediator.Send(deleteOrderCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all-order")]
        public async Task<IActionResult> GetAllOrder()
        {
            var request = new GetAllOrderQueryRequest();
            List<GetAllOrderQueryResponse.OrderDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetById-Order")]
        public async Task<IActionResult> GetByIdOrder([FromQuery] GetByIdOrderQueryRequest getByIdOrderQueryrequest)
        {
            var response = await _mediator.Send(getByIdOrderQueryrequest);
            return Ok(response);

        }

        [HttpPost("createproduct")]
        public async Task<IActionResult> CreateProduct([FromQuery] CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("GetById-Product")]
        public async Task<IActionResult> GetByIdProduct([FromQuery] GetByIdProductQueryRequest getByIdProductQueryrequest)
        {
            var response = await _mediator.Send(getByIdProductQueryrequest);
            return Ok(response);

        }

    }
}

