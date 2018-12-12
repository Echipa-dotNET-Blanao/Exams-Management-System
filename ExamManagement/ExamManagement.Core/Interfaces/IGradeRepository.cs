using System.Collections.Generic;
using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IGradeRepository
    {
        Grade GetGradeByStudentId(string studentId, int examId);
        void CreateGrade(Grade grade);
        void SetGrade(int gradeId, float value);
        void MarkStudentPresent(string studentId, int examId);
        IEnumerable<Grade> GetGradeByGradeId(int gradeId);

    }
}