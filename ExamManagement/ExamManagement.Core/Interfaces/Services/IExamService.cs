using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Enums;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface IExamService
    {
        void CreateExam(Exam exam);
        void StartExam(int examId);
        void CloseExam(int examId);
        void PublishGrades(int examId);
        void ManageExam(int examId, ManageExamTask task);
    }
}