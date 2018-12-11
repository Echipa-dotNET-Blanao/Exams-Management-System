using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
using ExamManagement.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Data
{
    public class GradeRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T CreateGrade<T>(T entity) where T : Grade
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
    
}