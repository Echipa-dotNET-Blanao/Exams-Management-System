using Domain.Domain.Entities;
using Domain.Domain.Interfaces;

namespace Services.Services.Implementation
{
    public class StudentService
    {
        private IStudentRepository _repository;

        public StudentService(IStudentRepository _repository)
        {
            this._repository = _repository;
        }

        public void AddStudent(Student student)
        {
            
        }
    }
}