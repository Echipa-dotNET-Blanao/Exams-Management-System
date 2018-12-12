using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IExamRepository
    {
        void CreateExam(Exam exam);
        void StartExam(int examID);
        void CloseExam(int examID);
        void PublishGrades(int examID);
    }
}