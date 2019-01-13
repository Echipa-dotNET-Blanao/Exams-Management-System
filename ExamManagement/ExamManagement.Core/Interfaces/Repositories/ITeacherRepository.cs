using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Teacher GetById(string id);
        List<Teacher> GetAll();
        void Add(Teacher student);
        void Update(string id, Teacher student);
        void Delete(string id);
    }
}