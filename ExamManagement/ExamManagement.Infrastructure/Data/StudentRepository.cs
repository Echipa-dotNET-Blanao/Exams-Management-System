using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Student student)
        {
            _dbContext.Add(student);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var student = GetById(id);
            _dbContext.Remove(student);
            _dbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            IEnumerable<Student> studentQuery = from stud in _dbContext.Students select stud;
            return studentQuery.ToList();
        }

        public Student GetById(string id)
        {
            IEnumerable<Student> studentQuery = from stud in _dbContext.Students
                where stud.Id == id
                select stud;

            return studentQuery.FirstOrDefault();
        }

        public void Update(string id, Student student)
        {
            var originalStudent = GetById(id);
            originalStudent.Id = student.Id;
            originalStudent.Email = student.Email;
            originalStudent.PasswordBase = student.PasswordBase;
            originalStudent.PasswordHash = student.PasswordHash;
            originalStudent.FullName = student.FullName;
            originalStudent.StudyYear = student.StudyYear;
            originalStudent.StudyGroup = student.StudyGroup;
            _dbContext.SaveChanges();
        }
    }
}