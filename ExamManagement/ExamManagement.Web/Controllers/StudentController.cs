using System.Net;
using System.Net.Http;
using ExamManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost("Presence")]
        public HttpResponseMessage Presence (MarkPresenceRequest markPresence)
        {
            if(markPresence == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if(markPresence.ExamID == 0)
            {
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
            else if (getGradeRequest.ExamID == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }

    }
}