using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Entities;
using Domain.Domain.Interfaces;

namespace Services.Services.Implementation
{
    public class ExamService
    {
        private IExamRepository _repository;

        private ICoursesRepository _coursesRepository;

        public ExamService(IExamRepository _repository)
        {
            _repository = this._repository;
        }

        public void AddExam(Exam exam)
        {
            string courseName = _coursesRepository.getExamCourseById(exam.CourseId);

            if(courseName == null)
            {
                throw new Exception("Course for which you trying to create an exam doesn't exist doesn't exist");
            }
            else
            {
                _repository.CreateExam(exam);
            }
        }
    }
}
