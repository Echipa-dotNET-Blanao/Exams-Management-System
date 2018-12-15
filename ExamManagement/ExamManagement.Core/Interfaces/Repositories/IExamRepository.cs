using ExamManagement.Core.Entities;
using System.Collections.Generic;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IExamRepository
    {
        Exam GetById(int id);
        List<Exam> GetAll();
        void Add(Exam exam);
        void Update(int id, Exam exam);
        void Delete(int id);
    }
}