using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string DNI { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
