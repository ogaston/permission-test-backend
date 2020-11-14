using Microsoft.EntityFrameworkCore;
using Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Repositories
{
    public class PermissionTypeRepository
    {
        private PermissionContext dbContext;

        public PermissionTypeRepository(PermissionContext context)
        {
            dbContext = context;
        }

        public Task<List<PermissionType>> GetAll()
        {
            return dbContext.PermissionTypes.ToListAsync();
        }

        public async Task<PermissionType> GetById(int id)
        {
            return await dbContext.PermissionTypes.FindAsync(id);
        }

        public async Task<PermissionType> Add(PermissionType entity)
        {
            dbContext.PermissionTypes.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<PermissionType> Update(PermissionType updated)
        {
            dbContext.Entry(updated).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return updated;
        }

        public async Task<bool> Delete(PermissionType obj)
        {
            try
            {
                dbContext.PermissionTypes.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
