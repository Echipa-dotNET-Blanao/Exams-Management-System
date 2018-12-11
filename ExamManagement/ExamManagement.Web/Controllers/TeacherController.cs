using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamManagement.Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        [HttpPost("create-exam")]
        public HttpResponseMessage CreateExam(CreateExamRequest createExamRequest)
        {
            if(createExamRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
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
        [HttpPost("set-grades")]
        public HttpResponseMessage SetGrades(SetGradeRequest setGradeRequest)
        {
            if (setGradeRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        [HttpPost("publish-grades")]
        public HttpResponseMessage PublishGrades(SetGradeRequest setGradeRequest)
        {
            if (setGradeRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}