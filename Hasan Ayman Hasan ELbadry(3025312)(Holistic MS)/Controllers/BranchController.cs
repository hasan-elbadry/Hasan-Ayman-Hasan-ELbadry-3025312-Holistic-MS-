using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.BranchDtos;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _BranchRepository;

        public BranchController(IBranchRepository BranchRepository)
        {
            _BranchRepository = BranchRepository;
        }

        [HttpPost]
        public IActionResult AddBranch(CreateBranchWithCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _BranchRepository.AddBranch(dto);
            if (!res)
                return BadRequest();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBranch(int id, UpdateBranchWithCustomerIds dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = _BranchRepository.UpdateBranch(id,dto);
            if (res.Item1)
                return Ok(res.Item2);

            return NotFound(res.Item2);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBranch(int id)
        {
            var res = _BranchRepository.DeleteRepository(id);
            if(res)
                return Ok();
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var branches = _BranchRepository.getAll();
            if (branches == null)
                return NotFound();
            return Ok(branches);
        }
    }
}