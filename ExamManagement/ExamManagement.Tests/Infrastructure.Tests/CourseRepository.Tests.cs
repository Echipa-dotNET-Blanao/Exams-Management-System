using System;
using System.Reflection.Metadata.Ecma335;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace ExamManagement.Tests.Infrastructure.Tests
{
    [TestClass]
    public class CourseRepositoryTests
    {
        private readonly AppDbContext _dbContext;
        
        public CourseRepositoryTests()
        {
            var options = new DbContextOptionsBuilder();
            
            options.UseMySql("Server=golar3.go.ro;Database=FiiExam;User=fiiexam;Password=fiiexam;",
                mySqlOptions => { mySqlOptions.ServerVersion(new Version(5, 1, 73), ServerType.MySql); });
            
            _dbContext = new AppDbContext(options);
        }
        
        private Course Sut()
        {
            return new Course(3, "ML", 3, 2);
        }

        
        [TestMethod]
        public void VerifyAtributes()
        {
            Course course = Sut();
            course.id.Should().NotBe(null);
            course.title.Should().Be("ML");
            course.studyYear.Should().NotBe(null);
            course.semester.Should().NotBe(null);
        }

        [TestMethod]
        public void WhenAdded_ShouldBe_Last()
        {
            Course course = Sut();
            ICourseRepository courseRepository = new CourseRepository(_dbContext);
            courseRepository.Add(course);

            Course addedCourse = courseRepository.GetById(course.id);
            addedCourse.Should().NotBe(null);
            addedCourse.id.Should().Be(course.id);
            addedCourse.title.Should().Be(course.title);
            addedCourse.studyYear.Should().Be(course.studyYear);
            addedCourse.semester.Should().Be(course.semester);

        }
        
    }
    
}