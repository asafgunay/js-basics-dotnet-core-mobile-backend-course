using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.Services
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
