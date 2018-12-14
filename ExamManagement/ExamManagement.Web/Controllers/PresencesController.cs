using ExamManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencesController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepo;
        public PresencesController(IGradeRepository gradeRepo)
        {
            _gradeRepo = gradeRepo;
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPut("{request}")]
        public HttpResponseMessage Presence([FromBody] MarkPresenceRequest request)
        {
            if (markPresence == null) throw new ArgumentNullException(nameof(markPresence));

            if (markPresence.StudentID != null && markPresence.ExamID != 0 && markPresence.Token != null)
            {
                _gradeRepo.MarkStudentPresent(markPresence.StudentID, markPresence.ExamID, markPresence.Token);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }
    }
}