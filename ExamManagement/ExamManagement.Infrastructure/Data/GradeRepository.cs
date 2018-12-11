using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
using ExamManagement.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Data
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetGradeByStudentId(char id)
        {
            throw (new NotImplementedException());
        }

        public void CreateGrade(Grade grade)
        {
            _dbContext.Set<Grade>().Add(grade);
            _dbContext.SaveChanges();
        }
    }
    
}