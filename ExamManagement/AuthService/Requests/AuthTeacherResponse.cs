using Newtonsoft.Json.Linq;
using System;

namespace AuthService.Requests
{
    public class AuthTeacherResponse : AuthResponse
    {
        public AuthTeacherResponse(int id, string email, string fullName)
        {
            this.Id = id;
            this.Email = email;
            this.FullName = fullName;
        }

        private int Id { get; set; }
        private string Email { get; set; }
        private string FullName { get; set; }

        public override string ToString()
        {
            dynamic jsonObject = new JObject();
            jsonObject.Id = Id;
            jsonObject.Email = Email;
            jsonObject.FullName = FullName;
            return jsonObject.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}
