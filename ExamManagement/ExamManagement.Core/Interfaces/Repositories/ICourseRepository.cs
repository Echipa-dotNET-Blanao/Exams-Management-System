using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Course GetById(int id);
        List<Course> GetAll();
        void Add(Course course);
        void Update(int id, Course course);
        void Delete(int id);
    }
}