using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IExamRepository
    {
        void CreateExam(Exam exam);
        void StartExam(int examId);
        void CloseExam(int examId);
    }
}