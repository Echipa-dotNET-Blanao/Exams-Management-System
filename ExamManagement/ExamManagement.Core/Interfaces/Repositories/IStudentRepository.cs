using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student GetById(string id);
        List<Student> GetAll();
        void Add(Student student);
        void Update(string id, Student student);
        void Delete(string id);
    }
}