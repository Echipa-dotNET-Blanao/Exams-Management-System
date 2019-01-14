using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Infrastructure.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _dbContext;

        public TeacherRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Teacher teacher)
        {
            _dbContext.Add(teacher);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var teacher = GetById(id);
            _dbContext.Remove(teacher);
            _dbContext.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            IEnumerable<Teacher> teacherQuery = from teach in _dbContext.Teachers select teach;
            return teacherQuery.ToList();
        }

        public Teacher GetById(int id)
        {
            IEnumerable<Teacher> teacherQuery = from teach in _dbContext.Teachers
                where teach.Id == id
                select teach;

            return teacherQuery.FirstOrDefault();
        }

        public void Update(int id, Teacher teacher)
        {
            var originalTeacher = GetById(id);
            originalTeacher.Email = teacher.Email;
            originalTeacher.FullName = teacher.FullName;
            originalTeacher.PasswordBase = teacher.PasswordBase;
            originalTeacher.PasswordHash = teacher.PasswordHash;
            _dbContext.SaveChanges();
        }
    }
}