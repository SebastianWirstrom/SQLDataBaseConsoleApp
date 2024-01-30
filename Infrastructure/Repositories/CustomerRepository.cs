using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : BaseRepo<CustomerEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<CustomerEntity> GetAll()
    {
        return _context.Customer.Include(i => i.Address).Include(i => i.Role).ToList();
    }

    public override CustomerEntity GetSingle(Expression<Func<CustomerEntity, bool>> predicate)
    {
        var entity = _context.Customer.Include(i => i.Address).Include(i => i.Role).FirstOrDefault(predicate)!;
        return entity;
    }
}
