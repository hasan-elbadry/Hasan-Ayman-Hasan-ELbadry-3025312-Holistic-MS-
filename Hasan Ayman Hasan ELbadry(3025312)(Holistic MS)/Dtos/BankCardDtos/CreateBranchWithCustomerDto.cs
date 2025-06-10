using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.CustomerDtos;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;
using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.BankCardDtos
{
    public class CreateBranchWithCustomerDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public List<CreateCustomerDto>? Customers { get; set; }
    }
}
