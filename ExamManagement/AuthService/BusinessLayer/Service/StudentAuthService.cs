using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.BusinessLayer.Repository;
using AuthService.Requests;

namespace AuthService.BusinessLayer.Service
{
    public class StudentAuthService : IStudentAuthService
    {
        private readonly IAuthRepository authRepository;

        public StudentAuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public AuthStudentResponse authStudent(AuthStudentRequest authStudentRequest)
        {
            return authRepository.retriveLoggedStudentInformation(authStudentRequest);
        }
    }
}
