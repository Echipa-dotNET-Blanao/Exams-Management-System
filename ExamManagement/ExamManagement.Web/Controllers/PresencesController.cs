using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
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

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPut]
        public HttpResponseMessage Presence([FromBody] MarkPresenceRequest markPresenceRequest)
        {
            if (markPresenceRequest == null) throw new ArgumentNullException(nameof(markPresenceRequest));

            if (markPresenceRequest.StudentID != null && markPresenceRequest.ExamID != 0 && markPresenceRequest.Token != null)
            {
                _presenceService.MarkStudentPresent(markPresenceRequest.StudentID, markPresenceRequest.ExamID, markPresenceRequest.Token);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }
    }
}