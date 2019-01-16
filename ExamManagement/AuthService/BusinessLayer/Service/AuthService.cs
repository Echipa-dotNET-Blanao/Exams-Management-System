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
            //if (Regex.Matches(authRequest.Username, "[0-9a-zA-Z\\.]@[0-9a-zA-Z\\.]\\.[a-zA-Z\\.]").Count==1)
            if (authRequest.Username.Contains('@'))
                return _authRepository.RetriveLoggedTeacherInformation(authRequest);
            else
                return _authRepository.RetriveLoggedStudentInformation(authRequest);
        }
    }
}
