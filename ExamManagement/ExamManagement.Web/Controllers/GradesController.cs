using System;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : Controller
    {

        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        [HttpPut]
        public HttpResponseMessage UpdateGrade([FromBody] UpdateGradeRequest setGradeRequest)
        {
            _gradeService.SetGrade(setGradeRequest.GradeID, setGradeRequest.Grade);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        [HttpGet]
        public JsonResult GetGrade([FromQuery] GetGradeRequest getGradeRequest)
        {
            return Json(_gradeService.GetGradeByStudentId(getGradeRequest.StudentID, getGradeRequest.ExamID));
        }
    }
}
