using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<TResult> GetAsync<TResult>(int id);
        Task<PaginateResponse<TResult>> GetAllAsync<TResult>(PaginateRequestDTO paginateRequestDTO);

        Task<bool> ExistAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> AddAsync<TSource>(TSource source);
        Task UpdateAsync<TSource>(int Id, TSource source);
        Task DeleteAsync(T entity);
    }
}
