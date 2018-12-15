using System;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        public HttpResponseMessage CreateExam([FromQuery] CreateExamRequest createExamRequest)
        {
            if (createExamRequest == null) throw new ArgumentNullException(nameof(createExamRequest));

            _examService.CreateExam(new Core.Entities.Exam(createExamRequest.CourseID, createExamRequest.ExamDate, createExamRequest.Room,
                createExamRequest.StartTime, createExamRequest.EndTime, createExamRequest.CorrectionScorePostDate, createExamRequest.Type,
                createExamRequest.CorrectionScore));

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPut]
        public HttpResponseMessage ManageExam([FromQuery] ManageExamRequest manageExamRequest)
        {
            if (manageExamRequest == null) throw new ArgumentNullException(nameof(manageExamRequest));

            _examService.ManageExam(manageExamRequest.ExamID, manageExamRequest.Task);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}