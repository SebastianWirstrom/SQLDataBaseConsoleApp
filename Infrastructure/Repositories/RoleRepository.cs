using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class RoleRepository(DataContext context) : BaseRepo<RoleEntity>(context)
{
    private readonly DataContext _context = context;
}
