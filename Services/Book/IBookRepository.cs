using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Book.Data;
using Book.Dtos;

namespace Book.Services.Book
{
    public interface IBookRepository
    {
        void AddBook(Books dto);
        List<Books> GetAll();

        void Edit(Books dto);

        void Delete(long Id);
        Books GetById(long Id);
        List<Books> GetReceivershipList();
        bool Receivership(AddReceivershipDto dto);
        bool BackBook(AddReceivershipDto dto);
        void Save();
    }

    public class BookRepository : IBookRepository
    {
        private readonly DataBaseContext _context;

        public BookRepository(DataBaseContext context)
        {
            _context = context;
        }


        public void AddBook(Books dto)
        {
            _context.Books.Add(dto);
        }

        public bool BackBook(AddReceivershipDto dto)
        {
            var book = GetById(dto.BookId);
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

        public void Delete(long Id)
        {
            var book = GetById(Id);
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

        public List<Books> GetAll()
        {
            return _context.Books.OrderByDescending(p => p.BookId).ToList();
        }

        public Books GetById(long Id)
        {
            return _context.Books.Find(Id);
        }

        public List<Books> GetReceivershipList()
        {
            return _context.Books.Where(p => p.Status == true).OrderByDescending(p=>p.BookId).ToList();
        }

        public bool Receivership(AddReceivershipDto dto)
        {
            var book = GetById(dto.BookId);
            if (book.Status != true)
            {
                book.Status = true;
                book.DateBe = DateTime.Now.AddDays(14);
                var stu = _context.Students.Find((long)dto.StudentId);
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}