using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.AccountDtos;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountController(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        [HttpPost]
        public IActionResult AddAccount(CreateAccountWithCustomer dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = _AccountRepository.AddAccount(dto);
                if (!res)
                    return BadRequest();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
