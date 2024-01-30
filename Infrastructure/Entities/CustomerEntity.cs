using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; } = null!;

        [Required]
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;

    }
}
