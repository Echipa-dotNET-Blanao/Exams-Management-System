using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Teacher GetById(int id);
        List<Teacher> GetAll();
        void Add(Teacher student);
        void Update(int id, Teacher student);
        void Delete(int id);
    }
}