using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> ExistAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
