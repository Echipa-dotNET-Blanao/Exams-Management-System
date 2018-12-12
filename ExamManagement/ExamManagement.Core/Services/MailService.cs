using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManagement.Core.Services
{
    class MailService
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
                Console.WriteLine("The mail has been sent successfully !!");
                Console.ReadLine();
                client.Disconnect(true);

            }
        }
    }
}
