using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Repositories
{
    interface Repository<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Update(T last);
        public Task<T> Add(T obj);
        public Task<bool> Delete(T obj);
    }
}
