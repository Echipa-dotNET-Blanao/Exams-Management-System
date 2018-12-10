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

        public ExamService(IExamRepository _repository)
        {
            _repository = this._repository;
        }

        public void AddExam(Exam exam)
        {
            _repository.CreateExam(exam);
        }
    }
}
