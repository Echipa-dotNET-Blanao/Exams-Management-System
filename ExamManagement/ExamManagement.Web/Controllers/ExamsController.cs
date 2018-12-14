using System;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        //TODO : In controllers will never be logic like defensive codding. Move it to repo or where you have the logic of the app.
        //TODO : Also respect naming convensions for the routes and the variables.
        [HttpPost]
        [Route("set/manageExam")]
        public HttpResponseMessage ManageExam([FromBody] ManageExamRequest manageExamRequest)
        {
            if (manageExamRequest == null) throw new ArgumentNullException(nameof(manageExamRequest));

            _examRepository.ManageExam(manageExamRequest.ExamID,manageExamRequest.Task);

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