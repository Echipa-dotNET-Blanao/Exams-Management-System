using MailKit.Net.Smtp;
using MimeKit;

namespace ExamManagement.Services
{
    public static class MailService
    {
        public static void SendEmail(string toAdress, string subject, string body)
        {
            string FromAddress = "fii.exam.management@gmail.com";

            string SmtpServer = "smtp.gmail.com";
            int SmtpPortNumber = 587;

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromAddress));
            mimeMessage.To.Add(new MailboxAddress(toAdress));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {

                client.Connect(SmtpServer, SmtpPortNumber, false);
                client.Authenticate("fii.exam.management@gmail.com", "fiiexam123");
                client.Send(mimeMessage);
                client.Disconnect(true);

            }
        }
    }
}