using AuthService.Requests;

namespace AuthService.BusinessLayer.Repository
{
    public interface IAuthRepository
    {
        bool StudentExists(AuthRequest authStudentRequest);
        AuthStudentResponse RetriveLoggedStudentInformation(AuthRequest authStudentRequest);
        bool TeacherExists(AuthRequest authStudentRequest);
        AuthTeacherResponse RetriveLoggedTeacherInformation(AuthRequest authStudentRequest);
    }
}
