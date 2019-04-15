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
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;
        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreateBookInput input)
        {
            try
            {
                Book newBook = Book.Create(input.Name, input.Price, input.ImgUrl, input.Rating, input.Binding, input.ReleaseDate, input.Details, input.PublisherId, input.AuthorId);
                await _context.Books.AddAsync(newBook);
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
                var book = await GetAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public async Task<Book> UpdateAsync(UpdateBookInput input)
        {
            try
            {
                var oldBook = await GetAsync(input.Id);
                oldBook.ImgUrl = input.ImgUrl;
                oldBook.Name = input.Name;
                oldBook.Price = input.Price;
                oldBook.PublisherId = input.PublisherId;
                oldBook.Rating = input.Rating;
                oldBook.ReleaseDate = input.ReleaseDate;
                oldBook.AuthorId = input.AuthorId;
                oldBook.Binding = input.Binding;
                oldBook.Details = input.Details;
                await _context.SaveChangesAsync();
                return oldBook;
            }
            catch (Exception err)
            {

                throw err;
            }
        }
    }
}
