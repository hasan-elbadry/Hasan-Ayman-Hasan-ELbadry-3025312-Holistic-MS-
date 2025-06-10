using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models
{
    public class BankCard
    {
        public int Id { get; set; }
        [Required, MaxLength(16)]
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer {  get; set; }
    }
}
