using ExamManagement.Core.Entities;
using System.Collections.Generic;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface IGradeService
    {
        Grade GetGradeByStudentId(string studentId, int examId);
        void CreateGrade(Grade grade);
        void SetGrade(int gradeId, float value);
        Grade GetGradeByGradeId(int gradeId);
        List<TeacherGrade> GetAllExamGrades(int examId);
    }
}