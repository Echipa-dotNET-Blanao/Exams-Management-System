using System;
using System.Linq;
using Domain.Domain.Context;
using Domain.Domain.Entities;

namespace Infrastructure.Infrastructure.Data
{
    public class GradeRepository
    {
            private ApplicationContext _context;

            public GradeRepository(ApplicationContext _context)
            {
                _context = this._context;
            }

            public void CreateGrade(Grade grade)
            {
                _context.Add(grade);
                _context.SaveChanges();
            }

            public int GetGradeById(int id)
            {
                var examGrade = _context.Grades.First(c => c.examId == id);
                return examGrade.grade;

            }
    }
}