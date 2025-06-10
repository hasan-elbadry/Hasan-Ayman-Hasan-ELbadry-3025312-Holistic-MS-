using System.ComponentModel.DataAnnotations;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
