using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Requests
{
    public class AuthStudentRequest
    {
        public String id { get; set; }
        public String password { get; set; }
    }
}
