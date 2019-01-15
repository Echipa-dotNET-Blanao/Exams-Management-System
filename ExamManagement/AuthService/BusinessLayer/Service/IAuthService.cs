using AuthService.Requests;

namespace AuthService.BusinessLayer.Service
{
    public interface IAuthService
    {
        AuthResponse Auth(AuthRequest authStudentRequest);
    }
}
