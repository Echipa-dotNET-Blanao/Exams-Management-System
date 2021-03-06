﻿using Newtonsoft.Json.Linq;
using System;

namespace AuthService.Requests
{
    public class AuthStudentResponse : AuthResponse
    {
        public AuthStudentResponse(string id, string email, string fullName, int studyYear, string studyGroup, bool isStudent)
        {
            this.Id = id;
            this.Email = email;
            this.FullName = fullName;
            this.StudyYear = studyYear;
            this.StudyGroup = studyGroup;
            IsStudent = isStudent;
        }

        private String Id { get; set; }
        private String Email { get; set; }
        private String FullName { get; set; }
        private int StudyYear { get; set; }
        private String StudyGroup { get; set; }
        public bool IsStudent { get; set; }

        public override string ToString()
        {
            dynamic jsonObject = new JObject();
            jsonObject.Id = Id;
            jsonObject.Email = Email;
            jsonObject.FullName = FullName;
            jsonObject.StudyYear = StudyYear;
            jsonObject.StudyGroup = StudyGroup;
            jsonObject.IsStudent = IsStudent;
            return jsonObject.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}
