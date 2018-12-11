using Domain.Domain.Context;
using Domain.Domain.Entities;

namespace Infrastructure.Infrastructure.Data
{
    public class StudentRepository
    {
        public ApplicationContext _context;

        public StudentRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public void AddStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }
    }
}