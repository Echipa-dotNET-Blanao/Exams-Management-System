using System;
using System.Net.Http;
using ExamManagement.Core.Interfaces;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : Controller
    {

        private readonly IGradeRepository _gradeRepository;

        public GradesController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        [HttpPut]
        public HttpResponseMessage UpdateGrade([FromBody] UpdateGradeRequest setGradeRequest)
        {
            if (setGradeRequest == null) throw new ArgumentNullException(nameof(setGradeRequest));

            _gradeRepository.SetGrade(setGradeRequest.GradeID, setGradeRequest.Grade);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        [HttpGet("{examId}/{studentId}")]
        public JsonResult GetGrade(int examId, string studentId)
        {
            if (studentId == null) throw new ArgumentNullException(nameof(studentId));

            if (examId <= 0) throw new ArgumentOutOfRangeException(nameof(examId));

            return Json(_gradeRepository.GetGradeByStudentId(studentId, examId));
        }
    }
}
