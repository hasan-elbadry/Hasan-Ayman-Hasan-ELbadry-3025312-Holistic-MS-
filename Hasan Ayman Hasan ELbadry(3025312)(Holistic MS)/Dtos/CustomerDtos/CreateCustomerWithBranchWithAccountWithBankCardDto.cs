
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;
using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.CustomerDtos
{
    public class CreateCustomerWithBranchWithAccountWithBankCardDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public List<CreateBranchDto>? Branches { get; set; }
        public List<CreateAccountDto> Accounts { get; set; }
        public CreateBankCardDto? BankCard { get; set; }
    }
}
