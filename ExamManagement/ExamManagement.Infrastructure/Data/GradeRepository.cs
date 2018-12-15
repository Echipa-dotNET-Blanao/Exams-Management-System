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
                                            where grade.id == id
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
            Grade originalGrade = GetById(id);
            originalGrade.id = grade.id;
            originalGrade.studentId = grade.studentId;
            originalGrade.examId = grade.examId;
            originalGrade.grade = grade.grade;
            originalGrade.reevaluationClosed = grade.reevaluationClosed;
            originalGrade.reevaluationRequested = grade.reevaluationRequested;
            originalGrade.final = grade.final;
            originalGrade.pages = grade.pages;
            originalGrade.present = grade.present;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Grade grade = GetById(id);
            _dbContext.Remove(grade);
            _dbContext.SaveChanges();
        }
    }

}