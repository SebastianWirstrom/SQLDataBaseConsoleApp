using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ProductRepository(DataContext context) : BaseRepo<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Product.Include(i => i.Category).ToList();
    }

    public override ProductEntity GetSingle(Expression<Func<ProductEntity, bool>> predicate)
    {
        var entity = _context.Product.Include(i => i.Category).FirstOrDefault(predicate)!;
        return entity;
    }
}
