using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AuthStudentResponse retriveLoggedStudentInformation(AuthStudentRequest authStudentRequest)
        {
            AuthStudentResponse responseStudent = null;
            if (studentExists(authStudentRequest) == true)
            {
                var dbStudent = applicationContext.Students.First(s => s.id == authStudentRequest.id && s.passwordBase == authStudentRequest.password);
                string id = dbStudent.id;
                string email = dbStudent.email;
                string fullName = dbStudent.fullName;
                int studyYear = dbStudent.studyYear;
                string studyGroup = dbStudent.studyGroup;
                responseStudent = new AuthStudentResponse(id, email, fullName, studyYear, studyGroup);
            }
            return responseStudent;
        }

        public bool studentExists(AuthStudentRequest authStudentRequest)
        {
            var dbStudent = applicationContext.Students.First(s => s.id == authStudentRequest.id && s.passwordBase == authStudentRequest.password);
            return dbStudent == null ? false : true;
        }
    }
}
