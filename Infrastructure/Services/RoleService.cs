using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class RoleService(RoleRepository roleRepository)
{
    private readonly RoleRepository _roleRepository = roleRepository;

    public RoleEntity CreateRole(string roleName)
    {
        try
        {
            var roleEntity = _roleRepository.GetSingle(x => x.RoleName == roleName);
            if (roleEntity == null)
            {
                roleEntity = new RoleEntity { RoleName = roleName };
                roleEntity = _roleRepository.Create(roleEntity);
            }
            return roleEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
        
    }

    public RoleEntity GetRoleByName(string roleName)
    {
        var roleEntity = _roleRepository.GetSingle(x => x.RoleName == roleName);
        return roleEntity;
    }

    public RoleEntity GetRoleById(int id)
    {
        var roleEntity = _roleRepository.GetSingle(x => x.Id == id);
        return roleEntity;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        var roles = _roleRepository.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return updatedRoleEntity;
    }

    public bool DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
        return true;
    }
}
