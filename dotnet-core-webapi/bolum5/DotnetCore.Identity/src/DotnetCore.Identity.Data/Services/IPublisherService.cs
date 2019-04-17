using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.Services
{
    public interface IPublisherService
    {
        Task CreateAsync(CreatePublisherInput input);
        Task DeleteAsync(int id);
        Task<Publisher> GetAsync(int id);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> UpdateAsync(UpdatePublisherInput input);
    }
}
