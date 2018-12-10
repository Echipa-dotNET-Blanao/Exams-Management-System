using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Entities;

namespace Services.Services.Interfaces
{
    public interface IExamService
    {
        void AddExam(Exam exam);
    }
}
