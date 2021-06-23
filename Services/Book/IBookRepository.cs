using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Book.Data;
using Book.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Book.Services.Book
{
    public interface IBookRepository
    {
        Task AddBook(Books dto);
        Task<List<Books>> GetAll();

        void Edit(Books dto);

        Task Delete(long Id);
        Task<Books> GetById(long Id);
        Task<List<Books>> GetReceivershipList();
        Task<bool> Receivership(AddReceivershipDto dto);
        Task<bool> BackBook(AddReceivershipDto dto);
        Task Save();
    }

    public class BookRepository : IBookRepository
    {
        private readonly DataBaseContext _context;

        public BookRepository(DataBaseContext context)
        {
            _context = context;
        }


        public async Task AddBook(Books dto)
        {
            await _context.Books.AddAsync(dto);
        }

        public async Task<bool> BackBook(AddReceivershipDto dto)
        {
            var book = await GetById(dto.BookId);
            if (book.Status != false)
            {
                book.Status = false;
                book.DateBe = DateTime.Now;
                book.StudentName = "";
                _context.Books.Update(book);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Delete(long Id)
        {
            var book = await GetById(Id);
            if (book.Image != null)
            {
                string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", book.Image);
                if (System.IO.File.Exists(imgpath))
                {
                    System.IO.File.Delete(imgpath);
                }
            }
            _context.Books.Remove(book);
        }

        public void Edit(Books dto)
        {
            _context.Books.Update(dto);
        }

        public async Task<List<Books>> GetAll()
        {
            return await _context.Books.OrderByDescending(p => p.BookId).ToListAsync();
        }

        public async Task<Books> GetById(long Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task<List<Books>> GetReceivershipList()
        {
            return await _context.Books.Where(p => p.Status == true).OrderByDescending(p=>p.BookId).ToListAsync();
        }

        public async Task<bool> Receivership(AddReceivershipDto dto)
        {
            var book = await GetById(dto.BookId);
            if (book.Status != true)
            {
                book.Status = true;
                book.DateBe = DateTime.Now.AddDays(13);
                var stu = await _context.Students.FindAsync((long)dto.StudentId);
                if (stu != null)
                {
                    book.StudentName = stu.Name + " " + stu.Family;
                }
                else
                {
                      return  false;
                }
                _context.Books.Update(book);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}