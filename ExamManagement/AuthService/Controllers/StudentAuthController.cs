using System;
using AuthService.BusinessLayer.Service;
using AuthService.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentAuthController : ControllerBase
    {
        private IStudentAuthService studentAuthService;

        public StudentAuthController(IStudentAuthService studentAuthService)
        {
            this.studentAuthService = studentAuthService;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public String AuthStudent([FromBody] AuthStudentRequest authStudentRequest)
        {
            return studentAuthService.authStudent(authStudentRequest).ToString();
        }
    }
}
