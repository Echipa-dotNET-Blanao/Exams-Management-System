namespace ExamManagement.Core.Interfaces.Services
{
    public interface IMailService
    {
        void SendEmail(string toAdress, string subject, string body);
    }
}