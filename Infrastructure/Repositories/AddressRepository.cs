using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class AddressRepository(DataContext context) : BaseRepo<CategoryEntity>(context)
{
    private readonly DataContext _context = context;
}
