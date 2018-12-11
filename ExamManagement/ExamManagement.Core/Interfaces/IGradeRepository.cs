using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IGradeRepository
    {
        int GetGradeByStudentId(char id);
        void CreateGrade(Grade grade);
        void SetGrade(int gradeId, float value);
    }
}