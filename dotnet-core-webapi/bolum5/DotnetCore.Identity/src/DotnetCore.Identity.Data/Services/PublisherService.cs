using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Identity.Data.DbContexts;
using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Identity.Data.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationUserDbContext _context;
        public PublisherService(ApplicationUserDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreatePublisherInput input)
        {
            try
            {
                var newPub = new Publisher
                {
                    Name = input.Name
                };
                _context.Publishers.Add(newPub);
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var publisher = await _context.Publishers.FindAsync(id);

                if (publisher != null)
                {
                    _context.Publishers.Remove(publisher);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            try
            {
                return await _context.Publishers
                    .Include(p=>p.Books)
                    .ToListAsync();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Publisher> GetAsync(int id)
        {
            try
            {
                return await _context.Publishers.FindAsync(id);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Publisher> UpdateAsync(UpdatePublisherInput input)
        {
            try
            {
                Publisher oldPub = await GetAsync(input.Id);
                oldPub.Name = input.Name;
                await _context.SaveChangesAsync();
                return oldPub;
            }
            catch (Exception err)
            {

                throw err;
            }
        }
    }
}
