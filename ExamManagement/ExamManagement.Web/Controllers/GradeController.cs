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
    public class GradeController : ControllerBase
    {

        private readonly IGradeRepository _gradeRepository;

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpPost("set")]
        public HttpResponseMessage SetGrade(SetGradeRequest setGradeRequest)
        {
            if (setGradeRequest == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            _gradeRepository.SetGrade(setGradeRequest.GradeID, setGradeRequest.Grade);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
        [HttpPost("get")]
        public ActionResult<Grade> GetGrade(GetGradeRequest getGradeRequest)
        {
            //if (getGradeRequest == null)
            //{
            //    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            //}

            return _gradeRepository.GetGradeByStudentId(getGradeRequest.StudentID, getGradeRequest.ExamID);
        }
    }
}