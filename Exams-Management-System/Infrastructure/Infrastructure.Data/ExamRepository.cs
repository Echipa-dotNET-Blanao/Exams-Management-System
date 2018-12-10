using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Context;
using Domain.Domain.Entities;

namespace Infrastructure.Infrastructure.Data
{
    public class ExamRepository
    {
        private ApplicationContext _context;

        public ExamRepository(ApplicationContext _context)
        {
            _context = this._context;
        }

        public void CreateExam(Exam exam)
        {
            _context.Add(exam);
            _context.SaveChanges();
        }
    }
}
