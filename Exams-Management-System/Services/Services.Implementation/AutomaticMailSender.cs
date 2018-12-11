using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Services.Services.Implementation
{
    public class AutomaticMailSender
    {
        private void sendEmail(string targetMail, string shownTargetName, string[] attachmentNames)
        {
            var fromAddress = new MailAddress("fii.exam.management@gmail.com", "MailSendingProgram");
            var toAddress = new MailAddress(targetMail, shownTargetName);
            const string fromPassword = "fiiexam123";
            const string subject = "Grade information";
            const string body =
            @"
                Information about your new grade
            ";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
        }
    }
}
