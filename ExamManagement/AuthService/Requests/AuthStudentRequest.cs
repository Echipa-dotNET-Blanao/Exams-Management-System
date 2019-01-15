using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Requests
{
    public class AuthStudentRequest
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
