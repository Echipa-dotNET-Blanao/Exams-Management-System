using System;
using System.Net;
using System.Net.Http;
using ExamManagement.Core.Interfaces;
using ExamManagement.Core.Requests;
using ExamManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IGradeRepository _gradeRepo;
        public StudentController(IGradeRepository gradeRepo)
        {
            _gradeRepo = gradeRepo;
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/presence")]
        public HttpResponseMessage Presence([FromBody] MarkPresenceRequest markPresence)
        {
            if (markPresence == null) throw new ArgumentNullException(nameof(markPresence));

            if (markPresence.StudentID != null && markPresence.ExamID != 0 && markPresence.Token != null)
            {
                _gradeRepo.MarkStudentPresent(markPresence.StudentID, markPresence.ExamID, markPresence.Token);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpGet]
        [Route("get/yourGrades")]
        public JsonResult GetYourGrade(string studentId, int examId)
        {
            if (studentId == null) throw new ArgumentNullException(nameof(studentId));

            if (examId <= 0) throw new ArgumentOutOfRangeException(nameof(examId));

            return Json(_gradeRepo.GetGradeByStudentId(studentId, examId));
        }
    }
}