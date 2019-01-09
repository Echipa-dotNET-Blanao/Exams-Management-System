using ExamManagement.Core.Interfaces.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace ExamManagement.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(string toAdress, string subject, string body)
        {
            const string fromAddress = "fii.exam.management@gmail.com";

            const string smtpServer = "smtp.gmail.com";
            const int smtpPortNumber = 587;

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(fromAddress));
            mimeMessage.To.Add(new MailboxAddress(toAdress));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(smtpServer, smtpPortNumber, false);
                client.Authenticate("fii.exam.management@gmail.com", "fiiexam123");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
        }
    }
}