using Book.Data;
using Book.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Services.Student
{
    public interface IStudentRepository
    {
        void AddStudent(AddStudentDto dto);
        List<Students> GetAll();

        void Edit(Students dto);

        void Delete(long Id);
        Students GetById(long Id);
        void Save();
    }

    public class StudentRepository : IStudentRepository
    {

        private readonly DataBaseContext _context;

        public StudentRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void AddStudent(AddStudentDto dto)
        {
            _context.Students.Add(new Students()
            {
                Name = dto.Name,
                Family=dto.Family,
                FatherName=dto.FatherName,
                NationalCode=dto.NationalCode,
                PhoneNumber=dto.PhoneNumber,
            });
        }

        public void Delete(long Id)
        {
            _context.Students.Remove(GetById(Id));
        }

        public void Edit(Students dto)
        {
            _context.Students.Update(dto);
        }

        public List<Students> GetAll()
        {
            return _context.Students.OrderByDescending(p=>p.StudentId).ToList();
        }

        public Students GetById(long Id)
        {
            return _context.Students.Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
