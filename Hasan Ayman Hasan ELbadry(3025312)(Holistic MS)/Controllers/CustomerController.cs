using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.CustomerDtos;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public IActionResult AddCustomer(CreateCustomerWithBranchWithAccountWithBankCardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _customerRepository.AddCustomer(dto);
            if (!res)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCustomer(int id)
        {

            var res = _customerRepository.getById(id);
            if (res == null)
                return NotFound();

            return Ok(res);
        }
    }
}
