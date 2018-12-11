using Domain.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Infrastructure.Data
{
    public class CoursesRepository
    {
        private ApplicationContext _context;

        public CoursesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public string getExamCourseById(int id)
        {
            var courseTitle = _context.Course.First(c => c.Id == id);

            return courseTitle.Title;
        }
    }
}
