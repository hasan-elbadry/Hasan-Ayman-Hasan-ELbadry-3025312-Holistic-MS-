using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public List<Branch>? Branches { get ; set; }
        public List<Account>? Accounts { get; set; }
        public BankCard? BankCard { get; set; }
    }
}
