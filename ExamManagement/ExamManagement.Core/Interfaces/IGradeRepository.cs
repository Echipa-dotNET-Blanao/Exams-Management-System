using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGradeByStudentId(string studentId, int examId);
        void CreateGrade(Grade grade);
        void MarkStudentPresent(string id);
        

    }
}