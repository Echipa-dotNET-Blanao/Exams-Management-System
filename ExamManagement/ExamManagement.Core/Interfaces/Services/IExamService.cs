using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Enums;
using System.Collections.Generic;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface IExamService
    {
        void CreateExam(Exam exam);
        void StartExam(int examId);
        void CloseExam(int examId);
        void PublishGrades(int examId);
        void ManageExam(int examId, ManageExamTask task);
        List<StudentExam> GetAllStudentExams(string studentId);
        List<StudentExam> GetFutureStudentExams(string studentId);
        List<StudentExam> GetPastStudentExams(string studentId);
        List<TeacherExam> GetAllTeacherExams(int studentId);
    }
}