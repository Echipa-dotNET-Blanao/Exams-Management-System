using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IExamRepository
    {
        void CreateExam(Exam exam);
        void StartExam(Exam exam);
        void CloseExam(Exam exam);
    }
}