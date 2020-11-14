using Microsoft.EntityFrameworkCore;
using Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Repositories
{
    public class PermissionRepository : Repository<Permission>
    {
        private PermissionContext dbContext;

        public PermissionRepository(PermissionContext context)
        {
            dbContext = context;
        }

        public Task<List<Permission>> GetAll()
        {
            return dbContext.Permissions.Include(p => p.permissionType).ToListAsync();
        }

        public async Task<Permission> GetById(int id)
        {
            return await dbContext.Permissions.Include(p => p.permissionType).FirstOrDefaultAsync(p => p.permissionID == id);
        }

        public async Task<Permission> Add(Permission entity)
        {
            entity.permissionType = dbContext.
                PermissionTypes.FirstOrDefault(r => r.permissionTypeID == entity.permissionType.permissionTypeID);

            dbContext.Permissions.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exists(int id)
        {
            return await dbContext.Permissions.AnyAsync(p => p.permissionID == id);
        }

        public async Task<Permission> Update(Permission updated)
        {
            dbContext.Entry(updated).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return updated;
        }

        public async Task<bool> Delete(Permission obj)
        {
            try
            {
                dbContext.Permissions.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
 