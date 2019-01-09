using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Requests
{
    public class AuthStudentResponse
    {
        public AuthStudentResponse(string id, string email, string fullName, int studyYear, string studyGroup)
        {
            this.id = id;
            this.email = email;
            this.fullName = fullName;
            this.studyYear = studyYear;
            this.studyGroup = studyGroup;
        }

        private String id { get; set; }
        private String email { get; set; }
        private String fullName { get; set; }
        private int studyYear { get; set; }
        private String studyGroup { get; set; }

        public override string ToString()
        {
            dynamic jsonObject = new JObject();
            jsonObject.id = id;
            jsonObject.email = email;
            jsonObject.fullName = fullName;
            jsonObject.studyYear = studyYear;
            jsonObject.studyGroup = studyGroup;
            return jsonObject.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}
