using System;

namespace AuthService.DataLayer
{
    public class Student
    {
        public Student(string id, string email, string passwordBase, string passwordHash, string fullName, int studyYear, string studyGroup)
        {
            this.Id = id;
            this.Email = email;
            this.PasswordBase = passwordBase;
            this.PasswordHash = passwordHash;
            this.FullName = fullName;
            this.StudyYear = studyYear;
            this.StudyGroup = studyGroup;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordBase { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public int StudyYear { get; set; }
        public string StudyGroup { get; set; }
    }
}
