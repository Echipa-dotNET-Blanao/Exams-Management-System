using System.Net;
using System.Net.Http;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;
namespace ExamManagement.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public HttpResponseMessage CreateExam([FromQuery] CreateExamRequest createExamRequest)
        {
            _examService.CreateExam(new Exam(createExamRequest.CourseId, createExamRequest.ExamDate,
                createExamRequest.Room,
                createExamRequest.StartTime, createExamRequest.EndTime, createExamRequest.CorrectionScorePostDate,
                createExamRequest.Type,
                createExamRequest.CorrectionScore));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage ManageExam([FromQuery] ManageExamRequest manageExamRequest)
        {
            _examService.ManageExam(manageExamRequest.ExamId, manageExamRequest.Task);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpGet]
        [Route("Teacher")]
        public JsonResult GetAllExamsOfTeacher(int teacherId)
        {
            return Json(_examService.GetAllTeacherExams(teacherId));
        }

        [HttpGet]
        [Route("Student")]
        public JsonResult GetAllExamsOfStudent(string studentId)
        {
            return Json(_examService.GetAllStudentExams(studentId));
        }

        [HttpGet]
        [Route("StudentFuture")]
        public JsonResult GetFutureExamsOfStudent(string studentId)
        {
            return Json(_examService.GetFutureStudentExams(studentId));
        }

        [HttpGet]
        [Route("StudentPast")]
        public JsonResult GetPastExamsOfStudent(string studentId)
        {
            return Json(_examService.GetPastStudentExams(studentId));
        }
    }
}