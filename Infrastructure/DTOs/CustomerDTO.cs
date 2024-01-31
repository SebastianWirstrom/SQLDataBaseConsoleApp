namespace Infrastructure.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleDTO Role { get; set; } = new RoleDTO();
        public AddressDTO Address { get; set; } = new AddressDTO();
    }
}
