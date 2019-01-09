using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.BusinessLayer.Service;
using AuthService.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAuthController : ControllerBase
    {
        private IStudentAuthService studentAuthService;

        public StudentAuthController(IStudentAuthService studentAuthService)
        {
            this.studentAuthService = studentAuthService;
        }

        // GET: api/StudentAuth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST: api/StudentAuth
        [HttpPost]
        public String AuthStudent([FromBody] AuthStudentRequest authStudentRequest)
        {
            return studentAuthService.authStudent(authStudentRequest).ToString();
        }
    }
}
