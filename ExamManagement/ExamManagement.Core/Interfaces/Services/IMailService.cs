using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface IMailService
    {
        void SendEmail(string toAdress, string subject, string body);
    }
}
