using Book.Data;
using Book.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Services.Student
{
    public interface IStudentRepository
    {
        Task AddStudent(AddStudentDto dto);
        Task<List<Students>> GetAll();

        void Edit(Students dto);

        Task Delete(long Id);
        Task<Students> GetById(long Id);
        Task Save();
    }

    public class StudentRepository : IStudentRepository
    {

        private readonly DataBaseContext _context;

        public StudentRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task AddStudent(AddStudentDto dto)
        {
            await _context.Students.AddAsync(new Students()
            {
                Name = dto.Name,
                Family=dto.Family,
                FatherName=dto.FatherName,
                NationalCode=dto.NationalCode,
                PhoneNumber=dto.PhoneNumber,
            });
        }

        public async Task Delete(long Id)
        {
            _context.Students.Remove(await GetById(Id));
        }

        public  void Edit(Students dto)
        {
            _context.Students.Update(dto);
        }

        public async Task<List<Students>> GetAll()
        {
            return await _context.Students.OrderByDescending(p=>p.StudentId).ToListAsync();
        }

        public async Task<Students> GetById(long Id)
        {
            return await _context.Students.FindAsync(Id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
