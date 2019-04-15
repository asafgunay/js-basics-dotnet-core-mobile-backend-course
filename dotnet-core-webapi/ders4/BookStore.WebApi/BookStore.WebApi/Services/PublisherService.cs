using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.DAL;
using BookStore.WebApi.Models;
using BookStore.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookStoreDbContext _context;
        public PublisherService(BookStoreDbContext context)
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
                return await _context.Publishers.ToListAsync();
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
