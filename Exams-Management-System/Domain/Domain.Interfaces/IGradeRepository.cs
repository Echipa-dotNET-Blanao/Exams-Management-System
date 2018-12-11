using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Entities;

namespace Domain.Domain.Interfaces
{
    public interface IGradeRepository
    {
        int GetGradeById(char id);
        void CreateGrade(Grade grade);
    }
}