using System.Net;
using System.Net.Http;
using ExamManagement.Core.Requests;
using ExamManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly GradeRepository gradeRepo;
        [HttpPost("Presence")]
        public HttpResponseMessage Presence (MarkPresenceRequest markPresence)
        {
            if(markPresence == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if(markPresence.StudentID != null && markPresence.ExamID != 0 && markPresence.Token != null)
            {
                gradeRepo.MarkStudentPresent(markPresence.StudentID, markPresence.ExamID);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }

        [HttpPost("GetYourGrade")]
        public HttpResponseMessage GetYourGrade(GetGradeRequest getGradeRequest)
        {
            if (getGradeRequest == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if (getGradeRequest.StudentID != null && getGradeRequest.ExamID != 0)
            {
                gradeRepo.GetGradeByStudentId(getGradeRequest.StudentID, getGradeRequest.ExamID);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }

    }
}