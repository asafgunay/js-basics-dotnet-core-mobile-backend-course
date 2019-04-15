using BookStore.WebApi.Models;
using BookStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.Services
{
    public interface IAuthorSevice
    {
        Task CreateAsync(CreateAuthorInput input);
        Task DeleteAsync(int id);
        Task<Author> GetAsync(int id);
        Task<List<Author>> GetAllAsync();
        Task<Author> UpdateAsync(UpdateAuthorInput input);
    }
}
