using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;

namespace ExamManagement.Infrastructure.Data
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Grade> GetGradeByStudentId(string studentId, int examId)
        {

            IEnumerable<Grade> gradeQuery = from grade in _dbContext.Grades
                where grade.studentId == studentId && grade.examId == examId
                orderby grade
                select grade;

            return gradeQuery;

        }

        public void CreateGrade(Grade grade)
        {
            _dbContext.Set<Grade>().Add(grade);
            _dbContext.SaveChanges();
        }

        public void MarkStudentPresent(string studentId, int examId)
        {
            var query = from grade in _dbContext.Grades
                where grade.studentId == studentId && grade.examId == examId
                select grade;

            foreach (var grade in query)
            {
                grade.present = 1;
            }

            _dbContext.SaveChanges();
        }
    }
    
}