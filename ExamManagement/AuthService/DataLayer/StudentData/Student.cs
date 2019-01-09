using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.DataLayer
{
    public class Student
    {
        public Student(string id, string email, string passwordBase, string passwordHash, string fullName, int studyYear, string studyGroup)
        {
            this.id = id;
            this.email = email;
            this.passwordBase = passwordBase;
            this.passwordHash = passwordHash;
            this.fullName = fullName;
            this.studyYear = studyYear;
            this.studyGroup = studyGroup;
        }

        public String id { get; set; }
        public String email { get; set; }
        public String passwordBase { get; set; }
        public String passwordHash { get; set; }
        public String fullName { get; set; }
        public int studyYear { get; set; }
        public String studyGroup { get; set; }
    }
}
