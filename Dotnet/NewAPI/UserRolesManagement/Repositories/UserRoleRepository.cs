using Transflower.EKrushi.UserRolesManagement.Entities;
using Transflower.EKrushi.UserRolesManagement.Repositories.Interfaces;
using Transflower.EKrushi.UserRolesManagement.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Transflower.EKrushi.UserRolesManagement.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly UserRoleContext _context;

    public UserRoleRepository(UserRoleContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        try
        {
            var roles = await (
                from role in _context.Roles
                join userRoles in _context.UserRoles on role.Id equals userRoles.RoleId
                where userRoles.UserId == userId
                select role.Name
            ).ToListAsync();
            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<string>> GetUsersId(string roleName)
    {
        try
        {
            List<int> userIds = await (
                from role in _context.Roles
                join userRoles in _context.UserRoles on role.Id equals userRoles.RoleId
                where role.Name == roleName
                select userRoles.UserId
            ).ToListAsync();

            string userIdString = string.Join(",", userIds);
            List<string> userIdStringList = new List<string> { userIdString };
            return userIdStringList;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        bool status = false;
        try
        {
            await _context.UserRoles.AddAsync(userRole);
            status = await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }
 

    private async Task<bool> SaveChanges()
    {
        int rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }
}
