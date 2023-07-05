using OnlineMuhasebeServer.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories.Abstract
{
    public interface IQueryRepository<T> where T:Entity
    {


        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
        Task<T> GetByIdAsync(string Id);
        Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetFirstAsync();

    }
}
