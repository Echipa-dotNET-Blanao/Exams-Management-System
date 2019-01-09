using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Data
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(DbContext dbContext)
        {
            _dbContext = dbContext as AppDbContext;
        }


        public Grade GetById(int id)
        {
            IEnumerable<Grade> gradeQuery = from grade in _dbContext.Grades
                where grade.Id == id
                select grade;

            return gradeQuery.FirstOrDefault();
        }

        public List<Grade> GetAll()
        {
            IEnumerable<Grade> gradeQuery = from grade in _dbContext.Grades
                select grade;
            return gradeQuery.ToList();
        }

        public void Add(Grade grade)
        {
            _dbContext.Add(grade);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Grade grade)
        {
            var originalGrade = GetById(id);
            originalGrade.Id = grade.Id;
            originalGrade.StudentId = grade.StudentId;
            originalGrade.ExamId = grade.ExamId;
            originalGrade.GradeValue = grade.GradeValue;
            originalGrade.ReevaluationClosed = grade.ReevaluationClosed;
            originalGrade.ReevaluationRequested = grade.ReevaluationRequested;
            originalGrade.Final = grade.Final;
            originalGrade.Pages = grade.Pages;
            originalGrade.Present = grade.Present;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var grade = GetById(id);
            _dbContext.Remove(grade);
            _dbContext.SaveChanges();
        }
    }
}