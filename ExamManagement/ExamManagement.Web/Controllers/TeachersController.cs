using System;
using System.Net.Http;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public TeachersController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/createExam")]
        public HttpResponseMessage CreateExam([FromBody] CreateExamRequest createExamRequest)
        {
            if (createExamRequest == null) throw new ArgumentNullException(nameof(createExamRequest));

            Exam tmpExam = new Exam(createExamRequest.CourseID, createExamRequest.ExamDate, createExamRequest.Room, createExamRequest.StartTime, createExamRequest.EndTime, createExamRequest.Type, createExamRequest.CorrectionScore);

            _examRepository.CreateExam(tmpExam);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/startExam")]
        public HttpResponseMessage StartExam([FromBody] StartExamRequest startExamRequest)
        {
            if (startExamRequest == null) throw new ArgumentNullException(nameof(startExamRequest));

            _examRepository.StartExam(startExamRequest.ExamID);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/endExam")]
        public HttpResponseMessage EndExam([FromBody] EndExamRequest endExamRequest)
        {
            if (endExamRequest == null) throw new ArgumentNullException(nameof(endExamRequest));

            _examRepository.CloseExam(endExamRequest.ExamID);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/publishGrades")]
        public HttpResponseMessage PublishGrades([FromBody] PublishAllGradesRequest publishAllGradesRequest)
        {
            if (publishAllGradesRequest == null) throw new ArgumentNullException(nameof(publishAllGradesRequest));

            _examRepository.PublishGrades(publishAllGradesRequest.ExamID);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}