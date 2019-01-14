using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IDidacticRepository
    {
        Didactic GetById(int id);
        List<Didactic> GetAll();
        void Add(Didactic didactic);
        void Update(int id, Didactic student);
        void Delete(int id);
    }
}