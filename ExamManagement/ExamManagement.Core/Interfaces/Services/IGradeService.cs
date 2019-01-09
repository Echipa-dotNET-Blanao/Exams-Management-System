using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface IGradeService
    {
        Grade GetGradeByStudentId(string studentId, int examId);
        void CreateGrade(Grade grade);
        void SetGrade(int gradeId, float value);
        Grade GetGradeByGradeId(int gradeId);
    }
}