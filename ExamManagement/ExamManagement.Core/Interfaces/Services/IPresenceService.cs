namespace ExamManagement.Core.Interfaces.Services
{
    public interface IPresenceService
    {
        void MarkStudentPresent(string studentId, int examId, string token);
    }
}
