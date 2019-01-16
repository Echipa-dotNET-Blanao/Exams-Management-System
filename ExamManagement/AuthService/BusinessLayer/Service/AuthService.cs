using AuthService.BusinessLayer.Repository;
using AuthService.Requests;
using System.Text.RegularExpressions;

namespace AuthService.BusinessLayer.Service
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthServiceImpl(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public AuthResponse Auth(AuthRequest authRequest)
        {

            if (authRequest.Username.Contains('@'))
                return _authRepository.RetriveLoggedTeacherInformation(authRequest);
            else
                return _authRepository.RetriveLoggedStudentInformation(authRequest);
        }
    }
}
