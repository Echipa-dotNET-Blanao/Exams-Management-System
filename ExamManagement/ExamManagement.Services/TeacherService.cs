using System;
using System.Collections.Generic;
using ExamManagement.Core;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IDidacticRepository _didacticRepository;

        public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository,
            IDidacticRepository didacticRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _didacticRepository = didacticRepository;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            var allTeachers = _teacherRepository.GetAll();

            foreach (var grade in allTeachers)
                if (grade.Id == teacherId)
                    return grade;
            throw new KeyNotFoundException();
        }

        public TeacherInformation GetTeacherInformation(Teacher teacher)
        {
            if (teacher == null) throw new ArgumentNullException(nameof(teacher));

            TeacherInformation teacherInformation = new TeacherInformation();
            teacherInformation.FullName = teacher.FullName;
            List<Course> courses = _courseRepository.GetAll();
            List<Didactic> didactics = _didacticRepository.GetAll();
            List<Course> filteredCourses = new List<Course>();
            List<Didactic> filteredDidactics = new List<Didactic>();

            foreach (var didactic in didactics)
            {
                if (didactic.TeacherId == teacher.Id)
                    filteredDidactics.Add(didactic);
            }
            foreach (var course in courses)
            {
                foreach (var didactic in filteredDidactics)
                {
                    if (course.Id == didactic.CourseId)
                    {
                        filteredCourses.Add(course);
                    }
                }
            }
            teacherInformation.Courses = filteredCourses;

            return teacherInformation;
        }
    }
}