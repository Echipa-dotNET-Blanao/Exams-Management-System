using System.Net;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPut]
        public HttpResponseMessage UpdateGrade([FromBody] UpdateGradeRequest setGradeRequest)
        {
            _gradeService.SetGrade(setGradeRequest.GradeId, setGradeRequest.Grade);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public JsonResult GetGrade([FromQuery] GetGradeRequest getGradeRequest)
        {
            return Json(_gradeService.GetGradeByStudentId(getGradeRequest.StudentId, getGradeRequest.ExamId));
        }

        [Route("All")]
        [HttpGet]
        [EnableCors("MyPolicy")]
        public JsonResult GetAllGradesForExam(int examId)
        {
            return Json(_gradeService.GetAllExamGrades(examId));
        }
    }
}