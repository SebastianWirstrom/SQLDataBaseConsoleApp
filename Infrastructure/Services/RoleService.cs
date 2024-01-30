using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class RoleService(RoleRepository roleRepository)
{
    private readonly RoleRepository _roleRepository = roleRepository;

    public RoleEntity CreateRole(string roleName)
    {
        var RoleEntity = _roleRepository.GetSingle(x => x.RoleName == roleName);
        if (RoleEntity == null)
        {
            RoleEntity = _roleRepository.Create(new RoleEntity { RoleName = roleName });
            return RoleEntity;
        }
        else
        {
            return null!;
        }
    }

    public RoleEntity GetRoleByName(string roleName)
    {
        var RoleEntity = _roleRepository.GetSingle(x => x.RoleName == roleName);
        return RoleEntity;
    }

    public RoleEntity GetRoleById(int id)
    {
        var RoleEntity = _roleRepository.GetSingle(x => x.Id == id);
        return RoleEntity;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        var roles = _roleRepository.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity RoleEntity)
    {
        var updatedRoleEntity = _roleRepository.Update(x => x.Id == RoleEntity.Id, RoleEntity);
        return updatedRoleEntity;
    }

    public bool DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
        return true;
    }
}
