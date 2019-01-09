using AuthService.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.BusinessLayer.Service
{
    public interface IStudentAuthService
    {
        AuthStudentResponse authStudent(AuthStudentRequest authStudentRequest);
    }
}
