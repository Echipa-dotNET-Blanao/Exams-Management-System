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

        [HttpPost("create-exam")]
        public HttpResponseMessage CreateExam(CreateExamRequest createExamRequest)
        {
            if(createExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            Exam tmpExam = new Exam(1, createExamRequest.CourseID, createExamRequest.ExamDate, createExamRequest.Room, createExamRequest.StartTime, createExamRequest.EndTime, createExamRequest.Type);
            _examRepository.CreateExam(_examRepository.CreateExam(tmpExam));
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        
        [HttpPost("start-exam")]
        public HttpResponseMessage StartExam(StartExamRequest startExamRequest)
        {
            if(startExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpPost("end-exam")]
        public HttpResponseMessage EndExam(EndExamRequest endExamRequest)
        {
            if(endExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        
    }
}