using AuthService.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.BusinessLayer.Repository
{
    public interface IAuthRepository
    {
        bool studentExists(AuthStudentRequest authStudentRequest);
        AuthStudentResponse retriveLoggedStudentInformation(AuthStudentRequest authStudentRequest);
    }
}
