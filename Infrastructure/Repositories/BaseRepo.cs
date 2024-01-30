using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected BaseRepo(DataContext context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }
       
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var result = _context.Set<TEntity>().ToList();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = _context.Set<TEntity>().FirstOrDefault(predicate);
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }
        public virtual TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity entity) 
        {
            try
            {
                var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(predicate);
                if (entityToUpdate != null)
                {
                    
                    _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entityToUpdate;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return null!;
        }

        
        public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entityToDelete = _context.Set<TEntity>().FirstOrDefault(predicate);
                if (entityToDelete != null)
                {
                    _context.Set<TEntity>().Remove(entityToDelete);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return false;
        }

        
        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = _context.Set<TEntity>().Any(predicate);
                return result;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return false;
        }
    }

    
}
