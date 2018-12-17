using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencesController : ControllerBase
    {
        private readonly IPresenceService _presenceService;

        public PresencesController(IPresenceService presenceService)
        {
            _presenceService = presenceService;
        }

        [HttpPut]
        public HttpResponseMessage Presence([FromBody] MarkPresenceRequest markPresenceRequest)
        {
            _presenceService.MarkStudentPresent(markPresenceRequest.StudentID, markPresenceRequest.ExamID, markPresenceRequest.Token);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
       }
    }
}