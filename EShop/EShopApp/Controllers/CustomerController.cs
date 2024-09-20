using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Customer.GetAll;
using Application.Customer.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
             GetAllCustomersQueryResponse.GetAllCustomersResponse response = await _mediator.Send(getAllCustomersQueryRequest);
            return Ok(response);            
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromQuery] CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse  response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }
    }
}

