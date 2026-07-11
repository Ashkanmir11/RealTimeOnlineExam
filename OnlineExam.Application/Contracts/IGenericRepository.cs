using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
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
        Task<PaginateResponse<TResult>> GetAllAsync<TResult>(PaginateRequestDTO paginateRequestDTO);
        Task<bool> ExistAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync<TSource>(int Id, TSource source);
        Task DeleteAsync(T entity);
    }
}
