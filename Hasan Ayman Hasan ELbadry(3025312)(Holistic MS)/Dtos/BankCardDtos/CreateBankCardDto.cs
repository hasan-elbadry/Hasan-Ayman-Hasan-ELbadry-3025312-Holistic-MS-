using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.BankCardDtos
{
    public class CreateBankCardDto
    {
        [Required, MaxLength(16)]
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
