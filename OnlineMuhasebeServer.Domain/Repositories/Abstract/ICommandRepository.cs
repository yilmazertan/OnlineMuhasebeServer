using OnlineMuhasebeServer.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories.Abstract
{
    public interface ICommandRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task DeleteByIdAsync(string Id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

    }
}
