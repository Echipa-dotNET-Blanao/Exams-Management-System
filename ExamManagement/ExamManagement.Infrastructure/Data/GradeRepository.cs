using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
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

        public Grade GetGradeByStudentId(string studentId, int examId)
        {

            IEnumerable<Grade> gradeQuery = from grade in _dbContext.Grades
                where grade.studentId == studentId && grade.examId == examId
                orderby grade
                select grade;

            return gradeQuery.FirstOrDefault();

        }

        public void CreateGrade(Grade grade)
        {
            _dbContext.Set<Grade>().Add(grade);
            _dbContext.SaveChanges();
        }

        public void SetGrade(int gradeId, float value)
        {
            var query = from grade in _dbContext.Grades
                where grade.id == gradeId
                select grade;

            foreach (var grade in query)
            {
                grade.grade = value;
            }

            _dbContext.SaveChanges();
        }

        public void MarkStudentPresent(string studentId, int examId)
        {
            var query = from grade in _dbContext.Grades
                where grade.studentId == studentId && grade.examId == examId
                select grade;

            foreach (var grade in query)
            {
                grade.present = true;
            }

            _dbContext.SaveChanges();
        }
    }

}