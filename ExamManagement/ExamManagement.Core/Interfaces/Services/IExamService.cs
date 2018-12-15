using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Services
{

    public interface IExamService
    {

        void CreateExam(Exam exam);
        void StartExam(int examId);
        void CloseExam(int examId);
        void PublishGrades(int examID);
        void ManageExam(int examId, Enums.ManageExamTask task);
    }
}
