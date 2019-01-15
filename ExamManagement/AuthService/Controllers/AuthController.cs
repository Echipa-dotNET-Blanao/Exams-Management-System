using System;
using AuthService.BusinessLayer.Service;
using AuthService.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService studentAuthService;

        public AuthController(IAuthService studentAuthService)
        {
            this.studentAuthService = studentAuthService;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public String AuthStudent([FromBody] AuthRequest authStudentRequest)
        {
            return studentAuthService.Auth(authStudentRequest).ToString();
        }
    }
}
