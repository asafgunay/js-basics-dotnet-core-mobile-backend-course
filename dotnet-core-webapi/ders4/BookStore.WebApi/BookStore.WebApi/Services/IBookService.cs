using BookStore.WebApi.Models;
using BookStore.WebApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.WebApi.Services
{
    public interface IBookService
    {
        Task CreateAsync(CreateBookInput input);
        Task DeleteAsync(int id);
        Task<Book> GetAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<Book> UpdateAsync(UpdateBookInput input);
    }
}
