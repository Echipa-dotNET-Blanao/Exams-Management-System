using ExamManagement.Core.Entities;
using System;
using ExamManagement.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ExamManagement.Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Student student)
        {
            _dbContext.Add(student);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Student student = GetById(id);
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
                                                where stud.id == id
                                          select stud;

            return studentQuery.FirstOrDefault();
        }

        public void Update(string id, Student student)
        {
            Student originalStudent = GetById(id);
            originalStudent.id = student.id;
            originalStudent.email = student.email;
            originalStudent.passwordBase = student.passwordBase;
            originalStudent.passwordHash = student.passwordHash;
            originalStudent.fullName = student.fullName;
            originalStudent.studyYear = student.studyYear;
            originalStudent.studyGroup = student.studyGroup;
            _dbContext.SaveChanges();
        }
    }
}