using System;
using Domain.Domain.Entities;
using Domain.Domain.Interfaces;

namespace Services.Services.Implementation
{
    public class GradeService
    {
        private IGradeRepository _repository;

        private IStudentRepository _studentRepository;

        public GradeService(IGradeRepository _repository)
        {
            _repository = this._repository;
        }

        public void SetGrade(Grade grade)
        {
            var student = _studentRepository.getStudentById(grade.studentId);

            if(student == null)
            {
                throw new Exception("Course for which you trying to create an exam doesn't exist doesn't exist");
            }
            else
            {
                _repository.CreateGrade(grade);
            }
        }
    }
}