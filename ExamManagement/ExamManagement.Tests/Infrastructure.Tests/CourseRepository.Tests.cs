using System;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Infrastructure.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            //_dbContext = new AppDbContext(options);
        }

        private Course Sut()
        {
            return new Course(3, "ML", 3, 2);
        }


        [TestMethod]
        public void VerifyAtributes()
        {
            var course = Sut();
            course.Id.Should().NotBe(null);
            course.Title.Should().Be("ML");
            course.StudyYear.Should().NotBe(null);
            course.Semester.Should().NotBe(null);
        }

        [TestMethod]
        public void WhenAdded_ShouldBe_Last()
        {
            var course = Sut();
            ICourseRepository courseRepository = new CourseRepository(_dbContext);
            courseRepository.Add(course);

            var addedCourse = courseRepository.GetById(course.Id);
            addedCourse.Should().NotBe(null);
            addedCourse.Id.Should().Be(course.Id);
            addedCourse.Title.Should().Be(course.Title);
            addedCourse.StudyYear.Should().Be(course.StudyYear);
            addedCourse.Semester.Should().Be(course.Semester);
        }
    }
}