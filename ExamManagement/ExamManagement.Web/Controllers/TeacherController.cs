using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
using ExamManagement.Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public TeacherController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpPost("CreateExam")]
        public HttpResponseMessage CreateExam(CreateExamRequest createExamRequest)
        {
            if (createExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            Exam tmpExam = new Exam(createExamRequest.CourseID, createExamRequest.ExamDate, createExamRequest.Room, createExamRequest.StartTime, createExamRequest.EndTime, createExamRequest.Type, createExamRequest.CorrectionScore);
            _examRepository.CreateExam(tmpExam);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }


        [HttpPost("StartExam")]
        public HttpResponseMessage StartExam(StartExamRequest startExamRequest)
        {
            if (startExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpPost("EndExam")]
        public HttpResponseMessage EndExam(EndExamRequest endExamRequest)
        {
            if (endExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        [HttpPost("SetGrades")]
        public HttpResponseMessage SetGrades(SetGradeRequest setGradeRequest)
        {
            if (setGradeRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        [HttpPost("PublishGrades")]
        public HttpResponseMessage PublishGrades(PublishAllGradesRequest publishAllGradesRequest)
        {
            if (publishAllGradesRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            _examRepository.PublishGrades(publishAllGradesRequest.ExamID);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}