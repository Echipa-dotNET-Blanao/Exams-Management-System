using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public enum ManageExamTask
    {
        Start, End, PublishGrades
    }
    public interface IExamRepository
    {
        void CreateExam(Exam exam);
        void StartExam(int examID);
        void CloseExam(int examID);
        void PublishGrades(int examID);
        void ManageExam(int examID, ManageExamTask task);
    }
}