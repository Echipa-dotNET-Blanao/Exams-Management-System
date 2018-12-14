using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IGradeRepository
    {
        Grade GetById(int id);
        List<Grade> GetAll();
        void Add(Grade grade);
        void Update(int id, Grade grade);
        void Delete(int id);
    }
}