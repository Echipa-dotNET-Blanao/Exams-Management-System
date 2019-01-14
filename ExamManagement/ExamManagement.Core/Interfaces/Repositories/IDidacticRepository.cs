using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IDidacticRepository
    {
        Didactic GetById(string id);
        List<Didactic> GetAll();
        void Add(Didactic didactic);
        void Update(string id, Didactic student);
        void Delete(string id);
    }
}