using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.Services
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
