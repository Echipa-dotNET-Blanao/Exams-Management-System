using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Entities;

namespace Domain.Domain.Interfaces
{
    public interface IExamRepository
    {
        void CreateExam(Exam exam);
    }
}
