using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Infrastructure.Data
{
    public class DidacticRepository : IDidacticRepository
    {
        private readonly AppDbContext _dbContext;

        public DidacticRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Didactic teacher)
        {
            _dbContext.Add(teacher);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var didactic = GetById(id);
            _dbContext.Remove(didactic);
            _dbContext.SaveChanges();
        }

        public List<Didactic> GetAll()
        {
            IEnumerable<Didactic> didacticQuery = from did in _dbContext.Didactics select did;
            return didacticQuery.ToList();
        }

        public Didactic GetById(int id)
        {
            IEnumerable<Didactic> didacticQuey = from did in _dbContext.Didactics
                where did.Id == id
                select did;

            return didacticQuey.FirstOrDefault();
        }

        public void Update(int id, Didactic didactic)
        {
            var originalDidactic = GetById(id);
            originalDidactic.CourseId = didactic.CourseId;
            originalDidactic.Id = didactic.Id;
            originalDidactic.TeacherId = originalDidactic.TeacherId;
            _dbContext.SaveChanges();
        }
    }
}