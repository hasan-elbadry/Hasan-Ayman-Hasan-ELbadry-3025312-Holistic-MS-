using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.AccountDtos
{
    public class CreateAccountDto
    {
        public string AccountNumber { get; set; }//unique
        [Range(0.01, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
