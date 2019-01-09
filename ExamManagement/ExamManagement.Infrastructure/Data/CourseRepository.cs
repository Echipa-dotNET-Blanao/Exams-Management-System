using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(DbContext dbContext)
        {
            _dbContext = dbContext as AppDbContext;
        }

        public void Add(Course course)
        {
            _dbContext.Add(course);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            _dbContext.Remove(course);
            _dbContext.SaveChanges();
        }

        public List<Course> GetAll()
        {
            IEnumerable<Course> courseQuery = from course in _dbContext.Courses
                select course;
            return courseQuery.ToList();
        }

        public Course GetById(int id)
        {
            IEnumerable<Course> courseQuery = from course in _dbContext.Courses
                where course.Id == id
                select course;

            return courseQuery.FirstOrDefault();
        }

        public void Update(int id, Course course)
        {
            var originalCourse = GetById(id);
            originalCourse.Id = course.Id;
            originalCourse.Title = course.Title;
            originalCourse.StudyYear = course.StudyYear;
            originalCourse.Semester = course.Semester;
            _dbContext.SaveChanges();
        }
    }
}