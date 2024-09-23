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

    }
}

