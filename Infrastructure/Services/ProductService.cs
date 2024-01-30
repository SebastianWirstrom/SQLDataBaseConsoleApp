using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class ProductService(CategoryRepository categoryService, ProductRepository productRepository)
    {
        private readonly ProductRepository _productRepository = productRepository;
        private readonly CategoryRepository _categoryService = categoryService;

        public RoleEntity GetProductByName(string roleName)
        {
            var RoleEntity = _productRepository.GetSingle(x => x.RoleName == roleName);
            return RoleEntity;
        }

        public RoleEntity GetRoleById(int id)
        {
            var RoleEntity = _productRepository.GetSingle(x => x.Id == id);
            return RoleEntity;
        }

        public IEnumerable<RoleEntity> GetRoles()
        {
            var roles = _productRepository.GetAll();
            return roles;
        }

        public RoleEntity UpdateRole(RoleEntity RoleEntity)
        {
            var updatedRoleEntity = _productRepository.Update(x => x.Id == RoleEntity.Id, RoleEntity);
            return updatedRoleEntity;
        }

        public bool DeleteRole(int id)
        {
            _productRepository.Delete(x => x.Id == id);
            return true;
        }
    }

    
}
