using DotnetCore.Identity.Data.DbContexts;
using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.Services
{
    public class AuthorService : IAuthorSevice
    {
        private readonly ApplicationUserDbContext _context;
        public AuthorService(ApplicationUserDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreateAuthorInput input)
        {
            try
            {
                var newPub = new Author
                {
                    Name = input.Name
                };
                _context.Authors.Add(newPub);
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
                var Author = await _context.Authors.FindAsync(id);

                if (Author != null)
                {
                    _context.Authors.Remove(Author);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<List<Author>> GetAllAsync()
        {
            try
            {
                return await _context.Authors.ToListAsync();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Author> GetAsync(int id)
        {
            try
            {
                return await _context.Authors.FindAsync(id);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Author> UpdateAsync(UpdateAuthorInput input)
        {
            try
            {
                Author oldPub = await GetAsync(input.Id);
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
