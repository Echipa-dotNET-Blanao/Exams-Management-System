using System.Linq;
using System;
using AuthService.DataLayer.Management;
using AuthService.Requests;

namespace AuthService.BusinessLayer.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext applicationContext;

        public AuthRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public AuthStudentResponse RetriveLoggedStudentInformation(AuthRequest authStudentRequest)
        {
            AuthStudentResponse responseStudent = null;
            if (StudentExists(authStudentRequest) == true)
            {
                var dbStudent = applicationContext.Students.First(s => s.Id == authStudentRequest.Username && s.PasswordBase == authStudentRequest.Password);
                string id = dbStudent.Id;
                string email = dbStudent.Email;
                string fullName = dbStudent.PullName;
                int studyYear = dbStudent.StudyYear;
                string studyGroup = dbStudent.StudyGroup;
                responseStudent = new AuthStudentResponse(id, email, fullName, studyYear, studyGroup);
                responseStudent.IsStudent = true;
            }
            return responseStudent;
        }

        public AuthTeacherResponse RetriveLoggedTeacherInformation(AuthRequest authStudentRequest)
        {
            AuthTeacherResponse responseStudent = null;
            if (TeacherExists(authStudentRequest) == true)
            {
                var dbStudent = applicationContext.Teachers.First(s => s.Email == authStudentRequest.Username && s.PasswordBase == authStudentRequest.Password);
                int id = dbStudent.Id;
                string email = dbStudent.Email;
                string fullName = dbStudent.FullName;
                responseStudent = new AuthTeacherResponse(id, email, fullName);
                responseStudent.IsStudent = false;
            }
            return responseStudent;
        }

        public bool StudentExists(AuthRequest authStudentRequest)
        {
            var dbStudent = applicationContext.Students.First(s => s.Id == authStudentRequest.Username && s.PasswordBase == authStudentRequest.Password);
            return dbStudent == null ? false : true;
        }

        public bool TeacherExists(AuthRequest authStudentRequest)
        {
            var dbStudent = applicationContext.Teachers.First(s => s.Email == authStudentRequest.Username && s.PasswordBase == authStudentRequest.Password);
            return dbStudent == null ? false : true;
        }
    }
}
