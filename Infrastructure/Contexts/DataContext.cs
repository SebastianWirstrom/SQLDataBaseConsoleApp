using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AddressEntity> Address { get; set; }
        public virtual DbSet<CategoryEntity> Category { get; set; }
        public virtual DbSet<CustomerEntity> Customer { get; set; }
        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<RoleEntity> Role { get; set; }
    }
}
